namespace Labs
{
    partial class LayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView.AllowDrop = true;
            this.ListView.CheckBoxes = true;
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.HoverSelection = true;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(211, 238);
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.List;
            this.ListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ItemChecked);
            this.ListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListView_ItemDrag);
            this.ListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
            this.ListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
            this.ListView.DragOver += new System.Windows.Forms.DragEventHandler(this.ListView_DragOver);
            this.ListView.DragLeave += new System.EventHandler(this.ListView_DragLeave);
            // 
            // LayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView);
            this.Name = "LayerControl";
            this.Size = new System.Drawing.Size(211, 238);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView;
    }
}
