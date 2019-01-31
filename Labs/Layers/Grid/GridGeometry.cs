using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.Layers.Grid
{
    /// <summary>
    /// Описывает структуру GridLayer'а
    /// </summary>
    public class GridGeometry
    {
        public double XMin { get; set; }
        public double YMin { get; set; }
        public double XMax => XMin + (CountX - 1) * Cell;
        public double YMax => YMin + (CountY - 1) * Cell;
        public int CountX { get; set; }
        public int CountY { get; set; }

        /// <summary>
        /// Ячейка
        /// </summary>
        public double Cell { get; set; }
    }
}
