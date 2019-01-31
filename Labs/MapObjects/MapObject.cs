using Labs.Layers.Vector;
using Labs.MapObjects.Shapes;
using Labs.MapTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   
namespace Labs.MapObjects
{
    public abstract class MapObject
    {
        public VectorLayer layer;
        protected MapObjectType ObjectType;
        public bool selected;

        public GeoRect Bounds
        {
            get
            {
                return GetBounds();
            }
        }

        protected abstract GeoRect GetBounds();

        internal abstract void Draw(System.Windows.Forms.PaintEventArgs e);

        internal abstract bool isCross(GeoRect SelectPoint);

        internal abstract void ChangeStyleFunction(string FontName, int PointSize, int PointNumber, System.Drawing.Color
            PointColor, int LineWidth, System.Drawing.Color LineColour, System.Drawing.Color PolygonColour,
            System.Drawing.Color BorderColor);
    }
}
