namespace iPos
{
    partial class WFImportar
    {
        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportar));
            this.BTCatalogos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.BTImportarTraslados = new System.Windows.Forms.Button();
            this.prBrTraslados = new System.Windows.Forms.ProgressBar();
            this.bgWorkTraslados = new System.ComponentModel.BackgroundWorker();
            this.prBrExistencias = new System.Windows.Forms.ProgressBar();
            this.BTImportarExistencias = new System.Windows.Forms.Button();
            this.bgWorkExistencias = new System.ComponentModel.BackgroundWorker();
            this.BTLimpiarCat = new System.Windows.Forms.Button();
            this.BTImportarPreciosNuevos = new System.Windows.Forms.Button();
            this.prBrTrasladosDevo = new System.Windows.Forms.ProgressBar();
            this.BTImportarTrasladosDevo = new System.Windows.Forms.Button();
            this.bgWorkTrasladosDevo = new System.ComponentModel.BackgroundWorker();
            this.prBrSolicitudesMerca = new System.Windows.Forms.ProgressBar();
            this.BTImportarSolicitudesMercancia = new System.Windows.Forms.Button();
            this.bgWorkSolicitudesMerca = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BTCatalogos
            // 
            this.BTCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCatalogos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCatalogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCatalogos.ForeColor = System.Drawing.Color.White;
            this.BTCatalogos.Location = new System.Drawing.Point(13, 14);
            this.BTCatalogos.Name = "BTCatalogos";
            this.BTCatalogos.Size = new System.Drawing.Size(132, 52);
            this.BTCatalogos.TabIndex = 0;
            this.BTCatalogos.Text = "Importar catalogos";
            this.BTCatalogos.UseVisualStyleBackColor = false;
            this.BTCatalogos.Click += new System.EventHandler(this.BTCatalogos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(182, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Importar compras";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 72);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(132, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(182, 72);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(139, 23);
            this.progressBar2.TabIndex = 3;
            // 
            // BTImportarTraslados
            // 
            this.BTImportarTraslados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarTraslados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImportarTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImportarTraslados.ForeColor = System.Drawing.Color.White;
            this.BTImportarTraslados.Location = new System.Drawing.Point(345, 14);
            this.BTImportarTraslados.Name = "BTImportarTraslados";
            this.BTImportarTraslados.Size = new System.Drawing.Size(134, 52);
            this.BTImportarTraslados.TabIndex = 4;
            this.BTImportarTraslados.Text = "Importar traslados";
            this.BTImportarTraslados.UseVisualStyleBackColor = false;
            this.BTImportarTraslados.Click += new System.EventHandler(this.BTImportarTraslados_Click);
            // 
            // prBrTraslados
            // 
            this.prBrTraslados.Location = new System.Drawing.Point(345, 72);
            this.prBrTraslados.Name = "prBrTraslados";
            this.prBrTraslados.Size = new System.Drawing.Size(134, 23);
            this.prBrTraslados.TabIndex = 5;
            // 
            // bgWorkTraslados
            // 
            this.bgWorkTraslados.WorkerReportsProgress = true;
            this.bgWorkTraslados.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkTraslados_DoWork);
            this.bgWorkTraslados.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkTraslados_RunWorkerCompleted);
            // 
            // prBrExistencias
            // 
            this.prBrExistencias.Location = new System.Drawing.Point(13, 175);
            this.prBrExistencias.Name = "prBrExistencias";
            this.prBrExistencias.Size = new System.Drawing.Size(132, 23);
            this.prBrExistencias.TabIndex = 7;
            // 
            // BTImportarExistencias
            // 
            this.BTImportarExistencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarExistencias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImportarExistencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImportarExistencias.ForeColor = System.Drawing.Color.White;
            this.BTImportarExistencias.Location = new System.Drawing.Point(13, 119);
            this.BTImportarExistencias.Name = "BTImportarExistencias";
            this.BTImportarExistencias.Size = new System.Drawing.Size(134, 50);
            this.BTImportarExistencias.TabIndex = 6;
            this.BTImportarExistencias.Text = "Importar existencias de sucursales";
            this.BTImportarExistencias.UseVisualStyleBackColor = false;
            this.BTImportarExistencias.Click += new System.EventHandler(this.BTImportarExistencias_Click);
            // 
            // bgWorkExistencias
            // 
            this.bgWorkExistencias.WorkerReportsProgress = true;
            this.bgWorkExistencias.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkExistencias_DoWork);
            this.bgWorkExistencias.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkExistencias_RunWorkerCompleted);
            // 
            // BTLimpiarCat
            // 
            this.BTLimpiarCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTLimpiarCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTLimpiarCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTLimpiarCat.ForeColor = System.Drawing.Color.White;
            this.BTLimpiarCat.Location = new System.Drawing.Point(182, 119);
            this.BTLimpiarCat.Name = "BTLimpiarCat";
            this.BTLimpiarCat.Size = new System.Drawing.Size(139, 50);
            this.BTLimpiarCat.TabIndex = 8;
            this.BTLimpiarCat.Text = "Limpiar importacion catalogos";
            this.BTLimpiarCat.UseVisualStyleBackColor = false;
            this.BTLimpiarCat.Click += new System.EventHandler(this.BTLimpiarCat_Click);
            // 
            // BTImportarPreciosNuevos
            // 
            this.BTImportarPreciosNuevos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarPreciosNuevos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImportarPreciosNuevos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImportarPreciosNuevos.ForeColor = System.Drawing.Color.White;
            this.BTImportarPreciosNuevos.Location = new System.Drawing.Point(345, 117);
            this.BTImportarPreciosNuevos.Name = "BTImportarPreciosNuevos";
            this.BTImportarPreciosNuevos.Size = new System.Drawing.Size(132, 52);
            this.BTImportarPreciosNuevos.TabIndex = 9;
            this.BTImportarPreciosNuevos.Text = "Importar precios nuevos";
            this.BTImportarPreciosNuevos.UseVisualStyleBackColor = false;
            this.BTImportarPreciosNuevos.Click += new System.EventHandler(this.BTImportarPreciosNuevos_Click);
            // 
            // prBrTrasladosDevo
            // 
            this.prBrTrasladosDevo.Location = new System.Drawing.Point(13, 286);
            this.prBrTrasladosDevo.Name = "prBrTrasladosDevo";
            this.prBrTrasladosDevo.Size = new System.Drawing.Size(134, 23);
            this.prBrTrasladosDevo.TabIndex = 11;
            // 
            // BTImportarTrasladosDevo
            // 
            this.BTImportarTrasladosDevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarTrasladosDevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImportarTrasladosDevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImportarTrasladosDevo.ForeColor = System.Drawing.Color.White;
            this.BTImportarTrasladosDevo.Location = new System.Drawing.Point(12, 227);
            this.BTImportarTrasladosDevo.Name = "BTImportarTrasladosDevo";
            this.BTImportarTrasladosDevo.Size = new System.Drawing.Size(135, 52);
            this.BTImportarTrasladosDevo.TabIndex = 10;
            this.BTImportarTrasladosDevo.Text = "Importar devoluciones de traslados";
            this.BTImportarTrasladosDevo.UseVisualStyleBackColor = false;
            this.BTImportarTrasladosDevo.Click += new System.EventHandler(this.BTImportarTrasladosDevo_Click);
            // 
            // bgWorkTrasladosDevo
            // 
            this.bgWorkTrasladosDevo.WorkerReportsProgress = true;
            this.bgWorkTrasladosDevo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkTrasladosDevo_DoWork);
            this.bgWorkTrasladosDevo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkTrasladosDevo_RunWorkerCompleted);
            // 
            // prBrSolicitudesMerca
            // 
            this.prBrSolicitudesMerca.Location = new System.Drawing.Point(182, 285);
            this.prBrSolicitudesMerca.Name = "prBrSolicitudesMerca";
            this.prBrSolicitudesMerca.Size = new System.Drawing.Size(134, 23);
            this.prBrSolicitudesMerca.TabIndex = 13;
            // 
            // BTImportarSolicitudesMercancia
            // 
            this.BTImportarSolicitudesMercancia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImportarSolicitudesMercancia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImportarSolicitudesMercancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImportarSolicitudesMercancia.ForeColor = System.Drawing.Color.White;
            this.BTImportarSolicitudesMercancia.Location = new System.Drawing.Point(182, 227);
            this.BTImportarSolicitudesMercancia.Name = "BTImportarSolicitudesMercancia";
            this.BTImportarSolicitudesMercancia.Size = new System.Drawing.Size(134, 52);
            this.BTImportarSolicitudesMercancia.TabIndex = 12;
            this.BTImportarSolicitudesMercancia.Text = "Importar solicitudes de mercancia";
            this.BTImportarSolicitudesMercancia.UseVisualStyleBackColor = false;
            this.BTImportarSolicitudesMercancia.Click += new System.EventHandler(this.BTImportarSolicitudesMercancia_Click);
            // 
            // bgWorkSolicitudesMerca
            // 
            this.bgWorkSolicitudesMerca.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkSolicitudesMerca_DoWork);
            this.bgWorkSolicitudesMerca.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkSolicitudesMerca_RunWorkerCompleted);
            // 
            // WFImportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(497, 327);
            this.Controls.Add(this.prBrSolicitudesMerca);
            this.Controls.Add(this.BTImportarSolicitudesMercancia);
            this.Controls.Add(this.prBrTrasladosDevo);
            this.Controls.Add(this.BTImportarTrasladosDevo);
            this.Controls.Add(this.BTImportarPreciosNuevos);
            this.Controls.Add(this.BTLimpiarCat);
            this.Controls.Add(this.prBrExistencias);
            this.Controls.Add(this.BTImportarExistencias);
            this.Controls.Add(this.prBrTraslados);
            this.Controls.Add(this.BTImportarTraslados);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTCatalogos);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportar";
            this.Text = "Importaciones de FTP";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFImportarProd_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button BTCatalogos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button BTImportarTraslados;
        private System.Windows.Forms.ProgressBar prBrTraslados;
        private System.ComponentModel.BackgroundWorker bgWorkTraslados;
        private System.Windows.Forms.ProgressBar prBrExistencias;
        private System.Windows.Forms.Button BTImportarExistencias;
        private System.ComponentModel.BackgroundWorker bgWorkExistencias;
        private System.Windows.Forms.Button BTLimpiarCat;
        private System.Windows.Forms.Button BTImportarPreciosNuevos;
        private System.Windows.Forms.ProgressBar prBrTrasladosDevo;
        private System.Windows.Forms.Button BTImportarTrasladosDevo;
        private System.ComponentModel.BackgroundWorker bgWorkTrasladosDevo;
        private System.Windows.Forms.ProgressBar prBrSolicitudesMerca;
        private System.Windows.Forms.Button BTImportarSolicitudesMercancia;
        private System.ComponentModel.BackgroundWorker bgWorkSolicitudesMerca;

        //private Skinner.FormSkin formSkin1;
    }
}