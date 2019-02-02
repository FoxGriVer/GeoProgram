using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Labs.MapObjects;
using Labs.MapObjects.Shapes;
using Labs.MapObjects.Points;
using Labs.MapObjects.Lines;

namespace Labs.Layers.Vector
{
    public class VectorLayer: AbstractLayer
    {
        public VectorLayer()
        {
            
        }        

        public override void LoadFromFile(string filename)
        {
            System.IO.StreamReader FileText = new System.IO.StreamReader(filename);
            string TempLine;
            List<string> DataStrings = new List<string>();
            bool DataBegin = false;
            Name = Path.GetFileNameWithoutExtension(filename);
            while ((TempLine = FileText.ReadLine()) != null)
            {
                TempLine = TempLine.ToLower();
                if ((DataBegin == true) && (TempLine != ""))
                {
                    DataStrings.Add(TempLine);
                }
                if (TempLine == "data")
                {
                    DataBegin = true;
                }
            }
            List<string> SeparatorArray;
            char[] SeparatorSymbols = new char[] { ',', ' ', '(', ')' };
            char[] SeparatorSymbolsCoord = new char[] { ' ', '(', ')' };
            for (int i = 0; i < DataStrings.Count; i++)
            {
                SeparatorArray = (DataStrings[i].Split(SeparatorSymbolsCoord)).ToList();
                Split(SeparatorArray);

                double x, y, z;
                if (SeparatorArray.Count > 0)
                {
                    switch (SeparatorArray[0])
                    {

                        case "point":
                            ConvertPointInCorrectFormat(SeparatorArray);
                            x = double.Parse(SeparatorArray[1].Replace('.', ','));
                            y = double.Parse(SeparatorArray[2].Replace('.', ','));
                            z = double.Parse(SeparatorArray[3].Replace('.', ','));
                            Point point = new Point(x, y, z);
                            CountHeightAndConvert(point);                            

                            AddObject(point);
                            break;

                        case "line":
                            double x1, y1;
                            x = double.Parse(SeparatorArray[1].Replace('.', ','));
                            y = double.Parse(SeparatorArray[2].Replace('.', ','));
                            x1 = double.Parse(SeparatorArray[3].Replace('.', ','));
                            y1 = double.Parse(SeparatorArray[4].Replace('.', ','));
                            Line line = new Line(new GeoPoint(x, y), new GeoPoint(x1, y1));
                            if ((i + 1) < DataStrings.Count)
                            {
                                SeparatorArray = (DataStrings[i + 1].Split(SeparatorSymbols)).ToList();
                                Split(SeparatorArray);
                                if (SeparatorArray[0] == "pen")
                                {
                                    i++;
                                    line.Style.Fatness = int.Parse(SeparatorArray[1]);
                                    line.Style.Type = int.Parse(SeparatorArray[2]);
                                    int Colour = int.Parse(SeparatorArray[3]);
                                    line.Style.LColour = System.Drawing.Color.FromArgb((Colour & 0xFF0000) / 65536,
                                                                                        (Colour & 0xFF00) / 256,
                                                                                        (Colour & 0xFF));
                                }
                            }
                            AddObject(line);
                            break;

                        case "pline":
                            i++;
                            SeparatorArray = (DataStrings[i].Split(SeparatorSymbols)).ToList();
                            Split(SeparatorArray);
                            int count = int.Parse(SeparatorArray[0]);
                            PolyLine ponyline = new PolyLine();
                            for (int k = 0; k < count; k++)
                            {
                                i++;
                                SeparatorArray = (DataStrings[i].Split(SeparatorSymbolsCoord)).ToList();
                                Split(SeparatorArray);
                                x = double.Parse(SeparatorArray[0].Replace('.', ','));
                                y = double.Parse(SeparatorArray[1].Replace('.', ','));
                                ponyline.AddNode(new GeoPoint(x, y));
                                if ((i + 1) < DataStrings.Count && (k == count - 1))
                                {
                                    SeparatorArray = (DataStrings[i + 1].Split(SeparatorSymbols)).ToList();
                                    Split(SeparatorArray);
                                    if (SeparatorArray[0] == "pen")
                                    {
                                        i++;
                                        ponyline.Style.Fatness = int.Parse(SeparatorArray[1]);
                                        ponyline.Style.Type = int.Parse(SeparatorArray[2]);
                                        int Colour = int.Parse(SeparatorArray[3]);
                                        ponyline.Style.LColour = System.Drawing.Color.FromArgb((Colour & 0xFF0000) / 65536,
                                                                                            (Colour & 0xFF00) / 256,
                                                                                            (Colour & 0xFF));
                                    }
                                }
                                AddObject(ponyline);
                            }




                            break;

                        case "region":

                            i++;
                            SeparatorArray = (DataStrings[i].Split(SeparatorSymbols)).ToList();
                            Split(SeparatorArray);
                            count = int.Parse(SeparatorArray[0]);
                            Polygone ponygnya = new Polygone();
                            for (int k = 0; k < count; k++)
                            {
                                i++;
                                SeparatorArray = (DataStrings[i].Split(SeparatorSymbolsCoord)).ToList();
                                Split(SeparatorArray);
                                x = double.Parse(SeparatorArray[0].Replace('.', ','));
                                y = double.Parse(SeparatorArray[1].Replace('.', ','));
                                ponygnya.AddNode(new GeoPoint(x, y));
                                if ((i + 1) < DataStrings.Count && (k == count - 1))
                                {
                                    SeparatorArray = (DataStrings[i + 1].Split(SeparatorSymbols)).ToList();
                                    Split(SeparatorArray);
                                    if (SeparatorArray[0] == "pen")
                                    {
                                        i++;
                                        ponygnya.Style.Fatness = int.Parse(SeparatorArray[1]);
                                        ponygnya.Style.Type = int.Parse(SeparatorArray[2]);
                                        int Colour = int.Parse(SeparatorArray[3]);
                                        ponygnya.Style.LColour = System.Drawing.Color.FromArgb((Colour & 0xFF0000) / 65536,
                                                                                            (Colour & 0xFF00) / 256,
                                                                                            (Colour & 0xFF));
                                    }
                                }
                                if ((i + 1) < DataStrings.Count && (k == count - 1))
                                {
                                    SeparatorArray = (DataStrings[i + 1].Split(SeparatorSymbols)).ToList();
                                    Split(SeparatorArray);
                                    if (SeparatorArray.Count >0)
                                    {
                                        if (SeparatorArray[0] == "brush")
                                        {
                                            i++;
                                            int Colour = int.Parse(SeparatorArray[2]);
                                            ponygnya.Brush.Color = System.Drawing.Color.FromArgb((Colour & 0xFF0000) / 65536,
                                                                                                (Colour & 0xFF00) / 256,
                                                                                                (Colour & 0xFF));
                                        }                                       
                                    }

                                }
                            }
                            AddObject(ponygnya);
                            break;

                        default: break;
                    }
                }
                

            }   
        }        

        public void SaveToFile(string filName)
        {
            try
            {
                //todo самостоятельно
                FileName = Name;
                Name = Path.GetFileNameWithoutExtension(filName);
            }
            catch (Exception)
            {

                throw;
            }
        }        

        public void InsertObject(int Index, MapObject Object)
        {
            Objects.Insert(Index, Object);
        }

        public void DeleteObject(int Index)
        {
            //реализации коррекции bounds
            if (Objects.Count >= Index)
            {
                Objects.RemoveAt(Index);                
            }
            else return;
        }

        private void CountHeightAndConvert(Point point)
        {
            double zMin = -1000;
            double zMax = 1000;

            int minFont = 4;
            int maxFont = 16;
            int font = 0;
            double coefficient;

            if (zMin < 0)
            {
                double middleZ = (Math.Abs(zMin) + zMax) / 2;
                coefficient = (point.location.z + middleZ) / (Math.Abs(zMin) + zMax);
            }
            else
            {
                coefficient = (point.location.z) / (zMin + zMax);
            }
            font = (int)((minFont + maxFont) * coefficient);

            point.Style.Size = font;
        }

        internal override void AddObject(MapObject Object)
        {
            bounds = GeoRect.Union(bounds, Object.Bounds);
            Objects.Add(Object);
            Object.layer = this;
        }

        internal override void Split(List<string> list)
        {
            for (int j = 0; j < list.Count(); j++)
            {
                if (list[j] == "")
                {
                    list.RemoveAt(j);
                    j--;
                }
            }
        }

        public int ObjectsCount
        {
            get
            {
                return Objects.Count;
            }
        }

        private void ConvertPointInCorrectFormat(List<string> list)
        {
            for (int j = 0; j < list.Count(); j++)
            {
                list[j] = list[j].TrimEnd(new Char[] { ',', ';' });
            }
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            foreach (MapObject obj in Objects)
            {
                obj.Draw(e); 
            }
        }
        
    }
}
