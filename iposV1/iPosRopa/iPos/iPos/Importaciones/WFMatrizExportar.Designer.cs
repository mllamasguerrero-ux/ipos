namespace iPos
{
    partial class WFMatrizExportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMatrizExportar));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BTCatalogos = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(70, 104);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(132, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // BTCatalogos
            // 
            this.BTCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCatalogos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCatalogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCatalogos.ForeColor = System.Drawing.Color.White;
            this.BTCatalogos.Location = new System.Drawing.Point(70, 46);
            this.BTCatalogos.Name = "BTCatalogos";
            this.BTCatalogos.Size = new System.Drawing.Size(132, 52);
            this.BTCatalogos.TabIndex = 5;
            this.BTCatalogos.Text = "Exportar precios y otros catalogos";
            this.BTCatalogos.UseVisualStyleBackColor = false;
            this.BTCatalogos.Click += new System.EventHandler(this.BTCatalogos_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WFMatrizExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(265, 184);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BTCatalogos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMatrizExportar";
            this.Text = "Exportar";
            this.Load += new System.EventHandler(this.WFMatrizExportar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button BTCatalogos;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}