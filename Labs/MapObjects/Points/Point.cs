using Labs.MapObjects;
using Labs.MapObjects.Shapes;
using Labs.MapTypes;
using Labs.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.MapObjects.Points
{
    public class GeoPoint 
    {
        public double x, y, z;

        public GeoPoint(double a, double b)
        {
            x = a;
            y = b;
        }

        public GeoPoint(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

    }

    public class Point : MapObject
    {
        public GeoPoint location;

        public Point(double a, double b)
        {
            location = new GeoPoint(a,b);
            ObjectType = MapObjectType.Point;
            style = new SymbolStyle();
        }

        public Point(double a, double b, double c)
        {
            location = new GeoPoint(a, b, c);
            ObjectType = MapObjectType.Point;
            style = new SymbolStyle();
        }

        protected override GeoRect GetBounds()
        {
            return (new GeoRect(location.x, location.x, location.y, location.y));
        }

        #region Style
        private SymbolStyle style;

        public SymbolStyle Style
        {
            get { return style; }
        }        
        #endregion
        
        internal override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Point loc = layer.map.MapToScreen(location);
            string symbol = Convert.ToChar(Style.Number).ToString();
            System.Drawing.Font font = new System.Drawing.Font(Style.Name, Style.Size);
            var size = e.Graphics.MeasureString(symbol, font);
            loc.X -= (int)(size.Width / 2);
            loc.Y -= (int)(size.Height / 2);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(Style.SColour);
            if (selected)
            {
                brush.Color = layer.map.SelectedColour;
            }
            else
            {
                brush.Color = Style.SColour;
            }
            e.Graphics.DrawString(symbol, font, brush, loc);
        }

        internal override bool isCross(GeoRect SelectPoint)
        {
            //находим покрытие символа и проверяем на пересечение

            if (layer == null) return false;
            if (layer.map == null) return false;

            System.Drawing.Graphics graphics = layer.map.CreateGraphics();

            string symbol = Convert.ToChar(Style.Number).ToString();
            System.Drawing.Font font = new System.Drawing.Font(Style.Name, Style.Size);
            System.Drawing.SizeF size = graphics.MeasureString(symbol, font);
            GeoRect rect = new GeoRect(location.x - (size.Width / 2) / layer.map.MapScale,
                                       location.x + (size.Width / 2) / layer.map.MapScale,
                                       location.y - (size.Height / 2) / layer.map.MapScale,
                                       location.y + (size.Height / 2) / layer.map.MapScale);

            if (GeoRect.isIntersect(SelectPoint, rect))
            {
                return true;
            }
            
            return false;
        }

        internal override void ChangeStyleFunction(string FontName, int PointSize, int PointNumber, System.Drawing.Color
            PointColor, int LineWidth, System.Drawing.Color LineColour, System.Drawing.Color PolygonColour, System.Drawing.Color BorderColor)
        {
            Style.Name = FontName;
            Style.Size = PointSize;
            Style.Number = Convert.ToByte(PointNumber);
            Style.SColour = PointColor;
        }
    }
}
