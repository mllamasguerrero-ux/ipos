namespace iPos.Reportes.Ventas
{
    partial class WFReporteConciliacionEmida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReporteConciliacionEmida));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateConciliacion = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dSContabilidad1 = new iPos.Contabilidad.DSContabilidad();
            this.rEQUESTEMIDACONCILIACIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rEQUESTEMIDACONCILIACIONTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.REQUESTEMIDACONCILIACIONTableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEQUESTEMIDACONCILIACIONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerateConciliacion);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Location = new System.Drawing.Point(12, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 226);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generar reporte conciliación recargas emida";
            // 
            // btnGenerateConciliacion
            // 
            this.btnGenerateConciliacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGenerateConciliacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGenerateConciliacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateConciliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnGenerateConciliacion.ForeColor = System.Drawing.Color.White;
            this.btnGenerateConciliacion.Location = new System.Drawing.Point(146, 156);
            this.btnGenerateConciliacion.Name = "btnGenerateConciliacion";
            this.btnGenerateConciliacion.Size = new System.Drawing.Size(79, 25);
            this.btnGenerateConciliacion.TabIndex = 3;
            this.btnGenerateConciliacion.Text = "Enviar";
            this.btnGenerateConciliacion.UseVisualStyleBackColor = false;
            this.btnGenerateConciliacion.Click += new System.EventHandler(this.btnGenerateConciliacion_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(130, 87);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(115, 20);
            this.dtpEnd.TabIndex = 2;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(130, 52);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(115, 20);
            this.dtpBegin.TabIndex = 1;
            // 
            // dSContabilidad1
            // 
            this.dSContabilidad1.DataSetName = "DSContabilidad";
            this.dSContabilidad1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rEQUESTEMIDACONCILIACIONBindingSource
            // 
            this.rEQUESTEMIDACONCILIACIONBindingSource.DataMember = "REQUESTEMIDACONCILIACION";
            this.rEQUESTEMIDACONCILIACIONBindingSource.DataSource = this.dSContabilidad1;
            // 
            // rEQUESTEMIDACONCILIACIONTableAdapter
            // 
            this.rEQUESTEMIDACONCILIACIONTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFReporteConciliacionEmida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(386, 267);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReporteConciliacionEmida";
            this.Text = "Reporte Conciliacion Recargas Emida";
            this.Load += new System.EventHandler(this.WFReporteConciliacionEmida_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEQUESTEMIDACONCILIACIONBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateConciliacion;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private iPos.Contabilidad.DSContabilidad dSContabilidad1;
        private System.Windows.Forms.BindingSource rEQUESTEMIDACONCILIACIONBindingSource;
        private iPos.Contabilidad.DSContabilidadTableAdapters.REQUESTEMIDACONCILIACIONTableAdapter rEQUESTEMIDACONCILIACIONTableAdapter;
        private iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}