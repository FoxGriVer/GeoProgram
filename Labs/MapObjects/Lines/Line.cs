using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Labs.Styles;
using Labs.MapTypes;
using Labs.MapObjects;
using Labs.MapObjects.Shapes;
using Labs.MapObjects.Points;

namespace Labs.MapObjects.Lines
{
    public class Line : MapObject
    {
        public Line(GeoPoint a, GeoPoint b)
        {
            BeginPoint = a;
            EndPoint = b;
            ObjectType = MapObjectType.Line;
            pen = new Pen(Color.DarkCyan);
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
            return (new GeoRect(Math.Min(BeginPoint.x, EndPoint.x), Math.Max(BeginPoint.x, EndPoint.x),
                Math.Min(BeginPoint.y, EndPoint.y), Math.Max(BeginPoint.y, EndPoint.y)));
        }

        internal override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Point bp = layer.map.MapToScreen(BeginPoint);
            System.Drawing.Point ep = layer.map.MapToScreen(EndPoint);
            pen.Width = Style.Fatness;            
            //pen.PenType = System.Drawing.Drawing2D.PenType.HatchFill;
            if (selected)
            {
                pen.Color = layer.map.SelectedColour;
            }
            else
            {
                pen.Color = Style.LColour;
            }
            e.Graphics.DrawLine(pen, bp, ep);
        }

        private Pen pen;

        public GeoPoint BeginPoint, EndPoint;

        internal override bool isCross(GeoRect SelectPoint)
        {
            //4 проверки на пересечения прямоугольника и линии (со сторонами) + если внутри
            GeoPoint A = new GeoPoint(SelectPoint.Xmin, SelectPoint.Ymax);
            GeoPoint B = new GeoPoint(SelectPoint.Xmax, SelectPoint.Ymax);
            GeoPoint C = new GeoPoint(SelectPoint.Xmax, SelectPoint.Ymin);
            GeoPoint D = new GeoPoint(SelectPoint.Xmin, SelectPoint.Ymin);
            if ( GeoRect.IsCrosLines(B, A, BeginPoint, EndPoint) )
            {
                return true;
            }
            if ( GeoRect.IsCrosLines(C, B, BeginPoint, EndPoint) )
            {
                return true;
            }
            if (GeoRect.IsCrosLines(C, D, BeginPoint, EndPoint))
            {
                return true;
            }
            if (GeoRect.IsCrosLines(D, A, BeginPoint, EndPoint))
            {
                return true;
            }
            if (BeginPoint.x >= SelectPoint.Xmax && BeginPoint.x <= SelectPoint.Xmin &&
                BeginPoint.y <= SelectPoint.Ymax && BeginPoint.y >= SelectPoint.Ymin)
            {
                return true;
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
