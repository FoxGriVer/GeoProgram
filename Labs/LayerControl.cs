using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Labs.Layers.Vector;

namespace Labs
{
    public partial class LayerControl : UserControl
    {
        public LayerControl()
        {
            InitializeComponent();
        }

        public MAP Map;

        public void RefreshList()
        {
            if (Map == null) return;
            ListView.BeginUpdate();
            ListView.Clear();
            foreach (var layer in Map.Layers)
            {
                if (layer.Name == null)
                {
                    layer.Name = "<Noname>";
                }
                ListViewItem item = ListView.Items.Insert(0, layer.Name);
                item.Checked = layer.Visible;
                item.Tag = layer;
            }
            ListView.EndUpdate();
        }


        public void SinListWithMap()
        {
            if (Map == null) return;
            List<VectorLayer> temp = new List<VectorLayer>();
            for (int i = ListView.Items.Count-1; i >= 0; i--)
            {
                temp.Add(ListView.Items[i].Tag as VectorLayer);
            }
            Map.Layers = temp;
            Map.Refresh();
        }

        private void ListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (Map == null) return;
            var layer = (e.Item.Tag) as VectorLayer;
            if (layer == null) return;    
            layer.Visible = e.Item.Checked;
            RefreshList();
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (sender != ListView)
            {
                return;
            }

            System.Drawing.Point targetPoint = ListView.PointToClient(new System.Drawing.Point(e.X, e.Y));

            int targetIndex = ListView.InsertionMark.NearestIndex(targetPoint);

            if (targetIndex > -1)
            {
                Rectangle itemBounds = ListView.GetItemRect(targetIndex);
                if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
                {
                    ListView.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    ListView.InsertionMark.AppearsAfterItem = false;
                }
            }
            ListView.InsertionMark.Index = targetIndex;
        }

        private void ListView_DragDrop(object sender, DragEventArgs e) //в момент отпускания кнопки мыши
        {
            if (sender != ListView)
            {
                return;
            }

            int targetIndex = ListView.InsertionMark.Index;
            if (targetIndex == -1)
            {
                return;
            }
            if (ListView.InsertionMark.AppearsAfterItem)
            {
                targetIndex++;
            }
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            MAP oldMap = Map;//это чтобы itemcheched не вызывался при insert
            Map = null;

            ListView.Items.Insert(targetIndex, (ListViewItem)draggedItem.Clone());

            Map = oldMap;

            ListView.Items.Remove(draggedItem);
            SinListWithMap();
            RefreshList();

        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (sender != ListView)
            {
                return;
            }

            e.Effect = e.AllowedEffect;
        }

        private void ListView_DragLeave(object sender, EventArgs e)
        {
            if (sender != ListView)
            {
                return;
            }
            ListView.InsertionMark.Index = -1;
        }

        private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (sender != ListView)
            {
                return;
            }
            ListView.DoDragDrop(e.Item, DragDropEffects.Move);
        }

    }
}
