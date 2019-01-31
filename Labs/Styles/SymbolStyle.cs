﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.Styles
{
    public class SymbolStyle
    {
        public string Name;
        public int Size;
        public byte Number;
        public System.Drawing.Color SColour;

        public SymbolStyle(string name, int size, byte number, System.Drawing.Color colour)
        {
            Name = name;
            Size = size;
            Number = number;
            SColour = colour;
        }

        public SymbolStyle()
        {
            Name = "Wingdings";
            Size = 12;
            Number = 0x7B;
            SColour = System.Drawing.Color.Pink;
        }
        
    }
}
