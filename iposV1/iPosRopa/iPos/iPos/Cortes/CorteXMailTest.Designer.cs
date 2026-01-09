namespace iPos.Cortes
{
    partial class CorteXMailTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorteXMailTest));
            this.corteTicketB2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCortesB = new iPos.DSCortesB();
            this.cORTE_CALCULO_DETALLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.corteTrasladosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.corteTicketB2TableAdapter = new iPos.DSCortesBTableAdapters.CorteTicketB2TableAdapter();
            this.tableAdapterManager = new iPos.DSCortesBTableAdapters.TableAdapterManager();
            this.corteTrasladosTableAdapter = new iPos.DSCortesBTableAdapters.CorteTrasladosTableAdapter();
            this.cORTE_CALCULO_DETALLETableAdapter = new iPos.DSCortesBTableAdapters.CORTE_CALCULO_DETALLETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketB2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCortesB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cORTE_CALCULO_DETALLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTrasladosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // corteTicketB2BindingSource
            // 
            this.corteTicketB2BindingSource.DataMember = "CorteTicketB2";
            this.corteTicketB2BindingSource.DataSource = this.dSCortesB;
            // 
            // dSCortesB
            // 
            this.dSCortesB.DataSetName = "DSCortesB";
            this.dSCortesB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cORTE_CALCULO_DETALLEBindingSource
            // 
            this.cORTE_CALCULO_DETALLEBindingSource.DataMember = "CORTE_CALCULO_DETALLE";
            this.cORTE_CALCULO_DETALLEBindingSource.DataSource = this.dSCortesB;
            // 
            // corteTrasladosBindingSource
            // 
            this.corteTrasladosBindingSource.DataMember = "CorteTraslados";
            this.corteTrasladosBindingSource.DataSource = this.dSCortesB;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "Ticket";
            reportDataSource1.Value = this.corteTicketB2BindingSource;
            reportDataSource2.Name = "CorteCalculo";
            reportDataSource2.Value = this.cORTE_CALCULO_DETALLEBindingSource;
            reportDataSource3.Name = "Traslados";
            reportDataSource3.Value = this.corteTrasladosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPos.Cortes.RptCorteXMail.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(17, 36);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(680, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // corteTicketB2TableAdapter
            // 
            this.corteTicketB2TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.DSCortesBTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // corteTrasladosTableAdapter
            // 
            this.corteTrasladosTableAdapter.ClearBeforeFill = true;
            // 
            // cORTE_CALCULO_DETALLETableAdapter
            // 
            this.cORTE_CALCULO_DETALLETableAdapter.ClearBeforeFill = true;
            // 
            // CorteXMailTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(719, 369);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CorteXMailTest";
            this.Text = "CorteXMailTest";
            this.Load += new System.EventHandler(this.CorteXMailTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketB2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCortesB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cORTE_CALCULO_DETALLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTrasladosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSCortesB dSCortesB;
        private System.Windows.Forms.BindingSource corteTicketB2BindingSource;
        private DSCortesBTableAdapters.CorteTicketB2TableAdapter corteTicketB2TableAdapter;
        private DSCortesBTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource corteTrasladosBindingSource;
        private DSCortesBTableAdapters.CorteTrasladosTableAdapter corteTrasladosTableAdapter;
        private System.Windows.Forms.BindingSource cORTE_CALCULO_DETALLEBindingSource;
        private DSCortesBTableAdapters.CORTE_CALCULO_DETALLETableAdapter cORTE_CALCULO_DETALLETableAdapter;
    }
}