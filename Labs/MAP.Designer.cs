namespace Labs
{
    partial class MAP
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
            this.SuspendLayout();
            // 
            // MAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            this.Name = "MAP";
            this.Size = new System.Drawing.Size(211, 173);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MAP_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MAP_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAP_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MAP_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MAP_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
