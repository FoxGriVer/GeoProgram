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
        }

        internal MAP map;
        public string Name { get; set; }
        public string FileName { get; set; }

        public abstract void LoadFromFile(string fileName);

        public abstract void Draw(PaintEventArgs e);
    }
}
