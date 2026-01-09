namespace iPosReporting
{
    partial class FRptTesting
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptTesting));
            this.TESTING_DOCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSReportIpos2 = new iPosReporting.DSReportIpos2();
            this.TESTING_PERSONASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TESTING_CORTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TESTING_PRODUCTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TESTING_DOCTOSTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.TESTING_DOCTOSTableAdapter();
            this.TESTING_CORTETableAdapter = new iPosReporting.DSReportIpos2TableAdapters.TESTING_CORTETableAdapter();
            this.TESTING_PERSONASTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.TESTING_PERSONASTableAdapter();
            this.TESTING_PRODUCTOTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.TESTING_PRODUCTOTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_DOCTOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_PERSONASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_CORTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_PRODUCTOBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TESTING_DOCTOSBindingSource
            // 
            this.TESTING_DOCTOSBindingSource.DataMember = "TESTING_DOCTOS";
            this.TESTING_DOCTOSBindingSource.DataSource = this.DSReportIpos2;
            // 
            // DSReportIpos2
            // 
            this.DSReportIpos2.DataSetName = "DSReportIpos2";
            this.DSReportIpos2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TESTING_PERSONASBindingSource
            // 
            this.TESTING_PERSONASBindingSource.DataMember = "TESTING_PERSONAS";
            this.TESTING_PERSONASBindingSource.DataSource = this.DSReportIpos2;
            // 
            // TESTING_CORTEBindingSource
            // 
            this.TESTING_CORTEBindingSource.DataMember = "TESTING_CORTE";
            this.TESTING_CORTEBindingSource.DataSource = this.DSReportIpos2;
            // 
            // TESTING_PRODUCTOBindingSource
            // 
            this.TESTING_PRODUCTOBindingSource.DataMember = "TESTING_PRODUCTO";
            this.TESTING_PRODUCTOBindingSource.DataSource = this.DSReportIpos2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 256);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(406, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doctos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TESTING_DOCTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.RptTestingDoctos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(400, 224);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(406, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Personas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.TESTING_PERSONASBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "iPosReporting.RptTestingPersonas.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(3, 3);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(400, 224);
            this.reportViewer3.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(406, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cortes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.TESTING_CORTEBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "iPosReporting.RptTestingCorte.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(400, 224);
            this.reportViewer2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.reportViewer4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(406, 230);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Productos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // reportViewer4
            // 
            this.reportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.TESTING_PRODUCTOBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "iPosReporting.RptTestingProductos.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(3, 3);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(400, 224);
            this.reportViewer4.TabIndex = 0;
            // 
            // TESTING_DOCTOSTableAdapter
            // 
            this.TESTING_DOCTOSTableAdapter.ClearBeforeFill = true;
            // 
            // TESTING_CORTETableAdapter
            // 
            this.TESTING_CORTETableAdapter.ClearBeforeFill = true;
            // 
            // TESTING_PERSONASTableAdapter
            // 
            this.TESTING_PERSONASTableAdapter.ClearBeforeFill = true;
            // 
            // TESTING_PRODUCTOTableAdapter
            // 
            this.TESTING_PRODUCTOTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 49);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(248, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Resetear base de datos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRptTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(414, 305);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptTesting";
            this.Text = "FRptTesting";
            this.Load += new System.EventHandler(this.FRptTesting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_DOCTOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSReportIpos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_PERSONASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_CORTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESTING_PRODUCTOBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.BindingSource TESTING_DOCTOSBindingSource;
        private DSReportIpos2 DSReportIpos2;
        private DSReportIpos2TableAdapters.TESTING_DOCTOSTableAdapter TESTING_DOCTOSTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource TESTING_CORTEBindingSource;
        private DSReportIpos2TableAdapters.TESTING_CORTETableAdapter TESTING_CORTETableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource TESTING_PERSONASBindingSource;
        private DSReportIpos2TableAdapters.TESTING_PERSONASTableAdapter TESTING_PERSONASTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.BindingSource TESTING_PRODUCTOBindingSource;
        private DSReportIpos2TableAdapters.TESTING_PRODUCTOTableAdapter TESTING_PRODUCTOTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;

    }
}