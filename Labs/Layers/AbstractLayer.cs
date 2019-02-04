using Labs.MapObjects;
using Labs.MapObjects.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labs.Layers
{
    public abstract class AbstractLayer
    {
        public List<MapObject> Objects;

        protected bool visible;
        public bool Visible
        {
            set
            {
                visible = value;
                map.Refresh();
            }
            get
            {
                return visible;
            }
        }

        protected GeoRect bounds = new GeoRect(0, 0, 0, 0);
        public GeoRect Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
                bounds = value;
            }
        }

        internal MAP map;
        public string Name { get; set; }
        public string FileName { get; set; }

        public AbstractLayer()
        {
            Objects = new List<MapObject>();
            visible = true;
        }

        public abstract void LoadFromFile(string fileName);

        public abstract void Draw(PaintEventArgs e);

        internal abstract void AddObject(MapObject Object);

        internal abstract void Split(List<string> list);

        internal MapObject FindObject(GeoRect SelectPoint)
        {
            MapObject result = null;
            if (visible)
            {
                for (int i = Objects.Count - 1; i >= 0; i--)
                {
                    result = Objects[i];
                    if (result.isCross(SelectPoint))
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        internal void ChangeStyleFunction(string FontName, int PointSize,
            int PointNumber, System.Drawing.Color PointColor,
            int LineWidth, System.Drawing.Color LineColour,
            System.Drawing.Color PolygonColour, System.Drawing.Color BorderColor)
        {
            for (int i = Objects.Count - 1; i >= 0; i--)
            {
                if (Objects[i].selected)
                {
                    Objects[i].ChangeStyleFunction(FontName, PointSize, PointNumber, PointColor,
                                                   LineWidth, LineColour, PolygonColour, BorderColor);
                }

            }
        }        


    }
}
