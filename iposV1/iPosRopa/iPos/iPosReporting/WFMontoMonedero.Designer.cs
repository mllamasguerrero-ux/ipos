namespace iPosReporting
{
    partial class WFMontoMonedero
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMontoMonedero));
            this.MONEDEROBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSReportIpos2 = new iPosReporting.DSReportIpos2();
            this.MONEDEROMOVTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mONEDERONOABONADOS_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReportIpos = new iPosReporting.DSReportIpos();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rptResumen = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rptDesglosado = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rptNoAbonado = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.MONEDEROTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.MONEDEROTableAdapter();
            this.MONEDEROMOVTOTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.MONEDEROMOVTOTableAdapter();
            this.mONEDERONOABONADOS_TableAdapter1 = new iPosReporting.DSReportIposTableAdapters.MONEDERONOABONADOS_TableAdapter();
            this.tableAdapterManager = new iPosReporting.DSReportIposTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.MONEDEROBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEDEROMOVTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONEDERONOABONADOS_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MONEDEROBindingSource
            // 
            this.MONEDEROBindingSource.DataMember = "MONEDERO";
            this.MONEDEROBindingSource.DataSource = this.DSReportIpos2;
            // 
            // DSReportIpos2
            // 
            this.DSReportIpos2.DataSetName = "DSReportIpos2";
            this.DSReportIpos2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MONEDEROMOVTOBindingSource
            // 
            this.MONEDEROMOVTOBindingSource.DataMember = "MONEDEROMOVTO";
            this.MONEDEROMOVTOBindingSource.DataSource = this.DSReportIpos2;
            // 
            // mONEDERONOABONADOS_BindingSource
            // 
            this.mONEDERONOABONADOS_BindingSource.DataMember = "MONEDERONOABONADOS_";
            this.mONEDERONOABONADOS_BindingSource.DataSource = this.dSReportIpos;
            // 
            // dSReportIpos
            // 
            this.dSReportIpos.DataSetName = "DSReportIpos";
            this.dSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 266);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rptResumen);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(933, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RESUMEN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rptResumen
            // 
            this.rptResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MONEDEROBindingSource;
            this.rptResumen.LocalReport.DataSources.Add(reportDataSource1);
            this.rptResumen.LocalReport.ReportEmbeddedResource = "iPosReporting.RptMonedero.rdlc";
            this.rptResumen.Location = new System.Drawing.Point(3, 3);
            this.rptResumen.Name = "rptResumen";
            this.rptResumen.Size = new System.Drawing.Size(927, 234);
            this.rptResumen.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rptDesglosado);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(933, 240);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DESGLOSADO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rptDesglosado
            // 
            this.rptDesglosado.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.MONEDEROMOVTOBindingSource;
            this.rptDesglosado.LocalReport.DataSources.Add(reportDataSource2);
            this.rptDesglosado.LocalReport.ReportEmbeddedResource = "iPosReporting.RptMonederoDetalle.rdlc";
            this.rptDesglosado.Location = new System.Drawing.Point(3, 3);
            this.rptDesglosado.Name = "rptDesglosado";
            this.rptDesglosado.Size = new System.Drawing.Size(927, 234);
            this.rptDesglosado.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rptNoAbonado);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(933, 240);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "NO APLICADO";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rptNoAbonado
            // 
            this.rptNoAbonado.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.mONEDERONOABONADOS_BindingSource;
            this.rptNoAbonado.LocalReport.DataSources.Add(reportDataSource3);
            this.rptNoAbonado.LocalReport.ReportEmbeddedResource = "iPosReporting.RptMonederoNoAbonadosB.rdlc";
            this.rptNoAbonado.Location = new System.Drawing.Point(3, 3);
            this.rptNoAbonado.Name = "rptNoAbonado";
            this.rptNoAbonado.Size = new System.Drawing.Size(927, 234);
            this.rptNoAbonado.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 79);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(187, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desde:";
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(234, 39);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 8;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(691, 32);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 34);
            this.BTEnviar.TabIndex = 11;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(452, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "A:";
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(474, 39);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "REPORTES DE USO DE MONEDERO ELECTRONICO";
            // 
            // MONEDEROTableAdapter
            // 
            this.MONEDEROTableAdapter.ClearBeforeFill = true;
            // 
            // MONEDEROMOVTOTableAdapter
            // 
            this.MONEDEROMOVTOTableAdapter.ClearBeforeFill = true;
            // 
            // mONEDERONOABONADOS_TableAdapter1
            // 
            this.mONEDERONOABONADOS_TableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CLIENTESTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PRODUCTO1TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSReportIposTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFMontoMonedero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(941, 345);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMontoMonedero";
            this.Text = "Monto de Monedero";
            this.Load += new System.EventHandler(this.WFMontoMonedero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MONEDEROBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEDEROMOVTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONEDERONOABONADOS_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer rptResumen;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer rptDesglosado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource MONEDEROBindingSource;
        private DSReportIpos2 DSReportIpos2;
        private DSReportIpos2TableAdapters.MONEDEROTableAdapter MONEDEROTableAdapter;
        private System.Windows.Forms.BindingSource MONEDEROMOVTOBindingSource;
        private DSReportIpos2TableAdapters.MONEDEROMOVTOTableAdapter MONEDEROMOVTOTableAdapter;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer rptNoAbonado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private DSReportIpos dSReportIpos;
        private System.Windows.Forms.BindingSource mONEDERONOABONADOS_BindingSource;
        private DSReportIposTableAdapters.MONEDERONOABONADOS_TableAdapter mONEDERONOABONADOS_TableAdapter1;
        private DSReportIposTableAdapters.TableAdapterManager tableAdapterManager;
    }
}