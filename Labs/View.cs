using Labs.Layers.Vector;
using Labs.Layers.Grid;
using Labs.MapTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Labs.Layers;
using Labs.MapObjects;
using Labs.MapObjects.Points;
using Microsoft.VisualBasic;

namespace Labs
{
    
    public partial class View : Form
    {    
        public List<string> CharList = new List<string>();

        private AbstractLayer selectedLayer { get; set; }

        public View()
        {
            InitializeComponent();            
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false; 
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            map.ActiveTool = MapToolType.select;
            LayerControl.Map = map;            
            map.LayerControl = LayerControl;
            for (int i = 33; i < 256; i++)
            {
                CharList.Add(Convert.ToChar(i).ToString());
            }
            MaskSymbolNumber.DataSource = CharList;
        }
  
        private void View_SizeChanged(object sender, EventArgs e)
        {
            map.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = true;
            map.ActiveTool = MapToolType.zoomout;
            map.Refresh();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
            toolStripButton4.Checked = false;
            map.ActiveTool = MapToolType.zoomin;
            map.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            map.ActiveTool = MapToolType.pan;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            map.ActiveTool = MapToolType.select;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            map.ZoomToAll();
        }

        private void ChooseButtonPolygon_Click(object sender, EventArgs e)
        {
            if (CDialogPolygon.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChooseButtonPolygon.BackColor = CDialogPolygon.Color;
            }
        }

        private void ChooseButtonPoint_Click(object sender, EventArgs e)
        {
            if (CDialogPoint.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChooseButtonPoint.BackColor = CDialogPoint.Color;
            }
        }

        private void ChooseButtonLine_Click(object sender, EventArgs e)
        {
            if (CDialogLine.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChooseButtonLine.BackColor = CDialogLine.Color;
            }
        }

        private void ChooseBorderButton_Click(object sender, EventArgs e)
        {
            if (BorderCDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChooseBorderButton.BackColor = BorderCDialog.Color;
            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            map.ChangeStyleFunction(MaskSymbolFont.Text, Convert.ToInt32(MaskSymbolSize.Text),
                            Convert.ToInt32(Convert.ToChar(MaskSymbolNumber.Text)), CDialogPoint.Color,
                        Convert.ToInt32(MaskLineWidth.Text), CDialogLine.Color,
                        CDialogPolygon.Color, BorderCDialog.Color);

        }

        private void Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "All formats|*.mif;*.txt;*.grd|Layers (*.mif)|*.mif|Grid files (*.grd)|*.grd|Geopoints file (*.txt)|*.txt";
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (OpenFileDialog.FileName != null)
                {
                    try
                    {                        

                        bool isExistName = true;
                        for (int i = 0; i < map.LayersCount; i++)
                        {
                            if (map.Layers[i].Name == System.IO.Path.GetFileNameWithoutExtension(OpenFileDialog.FileName))
                            {
                                isExistName = false;
                            }
                        }
                        if (isExistName)
                        {
                            if(Path.GetExtension(OpenFileDialog.FileName) == ".mif")
                            {
                                VectorLayer MifLayer = new VectorLayer();
                                map.AddLayer(MifLayer);
                                MifLayer.LoadFromFile(OpenFileDialog.FileName);                                
                            }
                            if (Path.GetExtension(OpenFileDialog.FileName) == ".txt")
                            {
                                VectorLayer vectorLayer = new VectorLayer();
                                map.AddLayer(vectorLayer);
                                vectorLayer.LoadFromFile(OpenFileDialog.FileName);
                            }
                            if (Path.GetExtension(OpenFileDialog.FileName) == ".grd")
                            {
                                GridLayer gridLayer = new GridLayer(new GridGeometry(), map);
                                map.AddLayer(gridLayer);
                                gridLayer.LoadFromFile(OpenFileDialog.FileName);
                            }
                            map.ZoomToAll();
                            map.Refresh();
                            LayerControl.RefreshList();
                        }
                        else
                        {
                            MessageBox.Show("Слой с таким именем уже существует.");
                        }
                        isExistName = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void MaskSymbolNumber_DrawItem(object sender, DrawItemEventArgs e)
        {

            System.Drawing.Point loc = new System.Drawing.Point(e.Bounds.X, e.Bounds.Y);
            System.Drawing.Font font = new System.Drawing.Font(MaskSymbolFont.Text, 16);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(Color.Black);
            e.Graphics.DrawString(CharList[e.Index], font, brush, loc);

        }

        private void MaskSymbolNumber_TextChanged_1(object sender, EventArgs e)
        {
            if (MaskSymbolNumber.Text.Count() > 1 || MaskSymbolNumber.Text == "")
            {
                MaskSymbolNumber.Text = "J";
            }
        }

        private void MaskSymbolFont_TextChanged(object sender, EventArgs e)
        {
            MaskSymbolNumber.Font = new System.Drawing.Font(MaskSymbolFont.Text, 16);
        }

        private void ShowBitmap_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            double searchRadius = 1;
            int power = 1;

            if (map.LayerControl.SelectedLayer != null 
                && map.LayerControl.SelectedLayer is VectorLayer 
                && map.LayerControl.SelectedLayer.Visible)
            {                
                VectorLayer vectorLayer = (VectorLayer)map.LayerControl.SelectedLayer;
                GridGeometry gridGeometry = null;
                GridInterpolationModalForm interpolationForm = new GridInterpolationModalForm();
                
                interpolationForm.InitializeForm(map.LayerControl.VectorLayers, ref vectorLayer, ref gridGeometry, ref searchRadius, ref power);
                if(interpolationForm.DialogResult == DialogResult.OK)
                {
                    GridLayer gridLayer = new GridLayer(gridGeometry, map);
                    foreach(var layer in map.Layers)
                    {
                        if(layer.Name == gridLayer.Name)
                        {
                            gridLayer.Name = Interaction.InputBox("Grid для данного слоя уже существует. Введите уникальное название для нового слоя.", "Название слоя", vectorLayer.Name) + ".grd";
                        }
                        else
                        {
                            gridLayer.Name = vectorLayer.Name + ".grd";
                        }
                    }
                    map.AddLayer(gridLayer);
                    List<GeoPoint> points = new List<GeoPoint>();

                    gridLayer.ColorMin = MinStripButton.BackColor;
                    gridLayer.ColorMax = MaxStripButton.BackColor;

                    points = GetPoints(vectorLayer);

                    if (points.Count == 0)
                    {
                        MessageBox.Show("Количество точек равно 0");
                    }
                    else
                    {
                        selectedLayer = gridLayer;
                        gridLayer.DoInterpolation(points, searchRadius, power);
                        ShowColors();
                    }
                }
                else
                {                    
                }
                map.Refresh();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать векторный слой !");
            }
        }

        private List<GeoPoint> GetPoints(AbstractLayer layer)
        {
            List<GeoPoint> points = new List<GeoPoint>();            

            foreach (MapObject m in layer.Objects)
            {
                if (m is Labs.MapObjects.Points.Point)
                {
                    var p = (Labs.MapObjects.Points.Point)m;
                    points.Add(new GeoPoint(p.location.x, p.location.y, p.location.z));
                }
            }

            return points;
        }

        private void ShowColors()
        {
            var selectedLayer = map.LayerControl.SelectedLayer;
            if (selectedLayer != null
                && selectedLayer is GridLayer
                && selectedLayer.Visible)
            {
                (selectedLayer as GridLayer).ColorMin = MinStripButton.BackColor;
                (selectedLayer as GridLayer).ColorMax = MaxStripButton.BackColor;                
            }
            else
            {
                MinStripButton.BackColor = Color.Black;
                MaxStripButton.BackColor = Color.White;
            }
            MinStripButton.Invalidate();
            MaxStripButton.Invalidate();
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            var PB = sender as Button;
            ColorDialog colorDialog = new ColorDialog();
            int[] colorRGB = new int[4];

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorRGB[0] = colorDialog.Color.A;
                colorRGB[1] = colorDialog.Color.R;
                colorRGB[2] = colorDialog.Color.G;
                colorRGB[3] = colorDialog.Color.B;
                PB.BackColor = Color.FromArgb(colorRGB[0], colorRGB[1], colorRGB[2], colorRGB[3]);
                PB.Invalidate();
            }
            ShowColors();
            Refresh();
        }

    }
}
