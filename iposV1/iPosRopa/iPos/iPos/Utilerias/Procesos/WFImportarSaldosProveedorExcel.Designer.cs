namespace iPos.Utilerias.Procesos
{
    partial class WFImportarSaldosProveedorExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFImportarSaldosProveedorExcel));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTImpCatalogos = new System.Windows.Forms.Button();
            this.TBImpCatalogos = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(275, 23);
            this.progressBar1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(101, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 48);
            this.label2.TabIndex = 21;
            this.label2.Text = "IMPORTAR SALDOS \r\nPROVEEDORES EXCEL";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.BTEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTEnviar.Location = new System.Drawing.Point(151, 191);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(122, 42);
            this.BTEnviar.TabIndex = 20;
            this.BTEnviar.Text = "Cargar";
            this.BTEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccione el archivo:";
            // 
            // BTImpCatalogos
            // 
            this.BTImpCatalogos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTImpCatalogos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTImpCatalogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTImpCatalogos.ForeColor = System.Drawing.Color.White;
            this.BTImpCatalogos.Image = global::iPos.Properties.Resources.searchNoBack_J;
            this.BTImpCatalogos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTImpCatalogos.Location = new System.Drawing.Point(295, 98);
            this.BTImpCatalogos.Name = "BTImpCatalogos";
            this.BTImpCatalogos.Size = new System.Drawing.Size(107, 37);
            this.BTImpCatalogos.TabIndex = 18;
            this.BTImpCatalogos.Text = "Explorar";
            this.BTImpCatalogos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTImpCatalogos.UseVisualStyleBackColor = false;
            this.BTImpCatalogos.Click += new System.EventHandler(this.BTImpCatalogos_Click);
            // 
            // TBImpCatalogos
            // 
            this.TBImpCatalogos.Location = new System.Drawing.Point(13, 107);
            this.TBImpCatalogos.Name = "TBImpCatalogos";
            this.TBImpCatalogos.Size = new System.Drawing.Size(275, 20);
            this.TBImpCatalogos.TabIndex = 17;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // WFImportarSaldosProveedorExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(414, 236);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTImpCatalogos);
            this.Controls.Add(this.TBImpCatalogos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFImportarSaldosProveedorExcel";
            this.Text = "Importar Saldos Proveedor Excel";
            this.Load += new System.EventHandler(this.WFImportarSaldosProveedorExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTImpCatalogos;
        private System.Windows.Forms.TextBox TBImpCatalogos;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}