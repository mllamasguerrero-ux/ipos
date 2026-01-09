namespace iPos.Contabilidad
{
    partial class WFGenerarPolizas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFGenerarPolizas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPdf = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeneratePolizas = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dSContabilidad1 = new iPos.Contabilidad.DSContabilidad();
            this.pOLIZALINEA_DETBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOLIZALINEA_DETTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.POLIZALINEA_DETTableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pOLIZALINEA_HDRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOLIZALINEA_HDRTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.POLIZALINEA_HDRTableAdapter();
            this.pOLIZALINEA_DET_PVCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOLIZALINEA_DET_PVCTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.POLIZALINEA_DET_PVCTableAdapter();
            this.btnExportarIngresuc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOLIZALINEA_DETBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOLIZALINEA_HDRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOLIZALINEA_DET_PVCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnExportarIngresuc);
            this.panel1.Controls.Add(this.btnPdf);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGeneratePolizas);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 342);
            this.panel1.TabIndex = 0;
            // 
            // btnPdf
            // 
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.Location = new System.Drawing.Point(142, 226);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(115, 23);
            this.btnPdf.TabIndex = 6;
            this.btnPdf.Text = "Enviar PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(84, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(202, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Generar por rango de fechas:";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(138, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generar Pólizas";
            // 
            // btnGeneratePolizas
            // 
            this.btnGeneratePolizas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePolizas.ForeColor = System.Drawing.Color.White;
            this.btnGeneratePolizas.Location = new System.Drawing.Point(142, 174);
            this.btnGeneratePolizas.Name = "btnGeneratePolizas";
            this.btnGeneratePolizas.Size = new System.Drawing.Size(115, 23);
            this.btnGeneratePolizas.TabIndex = 3;
            this.btnGeneratePolizas.Text = "Enviar TXT";
            this.btnGeneratePolizas.UseVisualStyleBackColor = true;
            this.btnGeneratePolizas.Click += new System.EventHandler(this.btnGeneratePolizas_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(142, 122);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(115, 20);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.Visible = false;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(142, 87);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(115, 20);
            this.dtpBegin.TabIndex = 1;
            // 
            // dSContabilidad1
            // 
            this.dSContabilidad1.DataSetName = "DSContabilidad";
            this.dSContabilidad1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pOLIZALINEA_DETBindingSource
            // 
            this.pOLIZALINEA_DETBindingSource.DataMember = "POLIZALINEA_DET";
            this.pOLIZALINEA_DETBindingSource.DataSource = this.dSContabilidad1;
            // 
            // pOLIZALINEA_DETTableAdapter
            // 
            this.pOLIZALINEA_DETTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pOLIZALINEA_HDRBindingSource
            // 
            this.pOLIZALINEA_HDRBindingSource.DataMember = "POLIZALINEA_HDR";
            this.pOLIZALINEA_HDRBindingSource.DataSource = this.dSContabilidad1;
            // 
            // pOLIZALINEA_HDRTableAdapter
            // 
            this.pOLIZALINEA_HDRTableAdapter.ClearBeforeFill = true;
            // 
            // pOLIZALINEA_DET_PVCBindingSource
            // 
            this.pOLIZALINEA_DET_PVCBindingSource.DataMember = "POLIZALINEA_DET_PVC";
            this.pOLIZALINEA_DET_PVCBindingSource.DataSource = this.dSContabilidad1;
            // 
            // pOLIZALINEA_DET_PVCTableAdapter
            // 
            this.pOLIZALINEA_DET_PVCTableAdapter.ClearBeforeFill = true;
            // 
            // btnExportarIngresuc
            // 
            this.btnExportarIngresuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarIngresuc.ForeColor = System.Drawing.Color.White;
            this.btnExportarIngresuc.Location = new System.Drawing.Point(145, 287);
            this.btnExportarIngresuc.Name = "btnExportarIngresuc";
            this.btnExportarIngresuc.Size = new System.Drawing.Size(115, 23);
            this.btnExportarIngresuc.TabIndex = 7;
            this.btnExportarIngresuc.Text = "Exportar ingresuc";
            this.btnExportarIngresuc.UseVisualStyleBackColor = true;
            this.btnExportarIngresuc.Click += new System.EventHandler(this.btnExportarIngresuc_Click);
            // 
            // WFGenerarPolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(404, 354);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFGenerarPolizas";
            this.Text = "Pólizas";
            this.Load += new System.EventHandler(this.WFGenerarPolizas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOLIZALINEA_DETBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOLIZALINEA_HDRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOLIZALINEA_DET_PVCBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGeneratePolizas;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private DSContabilidad dSContabilidad1;
        private System.Windows.Forms.BindingSource pOLIZALINEA_DETBindingSource;
        private DSContabilidadTableAdapters.POLIZALINEA_DETTableAdapter pOLIZALINEA_DETTableAdapter;
        private DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.BindingSource pOLIZALINEA_HDRBindingSource;
        private DSContabilidadTableAdapters.POLIZALINEA_HDRTableAdapter pOLIZALINEA_HDRTableAdapter;
        private System.Windows.Forms.BindingSource pOLIZALINEA_DET_PVCBindingSource;
        private DSContabilidadTableAdapters.POLIZALINEA_DET_PVCTableAdapter pOLIZALINEA_DET_PVCTableAdapter;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnExportarIngresuc;
    }
}