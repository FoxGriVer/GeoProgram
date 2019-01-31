using Labs.MapObjects.Lines;
using Labs.MapObjects.Points;
using Labs.MapTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.MapObjects.Shapes
{
    public class Polygone: PolyLine
    {
        public Polygone() : base()
        {
            ObjectType = MapObjectType.Polygone;
            pen = new System.Drawing.Pen(System.Drawing.Color.DarkCyan);
            brush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkCyan);
            border = System.Drawing.Color.Black;
        }

        private System.Drawing.SolidBrush brush;
        private System.Drawing.Color border = new System.Drawing.Color();

        public System.Drawing.SolidBrush Brush
        {
            get
            {
                return (brush);
            }
            set
            {
                brush = value;
            }
        }

        public List<System.Drawing.Point> nodik = new List<System.Drawing.Point>();

        internal override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            if (nodik!=null)
            {
                nodik.Clear();
            }
            foreach (var node in Nodes)
            {
                nodik.Add(layer.map.MapToScreen(node));
            }
            if (selected)
            {
                brush.Color = layer.map.SelectedColour;
                pen.Color = layer.map.SelectedColour;
            }
            else
            {
                brush.Color = Style.LColour;
                pen.Color = border;
            }
            e.Graphics.FillPolygon(brush, nodik.ToArray());
            e.Graphics.DrawPolygon(pen, nodik.ToArray());
        }

        internal override bool isCross(GeoRect SelectPoint)
        {

            if (NodesCount < 2)
            {
                return false;
            }
            GeoPoint A = new GeoPoint( (SelectPoint.Xmax + SelectPoint.Xmin)/2,
                                       (SelectPoint.Ymax + SelectPoint.Ymin)/2 );
            GeoPoint B = new GeoPoint(Bounds.Xmin+1, (SelectPoint.Ymax + SelectPoint.Ymin)/2);
            int k = 0;
            if (GeoRect.isIntersect(Bounds, SelectPoint))
            {
                for (int i = 0; i < Nodes.Count - 1; i++)
                {
                    if (GeoRect.IsCrosLines(A, B, Nodes[i], Nodes[i + 1]) &&
                        A.y !=Nodes[i].y &&
                        Nodes[i].y != Nodes[i+1].y)
                    {
                        k++;
                    }
                }
                if ((k % 2) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        internal override void ChangeStyleFunction(string FontName, int PointSize, int PointNumber, System.Drawing.Color
    PointColor, int LineWidth, System.Drawing.Color LineColour, System.Drawing.Color PolygonColour, System.Drawing.Color BorderColor)
        {
            Style.LColour = PolygonColour;
            border = BorderColor;
        }
        
    }
}























