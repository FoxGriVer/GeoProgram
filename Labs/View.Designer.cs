namespace Labs
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.CDialogPoint = new System.Windows.Forms.ColorDialog();
            this.CDialogLine = new System.Windows.Forms.ColorDialog();
            this.CDialogPolygon = new System.Windows.Forms.ColorDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.map = new Labs.MAP();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Add = new System.Windows.Forms.Button();
            this.LayerControl = new Labs.LayerControl();
            this.PanelChooseStyle = new System.Windows.Forms.Panel();
            this.ShowBitmap = new System.Windows.Forms.Button();
            this.ChooseBorderButton = new System.Windows.Forms.Button();
            this.BorderStyleLabel = new System.Windows.Forms.Label();
            this.MaskSymbolFont = new System.Windows.Forms.ComboBox();
            this.MaskSymbolNumber = new System.Windows.Forms.ComboBox();
            this.MaskSymbolSize = new System.Windows.Forms.ComboBox();
            this.MaskLineWidth = new System.Windows.Forms.ComboBox();
            this.ChooseButtonPolygon = new System.Windows.Forms.Button();
            this.ChooseButtonLine = new System.Windows.Forms.Button();
            this.ChooseButtonPoint = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PanelLayersVisibility = new System.Windows.Forms.Panel();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BorderCDialog = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.PanelChooseStyle.SuspendLayout();
            this.PanelLayersVisibility.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1654, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripButton1.MergeIndex = 1;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Выбор объекта";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripButton2.MergeIndex = 1;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Сместить центр";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripButton3.MergeIndex = 1;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Увеличить масштаб";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.toolStripButton4.MergeIndex = 1;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Уменьшить масштаб";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "Показать полностью";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::Labs.Properties.Resources._220px_Lagrange_polynomial_svg__1__0;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Интерполировать";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // CDialogPoint
            // 
            this.CDialogPoint.AnyColor = true;
            this.CDialogPoint.ShowHelp = true;
            // 
            // CDialogLine
            // 
            this.CDialogLine.AnyColor = true;
            this.CDialogLine.ShowHelp = true;
            // 
            // CDialogPolygon
            // 
            this.CDialogPolygon.AnyColor = true;
            this.CDialogPolygon.ShowHelp = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.map);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1654, 1486);
            this.splitContainer1.SplitterDistance = 968;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 7;
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.SystemColors.Window;
            this.map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MapScale = 1D;
            this.map.Margin = new System.Windows.Forms.Padding(12);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(968, 1486);
            this.map.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Add);
            this.splitContainer2.Panel1.Controls.Add(this.LayerControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.PanelChooseStyle);
            this.splitContainer2.Size = new System.Drawing.Size(678, 1486);
            this.splitContainer2.SplitterDistance = 182;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 3;
            // 
            // Add
            // 
            this.Add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Add.Location = new System.Drawing.Point(0, 1424);
            this.Add.Margin = new System.Windows.Forms.Padding(6);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(182, 62);
            this.Add.TabIndex = 22;
            this.Add.Text = "Добавить слой";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // LayerControl
            // 
            this.LayerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerControl.Location = new System.Drawing.Point(0, 0);
            this.LayerControl.Margin = new System.Windows.Forms.Padding(12);
            this.LayerControl.Name = "LayerControl";
            this.LayerControl.SelectedLayer = null;
            this.LayerControl.Size = new System.Drawing.Size(182, 1486);
            this.LayerControl.TabIndex = 4;
            // 
            // PanelChooseStyle
            // 
            this.PanelChooseStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelChooseStyle.Controls.Add(this.ShowBitmap);
            this.PanelChooseStyle.Controls.Add(this.ChooseBorderButton);
            this.PanelChooseStyle.Controls.Add(this.BorderStyleLabel);
            this.PanelChooseStyle.Controls.Add(this.MaskSymbolFont);
            this.PanelChooseStyle.Controls.Add(this.MaskSymbolNumber);
            this.PanelChooseStyle.Controls.Add(this.MaskSymbolSize);
            this.PanelChooseStyle.Controls.Add(this.MaskLineWidth);
            this.PanelChooseStyle.Controls.Add(this.ChooseButtonPolygon);
            this.PanelChooseStyle.Controls.Add(this.ChooseButtonLine);
            this.PanelChooseStyle.Controls.Add(this.ChooseButtonPoint);
            this.PanelChooseStyle.Controls.Add(this.OK_Button);
            this.PanelChooseStyle.Controls.Add(this.label10);
            this.PanelChooseStyle.Controls.Add(this.label9);
            this.PanelChooseStyle.Controls.Add(this.label8);
            this.PanelChooseStyle.Controls.Add(this.label7);
            this.PanelChooseStyle.Controls.Add(this.label6);
            this.PanelChooseStyle.Controls.Add(this.label5);
            this.PanelChooseStyle.Controls.Add(this.label4);
            this.PanelChooseStyle.Controls.Add(this.label3);
            this.PanelChooseStyle.Controls.Add(this.label2);
            this.PanelChooseStyle.Controls.Add(this.label1);
            this.PanelChooseStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelChooseStyle.Location = new System.Drawing.Point(0, 0);
            this.PanelChooseStyle.Margin = new System.Windows.Forms.Padding(6);
            this.PanelChooseStyle.Name = "PanelChooseStyle";
            this.PanelChooseStyle.Size = new System.Drawing.Size(488, 1486);
            this.PanelChooseStyle.TabIndex = 6;
            // 
            // ShowBitmap
            // 
            this.ShowBitmap.Location = new System.Drawing.Point(86, 625);
            this.ShowBitmap.Name = "ShowBitmap";
            this.ShowBitmap.Size = new System.Drawing.Size(230, 62);
            this.ShowBitmap.TabIndex = 27;
            this.ShowBitmap.Text = "Интерполировать";
            this.ShowBitmap.UseVisualStyleBackColor = true;
            this.ShowBitmap.Click += new System.EventHandler(this.ShowBitmap_Click);
            // 
            // ChooseBorderButton
            // 
            this.ChooseBorderButton.BackColor = System.Drawing.Color.Black;
            this.ChooseBorderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseBorderButton.Location = new System.Drawing.Point(148, 487);
            this.ChooseBorderButton.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseBorderButton.Name = "ChooseBorderButton";
            this.ChooseBorderButton.Size = new System.Drawing.Size(206, 33);
            this.ChooseBorderButton.TabIndex = 26;
            this.ChooseBorderButton.UseVisualStyleBackColor = false;
            this.ChooseBorderButton.Click += new System.EventHandler(this.ChooseBorderButton_Click);
            // 
            // BorderStyleLabel
            // 
            this.BorderStyleLabel.AutoSize = true;
            this.BorderStyleLabel.Location = new System.Drawing.Point(6, 487);
            this.BorderStyleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.BorderStyleLabel.Name = "BorderStyleLabel";
            this.BorderStyleLabel.Size = new System.Drawing.Size(102, 25);
            this.BorderStyleLabel.TabIndex = 25;
            this.BorderStyleLabel.Text = "Граница:";
            // 
            // MaskSymbolFont
            // 
            this.MaskSymbolFont.FormattingEnabled = true;
            this.MaskSymbolFont.Items.AddRange(new object[] {
            "Wingdings",
            "Webdings",
            "Arial"});
            this.MaskSymbolFont.Location = new System.Drawing.Point(148, 62);
            this.MaskSymbolFont.Margin = new System.Windows.Forms.Padding(6);
            this.MaskSymbolFont.Name = "MaskSymbolFont";
            this.MaskSymbolFont.Size = new System.Drawing.Size(200, 33);
            this.MaskSymbolFont.TabIndex = 24;
            this.MaskSymbolFont.Text = "Wingdings";
            this.MaskSymbolFont.TextChanged += new System.EventHandler(this.MaskSymbolFont_TextChanged);
            // 
            // MaskSymbolNumber
            // 
            this.MaskSymbolNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.MaskSymbolNumber.Font = new System.Drawing.Font("Wingdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MaskSymbolNumber.FormattingEnabled = true;
            this.MaskSymbolNumber.ItemHeight = 20;
            this.MaskSymbolNumber.Location = new System.Drawing.Point(148, 165);
            this.MaskSymbolNumber.Margin = new System.Windows.Forms.Padding(6);
            this.MaskSymbolNumber.Name = "MaskSymbolNumber";
            this.MaskSymbolNumber.Size = new System.Drawing.Size(200, 26);
            this.MaskSymbolNumber.TabIndex = 23;
            this.MaskSymbolNumber.Text = "J";
            this.MaskSymbolNumber.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MaskSymbolNumber_DrawItem);
            this.MaskSymbolNumber.TextChanged += new System.EventHandler(this.MaskSymbolNumber_TextChanged_1);
            // 
            // MaskSymbolSize
            // 
            this.MaskSymbolSize.FormattingEnabled = true;
            this.MaskSymbolSize.Items.AddRange(new object[] {
            "4",
            "6",
            "8",
            "9",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.MaskSymbolSize.Location = new System.Drawing.Point(148, 113);
            this.MaskSymbolSize.Margin = new System.Windows.Forms.Padding(6);
            this.MaskSymbolSize.Name = "MaskSymbolSize";
            this.MaskSymbolSize.Size = new System.Drawing.Size(202, 33);
            this.MaskSymbolSize.TabIndex = 22;
            this.MaskSymbolSize.Text = "16";
            // 
            // MaskLineWidth
            // 
            this.MaskLineWidth.FormattingEnabled = true;
            this.MaskLineWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.MaskLineWidth.Location = new System.Drawing.Point(148, 294);
            this.MaskLineWidth.Margin = new System.Windows.Forms.Padding(6);
            this.MaskLineWidth.Name = "MaskLineWidth";
            this.MaskLineWidth.Size = new System.Drawing.Size(202, 33);
            this.MaskLineWidth.TabIndex = 21;
            this.MaskLineWidth.Text = "1";
            // 
            // ChooseButtonPolygon
            // 
            this.ChooseButtonPolygon.BackColor = System.Drawing.Color.Black;
            this.ChooseButtonPolygon.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseButtonPolygon.Location = new System.Drawing.Point(148, 433);
            this.ChooseButtonPolygon.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseButtonPolygon.Name = "ChooseButtonPolygon";
            this.ChooseButtonPolygon.Size = new System.Drawing.Size(206, 33);
            this.ChooseButtonPolygon.TabIndex = 20;
            this.ChooseButtonPolygon.UseVisualStyleBackColor = false;
            this.ChooseButtonPolygon.Click += new System.EventHandler(this.ChooseButtonPolygon_Click);
            // 
            // ChooseButtonLine
            // 
            this.ChooseButtonLine.BackColor = System.Drawing.Color.Black;
            this.ChooseButtonLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseButtonLine.Location = new System.Drawing.Point(148, 346);
            this.ChooseButtonLine.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseButtonLine.Name = "ChooseButtonLine";
            this.ChooseButtonLine.Size = new System.Drawing.Size(206, 33);
            this.ChooseButtonLine.TabIndex = 19;
            this.ChooseButtonLine.UseVisualStyleBackColor = false;
            this.ChooseButtonLine.Click += new System.EventHandler(this.ChooseButtonLine_Click);
            // 
            // ChooseButtonPoint
            // 
            this.ChooseButtonPoint.BackColor = System.Drawing.Color.Black;
            this.ChooseButtonPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseButtonPoint.Location = new System.Drawing.Point(148, 225);
            this.ChooseButtonPoint.Margin = new System.Windows.Forms.Padding(6);
            this.ChooseButtonPoint.Name = "ChooseButtonPoint";
            this.ChooseButtonPoint.Size = new System.Drawing.Size(206, 33);
            this.ChooseButtonPoint.TabIndex = 18;
            this.ChooseButtonPoint.UseVisualStyleBackColor = false;
            this.ChooseButtonPoint.Click += new System.EventHandler(this.ChooseButtonPoint_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(86, 554);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(6);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(232, 62);
            this.OK_Button.TabIndex = 6;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label10.Location = new System.Drawing.Point(118, 402);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "Стиль полигона:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 346);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Цвет:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 300);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Толщина:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 225);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Цвет:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Тип:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Шрифт:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(118, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Стиль точки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(118, 263);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Стиль линии:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 433);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Заливка:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label11.Location = new System.Drawing.Point(30, 35);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Layer Visibility:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label12.Location = new System.Drawing.Point(212, 35);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 25);
            this.label12.TabIndex = 1;
            this.label12.Text = "Layer Order:";
            // 
            // PanelLayersVisibility
            // 
            this.PanelLayersVisibility.AutoScroll = true;
            this.PanelLayersVisibility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLayersVisibility.Controls.Add(this.label12);
            this.PanelLayersVisibility.Controls.Add(this.label11);
            this.PanelLayersVisibility.Location = new System.Drawing.Point(1270, 54);
            this.PanelLayersVisibility.Margin = new System.Windows.Forms.Padding(6);
            this.PanelLayersVisibility.Name = "PanelLayersVisibility";
            this.PanelLayersVisibility.Size = new System.Drawing.Size(384, 569);
            this.PanelLayersVisibility.TabIndex = 6;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "NewFile";
            this.OpenFileDialog.Filter = "Все файлы|*.mif;*.txt;*.grd|Layers (*.mif)|*.mif|grd files (*.grd)|*.grd|Geopoint" +
    "s file (*.txt)|*.txt";
            this.OpenFileDialog.Title = "Добавить слой";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1522, 1559);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.PanelLayersVisibility);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "View";
            this.Text = "MiniGIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.View_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.PanelChooseStyle.ResumeLayout(false);
            this.PanelChooseStyle.PerformLayout();
            this.PanelLayersVisibility.ResumeLayout(false);
            this.PanelLayersVisibility.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ColorDialog CDialogPoint;
        private System.Windows.Forms.ColorDialog CDialogLine;
        private System.Windows.Forms.ColorDialog CDialogPolygon;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MAP map;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private LayerControl LayerControl;
        private System.Windows.Forms.Panel PanelChooseStyle;
        private System.Windows.Forms.Button ChooseButtonPolygon;
        private System.Windows.Forms.Button ChooseButtonLine;
        private System.Windows.Forms.Button ChooseButtonPoint;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel PanelLayersVisibility;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ComboBox MaskLineWidth;
        private System.Windows.Forms.ComboBox MaskSymbolSize;
        private System.Windows.Forms.ComboBox MaskSymbolNumber;
        private System.Windows.Forms.ComboBox MaskSymbolFont;
        private System.Windows.Forms.Button ChooseBorderButton;
        private System.Windows.Forms.Label BorderStyleLabel;
        private System.Windows.Forms.ColorDialog BorderCDialog;
        private System.Windows.Forms.Button ShowBitmap;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
    }
}

