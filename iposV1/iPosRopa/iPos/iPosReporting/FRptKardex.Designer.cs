namespace iPosReporting
{
    partial class FRptKardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptKardex));
            this.KARDEX1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSReportIpos = new iPosReporting.DSReportIpos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KARDEX1TableAdapter = new iPosReporting.DSReportIposTableAdapters.KARDEX1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KARDEX1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos)).BeginInit();
            this.SuspendLayout();
            // 
            // KARDEX1BindingSource
            // 
            this.KARDEX1BindingSource.DataMember = "KARDEX1";
            this.KARDEX1BindingSource.DataSource = this.DSReportIpos;
            // 
            // DSReportIpos
            // 
            this.DSReportIpos.DataSetName = "DSReportIpos";
            this.DSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSReportIpos_KARDEX1";
            reportDataSource1.Value = this.KARDEX1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.RptKardex.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(736, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // KARDEX1TableAdapter
            // 
            this.KARDEX1TableAdapter.ClearBeforeFill = true;
            // 
            // FRptKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 425);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptKardex";
            this.Text = "Kardex";
            this.Load += new System.EventHandler(this.FRptKardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KARDEX1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KARDEX1BindingSource;
        private DSReportIpos DSReportIpos;
        private iPosReporting.DSReportIposTableAdapters.KARDEX1TableAdapter KARDEX1TableAdapter;
    }
}