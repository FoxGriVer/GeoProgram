using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Labs.MapTypes;
using Labs.MapObjects;
using Labs.MapObjects.Shapes;
using Labs.MapObjects.Points;
using Labs.MapObjects.Lines;
using Labs.Layers;
using Labs.Layers.Vector;

namespace Labs
{
    public partial class MAP : UserControl
    {
        public MAP()
        {
            InitializeComponent();
            Layers = new List<AbstractLayer>();
            visible = true;
            mapScale = 1;
            mapCenter = new GeoPoint(0, 0);
            ActiveTool = MapToolType.select;
        }        

        public LayerControl LayerControl;
        
        new public GeoRect Bounds
        {
            get
            {
                GeoRect result = new GeoRect(0,0,0,0);
                foreach (AbstractLayer layer in Layers)
                {
                    if (layer.Visible)
                    {
                        result = GeoRect.Union(result, layer.Bounds);
                    }
                }
                return result;
            }
        }

        public MapToolType ActiveTool;

        private double mapScale;

        public double MapScale
        {
            get
            {
                return mapScale;
            }
            set
            {
                mapScale = value;
                Refresh();
            }
        }

        public System.Drawing.Point MapToScreen(GeoPoint Point)
        {
            if (mapScale > 10 || mapScale < 0.5) mapScale = 1;
            System.Drawing.Point Result = new System.Drawing.Point();
            Result.X = (int)((Point.x - mapCenter.x) * mapScale + Width / 2 + 0.5);
            Result.Y = (int)(-(Point.y - mapCenter.y) * mapScale + Height / 2 + 0.5);
            return  Result;
        }

        public GeoPoint ScreenToMap(System.Drawing.Point Point)
        {
            GeoPoint Result = new GeoPoint(0, 0);

            Result.x = (Point.X - Width / 2) / mapScale + mapCenter.x;
            Result.y = -(Point.Y - Height / 2) / mapScale + mapCenter.y;

            return Result;
        }

        private GeoPoint mapCenter;

        public GeoPoint MapCenter
        {
            get
            {
                return mapCenter;
            }
            set
            {
                mapCenter = value;
                Refresh();
            }
        }

        public string FileName;

        public string MapName;

        public void LoadFromFile(string filName)
        { 
            try
            {
                //todo самостоятельно
                FileName = filName;
                MapName = Path.GetFileNameWithoutExtension(filName);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool visible;

        public void SaveToFile(string filName)
        {
            try
            {
                //todo самостоятельно
                FileName = MapName;
                MapName = Path.GetFileNameWithoutExtension(filName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AbstractLayer> Layers;


        public void InsertLayers(int Index, AbstractLayer Layer)
        {
            Layers.Insert(Index, Layer);
        }

        public void DeleteLayer(int Index)
        {
            if (Layers.Count >= Index)
            {
                Layers.RemoveAt(Index);
            }
            else return;
        }
        public void Delete(AbstractLayer layer)
        {
            Layers.Remove(layer);
        }
        public void AddLayer(AbstractLayer Layer)
        {
            Layers.Add(Layer);
            if (LayerControl != null)
            {
                LayerControl.RefreshList();
            }

            Layer.map = this;
            
        }
        
        public int LayersCount
        {
            get
            {
                return Layers.Count;
            }
        }

        public void Map_Paint(object sender, PaintEventArgs e)
        {
            foreach (AbstractLayer layer in Layers)
            {
                if (layer.Visible==true)
                {
                    layer.Draw(e);
                }
            }
        }

        private bool isMouseDown = false;

        private System.Drawing.Point mouseDownPosition;

        private void MAP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
            mouseDownPosition = e.Location;
            switch (ActiveTool)
            {
                case MapToolType.select:
                    break;
                case MapToolType.zoomin:
                    break;
                case MapToolType.zoomout:
                    break;
                case MapToolType.pan:
                    break;
                default:
                    break;
            }
            isMouseDown = true;
            }
        }

        const int SHAKE=10;
        public const int searchrect = 2;
        public Color SelectedColour = Color.BlueViolet;
        

        private void MAP_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            GeoPoint p = ScreenToMap(mouseDownPosition);
            switch (ActiveTool)
            {

                case MapToolType.select:

                    int Dx1 = e.X - mouseDownPosition.X;
                    int Dy1 = e.Y - mouseDownPosition.Y;
                    GeoPoint searchCenter = ScreenToMap(e.Location);
                    //хщ? * and /

                    GeoRect search = new GeoRect(searchCenter.x - searchrect / mapScale,
                                                 searchCenter.x + searchrect / mapScale,
                                                 searchCenter.y - searchrect / mapScale,
                                                 searchCenter.y + searchrect / mapScale);
                    
                    if (Math.Abs(Dx1) < SHAKE || Math.Abs(Dy1) < SHAKE)
                    {
                        MapObject searchObj = FindObject(search);
                        if ( searchObj != null )
                        {
                            if (!IsControlPressed)
                            {
                                for (int c = Layers.Count - 1; c >= 0; c--)
                                {
                                    for (int j = Layers[c].Objects.Count - 1; j >= 0; j--)
                                    {
                                        Layers[c].Objects[j].selected = false;
                                    }
                                }
                            }

                            if (searchObj.selected)
                            {
                                searchObj.selected = false;
                            }
                            else
                            {
                                searchObj.selected = true;
                            }
                        }
                        else if (!IsControlPressed)
                        {
                            for (int c = Layers.Count - 1; c >= 0; c--)
                            {
                                for (int j = Layers[c].Objects.Count - 1; j >= 0; j--)
                                {
                                    Layers[c].Objects[j].selected = false;
                                }
                            }
                        }

                        Refresh();
                    }

                    break;

                case MapToolType.zoomin:
                    double Dx2 = e.X - mouseDownPosition.X;
                    double Dy2 = e.Y - mouseDownPosition.Y;
                    if (Math.Abs(Dx2) > SHAKE || Math.Abs(Dy2) > SHAKE)
                    {
                        System.Drawing.Point newCenter = new System.Drawing.Point((mouseDownPosition.X+e.X)/2,
                            (mouseDownPosition.Y+e.Y)/2);
                        mapCenter = ScreenToMap(newCenter);
                        if (Width / Math.Abs(Dx2) < Height / Math.Abs(Dy2))
                            MapScale *= Width * 0.95 / Math.Abs(Dx2);
                        else MapScale *= Height * 0.95 / Math.Abs(Dy2);
                        Delete(Cosmetic);
                        Cosmetic.Objects.Remove(border);
                        Refresh();
                    }
                    else
                    {
                        mapCenter.x = p.x;
                        mapCenter.y = p.y;
                        MapScale *= 1.25;
                    }
                    break;
                case MapToolType.zoomout:
                    int Dx3 = e.X - mouseDownPosition.X;
                    int Dy3 = e.Y - mouseDownPosition.Y;
                    if (Math.Abs(Dx3) > SHAKE || Math.Abs(Dy3) > SHAKE)
                    {
                        //TODO рамка
                    }
                    else
                    {
                        mapCenter.x = p.x;
                        mapCenter.y = p.y;
                        MapScale /= 1.25;
                    }
                    break;
                case MapToolType.pan:
                    break;
                default:
                    break;
            }
        }


        public VectorLayer Cosmetic = new VectorLayer();
        public PolyLine border = new PolyLine();
        private void MAP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isMouseDown)
                {
                    switch (ActiveTool)
                    {
                        case MapToolType.select:
                            break;
                        case MapToolType.zoomin:
                            double Dx2 = e.X - mouseDownPosition.X;
                            double Dy2 = e.Y - mouseDownPosition.Y;
                            if (Math.Abs(Dx2) > SHAKE || Math.Abs(Dy2) > SHAKE)
                            {
                                Delete(Cosmetic);
                                Cosmetic.Objects.Remove(border);
                                border = new PolyLine();
                                border.Style.Fatness = 1;
                                border.Style.LColour = Color.Aqua;
                                GeoPoint first = ScreenToMap(mouseDownPosition);
                                GeoPoint second = ScreenToMap(e.Location);
                                border.AddNode(first);
                                border.AddNode(new GeoPoint(second.x, first.y));
                                border.AddNode(second);
                                border.AddNode(new GeoPoint(first.x, second.y));
                                border.AddNode(first);
                                Cosmetic.AddObject(border);
                                Cosmetic.Name = "Рамка";
                                AddLayer(Cosmetic);
                                Refresh();                              
                            }
                            break;
                        case MapToolType.zoomout:
                            break;
                        case MapToolType.pan:
                            double Dx = (e.X - mouseDownPosition.X) / mapScale;
                            double Dy = (e.Y - mouseDownPosition.Y) / mapScale;
                            mapCenter.x -= Dx;
                            mapCenter.y += Dy;
                            this.Refresh();
                            mouseDownPosition = e.Location;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        internal void ZoomToAll()
        {
            //ветки: менять только цетр (1 точка); изменение масштаба по ширине (линия); высоте (линия); общий случай
            GeoRect rect = Bounds;
            mapCenter.x = (rect.Xmax + rect.Xmin) / 2;
            mapCenter.y = (rect.Ymax + rect.Ymin) / 2;
            double rx = Width / (rect.Xmin - rect.Xmax) * 0.80;
            double ry = Height / (rect.Ymax - rect.Ymin) * 0.80;

            if (rx < ry) MapScale = rx;
            else MapScale = ry;
        }


        public MapObject FindObject(GeoRect SelectPoint)
        {
            MapObject result = null;
            for (int i = Layers.Count - 1; i >= 0; i--)
            {
                result = Layers[i].FindObject(SelectPoint);
                if (result != null)
                {
                    Refresh();
                    return result;
                }
            }

            Refresh();
            return null;
        }

        internal void ChangeStyleFunction(string FontName, int PointSize, int PointNumber, Color PointColor,
                                          int LineWidth, Color LineColour, Color PolygonColour, Color BorderColor)
        {
            for (int i = Layers.Count - 1; i >= 0; i--)
            {
                Layers[i].ChangeStyleFunction(FontName, PointSize, PointNumber, PointColor,
                                          LineWidth, LineColour, PolygonColour, BorderColor);
            }

            Refresh();
        }

        private bool IsControlPressed = false;

        private void MAP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 17 || e.KeyValue == 16) IsControlPressed = true;
        }

        private void MAP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 17 || e.KeyValue == 16) IsControlPressed = false;
        }
    }
}
