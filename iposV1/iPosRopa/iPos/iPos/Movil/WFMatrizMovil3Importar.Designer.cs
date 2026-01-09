namespace iPos
{
    partial class WFMatrizMovil3Importar
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BTCatalogos = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnAplicarDatosVendedorMovil = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(89, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(163, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // BTCatalogos
            // 
            this.BTCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCatalogos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCatalogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCatalogos.ForeColor = System.Drawing.Color.White;
            this.BTCatalogos.Location = new System.Drawing.Point(89, 53);
            this.BTCatalogos.Name = "BTCatalogos";
            this.BTCatalogos.Size = new System.Drawing.Size(163, 52);
            this.BTCatalogos.TabIndex = 3;
            this.BTCatalogos.Text = "Importar datos de vendedores moviles";
            this.BTCatalogos.UseVisualStyleBackColor = false;
            this.BTCatalogos.Click += new System.EventHandler(this.BTCatalogos_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(89, 262);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(163, 23);
            this.progressBar2.TabIndex = 6;
            // 
            // btnAplicarDatosVendedorMovil
            // 
            this.btnAplicarDatosVendedorMovil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAplicarDatosVendedorMovil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAplicarDatosVendedorMovil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarDatosVendedorMovil.ForeColor = System.Drawing.Color.White;
            this.btnAplicarDatosVendedorMovil.Location = new System.Drawing.Point(89, 204);
            this.btnAplicarDatosVendedorMovil.Name = "btnAplicarDatosVendedorMovil";
            this.btnAplicarDatosVendedorMovil.Size = new System.Drawing.Size(163, 52);
            this.btnAplicarDatosVendedorMovil.TabIndex = 5;
            this.btnAplicarDatosVendedorMovil.Text = "Aplicar datos de vendedores moviles";
            this.btnAplicarDatosVendedorMovil.UseVisualStyleBackColor = false;
            this.btnAplicarDatosVendedorMovil.Click += new System.EventHandler(this.btnAplicarDatosVendedorMovil_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // WFMatrizMovil3Importar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(367, 332);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.btnAplicarDatosVendedorMovil);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BTCatalogos);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WFMatrizMovil3Importar";
            this.Text = "Importar datos de vendedores moviles";
            this.Load += new System.EventHandler(this.WFMatrizMovil3Importar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button BTCatalogos;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btnAplicarDatosVendedorMovil;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}