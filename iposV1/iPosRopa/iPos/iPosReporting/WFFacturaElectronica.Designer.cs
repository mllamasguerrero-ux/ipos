namespace iPosReporting
{
    partial class WFFacturaElectronica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFFacturaElectronica));
            this.dSReportIpos2 = new iPosReporting.DSReportIpos2();
            this.rEP_FACTURAELECTRONICA_DETBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rEP_FACTURAELECTRONICA_DETTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.REP_FACTURAELECTRONICA_DETTableAdapter();
            this.tableAdapterManager = new iPosReporting.DSReportIpos2TableAdapters.TableAdapterManager();
            this.dSIposReportingC = new iPosReporting.DSIposReportingC();
            this.dOCTOCLIENTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dOCTOCLIENTETableAdapter = new iPosReporting.DSIposReportingCTableAdapters.DOCTOCLIENTETableAdapter();
            this.tableAdapterManager1 = new iPosReporting.DSIposReportingCTableAdapters.TableAdapterManager();
            this.pARAMETROBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pARAMETROTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.PARAMETROTableAdapter();
            this.dOCTOPAGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dOCTOPAGOTableAdapter = new iPosReporting.DSIposReportingCTableAdapters.DOCTOPAGOTableAdapter();
            this.rEP_FACTURAELECTRONICA_DET_REFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rEP_FACTURAELECTRONICA_DET_REFTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.REP_FACTURAELECTRONICA_DET_REFTableAdapter();
            this.report1 = new FastReport.Report();
            this.iNFOIMPORTACIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iNFOIMPORTACIONTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.INFOIMPORTACIONTableAdapter();
            this.dSFacturacionxsd = new iPosReporting.DSFacturacionxsd();
            this.fACTURAELECTRONICA_XMLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fACTURAELECTRONICA_XMLTableAdapter = new iPosReporting.DSFacturacionxsdTableAdapters.FACTURAELECTRONICA_XMLTableAdapter();
            this.tableAdapterManager2 = new iPosReporting.DSFacturacionxsdTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEP_FACTURAELECTRONICA_DETBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSIposReportingC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCTOCLIENTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pARAMETROBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCTOPAGOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEP_FACTURAELECTRONICA_DET_REFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFOIMPORTACIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSFacturacionxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURAELECTRONICA_XMLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dSReportIpos2
            // 
            this.dSReportIpos2.DataSetName = "DSReportIpos2";
            this.dSReportIpos2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rEP_FACTURAELECTRONICA_DETBindingSource
            // 
            this.rEP_FACTURAELECTRONICA_DETBindingSource.DataMember = "REP_FACTURAELECTRONICA_DET";
            this.rEP_FACTURAELECTRONICA_DETBindingSource.DataSource = this.dSReportIpos2;
            // 
            // rEP_FACTURAELECTRONICA_DETTableAdapter
            // 
            this.rEP_FACTURAELECTRONICA_DETTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSReportIpos2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dSIposReportingC
            // 
            this.dSIposReportingC.DataSetName = "DSIposReportingC";
            this.dSIposReportingC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dOCTOCLIENTEBindingSource
            // 
            this.dOCTOCLIENTEBindingSource.DataMember = "DOCTOCLIENTE";
            this.dOCTOCLIENTEBindingSource.DataSource = this.dSIposReportingC;
            // 
            // dOCTOCLIENTETableAdapter
            // 
            this.dOCTOCLIENTETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.DOCTOCLIENTETableAdapter = this.dOCTOCLIENTETableAdapter;
            this.tableAdapterManager1.UpdateOrder = iPosReporting.DSIposReportingCTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pARAMETROBindingSource
            // 
            this.pARAMETROBindingSource.DataMember = "PARAMETRO";
            this.pARAMETROBindingSource.DataSource = this.dSReportIpos2;
            // 
            // pARAMETROTableAdapter
            // 
            this.pARAMETROTableAdapter.ClearBeforeFill = true;
            // 
            // dOCTOPAGOBindingSource
            // 
            this.dOCTOPAGOBindingSource.DataMember = "DOCTOPAGO";
            this.dOCTOPAGOBindingSource.DataSource = this.dSIposReportingC;
            // 
            // dOCTOPAGOTableAdapter
            // 
            this.dOCTOPAGOTableAdapter.ClearBeforeFill = true;
            // 
            // rEP_FACTURAELECTRONICA_DET_REFBindingSource
            // 
            this.rEP_FACTURAELECTRONICA_DET_REFBindingSource.DataMember = "REP_FACTURAELECTRONICA_DET_REF";
            this.rEP_FACTURAELECTRONICA_DET_REFBindingSource.DataSource = this.dSReportIpos2;
            // 
            // rEP_FACTURAELECTRONICA_DET_REFTableAdapter
            // 
            this.rEP_FACTURAELECTRONICA_DET_REFTableAdapter.ClearBeforeFill = true;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // iNFOIMPORTACIONBindingSource
            // 
            this.iNFOIMPORTACIONBindingSource.DataMember = "INFOIMPORTACION";
            this.iNFOIMPORTACIONBindingSource.DataSource = this.dSReportIpos2;
            // 
            // iNFOIMPORTACIONTableAdapter
            // 
            this.iNFOIMPORTACIONTableAdapter.ClearBeforeFill = true;
            // 
            // dSFacturacionxsd
            // 
            this.dSFacturacionxsd.DataSetName = "DSFacturacionxsd";
            this.dSFacturacionxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fACTURAELECTRONICA_XMLBindingSource
            // 
            this.fACTURAELECTRONICA_XMLBindingSource.DataMember = "FACTURAELECTRONICA_XML";
            this.fACTURAELECTRONICA_XMLBindingSource.DataSource = this.dSFacturacionxsd;
            // 
            // fACTURAELECTRONICA_XMLTableAdapter
            // 
            this.fACTURAELECTRONICA_XMLTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.Connection = null;
            this.tableAdapterManager2.UpdateOrder = iPosReporting.DSFacturacionxsdTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFFacturaElectronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(780, 331);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFFacturaElectronica";
            this.Text = "WFFacturaElectronica";
            this.Load += new System.EventHandler(this.WFFacturaElectronica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEP_FACTURAELECTRONICA_DETBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSIposReportingC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCTOCLIENTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pARAMETROBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCTOPAGOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rEP_FACTURAELECTRONICA_DET_REFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFOIMPORTACIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSFacturacionxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACTURAELECTRONICA_XMLBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSReportIpos2 dSReportIpos2;
        private System.Windows.Forms.BindingSource rEP_FACTURAELECTRONICA_DETBindingSource;
        private DSReportIpos2TableAdapters.REP_FACTURAELECTRONICA_DETTableAdapter rEP_FACTURAELECTRONICA_DETTableAdapter;
        private DSReportIpos2TableAdapters.TableAdapterManager tableAdapterManager;
        private DSIposReportingC dSIposReportingC;
        private System.Windows.Forms.BindingSource dOCTOCLIENTEBindingSource;
        private DSIposReportingCTableAdapters.DOCTOCLIENTETableAdapter dOCTOCLIENTETableAdapter;
        private DSIposReportingCTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.BindingSource pARAMETROBindingSource;
        private DSReportIpos2TableAdapters.PARAMETROTableAdapter pARAMETROTableAdapter;
        private System.Windows.Forms.BindingSource dOCTOPAGOBindingSource;
        private DSIposReportingCTableAdapters.DOCTOPAGOTableAdapter dOCTOPAGOTableAdapter;
        private System.Windows.Forms.BindingSource rEP_FACTURAELECTRONICA_DET_REFBindingSource;
        private DSReportIpos2TableAdapters.REP_FACTURAELECTRONICA_DET_REFTableAdapter rEP_FACTURAELECTRONICA_DET_REFTableAdapter;
        private FastReport.Report report1;
        private System.Windows.Forms.BindingSource iNFOIMPORTACIONBindingSource;
        private DSReportIpos2TableAdapters.INFOIMPORTACIONTableAdapter iNFOIMPORTACIONTableAdapter;
        private DSFacturacionxsd dSFacturacionxsd;
        private System.Windows.Forms.BindingSource fACTURAELECTRONICA_XMLBindingSource;
        private DSFacturacionxsdTableAdapters.FACTURAELECTRONICA_XMLTableAdapter fACTURAELECTRONICA_XMLTableAdapter;
        private DSFacturacionxsdTableAdapters.TableAdapterManager tableAdapterManager2;
    }
}