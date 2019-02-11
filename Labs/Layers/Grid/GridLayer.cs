using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Labs.MapObjects;
using Labs.MapObjects.Images;
using Labs.MapObjects.Points;
using Labs.MapObjects.Shapes;

namespace Labs.Layers.Grid
{
    public class GridLayer: AbstractLayer
    {
        private GridGeometry gridGeometry;

        private double XMin
        {
            get
            {
                return gridGeometry.XMin;
            }
            set
            {
                value = 0.0;
            }
        }
        private double YMin
        {
            get
            {
                return gridGeometry.YMin;
            }
            set
            {
                value = 0.0;
            }
        }
        private double XMax
        {
            get
            {
                return gridGeometry.XMax;
            }
            set
            {
                value = 0.0;
            }
        }
        private double YMax
        {
            get
            {
                return gridGeometry.YMax;
            }
            set
            {
                value = 0.0;
            }
        }
        private int CountX => gridGeometry.CountX;
        private int CountY => gridGeometry.CountY;
        private double Cell => gridGeometry.Cell;

        private Bitmap bitmap;

        private double?[,] matrix;

        private Color colorMin;
        public Color ColorMin
        {
            get
            {

                return colorMin;
            }
            set
            {
                colorMin = value;
                needRecoloring = true;
            }
        }
        private Color colorMax;
        public Color ColorMax
        {
            get
            {

                return colorMax;
            }
            set
            {
                colorMax = value;
                needRecoloring = true;
            }
        }
        private bool needRecoloring;

        private double zMin;
        private double zMax;

        public GridLayer(GridGeometry gridGeometry, MAP map)
        {
            this.gridGeometry = gridGeometry;
            this.map = map;
            matrix = new double?[CountY, CountX];
            needRecoloring = true;
        }

        public override void Draw(PaintEventArgs e)
        {
            if (bitmap == null)
                bitmap = new Bitmap(CountX - 1, CountY - 1);
            //updateZminZmax(); tak ostabit'

            if (needRecoloring)
                Recoloring();

            //Graphics g = e.Graphics;
            System.Drawing.Point leftTop = map.MapToScreen(new GeoPoint(XMin, YMax));            
            System.Drawing.Point rightBottom = map.MapToScreen(new GeoPoint(XMax, YMin));
            Rectangle rect = new Rectangle(leftTop.X, leftTop.Y, rightBottom.X - leftTop.X, rightBottom.Y - leftTop.Y);

            CustomBitmap bmp = new CustomBitmap(bitmap, new MapObjects.Points.GeoPoint(rect.X, rect.Y) , rect.Width, rect.Height);
            bmp.Draw(e);            
        }

        public void DoInterpolation(List<GeoPoint> points, double searchRadius, int power)
        {
            double searchRadius2 = searchRadius * searchRadius;
            for (int i = 0; i < CountY; i++)
            {
                for (int j = 0; j < CountX; j++)
                {
                    double x = (XMin + Cell * j);
                    double y = (YMin + Cell * i);
                    double sum1 = 0;
                    double sum2 = 0;
                    bool isFind = false;
                    foreach (GeoPoint point in points)
                    {
                        double r2 = (x - point.x) * (x - point.x) + (y - point.y) * (y - point.y);
                        if (r2 < double.Epsilon)
                        {
                            //Matrix[i, j] = point.Z;
                            isFind = true;
                            sum1 = point.z;
                            sum2 = 1;
                            break;
                        }
                        if (r2 <= searchRadius2)
                        {
                            isFind = true;
                            double rp = Math.Pow(Math.Sqrt(r2), power);
                            sum1 += point.z / rp;
                            sum2 += 1 / rp;
                        }
                    }
                    if (isFind)
                    {
                        this.matrix[i, j] = sum1 / sum2;
                    }
                    else
                    {
                        this.matrix[i, j] = null;
                    }
                }
            }
            updateZminZmax();
            needRecoloring = true;
        }

        private void Recoloring()
        {
            for (int i = 0; i < this.matrix.GetLength(0) - 1; i++)
                for (int j = 0; j < this.matrix.GetLength(1) - 1; j++)
                {
                    var z = this.matrix[i, j];
                    Color color = GetColorForValue(z);
                    bitmap.SetPixel(j, bitmap.Height - i - 1, color);
                }
            needRecoloring = false;
        }

        private Color GetColorForValue(double? z)
        {
            if (z == null) return Color.Red;
            if (zMax - zMin < double.Epsilon) return ColorMin;
            int colorMinR = ColorMin.R;
            int colorMaxR = ColorMax.R;
            int colorMinG = ColorMin.G;
            int colorMaxG = ColorMax.G;
            int colorMinB = ColorMin.B;
            int colorMaxB = ColorMax.B;
            int colorR = (int)((z - zMin) * (colorMaxR - colorMinR) / (zMax - zMin) + colorMinR + 0.5);
            int colorG = (int)((z - zMin) * (colorMaxG - colorMinG) / (zMax - zMin) + colorMinG + 0.5);
            int colorB = (int)((z - zMin) * (colorMaxB - colorMinB) / (zMax - zMin) + colorMinB + 0.5);
            return Color.FromArgb(colorR, colorG, colorB);
        }

        public override void LoadFromFile(string fileName)
        {
            string[] patterns = { @"XMin: -?\d+.?d*", @"YMin: -?\d+.?d*", @"CountX: \d+", @"CountY: \d+", @"Cell: \d+", @"Matrix: ", @"(-?\d+.?d*)|null" };
            Regex regex = null;
            StreamReader fs = new StreamReader(fileName);
            string line = "";
            int index = 0;
            int j = 0;
            double number;

            Name = Path.GetFileNameWithoutExtension(fileName);

            while (line != null)
            {
                line = fs.ReadLine();
                if (index <= 5)
                {
                    regex = new Regex(patterns[index]);
                    if (regex.Match(line).Success == false) throw new Exception("Ошибка открытия файла");
                }
                switch (index)
                {
                    case (0):
                        gridGeometry.XMin = Convert.ToDouble(Regex.Match(regex.Match(line).Value, @"-?\d+.?d*").Value);
                        break;
                    case (1):
                        gridGeometry.YMin = Convert.ToDouble(Regex.Match(regex.Match(line).Value, @"-?\d+.?d*").Value);
                        break;
                    case (2):
                        gridGeometry.CountX = Convert.ToInt32(Regex.Match(regex.Match(line).Value, @"\d+").Value);
                        break;
                    case (3):
                        gridGeometry.CountY = Convert.ToInt32(Regex.Match(regex.Match(line).Value, @"\d+").Value);
                        matrix = new double?[gridGeometry.CountY, gridGeometry.CountX];
                        break;
                    case (4):
                        gridGeometry.Cell = Convert.ToInt32(Regex.Match(regex.Match(line).Value, @"\d+").Value);
                        break;
                    case (5):
                        break;
                    default:
                        if (line != null)
                        {
                            string[] matrix = line.Split(' ');
                            for (int i = 0; i < matrix.Length - 1; i++)
                            {
                                if (!double.TryParse(matrix[i], out number)) this.matrix[j, i] = null;
                                else this.matrix[j, i] = Convert.ToDouble(matrix[i]);
                            }
                            j++;
                        }
                        break;
                }
                index++;
            }
            updateZminZmax();
        }

        private void updateZminZmax()
        {
            zMin = -1000;
            zMax = 1000;
            //HasData = false;

            for (int i = 0; i < this.matrix.GetLength(0); i++)
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    var z = this.matrix[i, j];

                    if (z != null)
                    {
                        //HasData = true;
                        zMin = Math.Min(zMin, (double)z);
                        zMax = Math.Max(zMax, (double)z);
                    }
                }
        }        

        internal override void AddObject(MapObject Object)
        {
            bounds = GeoRect.Union(bounds, Object.Bounds);
            Objects.Add(Object);
            Object.layer = this;
        }

        internal override void Split(List<string> list)
        {
            throw new NotImplementedException();
        }

    }
}
