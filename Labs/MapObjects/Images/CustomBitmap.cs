using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Labs.MapObjects.Shapes;
using Labs.MapObjects.Points;

namespace Labs.MapObjects.Images
{
    public class CustomBitmap : MapObject
    {
        public Bitmap bmp;
        private GraphicsUnit units;
        private RectangleF srcRect;
        private double Xmin, Ymin, Xmax, Ymax;


        public CustomBitmap(Labs.MapObjects.Points.GeoPoint startPoint, int width, int height)
        {
            bmp = new Bitmap(width, height);
            units = GraphicsUnit.Pixel;
            srcRect = new RectangleF((float)Xmin, (float)Ymin, width, height);
            Xmin = startPoint.x;
            Ymin = startPoint.y;
            Xmax = width;
            Ymax = height;

            Random random = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int a = random.Next(256);
                    int r = random.Next(256);
                    int g = random.Next(256);
                    int b = random.Next(256);

                    bmp.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                    //bmp.SetPixel(j, i, Color.Blue);
                }
            }
        }

        protected override GeoRect GetBounds()
        {
            return (new GeoRect(Xmax, Xmin, Ymin, Ymax));
        }

        internal override void ChangeStyleFunction(string FontName, int PointSize, int PointNumber, Color PointColor, int LineWidth, Color LineColour, Color PolygonColour, Color BorderColor)
        {
            throw new NotImplementedException();
        }

        internal override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, (float)Xmin, (float)Ymin, srcRect, units);
        }

        internal override bool isCross(GeoRect SelectPoint)
        {
            throw new NotImplementedException();
        }
    }
}
