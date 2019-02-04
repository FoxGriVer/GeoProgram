using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Labs.Layers;
using Labs.Layers.Grid;
using Labs.Layers.Vector;
using Labs.MapObjects.Shapes;

namespace Labs
{
    public partial class GridInterpolationModalForm : Form
    {
        private AbstractLayer selectedLayer;
        public AbstractLayer SelectedLayer
        {
            get
            {
                return selectedLayer;
            }
            set
            {
                if (value is VectorLayer)
                {
                    selectedLayer = (VectorLayer)value;
                    VectorLayersListComboBox.SelectedItem = selectedLayer;
                }
                else
                {
                    MessageBox.Show("Для интерполяции необходим слой VectorLayer");
                    this.Close();
                }
            }
        }

        private List<VectorLayer> rangeOfVectorLayers;

        private double dx;
        private double dy;
        private double selectedCell
        {
            get { return Convert.ToDouble(numericUpDownGridStep.Value); }
            set { numericUpDownGridStep.Value = (decimal)value; }
        }

        private GridGeometry selectedGeometry
        {
            get
            {                
                SelectedLayer = rangeOfVectorLayers[VectorLayersListComboBox.SelectedIndex];
                GeoRect bounds = new GeoRect(SelectedLayer.Bounds.Xmin, SelectedLayer.Bounds.Xmax,
                    SelectedLayer.Bounds.Ymin, SelectedLayer.Bounds.Ymax);

                GridGeometry gridGeometry = new GridGeometry();
                gridGeometry.XMin = bounds.Xmin;
                gridGeometry.YMin = bounds.Ymin;

                gridGeometry.Cell = selectedCell;
                dx = (bounds.Xmax - bounds.Xmin);
                dy = (bounds.Ymax - bounds.Ymin);
                gridGeometry.CountX = (int)(dx / selectedCell + 1);
                gridGeometry.CountY = (int)(dy / selectedCell + 1);

                return gridGeometry;                              
            }
            set
            {

            }
        }

        private double selectedSearchRadius
        {
            get
            {
                return (double)numericUpDownRadius.Value;
            }
            set
            {
                numericUpDownRadius.Value = (decimal)value;
            }
        }
        private int selectedPower
        {
            get
            {
                return (int)numericUpDownPower.Value;
            }
            set
            {
                numericUpDownPower.Value = (decimal)value;
            }
        }
        private int selectedX
        {

            get
            {
                return (int)numericUpDownX.Value;
            }

            set
            {
                try
                {
                    if(numericUpDownX.Minimum < value)
                    {
                        numericUpDownX.Value = (decimal)value;
                    }
                    else
                    {
                        selectedCell = 1;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введен некорректный параметр");
                }
            }
        }
        private int selectedY
        {

            get
            {
                return (int)numericUpDownY.Value;
            }

            set
            {
                try
                {
                    if (numericUpDownY.Minimum < value)
                    {
                        numericUpDownY.Value = (decimal)value;
                    }
                    else
                    {
                        selectedCell = 1;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введен некорректный параметр");
                }
            }
        }

        public GridInterpolationModalForm()
        {
            InitializeComponent();
            this.AcceptButton = OkButton;
            this.CancelButton = CancelButton;
        }

        public GridInterpolationModalForm(List<VectorLayer> vectorLayers, AbstractLayer selectedLayer)
        {
            InitializeComponent();

            TypeGeometryComboBox.SelectedIndexChanged -= UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged -= UpdateGeometry;
            numericUpDownGridStep.ValueChanged -= UpdateGeometry;
            numericUpDownX.ValueChanged -= UpdateXStepGeometry;
            numericUpDownY.ValueChanged -= UpdateYStepGeometry;

            VectorLayersListComboBox.Items.Clear();            
            VectorLayersListComboBox.DataSource = vectorLayers;
            VectorLayersListComboBox.DisplayMember = "Name";
            VectorLayersListComboBox.ValueMember = "Name";

            SelectedLayer = selectedLayer;
            //selectedGeometry = gridGeometry;

            GetDefaultGeometry();

            UpdateGeometry(new object(), new EventArgs());

            TypeGeometryComboBox.SelectedIndexChanged += UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged += UpdateGeometry;
            numericUpDownGridStep.ValueChanged += UpdateGeometry;
            numericUpDownX.ValueChanged += UpdateXStepGeometry;
            numericUpDownY.ValueChanged += UpdateYStepGeometry;
            
        }

        public void InitializeForm(List<VectorLayer> vectorLayers, ref VectorLayer selectedLayer,
            ref GridGeometry gridGeometry)
        {
            TypeGeometryComboBox.SelectedIndexChanged -= UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged -= UpdateGeometry;
            numericUpDownGridStep.ValueChanged -= UpdateGeometry;
            numericUpDownX.ValueChanged -= UpdateXStepGeometry;
            numericUpDownY.ValueChanged -= UpdateYStepGeometry;

            rangeOfVectorLayers = new List<VectorLayer>(vectorLayers);

            VectorLayersListComboBox.DataSource = null;
            VectorLayersListComboBox.Items.Clear();
            VectorLayersListComboBox.DataSource = vectorLayers;
            VectorLayersListComboBox.DisplayMember = "Name";
            VectorLayersListComboBox.ValueMember = "Name";

            SelectedLayer = selectedLayer;
            //selectedGeometry = gridGeometry;

            GetDefaultGeometry();

            UpdateGeometry(new object(), new EventArgs());

            TypeGeometryComboBox.SelectedIndexChanged += UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged += UpdateGeometry;
            numericUpDownGridStep.ValueChanged += UpdateGeometry;
            numericUpDownX.ValueChanged += UpdateXStepGeometry;
            numericUpDownY.ValueChanged += UpdateYStepGeometry;

            //if (ShowDialog() == DialogResult.Cancel)
            //{
            //    return false;
            //}

            gridGeometry = selectedGeometry;

            ShowDialog();
            this.Close();
            

            //return true;
        }

        private void GetDefaultGeometry()
        {
            GridGeometry geom = selectedGeometry;
            double dx = geom.XMax - geom.XMin;
            double dy = geom.YMax - geom.YMin;

            if (dx >= dy)
            {
                selectedCell = dx / 100;
            }
            else
            {
                selectedCell = dy / 100;
            }

        }

        private void UpdateGeometry(object sender, EventArgs e)
        {
            GridGeometry geom = selectedGeometry;
            selectedX = geom.CountX;
            selectedY = geom.CountY;
            double dx = geom.XMax - geom.XMin;
            double dy = geom.YMax - geom.YMin;


            selectedSearchRadius = Math.Sqrt(dx * dx + dy * dy);
        }

        private void UpdateXStepGeometry(object sender, EventArgs e)
        {
            TypeGeometryComboBox.SelectedIndexChanged -= UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged -= UpdateGeometry;
            numericUpDownGridStep.ValueChanged -= UpdateGeometry;
            numericUpDownY.ValueChanged -= UpdateYStepGeometry;

            GridGeometry geom = new GridGeometry();

            geom.CountX = selectedX;
            selectedCell = dx / (geom.CountX - 1);
            geom.Cell = selectedCell;
            selectedY = (int)(dy / (geom.Cell) + 1);
            geom.CountY = selectedY;
            selectedGeometry = geom;

            TypeGeometryComboBox.SelectedIndexChanged += UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged += UpdateGeometry;
            numericUpDownGridStep.ValueChanged += UpdateGeometry;
            numericUpDownY.ValueChanged += UpdateYStepGeometry;
        }

        private void UpdateYStepGeometry(object sender, EventArgs e)
        {
            TypeGeometryComboBox.SelectedIndexChanged -= UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged -= UpdateGeometry;
            numericUpDownGridStep.ValueChanged -= UpdateGeometry;
            numericUpDownX.ValueChanged -= UpdateXStepGeometry;

            GridGeometry geom = new GridGeometry();

            geom.CountY = selectedY;
            selectedCell = dy / (geom.CountY - 1);
            geom.Cell = selectedCell;
            selectedX = (int)(dx / (geom.Cell) + 1);
            geom.CountX = selectedX;
            selectedGeometry = geom;

            TypeGeometryComboBox.SelectedIndexChanged += UpdateGeometry;
            VectorLayersListComboBox.SelectedIndexChanged += UpdateGeometry;
            numericUpDownGridStep.ValueChanged += UpdateGeometry;
            numericUpDownX.ValueChanged += UpdateXStepGeometry;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
        }

        private void CancelInterpolationButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
