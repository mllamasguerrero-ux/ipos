namespace iPos
{
    partial class WFExportarAExcel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFExportarAExcel));
            this.BTProductos = new System.Windows.Forms.Button();
            this.dSImportaciones = new iPos.Importaciones.DSImportaciones();
            this.pRODUCTOS_EXPORTVIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOS_EXPORTVIEWTableAdapter = new iPos.Importaciones.DSImportacionesTableAdapters.PRODUCTOS_EXPORTVIEWTableAdapter();
            this.tableAdapterManager = new iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOS_EXPORTVIEWBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BTProductos
            // 
            this.BTProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTProductos.ForeColor = System.Drawing.Color.White;
            this.BTProductos.Location = new System.Drawing.Point(87, 47);
            this.BTProductos.Name = "BTProductos";
            this.BTProductos.Size = new System.Drawing.Size(113, 54);
            this.BTProductos.TabIndex = 0;
            this.BTProductos.Text = "Productos";
            this.BTProductos.UseVisualStyleBackColor = false;
            this.BTProductos.Click += new System.EventHandler(this.BTProductos_Click);
            // 
            // dSImportaciones
            // 
            this.dSImportaciones.DataSetName = "DSImportaciones";
            this.dSImportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRODUCTOS_EXPORTVIEWBindingSource
            // 
            this.pRODUCTOS_EXPORTVIEWBindingSource.DataMember = "PRODUCTOS_EXPORTVIEW";
            this.pRODUCTOS_EXPORTVIEWBindingSource.DataSource = this.dSImportaciones;
            // 
            // pRODUCTOS_EXPORTVIEWTableAdapter
            // 
            this.pRODUCTOS_EXPORTVIEWTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Importaciones.DSImportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(87, 107);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(113, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WFExportarAExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(283, 181);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BTProductos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFExportarAExcel";
            this.Text = "Exportar a excel";
            this.Load += new System.EventHandler(this.WFExportarAExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSImportaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOS_EXPORTVIEWBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTProductos;
        private Importaciones.DSImportaciones dSImportaciones;
        private System.Windows.Forms.BindingSource pRODUCTOS_EXPORTVIEWBindingSource;
        private Importaciones.DSImportacionesTableAdapters.PRODUCTOS_EXPORTVIEWTableAdapter pRODUCTOS_EXPORTVIEWTableAdapter;
        private Importaciones.DSImportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}