namespace iPos
{
    partial class WFReporteMovProvee
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
            this.mOVIMIENTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSFastReports = new iPos.Reportes.DSFastReports();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mOVIMIENTOSTableAdapter = new iPos.Reportes.DSFastReportsTableAdapters.MOVIMIENTOSTableAdapter();
            this.tableAdapterManager = new iPos.Reportes.DSFastReportsTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.mOVIMIENTOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSFastReports)).BeginInit();
            this.SuspendLayout();
            // 
            // mOVIMIENTOSBindingSource
            // 
            this.mOVIMIENTOSBindingSource.DataMember = "MOVIMIENTOS";
            this.mOVIMIENTOSBindingSource.DataSource = this.dSFastReports;
            // 
            // dSFastReports
            // 
            this.dSFastReports.DataSetName = "DSFastReports";
            this.dSFastReports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.mOVIMIENTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPos.Reportes.MultiNivel.RptMovimientosProveedores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(626, 518);
            this.reportViewer1.TabIndex = 0;
            // 
            // mOVIMIENTOSTableAdapter
            // 
            this.mOVIMIENTOSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Reportes.DSFastReportsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFReporteMovProvee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.FONDO_IPOS_SIN_LOGO;
            this.ClientSize = new System.Drawing.Size(626, 518);
            this.Controls.Add(this.reportViewer1);
            this.Name = "WFReporteMovProvee";
            this.Text = "WFReporteMovProvee";
            this.Load += new System.EventHandler(this.WFReporteMovProvee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mOVIMIENTOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSFastReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSFastReports dSFastReports;
        private System.Windows.Forms.BindingSource mOVIMIENTOSBindingSource;
        private Reportes.DSFastReportsTableAdapters.MOVIMIENTOSTableAdapter mOVIMIENTOSTableAdapter;
        private Reportes.DSFastReportsTableAdapters.TableAdapterManager tableAdapterManager;
    }
}