namespace iPosReporting
{
    partial class WFRptInventarioXLoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRptInventarioXLoc));
            this.INVENTARIOXLOC_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSIposReportingC = new iPosReporting.DSIposReportingC();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.INVENTARIOXLOC_VIEWTableAdapter = new iPosReporting.DSIposReportingCTableAdapters.INVENTARIOXLOC_VIEWTableAdapter();
            this.PRODUCTOLOCATIONSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PRODUCTOLOCATIONSTableAdapter = new iPosReporting.DSIposReportingCTableAdapters.PRODUCTOLOCATIONSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.INVENTARIOXLOC_VIEWBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSIposReportingC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOLOCATIONSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // INVENTARIOXLOC_VIEWBindingSource
            // 
            this.INVENTARIOXLOC_VIEWBindingSource.DataMember = "INVENTARIOXLOC_VIEW";
            this.INVENTARIOXLOC_VIEWBindingSource.DataSource = this.DSIposReportingC;
            // 
            // DSIposReportingC
            // 
            this.DSIposReportingC.DataSetName = "DSIposReportingC";
            this.DSIposReportingC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.INVENTARIOXLOC_VIEWBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.RptInventarioXLoc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(686, 325);
            this.reportViewer1.TabIndex = 0;
            // 
            // INVENTARIOXLOC_VIEWTableAdapter
            // 
            this.INVENTARIOXLOC_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // PRODUCTOLOCATIONSBindingSource
            // 
            this.PRODUCTOLOCATIONSBindingSource.DataMember = "PRODUCTOLOCATIONS";
            this.PRODUCTOLOCATIONSBindingSource.DataSource = this.DSIposReportingC;
            // 
            // PRODUCTOLOCATIONSTableAdapter
            // 
            this.PRODUCTOLOCATIONSTableAdapter.ClearBeforeFill = true;
            // 
            // WFRptInventarioXLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 325);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFRptInventarioXLoc";
            this.Text = "WFRptInventarioXLoc";
            this.Load += new System.EventHandler(this.WFRptInventarioXLoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.INVENTARIOXLOC_VIEWBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSIposReportingC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRODUCTOLOCATIONSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource INVENTARIOXLOC_VIEWBindingSource;
        private DSIposReportingC DSIposReportingC;
        private DSIposReportingCTableAdapters.INVENTARIOXLOC_VIEWTableAdapter INVENTARIOXLOC_VIEWTableAdapter;
        private System.Windows.Forms.BindingSource PRODUCTOLOCATIONSBindingSource;
        private DSIposReportingCTableAdapters.PRODUCTOLOCATIONSTableAdapter PRODUCTOLOCATIONSTableAdapter;
    }
}