using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labs.Layers.Grid
{
    public class GridLayer: AbstractLayer
    {
        private GridGeometry gridGeometry;

        private double XMin
        {
            get
            {
                return gridGeometry.XMin;
            }
            set
            {
                value = 0.0;
            }
        }
        private double YMin
        {
            get
            {
                return gridGeometry.YMin;
            }
            set
            {
                value = 0.0;
            }
        }
        private double XMax
        {
            get
            {
                return gridGeometry.XMax;
            }
            set
            {
                value = 0.0;
            }
        }
        private double YMax
        {
            get
            {
                return gridGeometry.YMax;
            }
            set
            {
                value = 0.0;
            }
        }
        private int CountX => gridGeometry.CountX;
        private int CountY => gridGeometry.CountY;
        private double Cell => gridGeometry.Cell;

        private Bitmap bitmap;

        private double?[,] matrix;
        
        public Color ColorMin { get; set; } = Color.White;
        public Color ColorMax { get; set; } = Color.Black;

        private double zMin;
        private double zMax;

        public GridLayer(GridGeometry gridGeometry, MAP map)
        {
            this.gridGeometry = gridGeometry;
            this.map = map;
        }

        public override void Draw(PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void LoadFromFile(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
