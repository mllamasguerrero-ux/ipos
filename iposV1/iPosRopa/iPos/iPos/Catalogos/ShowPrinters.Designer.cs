namespace iPos
{
    partial class ShowPrinters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPrinters));
            this.dtgvListOfPrinters = new System.Windows.Forms.DataGridViewSum();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListOfPrinters)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvListOfPrinters
            // 
            this.dtgvListOfPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListOfPrinters.Location = new System.Drawing.Point(12, 23);
            this.dtgvListOfPrinters.Name = "dtgvListOfPrinters";
            this.dtgvListOfPrinters.Size = new System.Drawing.Size(258, 298);
            this.dtgvListOfPrinters.TabIndex = 0;
            this.dtgvListOfPrinters.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListOfPrinters_CellDoubleClick);
            // 
            // ShowPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(282, 347);
            this.Controls.Add(this.dtgvListOfPrinters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowPrinters";
            this.Text = "ShowPrinters";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListOfPrinters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewSum dtgvListOfPrinters;
    }
}