
namespace iPos
{
    partial class WFClienteEdicion
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
            System.Windows.Forms.Label label44;
            System.Windows.Forms.Label pROVEEDOR1IDLabel;
            System.Windows.Forms.Label pSAT_USOCFDIIDLabel;
            System.Windows.Forms.Label label37;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFClienteEdicion));
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.RAV_ID = new CustomValidation.RangeValidator();
            this.RAV_CREADOPOR_USERID = new CustomValidation.RangeValidator();
            this.RAV_MODIFICADOPOR_USERID = new CustomValidation.RangeValidator();
            this.RAV_TIPOPERSONAID = new CustomValidation.RangeValidator();
            this.RAV_SALUDOID = new CustomValidation.RangeValidator();
            this.RAV_EMPRESAID = new CustomValidation.RangeValidator();
            this.RAV_VENDEDORID = new CustomValidation.RangeValidator();
            this.RAV_LISTAPRECIOID = new CustomValidation.RangeValidator();
            this.RAV_RESET_PASS = new CustomValidation.RangeValidator();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.button1 = new System.Windows.Forms.Button();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.CLAVETextBox = new System.Windows.Forms.TextBox();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conSaldosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preciosEspecificosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descuentosPorLineaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialVentasYNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anticiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sumarizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHistory = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dOMICILIOSXPERSONADataGridView = new System.Windows.Forms.DataGridView();
            this.BTNEDITARDOMICILIO = new System.Windows.Forms.DataGridViewImageColumn();
            this.BTNELIMINARDOMICILIO = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDOMACTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOMICILIOSXPERSONABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos3 = new iPos.Catalogos.DSCatalogos3();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BtnAgregarDatosEntrega = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.pnlEdicionDatosEntrega = new System.Windows.Forms.Panel();
            this.btnMapaEntrega = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.ENTREGALONGITUDTextBox = new System.Windows.Forms.TextBox();
            this.ENTREGALATITUDTextBox = new System.Windows.Forms.TextBox();
            this.btnCancelarGuardadoEntrega = new System.Windows.Forms.Button();
            this.btnGuardarDatosEntrega = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_LOCALIDADIDTextBox = new iPos.Tools.TextBoxFB();
            this.ENTREGA_SAT_LOCALIDADIDButton = new System.Windows.Forms.Button();
            this.ENTREGA_SAT_LOCALIDADIDLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.ENTREGACALLETextBox = new System.Windows.Forms.TextBox();
            this.ENTREGAREFERENCIADOMTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_MUNICIPIOIDTextBox = new iPos.Tools.TextBoxFB();
            this.ENTREGA_SAT_MUNICIPIOIDButton = new System.Windows.Forms.Button();
            this.ENTREGA_SAT_MUNICIPIOIDLabel = new System.Windows.Forms.Label();
            this.ENTREGA_DISTANCIATextBox = new System.Windows.Forms.NumericTextBox();
            this.ENTREGAESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.ENTREGANUMEROEXTERIORTextBox = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.ENTREGACODIGOPOSTALTextBox = new System.Windows.Forms.TextBox();
            this.ENTREGANUMEROINTERIORTextBox = new System.Windows.Forms.TextBox();
            this.ENTREGA_SAT_COLONIAIDButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ENTREGA_SAT_COLONIAIDTextBox = new iPos.Tools.TextBoxFB();
            this.ENTREGA_SAT_COLONIAIDLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.GENERACARTAPORTETextBox = new System.Windows.Forms.CheckBox();
            this.GENERACOMPROBTRASLTextBox = new System.Windows.Forms.CheckBox();
            this.MAYOREOXPRODUCTOTextBox = new System.Windows.Forms.CheckBox();
            this.PREGUNTARTICKETLARGOTextBox = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.RUTAEMBARQUEIDButton = new System.Windows.Forms.Button();
            this.RUTAEMBARQUEIDTextBox = new iPos.Tools.TextBoxFB();
            this.RUTAEMBARQUEIDDescLabel = new System.Windows.Forms.Label();
            this.btnCuentasBanco = new System.Windows.Forms.Button();
            this.EXENTOIVATextBox = new System.Windows.Forms.CheckBox();
            this.PROVEECLIENTEIDButton = new System.Windows.Forms.Button();
            this.PROVEECLIENTEIDTextBox = new iPos.Tools.TextBoxFB();
            this.PROVEECLIENTEIDLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.EMAIL4TextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.EMAIL3TextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.RETIENEIVATextBox = new System.Windows.Forms.CheckBox();
            this.RETIENEISRTextBox = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.SUBTIPOCLIENTEButton = new System.Windows.Forms.Button();
            this.SUBTIPOCLIENTETextBox = new iPos.Tools.TextBoxFB();
            this.SUBTIPOCLIENTEDescLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbrirMapa = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.LONGITUDTextBox = new System.Windows.Forms.TextBox();
            this.LATITUDTextBox = new System.Windows.Forms.TextBox();
            this.SAT_REGIMENFISCALIDButton = new System.Windows.Forms.Button();
            this.SAT_REGIMENFISCALIDLabel = new System.Windows.Forms.Label();
            this.pSAT_REGIMENFISCALIDLabel = new System.Windows.Forms.Label();
            this.SAT_REGIMENFISCALIDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_COLONIAIDButton = new System.Windows.Forms.Button();
            this.SAT_COLONIAIDLabel = new System.Windows.Forms.Label();
            this.SAT_COLONIAIDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_MUNICIPIOIDButton = new System.Windows.Forms.Button();
            this.SAT_MUNICIPIOIDLabel = new System.Windows.Forms.Label();
            this.SAT_MUNICIPIOIDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_LOCALIDADIDButton = new System.Windows.Forms.Button();
            this.SAT_LOCALIDADIDLabel = new System.Windows.Forms.Label();
            this.SAT_LOCALIDADIDTextBox = new iPos.Tools.TextBoxFB();
            this.DISTANCIATextBox = new System.Windows.Forms.NumericTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SAT_USOCFDIIDTextBox = new iPos.Tools.TextBoxFB();
            this.SAT_USOCFDIIDLabel = new System.Windows.Forms.Label();
            this.PAISComboBoxFb = new System.Windows.Forms.ComboBoxFB();
            this.label26 = new System.Windows.Forms.Label();
            this.CIUDADLabel = new System.Windows.Forms.Label();
            this.txtCuentaContpaq = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.chkOrdenCompra = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.REFERENCIADOMTextBox = new System.Windows.Forms.TextBox();
            this.ULTIMAVENTATextBox = new System.Windows.Forms.DateTimePicker();
            this.SERVICIOADOMICILIOTextBox = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pnlDesglosaIEPS = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.CUENTAIEPSTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.DESGLOSEIEPSTextBox = new System.Windows.Forms.CheckBox();
            this.MONEDAButton = new System.Windows.Forms.Button();
            this.MONEDAIDTextBox = new iPos.Tools.TextBoxFB();
            this.MONEDALabel = new System.Windows.Forms.Label();
            this.mONEDAIDLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PAGOTARJMENORPRECIOLISTATextBox = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.CARGOXVENTACONTARJETATextBox = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.GENERARRECIBOELECTRONICOTextBox = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.PAGOPARCIALIDADESTextBox = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CREDITOREFERENCIAABONOSTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.CREDITOFORMAPAGOABONOSTextBox = new System.Windows.Forms.ComboBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.LblFormaPago = new System.Windows.Forms.Label();
            this.ESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.Pcredito = new System.Windows.Forms.Panel();
            this.POR_COMETextBox = new System.Windows.Forms.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.DIAS_EXTRTextBox = new System.Windows.Forms.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbSepararProdXPlazo = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.HAB_PAGOEFECTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.SUPERLISTAPRECIOIDTextBox = new System.Windows.Forms.ComboBox();
            this.SUPERLISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.HAB_PAGOTRANSFERENCIATextBox = new System.Windows.Forms.CheckBox();
            this.PAGOSTextBox = new System.Windows.Forms.ComboBox();
            this.REVISIONTextBox = new System.Windows.Forms.ComboBox();
            this.BLOQUEADOTextBox = new System.Windows.Forms.CheckBox();
            this.DIASTextBox = new System.Windows.Forms.NumericTextBox();
            this.LIMITECREDITOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ldias = new System.Windows.Forms.Label();
            this.llimite = new System.Windows.Forms.Label();
            this.HAB_PAGOCHEQUETextBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HAB_PAGOCREDITOTextBox = new System.Windows.Forms.CheckBox();
            this.lpagos = new System.Windows.Forms.Label();
            this.HAB_PAGOTARJETATextBox = new System.Windows.Forms.CheckBox();
            this.lrevisio = new System.Windows.Forms.Label();
            this.LISTAPRECIOIDTextBox = new System.Windows.Forms.ComboBox();
            this.LISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFB();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VENDEDORIDLabel = new System.Windows.Forms.Label();
            this.NUMEROINTERIORTextBox = new System.Windows.Forms.TextBox();
            this.NUMEROEXTERIORTextBox = new System.Windows.Forms.TextBox();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.DOMICILIOLabel = new System.Windows.Forms.Label();
            this.DOMICILIOTextBox = new System.Windows.Forms.TextBox();
            this.CREADOPOR_USERIDLabel = new System.Windows.Forms.Label();
            this.TextBoxCREADOPOR_USERCLAVE = new System.Windows.Forms.TextBox();
            this.COLONIALabel = new System.Windows.Forms.Label();
            this.MODIFICADOPOR_USERIDLabel = new System.Windows.Forms.Label();
            this.MODIFICADOPOR_USERIDTextBox = new System.Windows.Forms.TextBox();
            this.VIGENCIATextBox = new System.Windows.Forms.DateTimePicker();
            this.VIGENCIALabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.CONTACTO2TextBox = new System.Windows.Forms.TextBox();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.CONTACTO2Label = new System.Windows.Forms.Label();
            this.ESTADOLabel = new System.Windows.Forms.Label();
            this.CONTACTO1TextBox = new System.Windows.Forms.TextBox();
            this.CONTACTO1Label = new System.Windows.Forms.Label();
            this.MEMOLabel = new System.Windows.Forms.Label();
            this.RFCTextBox = new System.Windows.Forms.TextBox();
            this.MEMOTextBox = new System.Windows.Forms.TextBox();
            this.PAISLabel = new System.Windows.Forms.Label();
            this.RFCLabel = new System.Windows.Forms.Label();
            this.EMAIL2TextBox = new System.Windows.Forms.TextBox();
            this.EMAIL2Label = new System.Windows.Forms.Label();
            this.RAZONSOCIALTextBox = new System.Windows.Forms.TextBox();
            this.EMAIL1TextBox = new System.Windows.Forms.TextBox();
            this.RAZONSOCIALLabel = new System.Windows.Forms.Label();
            this.EMAIL1Label = new System.Windows.Forms.Label();
            this.NOMBRESLabel = new System.Windows.Forms.Label();
            this.CODIGOPOSTALLabel = new System.Windows.Forms.Label();
            this.APELLIDOSTextBox = new System.Windows.Forms.TextBox();
            this.NOMBRESTextBox = new System.Windows.Forms.TextBox();
            this.APELLIDOSLabel = new System.Windows.Forms.Label();
            this.CODIGOPOSTALTextBox = new System.Windows.Forms.TextBox();
            this.TELEFONO1Label = new System.Windows.Forms.Label();
            this.TELEFONO1TextBox = new System.Windows.Forms.TextBox();
            this.TELEFONO2TextBox = new System.Windows.Forms.TextBox();
            this.TELEFONO2Label = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TBNotasCredito = new System.Windows.Forms.TabPage();
            this.FirmaTabPage = new System.Windows.Forms.TabPage();
            this.btnFirmaImageSelector = new System.Windows.Forms.Button();
            this.NuevaFirmaImagenTextBox = new System.Windows.Forms.TextBox();
            this.btnEliminarFirmaImagen = new System.Windows.Forms.Button();
            this.FIRMAIMAGENTextBox = new System.Windows.Forms.TextBox();
            this.FIRMAIMAGENPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTAgregarNota = new System.Windows.Forms.Button();
            this.btnNotaIncidencia = new System.Windows.Forms.Button();
            this.dOMICILIOSXPERSONATableAdapter = new iPos.Catalogos.DSCatalogos3TableAdapters.DOMICILIOSXPERSONATableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogos3TableAdapters.TableAdapterManager();
            label44 = new System.Windows.Forms.Label();
            pROVEEDOR1IDLabel = new System.Windows.Forms.Label();
            pSAT_USOCFDIIDLabel = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos3)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel11.SuspendLayout();
            this.pnlEdicionDatosEntrega.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDesglosaIEPS.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Pcredito.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.FirmaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FIRMAIMAGENPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new System.Drawing.Point(818, 431);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(83, 13);
            label44.TabIndex = 253;
            label44.Text = "Ultima Venta:";
            // 
            // pROVEEDOR1IDLabel
            // 
            pROVEEDOR1IDLabel.AutoSize = true;
            pROVEEDOR1IDLabel.Location = new System.Drawing.Point(504, 51);
            pROVEEDOR1IDLabel.Name = "pROVEEDOR1IDLabel";
            pROVEEDOR1IDLabel.Size = new System.Drawing.Size(139, 13);
            pROVEEDOR1IDLabel.TabIndex = 217;
            pROVEEDOR1IDLabel.Text = "Proveedor relacionado:";
            // 
            // pSAT_USOCFDIIDLabel
            // 
            pSAT_USOCFDIIDLabel.AutoSize = true;
            pSAT_USOCFDIIDLabel.Location = new System.Drawing.Point(218, 301);
            pSAT_USOCFDIIDLabel.Name = "pSAT_USOCFDIIDLabel";
            pSAT_USOCFDIIDLabel.Size = new System.Drawing.Size(69, 13);
            pSAT_USOCFDIIDLabel.TabIndex = 266;
            pSAT_USOCFDIIDLabel.Text = "Uso CFDI: ";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.ForeColor = System.Drawing.Color.White;
            label37.Location = new System.Drawing.Point(48, 49);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(41, 13);
            label37.TabIndex = 224;
            label37.Text = "Firma:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Location = new System.Drawing.Point(36, 40);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(43, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "Clave:";
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo ID";
            this.RFV_CLAVE.Icon = null;
            // 
            // RAV_ID
            // 
            this.RAV_ID.Enabled = true;
            this.RAV_ID.ErrorMessage = "Error el campo ID no esta dentro del rango";
            this.RAV_ID.Icon = null;
            this.RAV_ID.MaximumValue = "999999999999";
            this.RAV_ID.MinimumValue = "0";
            this.RAV_ID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_CREADOPOR_USERID
            // 
            this.RAV_CREADOPOR_USERID.Enabled = true;
            this.RAV_CREADOPOR_USERID.ErrorMessage = "Error el campo CREADOPOR_USERID no esta dentro del rango";
            this.RAV_CREADOPOR_USERID.Icon = null;
            this.RAV_CREADOPOR_USERID.MaximumValue = "999999999999";
            this.RAV_CREADOPOR_USERID.MinimumValue = "0";
            this.RAV_CREADOPOR_USERID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_MODIFICADOPOR_USERID
            // 
            this.RAV_MODIFICADOPOR_USERID.Enabled = true;
            this.RAV_MODIFICADOPOR_USERID.ErrorMessage = "Error el campo MODIFICADOPOR_USERID no esta dentro del rango";
            this.RAV_MODIFICADOPOR_USERID.Icon = null;
            this.RAV_MODIFICADOPOR_USERID.MaximumValue = "999999999999";
            this.RAV_MODIFICADOPOR_USERID.MinimumValue = "0";
            this.RAV_MODIFICADOPOR_USERID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_TIPOPERSONAID
            // 
            this.RAV_TIPOPERSONAID.Enabled = true;
            this.RAV_TIPOPERSONAID.ErrorMessage = "Error el campo TIPOPERSONAID no esta dentro del rango";
            this.RAV_TIPOPERSONAID.Icon = null;
            this.RAV_TIPOPERSONAID.MaximumValue = "999999999999";
            this.RAV_TIPOPERSONAID.MinimumValue = "0";
            this.RAV_TIPOPERSONAID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_SALUDOID
            // 
            this.RAV_SALUDOID.Enabled = true;
            this.RAV_SALUDOID.ErrorMessage = "Error el campo SALUDOID no esta dentro del rango";
            this.RAV_SALUDOID.Icon = null;
            this.RAV_SALUDOID.MaximumValue = "999999999999";
            this.RAV_SALUDOID.MinimumValue = "0";
            this.RAV_SALUDOID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_EMPRESAID
            // 
            this.RAV_EMPRESAID.Enabled = true;
            this.RAV_EMPRESAID.ErrorMessage = "Error el campo EMPRESAID no esta dentro del rango";
            this.RAV_EMPRESAID.Icon = null;
            this.RAV_EMPRESAID.MaximumValue = "999999999999";
            this.RAV_EMPRESAID.MinimumValue = "0";
            this.RAV_EMPRESAID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_VENDEDORID
            // 
            this.RAV_VENDEDORID.Enabled = true;
            this.RAV_VENDEDORID.ErrorMessage = "Error el campo VENDEDORID no esta dentro del rango";
            this.RAV_VENDEDORID.Icon = null;
            this.RAV_VENDEDORID.MaximumValue = "999999999999";
            this.RAV_VENDEDORID.MinimumValue = "0";
            this.RAV_VENDEDORID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_LISTAPRECIOID
            // 
            this.RAV_LISTAPRECIOID.Enabled = true;
            this.RAV_LISTAPRECIOID.ErrorMessage = "Error el campo LISTAPRECIOID no esta dentro del rango";
            this.RAV_LISTAPRECIOID.Icon = null;
            this.RAV_LISTAPRECIOID.MaximumValue = "999999999999";
            this.RAV_LISTAPRECIOID.MinimumValue = "0";
            this.RAV_LISTAPRECIOID.Type = CustomValidation.ValidationDataType.Double;
            // 
            // RAV_RESET_PASS
            // 
            this.RAV_RESET_PASS.Enabled = true;
            this.RAV_RESET_PASS.ErrorMessage = "Error el campo RESET_PASS no esta dentro del rango";
            this.RAV_RESET_PASS.Icon = null;
            this.RAV_RESET_PASS.MaximumValue = "999999999999";
            this.RAV_RESET_PASS.MinimumValue = "0";
            this.RAV_RESET_PASS.Type = CustomValidation.ValidationDataType.Double;
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(0, 0);
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(10, 13);
            this.LBError.TabIndex = 44;
            this.LBError.Text = "-";
            // 
            // FbConnection1
            // 
            this.FbConnection1.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(357, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 30);
            this.button1.TabIndex = 70;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.Enabled = true;
            this.requiredFieldValidator1.Icon = null;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.Cursor = System.Windows.Forms.Cursors.Default;
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(236, 33);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(87, 23);
            this.BTIniciaEdicion.TabIndex = 3;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // CLAVETextBox
            // 
            this.CLAVETextBox.Enabled = false;
            this.CLAVETextBox.Location = new System.Drawing.Point(94, 35);
            this.CLAVETextBox.Name = "CLAVETextBox";
            this.CLAVETextBox.Size = new System.Drawing.Size(116, 20);
            this.CLAVETextBox.TabIndex = 2;
            this.CLAVETextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(629, 583);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(132, 30);
            this.BTCancelar.TabIndex = 71;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.anticiposToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1107, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todasToolStripMenuItem,
            this.conSaldosToolStripMenuItem,
            this.estadisticosToolStripMenuItem,
            this.preciosEspecificosToolStripMenuItem,
            this.descuentosPorLineaToolStripMenuItem,
            this.historialVentasYNCToolStripMenuItem});
            this.ventasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ventasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // todasToolStripMenuItem
            // 
            this.todasToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.todasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.todasToolStripMenuItem.Name = "todasToolStripMenuItem";
            this.todasToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.todasToolStripMenuItem.Text = "Todas";
            this.todasToolStripMenuItem.Click += new System.EventHandler(this.todasToolStripMenuItem_Click);
            // 
            // conSaldosToolStripMenuItem
            // 
            this.conSaldosToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.conSaldosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.conSaldosToolStripMenuItem.Name = "conSaldosToolStripMenuItem";
            this.conSaldosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.conSaldosToolStripMenuItem.Text = "Con Saldos";
            this.conSaldosToolStripMenuItem.Click += new System.EventHandler(this.conSaldosToolStripMenuItem_Click);
            // 
            // estadisticosToolStripMenuItem
            // 
            this.estadisticosToolStripMenuItem.Name = "estadisticosToolStripMenuItem";
            this.estadisticosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.estadisticosToolStripMenuItem.Text = "Estadisticos";
            this.estadisticosToolStripMenuItem.Click += new System.EventHandler(this.estadisticosToolStripMenuItem_Click);
            // 
            // preciosEspecificosToolStripMenuItem
            // 
            this.preciosEspecificosToolStripMenuItem.Name = "preciosEspecificosToolStripMenuItem";
            this.preciosEspecificosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.preciosEspecificosToolStripMenuItem.Text = "Precios especificos";
            this.preciosEspecificosToolStripMenuItem.Click += new System.EventHandler(this.preciosEspecificosToolStripMenuItem_Click);
            // 
            // descuentosPorLineaToolStripMenuItem
            // 
            this.descuentosPorLineaToolStripMenuItem.Name = "descuentosPorLineaToolStripMenuItem";
            this.descuentosPorLineaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.descuentosPorLineaToolStripMenuItem.Text = "Descuentos por Linea";
            this.descuentosPorLineaToolStripMenuItem.Click += new System.EventHandler(this.descuentosPorLineaToolStripMenuItem_Click);
            // 
            // historialVentasYNCToolStripMenuItem
            // 
            this.historialVentasYNCToolStripMenuItem.Name = "historialVentasYNCToolStripMenuItem";
            this.historialVentasYNCToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.historialVentasYNCToolStripMenuItem.Text = "Historial ventas y NC";
            this.historialVentasYNCToolStripMenuItem.Click += new System.EventHandler(this.historialVentasYNCToolStripMenuItem_Click);
            // 
            // anticiposToolStripMenuItem
            // 
            this.anticiposToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.anticiposToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.anticiposToolStripMenuItem.Name = "anticiposToolStripMenuItem";
            this.anticiposToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.anticiposToolStripMenuItem.Text = "Anticipos";
            this.anticiposToolStripMenuItem.Click += new System.EventHandler(this.anticiposToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineaToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.proveedorToolStripMenuItem,
            this.productosToolStripMenuItem});
            this.reportesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportesToolStripMenuItem.Text = "Analisis";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // lineaToolStripMenuItem
            // 
            this.lineaToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.lineaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.lineaToolStripMenuItem.Name = "lineaToolStripMenuItem";
            this.lineaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.lineaToolStripMenuItem.Text = "Linea";
            this.lineaToolStripMenuItem.Click += new System.EventHandler(this.lineaToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.marcaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.proveedorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detalleToolStripMenuItem,
            this.sumarizadoToolStripMenuItem});
            this.productosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // detalleToolStripMenuItem
            // 
            this.detalleToolStripMenuItem.Name = "detalleToolStripMenuItem";
            this.detalleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.detalleToolStripMenuItem.Text = "Detalle";
            this.detalleToolStripMenuItem.Click += new System.EventHandler(this.detalleToolStripMenuItem_Click);
            // 
            // sumarizadoToolStripMenuItem
            // 
            this.sumarizadoToolStripMenuItem.Name = "sumarizadoToolStripMenuItem";
            this.sumarizadoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sumarizadoToolStripMenuItem.Text = "Sumarizado";
            this.sumarizadoToolStripMenuItem.Click += new System.EventHandler(this.sumarizadoToolStripMenuItem_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(1004, 35);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(75, 23);
            this.btnHistory.TabIndex = 219;
            this.btnHistory.Text = "Historial";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1096, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Domicilios de Entrega";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 475);
            this.panel2.TabIndex = 191;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Controls.Add(this.panel7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1073, 275);
            this.panel9.TabIndex = 290;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 33);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1073, 242);
            this.panel8.TabIndex = 292;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dOMICILIOSXPERSONADataGridView);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1073, 242);
            this.panel6.TabIndex = 290;
            // 
            // dOMICILIOSXPERSONADataGridView
            // 
            this.dOMICILIOSXPERSONADataGridView.AllowUserToAddRows = false;
            this.dOMICILIOSXPERSONADataGridView.AutoGenerateColumns = false;
            this.dOMICILIOSXPERSONADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dOMICILIOSXPERSONADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BTNEDITARDOMICILIO,
            this.BTNELIMINARDOMICILIO,
            this.dataGridViewTextBoxColumn7,
            this.DGDOMACTIVO,
            this.DGID,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn23});
            this.dOMICILIOSXPERSONADataGridView.DataSource = this.dOMICILIOSXPERSONABindingSource;
            this.dOMICILIOSXPERSONADataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dOMICILIOSXPERSONADataGridView.Location = new System.Drawing.Point(0, 0);
            this.dOMICILIOSXPERSONADataGridView.Name = "dOMICILIOSXPERSONADataGridView";
            this.dOMICILIOSXPERSONADataGridView.RowHeadersVisible = false;
            this.dOMICILIOSXPERSONADataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dOMICILIOSXPERSONADataGridView.Size = new System.Drawing.Size(1073, 242);
            this.dOMICILIOSXPERSONADataGridView.TabIndex = 288;
            this.dOMICILIOSXPERSONADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dOMICILIOSXPERSONADataGridView_CellContentClick);
            // 
            // BTNEDITARDOMICILIO
            // 
            this.BTNEDITARDOMICILIO.HeaderText = "";
            this.BTNEDITARDOMICILIO.Image = global::iPos.Properties.Resources.Edit;
            this.BTNEDITARDOMICILIO.Name = "BTNEDITARDOMICILIO";
            this.BTNEDITARDOMICILIO.Width = 35;
            // 
            // BTNELIMINARDOMICILIO
            // 
            this.BTNELIMINARDOMICILIO.HeaderText = "";
            this.BTNELIMINARDOMICILIO.Image = global::iPos.Properties.Resources.outdent;
            this.BTNELIMINARDOMICILIO.Name = "BTNELIMINARDOMICILIO";
            this.BTNELIMINARDOMICILIO.Width = 35;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CALLE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CALLE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // DGDOMACTIVO
            // 
            this.DGDOMACTIVO.DataPropertyName = "ACTIVO";
            this.DGDOMACTIVO.HeaderText = "ACTIVO";
            this.DGDOMACTIVO.Name = "DGDOMACTIVO";
            this.DGDOMACTIVO.Width = 55;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NUMEROEXTERIOR";
            this.dataGridViewTextBoxColumn8.HeaderText = "# EXT";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NUMEROINTERIOR";
            this.dataGridViewTextBoxColumn9.HeaderText = "# INT";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 45;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "COLONIA";
            this.dataGridViewTextBoxColumn10.HeaderText = "COLONIA";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MUNICIPIO";
            this.dataGridViewTextBoxColumn11.HeaderText = "MUNICIPIO";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ESTADO";
            this.dataGridViewTextBoxColumn12.HeaderText = "ESTADO";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CODIGOPOSTAL";
            this.dataGridViewTextBoxColumn13.HeaderText = "C. P.";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 75;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "REFERENCIADOM";
            this.dataGridViewTextBoxColumn18.HeaderText = "REF.";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 75;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "LATITUD";
            this.dataGridViewTextBoxColumn19.HeaderText = "LAT.";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 75;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "LONGITUD";
            this.dataGridViewTextBoxColumn20.HeaderText = "LONG.";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 75;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "PREDETERMINADO";
            this.dataGridViewTextBoxColumn23.HeaderText = "PRED.";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Width = 50;
            // 
            // dOMICILIOSXPERSONABindingSource
            // 
            this.dOMICILIOSXPERSONABindingSource.DataMember = "DOMICILIOSXPERSONA";
            this.dOMICILIOSXPERSONABindingSource.DataSource = this.dSCatalogos3;
            // 
            // dSCatalogos3
            // 
            this.dSCatalogos3.DataSetName = "DSCatalogos3";
            this.dSCatalogos3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BtnAgregarDatosEntrega);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1073, 33);
            this.panel7.TabIndex = 291;
            // 
            // BtnAgregarDatosEntrega
            // 
            this.BtnAgregarDatosEntrega.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarDatosEntrega.BackgroundImage = global::iPos.Properties.Resources.add_J;
            this.BtnAgregarDatosEntrega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAgregarDatosEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarDatosEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnAgregarDatosEntrega.Location = new System.Drawing.Point(1024, 7);
            this.BtnAgregarDatosEntrega.Name = "BtnAgregarDatosEntrega";
            this.BtnAgregarDatosEntrega.Size = new System.Drawing.Size(28, 23);
            this.BtnAgregarDatosEntrega.TabIndex = 192;
            this.BtnAgregarDatosEntrega.UseVisualStyleBackColor = false;
            this.BtnAgregarDatosEntrega.Click += new System.EventHandler(this.BtnAgregarDatosEntrega_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 191;
            this.label12.Text = "DATOS DE ENTREGA";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Controls.Add(this.pnlEdicionDatosEntrega);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 275);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1073, 201);
            this.panel5.TabIndex = 289;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label40);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1073, 30);
            this.panel11.TabIndex = 290;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(34, 9);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(125, 13);
            this.label40.TabIndex = 192;
            this.label40.Text = "EDICION DE DATOS";
            // 
            // pnlEdicionDatosEntrega
            // 
            this.pnlEdicionDatosEntrega.Controls.Add(this.btnMapaEntrega);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label41);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label42);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGALONGITUDTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGALATITUDTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.btnCancelarGuardadoEntrega);
            this.pnlEdicionDatosEntrega.Controls.Add(this.btnGuardarDatosEntrega);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label10);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_LOCALIDADIDTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label8);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_LOCALIDADIDLabel);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label36);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label35);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGACALLETextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_LOCALIDADIDButton);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGAREFERENCIADOMTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label7);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label9);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_MUNICIPIOIDTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_DISTANCIATextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGAESTADOTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGANUMEROEXTERIORTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_MUNICIPIOIDLabel);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label34);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGACODIGOPOSTALTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGANUMEROINTERIORTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_MUNICIPIOIDButton);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_COLONIAIDButton);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label5);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label6);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_COLONIAIDTextBox);
            this.pnlEdicionDatosEntrega.Controls.Add(this.ENTREGA_SAT_COLONIAIDLabel);
            this.pnlEdicionDatosEntrega.Controls.Add(this.label11);
            this.pnlEdicionDatosEntrega.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEdicionDatosEntrega.Enabled = false;
            this.pnlEdicionDatosEntrega.Location = new System.Drawing.Point(0, 25);
            this.pnlEdicionDatosEntrega.Name = "pnlEdicionDatosEntrega";
            this.pnlEdicionDatosEntrega.Size = new System.Drawing.Size(1073, 176);
            this.pnlEdicionDatosEntrega.TabIndex = 289;
            // 
            // btnMapaEntrega
            // 
            this.btnMapaEntrega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnMapaEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMapaEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapaEntrega.ForeColor = System.Drawing.Color.White;
            this.btnMapaEntrega.Location = new System.Drawing.Point(734, 113);
            this.btnMapaEntrega.Name = "btnMapaEntrega";
            this.btnMapaEntrega.Size = new System.Drawing.Size(171, 23);
            this.btnMapaEntrega.TabIndex = 295;
            this.btnMapaEntrega.Text = "Abrir mapa";
            this.btnMapaEntrega.UseVisualStyleBackColor = false;
            this.btnMapaEntrega.Click += new System.EventHandler(this.btnMapaEntrega_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(547, 100);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 13);
            this.label41.TabIndex = 294;
            this.label41.Text = "Longitud:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(348, 100);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(50, 13);
            this.label42.TabIndex = 293;
            this.label42.Text = "Latitud:";
            // 
            // ENTREGALONGITUDTextBox
            // 
            this.ENTREGALONGITUDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ENTREGALONGITUDTextBox.Location = new System.Drawing.Point(550, 116);
            this.ENTREGALONGITUDTextBox.Name = "ENTREGALONGITUDTextBox";
            this.ENTREGALONGITUDTextBox.Size = new System.Drawing.Size(177, 20);
            this.ENTREGALONGITUDTextBox.TabIndex = 292;
            // 
            // ENTREGALATITUDTextBox
            // 
            this.ENTREGALATITUDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ENTREGALATITUDTextBox.Location = new System.Drawing.Point(351, 116);
            this.ENTREGALATITUDTextBox.Name = "ENTREGALATITUDTextBox";
            this.ENTREGALATITUDTextBox.Size = new System.Drawing.Size(193, 20);
            this.ENTREGALATITUDTextBox.TabIndex = 291;
            // 
            // btnCancelarGuardadoEntrega
            // 
            this.btnCancelarGuardadoEntrega.BackColor = System.Drawing.Color.DarkGray;
            this.btnCancelarGuardadoEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarGuardadoEntrega.ForeColor = System.Drawing.Color.White;
            this.btnCancelarGuardadoEntrega.Location = new System.Drawing.Point(911, 147);
            this.btnCancelarGuardadoEntrega.Name = "btnCancelarGuardadoEntrega";
            this.btnCancelarGuardadoEntrega.Size = new System.Drawing.Size(85, 23);
            this.btnCancelarGuardadoEntrega.TabIndex = 290;
            this.btnCancelarGuardadoEntrega.Text = "Cancelar";
            this.btnCancelarGuardadoEntrega.UseVisualStyleBackColor = false;
            this.btnCancelarGuardadoEntrega.Click += new System.EventHandler(this.btnCancelarGuardadoEntrega_Click);
            // 
            // btnGuardarDatosEntrega
            // 
            this.btnGuardarDatosEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarDatosEntrega.ForeColor = System.Drawing.Color.White;
            this.btnGuardarDatosEntrega.Location = new System.Drawing.Point(733, 148);
            this.btnGuardarDatosEntrega.Name = "btnGuardarDatosEntrega";
            this.btnGuardarDatosEntrega.Size = new System.Drawing.Size(172, 23);
            this.btnGuardarDatosEntrega.TabIndex = 289;
            this.btnGuardarDatosEntrega.Text = "Guardar datos de entrega";
            this.btnGuardarDatosEntrega.UseVisualStyleBackColor = true;
            this.btnGuardarDatosEntrega.Click += new System.EventHandler(this.btnGuardarDatosEntrega_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 179;
            this.label10.Text = "Estado: ";
            // 
            // ENTREGA_SAT_LOCALIDADIDTextBox
            // 
            this.ENTREGA_SAT_LOCALIDADIDTextBox.BotonLookUp = this.ENTREGA_SAT_LOCALIDADIDButton;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Condicion = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.DbValue = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Format_Expression = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.IndiceCampoDescripcion = 2;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.IndiceCampoSelector = 1;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.IndiceCampoValue = 0;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.LabelDescription = this.ENTREGA_SAT_LOCALIDADIDLabel;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Location = new System.Drawing.Point(351, 25);
            this.ENTREGA_SAT_LOCALIDADIDTextBox.MostrarErrores = true;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Name = "ENTREGA_SAT_LOCALIDADIDTextBox";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.NombreCampoSelector = "clave";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.NombreCampoValue = "id";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Query = resources.GetString("ENTREGA_SAT_LOCALIDADIDTextBox.Query");
            this.ENTREGA_SAT_LOCALIDADIDTextBox.QueryDeSeleccion = resources.GetString("ENTREGA_SAT_LOCALIDADIDTextBox.QueryDeSeleccion");
            this.ENTREGA_SAT_LOCALIDADIDTextBox.QueryPorDBValue = "SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIP" +
    "CION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON LOC.clave_estado = E" +
    "STADO.acronimo WHERE  LOC.ID = @id";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.ENTREGA_SAT_LOCALIDADIDTextBox.TabIndex = 203;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Tag = "36";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.TextDescription = null;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.Titulo = "Localidad";
            this.ENTREGA_SAT_LOCALIDADIDTextBox.ValidarEntrada = true;
            this.ENTREGA_SAT_LOCALIDADIDTextBox.ValidationExpression = null;
            // 
            // ENTREGA_SAT_LOCALIDADIDButton
            // 
            this.ENTREGA_SAT_LOCALIDADIDButton.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_LOCALIDADIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENTREGA_SAT_LOCALIDADIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENTREGA_SAT_LOCALIDADIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENTREGA_SAT_LOCALIDADIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENTREGA_SAT_LOCALIDADIDButton.Location = new System.Drawing.Point(398, 23);
            this.ENTREGA_SAT_LOCALIDADIDButton.Name = "ENTREGA_SAT_LOCALIDADIDButton";
            this.ENTREGA_SAT_LOCALIDADIDButton.Size = new System.Drawing.Size(23, 23);
            this.ENTREGA_SAT_LOCALIDADIDButton.TabIndex = 204;
            this.ENTREGA_SAT_LOCALIDADIDButton.UseVisualStyleBackColor = false;
            // 
            // ENTREGA_SAT_LOCALIDADIDLabel
            // 
            this.ENTREGA_SAT_LOCALIDADIDLabel.AutoSize = true;
            this.ENTREGA_SAT_LOCALIDADIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_LOCALIDADIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTREGA_SAT_LOCALIDADIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ENTREGA_SAT_LOCALIDADIDLabel.Location = new System.Drawing.Point(420, 32);
            this.ENTREGA_SAT_LOCALIDADIDLabel.Name = "ENTREGA_SAT_LOCALIDADIDLabel";
            this.ENTREGA_SAT_LOCALIDADIDLabel.Size = new System.Drawing.Size(19, 13);
            this.ENTREGA_SAT_LOCALIDADIDLabel.TabIndex = 277;
            this.ENTREGA_SAT_LOCALIDADIDLabel.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 177;
            this.label8.Text = "Colonia: ";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(4, 100);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(140, 13);
            this.label36.TabIndex = 288;
            this.label36.Text = "Referencia domiciliaria:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(349, 8);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(66, 13);
            this.label35.TabIndex = 275;
            this.label35.Text = "Localidad:";
            // 
            // ENTREGACALLETextBox
            // 
            this.ENTREGACALLETextBox.Location = new System.Drawing.Point(352, 69);
            this.ENTREGACALLETextBox.Name = "ENTREGACALLETextBox";
            this.ENTREGACALLETextBox.Size = new System.Drawing.Size(375, 20);
            this.ENTREGACALLETextBox.TabIndex = 209;
            // 
            // ENTREGAREFERENCIADOMTextBox
            // 
            this.ENTREGAREFERENCIADOMTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ENTREGAREFERENCIADOMTextBox.Location = new System.Drawing.Point(4, 116);
            this.ENTREGAREFERENCIADOMTextBox.Name = "ENTREGAREFERENCIADOMTextBox";
            this.ENTREGAREFERENCIADOMTextBox.Size = new System.Drawing.Size(339, 20);
            this.ENTREGAREFERENCIADOMTextBox.TabIndex = 212;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 178;
            this.label7.Text = "Domicilio :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(731, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 180;
            this.label9.Text = "Ciudad:";
            // 
            // ENTREGA_SAT_MUNICIPIOIDTextBox
            // 
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.BotonLookUp = this.ENTREGA_SAT_MUNICIPIOIDButton;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Condicion = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbValue = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Format_Expression = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.IndiceCampoDescripcion = 2;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.IndiceCampoSelector = 1;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.IndiceCampoValue = 0;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.LabelDescription = this.ENTREGA_SAT_MUNICIPIOIDLabel;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Location = new System.Drawing.Point(733, 23);
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.MostrarErrores = true;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Name = "ENTREGA_SAT_MUNICIPIOIDTextBox";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.NombreCampoSelector = "clave";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.NombreCampoValue = "id";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Query = resources.GetString("ENTREGA_SAT_MUNICIPIOIDTextBox.Query");
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.QueryDeSeleccion = resources.GetString("ENTREGA_SAT_MUNICIPIOIDTextBox.QueryDeSeleccion");
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.QueryPorDBValue = "SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIP" +
    "CION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON MUN.clave_estado = E" +
    "STADO.acronimo WHERE  MUN.ID = @id";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.TabIndex = 205;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Tag = "36";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.TextDescription = null;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Titulo = "Municipio";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.ValidarEntrada = true;
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.ValidationExpression = null;
            // 
            // ENTREGA_SAT_MUNICIPIOIDButton
            // 
            this.ENTREGA_SAT_MUNICIPIOIDButton.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_MUNICIPIOIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENTREGA_SAT_MUNICIPIOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENTREGA_SAT_MUNICIPIOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENTREGA_SAT_MUNICIPIOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENTREGA_SAT_MUNICIPIOIDButton.Location = new System.Drawing.Point(780, 21);
            this.ENTREGA_SAT_MUNICIPIOIDButton.Name = "ENTREGA_SAT_MUNICIPIOIDButton";
            this.ENTREGA_SAT_MUNICIPIOIDButton.Size = new System.Drawing.Size(23, 23);
            this.ENTREGA_SAT_MUNICIPIOIDButton.TabIndex = 206;
            this.ENTREGA_SAT_MUNICIPIOIDButton.UseVisualStyleBackColor = false;
            // 
            // ENTREGA_SAT_MUNICIPIOIDLabel
            // 
            this.ENTREGA_SAT_MUNICIPIOIDLabel.AutoSize = true;
            this.ENTREGA_SAT_MUNICIPIOIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTREGA_SAT_MUNICIPIOIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Location = new System.Drawing.Point(802, 30);
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Name = "ENTREGA_SAT_MUNICIPIOIDLabel";
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Size = new System.Drawing.Size(19, 13);
            this.ENTREGA_SAT_MUNICIPIOIDLabel.TabIndex = 280;
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Text = "...";
            // 
            // ENTREGA_DISTANCIATextBox
            // 
            this.ENTREGA_DISTANCIATextBox.AllowNegative = true;
            this.ENTREGA_DISTANCIATextBox.Format_Expression = null;
            this.ENTREGA_DISTANCIATextBox.Location = new System.Drawing.Point(911, 69);
            this.ENTREGA_DISTANCIATextBox.Name = "ENTREGA_DISTANCIATextBox";
            this.ENTREGA_DISTANCIATextBox.NumericPrecision = 18;
            this.ENTREGA_DISTANCIATextBox.NumericScaleOnFocus = 3;
            this.ENTREGA_DISTANCIATextBox.NumericScaleOnLostFocus = 3;
            this.ENTREGA_DISTANCIATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ENTREGA_DISTANCIATextBox.Size = new System.Drawing.Size(85, 20);
            this.ENTREGA_DISTANCIATextBox.TabIndex = 212;
            this.ENTREGA_DISTANCIATextBox.Tag = "";
            this.ENTREGA_DISTANCIATextBox.Text = "0.000";
            this.ENTREGA_DISTANCIATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ENTREGA_DISTANCIATextBox.ValidationExpression = null;
            this.ENTREGA_DISTANCIATextBox.ZeroIsValid = true;
            // 
            // ENTREGAESTADOTextBox
            // 
            this.ENTREGAESTADOTextBox.Condicion = null;
            this.ENTREGAESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGAESTADOTextBox.DisplayMember = "nombre";
            this.ENTREGAESTADOTextBox.FormattingEnabled = true;
            this.ENTREGAESTADOTextBox.IndiceCampoSelector = 0;
            this.ENTREGAESTADOTextBox.LabelDescription = null;
            this.ENTREGAESTADOTextBox.Location = new System.Drawing.Point(6, 24);
            this.ENTREGAESTADOTextBox.Name = "ENTREGAESTADOTextBox";
            this.ENTREGAESTADOTextBox.NombreCampoSelector = "id";
            this.ENTREGAESTADOTextBox.Query = "select id,nombre from estado";
            this.ENTREGAESTADOTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.ENTREGAESTADOTextBox.SelectedDataDisplaying = null;
            this.ENTREGAESTADOTextBox.SelectedDataValue = null;
            this.ENTREGAESTADOTextBox.Size = new System.Drawing.Size(227, 21);
            this.ENTREGAESTADOTextBox.TabIndex = 201;
            this.ENTREGAESTADOTextBox.ValueMember = "id";
            this.ENTREGAESTADOTextBox.SelectedIndexChanged += new System.EventHandler(this.ENTREGAESTADOTextBox_SelectedIndexChanged);
            // 
            // ENTREGANUMEROEXTERIORTextBox
            // 
            this.ENTREGANUMEROEXTERIORTextBox.Location = new System.Drawing.Point(733, 69);
            this.ENTREGANUMEROEXTERIORTextBox.Name = "ENTREGANUMEROEXTERIORTextBox";
            this.ENTREGANUMEROEXTERIORTextBox.Size = new System.Drawing.Size(69, 20);
            this.ENTREGANUMEROEXTERIORTextBox.TabIndex = 210;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(908, 54);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 13);
            this.label34.TabIndex = 286;
            this.label34.Text = "Distancia:";
            // 
            // ENTREGACODIGOPOSTALTextBox
            // 
            this.ENTREGACODIGOPOSTALTextBox.Location = new System.Drawing.Point(246, 25);
            this.ENTREGACODIGOPOSTALTextBox.Name = "ENTREGACODIGOPOSTALTextBox";
            this.ENTREGACODIGOPOSTALTextBox.Size = new System.Drawing.Size(97, 20);
            this.ENTREGACODIGOPOSTALTextBox.TabIndex = 202;
            this.ENTREGACODIGOPOSTALTextBox.Validated += new System.EventHandler(this.ENTREGACODIGOPOSTALTextBox_Validated);
            // 
            // ENTREGANUMEROINTERIORTextBox
            // 
            this.ENTREGANUMEROINTERIORTextBox.Location = new System.Drawing.Point(815, 69);
            this.ENTREGANUMEROINTERIORTextBox.Name = "ENTREGANUMEROINTERIORTextBox";
            this.ENTREGANUMEROINTERIORTextBox.Size = new System.Drawing.Size(73, 20);
            this.ENTREGANUMEROINTERIORTextBox.TabIndex = 211;
            // 
            // ENTREGA_SAT_COLONIAIDButton
            // 
            this.ENTREGA_SAT_COLONIAIDButton.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_COLONIAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENTREGA_SAT_COLONIAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENTREGA_SAT_COLONIAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENTREGA_SAT_COLONIAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENTREGA_SAT_COLONIAIDButton.Location = new System.Drawing.Point(52, 65);
            this.ENTREGA_SAT_COLONIAIDButton.Name = "ENTREGA_SAT_COLONIAIDButton";
            this.ENTREGA_SAT_COLONIAIDButton.Size = new System.Drawing.Size(23, 23);
            this.ENTREGA_SAT_COLONIAIDButton.TabIndex = 208;
            this.ENTREGA_SAT_COLONIAIDButton.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(811, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 190;
            this.label5.Text = "Num. Int.: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(730, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 189;
            this.label6.Text = "Num. Ext.: ";
            // 
            // ENTREGA_SAT_COLONIAIDTextBox
            // 
            this.ENTREGA_SAT_COLONIAIDTextBox.BotonLookUp = this.ENTREGA_SAT_COLONIAIDButton;
            this.ENTREGA_SAT_COLONIAIDTextBox.Condicion = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_COLONIAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENTREGA_SAT_COLONIAIDTextBox.DbValue = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.Format_Expression = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.IndiceCampoDescripcion = 2;
            this.ENTREGA_SAT_COLONIAIDTextBox.IndiceCampoSelector = 1;
            this.ENTREGA_SAT_COLONIAIDTextBox.IndiceCampoValue = 0;
            this.ENTREGA_SAT_COLONIAIDTextBox.LabelDescription = this.ENTREGA_SAT_COLONIAIDLabel;
            this.ENTREGA_SAT_COLONIAIDTextBox.Location = new System.Drawing.Point(5, 67);
            this.ENTREGA_SAT_COLONIAIDTextBox.MostrarErrores = true;
            this.ENTREGA_SAT_COLONIAIDTextBox.Name = "ENTREGA_SAT_COLONIAIDTextBox";
            this.ENTREGA_SAT_COLONIAIDTextBox.NombreCampoSelector = "clave";
            this.ENTREGA_SAT_COLONIAIDTextBox.NombreCampoValue = "id";
            this.ENTREGA_SAT_COLONIAIDTextBox.Query = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C WHERE c.codigopostal = @CODIGOPOSTAL ORDER BY C.nombre";
            this.ENTREGA_SAT_COLONIAIDTextBox.QueryDeSeleccion = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C WHERE c.codigopostal = @CODIGOPOSTAL  and c.COLONIA = @clave";
            this.ENTREGA_SAT_COLONIAIDTextBox.QueryPorDBValue = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C  WHERE c.ID = @id";
            this.ENTREGA_SAT_COLONIAIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.ENTREGA_SAT_COLONIAIDTextBox.TabIndex = 207;
            this.ENTREGA_SAT_COLONIAIDTextBox.Tag = "36";
            this.ENTREGA_SAT_COLONIAIDTextBox.TextDescription = null;
            this.ENTREGA_SAT_COLONIAIDTextBox.Titulo = "Colonia";
            this.ENTREGA_SAT_COLONIAIDTextBox.ValidarEntrada = true;
            this.ENTREGA_SAT_COLONIAIDTextBox.ValidationExpression = null;
            // 
            // ENTREGA_SAT_COLONIAIDLabel
            // 
            this.ENTREGA_SAT_COLONIAIDLabel.AutoSize = true;
            this.ENTREGA_SAT_COLONIAIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.ENTREGA_SAT_COLONIAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENTREGA_SAT_COLONIAIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ENTREGA_SAT_COLONIAIDLabel.Location = new System.Drawing.Point(74, 74);
            this.ENTREGA_SAT_COLONIAIDLabel.Name = "ENTREGA_SAT_COLONIAIDLabel";
            this.ENTREGA_SAT_COLONIAIDLabel.Size = new System.Drawing.Size(19, 13);
            this.ENTREGA_SAT_COLONIAIDLabel.TabIndex = 283;
            this.ENTREGA_SAT_COLONIAIDLabel.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(243, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 181;
            this.label11.Text = "Código postal: ";
            // 
            // GENERACARTAPORTETextBox
            // 
            this.GENERACARTAPORTETextBox.AutoSize = true;
            this.GENERACARTAPORTETextBox.Location = new System.Drawing.Point(288, 241);
            this.GENERACARTAPORTETextBox.Name = "GENERACARTAPORTETextBox";
            this.GENERACARTAPORTETextBox.Size = new System.Drawing.Size(133, 17);
            this.GENERACARTAPORTETextBox.TabIndex = 228;
            this.GENERACARTAPORTETextBox.Text = "Genera carta porte";
            this.GENERACARTAPORTETextBox.UseVisualStyleBackColor = true;
            // 
            // GENERACOMPROBTRASLTextBox
            // 
            this.GENERACOMPROBTRASLTextBox.AutoSize = true;
            this.GENERACOMPROBTRASLTextBox.Location = new System.Drawing.Point(29, 241);
            this.GENERACOMPROBTRASLTextBox.Name = "GENERACOMPROBTRASLTextBox";
            this.GENERACOMPROBTRASLTextBox.Size = new System.Drawing.Size(193, 17);
            this.GENERACOMPROBTRASLTextBox.TabIndex = 227;
            this.GENERACOMPROBTRASLTextBox.Text = "Genera comprobante traslado";
            this.GENERACOMPROBTRASLTextBox.UseVisualStyleBackColor = true;
            // 
            // MAYOREOXPRODUCTOTextBox
            // 
            this.MAYOREOXPRODUCTOTextBox.AutoSize = true;
            this.MAYOREOXPRODUCTOTextBox.Location = new System.Drawing.Point(776, 190);
            this.MAYOREOXPRODUCTOTextBox.Name = "MAYOREOXPRODUCTOTextBox";
            this.MAYOREOXPRODUCTOTextBox.Size = new System.Drawing.Size(194, 17);
            this.MAYOREOXPRODUCTOTextBox.TabIndex = 226;
            this.MAYOREOXPRODUCTOTextBox.Text = "Maneja mayoreo por producto";
            this.MAYOREOXPRODUCTOTextBox.UseVisualStyleBackColor = true;
            // 
            // PREGUNTARTICKETLARGOTextBox
            // 
            this.PREGUNTARTICKETLARGOTextBox.AutoSize = true;
            this.PREGUNTARTICKETLARGOTextBox.Location = new System.Drawing.Point(507, 189);
            this.PREGUNTARTICKETLARGOTextBox.Name = "PREGUNTARTICKETLARGOTextBox";
            this.PREGUNTARTICKETLARGOTextBox.Size = new System.Drawing.Size(149, 17);
            this.PREGUNTARTICKETLARGOTextBox.TabIndex = 225;
            this.PREGUNTARTICKETLARGOTextBox.Text = "Preguntar ticket largo";
            this.PREGUNTARTICKETLARGOTextBox.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(26, 167);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(115, 13);
            this.label31.TabIndex = 224;
            this.label31.Text = "Ruta de embarque:";
            // 
            // RUTAEMBARQUEIDButton
            // 
            this.RUTAEMBARQUEIDButton.BackColor = System.Drawing.Color.Transparent;
            this.RUTAEMBARQUEIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.RUTAEMBARQUEIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RUTAEMBARQUEIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RUTAEMBARQUEIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.RUTAEMBARQUEIDButton.Location = new System.Drawing.Point(116, 186);
            this.RUTAEMBARQUEIDButton.Name = "RUTAEMBARQUEIDButton";
            this.RUTAEMBARQUEIDButton.Size = new System.Drawing.Size(23, 23);
            this.RUTAEMBARQUEIDButton.TabIndex = 223;
            this.RUTAEMBARQUEIDButton.UseVisualStyleBackColor = false;
            this.RUTAEMBARQUEIDButton.Click += new System.EventHandler(this.RUTAEMBARQUEIDButton_Click);
            // 
            // RUTAEMBARQUEIDTextBox
            // 
            this.RUTAEMBARQUEIDTextBox.BotonLookUp = null;
            this.RUTAEMBARQUEIDTextBox.Condicion = null;
            this.RUTAEMBARQUEIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.RUTAEMBARQUEIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.RUTAEMBARQUEIDTextBox.DbValue = null;
            this.RUTAEMBARQUEIDTextBox.Format_Expression = null;
            this.RUTAEMBARQUEIDTextBox.IndiceCampoDescripcion = 2;
            this.RUTAEMBARQUEIDTextBox.IndiceCampoSelector = 1;
            this.RUTAEMBARQUEIDTextBox.IndiceCampoValue = 0;
            this.RUTAEMBARQUEIDTextBox.LabelDescription = this.RUTAEMBARQUEIDDescLabel;
            this.RUTAEMBARQUEIDTextBox.Location = new System.Drawing.Point(28, 189);
            this.RUTAEMBARQUEIDTextBox.MostrarErrores = true;
            this.RUTAEMBARQUEIDTextBox.Name = "RUTAEMBARQUEIDTextBox";
            this.RUTAEMBARQUEIDTextBox.NombreCampoSelector = "clave";
            this.RUTAEMBARQUEIDTextBox.NombreCampoValue = "id";
            this.RUTAEMBARQUEIDTextBox.Query = "select id,clave,nombre from rutaembarque";
            this.RUTAEMBARQUEIDTextBox.QueryDeSeleccion = "select id,clave,nombre from rutaembarque where clave = @clave";
            this.RUTAEMBARQUEIDTextBox.QueryPorDBValue = "select id,clave,nombre from rutaembarque where id = @id";
            this.RUTAEMBARQUEIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.RUTAEMBARQUEIDTextBox.TabIndex = 222;
            this.RUTAEMBARQUEIDTextBox.Tag = 34;
            this.RUTAEMBARQUEIDTextBox.TextDescription = null;
            this.RUTAEMBARQUEIDTextBox.Titulo = "Rutas de Embarque";
            this.RUTAEMBARQUEIDTextBox.ValidarEntrada = true;
            this.RUTAEMBARQUEIDTextBox.ValidationExpression = null;
            // 
            // RUTAEMBARQUEIDDescLabel
            // 
            this.RUTAEMBARQUEIDDescLabel.AutoSize = true;
            this.RUTAEMBARQUEIDDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.RUTAEMBARQUEIDDescLabel.Enabled = false;
            this.RUTAEMBARQUEIDDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RUTAEMBARQUEIDDescLabel.ForeColor = System.Drawing.Color.White;
            this.RUTAEMBARQUEIDDescLabel.Location = new System.Drawing.Point(143, 194);
            this.RUTAEMBARQUEIDDescLabel.Name = "RUTAEMBARQUEIDDescLabel";
            this.RUTAEMBARQUEIDDescLabel.Size = new System.Drawing.Size(16, 13);
            this.RUTAEMBARQUEIDDescLabel.TabIndex = 221;
            this.RUTAEMBARQUEIDDescLabel.Text = "...";
            // 
            // btnCuentasBanco
            // 
            this.btnCuentasBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCuentasBanco.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCuentasBanco.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCuentasBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentasBanco.ForeColor = System.Drawing.Color.White;
            this.btnCuentasBanco.Location = new System.Drawing.Point(674, 124);
            this.btnCuentasBanco.Name = "btnCuentasBanco";
            this.btnCuentasBanco.Size = new System.Drawing.Size(180, 23);
            this.btnCuentasBanco.TabIndex = 220;
            this.btnCuentasBanco.Text = "Cuentas de banco";
            this.btnCuentasBanco.UseVisualStyleBackColor = false;
            this.btnCuentasBanco.Click += new System.EventHandler(this.btnCuentasBanco_Click);
            // 
            // EXENTOIVATextBox
            // 
            this.EXENTOIVATextBox.AutoSize = true;
            this.EXENTOIVATextBox.Location = new System.Drawing.Point(539, 124);
            this.EXENTOIVATextBox.Name = "EXENTOIVATextBox";
            this.EXENTOIVATextBox.Size = new System.Drawing.Size(86, 17);
            this.EXENTOIVATextBox.TabIndex = 219;
            this.EXENTOIVATextBox.Text = "Exento iva";
            this.EXENTOIVATextBox.UseVisualStyleBackColor = true;
            // 
            // PROVEECLIENTEIDButton
            // 
            this.PROVEECLIENTEIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PROVEECLIENTEIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PROVEECLIENTEIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROVEECLIENTEIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEECLIENTEIDButton.Location = new System.Drawing.Point(733, 47);
            this.PROVEECLIENTEIDButton.Name = "PROVEECLIENTEIDButton";
            this.PROVEECLIENTEIDButton.Size = new System.Drawing.Size(21, 23);
            this.PROVEECLIENTEIDButton.TabIndex = 216;
            this.PROVEECLIENTEIDButton.UseVisualStyleBackColor = true;
            // 
            // PROVEECLIENTEIDTextBox
            // 
            this.PROVEECLIENTEIDTextBox.BotonLookUp = this.PROVEECLIENTEIDButton;
            this.PROVEECLIENTEIDTextBox.Condicion = null;
            this.PROVEECLIENTEIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEECLIENTEIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEECLIENTEIDTextBox.DbValue = null;
            this.PROVEECLIENTEIDTextBox.Format_Expression = null;
            this.PROVEECLIENTEIDTextBox.IndiceCampoDescripcion = 2;
            this.PROVEECLIENTEIDTextBox.IndiceCampoSelector = 1;
            this.PROVEECLIENTEIDTextBox.IndiceCampoValue = 0;
            this.PROVEECLIENTEIDTextBox.LabelDescription = this.PROVEECLIENTEIDLabel;
            this.PROVEECLIENTEIDTextBox.Location = new System.Drawing.Point(645, 48);
            this.PROVEECLIENTEIDTextBox.MostrarErrores = true;
            this.PROVEECLIENTEIDTextBox.Name = "PROVEECLIENTEIDTextBox";
            this.PROVEECLIENTEIDTextBox.NombreCampoSelector = "clave";
            this.PROVEECLIENTEIDTextBox.NombreCampoValue = "id";
            this.PROVEECLIENTEIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 40";
            this.PROVEECLIENTEIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 40 and  clave = @clave";
            this.PROVEECLIENTEIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 40 and  id = @id";
            this.PROVEECLIENTEIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PROVEECLIENTEIDTextBox.TabIndex = 215;
            this.PROVEECLIENTEIDTextBox.Tag = 34;
            this.PROVEECLIENTEIDTextBox.TextDescription = null;
            this.PROVEECLIENTEIDTextBox.Titulo = "Proveedores";
            this.PROVEECLIENTEIDTextBox.ValidarEntrada = true;
            this.PROVEECLIENTEIDTextBox.ValidationExpression = null;
            // 
            // PROVEECLIENTEIDLabel
            // 
            this.PROVEECLIENTEIDLabel.AutoSize = true;
            this.PROVEECLIENTEIDLabel.Location = new System.Drawing.Point(760, 52);
            this.PROVEECLIENTEIDLabel.Name = "PROVEECLIENTEIDLabel";
            this.PROVEECLIENTEIDLabel.Size = new System.Drawing.Size(19, 13);
            this.PROVEECLIENTEIDLabel.TabIndex = 218;
            this.PROVEECLIENTEIDLabel.Text = "...";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 214;
            this.label20.Text = "OTROS";
            // 
            // EMAIL4TextBox
            // 
            this.EMAIL4TextBox.Location = new System.Drawing.Point(268, 121);
            this.EMAIL4TextBox.Name = "EMAIL4TextBox";
            this.EMAIL4TextBox.Size = new System.Drawing.Size(242, 20);
            this.EMAIL4TextBox.TabIndex = 218;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(265, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 211;
            this.label18.Text = "E-mail 4:";
            // 
            // EMAIL3TextBox
            // 
            this.EMAIL3TextBox.Location = new System.Drawing.Point(28, 120);
            this.EMAIL3TextBox.Name = "EMAIL3TextBox";
            this.EMAIL3TextBox.Size = new System.Drawing.Size(226, 20);
            this.EMAIL3TextBox.TabIndex = 217;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 13);
            this.label19.TabIndex = 210;
            this.label19.Text = "E-mail 3:";
            // 
            // RETIENEIVATextBox
            // 
            this.RETIENEIVATextBox.AutoSize = true;
            this.RETIENEIVATextBox.Location = new System.Drawing.Point(29, 47);
            this.RETIENEIVATextBox.Name = "RETIENEIVATextBox";
            this.RETIENEIVATextBox.Size = new System.Drawing.Size(94, 17);
            this.RETIENEIVATextBox.TabIndex = 213;
            this.RETIENEIVATextBox.Text = "Retiene IVA";
            this.RETIENEIVATextBox.UseVisualStyleBackColor = true;
            // 
            // RETIENEISRTextBox
            // 
            this.RETIENEISRTextBox.AutoSize = true;
            this.RETIENEISRTextBox.Location = new System.Drawing.Point(298, 47);
            this.RETIENEISRTextBox.Name = "RETIENEISRTextBox";
            this.RETIENEISRTextBox.Size = new System.Drawing.Size(95, 17);
            this.RETIENEISRTextBox.TabIndex = 214;
            this.RETIENEISRTextBox.Text = "Retiene ISR";
            this.RETIENEISRTextBox.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(772, 29);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 13);
            this.label32.TabIndex = 228;
            this.label32.Text = "Tipo Cliente:";
            // 
            // SUBTIPOCLIENTEButton
            // 
            this.SUBTIPOCLIENTEButton.BackColor = System.Drawing.Color.Transparent;
            this.SUBTIPOCLIENTEButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SUBTIPOCLIENTEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SUBTIPOCLIENTEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUBTIPOCLIENTEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SUBTIPOCLIENTEButton.Location = new System.Drawing.Point(942, 23);
            this.SUBTIPOCLIENTEButton.Name = "SUBTIPOCLIENTEButton";
            this.SUBTIPOCLIENTEButton.Size = new System.Drawing.Size(23, 23);
            this.SUBTIPOCLIENTEButton.TabIndex = 43;
            this.SUBTIPOCLIENTEButton.UseVisualStyleBackColor = false;
            // 
            // SUBTIPOCLIENTETextBox
            // 
            this.SUBTIPOCLIENTETextBox.BotonLookUp = this.SUBTIPOCLIENTEButton;
            this.SUBTIPOCLIENTETextBox.Condicion = null;
            this.SUBTIPOCLIENTETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUBTIPOCLIENTETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUBTIPOCLIENTETextBox.DbValue = null;
            this.SUBTIPOCLIENTETextBox.Format_Expression = null;
            this.SUBTIPOCLIENTETextBox.IndiceCampoDescripcion = 2;
            this.SUBTIPOCLIENTETextBox.IndiceCampoSelector = 1;
            this.SUBTIPOCLIENTETextBox.IndiceCampoValue = 1;
            this.SUBTIPOCLIENTETextBox.LabelDescription = this.SUBTIPOCLIENTEDescLabel;
            this.SUBTIPOCLIENTETextBox.Location = new System.Drawing.Point(857, 25);
            this.SUBTIPOCLIENTETextBox.MostrarErrores = true;
            this.SUBTIPOCLIENTETextBox.Name = "SUBTIPOCLIENTETextBox";
            this.SUBTIPOCLIENTETextBox.NombreCampoSelector = "clave";
            this.SUBTIPOCLIENTETextBox.NombreCampoValue = "clave";
            this.SUBTIPOCLIENTETextBox.Query = "select id,clave,nombre from subtipocliente";
            this.SUBTIPOCLIENTETextBox.QueryDeSeleccion = "select id,clave,nombre from subtipocliente where clave = @clave";
            this.SUBTIPOCLIENTETextBox.QueryPorDBValue = "select id,clave,nombre from subtipocliente where clave = @clave";
            this.SUBTIPOCLIENTETextBox.Size = new System.Drawing.Size(82, 20);
            this.SUBTIPOCLIENTETextBox.TabIndex = 42;
            this.SUBTIPOCLIENTETextBox.Tag = "36";
            this.SUBTIPOCLIENTETextBox.TextDescription = null;
            this.SUBTIPOCLIENTETextBox.Titulo = "Tipo cliente";
            this.SUBTIPOCLIENTETextBox.ValidarEntrada = true;
            this.SUBTIPOCLIENTETextBox.ValidationExpression = null;
            // 
            // SUBTIPOCLIENTEDescLabel
            // 
            this.SUBTIPOCLIENTEDescLabel.AutoSize = true;
            this.SUBTIPOCLIENTEDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.SUBTIPOCLIENTEDescLabel.Enabled = false;
            this.SUBTIPOCLIENTEDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SUBTIPOCLIENTEDescLabel.ForeColor = System.Drawing.Color.White;
            this.SUBTIPOCLIENTEDescLabel.Location = new System.Drawing.Point(974, 32);
            this.SUBTIPOCLIENTEDescLabel.Name = "SUBTIPOCLIENTEDescLabel";
            this.SUBTIPOCLIENTEDescLabel.Size = new System.Drawing.Size(16, 13);
            this.SUBTIPOCLIENTEDescLabel.TabIndex = 225;
            this.SUBTIPOCLIENTEDescLabel.Text = "...";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1096, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnAbrirMapa);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.LONGITUDTextBox);
            this.panel1.Controls.Add(this.LATITUDTextBox);
            this.panel1.Controls.Add(this.SAT_REGIMENFISCALIDButton);
            this.panel1.Controls.Add(this.SAT_REGIMENFISCALIDLabel);
            this.panel1.Controls.Add(this.pSAT_REGIMENFISCALIDLabel);
            this.panel1.Controls.Add(this.SAT_REGIMENFISCALIDTextBox);
            this.panel1.Controls.Add(this.SAT_COLONIAIDButton);
            this.panel1.Controls.Add(this.SAT_COLONIAIDLabel);
            this.panel1.Controls.Add(this.SAT_COLONIAIDTextBox);
            this.panel1.Controls.Add(this.SAT_MUNICIPIOIDButton);
            this.panel1.Controls.Add(this.SAT_MUNICIPIOIDLabel);
            this.panel1.Controls.Add(this.SAT_MUNICIPIOIDTextBox);
            this.panel1.Controls.Add(this.SAT_LOCALIDADIDButton);
            this.panel1.Controls.Add(this.SAT_LOCALIDADIDLabel);
            this.panel1.Controls.Add(this.SAT_LOCALIDADIDTextBox);
            this.panel1.Controls.Add(this.DISTANCIATextBox);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.SUBTIPOCLIENTEButton);
            this.panel1.Controls.Add(this.SAT_USOCFDIIDTextBox);
            this.panel1.Controls.Add(this.SUBTIPOCLIENTEDescLabel);
            this.panel1.Controls.Add(this.SAT_USOCFDIIDLabel);
            this.panel1.Controls.Add(this.SUBTIPOCLIENTETextBox);
            this.panel1.Controls.Add(pSAT_USOCFDIIDLabel);
            this.panel1.Controls.Add(this.PAISComboBoxFb);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.CIUDADLabel);
            this.panel1.Controls.Add(this.txtCuentaContpaq);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.chkOrdenCompra);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.REFERENCIADOMTextBox);
            this.panel1.Controls.Add(this.ULTIMAVENTATextBox);
            this.panel1.Controls.Add(label44);
            this.panel1.Controls.Add(this.SERVICIOADOMICILIOTextBox);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.pnlDesglosaIEPS);
            this.panel1.Controls.Add(this.MONEDAButton);
            this.panel1.Controls.Add(this.MONEDAIDTextBox);
            this.panel1.Controls.Add(this.MONEDALabel);
            this.panel1.Controls.Add(this.mONEDAIDLabel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ESTADOTextBox);
            this.panel1.Controls.Add(this.Pcredito);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.VENDEDORIDTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.VENDEDORIDLabel);
            this.panel1.Controls.Add(this.VENDEDORButton);
            this.panel1.Controls.Add(this.NUMEROINTERIORTextBox);
            this.panel1.Controls.Add(this.NUMEROEXTERIORTextBox);
            this.panel1.Controls.Add(this.VENDEDORLabel);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.DOMICILIOLabel);
            this.panel1.Controls.Add(this.DOMICILIOTextBox);
            this.panel1.Controls.Add(this.CREADOPOR_USERIDLabel);
            this.panel1.Controls.Add(this.TextBoxCREADOPOR_USERCLAVE);
            this.panel1.Controls.Add(this.COLONIALabel);
            this.panel1.Controls.Add(this.MODIFICADOPOR_USERIDLabel);
            this.panel1.Controls.Add(this.MODIFICADOPOR_USERIDTextBox);
            this.panel1.Controls.Add(this.VIGENCIATextBox);
            this.panel1.Controls.Add(this.VIGENCIALabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.CONTACTO2TextBox);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Controls.Add(this.CONTACTO2Label);
            this.panel1.Controls.Add(this.ESTADOLabel);
            this.panel1.Controls.Add(this.CONTACTO1TextBox);
            this.panel1.Controls.Add(this.CONTACTO1Label);
            this.panel1.Controls.Add(this.MEMOLabel);
            this.panel1.Controls.Add(this.RFCTextBox);
            this.panel1.Controls.Add(this.MEMOTextBox);
            this.panel1.Controls.Add(this.PAISLabel);
            this.panel1.Controls.Add(this.RFCLabel);
            this.panel1.Controls.Add(this.EMAIL2TextBox);
            this.panel1.Controls.Add(this.EMAIL2Label);
            this.panel1.Controls.Add(this.RAZONSOCIALTextBox);
            this.panel1.Controls.Add(this.EMAIL1TextBox);
            this.panel1.Controls.Add(this.RAZONSOCIALLabel);
            this.panel1.Controls.Add(this.EMAIL1Label);
            this.panel1.Controls.Add(this.NOMBRESLabel);
            this.panel1.Controls.Add(this.CODIGOPOSTALLabel);
            this.panel1.Controls.Add(this.APELLIDOSTextBox);
            this.panel1.Controls.Add(this.NOMBRESTextBox);
            this.panel1.Controls.Add(this.APELLIDOSLabel);
            this.panel1.Controls.Add(this.CODIGOPOSTALTextBox);
            this.panel1.Controls.Add(this.TELEFONO1Label);
            this.panel1.Controls.Add(this.TELEFONO1TextBox);
            this.panel1.Controls.Add(this.TELEFONO2TextBox);
            this.panel1.Controls.Add(this.TELEFONO2Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 475);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnAbrirMapa
            // 
            this.btnAbrirMapa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAbrirMapa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAbrirMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirMapa.ForeColor = System.Drawing.Color.White;
            this.btnAbrirMapa.Location = new System.Drawing.Point(347, 271);
            this.btnAbrirMapa.Name = "btnAbrirMapa";
            this.btnAbrirMapa.Size = new System.Drawing.Size(160, 23);
            this.btnAbrirMapa.TabIndex = 288;
            this.btnAbrirMapa.Text = "Abrir mapa";
            this.btnAbrirMapa.UseVisualStyleBackColor = false;
            this.btnAbrirMapa.Click += new System.EventHandler(this.btnAbrirMapa_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(185, 258);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(60, 13);
            this.label38.TabIndex = 287;
            this.label38.Text = "Longitud:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(11, 258);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(50, 13);
            this.label39.TabIndex = 286;
            this.label39.Text = "Latitud:";
            // 
            // LONGITUDTextBox
            // 
            this.LONGITUDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LONGITUDTextBox.Location = new System.Drawing.Point(187, 274);
            this.LONGITUDTextBox.Name = "LONGITUDTextBox";
            this.LONGITUDTextBox.Size = new System.Drawing.Size(153, 20);
            this.LONGITUDTextBox.TabIndex = 285;
            // 
            // LATITUDTextBox
            // 
            this.LATITUDTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LATITUDTextBox.Location = new System.Drawing.Point(14, 274);
            this.LATITUDTextBox.Name = "LATITUDTextBox";
            this.LATITUDTextBox.Size = new System.Drawing.Size(167, 20);
            this.LATITUDTextBox.TabIndex = 284;
            // 
            // SAT_REGIMENFISCALIDButton
            // 
            this.SAT_REGIMENFISCALIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_REGIMENFISCALIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_REGIMENFISCALIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_REGIMENFISCALIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_REGIMENFISCALIDButton.Location = new System.Drawing.Point(542, 314);
            this.SAT_REGIMENFISCALIDButton.Name = "SAT_REGIMENFISCALIDButton";
            this.SAT_REGIMENFISCALIDButton.Size = new System.Drawing.Size(21, 23);
            this.SAT_REGIMENFISCALIDButton.TabIndex = 26;
            this.SAT_REGIMENFISCALIDButton.UseVisualStyleBackColor = true;
            // 
            // SAT_REGIMENFISCALIDLabel
            // 
            this.SAT_REGIMENFISCALIDLabel.AutoSize = true;
            this.SAT_REGIMENFISCALIDLabel.Location = new System.Drawing.Point(568, 321);
            this.SAT_REGIMENFISCALIDLabel.Name = "SAT_REGIMENFISCALIDLabel";
            this.SAT_REGIMENFISCALIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SAT_REGIMENFISCALIDLabel.TabIndex = 283;
            this.SAT_REGIMENFISCALIDLabel.Text = "...";
            // 
            // pSAT_REGIMENFISCALIDLabel
            // 
            this.pSAT_REGIMENFISCALIDLabel.AutoSize = true;
            this.pSAT_REGIMENFISCALIDLabel.Location = new System.Drawing.Point(464, 299);
            this.pSAT_REGIMENFISCALIDLabel.Name = "pSAT_REGIMENFISCALIDLabel";
            this.pSAT_REGIMENFISCALIDLabel.Size = new System.Drawing.Size(60, 13);
            this.pSAT_REGIMENFISCALIDLabel.TabIndex = 280;
            this.pSAT_REGIMENFISCALIDLabel.Text = "Regimen:";
            // 
            // SAT_REGIMENFISCALIDTextBox
            // 
            this.SAT_REGIMENFISCALIDTextBox.BotonLookUp = this.SAT_REGIMENFISCALIDButton;
            this.SAT_REGIMENFISCALIDTextBox.Condicion = null;
            this.SAT_REGIMENFISCALIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_REGIMENFISCALIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_REGIMENFISCALIDTextBox.DbValue = null;
            this.SAT_REGIMENFISCALIDTextBox.Format_Expression = null;
            this.SAT_REGIMENFISCALIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_REGIMENFISCALIDTextBox.IndiceCampoSelector = 1;
            this.SAT_REGIMENFISCALIDTextBox.IndiceCampoValue = 0;
            this.SAT_REGIMENFISCALIDTextBox.LabelDescription = this.SAT_REGIMENFISCALIDLabel;
            this.SAT_REGIMENFISCALIDTextBox.Location = new System.Drawing.Point(468, 315);
            this.SAT_REGIMENFISCALIDTextBox.MostrarErrores = true;
            this.SAT_REGIMENFISCALIDTextBox.Name = "SAT_REGIMENFISCALIDTextBox";
            this.SAT_REGIMENFISCALIDTextBox.NombreCampoSelector = "sat_clave";
            this.SAT_REGIMENFISCALIDTextBox.NombreCampoValue = "id";
            this.SAT_REGIMENFISCALIDTextBox.Query = "select p.id,p.sat_clave,p.sat_descripcion from sat_regimenfiscal p ";
            this.SAT_REGIMENFISCALIDTextBox.QueryDeSeleccion = "select  id,sat_clave, sat_descripcion from sat_regimenfiscal where  sat_clave = @" +
    "sat_clave";
            this.SAT_REGIMENFISCALIDTextBox.QueryPorDBValue = "select  id,sat_clave, sat_descripcion from sat_regimenfiscal where  id = @id";
            this.SAT_REGIMENFISCALIDTextBox.Size = new System.Drawing.Size(72, 20);
            this.SAT_REGIMENFISCALIDTextBox.TabIndex = 25;
            this.SAT_REGIMENFISCALIDTextBox.Tag = 34;
            this.SAT_REGIMENFISCALIDTextBox.TextDescription = null;
            this.SAT_REGIMENFISCALIDTextBox.Titulo = "Regimen fiscal";
            this.SAT_REGIMENFISCALIDTextBox.ValidarEntrada = true;
            this.SAT_REGIMENFISCALIDTextBox.ValidationExpression = null;
            // 
            // SAT_COLONIAIDButton
            // 
            this.SAT_COLONIAIDButton.BackColor = System.Drawing.Color.Transparent;
            this.SAT_COLONIAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_COLONIAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_COLONIAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_COLONIAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_COLONIAIDButton.Location = new System.Drawing.Point(316, 188);
            this.SAT_COLONIAIDButton.Name = "SAT_COLONIAIDButton";
            this.SAT_COLONIAIDButton.Size = new System.Drawing.Size(23, 23);
            this.SAT_COLONIAIDButton.TabIndex = 15;
            this.SAT_COLONIAIDButton.UseVisualStyleBackColor = false;
            // 
            // SAT_COLONIAIDLabel
            // 
            this.SAT_COLONIAIDLabel.AutoSize = true;
            this.SAT_COLONIAIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.SAT_COLONIAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_COLONIAIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SAT_COLONIAIDLabel.Location = new System.Drawing.Point(338, 197);
            this.SAT_COLONIAIDLabel.Name = "SAT_COLONIAIDLabel";
            this.SAT_COLONIAIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SAT_COLONIAIDLabel.TabIndex = 279;
            this.SAT_COLONIAIDLabel.Text = "...";
            // 
            // SAT_COLONIAIDTextBox
            // 
            this.SAT_COLONIAIDTextBox.BotonLookUp = this.SAT_COLONIAIDButton;
            this.SAT_COLONIAIDTextBox.Condicion = null;
            this.SAT_COLONIAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_COLONIAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_COLONIAIDTextBox.DbValue = null;
            this.SAT_COLONIAIDTextBox.Format_Expression = null;
            this.SAT_COLONIAIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_COLONIAIDTextBox.IndiceCampoSelector = 1;
            this.SAT_COLONIAIDTextBox.IndiceCampoValue = 0;
            this.SAT_COLONIAIDTextBox.LabelDescription = this.SAT_COLONIAIDLabel;
            this.SAT_COLONIAIDTextBox.Location = new System.Drawing.Point(269, 190);
            this.SAT_COLONIAIDTextBox.MostrarErrores = true;
            this.SAT_COLONIAIDTextBox.Name = "SAT_COLONIAIDTextBox";
            this.SAT_COLONIAIDTextBox.NombreCampoSelector = "clave";
            this.SAT_COLONIAIDTextBox.NombreCampoValue = "id";
            this.SAT_COLONIAIDTextBox.Query = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C WHERE c.codigopostal = @CODIGOPOSTAL ORDER BY C.nombre";
            this.SAT_COLONIAIDTextBox.QueryDeSeleccion = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C WHERE c.codigopostal = @CODIGOPOSTAL  and c.COLONIA = @clave";
            this.SAT_COLONIAIDTextBox.QueryPorDBValue = "SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_" +
    "colonia C  WHERE c.ID = @id";
            this.SAT_COLONIAIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.SAT_COLONIAIDTextBox.TabIndex = 15;
            this.SAT_COLONIAIDTextBox.Tag = "36";
            this.SAT_COLONIAIDTextBox.TextDescription = null;
            this.SAT_COLONIAIDTextBox.Titulo = "Colonia";
            this.SAT_COLONIAIDTextBox.ValidarEntrada = true;
            this.SAT_COLONIAIDTextBox.ValidationExpression = null;
            // 
            // SAT_MUNICIPIOIDButton
            // 
            this.SAT_MUNICIPIOIDButton.BackColor = System.Drawing.Color.Transparent;
            this.SAT_MUNICIPIOIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_MUNICIPIOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_MUNICIPIOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_MUNICIPIOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_MUNICIPIOIDButton.Location = new System.Drawing.Point(61, 188);
            this.SAT_MUNICIPIOIDButton.Name = "SAT_MUNICIPIOIDButton";
            this.SAT_MUNICIPIOIDButton.Size = new System.Drawing.Size(23, 23);
            this.SAT_MUNICIPIOIDButton.TabIndex = 14;
            this.SAT_MUNICIPIOIDButton.UseVisualStyleBackColor = false;
            // 
            // SAT_MUNICIPIOIDLabel
            // 
            this.SAT_MUNICIPIOIDLabel.AutoSize = true;
            this.SAT_MUNICIPIOIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.SAT_MUNICIPIOIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_MUNICIPIOIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SAT_MUNICIPIOIDLabel.Location = new System.Drawing.Point(83, 197);
            this.SAT_MUNICIPIOIDLabel.Name = "SAT_MUNICIPIOIDLabel";
            this.SAT_MUNICIPIOIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SAT_MUNICIPIOIDLabel.TabIndex = 276;
            this.SAT_MUNICIPIOIDLabel.Text = "...";
            // 
            // SAT_MUNICIPIOIDTextBox
            // 
            this.SAT_MUNICIPIOIDTextBox.BotonLookUp = this.SAT_MUNICIPIOIDButton;
            this.SAT_MUNICIPIOIDTextBox.Condicion = null;
            this.SAT_MUNICIPIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_MUNICIPIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_MUNICIPIOIDTextBox.DbValue = null;
            this.SAT_MUNICIPIOIDTextBox.Format_Expression = null;
            this.SAT_MUNICIPIOIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_MUNICIPIOIDTextBox.IndiceCampoSelector = 1;
            this.SAT_MUNICIPIOIDTextBox.IndiceCampoValue = 0;
            this.SAT_MUNICIPIOIDTextBox.LabelDescription = this.SAT_MUNICIPIOIDLabel;
            this.SAT_MUNICIPIOIDTextBox.Location = new System.Drawing.Point(14, 190);
            this.SAT_MUNICIPIOIDTextBox.MostrarErrores = true;
            this.SAT_MUNICIPIOIDTextBox.Name = "SAT_MUNICIPIOIDTextBox";
            this.SAT_MUNICIPIOIDTextBox.NombreCampoSelector = "clave";
            this.SAT_MUNICIPIOIDTextBox.NombreCampoValue = "id";
            this.SAT_MUNICIPIOIDTextBox.Query = resources.GetString("SAT_MUNICIPIOIDTextBox.Query");
            this.SAT_MUNICIPIOIDTextBox.QueryDeSeleccion = resources.GetString("SAT_MUNICIPIOIDTextBox.QueryDeSeleccion");
            this.SAT_MUNICIPIOIDTextBox.QueryPorDBValue = "SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIP" +
    "CION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON MUN.clave_estado = E" +
    "STADO.acronimo WHERE  MUN.ID = @id";
            this.SAT_MUNICIPIOIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.SAT_MUNICIPIOIDTextBox.TabIndex = 14;
            this.SAT_MUNICIPIOIDTextBox.Tag = "36";
            this.SAT_MUNICIPIOIDTextBox.TextDescription = null;
            this.SAT_MUNICIPIOIDTextBox.Titulo = "Municipio";
            this.SAT_MUNICIPIOIDTextBox.ValidarEntrada = true;
            this.SAT_MUNICIPIOIDTextBox.ValidationExpression = null;
            // 
            // SAT_LOCALIDADIDButton
            // 
            this.SAT_LOCALIDADIDButton.BackColor = System.Drawing.Color.Transparent;
            this.SAT_LOCALIDADIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SAT_LOCALIDADIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAT_LOCALIDADIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAT_LOCALIDADIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SAT_LOCALIDADIDButton.Location = new System.Drawing.Point(569, 146);
            this.SAT_LOCALIDADIDButton.Name = "SAT_LOCALIDADIDButton";
            this.SAT_LOCALIDADIDButton.Size = new System.Drawing.Size(23, 23);
            this.SAT_LOCALIDADIDButton.TabIndex = 13;
            this.SAT_LOCALIDADIDButton.UseVisualStyleBackColor = false;
            // 
            // SAT_LOCALIDADIDLabel
            // 
            this.SAT_LOCALIDADIDLabel.AutoSize = true;
            this.SAT_LOCALIDADIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.SAT_LOCALIDADIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAT_LOCALIDADIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SAT_LOCALIDADIDLabel.Location = new System.Drawing.Point(591, 155);
            this.SAT_LOCALIDADIDLabel.Name = "SAT_LOCALIDADIDLabel";
            this.SAT_LOCALIDADIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SAT_LOCALIDADIDLabel.TabIndex = 273;
            this.SAT_LOCALIDADIDLabel.Text = "...";
            // 
            // SAT_LOCALIDADIDTextBox
            // 
            this.SAT_LOCALIDADIDTextBox.BotonLookUp = this.SAT_LOCALIDADIDButton;
            this.SAT_LOCALIDADIDTextBox.Condicion = null;
            this.SAT_LOCALIDADIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_LOCALIDADIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_LOCALIDADIDTextBox.DbValue = null;
            this.SAT_LOCALIDADIDTextBox.Format_Expression = null;
            this.SAT_LOCALIDADIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_LOCALIDADIDTextBox.IndiceCampoSelector = 1;
            this.SAT_LOCALIDADIDTextBox.IndiceCampoValue = 0;
            this.SAT_LOCALIDADIDTextBox.LabelDescription = this.SAT_LOCALIDADIDLabel;
            this.SAT_LOCALIDADIDTextBox.Location = new System.Drawing.Point(522, 148);
            this.SAT_LOCALIDADIDTextBox.MostrarErrores = true;
            this.SAT_LOCALIDADIDTextBox.Name = "SAT_LOCALIDADIDTextBox";
            this.SAT_LOCALIDADIDTextBox.NombreCampoSelector = "clave";
            this.SAT_LOCALIDADIDTextBox.NombreCampoValue = "id";
            this.SAT_LOCALIDADIDTextBox.Query = resources.GetString("SAT_LOCALIDADIDTextBox.Query");
            this.SAT_LOCALIDADIDTextBox.QueryDeSeleccion = resources.GetString("SAT_LOCALIDADIDTextBox.QueryDeSeleccion");
            this.SAT_LOCALIDADIDTextBox.QueryPorDBValue = "SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIP" +
    "CION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON LOC.clave_estado = E" +
    "STADO.acronimo WHERE  LOC.ID = @id";
            this.SAT_LOCALIDADIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.SAT_LOCALIDADIDTextBox.TabIndex = 13;
            this.SAT_LOCALIDADIDTextBox.Tag = "36";
            this.SAT_LOCALIDADIDTextBox.TextDescription = null;
            this.SAT_LOCALIDADIDTextBox.Titulo = "Localidad";
            this.SAT_LOCALIDADIDTextBox.ValidarEntrada = true;
            this.SAT_LOCALIDADIDTextBox.ValidationExpression = null;
            // 
            // DISTANCIATextBox
            // 
            this.DISTANCIATextBox.AllowNegative = true;
            this.DISTANCIATextBox.Format_Expression = null;
            this.DISTANCIATextBox.Location = new System.Drawing.Point(520, 443);
            this.DISTANCIATextBox.Name = "DISTANCIATextBox";
            this.DISTANCIATextBox.NumericPrecision = 18;
            this.DISTANCIATextBox.NumericScaleOnFocus = 3;
            this.DISTANCIATextBox.NumericScaleOnLostFocus = 3;
            this.DISTANCIATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DISTANCIATextBox.Size = new System.Drawing.Size(85, 20);
            this.DISTANCIATextBox.TabIndex = 36;
            this.DISTANCIATextBox.Tag = "";
            this.DISTANCIATextBox.Text = "0.000";
            this.DISTANCIATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DISTANCIATextBox.ValidationExpression = null;
            this.DISTANCIATextBox.ZeroIsValid = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(450, 446);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 13);
            this.label33.TabIndex = 271;
            this.label33.Text = "Distancia:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.Location = new System.Drawing.Point(292, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 23);
            this.button2.TabIndex = 24;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SAT_USOCFDIIDTextBox
            // 
            this.SAT_USOCFDIIDTextBox.BotonLookUp = this.button2;
            this.SAT_USOCFDIIDTextBox.Condicion = null;
            this.SAT_USOCFDIIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_USOCFDIIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SAT_USOCFDIIDTextBox.DbValue = null;
            this.SAT_USOCFDIIDTextBox.Format_Expression = null;
            this.SAT_USOCFDIIDTextBox.IndiceCampoDescripcion = 2;
            this.SAT_USOCFDIIDTextBox.IndiceCampoSelector = 1;
            this.SAT_USOCFDIIDTextBox.IndiceCampoValue = 0;
            this.SAT_USOCFDIIDTextBox.LabelDescription = this.SAT_USOCFDIIDLabel;
            this.SAT_USOCFDIIDTextBox.Location = new System.Drawing.Point(217, 314);
            this.SAT_USOCFDIIDTextBox.MostrarErrores = true;
            this.SAT_USOCFDIIDTextBox.Name = "SAT_USOCFDIIDTextBox";
            this.SAT_USOCFDIIDTextBox.NombreCampoSelector = "clave";
            this.SAT_USOCFDIIDTextBox.NombreCampoValue = "id";
            this.SAT_USOCFDIIDTextBox.Query = "select sat_usocfdi.id , sat_usocfdi.sat_clave as clave, sat_usocfdi.sat_descripci" +
    "on as descripcion from   sat_usocfdi_oper inner join sat_usocfdi on sat_usocfdi." +
    "id = sat_usocfdi_oper.sat_usocfdiid";
            this.SAT_USOCFDIIDTextBox.QueryDeSeleccion = resources.GetString("SAT_USOCFDIIDTextBox.QueryDeSeleccion");
            this.SAT_USOCFDIIDTextBox.QueryPorDBValue = resources.GetString("SAT_USOCFDIIDTextBox.QueryPorDBValue");
            this.SAT_USOCFDIIDTextBox.Size = new System.Drawing.Size(70, 20);
            this.SAT_USOCFDIIDTextBox.TabIndex = 23;
            this.SAT_USOCFDIIDTextBox.Tag = 34;
            this.SAT_USOCFDIIDTextBox.TextDescription = null;
            this.SAT_USOCFDIIDTextBox.Titulo = "USO CFDI";
            this.SAT_USOCFDIIDTextBox.ValidarEntrada = true;
            this.SAT_USOCFDIIDTextBox.ValidationExpression = null;
            // 
            // SAT_USOCFDIIDLabel
            // 
            this.SAT_USOCFDIIDLabel.AutoEllipsis = true;
            this.SAT_USOCFDIIDLabel.AutoSize = true;
            this.SAT_USOCFDIIDLabel.Location = new System.Drawing.Point(319, 318);
            this.SAT_USOCFDIIDLabel.Name = "SAT_USOCFDIIDLabel";
            this.SAT_USOCFDIIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SAT_USOCFDIIDLabel.TabIndex = 267;
            this.SAT_USOCFDIIDLabel.Text = "...";
            // 
            // PAISComboBoxFb
            // 
            this.PAISComboBoxFb.Condicion = null;
            this.PAISComboBoxFb.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PAISComboBoxFb.DisplayMember = "sat_descripcion";
            this.PAISComboBoxFb.FormattingEnabled = true;
            this.PAISComboBoxFb.IndiceCampoSelector = 1;
            this.PAISComboBoxFb.LabelDescription = null;
            this.PAISComboBoxFb.Location = new System.Drawing.Point(13, 147);
            this.PAISComboBoxFb.Name = "PAISComboBoxFb";
            this.PAISComboBoxFb.NombreCampoSelector = "sat_clave";
            this.PAISComboBoxFb.Query = "select id, sat_clave, sat_descripcion from sat_pais";
            this.PAISComboBoxFb.QueryDeSeleccion = "select id, sat_clave, sat_descripcion from sat_pais where sat_clave = @sat_clave";
            this.PAISComboBoxFb.SelectedDataDisplaying = null;
            this.PAISComboBoxFb.SelectedDataValue = null;
            this.PAISComboBoxFb.Size = new System.Drawing.Size(187, 21);
            this.PAISComboBoxFb.TabIndex = 10;
            this.PAISComboBoxFb.ValueMember = "sat_clave";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(799, 455);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(102, 13);
            this.label26.TabIndex = 262;
            this.label26.Text = "Cuenta Contpaq:";
            // 
            // CIUDADLabel
            // 
            this.CIUDADLabel.AutoSize = true;
            this.CIUDADLabel.Location = new System.Drawing.Point(10, 175);
            this.CIUDADLabel.Name = "CIUDADLabel";
            this.CIUDADLabel.Size = new System.Drawing.Size(67, 13);
            this.CIUDADLabel.TabIndex = 1;
            this.CIUDADLabel.Text = "Ciudad (*):";
            // 
            // txtCuentaContpaq
            // 
            this.txtCuentaContpaq.Location = new System.Drawing.Point(903, 452);
            this.txtCuentaContpaq.Name = "txtCuentaContpaq";
            this.txtCuentaContpaq.Size = new System.Drawing.Size(140, 20);
            this.txtCuentaContpaq.TabIndex = 68;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(520, 131);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 13);
            this.label24.TabIndex = 255;
            this.label24.Text = "Localidad:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(683, 455);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 13);
            this.label27.TabIndex = 261;
            this.label27.Text = "Orden compra";
            // 
            // chkOrdenCompra
            // 
            this.chkOrdenCompra.AutoSize = true;
            this.chkOrdenCompra.Location = new System.Drawing.Point(780, 456);
            this.chkOrdenCompra.Name = "chkOrdenCompra";
            this.chkOrdenCompra.Size = new System.Drawing.Size(15, 14);
            this.chkOrdenCompra.TabIndex = 67;
            this.chkOrdenCompra.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(520, 219);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(140, 13);
            this.label25.TabIndex = 257;
            this.label25.Text = "Referencia domiciliaria:";
            // 
            // REFERENCIADOMTextBox
            // 
            this.REFERENCIADOMTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.REFERENCIADOMTextBox.Location = new System.Drawing.Point(520, 235);
            this.REFERENCIADOMTextBox.Name = "REFERENCIADOMTextBox";
            this.REFERENCIADOMTextBox.Size = new System.Drawing.Size(244, 20);
            this.REFERENCIADOMTextBox.TabIndex = 21;
            // 
            // ULTIMAVENTATextBox
            // 
            this.ULTIMAVENTATextBox.Enabled = false;
            this.ULTIMAVENTATextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ULTIMAVENTATextBox.Location = new System.Drawing.Point(903, 428);
            this.ULTIMAVENTATextBox.Name = "ULTIMAVENTATextBox";
            this.ULTIMAVENTATextBox.Size = new System.Drawing.Size(94, 20);
            this.ULTIMAVENTATextBox.TabIndex = 65;
            this.ULTIMAVENTATextBox.Value = new System.DateTime(2016, 7, 1, 16, 16, 6, 0);
            // 
            // SERVICIOADOMICILIOTextBox
            // 
            this.SERVICIOADOMICILIOTextBox.AutoSize = true;
            this.SERVICIOADOMICILIOTextBox.Location = new System.Drawing.Point(780, 439);
            this.SERVICIOADOMICILIOTextBox.Name = "SERVICIOADOMICILIOTextBox";
            this.SERVICIOADOMICILIOTextBox.Size = new System.Drawing.Size(15, 14);
            this.SERVICIOADOMICILIOTextBox.TabIndex = 66;
            this.SERVICIOADOMICILIOTextBox.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(653, 439);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(117, 13);
            this.label22.TabIndex = 184;
            this.label22.Text = "Servicio a domicilio";
            // 
            // pnlDesglosaIEPS
            // 
            this.pnlDesglosaIEPS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDesglosaIEPS.Controls.Add(this.label17);
            this.pnlDesglosaIEPS.Controls.Add(this.CUENTAIEPSTextBox);
            this.pnlDesglosaIEPS.Controls.Add(this.label16);
            this.pnlDesglosaIEPS.Controls.Add(this.DESGLOSEIEPSTextBox);
            this.pnlDesglosaIEPS.Location = new System.Drawing.Point(18, 431);
            this.pnlDesglosaIEPS.Name = "pnlDesglosaIEPS";
            this.pnlDesglosaIEPS.Size = new System.Drawing.Size(424, 38);
            this.pnlDesglosaIEPS.TabIndex = 183;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(129, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 167;
            this.label17.Text = "Cuenta IEPS:";
            // 
            // CUENTAIEPSTextBox
            // 
            this.CUENTAIEPSTextBox.Location = new System.Drawing.Point(218, 7);
            this.CUENTAIEPSTextBox.Name = "CUENTAIEPSTextBox";
            this.CUENTAIEPSTextBox.Size = new System.Drawing.Size(188, 20);
            this.CUENTAIEPSTextBox.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 13);
            this.label16.TabIndex = 166;
            this.label16.Text = "Desglosa IEPS";
            // 
            // DESGLOSEIEPSTextBox
            // 
            this.DESGLOSEIEPSTextBox.AutoSize = true;
            this.DESGLOSEIEPSTextBox.Location = new System.Drawing.Point(100, 9);
            this.DESGLOSEIEPSTextBox.Name = "DESGLOSEIEPSTextBox";
            this.DESGLOSEIEPSTextBox.Size = new System.Drawing.Size(15, 14);
            this.DESGLOSEIEPSTextBox.TabIndex = 34;
            this.DESGLOSEIEPSTextBox.UseVisualStyleBackColor = true;
            this.DESGLOSEIEPSTextBox.CheckedChanged += new System.EventHandler(this.DESGLOSEIEPSTextBox_CheckedChanged);
            // 
            // MONEDAButton
            // 
            this.MONEDAButton.AccessibleDescription = "";
            this.MONEDAButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.MONEDAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MONEDAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MONEDAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.MONEDAButton.Location = new System.Drawing.Point(608, 398);
            this.MONEDAButton.Name = "MONEDAButton";
            this.MONEDAButton.Size = new System.Drawing.Size(21, 23);
            this.MONEDAButton.TabIndex = 33;
            this.MONEDAButton.UseVisualStyleBackColor = true;
            // 
            // MONEDAIDTextBox
            // 
            this.MONEDAIDTextBox.AccessibleDescription = "";
            this.MONEDAIDTextBox.BotonLookUp = this.MONEDAButton;
            this.MONEDAIDTextBox.Condicion = null;
            this.MONEDAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MONEDAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MONEDAIDTextBox.DbValue = null;
            this.MONEDAIDTextBox.Format_Expression = null;
            this.MONEDAIDTextBox.IndiceCampoDescripcion = 2;
            this.MONEDAIDTextBox.IndiceCampoSelector = 1;
            this.MONEDAIDTextBox.IndiceCampoValue = 0;
            this.MONEDAIDTextBox.LabelDescription = this.MONEDALabel;
            this.MONEDAIDTextBox.Location = new System.Drawing.Point(520, 399);
            this.MONEDAIDTextBox.MostrarErrores = true;
            this.MONEDAIDTextBox.Name = "MONEDAIDTextBox";
            this.MONEDAIDTextBox.NombreCampoSelector = "clave";
            this.MONEDAIDTextBox.NombreCampoValue = "id";
            this.MONEDAIDTextBox.Query = "select id,clave,nombre from moneda";
            this.MONEDAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from moneda where clave = @clave";
            this.MONEDAIDTextBox.QueryPorDBValue = "select id,clave,nombre from moneda where id = @id";
            this.MONEDAIDTextBox.Size = new System.Drawing.Size(85, 20);
            this.MONEDAIDTextBox.TabIndex = 32;
            this.MONEDAIDTextBox.Tag = 34;
            this.MONEDAIDTextBox.TextDescription = null;
            this.MONEDAIDTextBox.Titulo = "Monedas";
            this.MONEDAIDTextBox.ValidarEntrada = true;
            this.MONEDAIDTextBox.ValidationExpression = null;
            // 
            // MONEDALabel
            // 
            this.MONEDALabel.AccessibleDescription = "";
            this.MONEDALabel.AutoSize = true;
            this.MONEDALabel.Location = new System.Drawing.Point(634, 406);
            this.MONEDALabel.Name = "MONEDALabel";
            this.MONEDALabel.Size = new System.Drawing.Size(19, 13);
            this.MONEDALabel.TabIndex = 182;
            this.MONEDALabel.Text = "...";
            // 
            // mONEDAIDLabel
            // 
            this.mONEDAIDLabel.AccessibleDescription = "";
            this.mONEDAIDLabel.AutoSize = true;
            this.mONEDAIDLabel.Location = new System.Drawing.Point(520, 384);
            this.mONEDAIDLabel.Name = "mONEDAIDLabel";
            this.mONEDAIDLabel.Size = new System.Drawing.Size(61, 13);
            this.mONEDAIDLabel.TabIndex = 181;
            this.mONEDAIDLabel.Text = "Moneda*:";
            // 
            // panel3
            // 
            this.panel3.AccessibleDescription = "";
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.PAGOTARJMENORPRECIOLISTATextBox);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.CARGOXVENTACONTARJETATextBox);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Controls.Add(this.GENERARRECIBOELECTRONICOTextBox);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.PAGOPARCIALIDADESTextBox);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.CREDITOREFERENCIAABONOSTextBox);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.CREDITOFORMAPAGOABONOSTextBox);
            this.panel3.Controls.Add(this.lblReferencia);
            this.panel3.Controls.Add(this.LblFormaPago);
            this.panel3.Location = new System.Drawing.Point(773, 269);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 120);
            this.panel3.TabIndex = 178;
            // 
            // PAGOTARJMENORPRECIOLISTATextBox
            // 
            this.PAGOTARJMENORPRECIOLISTATextBox.AutoSize = true;
            this.PAGOTARJMENORPRECIOLISTATextBox.Location = new System.Drawing.Point(248, 97);
            this.PAGOTARJMENORPRECIOLISTATextBox.Name = "PAGOTARJMENORPRECIOLISTATextBox";
            this.PAGOTARJMENORPRECIOLISTATextBox.Size = new System.Drawing.Size(15, 14);
            this.PAGOTARJMENORPRECIOLISTATextBox.TabIndex = 64;
            this.PAGOTARJMENORPRECIOLISTATextBox.UseVisualStyleBackColor = true;
            this.PAGOTARJMENORPRECIOLISTATextBox.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(132, 97);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(118, 13);
            this.label30.TabIndex = 269;
            this.label30.Text = "C/tarj. < prec. lista:";
            this.label30.Visible = false;
            // 
            // CARGOXVENTACONTARJETATextBox
            // 
            this.CARGOXVENTACONTARJETATextBox.AutoSize = true;
            this.CARGOXVENTACONTARJETATextBox.Location = new System.Drawing.Point(248, 74);
            this.CARGOXVENTACONTARJETATextBox.Name = "CARGOXVENTACONTARJETATextBox";
            this.CARGOXVENTACONTARJETATextBox.Size = new System.Drawing.Size(15, 14);
            this.CARGOXVENTACONTARJETATextBox.TabIndex = 62;
            this.CARGOXVENTACONTARJETATextBox.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(121, 74);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(129, 13);
            this.label29.TabIndex = 267;
            this.label29.Text = "Cargo x venta c/tarj.:";
            // 
            // GENERARRECIBOELECTRONICOTextBox
            // 
            this.GENERARRECIBOELECTRONICOTextBox.AutoSize = true;
            this.GENERARRECIBOELECTRONICOTextBox.Location = new System.Drawing.Point(101, 97);
            this.GENERARRECIBOELECTRONICOTextBox.Name = "GENERARRECIBOELECTRONICOTextBox";
            this.GENERARRECIBOELECTRONICOTextBox.Size = new System.Drawing.Size(15, 14);
            this.GENERARRECIBOELECTRONICOTextBox.TabIndex = 63;
            this.GENERARRECIBOELECTRONICOTextBox.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 97);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 13);
            this.label23.TabIndex = 172;
            this.label23.Text = "Recibo elect.:";
            // 
            // PAGOPARCIALIDADESTextBox
            // 
            this.PAGOPARCIALIDADESTextBox.AutoSize = true;
            this.PAGOPARCIALIDADESTextBox.Location = new System.Drawing.Point(101, 73);
            this.PAGOPARCIALIDADESTextBox.Name = "PAGOPARCIALIDADESTextBox";
            this.PAGOPARCIALIDADESTextBox.Size = new System.Drawing.Size(15, 14);
            this.PAGOPARCIALIDADESTextBox.TabIndex = 61;
            this.PAGOPARCIALIDADESTextBox.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(113, -2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 169;
            this.label15.Text = "Abonos";
            // 
            // CREDITOREFERENCIAABONOSTextBox
            // 
            this.CREDITOREFERENCIAABONOSTextBox.Location = new System.Drawing.Point(101, 43);
            this.CREDITOREFERENCIAABONOSTextBox.Name = "CREDITOREFERENCIAABONOSTextBox";
            this.CREDITOREFERENCIAABONOSTextBox.Size = new System.Drawing.Size(136, 20);
            this.CREDITOREFERENCIAABONOSTextBox.TabIndex = 60;
            this.CREDITOREFERENCIAABONOSTextBox.Enter += new System.EventHandler(this.CREDITOREFERENCIAABONOSTextBox_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 13);
            this.label21.TabIndex = 170;
            this.label21.Text = "Parcialidades:";
            // 
            // CREDITOFORMAPAGOABONOSTextBox
            // 
            this.CREDITOFORMAPAGOABONOSTextBox.FormattingEnabled = true;
            this.CREDITOFORMAPAGOABONOSTextBox.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de credito",
            "Tarjeta de debito",
            "Tarjeta de servicio",
            "Cheque nominativo",
            "Vales de despensa",
            "Transferencia electronica de fondos",
            "Otros"});
            this.CREDITOFORMAPAGOABONOSTextBox.Location = new System.Drawing.Point(101, 14);
            this.CREDITOFORMAPAGOABONOSTextBox.Name = "CREDITOFORMAPAGOABONOSTextBox";
            this.CREDITOFORMAPAGOABONOSTextBox.Size = new System.Drawing.Size(136, 21);
            this.CREDITOFORMAPAGOABONOSTextBox.TabIndex = 59;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(5, 46);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(73, 13);
            this.lblReferencia.TabIndex = 166;
            this.lblReferencia.Text = "Referencia:";
            // 
            // LblFormaPago
            // 
            this.LblFormaPago.AutoSize = true;
            this.LblFormaPago.Location = new System.Drawing.Point(4, 20);
            this.LblFormaPago.Name = "LblFormaPago";
            this.LblFormaPago.Size = new System.Drawing.Size(95, 13);
            this.LblFormaPago.TabIndex = 165;
            this.LblFormaPago.Text = "Forma de pago:";
            // 
            // ESTADOTextBox
            // 
            this.ESTADOTextBox.Condicion = null;
            this.ESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ESTADOTextBox.DisplayMember = "nombre";
            this.ESTADOTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ESTADOTextBox.FormattingEnabled = true;
            this.ESTADOTextBox.IndiceCampoSelector = 0;
            this.ESTADOTextBox.LabelDescription = null;
            this.ESTADOTextBox.Location = new System.Drawing.Point(212, 147);
            this.ESTADOTextBox.Name = "ESTADOTextBox";
            this.ESTADOTextBox.NombreCampoSelector = "acronimo";
            this.ESTADOTextBox.Query = "select acronimo,nombre from estado";
            this.ESTADOTextBox.QueryDeSeleccion = "select acronimo,nombre from estado where  id = @id";
            this.ESTADOTextBox.SelectedDataDisplaying = null;
            this.ESTADOTextBox.SelectedDataValue = null;
            this.ESTADOTextBox.Size = new System.Drawing.Size(199, 21);
            this.ESTADOTextBox.TabIndex = 11;
            this.ESTADOTextBox.ValueMember = "acronimo";
            this.ESTADOTextBox.SelectedIndexChanged += new System.EventHandler(this.ESTADOTextBox_SelectedIndexChanged);
            // 
            // Pcredito
            // 
            this.Pcredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pcredito.Controls.Add(this.POR_COMETextBox);
            this.Pcredito.Controls.Add(this.label14);
            this.Pcredito.Controls.Add(this.DIAS_EXTRTextBox);
            this.Pcredito.Controls.Add(this.label13);
            this.Pcredito.Controls.Add(this.cbSepararProdXPlazo);
            this.Pcredito.Controls.Add(this.label28);
            this.Pcredito.Controls.Add(this.HAB_PAGOEFECTIVOTextBox);
            this.Pcredito.Controls.Add(this.SUPERLISTAPRECIOIDTextBox);
            this.Pcredito.Controls.Add(this.SUPERLISTAPRECIOIDLabel);
            this.Pcredito.Controls.Add(this.HAB_PAGOTRANSFERENCIATextBox);
            this.Pcredito.Controls.Add(this.PAGOSTextBox);
            this.Pcredito.Controls.Add(this.REVISIONTextBox);
            this.Pcredito.Controls.Add(this.BLOQUEADOTextBox);
            this.Pcredito.Controls.Add(this.DIASTextBox);
            this.Pcredito.Controls.Add(this.LIMITECREDITOTextBox);
            this.Pcredito.Controls.Add(this.label4);
            this.Pcredito.Controls.Add(this.ldias);
            this.Pcredito.Controls.Add(this.llimite);
            this.Pcredito.Controls.Add(this.HAB_PAGOCHEQUETextBox);
            this.Pcredito.Controls.Add(this.label1);
            this.Pcredito.Controls.Add(this.HAB_PAGOCREDITOTextBox);
            this.Pcredito.Controls.Add(this.lpagos);
            this.Pcredito.Controls.Add(this.HAB_PAGOTARJETATextBox);
            this.Pcredito.Controls.Add(this.lrevisio);
            this.Pcredito.Controls.Add(this.LISTAPRECIOIDTextBox);
            this.Pcredito.Controls.Add(this.LISTAPRECIOIDLabel);
            this.Pcredito.Location = new System.Drawing.Point(776, 51);
            this.Pcredito.Name = "Pcredito";
            this.Pcredito.Size = new System.Drawing.Size(298, 215);
            this.Pcredito.TabIndex = 177;
            // 
            // POR_COMETextBox
            // 
            this.POR_COMETextBox.AllowNegative = true;
            this.POR_COMETextBox.Format_Expression = null;
            this.POR_COMETextBox.Location = new System.Drawing.Point(245, 116);
            this.POR_COMETextBox.Name = "POR_COMETextBox";
            this.POR_COMETextBox.NumericPrecision = 18;
            this.POR_COMETextBox.NumericScaleOnFocus = 2;
            this.POR_COMETextBox.NumericScaleOnLostFocus = 2;
            this.POR_COMETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.POR_COMETextBox.Size = new System.Drawing.Size(46, 20);
            this.POR_COMETextBox.TabIndex = 53;
            this.POR_COMETextBox.Tag = "";
            this.POR_COMETextBox.Text = "0.00";
            this.POR_COMETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.POR_COMETextBox.ValidationExpression = null;
            this.POR_COMETextBox.ZeroIsValid = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 269;
            this.label14.Text = "% Com. E.";
            // 
            // DIAS_EXTRTextBox
            // 
            this.DIAS_EXTRTextBox.AllowNegative = true;
            this.DIAS_EXTRTextBox.Format_Expression = null;
            this.DIAS_EXTRTextBox.Location = new System.Drawing.Point(211, 88);
            this.DIAS_EXTRTextBox.Name = "DIAS_EXTRTextBox";
            this.DIAS_EXTRTextBox.NumericPrecision = 18;
            this.DIAS_EXTRTextBox.NumericScaleOnFocus = 0;
            this.DIAS_EXTRTextBox.NumericScaleOnLostFocus = 0;
            this.DIAS_EXTRTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DIAS_EXTRTextBox.Size = new System.Drawing.Size(80, 20);
            this.DIAS_EXTRTextBox.TabIndex = 51;
            this.DIAS_EXTRTextBox.Tag = "";
            this.DIAS_EXTRTextBox.Text = "0";
            this.DIAS_EXTRTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DIAS_EXTRTextBox.ValidationExpression = null;
            this.DIAS_EXTRTextBox.ZeroIsValid = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 267;
            this.label13.Text = "Ext:";
            // 
            // cbSepararProdXPlazo
            // 
            this.cbSepararProdXPlazo.AutoSize = true;
            this.cbSepararProdXPlazo.Location = new System.Drawing.Point(227, 190);
            this.cbSepararProdXPlazo.Name = "cbSepararProdXPlazo";
            this.cbSepararProdXPlazo.Size = new System.Drawing.Size(15, 14);
            this.cbSepararProdXPlazo.TabIndex = 58;
            this.cbSepararProdXPlazo.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(104, 190);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(130, 13);
            this.label28.TabIndex = 265;
            this.label28.Text = "Separar Prod.x Plazo:";
            // 
            // HAB_PAGOEFECTIVOTextBox
            // 
            this.HAB_PAGOEFECTIVOTextBox.AutoSize = true;
            this.HAB_PAGOEFECTIVOTextBox.Checked = true;
            this.HAB_PAGOEFECTIVOTextBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HAB_PAGOEFECTIVOTextBox.Location = new System.Drawing.Point(113, 38);
            this.HAB_PAGOEFECTIVOTextBox.Name = "HAB_PAGOEFECTIVOTextBox";
            this.HAB_PAGOEFECTIVOTextBox.Size = new System.Drawing.Size(73, 17);
            this.HAB_PAGOEFECTIVOTextBox.TabIndex = 48;
            this.HAB_PAGOEFECTIVOTextBox.Text = "Efectivo";
            this.HAB_PAGOEFECTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // SUPERLISTAPRECIOIDTextBox
            // 
            this.SUPERLISTAPRECIOIDTextBox.FormattingEnabled = true;
            this.SUPERLISTAPRECIOIDTextBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.SUPERLISTAPRECIOIDTextBox.Location = new System.Drawing.Point(198, 161);
            this.SUPERLISTAPRECIOIDTextBox.Name = "SUPERLISTAPRECIOIDTextBox";
            this.SUPERLISTAPRECIOIDTextBox.Size = new System.Drawing.Size(58, 21);
            this.SUPERLISTAPRECIOIDTextBox.TabIndex = 56;
            // 
            // SUPERLISTAPRECIOIDLabel
            // 
            this.SUPERLISTAPRECIOIDLabel.AutoSize = true;
            this.SUPERLISTAPRECIOIDLabel.Location = new System.Drawing.Point(129, 167);
            this.SUPERLISTAPRECIOIDLabel.Name = "SUPERLISTAPRECIOIDLabel";
            this.SUPERLISTAPRECIOIDLabel.Size = new System.Drawing.Size(63, 13);
            this.SUPERLISTAPRECIOIDLabel.TabIndex = 165;
            this.SUPERLISTAPRECIOIDLabel.Text = "S. Precio:";
            // 
            // HAB_PAGOTRANSFERENCIATextBox
            // 
            this.HAB_PAGOTRANSFERENCIATextBox.AutoSize = true;
            this.HAB_PAGOTRANSFERENCIATextBox.Location = new System.Drawing.Point(3, 38);
            this.HAB_PAGOTRANSFERENCIATextBox.Name = "HAB_PAGOTRANSFERENCIATextBox";
            this.HAB_PAGOTRANSFERENCIATextBox.Size = new System.Drawing.Size(104, 17);
            this.HAB_PAGOTRANSFERENCIATextBox.TabIndex = 47;
            this.HAB_PAGOTRANSFERENCIATextBox.Text = "Transferencia";
            this.HAB_PAGOTRANSFERENCIATextBox.UseVisualStyleBackColor = true;
            // 
            // PAGOSTextBox
            // 
            this.PAGOSTextBox.FormattingEnabled = true;
            this.PAGOSTextBox.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.PAGOSTextBox.Location = new System.Drawing.Point(72, 137);
            this.PAGOSTextBox.Name = "PAGOSTextBox";
            this.PAGOSTextBox.Size = new System.Drawing.Size(100, 21);
            this.PAGOSTextBox.TabIndex = 54;
            // 
            // REVISIONTextBox
            // 
            this.REVISIONTextBox.FormattingEnabled = true;
            this.REVISIONTextBox.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.REVISIONTextBox.Location = new System.Drawing.Point(72, 113);
            this.REVISIONTextBox.Name = "REVISIONTextBox";
            this.REVISIONTextBox.Size = new System.Drawing.Size(100, 21);
            this.REVISIONTextBox.TabIndex = 52;
            // 
            // BLOQUEADOTextBox
            // 
            this.BLOQUEADOTextBox.AutoSize = true;
            this.BLOQUEADOTextBox.Location = new System.Drawing.Point(72, 190);
            this.BLOQUEADOTextBox.Name = "BLOQUEADOTextBox";
            this.BLOQUEADOTextBox.Size = new System.Drawing.Size(15, 14);
            this.BLOQUEADOTextBox.TabIndex = 57;
            this.BLOQUEADOTextBox.UseVisualStyleBackColor = true;
            // 
            // DIASTextBox
            // 
            this.DIASTextBox.AllowNegative = true;
            this.DIASTextBox.Format_Expression = null;
            this.DIASTextBox.Location = new System.Drawing.Point(72, 88);
            this.DIASTextBox.Name = "DIASTextBox";
            this.DIASTextBox.NumericPrecision = 18;
            this.DIASTextBox.NumericScaleOnFocus = 0;
            this.DIASTextBox.NumericScaleOnLostFocus = 0;
            this.DIASTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DIASTextBox.Size = new System.Drawing.Size(100, 20);
            this.DIASTextBox.TabIndex = 50;
            this.DIASTextBox.Tag = "";
            this.DIASTextBox.Text = "0";
            this.DIASTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DIASTextBox.ValidationExpression = null;
            this.DIASTextBox.ZeroIsValid = true;
            // 
            // LIMITECREDITOTextBox
            // 
            this.LIMITECREDITOTextBox.AllowNegative = true;
            this.LIMITECREDITOTextBox.Format_Expression = null;
            this.LIMITECREDITOTextBox.Location = new System.Drawing.Point(72, 64);
            this.LIMITECREDITOTextBox.Name = "LIMITECREDITOTextBox";
            this.LIMITECREDITOTextBox.NumericPrecision = 18;
            this.LIMITECREDITOTextBox.NumericScaleOnFocus = 2;
            this.LIMITECREDITOTextBox.NumericScaleOnLostFocus = 2;
            this.LIMITECREDITOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LIMITECREDITOTextBox.Size = new System.Drawing.Size(100, 20);
            this.LIMITECREDITOTextBox.TabIndex = 49;
            this.LIMITECREDITOTextBox.Tag = "";
            this.LIMITECREDITOTextBox.Text = "0.00";
            this.LIMITECREDITOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LIMITECREDITOTextBox.ValidationExpression = null;
            this.LIMITECREDITOTextBox.ZeroIsValid = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Bloqueado";
            // 
            // ldias
            // 
            this.ldias.AutoSize = true;
            this.ldias.Location = new System.Drawing.Point(-2, 91);
            this.ldias.Name = "ldias";
            this.ldias.Size = new System.Drawing.Size(71, 13);
            this.ldias.TabIndex = 26;
            this.ldias.Text = "Dias Plazo:";
            // 
            // llimite
            // 
            this.llimite.AutoSize = true;
            this.llimite.Location = new System.Drawing.Point(23, 67);
            this.llimite.Name = "llimite";
            this.llimite.Size = new System.Drawing.Size(44, 13);
            this.llimite.TabIndex = 20;
            this.llimite.Text = "Limite:";
            // 
            // HAB_PAGOCHEQUETextBox
            // 
            this.HAB_PAGOCHEQUETextBox.AutoSize = true;
            this.HAB_PAGOCHEQUETextBox.Location = new System.Drawing.Point(148, 15);
            this.HAB_PAGOCHEQUETextBox.Name = "HAB_PAGOCHEQUETextBox";
            this.HAB_PAGOCHEQUETextBox.Size = new System.Drawing.Size(69, 17);
            this.HAB_PAGOCHEQUETextBox.TabIndex = 46;
            this.HAB_PAGOCHEQUETextBox.Text = "Cheque";
            this.HAB_PAGOCHEQUETextBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "Formas de Pago";
            // 
            // HAB_PAGOCREDITOTextBox
            // 
            this.HAB_PAGOCREDITOTextBox.AutoSize = true;
            this.HAB_PAGOCREDITOTextBox.Location = new System.Drawing.Point(72, 15);
            this.HAB_PAGOCREDITOTextBox.Name = "HAB_PAGOCREDITOTextBox";
            this.HAB_PAGOCREDITOTextBox.Size = new System.Drawing.Size(66, 17);
            this.HAB_PAGOCREDITOTextBox.TabIndex = 45;
            this.HAB_PAGOCREDITOTextBox.Text = "Credito";
            this.HAB_PAGOCREDITOTextBox.UseVisualStyleBackColor = true;
            // 
            // lpagos
            // 
            this.lpagos.AutoSize = true;
            this.lpagos.Location = new System.Drawing.Point(23, 140);
            this.lpagos.Name = "lpagos";
            this.lpagos.Size = new System.Drawing.Size(46, 13);
            this.lpagos.TabIndex = 19;
            this.lpagos.Text = "Pagos:";
            // 
            // HAB_PAGOTARJETATextBox
            // 
            this.HAB_PAGOTARJETATextBox.AutoSize = true;
            this.HAB_PAGOTARJETATextBox.Location = new System.Drawing.Point(3, 15);
            this.HAB_PAGOTARJETATextBox.Name = "HAB_PAGOTARJETATextBox";
            this.HAB_PAGOTARJETATextBox.Size = new System.Drawing.Size(66, 17);
            this.HAB_PAGOTARJETATextBox.TabIndex = 44;
            this.HAB_PAGOTARJETATextBox.Text = "Tarjeta";
            this.HAB_PAGOTARJETATextBox.UseVisualStyleBackColor = true;
            // 
            // lrevisio
            // 
            this.lrevisio.AutoSize = true;
            this.lrevisio.Location = new System.Drawing.Point(10, 116);
            this.lrevisio.Name = "lrevisio";
            this.lrevisio.Size = new System.Drawing.Size(60, 13);
            this.lrevisio.TabIndex = 18;
            this.lrevisio.Text = "Revision:";
            // 
            // LISTAPRECIOIDTextBox
            // 
            this.LISTAPRECIOIDTextBox.FormattingEnabled = true;
            this.LISTAPRECIOIDTextBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOIDTextBox.Location = new System.Drawing.Point(72, 161);
            this.LISTAPRECIOIDTextBox.Name = "LISTAPRECIOIDTextBox";
            this.LISTAPRECIOIDTextBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECIOIDTextBox.TabIndex = 55;
            // 
            // LISTAPRECIOIDLabel
            // 
            this.LISTAPRECIOIDLabel.AutoSize = true;
            this.LISTAPRECIOIDLabel.Location = new System.Drawing.Point(22, 167);
            this.LISTAPRECIOIDLabel.Name = "LISTAPRECIOIDLabel";
            this.LISTAPRECIOIDLabel.Size = new System.Drawing.Size(47, 13);
            this.LISTAPRECIOIDLabel.TabIndex = 1;
            this.LISTAPRECIOIDLabel.Text = "Precio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 176;
            this.label3.Text = "Num. Int. (*):";
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.AccessibleDescription = "";
            this.VENDEDORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.VENDEDORIDTextBox.Condicion = null;
            this.VENDEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbValue = null;
            this.VENDEDORIDTextBox.Format_Expression = null;
            this.VENDEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORIDTextBox.IndiceCampoSelector = 1;
            this.VENDEDORIDTextBox.IndiceCampoValue = 0;
            this.VENDEDORIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(857, 2);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 22";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave= @clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 22 and  id = @id";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(97, 20);
            this.VENDEDORIDTextBox.TabIndex = 40;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Vendedores";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.AccessibleDescription = "";
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(960, 2);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(24, 23);
            this.VENDEDORButton.TabIndex = 41;
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AccessibleDescription = "";
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.Location = new System.Drawing.Point(990, 8);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(19, 13);
            this.VENDEDORLabel.TabIndex = 157;
            this.VENDEDORLabel.Text = "...";
            this.VENDEDORLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 175;
            this.label2.Text = "Num. Ext. (*):";
            // 
            // VENDEDORIDLabel
            // 
            this.VENDEDORIDLabel.AccessibleDescription = "";
            this.VENDEDORIDLabel.AutoSize = true;
            this.VENDEDORIDLabel.Location = new System.Drawing.Point(773, 8);
            this.VENDEDORIDLabel.Name = "VENDEDORIDLabel";
            this.VENDEDORIDLabel.Size = new System.Drawing.Size(65, 13);
            this.VENDEDORIDLabel.TabIndex = 1;
            this.VENDEDORIDLabel.Text = "Vendedor:";
            // 
            // NUMEROINTERIORTextBox
            // 
            this.NUMEROINTERIORTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NUMEROINTERIORTextBox.Location = new System.Drawing.Point(435, 235);
            this.NUMEROINTERIORTextBox.Name = "NUMEROINTERIORTextBox";
            this.NUMEROINTERIORTextBox.Size = new System.Drawing.Size(73, 20);
            this.NUMEROINTERIORTextBox.TabIndex = 20;
            // 
            // NUMEROEXTERIORTextBox
            // 
            this.NUMEROEXTERIORTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NUMEROEXTERIORTextBox.Location = new System.Drawing.Point(346, 235);
            this.NUMEROEXTERIORTextBox.Name = "NUMEROEXTERIORTextBox";
            this.NUMEROEXTERIORTextBox.Size = new System.Drawing.Size(69, 20);
            this.NUMEROEXTERIORTextBox.TabIndex = 19;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AccessibleDescription = "";
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(319, 14);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(47, 31);
            this.ACTIVOTextBox.TabIndex = 3;
            this.ACTIVOTextBox.Text = "Activo";
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // DOMICILIOLabel
            // 
            this.DOMICILIOLabel.AutoSize = true;
            this.DOMICILIOLabel.Location = new System.Drawing.Point(14, 219);
            this.DOMICILIOLabel.Name = "DOMICILIOLabel";
            this.DOMICILIOLabel.Size = new System.Drawing.Size(79, 13);
            this.DOMICILIOLabel.TabIndex = 1;
            this.DOMICILIOLabel.Text = "Domicilio (*):";
            // 
            // DOMICILIOTextBox
            // 
            this.DOMICILIOTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DOMICILIOTextBox.Location = new System.Drawing.Point(13, 235);
            this.DOMICILIOTextBox.Name = "DOMICILIOTextBox";
            this.DOMICILIOTextBox.Size = new System.Drawing.Size(327, 20);
            this.DOMICILIOTextBox.TabIndex = 18;
            // 
            // CREADOPOR_USERIDLabel
            // 
            this.CREADOPOR_USERIDLabel.AccessibleDescription = "";
            this.CREADOPOR_USERIDLabel.AutoSize = true;
            this.CREADOPOR_USERIDLabel.Location = new System.Drawing.Point(545, 14);
            this.CREADOPOR_USERIDLabel.Name = "CREADOPOR_USERIDLabel";
            this.CREADOPOR_USERIDLabel.Size = new System.Drawing.Size(73, 13);
            this.CREADOPOR_USERIDLabel.TabIndex = 1;
            this.CREADOPOR_USERIDLabel.Text = "Creado por:";
            // 
            // TextBoxCREADOPOR_USERCLAVE
            // 
            this.TextBoxCREADOPOR_USERCLAVE.AccessibleDescription = "";
            this.TextBoxCREADOPOR_USERCLAVE.Enabled = false;
            this.TextBoxCREADOPOR_USERCLAVE.Location = new System.Drawing.Point(548, 30);
            this.TextBoxCREADOPOR_USERCLAVE.Name = "TextBoxCREADOPOR_USERCLAVE";
            this.TextBoxCREADOPOR_USERCLAVE.ReadOnly = true;
            this.TextBoxCREADOPOR_USERCLAVE.Size = new System.Drawing.Size(106, 20);
            this.TextBoxCREADOPOR_USERCLAVE.TabIndex = 5;
            this.TextBoxCREADOPOR_USERCLAVE.TabStop = false;
            // 
            // COLONIALabel
            // 
            this.COLONIALabel.AutoSize = true;
            this.COLONIALabel.Location = new System.Drawing.Point(268, 175);
            this.COLONIALabel.Name = "COLONIALabel";
            this.COLONIALabel.Size = new System.Drawing.Size(70, 13);
            this.COLONIALabel.TabIndex = 1;
            this.COLONIALabel.Text = "Colonia (*):";
            // 
            // MODIFICADOPOR_USERIDLabel
            // 
            this.MODIFICADOPOR_USERIDLabel.AccessibleDescription = "";
            this.MODIFICADOPOR_USERIDLabel.AutoSize = true;
            this.MODIFICADOPOR_USERIDLabel.Location = new System.Drawing.Point(663, 14);
            this.MODIFICADOPOR_USERIDLabel.Name = "MODIFICADOPOR_USERIDLabel";
            this.MODIFICADOPOR_USERIDLabel.Size = new System.Drawing.Size(95, 13);
            this.MODIFICADOPOR_USERIDLabel.TabIndex = 1;
            this.MODIFICADOPOR_USERIDLabel.Text = "Modificado por:";
            // 
            // MODIFICADOPOR_USERIDTextBox
            // 
            this.MODIFICADOPOR_USERIDTextBox.AccessibleDescription = "";
            this.MODIFICADOPOR_USERIDTextBox.Enabled = false;
            this.MODIFICADOPOR_USERIDTextBox.Location = new System.Drawing.Point(666, 30);
            this.MODIFICADOPOR_USERIDTextBox.Name = "MODIFICADOPOR_USERIDTextBox";
            this.MODIFICADOPOR_USERIDTextBox.ReadOnly = true;
            this.MODIFICADOPOR_USERIDTextBox.Size = new System.Drawing.Size(99, 20);
            this.MODIFICADOPOR_USERIDTextBox.TabIndex = 6;
            this.MODIFICADOPOR_USERIDTextBox.TabStop = false;
            // 
            // VIGENCIATextBox
            // 
            this.VIGENCIATextBox.AccessibleDescription = "";
            this.VIGENCIATextBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.VIGENCIATextBox.Location = new System.Drawing.Point(405, 29);
            this.VIGENCIATextBox.Name = "VIGENCIATextBox";
            this.VIGENCIATextBox.Size = new System.Drawing.Size(124, 20);
            this.VIGENCIATextBox.TabIndex = 4;
            // 
            // VIGENCIALabel
            // 
            this.VIGENCIALabel.AccessibleDescription = "";
            this.VIGENCIALabel.AutoSize = true;
            this.VIGENCIALabel.Location = new System.Drawing.Point(405, 14);
            this.VIGENCIALabel.Name = "VIGENCIALabel";
            this.VIGENCIALabel.Size = new System.Drawing.Size(60, 13);
            this.VIGENCIALabel.TabIndex = 1;
            this.VIGENCIALabel.Text = "Vigencia:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.Location = new System.Drawing.Point(14, 13);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // CONTACTO2TextBox
            // 
            this.CONTACTO2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CONTACTO2TextBox.Location = new System.Drawing.Point(590, 358);
            this.CONTACTO2TextBox.Name = "CONTACTO2TextBox";
            this.CONTACTO2TextBox.Size = new System.Drawing.Size(174, 20);
            this.CONTACTO2TextBox.TabIndex = 30;
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NOMBRETextBox.Location = new System.Drawing.Point(14, 29);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(293, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // CONTACTO2Label
            // 
            this.CONTACTO2Label.AutoSize = true;
            this.CONTACTO2Label.Location = new System.Drawing.Point(583, 342);
            this.CONTACTO2Label.Name = "CONTACTO2Label";
            this.CONTACTO2Label.Size = new System.Drawing.Size(73, 13);
            this.CONTACTO2Label.TabIndex = 1;
            this.CONTACTO2Label.Text = "Contacto 2:";
            // 
            // ESTADOLabel
            // 
            this.ESTADOLabel.AutoSize = true;
            this.ESTADOLabel.Location = new System.Drawing.Point(214, 132);
            this.ESTADOLabel.Name = "ESTADOLabel";
            this.ESTADOLabel.Size = new System.Drawing.Size(67, 13);
            this.ESTADOLabel.TabIndex = 1;
            this.ESTADOLabel.Text = "Estado (*):";
            // 
            // CONTACTO1TextBox
            // 
            this.CONTACTO1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CONTACTO1TextBox.Location = new System.Drawing.Point(428, 358);
            this.CONTACTO1TextBox.Name = "CONTACTO1TextBox";
            this.CONTACTO1TextBox.Size = new System.Drawing.Size(156, 20);
            this.CONTACTO1TextBox.TabIndex = 29;
            // 
            // CONTACTO1Label
            // 
            this.CONTACTO1Label.AutoSize = true;
            this.CONTACTO1Label.Location = new System.Drawing.Point(425, 342);
            this.CONTACTO1Label.Name = "CONTACTO1Label";
            this.CONTACTO1Label.Size = new System.Drawing.Size(73, 13);
            this.CONTACTO1Label.TabIndex = 1;
            this.CONTACTO1Label.Text = "Contacto 1:";
            // 
            // MEMOLabel
            // 
            this.MEMOLabel.AutoSize = true;
            this.MEMOLabel.Location = new System.Drawing.Point(14, 384);
            this.MEMOLabel.Name = "MEMOLabel";
            this.MEMOLabel.Size = new System.Drawing.Size(95, 13);
            this.MEMOLabel.TabIndex = 1;
            this.MEMOLabel.Text = "Observaciones:";
            // 
            // RFCTextBox
            // 
            this.RFCTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RFCTextBox.Location = new System.Drawing.Point(16, 316);
            this.RFCTextBox.Name = "RFCTextBox";
            this.RFCTextBox.Size = new System.Drawing.Size(184, 20);
            this.RFCTextBox.TabIndex = 22;
            // 
            // MEMOTextBox
            // 
            this.MEMOTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MEMOTextBox.Location = new System.Drawing.Point(14, 400);
            this.MEMOTextBox.Name = "MEMOTextBox";
            this.MEMOTextBox.Size = new System.Drawing.Size(493, 20);
            this.MEMOTextBox.TabIndex = 31;
            // 
            // PAISLabel
            // 
            this.PAISLabel.AutoSize = true;
            this.PAISLabel.Location = new System.Drawing.Point(13, 133);
            this.PAISLabel.Name = "PAISLabel";
            this.PAISLabel.Size = new System.Drawing.Size(54, 13);
            this.PAISLabel.TabIndex = 1;
            this.PAISLabel.Text = "País (*):";
            // 
            // RFCLabel
            // 
            this.RFCLabel.AutoSize = true;
            this.RFCLabel.Location = new System.Drawing.Point(15, 302);
            this.RFCLabel.Name = "RFCLabel";
            this.RFCLabel.Size = new System.Drawing.Size(56, 13);
            this.RFCLabel.TabIndex = 1;
            this.RFCLabel.Text = "RFC: (*):";
            // 
            // EMAIL2TextBox
            // 
            this.EMAIL2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EMAIL2TextBox.Location = new System.Drawing.Point(217, 359);
            this.EMAIL2TextBox.Name = "EMAIL2TextBox";
            this.EMAIL2TextBox.Size = new System.Drawing.Size(198, 20);
            this.EMAIL2TextBox.TabIndex = 28;
            // 
            // EMAIL2Label
            // 
            this.EMAIL2Label.AutoSize = true;
            this.EMAIL2Label.Location = new System.Drawing.Point(209, 342);
            this.EMAIL2Label.Name = "EMAIL2Label";
            this.EMAIL2Label.Size = new System.Drawing.Size(56, 13);
            this.EMAIL2Label.TabIndex = 1;
            this.EMAIL2Label.Text = "E-mail 2:";
            // 
            // RAZONSOCIALTextBox
            // 
            this.RAZONSOCIALTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RAZONSOCIALTextBox.Location = new System.Drawing.Point(14, 108);
            this.RAZONSOCIALTextBox.Name = "RAZONSOCIALTextBox";
            this.RAZONSOCIALTextBox.Size = new System.Drawing.Size(751, 20);
            this.RAZONSOCIALTextBox.TabIndex = 9;
            // 
            // EMAIL1TextBox
            // 
            this.EMAIL1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EMAIL1TextBox.Location = new System.Drawing.Point(18, 359);
            this.EMAIL1TextBox.Name = "EMAIL1TextBox";
            this.EMAIL1TextBox.Size = new System.Drawing.Size(182, 20);
            this.EMAIL1TextBox.TabIndex = 27;
            // 
            // RAZONSOCIALLabel
            // 
            this.RAZONSOCIALLabel.AutoSize = true;
            this.RAZONSOCIALLabel.Location = new System.Drawing.Point(14, 94);
            this.RAZONSOCIALLabel.Name = "RAZONSOCIALLabel";
            this.RAZONSOCIALLabel.Size = new System.Drawing.Size(84, 13);
            this.RAZONSOCIALLabel.TabIndex = 1;
            this.RAZONSOCIALLabel.Text = "Razón social:";
            // 
            // EMAIL1Label
            // 
            this.EMAIL1Label.AutoSize = true;
            this.EMAIL1Label.Location = new System.Drawing.Point(17, 342);
            this.EMAIL1Label.Name = "EMAIL1Label";
            this.EMAIL1Label.Size = new System.Drawing.Size(56, 13);
            this.EMAIL1Label.TabIndex = 1;
            this.EMAIL1Label.Text = "E-mail 1:";
            // 
            // NOMBRESLabel
            // 
            this.NOMBRESLabel.AccessibleDescription = "";
            this.NOMBRESLabel.AutoSize = true;
            this.NOMBRESLabel.Location = new System.Drawing.Point(14, 55);
            this.NOMBRESLabel.Name = "NOMBRESLabel";
            this.NOMBRESLabel.Size = new System.Drawing.Size(77, 13);
            this.NOMBRESLabel.TabIndex = 1;
            this.NOMBRESLabel.Text = "Nombres (*):";
            // 
            // CODIGOPOSTALLabel
            // 
            this.CODIGOPOSTALLabel.AutoSize = true;
            this.CODIGOPOSTALLabel.Location = new System.Drawing.Point(412, 131);
            this.CODIGOPOSTALLabel.Name = "CODIGOPOSTALLabel";
            this.CODIGOPOSTALLabel.Size = new System.Drawing.Size(106, 13);
            this.CODIGOPOSTALLabel.TabIndex = 1;
            this.CODIGOPOSTALLabel.Text = "Código Postal (*):";
            // 
            // APELLIDOSTextBox
            // 
            this.APELLIDOSTextBox.AccessibleDescription = "";
            this.APELLIDOSTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.APELLIDOSTextBox.Location = new System.Drawing.Point(326, 69);
            this.APELLIDOSTextBox.Name = "APELLIDOSTextBox";
            this.APELLIDOSTextBox.Size = new System.Drawing.Size(439, 20);
            this.APELLIDOSTextBox.TabIndex = 8;
            // 
            // NOMBRESTextBox
            // 
            this.NOMBRESTextBox.AccessibleDescription = "";
            this.NOMBRESTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NOMBRESTextBox.Location = new System.Drawing.Point(14, 69);
            this.NOMBRESTextBox.Name = "NOMBRESTextBox";
            this.NOMBRESTextBox.Size = new System.Drawing.Size(294, 20);
            this.NOMBRESTextBox.TabIndex = 7;
            // 
            // APELLIDOSLabel
            // 
            this.APELLIDOSLabel.AccessibleDescription = "";
            this.APELLIDOSLabel.AutoSize = true;
            this.APELLIDOSLabel.Location = new System.Drawing.Point(333, 55);
            this.APELLIDOSLabel.Name = "APELLIDOSLabel";
            this.APELLIDOSLabel.Size = new System.Drawing.Size(79, 13);
            this.APELLIDOSLabel.TabIndex = 1;
            this.APELLIDOSLabel.Text = "Apellidos (*):";
            // 
            // CODIGOPOSTALTextBox
            // 
            this.CODIGOPOSTALTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CODIGOPOSTALTextBox.Location = new System.Drawing.Point(423, 148);
            this.CODIGOPOSTALTextBox.Name = "CODIGOPOSTALTextBox";
            this.CODIGOPOSTALTextBox.Size = new System.Drawing.Size(75, 20);
            this.CODIGOPOSTALTextBox.TabIndex = 12;
            this.CODIGOPOSTALTextBox.Validated += new System.EventHandler(this.CODIGOPOSTALTextBox_Validated);
            // 
            // TELEFONO1Label
            // 
            this.TELEFONO1Label.AutoSize = true;
            this.TELEFONO1Label.Location = new System.Drawing.Point(520, 176);
            this.TELEFONO1Label.Name = "TELEFONO1Label";
            this.TELEFONO1Label.Size = new System.Drawing.Size(72, 13);
            this.TELEFONO1Label.TabIndex = 1;
            this.TELEFONO1Label.Text = "Teléfono 1:";
            // 
            // TELEFONO1TextBox
            // 
            this.TELEFONO1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TELEFONO1TextBox.Location = new System.Drawing.Point(520, 192);
            this.TELEFONO1TextBox.Name = "TELEFONO1TextBox";
            this.TELEFONO1TextBox.Size = new System.Drawing.Size(110, 20);
            this.TELEFONO1TextBox.TabIndex = 16;
            // 
            // TELEFONO2TextBox
            // 
            this.TELEFONO2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TELEFONO2TextBox.Location = new System.Drawing.Point(639, 192);
            this.TELEFONO2TextBox.Name = "TELEFONO2TextBox";
            this.TELEFONO2TextBox.Size = new System.Drawing.Size(99, 20);
            this.TELEFONO2TextBox.TabIndex = 17;
            // 
            // TELEFONO2Label
            // 
            this.TELEFONO2Label.AutoSize = true;
            this.TELEFONO2Label.Location = new System.Drawing.Point(633, 176);
            this.TELEFONO2Label.Name = "TELEFONO2Label";
            this.TELEFONO2Label.Size = new System.Drawing.Size(72, 13);
            this.TELEFONO2Label.TabIndex = 1;
            this.TELEFONO2Label.Text = "Teléfono 2:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.TBNotasCredito);
            this.tabControl1.Controls.Add(this.FirmaTabPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1104, 507);
            this.tabControl1.TabIndex = 36;
            // 
            // TBNotasCredito
            // 
            this.TBNotasCredito.Location = new System.Drawing.Point(4, 22);
            this.TBNotasCredito.Name = "TBNotasCredito";
            this.TBNotasCredito.Padding = new System.Windows.Forms.Padding(3);
            this.TBNotasCredito.Size = new System.Drawing.Size(1096, 481);
            this.TBNotasCredito.TabIndex = 2;
            this.TBNotasCredito.Text = "Notas de credito";
            this.TBNotasCredito.UseVisualStyleBackColor = true;
            // 
            // FirmaTabPage
            // 
            this.FirmaTabPage.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.FirmaTabPage.Controls.Add(this.btnFirmaImageSelector);
            this.FirmaTabPage.Controls.Add(this.NuevaFirmaImagenTextBox);
            this.FirmaTabPage.Controls.Add(this.btnEliminarFirmaImagen);
            this.FirmaTabPage.Controls.Add(this.FIRMAIMAGENTextBox);
            this.FirmaTabPage.Controls.Add(this.FIRMAIMAGENPictureBox);
            this.FirmaTabPage.Controls.Add(label37);
            this.FirmaTabPage.Location = new System.Drawing.Point(4, 22);
            this.FirmaTabPage.Name = "FirmaTabPage";
            this.FirmaTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FirmaTabPage.Size = new System.Drawing.Size(1096, 481);
            this.FirmaTabPage.TabIndex = 3;
            this.FirmaTabPage.Text = "Firma";
            this.FirmaTabPage.UseVisualStyleBackColor = true;
            // 
            // btnFirmaImageSelector
            // 
            this.btnFirmaImageSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirmaImageSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirmaImageSelector.ForeColor = System.Drawing.Color.White;
            this.btnFirmaImageSelector.Location = new System.Drawing.Point(467, 60);
            this.btnFirmaImageSelector.Name = "btnFirmaImageSelector";
            this.btnFirmaImageSelector.Size = new System.Drawing.Size(75, 23);
            this.btnFirmaImageSelector.TabIndex = 225;
            this.btnFirmaImageSelector.Text = "Explorar";
            this.btnFirmaImageSelector.UseVisualStyleBackColor = true;
            this.btnFirmaImageSelector.Click += new System.EventHandler(this.btnFirmaImageSelector_Click);
            // 
            // NuevaFirmaImagenTextBox
            // 
            this.NuevaFirmaImagenTextBox.Location = new System.Drawing.Point(51, 63);
            this.NuevaFirmaImagenTextBox.Name = "NuevaFirmaImagenTextBox";
            this.NuevaFirmaImagenTextBox.Size = new System.Drawing.Size(410, 20);
            this.NuevaFirmaImagenTextBox.TabIndex = 228;
            // 
            // btnEliminarFirmaImagen
            // 
            this.btnEliminarFirmaImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFirmaImagen.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFirmaImagen.Location = new System.Drawing.Point(788, 89);
            this.btnEliminarFirmaImagen.Name = "btnEliminarFirmaImagen";
            this.btnEliminarFirmaImagen.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarFirmaImagen.TabIndex = 227;
            this.btnEliminarFirmaImagen.Text = "Eliminar imagen";
            this.btnEliminarFirmaImagen.UseVisualStyleBackColor = true;
            this.btnEliminarFirmaImagen.Click += new System.EventHandler(this.btnEliminarFirmaImagen_Click);
            // 
            // FIRMAIMAGENTextBox
            // 
            this.FIRMAIMAGENTextBox.Enabled = false;
            this.FIRMAIMAGENTextBox.Location = new System.Drawing.Point(572, 63);
            this.FIRMAIMAGENTextBox.Name = "FIRMAIMAGENTextBox";
            this.FIRMAIMAGENTextBox.Size = new System.Drawing.Size(291, 20);
            this.FIRMAIMAGENTextBox.TabIndex = 223;
            // 
            // FIRMAIMAGENPictureBox
            // 
            this.FIRMAIMAGENPictureBox.Location = new System.Drawing.Point(51, 118);
            this.FIRMAIMAGENPictureBox.Name = "FIRMAIMAGENPictureBox";
            this.FIRMAIMAGENPictureBox.Size = new System.Drawing.Size(410, 306);
            this.FIRMAIMAGENPictureBox.TabIndex = 226;
            this.FIRMAIMAGENPictureBox.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1096, 481);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Datos Adicionales";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel4.Controls.Add(this.RETIENEIVATextBox);
            this.panel4.Controls.Add(this.btnCuentasBanco);
            this.panel4.Controls.Add(this.EXENTOIVATextBox);
            this.panel4.Controls.Add(this.RUTAEMBARQUEIDDescLabel);
            this.panel4.Controls.Add(this.PROVEECLIENTEIDButton);
            this.panel4.Controls.Add(this.RUTAEMBARQUEIDTextBox);
            this.panel4.Controls.Add(this.PROVEECLIENTEIDTextBox);
            this.panel4.Controls.Add(this.RUTAEMBARQUEIDButton);
            this.panel4.Controls.Add(this.PROVEECLIENTEIDLabel);
            this.panel4.Controls.Add(this.label31);
            this.panel4.Controls.Add(pROVEEDOR1IDLabel);
            this.panel4.Controls.Add(this.RETIENEISRTextBox);
            this.panel4.Controls.Add(this.PREGUNTARTICKETLARGOTextBox);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.EMAIL3TextBox);
            this.panel4.Controls.Add(this.MAYOREOXPRODUCTOTextBox);
            this.panel4.Controls.Add(this.GENERACARTAPORTETextBox);
            this.panel4.Controls.Add(this.EMAIL4TextBox);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.GENERACOMPROBTRASLTextBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1090, 475);
            this.panel4.TabIndex = 0;
            // 
            // BTAgregarNota
            // 
            this.BTAgregarNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTAgregarNota.Enabled = false;
            this.BTAgregarNota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTAgregarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarNota.ForeColor = System.Drawing.Color.White;
            this.BTAgregarNota.Location = new System.Drawing.Point(597, 35);
            this.BTAgregarNota.Name = "BTAgregarNota";
            this.BTAgregarNota.Size = new System.Drawing.Size(164, 23);
            this.BTAgregarNota.TabIndex = 220;
            this.BTAgregarNota.Text = "Agregar nota incidencia";
            this.BTAgregarNota.UseVisualStyleBackColor = false;
            this.BTAgregarNota.Click += new System.EventHandler(this.BTAgregarNota_Click);
            // 
            // btnNotaIncidencia
            // 
            this.btnNotaIncidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnNotaIncidencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnNotaIncidencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotaIncidencia.ForeColor = System.Drawing.Color.White;
            this.btnNotaIncidencia.Location = new System.Drawing.Point(793, 35);
            this.btnNotaIncidencia.Name = "btnNotaIncidencia";
            this.btnNotaIncidencia.Size = new System.Drawing.Size(142, 23);
            this.btnNotaIncidencia.TabIndex = 221;
            this.btnNotaIncidencia.Text = "Notas de incidencia";
            this.btnNotaIncidencia.UseVisualStyleBackColor = false;
            this.btnNotaIncidencia.Click += new System.EventHandler(this.btnNotaIncidencia_Click);
            // 
            // dOMICILIOSXPERSONATableAdapter
            // 
            this.dOMICILIOSXPERSONATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogos3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFClienteEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1107, 625);
            this.Controls.Add(this.btnNotaIncidencia);
            this.Controls.Add(this.BTAgregarNota);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CLAVETextBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WFClienteEdicion";
            this.Text = "CLIENTE";
            this.Load += new System.EventHandler(this.PERSONAEdit_Reg_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos3)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnlEdicionDatosEntrega.ResumeLayout(false);
            this.pnlEdicionDatosEntrega.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDesglosaIEPS.ResumeLayout(false);
            this.pnlDesglosaIEPS.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Pcredito.ResumeLayout(false);
            this.Pcredito.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.FirmaTabPage.ResumeLayout(false);
            this.FirmaTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FIRMAIMAGENPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion


        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;
  private CustomValidation.RequiredFieldValidator requiredFieldValidator1;




        private CustomValidation.RequiredFieldValidator RFV_CLAVE;
 
     
        private CustomValidation.RangeValidator RAV_ID;
     
        private CustomValidation.RangeValidator RAV_CREADOPOR_USERID;
     
        private CustomValidation.RangeValidator RAV_MODIFICADOPOR_USERID;
     
        private CustomValidation.RangeValidator RAV_TIPOPERSONAID;
     
        private CustomValidation.RangeValidator RAV_SALUDOID;
     
        private CustomValidation.RangeValidator RAV_EMPRESAID;
     
        private CustomValidation.RangeValidator RAV_VENDEDORID;
     
        private CustomValidation.RangeValidator RAV_LISTAPRECIOID;

        private CustomValidation.RangeValidator RAV_RESET_PASS;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.TextBox CLAVETextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conSaldosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anticiposToolStripMenuItem;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sumarizadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preciosEspecificosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descuentosPorLineaToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox EMAIL4TextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox EMAIL3TextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox RETIENEIVATextBox;
        private System.Windows.Forms.CheckBox RETIENEISRTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBoxFB ENTREGAESTADOTextBox;
        private System.Windows.Forms.TextBox ENTREGACODIGOPOSTALTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ENTREGANUMEROINTERIORTextBox;
        private System.Windows.Forms.TextBox ENTREGANUMEROEXTERIORTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ENTREGACALLETextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCuentaContpaq;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkOrdenCompra;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox REFERENCIADOMTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker ULTIMAVENTATextBox;
        private System.Windows.Forms.CheckBox SERVICIOADOMICILIOTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel pnlDesglosaIEPS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox CUENTAIEPSTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox DESGLOSEIEPSTextBox;
        private System.Windows.Forms.Button MONEDAButton;
        private Tools.TextBoxFB MONEDAIDTextBox;
        private System.Windows.Forms.Label MONEDALabel;
        private System.Windows.Forms.Label mONEDAIDLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox GENERARRECIBOELECTRONICOTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox PAGOPARCIALIDADESTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox CREDITOREFERENCIAABONOSTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox CREDITOFORMAPAGOABONOSTextBox;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label LblFormaPago;
        private System.Windows.Forms.ComboBoxFB ESTADOTextBox;
        private System.Windows.Forms.Panel Pcredito;
        private System.Windows.Forms.CheckBox HAB_PAGOEFECTIVOTextBox;
        private System.Windows.Forms.ComboBox SUPERLISTAPRECIOIDTextBox;
        private System.Windows.Forms.Label SUPERLISTAPRECIOIDLabel;
        private System.Windows.Forms.CheckBox HAB_PAGOTRANSFERENCIATextBox;
        private System.Windows.Forms.ComboBox PAGOSTextBox;
        private System.Windows.Forms.ComboBox REVISIONTextBox;
        private System.Windows.Forms.CheckBox BLOQUEADOTextBox;
        private System.Windows.Forms.NumericTextBox DIASTextBox;
        private System.Windows.Forms.NumericTextBox LIMITECREDITOTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ldias;
        private System.Windows.Forms.Label llimite;
        private System.Windows.Forms.CheckBox HAB_PAGOCHEQUETextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox HAB_PAGOCREDITOTextBox;
        private System.Windows.Forms.Label lpagos;
        private System.Windows.Forms.CheckBox HAB_PAGOTARJETATextBox;
        private System.Windows.Forms.Label lrevisio;
        private System.Windows.Forms.ComboBox LISTAPRECIOIDTextBox;
        private System.Windows.Forms.Label LISTAPRECIOIDLabel;
        private System.Windows.Forms.Label label3;
        private Tools.TextBoxFB VENDEDORIDTextBox;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label VENDEDORIDLabel;
        private System.Windows.Forms.TextBox NUMEROINTERIORTextBox;
        private System.Windows.Forms.TextBox NUMEROEXTERIORTextBox;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Label DOMICILIOLabel;
        private System.Windows.Forms.TextBox DOMICILIOTextBox;
        private System.Windows.Forms.Label CREADOPOR_USERIDLabel;
        private System.Windows.Forms.TextBox TextBoxCREADOPOR_USERCLAVE;
        private System.Windows.Forms.Label COLONIALabel;
        private System.Windows.Forms.Label MODIFICADOPOR_USERIDLabel;
        private System.Windows.Forms.TextBox MODIFICADOPOR_USERIDTextBox;
        private System.Windows.Forms.DateTimePicker VIGENCIATextBox;
        private System.Windows.Forms.Label CIUDADLabel;
        private System.Windows.Forms.Label VIGENCIALabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.TextBox CONTACTO2TextBox;
        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.Label CONTACTO2Label;
        private System.Windows.Forms.Label ESTADOLabel;
        private System.Windows.Forms.TextBox CONTACTO1TextBox;
        private System.Windows.Forms.Label CONTACTO1Label;
        private System.Windows.Forms.Label MEMOLabel;
        private System.Windows.Forms.TextBox RFCTextBox;
        private System.Windows.Forms.TextBox MEMOTextBox;
        private System.Windows.Forms.Label PAISLabel;
        private System.Windows.Forms.Label RFCLabel;
        private System.Windows.Forms.TextBox EMAIL2TextBox;
        private System.Windows.Forms.Label EMAIL2Label;
        private System.Windows.Forms.TextBox RAZONSOCIALTextBox;
        private System.Windows.Forms.TextBox EMAIL1TextBox;
        private System.Windows.Forms.Label RAZONSOCIALLabel;
        private System.Windows.Forms.Label EMAIL1Label;
        private System.Windows.Forms.Label NOMBRESLabel;
        private System.Windows.Forms.Label CODIGOPOSTALLabel;
        private System.Windows.Forms.TextBox APELLIDOSTextBox;
        private System.Windows.Forms.TextBox NOMBRESTextBox;
        private System.Windows.Forms.Label APELLIDOSLabel;
        private System.Windows.Forms.TextBox CODIGOPOSTALTextBox;
        private System.Windows.Forms.Label TELEFONO1Label;
        private System.Windows.Forms.TextBox TELEFONO1TextBox;
        private System.Windows.Forms.TextBox TELEFONO2TextBox;
        private System.Windows.Forms.Label TELEFONO2Label;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox cbSepararProdXPlazo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox CARGOXVENTACONTARJETATextBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox PAGOTARJMENORPRECIOLISTATextBox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBoxFB PAISComboBoxFb;
        private System.Windows.Forms.Button PROVEECLIENTEIDButton;
        private Tools.TextBoxFB PROVEECLIENTEIDTextBox;
        private System.Windows.Forms.Label PROVEECLIENTEIDLabel;
        private System.Windows.Forms.CheckBox EXENTOIVATextBox;
        private System.Windows.Forms.Button button2;
        private Tools.TextBoxFB SAT_USOCFDIIDTextBox;
        private System.Windows.Forms.Label SAT_USOCFDIIDLabel;
        private System.Windows.Forms.Button btnCuentasBanco;
        private System.Windows.Forms.NumericTextBox POR_COMETextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericTextBox DIAS_EXTRTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button RUTAEMBARQUEIDButton;
        private Tools.TextBoxFB RUTAEMBARQUEIDTextBox;
        private System.Windows.Forms.Label RUTAEMBARQUEIDDescLabel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button SUBTIPOCLIENTEButton;
        private Tools.TextBoxFB SUBTIPOCLIENTETextBox;
        private System.Windows.Forms.Label SUBTIPOCLIENTEDescLabel;
        private System.Windows.Forms.ToolStripMenuItem historialVentasYNCToolStripMenuItem;
        private System.Windows.Forms.CheckBox PREGUNTARTICKETLARGOTextBox;
        private System.Windows.Forms.Button BTAgregarNota;
        private System.Windows.Forms.TabPage TBNotasCredito;
        private System.Windows.Forms.Button btnNotaIncidencia;
        private System.Windows.Forms.CheckBox MAYOREOXPRODUCTOTextBox;
        private System.Windows.Forms.CheckBox GENERACARTAPORTETextBox;
        private System.Windows.Forms.CheckBox GENERACOMPROBTRASLTextBox;
        private System.Windows.Forms.NumericTextBox DISTANCIATextBox;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button SAT_LOCALIDADIDButton;
        private System.Windows.Forms.Label SAT_LOCALIDADIDLabel;
        private Tools.TextBoxFB SAT_LOCALIDADIDTextBox;
        private System.Windows.Forms.Button SAT_MUNICIPIOIDButton;
        private System.Windows.Forms.Label SAT_MUNICIPIOIDLabel;
        private Tools.TextBoxFB SAT_MUNICIPIOIDTextBox;
        private System.Windows.Forms.Button SAT_COLONIAIDButton;
        private System.Windows.Forms.Label SAT_COLONIAIDLabel;
        private Tools.TextBoxFB SAT_COLONIAIDTextBox;
        private System.Windows.Forms.Button ENTREGA_SAT_COLONIAIDButton;
        private System.Windows.Forms.Label ENTREGA_SAT_COLONIAIDLabel;
        private Tools.TextBoxFB ENTREGA_SAT_COLONIAIDTextBox;
        private System.Windows.Forms.Button ENTREGA_SAT_MUNICIPIOIDButton;
        private System.Windows.Forms.Label ENTREGA_SAT_MUNICIPIOIDLabel;
        private Tools.TextBoxFB ENTREGA_SAT_MUNICIPIOIDTextBox;
        private System.Windows.Forms.Button ENTREGA_SAT_LOCALIDADIDButton;
        private System.Windows.Forms.Label ENTREGA_SAT_LOCALIDADIDLabel;
        private Tools.TextBoxFB ENTREGA_SAT_LOCALIDADIDTextBox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericTextBox ENTREGA_DISTANCIATextBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox ENTREGAREFERENCIADOMTextBox;
        private System.Windows.Forms.Button SAT_REGIMENFISCALIDButton;
        private System.Windows.Forms.Label SAT_REGIMENFISCALIDLabel;
        private System.Windows.Forms.Label pSAT_REGIMENFISCALIDLabel;
        private Tools.TextBoxFB SAT_REGIMENFISCALIDTextBox;
        private System.Windows.Forms.TabPage FirmaTabPage;
        private System.Windows.Forms.Button btnFirmaImageSelector;
        private System.Windows.Forms.TextBox NuevaFirmaImagenTextBox;
        private System.Windows.Forms.Button btnEliminarFirmaImagen;
        private System.Windows.Forms.TextBox FIRMAIMAGENTextBox;
        private System.Windows.Forms.PictureBox FIRMAIMAGENPictureBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAbrirMapa;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox LONGITUDTextBox;
        private System.Windows.Forms.TextBox LATITUDTextBox;
        private Catalogos.DSCatalogos3 dSCatalogos3;
        private System.Windows.Forms.BindingSource dOMICILIOSXPERSONABindingSource;
        private Catalogos.DSCatalogos3TableAdapters.DOMICILIOSXPERSONATableAdapter dOMICILIOSXPERSONATableAdapter;
        private Catalogos.DSCatalogos3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dOMICILIOSXPERSONADataGridView;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Panel pnlEdicionDatosEntrega;
        private System.Windows.Forms.Button btnCancelarGuardadoEntrega;
        private System.Windows.Forms.Button btnGuardarDatosEntrega;
        private System.Windows.Forms.Button BtnAgregarDatosEntrega;
        private System.Windows.Forms.Button btnMapaEntrega;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox ENTREGALONGITUDTextBox;
        private System.Windows.Forms.TextBox ENTREGALATITUDTextBox;
        private System.Windows.Forms.DataGridViewImageColumn BTNEDITARDOMICILIO;
        private System.Windows.Forms.DataGridViewImageColumn BTNELIMINARDOMICILIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDOMACTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
    }
}

