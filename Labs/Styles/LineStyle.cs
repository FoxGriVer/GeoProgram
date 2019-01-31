using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.Styles
{
    public class LineStyle
    {
        public LineStyle(int type, int fatness, System.Drawing.Color colour)
        {
            Type = type;
            Fatness = fatness;
            LColour = colour;
        }

        public LineStyle()
        {
            Type = 1;
            Fatness = 7;
            LColour = System.Drawing.Color.Green;
        }

        public int Type;
        public int Fatness;
        public System.Drawing.Color LColour;
    }
}
