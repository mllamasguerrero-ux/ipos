namespace iPosReporting
{
    partial class FRptClientes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptClientes));
            this.CLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSReportIpos = new iPosReporting.DSReportIpos();
            this.CLIENTESTableAdapter = new iPosReporting.DSReportIposTableAdapters.CLIENTESTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CLIENTESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos)).BeginInit();
            this.SuspendLayout();
            // 
            // CLIENTESBindingSource
            // 
            this.CLIENTESBindingSource.DataMember = "CLIENTES";
            this.CLIENTESBindingSource.DataSource = this.DSReportIpos;
            // 
            // DSReportIpos
            // 
            this.DSReportIpos.DataSetName = "DSReportIpos";
            this.DSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CLIENTESTableAdapter
            // 
            this.CLIENTESTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSReportIpos_CLIENTES";
            reportDataSource1.Value = this.CLIENTESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // FRptClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptClientes";
            this.Text = "Reporte de Clientes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CLIENTESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.BindingSource CLIENTESBindingSource;
        private DSReportIpos DSReportIpos;
        private iPosReporting.DSReportIposTableAdapters.CLIENTESTableAdapter CLIENTESTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}

