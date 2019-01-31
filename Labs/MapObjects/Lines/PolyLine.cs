using Labs.MapObjects;
using Labs.MapObjects.Points;
using Labs.MapObjects.Shapes;
using Labs.MapTypes;
using Labs.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.MapObjects.Lines
{
    public class PolyLine : MapObject
    {
        public PolyLine()
        {
            Nodes = new List<GeoPoint>();
            ObjectType = MapObjectType.PolyLine;
            pen = new System.Drawing.Pen(System.Drawing.Color.DarkCyan);
            style = new LineStyle();     
        }

        #region Style
        private LineStyle style;
        public LineStyle Style
        {
            get { return style; }
        }
        #endregion

        protected override GeoRect GetBounds()
        {
            GeoRect result = new GeoRect(0, 0, 0, 0);
            foreach (var node in Nodes)
            {
                if (result.isCucumber)
                {
                    result.Xmin = Math.Max(result.Xmin, node.x);
                    result.Xmax = Math.Min(result.Xmax, node.x);
                    result.Ymax = Math.Max(result.Ymax, node.y);
                    result.Ymin = Math.Min(result.Ymin, node.y);
                }
                else
                {
                    result.Xmax = node.x;
                    result.Xmin = node.x;
                    result.Ymax = node.y;
                    result.Ymin = node.y;
                }
            }
            return result;
        }

        protected System.Drawing.Pen pen;

        public List<System.Drawing.Point> nod = new List<System.Drawing.Point>();

        internal override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            if (nod != null)
            {
                nod.Clear();
            }
            foreach (var node in Nodes)
            {
                nod.Add(layer.map.MapToScreen(node));
            }
            pen.Width = Style.Fatness;
            if (selected)
            {
                pen.Color = layer.map.SelectedColour;
            }
            else
            {
                pen.Color = Style.LColour;
            }
            e.Graphics.DrawLines(pen, nod.ToArray());  
        }

        public List<GeoPoint> Nodes;
        
        public void InsertNode(int Index, GeoPoint Point)
        {
            Nodes.Insert(Index, Point);
        }

        public void InsertNode(int Index, int x, int y)
        {
            Nodes.Insert(Index, new GeoPoint(x,y));
        }

        public void DeleteNode(int a)
        {
            if (Nodes.Count >= a)
            {
                Nodes.RemoveAt(a);                
            }
            else return;
        }

        public void AddNode(double x, double y)
        {
            GeoPoint S = new GeoPoint(x,y);
            AddNode(S);
        }

        public void AddNode(GeoPoint Point)
        {
            Nodes.Add(Point);
        }
        
        public int NodesCount
        {
            get
            {
                return Nodes.Count;
            }
        }

        internal override bool isCross(GeoRect SelectPoint)
        {

            if (NodesCount < 2)
            {
                return false;
            }


            GeoPoint A = new GeoPoint(SelectPoint.Xmin, SelectPoint.Ymax);
            GeoPoint B = new GeoPoint(SelectPoint.Xmax, SelectPoint.Ymax);
            GeoPoint C = new GeoPoint(SelectPoint.Xmax, SelectPoint.Ymin);
            GeoPoint D = new GeoPoint(SelectPoint.Xmin, SelectPoint.Ymin);

            for (int i = 0; i < Nodes.Count-1; i++)
            {
                if (GeoRect.IsCrosLines(B, A, Nodes[i], Nodes[i + 1]))
                {
                    return true;
                }
                if (GeoRect.IsCrosLines(C, B, Nodes[i], Nodes[i + 1]))
                {
                    return true;
                }
                if (GeoRect.IsCrosLines(C, D, Nodes[i], Nodes[i + 1]))
                {
                    return true;
                }
                if (GeoRect.IsCrosLines(D, A, Nodes[i], Nodes[i + 1]))
                {
                    return true;
                }
                if (Nodes[i].x >= SelectPoint.Xmax && Nodes[i].x <= SelectPoint.Xmin &&
                    Nodes[i].y <= SelectPoint.Ymax && Nodes[i].y >= SelectPoint.Ymin)
                {
                    return true;
                }
            }

            return false;
        }

        internal override void ChangeStyleFunction(string FontName, int PointSize, int PointNumber, System.Drawing.Color
    PointColor, int LineWidth, System.Drawing.Color LineColour, System.Drawing.Color PolygonColour, System.Drawing.Color BorderColor)
        {
            Style.Fatness = LineWidth;
            Style.LColour = LineColour;
        }
    }
}
