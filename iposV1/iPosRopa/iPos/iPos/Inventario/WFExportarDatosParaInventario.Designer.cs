namespace iPos
{
    partial class WFExportarDatosParaInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFExportarDatosParaInventario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBPrefijo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.TBCarpetaArchivos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.RBPorArchivos = new System.Windows.Forms.RadioButton();
            this.RBPorWebService = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnExportar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.TBPrefijo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSeleccionarCarpeta);
            this.groupBox1.Controls.Add(this.TBCarpetaArchivos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.RBPorArchivos);
            this.groupBox1.Controls.Add(this.RBPorWebService);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCIONE LA FORMA DE EXPORTAR EL INVENTARIO";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TBPrefijo
            // 
            this.TBPrefijo.Location = new System.Drawing.Point(152, 197);
            this.TBPrefijo.Name = "TBPrefijo";
            this.TBPrefijo.Size = new System.Drawing.Size(251, 20);
            this.TBPrefijo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prefijo:";
            // 
            // btnSeleccionarCarpeta
            // 
            this.btnSeleccionarCarpeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSeleccionarCarpeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSeleccionarCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(409, 144);
            this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(97, 23);
            this.btnSeleccionarCarpeta.TabIndex = 6;
            this.btnSeleccionarCarpeta.Text = "Seleccionar";
            this.btnSeleccionarCarpeta.UseVisualStyleBackColor = false;
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            // 
            // TBCarpetaArchivos
            // 
            this.TBCarpetaArchivos.Location = new System.Drawing.Point(152, 147);
            this.TBCarpetaArchivos.Name = "TBCarpetaArchivos";
            this.TBCarpetaArchivos.Size = new System.Drawing.Size(251, 20);
            this.TBCarpetaArchivos.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Carpeta destino:";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(257, 90);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(146, 24);
            this.progressBar2.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(257, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(146, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // RBPorArchivos
            // 
            this.RBPorArchivos.AutoSize = true;
            this.RBPorArchivos.Location = new System.Drawing.Point(65, 90);
            this.RBPorArchivos.Name = "RBPorArchivos";
            this.RBPorArchivos.Size = new System.Drawing.Size(84, 17);
            this.RBPorArchivos.TabIndex = 1;
            this.RBPorArchivos.TabStop = true;
            this.RBPorArchivos.Text = "Por archivos";
            this.RBPorArchivos.UseVisualStyleBackColor = true;
            this.RBPorArchivos.CheckedChanged += new System.EventHandler(this.RBPorArchivos_CheckedChanged);
            // 
            // RBPorWebService
            // 
            this.RBPorWebService.AutoSize = true;
            this.RBPorWebService.Location = new System.Drawing.Point(65, 43);
            this.RBPorWebService.Name = "RBPorWebService";
            this.RBPorWebService.Size = new System.Drawing.Size(98, 17);
            this.RBPorWebService.TabIndex = 0;
            this.RBPorWebService.TabStop = true;
            this.RBPorWebService.Text = "Por webservice";
            this.RBPorWebService.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(218, 299);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(144, 33);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WFExportarDatosParaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(577, 344);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFExportarDatosParaInventario";
            this.Text = "Exportar datos para inventario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton RBPorArchivos;
        private System.Windows.Forms.RadioButton RBPorWebService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox TBPrefijo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSeleccionarCarpeta;
        private System.Windows.Forms.TextBox TBCarpetaArchivos;
        private System.Windows.Forms.Button btnExportar;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}