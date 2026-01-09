namespace iPos.Utilerias.Procesos
{
    partial class WFImportarVentasDBFGiralda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportarVentasDBFGiralda));
            this.btnImportDetail = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BTImpCatalogos = new System.Windows.Forms.Button();
            this.TBImpVentasHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.BTImpVentas = new System.Windows.Forms.Button();
            this.TBImpVentasDetalle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BTImpDevHeader = new System.Windows.Forms.Button();
            this.TBImpDevolucionesHeader = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnImportDetail
            // 
            this.btnImportDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnImportDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImportDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportDetail.ForeColor = System.Drawing.Color.White;
            this.btnImportDetail.Location = new System.Drawing.Point(167, 253);
            this.btnImportDetail.Name = "btnImportDetail";
            this.btnImportDetail.Size = new System.Drawing.Size(102, 23);
            this.btnImportDetail.TabIndex = 1;
            this.btnImportDetail.Text = "Importar";
            this.btnImportDetail.UseVisualStyleBackColor = false;
            this.btnImportDetail.Click += new System.EventHandler(this.btnImportDetail_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 216);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(390, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seleccione el archivo del Header De Ventas:";
            // 
            // BTImpCatalogos
            // 
            this.BTImpCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImpCatalogos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImpCatalogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImpCatalogos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.BTImpCatalogos.ForeColor = System.Drawing.Color.White;
            this.BTImpCatalogos.Image = ((System.Drawing.Image)(resources.GetObject("BTImpCatalogos.Image")));
            this.BTImpCatalogos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTImpCatalogos.Location = new System.Drawing.Point(301, 71);
            this.BTImpCatalogos.Name = "BTImpCatalogos";
            this.BTImpCatalogos.Size = new System.Drawing.Size(107, 35);
            this.BTImpCatalogos.TabIndex = 12;
            this.BTImpCatalogos.Text = "Explorar";
            this.BTImpCatalogos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTImpCatalogos.UseVisualStyleBackColor = false;
            this.BTImpCatalogos.Click += new System.EventHandler(this.BTImpCatalogos_Click);
            // 
            // TBImpVentasHeader
            // 
            this.TBImpVentasHeader.Location = new System.Drawing.Point(20, 80);
            this.TBImpVentasHeader.Name = "TBImpVentasHeader";
            this.TBImpVentasHeader.Size = new System.Drawing.Size(275, 20);
            this.TBImpVentasHeader.TabIndex = 11;
            this.TBImpVentasHeader.Text = "C:\\temporal\\oblatos\\tienda contado\\VENTAS.DBF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(88, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "IMPORTAR VENTAS DBF";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Seleccione el archivo del Detalle:";
            // 
            // BTImpVentas
            // 
            this.BTImpVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImpVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImpVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImpVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.BTImpVentas.ForeColor = System.Drawing.Color.White;
            this.BTImpVentas.Image = ((System.Drawing.Image)(resources.GetObject("BTImpVentas.Image")));
            this.BTImpVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTImpVentas.Location = new System.Drawing.Point(301, 121);
            this.BTImpVentas.Name = "BTImpVentas";
            this.BTImpVentas.Size = new System.Drawing.Size(107, 35);
            this.BTImpVentas.TabIndex = 17;
            this.BTImpVentas.Text = "Explorar";
            this.BTImpVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTImpVentas.UseVisualStyleBackColor = false;
            this.BTImpVentas.Click += new System.EventHandler(this.BTImpVentas_Click);
            // 
            // TBImpVentasDetalle
            // 
            this.TBImpVentasDetalle.Location = new System.Drawing.Point(20, 130);
            this.TBImpVentasDetalle.Name = "TBImpVentasDetalle";
            this.TBImpVentasDetalle.Size = new System.Drawing.Size(275, 20);
            this.TBImpVentasDetalle.TabIndex = 16;
            this.TBImpVentasDetalle.Text = "C:\\temporal\\oblatos\\tienda contado\\DETALLEVENTAS.DBF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Seleccione el archivo del Header de Devoluciónes:";
            // 
            // BTImpDevHeader
            // 
            this.BTImpDevHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImpDevHeader.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImpDevHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImpDevHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.BTImpDevHeader.ForeColor = System.Drawing.Color.White;
            this.BTImpDevHeader.Image = ((System.Drawing.Image)(resources.GetObject("BTImpDevHeader.Image")));
            this.BTImpDevHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTImpDevHeader.Location = new System.Drawing.Point(301, 170);
            this.BTImpDevHeader.Name = "BTImpDevHeader";
            this.BTImpDevHeader.Size = new System.Drawing.Size(107, 35);
            this.BTImpDevHeader.TabIndex = 20;
            this.BTImpDevHeader.Text = "Explorar";
            this.BTImpDevHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTImpDevHeader.UseVisualStyleBackColor = false;
            this.BTImpDevHeader.Click += new System.EventHandler(this.BTImpDevHeader_Click);
            // 
            // TBImpDevolucionesHeader
            // 
            this.TBImpDevolucionesHeader.Location = new System.Drawing.Point(20, 179);
            this.TBImpDevolucionesHeader.Name = "TBImpDevolucionesHeader";
            this.TBImpDevolucionesHeader.Size = new System.Drawing.Size(275, 20);
            this.TBImpDevolucionesHeader.TabIndex = 19;
            this.TBImpDevolucionesHeader.Text = "C:\\temporal\\oblatos\\tienda contado\\DEVOHEADERCONTADO.dbf";
            // 
            // WFImportarVentasDBFGiralda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(433, 287);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTImpDevHeader);
            this.Controls.Add(this.TBImpDevolucionesHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTImpVentas);
            this.Controls.Add(this.TBImpVentasDetalle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTImpCatalogos);
            this.Controls.Add(this.TBImpVentasHeader);
            this.Controls.Add(this.btnImportDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportarVentasDBFGiralda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Ventas DBF Giralda";
            this.Load += new System.EventHandler(this.WFImportarVentasDBFGiralda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportDetail;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTImpCatalogos;
        private System.Windows.Forms.TextBox TBImpVentasHeader;
        private System.Windows.Forms.Label label2;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTImpVentas;
        private System.Windows.Forms.TextBox TBImpVentasDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTImpDevHeader;
        private System.Windows.Forms.TextBox TBImpDevolucionesHeader;
    }
}