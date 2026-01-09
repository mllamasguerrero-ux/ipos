namespace iPos
{
    partial class WFImportarDeExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportarDeExcel));
            this.BTImpCatExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTImpCatExcel
            // 
            this.BTImpCatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImpCatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImpCatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImpCatExcel.ForeColor = System.Drawing.Color.White;
            this.BTImpCatExcel.Location = new System.Drawing.Point(87, 48);
            this.BTImpCatExcel.Name = "BTImpCatExcel";
            this.BTImpCatExcel.Size = new System.Drawing.Size(119, 50);
            this.BTImpCatExcel.TabIndex = 10;
            this.BTImpCatExcel.Text = "Importar catalogos desde Excel";
            this.BTImpCatExcel.UseVisualStyleBackColor = false;
            this.BTImpCatExcel.Click += new System.EventHandler(this.BTImpCatExcel_Click);
            // 
            // WFImportarDeExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(285, 152);
            this.Controls.Add(this.BTImpCatExcel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportarDeExcel";
            this.Text = "Importar De Excel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTImpCatExcel;
    }
}