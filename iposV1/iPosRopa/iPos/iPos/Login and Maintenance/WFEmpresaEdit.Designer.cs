
namespace iPos
{
    partial class WFEmpresaEdit
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
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label TEXTO6Label;
            System.Windows.Forms.Label TEXTO4Label;
            System.Windows.Forms.Label TEXTO5Label;
            System.Windows.Forms.Label TEXTO2Label;
            System.Windows.Forms.Label TEXTO3Label;
            System.Windows.Forms.Label TEXTO1Label;
            System.Windows.Forms.Label pROVEEDOR1IDServLabel;
            System.Windows.Forms.Label mARCAIDServLabel;
            System.Windows.Forms.Label lINEAIDServLabel;
            System.Windows.Forms.Label pROVEEDOR1IDRecLabel;
            System.Windows.Forms.Label mARCAIDRecLabel;
            System.Windows.Forms.Label lINEAIDRecLabel;
            System.Windows.Forms.Label label218;
            System.Windows.Forms.Label lblVersionTope;
            System.Windows.Forms.Label lblVersionComision;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFEmpresaEdit));
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter2 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.RFV_NOMBRE = new CustomValidation.RequiredFieldValidator();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.NUMEROINTERIORTextBox = new System.Windows.Forms.TextBox();
            this.NUMEROEXTERIORTextBox = new System.Windows.Forms.TextBox();
            this.CALLELabel = new System.Windows.Forms.Label();
            this.RFCTextBox = new System.Windows.Forms.TextBox();
            this.RFCLabel = new System.Windows.Forms.Label();
            this.PAGINAWEBTextBox = new System.Windows.Forms.TextBox();
            this.PAGINAWEBLabel = new System.Windows.Forms.Label();
            this.CORREOETextBox = new System.Windows.Forms.TextBox();
            this.CORREOELabel = new System.Windows.Forms.Label();
            this.FAXTextBox = new System.Windows.Forms.TextBox();
            this.FAXLabel = new System.Windows.Forms.Label();
            this.TELEFONOTextBox = new System.Windows.Forms.TextBox();
            this.TELEFONOLabel = new System.Windows.Forms.Label();
            this.CPTextBox = new System.Windows.Forms.TextBox();
            this.CPLabel = new System.Windows.Forms.Label();
            this.ESTADOLabel = new System.Windows.Forms.Label();
            this.LOCALIDADTextBox = new System.Windows.Forms.TextBox();
            this.LOCALIDADLabel = new System.Windows.Forms.Label();
            this.CALLETextBox = new System.Windows.Forms.TextBox();
            this.COLONIATextBox = new System.Windows.Forms.TextBox();
            this.COLONIALabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AUTPRECIOLISTABAJOTextBox = new System.Windows.Forms.ComboBox();
            this.label320 = new System.Windows.Forms.Label();
            this.label318 = new System.Windows.Forms.Label();
            this.RUTAFIRMAIMAGENESTextBox = new System.Windows.Forms.TextBox();
            this.HABVENTACLISUCTextBox = new System.Windows.Forms.ComboBox();
            this.label266 = new System.Windows.Forms.Label();
            this.HABFONDODINAMICOTextBox = new System.Windows.Forms.ComboBox();
            this.label265 = new System.Windows.Forms.Label();
            this.SOLOABONOAPLICADOTextBox = new System.Windows.Forms.CheckBox();
            this.lblSaldosAplicados = new System.Windows.Forms.Label();
            this.AGRUPACIONVENTAIDButton = new System.Windows.Forms.Button();
            this.AGRUPACIONVENTAIDLabel = new System.Windows.Forms.Label();
            this.label250 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.HABVENTASAFUTUROComboBox = new System.Windows.Forms.ComboBox();
            this.VENTASXCORTEEMAILTextBox = new System.Windows.Forms.ComboBox();
            this.label174 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.PREGUNTACANCELACOTIZACIONTextBox = new System.Windows.Forms.ComboBox();
            this.label166 = new System.Windows.Forms.Label();
            this.HABILITARLOGComboBox = new System.Windows.Forms.ComboBox();
            this.label152 = new System.Windows.Forms.Label();
            this.MANEJARECETATextBox = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.MANEJAALMACENTextBox = new System.Windows.Forms.ComboBox();
            this.label103 = new System.Windows.Forms.Label();
            this.MANEJASUPERLISTAPRECIOTextBox = new System.Windows.Forms.ComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.DIVIDIR_REM_FACTTextBox = new System.Windows.Forms.ComboBox();
            this.label100 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.PREFIJOCLIENTETextBox = new System.Windows.Forms.TextBox();
            this.MOSTRARIMAGENENVENTATextBox = new System.Windows.Forms.ComboBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.RUTAIMAGENESPRODUCTOTextBox = new System.Windows.Forms.TextBox();
            this.PREGUNTARRAZONPRECIOMENORComboBox = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.CORTEPORMAILTextBox = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.ENVIOAUTOMATICOEXISTENCIASComboBox = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.HAYVENDEDORPISOComboBox = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.LISTAPRECIOINIMAYOComboBox = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.PREFIJOBASCULATextBox = new System.Windows.Forms.TextBox();
            this.HAB_FACTURAELECTRONICAComboBox = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.IMP_PROD_TOTALComboBox = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.REABRIRCORTESComboBox = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.REQ_APROBACION_INVComboBox = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.MOSTRAR_EXIS_SUCComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.HAB_IMPR_COTIZACIONComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.HAB_SEL_CLIENTEComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CBCambiarPrecio = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.LISTA_PRECIO_DEFLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.HABILITAR_IMPEXP_AUTComboBox = new System.Windows.Forms.ComboBox();
            this.LISTA_PRECIO_DEFTextBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ID_DOSLETRASTextBox = new System.Windows.Forms.TextBox();
            this.ESTADO_DEFLabel = new System.Windows.Forms.Label();
            this.UltimaFecha = new System.Windows.Forms.DateTimePicker();
            this.IMP_PROD_DEFLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AGRUPACIONVENTAIDTextBox = new iPos.Tools.TextBoxFB();
            this.TIPODESCUENTOPRODIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.MINUTILIDADTextBox = new System.Windows.Forms.NumericTextBox();
            this.ESTADO_DEFTextBox = new System.Windows.Forms.ComboBoxFB();
            this.LONGPESOBASCULATextBox = new System.Windows.Forms.NumericTextBox();
            this.LONGPRODBASCULATextBox = new System.Windows.Forms.NumericTextBox();
            this.IMP_PROD_DEFTextBox = new System.Windows.Forms.NumericTextBox();
            this.SucursalComboBox = new System.Windows.Forms.ComboBoxFB();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RUTAIMPORTADATOSTextBox = new System.Windows.Forms.TextBox();
            this.label246 = new System.Windows.Forms.Label();
            this.RUTACATALOGOSUPDTextBox = new System.Windows.Forms.TextBox();
            this.label243 = new System.Windows.Forms.Label();
            this.txtRutaReplicadorExe = new System.Windows.Forms.TextBox();
            this.lblRutaReplicadorExe = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label132 = new System.Windows.Forms.Label();
            this.BDLOCALREPLTextBox = new System.Windows.Forms.TextBox();
            this.HABILITARREPLTextBox = new System.Windows.Forms.ComboBox();
            this.label131 = new System.Windows.Forms.Label();
            this.WSESPECIALEXISTMATRIZTextBox = new System.Windows.Forms.TextBox();
            this.label227 = new System.Windows.Forms.Label();
            this.VERSIONWSEXISTENCIASTextBox = new System.Windows.Forms.NumericUpDown();
            this.label223 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox = new System.Windows.Forms.ComboBox();
            this.label220 = new System.Windows.Forms.Label();
            this.HAB_DEVOLUCIONTRASLADOComboBox = new System.Windows.Forms.ComboBox();
            this.txtRutaDBFExistenciaSuc = new System.Windows.Forms.TextBox();
            this.label221 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.unicaVisitaPorDoctoCheckBox = new System.Windows.Forms.CheckBox();
            this.label206 = new System.Windows.Forms.Label();
            this.WSMENSAJERIATextBox = new System.Windows.Forms.TextBox();
            this.label205 = new System.Windows.Forms.Label();
            this.HABMENSAJERIAComboBox = new System.Windows.Forms.ComboBox();
            this.txtRutaAdjuntarArchivo = new System.Windows.Forms.TextBox();
            this.label186 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.MAILEJECUTIVOTextBox = new System.Windows.Forms.TextBox();
            this.txtRutaRespaldo = new System.Windows.Forms.TextBox();
            this.label153 = new System.Windows.Forms.Label();
            this.RUTAREPORTESSISTEMATextBox = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.RUTARESPALDOSZIPTextBox = new System.Windows.Forms.TextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.MAILTOINVENTARIOTextBox = new System.Windows.Forms.TextBox();
            this.USARCONEXIONLOCALTextBox = new System.Windows.Forms.ComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.LOCALWEBSERVICETextBox = new System.Windows.Forms.TextBox();
            this.label119 = new System.Windows.Forms.Label();
            this.LOCALFTPHOSTTextBox = new System.Windows.Forms.TextBox();
            this.WEBSERVICETextBox = new System.Windows.Forms.TextBox();
            this.LABELWEBSERVICE = new System.Windows.Forms.Label();
            this.FACT_ELECT_FOLDERTextBox = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.PEDIDOS_FOLDERTextBox = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.SMTPSSLComboBox = new System.Windows.Forms.ComboBox();
            this.RUTAREPORTESTextBox = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.FTPFOLDERPASSTextBox = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.FTPFOLDERTextBox = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SMTPMAILTOTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SMTPMAILFROMTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SMTPPASSWORDTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SMTPUSUARIOTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SMTPHOSTTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FTPPASSWORDTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FTPHOSTTextBox = new System.Windows.Forms.TextBox();
            this.FTPUSUARIOTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SMTPPORTTextBox = new System.Windows.Forms.NumericTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label307 = new System.Windows.Forms.Label();
            this.label306 = new System.Windows.Forms.Label();
            this.TICKET_IMPR_DESC2ComboBox = new System.Windows.Forms.ComboBox();
            this.label293 = new System.Windows.Forms.Label();
            this.label292 = new System.Windows.Forms.Label();
            this.TICKET_DESC_VALE_AL_FINALComboBox = new System.Windows.Forms.ComboBox();
            this.label290 = new System.Windows.Forms.Label();
            this.label282 = new System.Windows.Forms.Label();
            this.label291 = new System.Windows.Forms.Label();
            this.label289 = new System.Windows.Forms.Label();
            this.label287 = new System.Windows.Forms.Label();
            this.label285 = new System.Windows.Forms.Label();
            this.label283 = new System.Windows.Forms.Label();
            this.label280 = new System.Windows.Forms.Label();
            this.label281 = new System.Windows.Forms.Label();
            this.label279 = new System.Windows.Forms.Label();
            this.label276 = new System.Windows.Forms.Label();
            this.label277 = new System.Windows.Forms.Label();
            this.label275 = new System.Windows.Forms.Label();
            this.label264 = new System.Windows.Forms.Label();
            this.RECIBOLARGOCOTIPRINTERTextBox = new System.Windows.Forms.TextBox();
            this.label262 = new System.Windows.Forms.Label();
            this.IMPRFORMAVENTATRASLTextBox = new System.Windows.Forms.CheckBox();
            this.label261 = new System.Windows.Forms.Label();
            this.label255 = new System.Windows.Forms.Label();
            this.IMPR_CANC_VENTAComboBox = new System.Windows.Forms.CheckBox();
            this.label254 = new System.Windows.Forms.Label();
            this.IMPRIMIRBANCOSCORTEComboBox = new System.Windows.Forms.CheckBox();
            this.label251 = new System.Windows.Forms.Label();
            this.label244 = new System.Windows.Forms.Label();
            this.IMPRIMIRCOPIAALMACENComboBox = new System.Windows.Forms.ComboBox();
            this.label233 = new System.Windows.Forms.Label();
            this.PIEZACAJAENTICKETComboBox = new System.Windows.Forms.ComboBox();
            this.label232 = new System.Windows.Forms.Label();
            this.label231 = new System.Windows.Forms.Label();
            this.RECARGASDEFAULTPRINTERTextBox = new System.Windows.Forms.TextBox();
            this.label230 = new System.Windows.Forms.Label();
            this.TICKETDEFAULTPRINTERTextBox = new System.Windows.Forms.TextBox();
            this.label229 = new System.Windows.Forms.Label();
            this.TICKETESPECIALTextBox = new System.Windows.Forms.TextBox();
            this.cmbPrecioDifInv = new System.Windows.Forms.ComboBox();
            this.label212 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.cbHabVentasMostrador = new System.Windows.Forms.CheckBox();
            this.label181 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.HABTRASLADOPORAUTORIZACIONComboBox = new System.Windows.Forms.ComboBox();
            this.label180 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.HABIMPRESIONCORTECAJEROComboBox = new System.Windows.Forms.ComboBox();
            this.FORMATOTICKETCORTOIDComboBox = new System.Windows.Forms.ComboBox();
            this.label177 = new System.Windows.Forms.Label();
            this.REIMPRESIONESCONMARCAComboBox = new System.Windows.Forms.ComboBox();
            this.label148 = new System.Windows.Forms.Label();
            this.DOBLECOPIAREMISIONComboBox = new System.Windows.Forms.ComboBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.ABRIRCAJONALFINCORTEComboBox = new System.Windows.Forms.ComboBox();
            this.label142 = new System.Windows.Forms.Label();
            this.REQAUTELIMDETALLECOTIComboBox = new System.Windows.Forms.ComboBox();
            this.label141 = new System.Windows.Forms.Label();
            this.REQAUTCANCELARCOTIComboBox = new System.Windows.Forms.ComboBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.TAMANOLETRATICKETTextBox = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.PROMOENTICKETComboBox = new System.Windows.Forms.ComboBox();
            this.ORDENIMPRESIONComboBox = new System.Windows.Forms.ComboBox();
            this.label115 = new System.Windows.Forms.Label();
            this.MOSTRARPZACAJAENFACTURAComboBox = new System.Windows.Forms.ComboBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.RECIBOLARGOCONFACTURAComboBox = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.UIVENTACONCANTIDADComboBox = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.MOSTRARDESCUENTOFACTURAComboBox = new System.Windows.Forms.ComboBox();
            this.label88 = new System.Windows.Forms.Label();
            this.MOSTRARMONTOAHORROComboBox = new System.Windows.Forms.ComboBox();
            this.PREGUNTARDATOSENTREGAComboBox = new System.Windows.Forms.ComboBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.RECIBOLARGOPREVIEWComboBox = new System.Windows.Forms.ComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.RECIBOLARGOPRINTERTextBox = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.IMPRIMIRNUMEROPIEZASComboBox = new System.Windows.Forms.ComboBox();
            this.FOOTERVENTAAPARTADOTextBox = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.FOOTERTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.HEADERTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CANTTICKETCIERREBILLETESTextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETCIERRECORTETextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETABRIRCORTETextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETCOMPRASTextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETGASTOSTextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETFONDOCAJATextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETDEPOSITOSTextBox = new System.Windows.Forms.NumericTextBox();
            this.CANTTICKETRETIROTextBox = new System.Windows.Forms.NumericTextBox();
            this.DOBLECOPIATARJETATextBox = new System.Windows.Forms.NumericTextBox();
            this.DOBLECOPIACONTADOTextBox = new System.Windows.Forms.NumericTextBox();
            this.NUMTICKETSABONOTextBox = new System.Windows.Forms.NumericTextBox();
            this.PENDMAXDIASTextBox = new System.Windows.Forms.NumericTextBox();
            this.DOBLECOPIATRASLADOTextBox = new System.Windows.Forms.NumericTextBox();
            this.DOBLECOPIACREDITOTextBox = new System.Windows.Forms.NumericTextBox();
            this.TBComisiones = new System.Windows.Forms.TabPage();
            this.label321 = new System.Windows.Forms.Label();
            this.LISTAPRECMEDMAYLINEAComboBox = new System.Windows.Forms.ComboBox();
            this.label319 = new System.Windows.Forms.Label();
            this.LISTAPRECIOMAYLINEAComboBox = new System.Windows.Forms.ComboBox();
            this.label274 = new System.Windows.Forms.Label();
            this.label272 = new System.Windows.Forms.Label();
            this.label273 = new System.Windows.Forms.Label();
            this.label260 = new System.Windows.Forms.Label();
            this.PREGUNTARSERVDOMTextBox = new System.Windows.Forms.CheckBox();
            this.label258 = new System.Windows.Forms.Label();
            this.PAGOTARJMENORPRECIOLISTAALLTextBox = new System.Windows.Forms.CheckBox();
            this.label257 = new System.Windows.Forms.Label();
            this.RETIROCAJAALCERRARCORTETextBox = new System.Windows.Forms.ComboBox();
            this.label256 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.PREGUNTARSIESACREDITOTextBox = new System.Windows.Forms.ComboBox();
            this.label204 = new System.Windows.Forms.Label();
            this.label194 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.CAMBIARPRECIOXUEMPAQUEComboBox = new System.Windows.Forms.ComboBox();
            this.LISTAPRECIOXUEMPAQUEComboBox = new System.Windows.Forms.ComboBox();
            this.CAMBIARPRECIOXPZACAJAComboBox = new System.Windows.Forms.ComboBox();
            this.LISTAPRECIOXPZACAJAComboBox = new System.Windows.Forms.ComboBox();
            this.label161 = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.APLICARMAYOREOPORLINEATextBox = new System.Windows.Forms.ComboBox();
            this.label159 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.MANEJARRETIRODECAJATextBox = new System.Windows.Forms.ComboBox();
            this.label154 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.MANEJAQUOTATextBox = new System.Windows.Forms.ComboBox();
            this.label107 = new System.Windows.Forms.Label();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.lblClienteSuc = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.FACTCONSMAXPORTextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONDEBPORTARJETATextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONDEBTARJETAEMPRESATextBox = new System.Windows.Forms.NumericTextBox();
            this.MAXCOMISIONXCLIENTETextBox = new System.Windows.Forms.NumericTextBox();
            this.VERSIONCOMISIONIDTextBox = new System.Windows.Forms.NumericTextBox();
            this.INTENTOSRETIROCAJATextBox = new System.Windows.Forms.NumericTextBox();
            this.MONTOMAXSALDOMENORNumericTextBox = new System.Windows.Forms.NumericTextBox();
            this.IVACOMISIONTARJETAEMPRESATextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONTARJETAEMPRESATextBox = new System.Windows.Forms.NumericTextBox();
            this.PIEZASDIFMAYOREOTextBox = new System.Windows.Forms.NumericTextBox();
            this.PIEZASIGUALESMAYOREOTextBox = new System.Windows.Forms.NumericTextBox();
            this.PIEZASDIFMEDIOMAYOREOTextBox = new System.Windows.Forms.NumericTextBox();
            this.PIEZASIGUALESMEDIOMAYOREOTextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONPORTARJETATextBox = new System.Windows.Forms.NumericTextBox();
            this.MONTORETIROCAJATextBox = new System.Windows.Forms.NumericTextBox();
            this.TIPOUTILIDADIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.ENCARGADOIDTextBox = new iPos.Tools.TextBoxFB();
            this.PORC_COMISIONVENDEDORTextBox = new System.Windows.Forms.NumericTextBox();
            this.PORC_COMISIONENCARGADOTextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONDEPENDIENTETextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONMEDICOTextBox = new System.Windows.Forms.NumericTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label301 = new System.Windows.Forms.Label();
            this.HABSURTIDOPREVIOTextBox = new System.Windows.Forms.ComboBox();
            this.label302 = new System.Windows.Forms.Label();
            this.label300 = new System.Windows.Forms.Label();
            this.COSTOREPOIGUALCOSTOULTComboBox = new System.Windows.Forms.ComboBox();
            this.label288 = new System.Windows.Forms.Label();
            this.HABMULTPLAZOCOMPRATextBox = new System.Windows.Forms.ComboBox();
            this.label286 = new System.Windows.Forms.Label();
            this.MANEJAUTILIDADPRECIOSTextBox = new System.Windows.Forms.ComboBox();
            this.label284 = new System.Windows.Forms.Label();
            this.HABREVISIONFINALTextBox = new System.Windows.Forms.ComboBox();
            this.label263 = new System.Windows.Forms.Label();
            this.label247 = new System.Windows.Forms.Label();
            this.cbBusquedaTipo2 = new System.Windows.Forms.CheckBox();
            this.label241 = new System.Windows.Forms.Label();
            this.label240 = new System.Windows.Forms.Label();
            this.label239 = new System.Windows.Forms.Label();
            this.label238 = new System.Windows.Forms.Label();
            this.label237 = new System.Windows.Forms.Label();
            this.label236 = new System.Windows.Forms.Label();
            this.PRECIONETOENGRIDSTextBox = new System.Windows.Forms.ComboBox();
            this.label226 = new System.Windows.Forms.Label();
            this.label217 = new System.Windows.Forms.Label();
            this.actPrecAutoCB = new System.Windows.Forms.CheckBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.autocompleteConExistenciaCB = new System.Windows.Forms.CheckBox();
            this.label214 = new System.Windows.Forms.Label();
            this.cbPlazosXProducto = new System.Windows.Forms.CheckBox();
            this.label210 = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.CXCVALIDARTRASLADOSTextBox = new System.Windows.Forms.ComboBox();
            this.label202 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.HAB_PRECIOSCLIENTETextBox = new System.Windows.Forms.ComboBox();
            this.label199 = new System.Windows.Forms.Label();
            this.EANPUEDEREPETIRSETextBox = new System.Windows.Forms.ComboBox();
            this.label197 = new System.Windows.Forms.Label();
            this.PRECIOSORDENADOSTextBox = new System.Windows.Forms.ComboBox();
            this.label196 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.HABPROMOXMONTOMINTextBox = new System.Windows.Forms.ComboBox();
            this.label189 = new System.Windows.Forms.Label();
            this.HABVERIFICACIONCXCTextBox = new System.Windows.Forms.ComboBox();
            this.label168 = new System.Windows.Forms.Label();
            this.HABSURTIDOPOSTPUESTOTextBox = new System.Windows.Forms.ComboBox();
            this.label144 = new System.Windows.Forms.Label();
            this.RECALCULARCAMBIOCLIENTETextBox = new System.Windows.Forms.ComboBox();
            this.label135 = new System.Windows.Forms.Label();
            this.REBAJAESPECIALTextBox = new System.Windows.Forms.ComboBox();
            this.label130 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.LISTAPRECIOMINIMOComboBox = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.CAMPOIMPOCOSTOREPOTextBox = new System.Windows.Forms.ComboBox();
            this.MANEJAKITSTextBox = new System.Windows.Forms.ComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.PRECIOXCAJAENPVTextBox = new System.Windows.Forms.ComboBox();
            this.label118 = new System.Windows.Forms.Label();
            this.AUTOCOMPCLIENTETextBox = new System.Windows.Forms.ComboBox();
            this.label117 = new System.Windows.Forms.Label();
            this.MOSTRARFLASHComboBox = new System.Windows.Forms.ComboBox();
            this.label116 = new System.Windows.Forms.Label();
            this.PRECIONETOENPVTextBox = new System.Windows.Forms.ComboBox();
            this.label113 = new System.Windows.Forms.Label();
            this.CAJASBOTELLASTextBox = new System.Windows.Forms.ComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.AUTOCOMPPRODTextBox = new System.Windows.Forms.ComboBox();
            this.label106 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.FECHA2TextBox = new System.Windows.Forms.TextBox();
            this.NUMERO4TextBox = new System.Windows.Forms.TextBox();
            this.FECHA1TextBox = new System.Windows.Forms.TextBox();
            this.NUMERO2TextBox = new System.Windows.Forms.TextBox();
            this.NUMERO3TextBox = new System.Windows.Forms.TextBox();
            this.NUMERO1TextBox = new System.Windows.Forms.TextBox();
            this.TEXTO6TextBox = new System.Windows.Forms.TextBox();
            this.TEXTO4TextBox = new System.Windows.Forms.TextBox();
            this.TEXTO5TextBox = new System.Windows.Forms.TextBox();
            this.TEXTO2TextBox = new System.Windows.Forms.TextBox();
            this.TEXTO3TextBox = new System.Windows.Forms.TextBox();
            this.TEXTO1TextBox = new System.Windows.Forms.TextBox();
            this.VERSIONTOPEIDTextBox = new System.Windows.Forms.NumericTextBox();
            this.cancelXActNumericTextBox = new System.Windows.Forms.NumericTextBox();
            this.ALMACENRECEPCIONIDTextBox = new System.Windows.Forms.ComboBoxFB();
            this.CADUCIDADMINIMATextBox = new System.Windows.Forms.NumericTextBox();
            this.DECIMALESENCANTIDADTextBox = new System.Windows.Forms.NumericTextBox();
            this.CORTACADUCIDADTextBox = new System.Windows.Forms.NumericTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.SERIECOMPRTRASLSATTextBox = new System.Windows.Forms.TextBox();
            this.label308 = new System.Windows.Forms.Label();
            this.FISCALFECHACANCELACION2TextBox = new System.Windows.Forms.DateTimePicker();
            this.label278 = new System.Windows.Forms.Label();
            this.label252 = new System.Windows.Forms.Label();
            this.DESGLOSEIEPSFACTURATextBox = new System.Windows.Forms.CheckBox();
            this.VERSIONCFDITextBox = new System.Windows.Forms.TextBox();
            this.label248 = new System.Windows.Forms.Label();
            this.GENERARFECheckBox = new System.Windows.Forms.CheckBox();
            this.PAGOSERVCONSOLIDADOTextBox = new System.Windows.Forms.CheckBox();
            this.METPAGOSATIDButton = new System.Windows.Forms.Button();
            this.METPAGOSATIDValLabel = new System.Windows.Forms.Label();
            this.METPAGOSATIDLabel = new System.Windows.Forms.Label();
            this.REGIMENSATFBButton = new System.Windows.Forms.Button();
            this.REGIMENSATLBL = new System.Windows.Forms.Label();
            this.FORMATOFACTURAComboBox = new System.Windows.Forms.ComboBox();
            this.label190 = new System.Windows.Forms.Label();
            this.SERIESATABONOTextBox = new System.Windows.Forms.TextBox();
            this.label178 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.CLIENTECLAVEButton = new System.Windows.Forms.Button();
            this.CLIENTECLAVELabel = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.CUENTAIEPSTextBox = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.DESGLOSEIEPSTextBox = new System.Windows.Forms.CheckBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.ARRENDATARIOCheckBox = new System.Windows.Forms.CheckBox();
            this.label82 = new System.Windows.Forms.Label();
            this.FISCALREGIMENTextBox = new System.Windows.Forms.TextBox();
            this.PACUSUARIOTextBox = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.PACNOMBRETextBox = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.SERIESATDEVOLUCIONTextBox = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.USARFISCALESENEXPEDICIONCheckBox = new System.Windows.Forms.CheckBox();
            this.SERIESATTextBox = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.TIMBRADOKEYTextBox = new System.Windows.Forms.TextBox();
            this.TIMBRADOARCHIVOKEYTextBox = new System.Windows.Forms.TextBox();
            this.TIMBRADOARCHIVOCERTIFICADOTextBox = new System.Windows.Forms.TextBox();
            this.TIMBRADOPASSWORDTextBox = new System.Windows.Forms.TextBox();
            this.TIMBRADOUSERTextBox = new System.Windows.Forms.TextBox();
            this.FISCALNOMBRETextBox = new System.Windows.Forms.TextBox();
            this.CERTIFICADOCSDTextBox = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.FISCALNUMEROINTERIORTextBox = new System.Windows.Forms.TextBox();
            this.FISCALNUMEROEXTERIORTextBox = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.FISCALCODIGOPOSTALTextBox = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.FISCALMUNICIPIOTextBox = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.FISCALCALLETextBox = new System.Windows.Forms.TextBox();
            this.FISCALCOLONIATextBox = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.METPAGOSATIDTextBox = new iPos.Tools.TextBoxFB();
            this.REGIMENSATFBTextBox = new iPos.Tools.TextBoxFB();
            this.CLIENTECONSOLIDADOIDTextBox = new iPos.Tools.TextBoxFB();
            this.RETENCIONISRTextBox = new System.Windows.Forms.NumericTextBox();
            this.RETENCIONIVATextBox = new System.Windows.Forms.NumericTextBox();
            this.FISCALESTADOTextBox = new System.Windows.Forms.ComboBoxFB();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.MONEDEROLISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.MONEDEROCAMPOREFLabel = new System.Windows.Forms.Label();
            this.MONEDEROCAMPOREFTextBox = new System.Windows.Forms.TextBox();
            this.MONEDEROLISTAPRECIOIDComboBox = new System.Windows.Forms.ComboBox();
            this.RUTAPOLIZAPDFTextBox = new System.Windows.Forms.TextBox();
            this.label253 = new System.Windows.Forms.Label();
            this.label249 = new System.Windows.Forms.Label();
            this.CONSFACTOMITIRVALESCheckBox = new System.Windows.Forms.CheckBox();
            this.label228 = new System.Windows.Forms.Label();
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox = new System.Windows.Forms.CheckBox();
            this.label225 = new System.Windows.Forms.Label();
            this.MANEJAPRODUCTOSPROMOCIONCheckBox = new System.Windows.Forms.CheckBox();
            this.filtroProdSatComboBox = new System.Windows.Forms.ComboBox();
            this.MANEJAPRODUCTOSPROMOCIONLabel = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.MANEJACUPONESCheckBox = new System.Windows.Forms.CheckBox();
            this.label211 = new System.Windows.Forms.Label();
            this.cbHabBtnPagoVale = new System.Windows.Forms.CheckBox();
            this.label209 = new System.Windows.Forms.Label();
            this.MANEJAGASTOSADICCheckBox = new System.Windows.Forms.CheckBox();
            this.label208 = new System.Windows.Forms.Label();
            this.MANEJARLOTEIMPORTACIONCheckBox = new System.Windows.Forms.CheckBox();
            this.label207 = new System.Windows.Forms.Label();
            this.DESCUENTOLINEAPERSONACheckBox = new System.Windows.Forms.CheckBox();
            this.label198 = new System.Windows.Forms.Label();
            this.BANCOMERHABPINPADCheckBox = new System.Windows.Forms.CheckBox();
            this.MULTIPLETIPOVALETextBox = new System.Windows.Forms.ComboBox();
            this.label151 = new System.Windows.Forms.Label();
            this.DESCUENTOTIPO4TEXTOTextBox = new System.Windows.Forms.TextBox();
            this.DESCUENTOTIPO3TEXTOTextBox = new System.Windows.Forms.TextBox();
            this.DESCUENTOTIPO2TEXTOTextBox = new System.Windows.Forms.TextBox();
            this.DESCUENTOTIPO1TEXTOTextBox = new System.Windows.Forms.TextBox();
            this.label150 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.MONEDEROAPLICARComboBox = new System.Windows.Forms.ComboBox();
            this.label66 = new System.Windows.Forms.Label();
            this.DESCUENTOTIPO4PORCTextBox = new System.Windows.Forms.NumericTextBox();
            this.DESCUENTOTIPO3PORCTextBox = new System.Windows.Forms.NumericTextBox();
            this.DESCUENTOTIPO2PORCTextBox = new System.Windows.Forms.NumericTextBox();
            this.DESCUENTOTIPO1PORCTextBox = new System.Windows.Forms.NumericTextBox();
            this.DESCUENTOVALETextBox = new System.Windows.Forms.NumericTextBox();
            this.MONEDEROCADUCIDADTextBox = new System.Windows.Forms.NumericTextBox();
            this.MONEDEROMONTOMINIMOTextBox = new System.Windows.Forms.NumericTextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label224 = new System.Windows.Forms.Label();
            this.MOSTRARINVINFOADICPRODTextBox = new System.Windows.Forms.ComboBox();
            this.label149 = new System.Windows.Forms.Label();
            this.HABTOTALIZADOSTextBox = new System.Windows.Forms.ComboBox();
            this.label91 = new System.Windows.Forms.Label();
            this.EXPORTCATALOGOAUXTextBox = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.CAMPOSCUSTOMALIMPORTARTextBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.L1LBL_CAMPO36TextBox = new System.Windows.Forms.TextBox();
            this.lblPrecioMacro = new System.Windows.Forms.Label();
            this.L1CAMPO36CheckBox = new System.Windows.Forms.CheckBox();
            this.PORCUTILMACROLISTADOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label323 = new System.Windows.Forms.Label();
            this.PORCUTILIDADLISTADOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label317 = new System.Windows.Forms.Label();
            this.label234 = new System.Windows.Forms.Label();
            this.PVCOLOREARTextBox = new System.Windows.Forms.ComboBox();
            this.L1LBL_CAMPO35TextBox = new System.Windows.Forms.TextBox();
            this.L1CAMPO35CheckBox = new System.Windows.Forms.CheckBox();
            this.L1LBL_CAMPO34TextBox = new System.Windows.Forms.TextBox();
            this.L1CAMPO34CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO33CheckBox = new System.Windows.Forms.CheckBox();
            this.L1LBL_CAMPO33TextBox = new System.Windows.Forms.TextBox();
            this.L1CAMPO32CheckBox = new System.Windows.Forms.CheckBox();
            this.L1LBL_CAMPO32TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO31TextBox = new System.Windows.Forms.TextBox();
            this.label203 = new System.Windows.Forms.Label();
            this.L1CAMPO31CheckBox = new System.Windows.Forms.CheckBox();
            this.L1LBL_CAMPO23TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO22TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO21TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO20TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO18TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO16TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO30TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO29TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO28TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO27TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO26TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO24TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO25TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO17TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO13TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO7TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO12TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO6TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO11TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO5TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO10TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO9TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO4TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO3TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO1TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO19TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO15TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO14TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO8TextBox = new System.Windows.Forms.TextBox();
            this.L1LBL_CAMPO2TextBox = new System.Windows.Forms.TextBox();
            this.label172 = new System.Windows.Forms.Label();
            this.L1CAMPO30CheckBox = new System.Windows.Forms.CheckBox();
            this.label170 = new System.Windows.Forms.Label();
            this.L1CAMPO29CheckBox = new System.Windows.Forms.CheckBox();
            this.label171 = new System.Windows.Forms.Label();
            this.L1CAMPO28CheckBox = new System.Windows.Forms.CheckBox();
            this.label169 = new System.Windows.Forms.Label();
            this.L1CAMPO27CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO26CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO25CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO24CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO23CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO22CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO21CheckBox = new System.Windows.Forms.CheckBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.L1CAMPO20CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO19CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO18CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO17CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO16CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO15CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPOOBLIGADO3 = new System.Windows.Forms.CheckBox();
            this.L1CAMPO14CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO13CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO12CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO11CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO9CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO10CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO8CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO7CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO6CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO5CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO3CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO4CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO2CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPO1CheckBox = new System.Windows.Forms.CheckBox();
            this.L1CAMPOOBLIGADO2 = new System.Windows.Forms.CheckBox();
            this.L1CAMPOOBLIGADO1 = new System.Windows.Forms.CheckBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.HABSURTIDOPOSTMOVILTextBox = new System.Windows.Forms.ComboBox();
            this.label316 = new System.Windows.Forms.Label();
            this.rutaBdVenMovTextBox = new System.Windows.Forms.TextBox();
            this.label245 = new System.Windows.Forms.Label();
            this.MOVIL3_PREIMPORTARCheckBox = new System.Windows.Forms.CheckBox();
            this.label242 = new System.Windows.Forms.Label();
            this.MOVIL_TIENEVENDEDORESComboBox = new System.Windows.Forms.ComboBox();
            this.TIPOSYNCMOVILTextBox = new System.Windows.Forms.ComboBox();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.TOUCHTextBox = new System.Windows.Forms.ComboBox();
            this.ESVENDEDORMOVILTextBox = new System.Windows.Forms.ComboBox();
            this.label124 = new System.Windows.Forms.Label();
            this.SCREENCONFIGTextBox = new System.Windows.Forms.ComboBox();
            this.VENDEDORMOVILIDLabel = new System.Windows.Forms.Label();
            this.VENDEDORIDLabel = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.PRECIOSMOVILANTESVENTATextBox = new System.Windows.Forms.ComboBox();
            this.PENDMOVILANTESVENTATextBox = new System.Windows.Forms.ComboBox();
            this.label133 = new System.Windows.Forms.Label();
            this.VENDEDORMOVILIDButton = new System.Windows.Forms.Button();
            this.MOVILVERIFICARVENTAComboBox = new System.Windows.Forms.ComboBox();
            this.label139 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.BDMATRIZMOVILTextBox = new System.Windows.Forms.TextBox();
            this.label137 = new System.Windows.Forms.Label();
            this.label136 = new System.Windows.Forms.Label();
            this.BDSERVERWSTextBox = new System.Windows.Forms.TextBox();
            this.TIPOVENDEDORMOVILTextBox = new System.Windows.Forms.ComboBox();
            this.VENDEDORMOVILCLAVETextBox = new iPos.Tools.TextBoxFB();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label193 = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.PROVEEDOR1ServButton = new System.Windows.Forms.Button();
            this.PROVEEDOR1ServLabel = new System.Windows.Forms.Label();
            this.MARCAServButton = new System.Windows.Forms.Button();
            this.MARCAServLabel = new System.Windows.Forms.Label();
            this.LINEAServButton = new System.Windows.Forms.Button();
            this.LINEAServLabel = new System.Windows.Forms.Label();
            this.PROVEEDOR1RecButton = new System.Windows.Forms.Button();
            this.PROVEEDOR1RecLabel = new System.Windows.Forms.Label();
            this.MARCARecButton = new System.Windows.Forms.Button();
            this.MARCARecLabel = new System.Windows.Forms.Label();
            this.LINEARecButton = new System.Windows.Forms.Button();
            this.LINEARecLabel = new System.Windows.Forms.Label();
            this.label188 = new System.Windows.Forms.Label();
            this.HABPAGOSERVEMIDACheckBox = new System.Windows.Forms.CheckBox();
            this.label187 = new System.Windows.Forms.Label();
            this.TIMEOUTPINTDISTSALESERVTextBox = new System.Windows.Forms.NumericUpDown();
            this.label185 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.nudTimeOutLookUp = new System.Windows.Forms.NumericUpDown();
            this.nudTimeOutPin = new System.Windows.Forms.NumericUpDown();
            this.label176 = new System.Windows.Forms.Label();
            this.rdbtnEmidaServices = new System.Windows.Forms.CheckBox();
            this.txtUtilidadPagoServicio = new System.Windows.Forms.NumericTextBox();
            this.txtPorcUtilidadRecargas = new System.Windows.Forms.NumericTextBox();
            this.PROVEEDOR1IDServTextBox = new iPos.Tools.TextBoxFB();
            this.MARCAIDServTextBox = new iPos.Tools.TextBoxFB();
            this.LINEAIDServTextBox = new iPos.Tools.TextBoxFB();
            this.PROVEEDOR1IDRecTextBox = new iPos.Tools.TextBoxFB();
            this.MARCAIDRecTextBox = new iPos.Tools.TextBoxFB();
            this.LINEAIDRecTextBox = new iPos.Tools.TextBoxFB();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.label215 = new System.Windows.Forms.Label();
            this.txtRutaBDAppInventario = new System.Windows.Forms.TextBox();
            this.label216 = new System.Windows.Forms.Label();
            this.txtIPWsAppInventario = new System.Windows.Forms.TextBox();
            this.tabPagePPC = new System.Windows.Forms.TabPage();
            this.HABPPCTextBox = new System.Windows.Forms.CheckBox();
            this.label259 = new System.Windows.Forms.Label();
            this.tabPageImportaciones = new System.Windows.Forms.TabPage();
            this.HABWSDBFTextBox = new System.Windows.Forms.ComboBox();
            this.label271 = new System.Windows.Forms.Label();
            this.label270 = new System.Windows.Forms.Label();
            this.WSDBFTextBox = new System.Windows.Forms.TextBox();
            this.label269 = new System.Windows.Forms.Label();
            this.label268 = new System.Windows.Forms.Label();
            this.label267 = new System.Windows.Forms.Label();
            this.DIASMAXIMPFTPTextBox = new System.Windows.Forms.NumericTextBox();
            this.DIASMAXEXPFTPTextBox = new System.Windows.Forms.NumericTextBox();
            this.SEGUNDOSCICLOFTPTextBox = new System.Windows.Forms.NumericTextBox();
            this.TabPageComisionesXPrecio = new System.Windows.Forms.TabPage();
            this.label299 = new System.Windows.Forms.Label();
            this.label298 = new System.Windows.Forms.Label();
            this.label297 = new System.Windows.Forms.Label();
            this.label296 = new System.Windows.Forms.Label();
            this.label295 = new System.Windows.Forms.Label();
            this.label294 = new System.Windows.Forms.Label();
            this.COMISIONPRECIOOTROTextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONPRECIO5TextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONPRECIO4TextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONPRECIO3TextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONPRECIO2TextBox = new System.Windows.Forms.NumericTextBox();
            this.COMISIONPRECIO1TextBox = new System.Windows.Forms.NumericTextBox();
            this.TBComanda = new System.Windows.Forms.TabPage();
            this.label304 = new System.Windows.Forms.Label();
            this.RECIBOPREVIEWCOMANDATextBox = new System.Windows.Forms.ComboBox();
            this.label305 = new System.Windows.Forms.Label();
            this.label303 = new System.Windows.Forms.Label();
            this.IMPRESORACOMANDATextBox = new System.Windows.Forms.TextBox();
            this.NUMTICKETSCOMANDATextBox = new System.Windows.Forms.NumericTextBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.L2LBL_CAMPO12TextBox = new System.Windows.Forms.TextBox();
            this.label315 = new System.Windows.Forms.Label();
            this.L2CAMPO12CheckBox = new System.Windows.Forms.CheckBox();
            this.L2LBL_CAMPO6TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO11TextBox = new System.Windows.Forms.TextBox();
            this.label309 = new System.Windows.Forms.Label();
            this.L2CAMPO11CheckBox = new System.Windows.Forms.CheckBox();
            this.L2LBL_CAMPO10TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO9TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO8TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO7TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO5TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO3TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO4TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO2TextBox = new System.Windows.Forms.TextBox();
            this.L2LBL_CAMPO1TextBox = new System.Windows.Forms.TextBox();
            this.label310 = new System.Windows.Forms.Label();
            this.L2CAMPO10CheckBox = new System.Windows.Forms.CheckBox();
            this.label311 = new System.Windows.Forms.Label();
            this.L2CAMPO9CheckBox = new System.Windows.Forms.CheckBox();
            this.label312 = new System.Windows.Forms.Label();
            this.L2CAMPO8CheckBox = new System.Windows.Forms.CheckBox();
            this.label313 = new System.Windows.Forms.Label();
            this.L2CAMPO7CheckBox = new System.Windows.Forms.CheckBox();
            this.L2CAMPO5CheckBox = new System.Windows.Forms.CheckBox();
            this.L2CAMPO4CheckBox = new System.Windows.Forms.CheckBox();
            this.L2CAMPO3CheckBox = new System.Windows.Forms.CheckBox();
            this.label314 = new System.Windows.Forms.Label();
            this.L2CAMPO2CheckBox = new System.Windows.Forms.CheckBox();
            this.L2CAMPO6CheckBox = new System.Windows.Forms.CheckBox();
            this.L2CAMPO1CheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VERIFONEACTIVOCheckBox = new System.Windows.Forms.CheckBox();
            this.label322 = new System.Windows.Forms.Label();
            this.VERIFONE_OPERATORLOCALETextBox = new System.Windows.Forms.TextBox();
            this.label325 = new System.Windows.Forms.Label();
            this.VERIFONE_MERCHANTIDTextBox = new System.Windows.Forms.TextBox();
            this.label326 = new System.Windows.Forms.Label();
            this.VERIFONE_SHIFTNUMBERTextBox = new System.Windows.Forms.TextBox();
            this.label327 = new System.Windows.Forms.Label();
            this.VERIFONE_CONTRASENATextBox = new System.Windows.Forms.TextBox();
            this.lblVerifoneContrasena = new System.Windows.Forms.Label();
            this.VERIFONE_USERIDTextBox = new System.Windows.Forms.TextBox();
            this.label328 = new System.Windows.Forms.Label();
            this.label329 = new System.Windows.Forms.Label();
            this.label1191 = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            TEXTO6Label = new System.Windows.Forms.Label();
            TEXTO4Label = new System.Windows.Forms.Label();
            TEXTO5Label = new System.Windows.Forms.Label();
            TEXTO2Label = new System.Windows.Forms.Label();
            TEXTO3Label = new System.Windows.Forms.Label();
            TEXTO1Label = new System.Windows.Forms.Label();
            pROVEEDOR1IDServLabel = new System.Windows.Forms.Label();
            mARCAIDServLabel = new System.Windows.Forms.Label();
            lINEAIDServLabel = new System.Windows.Forms.Label();
            pROVEEDOR1IDRecLabel = new System.Windows.Forms.Label();
            mARCAIDRecLabel = new System.Windows.Forms.Label();
            lINEAIDRecLabel = new System.Windows.Forms.Label();
            label218 = new System.Windows.Forms.Label();
            lblVersionTope = new System.Windows.Forms.Label();
            lblVersionComision = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VERSIONWSEXISTENCIASTextBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.TBComisiones.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIMEOUTPINTDISTSALESERVTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutPin)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.tabPagePPC.SuspendLayout();
            this.tabPageImportaciones.SuspendLayout();
            this.TabPageComisionesXPrecio.SuspendLayout();
            this.TBComanda.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(262, 222);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(49, 13);
            label26.TabIndex = 133;
            label26.Text = "Fecha2";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(262, 182);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(57, 13);
            label27.TabIndex = 131;
            label27.Text = "Numero4";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(12, 222);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(49, 13);
            label28.TabIndex = 129;
            label28.Text = "Fecha1";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(262, 139);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(57, 13);
            label29.TabIndex = 127;
            label29.Text = "Numero2";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(12, 182);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(57, 13);
            label30.TabIndex = 125;
            label30.Text = "Numero3";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(12, 139);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(57, 13);
            label31.TabIndex = 123;
            label31.Text = "Numero1";
            // 
            // TEXTO6Label
            // 
            TEXTO6Label.AutoSize = true;
            TEXTO6Label.Location = new System.Drawing.Point(262, 92);
            TEXTO6Label.Name = "TEXTO6Label";
            TEXTO6Label.Size = new System.Drawing.Size(46, 13);
            TEXTO6Label.TabIndex = 121;
            TEXTO6Label.Text = "Texto6";
            // 
            // TEXTO4Label
            // 
            TEXTO4Label.AutoSize = true;
            TEXTO4Label.Location = new System.Drawing.Point(262, 52);
            TEXTO4Label.Name = "TEXTO4Label";
            TEXTO4Label.Size = new System.Drawing.Size(46, 13);
            TEXTO4Label.TabIndex = 119;
            TEXTO4Label.Text = "Texto4";
            // 
            // TEXTO5Label
            // 
            TEXTO5Label.AutoSize = true;
            TEXTO5Label.Location = new System.Drawing.Point(12, 92);
            TEXTO5Label.Name = "TEXTO5Label";
            TEXTO5Label.Size = new System.Drawing.Size(46, 13);
            TEXTO5Label.TabIndex = 117;
            TEXTO5Label.Text = "Texto5";
            // 
            // TEXTO2Label
            // 
            TEXTO2Label.AutoSize = true;
            TEXTO2Label.Location = new System.Drawing.Point(262, 13);
            TEXTO2Label.Name = "TEXTO2Label";
            TEXTO2Label.Size = new System.Drawing.Size(46, 13);
            TEXTO2Label.TabIndex = 115;
            TEXTO2Label.Text = "Texto2";
            // 
            // TEXTO3Label
            // 
            TEXTO3Label.AutoSize = true;
            TEXTO3Label.Location = new System.Drawing.Point(12, 52);
            TEXTO3Label.Name = "TEXTO3Label";
            TEXTO3Label.Size = new System.Drawing.Size(46, 13);
            TEXTO3Label.TabIndex = 113;
            TEXTO3Label.Text = "Texto3";
            // 
            // TEXTO1Label
            // 
            TEXTO1Label.AutoSize = true;
            TEXTO1Label.Location = new System.Drawing.Point(12, 13);
            TEXTO1Label.Name = "TEXTO1Label";
            TEXTO1Label.Size = new System.Drawing.Size(46, 13);
            TEXTO1Label.TabIndex = 111;
            TEXTO1Label.Text = "Texto1";
            // 
            // pROVEEDOR1IDServLabel
            // 
            pROVEEDOR1IDServLabel.AutoSize = true;
            pROVEEDOR1IDServLabel.Location = new System.Drawing.Point(146, 231);
            pROVEEDOR1IDServLabel.Name = "pROVEEDOR1IDServLabel";
            pROVEEDOR1IDServLabel.Size = new System.Drawing.Size(117, 13);
            pROVEEDOR1IDServLabel.TabIndex = 211;
            pROVEEDOR1IDServLabel.Text = "Proveedor servicio:";
            // 
            // mARCAIDServLabel
            // 
            mARCAIDServLabel.AutoSize = true;
            mARCAIDServLabel.Location = new System.Drawing.Point(169, 193);
            mARCAIDServLabel.Name = "mARCAIDServLabel";
            mARCAIDServLabel.Size = new System.Drawing.Size(94, 13);
            mARCAIDServLabel.TabIndex = 207;
            mARCAIDServLabel.Text = "Marca servicio:";
            // 
            // lINEAIDServLabel
            // 
            lINEAIDServLabel.AutoSize = true;
            lINEAIDServLabel.Location = new System.Drawing.Point(173, 153);
            lINEAIDServLabel.Name = "lINEAIDServLabel";
            lINEAIDServLabel.Size = new System.Drawing.Size(90, 13);
            lINEAIDServLabel.TabIndex = 203;
            lINEAIDServLabel.Text = "Linea servicio:";
            // 
            // pROVEEDOR1IDRecLabel
            // 
            pROVEEDOR1IDRecLabel.AutoSize = true;
            pROVEEDOR1IDRecLabel.Location = new System.Drawing.Point(147, 115);
            pROVEEDOR1IDRecLabel.Name = "pROVEEDOR1IDRecLabel";
            pROVEEDOR1IDRecLabel.Size = new System.Drawing.Size(116, 13);
            pROVEEDOR1IDRecLabel.TabIndex = 199;
            pROVEEDOR1IDRecLabel.Text = "Proveedor recarga:";
            // 
            // mARCAIDRecLabel
            // 
            mARCAIDRecLabel.AutoSize = true;
            mARCAIDRecLabel.Location = new System.Drawing.Point(170, 76);
            mARCAIDRecLabel.Name = "mARCAIDRecLabel";
            mARCAIDRecLabel.Size = new System.Drawing.Size(93, 13);
            mARCAIDRecLabel.TabIndex = 195;
            mARCAIDRecLabel.Text = "Marca recarga:";
            // 
            // lINEAIDRecLabel
            // 
            lINEAIDRecLabel.AutoSize = true;
            lINEAIDRecLabel.Location = new System.Drawing.Point(174, 37);
            lINEAIDRecLabel.Name = "lINEAIDRecLabel";
            lINEAIDRecLabel.Size = new System.Drawing.Size(89, 13);
            lINEAIDRecLabel.TabIndex = 191;
            lINEAIDRecLabel.Text = "Linea recarga:";
            // 
            // label218
            // 
            label218.AutoSize = true;
            label218.Location = new System.Drawing.Point(15, 496);
            label218.Name = "label218";
            label218.Size = new System.Drawing.Size(268, 13);
            label218.TabIndex = 202;
            label218.Text = "Cancelaciones por actualizacion de catalogos";
            // 
            // lblVersionTope
            // 
            lblVersionTope.AutoSize = true;
            lblVersionTope.Location = new System.Drawing.Point(495, 137);
            lblVersionTope.Name = "lblVersionTope";
            lblVersionTope.Size = new System.Drawing.Size(200, 13);
            lblVersionTope.TabIndex = 214;
            lblVersionTope.Text = "Version rebaja por nota de credito";
            // 
            // lblVersionComision
            // 
            lblVersionComision.AutoSize = true;
            lblVersionComision.Location = new System.Drawing.Point(590, 63);
            lblVersionComision.Name = "lblVersionComision";
            lblVersionComision.Size = new System.Drawing.Size(106, 13);
            lblVersionComision.TabIndex = 275;
            lblVersionComision.Text = "Version comision:";
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(26, 20);
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
            // FbCommand1
            // 
            this.FbCommand1.CommandText = resources.GetString("FbCommand1.CommandText");
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter2.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.Char;
            fbParameter2.ParameterName = "@NOMBRE";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter2});
            // 
            // RFV_NOMBRE
            // 
            this.RFV_NOMBRE.ControlToValidate = this.NOMBRETextBox;
            this.RFV_NOMBRE.Enabled = true;
            this.RFV_NOMBRE.ErrorMessage = "Se requiere el campo NOMBRE";
            this.RFV_NOMBRE.Icon = null;
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(108, 6);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(195, 20);
            this.NOMBRETextBox.TabIndex = 2;
            this.NOMBRETextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NOMBRETextBox_KeyDown);
            this.NOMBRETextBox.Validated += new System.EventHandler(this.NOMBRETextBox_Validated);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.Enabled = true;
            this.requiredFieldValidator1.Icon = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 700);
            this.panel1.TabIndex = 45;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(318, 591);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 30);
            this.button1.TabIndex = 52;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.TBComisiones);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPagePPC);
            this.tabControl1.Controls.Add(this.tabPageImportaciones);
            this.tabControl1.Controls.Add(this.TabPageComisionesXPrecio);
            this.tabControl1.Controls.Add(this.TBComanda);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Location = new System.Drawing.Point(-1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 582);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.ESTADOTextBox);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.NUMEROINTERIORTextBox);
            this.tabPage1.Controls.Add(this.NUMEROEXTERIORTextBox);
            this.tabPage1.Controls.Add(this.CALLELabel);
            this.tabPage1.Controls.Add(this.RFCTextBox);
            this.tabPage1.Controls.Add(this.RFCLabel);
            this.tabPage1.Controls.Add(this.PAGINAWEBTextBox);
            this.tabPage1.Controls.Add(this.PAGINAWEBLabel);
            this.tabPage1.Controls.Add(this.CORREOETextBox);
            this.tabPage1.Controls.Add(this.CORREOELabel);
            this.tabPage1.Controls.Add(this.FAXTextBox);
            this.tabPage1.Controls.Add(this.FAXLabel);
            this.tabPage1.Controls.Add(this.TELEFONOTextBox);
            this.tabPage1.Controls.Add(this.TELEFONOLabel);
            this.tabPage1.Controls.Add(this.CPTextBox);
            this.tabPage1.Controls.Add(this.CPLabel);
            this.tabPage1.Controls.Add(this.ESTADOLabel);
            this.tabPage1.Controls.Add(this.LOCALIDADTextBox);
            this.tabPage1.Controls.Add(this.LOCALIDADLabel);
            this.tabPage1.Controls.Add(this.CALLETextBox);
            this.tabPage1.Controls.Add(this.COLONIATextBox);
            this.tabPage1.Controls.Add(this.COLONIALabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // ESTADOTextBox
            // 
            this.ESTADOTextBox.Condicion = null;
            this.ESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ESTADOTextBox.DisplayMember = "nombre";
            this.ESTADOTextBox.FormattingEnabled = true;
            this.ESTADOTextBox.IndiceCampoSelector = 0;
            this.ESTADOTextBox.LabelDescription = null;
            this.ESTADOTextBox.Location = new System.Drawing.Point(105, 120);
            this.ESTADOTextBox.Name = "ESTADOTextBox";
            this.ESTADOTextBox.NombreCampoSelector = "id";
            this.ESTADOTextBox.Query = "select id,nombre from estado";
            this.ESTADOTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.ESTADOTextBox.SelectedDataDisplaying = null;
            this.ESTADOTextBox.SelectedDataValue = null;
            this.ESTADOTextBox.Size = new System.Drawing.Size(196, 21);
            this.ESTADOTextBox.TabIndex = 9;
            this.ESTADOTextBox.ValueMember = "id";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(435, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(23, 13);
            this.label32.TabIndex = 26;
            this.label32.Text = "#I:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(309, 14);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 13);
            this.label33.TabIndex = 25;
            this.label33.Text = "#E:";
            // 
            // NUMEROINTERIORTextBox
            // 
            this.NUMEROINTERIORTextBox.Location = new System.Drawing.Point(459, 11);
            this.NUMEROINTERIORTextBox.Name = "NUMEROINTERIORTextBox";
            this.NUMEROINTERIORTextBox.Size = new System.Drawing.Size(90, 20);
            this.NUMEROINTERIORTextBox.TabIndex = 6;
            // 
            // NUMEROEXTERIORTextBox
            // 
            this.NUMEROEXTERIORTextBox.Location = new System.Drawing.Point(336, 11);
            this.NUMEROEXTERIORTextBox.Name = "NUMEROEXTERIORTextBox";
            this.NUMEROEXTERIORTextBox.Size = new System.Drawing.Size(90, 20);
            this.NUMEROEXTERIORTextBox.TabIndex = 5;
            // 
            // CALLELabel
            // 
            this.CALLELabel.AutoSize = true;
            this.CALLELabel.Location = new System.Drawing.Point(61, 14);
            this.CALLELabel.Name = "CALLELabel";
            this.CALLELabel.Size = new System.Drawing.Size(39, 13);
            this.CALLELabel.TabIndex = 1;
            this.CALLELabel.Text = "Calle:";
            // 
            // RFCTextBox
            // 
            this.RFCTextBox.Location = new System.Drawing.Point(106, 343);
            this.RFCTextBox.Name = "RFCTextBox";
            this.RFCTextBox.Size = new System.Drawing.Size(195, 20);
            this.RFCTextBox.TabIndex = 15;
            // 
            // RFCLabel
            // 
            this.RFCLabel.AutoSize = true;
            this.RFCLabel.Location = new System.Drawing.Point(64, 346);
            this.RFCLabel.Name = "RFCLabel";
            this.RFCLabel.Size = new System.Drawing.Size(35, 13);
            this.RFCLabel.TabIndex = 1;
            this.RFCLabel.Text = "RFC:";
            // 
            // PAGINAWEBTextBox
            // 
            this.PAGINAWEBTextBox.Location = new System.Drawing.Point(106, 305);
            this.PAGINAWEBTextBox.Name = "PAGINAWEBTextBox";
            this.PAGINAWEBTextBox.Size = new System.Drawing.Size(195, 20);
            this.PAGINAWEBTextBox.TabIndex = 14;
            // 
            // PAGINAWEBLabel
            // 
            this.PAGINAWEBLabel.AutoSize = true;
            this.PAGINAWEBLabel.Location = new System.Drawing.Point(22, 308);
            this.PAGINAWEBLabel.Name = "PAGINAWEBLabel";
            this.PAGINAWEBLabel.Size = new System.Drawing.Size(77, 13);
            this.PAGINAWEBLabel.TabIndex = 1;
            this.PAGINAWEBLabel.Text = "Pagina web:";
            // 
            // CORREOETextBox
            // 
            this.CORREOETextBox.Location = new System.Drawing.Point(106, 267);
            this.CORREOETextBox.Name = "CORREOETextBox";
            this.CORREOETextBox.Size = new System.Drawing.Size(195, 20);
            this.CORREOETextBox.TabIndex = 13;
            // 
            // CORREOELabel
            // 
            this.CORREOELabel.AutoSize = true;
            this.CORREOELabel.Location = new System.Drawing.Point(39, 270);
            this.CORREOELabel.Name = "CORREOELabel";
            this.CORREOELabel.Size = new System.Drawing.Size(60, 13);
            this.CORREOELabel.TabIndex = 1;
            this.CORREOELabel.Text = "Correo E:";
            // 
            // FAXTextBox
            // 
            this.FAXTextBox.Location = new System.Drawing.Point(106, 230);
            this.FAXTextBox.Name = "FAXTextBox";
            this.FAXTextBox.Size = new System.Drawing.Size(195, 20);
            this.FAXTextBox.TabIndex = 12;
            // 
            // FAXLabel
            // 
            this.FAXLabel.AutoSize = true;
            this.FAXLabel.Location = new System.Drawing.Point(67, 233);
            this.FAXLabel.Name = "FAXLabel";
            this.FAXLabel.Size = new System.Drawing.Size(31, 13);
            this.FAXLabel.TabIndex = 1;
            this.FAXLabel.Text = "Fax:";
            // 
            // TELEFONOTextBox
            // 
            this.TELEFONOTextBox.Location = new System.Drawing.Point(106, 194);
            this.TELEFONOTextBox.Name = "TELEFONOTextBox";
            this.TELEFONOTextBox.Size = new System.Drawing.Size(195, 20);
            this.TELEFONOTextBox.TabIndex = 11;
            // 
            // TELEFONOLabel
            // 
            this.TELEFONOLabel.AutoSize = true;
            this.TELEFONOLabel.Location = new System.Drawing.Point(37, 197);
            this.TELEFONOLabel.Name = "TELEFONOLabel";
            this.TELEFONOLabel.Size = new System.Drawing.Size(61, 13);
            this.TELEFONOLabel.TabIndex = 1;
            this.TELEFONOLabel.Text = "Telefono:";
            // 
            // CPTextBox
            // 
            this.CPTextBox.Location = new System.Drawing.Point(106, 158);
            this.CPTextBox.Name = "CPTextBox";
            this.CPTextBox.Size = new System.Drawing.Size(195, 20);
            this.CPTextBox.TabIndex = 10;
            // 
            // CPLabel
            // 
            this.CPLabel.AutoSize = true;
            this.CPLabel.Location = new System.Drawing.Point(63, 161);
            this.CPLabel.Name = "CPLabel";
            this.CPLabel.Size = new System.Drawing.Size(35, 13);
            this.CPLabel.TabIndex = 1;
            this.CPLabel.Text = "C.P.:";
            // 
            // ESTADOLabel
            // 
            this.ESTADOLabel.AutoSize = true;
            this.ESTADOLabel.Location = new System.Drawing.Point(48, 123);
            this.ESTADOLabel.Name = "ESTADOLabel";
            this.ESTADOLabel.Size = new System.Drawing.Size(50, 13);
            this.ESTADOLabel.TabIndex = 1;
            this.ESTADOLabel.Text = "Estado:";
            // 
            // LOCALIDADTextBox
            // 
            this.LOCALIDADTextBox.Location = new System.Drawing.Point(105, 83);
            this.LOCALIDADTextBox.Name = "LOCALIDADTextBox";
            this.LOCALIDADTextBox.Size = new System.Drawing.Size(196, 20);
            this.LOCALIDADTextBox.TabIndex = 8;
            // 
            // LOCALIDADLabel
            // 
            this.LOCALIDADLabel.AutoSize = true;
            this.LOCALIDADLabel.Location = new System.Drawing.Point(32, 86);
            this.LOCALIDADLabel.Name = "LOCALIDADLabel";
            this.LOCALIDADLabel.Size = new System.Drawing.Size(66, 13);
            this.LOCALIDADLabel.TabIndex = 1;
            this.LOCALIDADLabel.Text = "Localidad:";
            // 
            // CALLETextBox
            // 
            this.CALLETextBox.Location = new System.Drawing.Point(106, 11);
            this.CALLETextBox.Name = "CALLETextBox";
            this.CALLETextBox.Size = new System.Drawing.Size(195, 20);
            this.CALLETextBox.TabIndex = 4;
            // 
            // COLONIATextBox
            // 
            this.COLONIATextBox.Location = new System.Drawing.Point(105, 47);
            this.COLONIATextBox.Name = "COLONIATextBox";
            this.COLONIATextBox.Size = new System.Drawing.Size(196, 20);
            this.COLONIATextBox.TabIndex = 7;
            // 
            // COLONIALabel
            // 
            this.COLONIALabel.AutoSize = true;
            this.COLONIALabel.Location = new System.Drawing.Point(46, 50);
            this.COLONIALabel.Name = "COLONIALabel";
            this.COLONIALabel.Size = new System.Drawing.Size(53, 13);
            this.COLONIALabel.TabIndex = 1;
            this.COLONIALabel.Text = "Colonia:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.AUTPRECIOLISTABAJOTextBox);
            this.tabPage2.Controls.Add(this.label320);
            this.tabPage2.Controls.Add(this.label318);
            this.tabPage2.Controls.Add(this.RUTAFIRMAIMAGENESTextBox);
            this.tabPage2.Controls.Add(this.HABVENTACLISUCTextBox);
            this.tabPage2.Controls.Add(this.label266);
            this.tabPage2.Controls.Add(this.HABFONDODINAMICOTextBox);
            this.tabPage2.Controls.Add(this.label265);
            this.tabPage2.Controls.Add(this.SOLOABONOAPLICADOTextBox);
            this.tabPage2.Controls.Add(this.lblSaldosAplicados);
            this.tabPage2.Controls.Add(this.AGRUPACIONVENTAIDButton);
            this.tabPage2.Controls.Add(this.AGRUPACIONVENTAIDLabel);
            this.tabPage2.Controls.Add(this.label250);
            this.tabPage2.Controls.Add(this.label175);
            this.tabPage2.Controls.Add(this.HABVENTASAFUTUROComboBox);
            this.tabPage2.Controls.Add(this.VENTASXCORTEEMAILTextBox);
            this.tabPage2.Controls.Add(this.label174);
            this.tabPage2.Controls.Add(this.label167);
            this.tabPage2.Controls.Add(this.PREGUNTACANCELACOTIZACIONTextBox);
            this.tabPage2.Controls.Add(this.label166);
            this.tabPage2.Controls.Add(this.HABILITARLOGComboBox);
            this.tabPage2.Controls.Add(this.label152);
            this.tabPage2.Controls.Add(this.MANEJARECETATextBox);
            this.tabPage2.Controls.Add(this.label105);
            this.tabPage2.Controls.Add(this.label104);
            this.tabPage2.Controls.Add(this.MANEJAALMACENTextBox);
            this.tabPage2.Controls.Add(this.label103);
            this.tabPage2.Controls.Add(this.MANEJASUPERLISTAPRECIOTextBox);
            this.tabPage2.Controls.Add(this.label102);
            this.tabPage2.Controls.Add(this.label101);
            this.tabPage2.Controls.Add(this.DIVIDIR_REM_FACTTextBox);
            this.tabPage2.Controls.Add(this.label100);
            this.tabPage2.Controls.Add(this.label95);
            this.tabPage2.Controls.Add(this.PREFIJOCLIENTETextBox);
            this.tabPage2.Controls.Add(this.MOSTRARIMAGENENVENTATextBox);
            this.tabPage2.Controls.Add(this.label87);
            this.tabPage2.Controls.Add(this.label86);
            this.tabPage2.Controls.Add(this.RUTAIMAGENESPRODUCTOTextBox);
            this.tabPage2.Controls.Add(this.PREGUNTARRAZONPRECIOMENORComboBox);
            this.tabPage2.Controls.Add(this.label78);
            this.tabPage2.Controls.Add(this.CORTEPORMAILTextBox);
            this.tabPage2.Controls.Add(this.label73);
            this.tabPage2.Controls.Add(this.ENVIOAUTOMATICOEXISTENCIASComboBox);
            this.tabPage2.Controls.Add(this.label63);
            this.tabPage2.Controls.Add(this.HAYVENDEDORPISOComboBox);
            this.tabPage2.Controls.Add(this.label62);
            this.tabPage2.Controls.Add(this.label61);
            this.tabPage2.Controls.Add(this.LISTAPRECIOINIMAYOComboBox);
            this.tabPage2.Controls.Add(this.label60);
            this.tabPage2.Controls.Add(this.label59);
            this.tabPage2.Controls.Add(this.label58);
            this.tabPage2.Controls.Add(this.PREFIJOBASCULATextBox);
            this.tabPage2.Controls.Add(this.HAB_FACTURAELECTRONICAComboBox);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.IMP_PROD_TOTALComboBox);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.REABRIRCORTESComboBox);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.REQ_APROBACION_INVComboBox);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.MOSTRAR_EXIS_SUCComboBox);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.HAB_IMPR_COTIZACIONComboBox);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.HAB_SEL_CLIENTEComboBox);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.CBCambiarPrecio);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.LISTA_PRECIO_DEFLabel);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.HABILITAR_IMPEXP_AUTComboBox);
            this.tabPage2.Controls.Add(this.LISTA_PRECIO_DEFTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.ID_DOSLETRASTextBox);
            this.tabPage2.Controls.Add(this.ESTADO_DEFLabel);
            this.tabPage2.Controls.Add(this.UltimaFecha);
            this.tabPage2.Controls.Add(this.IMP_PROD_DEFLabel);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.AGRUPACIONVENTAIDTextBox);
            this.tabPage2.Controls.Add(this.TIPODESCUENTOPRODIDTextBox);
            this.tabPage2.Controls.Add(this.MINUTILIDADTextBox);
            this.tabPage2.Controls.Add(this.ESTADO_DEFTextBox);
            this.tabPage2.Controls.Add(this.LONGPESOBASCULATextBox);
            this.tabPage2.Controls.Add(this.LONGPRODBASCULATextBox);
            this.tabPage2.Controls.Add(this.IMP_PROD_DEFTextBox);
            this.tabPage2.Controls.Add(this.SucursalComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Default";
            // 
            // AUTPRECIOLISTABAJOTextBox
            // 
            this.AUTPRECIOLISTABAJOTextBox.FormattingEnabled = true;
            this.AUTPRECIOLISTABAJOTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.AUTPRECIOLISTABAJOTextBox.Location = new System.Drawing.Point(490, 464);
            this.AUTPRECIOLISTABAJOTextBox.Name = "AUTPRECIOLISTABAJOTextBox";
            this.AUTPRECIOLISTABAJOTextBox.Size = new System.Drawing.Size(73, 21);
            this.AUTPRECIOLISTABAJOTextBox.TabIndex = 97;
            this.AUTPRECIOLISTABAJOTextBox.Tag = "";
            // 
            // label320
            // 
            this.label320.AutoSize = true;
            this.label320.Location = new System.Drawing.Point(323, 467);
            this.label320.Name = "label320";
            this.label320.Size = new System.Drawing.Size(160, 13);
            this.label320.TabIndex = 285;
            this.label320.Text = "Aut. Precios Lista Bajo Min";
            // 
            // label318
            // 
            this.label318.AutoSize = true;
            this.label318.Location = new System.Drawing.Point(50, 441);
            this.label318.Name = "label318";
            this.label318.Size = new System.Drawing.Size(75, 13);
            this.label318.TabIndex = 283;
            this.label318.Text = "Ruta firmas:";
            // 
            // RUTAFIRMAIMAGENESTextBox
            // 
            this.RUTAFIRMAIMAGENESTextBox.Location = new System.Drawing.Point(151, 438);
            this.RUTAFIRMAIMAGENESTextBox.Name = "RUTAFIRMAIMAGENESTextBox";
            this.RUTAFIRMAIMAGENESTextBox.Size = new System.Drawing.Size(158, 20);
            this.RUTAFIRMAIMAGENESTextBox.TabIndex = 282;
            // 
            // HABVENTACLISUCTextBox
            // 
            this.HABVENTACLISUCTextBox.FormattingEnabled = true;
            this.HABVENTACLISUCTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABVENTACLISUCTextBox.Location = new System.Drawing.Point(622, 245);
            this.HABVENTACLISUCTextBox.Name = "HABVENTACLISUCTextBox";
            this.HABVENTACLISUCTextBox.Size = new System.Drawing.Size(73, 21);
            this.HABVENTACLISUCTextBox.TabIndex = 280;
            this.HABVENTACLISUCTextBox.Tag = "";
            // 
            // label266
            // 
            this.label266.AutoSize = true;
            this.label266.Location = new System.Drawing.Point(581, 229);
            this.label266.Name = "label266";
            this.label266.Size = new System.Drawing.Size(200, 13);
            this.label266.TabIndex = 281;
            this.label266.Text = "Ventas directas a clientes de suc:";
            // 
            // HABFONDODINAMICOTextBox
            // 
            this.HABFONDODINAMICOTextBox.FormattingEnabled = true;
            this.HABFONDODINAMICOTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABFONDODINAMICOTextBox.Location = new System.Drawing.Point(622, 289);
            this.HABFONDODINAMICOTextBox.Name = "HABFONDODINAMICOTextBox";
            this.HABFONDODINAMICOTextBox.Size = new System.Drawing.Size(73, 21);
            this.HABFONDODINAMICOTextBox.TabIndex = 278;
            this.HABFONDODINAMICOTextBox.Tag = "";
            // 
            // label265
            // 
            this.label265.AutoSize = true;
            this.label265.Location = new System.Drawing.Point(614, 270);
            this.label265.Name = "label265";
            this.label265.Size = new System.Drawing.Size(156, 13);
            this.label265.TabIndex = 279;
            this.label265.Text = "Corte con fondo dinamico:";
            // 
            // SOLOABONOAPLICADOTextBox
            // 
            this.SOLOABONOAPLICADOTextBox.AutoSize = true;
            this.SOLOABONOAPLICADOTextBox.Location = new System.Drawing.Point(626, 489);
            this.SOLOABONOAPLICADOTextBox.Name = "SOLOABONOAPLICADOTextBox";
            this.SOLOABONOAPLICADOTextBox.Size = new System.Drawing.Size(15, 14);
            this.SOLOABONOAPLICADOTextBox.TabIndex = 277;
            this.SOLOABONOAPLICADOTextBox.UseVisualStyleBackColor = true;
            // 
            // lblSaldosAplicados
            // 
            this.lblSaldosAplicados.AutoSize = true;
            this.lblSaldosAplicados.Location = new System.Drawing.Point(624, 471);
            this.lblSaldosAplicados.Name = "lblSaldosAplicados";
            this.lblSaldosAplicados.Size = new System.Drawing.Size(136, 13);
            this.lblSaldosAplicados.TabIndex = 206;
            this.lblSaldosAplicados.Text = "Cheques postfechados";
            // 
            // AGRUPACIONVENTAIDButton
            // 
            this.AGRUPACIONVENTAIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.AGRUPACIONVENTAIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AGRUPACIONVENTAIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AGRUPACIONVENTAIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.AGRUPACIONVENTAIDButton.Location = new System.Drawing.Point(254, 523);
            this.AGRUPACIONVENTAIDButton.Name = "AGRUPACIONVENTAIDButton";
            this.AGRUPACIONVENTAIDButton.Size = new System.Drawing.Size(21, 23);
            this.AGRUPACIONVENTAIDButton.TabIndex = 204;
            this.AGRUPACIONVENTAIDButton.UseVisualStyleBackColor = true;
            // 
            // AGRUPACIONVENTAIDLabel
            // 
            this.AGRUPACIONVENTAIDLabel.AutoSize = true;
            this.AGRUPACIONVENTAIDLabel.Location = new System.Drawing.Point(280, 528);
            this.AGRUPACIONVENTAIDLabel.Name = "AGRUPACIONVENTAIDLabel";
            this.AGRUPACIONVENTAIDLabel.Size = new System.Drawing.Size(19, 13);
            this.AGRUPACIONVENTAIDLabel.TabIndex = 205;
            this.AGRUPACIONVENTAIDLabel.Text = "...";
            // 
            // label250
            // 
            this.label250.AutoSize = true;
            this.label250.Location = new System.Drawing.Point(2, 528);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(143, 13);
            this.label250.TabIndex = 202;
            this.label250.Text = "Agrupacion en la venta:";
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Location = new System.Drawing.Point(441, 64);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(129, 13);
            this.label175.TabIndex = 124;
            this.label175.Text = "Hab. Ventas a futuro:";
            // 
            // HABVENTASAFUTUROComboBox
            // 
            this.HABVENTASAFUTUROComboBox.FormattingEnabled = true;
            this.HABVENTASAFUTUROComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABVENTASAFUTUROComboBox.Location = new System.Drawing.Point(590, 61);
            this.HABVENTASAFUTUROComboBox.Name = "HABVENTASAFUTUROComboBox";
            this.HABVENTASAFUTUROComboBox.Size = new System.Drawing.Size(60, 21);
            this.HABVENTASAFUTUROComboBox.TabIndex = 123;
            // 
            // VENTASXCORTEEMAILTextBox
            // 
            this.VENTASXCORTEEMAILTextBox.FormattingEnabled = true;
            this.VENTASXCORTEEMAILTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.VENTASXCORTEEMAILTextBox.Location = new System.Drawing.Point(490, 170);
            this.VENTASXCORTEEMAILTextBox.Name = "VENTASXCORTEEMAILTextBox";
            this.VENTASXCORTEEMAILTextBox.Size = new System.Drawing.Size(73, 21);
            this.VENTASXCORTEEMAILTextBox.TabIndex = 121;
            this.VENTASXCORTEEMAILTextBox.Tag = "";
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Location = new System.Drawing.Point(335, 173);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(149, 13);
            this.label174.TabIndex = 122;
            this.label174.Text = "Ventas de corte por mail:";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(42, 287);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(102, 13);
            this.label167.TabIndex = 120;
            this.label167.Text = "al salir de venta:";
            // 
            // PREGUNTACANCELACOTIZACIONTextBox
            // 
            this.PREGUNTACANCELACOTIZACIONTextBox.FormattingEnabled = true;
            this.PREGUNTACANCELACOTIZACIONTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PREGUNTACANCELACOTIZACIONTextBox.Location = new System.Drawing.Point(151, 273);
            this.PREGUNTACANCELACOTIZACIONTextBox.Name = "PREGUNTACANCELACOTIZACIONTextBox";
            this.PREGUNTACANCELACOTIZACIONTextBox.Size = new System.Drawing.Size(73, 21);
            this.PREGUNTACANCELACOTIZACIONTextBox.TabIndex = 118;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(18, 270);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(126, 13);
            this.label166.TabIndex = 119;
            this.label166.Text = "Preg. Cancelar cotiz.";
            // 
            // HABILITARLOGComboBox
            // 
            this.HABILITARLOGComboBox.FormattingEnabled = true;
            this.HABILITARLOGComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABILITARLOGComboBox.Location = new System.Drawing.Point(151, 321);
            this.HABILITARLOGComboBox.Name = "HABILITARLOGComboBox";
            this.HABILITARLOGComboBox.Size = new System.Drawing.Size(73, 21);
            this.HABILITARLOGComboBox.TabIndex = 116;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(55, 324);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(89, 13);
            this.label152.TabIndex = 117;
            this.label152.Text = "Hab. Bitacora:";
            // 
            // MANEJARECETATextBox
            // 
            this.MANEJARECETATextBox.FormattingEnabled = true;
            this.MANEJARECETATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJARECETATextBox.Location = new System.Drawing.Point(622, 334);
            this.MANEJARECETATextBox.Name = "MANEJARECETATextBox";
            this.MANEJARECETATextBox.Size = new System.Drawing.Size(99, 21);
            this.MANEJARECETATextBox.TabIndex = 106;
            this.MANEJARECETATextBox.Tag = "";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(619, 318);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(92, 13);
            this.label105.TabIndex = 105;
            this.label105.Text = "Manejo receta:";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(619, 368);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(121, 13);
            this.label104.TabIndex = 103;
            this.label104.Text = "Manejo desc. Prod.:";
            // 
            // MANEJAALMACENTextBox
            // 
            this.MANEJAALMACENTextBox.FormattingEnabled = true;
            this.MANEJAALMACENTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJAALMACENTextBox.Location = new System.Drawing.Point(622, 435);
            this.MANEJAALMACENTextBox.Name = "MANEJAALMACENTextBox";
            this.MANEJAALMACENTextBox.Size = new System.Drawing.Size(99, 21);
            this.MANEJAALMACENTextBox.TabIndex = 100;
            this.MANEJAALMACENTextBox.Tag = "";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(619, 418);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(103, 13);
            this.label103.TabIndex = 101;
            this.label103.Text = "Maneja almacen:";
            // 
            // MANEJASUPERLISTAPRECIOTextBox
            // 
            this.MANEJASUPERLISTAPRECIOTextBox.FormattingEnabled = true;
            this.MANEJASUPERLISTAPRECIOTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJASUPERLISTAPRECIOTextBox.Location = new System.Drawing.Point(152, 496);
            this.MANEJASUPERLISTAPRECIOTextBox.Name = "MANEJASUPERLISTAPRECIOTextBox";
            this.MANEJASUPERLISTAPRECIOTextBox.Size = new System.Drawing.Size(72, 21);
            this.MANEJASUPERLISTAPRECIOTextBox.TabIndex = 98;
            this.MANEJASUPERLISTAPRECIOTextBox.Tag = "";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(11, 499);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(134, 13);
            this.label102.TabIndex = 99;
            this.label102.Text = "Super lista de precios:";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(388, 438);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(96, 13);
            this.label101.TabIndex = 97;
            this.label101.Text = "Utilidad minima:";
            // 
            // DIVIDIR_REM_FACTTextBox
            // 
            this.DIVIDIR_REM_FACTTextBox.FormattingEnabled = true;
            this.DIVIDIR_REM_FACTTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.DIVIDIR_REM_FACTTextBox.Location = new System.Drawing.Point(490, 406);
            this.DIVIDIR_REM_FACTTextBox.Name = "DIVIDIR_REM_FACTTextBox";
            this.DIVIDIR_REM_FACTTextBox.Size = new System.Drawing.Size(73, 21);
            this.DIVIDIR_REM_FACTTextBox.TabIndex = 94;
            this.DIVIDIR_REM_FACTTextBox.Tag = "";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(351, 409);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(133, 13);
            this.label100.TabIndex = 95;
            this.label100.Text = "Dividir rem de factura:";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(55, 470);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(89, 13);
            this.label95.TabIndex = 93;
            this.label95.Text = "Prefijo cliente:";
            // 
            // PREFIJOCLIENTETextBox
            // 
            this.PREFIJOCLIENTETextBox.Location = new System.Drawing.Point(151, 467);
            this.PREFIJOCLIENTETextBox.Name = "PREFIJOCLIENTETextBox";
            this.PREFIJOCLIENTETextBox.Size = new System.Drawing.Size(73, 20);
            this.PREFIJOCLIENTETextBox.TabIndex = 92;
            // 
            // MOSTRARIMAGENENVENTATextBox
            // 
            this.MOSTRARIMAGENENVENTATextBox.FormattingEnabled = true;
            this.MOSTRARIMAGENENVENTATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRARIMAGENENVENTATextBox.Location = new System.Drawing.Point(490, 378);
            this.MOSTRARIMAGENENVENTATextBox.Name = "MOSTRARIMAGENENVENTATextBox";
            this.MOSTRARIMAGENENVENTATextBox.Size = new System.Drawing.Size(73, 21);
            this.MOSTRARIMAGENENVENTATextBox.TabIndex = 90;
            this.MOSTRARIMAGENENVENTATextBox.Tag = "";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(372, 381);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(112, 13);
            this.label87.TabIndex = 91;
            this.label87.Text = "Mostrar foto prod.:";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(50, 414);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(95, 13);
            this.label86.TabIndex = 89;
            this.label86.Text = "Ruta imagenes:";
            // 
            // RUTAIMAGENESPRODUCTOTextBox
            // 
            this.RUTAIMAGENESPRODUCTOTextBox.Location = new System.Drawing.Point(151, 411);
            this.RUTAIMAGENESPRODUCTOTextBox.Name = "RUTAIMAGENESPRODUCTOTextBox";
            this.RUTAIMAGENESPRODUCTOTextBox.Size = new System.Drawing.Size(158, 20);
            this.RUTAIMAGENESPRODUCTOTextBox.TabIndex = 88;
            // 
            // PREGUNTARRAZONPRECIOMENORComboBox
            // 
            this.PREGUNTARRAZONPRECIOMENORComboBox.FormattingEnabled = true;
            this.PREGUNTARRAZONPRECIOMENORComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PREGUNTARRAZONPRECIOMENORComboBox.Location = new System.Drawing.Point(151, 381);
            this.PREGUNTARRAZONPRECIOMENORComboBox.Name = "PREGUNTARRAZONPRECIOMENORComboBox";
            this.PREGUNTARRAZONPRECIOMENORComboBox.Size = new System.Drawing.Size(73, 21);
            this.PREGUNTARRAZONPRECIOMENORComboBox.TabIndex = 86;
            this.PREGUNTARRAZONPRECIOMENORComboBox.Tag = "";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(25, 384);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(120, 13);
            this.label78.TabIndex = 87;
            this.label78.Text = "Preg. X precio bajo:";
            // 
            // CORTEPORMAILTextBox
            // 
            this.CORTEPORMAILTextBox.FormattingEnabled = true;
            this.CORTEPORMAILTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CORTEPORMAILTextBox.Location = new System.Drawing.Point(490, 144);
            this.CORTEPORMAILTextBox.Name = "CORTEPORMAILTextBox";
            this.CORTEPORMAILTextBox.Size = new System.Drawing.Size(73, 21);
            this.CORTEPORMAILTextBox.TabIndex = 83;
            this.CORTEPORMAILTextBox.Tag = "";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(395, 147);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(89, 13);
            this.label73.TabIndex = 85;
            this.label73.Text = "Corte por mail:";
            // 
            // ENVIOAUTOMATICOEXISTENCIASComboBox
            // 
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.FormattingEnabled = true;
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.Location = new System.Drawing.Point(490, 351);
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.Name = "ENVIOAUTOMATICOEXISTENCIASComboBox";
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.Size = new System.Drawing.Size(73, 21);
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.TabIndex = 82;
            this.ENVIOAUTOMATICOEXISTENCIASComboBox.Tag = "";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(346, 354);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(138, 13);
            this.label63.TabIndex = 83;
            this.label63.Text = "Envio Aut. Existencias:";
            // 
            // HAYVENDEDORPISOComboBox
            // 
            this.HAYVENDEDORPISOComboBox.FormattingEnabled = true;
            this.HAYVENDEDORPISOComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAYVENDEDORPISOComboBox.Location = new System.Drawing.Point(151, 351);
            this.HAYVENDEDORPISOComboBox.Name = "HAYVENDEDORPISOComboBox";
            this.HAYVENDEDORPISOComboBox.Size = new System.Drawing.Size(73, 21);
            this.HAYVENDEDORPISOComboBox.TabIndex = 80;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(28, 354);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(117, 13);
            this.label62.TabIndex = 81;
            this.label62.Text = "Hay vendedor piso:";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(349, 328);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(132, 13);
            this.label61.TabIndex = 79;
            this.label61.Text = "Lista mayoreo X peso:";
            // 
            // LISTAPRECIOINIMAYOComboBox
            // 
            this.LISTAPRECIOINIMAYOComboBox.FormattingEnabled = true;
            this.LISTAPRECIOINIMAYOComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOINIMAYOComboBox.Location = new System.Drawing.Point(490, 325);
            this.LISTAPRECIOINIMAYOComboBox.Name = "LISTAPRECIOINIMAYOComboBox";
            this.LISTAPRECIOINIMAYOComboBox.Size = new System.Drawing.Size(73, 21);
            this.LISTAPRECIOINIMAYOComboBox.TabIndex = 78;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(361, 278);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(123, 13);
            this.label60.TabIndex = 77;
            this.label60.Text = "Long. Peso bascula:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(358, 304);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(126, 13);
            this.label59.TabIndex = 76;
            this.label59.Text = "Long. Prod. Bascula:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(389, 252);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(95, 13);
            this.label58.TabIndex = 73;
            this.label58.Text = "Prefijo bascula:";
            // 
            // PREFIJOBASCULATextBox
            // 
            this.PREFIJOBASCULATextBox.Location = new System.Drawing.Point(490, 249);
            this.PREFIJOBASCULATextBox.Name = "PREFIJOBASCULATextBox";
            this.PREFIJOBASCULATextBox.Size = new System.Drawing.Size(73, 20);
            this.PREFIJOBASCULATextBox.TabIndex = 33;
            // 
            // HAB_FACTURAELECTRONICAComboBox
            // 
            this.HAB_FACTURAELECTRONICAComboBox.FormattingEnabled = true;
            this.HAB_FACTURAELECTRONICAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAB_FACTURAELECTRONICAComboBox.Location = new System.Drawing.Point(490, 223);
            this.HAB_FACTURAELECTRONICAComboBox.Name = "HAB_FACTURAELECTRONICAComboBox";
            this.HAB_FACTURAELECTRONICAComboBox.Size = new System.Drawing.Size(73, 21);
            this.HAB_FACTURAELECTRONICAComboBox.TabIndex = 31;
            this.HAB_FACTURAELECTRONICAComboBox.Tag = "";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(332, 226);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(152, 13);
            this.label34.TabIndex = 67;
            this.label34.Text = "Hab. Factura electronica:";
            // 
            // IMP_PROD_TOTALComboBox
            // 
            this.IMP_PROD_TOTALComboBox.FormattingEnabled = true;
            this.IMP_PROD_TOTALComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.IMP_PROD_TOTALComboBox.Location = new System.Drawing.Point(490, 196);
            this.IMP_PROD_TOTALComboBox.Name = "IMP_PROD_TOTALComboBox";
            this.IMP_PROD_TOTALComboBox.Size = new System.Drawing.Size(73, 21);
            this.IMP_PROD_TOTALComboBox.TabIndex = 30;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(365, 199);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(119, 13);
            this.label25.TabIndex = 64;
            this.label25.Text = "Imp. Total de prod.:";
            // 
            // REABRIRCORTESComboBox
            // 
            this.REABRIRCORTESComboBox.FormattingEnabled = true;
            this.REABRIRCORTESComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.REABRIRCORTESComboBox.Location = new System.Drawing.Point(490, 119);
            this.REABRIRCORTESComboBox.Name = "REABRIRCORTESComboBox";
            this.REABRIRCORTESComboBox.Size = new System.Drawing.Size(73, 21);
            this.REABRIRCORTESComboBox.TabIndex = 28;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(393, 122);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 13);
            this.label23.TabIndex = 60;
            this.label23.Text = "Reabrir cortes:";
            // 
            // REQ_APROBACION_INVComboBox
            // 
            this.REQ_APROBACION_INVComboBox.FormattingEnabled = true;
            this.REQ_APROBACION_INVComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.REQ_APROBACION_INVComboBox.Location = new System.Drawing.Point(490, 94);
            this.REQ_APROBACION_INVComboBox.Name = "REQ_APROBACION_INVComboBox";
            this.REQ_APROBACION_INVComboBox.Size = new System.Drawing.Size(73, 21);
            this.REQ_APROBACION_INVComboBox.TabIndex = 27;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(318, 97);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(166, 13);
            this.label22.TabIndex = 58;
            this.label22.Text = "Req. Aprobacion inventario:";
            // 
            // MOSTRAR_EXIS_SUCComboBox
            // 
            this.MOSTRAR_EXIS_SUCComboBox.FormattingEnabled = true;
            this.MOSTRAR_EXIS_SUCComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRAR_EXIS_SUCComboBox.Location = new System.Drawing.Point(151, 230);
            this.MOSTRAR_EXIS_SUCComboBox.Name = "MOSTRAR_EXIS_SUCComboBox";
            this.MOSTRAR_EXIS_SUCComboBox.Size = new System.Drawing.Size(73, 21);
            this.MOSTRAR_EXIS_SUCComboBox.TabIndex = 24;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(30, 233);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 13);
            this.label21.TabIndex = 56;
            this.label21.Text = "Mostrar exist. suc.:";
            // 
            // HAB_IMPR_COTIZACIONComboBox
            // 
            this.HAB_IMPR_COTIZACIONComboBox.FormattingEnabled = true;
            this.HAB_IMPR_COTIZACIONComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAB_IMPR_COTIZACIONComboBox.Location = new System.Drawing.Point(151, 204);
            this.HAB_IMPR_COTIZACIONComboBox.Name = "HAB_IMPR_COTIZACIONComboBox";
            this.HAB_IMPR_COTIZACIONComboBox.Size = new System.Drawing.Size(73, 21);
            this.HAB_IMPR_COTIZACIONComboBox.TabIndex = 23;
            this.HAB_IMPR_COTIZACIONComboBox.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(43, 207);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 13);
            this.label18.TabIndex = 54;
            this.label18.Text = "Impr. Cotizacion:";
            this.label18.Visible = false;
            // 
            // HAB_SEL_CLIENTEComboBox
            // 
            this.HAB_SEL_CLIENTEComboBox.FormattingEnabled = true;
            this.HAB_SEL_CLIENTEComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAB_SEL_CLIENTEComboBox.Location = new System.Drawing.Point(151, 177);
            this.HAB_SEL_CLIENTEComboBox.Name = "HAB_SEL_CLIENTEComboBox";
            this.HAB_SEL_CLIENTEComboBox.Size = new System.Drawing.Size(73, 21);
            this.HAB_SEL_CLIENTEComboBox.TabIndex = 22;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(37, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 13);
            this.label17.TabIndex = 52;
            this.label17.Text = "Hab. Sel. Cliente:";
            // 
            // CBCambiarPrecio
            // 
            this.CBCambiarPrecio.FormattingEnabled = true;
            this.CBCambiarPrecio.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CBCambiarPrecio.Location = new System.Drawing.Point(151, 150);
            this.CBCambiarPrecio.Name = "CBCambiarPrecio";
            this.CBCambiarPrecio.Size = new System.Drawing.Size(73, 21);
            this.CBCambiarPrecio.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Cambiar precio:";
            // 
            // LISTA_PRECIO_DEFLabel
            // 
            this.LISTA_PRECIO_DEFLabel.AutoSize = true;
            this.LISTA_PRECIO_DEFLabel.Location = new System.Drawing.Point(64, 8);
            this.LISTA_PRECIO_DEFLabel.Name = "LISTA_PRECIO_DEFLabel";
            this.LISTA_PRECIO_DEFLabel.Size = new System.Drawing.Size(77, 13);
            this.LISTA_PRECIO_DEFLabel.TabIndex = 19;
            this.LISTA_PRECIO_DEFLabel.Text = "Lista precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Hab. Imp. Exp, Aut.:";
            this.label5.Visible = false;
            // 
            // HABILITAR_IMPEXP_AUTComboBox
            // 
            this.HABILITAR_IMPEXP_AUTComboBox.FormattingEnabled = true;
            this.HABILITAR_IMPEXP_AUTComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABILITAR_IMPEXP_AUTComboBox.Location = new System.Drawing.Point(151, 122);
            this.HABILITAR_IMPEXP_AUTComboBox.Name = "HABILITAR_IMPEXP_AUTComboBox";
            this.HABILITAR_IMPEXP_AUTComboBox.Size = new System.Drawing.Size(73, 21);
            this.HABILITAR_IMPEXP_AUTComboBox.TabIndex = 20;
            this.HABILITAR_IMPEXP_AUTComboBox.Visible = false;
            // 
            // LISTA_PRECIO_DEFTextBox
            // 
            this.LISTA_PRECIO_DEFTextBox.FormattingEnabled = true;
            this.LISTA_PRECIO_DEFTextBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTA_PRECIO_DEFTextBox.Location = new System.Drawing.Point(151, 5);
            this.LISTA_PRECIO_DEFTextBox.Name = "LISTA_PRECIO_DEFTextBox";
            this.LISTA_PRECIO_DEFTextBox.Size = new System.Drawing.Size(182, 21);
            this.LISTA_PRECIO_DEFTextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "ID Pedidos:";
            // 
            // ID_DOSLETRASTextBox
            // 
            this.ID_DOSLETRASTextBox.Location = new System.Drawing.Point(151, 96);
            this.ID_DOSLETRASTextBox.MaxLength = 2;
            this.ID_DOSLETRASTextBox.Name = "ID_DOSLETRASTextBox";
            this.ID_DOSLETRASTextBox.Size = new System.Drawing.Size(73, 20);
            this.ID_DOSLETRASTextBox.TabIndex = 19;
            // 
            // ESTADO_DEFLabel
            // 
            this.ESTADO_DEFLabel.AutoSize = true;
            this.ESTADO_DEFLabel.Location = new System.Drawing.Point(94, 35);
            this.ESTADO_DEFLabel.Name = "ESTADO_DEFLabel";
            this.ESTADO_DEFLabel.Size = new System.Drawing.Size(50, 13);
            this.ESTADO_DEFLabel.TabIndex = 17;
            this.ESTADO_DEFLabel.Text = "Estado:";
            // 
            // UltimaFecha
            // 
            this.UltimaFecha.Location = new System.Drawing.Point(152, 62);
            this.UltimaFecha.Name = "UltimaFecha";
            this.UltimaFecha.Size = new System.Drawing.Size(233, 20);
            this.UltimaFecha.TabIndex = 18;
            // 
            // IMP_PROD_DEFLabel
            // 
            this.IMP_PROD_DEFLabel.AutoSize = true;
            this.IMP_PROD_DEFLabel.Location = new System.Drawing.Point(441, 8);
            this.IMP_PROD_DEFLabel.Name = "IMP_PROD_DEFLabel";
            this.IMP_PROD_DEFLabel.Size = new System.Drawing.Size(62, 13);
            this.IMP_PROD_DEFLabel.TabIndex = 18;
            this.IMP_PROD_DEFLabel.Text = "Impuesto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Ultima fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Sucursal:";
            // 
            // AGRUPACIONVENTAIDTextBox
            // 
            this.AGRUPACIONVENTAIDTextBox.BotonLookUp = this.AGRUPACIONVENTAIDButton;
            this.AGRUPACIONVENTAIDTextBox.Condicion = null;
            this.AGRUPACIONVENTAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.AGRUPACIONVENTAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.AGRUPACIONVENTAIDTextBox.DbValue = null;
            this.AGRUPACIONVENTAIDTextBox.Format_Expression = null;
            this.AGRUPACIONVENTAIDTextBox.IndiceCampoDescripcion = 2;
            this.AGRUPACIONVENTAIDTextBox.IndiceCampoSelector = 1;
            this.AGRUPACIONVENTAIDTextBox.IndiceCampoValue = 0;
            this.AGRUPACIONVENTAIDTextBox.LabelDescription = this.AGRUPACIONVENTAIDLabel;
            this.AGRUPACIONVENTAIDTextBox.Location = new System.Drawing.Point(151, 525);
            this.AGRUPACIONVENTAIDTextBox.MostrarErrores = true;
            this.AGRUPACIONVENTAIDTextBox.Name = "AGRUPACIONVENTAIDTextBox";
            this.AGRUPACIONVENTAIDTextBox.NombreCampoSelector = "clave";
            this.AGRUPACIONVENTAIDTextBox.NombreCampoValue = "id";
            this.AGRUPACIONVENTAIDTextBox.Query = "select  id, clave, nombre from agrupacionventa ";
            this.AGRUPACIONVENTAIDTextBox.QueryDeSeleccion = "select  id, clave, nombre from agrupacionventa where  clave = @clave";
            this.AGRUPACIONVENTAIDTextBox.QueryPorDBValue = "select  id, clave, nombre from agrupacionventa where  id = @id";
            this.AGRUPACIONVENTAIDTextBox.Size = new System.Drawing.Size(98, 20);
            this.AGRUPACIONVENTAIDTextBox.TabIndex = 203;
            this.AGRUPACIONVENTAIDTextBox.Tag = 34;
            this.AGRUPACIONVENTAIDTextBox.TextDescription = null;
            this.AGRUPACIONVENTAIDTextBox.Titulo = "Agrupacion de venta";
            this.AGRUPACIONVENTAIDTextBox.ValidarEntrada = true;
            this.AGRUPACIONVENTAIDTextBox.ValidationExpression = null;
            // 
            // TIPODESCUENTOPRODIDTextBox
            // 
            this.TIPODESCUENTOPRODIDTextBox.Condicion = null;
            this.TIPODESCUENTOPRODIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TIPODESCUENTOPRODIDTextBox.DisplayMember = "nombre";
            this.TIPODESCUENTOPRODIDTextBox.FormattingEnabled = true;
            this.TIPODESCUENTOPRODIDTextBox.IndiceCampoSelector = 0;
            this.TIPODESCUENTOPRODIDTextBox.LabelDescription = null;
            this.TIPODESCUENTOPRODIDTextBox.Location = new System.Drawing.Point(622, 384);
            this.TIPODESCUENTOPRODIDTextBox.Name = "TIPODESCUENTOPRODIDTextBox";
            this.TIPODESCUENTOPRODIDTextBox.NombreCampoSelector = "id";
            this.TIPODESCUENTOPRODIDTextBox.Query = "select id,nombre from tipodescuentoprod";
            this.TIPODESCUENTOPRODIDTextBox.QueryDeSeleccion = "select id,nombre from tipodescuentoprod where  id = @id";
            this.TIPODESCUENTOPRODIDTextBox.SelectedDataDisplaying = null;
            this.TIPODESCUENTOPRODIDTextBox.SelectedDataValue = null;
            this.TIPODESCUENTOPRODIDTextBox.Size = new System.Drawing.Size(110, 21);
            this.TIPODESCUENTOPRODIDTextBox.TabIndex = 102;
            this.TIPODESCUENTOPRODIDTextBox.ValueMember = "id";
            // 
            // MINUTILIDADTextBox
            // 
            this.MINUTILIDADTextBox.AllowNegative = false;
            this.MINUTILIDADTextBox.Format_Expression = null;
            this.MINUTILIDADTextBox.Location = new System.Drawing.Point(490, 435);
            this.MINUTILIDADTextBox.Name = "MINUTILIDADTextBox";
            this.MINUTILIDADTextBox.NumericPrecision = 5;
            this.MINUTILIDADTextBox.NumericScaleOnFocus = 2;
            this.MINUTILIDADTextBox.NumericScaleOnLostFocus = 2;
            this.MINUTILIDADTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MINUTILIDADTextBox.Size = new System.Drawing.Size(73, 20);
            this.MINUTILIDADTextBox.TabIndex = 96;
            this.MINUTILIDADTextBox.Tag = 34;
            this.MINUTILIDADTextBox.Text = "0.00";
            this.MINUTILIDADTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MINUTILIDADTextBox.ValidationExpression = null;
            this.MINUTILIDADTextBox.ZeroIsValid = true;
            // 
            // ESTADO_DEFTextBox
            // 
            this.ESTADO_DEFTextBox.Condicion = null;
            this.ESTADO_DEFTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ESTADO_DEFTextBox.DisplayMember = "nombre";
            this.ESTADO_DEFTextBox.FormattingEnabled = true;
            this.ESTADO_DEFTextBox.IndiceCampoSelector = 0;
            this.ESTADO_DEFTextBox.LabelDescription = null;
            this.ESTADO_DEFTextBox.Location = new System.Drawing.Point(151, 32);
            this.ESTADO_DEFTextBox.Name = "ESTADO_DEFTextBox";
            this.ESTADO_DEFTextBox.NombreCampoSelector = "id";
            this.ESTADO_DEFTextBox.Query = "select id,nombre from estado";
            this.ESTADO_DEFTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.ESTADO_DEFTextBox.SelectedDataDisplaying = null;
            this.ESTADO_DEFTextBox.SelectedDataValue = null;
            this.ESTADO_DEFTextBox.Size = new System.Drawing.Size(183, 21);
            this.ESTADO_DEFTextBox.TabIndex = 16;
            this.ESTADO_DEFTextBox.ValueMember = "id";
            // 
            // LONGPESOBASCULATextBox
            // 
            this.LONGPESOBASCULATextBox.AllowNegative = false;
            this.LONGPESOBASCULATextBox.Format_Expression = null;
            this.LONGPESOBASCULATextBox.Location = new System.Drawing.Point(490, 275);
            this.LONGPESOBASCULATextBox.Name = "LONGPESOBASCULATextBox";
            this.LONGPESOBASCULATextBox.NumericPrecision = 3;
            this.LONGPESOBASCULATextBox.NumericScaleOnFocus = 0;
            this.LONGPESOBASCULATextBox.NumericScaleOnLostFocus = 0;
            this.LONGPESOBASCULATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LONGPESOBASCULATextBox.Size = new System.Drawing.Size(73, 20);
            this.LONGPESOBASCULATextBox.TabIndex = 34;
            this.LONGPESOBASCULATextBox.Tag = 34;
            this.LONGPESOBASCULATextBox.Text = "0";
            this.LONGPESOBASCULATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LONGPESOBASCULATextBox.ValidationExpression = null;
            this.LONGPESOBASCULATextBox.ZeroIsValid = true;
            // 
            // LONGPRODBASCULATextBox
            // 
            this.LONGPRODBASCULATextBox.AllowNegative = false;
            this.LONGPRODBASCULATextBox.Format_Expression = null;
            this.LONGPRODBASCULATextBox.Location = new System.Drawing.Point(490, 301);
            this.LONGPRODBASCULATextBox.Name = "LONGPRODBASCULATextBox";
            this.LONGPRODBASCULATextBox.NumericPrecision = 3;
            this.LONGPRODBASCULATextBox.NumericScaleOnFocus = 0;
            this.LONGPRODBASCULATextBox.NumericScaleOnLostFocus = 0;
            this.LONGPRODBASCULATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LONGPRODBASCULATextBox.Size = new System.Drawing.Size(73, 20);
            this.LONGPRODBASCULATextBox.TabIndex = 26;
            this.LONGPRODBASCULATextBox.Tag = 34;
            this.LONGPRODBASCULATextBox.Text = "0";
            this.LONGPRODBASCULATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LONGPRODBASCULATextBox.ValidationExpression = null;
            this.LONGPRODBASCULATextBox.ZeroIsValid = true;
            // 
            // IMP_PROD_DEFTextBox
            // 
            this.IMP_PROD_DEFTextBox.AllowNegative = false;
            this.IMP_PROD_DEFTextBox.Format_Expression = null;
            this.IMP_PROD_DEFTextBox.Location = new System.Drawing.Point(509, 5);
            this.IMP_PROD_DEFTextBox.Name = "IMP_PROD_DEFTextBox";
            this.IMP_PROD_DEFTextBox.NumericPrecision = 5;
            this.IMP_PROD_DEFTextBox.NumericScaleOnFocus = 2;
            this.IMP_PROD_DEFTextBox.NumericScaleOnLostFocus = 2;
            this.IMP_PROD_DEFTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IMP_PROD_DEFTextBox.Size = new System.Drawing.Size(141, 20);
            this.IMP_PROD_DEFTextBox.TabIndex = 15;
            this.IMP_PROD_DEFTextBox.Tag = 34;
            this.IMP_PROD_DEFTextBox.Text = "0";
            this.IMP_PROD_DEFTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IMP_PROD_DEFTextBox.ValidationExpression = null;
            this.IMP_PROD_DEFTextBox.ZeroIsValid = true;
            // 
            // SucursalComboBox
            // 
            this.SucursalComboBox.Condicion = null;
            this.SucursalComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SucursalComboBox.DisplayMember = "clave";
            this.SucursalComboBox.FormattingEnabled = true;
            this.SucursalComboBox.IndiceCampoSelector = 0;
            this.SucursalComboBox.LabelDescription = null;
            this.SucursalComboBox.Location = new System.Drawing.Point(509, 32);
            this.SucursalComboBox.Name = "SucursalComboBox";
            this.SucursalComboBox.NombreCampoSelector = "";
            this.SucursalComboBox.Query = "select id,clave from sucursal";
            this.SucursalComboBox.QueryDeSeleccion = null;
            this.SucursalComboBox.SelectedDataDisplaying = null;
            this.SucursalComboBox.SelectedDataValue = null;
            this.SucursalComboBox.Size = new System.Drawing.Size(141, 21);
            this.SucursalComboBox.TabIndex = 17;
            this.SucursalComboBox.ValueMember = "id";
            this.SucursalComboBox.Enter += new System.EventHandler(this.SucursalComboBox_Enter);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.RUTAIMPORTADATOSTextBox);
            this.tabPage3.Controls.Add(this.label246);
            this.tabPage3.Controls.Add(this.RUTACATALOGOSUPDTextBox);
            this.tabPage3.Controls.Add(this.label243);
            this.tabPage3.Controls.Add(this.txtRutaReplicadorExe);
            this.tabPage3.Controls.Add(this.lblRutaReplicadorExe);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.WSESPECIALEXISTMATRIZTextBox);
            this.tabPage3.Controls.Add(this.label227);
            this.tabPage3.Controls.Add(this.VERSIONWSEXISTENCIASTextBox);
            this.tabPage3.Controls.Add(this.label223);
            this.tabPage3.Controls.Add(this.label222);
            this.tabPage3.Controls.Add(this.HAB_DEVOLUCIONSURTIDOSUCComboBox);
            this.tabPage3.Controls.Add(this.label220);
            this.tabPage3.Controls.Add(this.HAB_DEVOLUCIONTRASLADOComboBox);
            this.tabPage3.Controls.Add(this.txtRutaDBFExistenciaSuc);
            this.tabPage3.Controls.Add(this.label221);
            this.tabPage3.Controls.Add(this.label213);
            this.tabPage3.Controls.Add(this.unicaVisitaPorDoctoCheckBox);
            this.tabPage3.Controls.Add(this.label206);
            this.tabPage3.Controls.Add(this.WSMENSAJERIATextBox);
            this.tabPage3.Controls.Add(this.label205);
            this.tabPage3.Controls.Add(this.HABMENSAJERIAComboBox);
            this.tabPage3.Controls.Add(this.txtRutaAdjuntarArchivo);
            this.tabPage3.Controls.Add(this.label186);
            this.tabPage3.Controls.Add(this.label173);
            this.tabPage3.Controls.Add(this.MAILEJECUTIVOTextBox);
            this.tabPage3.Controls.Add(this.txtRutaRespaldo);
            this.tabPage3.Controls.Add(this.label153);
            this.tabPage3.Controls.Add(this.RUTAREPORTESSISTEMATextBox);
            this.tabPage3.Controls.Add(this.label146);
            this.tabPage3.Controls.Add(this.RUTARESPALDOSZIPTextBox);
            this.tabPage3.Controls.Add(this.label123);
            this.tabPage3.Controls.Add(this.label122);
            this.tabPage3.Controls.Add(this.MAILTOINVENTARIOTextBox);
            this.tabPage3.Controls.Add(this.USARCONEXIONLOCALTextBox);
            this.tabPage3.Controls.Add(this.label121);
            this.tabPage3.Controls.Add(this.label120);
            this.tabPage3.Controls.Add(this.LOCALWEBSERVICETextBox);
            this.tabPage3.Controls.Add(this.label119);
            this.tabPage3.Controls.Add(this.LOCALFTPHOSTTextBox);
            this.tabPage3.Controls.Add(this.WEBSERVICETextBox);
            this.tabPage3.Controls.Add(this.LABELWEBSERVICE);
            this.tabPage3.Controls.Add(this.FACT_ELECT_FOLDERTextBox);
            this.tabPage3.Controls.Add(this.label94);
            this.tabPage3.Controls.Add(this.PEDIDOS_FOLDERTextBox);
            this.tabPage3.Controls.Add(this.label93);
            this.tabPage3.Controls.Add(this.label89);
            this.tabPage3.Controls.Add(this.SMTPSSLComboBox);
            this.tabPage3.Controls.Add(this.RUTAREPORTESTextBox);
            this.tabPage3.Controls.Add(this.label74);
            this.tabPage3.Controls.Add(this.FTPFOLDERPASSTextBox);
            this.tabPage3.Controls.Add(this.label53);
            this.tabPage3.Controls.Add(this.FTPFOLDERTextBox);
            this.tabPage3.Controls.Add(this.label54);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.SMTPMAILTOTextBox);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.SMTPMAILFROMTextBox);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.SMTPPASSWORDTextBox);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.SMTPUSUARIOTextBox);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.SMTPHOSTTextBox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.FTPPASSWORDTextBox);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.FTPHOSTTextBox);
            this.tabPage3.Controls.Add(this.FTPUSUARIOTextBox);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.SMTPPORTTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(782, 556);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conexiones";
            // 
            // RUTAIMPORTADATOSTextBox
            // 
            this.RUTAIMPORTADATOSTextBox.Location = new System.Drawing.Point(171, 527);
            this.RUTAIMPORTADATOSTextBox.Name = "RUTAIMPORTADATOSTextBox";
            this.RUTAIMPORTADATOSTextBox.Size = new System.Drawing.Size(195, 20);
            this.RUTAIMPORTADATOSTextBox.TabIndex = 206;
            // 
            // label246
            // 
            this.label246.AutoSize = true;
            this.label246.Location = new System.Drawing.Point(7, 530);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(162, 13);
            this.label246.TabIndex = 207;
            this.label246.Text = "Ruta importacion traslados:";
            // 
            // RUTACATALOGOSUPDTextBox
            // 
            this.RUTACATALOGOSUPDTextBox.Location = new System.Drawing.Point(171, 501);
            this.RUTACATALOGOSUPDTextBox.Name = "RUTACATALOGOSUPDTextBox";
            this.RUTACATALOGOSUPDTextBox.Size = new System.Drawing.Size(195, 20);
            this.RUTACATALOGOSUPDTextBox.TabIndex = 204;
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Location = new System.Drawing.Point(7, 504);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(160, 13);
            this.label243.TabIndex = 205;
            this.label243.Text = "Ruta importacion catalogo:";
            // 
            // txtRutaReplicadorExe
            // 
            this.txtRutaReplicadorExe.Location = new System.Drawing.Point(541, 513);
            this.txtRutaReplicadorExe.Name = "txtRutaReplicadorExe";
            this.txtRutaReplicadorExe.Size = new System.Drawing.Size(195, 20);
            this.txtRutaReplicadorExe.TabIndex = 202;
            // 
            // lblRutaReplicadorExe
            // 
            this.lblRutaReplicadorExe.AutoSize = true;
            this.lblRutaReplicadorExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaReplicadorExe.Location = new System.Drawing.Point(419, 517);
            this.lblRutaReplicadorExe.Name = "lblRutaReplicadorExe";
            this.lblRutaReplicadorExe.Size = new System.Drawing.Size(110, 12);
            this.lblRutaReplicadorExe.TabIndex = 203;
            this.lblRutaReplicadorExe.Text = "Ruta replicador .EXE";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label132);
            this.groupBox2.Controls.Add(this.BDLOCALREPLTextBox);
            this.groupBox2.Controls.Add(this.HABILITARREPLTextBox);
            this.groupBox2.Controls.Add(this.label131);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(398, 419);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 93);
            this.groupBox2.TabIndex = 201;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replicacion (Viejo)";
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(12, 45);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(181, 13);
            this.label132.TabIndex = 115;
            this.label132.Text = "Conexion BD replicacion local:";
            // 
            // BDLOCALREPLTextBox
            // 
            this.BDLOCALREPLTextBox.Location = new System.Drawing.Point(15, 64);
            this.BDLOCALREPLTextBox.Name = "BDLOCALREPLTextBox";
            this.BDLOCALREPLTextBox.Size = new System.Drawing.Size(298, 20);
            this.BDLOCALREPLTextBox.TabIndex = 116;
            // 
            // HABILITARREPLTextBox
            // 
            this.HABILITARREPLTextBox.FormattingEnabled = true;
            this.HABILITARREPLTextBox.Items.AddRange(new object[] {
            "N",
            "S",
            "N",
            "S"});
            this.HABILITARREPLTextBox.Location = new System.Drawing.Point(142, 16);
            this.HABILITARREPLTextBox.Name = "HABILITARREPLTextBox";
            this.HABILITARREPLTextBox.Size = new System.Drawing.Size(81, 21);
            this.HABILITARREPLTextBox.TabIndex = 114;
            this.HABILITARREPLTextBox.Tag = "";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(16, 19);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(117, 13);
            this.label131.TabIndex = 113;
            this.label131.Text = "Replicacion activa:";
            // 
            // WSESPECIALEXISTMATRIZTextBox
            // 
            this.WSESPECIALEXISTMATRIZTextBox.Location = new System.Drawing.Point(171, 472);
            this.WSESPECIALEXISTMATRIZTextBox.Name = "WSESPECIALEXISTMATRIZTextBox";
            this.WSESPECIALEXISTMATRIZTextBox.Size = new System.Drawing.Size(195, 20);
            this.WSESPECIALEXISTMATRIZTextBox.TabIndex = 199;
            // 
            // label227
            // 
            this.label227.AutoSize = true;
            this.label227.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label227.Location = new System.Drawing.Point(34, 476);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(131, 12);
            this.label227.TabIndex = 200;
            this.label227.Text = "Webservice Esp. Matriz:";
            // 
            // VERSIONWSEXISTENCIASTextBox
            // 
            this.VERSIONWSEXISTENCIASTextBox.Location = new System.Drawing.Point(540, 335);
            this.VERSIONWSEXISTENCIASTextBox.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.VERSIONWSEXISTENCIASTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VERSIONWSEXISTENCIASTextBox.Name = "VERSIONWSEXISTENCIASTextBox";
            this.VERSIONWSEXISTENCIASTextBox.Size = new System.Drawing.Size(120, 20);
            this.VERSIONWSEXISTENCIASTextBox.TabIndex = 198;
            this.VERSIONWSEXISTENCIASTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Location = new System.Drawing.Point(392, 337);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(139, 13);
            this.label223.TabIndex = 197;
            this.label223.Text = "Version ws existencias:";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label222.Location = new System.Drawing.Point(410, 399);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(121, 12);
            this.label222.TabIndex = 196;
            this.label222.Text = "Hab. Envio devo. PM.:";
            // 
            // HAB_DEVOLUCIONSURTIDOSUCComboBox
            // 
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox.FormattingEnabled = true;
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Location = new System.Drawing.Point(540, 395);
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Name = "HAB_DEVOLUCIONSURTIDOSUCComboBox";
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Size = new System.Drawing.Size(81, 21);
            this.HAB_DEVOLUCIONSURTIDOSUCComboBox.TabIndex = 195;
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label220.Location = new System.Drawing.Point(396, 372);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(135, 12);
            this.label220.TabIndex = 194;
            this.label220.Text = "Hab. Envio devo. Trasla.:";
            // 
            // HAB_DEVOLUCIONTRASLADOComboBox
            // 
            this.HAB_DEVOLUCIONTRASLADOComboBox.FormattingEnabled = true;
            this.HAB_DEVOLUCIONTRASLADOComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAB_DEVOLUCIONTRASLADOComboBox.Location = new System.Drawing.Point(540, 368);
            this.HAB_DEVOLUCIONTRASLADOComboBox.Name = "HAB_DEVOLUCIONTRASLADOComboBox";
            this.HAB_DEVOLUCIONTRASLADOComboBox.Size = new System.Drawing.Size(81, 21);
            this.HAB_DEVOLUCIONTRASLADOComboBox.TabIndex = 193;
            // 
            // txtRutaDBFExistenciaSuc
            // 
            this.txtRutaDBFExistenciaSuc.Location = new System.Drawing.Point(171, 444);
            this.txtRutaDBFExistenciaSuc.Name = "txtRutaDBFExistenciaSuc";
            this.txtRutaDBFExistenciaSuc.Size = new System.Drawing.Size(195, 20);
            this.txtRutaDBFExistenciaSuc.TabIndex = 191;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(4, 447);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(162, 13);
            this.label221.TabIndex = 192;
            this.label221.Text = "Ruta DBF Existencias suc.:";
            // 
            // label213
            // 
            this.label213.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label213.Location = new System.Drawing.Point(415, 540);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(130, 15);
            this.label213.TabIndex = 190;
            this.label213.Text = "Unica visita por DOCTO";
            // 
            // unicaVisitaPorDoctoCheckBox
            // 
            this.unicaVisitaPorDoctoCheckBox.AutoSize = true;
            this.unicaVisitaPorDoctoCheckBox.Location = new System.Drawing.Point(551, 539);
            this.unicaVisitaPorDoctoCheckBox.Name = "unicaVisitaPorDoctoCheckBox";
            this.unicaVisitaPorDoctoCheckBox.Size = new System.Drawing.Size(15, 14);
            this.unicaVisitaPorDoctoCheckBox.TabIndex = 189;
            this.unicaVisitaPorDoctoCheckBox.UseVisualStyleBackColor = true;
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(431, 98);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(100, 13);
            this.label206.TabIndex = 127;
            this.label206.Text = "WS. Mensajeria:";
            // 
            // WSMENSAJERIATextBox
            // 
            this.WSMENSAJERIATextBox.Location = new System.Drawing.Point(540, 95);
            this.WSMENSAJERIATextBox.Name = "WSMENSAJERIATextBox";
            this.WSMENSAJERIATextBox.Size = new System.Drawing.Size(195, 20);
            this.WSMENSAJERIATextBox.TabIndex = 126;
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(428, 72);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(103, 13);
            this.label205.TabIndex = 125;
            this.label205.Text = "Hab. Mensajeria:";
            // 
            // HABMENSAJERIAComboBox
            // 
            this.HABMENSAJERIAComboBox.FormattingEnabled = true;
            this.HABMENSAJERIAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABMENSAJERIAComboBox.Location = new System.Drawing.Point(540, 69);
            this.HABMENSAJERIAComboBox.Name = "HABMENSAJERIAComboBox";
            this.HABMENSAJERIAComboBox.Size = new System.Drawing.Size(73, 21);
            this.HABMENSAJERIAComboBox.TabIndex = 124;
            // 
            // txtRutaAdjuntarArchivo
            // 
            this.txtRutaAdjuntarArchivo.Location = new System.Drawing.Point(540, 304);
            this.txtRutaAdjuntarArchivo.Name = "txtRutaAdjuntarArchivo";
            this.txtRutaAdjuntarArchivo.Size = new System.Drawing.Size(195, 20);
            this.txtRutaAdjuntarArchivo.TabIndex = 0;
            // 
            // label186
            // 
            this.label186.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            this.label186.Location = new System.Drawing.Point(404, 308);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(127, 23);
            this.label186.TabIndex = 1;
            this.label186.Text = "Ruta archivos adjuntos:";
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(441, 157);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(90, 13);
            this.label173.TabIndex = 123;
            this.label173.Text = "Mail ejecutivo:";
            // 
            // MAILEJECUTIVOTextBox
            // 
            this.MAILEJECUTIVOTextBox.Location = new System.Drawing.Point(540, 154);
            this.MAILEJECUTIVOTextBox.Name = "MAILEJECUTIVOTextBox";
            this.MAILEJECUTIVOTextBox.Size = new System.Drawing.Size(195, 20);
            this.MAILEJECUTIVOTextBox.TabIndex = 122;
            // 
            // txtRutaRespaldo
            // 
            this.txtRutaRespaldo.Location = new System.Drawing.Point(540, 244);
            this.txtRutaRespaldo.Name = "txtRutaRespaldo";
            this.txtRutaRespaldo.Size = new System.Drawing.Size(195, 20);
            this.txtRutaRespaldo.TabIndex = 121;
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(441, 247);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(90, 13);
            this.label153.TabIndex = 120;
            this.label153.Text = "Ruta respaldo:";
            // 
            // RUTAREPORTESSISTEMATextBox
            // 
            this.RUTAREPORTESSISTEMATextBox.Location = new System.Drawing.Point(540, 215);
            this.RUTAREPORTESSISTEMATextBox.Name = "RUTAREPORTESSISTEMATextBox";
            this.RUTAREPORTESSISTEMATextBox.Size = new System.Drawing.Size(195, 20);
            this.RUTAREPORTESSISTEMATextBox.TabIndex = 118;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(391, 218);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(140, 13);
            this.label146.TabIndex = 119;
            this.label146.Text = "Ruta reportes sistemas:";
            // 
            // RUTARESPALDOSZIPTextBox
            // 
            this.RUTARESPALDOSZIPTextBox.Location = new System.Drawing.Point(540, 183);
            this.RUTARESPALDOSZIPTextBox.Name = "RUTARESPALDOSZIPTextBox";
            this.RUTARESPALDOSZIPTextBox.Size = new System.Drawing.Size(195, 20);
            this.RUTARESPALDOSZIPTextBox.TabIndex = 115;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(402, 186);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(129, 13);
            this.label123.TabIndex = 116;
            this.label123.Text = "Ruta respaldos movil:";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(437, 125);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(94, 13);
            this.label122.TabIndex = 114;
            this.label122.Text = "Mail inventario:";
            // 
            // MAILTOINVENTARIOTextBox
            // 
            this.MAILTOINVENTARIOTextBox.Location = new System.Drawing.Point(540, 122);
            this.MAILTOINVENTARIOTextBox.Name = "MAILTOINVENTARIOTextBox";
            this.MAILTOINVENTARIOTextBox.Size = new System.Drawing.Size(195, 20);
            this.MAILTOINVENTARIOTextBox.TabIndex = 32;
            // 
            // USARCONEXIONLOCALTextBox
            // 
            this.USARCONEXIONLOCALTextBox.FormattingEnabled = true;
            this.USARCONEXIONLOCALTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.USARCONEXIONLOCALTextBox.Location = new System.Drawing.Point(540, 40);
            this.USARCONEXIONLOCALTextBox.Name = "USARCONEXIONLOCALTextBox";
            this.USARCONEXIONLOCALTextBox.Size = new System.Drawing.Size(73, 21);
            this.USARCONEXIONLOCALTextBox.TabIndex = 112;
            this.USARCONEXIONLOCALTextBox.Tag = "";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(408, 43);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(123, 13);
            this.label121.TabIndex = 111;
            this.label121.Text = "Usar conexión local:";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(421, 278);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(110, 13);
            this.label120.TabIndex = 106;
            this.label120.Text = "Local webservice:";
            // 
            // LOCALWEBSERVICETextBox
            // 
            this.LOCALWEBSERVICETextBox.Location = new System.Drawing.Point(540, 275);
            this.LOCALWEBSERVICETextBox.Name = "LOCALWEBSERVICETextBox";
            this.LOCALWEBSERVICETextBox.Size = new System.Drawing.Size(195, 20);
            this.LOCALWEBSERVICETextBox.TabIndex = 107;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(461, 19);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(70, 13);
            this.label119.TabIndex = 104;
            this.label119.Text = "Local host:";
            // 
            // LOCALFTPHOSTTextBox
            // 
            this.LOCALFTPHOSTTextBox.Location = new System.Drawing.Point(540, 16);
            this.LOCALFTPHOSTTextBox.Name = "LOCALFTPHOSTTextBox";
            this.LOCALFTPHOSTTextBox.Size = new System.Drawing.Size(195, 20);
            this.LOCALFTPHOSTTextBox.TabIndex = 105;
            // 
            // WEBSERVICETextBox
            // 
            this.WEBSERVICETextBox.Location = new System.Drawing.Point(171, 416);
            this.WEBSERVICETextBox.Name = "WEBSERVICETextBox";
            this.WEBSERVICETextBox.Size = new System.Drawing.Size(195, 20);
            this.WEBSERVICETextBox.TabIndex = 102;
            // 
            // LABELWEBSERVICE
            // 
            this.LABELWEBSERVICE.AutoSize = true;
            this.LABELWEBSERVICE.Location = new System.Drawing.Point(87, 419);
            this.LABELWEBSERVICE.Name = "LABELWEBSERVICE";
            this.LABELWEBSERVICE.Size = new System.Drawing.Size(78, 13);
            this.LABELWEBSERVICE.TabIndex = 103;
            this.LABELWEBSERVICE.Text = "Webservice:";
            // 
            // FACT_ELECT_FOLDERTextBox
            // 
            this.FACT_ELECT_FOLDERTextBox.Location = new System.Drawing.Point(171, 387);
            this.FACT_ELECT_FOLDERTextBox.Name = "FACT_ELECT_FOLDERTextBox";
            this.FACT_ELECT_FOLDERTextBox.Size = new System.Drawing.Size(195, 20);
            this.FACT_ELECT_FOLDERTextBox.TabIndex = 39;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(17, 390);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(149, 13);
            this.label94.TabIndex = 101;
            this.label94.Text = "Ruta factura electronica:";
            // 
            // PEDIDOS_FOLDERTextBox
            // 
            this.PEDIDOS_FOLDERTextBox.Location = new System.Drawing.Point(171, 358);
            this.PEDIDOS_FOLDERTextBox.Name = "PEDIDOS_FOLDERTextBox";
            this.PEDIDOS_FOLDERTextBox.Size = new System.Drawing.Size(195, 20);
            this.PEDIDOS_FOLDERTextBox.TabIndex = 38;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(79, 361);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(86, 13);
            this.label93.TabIndex = 99;
            this.label93.Text = "Ruta pedidos:";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(94, 193);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(72, 13);
            this.label89.TabIndex = 98;
            this.label89.Text = "SMTP SSL:";
            // 
            // SMTPSSLComboBox
            // 
            this.SMTPSSLComboBox.FormattingEnabled = true;
            this.SMTPSSLComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.SMTPSSLComboBox.Location = new System.Drawing.Point(172, 190);
            this.SMTPSSLComboBox.Name = "SMTPSSLComboBox";
            this.SMTPSSLComboBox.Size = new System.Drawing.Size(62, 21);
            this.SMTPSSLComboBox.TabIndex = 30;
            // 
            // RUTAREPORTESTextBox
            // 
            this.RUTAREPORTESTextBox.Location = new System.Drawing.Point(172, 330);
            this.RUTAREPORTESTextBox.Name = "RUTAREPORTESTextBox";
            this.RUTAREPORTESTextBox.Size = new System.Drawing.Size(195, 20);
            this.RUTAREPORTESTextBox.TabIndex = 37;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(45, 333);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(120, 13);
            this.label74.TabIndex = 37;
            this.label74.Text = "Ruta reportes pers.:";
            // 
            // FTPFOLDERPASSTextBox
            // 
            this.FTPFOLDERPASSTextBox.Location = new System.Drawing.Point(171, 302);
            this.FTPFOLDERPASSTextBox.Name = "FTPFOLDERPASSTextBox";
            this.FTPFOLDERPASSTextBox.PasswordChar = '*';
            this.FTPFOLDERPASSTextBox.Size = new System.Drawing.Size(195, 20);
            this.FTPFOLDERPASSTextBox.TabIndex = 36;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(50, 305);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(116, 13);
            this.label53.TabIndex = 34;
            this.label53.Text = "FTP Carpeta serial:";
            // 
            // FTPFOLDERTextBox
            // 
            this.FTPFOLDERTextBox.Location = new System.Drawing.Point(171, 275);
            this.FTPFOLDERTextBox.Name = "FTPFOLDERTextBox";
            this.FTPFOLDERTextBox.Size = new System.Drawing.Size(195, 20);
            this.FTPFOLDERTextBox.TabIndex = 35;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(83, 278);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(82, 13);
            this.label54.TabIndex = 33;
            this.label54.Text = "FTP Carpeta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "FTP Host:";
            // 
            // SMTPMAILTOTextBox
            // 
            this.SMTPMAILTOTextBox.Location = new System.Drawing.Point(172, 246);
            this.SMTPMAILTOTextBox.Name = "SMTPMAILTOTextBox";
            this.SMTPMAILTOTextBox.Size = new System.Drawing.Size(195, 20);
            this.SMTPMAILTOTextBox.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mail destino:";
            // 
            // SMTPMAILFROMTextBox
            // 
            this.SMTPMAILFROMTextBox.Location = new System.Drawing.Point(172, 220);
            this.SMTPMAILFROMTextBox.Name = "SMTPMAILFROMTextBox";
            this.SMTPMAILFROMTextBox.Size = new System.Drawing.Size(195, 20);
            this.SMTPMAILFROMTextBox.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mail fuente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "SMTP Port:";
            // 
            // SMTPPASSWORDTextBox
            // 
            this.SMTPPASSWORDTextBox.Location = new System.Drawing.Point(172, 141);
            this.SMTPPASSWORDTextBox.Name = "SMTPPASSWORDTextBox";
            this.SMTPPASSWORDTextBox.PasswordChar = '*';
            this.SMTPPASSWORDTextBox.Size = new System.Drawing.Size(195, 20);
            this.SMTPPASSWORDTextBox.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "SMTP Password:";
            // 
            // SMTPUSUARIOTextBox
            // 
            this.SMTPUSUARIOTextBox.Location = new System.Drawing.Point(172, 115);
            this.SMTPUSUARIOTextBox.Name = "SMTPUSUARIOTextBox";
            this.SMTPUSUARIOTextBox.Size = new System.Drawing.Size(195, 20);
            this.SMTPUSUARIOTextBox.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "SMTP Usuario:";
            // 
            // SMTPHOSTTextBox
            // 
            this.SMTPHOSTTextBox.Location = new System.Drawing.Point(172, 89);
            this.SMTPHOSTTextBox.Name = "SMTPHOSTTextBox";
            this.SMTPHOSTTextBox.Size = new System.Drawing.Size(195, 20);
            this.SMTPHOSTTextBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(91, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "SMTP Host:";
            // 
            // FTPPASSWORDTextBox
            // 
            this.FTPPASSWORDTextBox.Location = new System.Drawing.Point(172, 63);
            this.FTPPASSWORDTextBox.Name = "FTPPASSWORDTextBox";
            this.FTPPASSWORDTextBox.PasswordChar = '*';
            this.FTPPASSWORDTextBox.Size = new System.Drawing.Size(195, 20);
            this.FTPPASSWORDTextBox.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "FTP Password:";
            // 
            // FTPHOSTTextBox
            // 
            this.FTPHOSTTextBox.Location = new System.Drawing.Point(172, 13);
            this.FTPHOSTTextBox.Name = "FTPHOSTTextBox";
            this.FTPHOSTTextBox.Size = new System.Drawing.Size(195, 20);
            this.FTPHOSTTextBox.TabIndex = 23;
            // 
            // FTPUSUARIOTextBox
            // 
            this.FTPUSUARIOTextBox.Location = new System.Drawing.Point(172, 37);
            this.FTPUSUARIOTextBox.Name = "FTPUSUARIOTextBox";
            this.FTPUSUARIOTextBox.Size = new System.Drawing.Size(195, 20);
            this.FTPUSUARIOTextBox.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(84, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "FTP Usuario:";
            // 
            // SMTPPORTTextBox
            // 
            this.SMTPPORTTextBox.AllowNegative = false;
            this.SMTPPORTTextBox.Format_Expression = null;
            this.SMTPPORTTextBox.Location = new System.Drawing.Point(172, 164);
            this.SMTPPORTTextBox.Name = "SMTPPORTTextBox";
            this.SMTPPORTTextBox.NumericPrecision = 5;
            this.SMTPPORTTextBox.NumericScaleOnFocus = 0;
            this.SMTPPORTTextBox.NumericScaleOnLostFocus = 0;
            this.SMTPPORTTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SMTPPORTTextBox.Size = new System.Drawing.Size(116, 20);
            this.SMTPPORTTextBox.TabIndex = 29;
            this.SMTPPORTTextBox.Tag = 34;
            this.SMTPPORTTextBox.Text = "0";
            this.SMTPPORTTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SMTPPORTTextBox.ValidationExpression = null;
            this.SMTPPORTTextBox.ZeroIsValid = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage4.Controls.Add(this.label307);
            this.tabPage4.Controls.Add(this.label306);
            this.tabPage4.Controls.Add(this.TICKET_IMPR_DESC2ComboBox);
            this.tabPage4.Controls.Add(this.label293);
            this.tabPage4.Controls.Add(this.label292);
            this.tabPage4.Controls.Add(this.TICKET_DESC_VALE_AL_FINALComboBox);
            this.tabPage4.Controls.Add(this.label290);
            this.tabPage4.Controls.Add(this.label282);
            this.tabPage4.Controls.Add(this.label291);
            this.tabPage4.Controls.Add(this.label289);
            this.tabPage4.Controls.Add(this.label287);
            this.tabPage4.Controls.Add(this.label285);
            this.tabPage4.Controls.Add(this.label283);
            this.tabPage4.Controls.Add(this.label280);
            this.tabPage4.Controls.Add(this.label281);
            this.tabPage4.Controls.Add(this.label279);
            this.tabPage4.Controls.Add(this.label276);
            this.tabPage4.Controls.Add(this.label277);
            this.tabPage4.Controls.Add(this.label275);
            this.tabPage4.Controls.Add(this.label264);
            this.tabPage4.Controls.Add(this.RECIBOLARGOCOTIPRINTERTextBox);
            this.tabPage4.Controls.Add(this.label262);
            this.tabPage4.Controls.Add(this.IMPRFORMAVENTATRASLTextBox);
            this.tabPage4.Controls.Add(this.label261);
            this.tabPage4.Controls.Add(this.label255);
            this.tabPage4.Controls.Add(this.IMPR_CANC_VENTAComboBox);
            this.tabPage4.Controls.Add(this.label254);
            this.tabPage4.Controls.Add(this.IMPRIMIRBANCOSCORTEComboBox);
            this.tabPage4.Controls.Add(this.label251);
            this.tabPage4.Controls.Add(this.label244);
            this.tabPage4.Controls.Add(this.IMPRIMIRCOPIAALMACENComboBox);
            this.tabPage4.Controls.Add(this.label233);
            this.tabPage4.Controls.Add(this.PIEZACAJAENTICKETComboBox);
            this.tabPage4.Controls.Add(this.label232);
            this.tabPage4.Controls.Add(this.label231);
            this.tabPage4.Controls.Add(this.RECARGASDEFAULTPRINTERTextBox);
            this.tabPage4.Controls.Add(this.label230);
            this.tabPage4.Controls.Add(this.TICKETDEFAULTPRINTERTextBox);
            this.tabPage4.Controls.Add(this.label229);
            this.tabPage4.Controls.Add(this.TICKETESPECIALTextBox);
            this.tabPage4.Controls.Add(this.cmbPrecioDifInv);
            this.tabPage4.Controls.Add(this.label212);
            this.tabPage4.Controls.Add(this.label183);
            this.tabPage4.Controls.Add(this.cbHabVentasMostrador);
            this.tabPage4.Controls.Add(this.label181);
            this.tabPage4.Controls.Add(this.label182);
            this.tabPage4.Controls.Add(this.HABTRASLADOPORAUTORIZACIONComboBox);
            this.tabPage4.Controls.Add(this.label180);
            this.tabPage4.Controls.Add(this.label179);
            this.tabPage4.Controls.Add(this.HABIMPRESIONCORTECAJEROComboBox);
            this.tabPage4.Controls.Add(this.FORMATOTICKETCORTOIDComboBox);
            this.tabPage4.Controls.Add(this.label177);
            this.tabPage4.Controls.Add(this.REIMPRESIONESCONMARCAComboBox);
            this.tabPage4.Controls.Add(this.label148);
            this.tabPage4.Controls.Add(this.DOBLECOPIAREMISIONComboBox);
            this.tabPage4.Controls.Add(this.label147);
            this.tabPage4.Controls.Add(this.label143);
            this.tabPage4.Controls.Add(this.ABRIRCAJONALFINCORTEComboBox);
            this.tabPage4.Controls.Add(this.label142);
            this.tabPage4.Controls.Add(this.REQAUTELIMDETALLECOTIComboBox);
            this.tabPage4.Controls.Add(this.label141);
            this.tabPage4.Controls.Add(this.REQAUTCANCELARCOTIComboBox);
            this.tabPage4.Controls.Add(this.label140);
            this.tabPage4.Controls.Add(this.label126);
            this.tabPage4.Controls.Add(this.TAMANOLETRATICKETTextBox);
            this.tabPage4.Controls.Add(this.label125);
            this.tabPage4.Controls.Add(this.PROMOENTICKETComboBox);
            this.tabPage4.Controls.Add(this.ORDENIMPRESIONComboBox);
            this.tabPage4.Controls.Add(this.label115);
            this.tabPage4.Controls.Add(this.MOSTRARPZACAJAENFACTURAComboBox);
            this.tabPage4.Controls.Add(this.label97);
            this.tabPage4.Controls.Add(this.label96);
            this.tabPage4.Controls.Add(this.RECIBOLARGOCONFACTURAComboBox);
            this.tabPage4.Controls.Add(this.label92);
            this.tabPage4.Controls.Add(this.UIVENTACONCANTIDADComboBox);
            this.tabPage4.Controls.Add(this.label90);
            this.tabPage4.Controls.Add(this.MOSTRARDESCUENTOFACTURAComboBox);
            this.tabPage4.Controls.Add(this.label88);
            this.tabPage4.Controls.Add(this.MOSTRARMONTOAHORROComboBox);
            this.tabPage4.Controls.Add(this.PREGUNTARDATOSENTREGAComboBox);
            this.tabPage4.Controls.Add(this.label81);
            this.tabPage4.Controls.Add(this.label80);
            this.tabPage4.Controls.Add(this.RECIBOLARGOPREVIEWComboBox);
            this.tabPage4.Controls.Add(this.label79);
            this.tabPage4.Controls.Add(this.RECIBOLARGOPRINTERTextBox);
            this.tabPage4.Controls.Add(this.label76);
            this.tabPage4.Controls.Add(this.label75);
            this.tabPage4.Controls.Add(this.label67);
            this.tabPage4.Controls.Add(this.IMPRIMIRNUMEROPIEZASComboBox);
            this.tabPage4.Controls.Add(this.FOOTERVENTAAPARTADOTextBox);
            this.tabPage4.Controls.Add(this.label50);
            this.tabPage4.Controls.Add(this.FOOTERTextBox);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.HEADERTextBox);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.CANTTICKETCIERREBILLETESTextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETCIERRECORTETextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETABRIRCORTETextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETCOMPRASTextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETGASTOSTextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETFONDOCAJATextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETDEPOSITOSTextBox);
            this.tabPage4.Controls.Add(this.CANTTICKETRETIROTextBox);
            this.tabPage4.Controls.Add(this.DOBLECOPIATARJETATextBox);
            this.tabPage4.Controls.Add(this.DOBLECOPIACONTADOTextBox);
            this.tabPage4.Controls.Add(this.NUMTICKETSABONOTextBox);
            this.tabPage4.Controls.Add(this.PENDMAXDIASTextBox);
            this.tabPage4.Controls.Add(this.DOBLECOPIATRASLADOTextBox);
            this.tabPage4.Controls.Add(this.DOBLECOPIACREDITOTextBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(782, 556);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tickets";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // label307
            // 
            this.label307.AutoSize = true;
            this.label307.Location = new System.Drawing.Point(420, 367);
            this.label307.Name = "label307";
            this.label307.Size = new System.Drawing.Size(91, 13);
            this.label307.TabIndex = 317;
            this.label307.Text = "descripcion 2 :";
            // 
            // label306
            // 
            this.label306.AutoSize = true;
            this.label306.Location = new System.Drawing.Point(422, 352);
            this.label306.Name = "label306";
            this.label306.Size = new System.Drawing.Size(70, 13);
            this.label306.TabIndex = 316;
            this.label306.Text = "Ticket impr";
            // 
            // TICKET_IMPR_DESC2ComboBox
            // 
            this.TICKET_IMPR_DESC2ComboBox.FormattingEnabled = true;
            this.TICKET_IMPR_DESC2ComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.TICKET_IMPR_DESC2ComboBox.Location = new System.Drawing.Point(416, 383);
            this.TICKET_IMPR_DESC2ComboBox.Name = "TICKET_IMPR_DESC2ComboBox";
            this.TICKET_IMPR_DESC2ComboBox.Size = new System.Drawing.Size(86, 21);
            this.TICKET_IMPR_DESC2ComboBox.TabIndex = 315;
            // 
            // label293
            // 
            this.label293.AutoSize = true;
            this.label293.Location = new System.Drawing.Point(517, 365);
            this.label293.Name = "label293";
            this.label293.Size = new System.Drawing.Size(84, 13);
            this.label293.TabIndex = 314;
            this.label293.Text = "hasta el final:";
            // 
            // label292
            // 
            this.label292.AutoSize = true;
            this.label292.Location = new System.Drawing.Point(326, 365);
            this.label292.Name = "label292";
            this.label292.Size = new System.Drawing.Size(84, 13);
            this.label292.TabIndex = 313;
            this.label292.Text = "en traslados :";
            // 
            // TICKET_DESC_VALE_AL_FINALComboBox
            // 
            this.TICKET_DESC_VALE_AL_FINALComboBox.FormattingEnabled = true;
            this.TICKET_DESC_VALE_AL_FINALComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.TICKET_DESC_VALE_AL_FINALComboBox.Location = new System.Drawing.Point(531, 381);
            this.TICKET_DESC_VALE_AL_FINALComboBox.Name = "TICKET_DESC_VALE_AL_FINALComboBox";
            this.TICKET_DESC_VALE_AL_FINALComboBox.Size = new System.Drawing.Size(62, 21);
            this.TICKET_DESC_VALE_AL_FINALComboBox.TabIndex = 312;
            this.TICKET_DESC_VALE_AL_FINALComboBox.Tag = "";
            // 
            // label290
            // 
            this.label290.AutoSize = true;
            this.label290.Location = new System.Drawing.Point(517, 350);
            this.label290.Name = "label290";
            this.label290.Size = new System.Drawing.Size(97, 13);
            this.label290.TabIndex = 311;
            this.label290.Text = "Descuento Vale";
            // 
            // label282
            // 
            this.label282.AutoSize = true;
            this.label282.Location = new System.Drawing.Point(429, 215);
            this.label282.Name = "label282";
            this.label282.Size = new System.Drawing.Size(83, 13);
            this.label282.TabIndex = 310;
            this.label282.Text = "cierre billetes";
            // 
            // label291
            // 
            this.label291.AutoSize = true;
            this.label291.Location = new System.Drawing.Point(359, 215);
            this.label291.Name = "label291";
            this.label291.Size = new System.Drawing.Size(72, 13);
            this.label291.TabIndex = 308;
            this.label291.Text = "cierre corte";
            // 
            // label289
            // 
            this.label289.AutoSize = true;
            this.label289.Location = new System.Drawing.Point(290, 215);
            this.label289.Name = "label289";
            this.label289.Size = new System.Drawing.Size(65, 13);
            this.label289.TabIndex = 305;
            this.label289.Text = "abrir corte";
            // 
            // label287
            // 
            this.label287.AutoSize = true;
            this.label287.Location = new System.Drawing.Point(234, 215);
            this.label287.Name = "label287";
            this.label287.Size = new System.Drawing.Size(54, 13);
            this.label287.TabIndex = 302;
            this.label287.Text = "compras";
            // 
            // label285
            // 
            this.label285.AutoSize = true;
            this.label285.Location = new System.Drawing.Point(184, 215);
            this.label285.Name = "label285";
            this.label285.Size = new System.Drawing.Size(44, 13);
            this.label285.TabIndex = 299;
            this.label285.Text = "gastos";
            // 
            // label283
            // 
            this.label283.AutoSize = true;
            this.label283.Location = new System.Drawing.Point(116, 216);
            this.label283.Name = "label283";
            this.label283.Size = new System.Drawing.Size(67, 13);
            this.label283.TabIndex = 296;
            this.label283.Text = "fondo caja";
            // 
            // label280
            // 
            this.label280.AutoSize = true;
            this.label280.Location = new System.Drawing.Point(53, 215);
            this.label280.Name = "label280";
            this.label280.Size = new System.Drawing.Size(61, 13);
            this.label280.TabIndex = 293;
            this.label280.Text = "depositos";
            // 
            // label281
            // 
            this.label281.AutoSize = true;
            this.label281.Location = new System.Drawing.Point(9, 215);
            this.label281.Name = "label281";
            this.label281.Size = new System.Drawing.Size(36, 13);
            this.label281.TabIndex = 291;
            this.label281.Text = "retiro";
            // 
            // label279
            // 
            this.label279.AutoSize = true;
            this.label279.Location = new System.Drawing.Point(7, 200);
            this.label279.Name = "label279";
            this.label279.Size = new System.Drawing.Size(75, 13);
            this.label279.TabIndex = 288;
            this.label279.Text = "# de tickets";
            // 
            // label276
            // 
            this.label276.AutoSize = true;
            this.label276.Location = new System.Drawing.Point(245, 367);
            this.label276.Name = "label276";
            this.label276.Size = new System.Drawing.Size(33, 13);
            this.label276.TabIndex = 286;
            this.label276.Text = "tarj :";
            // 
            // label277
            // 
            this.label277.AutoSize = true;
            this.label277.Location = new System.Drawing.Point(245, 350);
            this.label277.Name = "label277";
            this.label277.Size = new System.Drawing.Size(75, 13);
            this.label277.TabIndex = 285;
            this.label277.Text = "# de tickets";
            // 
            // label275
            // 
            this.label275.AutoSize = true;
            this.label275.Location = new System.Drawing.Point(164, 367);
            this.label275.Name = "label275";
            this.label275.Size = new System.Drawing.Size(40, 13);
            this.label275.TabIndex = 283;
            this.label275.Text = "cred :";
            // 
            // label264
            // 
            this.label264.AutoSize = true;
            this.label264.Location = new System.Drawing.Point(606, 227);
            this.label264.Name = "label264";
            this.label264.Size = new System.Drawing.Size(165, 13);
            this.label264.TabIndex = 282;
            this.label264.Text = "Imp. ticket cotizacion largo:";
            // 
            // RECIBOLARGOCOTIPRINTERTextBox
            // 
            this.RECIBOLARGOCOTIPRINTERTextBox.Location = new System.Drawing.Point(609, 243);
            this.RECIBOLARGOCOTIPRINTERTextBox.Name = "RECIBOLARGOCOTIPRINTERTextBox";
            this.RECIBOLARGOCOTIPRINTERTextBox.Size = new System.Drawing.Size(157, 20);
            this.RECIBOLARGOCOTIPRINTERTextBox.TabIndex = 281;
            // 
            // label262
            // 
            this.label262.AutoSize = true;
            this.label262.Location = new System.Drawing.Point(496, 248);
            this.label262.Name = "label262";
            this.label262.Size = new System.Drawing.Size(70, 13);
            this.label262.TabIndex = 280;
            this.label262.Text = "en traslado";
            // 
            // IMPRFORMAVENTATRASLTextBox
            // 
            this.IMPRFORMAVENTATRASLTextBox.AutoSize = true;
            this.IMPRFORMAVENTATRASLTextBox.Location = new System.Drawing.Point(571, 250);
            this.IMPRFORMAVENTATRASLTextBox.Name = "IMPRFORMAVENTATRASLTextBox";
            this.IMPRFORMAVENTATRASLTextBox.Size = new System.Drawing.Size(15, 14);
            this.IMPRFORMAVENTATRASLTextBox.TabIndex = 279;
            this.IMPRFORMAVENTATRASLTextBox.UseVisualStyleBackColor = true;
            // 
            // label261
            // 
            this.label261.AutoSize = true;
            this.label261.Location = new System.Drawing.Point(484, 234);
            this.label261.Name = "label261";
            this.label261.Size = new System.Drawing.Size(88, 13);
            this.label261.TabIndex = 278;
            this.label261.Text = "Formato venta";
            // 
            // label255
            // 
            this.label255.AutoSize = true;
            this.label255.Location = new System.Drawing.Point(228, 264);
            this.label255.Name = "label255";
            this.label255.Size = new System.Drawing.Size(144, 13);
            this.label255.TabIndex = 193;
            this.label255.Text = "Imp. canc de remisiones";
            // 
            // IMPR_CANC_VENTAComboBox
            // 
            this.IMPR_CANC_VENTAComboBox.AutoSize = true;
            this.IMPR_CANC_VENTAComboBox.Checked = true;
            this.IMPR_CANC_VENTAComboBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IMPR_CANC_VENTAComboBox.Location = new System.Drawing.Point(276, 283);
            this.IMPR_CANC_VENTAComboBox.Name = "IMPR_CANC_VENTAComboBox";
            this.IMPR_CANC_VENTAComboBox.Size = new System.Drawing.Size(15, 14);
            this.IMPR_CANC_VENTAComboBox.TabIndex = 192;
            this.IMPR_CANC_VENTAComboBox.UseVisualStyleBackColor = true;
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Location = new System.Drawing.Point(484, 189);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(82, 26);
            this.label254.TabIndex = 191;
            this.label254.Text = "Imp. bancos\r\nen corte caja";
            // 
            // IMPRIMIRBANCOSCORTEComboBox
            // 
            this.IMPRIMIRBANCOSCORTEComboBox.AutoSize = true;
            this.IMPRIMIRBANCOSCORTEComboBox.Location = new System.Drawing.Point(572, 201);
            this.IMPRIMIRBANCOSCORTEComboBox.Name = "IMPRIMIRBANCOSCORTEComboBox";
            this.IMPRIMIRBANCOSCORTEComboBox.Size = new System.Drawing.Size(15, 14);
            this.IMPRIMIRBANCOSCORTEComboBox.TabIndex = 190;
            this.IMPRIMIRBANCOSCORTEComboBox.UseVisualStyleBackColor = true;
            // 
            // label251
            // 
            this.label251.AutoSize = true;
            this.label251.Location = new System.Drawing.Point(6, 513);
            this.label251.Name = "label251";
            this.label251.Size = new System.Drawing.Size(151, 13);
            this.label251.TabIndex = 188;
            this.label251.Text = "# de tickets en contado :";
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Location = new System.Drawing.Point(200, 512);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(140, 13);
            this.label244.TabIndex = 186;
            this.label244.Text = "Imprimir copia almacen:";
            // 
            // IMPRIMIRCOPIAALMACENComboBox
            // 
            this.IMPRIMIRCOPIAALMACENComboBox.FormattingEnabled = true;
            this.IMPRIMIRCOPIAALMACENComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.IMPRIMIRCOPIAALMACENComboBox.Location = new System.Drawing.Point(203, 528);
            this.IMPRIMIRCOPIAALMACENComboBox.Name = "IMPRIMIRCOPIAALMACENComboBox";
            this.IMPRIMIRCOPIAALMACENComboBox.Size = new System.Drawing.Size(79, 21);
            this.IMPRIMIRCOPIAALMACENComboBox.TabIndex = 185;
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Location = new System.Drawing.Point(387, 512);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(164, 13);
            this.label233.TabIndex = 184;
            this.label233.Text = "Copias por ticket de abono:";
            // 
            // PIEZACAJAENTICKETComboBox
            // 
            this.PIEZACAJAENTICKETComboBox.FormattingEnabled = true;
            this.PIEZACAJAENTICKETComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PIEZACAJAENTICKETComboBox.Location = new System.Drawing.Point(609, 529);
            this.PIEZACAJAENTICKETComboBox.Name = "PIEZACAJAENTICKETComboBox";
            this.PIEZACAJAENTICKETComboBox.Size = new System.Drawing.Size(72, 21);
            this.PIEZACAJAENTICKETComboBox.TabIndex = 181;
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Location = new System.Drawing.Point(606, 513);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(161, 13);
            this.label232.TabIndex = 182;
            this.label232.Text = "Mostrar pza/caja en ticket:";
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Location = new System.Drawing.Point(606, 264);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(162, 13);
            this.label231.TabIndex = 180;
            this.label231.Text = "Impresora default recargas:";
            // 
            // RECARGASDEFAULTPRINTERTextBox
            // 
            this.RECARGASDEFAULTPRINTERTextBox.Enabled = false;
            this.RECARGASDEFAULTPRINTERTextBox.Location = new System.Drawing.Point(609, 280);
            this.RECARGASDEFAULTPRINTERTextBox.Name = "RECARGASDEFAULTPRINTERTextBox";
            this.RECARGASDEFAULTPRINTERTextBox.Size = new System.Drawing.Size(157, 20);
            this.RECARGASDEFAULTPRINTERTextBox.TabIndex = 179;
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Location = new System.Drawing.Point(386, 264);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(145, 13);
            this.label230.TabIndex = 178;
            this.label230.Text = "Impresora default ticket:";
            // 
            // TICKETDEFAULTPRINTERTextBox
            // 
            this.TICKETDEFAULTPRINTERTextBox.Enabled = false;
            this.TICKETDEFAULTPRINTERTextBox.Location = new System.Drawing.Point(389, 280);
            this.TICKETDEFAULTPRINTERTextBox.Name = "TICKETDEFAULTPRINTERTextBox";
            this.TICKETDEFAULTPRINTERTextBox.Size = new System.Drawing.Size(157, 20);
            this.TICKETDEFAULTPRINTERTextBox.TabIndex = 177;
            // 
            // label229
            // 
            this.label229.AutoSize = true;
            this.label229.Location = new System.Drawing.Point(607, 465);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(102, 13);
            this.label229.TabIndex = 176;
            this.label229.Text = "Ticket especial :";
            // 
            // TICKETESPECIALTextBox
            // 
            this.TICKETESPECIALTextBox.Location = new System.Drawing.Point(610, 481);
            this.TICKETESPECIALTextBox.Name = "TICKETESPECIALTextBox";
            this.TICKETESPECIALTextBox.Size = new System.Drawing.Size(157, 20);
            this.TICKETESPECIALTextBox.TabIndex = 175;
            // 
            // cmbPrecioDifInv
            // 
            this.cmbPrecioDifInv.FormattingEnabled = true;
            this.cmbPrecioDifInv.Items.AddRange(new object[] {
            "PRECIO 1",
            "PRECIO 2\t",
            "PRECIO 3",
            "PRECIO 4",
            "PRECIO 5",
            "COSTO ULTIMO",
            "REPOSICION",
            "SIN PRECIO"});
            this.cmbPrecioDifInv.Location = new System.Drawing.Point(10, 280);
            this.cmbPrecioDifInv.Name = "cmbPrecioDifInv";
            this.cmbPrecioDifInv.Size = new System.Drawing.Size(185, 21);
            this.cmbPrecioDifInv.TabIndex = 173;
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(3, 264);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(216, 13);
            this.label212.TabIndex = 174;
            this.label212.Text = " Precio ajuste de diferencias invent.:";
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(483, 110);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(76, 26);
            this.label183.TabIndex = 171;
            this.label183.Text = "Hab. ventas\r\nmostrador";
            // 
            // cbHabVentasMostrador
            // 
            this.cbHabVentasMostrador.AutoSize = true;
            this.cbHabVentasMostrador.Location = new System.Drawing.Point(565, 122);
            this.cbHabVentasMostrador.Name = "cbHabVentasMostrador";
            this.cbHabVentasMostrador.Size = new System.Drawing.Size(15, 14);
            this.cbHabVentasMostrador.TabIndex = 172;
            this.cbHabVentasMostrador.UseVisualStyleBackColor = true;
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Location = new System.Drawing.Point(483, 68);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(102, 13);
            this.label181.TabIndex = 130;
            this.label181.Text = "por autorizacion:";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Location = new System.Drawing.Point(481, 54);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(103, 13);
            this.label182.TabIndex = 129;
            this.label182.Text = "Habilitar traslado";
            // 
            // HABTRASLADOPORAUTORIZACIONComboBox
            // 
            this.HABTRASLADOPORAUTORIZACIONComboBox.FormattingEnabled = true;
            this.HABTRASLADOPORAUTORIZACIONComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABTRASLADOPORAUTORIZACIONComboBox.Location = new System.Drawing.Point(487, 83);
            this.HABTRASLADOPORAUTORIZACIONComboBox.Name = "HABTRASLADOPORAUTORIZACIONComboBox";
            this.HABTRASLADOPORAUTORIZACIONComboBox.Size = new System.Drawing.Size(62, 21);
            this.HABTRASLADOPORAUTORIZACIONComboBox.TabIndex = 128;
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(484, 15);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(107, 13);
            this.label180.TabIndex = 127;
            this.label180.Text = "imprime  su corte:";
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Location = new System.Drawing.Point(484, 2);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(99, 13);
            this.label179.TabIndex = 126;
            this.label179.Text = "Cualquier cajero";
            // 
            // HABIMPRESIONCORTECAJEROComboBox
            // 
            this.HABIMPRESIONCORTECAJEROComboBox.FormattingEnabled = true;
            this.HABIMPRESIONCORTECAJEROComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABIMPRESIONCORTECAJEROComboBox.Location = new System.Drawing.Point(487, 28);
            this.HABIMPRESIONCORTECAJEROComboBox.Name = "HABIMPRESIONCORTECAJEROComboBox";
            this.HABIMPRESIONCORTECAJEROComboBox.Size = new System.Drawing.Size(62, 21);
            this.HABIMPRESIONCORTECAJEROComboBox.TabIndex = 125;
            // 
            // FORMATOTICKETCORTOIDComboBox
            // 
            this.FORMATOTICKETCORTOIDComboBox.FormattingEnabled = true;
            this.FORMATOTICKETCORTOIDComboBox.Items.AddRange(new object[] {
            "Normal",
            "Por Linea"});
            this.FORMATOTICKETCORTOIDComboBox.Location = new System.Drawing.Point(389, 325);
            this.FORMATOTICKETCORTOIDComboBox.Name = "FORMATOTICKETCORTOIDComboBox";
            this.FORMATOTICKETCORTOIDComboBox.Size = new System.Drawing.Size(86, 21);
            this.FORMATOTICKETCORTOIDComboBox.TabIndex = 123;
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(386, 309);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(129, 13);
            this.label177.TabIndex = 124;
            this.label177.Text = "Formato ticket corte :";
            // 
            // REIMPRESIONESCONMARCAComboBox
            // 
            this.REIMPRESIONESCONMARCAComboBox.FormattingEnabled = true;
            this.REIMPRESIONESCONMARCAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.REIMPRESIONESCONMARCAComboBox.Location = new System.Drawing.Point(203, 325);
            this.REIMPRESIONESCONMARCAComboBox.Name = "REIMPRESIONESCONMARCAComboBox";
            this.REIMPRESIONESCONMARCAComboBox.Size = new System.Drawing.Size(79, 21);
            this.REIMPRESIONESCONMARCAComboBox.TabIndex = 121;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Location = new System.Drawing.Point(200, 309);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(172, 13);
            this.label148.TabIndex = 122;
            this.label148.Text = "Reimpr. r. largo con marca? :";
            // 
            // DOBLECOPIAREMISIONComboBox
            // 
            this.DOBLECOPIAREMISIONComboBox.FormattingEnabled = true;
            this.DOBLECOPIAREMISIONComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.DOBLECOPIAREMISIONComboBox.Location = new System.Drawing.Point(10, 325);
            this.DOBLECOPIAREMISIONComboBox.Name = "DOBLECOPIAREMISIONComboBox";
            this.DOBLECOPIAREMISIONComboBox.Size = new System.Drawing.Size(89, 21);
            this.DOBLECOPIAREMISIONComboBox.TabIndex = 119;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(7, 309);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(188, 13);
            this.label147.TabIndex = 120;
            this.label147.Text = "Doble impr. remision (r. largo)? :";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(607, 9);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(155, 13);
            this.label143.TabIndex = 118;
            this.label143.Text = "Abrir cajon al cierre corte:";
            // 
            // ABRIRCAJONALFINCORTEComboBox
            // 
            this.ABRIRCAJONALFINCORTEComboBox.FormattingEnabled = true;
            this.ABRIRCAJONALFINCORTEComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.ABRIRCAJONALFINCORTEComboBox.Location = new System.Drawing.Point(610, 23);
            this.ABRIRCAJONALFINCORTEComboBox.Name = "ABRIRCAJONALFINCORTEComboBox";
            this.ABRIRCAJONALFINCORTEComboBox.Size = new System.Drawing.Size(71, 21);
            this.ABRIRCAJONALFINCORTEComboBox.TabIndex = 117;
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(607, 91);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(170, 13);
            this.label142.TabIndex = 116;
            this.label142.Text = "Req. Aut. Elim. Detalle Coti.:";
            // 
            // REQAUTELIMDETALLECOTIComboBox
            // 
            this.REQAUTELIMDETALLECOTIComboBox.FormattingEnabled = true;
            this.REQAUTELIMDETALLECOTIComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.REQAUTELIMDETALLECOTIComboBox.Location = new System.Drawing.Point(610, 109);
            this.REQAUTELIMDETALLECOTIComboBox.Name = "REQAUTELIMDETALLECOTIComboBox";
            this.REQAUTELIMDETALLECOTIComboBox.Size = new System.Drawing.Size(71, 21);
            this.REQAUTELIMDETALLECOTIComboBox.TabIndex = 115;
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(607, 47);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(148, 13);
            this.label141.TabIndex = 114;
            this.label141.Text = "Req. Aut. Cancelar coti.:";
            // 
            // REQAUTCANCELARCOTIComboBox
            // 
            this.REQAUTCANCELARCOTIComboBox.FormattingEnabled = true;
            this.REQAUTCANCELARCOTIComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.REQAUTCANCELARCOTIComboBox.Location = new System.Drawing.Point(610, 65);
            this.REQAUTCANCELARCOTIComboBox.Name = "REQAUTCANCELARCOTIComboBox";
            this.REQAUTCANCELARCOTIComboBox.Size = new System.Drawing.Size(71, 21);
            this.REQAUTCANCELARCOTIComboBox.TabIndex = 113;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(607, 137);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(162, 13);
            this.label140.TabIndex = 112;
            this.label140.Text = "Dias de ventas pendientes:";
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(481, 146);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(105, 13);
            this.label126.TabIndex = 110;
            this.label126.Text = "Letra en ticket? :";
            // 
            // TAMANOLETRATICKETTextBox
            // 
            this.TAMANOLETRATICKETTextBox.FormattingEnabled = true;
            this.TAMANOLETRATICKETTextBox.Items.AddRange(new object[] {
            "Normal",
            "Pequeña"});
            this.TAMANOLETRATICKETTextBox.Location = new System.Drawing.Point(484, 162);
            this.TAMANOLETRATICKETTextBox.Name = "TAMANOLETRATICKETTextBox";
            this.TAMANOLETRATICKETTextBox.Size = new System.Drawing.Size(97, 21);
            this.TAMANOLETRATICKETTextBox.TabIndex = 109;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(607, 185);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(131, 13);
            this.label125.TabIndex = 108;
            this.label125.Text = "Promocion en ticket?:";
            // 
            // PROMOENTICKETComboBox
            // 
            this.PROMOENTICKETComboBox.FormattingEnabled = true;
            this.PROMOENTICKETComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PROMOENTICKETComboBox.Location = new System.Drawing.Point(610, 201);
            this.PROMOENTICKETComboBox.Name = "PROMOENTICKETComboBox";
            this.PROMOENTICKETComboBox.Size = new System.Drawing.Size(71, 21);
            this.PROMOENTICKETComboBox.TabIndex = 107;
            // 
            // ORDENIMPRESIONComboBox
            // 
            this.ORDENIMPRESIONComboBox.FormattingEnabled = true;
            this.ORDENIMPRESIONComboBox.Items.AddRange(new object[] {
            "NORMAL",
            "DESCRIPCION",
            "DESCRIPCION1",
            "DESCRIPCION2"});
            this.ORDENIMPRESIONComboBox.Location = new System.Drawing.Point(610, 435);
            this.ORDENIMPRESIONComboBox.Name = "ORDENIMPRESIONComboBox";
            this.ORDENIMPRESIONComboBox.Size = new System.Drawing.Size(98, 21);
            this.ORDENIMPRESIONComboBox.TabIndex = 105;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(607, 419);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(102, 13);
            this.label115.TabIndex = 106;
            this.label115.Text = "Orden impresion:";
            // 
            // MOSTRARPZACAJAENFACTURAComboBox
            // 
            this.MOSTRARPZACAJAENFACTURAComboBox.FormattingEnabled = true;
            this.MOSTRARPZACAJAENFACTURAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRARPZACAJAENFACTURAComboBox.Location = new System.Drawing.Point(631, 383);
            this.MOSTRARPZACAJAENFACTURAComboBox.Name = "MOSTRARPZACAJAENFACTURAComboBox";
            this.MOSTRARPZACAJAENFACTURAComboBox.Size = new System.Drawing.Size(71, 21);
            this.MOSTRARPZACAJAENFACTURAComboBox.TabIndex = 11;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(627, 367);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(155, 13);
            this.label97.TabIndex = 104;
            this.label97.Text = "Mostrar pza/caja en fact.:";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(386, 419);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(159, 13);
            this.label96.TabIndex = 102;
            this.label96.Text = "Ticket junto con factura? :";
            // 
            // RECIBOLARGOCONFACTURAComboBox
            // 
            this.RECIBOLARGOCONFACTURAComboBox.FormattingEnabled = true;
            this.RECIBOLARGOCONFACTURAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.RECIBOLARGOCONFACTURAComboBox.Location = new System.Drawing.Point(389, 435);
            this.RECIBOLARGOCONFACTURAComboBox.Name = "RECIBOLARGOCONFACTURAComboBox";
            this.RECIBOLARGOCONFACTURAComboBox.Size = new System.Drawing.Size(86, 21);
            this.RECIBOLARGOCONFACTURAComboBox.TabIndex = 10;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(386, 465);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(195, 13);
            this.label92.TabIndex = 100;
            this.label92.Text = "UI Ingresar cantidad en la venta:";
            // 
            // UIVENTACONCANTIDADComboBox
            // 
            this.UIVENTACONCANTIDADComboBox.FormattingEnabled = true;
            this.UIVENTACONCANTIDADComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.UIVENTACONCANTIDADComboBox.Location = new System.Drawing.Point(389, 481);
            this.UIVENTACONCANTIDADComboBox.Name = "UIVENTACONCANTIDADComboBox";
            this.UIVENTACONCANTIDADComboBox.Size = new System.Drawing.Size(86, 21);
            this.UIVENTACONCANTIDADComboBox.TabIndex = 14;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(200, 465);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(153, 13);
            this.label90.TabIndex = 98;
            this.label90.Text = "Mostrar descuent en fact:";
            // 
            // MOSTRARDESCUENTOFACTURAComboBox
            // 
            this.MOSTRARDESCUENTOFACTURAComboBox.FormattingEnabled = true;
            this.MOSTRARDESCUENTOFACTURAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRARDESCUENTOFACTURAComboBox.Location = new System.Drawing.Point(203, 481);
            this.MOSTRARDESCUENTOFACTURAComboBox.Name = "MOSTRARDESCUENTOFACTURAComboBox";
            this.MOSTRARDESCUENTOFACTURAComboBox.Size = new System.Drawing.Size(79, 21);
            this.MOSTRARDESCUENTOFACTURAComboBox.TabIndex = 13;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(7, 465);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(149, 13);
            this.label88.TabIndex = 96;
            this.label88.Text = "Mostrar monto de ahorro:";
            // 
            // MOSTRARMONTOAHORROComboBox
            // 
            this.MOSTRARMONTOAHORROComboBox.FormattingEnabled = true;
            this.MOSTRARMONTOAHORROComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRARMONTOAHORROComboBox.Location = new System.Drawing.Point(10, 481);
            this.MOSTRARMONTOAHORROComboBox.Name = "MOSTRARMONTOAHORROComboBox";
            this.MOSTRARMONTOAHORROComboBox.Size = new System.Drawing.Size(89, 21);
            this.MOSTRARMONTOAHORROComboBox.TabIndex = 12;
            // 
            // PREGUNTARDATOSENTREGAComboBox
            // 
            this.PREGUNTARDATOSENTREGAComboBox.FormattingEnabled = true;
            this.PREGUNTARDATOSENTREGAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PREGUNTARDATOSENTREGAComboBox.Location = new System.Drawing.Point(610, 325);
            this.PREGUNTARDATOSENTREGAComboBox.Name = "PREGUNTARDATOSENTREGAComboBox";
            this.PREGUNTARDATOSENTREGAComboBox.Size = new System.Drawing.Size(71, 21);
            this.PREGUNTARDATOSENTREGAComboBox.TabIndex = 7;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(606, 309);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(177, 13);
            this.label81.TabIndex = 94;
            this.label81.Text = "Preguntar datos de entrega? :";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(200, 419);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(172, 13);
            this.label80.TabIndex = 93;
            this.label80.Text = "Mostrar previo (ticket largo) :";
            // 
            // RECIBOLARGOPREVIEWComboBox
            // 
            this.RECIBOLARGOPREVIEWComboBox.FormattingEnabled = true;
            this.RECIBOLARGOPREVIEWComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.RECIBOLARGOPREVIEWComboBox.Location = new System.Drawing.Point(203, 435);
            this.RECIBOLARGOPREVIEWComboBox.Name = "RECIBOLARGOPREVIEWComboBox";
            this.RECIBOLARGOPREVIEWComboBox.Size = new System.Drawing.Size(79, 21);
            this.RECIBOLARGOPREVIEWComboBox.TabIndex = 9;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(7, 419);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(134, 13);
            this.label79.TabIndex = 90;
            this.label79.Text = "Impresora ticket largo:";
            // 
            // RECIBOLARGOPRINTERTextBox
            // 
            this.RECIBOLARGOPRINTERTextBox.Location = new System.Drawing.Point(10, 435);
            this.RECIBOLARGOPRINTERTextBox.Name = "RECIBOLARGOPRINTERTextBox";
            this.RECIBOLARGOPRINTERTextBox.Size = new System.Drawing.Size(157, 20);
            this.RECIBOLARGOPRINTERTextBox.TabIndex = 8;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(325, 349);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(75, 13);
            this.label76.TabIndex = 87;
            this.label76.Text = "# de tickets";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(164, 350);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(75, 13);
            this.label75.TabIndex = 85;
            this.label75.Text = "# de tickets";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(7, 366);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(140, 13);
            this.label67.TabIndex = 83;
            this.label67.Text = "Imprimir cantidad total :";
            // 
            // IMPRIMIRNUMEROPIEZASComboBox
            // 
            this.IMPRIMIRNUMEROPIEZASComboBox.FormattingEnabled = true;
            this.IMPRIMIRNUMEROPIEZASComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.IMPRIMIRNUMEROPIEZASComboBox.Location = new System.Drawing.Point(10, 381);
            this.IMPRIMIRNUMEROPIEZASComboBox.Name = "IMPRIMIRNUMEROPIEZASComboBox";
            this.IMPRIMIRNUMEROPIEZASComboBox.Size = new System.Drawing.Size(89, 21);
            this.IMPRIMIRNUMEROPIEZASComboBox.TabIndex = 4;
            // 
            // FOOTERVENTAAPARTADOTextBox
            // 
            this.FOOTERVENTAAPARTADOTextBox.Location = new System.Drawing.Point(9, 152);
            this.FOOTERVENTAAPARTADOTextBox.Multiline = true;
            this.FOOTERVENTAAPARTADOTextBox.Name = "FOOTERVENTAAPARTADOTextBox";
            this.FOOTERVENTAAPARTADOTextBox.Size = new System.Drawing.Size(465, 42);
            this.FOOTERVENTAAPARTADOTextBox.TabIndex = 3;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(7, 137);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(166, 13);
            this.label50.TabIndex = 4;
            this.label50.Text = "Texto footer venta apartado";
            // 
            // FOOTERTextBox
            // 
            this.FOOTERTextBox.Location = new System.Drawing.Point(10, 87);
            this.FOOTERTextBox.Multiline = true;
            this.FOOTERTextBox.Name = "FOOTERTextBox";
            this.FOOTERTextBox.Size = new System.Drawing.Size(465, 42);
            this.FOOTERTextBox.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Texto footer";
            // 
            // HEADERTextBox
            // 
            this.HEADERTextBox.Location = new System.Drawing.Point(10, 25);
            this.HEADERTextBox.Multiline = true;
            this.HEADERTextBox.Name = "HEADERTextBox";
            this.HEADERTextBox.Size = new System.Drawing.Size(465, 42);
            this.HEADERTextBox.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Texto encabezado";
            // 
            // CANTTICKETCIERREBILLETESTextBox
            // 
            this.CANTTICKETCIERREBILLETESTextBox.AllowNegative = false;
            this.CANTTICKETCIERREBILLETESTextBox.Format_Expression = null;
            this.CANTTICKETCIERREBILLETESTextBox.Location = new System.Drawing.Point(432, 232);
            this.CANTTICKETCIERREBILLETESTextBox.Name = "CANTTICKETCIERREBILLETESTextBox";
            this.CANTTICKETCIERREBILLETESTextBox.NumericPrecision = 3;
            this.CANTTICKETCIERREBILLETESTextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETCIERREBILLETESTextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETCIERREBILLETESTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETCIERREBILLETESTextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETCIERREBILLETESTextBox.TabIndex = 309;
            this.CANTTICKETCIERREBILLETESTextBox.Tag = 34;
            this.CANTTICKETCIERREBILLETESTextBox.Text = "0";
            this.CANTTICKETCIERREBILLETESTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETCIERREBILLETESTextBox.ValidationExpression = null;
            this.CANTTICKETCIERREBILLETESTextBox.ZeroIsValid = true;
            // 
            // CANTTICKETCIERRECORTETextBox
            // 
            this.CANTTICKETCIERRECORTETextBox.AllowNegative = false;
            this.CANTTICKETCIERRECORTETextBox.Format_Expression = null;
            this.CANTTICKETCIERRECORTETextBox.Location = new System.Drawing.Point(364, 232);
            this.CANTTICKETCIERRECORTETextBox.Name = "CANTTICKETCIERRECORTETextBox";
            this.CANTTICKETCIERRECORTETextBox.NumericPrecision = 3;
            this.CANTTICKETCIERRECORTETextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETCIERRECORTETextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETCIERRECORTETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETCIERRECORTETextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETCIERRECORTETextBox.TabIndex = 306;
            this.CANTTICKETCIERRECORTETextBox.Tag = 34;
            this.CANTTICKETCIERRECORTETextBox.Text = "0";
            this.CANTTICKETCIERRECORTETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETCIERRECORTETextBox.ValidationExpression = null;
            this.CANTTICKETCIERRECORTETextBox.ZeroIsValid = true;
            // 
            // CANTTICKETABRIRCORTETextBox
            // 
            this.CANTTICKETABRIRCORTETextBox.AllowNegative = false;
            this.CANTTICKETABRIRCORTETextBox.Format_Expression = null;
            this.CANTTICKETABRIRCORTETextBox.Location = new System.Drawing.Point(294, 232);
            this.CANTTICKETABRIRCORTETextBox.Name = "CANTTICKETABRIRCORTETextBox";
            this.CANTTICKETABRIRCORTETextBox.NumericPrecision = 3;
            this.CANTTICKETABRIRCORTETextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETABRIRCORTETextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETABRIRCORTETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETABRIRCORTETextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETABRIRCORTETextBox.TabIndex = 303;
            this.CANTTICKETABRIRCORTETextBox.Tag = 34;
            this.CANTTICKETABRIRCORTETextBox.Text = "0";
            this.CANTTICKETABRIRCORTETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETABRIRCORTETextBox.ValidationExpression = null;
            this.CANTTICKETABRIRCORTETextBox.ZeroIsValid = true;
            // 
            // CANTTICKETCOMPRASTextBox
            // 
            this.CANTTICKETCOMPRASTextBox.AllowNegative = false;
            this.CANTTICKETCOMPRASTextBox.Format_Expression = null;
            this.CANTTICKETCOMPRASTextBox.Location = new System.Drawing.Point(232, 232);
            this.CANTTICKETCOMPRASTextBox.Name = "CANTTICKETCOMPRASTextBox";
            this.CANTTICKETCOMPRASTextBox.NumericPrecision = 3;
            this.CANTTICKETCOMPRASTextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETCOMPRASTextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETCOMPRASTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETCOMPRASTextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETCOMPRASTextBox.TabIndex = 300;
            this.CANTTICKETCOMPRASTextBox.Tag = 34;
            this.CANTTICKETCOMPRASTextBox.Text = "0";
            this.CANTTICKETCOMPRASTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETCOMPRASTextBox.ValidationExpression = null;
            this.CANTTICKETCOMPRASTextBox.ZeroIsValid = true;
            // 
            // CANTTICKETGASTOSTextBox
            // 
            this.CANTTICKETGASTOSTextBox.AllowNegative = false;
            this.CANTTICKETGASTOSTextBox.Format_Expression = null;
            this.CANTTICKETGASTOSTextBox.Location = new System.Drawing.Point(182, 232);
            this.CANTTICKETGASTOSTextBox.Name = "CANTTICKETGASTOSTextBox";
            this.CANTTICKETGASTOSTextBox.NumericPrecision = 3;
            this.CANTTICKETGASTOSTextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETGASTOSTextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETGASTOSTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETGASTOSTextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETGASTOSTextBox.TabIndex = 297;
            this.CANTTICKETGASTOSTextBox.Tag = 34;
            this.CANTTICKETGASTOSTextBox.Text = "0";
            this.CANTTICKETGASTOSTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETGASTOSTextBox.ValidationExpression = null;
            this.CANTTICKETGASTOSTextBox.ZeroIsValid = true;
            // 
            // CANTTICKETFONDOCAJATextBox
            // 
            this.CANTTICKETFONDOCAJATextBox.AllowNegative = false;
            this.CANTTICKETFONDOCAJATextBox.Format_Expression = null;
            this.CANTTICKETFONDOCAJATextBox.Location = new System.Drawing.Point(123, 233);
            this.CANTTICKETFONDOCAJATextBox.Name = "CANTTICKETFONDOCAJATextBox";
            this.CANTTICKETFONDOCAJATextBox.NumericPrecision = 3;
            this.CANTTICKETFONDOCAJATextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETFONDOCAJATextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETFONDOCAJATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETFONDOCAJATextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETFONDOCAJATextBox.TabIndex = 294;
            this.CANTTICKETFONDOCAJATextBox.Tag = 34;
            this.CANTTICKETFONDOCAJATextBox.Text = "0";
            this.CANTTICKETFONDOCAJATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETFONDOCAJATextBox.ValidationExpression = null;
            this.CANTTICKETFONDOCAJATextBox.ZeroIsValid = true;
            // 
            // CANTTICKETDEPOSITOSTextBox
            // 
            this.CANTTICKETDEPOSITOSTextBox.AllowNegative = false;
            this.CANTTICKETDEPOSITOSTextBox.Format_Expression = null;
            this.CANTTICKETDEPOSITOSTextBox.Location = new System.Drawing.Point(61, 232);
            this.CANTTICKETDEPOSITOSTextBox.Name = "CANTTICKETDEPOSITOSTextBox";
            this.CANTTICKETDEPOSITOSTextBox.NumericPrecision = 3;
            this.CANTTICKETDEPOSITOSTextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETDEPOSITOSTextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETDEPOSITOSTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETDEPOSITOSTextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETDEPOSITOSTextBox.TabIndex = 289;
            this.CANTTICKETDEPOSITOSTextBox.Tag = 34;
            this.CANTTICKETDEPOSITOSTextBox.Text = "0";
            this.CANTTICKETDEPOSITOSTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETDEPOSITOSTextBox.ValidationExpression = null;
            this.CANTTICKETDEPOSITOSTextBox.ZeroIsValid = true;
            // 
            // CANTTICKETRETIROTextBox
            // 
            this.CANTTICKETRETIROTextBox.AllowNegative = false;
            this.CANTTICKETRETIROTextBox.Format_Expression = null;
            this.CANTTICKETRETIROTextBox.Location = new System.Drawing.Point(10, 231);
            this.CANTTICKETRETIROTextBox.Name = "CANTTICKETRETIROTextBox";
            this.CANTTICKETRETIROTextBox.NumericPrecision = 3;
            this.CANTTICKETRETIROTextBox.NumericScaleOnFocus = 0;
            this.CANTTICKETRETIROTextBox.NumericScaleOnLostFocus = 0;
            this.CANTTICKETRETIROTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CANTTICKETRETIROTextBox.Size = new System.Drawing.Size(39, 20);
            this.CANTTICKETRETIROTextBox.TabIndex = 287;
            this.CANTTICKETRETIROTextBox.Tag = 34;
            this.CANTTICKETRETIROTextBox.Text = "0";
            this.CANTTICKETRETIROTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CANTTICKETRETIROTextBox.ValidationExpression = null;
            this.CANTTICKETRETIROTextBox.ZeroIsValid = true;
            // 
            // DOBLECOPIATARJETATextBox
            // 
            this.DOBLECOPIATARJETATextBox.AllowNegative = false;
            this.DOBLECOPIATARJETATextBox.Format_Expression = null;
            this.DOBLECOPIATARJETATextBox.Location = new System.Drawing.Point(248, 384);
            this.DOBLECOPIATARJETATextBox.Name = "DOBLECOPIATARJETATextBox";
            this.DOBLECOPIATARJETATextBox.NumericPrecision = 3;
            this.DOBLECOPIATARJETATextBox.NumericScaleOnFocus = 0;
            this.DOBLECOPIATARJETATextBox.NumericScaleOnLostFocus = 0;
            this.DOBLECOPIATARJETATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DOBLECOPIATARJETATextBox.Size = new System.Drawing.Size(39, 20);
            this.DOBLECOPIATARJETATextBox.TabIndex = 284;
            this.DOBLECOPIATARJETATextBox.Tag = 34;
            this.DOBLECOPIATARJETATextBox.Text = "0";
            this.DOBLECOPIATARJETATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DOBLECOPIATARJETATextBox.ValidationExpression = null;
            this.DOBLECOPIATARJETATextBox.ZeroIsValid = true;
            // 
            // DOBLECOPIACONTADOTextBox
            // 
            this.DOBLECOPIACONTADOTextBox.AllowNegative = false;
            this.DOBLECOPIACONTADOTextBox.Format_Expression = null;
            this.DOBLECOPIACONTADOTextBox.Location = new System.Drawing.Point(9, 529);
            this.DOBLECOPIACONTADOTextBox.Name = "DOBLECOPIACONTADOTextBox";
            this.DOBLECOPIACONTADOTextBox.NumericPrecision = 3;
            this.DOBLECOPIACONTADOTextBox.NumericScaleOnFocus = 0;
            this.DOBLECOPIACONTADOTextBox.NumericScaleOnLostFocus = 0;
            this.DOBLECOPIACONTADOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DOBLECOPIACONTADOTextBox.Size = new System.Drawing.Size(79, 20);
            this.DOBLECOPIACONTADOTextBox.TabIndex = 187;
            this.DOBLECOPIACONTADOTextBox.Tag = 34;
            this.DOBLECOPIACONTADOTextBox.Text = "0";
            this.DOBLECOPIACONTADOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DOBLECOPIACONTADOTextBox.ValidationExpression = null;
            this.DOBLECOPIACONTADOTextBox.ZeroIsValid = true;
            // 
            // NUMTICKETSABONOTextBox
            // 
            this.NUMTICKETSABONOTextBox.AllowNegative = false;
            this.NUMTICKETSABONOTextBox.Format_Expression = null;
            this.NUMTICKETSABONOTextBox.Location = new System.Drawing.Point(389, 529);
            this.NUMTICKETSABONOTextBox.Name = "NUMTICKETSABONOTextBox";
            this.NUMTICKETSABONOTextBox.NumericPrecision = 3;
            this.NUMTICKETSABONOTextBox.NumericScaleOnFocus = 0;
            this.NUMTICKETSABONOTextBox.NumericScaleOnLostFocus = 0;
            this.NUMTICKETSABONOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NUMTICKETSABONOTextBox.Size = new System.Drawing.Size(86, 20);
            this.NUMTICKETSABONOTextBox.TabIndex = 183;
            this.NUMTICKETSABONOTextBox.Tag = 34;
            this.NUMTICKETSABONOTextBox.Text = "0";
            this.NUMTICKETSABONOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUMTICKETSABONOTextBox.ValidationExpression = null;
            this.NUMTICKETSABONOTextBox.ZeroIsValid = true;
            // 
            // PENDMAXDIASTextBox
            // 
            this.PENDMAXDIASTextBox.AllowNegative = false;
            this.PENDMAXDIASTextBox.Format_Expression = null;
            this.PENDMAXDIASTextBox.Location = new System.Drawing.Point(610, 153);
            this.PENDMAXDIASTextBox.Name = "PENDMAXDIASTextBox";
            this.PENDMAXDIASTextBox.NumericPrecision = 3;
            this.PENDMAXDIASTextBox.NumericScaleOnFocus = 0;
            this.PENDMAXDIASTextBox.NumericScaleOnLostFocus = 0;
            this.PENDMAXDIASTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PENDMAXDIASTextBox.Size = new System.Drawing.Size(71, 20);
            this.PENDMAXDIASTextBox.TabIndex = 111;
            this.PENDMAXDIASTextBox.Tag = 34;
            this.PENDMAXDIASTextBox.Text = "0";
            this.PENDMAXDIASTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PENDMAXDIASTextBox.ValidationExpression = null;
            this.PENDMAXDIASTextBox.ZeroIsValid = true;
            // 
            // DOBLECOPIATRASLADOTextBox
            // 
            this.DOBLECOPIATRASLADOTextBox.AllowNegative = false;
            this.DOBLECOPIATRASLADOTextBox.Format_Expression = null;
            this.DOBLECOPIATRASLADOTextBox.Location = new System.Drawing.Point(328, 385);
            this.DOBLECOPIATRASLADOTextBox.Name = "DOBLECOPIATRASLADOTextBox";
            this.DOBLECOPIATRASLADOTextBox.NumericPrecision = 3;
            this.DOBLECOPIATRASLADOTextBox.NumericScaleOnFocus = 0;
            this.DOBLECOPIATRASLADOTextBox.NumericScaleOnLostFocus = 0;
            this.DOBLECOPIATRASLADOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DOBLECOPIATRASLADOTextBox.Size = new System.Drawing.Size(42, 20);
            this.DOBLECOPIATRASLADOTextBox.TabIndex = 6;
            this.DOBLECOPIATRASLADOTextBox.Tag = 34;
            this.DOBLECOPIATRASLADOTextBox.Text = "0";
            this.DOBLECOPIATRASLADOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DOBLECOPIATRASLADOTextBox.ValidationExpression = null;
            this.DOBLECOPIATRASLADOTextBox.ZeroIsValid = true;
            // 
            // DOBLECOPIACREDITOTextBox
            // 
            this.DOBLECOPIACREDITOTextBox.AllowNegative = false;
            this.DOBLECOPIACREDITOTextBox.Format_Expression = null;
            this.DOBLECOPIACREDITOTextBox.Location = new System.Drawing.Point(167, 384);
            this.DOBLECOPIACREDITOTextBox.Name = "DOBLECOPIACREDITOTextBox";
            this.DOBLECOPIACREDITOTextBox.NumericPrecision = 3;
            this.DOBLECOPIACREDITOTextBox.NumericScaleOnFocus = 0;
            this.DOBLECOPIACREDITOTextBox.NumericScaleOnLostFocus = 0;
            this.DOBLECOPIACREDITOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DOBLECOPIACREDITOTextBox.Size = new System.Drawing.Size(39, 20);
            this.DOBLECOPIACREDITOTextBox.TabIndex = 5;
            this.DOBLECOPIACREDITOTextBox.Tag = 34;
            this.DOBLECOPIACREDITOTextBox.Text = "0";
            this.DOBLECOPIACREDITOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DOBLECOPIACREDITOTextBox.ValidationExpression = null;
            this.DOBLECOPIACREDITOTextBox.ZeroIsValid = true;
            // 
            // TBComisiones
            // 
            this.TBComisiones.BackColor = System.Drawing.Color.Transparent;
            this.TBComisiones.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.TBComisiones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TBComisiones.Controls.Add(this.label321);
            this.TBComisiones.Controls.Add(this.LISTAPRECMEDMAYLINEAComboBox);
            this.TBComisiones.Controls.Add(this.label319);
            this.TBComisiones.Controls.Add(this.LISTAPRECIOMAYLINEAComboBox);
            this.TBComisiones.Controls.Add(this.label274);
            this.TBComisiones.Controls.Add(this.label272);
            this.TBComisiones.Controls.Add(this.label273);
            this.TBComisiones.Controls.Add(this.label260);
            this.TBComisiones.Controls.Add(lblVersionComision);
            this.TBComisiones.Controls.Add(this.PREGUNTARSERVDOMTextBox);
            this.TBComisiones.Controls.Add(this.label258);
            this.TBComisiones.Controls.Add(this.PAGOTARJMENORPRECIOLISTAALLTextBox);
            this.TBComisiones.Controls.Add(this.label257);
            this.TBComisiones.Controls.Add(this.RETIROCAJAALCERRARCORTETextBox);
            this.TBComisiones.Controls.Add(this.label256);
            this.TBComisiones.Controls.Add(this.label235);
            this.TBComisiones.Controls.Add(this.PREGUNTARSIESACREDITOTextBox);
            this.TBComisiones.Controls.Add(this.label204);
            this.TBComisiones.Controls.Add(this.label194);
            this.TBComisiones.Controls.Add(this.label165);
            this.TBComisiones.Controls.Add(this.label164);
            this.TBComisiones.Controls.Add(this.label162);
            this.TBComisiones.Controls.Add(this.label163);
            this.TBComisiones.Controls.Add(this.label56);
            this.TBComisiones.Controls.Add(this.label57);
            this.TBComisiones.Controls.Add(this.CAMBIARPRECIOXUEMPAQUEComboBox);
            this.TBComisiones.Controls.Add(this.LISTAPRECIOXUEMPAQUEComboBox);
            this.TBComisiones.Controls.Add(this.CAMBIARPRECIOXPZACAJAComboBox);
            this.TBComisiones.Controls.Add(this.LISTAPRECIOXPZACAJAComboBox);
            this.TBComisiones.Controls.Add(this.label161);
            this.TBComisiones.Controls.Add(this.label160);
            this.TBComisiones.Controls.Add(this.label157);
            this.TBComisiones.Controls.Add(this.label158);
            this.TBComisiones.Controls.Add(this.APLICARMAYOREOPORLINEATextBox);
            this.TBComisiones.Controls.Add(this.label159);
            this.TBComisiones.Controls.Add(this.label156);
            this.TBComisiones.Controls.Add(this.label155);
            this.TBComisiones.Controls.Add(this.MANEJARRETIRODECAJATextBox);
            this.TBComisiones.Controls.Add(this.label154);
            this.TBComisiones.Controls.Add(this.label109);
            this.TBComisiones.Controls.Add(this.label108);
            this.TBComisiones.Controls.Add(this.MANEJAQUOTATextBox);
            this.TBComisiones.Controls.Add(this.label107);
            this.TBComisiones.Controls.Add(this.VENDEDORButton);
            this.TBComisiones.Controls.Add(this.VENDEDORLabel);
            this.TBComisiones.Controls.Add(this.lblClienteSuc);
            this.TBComisiones.Controls.Add(this.label52);
            this.TBComisiones.Controls.Add(this.label51);
            this.TBComisiones.Controls.Add(this.label20);
            this.TBComisiones.Controls.Add(this.label19);
            this.TBComisiones.Controls.Add(this.FACTCONSMAXPORTextBox);
            this.TBComisiones.Controls.Add(this.COMISIONDEBPORTARJETATextBox);
            this.TBComisiones.Controls.Add(this.COMISIONDEBTARJETAEMPRESATextBox);
            this.TBComisiones.Controls.Add(this.MAXCOMISIONXCLIENTETextBox);
            this.TBComisiones.Controls.Add(this.VERSIONCOMISIONIDTextBox);
            this.TBComisiones.Controls.Add(this.INTENTOSRETIROCAJATextBox);
            this.TBComisiones.Controls.Add(this.MONTOMAXSALDOMENORNumericTextBox);
            this.TBComisiones.Controls.Add(this.IVACOMISIONTARJETAEMPRESATextBox);
            this.TBComisiones.Controls.Add(this.COMISIONTARJETAEMPRESATextBox);
            this.TBComisiones.Controls.Add(this.PIEZASDIFMAYOREOTextBox);
            this.TBComisiones.Controls.Add(this.PIEZASIGUALESMAYOREOTextBox);
            this.TBComisiones.Controls.Add(this.PIEZASDIFMEDIOMAYOREOTextBox);
            this.TBComisiones.Controls.Add(this.PIEZASIGUALESMEDIOMAYOREOTextBox);
            this.TBComisiones.Controls.Add(this.COMISIONPORTARJETATextBox);
            this.TBComisiones.Controls.Add(this.MONTORETIROCAJATextBox);
            this.TBComisiones.Controls.Add(this.TIPOUTILIDADIDTextBox);
            this.TBComisiones.Controls.Add(this.ENCARGADOIDTextBox);
            this.TBComisiones.Controls.Add(this.PORC_COMISIONVENDEDORTextBox);
            this.TBComisiones.Controls.Add(this.PORC_COMISIONENCARGADOTextBox);
            this.TBComisiones.Controls.Add(this.COMISIONDEPENDIENTETextBox);
            this.TBComisiones.Controls.Add(this.COMISIONMEDICOTextBox);
            this.TBComisiones.Location = new System.Drawing.Point(4, 22);
            this.TBComisiones.Name = "TBComisiones";
            this.TBComisiones.Padding = new System.Windows.Forms.Padding(3);
            this.TBComisiones.Size = new System.Drawing.Size(782, 556);
            this.TBComisiones.TabIndex = 4;
            this.TBComisiones.Text = "Comisiones/Quotas";
            // 
            // label321
            // 
            this.label321.AutoSize = true;
            this.label321.Location = new System.Drawing.Point(596, 350);
            this.label321.Name = "label321";
            this.label321.Size = new System.Drawing.Size(85, 13);
            this.label321.TabIndex = 288;
            this.label321.Text = "L/precio may:";
            // 
            // LISTAPRECMEDMAYLINEAComboBox
            // 
            this.LISTAPRECMEDMAYLINEAComboBox.FormattingEnabled = true;
            this.LISTAPRECMEDMAYLINEAComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECMEDMAYLINEAComboBox.Location = new System.Drawing.Point(538, 347);
            this.LISTAPRECMEDMAYLINEAComboBox.Name = "LISTAPRECMEDMAYLINEAComboBox";
            this.LISTAPRECMEDMAYLINEAComboBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECMEDMAYLINEAComboBox.TabIndex = 180;
            // 
            // label319
            // 
            this.label319.AutoSize = true;
            this.label319.Location = new System.Drawing.Point(368, 350);
            this.label319.Name = "label319";
            this.label319.Size = new System.Drawing.Size(122, 13);
            this.label319.TabIndex = 286;
            this.label319.Text = "L/precio medio may:";
            // 
            // LISTAPRECIOMAYLINEAComboBox
            // 
            this.LISTAPRECIOMAYLINEAComboBox.FormattingEnabled = true;
            this.LISTAPRECIOMAYLINEAComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOMAYLINEAComboBox.Location = new System.Drawing.Point(681, 347);
            this.LISTAPRECIOMAYLINEAComboBox.Name = "LISTAPRECIOMAYLINEAComboBox";
            this.LISTAPRECIOMAYLINEAComboBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECIOMAYLINEAComboBox.TabIndex = 181;
            // 
            // label274
            // 
            this.label274.AutoSize = true;
            this.label274.Location = new System.Drawing.Point(16, 204);
            this.label274.Name = "label274";
            this.label274.Size = new System.Drawing.Size(116, 13);
            this.label274.TabIndex = 284;
            this.label274.Text = "Max. % fact. cons.:";
            // 
            // label272
            // 
            this.label272.AutoSize = true;
            this.label272.Location = new System.Drawing.Point(410, 232);
            this.label272.Name = "label272";
            this.label272.Size = new System.Drawing.Size(249, 13);
            this.label272.TabIndex = 282;
            this.label272.Text = "Com. por pago con tarjeta Deb. ( af. prec) ";
            // 
            // label273
            // 
            this.label273.AutoSize = true;
            this.label273.Location = new System.Drawing.Point(415, 257);
            this.label273.Name = "label273";
            this.label273.Size = new System.Drawing.Size(248, 13);
            this.label273.TabIndex = 280;
            this.label273.Text = "Comision pago con tarj/deb(afecta poliza):";
            // 
            // label260
            // 
            this.label260.AutoSize = true;
            this.label260.Location = new System.Drawing.Point(402, 90);
            this.label260.Name = "label260";
            this.label260.Size = new System.Drawing.Size(143, 13);
            this.label260.TabIndex = 278;
            this.label260.Text = "Max. comision x cliente:";
            // 
            // PREGUNTARSERVDOMTextBox
            // 
            this.PREGUNTARSERVDOMTextBox.AutoSize = true;
            this.PREGUNTARSERVDOMTextBox.Location = new System.Drawing.Point(226, 525);
            this.PREGUNTARSERVDOMTextBox.Name = "PREGUNTARSERVDOMTextBox";
            this.PREGUNTARSERVDOMTextBox.Size = new System.Drawing.Size(15, 14);
            this.PREGUNTARSERVDOMTextBox.TabIndex = 274;
            this.PREGUNTARSERVDOMTextBox.UseVisualStyleBackColor = true;
            // 
            // label258
            // 
            this.label258.AutoSize = true;
            this.label258.Location = new System.Drawing.Point(15, 523);
            this.label258.Name = "label258";
            this.label258.Size = new System.Drawing.Size(155, 13);
            this.label258.TabIndex = 273;
            this.label258.Text = "Preguntar si es serv. dom.";
            // 
            // PAGOTARJMENORPRECIOLISTAALLTextBox
            // 
            this.PAGOTARJMENORPRECIOLISTAALLTextBox.AutoSize = true;
            this.PAGOTARJMENORPRECIOLISTAALLTextBox.Location = new System.Drawing.Point(530, 326);
            this.PAGOTARJMENORPRECIOLISTAALLTextBox.Name = "PAGOTARJMENORPRECIOLISTAALLTextBox";
            this.PAGOTARJMENORPRECIOLISTAALLTextBox.Size = new System.Drawing.Size(15, 14);
            this.PAGOTARJMENORPRECIOLISTAALLTextBox.TabIndex = 272;
            this.PAGOTARJMENORPRECIOLISTAALLTextBox.UseVisualStyleBackColor = true;
            // 
            // label257
            // 
            this.label257.AutoSize = true;
            this.label257.Location = new System.Drawing.Point(406, 326);
            this.label257.Name = "label257";
            this.label257.Size = new System.Drawing.Size(118, 13);
            this.label257.TabIndex = 271;
            this.label257.Text = "C/tarj. < prec. lista:";
            // 
            // RETIROCAJAALCERRARCORTETextBox
            // 
            this.RETIROCAJAALCERRARCORTETextBox.FormattingEnabled = true;
            this.RETIROCAJAALCERRARCORTETextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.RETIROCAJAALCERRARCORTETextBox.Location = new System.Drawing.Point(668, 525);
            this.RETIROCAJAALCERRARCORTETextBox.Name = "RETIROCAJAALCERRARCORTETextBox";
            this.RETIROCAJAALCERRARCORTETextBox.Size = new System.Drawing.Size(63, 21);
            this.RETIROCAJAALCERRARCORTETextBox.TabIndex = 201;
            // 
            // label256
            // 
            this.label256.AutoSize = true;
            this.label256.Location = new System.Drawing.Point(368, 528);
            this.label256.Name = "label256";
            this.label256.Size = new System.Drawing.Size(258, 13);
            this.label256.TabIndex = 202;
            this.label256.Text = "Preguntar si se hace retiro de caja en corte:";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Location = new System.Drawing.Point(409, 202);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(155, 13);
            this.label235.TabIndex = 200;
            this.label235.Text = "Intentos aut. Retiros caja:";
            // 
            // PREGUNTARSIESACREDITOTextBox
            // 
            this.PREGUNTARSIESACREDITOTextBox.FormattingEnabled = true;
            this.PREGUNTARSIESACREDITOTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PREGUNTARSIESACREDITOTextBox.Location = new System.Drawing.Point(668, 485);
            this.PREGUNTARSIESACREDITOTextBox.Name = "PREGUNTARSIESACREDITOTextBox";
            this.PREGUNTARSIESACREDITOTextBox.Size = new System.Drawing.Size(63, 21);
            this.PREGUNTARSIESACREDITOTextBox.TabIndex = 197;
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(368, 488);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(294, 13);
            this.label204.TabIndex = 198;
            this.label204.Text = "Preguntar si la venta es a credito durante captura:";
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(15, 488);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(198, 13);
            this.label194.TabIndex = 196;
            this.label194.Text = "Maximo P/Saldar saldos menores:";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(57, 290);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(222, 13);
            this.label165.TabIndex = 195;
            this.label165.Text = "IVA X Comision tarjeta (afecta poliza):";
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(27, 260);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(252, 13);
            this.label164.TabIndex = 193;
            this.label164.Text = "Comision pago con tarj/cred(afecta poliza):";
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(368, 413);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(159, 13);
            this.label162.TabIndex = 191;
            this.label162.Text = "Piezas diferentes mayoreo:";
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(16, 413);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(143, 13);
            this.label163.TabIndex = 189;
            this.label163.Text = "Piezas iguales mayoreo:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(368, 451);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(127, 13);
            this.label56.TabIndex = 69;
            this.label56.Text = "C.Precio X Empaque:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(15, 451);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(137, 13);
            this.label57.TabIndex = 71;
            this.label57.Text = "C. precio X Pieza caja:";
            // 
            // CAMBIARPRECIOXUEMPAQUEComboBox
            // 
            this.CAMBIARPRECIOXUEMPAQUEComboBox.FormattingEnabled = true;
            this.CAMBIARPRECIOXUEMPAQUEComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CAMBIARPRECIOXUEMPAQUEComboBox.Location = new System.Drawing.Point(539, 448);
            this.CAMBIARPRECIOXUEMPAQUEComboBox.Name = "CAMBIARPRECIOXUEMPAQUEComboBox";
            this.CAMBIARPRECIOXUEMPAQUEComboBox.Size = new System.Drawing.Size(62, 21);
            this.CAMBIARPRECIOXUEMPAQUEComboBox.TabIndex = 32;
            // 
            // LISTAPRECIOXUEMPAQUEComboBox
            // 
            this.LISTAPRECIOXUEMPAQUEComboBox.FormattingEnabled = true;
            this.LISTAPRECIOXUEMPAQUEComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOXUEMPAQUEComboBox.Location = new System.Drawing.Point(607, 448);
            this.LISTAPRECIOXUEMPAQUEComboBox.Name = "LISTAPRECIOXUEMPAQUEComboBox";
            this.LISTAPRECIOXUEMPAQUEComboBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECIOXUEMPAQUEComboBox.TabIndex = 33;
            // 
            // CAMBIARPRECIOXPZACAJAComboBox
            // 
            this.CAMBIARPRECIOXPZACAJAComboBox.FormattingEnabled = true;
            this.CAMBIARPRECIOXPZACAJAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CAMBIARPRECIOXPZACAJAComboBox.Location = new System.Drawing.Point(226, 448);
            this.CAMBIARPRECIOXPZACAJAComboBox.Name = "CAMBIARPRECIOXPZACAJAComboBox";
            this.CAMBIARPRECIOXPZACAJAComboBox.Size = new System.Drawing.Size(60, 21);
            this.CAMBIARPRECIOXPZACAJAComboBox.TabIndex = 25;
            // 
            // LISTAPRECIOXPZACAJAComboBox
            // 
            this.LISTAPRECIOXPZACAJAComboBox.FormattingEnabled = true;
            this.LISTAPRECIOXPZACAJAComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOXPZACAJAComboBox.Location = new System.Drawing.Point(292, 448);
            this.LISTAPRECIOXPZACAJAComboBox.Name = "LISTAPRECIOXPZACAJAComboBox";
            this.LISTAPRECIOXPZACAJAComboBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECIOXPZACAJAComboBox.TabIndex = 26;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(368, 378);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(159, 13);
            this.label161.TabIndex = 187;
            this.label161.Text = "Piezas dif. Medio mayoreo:";
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(16, 378);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(184, 13);
            this.label160.TabIndex = 185;
            this.label160.Text = "Piezas iguales medio mayorreo:";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(15, 320);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(143, 13);
            this.label157.TabIndex = 183;
            this.label157.Text = "MANEJO DE MAYOREO";
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(9, 234);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(273, 13);
            this.label158.TabIndex = 182;
            this.label158.Text = "Comision por pago con tarjeta (afecta precios):";
            // 
            // APLICARMAYOREOPORLINEATextBox
            // 
            this.APLICARMAYOREOPORLINEATextBox.FormattingEnabled = true;
            this.APLICARMAYOREOPORLINEATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.APLICARMAYOREOPORLINEATextBox.Location = new System.Drawing.Point(226, 345);
            this.APLICARMAYOREOPORLINEATextBox.Name = "APLICARMAYOREOPORLINEATextBox";
            this.APLICARMAYOREOPORLINEATextBox.Size = new System.Drawing.Size(63, 21);
            this.APLICARMAYOREOPORLINEATextBox.TabIndex = 179;
            this.APLICARMAYOREOPORLINEATextBox.SelectedIndexChanged += new System.EventHandler(this.APLICARMAYOREOPORLINEATextBox_SelectedIndexChanged);
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(16, 348);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(112, 13);
            this.label159.TabIndex = 180;
            this.label159.Text = "Mayoreo por linea:";
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(408, 121);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(117, 13);
            this.label156.TabIndex = 178;
            this.label156.Text = "RETIROS DE CAJA";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(409, 174);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(154, 13);
            this.label155.TabIndex = 177;
            this.label155.Text = "Monto para retiro de caja:";
            // 
            // MANEJARRETIRODECAJATextBox
            // 
            this.MANEJARRETIRODECAJATextBox.FormattingEnabled = true;
            this.MANEJARRETIRODECAJATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJARRETIRODECAJATextBox.Location = new System.Drawing.Point(569, 145);
            this.MANEJARRETIRODECAJATextBox.Name = "MANEJARRETIRODECAJATextBox";
            this.MANEJARRETIRODECAJATextBox.Size = new System.Drawing.Size(63, 21);
            this.MANEJARRETIRODECAJATextBox.TabIndex = 174;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(426, 148);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(137, 13);
            this.label154.TabIndex = 175;
            this.label154.Text = "Maneja retiros de caja:";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(22, 175);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(81, 13);
            this.label109.TabIndex = 173;
            this.label109.Text = "Tipo utilidad:";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(13, 121);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(58, 13);
            this.label108.TabIndex = 171;
            this.label108.Text = "QUOTAS";
            // 
            // MANEJAQUOTATextBox
            // 
            this.MANEJAQUOTATextBox.FormattingEnabled = true;
            this.MANEJAQUOTATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJAQUOTATextBox.Location = new System.Drawing.Point(109, 145);
            this.MANEJAQUOTATextBox.Name = "MANEJAQUOTATextBox";
            this.MANEJAQUOTATextBox.Size = new System.Drawing.Size(63, 21);
            this.MANEJAQUOTATextBox.TabIndex = 169;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(13, 148);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(90, 13);
            this.label107.TabIndex = 170;
            this.label107.Text = "Maneja Quota:";
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORButton.Location = new System.Drawing.Point(326, 56);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(24, 23);
            this.VENDEDORButton.TabIndex = 4;
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.Location = new System.Drawing.Point(356, 61);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(19, 13);
            this.VENDEDORLabel.TabIndex = 168;
            this.VENDEDORLabel.Text = "...";
            // 
            // lblClienteSuc
            // 
            this.lblClienteSuc.AutoSize = true;
            this.lblClienteSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteSuc.Location = new System.Drawing.Point(57, 61);
            this.lblClienteSuc.Name = "lblClienteSuc";
            this.lblClienteSuc.Size = new System.Drawing.Size(143, 13);
            this.lblClienteSuc.TabIndex = 165;
            this.lblClienteSuc.Text = "Encargado de la tienda:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(48, 35);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(152, 13);
            this.label52.TabIndex = 26;
            this.label52.Text = "Porc. Comision vendedor:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(41, 7);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(159, 13);
            this.label51.TabIndex = 24;
            this.label51.Text = "Porc. Comision encargado:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(404, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(135, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Comision dependiente:";
            this.label20.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(434, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Comision medico:";
            this.label19.Visible = false;
            // 
            // FACTCONSMAXPORTextBox
            // 
            this.FACTCONSMAXPORTextBox.AllowNegative = false;
            this.FACTCONSMAXPORTextBox.Format_Expression = null;
            this.FACTCONSMAXPORTextBox.Location = new System.Drawing.Point(154, 201);
            this.FACTCONSMAXPORTextBox.Name = "FACTCONSMAXPORTextBox";
            this.FACTCONSMAXPORTextBox.NumericPrecision = 5;
            this.FACTCONSMAXPORTextBox.NumericScaleOnFocus = 2;
            this.FACTCONSMAXPORTextBox.NumericScaleOnLostFocus = 2;
            this.FACTCONSMAXPORTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FACTCONSMAXPORTextBox.Size = new System.Drawing.Size(116, 20);
            this.FACTCONSMAXPORTextBox.TabIndex = 283;
            this.FACTCONSMAXPORTextBox.Tag = 34;
            this.FACTCONSMAXPORTextBox.Text = "0.00";
            this.FACTCONSMAXPORTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FACTCONSMAXPORTextBox.ValidationExpression = null;
            this.FACTCONSMAXPORTextBox.ZeroIsValid = true;
            // 
            // COMISIONDEBPORTARJETATextBox
            // 
            this.COMISIONDEBPORTARJETATextBox.AllowNegative = false;
            this.COMISIONDEBPORTARJETATextBox.Format_Expression = null;
            this.COMISIONDEBPORTARJETATextBox.Location = new System.Drawing.Point(662, 228);
            this.COMISIONDEBPORTARJETATextBox.Name = "COMISIONDEBPORTARJETATextBox";
            this.COMISIONDEBPORTARJETATextBox.NumericPrecision = 18;
            this.COMISIONDEBPORTARJETATextBox.NumericScaleOnFocus = 2;
            this.COMISIONDEBPORTARJETATextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONDEBPORTARJETATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONDEBPORTARJETATextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONDEBPORTARJETATextBox.TabIndex = 281;
            this.COMISIONDEBPORTARJETATextBox.Tag = 34;
            this.COMISIONDEBPORTARJETATextBox.Text = "0.00";
            this.COMISIONDEBPORTARJETATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONDEBPORTARJETATextBox.ValidationExpression = null;
            this.COMISIONDEBPORTARJETATextBox.ZeroIsValid = true;
            // 
            // COMISIONDEBTARJETAEMPRESATextBox
            // 
            this.COMISIONDEBTARJETAEMPRESATextBox.AllowNegative = false;
            this.COMISIONDEBTARJETAEMPRESATextBox.Format_Expression = null;
            this.COMISIONDEBTARJETAEMPRESATextBox.Location = new System.Drawing.Point(664, 251);
            this.COMISIONDEBTARJETAEMPRESATextBox.Name = "COMISIONDEBTARJETAEMPRESATextBox";
            this.COMISIONDEBTARJETAEMPRESATextBox.NumericPrecision = 18;
            this.COMISIONDEBTARJETAEMPRESATextBox.NumericScaleOnFocus = 2;
            this.COMISIONDEBTARJETAEMPRESATextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONDEBTARJETAEMPRESATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONDEBTARJETAEMPRESATextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONDEBTARJETAEMPRESATextBox.TabIndex = 279;
            this.COMISIONDEBTARJETAEMPRESATextBox.Tag = 34;
            this.COMISIONDEBTARJETAEMPRESATextBox.Text = "0.00";
            this.COMISIONDEBTARJETAEMPRESATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONDEBTARJETAEMPRESATextBox.ValidationExpression = null;
            this.COMISIONDEBTARJETAEMPRESATextBox.ZeroIsValid = true;
            // 
            // MAXCOMISIONXCLIENTETextBox
            // 
            this.MAXCOMISIONXCLIENTETextBox.AllowNegative = false;
            this.MAXCOMISIONXCLIENTETextBox.Format_Expression = null;
            this.MAXCOMISIONXCLIENTETextBox.Location = new System.Drawing.Point(545, 87);
            this.MAXCOMISIONXCLIENTETextBox.Name = "MAXCOMISIONXCLIENTETextBox";
            this.MAXCOMISIONXCLIENTETextBox.NumericPrecision = 5;
            this.MAXCOMISIONXCLIENTETextBox.NumericScaleOnFocus = 2;
            this.MAXCOMISIONXCLIENTETextBox.NumericScaleOnLostFocus = 2;
            this.MAXCOMISIONXCLIENTETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MAXCOMISIONXCLIENTETextBox.Size = new System.Drawing.Size(116, 20);
            this.MAXCOMISIONXCLIENTETextBox.TabIndex = 277;
            this.MAXCOMISIONXCLIENTETextBox.Tag = 34;
            this.MAXCOMISIONXCLIENTETextBox.Text = "0.00";
            this.MAXCOMISIONXCLIENTETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MAXCOMISIONXCLIENTETextBox.ValidationExpression = null;
            this.MAXCOMISIONXCLIENTETextBox.ZeroIsValid = true;
            // 
            // VERSIONCOMISIONIDTextBox
            // 
            this.VERSIONCOMISIONIDTextBox.AllowNegative = true;
            this.VERSIONCOMISIONIDTextBox.Format_Expression = null;
            this.VERSIONCOMISIONIDTextBox.Location = new System.Drawing.Point(702, 59);
            this.VERSIONCOMISIONIDTextBox.Name = "VERSIONCOMISIONIDTextBox";
            this.VERSIONCOMISIONIDTextBox.NumericPrecision = 1;
            this.VERSIONCOMISIONIDTextBox.NumericScaleOnFocus = 0;
            this.VERSIONCOMISIONIDTextBox.NumericScaleOnLostFocus = 0;
            this.VERSIONCOMISIONIDTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VERSIONCOMISIONIDTextBox.Size = new System.Drawing.Size(70, 20);
            this.VERSIONCOMISIONIDTextBox.TabIndex = 276;
            this.VERSIONCOMISIONIDTextBox.Tag = 34;
            this.VERSIONCOMISIONIDTextBox.Text = "0";
            this.VERSIONCOMISIONIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.VERSIONCOMISIONIDTextBox.ValidationExpression = null;
            this.VERSIONCOMISIONIDTextBox.ZeroIsValid = false;
            // 
            // INTENTOSRETIROCAJATextBox
            // 
            this.INTENTOSRETIROCAJATextBox.AllowNegative = false;
            this.INTENTOSRETIROCAJATextBox.Format_Expression = null;
            this.INTENTOSRETIROCAJATextBox.Location = new System.Drawing.Point(570, 199);
            this.INTENTOSRETIROCAJATextBox.Name = "INTENTOSRETIROCAJATextBox";
            this.INTENTOSRETIROCAJATextBox.NumericPrecision = 5;
            this.INTENTOSRETIROCAJATextBox.NumericScaleOnFocus = 0;
            this.INTENTOSRETIROCAJATextBox.NumericScaleOnLostFocus = 0;
            this.INTENTOSRETIROCAJATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.INTENTOSRETIROCAJATextBox.Size = new System.Drawing.Size(116, 20);
            this.INTENTOSRETIROCAJATextBox.TabIndex = 199;
            this.INTENTOSRETIROCAJATextBox.Tag = 34;
            this.INTENTOSRETIROCAJATextBox.Text = "0";
            this.INTENTOSRETIROCAJATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.INTENTOSRETIROCAJATextBox.ValidationExpression = null;
            this.INTENTOSRETIROCAJATextBox.ZeroIsValid = true;
            // 
            // MONTOMAXSALDOMENORNumericTextBox
            // 
            this.MONTOMAXSALDOMENORNumericTextBox.AllowNegative = false;
            this.MONTOMAXSALDOMENORNumericTextBox.Format_Expression = null;
            this.MONTOMAXSALDOMENORNumericTextBox.Location = new System.Drawing.Point(226, 485);
            this.MONTOMAXSALDOMENORNumericTextBox.Name = "MONTOMAXSALDOMENORNumericTextBox";
            this.MONTOMAXSALDOMENORNumericTextBox.NumericPrecision = 18;
            this.MONTOMAXSALDOMENORNumericTextBox.NumericScaleOnFocus = 2;
            this.MONTOMAXSALDOMENORNumericTextBox.NumericScaleOnLostFocus = 2;
            this.MONTOMAXSALDOMENORNumericTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MONTOMAXSALDOMENORNumericTextBox.Size = new System.Drawing.Size(124, 20);
            this.MONTOMAXSALDOMENORNumericTextBox.TabIndex = 174;
            this.MONTOMAXSALDOMENORNumericTextBox.Tag = 34;
            this.MONTOMAXSALDOMENORNumericTextBox.Text = "0.00";
            this.MONTOMAXSALDOMENORNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MONTOMAXSALDOMENORNumericTextBox.ValidationExpression = null;
            this.MONTOMAXSALDOMENORNumericTextBox.ZeroIsValid = true;
            // 
            // IVACOMISIONTARJETAEMPRESATextBox
            // 
            this.IVACOMISIONTARJETAEMPRESATextBox.AllowNegative = false;
            this.IVACOMISIONTARJETAEMPRESATextBox.Format_Expression = null;
            this.IVACOMISIONTARJETAEMPRESATextBox.Location = new System.Drawing.Point(290, 283);
            this.IVACOMISIONTARJETAEMPRESATextBox.Name = "IVACOMISIONTARJETAEMPRESATextBox";
            this.IVACOMISIONTARJETAEMPRESATextBox.NumericPrecision = 18;
            this.IVACOMISIONTARJETAEMPRESATextBox.NumericScaleOnFocus = 2;
            this.IVACOMISIONTARJETAEMPRESATextBox.NumericScaleOnLostFocus = 2;
            this.IVACOMISIONTARJETAEMPRESATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IVACOMISIONTARJETAEMPRESATextBox.Size = new System.Drawing.Size(116, 20);
            this.IVACOMISIONTARJETAEMPRESATextBox.TabIndex = 194;
            this.IVACOMISIONTARJETAEMPRESATextBox.Tag = 34;
            this.IVACOMISIONTARJETAEMPRESATextBox.Text = "0.00";
            this.IVACOMISIONTARJETAEMPRESATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IVACOMISIONTARJETAEMPRESATextBox.ValidationExpression = null;
            this.IVACOMISIONTARJETAEMPRESATextBox.ZeroIsValid = true;
            // 
            // COMISIONTARJETAEMPRESATextBox
            // 
            this.COMISIONTARJETAEMPRESATextBox.AllowNegative = false;
            this.COMISIONTARJETAEMPRESATextBox.Format_Expression = null;
            this.COMISIONTARJETAEMPRESATextBox.Location = new System.Drawing.Point(290, 257);
            this.COMISIONTARJETAEMPRESATextBox.Name = "COMISIONTARJETAEMPRESATextBox";
            this.COMISIONTARJETAEMPRESATextBox.NumericPrecision = 18;
            this.COMISIONTARJETAEMPRESATextBox.NumericScaleOnFocus = 2;
            this.COMISIONTARJETAEMPRESATextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONTARJETAEMPRESATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONTARJETAEMPRESATextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONTARJETAEMPRESATextBox.TabIndex = 192;
            this.COMISIONTARJETAEMPRESATextBox.Tag = 34;
            this.COMISIONTARJETAEMPRESATextBox.Text = "0.00";
            this.COMISIONTARJETAEMPRESATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONTARJETAEMPRESATextBox.ValidationExpression = null;
            this.COMISIONTARJETAEMPRESATextBox.ZeroIsValid = true;
            // 
            // PIEZASDIFMAYOREOTextBox
            // 
            this.PIEZASDIFMAYOREOTextBox.AllowNegative = false;
            this.PIEZASDIFMAYOREOTextBox.Format_Expression = null;
            this.PIEZASDIFMAYOREOTextBox.Location = new System.Drawing.Point(539, 410);
            this.PIEZASDIFMAYOREOTextBox.Name = "PIEZASDIFMAYOREOTextBox";
            this.PIEZASDIFMAYOREOTextBox.NumericPrecision = 18;
            this.PIEZASDIFMAYOREOTextBox.NumericScaleOnFocus = 2;
            this.PIEZASDIFMAYOREOTextBox.NumericScaleOnLostFocus = 2;
            this.PIEZASDIFMAYOREOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PIEZASDIFMAYOREOTextBox.Size = new System.Drawing.Size(126, 20);
            this.PIEZASDIFMAYOREOTextBox.TabIndex = 190;
            this.PIEZASDIFMAYOREOTextBox.Tag = 34;
            this.PIEZASDIFMAYOREOTextBox.Text = "0.00";
            this.PIEZASDIFMAYOREOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PIEZASDIFMAYOREOTextBox.ValidationExpression = null;
            this.PIEZASDIFMAYOREOTextBox.ZeroIsValid = true;
            // 
            // PIEZASIGUALESMAYOREOTextBox
            // 
            this.PIEZASIGUALESMAYOREOTextBox.AllowNegative = false;
            this.PIEZASIGUALESMAYOREOTextBox.Format_Expression = null;
            this.PIEZASIGUALESMAYOREOTextBox.Location = new System.Drawing.Point(226, 410);
            this.PIEZASIGUALESMAYOREOTextBox.Name = "PIEZASIGUALESMAYOREOTextBox";
            this.PIEZASIGUALESMAYOREOTextBox.NumericPrecision = 18;
            this.PIEZASIGUALESMAYOREOTextBox.NumericScaleOnFocus = 2;
            this.PIEZASIGUALESMAYOREOTextBox.NumericScaleOnLostFocus = 2;
            this.PIEZASIGUALESMAYOREOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PIEZASIGUALESMAYOREOTextBox.Size = new System.Drawing.Size(124, 20);
            this.PIEZASIGUALESMAYOREOTextBox.TabIndex = 188;
            this.PIEZASIGUALESMAYOREOTextBox.Tag = 34;
            this.PIEZASIGUALESMAYOREOTextBox.Text = "0.00";
            this.PIEZASIGUALESMAYOREOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PIEZASIGUALESMAYOREOTextBox.ValidationExpression = null;
            this.PIEZASIGUALESMAYOREOTextBox.ZeroIsValid = true;
            // 
            // PIEZASDIFMEDIOMAYOREOTextBox
            // 
            this.PIEZASDIFMEDIOMAYOREOTextBox.AllowNegative = false;
            this.PIEZASDIFMEDIOMAYOREOTextBox.Format_Expression = null;
            this.PIEZASDIFMEDIOMAYOREOTextBox.Location = new System.Drawing.Point(539, 375);
            this.PIEZASDIFMEDIOMAYOREOTextBox.Name = "PIEZASDIFMEDIOMAYOREOTextBox";
            this.PIEZASDIFMEDIOMAYOREOTextBox.NumericPrecision = 18;
            this.PIEZASDIFMEDIOMAYOREOTextBox.NumericScaleOnFocus = 2;
            this.PIEZASDIFMEDIOMAYOREOTextBox.NumericScaleOnLostFocus = 2;
            this.PIEZASDIFMEDIOMAYOREOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PIEZASDIFMEDIOMAYOREOTextBox.Size = new System.Drawing.Size(126, 20);
            this.PIEZASDIFMEDIOMAYOREOTextBox.TabIndex = 186;
            this.PIEZASDIFMEDIOMAYOREOTextBox.Tag = 34;
            this.PIEZASDIFMEDIOMAYOREOTextBox.Text = "0.00";
            this.PIEZASDIFMEDIOMAYOREOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PIEZASDIFMEDIOMAYOREOTextBox.ValidationExpression = null;
            this.PIEZASDIFMEDIOMAYOREOTextBox.ZeroIsValid = true;
            // 
            // PIEZASIGUALESMEDIOMAYOREOTextBox
            // 
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.AllowNegative = false;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.Format_Expression = null;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.Location = new System.Drawing.Point(226, 375);
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.Name = "PIEZASIGUALESMEDIOMAYOREOTextBox";
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.NumericPrecision = 18;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.NumericScaleOnFocus = 2;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.NumericScaleOnLostFocus = 2;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.Size = new System.Drawing.Size(124, 20);
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.TabIndex = 184;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.Tag = 34;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.Text = "0.00";
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.ValidationExpression = null;
            this.PIEZASIGUALESMEDIOMAYOREOTextBox.ZeroIsValid = true;
            // 
            // COMISIONPORTARJETATextBox
            // 
            this.COMISIONPORTARJETATextBox.AllowNegative = false;
            this.COMISIONPORTARJETATextBox.Format_Expression = null;
            this.COMISIONPORTARJETATextBox.Location = new System.Drawing.Point(289, 231);
            this.COMISIONPORTARJETATextBox.Name = "COMISIONPORTARJETATextBox";
            this.COMISIONPORTARJETATextBox.NumericPrecision = 18;
            this.COMISIONPORTARJETATextBox.NumericScaleOnFocus = 2;
            this.COMISIONPORTARJETATextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPORTARJETATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPORTARJETATextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPORTARJETATextBox.TabIndex = 181;
            this.COMISIONPORTARJETATextBox.Tag = 34;
            this.COMISIONPORTARJETATextBox.Text = "0.00";
            this.COMISIONPORTARJETATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPORTARJETATextBox.ValidationExpression = null;
            this.COMISIONPORTARJETATextBox.ZeroIsValid = true;
            // 
            // MONTORETIROCAJATextBox
            // 
            this.MONTORETIROCAJATextBox.AllowNegative = false;
            this.MONTORETIROCAJATextBox.Format_Expression = null;
            this.MONTORETIROCAJATextBox.Location = new System.Drawing.Point(570, 171);
            this.MONTORETIROCAJATextBox.Name = "MONTORETIROCAJATextBox";
            this.MONTORETIROCAJATextBox.NumericPrecision = 18;
            this.MONTORETIROCAJATextBox.NumericScaleOnFocus = 2;
            this.MONTORETIROCAJATextBox.NumericScaleOnLostFocus = 2;
            this.MONTORETIROCAJATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MONTORETIROCAJATextBox.Size = new System.Drawing.Size(116, 20);
            this.MONTORETIROCAJATextBox.TabIndex = 176;
            this.MONTORETIROCAJATextBox.Tag = 34;
            this.MONTORETIROCAJATextBox.Text = "0.00";
            this.MONTORETIROCAJATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MONTORETIROCAJATextBox.ValidationExpression = null;
            this.MONTORETIROCAJATextBox.ZeroIsValid = true;
            // 
            // TIPOUTILIDADIDTextBox
            // 
            this.TIPOUTILIDADIDTextBox.Condicion = null;
            this.TIPOUTILIDADIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TIPOUTILIDADIDTextBox.DisplayMember = "nombre";
            this.TIPOUTILIDADIDTextBox.FormattingEnabled = true;
            this.TIPOUTILIDADIDTextBox.IndiceCampoSelector = 0;
            this.TIPOUTILIDADIDTextBox.LabelDescription = null;
            this.TIPOUTILIDADIDTextBox.Location = new System.Drawing.Point(109, 172);
            this.TIPOUTILIDADIDTextBox.Name = "TIPOUTILIDADIDTextBox";
            this.TIPOUTILIDADIDTextBox.NombreCampoSelector = "id";
            this.TIPOUTILIDADIDTextBox.Query = "select id,nombre from tipoutilidad";
            this.TIPOUTILIDADIDTextBox.QueryDeSeleccion = "select id,nombre from tipoutilidad where  id = @id";
            this.TIPOUTILIDADIDTextBox.SelectedDataDisplaying = null;
            this.TIPOUTILIDADIDTextBox.SelectedDataValue = null;
            this.TIPOUTILIDADIDTextBox.Size = new System.Drawing.Size(183, 21);
            this.TIPOUTILIDADIDTextBox.TabIndex = 172;
            this.TIPOUTILIDADIDTextBox.ValueMember = "id";
            // 
            // ENCARGADOIDTextBox
            // 
            this.ENCARGADOIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.ENCARGADOIDTextBox.Condicion = null;
            this.ENCARGADOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENCARGADOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENCARGADOIDTextBox.DbValue = null;
            this.ENCARGADOIDTextBox.Format_Expression = null;
            this.ENCARGADOIDTextBox.IndiceCampoDescripcion = 2;
            this.ENCARGADOIDTextBox.IndiceCampoSelector = 1;
            this.ENCARGADOIDTextBox.IndiceCampoValue = 0;
            this.ENCARGADOIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.ENCARGADOIDTextBox.Location = new System.Drawing.Point(206, 58);
            this.ENCARGADOIDTextBox.MostrarErrores = true;
            this.ENCARGADOIDTextBox.Name = "ENCARGADOIDTextBox";
            this.ENCARGADOIDTextBox.NombreCampoSelector = "clave";
            this.ENCARGADOIDTextBox.NombreCampoValue = "id";
            this.ENCARGADOIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (22,20)";
            this.ENCARGADOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid  in (22,20) and  clave= @" +
    "clave";
            this.ENCARGADOIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid  in (22,20) and  id = @id" +
    "";
            this.ENCARGADOIDTextBox.Size = new System.Drawing.Size(117, 20);
            this.ENCARGADOIDTextBox.TabIndex = 3;
            this.ENCARGADOIDTextBox.Tag = 34;
            this.ENCARGADOIDTextBox.TextDescription = null;
            this.ENCARGADOIDTextBox.Titulo = "Vendedores";
            this.ENCARGADOIDTextBox.ValidarEntrada = true;
            this.ENCARGADOIDTextBox.ValidationExpression = null;
            // 
            // PORC_COMISIONVENDEDORTextBox
            // 
            this.PORC_COMISIONVENDEDORTextBox.AllowNegative = false;
            this.PORC_COMISIONVENDEDORTextBox.Format_Expression = null;
            this.PORC_COMISIONVENDEDORTextBox.Location = new System.Drawing.Point(207, 31);
            this.PORC_COMISIONVENDEDORTextBox.Name = "PORC_COMISIONVENDEDORTextBox";
            this.PORC_COMISIONVENDEDORTextBox.NumericPrecision = 5;
            this.PORC_COMISIONVENDEDORTextBox.NumericScaleOnFocus = 2;
            this.PORC_COMISIONVENDEDORTextBox.NumericScaleOnLostFocus = 2;
            this.PORC_COMISIONVENDEDORTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORC_COMISIONVENDEDORTextBox.Size = new System.Drawing.Size(116, 20);
            this.PORC_COMISIONVENDEDORTextBox.TabIndex = 2;
            this.PORC_COMISIONVENDEDORTextBox.Tag = 34;
            this.PORC_COMISIONVENDEDORTextBox.Text = "0.00";
            this.PORC_COMISIONVENDEDORTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORC_COMISIONVENDEDORTextBox.ValidationExpression = null;
            this.PORC_COMISIONVENDEDORTextBox.ZeroIsValid = true;
            // 
            // PORC_COMISIONENCARGADOTextBox
            // 
            this.PORC_COMISIONENCARGADOTextBox.AllowNegative = false;
            this.PORC_COMISIONENCARGADOTextBox.Format_Expression = null;
            this.PORC_COMISIONENCARGADOTextBox.Location = new System.Drawing.Point(207, 4);
            this.PORC_COMISIONENCARGADOTextBox.Name = "PORC_COMISIONENCARGADOTextBox";
            this.PORC_COMISIONENCARGADOTextBox.NumericPrecision = 5;
            this.PORC_COMISIONENCARGADOTextBox.NumericScaleOnFocus = 2;
            this.PORC_COMISIONENCARGADOTextBox.NumericScaleOnLostFocus = 2;
            this.PORC_COMISIONENCARGADOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORC_COMISIONENCARGADOTextBox.Size = new System.Drawing.Size(116, 20);
            this.PORC_COMISIONENCARGADOTextBox.TabIndex = 1;
            this.PORC_COMISIONENCARGADOTextBox.Tag = 34;
            this.PORC_COMISIONENCARGADOTextBox.Text = "0.00";
            this.PORC_COMISIONENCARGADOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORC_COMISIONENCARGADOTextBox.ValidationExpression = null;
            this.PORC_COMISIONENCARGADOTextBox.ZeroIsValid = true;
            // 
            // COMISIONDEPENDIENTETextBox
            // 
            this.COMISIONDEPENDIENTETextBox.AllowNegative = false;
            this.COMISIONDEPENDIENTETextBox.Format_Expression = null;
            this.COMISIONDEPENDIENTETextBox.Location = new System.Drawing.Point(545, 32);
            this.COMISIONDEPENDIENTETextBox.Name = "COMISIONDEPENDIENTETextBox";
            this.COMISIONDEPENDIENTETextBox.NumericPrecision = 5;
            this.COMISIONDEPENDIENTETextBox.NumericScaleOnFocus = 2;
            this.COMISIONDEPENDIENTETextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONDEPENDIENTETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONDEPENDIENTETextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONDEPENDIENTETextBox.TabIndex = 6;
            this.COMISIONDEPENDIENTETextBox.Tag = 34;
            this.COMISIONDEPENDIENTETextBox.Text = "0";
            this.COMISIONDEPENDIENTETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONDEPENDIENTETextBox.ValidationExpression = null;
            this.COMISIONDEPENDIENTETextBox.Visible = false;
            this.COMISIONDEPENDIENTETextBox.ZeroIsValid = true;
            // 
            // COMISIONMEDICOTextBox
            // 
            this.COMISIONMEDICOTextBox.AllowNegative = false;
            this.COMISIONMEDICOTextBox.Format_Expression = null;
            this.COMISIONMEDICOTextBox.Location = new System.Drawing.Point(545, 4);
            this.COMISIONMEDICOTextBox.Name = "COMISIONMEDICOTextBox";
            this.COMISIONMEDICOTextBox.NumericPrecision = 5;
            this.COMISIONMEDICOTextBox.NumericScaleOnFocus = 2;
            this.COMISIONMEDICOTextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONMEDICOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONMEDICOTextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONMEDICOTextBox.TabIndex = 5;
            this.COMISIONMEDICOTextBox.Tag = 34;
            this.COMISIONMEDICOTextBox.Text = "0.00";
            this.COMISIONMEDICOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONMEDICOTextBox.ValidationExpression = null;
            this.COMISIONMEDICOTextBox.Visible = false;
            this.COMISIONMEDICOTextBox.ZeroIsValid = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage5.Controls.Add(this.label301);
            this.tabPage5.Controls.Add(this.HABSURTIDOPREVIOTextBox);
            this.tabPage5.Controls.Add(this.label302);
            this.tabPage5.Controls.Add(this.label300);
            this.tabPage5.Controls.Add(this.COSTOREPOIGUALCOSTOULTComboBox);
            this.tabPage5.Controls.Add(this.label288);
            this.tabPage5.Controls.Add(this.HABMULTPLAZOCOMPRATextBox);
            this.tabPage5.Controls.Add(this.label286);
            this.tabPage5.Controls.Add(this.MANEJAUTILIDADPRECIOSTextBox);
            this.tabPage5.Controls.Add(this.label284);
            this.tabPage5.Controls.Add(this.HABREVISIONFINALTextBox);
            this.tabPage5.Controls.Add(this.label263);
            this.tabPage5.Controls.Add(lblVersionTope);
            this.tabPage5.Controls.Add(this.label247);
            this.tabPage5.Controls.Add(this.cbBusquedaTipo2);
            this.tabPage5.Controls.Add(this.label241);
            this.tabPage5.Controls.Add(this.label240);
            this.tabPage5.Controls.Add(this.label239);
            this.tabPage5.Controls.Add(this.label238);
            this.tabPage5.Controls.Add(this.label237);
            this.tabPage5.Controls.Add(this.label236);
            this.tabPage5.Controls.Add(this.PRECIONETOENGRIDSTextBox);
            this.tabPage5.Controls.Add(this.label226);
            this.tabPage5.Controls.Add(label218);
            this.tabPage5.Controls.Add(this.label217);
            this.tabPage5.Controls.Add(this.actPrecAutoCB);
            this.tabPage5.Controls.Add(this.lblAlmacen);
            this.tabPage5.Controls.Add(this.autocompleteConExistenciaCB);
            this.tabPage5.Controls.Add(this.label214);
            this.tabPage5.Controls.Add(this.cbPlazosXProducto);
            this.tabPage5.Controls.Add(this.label210);
            this.tabPage5.Controls.Add(this.label201);
            this.tabPage5.Controls.Add(this.CXCVALIDARTRASLADOSTextBox);
            this.tabPage5.Controls.Add(this.label202);
            this.tabPage5.Controls.Add(this.label200);
            this.tabPage5.Controls.Add(this.HAB_PRECIOSCLIENTETextBox);
            this.tabPage5.Controls.Add(this.label199);
            this.tabPage5.Controls.Add(this.EANPUEDEREPETIRSETextBox);
            this.tabPage5.Controls.Add(this.label197);
            this.tabPage5.Controls.Add(this.PRECIOSORDENADOSTextBox);
            this.tabPage5.Controls.Add(this.label196);
            this.tabPage5.Controls.Add(this.label195);
            this.tabPage5.Controls.Add(this.HABPROMOXMONTOMINTextBox);
            this.tabPage5.Controls.Add(this.label189);
            this.tabPage5.Controls.Add(this.HABVERIFICACIONCXCTextBox);
            this.tabPage5.Controls.Add(this.label168);
            this.tabPage5.Controls.Add(this.HABSURTIDOPOSTPUESTOTextBox);
            this.tabPage5.Controls.Add(this.label144);
            this.tabPage5.Controls.Add(this.RECALCULARCAMBIOCLIENTETextBox);
            this.tabPage5.Controls.Add(this.label135);
            this.tabPage5.Controls.Add(this.REBAJAESPECIALTextBox);
            this.tabPage5.Controls.Add(this.label130);
            this.tabPage5.Controls.Add(this.label129);
            this.tabPage5.Controls.Add(this.LISTAPRECIOMINIMOComboBox);
            this.tabPage5.Controls.Add(this.label128);
            this.tabPage5.Controls.Add(this.CAMPOIMPOCOSTOREPOTextBox);
            this.tabPage5.Controls.Add(this.MANEJAKITSTextBox);
            this.tabPage5.Controls.Add(this.label127);
            this.tabPage5.Controls.Add(this.PRECIOXCAJAENPVTextBox);
            this.tabPage5.Controls.Add(this.label118);
            this.tabPage5.Controls.Add(this.AUTOCOMPCLIENTETextBox);
            this.tabPage5.Controls.Add(this.label117);
            this.tabPage5.Controls.Add(this.MOSTRARFLASHComboBox);
            this.tabPage5.Controls.Add(this.label116);
            this.tabPage5.Controls.Add(this.PRECIONETOENPVTextBox);
            this.tabPage5.Controls.Add(this.label113);
            this.tabPage5.Controls.Add(this.CAJASBOTELLASTextBox);
            this.tabPage5.Controls.Add(this.label112);
            this.tabPage5.Controls.Add(this.AUTOCOMPPRODTextBox);
            this.tabPage5.Controls.Add(this.label106);
            this.tabPage5.Controls.Add(this.label83);
            this.tabPage5.Controls.Add(this.FECHA2TextBox);
            this.tabPage5.Controls.Add(label26);
            this.tabPage5.Controls.Add(this.NUMERO4TextBox);
            this.tabPage5.Controls.Add(label27);
            this.tabPage5.Controls.Add(this.FECHA1TextBox);
            this.tabPage5.Controls.Add(label28);
            this.tabPage5.Controls.Add(this.NUMERO2TextBox);
            this.tabPage5.Controls.Add(label29);
            this.tabPage5.Controls.Add(this.NUMERO3TextBox);
            this.tabPage5.Controls.Add(label30);
            this.tabPage5.Controls.Add(this.NUMERO1TextBox);
            this.tabPage5.Controls.Add(label31);
            this.tabPage5.Controls.Add(this.TEXTO6TextBox);
            this.tabPage5.Controls.Add(TEXTO6Label);
            this.tabPage5.Controls.Add(this.TEXTO4TextBox);
            this.tabPage5.Controls.Add(TEXTO4Label);
            this.tabPage5.Controls.Add(this.TEXTO5TextBox);
            this.tabPage5.Controls.Add(TEXTO5Label);
            this.tabPage5.Controls.Add(this.TEXTO2TextBox);
            this.tabPage5.Controls.Add(TEXTO2Label);
            this.tabPage5.Controls.Add(this.TEXTO3TextBox);
            this.tabPage5.Controls.Add(TEXTO3Label);
            this.tabPage5.Controls.Add(this.TEXTO1TextBox);
            this.tabPage5.Controls.Add(TEXTO1Label);
            this.tabPage5.Controls.Add(this.VERSIONTOPEIDTextBox);
            this.tabPage5.Controls.Add(this.cancelXActNumericTextBox);
            this.tabPage5.Controls.Add(this.ALMACENRECEPCIONIDTextBox);
            this.tabPage5.Controls.Add(this.CADUCIDADMINIMATextBox);
            this.tabPage5.Controls.Add(this.DECIMALESENCANTIDADTextBox);
            this.tabPage5.Controls.Add(this.CORTACADUCIDADTextBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(782, 556);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Prod/Caract.";
            // 
            // label301
            // 
            this.label301.AutoSize = true;
            this.label301.Location = new System.Drawing.Point(673, 424);
            this.label301.Name = "label301";
            this.label301.Size = new System.Drawing.Size(46, 13);
            this.label301.TabIndex = 228;
            this.label301.Text = "previo:";
            // 
            // HABSURTIDOPREVIOTextBox
            // 
            this.HABSURTIDOPREVIOTextBox.FormattingEnabled = true;
            this.HABSURTIDOPREVIOTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABSURTIDOPREVIOTextBox.Location = new System.Drawing.Point(682, 440);
            this.HABSURTIDOPREVIOTextBox.Name = "HABSURTIDOPREVIOTextBox";
            this.HABSURTIDOPREVIOTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABSURTIDOPREVIOTextBox.TabIndex = 226;
            this.HABSURTIDOPREVIOTextBox.Tag = "";
            // 
            // label302
            // 
            this.label302.AutoSize = true;
            this.label302.Location = new System.Drawing.Point(672, 412);
            this.label302.Name = "label302";
            this.label302.Size = new System.Drawing.Size(76, 13);
            this.label302.TabIndex = 227;
            this.label302.Text = "Hab. surtido";
            // 
            // label300
            // 
            this.label300.AutoSize = true;
            this.label300.Location = new System.Drawing.Point(526, 423);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(82, 13);
            this.label300.TabIndex = 225;
            this.label300.Text = " x monto min:";
            // 
            // COSTOREPOIGUALCOSTOULTComboBox
            // 
            this.COSTOREPOIGUALCOSTOULTComboBox.FormattingEnabled = true;
            this.COSTOREPOIGUALCOSTOULTComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.COSTOREPOIGUALCOSTOULTComboBox.Location = new System.Drawing.Point(674, 198);
            this.COSTOREPOIGUALCOSTOULTComboBox.Name = "COSTOREPOIGUALCOSTOULTComboBox";
            this.COSTOREPOIGUALCOSTOULTComboBox.Size = new System.Drawing.Size(62, 21);
            this.COSTOREPOIGUALCOSTOULTComboBox.TabIndex = 224;
            this.COSTOREPOIGUALCOSTOULTComboBox.Tag = "";
            // 
            // label288
            // 
            this.label288.AutoSize = true;
            this.label288.Location = new System.Drawing.Point(638, 181);
            this.label288.Name = "label288";
            this.label288.Size = new System.Drawing.Size(144, 13);
            this.label288.TabIndex = 223;
            this.label288.Text = "Costo repo = Costo ult?:";
            // 
            // HABMULTPLAZOCOMPRATextBox
            // 
            this.HABMULTPLAZOCOMPRATextBox.FormattingEnabled = true;
            this.HABMULTPLAZOCOMPRATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABMULTPLAZOCOMPRATextBox.Location = new System.Drawing.Point(681, 389);
            this.HABMULTPLAZOCOMPRATextBox.Name = "HABMULTPLAZOCOMPRATextBox";
            this.HABMULTPLAZOCOMPRATextBox.Size = new System.Drawing.Size(62, 21);
            this.HABMULTPLAZOCOMPRATextBox.TabIndex = 220;
            this.HABMULTPLAZOCOMPRATextBox.Tag = "";
            // 
            // label286
            // 
            this.label286.AutoSize = true;
            this.label286.Location = new System.Drawing.Point(664, 373);
            this.label286.Name = "label286";
            this.label286.Size = new System.Drawing.Size(125, 13);
            this.label286.TabIndex = 221;
            this.label286.Text = "Hab. Plazos Compra:";
            // 
            // MANEJAUTILIDADPRECIOSTextBox
            // 
            this.MANEJAUTILIDADPRECIOSTextBox.FormattingEnabled = true;
            this.MANEJAUTILIDADPRECIOSTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJAUTILIDADPRECIOSTextBox.Location = new System.Drawing.Point(682, 336);
            this.MANEJAUTILIDADPRECIOSTextBox.Name = "MANEJAUTILIDADPRECIOSTextBox";
            this.MANEJAUTILIDADPRECIOSTextBox.Size = new System.Drawing.Size(62, 21);
            this.MANEJAUTILIDADPRECIOSTextBox.TabIndex = 218;
            this.MANEJAUTILIDADPRECIOSTextBox.Tag = "";
            // 
            // label284
            // 
            this.label284.AutoSize = true;
            this.label284.Location = new System.Drawing.Point(665, 320);
            this.label284.Name = "label284";
            this.label284.Size = new System.Drawing.Size(104, 13);
            this.label284.TabIndex = 219;
            this.label284.Text = "Maneja util/prec:";
            // 
            // HABREVISIONFINALTextBox
            // 
            this.HABREVISIONFINALTextBox.FormattingEnabled = true;
            this.HABREVISIONFINALTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABREVISIONFINALTextBox.Location = new System.Drawing.Point(682, 287);
            this.HABREVISIONFINALTextBox.Name = "HABREVISIONFINALTextBox";
            this.HABREVISIONFINALTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABREVISIONFINALTextBox.TabIndex = 216;
            this.HABREVISIONFINALTextBox.Tag = "";
            // 
            // label263
            // 
            this.label263.AutoSize = true;
            this.label263.Location = new System.Drawing.Point(656, 271);
            this.label263.Name = "label263";
            this.label263.Size = new System.Drawing.Size(110, 13);
            this.label263.TabIndex = 217;
            this.label263.Text = "Hab. revision final";
            // 
            // label247
            // 
            this.label247.AutoSize = true;
            this.label247.Location = new System.Drawing.Point(463, 496);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(103, 13);
            this.label247.TabIndex = 212;
            this.label247.Text = "Busqueda Tipo 2";
            // 
            // cbBusquedaTipo2
            // 
            this.cbBusquedaTipo2.AutoSize = true;
            this.cbBusquedaTipo2.Location = new System.Drawing.Point(442, 496);
            this.cbBusquedaTipo2.Name = "cbBusquedaTipo2";
            this.cbBusquedaTipo2.Size = new System.Drawing.Size(15, 14);
            this.cbBusquedaTipo2.TabIndex = 213;
            this.cbBusquedaTipo2.UseVisualStyleBackColor = true;
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Location = new System.Drawing.Point(194, 324);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(67, 13);
            this.label241.TabIndex = 211;
            this.label241.Text = "de surtido:";
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(15, 423);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(120, 13);
            this.label240.TabIndex = 210;
            this.label240.Text = "orden descendente:";
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(16, 373);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(78, 13);
            this.label239.TabIndex = 209;
            this.label239.Text = "en cantidad:";
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(16, 320);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(81, 13);
            this.label238.TabIndex = 208;
            this.label238.Text = "para compra:";
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(16, 274);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(129, 13);
            this.label237.TabIndex = 207;
            this.label237.Text = "\"caducidad proxima\":";
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Location = new System.Drawing.Point(224, 447);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(0, 13);
            this.label236.TabIndex = 206;
            // 
            // PRECIONETOENGRIDSTextBox
            // 
            this.PRECIONETOENGRIDSTextBox.FormattingEnabled = true;
            this.PRECIONETOENGRIDSTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PRECIONETOENGRIDSTextBox.Location = new System.Drawing.Point(611, 533);
            this.PRECIONETOENGRIDSTextBox.Name = "PRECIONETOENGRIDSTextBox";
            this.PRECIONETOENGRIDSTextBox.Size = new System.Drawing.Size(62, 21);
            this.PRECIONETOENGRIDSTextBox.TabIndex = 204;
            this.PRECIONETOENGRIDSTextBox.Tag = "";
            // 
            // label226
            // 
            this.label226.AutoSize = true;
            this.label226.Location = new System.Drawing.Point(608, 517);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(132, 13);
            this.label226.TabIndex = 205;
            this.label226.Text = "Precio neto en grids?:";
            // 
            // label217
            // 
            this.label217.AutoSize = true;
            this.label217.Location = new System.Drawing.Point(34, 474);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(208, 13);
            this.label217.TabIndex = 200;
            this.label217.Text = "Actualizar precios automaticamente";
            // 
            // actPrecAutoCB
            // 
            this.actPrecAutoCB.AutoSize = true;
            this.actPrecAutoCB.Location = new System.Drawing.Point(17, 474);
            this.actPrecAutoCB.Name = "actPrecAutoCB";
            this.actPrecAutoCB.Size = new System.Drawing.Size(15, 14);
            this.actPrecAutoCB.TabIndex = 199;
            this.actPrecAutoCB.UseVisualStyleBackColor = true;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAlmacen.Location = new System.Drawing.Point(608, 473);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(174, 13);
            this.lblAlmacen.TabIndex = 199;
            this.lblAlmacen.Text = "Almacen recepción traslados:";
            // 
            // autocompleteConExistenciaCB
            // 
            this.autocompleteConExistenciaCB.AutoSize = true;
            this.autocompleteConExistenciaCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autocompleteConExistenciaCB.Location = new System.Drawing.Point(285, 472);
            this.autocompleteConExistenciaCB.Name = "autocompleteConExistenciaCB";
            this.autocompleteConExistenciaCB.Size = new System.Drawing.Size(172, 16);
            this.autocompleteConExistenciaCB.TabIndex = 125;
            this.autocompleteConExistenciaCB.Text = "AutoComplete con existencia";
            this.autocompleteConExistenciaCB.UseVisualStyleBackColor = true;
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(463, 520);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(120, 13);
            this.label214.TabIndex = 197;
            this.label214.Text = "Plazos por producto";
            // 
            // cbPlazosXProducto
            // 
            this.cbPlazosXProducto.AutoSize = true;
            this.cbPlazosXProducto.Location = new System.Drawing.Point(442, 520);
            this.cbPlazosXProducto.Name = "cbPlazosXProducto";
            this.cbPlazosXProducto.Size = new System.Drawing.Size(15, 14);
            this.cbPlazosXProducto.TabIndex = 198;
            this.cbPlazosXProducto.UseVisualStyleBackColor = true;
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(15, 309);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(111, 13);
            this.label210.TabIndex = 194;
            this.label210.Text = "Caducidad mínima";
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(347, 423);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(128, 13);
            this.label201.TabIndex = 192;
            this.label201.Text = "y surtimiento de suc.:";
            // 
            // CXCVALIDARTRASLADOSTextBox
            // 
            this.CXCVALIDARTRASLADOSTextBox.FormattingEnabled = true;
            this.CXCVALIDARTRASLADOSTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CXCVALIDARTRASLADOSTextBox.Location = new System.Drawing.Point(372, 439);
            this.CXCVALIDARTRASLADOSTextBox.Name = "CXCVALIDARTRASLADOSTextBox";
            this.CXCVALIDARTRASLADOSTextBox.Size = new System.Drawing.Size(62, 21);
            this.CXCVALIDARTRASLADOSTextBox.TabIndex = 190;
            this.CXCVALIDARTRASLADOSTextBox.Tag = "";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(333, 409);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(166, 13);
            this.label202.TabIndex = 191;
            this.label202.Text = "Verificar CXC para traslados";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(183, 372);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(96, 13);
            this.label200.TabIndex = 189;
            this.label200.Text = "barras repetido:";
            // 
            // HAB_PRECIOSCLIENTETextBox
            // 
            this.HAB_PRECIOSCLIENTETextBox.FormattingEnabled = true;
            this.HAB_PRECIOSCLIENTETextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HAB_PRECIOSCLIENTETextBox.Location = new System.Drawing.Point(535, 386);
            this.HAB_PRECIOSCLIENTETextBox.Name = "HAB_PRECIOSCLIENTETextBox";
            this.HAB_PRECIOSCLIENTETextBox.Size = new System.Drawing.Size(62, 21);
            this.HAB_PRECIOSCLIENTETextBox.TabIndex = 187;
            this.HAB_PRECIOSCLIENTETextBox.Tag = "";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(497, 369);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(156, 13);
            this.label199.TabIndex = 188;
            this.label199.Text = "Permitir precio por cliente:";
            // 
            // EANPUEDEREPETIRSETextBox
            // 
            this.EANPUEDEREPETIRSETextBox.FormattingEnabled = true;
            this.EANPUEDEREPETIRSETextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.EANPUEDEREPETIRSETextBox.Location = new System.Drawing.Point(197, 386);
            this.EANPUEDEREPETIRSETextBox.Name = "EANPUEDEREPETIRSETextBox";
            this.EANPUEDEREPETIRSETextBox.Size = new System.Drawing.Size(62, 21);
            this.EANPUEDEREPETIRSETextBox.TabIndex = 185;
            this.EANPUEDEREPETIRSETextBox.Tag = "";
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Location = new System.Drawing.Point(178, 359);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(109, 13);
            this.label197.TabIndex = 186;
            this.label197.Text = "Permitir codigo de";
            // 
            // PRECIOSORDENADOSTextBox
            // 
            this.PRECIOSORDENADOSTextBox.FormattingEnabled = true;
            this.PRECIOSORDENADOSTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PRECIOSORDENADOSTextBox.Location = new System.Drawing.Point(17, 439);
            this.PRECIOSORDENADOSTextBox.Name = "PRECIOSORDENADOSTextBox";
            this.PRECIOSORDENADOSTextBox.Size = new System.Drawing.Size(62, 21);
            this.PRECIOSORDENADOSTextBox.TabIndex = 183;
            this.PRECIOSORDENADOSTextBox.Tag = "";
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Location = new System.Drawing.Point(14, 409);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(121, 13);
            this.label196.TabIndex = 184;
            this.label196.Text = "Precios de producto";
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Location = new System.Drawing.Point(16, 360);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(128, 13);
            this.label195.TabIndex = 182;
            this.label195.Text = "Numero de decimales";
            // 
            // HABPROMOXMONTOMINTextBox
            // 
            this.HABPROMOXMONTOMINTextBox.FormattingEnabled = true;
            this.HABPROMOXMONTOMINTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABPROMOXMONTOMINTextBox.Location = new System.Drawing.Point(535, 439);
            this.HABPROMOXMONTOMINTextBox.Name = "HABPROMOXMONTOMINTextBox";
            this.HABPROMOXMONTOMINTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABPROMOXMONTOMINTextBox.TabIndex = 179;
            this.HABPROMOXMONTOMINTextBox.Tag = "";
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(505, 410);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(117, 13);
            this.label189.TabIndex = 180;
            this.label189.Text = "Hab. promo. x linea";
            // 
            // HABVERIFICACIONCXCTextBox
            // 
            this.HABVERIFICACIONCXCTextBox.FormattingEnabled = true;
            this.HABVERIFICACIONCXCTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABVERIFICACIONCXCTextBox.Location = new System.Drawing.Point(197, 336);
            this.HABVERIFICACIONCXCTextBox.Name = "HABVERIFICACIONCXCTextBox";
            this.HABVERIFICACIONCXCTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABVERIFICACIONCXCTextBox.TabIndex = 164;
            this.HABVERIFICACIONCXCTextBox.Tag = "";
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(168, 311);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(117, 13);
            this.label168.TabIndex = 165;
            this.label168.Text = "Verificar CXC antes";
            // 
            // HABSURTIDOPOSTPUESTOTextBox
            // 
            this.HABSURTIDOPOSTPUESTOTextBox.FormattingEnabled = true;
            this.HABSURTIDOPOSTPUESTOTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABSURTIDOPOSTPUESTOTextBox.Location = new System.Drawing.Point(373, 385);
            this.HABSURTIDOPOSTPUESTOTextBox.Name = "HABSURTIDOPOSTPUESTOTextBox";
            this.HABSURTIDOPOSTPUESTOTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABSURTIDOPOSTPUESTOTextBox.TabIndex = 162;
            this.HABSURTIDOPOSTPUESTOTextBox.Tag = "";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(333, 369);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(164, 13);
            this.label144.TabIndex = 163;
            this.label144.Text = "Permitir surtido en almacen:";
            // 
            // RECALCULARCAMBIOCLIENTETextBox
            // 
            this.RECALCULARCAMBIOCLIENTETextBox.FormattingEnabled = true;
            this.RECALCULARCAMBIOCLIENTETextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.RECALCULARCAMBIOCLIENTETextBox.Location = new System.Drawing.Point(494, 45);
            this.RECALCULARCAMBIOCLIENTETextBox.Name = "RECALCULARCAMBIOCLIENTETextBox";
            this.RECALCULARCAMBIOCLIENTETextBox.Size = new System.Drawing.Size(62, 21);
            this.RECALCULARCAMBIOCLIENTETextBox.TabIndex = 160;
            this.RECALCULARCAMBIOCLIENTETextBox.Tag = "";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(491, 29);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(212, 13);
            this.label135.TabIndex = 161;
            this.label135.Text = "Recalcular venta al cambiar cliente:";
            // 
            // REBAJAESPECIALTextBox
            // 
            this.REBAJAESPECIALTextBox.FormattingEnabled = true;
            this.REBAJAESPECIALTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.REBAJAESPECIALTextBox.Location = new System.Drawing.Point(494, 108);
            this.REBAJAESPECIALTextBox.Name = "REBAJAESPECIALTextBox";
            this.REBAJAESPECIALTextBox.Size = new System.Drawing.Size(62, 21);
            this.REBAJAESPECIALTextBox.TabIndex = 154;
            this.REBAJAESPECIALTextBox.Tag = "";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(491, 92);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(203, 13);
            this.label130.TabIndex = 155;
            this.label130.Text = "Maneja rebaja por nota de credito:";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(496, 182);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(89, 13);
            this.label129.TabIndex = 153;
            this.label129.Text = "Precio minimo:";
            // 
            // LISTAPRECIOMINIMOComboBox
            // 
            this.LISTAPRECIOMINIMOComboBox.FormattingEnabled = true;
            this.LISTAPRECIOMINIMOComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOMINIMOComboBox.Location = new System.Drawing.Point(499, 198);
            this.LISTAPRECIOMINIMOComboBox.Name = "LISTAPRECIOMINIMOComboBox";
            this.LISTAPRECIOMINIMOComboBox.Size = new System.Drawing.Size(62, 21);
            this.LISTAPRECIOMINIMOComboBox.TabIndex = 152;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(496, 222);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(143, 13);
            this.label128.TabIndex = 151;
            this.label128.Text = "Importar costo repo. de:";
            // 
            // CAMPOIMPOCOSTOREPOTextBox
            // 
            this.CAMPOIMPOCOSTOREPOTextBox.FormattingEnabled = true;
            this.CAMPOIMPOCOSTOREPOTextBox.Items.AddRange(new object[] {
            "Costo Reposicion",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.CAMPOIMPOCOSTOREPOTextBox.Location = new System.Drawing.Point(499, 238);
            this.CAMPOIMPOCOSTOREPOTextBox.Name = "CAMPOIMPOCOSTOREPOTextBox";
            this.CAMPOIMPOCOSTOREPOTextBox.Size = new System.Drawing.Size(140, 21);
            this.CAMPOIMPOCOSTOREPOTextBox.TabIndex = 150;
            // 
            // MANEJAKITSTextBox
            // 
            this.MANEJAKITSTextBox.FormattingEnabled = true;
            this.MANEJAKITSTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MANEJAKITSTextBox.Location = new System.Drawing.Point(535, 287);
            this.MANEJAKITSTextBox.Name = "MANEJAKITSTextBox";
            this.MANEJAKITSTextBox.Size = new System.Drawing.Size(62, 21);
            this.MANEJAKITSTextBox.TabIndex = 148;
            this.MANEJAKITSTextBox.Tag = "";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(532, 271);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(76, 13);
            this.label127.TabIndex = 149;
            this.label127.Text = "Maneja kits:";
            // 
            // PRECIOXCAJAENPVTextBox
            // 
            this.PRECIOXCAJAENPVTextBox.FormattingEnabled = true;
            this.PRECIOXCAJAENPVTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PRECIOXCAJAENPVTextBox.Location = new System.Drawing.Point(535, 336);
            this.PRECIOXCAJAENPVTextBox.Name = "PRECIOXCAJAENPVTextBox";
            this.PRECIOXCAJAENPVTextBox.Size = new System.Drawing.Size(62, 21);
            this.PRECIOXCAJAENPVTextBox.TabIndex = 146;
            this.PRECIOXCAJAENPVTextBox.Tag = "";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(497, 321);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(146, 13);
            this.label118.TabIndex = 147;
            this.label118.Text = "Precio x caja en venta?:";
            // 
            // AUTOCOMPCLIENTETextBox
            // 
            this.AUTOCOMPCLIENTETextBox.FormattingEnabled = true;
            this.AUTOCOMPCLIENTETextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.AUTOCOMPCLIENTETextBox.Location = new System.Drawing.Point(341, 514);
            this.AUTOCOMPCLIENTETextBox.Name = "AUTOCOMPCLIENTETextBox";
            this.AUTOCOMPCLIENTETextBox.Size = new System.Drawing.Size(62, 21);
            this.AUTOCOMPCLIENTETextBox.TabIndex = 144;
            this.AUTOCOMPCLIENTETextBox.Tag = "";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(303, 496);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(136, 13);
            this.label117.TabIndex = 145;
            this.label117.Text = "Autocomplete clientes:";
            // 
            // MOSTRARFLASHComboBox
            // 
            this.MOSTRARFLASHComboBox.FormattingEnabled = true;
            this.MOSTRARFLASHComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRARFLASHComboBox.Location = new System.Drawing.Point(197, 287);
            this.MOSTRARFLASHComboBox.Name = "MOSTRARFLASHComboBox";
            this.MOSTRARFLASHComboBox.Size = new System.Drawing.Size(62, 21);
            this.MOSTRARFLASHComboBox.TabIndex = 142;
            this.MOSTRARFLASHComboBox.Tag = "";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(171, 271);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(114, 13);
            this.label116.TabIndex = 143;
            this.label116.Text = "Mostrar animacion:";
            // 
            // PRECIONETOENPVTextBox
            // 
            this.PRECIONETOENPVTextBox.FormattingEnabled = true;
            this.PRECIONETOENPVTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PRECIONETOENPVTextBox.Location = new System.Drawing.Point(373, 336);
            this.PRECIONETOENPVTextBox.Name = "PRECIONETOENPVTextBox";
            this.PRECIONETOENPVTextBox.Size = new System.Drawing.Size(62, 21);
            this.PRECIONETOENPVTextBox.TabIndex = 140;
            this.PRECIONETOENPVTextBox.Tag = "";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(338, 317);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(137, 13);
            this.label113.TabIndex = 141;
            this.label113.Text = "Precio neto en venta?:";
            // 
            // CAJASBOTELLASTextBox
            // 
            this.CAJASBOTELLASTextBox.FormattingEnabled = true;
            this.CAJASBOTELLASTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CAJASBOTELLASTextBox.Location = new System.Drawing.Point(373, 287);
            this.CAJASBOTELLASTextBox.Name = "CAJASBOTELLASTextBox";
            this.CAJASBOTELLASTextBox.Size = new System.Drawing.Size(62, 21);
            this.CAJASBOTELLASTextBox.TabIndex = 138;
            this.CAJASBOTELLASTextBox.Tag = "";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(364, 271);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(93, 13);
            this.label112.TabIndex = 139;
            this.label112.Text = "Cajas/Botellas:";
            // 
            // AUTOCOMPPRODTextBox
            // 
            this.AUTOCOMPPRODTextBox.FormattingEnabled = true;
            this.AUTOCOMPPRODTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.AUTOCOMPPRODTextBox.Location = new System.Drawing.Point(197, 439);
            this.AUTOCOMPPRODTextBox.Name = "AUTOCOMPPRODTextBox";
            this.AUTOCOMPPRODTextBox.Size = new System.Drawing.Size(62, 21);
            this.AUTOCOMPPRODTextBox.TabIndex = 136;
            this.AUTOCOMPPRODTextBox.Tag = "";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(191, 423);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(88, 13);
            this.label106.TabIndex = 137;
            this.label106.Text = "Autocomplete:";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(15, 261);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(124, 13);
            this.label83.TabIndex = 135;
            this.label83.Text = "Dias para considerar";
            // 
            // FECHA2TextBox
            // 
            this.FECHA2TextBox.Location = new System.Drawing.Point(261, 238);
            this.FECHA2TextBox.Name = "FECHA2TextBox";
            this.FECHA2TextBox.Size = new System.Drawing.Size(203, 20);
            this.FECHA2TextBox.TabIndex = 132;
            // 
            // NUMERO4TextBox
            // 
            this.NUMERO4TextBox.Location = new System.Drawing.Point(261, 198);
            this.NUMERO4TextBox.Name = "NUMERO4TextBox";
            this.NUMERO4TextBox.Size = new System.Drawing.Size(203, 20);
            this.NUMERO4TextBox.TabIndex = 125;
            // 
            // FECHA1TextBox
            // 
            this.FECHA1TextBox.Location = new System.Drawing.Point(11, 238);
            this.FECHA1TextBox.Name = "FECHA1TextBox";
            this.FECHA1TextBox.Size = new System.Drawing.Size(203, 20);
            this.FECHA1TextBox.TabIndex = 128;
            // 
            // NUMERO2TextBox
            // 
            this.NUMERO2TextBox.Location = new System.Drawing.Point(261, 155);
            this.NUMERO2TextBox.Name = "NUMERO2TextBox";
            this.NUMERO2TextBox.Size = new System.Drawing.Size(203, 20);
            this.NUMERO2TextBox.TabIndex = 123;
            // 
            // NUMERO3TextBox
            // 
            this.NUMERO3TextBox.Location = new System.Drawing.Point(11, 198);
            this.NUMERO3TextBox.Name = "NUMERO3TextBox";
            this.NUMERO3TextBox.Size = new System.Drawing.Size(203, 20);
            this.NUMERO3TextBox.TabIndex = 124;
            // 
            // NUMERO1TextBox
            // 
            this.NUMERO1TextBox.Location = new System.Drawing.Point(11, 155);
            this.NUMERO1TextBox.Name = "NUMERO1TextBox";
            this.NUMERO1TextBox.Size = new System.Drawing.Size(203, 20);
            this.NUMERO1TextBox.TabIndex = 122;
            // 
            // TEXTO6TextBox
            // 
            this.TEXTO6TextBox.Location = new System.Drawing.Point(261, 108);
            this.TEXTO6TextBox.Name = "TEXTO6TextBox";
            this.TEXTO6TextBox.Size = new System.Drawing.Size(203, 20);
            this.TEXTO6TextBox.TabIndex = 120;
            // 
            // TEXTO4TextBox
            // 
            this.TEXTO4TextBox.Location = new System.Drawing.Point(261, 68);
            this.TEXTO4TextBox.Name = "TEXTO4TextBox";
            this.TEXTO4TextBox.Size = new System.Drawing.Size(203, 20);
            this.TEXTO4TextBox.TabIndex = 113;
            // 
            // TEXTO5TextBox
            // 
            this.TEXTO5TextBox.Location = new System.Drawing.Point(11, 108);
            this.TEXTO5TextBox.Name = "TEXTO5TextBox";
            this.TEXTO5TextBox.Size = new System.Drawing.Size(203, 20);
            this.TEXTO5TextBox.TabIndex = 116;
            // 
            // TEXTO2TextBox
            // 
            this.TEXTO2TextBox.Location = new System.Drawing.Point(261, 29);
            this.TEXTO2TextBox.Name = "TEXTO2TextBox";
            this.TEXTO2TextBox.Size = new System.Drawing.Size(203, 20);
            this.TEXTO2TextBox.TabIndex = 111;
            // 
            // TEXTO3TextBox
            // 
            this.TEXTO3TextBox.Location = new System.Drawing.Point(11, 68);
            this.TEXTO3TextBox.Name = "TEXTO3TextBox";
            this.TEXTO3TextBox.Size = new System.Drawing.Size(203, 20);
            this.TEXTO3TextBox.TabIndex = 112;
            // 
            // TEXTO1TextBox
            // 
            this.TEXTO1TextBox.Location = new System.Drawing.Point(11, 29);
            this.TEXTO1TextBox.Name = "TEXTO1TextBox";
            this.TEXTO1TextBox.Size = new System.Drawing.Size(203, 20);
            this.TEXTO1TextBox.TabIndex = 110;
            // 
            // VERSIONTOPEIDTextBox
            // 
            this.VERSIONTOPEIDTextBox.AllowNegative = true;
            this.VERSIONTOPEIDTextBox.Format_Expression = null;
            this.VERSIONTOPEIDTextBox.Location = new System.Drawing.Point(495, 155);
            this.VERSIONTOPEIDTextBox.Name = "VERSIONTOPEIDTextBox";
            this.VERSIONTOPEIDTextBox.NumericPrecision = 1;
            this.VERSIONTOPEIDTextBox.NumericScaleOnFocus = 0;
            this.VERSIONTOPEIDTextBox.NumericScaleOnLostFocus = 0;
            this.VERSIONTOPEIDTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VERSIONTOPEIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.VERSIONTOPEIDTextBox.TabIndex = 215;
            this.VERSIONTOPEIDTextBox.Tag = 34;
            this.VERSIONTOPEIDTextBox.Text = "0";
            this.VERSIONTOPEIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.VERSIONTOPEIDTextBox.ValidationExpression = null;
            this.VERSIONTOPEIDTextBox.ZeroIsValid = false;
            // 
            // cancelXActNumericTextBox
            // 
            this.cancelXActNumericTextBox.AllowNegative = true;
            this.cancelXActNumericTextBox.Format_Expression = null;
            this.cancelXActNumericTextBox.Location = new System.Drawing.Point(15, 514);
            this.cancelXActNumericTextBox.Name = "cancelXActNumericTextBox";
            this.cancelXActNumericTextBox.NumericPrecision = 1;
            this.cancelXActNumericTextBox.NumericScaleOnFocus = 0;
            this.cancelXActNumericTextBox.NumericScaleOnLostFocus = 0;
            this.cancelXActNumericTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cancelXActNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.cancelXActNumericTextBox.TabIndex = 203;
            this.cancelXActNumericTextBox.Tag = 34;
            this.cancelXActNumericTextBox.Text = "0";
            this.cancelXActNumericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cancelXActNumericTextBox.ValidationExpression = null;
            this.cancelXActNumericTextBox.ZeroIsValid = false;
            // 
            // ALMACENRECEPCIONIDTextBox
            // 
            this.ALMACENRECEPCIONIDTextBox.Condicion = null;
            this.ALMACENRECEPCIONIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENRECEPCIONIDTextBox.DisplayMember = "nombre";
            this.ALMACENRECEPCIONIDTextBox.FormattingEnabled = true;
            this.ALMACENRECEPCIONIDTextBox.IndiceCampoSelector = 0;
            this.ALMACENRECEPCIONIDTextBox.LabelDescription = null;
            this.ALMACENRECEPCIONIDTextBox.Location = new System.Drawing.Point(611, 488);
            this.ALMACENRECEPCIONIDTextBox.Name = "ALMACENRECEPCIONIDTextBox";
            this.ALMACENRECEPCIONIDTextBox.NombreCampoSelector = "id";
            this.ALMACENRECEPCIONIDTextBox.Query = "select id,nombre from almacen";
            this.ALMACENRECEPCIONIDTextBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENRECEPCIONIDTextBox.SelectedDataDisplaying = null;
            this.ALMACENRECEPCIONIDTextBox.SelectedDataValue = null;
            this.ALMACENRECEPCIONIDTextBox.Size = new System.Drawing.Size(125, 21);
            this.ALMACENRECEPCIONIDTextBox.TabIndex = 200;
            this.ALMACENRECEPCIONIDTextBox.ValueMember = "id";
            // 
            // CADUCIDADMINIMATextBox
            // 
            this.CADUCIDADMINIMATextBox.AllowNegative = false;
            this.CADUCIDADMINIMATextBox.Format_Expression = null;
            this.CADUCIDADMINIMATextBox.Location = new System.Drawing.Point(18, 336);
            this.CADUCIDADMINIMATextBox.Name = "CADUCIDADMINIMATextBox";
            this.CADUCIDADMINIMATextBox.NumericPrecision = 3;
            this.CADUCIDADMINIMATextBox.NumericScaleOnFocus = 0;
            this.CADUCIDADMINIMATextBox.NumericScaleOnLostFocus = 0;
            this.CADUCIDADMINIMATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CADUCIDADMINIMATextBox.Size = new System.Drawing.Size(62, 20);
            this.CADUCIDADMINIMATextBox.TabIndex = 193;
            this.CADUCIDADMINIMATextBox.Tag = 34;
            this.CADUCIDADMINIMATextBox.Text = "0";
            this.CADUCIDADMINIMATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CADUCIDADMINIMATextBox.ValidationExpression = null;
            this.CADUCIDADMINIMATextBox.ZeroIsValid = true;
            // 
            // DECIMALESENCANTIDADTextBox
            // 
            this.DECIMALESENCANTIDADTextBox.AllowNegative = false;
            this.DECIMALESENCANTIDADTextBox.Format_Expression = null;
            this.DECIMALESENCANTIDADTextBox.Location = new System.Drawing.Point(18, 386);
            this.DECIMALESENCANTIDADTextBox.Name = "DECIMALESENCANTIDADTextBox";
            this.DECIMALESENCANTIDADTextBox.NumericPrecision = 3;
            this.DECIMALESENCANTIDADTextBox.NumericScaleOnFocus = 0;
            this.DECIMALESENCANTIDADTextBox.NumericScaleOnLostFocus = 0;
            this.DECIMALESENCANTIDADTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DECIMALESENCANTIDADTextBox.Size = new System.Drawing.Size(62, 20);
            this.DECIMALESENCANTIDADTextBox.TabIndex = 181;
            this.DECIMALESENCANTIDADTextBox.Tag = 34;
            this.DECIMALESENCANTIDADTextBox.Text = "0";
            this.DECIMALESENCANTIDADTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DECIMALESENCANTIDADTextBox.ValidationExpression = null;
            this.DECIMALESENCANTIDADTextBox.ZeroIsValid = true;
            // 
            // CORTACADUCIDADTextBox
            // 
            this.CORTACADUCIDADTextBox.AllowNegative = false;
            this.CORTACADUCIDADTextBox.Format_Expression = null;
            this.CORTACADUCIDADTextBox.Location = new System.Drawing.Point(17, 286);
            this.CORTACADUCIDADTextBox.Name = "CORTACADUCIDADTextBox";
            this.CORTACADUCIDADTextBox.NumericPrecision = 3;
            this.CORTACADUCIDADTextBox.NumericScaleOnFocus = 0;
            this.CORTACADUCIDADTextBox.NumericScaleOnLostFocus = 0;
            this.CORTACADUCIDADTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CORTACADUCIDADTextBox.Size = new System.Drawing.Size(62, 20);
            this.CORTACADUCIDADTextBox.TabIndex = 134;
            this.CORTACADUCIDADTextBox.Tag = 34;
            this.CORTACADUCIDADTextBox.Text = "0";
            this.CORTACADUCIDADTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CORTACADUCIDADTextBox.ValidationExpression = null;
            this.CORTACADUCIDADTextBox.ZeroIsValid = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Transparent;
            this.tabPage6.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage6.Controls.Add(this.SERIECOMPRTRASLSATTextBox);
            this.tabPage6.Controls.Add(this.label308);
            this.tabPage6.Controls.Add(this.FISCALFECHACANCELACION2TextBox);
            this.tabPage6.Controls.Add(this.label278);
            this.tabPage6.Controls.Add(this.label252);
            this.tabPage6.Controls.Add(this.DESGLOSEIEPSFACTURATextBox);
            this.tabPage6.Controls.Add(this.VERSIONCFDITextBox);
            this.tabPage6.Controls.Add(this.label248);
            this.tabPage6.Controls.Add(this.GENERARFECheckBox);
            this.tabPage6.Controls.Add(this.PAGOSERVCONSOLIDADOTextBox);
            this.tabPage6.Controls.Add(this.METPAGOSATIDButton);
            this.tabPage6.Controls.Add(this.METPAGOSATIDValLabel);
            this.tabPage6.Controls.Add(this.METPAGOSATIDLabel);
            this.tabPage6.Controls.Add(this.REGIMENSATFBButton);
            this.tabPage6.Controls.Add(this.REGIMENSATLBL);
            this.tabPage6.Controls.Add(this.FORMATOFACTURAComboBox);
            this.tabPage6.Controls.Add(this.label190);
            this.tabPage6.Controls.Add(this.SERIESATABONOTextBox);
            this.tabPage6.Controls.Add(this.label178);
            this.tabPage6.Controls.Add(this.label145);
            this.tabPage6.Controls.Add(this.CLIENTECLAVEButton);
            this.tabPage6.Controls.Add(this.CLIENTECLAVELabel);
            this.tabPage6.Controls.Add(this.label98);
            this.tabPage6.Controls.Add(this.CUENTAIEPSTextBox);
            this.tabPage6.Controls.Add(this.label99);
            this.tabPage6.Controls.Add(this.DESGLOSEIEPSTextBox);
            this.tabPage6.Controls.Add(this.label85);
            this.tabPage6.Controls.Add(this.label84);
            this.tabPage6.Controls.Add(this.ARRENDATARIOCheckBox);
            this.tabPage6.Controls.Add(this.label82);
            this.tabPage6.Controls.Add(this.FISCALREGIMENTextBox);
            this.tabPage6.Controls.Add(this.PACUSUARIOTextBox);
            this.tabPage6.Controls.Add(this.label71);
            this.tabPage6.Controls.Add(this.PACNOMBRETextBox);
            this.tabPage6.Controls.Add(this.label72);
            this.tabPage6.Controls.Add(this.SERIESATDEVOLUCIONTextBox);
            this.tabPage6.Controls.Add(this.label55);
            this.tabPage6.Controls.Add(this.USARFISCALESENEXPEDICIONCheckBox);
            this.tabPage6.Controls.Add(this.SERIESATTextBox);
            this.tabPage6.Controls.Add(this.label44);
            this.tabPage6.Controls.Add(this.label35);
            this.tabPage6.Controls.Add(this.label36);
            this.tabPage6.Controls.Add(this.label37);
            this.tabPage6.Controls.Add(this.label38);
            this.tabPage6.Controls.Add(this.label42);
            this.tabPage6.Controls.Add(this.label43);
            this.tabPage6.Controls.Add(this.label39);
            this.tabPage6.Controls.Add(this.TIMBRADOKEYTextBox);
            this.tabPage6.Controls.Add(this.TIMBRADOARCHIVOKEYTextBox);
            this.tabPage6.Controls.Add(this.TIMBRADOARCHIVOCERTIFICADOTextBox);
            this.tabPage6.Controls.Add(this.TIMBRADOPASSWORDTextBox);
            this.tabPage6.Controls.Add(this.TIMBRADOUSERTextBox);
            this.tabPage6.Controls.Add(this.FISCALNOMBRETextBox);
            this.tabPage6.Controls.Add(this.CERTIFICADOCSDTextBox);
            this.tabPage6.Controls.Add(this.label40);
            this.tabPage6.Controls.Add(this.label41);
            this.tabPage6.Controls.Add(this.FISCALNUMEROINTERIORTextBox);
            this.tabPage6.Controls.Add(this.FISCALNUMEROEXTERIORTextBox);
            this.tabPage6.Controls.Add(this.label45);
            this.tabPage6.Controls.Add(this.FISCALCODIGOPOSTALTextBox);
            this.tabPage6.Controls.Add(this.label46);
            this.tabPage6.Controls.Add(this.label47);
            this.tabPage6.Controls.Add(this.FISCALMUNICIPIOTextBox);
            this.tabPage6.Controls.Add(this.label48);
            this.tabPage6.Controls.Add(this.FISCALCALLETextBox);
            this.tabPage6.Controls.Add(this.FISCALCOLONIATextBox);
            this.tabPage6.Controls.Add(this.label49);
            this.tabPage6.Controls.Add(this.METPAGOSATIDTextBox);
            this.tabPage6.Controls.Add(this.REGIMENSATFBTextBox);
            this.tabPage6.Controls.Add(this.CLIENTECONSOLIDADOIDTextBox);
            this.tabPage6.Controls.Add(this.RETENCIONISRTextBox);
            this.tabPage6.Controls.Add(this.RETENCIONIVATextBox);
            this.tabPage6.Controls.Add(this.FISCALESTADOTextBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(782, 556);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "D. Fiscales";
            // 
            // SERIECOMPRTRASLSATTextBox
            // 
            this.SERIECOMPRTRASLSATTextBox.Location = new System.Drawing.Point(701, 81);
            this.SERIECOMPRTRASLSATTextBox.Name = "SERIECOMPRTRASLSATTextBox";
            this.SERIECOMPRTRASLSATTextBox.Size = new System.Drawing.Size(65, 20);
            this.SERIECOMPRTRASLSATTextBox.TabIndex = 210;
            // 
            // label308
            // 
            this.label308.AutoSize = true;
            this.label308.Location = new System.Drawing.Point(562, 84);
            this.label308.Name = "label308";
            this.label308.Size = new System.Drawing.Size(114, 13);
            this.label308.TabIndex = 211;
            this.label308.Text = "Serie compr. trasl.:";
            // 
            // FISCALFECHACANCELACION2TextBox
            // 
            this.FISCALFECHACANCELACION2TextBox.Location = new System.Drawing.Point(537, 240);
            this.FISCALFECHACANCELACION2TextBox.Name = "FISCALFECHACANCELACION2TextBox";
            this.FISCALFECHACANCELACION2TextBox.Size = new System.Drawing.Size(233, 20);
            this.FISCALFECHACANCELACION2TextBox.TabIndex = 208;
            this.FISCALFECHACANCELACION2TextBox.Value = new System.DateTime(2018, 10, 15, 6, 8, 0, 0);
            // 
            // label278
            // 
            this.label278.AutoSize = true;
            this.label278.Location = new System.Drawing.Point(542, 224);
            this.label278.Name = "label278";
            this.label278.Size = new System.Drawing.Size(141, 13);
            this.label278.TabIndex = 209;
            this.label278.Text = "Fecha ultimo esquema :";
            // 
            // label252
            // 
            this.label252.AutoSize = true;
            this.label252.Location = new System.Drawing.Point(555, 416);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(211, 13);
            this.label252.TabIndex = 206;
            this.label252.Text = "Desglosar IEPS en fact consolidada";
            // 
            // DESGLOSEIEPSFACTURATextBox
            // 
            this.DESGLOSEIEPSFACTURATextBox.AutoSize = true;
            this.DESGLOSEIEPSFACTURATextBox.Location = new System.Drawing.Point(534, 417);
            this.DESGLOSEIEPSFACTURATextBox.Name = "DESGLOSEIEPSFACTURATextBox";
            this.DESGLOSEIEPSFACTURATextBox.Size = new System.Drawing.Size(15, 14);
            this.DESGLOSEIEPSFACTURATextBox.TabIndex = 207;
            this.DESGLOSEIEPSFACTURATextBox.UseVisualStyleBackColor = true;
            // 
            // VERSIONCFDITextBox
            // 
            this.VERSIONCFDITextBox.Location = new System.Drawing.Point(545, 534);
            this.VERSIONCFDITextBox.Name = "VERSIONCFDITextBox";
            this.VERSIONCFDITextBox.Size = new System.Drawing.Size(65, 20);
            this.VERSIONCFDITextBox.TabIndex = 204;
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Location = new System.Drawing.Point(454, 537);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(85, 13);
            this.label248.TabIndex = 205;
            this.label248.Text = "Version CFDI:";
            // 
            // GENERARFECheckBox
            // 
            this.GENERARFECheckBox.AutoSize = true;
            this.GENERARFECheckBox.Location = new System.Drawing.Point(448, 507);
            this.GENERARFECheckBox.Name = "GENERARFECheckBox";
            this.GENERARFECheckBox.Size = new System.Drawing.Size(253, 17);
            this.GENERARFECheckBox.TabIndex = 203;
            this.GENERARFECheckBox.Text = "Generar Factura Electronica por Default";
            this.GENERARFECheckBox.UseVisualStyleBackColor = true;
            // 
            // PAGOSERVCONSOLIDADOTextBox
            // 
            this.PAGOSERVCONSOLIDADOTextBox.AutoSize = true;
            this.PAGOSERVCONSOLIDADOTextBox.Location = new System.Drawing.Point(3, 507);
            this.PAGOSERVCONSOLIDADOTextBox.Name = "PAGOSERVCONSOLIDADOTextBox";
            this.PAGOSERVCONSOLIDADOTextBox.Size = new System.Drawing.Size(255, 17);
            this.PAGOSERVCONSOLIDADOTextBox.TabIndex = 202;
            this.PAGOSERVCONSOLIDADOTextBox.Text = "Incluir pago de servicios en consolidado";
            this.PAGOSERVCONSOLIDADOTextBox.UseVisualStyleBackColor = true;
            // 
            // METPAGOSATIDButton
            // 
            this.METPAGOSATIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.METPAGOSATIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.METPAGOSATIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.METPAGOSATIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.METPAGOSATIDButton.Location = new System.Drawing.Point(209, 468);
            this.METPAGOSATIDButton.Name = "METPAGOSATIDButton";
            this.METPAGOSATIDButton.Size = new System.Drawing.Size(21, 23);
            this.METPAGOSATIDButton.TabIndex = 200;
            this.METPAGOSATIDButton.UseVisualStyleBackColor = true;
            // 
            // METPAGOSATIDValLabel
            // 
            this.METPAGOSATIDValLabel.AutoSize = true;
            this.METPAGOSATIDValLabel.Location = new System.Drawing.Point(235, 473);
            this.METPAGOSATIDValLabel.Name = "METPAGOSATIDValLabel";
            this.METPAGOSATIDValLabel.Size = new System.Drawing.Size(19, 13);
            this.METPAGOSATIDValLabel.TabIndex = 201;
            this.METPAGOSATIDValLabel.Text = "...";
            // 
            // METPAGOSATIDLabel
            // 
            this.METPAGOSATIDLabel.AutoSize = true;
            this.METPAGOSATIDLabel.Location = new System.Drawing.Point(14, 473);
            this.METPAGOSATIDLabel.Name = "METPAGOSATIDLabel";
            this.METPAGOSATIDLabel.Size = new System.Drawing.Size(85, 13);
            this.METPAGOSATIDLabel.TabIndex = 198;
            this.METPAGOSATIDLabel.Text = "Metodo pago:";
            // 
            // REGIMENSATFBButton
            // 
            this.REGIMENSATFBButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.REGIMENSATFBButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.REGIMENSATFBButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.REGIMENSATFBButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.REGIMENSATFBButton.Location = new System.Drawing.Point(206, 367);
            this.REGIMENSATFBButton.Name = "REGIMENSATFBButton";
            this.REGIMENSATFBButton.Size = new System.Drawing.Size(21, 23);
            this.REGIMENSATFBButton.TabIndex = 196;
            this.REGIMENSATFBButton.UseVisualStyleBackColor = true;
            // 
            // REGIMENSATLBL
            // 
            this.REGIMENSATLBL.AutoSize = true;
            this.REGIMENSATLBL.Location = new System.Drawing.Point(235, 374);
            this.REGIMENSATLBL.Name = "REGIMENSATLBL";
            this.REGIMENSATLBL.Size = new System.Drawing.Size(19, 13);
            this.REGIMENSATLBL.TabIndex = 197;
            this.REGIMENSATLBL.Text = "...";
            this.REGIMENSATLBL.Visible = false;
            this.REGIMENSATLBL.TextChanged += new System.EventHandler(this.REGIMENSATLBL_TextChanged);
            // 
            // FORMATOFACTURAComboBox
            // 
            this.FORMATOFACTURAComboBox.DisplayMember = "id";
            this.FORMATOFACTURAComboBox.FormattingEnabled = true;
            this.FORMATOFACTURAComboBox.Items.AddRange(new object[] {
            "Normal",
            "FastReport"});
            this.FORMATOFACTURAComboBox.Location = new System.Drawing.Point(433, 315);
            this.FORMATOFACTURAComboBox.Name = "FORMATOFACTURAComboBox";
            this.FORMATOFACTURAComboBox.Size = new System.Drawing.Size(95, 21);
            this.FORMATOFACTURAComboBox.TabIndex = 194;
            this.FORMATOFACTURAComboBox.ValueMember = "id";
            this.FORMATOFACTURAComboBox.SelectedIndexChanged += new System.EventHandler(this.FORMATOFACTURATextBox_SelectedIndexChanged);
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(349, 318);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(79, 13);
            this.label190.TabIndex = 193;
            this.label190.Text = "Formato F.E.";
            // 
            // SERIESATABONOTextBox
            // 
            this.SERIESATABONOTextBox.Location = new System.Drawing.Point(474, 133);
            this.SERIESATABONOTextBox.Name = "SERIESATABONOTextBox";
            this.SERIESATABONOTextBox.Size = new System.Drawing.Size(65, 20);
            this.SERIESATABONOTextBox.TabIndex = 191;
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Location = new System.Drawing.Point(383, 136);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(85, 13);
            this.label178.TabIndex = 192;
            this.label178.Text = "Serie abonos:";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(343, 344);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(85, 13);
            this.label145.TabIndex = 190;
            this.label145.Text = "Cliente cons.:";
            // 
            // CLIENTECLAVEButton
            // 
            this.CLIENTECLAVEButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CLIENTECLAVEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLIENTECLAVEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLIENTECLAVEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLIENTECLAVEButton.Location = new System.Drawing.Point(534, 340);
            this.CLIENTECLAVEButton.Name = "CLIENTECLAVEButton";
            this.CLIENTECLAVEButton.Size = new System.Drawing.Size(21, 23);
            this.CLIENTECLAVEButton.TabIndex = 188;
            this.CLIENTECLAVEButton.UseVisualStyleBackColor = true;
            // 
            // CLIENTECLAVELabel
            // 
            this.CLIENTECLAVELabel.AutoSize = true;
            this.CLIENTECLAVELabel.Location = new System.Drawing.Point(561, 344);
            this.CLIENTECLAVELabel.Name = "CLIENTECLAVELabel";
            this.CLIENTECLAVELabel.Size = new System.Drawing.Size(19, 13);
            this.CLIENTECLAVELabel.TabIndex = 189;
            this.CLIENTECLAVELabel.Text = "...";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(363, 439);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(79, 13);
            this.label98.TabIndex = 171;
            this.label98.Text = "Cuenta IEPS";
            this.label98.Visible = false;
            // 
            // CUENTAIEPSTextBox
            // 
            this.CUENTAIEPSTextBox.Location = new System.Drawing.Point(448, 436);
            this.CUENTAIEPSTextBox.Name = "CUENTAIEPSTextBox";
            this.CUENTAIEPSTextBox.Size = new System.Drawing.Size(242, 20);
            this.CUENTAIEPSTextBox.TabIndex = 24;
            this.CUENTAIEPSTextBox.Visible = false;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(401, 417);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(80, 13);
            this.label99.TabIndex = 23;
            this.label99.Text = "Maneja IEPS";
            // 
            // DESGLOSEIEPSTextBox
            // 
            this.DESGLOSEIEPSTextBox.AutoSize = true;
            this.DESGLOSEIEPSTextBox.Location = new System.Drawing.Point(386, 417);
            this.DESGLOSEIEPSTextBox.Name = "DESGLOSEIEPSTextBox";
            this.DESGLOSEIEPSTextBox.Size = new System.Drawing.Size(15, 14);
            this.DESGLOSEIEPSTextBox.TabIndex = 168;
            this.DESGLOSEIEPSTextBox.UseVisualStyleBackColor = true;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(5, 443);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(94, 13);
            this.label85.TabIndex = 100;
            this.label85.Text = "Retencion ISR:";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(7, 417);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(93, 13);
            this.label84.TabIndex = 99;
            this.label84.Text = "Retencion IVA:";
            // 
            // ARRENDATARIOCheckBox
            // 
            this.ARRENDATARIOCheckBox.AutoSize = true;
            this.ARRENDATARIOCheckBox.Location = new System.Drawing.Point(238, 416);
            this.ARRENDATARIOCheckBox.Name = "ARRENDATARIOCheckBox";
            this.ARRENDATARIOCheckBox.Size = new System.Drawing.Size(119, 17);
            this.ARRENDATARIOCheckBox.TabIndex = 22;
            this.ARRENDATARIOCheckBox.Text = "Es arrendatario?";
            this.ARRENDATARIOCheckBox.UseVisualStyleBackColor = true;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(40, 372);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(60, 13);
            this.label82.TabIndex = 95;
            this.label82.Text = "Regimen:";
            // 
            // FISCALREGIMENTextBox
            // 
            this.FISCALREGIMENTextBox.Location = new System.Drawing.Point(238, 369);
            this.FISCALREGIMENTextBox.Name = "FISCALREGIMENTextBox";
            this.FISCALREGIMENTextBox.Size = new System.Drawing.Size(410, 20);
            this.FISCALREGIMENTextBox.TabIndex = 18;
            // 
            // PACUSUARIOTextBox
            // 
            this.PACUSUARIOTextBox.Location = new System.Drawing.Point(107, 341);
            this.PACUSUARIOTextBox.Name = "PACUSUARIOTextBox";
            this.PACUSUARIOTextBox.Size = new System.Drawing.Size(195, 20);
            this.PACUSUARIOTextBox.TabIndex = 17;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(20, 344);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(79, 13);
            this.label71.TabIndex = 92;
            this.label71.Text = "Usuario pac:";
            // 
            // PACNOMBRETextBox
            // 
            this.PACNOMBRETextBox.Location = new System.Drawing.Point(107, 315);
            this.PACNOMBRETextBox.Name = "PACNOMBRETextBox";
            this.PACNOMBRETextBox.Size = new System.Drawing.Size(195, 20);
            this.PACNOMBRETextBox.TabIndex = 16;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(20, 318);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(79, 13);
            this.label72.TabIndex = 93;
            this.label72.Text = "Nombre pac:";
            // 
            // SERIESATDEVOLUCIONTextBox
            // 
            this.SERIESATDEVOLUCIONTextBox.Location = new System.Drawing.Point(474, 107);
            this.SERIESATDEVOLUCIONTextBox.Name = "SERIESATDEVOLUCIONTextBox";
            this.SERIESATDEVOLUCIONTextBox.Size = new System.Drawing.Size(65, 20);
            this.SERIESATDEVOLUCIONTextBox.TabIndex = 10;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(349, 110);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(119, 13);
            this.label55.TabIndex = 89;
            this.label55.Text = "Serie devoluciones:";
            // 
            // USARFISCALESENEXPEDICIONCheckBox
            // 
            this.USARFISCALESENEXPEDICIONCheckBox.AutoSize = true;
            this.USARFISCALESENEXPEDICIONCheckBox.Location = new System.Drawing.Point(107, 395);
            this.USARFISCALESENEXPEDICIONCheckBox.Name = "USARFISCALESENEXPEDICIONCheckBox";
            this.USARFISCALESENEXPEDICIONCheckBox.Size = new System.Drawing.Size(415, 17);
            this.USARFISCALESENEXPEDICIONCheckBox.TabIndex = 19;
            this.USARFISCALESENEXPEDICIONCheckBox.Text = "Usar datos fiscales como datos de expedicion en factura electronica";
            this.USARFISCALESENEXPEDICIONCheckBox.UseVisualStyleBackColor = true;
            // 
            // SERIESATTextBox
            // 
            this.SERIESATTextBox.Location = new System.Drawing.Point(474, 81);
            this.SERIESATTextBox.Name = "SERIESATTextBox";
            this.SERIESATTextBox.Size = new System.Drawing.Size(65, 20);
            this.SERIESATTextBox.TabIndex = 9;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(378, 84);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(90, 13);
            this.label44.TabIndex = 87;
            this.label44.Text = "Serie facturas:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(32, 162);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(67, 13);
            this.label35.TabIndex = 86;
            this.label35.Text = "Cert. CSD:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(18, 188);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(82, 13);
            this.label36.TabIndex = 84;
            this.label36.Text = "Tim. Usuario:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(40, 291);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(60, 13);
            this.label37.TabIndex = 82;
            this.label37.Text = "Tim. Key:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(22, 265);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 13);
            this.label38.TabIndex = 81;
            this.label38.Text = "Archivo key:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(24, 240);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(76, 13);
            this.label42.TabIndex = 83;
            this.label42.Text = "Archivo cer:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(27, 214);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(73, 13);
            this.label43.TabIndex = 85;
            this.label43.Text = "Cert. Pass.:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(46, 9);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(54, 13);
            this.label39.TabIndex = 80;
            this.label39.Text = "Nombre:";
            // 
            // TIMBRADOKEYTextBox
            // 
            this.TIMBRADOKEYTextBox.Location = new System.Drawing.Point(107, 288);
            this.TIMBRADOKEYTextBox.Name = "TIMBRADOKEYTextBox";
            this.TIMBRADOKEYTextBox.Size = new System.Drawing.Size(421, 20);
            this.TIMBRADOKEYTextBox.TabIndex = 15;
            // 
            // TIMBRADOARCHIVOKEYTextBox
            // 
            this.TIMBRADOARCHIVOKEYTextBox.Location = new System.Drawing.Point(107, 262);
            this.TIMBRADOARCHIVOKEYTextBox.Name = "TIMBRADOARCHIVOKEYTextBox";
            this.TIMBRADOARCHIVOKEYTextBox.Size = new System.Drawing.Size(374, 20);
            this.TIMBRADOARCHIVOKEYTextBox.TabIndex = 14;
            // 
            // TIMBRADOARCHIVOCERTIFICADOTextBox
            // 
            this.TIMBRADOARCHIVOCERTIFICADOTextBox.Location = new System.Drawing.Point(107, 237);
            this.TIMBRADOARCHIVOCERTIFICADOTextBox.Name = "TIMBRADOARCHIVOCERTIFICADOTextBox";
            this.TIMBRADOARCHIVOCERTIFICADOTextBox.Size = new System.Drawing.Size(374, 20);
            this.TIMBRADOARCHIVOCERTIFICADOTextBox.TabIndex = 13;
            // 
            // TIMBRADOPASSWORDTextBox
            // 
            this.TIMBRADOPASSWORDTextBox.Location = new System.Drawing.Point(107, 211);
            this.TIMBRADOPASSWORDTextBox.Name = "TIMBRADOPASSWORDTextBox";
            this.TIMBRADOPASSWORDTextBox.PasswordChar = '*';
            this.TIMBRADOPASSWORDTextBox.Size = new System.Drawing.Size(431, 20);
            this.TIMBRADOPASSWORDTextBox.TabIndex = 12;
            // 
            // TIMBRADOUSERTextBox
            // 
            this.TIMBRADOUSERTextBox.Location = new System.Drawing.Point(107, 185);
            this.TIMBRADOUSERTextBox.Name = "TIMBRADOUSERTextBox";
            this.TIMBRADOUSERTextBox.Size = new System.Drawing.Size(431, 20);
            this.TIMBRADOUSERTextBox.TabIndex = 11;
            // 
            // FISCALNOMBRETextBox
            // 
            this.FISCALNOMBRETextBox.Location = new System.Drawing.Point(107, 6);
            this.FISCALNOMBRETextBox.Name = "FISCALNOMBRETextBox";
            this.FISCALNOMBRETextBox.Size = new System.Drawing.Size(431, 20);
            this.FISCALNOMBRETextBox.TabIndex = 1;
            // 
            // CERTIFICADOCSDTextBox
            // 
            this.CERTIFICADOCSDTextBox.Location = new System.Drawing.Point(107, 159);
            this.CERTIFICADOCSDTextBox.Name = "CERTIFICADOCSDTextBox";
            this.CERTIFICADOCSDTextBox.Size = new System.Drawing.Size(431, 20);
            this.CERTIFICADOCSDTextBox.TabIndex = 10;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(425, 32);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(23, 13);
            this.label40.TabIndex = 79;
            this.label40.Text = "#I:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(306, 33);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(27, 13);
            this.label41.TabIndex = 78;
            this.label41.Text = "#E:";
            // 
            // FISCALNUMEROINTERIORTextBox
            // 
            this.FISCALNUMEROINTERIORTextBox.Location = new System.Drawing.Point(448, 29);
            this.FISCALNUMEROINTERIORTextBox.Name = "FISCALNUMEROINTERIORTextBox";
            this.FISCALNUMEROINTERIORTextBox.Size = new System.Drawing.Size(90, 20);
            this.FISCALNUMEROINTERIORTextBox.TabIndex = 4;
            // 
            // FISCALNUMEROEXTERIORTextBox
            // 
            this.FISCALNUMEROEXTERIORTextBox.Location = new System.Drawing.Point(331, 30);
            this.FISCALNUMEROEXTERIORTextBox.Name = "FISCALNUMEROEXTERIORTextBox";
            this.FISCALNUMEROEXTERIORTextBox.Size = new System.Drawing.Size(90, 20);
            this.FISCALNUMEROEXTERIORTextBox.TabIndex = 3;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(60, 34);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(39, 13);
            this.label45.TabIndex = 76;
            this.label45.Text = "Calle:";
            // 
            // FISCALCODIGOPOSTALTextBox
            // 
            this.FISCALCODIGOPOSTALTextBox.Location = new System.Drawing.Point(107, 133);
            this.FISCALCODIGOPOSTALTextBox.Name = "FISCALCODIGOPOSTALTextBox";
            this.FISCALCODIGOPOSTALTextBox.Size = new System.Drawing.Size(195, 20);
            this.FISCALCODIGOPOSTALTextBox.TabIndex = 8;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(64, 136);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(35, 13);
            this.label46.TabIndex = 74;
            this.label46.Text = "C.P.:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(49, 109);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(50, 13);
            this.label47.TabIndex = 73;
            this.label47.Text = "Estado:";
            // 
            // FISCALMUNICIPIOTextBox
            // 
            this.FISCALMUNICIPIOTextBox.Location = new System.Drawing.Point(107, 81);
            this.FISCALMUNICIPIOTextBox.Name = "FISCALMUNICIPIOTextBox";
            this.FISCALMUNICIPIOTextBox.Size = new System.Drawing.Size(195, 20);
            this.FISCALMUNICIPIOTextBox.TabIndex = 6;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(35, 84);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(65, 13);
            this.label48.TabIndex = 75;
            this.label48.Text = "Municipio:";
            // 
            // FISCALCALLETextBox
            // 
            this.FISCALCALLETextBox.Location = new System.Drawing.Point(107, 31);
            this.FISCALCALLETextBox.Name = "FISCALCALLETextBox";
            this.FISCALCALLETextBox.Size = new System.Drawing.Size(195, 20);
            this.FISCALCALLETextBox.TabIndex = 2;
            // 
            // FISCALCOLONIATextBox
            // 
            this.FISCALCOLONIATextBox.Location = new System.Drawing.Point(107, 55);
            this.FISCALCOLONIATextBox.Name = "FISCALCOLONIATextBox";
            this.FISCALCOLONIATextBox.Size = new System.Drawing.Size(195, 20);
            this.FISCALCOLONIATextBox.TabIndex = 5;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(47, 58);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(53, 13);
            this.label49.TabIndex = 77;
            this.label49.Text = "Colonia:";
            // 
            // METPAGOSATIDTextBox
            // 
            this.METPAGOSATIDTextBox.BotonLookUp = this.METPAGOSATIDButton;
            this.METPAGOSATIDTextBox.Condicion = null;
            this.METPAGOSATIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.METPAGOSATIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.METPAGOSATIDTextBox.DbValue = null;
            this.METPAGOSATIDTextBox.Format_Expression = null;
            this.METPAGOSATIDTextBox.IndiceCampoDescripcion = 2;
            this.METPAGOSATIDTextBox.IndiceCampoSelector = 1;
            this.METPAGOSATIDTextBox.IndiceCampoValue = 0;
            this.METPAGOSATIDTextBox.LabelDescription = this.METPAGOSATIDValLabel;
            this.METPAGOSATIDTextBox.Location = new System.Drawing.Point(106, 470);
            this.METPAGOSATIDTextBox.MostrarErrores = true;
            this.METPAGOSATIDTextBox.Name = "METPAGOSATIDTextBox";
            this.METPAGOSATIDTextBox.NombreCampoSelector = "sat_clave";
            this.METPAGOSATIDTextBox.NombreCampoValue = "id";
            this.METPAGOSATIDTextBox.Query = "select p.id,p.sat_clave,p.sat_descripcion from sat_metodopago p ";
            this.METPAGOSATIDTextBox.QueryDeSeleccion = "select  id,sat_clave, sat_descripcion from sat_metodopago where  sat_clave = @sat" +
    "_clave";
            this.METPAGOSATIDTextBox.QueryPorDBValue = "select  id,sat_clave, sat_descripcion from sat_metodopago where  id = @id";
            this.METPAGOSATIDTextBox.Size = new System.Drawing.Size(98, 20);
            this.METPAGOSATIDTextBox.TabIndex = 199;
            this.METPAGOSATIDTextBox.Tag = 34;
            this.METPAGOSATIDTextBox.TextDescription = null;
            this.METPAGOSATIDTextBox.Titulo = "Metodo pago";
            this.METPAGOSATIDTextBox.ValidarEntrada = true;
            this.METPAGOSATIDTextBox.ValidationExpression = null;
            // 
            // REGIMENSATFBTextBox
            // 
            this.REGIMENSATFBTextBox.BotonLookUp = this.REGIMENSATFBButton;
            this.REGIMENSATFBTextBox.Condicion = null;
            this.REGIMENSATFBTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.REGIMENSATFBTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.REGIMENSATFBTextBox.DbValue = null;
            this.REGIMENSATFBTextBox.Format_Expression = null;
            this.REGIMENSATFBTextBox.IndiceCampoDescripcion = 2;
            this.REGIMENSATFBTextBox.IndiceCampoSelector = 1;
            this.REGIMENSATFBTextBox.IndiceCampoValue = 0;
            this.REGIMENSATFBTextBox.LabelDescription = this.REGIMENSATLBL;
            this.REGIMENSATFBTextBox.Location = new System.Drawing.Point(106, 369);
            this.REGIMENSATFBTextBox.MostrarErrores = true;
            this.REGIMENSATFBTextBox.Name = "REGIMENSATFBTextBox";
            this.REGIMENSATFBTextBox.NombreCampoSelector = "sat_clave";
            this.REGIMENSATFBTextBox.NombreCampoValue = "id";
            this.REGIMENSATFBTextBox.Query = "select p.id,p.sat_clave,p.sat_descripcion from sat_regimenfiscal p ";
            this.REGIMENSATFBTextBox.QueryDeSeleccion = "select  id,sat_clave, sat_descripcion from sat_regimenfiscal where  sat_clave = @" +
    "sat_clave";
            this.REGIMENSATFBTextBox.QueryPorDBValue = "select  id,sat_clave, sat_descripcion from sat_regimenfiscal where  id = @id";
            this.REGIMENSATFBTextBox.Size = new System.Drawing.Size(95, 20);
            this.REGIMENSATFBTextBox.TabIndex = 195;
            this.REGIMENSATFBTextBox.Tag = 34;
            this.REGIMENSATFBTextBox.TextDescription = null;
            this.REGIMENSATFBTextBox.Titulo = "Regimen fiscal";
            this.REGIMENSATFBTextBox.ValidarEntrada = true;
            this.REGIMENSATFBTextBox.ValidationExpression = null;
            // 
            // CLIENTECONSOLIDADOIDTextBox
            // 
            this.CLIENTECONSOLIDADOIDTextBox.BotonLookUp = this.CLIENTECLAVEButton;
            this.CLIENTECONSOLIDADOIDTextBox.Condicion = null;
            this.CLIENTECONSOLIDADOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLIENTECONSOLIDADOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLIENTECONSOLIDADOIDTextBox.DbValue = null;
            this.CLIENTECONSOLIDADOIDTextBox.Format_Expression = null;
            this.CLIENTECONSOLIDADOIDTextBox.IndiceCampoDescripcion = 2;
            this.CLIENTECONSOLIDADOIDTextBox.IndiceCampoSelector = 1;
            this.CLIENTECONSOLIDADOIDTextBox.IndiceCampoValue = 0;
            this.CLIENTECONSOLIDADOIDTextBox.LabelDescription = this.CLIENTECLAVELabel;
            this.CLIENTECONSOLIDADOIDTextBox.Location = new System.Drawing.Point(433, 341);
            this.CLIENTECONSOLIDADOIDTextBox.MostrarErrores = true;
            this.CLIENTECONSOLIDADOIDTextBox.Name = "CLIENTECONSOLIDADOIDTextBox";
            this.CLIENTECONSOLIDADOIDTextBox.NombreCampoSelector = "clave";
            this.CLIENTECONSOLIDADOIDTextBox.NombreCampoValue = "id";
            this.CLIENTECONSOLIDADOIDTextBox.Query = "select p.id,p.clave,p.nombre from persona p where p.tipopersonaid in (50) ";
            this.CLIENTECONSOLIDADOIDTextBox.QueryDeSeleccion = "select  id,clave, nombre from persona where tipopersonaid  in (50) and  clave = @" +
    "clave";
            this.CLIENTECONSOLIDADOIDTextBox.QueryPorDBValue = "select  id,clave, nombre from persona where tipopersonaid  in (50) and  id = @id";
            this.CLIENTECONSOLIDADOIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.CLIENTECONSOLIDADOIDTextBox.TabIndex = 187;
            this.CLIENTECONSOLIDADOIDTextBox.Tag = 34;
            this.CLIENTECONSOLIDADOIDTextBox.TextDescription = null;
            this.CLIENTECONSOLIDADOIDTextBox.Titulo = "Clientes";
            this.CLIENTECONSOLIDADOIDTextBox.ValidarEntrada = true;
            this.CLIENTECONSOLIDADOIDTextBox.ValidationExpression = null;
            // 
            // RETENCIONISRTextBox
            // 
            this.RETENCIONISRTextBox.AllowNegative = false;
            this.RETENCIONISRTextBox.Format_Expression = null;
            this.RETENCIONISRTextBox.Location = new System.Drawing.Point(106, 440);
            this.RETENCIONISRTextBox.Name = "RETENCIONISRTextBox";
            this.RETENCIONISRTextBox.NumericPrecision = 5;
            this.RETENCIONISRTextBox.NumericScaleOnFocus = 2;
            this.RETENCIONISRTextBox.NumericScaleOnLostFocus = 2;
            this.RETENCIONISRTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RETENCIONISRTextBox.Size = new System.Drawing.Size(116, 20);
            this.RETENCIONISRTextBox.TabIndex = 21;
            this.RETENCIONISRTextBox.Tag = 34;
            this.RETENCIONISRTextBox.Text = "0";
            this.RETENCIONISRTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.RETENCIONISRTextBox.ValidationExpression = null;
            this.RETENCIONISRTextBox.ZeroIsValid = true;
            // 
            // RETENCIONIVATextBox
            // 
            this.RETENCIONIVATextBox.AllowNegative = false;
            this.RETENCIONIVATextBox.Format_Expression = null;
            this.RETENCIONIVATextBox.Location = new System.Drawing.Point(107, 413);
            this.RETENCIONIVATextBox.Name = "RETENCIONIVATextBox";
            this.RETENCIONIVATextBox.NumericPrecision = 5;
            this.RETENCIONIVATextBox.NumericScaleOnFocus = 2;
            this.RETENCIONIVATextBox.NumericScaleOnLostFocus = 2;
            this.RETENCIONIVATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RETENCIONIVATextBox.Size = new System.Drawing.Size(116, 20);
            this.RETENCIONIVATextBox.TabIndex = 20;
            this.RETENCIONIVATextBox.Tag = 34;
            this.RETENCIONIVATextBox.Text = "0";
            this.RETENCIONIVATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.RETENCIONIVATextBox.ValidationExpression = null;
            this.RETENCIONIVATextBox.ZeroIsValid = true;
            // 
            // FISCALESTADOTextBox
            // 
            this.FISCALESTADOTextBox.Condicion = null;
            this.FISCALESTADOTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.FISCALESTADOTextBox.DisplayMember = "nombre";
            this.FISCALESTADOTextBox.FormattingEnabled = true;
            this.FISCALESTADOTextBox.IndiceCampoSelector = 0;
            this.FISCALESTADOTextBox.LabelDescription = null;
            this.FISCALESTADOTextBox.Location = new System.Drawing.Point(106, 106);
            this.FISCALESTADOTextBox.Name = "FISCALESTADOTextBox";
            this.FISCALESTADOTextBox.NombreCampoSelector = "id";
            this.FISCALESTADOTextBox.Query = "select id,nombre from estado";
            this.FISCALESTADOTextBox.QueryDeSeleccion = "select id,nombre from estado where  id = @id";
            this.FISCALESTADOTextBox.SelectedDataDisplaying = null;
            this.FISCALESTADOTextBox.SelectedDataValue = null;
            this.FISCALESTADOTextBox.Size = new System.Drawing.Size(196, 21);
            this.FISCALESTADOTextBox.TabIndex = 7;
            this.FISCALESTADOTextBox.ValueMember = "id";
            // 
            // tabPage7
            // 
            this.tabPage7.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage7.Controls.Add(this.MONEDEROLISTAPRECIOIDLabel);
            this.tabPage7.Controls.Add(this.MONEDEROCAMPOREFLabel);
            this.tabPage7.Controls.Add(this.MONEDEROCAMPOREFTextBox);
            this.tabPage7.Controls.Add(this.MONEDEROLISTAPRECIOIDComboBox);
            this.tabPage7.Controls.Add(this.RUTAPOLIZAPDFTextBox);
            this.tabPage7.Controls.Add(this.label253);
            this.tabPage7.Controls.Add(this.label249);
            this.tabPage7.Controls.Add(this.CONSFACTOMITIRVALESCheckBox);
            this.tabPage7.Controls.Add(this.label228);
            this.tabPage7.Controls.Add(this.HAB_CONSOLIDADOAUTOMATICOCheckBox);
            this.tabPage7.Controls.Add(this.label225);
            this.tabPage7.Controls.Add(this.MANEJAPRODUCTOSPROMOCIONCheckBox);
            this.tabPage7.Controls.Add(this.filtroProdSatComboBox);
            this.tabPage7.Controls.Add(this.MANEJAPRODUCTOSPROMOCIONLabel);
            this.tabPage7.Controls.Add(this.label219);
            this.tabPage7.Controls.Add(this.MANEJACUPONESCheckBox);
            this.tabPage7.Controls.Add(this.label211);
            this.tabPage7.Controls.Add(this.cbHabBtnPagoVale);
            this.tabPage7.Controls.Add(this.label209);
            this.tabPage7.Controls.Add(this.MANEJAGASTOSADICCheckBox);
            this.tabPage7.Controls.Add(this.label208);
            this.tabPage7.Controls.Add(this.MANEJARLOTEIMPORTACIONCheckBox);
            this.tabPage7.Controls.Add(this.label207);
            this.tabPage7.Controls.Add(this.DESCUENTOLINEAPERSONACheckBox);
            this.tabPage7.Controls.Add(this.label198);
            this.tabPage7.Controls.Add(this.BANCOMERHABPINPADCheckBox);
            this.tabPage7.Controls.Add(this.MULTIPLETIPOVALETextBox);
            this.tabPage7.Controls.Add(this.label151);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO4TEXTOTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO3TEXTOTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO2TEXTOTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO1TEXTOTextBox);
            this.tabPage7.Controls.Add(this.label150);
            this.tabPage7.Controls.Add(this.label24);
            this.tabPage7.Controls.Add(this.label64);
            this.tabPage7.Controls.Add(this.label65);
            this.tabPage7.Controls.Add(this.MONEDEROAPLICARComboBox);
            this.tabPage7.Controls.Add(this.label66);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO4PORCTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO3PORCTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO2PORCTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOTIPO1PORCTextBox);
            this.tabPage7.Controls.Add(this.DESCUENTOVALETextBox);
            this.tabPage7.Controls.Add(this.MONEDEROCADUCIDADTextBox);
            this.tabPage7.Controls.Add(this.MONEDEROMONTOMINIMOTextBox);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(782, 556);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Monedero/vale";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // MONEDEROLISTAPRECIOIDLabel
            // 
            this.MONEDEROLISTAPRECIOIDLabel.AutoSize = true;
            this.MONEDEROLISTAPRECIOIDLabel.Location = new System.Drawing.Point(477, 37);
            this.MONEDEROLISTAPRECIOIDLabel.Name = "MONEDEROLISTAPRECIOIDLabel";
            this.MONEDEROLISTAPRECIOIDLabel.Size = new System.Drawing.Size(160, 13);
            this.MONEDEROLISTAPRECIOIDLabel.TabIndex = 214;
            this.MONEDEROLISTAPRECIOIDLabel.Text = "Lista precio min. Monedero";
            // 
            // MONEDEROCAMPOREFLabel
            // 
            this.MONEDEROCAMPOREFLabel.AutoSize = true;
            this.MONEDEROCAMPOREFLabel.Location = new System.Drawing.Point(491, 83);
            this.MONEDEROCAMPOREFLabel.Name = "MONEDEROCAMPOREFLabel";
            this.MONEDEROCAMPOREFLabel.Size = new System.Drawing.Size(146, 13);
            this.MONEDEROCAMPOREFLabel.TabIndex = 213;
            this.MONEDEROCAMPOREFLabel.Text = "Campo promo monedero:";
            // 
            // MONEDEROCAMPOREFTextBox
            // 
            this.MONEDEROCAMPOREFTextBox.Location = new System.Drawing.Point(643, 80);
            this.MONEDEROCAMPOREFTextBox.Name = "MONEDEROCAMPOREFTextBox";
            this.MONEDEROCAMPOREFTextBox.Size = new System.Drawing.Size(105, 20);
            this.MONEDEROCAMPOREFTextBox.TabIndex = 212;
            // 
            // MONEDEROLISTAPRECIOIDComboBox
            // 
            this.MONEDEROLISTAPRECIOIDComboBox.FormattingEnabled = true;
            this.MONEDEROLISTAPRECIOIDComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.MONEDEROLISTAPRECIOIDComboBox.Location = new System.Drawing.Point(650, 33);
            this.MONEDEROLISTAPRECIOIDComboBox.Name = "MONEDEROLISTAPRECIOIDComboBox";
            this.MONEDEROLISTAPRECIOIDComboBox.Size = new System.Drawing.Size(73, 21);
            this.MONEDEROLISTAPRECIOIDComboBox.TabIndex = 211;
            // 
            // RUTAPOLIZAPDFTextBox
            // 
            this.RUTAPOLIZAPDFTextBox.Location = new System.Drawing.Point(511, 351);
            this.RUTAPOLIZAPDFTextBox.Name = "RUTAPOLIZAPDFTextBox";
            this.RUTAPOLIZAPDFTextBox.Size = new System.Drawing.Size(195, 20);
            this.RUTAPOLIZAPDFTextBox.TabIndex = 209;
            // 
            // label253
            // 
            this.label253.AutoSize = true;
            this.label253.Location = new System.Drawing.Point(508, 330);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(181, 13);
            this.label253.TabIndex = 210;
            this.label253.Text = "Ruta de exportacion poliza pdf";
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Location = new System.Drawing.Point(283, 533);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(201, 13);
            this.label249.TabIndex = 208;
            this.label249.Text = "Omitir vales en facturacion autom.";
            // 
            // CONSFACTOMITIRVALESCheckBox
            // 
            this.CONSFACTOMITIRVALESCheckBox.AutoSize = true;
            this.CONSFACTOMITIRVALESCheckBox.Location = new System.Drawing.Point(268, 533);
            this.CONSFACTOMITIRVALESCheckBox.Name = "CONSFACTOMITIRVALESCheckBox";
            this.CONSFACTOMITIRVALESCheckBox.Size = new System.Drawing.Size(15, 14);
            this.CONSFACTOMITIRVALESCheckBox.TabIndex = 207;
            this.CONSFACTOMITIRVALESCheckBox.UseVisualStyleBackColor = true;
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.Location = new System.Drawing.Point(283, 494);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(212, 13);
            this.label228.TabIndex = 204;
            this.label228.Text = "Facturacion consolidada automatica";
            // 
            // HAB_CONSOLIDADOAUTOMATICOCheckBox
            // 
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox.AutoSize = true;
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox.Location = new System.Drawing.Point(268, 493);
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox.Name = "HAB_CONSOLIDADOAUTOMATICOCheckBox";
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox.Size = new System.Drawing.Size(15, 14);
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox.TabIndex = 205;
            this.HAB_CONSOLIDADOAUTOMATICOCheckBox.UseVisualStyleBackColor = true;
            // 
            // label225
            // 
            this.label225.AutoSize = true;
            this.label225.Location = new System.Drawing.Point(508, 494);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(153, 13);
            this.label225.TabIndex = 203;
            this.label225.Text = "Filtrar productos SAT por:";
            // 
            // MANEJAPRODUCTOSPROMOCIONCheckBox
            // 
            this.MANEJAPRODUCTOSPROMOCIONCheckBox.AutoSize = true;
            this.MANEJAPRODUCTOSPROMOCIONCheckBox.Location = new System.Drawing.Point(34, 492);
            this.MANEJAPRODUCTOSPROMOCIONCheckBox.Name = "MANEJAPRODUCTOSPROMOCIONCheckBox";
            this.MANEJAPRODUCTOSPROMOCIONCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MANEJAPRODUCTOSPROMOCIONCheckBox.TabIndex = 202;
            this.MANEJAPRODUCTOSPROMOCIONCheckBox.UseVisualStyleBackColor = true;
            // 
            // filtroProdSatComboBox
            // 
            this.filtroProdSatComboBox.FormattingEnabled = true;
            this.filtroProdSatComboBox.Items.AddRange(new object[] {
            "Todos",
            "Parcial",
            "Linea"});
            this.filtroProdSatComboBox.Location = new System.Drawing.Point(667, 489);
            this.filtroProdSatComboBox.Name = "filtroProdSatComboBox";
            this.filtroProdSatComboBox.Size = new System.Drawing.Size(109, 21);
            this.filtroProdSatComboBox.TabIndex = 196;
            // 
            // MANEJAPRODUCTOSPROMOCIONLabel
            // 
            this.MANEJAPRODUCTOSPROMOCIONLabel.AutoSize = true;
            this.MANEJAPRODUCTOSPROMOCIONLabel.Location = new System.Drawing.Point(51, 494);
            this.MANEJAPRODUCTOSPROMOCIONLabel.Name = "MANEJAPRODUCTOSPROMOCIONLabel";
            this.MANEJAPRODUCTOSPROMOCIONLabel.Size = new System.Drawing.Size(188, 13);
            this.MANEJAPRODUCTOSPROMOCIONLabel.TabIndex = 201;
            this.MANEJAPRODUCTOSPROMOCIONLabel.Text = "Maneja promocion de productos";
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Location = new System.Drawing.Point(283, 418);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(101, 13);
            this.label219.TabIndex = 199;
            this.label219.Text = "Maneja Cupones";
            // 
            // MANEJACUPONESCheckBox
            // 
            this.MANEJACUPONESCheckBox.AutoSize = true;
            this.MANEJACUPONESCheckBox.Location = new System.Drawing.Point(268, 417);
            this.MANEJACUPONESCheckBox.Name = "MANEJACUPONESCheckBox";
            this.MANEJACUPONESCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MANEJACUPONESCheckBox.TabIndex = 200;
            this.MANEJACUPONESCheckBox.UseVisualStyleBackColor = true;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(531, 419);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(178, 13);
            this.label211.TabIndex = 197;
            this.label211.Text = "Habilitar Boton Pago con Vale";
            // 
            // cbHabBtnPagoVale
            // 
            this.cbHabBtnPagoVale.AutoSize = true;
            this.cbHabBtnPagoVale.Location = new System.Drawing.Point(514, 419);
            this.cbHabBtnPagoVale.Name = "cbHabBtnPagoVale";
            this.cbHabBtnPagoVale.Size = new System.Drawing.Size(15, 14);
            this.cbHabBtnPagoVale.TabIndex = 198;
            this.cbHabBtnPagoVale.UseVisualStyleBackColor = true;
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(531, 451);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(157, 13);
            this.label209.TabIndex = 195;
            this.label209.Text = "Maneja gastos adicionales";
            // 
            // MANEJAGASTOSADICCheckBox
            // 
            this.MANEJAGASTOSADICCheckBox.AutoSize = true;
            this.MANEJAGASTOSADICCheckBox.Location = new System.Drawing.Point(514, 450);
            this.MANEJAGASTOSADICCheckBox.Name = "MANEJAGASTOSADICCheckBox";
            this.MANEJAGASTOSADICCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MANEJAGASTOSADICCheckBox.TabIndex = 196;
            this.MANEJAGASTOSADICCheckBox.UseVisualStyleBackColor = true;
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(283, 452);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(146, 13);
            this.label208.TabIndex = 193;
            this.label208.Text = "Manejar lote importacion";
            // 
            // MANEJARLOTEIMPORTACIONCheckBox
            // 
            this.MANEJARLOTEIMPORTACIONCheckBox.AutoSize = true;
            this.MANEJARLOTEIMPORTACIONCheckBox.Location = new System.Drawing.Point(268, 451);
            this.MANEJARLOTEIMPORTACIONCheckBox.Name = "MANEJARLOTEIMPORTACIONCheckBox";
            this.MANEJARLOTEIMPORTACIONCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MANEJARLOTEIMPORTACIONCheckBox.TabIndex = 194;
            this.MANEJARLOTEIMPORTACIONCheckBox.UseVisualStyleBackColor = true;
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(50, 453);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(153, 13);
            this.label207.TabIndex = 191;
            this.label207.Text = "Descuento Linea Persona";
            // 
            // DESCUENTOLINEAPERSONACheckBox
            // 
            this.DESCUENTOLINEAPERSONACheckBox.AutoSize = true;
            this.DESCUENTOLINEAPERSONACheckBox.Location = new System.Drawing.Point(35, 452);
            this.DESCUENTOLINEAPERSONACheckBox.Name = "DESCUENTOLINEAPERSONACheckBox";
            this.DESCUENTOLINEAPERSONACheckBox.Size = new System.Drawing.Size(15, 14);
            this.DESCUENTOLINEAPERSONACheckBox.TabIndex = 192;
            this.DESCUENTOLINEAPERSONACheckBox.UseVisualStyleBackColor = true;
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(50, 419);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(158, 13);
            this.label198.TabIndex = 189;
            this.label198.Text = "Bancomer Habilitar PinPad";
            // 
            // BANCOMERHABPINPADCheckBox
            // 
            this.BANCOMERHABPINPADCheckBox.AutoSize = true;
            this.BANCOMERHABPINPADCheckBox.Location = new System.Drawing.Point(35, 418);
            this.BANCOMERHABPINPADCheckBox.Name = "BANCOMERHABPINPADCheckBox";
            this.BANCOMERHABPINPADCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BANCOMERHABPINPADCheckBox.TabIndex = 190;
            this.BANCOMERHABPINPADCheckBox.UseVisualStyleBackColor = true;
            // 
            // MULTIPLETIPOVALETextBox
            // 
            this.MULTIPLETIPOVALETextBox.FormattingEnabled = true;
            this.MULTIPLETIPOVALETextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MULTIPLETIPOVALETextBox.Location = new System.Drawing.Point(301, 200);
            this.MULTIPLETIPOVALETextBox.Name = "MULTIPLETIPOVALETextBox";
            this.MULTIPLETIPOVALETextBox.Size = new System.Drawing.Size(100, 21);
            this.MULTIPLETIPOVALETextBox.TabIndex = 75;
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(141, 203);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(154, 13);
            this.label151.TabIndex = 74;
            this.label151.Text = "Permitir otros descuentos:";
            // 
            // DESCUENTOTIPO4TEXTOTextBox
            // 
            this.DESCUENTOTIPO4TEXTOTextBox.Location = new System.Drawing.Point(31, 351);
            this.DESCUENTOTIPO4TEXTOTextBox.Name = "DESCUENTOTIPO4TEXTOTextBox";
            this.DESCUENTOTIPO4TEXTOTextBox.Size = new System.Drawing.Size(236, 20);
            this.DESCUENTOTIPO4TEXTOTextBox.TabIndex = 72;
            // 
            // DESCUENTOTIPO3TEXTOTextBox
            // 
            this.DESCUENTOTIPO3TEXTOTextBox.Location = new System.Drawing.Point(31, 323);
            this.DESCUENTOTIPO3TEXTOTextBox.Name = "DESCUENTOTIPO3TEXTOTextBox";
            this.DESCUENTOTIPO3TEXTOTextBox.Size = new System.Drawing.Size(236, 20);
            this.DESCUENTOTIPO3TEXTOTextBox.TabIndex = 70;
            // 
            // DESCUENTOTIPO2TEXTOTextBox
            // 
            this.DESCUENTOTIPO2TEXTOTextBox.Location = new System.Drawing.Point(31, 296);
            this.DESCUENTOTIPO2TEXTOTextBox.Name = "DESCUENTOTIPO2TEXTOTextBox";
            this.DESCUENTOTIPO2TEXTOTextBox.Size = new System.Drawing.Size(236, 20);
            this.DESCUENTOTIPO2TEXTOTextBox.TabIndex = 68;
            // 
            // DESCUENTOTIPO1TEXTOTextBox
            // 
            this.DESCUENTOTIPO1TEXTOTextBox.Location = new System.Drawing.Point(31, 268);
            this.DESCUENTOTIPO1TEXTOTextBox.Name = "DESCUENTOTIPO1TEXTOTextBox";
            this.DESCUENTOTIPO1TEXTOTextBox.Size = new System.Drawing.Size(236, 20);
            this.DESCUENTOTIPO1TEXTOTextBox.TabIndex = 66;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(28, 242);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(110, 13);
            this.label150.TabIndex = 65;
            this.label150.Text = "Otros descuentos:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(182, 159);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(113, 13);
            this.label24.TabIndex = 64;
            this.label24.Text = "% Descuento vale:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(207, 37);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(88, 13);
            this.label64.TabIndex = 62;
            this.label64.Text = "Monto minimo:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(189, 63);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(106, 13);
            this.label65.TabIndex = 61;
            this.label65.Text = "Dias de vigencia:";
            // 
            // MONEDEROAPLICARComboBox
            // 
            this.MONEDEROAPLICARComboBox.FormattingEnabled = true;
            this.MONEDEROAPLICARComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MONEDEROAPLICARComboBox.Location = new System.Drawing.Point(301, 87);
            this.MONEDEROAPLICARComboBox.Name = "MONEDEROAPLICARComboBox";
            this.MONEDEROAPLICARComboBox.Size = new System.Drawing.Size(100, 21);
            this.MONEDEROAPLICARComboBox.TabIndex = 59;
            this.MONEDEROAPLICARComboBox.Visible = false;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(85, 90);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(210, 13);
            this.label66.TabIndex = 60;
            this.label66.Text = "Habilitar promociones en monedero:";
            this.label66.Visible = false;
            // 
            // DESCUENTOTIPO4PORCTextBox
            // 
            this.DESCUENTOTIPO4PORCTextBox.AllowNegative = false;
            this.DESCUENTOTIPO4PORCTextBox.Format_Expression = null;
            this.DESCUENTOTIPO4PORCTextBox.Location = new System.Drawing.Point(301, 351);
            this.DESCUENTOTIPO4PORCTextBox.Name = "DESCUENTOTIPO4PORCTextBox";
            this.DESCUENTOTIPO4PORCTextBox.NumericPrecision = 5;
            this.DESCUENTOTIPO4PORCTextBox.NumericScaleOnFocus = 2;
            this.DESCUENTOTIPO4PORCTextBox.NumericScaleOnLostFocus = 2;
            this.DESCUENTOTIPO4PORCTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DESCUENTOTIPO4PORCTextBox.Size = new System.Drawing.Size(100, 20);
            this.DESCUENTOTIPO4PORCTextBox.TabIndex = 73;
            this.DESCUENTOTIPO4PORCTextBox.Tag = 34;
            this.DESCUENTOTIPO4PORCTextBox.Text = "0.00";
            this.DESCUENTOTIPO4PORCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DESCUENTOTIPO4PORCTextBox.ValidationExpression = null;
            this.DESCUENTOTIPO4PORCTextBox.ZeroIsValid = true;
            // 
            // DESCUENTOTIPO3PORCTextBox
            // 
            this.DESCUENTOTIPO3PORCTextBox.AllowNegative = false;
            this.DESCUENTOTIPO3PORCTextBox.Format_Expression = null;
            this.DESCUENTOTIPO3PORCTextBox.Location = new System.Drawing.Point(301, 323);
            this.DESCUENTOTIPO3PORCTextBox.Name = "DESCUENTOTIPO3PORCTextBox";
            this.DESCUENTOTIPO3PORCTextBox.NumericPrecision = 5;
            this.DESCUENTOTIPO3PORCTextBox.NumericScaleOnFocus = 2;
            this.DESCUENTOTIPO3PORCTextBox.NumericScaleOnLostFocus = 2;
            this.DESCUENTOTIPO3PORCTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DESCUENTOTIPO3PORCTextBox.Size = new System.Drawing.Size(100, 20);
            this.DESCUENTOTIPO3PORCTextBox.TabIndex = 71;
            this.DESCUENTOTIPO3PORCTextBox.Tag = 34;
            this.DESCUENTOTIPO3PORCTextBox.Text = "0.00";
            this.DESCUENTOTIPO3PORCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DESCUENTOTIPO3PORCTextBox.ValidationExpression = null;
            this.DESCUENTOTIPO3PORCTextBox.ZeroIsValid = true;
            // 
            // DESCUENTOTIPO2PORCTextBox
            // 
            this.DESCUENTOTIPO2PORCTextBox.AllowNegative = false;
            this.DESCUENTOTIPO2PORCTextBox.Format_Expression = null;
            this.DESCUENTOTIPO2PORCTextBox.Location = new System.Drawing.Point(301, 296);
            this.DESCUENTOTIPO2PORCTextBox.Name = "DESCUENTOTIPO2PORCTextBox";
            this.DESCUENTOTIPO2PORCTextBox.NumericPrecision = 5;
            this.DESCUENTOTIPO2PORCTextBox.NumericScaleOnFocus = 2;
            this.DESCUENTOTIPO2PORCTextBox.NumericScaleOnLostFocus = 2;
            this.DESCUENTOTIPO2PORCTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DESCUENTOTIPO2PORCTextBox.Size = new System.Drawing.Size(100, 20);
            this.DESCUENTOTIPO2PORCTextBox.TabIndex = 69;
            this.DESCUENTOTIPO2PORCTextBox.Tag = 34;
            this.DESCUENTOTIPO2PORCTextBox.Text = "0.00";
            this.DESCUENTOTIPO2PORCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DESCUENTOTIPO2PORCTextBox.ValidationExpression = null;
            this.DESCUENTOTIPO2PORCTextBox.ZeroIsValid = true;
            // 
            // DESCUENTOTIPO1PORCTextBox
            // 
            this.DESCUENTOTIPO1PORCTextBox.AllowNegative = false;
            this.DESCUENTOTIPO1PORCTextBox.Format_Expression = null;
            this.DESCUENTOTIPO1PORCTextBox.Location = new System.Drawing.Point(301, 268);
            this.DESCUENTOTIPO1PORCTextBox.Name = "DESCUENTOTIPO1PORCTextBox";
            this.DESCUENTOTIPO1PORCTextBox.NumericPrecision = 5;
            this.DESCUENTOTIPO1PORCTextBox.NumericScaleOnFocus = 2;
            this.DESCUENTOTIPO1PORCTextBox.NumericScaleOnLostFocus = 2;
            this.DESCUENTOTIPO1PORCTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DESCUENTOTIPO1PORCTextBox.Size = new System.Drawing.Size(100, 20);
            this.DESCUENTOTIPO1PORCTextBox.TabIndex = 67;
            this.DESCUENTOTIPO1PORCTextBox.Tag = 34;
            this.DESCUENTOTIPO1PORCTextBox.Text = "0.00";
            this.DESCUENTOTIPO1PORCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DESCUENTOTIPO1PORCTextBox.ValidationExpression = null;
            this.DESCUENTOTIPO1PORCTextBox.ZeroIsValid = true;
            // 
            // DESCUENTOVALETextBox
            // 
            this.DESCUENTOVALETextBox.AllowNegative = false;
            this.DESCUENTOVALETextBox.Format_Expression = null;
            this.DESCUENTOVALETextBox.Location = new System.Drawing.Point(301, 156);
            this.DESCUENTOVALETextBox.Name = "DESCUENTOVALETextBox";
            this.DESCUENTOVALETextBox.NumericPrecision = 5;
            this.DESCUENTOVALETextBox.NumericScaleOnFocus = 2;
            this.DESCUENTOVALETextBox.NumericScaleOnLostFocus = 2;
            this.DESCUENTOVALETextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DESCUENTOVALETextBox.Size = new System.Drawing.Size(100, 20);
            this.DESCUENTOVALETextBox.TabIndex = 63;
            this.DESCUENTOVALETextBox.Tag = 34;
            this.DESCUENTOVALETextBox.Text = "0.00";
            this.DESCUENTOVALETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DESCUENTOVALETextBox.ValidationExpression = null;
            this.DESCUENTOVALETextBox.ZeroIsValid = true;
            // 
            // MONEDEROCADUCIDADTextBox
            // 
            this.MONEDEROCADUCIDADTextBox.AllowNegative = false;
            this.MONEDEROCADUCIDADTextBox.Format_Expression = null;
            this.MONEDEROCADUCIDADTextBox.Location = new System.Drawing.Point(301, 60);
            this.MONEDEROCADUCIDADTextBox.Name = "MONEDEROCADUCIDADTextBox";
            this.MONEDEROCADUCIDADTextBox.NumericPrecision = 5;
            this.MONEDEROCADUCIDADTextBox.NumericScaleOnFocus = 0;
            this.MONEDEROCADUCIDADTextBox.NumericScaleOnLostFocus = 0;
            this.MONEDEROCADUCIDADTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MONEDEROCADUCIDADTextBox.Size = new System.Drawing.Size(100, 20);
            this.MONEDEROCADUCIDADTextBox.TabIndex = 58;
            this.MONEDEROCADUCIDADTextBox.Tag = 34;
            this.MONEDEROCADUCIDADTextBox.Text = "0";
            this.MONEDEROCADUCIDADTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MONEDEROCADUCIDADTextBox.ValidationExpression = null;
            this.MONEDEROCADUCIDADTextBox.ZeroIsValid = true;
            // 
            // MONEDEROMONTOMINIMOTextBox
            // 
            this.MONEDEROMONTOMINIMOTextBox.AllowNegative = false;
            this.MONEDEROMONTOMINIMOTextBox.Format_Expression = null;
            this.MONEDEROMONTOMINIMOTextBox.Location = new System.Drawing.Point(301, 34);
            this.MONEDEROMONTOMINIMOTextBox.Name = "MONEDEROMONTOMINIMOTextBox";
            this.MONEDEROMONTOMINIMOTextBox.NumericPrecision = 18;
            this.MONEDEROMONTOMINIMOTextBox.NumericScaleOnFocus = 2;
            this.MONEDEROMONTOMINIMOTextBox.NumericScaleOnLostFocus = 2;
            this.MONEDEROMONTOMINIMOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MONEDEROMONTOMINIMOTextBox.Size = new System.Drawing.Size(100, 20);
            this.MONEDEROMONTOMINIMOTextBox.TabIndex = 57;
            this.MONEDEROMONTOMINIMOTextBox.Tag = 34;
            this.MONEDEROMONTOMINIMOTextBox.Text = "0.00";
            this.MONEDEROMONTOMINIMOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MONEDEROMONTOMINIMOTextBox.ValidationExpression = null;
            this.MONEDEROMONTOMINIMOTextBox.ZeroIsValid = true;
            // 
            // tabPage8
            // 
            this.tabPage8.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage8.Controls.Add(this.label224);
            this.tabPage8.Controls.Add(this.MOSTRARINVINFOADICPRODTextBox);
            this.tabPage8.Controls.Add(this.label149);
            this.tabPage8.Controls.Add(this.HABTOTALIZADOSTextBox);
            this.tabPage8.Controls.Add(this.label91);
            this.tabPage8.Controls.Add(this.EXPORTCATALOGOAUXTextBox);
            this.tabPage8.Controls.Add(this.label77);
            this.tabPage8.Controls.Add(this.CAMPOSCUSTOMALIMPORTARTextBox);
            this.tabPage8.Controls.Add(this.groupBox1);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(782, 556);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "Listados";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.Location = new System.Drawing.Point(364, 497);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(309, 13);
            this.label224.TabIndex = 95;
            this.label224.Text = "Mostrar datos adicionales de producto en inventario?";
            // 
            // MOSTRARINVINFOADICPRODTextBox
            // 
            this.MOSTRARINVINFOADICPRODTextBox.FormattingEnabled = true;
            this.MOSTRARINVINFOADICPRODTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOSTRARINVINFOADICPRODTextBox.Location = new System.Drawing.Point(674, 494);
            this.MOSTRARINVINFOADICPRODTextBox.Name = "MOSTRARINVINFOADICPRODTextBox";
            this.MOSTRARINVINFOADICPRODTextBox.Size = new System.Drawing.Size(62, 21);
            this.MOSTRARINVINFOADICPRODTextBox.TabIndex = 94;
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Location = new System.Drawing.Point(53, 497);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(207, 13);
            this.label149.TabIndex = 93;
            this.label149.Text = "Habilitar totalizacion para reporteo:";
            // 
            // HABTOTALIZADOSTextBox
            // 
            this.HABTOTALIZADOSTextBox.FormattingEnabled = true;
            this.HABTOTALIZADOSTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABTOTALIZADOSTextBox.Location = new System.Drawing.Point(266, 494);
            this.HABTOTALIZADOSTextBox.Name = "HABTOTALIZADOSTextBox";
            this.HABTOTALIZADOSTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABTOTALIZADOSTextBox.TabIndex = 92;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(377, 467);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(296, 13);
            this.label91.TabIndex = 91;
            this.label91.Text = "Exportar catalogos junto a los pedidos y traslados?";
            // 
            // EXPORTCATALOGOAUXTextBox
            // 
            this.EXPORTCATALOGOAUXTextBox.FormattingEnabled = true;
            this.EXPORTCATALOGOAUXTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.EXPORTCATALOGOAUXTextBox.Location = new System.Drawing.Point(675, 464);
            this.EXPORTCATALOGOAUXTextBox.Name = "EXPORTCATALOGOAUXTextBox";
            this.EXPORTCATALOGOAUXTextBox.Size = new System.Drawing.Size(62, 21);
            this.EXPORTCATALOGOAUXTextBox.TabIndex = 90;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(32, 467);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(228, 13);
            this.label77.TabIndex = 89;
            this.label77.Text = "Al importar ver campos personalizados:";
            // 
            // CAMPOSCUSTOMALIMPORTARTextBox
            // 
            this.CAMPOSCUSTOMALIMPORTARTextBox.FormattingEnabled = true;
            this.CAMPOSCUSTOMALIMPORTARTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.CAMPOSCUSTOMALIMPORTARTextBox.Location = new System.Drawing.Point(266, 464);
            this.CAMPOSCUSTOMALIMPORTARTextBox.Name = "CAMPOSCUSTOMALIMPORTARTextBox";
            this.CAMPOSCUSTOMALIMPORTARTextBox.Size = new System.Drawing.Size(62, 21);
            this.CAMPOSCUSTOMALIMPORTARTextBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO36TextBox);
            this.groupBox1.Controls.Add(this.lblPrecioMacro);
            this.groupBox1.Controls.Add(this.L1CAMPO36CheckBox);
            this.groupBox1.Controls.Add(this.PORCUTILMACROLISTADOTextBox);
            this.groupBox1.Controls.Add(this.label323);
            this.groupBox1.Controls.Add(this.PORCUTILIDADLISTADOTextBox);
            this.groupBox1.Controls.Add(this.label317);
            this.groupBox1.Controls.Add(this.label234);
            this.groupBox1.Controls.Add(this.PVCOLOREARTextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO35TextBox);
            this.groupBox1.Controls.Add(this.L1CAMPO35CheckBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO34TextBox);
            this.groupBox1.Controls.Add(this.L1CAMPO34CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO33CheckBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO33TextBox);
            this.groupBox1.Controls.Add(this.L1CAMPO32CheckBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO32TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO31TextBox);
            this.groupBox1.Controls.Add(this.label203);
            this.groupBox1.Controls.Add(this.L1CAMPO31CheckBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO23TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO22TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO21TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO20TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO18TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO16TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO30TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO29TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO28TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO27TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO26TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO24TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO25TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO17TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO13TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO7TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO12TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO6TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO11TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO5TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO10TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO9TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO4TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO3TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO1TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO19TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO15TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO14TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO8TextBox);
            this.groupBox1.Controls.Add(this.L1LBL_CAMPO2TextBox);
            this.groupBox1.Controls.Add(this.label172);
            this.groupBox1.Controls.Add(this.L1CAMPO30CheckBox);
            this.groupBox1.Controls.Add(this.label170);
            this.groupBox1.Controls.Add(this.L1CAMPO29CheckBox);
            this.groupBox1.Controls.Add(this.label171);
            this.groupBox1.Controls.Add(this.L1CAMPO28CheckBox);
            this.groupBox1.Controls.Add(this.label169);
            this.groupBox1.Controls.Add(this.L1CAMPO27CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO26CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO25CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO24CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO23CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO22CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO21CheckBox);
            this.groupBox1.Controls.Add(this.label70);
            this.groupBox1.Controls.Add(this.label69);
            this.groupBox1.Controls.Add(this.label68);
            this.groupBox1.Controls.Add(this.L1CAMPO20CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO19CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO18CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO17CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO16CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO15CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPOOBLIGADO3);
            this.groupBox1.Controls.Add(this.L1CAMPO14CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO13CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO12CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO11CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO9CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO10CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO8CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO7CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO6CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO5CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO3CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO4CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO2CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPO1CheckBox);
            this.groupBox1.Controls.Add(this.L1CAMPOOBLIGADO2);
            this.groupBox1.Controls.Add(this.L1CAMPOOBLIGADO1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de productos";
            // 
            // L1LBL_CAMPO36TextBox
            // 
            this.L1LBL_CAMPO36TextBox.Location = new System.Drawing.Point(371, 271);
            this.L1LBL_CAMPO36TextBox.Name = "L1LBL_CAMPO36TextBox";
            this.L1LBL_CAMPO36TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO36TextBox.TabIndex = 70;
            // 
            // lblPrecioMacro
            // 
            this.lblPrecioMacro.AutoSize = true;
            this.lblPrecioMacro.Location = new System.Drawing.Point(388, 256);
            this.lblPrecioMacro.Name = "lblPrecioMacro";
            this.lblPrecioMacro.Size = new System.Drawing.Size(81, 13);
            this.lblPrecioMacro.TabIndex = 97;
            this.lblPrecioMacro.Text = "Precio macro";
            // 
            // L1CAMPO36CheckBox
            // 
            this.L1CAMPO36CheckBox.AutoSize = true;
            this.L1CAMPO36CheckBox.Location = new System.Drawing.Point(373, 256);
            this.L1CAMPO36CheckBox.Name = "L1CAMPO36CheckBox";
            this.L1CAMPO36CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPO36CheckBox.TabIndex = 69;
            this.L1CAMPO36CheckBox.UseVisualStyleBackColor = true;
            // 
            // PORCUTILMACROLISTADOTextBox
            // 
            this.PORCUTILMACROLISTADOTextBox.AllowNegative = false;
            this.PORCUTILMACROLISTADOTextBox.Format_Expression = null;
            this.PORCUTILMACROLISTADOTextBox.Location = new System.Drawing.Point(618, 417);
            this.PORCUTILMACROLISTADOTextBox.Name = "PORCUTILMACROLISTADOTextBox";
            this.PORCUTILMACROLISTADOTextBox.NumericPrecision = 5;
            this.PORCUTILMACROLISTADOTextBox.NumericScaleOnFocus = 2;
            this.PORCUTILMACROLISTADOTextBox.NumericScaleOnLostFocus = 2;
            this.PORCUTILMACROLISTADOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORCUTILMACROLISTADOTextBox.Size = new System.Drawing.Size(101, 20);
            this.PORCUTILMACROLISTADOTextBox.TabIndex = 95;
            this.PORCUTILMACROLISTADOTextBox.Tag = 34;
            this.PORCUTILMACROLISTADOTextBox.Text = "0.00";
            this.PORCUTILMACROLISTADOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORCUTILMACROLISTADOTextBox.ValidationExpression = null;
            this.PORCUTILMACROLISTADOTextBox.ZeroIsValid = true;
            // 
            // label323
            // 
            this.label323.AutoSize = true;
            this.label323.Location = new System.Drawing.Point(615, 400);
            this.label323.Name = "label323";
            this.label323.Size = new System.Drawing.Size(128, 13);
            this.label323.TabIndex = 94;
            this.label323.Text = "% utilidad prec macro";
            // 
            // PORCUTILIDADLISTADOTextBox
            // 
            this.PORCUTILIDADLISTADOTextBox.AllowNegative = false;
            this.PORCUTILIDADLISTADOTextBox.Format_Expression = null;
            this.PORCUTILIDADLISTADOTextBox.Location = new System.Drawing.Point(501, 417);
            this.PORCUTILIDADLISTADOTextBox.Name = "PORCUTILIDADLISTADOTextBox";
            this.PORCUTILIDADLISTADOTextBox.NumericPrecision = 5;
            this.PORCUTILIDADLISTADOTextBox.NumericScaleOnFocus = 2;
            this.PORCUTILIDADLISTADOTextBox.NumericScaleOnLostFocus = 2;
            this.PORCUTILIDADLISTADOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PORCUTILIDADLISTADOTextBox.Size = new System.Drawing.Size(101, 20);
            this.PORCUTILIDADLISTADOTextBox.TabIndex = 93;
            this.PORCUTILIDADLISTADOTextBox.Tag = 34;
            this.PORCUTILIDADLISTADOTextBox.Text = "0.00";
            this.PORCUTILIDADLISTADOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PORCUTILIDADLISTADOTextBox.ValidationExpression = null;
            this.PORCUTILIDADLISTADOTextBox.ZeroIsValid = true;
            // 
            // label317
            // 
            this.label317.AutoSize = true;
            this.label317.Location = new System.Drawing.Point(498, 400);
            this.label317.Name = "label317";
            this.label317.Size = new System.Drawing.Size(106, 13);
            this.label317.TabIndex = 92;
            this.label317.Text = "% utilidad en lista";
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Location = new System.Drawing.Point(371, 401);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(116, 13);
            this.label234.TabIndex = 90;
            this.label234.Text = "Modo alerta en PV:";
            // 
            // PVCOLOREARTextBox
            // 
            this.PVCOLOREARTextBox.FormattingEnabled = true;
            this.PVCOLOREARTextBox.Items.AddRange(new object[] {
            "NINGUNO ESPECIAL",
            "PRECIO MINIMO - COSTO"});
            this.PVCOLOREARTextBox.Location = new System.Drawing.Point(370, 416);
            this.PVCOLOREARTextBox.Name = "PVCOLOREARTextBox";
            this.PVCOLOREARTextBox.Size = new System.Drawing.Size(115, 21);
            this.PVCOLOREARTextBox.TabIndex = 84;
            // 
            // L1LBL_CAMPO35TextBox
            // 
            this.L1LBL_CAMPO35TextBox.Location = new System.Drawing.Point(241, 418);
            this.L1LBL_CAMPO35TextBox.Name = "L1LBL_CAMPO35TextBox";
            this.L1LBL_CAMPO35TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO35TextBox.TabIndex = 83;
            // 
            // L1CAMPO35CheckBox
            // 
            this.L1CAMPO35CheckBox.AutoSize = true;
            this.L1CAMPO35CheckBox.Location = new System.Drawing.Point(244, 400);
            this.L1CAMPO35CheckBox.Name = "L1CAMPO35CheckBox";
            this.L1CAMPO35CheckBox.Size = new System.Drawing.Size(96, 17);
            this.L1CAMPO35CheckBox.TabIndex = 82;
            this.L1CAMPO35CheckBox.Text = "Pieza / Caja";
            this.L1CAMPO35CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1LBL_CAMPO34TextBox
            // 
            this.L1LBL_CAMPO34TextBox.Location = new System.Drawing.Point(7, 418);
            this.L1LBL_CAMPO34TextBox.Name = "L1LBL_CAMPO34TextBox";
            this.L1LBL_CAMPO34TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO34TextBox.TabIndex = 81;
            // 
            // L1CAMPO34CheckBox
            // 
            this.L1CAMPO34CheckBox.AutoSize = true;
            this.L1CAMPO34CheckBox.Location = new System.Drawing.Point(8, 400);
            this.L1CAMPO34CheckBox.Name = "L1CAMPO34CheckBox";
            this.L1CAMPO34CheckBox.Size = new System.Drawing.Size(139, 17);
            this.L1CAMPO34CheckBox.TabIndex = 80;
            this.L1CAMPO34CheckBox.Text = "Unidad de empaque";
            this.L1CAMPO34CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO33CheckBox
            // 
            this.L1CAMPO33CheckBox.AutoSize = true;
            this.L1CAMPO33CheckBox.Location = new System.Drawing.Point(372, 349);
            this.L1CAMPO33CheckBox.Name = "L1CAMPO33CheckBox";
            this.L1CAMPO33CheckBox.Size = new System.Drawing.Size(332, 17);
            this.L1CAMPO33CheckBox.TabIndex = 79;
            this.L1CAMPO33CheckBox.Text = "Precio medio mayoreo con impuesto y comision tarjeta";
            this.L1CAMPO33CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1LBL_CAMPO33TextBox
            // 
            this.L1LBL_CAMPO33TextBox.Location = new System.Drawing.Point(370, 370);
            this.L1LBL_CAMPO33TextBox.Name = "L1LBL_CAMPO33TextBox";
            this.L1LBL_CAMPO33TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO33TextBox.TabIndex = 78;
            // 
            // L1CAMPO32CheckBox
            // 
            this.L1CAMPO32CheckBox.AutoSize = true;
            this.L1CAMPO32CheckBox.Location = new System.Drawing.Point(7, 349);
            this.L1CAMPO32CheckBox.Name = "L1CAMPO32CheckBox";
            this.L1CAMPO32CheckBox.Size = new System.Drawing.Size(332, 17);
            this.L1CAMPO32CheckBox.TabIndex = 77;
            this.L1CAMPO32CheckBox.Text = "Precio medio mayoreo con impuesto y comision tarjeta";
            this.L1CAMPO32CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1LBL_CAMPO32TextBox
            // 
            this.L1LBL_CAMPO32TextBox.Location = new System.Drawing.Point(5, 370);
            this.L1LBL_CAMPO32TextBox.Name = "L1LBL_CAMPO32TextBox";
            this.L1LBL_CAMPO32TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO32TextBox.TabIndex = 76;
            // 
            // L1LBL_CAMPO31TextBox
            // 
            this.L1LBL_CAMPO31TextBox.Location = new System.Drawing.Point(623, 227);
            this.L1LBL_CAMPO31TextBox.Name = "L1LBL_CAMPO31TextBox";
            this.L1LBL_CAMPO31TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO31TextBox.TabIndex = 75;
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(639, 210);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(71, 13);
            this.label203.TabIndex = 74;
            this.label203.Text = "Precio caja";
            // 
            // L1CAMPO31CheckBox
            // 
            this.L1CAMPO31CheckBox.AutoSize = true;
            this.L1CAMPO31CheckBox.Location = new System.Drawing.Point(624, 210);
            this.L1CAMPO31CheckBox.Name = "L1CAMPO31CheckBox";
            this.L1CAMPO31CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPO31CheckBox.TabIndex = 73;
            this.L1CAMPO31CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1LBL_CAMPO23TextBox
            // 
            this.L1LBL_CAMPO23TextBox.Location = new System.Drawing.Point(498, 322);
            this.L1LBL_CAMPO23TextBox.Name = "L1LBL_CAMPO23TextBox";
            this.L1LBL_CAMPO23TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO23TextBox.TabIndex = 72;
            // 
            // L1LBL_CAMPO22TextBox
            // 
            this.L1LBL_CAMPO22TextBox.Location = new System.Drawing.Point(372, 321);
            this.L1LBL_CAMPO22TextBox.Name = "L1LBL_CAMPO22TextBox";
            this.L1LBL_CAMPO22TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO22TextBox.TabIndex = 71;
            // 
            // L1LBL_CAMPO21TextBox
            // 
            this.L1LBL_CAMPO21TextBox.Location = new System.Drawing.Point(240, 321);
            this.L1LBL_CAMPO21TextBox.Name = "L1LBL_CAMPO21TextBox";
            this.L1LBL_CAMPO21TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO21TextBox.TabIndex = 70;
            // 
            // L1LBL_CAMPO20TextBox
            // 
            this.L1LBL_CAMPO20TextBox.Location = new System.Drawing.Point(111, 320);
            this.L1LBL_CAMPO20TextBox.Name = "L1LBL_CAMPO20TextBox";
            this.L1LBL_CAMPO20TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO20TextBox.TabIndex = 69;
            // 
            // L1LBL_CAMPO18TextBox
            // 
            this.L1LBL_CAMPO18TextBox.Location = new System.Drawing.Point(239, 272);
            this.L1LBL_CAMPO18TextBox.Name = "L1LBL_CAMPO18TextBox";
            this.L1LBL_CAMPO18TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO18TextBox.TabIndex = 68;
            // 
            // L1LBL_CAMPO16TextBox
            // 
            this.L1LBL_CAMPO16TextBox.Location = new System.Drawing.Point(111, 272);
            this.L1LBL_CAMPO16TextBox.Name = "L1LBL_CAMPO16TextBox";
            this.L1LBL_CAMPO16TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO16TextBox.TabIndex = 67;
            // 
            // L1LBL_CAMPO30TextBox
            // 
            this.L1LBL_CAMPO30TextBox.Location = new System.Drawing.Point(494, 228);
            this.L1LBL_CAMPO30TextBox.Name = "L1LBL_CAMPO30TextBox";
            this.L1LBL_CAMPO30TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO30TextBox.TabIndex = 66;
            // 
            // L1LBL_CAMPO29TextBox
            // 
            this.L1LBL_CAMPO29TextBox.Location = new System.Drawing.Point(372, 227);
            this.L1LBL_CAMPO29TextBox.Name = "L1LBL_CAMPO29TextBox";
            this.L1LBL_CAMPO29TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO29TextBox.TabIndex = 65;
            // 
            // L1LBL_CAMPO28TextBox
            // 
            this.L1LBL_CAMPO28TextBox.Location = new System.Drawing.Point(240, 227);
            this.L1LBL_CAMPO28TextBox.Name = "L1LBL_CAMPO28TextBox";
            this.L1LBL_CAMPO28TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO28TextBox.TabIndex = 64;
            // 
            // L1LBL_CAMPO27TextBox
            // 
            this.L1LBL_CAMPO27TextBox.Location = new System.Drawing.Point(111, 227);
            this.L1LBL_CAMPO27TextBox.Name = "L1LBL_CAMPO27TextBox";
            this.L1LBL_CAMPO27TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO27TextBox.TabIndex = 63;
            // 
            // L1LBL_CAMPO26TextBox
            // 
            this.L1LBL_CAMPO26TextBox.Location = new System.Drawing.Point(494, 177);
            this.L1LBL_CAMPO26TextBox.Name = "L1LBL_CAMPO26TextBox";
            this.L1LBL_CAMPO26TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO26TextBox.TabIndex = 62;
            // 
            // L1LBL_CAMPO24TextBox
            // 
            this.L1LBL_CAMPO24TextBox.Location = new System.Drawing.Point(241, 177);
            this.L1LBL_CAMPO24TextBox.Name = "L1LBL_CAMPO24TextBox";
            this.L1LBL_CAMPO24TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO24TextBox.TabIndex = 61;
            // 
            // L1LBL_CAMPO25TextBox
            // 
            this.L1LBL_CAMPO25TextBox.Location = new System.Drawing.Point(371, 177);
            this.L1LBL_CAMPO25TextBox.Name = "L1LBL_CAMPO25TextBox";
            this.L1LBL_CAMPO25TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO25TextBox.TabIndex = 60;
            // 
            // L1LBL_CAMPO17TextBox
            // 
            this.L1LBL_CAMPO17TextBox.Location = new System.Drawing.Point(110, 179);
            this.L1LBL_CAMPO17TextBox.Name = "L1LBL_CAMPO17TextBox";
            this.L1LBL_CAMPO17TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO17TextBox.TabIndex = 59;
            // 
            // L1LBL_CAMPO13TextBox
            // 
            this.L1LBL_CAMPO13TextBox.Location = new System.Drawing.Point(622, 130);
            this.L1LBL_CAMPO13TextBox.Name = "L1LBL_CAMPO13TextBox";
            this.L1LBL_CAMPO13TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO13TextBox.TabIndex = 58;
            // 
            // L1LBL_CAMPO7TextBox
            // 
            this.L1LBL_CAMPO7TextBox.Location = new System.Drawing.Point(621, 84);
            this.L1LBL_CAMPO7TextBox.Name = "L1LBL_CAMPO7TextBox";
            this.L1LBL_CAMPO7TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO7TextBox.TabIndex = 57;
            // 
            // L1LBL_CAMPO12TextBox
            // 
            this.L1LBL_CAMPO12TextBox.Location = new System.Drawing.Point(496, 130);
            this.L1LBL_CAMPO12TextBox.Name = "L1LBL_CAMPO12TextBox";
            this.L1LBL_CAMPO12TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO12TextBox.TabIndex = 56;
            // 
            // L1LBL_CAMPO6TextBox
            // 
            this.L1LBL_CAMPO6TextBox.Location = new System.Drawing.Point(494, 84);
            this.L1LBL_CAMPO6TextBox.Name = "L1LBL_CAMPO6TextBox";
            this.L1LBL_CAMPO6TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO6TextBox.TabIndex = 55;
            // 
            // L1LBL_CAMPO11TextBox
            // 
            this.L1LBL_CAMPO11TextBox.Location = new System.Drawing.Point(371, 130);
            this.L1LBL_CAMPO11TextBox.Name = "L1LBL_CAMPO11TextBox";
            this.L1LBL_CAMPO11TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO11TextBox.TabIndex = 54;
            // 
            // L1LBL_CAMPO5TextBox
            // 
            this.L1LBL_CAMPO5TextBox.Location = new System.Drawing.Point(370, 84);
            this.L1LBL_CAMPO5TextBox.Name = "L1LBL_CAMPO5TextBox";
            this.L1LBL_CAMPO5TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO5TextBox.TabIndex = 53;
            // 
            // L1LBL_CAMPO10TextBox
            // 
            this.L1LBL_CAMPO10TextBox.Location = new System.Drawing.Point(241, 130);
            this.L1LBL_CAMPO10TextBox.Name = "L1LBL_CAMPO10TextBox";
            this.L1LBL_CAMPO10TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO10TextBox.TabIndex = 52;
            // 
            // L1LBL_CAMPO9TextBox
            // 
            this.L1LBL_CAMPO9TextBox.Location = new System.Drawing.Point(108, 130);
            this.L1LBL_CAMPO9TextBox.Name = "L1LBL_CAMPO9TextBox";
            this.L1LBL_CAMPO9TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO9TextBox.TabIndex = 51;
            // 
            // L1LBL_CAMPO4TextBox
            // 
            this.L1LBL_CAMPO4TextBox.Location = new System.Drawing.Point(239, 83);
            this.L1LBL_CAMPO4TextBox.Name = "L1LBL_CAMPO4TextBox";
            this.L1LBL_CAMPO4TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO4TextBox.TabIndex = 50;
            // 
            // L1LBL_CAMPO3TextBox
            // 
            this.L1LBL_CAMPO3TextBox.Location = new System.Drawing.Point(111, 83);
            this.L1LBL_CAMPO3TextBox.Name = "L1LBL_CAMPO3TextBox";
            this.L1LBL_CAMPO3TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO3TextBox.TabIndex = 49;
            // 
            // L1LBL_CAMPO1TextBox
            // 
            this.L1LBL_CAMPO1TextBox.Location = new System.Drawing.Point(239, 40);
            this.L1LBL_CAMPO1TextBox.Name = "L1LBL_CAMPO1TextBox";
            this.L1LBL_CAMPO1TextBox.Size = new System.Drawing.Size(96, 20);
            this.L1LBL_CAMPO1TextBox.TabIndex = 48;
            // 
            // L1LBL_CAMPO19TextBox
            // 
            this.L1LBL_CAMPO19TextBox.Location = new System.Drawing.Point(5, 320);
            this.L1LBL_CAMPO19TextBox.Name = "L1LBL_CAMPO19TextBox";
            this.L1LBL_CAMPO19TextBox.Size = new System.Drawing.Size(97, 20);
            this.L1LBL_CAMPO19TextBox.TabIndex = 46;
            // 
            // L1LBL_CAMPO15TextBox
            // 
            this.L1LBL_CAMPO15TextBox.Location = new System.Drawing.Point(6, 273);
            this.L1LBL_CAMPO15TextBox.Name = "L1LBL_CAMPO15TextBox";
            this.L1LBL_CAMPO15TextBox.Size = new System.Drawing.Size(97, 20);
            this.L1LBL_CAMPO15TextBox.TabIndex = 45;
            // 
            // L1LBL_CAMPO14TextBox
            // 
            this.L1LBL_CAMPO14TextBox.Location = new System.Drawing.Point(5, 179);
            this.L1LBL_CAMPO14TextBox.Name = "L1LBL_CAMPO14TextBox";
            this.L1LBL_CAMPO14TextBox.Size = new System.Drawing.Size(97, 20);
            this.L1LBL_CAMPO14TextBox.TabIndex = 43;
            // 
            // L1LBL_CAMPO8TextBox
            // 
            this.L1LBL_CAMPO8TextBox.Location = new System.Drawing.Point(5, 130);
            this.L1LBL_CAMPO8TextBox.Name = "L1LBL_CAMPO8TextBox";
            this.L1LBL_CAMPO8TextBox.Size = new System.Drawing.Size(97, 20);
            this.L1LBL_CAMPO8TextBox.TabIndex = 42;
            // 
            // L1LBL_CAMPO2TextBox
            // 
            this.L1LBL_CAMPO2TextBox.Location = new System.Drawing.Point(6, 83);
            this.L1LBL_CAMPO2TextBox.Name = "L1LBL_CAMPO2TextBox";
            this.L1LBL_CAMPO2TextBox.Size = new System.Drawing.Size(97, 20);
            this.L1LBL_CAMPO2TextBox.TabIndex = 41;
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(510, 211);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(87, 13);
            this.label172.TabIndex = 39;
            this.label172.Text = "Precio5 + IMP";
            // 
            // L1CAMPO30CheckBox
            // 
            this.L1CAMPO30CheckBox.AutoSize = true;
            this.L1CAMPO30CheckBox.Location = new System.Drawing.Point(495, 211);
            this.L1CAMPO30CheckBox.Name = "L1CAMPO30CheckBox";
            this.L1CAMPO30CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPO30CheckBox.TabIndex = 38;
            this.L1CAMPO30CheckBox.UseVisualStyleBackColor = true;
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Location = new System.Drawing.Point(389, 212);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(87, 13);
            this.label170.TabIndex = 37;
            this.label170.Text = "Precio4 + IMP";
            // 
            // L1CAMPO29CheckBox
            // 
            this.L1CAMPO29CheckBox.AutoSize = true;
            this.L1CAMPO29CheckBox.Location = new System.Drawing.Point(374, 212);
            this.L1CAMPO29CheckBox.Name = "L1CAMPO29CheckBox";
            this.L1CAMPO29CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPO29CheckBox.TabIndex = 36;
            this.L1CAMPO29CheckBox.UseVisualStyleBackColor = true;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Location = new System.Drawing.Point(256, 212);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(87, 13);
            this.label171.TabIndex = 35;
            this.label171.Text = "Precio3 + IMP";
            // 
            // L1CAMPO28CheckBox
            // 
            this.L1CAMPO28CheckBox.AutoSize = true;
            this.L1CAMPO28CheckBox.Location = new System.Drawing.Point(241, 212);
            this.L1CAMPO28CheckBox.Name = "L1CAMPO28CheckBox";
            this.L1CAMPO28CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPO28CheckBox.TabIndex = 34;
            this.L1CAMPO28CheckBox.UseVisualStyleBackColor = true;
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(126, 211);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(87, 13);
            this.label169.TabIndex = 33;
            this.label169.Text = "Precio2 + IMP";
            // 
            // L1CAMPO27CheckBox
            // 
            this.L1CAMPO27CheckBox.AutoSize = true;
            this.L1CAMPO27CheckBox.Location = new System.Drawing.Point(111, 211);
            this.L1CAMPO27CheckBox.Name = "L1CAMPO27CheckBox";
            this.L1CAMPO27CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPO27CheckBox.TabIndex = 32;
            this.L1CAMPO27CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO26CheckBox
            // 
            this.L1CAMPO26CheckBox.AutoSize = true;
            this.L1CAMPO26CheckBox.Location = new System.Drawing.Point(495, 161);
            this.L1CAMPO26CheckBox.Name = "L1CAMPO26CheckBox";
            this.L1CAMPO26CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L1CAMPO26CheckBox.TabIndex = 31;
            this.L1CAMPO26CheckBox.Text = "Precio 5";
            this.L1CAMPO26CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO25CheckBox
            // 
            this.L1CAMPO25CheckBox.AutoSize = true;
            this.L1CAMPO25CheckBox.Location = new System.Drawing.Point(372, 161);
            this.L1CAMPO25CheckBox.Name = "L1CAMPO25CheckBox";
            this.L1CAMPO25CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L1CAMPO25CheckBox.TabIndex = 30;
            this.L1CAMPO25CheckBox.Text = "Precio 4";
            this.L1CAMPO25CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO24CheckBox
            // 
            this.L1CAMPO24CheckBox.AutoSize = true;
            this.L1CAMPO24CheckBox.Location = new System.Drawing.Point(241, 161);
            this.L1CAMPO24CheckBox.Name = "L1CAMPO24CheckBox";
            this.L1CAMPO24CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L1CAMPO24CheckBox.TabIndex = 29;
            this.L1CAMPO24CheckBox.Text = "Precio 3";
            this.L1CAMPO24CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO23CheckBox
            // 
            this.L1CAMPO23CheckBox.AutoSize = true;
            this.L1CAMPO23CheckBox.Location = new System.Drawing.Point(497, 305);
            this.L1CAMPO23CheckBox.Name = "L1CAMPO23CheckBox";
            this.L1CAMPO23CheckBox.Size = new System.Drawing.Size(142, 17);
            this.L1CAMPO23CheckBox.TabIndex = 28;
            this.L1CAMPO23CheckBox.Text = "Desglose almacenes";
            this.L1CAMPO23CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO22CheckBox
            // 
            this.L1CAMPO22CheckBox.AutoSize = true;
            this.L1CAMPO22CheckBox.Location = new System.Drawing.Point(373, 303);
            this.L1CAMPO22CheckBox.Name = "L1CAMPO22CheckBox";
            this.L1CAMPO22CheckBox.Size = new System.Drawing.Size(82, 17);
            this.L1CAMPO22CheckBox.TabIndex = 27;
            this.L1CAMPO22CheckBox.Text = "Tasa Ieps";
            this.L1CAMPO22CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO21CheckBox
            // 
            this.L1CAMPO21CheckBox.AutoSize = true;
            this.L1CAMPO21CheckBox.Location = new System.Drawing.Point(241, 304);
            this.L1CAMPO21CheckBox.Name = "L1CAMPO21CheckBox";
            this.L1CAMPO21CheckBox.Size = new System.Drawing.Size(90, 17);
            this.L1CAMPO21CheckBox.TabIndex = 23;
            this.L1CAMPO21CheckBox.Text = "En proceso";
            this.L1CAMPO21CheckBox.UseVisualStyleBackColor = true;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(128, 24);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(85, 13);
            this.label70.TabIndex = 25;
            this.label70.Text = "Descripción 1";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(24, 23);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(39, 13);
            this.label69.TabIndex = 24;
            this.label69.Text = "Clave";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(21, 211);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(85, 13);
            this.label68.TabIndex = 23;
            this.label68.Text = "Precio1 + IVA";
            // 
            // L1CAMPO20CheckBox
            // 
            this.L1CAMPO20CheckBox.AutoSize = true;
            this.L1CAMPO20CheckBox.Location = new System.Drawing.Point(111, 303);
            this.L1CAMPO20CheckBox.Name = "L1CAMPO20CheckBox";
            this.L1CAMPO20CheckBox.Size = new System.Drawing.Size(83, 17);
            this.L1CAMPO20CheckBox.TabIndex = 22;
            this.L1CAMPO20CheckBox.Text = "Apartados";
            this.L1CAMPO20CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO19CheckBox
            // 
            this.L1CAMPO19CheckBox.AutoSize = true;
            this.L1CAMPO19CheckBox.Location = new System.Drawing.Point(7, 301);
            this.L1CAMPO19CheckBox.Name = "L1CAMPO19CheckBox";
            this.L1CAMPO19CheckBox.Size = new System.Drawing.Size(84, 17);
            this.L1CAMPO19CheckBox.TabIndex = 21;
            this.L1CAMPO19CheckBox.Text = "Existencia";
            this.L1CAMPO19CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO18CheckBox
            // 
            this.L1CAMPO18CheckBox.AutoSize = true;
            this.L1CAMPO18CheckBox.Location = new System.Drawing.Point(240, 255);
            this.L1CAMPO18CheckBox.Name = "L1CAMPO18CheckBox";
            this.L1CAMPO18CheckBox.Size = new System.Drawing.Size(104, 17);
            this.L1CAMPO18CheckBox.TabIndex = 20;
            this.L1CAMPO18CheckBox.Text = "Codigo barras";
            this.L1CAMPO18CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO17CheckBox
            // 
            this.L1CAMPO17CheckBox.AutoSize = true;
            this.L1CAMPO17CheckBox.Location = new System.Drawing.Point(111, 161);
            this.L1CAMPO17CheckBox.Name = "L1CAMPO17CheckBox";
            this.L1CAMPO17CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L1CAMPO17CheckBox.TabIndex = 19;
            this.L1CAMPO17CheckBox.Text = "Precio 2";
            this.L1CAMPO17CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO16CheckBox
            // 
            this.L1CAMPO16CheckBox.AutoSize = true;
            this.L1CAMPO16CheckBox.Location = new System.Drawing.Point(111, 255);
            this.L1CAMPO16CheckBox.Name = "L1CAMPO16CheckBox";
            this.L1CAMPO16CheckBox.Size = new System.Drawing.Size(109, 17);
            this.L1CAMPO16CheckBox.TabIndex = 18;
            this.L1CAMPO16CheckBox.Text = "Limite precio 2";
            this.L1CAMPO16CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO15CheckBox
            // 
            this.L1CAMPO15CheckBox.AutoSize = true;
            this.L1CAMPO15CheckBox.Location = new System.Drawing.Point(7, 255);
            this.L1CAMPO15CheckBox.Name = "L1CAMPO15CheckBox";
            this.L1CAMPO15CheckBox.Size = new System.Drawing.Size(76, 17);
            this.L1CAMPO15CheckBox.TabIndex = 17;
            this.L1CAMPO15CheckBox.Text = "Tasa Iva";
            this.L1CAMPO15CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPOOBLIGADO3
            // 
            this.L1CAMPOOBLIGADO3.AutoSize = true;
            this.L1CAMPOOBLIGADO3.Checked = true;
            this.L1CAMPOOBLIGADO3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.L1CAMPOOBLIGADO3.Enabled = false;
            this.L1CAMPOOBLIGADO3.Location = new System.Drawing.Point(6, 210);
            this.L1CAMPOOBLIGADO3.Name = "L1CAMPOOBLIGADO3";
            this.L1CAMPOOBLIGADO3.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPOOBLIGADO3.TabIndex = 16;
            this.L1CAMPOOBLIGADO3.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO14CheckBox
            // 
            this.L1CAMPO14CheckBox.AutoSize = true;
            this.L1CAMPO14CheckBox.Location = new System.Drawing.Point(5, 161);
            this.L1CAMPO14CheckBox.Name = "L1CAMPO14CheckBox";
            this.L1CAMPO14CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L1CAMPO14CheckBox.TabIndex = 15;
            this.L1CAMPO14CheckBox.Text = "Precio 1";
            this.L1CAMPO14CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO13CheckBox
            // 
            this.L1CAMPO13CheckBox.AutoSize = true;
            this.L1CAMPO13CheckBox.Location = new System.Drawing.Point(623, 113);
            this.L1CAMPO13CheckBox.Name = "L1CAMPO13CheckBox";
            this.L1CAMPO13CheckBox.Size = new System.Drawing.Size(72, 17);
            this.L1CAMPO13CheckBox.TabIndex = 14;
            this.L1CAMPO13CheckBox.Text = "Fecha 2";
            this.L1CAMPO13CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO12CheckBox
            // 
            this.L1CAMPO12CheckBox.AutoSize = true;
            this.L1CAMPO12CheckBox.Location = new System.Drawing.Point(496, 113);
            this.L1CAMPO12CheckBox.Name = "L1CAMPO12CheckBox";
            this.L1CAMPO12CheckBox.Size = new System.Drawing.Size(72, 17);
            this.L1CAMPO12CheckBox.TabIndex = 13;
            this.L1CAMPO12CheckBox.Text = "Fecha 1";
            this.L1CAMPO12CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO11CheckBox
            // 
            this.L1CAMPO11CheckBox.AutoSize = true;
            this.L1CAMPO11CheckBox.Location = new System.Drawing.Point(372, 113);
            this.L1CAMPO11CheckBox.Name = "L1CAMPO11CheckBox";
            this.L1CAMPO11CheckBox.Size = new System.Drawing.Size(80, 17);
            this.L1CAMPO11CheckBox.TabIndex = 12;
            this.L1CAMPO11CheckBox.Text = "Numero 4";
            this.L1CAMPO11CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO9CheckBox
            // 
            this.L1CAMPO9CheckBox.AutoSize = true;
            this.L1CAMPO9CheckBox.Location = new System.Drawing.Point(110, 113);
            this.L1CAMPO9CheckBox.Name = "L1CAMPO9CheckBox";
            this.L1CAMPO9CheckBox.Size = new System.Drawing.Size(80, 17);
            this.L1CAMPO9CheckBox.TabIndex = 11;
            this.L1CAMPO9CheckBox.Text = "Numero 2";
            this.L1CAMPO9CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO10CheckBox
            // 
            this.L1CAMPO10CheckBox.AutoSize = true;
            this.L1CAMPO10CheckBox.Location = new System.Drawing.Point(241, 113);
            this.L1CAMPO10CheckBox.Name = "L1CAMPO10CheckBox";
            this.L1CAMPO10CheckBox.Size = new System.Drawing.Size(80, 17);
            this.L1CAMPO10CheckBox.TabIndex = 10;
            this.L1CAMPO10CheckBox.Text = "Numero 3";
            this.L1CAMPO10CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO8CheckBox
            // 
            this.L1CAMPO8CheckBox.AutoSize = true;
            this.L1CAMPO8CheckBox.Location = new System.Drawing.Point(6, 113);
            this.L1CAMPO8CheckBox.Name = "L1CAMPO8CheckBox";
            this.L1CAMPO8CheckBox.Size = new System.Drawing.Size(80, 17);
            this.L1CAMPO8CheckBox.TabIndex = 9;
            this.L1CAMPO8CheckBox.Text = "Numero 1";
            this.L1CAMPO8CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO7CheckBox
            // 
            this.L1CAMPO7CheckBox.AutoSize = true;
            this.L1CAMPO7CheckBox.Location = new System.Drawing.Point(622, 67);
            this.L1CAMPO7CheckBox.Name = "L1CAMPO7CheckBox";
            this.L1CAMPO7CheckBox.Size = new System.Drawing.Size(69, 17);
            this.L1CAMPO7CheckBox.TabIndex = 8;
            this.L1CAMPO7CheckBox.Text = "Texto 6";
            this.L1CAMPO7CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO6CheckBox
            // 
            this.L1CAMPO6CheckBox.AutoSize = true;
            this.L1CAMPO6CheckBox.Location = new System.Drawing.Point(495, 67);
            this.L1CAMPO6CheckBox.Name = "L1CAMPO6CheckBox";
            this.L1CAMPO6CheckBox.Size = new System.Drawing.Size(69, 17);
            this.L1CAMPO6CheckBox.TabIndex = 7;
            this.L1CAMPO6CheckBox.Text = "Texto 5";
            this.L1CAMPO6CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO5CheckBox
            // 
            this.L1CAMPO5CheckBox.AutoSize = true;
            this.L1CAMPO5CheckBox.Location = new System.Drawing.Point(371, 67);
            this.L1CAMPO5CheckBox.Name = "L1CAMPO5CheckBox";
            this.L1CAMPO5CheckBox.Size = new System.Drawing.Size(69, 17);
            this.L1CAMPO5CheckBox.TabIndex = 6;
            this.L1CAMPO5CheckBox.Text = "Texto 4";
            this.L1CAMPO5CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO3CheckBox
            // 
            this.L1CAMPO3CheckBox.AutoSize = true;
            this.L1CAMPO3CheckBox.Location = new System.Drawing.Point(109, 67);
            this.L1CAMPO3CheckBox.Name = "L1CAMPO3CheckBox";
            this.L1CAMPO3CheckBox.Size = new System.Drawing.Size(69, 17);
            this.L1CAMPO3CheckBox.TabIndex = 5;
            this.L1CAMPO3CheckBox.Text = "Texto 2";
            this.L1CAMPO3CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO4CheckBox
            // 
            this.L1CAMPO4CheckBox.AutoSize = true;
            this.L1CAMPO4CheckBox.Location = new System.Drawing.Point(240, 67);
            this.L1CAMPO4CheckBox.Name = "L1CAMPO4CheckBox";
            this.L1CAMPO4CheckBox.Size = new System.Drawing.Size(69, 17);
            this.L1CAMPO4CheckBox.TabIndex = 4;
            this.L1CAMPO4CheckBox.Text = "Texto 3";
            this.L1CAMPO4CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO2CheckBox
            // 
            this.L1CAMPO2CheckBox.AutoSize = true;
            this.L1CAMPO2CheckBox.Location = new System.Drawing.Point(5, 67);
            this.L1CAMPO2CheckBox.Name = "L1CAMPO2CheckBox";
            this.L1CAMPO2CheckBox.Size = new System.Drawing.Size(69, 17);
            this.L1CAMPO2CheckBox.TabIndex = 3;
            this.L1CAMPO2CheckBox.Text = "Texto 1";
            this.L1CAMPO2CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPO1CheckBox
            // 
            this.L1CAMPO1CheckBox.AutoSize = true;
            this.L1CAMPO1CheckBox.Location = new System.Drawing.Point(241, 23);
            this.L1CAMPO1CheckBox.Name = "L1CAMPO1CheckBox";
            this.L1CAMPO1CheckBox.Size = new System.Drawing.Size(104, 17);
            this.L1CAMPO1CheckBox.TabIndex = 2;
            this.L1CAMPO1CheckBox.Text = "Descripción 2";
            this.L1CAMPO1CheckBox.UseVisualStyleBackColor = true;
            // 
            // L1CAMPOOBLIGADO2
            // 
            this.L1CAMPOOBLIGADO2.AutoSize = true;
            this.L1CAMPOOBLIGADO2.Checked = true;
            this.L1CAMPOOBLIGADO2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.L1CAMPOOBLIGADO2.Enabled = false;
            this.L1CAMPOOBLIGADO2.Location = new System.Drawing.Point(110, 23);
            this.L1CAMPOOBLIGADO2.Name = "L1CAMPOOBLIGADO2";
            this.L1CAMPOOBLIGADO2.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPOOBLIGADO2.TabIndex = 1;
            this.L1CAMPOOBLIGADO2.UseVisualStyleBackColor = true;
            // 
            // L1CAMPOOBLIGADO1
            // 
            this.L1CAMPOOBLIGADO1.AutoSize = true;
            this.L1CAMPOOBLIGADO1.Checked = true;
            this.L1CAMPOOBLIGADO1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.L1CAMPOOBLIGADO1.Enabled = false;
            this.L1CAMPOOBLIGADO1.ForeColor = System.Drawing.Color.Gainsboro;
            this.L1CAMPOOBLIGADO1.Location = new System.Drawing.Point(6, 23);
            this.L1CAMPOOBLIGADO1.Name = "L1CAMPOOBLIGADO1";
            this.L1CAMPOOBLIGADO1.Size = new System.Drawing.Size(15, 14);
            this.L1CAMPOOBLIGADO1.TabIndex = 0;
            this.L1CAMPOOBLIGADO1.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.tabPage9.Controls.Add(this.HABSURTIDOPOSTMOVILTextBox);
            this.tabPage9.Controls.Add(this.label316);
            this.tabPage9.Controls.Add(this.rutaBdVenMovTextBox);
            this.tabPage9.Controls.Add(this.label245);
            this.tabPage9.Controls.Add(this.MOVIL3_PREIMPORTARCheckBox);
            this.tabPage9.Controls.Add(this.label242);
            this.tabPage9.Controls.Add(this.MOVIL_TIENEVENDEDORESComboBox);
            this.tabPage9.Controls.Add(this.TIPOSYNCMOVILTextBox);
            this.tabPage9.Controls.Add(this.label110);
            this.tabPage9.Controls.Add(this.label111);
            this.tabPage9.Controls.Add(this.label114);
            this.tabPage9.Controls.Add(this.TOUCHTextBox);
            this.tabPage9.Controls.Add(this.ESVENDEDORMOVILTextBox);
            this.tabPage9.Controls.Add(this.label124);
            this.tabPage9.Controls.Add(this.SCREENCONFIGTextBox);
            this.tabPage9.Controls.Add(this.VENDEDORMOVILIDLabel);
            this.tabPage9.Controls.Add(this.VENDEDORIDLabel);
            this.tabPage9.Controls.Add(this.label134);
            this.tabPage9.Controls.Add(this.PRECIOSMOVILANTESVENTATextBox);
            this.tabPage9.Controls.Add(this.PENDMOVILANTESVENTATextBox);
            this.tabPage9.Controls.Add(this.label133);
            this.tabPage9.Controls.Add(this.VENDEDORMOVILIDButton);
            this.tabPage9.Controls.Add(this.MOVILVERIFICARVENTAComboBox);
            this.tabPage9.Controls.Add(this.label139);
            this.tabPage9.Controls.Add(this.label138);
            this.tabPage9.Controls.Add(this.BDMATRIZMOVILTextBox);
            this.tabPage9.Controls.Add(this.label137);
            this.tabPage9.Controls.Add(this.label136);
            this.tabPage9.Controls.Add(this.BDSERVERWSTextBox);
            this.tabPage9.Controls.Add(this.TIPOVENDEDORMOVILTextBox);
            this.tabPage9.Controls.Add(this.VENDEDORMOVILCLAVETextBox);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(782, 556);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Text = "Movil";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // HABSURTIDOPOSTMOVILTextBox
            // 
            this.HABSURTIDOPOSTMOVILTextBox.FormattingEnabled = true;
            this.HABSURTIDOPOSTMOVILTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABSURTIDOPOSTMOVILTextBox.Location = new System.Drawing.Point(56, 400);
            this.HABSURTIDOPOSTMOVILTextBox.Name = "HABSURTIDOPOSTMOVILTextBox";
            this.HABSURTIDOPOSTMOVILTextBox.Size = new System.Drawing.Size(62, 21);
            this.HABSURTIDOPOSTMOVILTextBox.TabIndex = 203;
            this.HABSURTIDOPOSTMOVILTextBox.Tag = "";
            // 
            // label316
            // 
            this.label316.AutoSize = true;
            this.label316.Location = new System.Drawing.Point(16, 384);
            this.label316.Name = "label316";
            this.label316.Size = new System.Drawing.Size(205, 13);
            this.label316.TabIndex = 204;
            this.label316.Text = "Permitir surtido en almacen (movil):";
            // 
            // rutaBdVenMovTextBox
            // 
            this.rutaBdVenMovTextBox.Location = new System.Drawing.Point(365, 335);
            this.rutaBdVenMovTextBox.Name = "rutaBdVenMovTextBox";
            this.rutaBdVenMovTextBox.Size = new System.Drawing.Size(298, 20);
            this.rutaBdVenMovTextBox.TabIndex = 202;
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Location = new System.Drawing.Point(45, 335);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(117, 13);
            this.label245.TabIndex = 199;
            this.label245.Text = "Movil3 Pre-Importar";
            // 
            // MOVIL3_PREIMPORTARCheckBox
            // 
            this.MOVIL3_PREIMPORTARCheckBox.AutoSize = true;
            this.MOVIL3_PREIMPORTARCheckBox.Location = new System.Drawing.Point(24, 335);
            this.MOVIL3_PREIMPORTARCheckBox.Name = "MOVIL3_PREIMPORTARCheckBox";
            this.MOVIL3_PREIMPORTARCheckBox.Size = new System.Drawing.Size(15, 14);
            this.MOVIL3_PREIMPORTARCheckBox.TabIndex = 200;
            this.MOVIL3_PREIMPORTARCheckBox.UseVisualStyleBackColor = true;
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(365, 268);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(155, 13);
            this.label242.TabIndex = 187;
            this.label242.Text = "Tiene vendedores moviles";
            // 
            // MOVIL_TIENEVENDEDORESComboBox
            // 
            this.MOVIL_TIENEVENDEDORESComboBox.FormattingEnabled = true;
            this.MOVIL_TIENEVENDEDORESComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOVIL_TIENEVENDEDORESComboBox.Location = new System.Drawing.Point(368, 283);
            this.MOVIL_TIENEVENDEDORESComboBox.Name = "MOVIL_TIENEVENDEDORESComboBox";
            this.MOVIL_TIENEVENDEDORESComboBox.Size = new System.Drawing.Size(62, 21);
            this.MOVIL_TIENEVENDEDORESComboBox.TabIndex = 186;
            this.MOVIL_TIENEVENDEDORESComboBox.Tag = "";
            // 
            // TIPOSYNCMOVILTextBox
            // 
            this.TIPOSYNCMOVILTextBox.FormattingEnabled = true;
            this.TIPOSYNCMOVILTextBox.Items.AddRange(new object[] {
            "WS",
            "FTP"});
            this.TIPOSYNCMOVILTextBox.Location = new System.Drawing.Point(22, 67);
            this.TIPOSYNCMOVILTextBox.Name = "TIPOSYNCMOVILTextBox";
            this.TIPOSYNCMOVILTextBox.Size = new System.Drawing.Size(102, 21);
            this.TIPOSYNCMOVILTextBox.TabIndex = 112;
            this.TIPOSYNCMOVILTextBox.Tag = "";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(362, 52);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(47, 13);
            this.label110.TabIndex = 107;
            this.label110.Text = "Touch:";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(19, 3);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(115, 13);
            this.label111.TabIndex = 109;
            this.label111.Text = "Es vendedor movil:";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(19, 51);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(99, 13);
            this.label114.TabIndex = 111;
            this.label114.Text = "Tipo sync movil:";
            // 
            // TOUCHTextBox
            // 
            this.TOUCHTextBox.FormattingEnabled = true;
            this.TOUCHTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.TOUCHTextBox.Location = new System.Drawing.Point(365, 68);
            this.TOUCHTextBox.Name = "TOUCHTextBox";
            this.TOUCHTextBox.Size = new System.Drawing.Size(102, 21);
            this.TOUCHTextBox.TabIndex = 108;
            this.TOUCHTextBox.Tag = "";
            // 
            // ESVENDEDORMOVILTextBox
            // 
            this.ESVENDEDORMOVILTextBox.FormattingEnabled = true;
            this.ESVENDEDORMOVILTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.ESVENDEDORMOVILTextBox.Location = new System.Drawing.Point(22, 19);
            this.ESVENDEDORMOVILTextBox.Name = "ESVENDEDORMOVILTextBox";
            this.ESVENDEDORMOVILTextBox.Size = new System.Drawing.Size(102, 21);
            this.ESVENDEDORMOVILTextBox.TabIndex = 110;
            this.ESVENDEDORMOVILTextBox.Tag = "";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(364, 3);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(101, 13);
            this.label124.TabIndex = 113;
            this.label124.Text = "Config. Pantalla:";
            // 
            // SCREENCONFIGTextBox
            // 
            this.SCREENCONFIGTextBox.FormattingEnabled = true;
            this.SCREENCONFIGTextBox.Items.AddRange(new object[] {
            "Normal",
            "Movil mediano",
            "Movil 10\'"});
            this.SCREENCONFIGTextBox.Location = new System.Drawing.Point(367, 18);
            this.SCREENCONFIGTextBox.Name = "SCREENCONFIGTextBox";
            this.SCREENCONFIGTextBox.Size = new System.Drawing.Size(102, 21);
            this.SCREENCONFIGTextBox.TabIndex = 114;
            this.SCREENCONFIGTextBox.Tag = "";
            // 
            // VENDEDORMOVILIDLabel
            // 
            this.VENDEDORMOVILIDLabel.AutoSize = true;
            this.VENDEDORMOVILIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORMOVILIDLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORMOVILIDLabel.Location = new System.Drawing.Point(516, 127);
            this.VENDEDORMOVILIDLabel.Name = "VENDEDORMOVILIDLabel";
            this.VENDEDORMOVILIDLabel.Size = new System.Drawing.Size(19, 13);
            this.VENDEDORMOVILIDLabel.TabIndex = 185;
            this.VENDEDORMOVILIDLabel.Text = "...";
            // 
            // VENDEDORIDLabel
            // 
            this.VENDEDORIDLabel.AccessibleDescription = "";
            this.VENDEDORIDLabel.AutoSize = true;
            this.VENDEDORIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORIDLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORIDLabel.Location = new System.Drawing.Point(364, 105);
            this.VENDEDORIDLabel.Name = "VENDEDORIDLabel";
            this.VENDEDORIDLabel.Size = new System.Drawing.Size(120, 13);
            this.VENDEDORIDLabel.TabIndex = 182;
            this.VENDEDORIDLabel.Text = "Vendedor asociado:";
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(365, 214);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(243, 13);
            this.label134.TabIndex = 159;
            this.label134.Text = "(Movil) Actualizar precios antes de venta:";
            // 
            // PRECIOSMOVILANTESVENTATextBox
            // 
            this.PRECIOSMOVILANTESVENTATextBox.FormattingEnabled = true;
            this.PRECIOSMOVILANTESVENTATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PRECIOSMOVILANTESVENTATextBox.Location = new System.Drawing.Point(368, 229);
            this.PRECIOSMOVILANTESVENTATextBox.Name = "PRECIOSMOVILANTESVENTATextBox";
            this.PRECIOSMOVILANTESVENTATextBox.Size = new System.Drawing.Size(62, 21);
            this.PRECIOSMOVILANTESVENTATextBox.TabIndex = 158;
            this.PRECIOSMOVILANTESVENTATextBox.Tag = "";
            // 
            // PENDMOVILANTESVENTATextBox
            // 
            this.PENDMOVILANTESVENTATextBox.FormattingEnabled = true;
            this.PENDMOVILANTESVENTATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.PENDMOVILANTESVENTATextBox.Location = new System.Drawing.Point(367, 170);
            this.PENDMOVILANTESVENTATextBox.Name = "PENDMOVILANTESVENTATextBox";
            this.PENDMOVILANTESVENTATextBox.Size = new System.Drawing.Size(62, 21);
            this.PENDMOVILANTESVENTATextBox.TabIndex = 156;
            this.PENDMOVILANTESVENTATextBox.Tag = "";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(364, 154);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(244, 13);
            this.label133.TabIndex = 157;
            this.label133.Text = "(Movil) Enviar pendientes antes de venta:";
            // 
            // VENDEDORMOVILIDButton
            // 
            this.VENDEDORMOVILIDButton.AccessibleDescription = "";
            this.VENDEDORMOVILIDButton.BackColor = System.Drawing.Color.Transparent;
            this.VENDEDORMOVILIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.VENDEDORMOVILIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VENDEDORMOVILIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VENDEDORMOVILIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.VENDEDORMOVILIDButton.Location = new System.Drawing.Point(490, 121);
            this.VENDEDORMOVILIDButton.Name = "VENDEDORMOVILIDButton";
            this.VENDEDORMOVILIDButton.Size = new System.Drawing.Size(24, 23);
            this.VENDEDORMOVILIDButton.TabIndex = 184;
            this.VENDEDORMOVILIDButton.UseVisualStyleBackColor = false;
            // 
            // MOVILVERIFICARVENTAComboBox
            // 
            this.MOVILVERIFICARVENTAComboBox.FormattingEnabled = true;
            this.MOVILVERIFICARVENTAComboBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.MOVILVERIFICARVENTAComboBox.Location = new System.Drawing.Point(20, 284);
            this.MOVILVERIFICARVENTAComboBox.Name = "MOVILVERIFICARVENTAComboBox";
            this.MOVILVERIFICARVENTAComboBox.Size = new System.Drawing.Size(72, 21);
            this.MOVILVERIFICARVENTAComboBox.TabIndex = 122;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(17, 268);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(176, 13);
            this.label139.TabIndex = 123;
            this.label139.Text = "Verificar venta móvil (Default)";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(17, 214);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(142, 13);
            this.label138.TabIndex = 120;
            this.label138.Text = "Conexión BD a la matriz";
            // 
            // BDMATRIZMOVILTextBox
            // 
            this.BDMATRIZMOVILTextBox.Location = new System.Drawing.Point(20, 230);
            this.BDMATRIZMOVILTextBox.Name = "BDMATRIZMOVILTextBox";
            this.BDMATRIZMOVILTextBox.Size = new System.Drawing.Size(298, 20);
            this.BDMATRIZMOVILTextBox.TabIndex = 121;
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(19, 105);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(138, 13);
            this.label137.TabIndex = 119;
            this.label137.Text = "Tipo de conexión móvil";
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(17, 157);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(199, 13);
            this.label136.TabIndex = 117;
            this.label136.Text = "Conexión BD en webservice movil";
            // 
            // BDSERVERWSTextBox
            // 
            this.BDSERVERWSTextBox.Location = new System.Drawing.Point(20, 173);
            this.BDSERVERWSTextBox.Name = "BDSERVERWSTextBox";
            this.BDSERVERWSTextBox.Size = new System.Drawing.Size(298, 20);
            this.BDSERVERWSTextBox.TabIndex = 118;
            // 
            // TIPOVENDEDORMOVILTextBox
            // 
            this.TIPOVENDEDORMOVILTextBox.FormattingEnabled = true;
            this.TIPOVENDEDORMOVILTextBox.Items.AddRange(new object[] {
            "Ninguno",
            "Tipo 1",
            "Tipo 2",
            "Tipo 3",
            "Tipo 4"});
            this.TIPOVENDEDORMOVILTextBox.Location = new System.Drawing.Point(20, 121);
            this.TIPOVENDEDORMOVILTextBox.Name = "TIPOVENDEDORMOVILTextBox";
            this.TIPOVENDEDORMOVILTextBox.Size = new System.Drawing.Size(147, 21);
            this.TIPOVENDEDORMOVILTextBox.TabIndex = 0;
            // 
            // VENDEDORMOVILCLAVETextBox
            // 
            this.VENDEDORMOVILCLAVETextBox.AccessibleDescription = "";
            this.VENDEDORMOVILCLAVETextBox.BotonLookUp = this.VENDEDORMOVILIDButton;
            this.VENDEDORMOVILCLAVETextBox.Condicion = null;
            this.VENDEDORMOVILCLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORMOVILCLAVETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORMOVILCLAVETextBox.DbValue = null;
            this.VENDEDORMOVILCLAVETextBox.Format_Expression = null;
            this.VENDEDORMOVILCLAVETextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORMOVILCLAVETextBox.IndiceCampoSelector = 1;
            this.VENDEDORMOVILCLAVETextBox.IndiceCampoValue = 1;
            this.VENDEDORMOVILCLAVETextBox.LabelDescription = this.VENDEDORMOVILIDLabel;
            this.VENDEDORMOVILCLAVETextBox.Location = new System.Drawing.Point(367, 121);
            this.VENDEDORMOVILCLAVETextBox.MostrarErrores = true;
            this.VENDEDORMOVILCLAVETextBox.Name = "VENDEDORMOVILCLAVETextBox";
            this.VENDEDORMOVILCLAVETextBox.NombreCampoSelector = "clave";
            this.VENDEDORMOVILCLAVETextBox.NombreCampoValue = "clave";
            this.VENDEDORMOVILCLAVETextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 22";
            this.VENDEDORMOVILCLAVETextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave= @clave";
            this.VENDEDORMOVILCLAVETextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 22 and  clave = @clave";
            this.VENDEDORMOVILCLAVETextBox.Size = new System.Drawing.Size(117, 20);
            this.VENDEDORMOVILCLAVETextBox.TabIndex = 183;
            this.VENDEDORMOVILCLAVETextBox.Tag = 34;
            this.VENDEDORMOVILCLAVETextBox.TextDescription = null;
            this.VENDEDORMOVILCLAVETextBox.Titulo = "Cobradores";
            this.VENDEDORMOVILCLAVETextBox.ValidarEntrada = true;
            this.VENDEDORMOVILCLAVETextBox.ValidationExpression = null;
            // 
            // tabPage10
            // 
            this.tabPage10.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage10.Controls.Add(this.label193);
            this.tabPage10.Controls.Add(this.label192);
            this.tabPage10.Controls.Add(this.label191);
            this.tabPage10.Controls.Add(this.PROVEEDOR1ServButton);
            this.tabPage10.Controls.Add(this.PROVEEDOR1ServLabel);
            this.tabPage10.Controls.Add(pROVEEDOR1IDServLabel);
            this.tabPage10.Controls.Add(this.MARCAServButton);
            this.tabPage10.Controls.Add(this.MARCAServLabel);
            this.tabPage10.Controls.Add(mARCAIDServLabel);
            this.tabPage10.Controls.Add(this.LINEAServButton);
            this.tabPage10.Controls.Add(this.LINEAServLabel);
            this.tabPage10.Controls.Add(lINEAIDServLabel);
            this.tabPage10.Controls.Add(this.PROVEEDOR1RecButton);
            this.tabPage10.Controls.Add(this.PROVEEDOR1RecLabel);
            this.tabPage10.Controls.Add(pROVEEDOR1IDRecLabel);
            this.tabPage10.Controls.Add(this.MARCARecButton);
            this.tabPage10.Controls.Add(this.MARCARecLabel);
            this.tabPage10.Controls.Add(mARCAIDRecLabel);
            this.tabPage10.Controls.Add(this.LINEARecButton);
            this.tabPage10.Controls.Add(this.LINEARecLabel);
            this.tabPage10.Controls.Add(lINEAIDRecLabel);
            this.tabPage10.Controls.Add(this.label188);
            this.tabPage10.Controls.Add(this.HABPAGOSERVEMIDACheckBox);
            this.tabPage10.Controls.Add(this.label187);
            this.tabPage10.Controls.Add(this.TIMEOUTPINTDISTSALESERVTextBox);
            this.tabPage10.Controls.Add(this.label185);
            this.tabPage10.Controls.Add(this.label184);
            this.tabPage10.Controls.Add(this.nudTimeOutLookUp);
            this.tabPage10.Controls.Add(this.nudTimeOutPin);
            this.tabPage10.Controls.Add(this.label176);
            this.tabPage10.Controls.Add(this.rdbtnEmidaServices);
            this.tabPage10.Controls.Add(this.txtUtilidadPagoServicio);
            this.tabPage10.Controls.Add(this.txtPorcUtilidadRecargas);
            this.tabPage10.Controls.Add(this.PROVEEDOR1IDServTextBox);
            this.tabPage10.Controls.Add(this.MARCAIDServTextBox);
            this.tabPage10.Controls.Add(this.LINEAIDServTextBox);
            this.tabPage10.Controls.Add(this.PROVEEDOR1IDRecTextBox);
            this.tabPage10.Controls.Add(this.MARCAIDRecTextBox);
            this.tabPage10.Controls.Add(this.LINEAIDRecTextBox);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(782, 556);
            this.tabPage10.TabIndex = 10;
            this.tabPage10.Text = "Emida";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(143, 267);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(120, 13);
            this.label193.TabIndex = 217;
            this.label193.Text = "% Utilidad recargas:";
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(129, 306);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(134, 13);
            this.label192.TabIndex = 216;
            this.label192.Text = "Utilidad pago servicio:";
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(614, 465);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(159, 13);
            this.label191.TabIndex = 173;
            this.label191.Text = "Monto maximo saldo menor";
            // 
            // PROVEEDOR1ServButton
            // 
            this.PROVEEDOR1ServButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PROVEEDOR1ServButton.BackgroundImage")));
            this.PROVEEDOR1ServButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PROVEEDOR1ServButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROVEEDOR1ServButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEEDOR1ServButton.Location = new System.Drawing.Point(353, 226);
            this.PROVEEDOR1ServButton.Name = "PROVEEDOR1ServButton";
            this.PROVEEDOR1ServButton.Size = new System.Drawing.Size(21, 23);
            this.PROVEEDOR1ServButton.TabIndex = 210;
            this.PROVEEDOR1ServButton.UseVisualStyleBackColor = true;
            // 
            // PROVEEDOR1ServLabel
            // 
            this.PROVEEDOR1ServLabel.AutoSize = true;
            this.PROVEEDOR1ServLabel.Location = new System.Drawing.Point(380, 231);
            this.PROVEEDOR1ServLabel.Name = "PROVEEDOR1ServLabel";
            this.PROVEEDOR1ServLabel.Size = new System.Drawing.Size(19, 13);
            this.PROVEEDOR1ServLabel.TabIndex = 212;
            this.PROVEEDOR1ServLabel.Text = "...";
            // 
            // MARCAServButton
            // 
            this.MARCAServButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MARCAServButton.BackgroundImage")));
            this.MARCAServButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MARCAServButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MARCAServButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.MARCAServButton.Location = new System.Drawing.Point(353, 188);
            this.MARCAServButton.Name = "MARCAServButton";
            this.MARCAServButton.Size = new System.Drawing.Size(21, 23);
            this.MARCAServButton.TabIndex = 206;
            this.MARCAServButton.UseVisualStyleBackColor = true;
            // 
            // MARCAServLabel
            // 
            this.MARCAServLabel.AutoSize = true;
            this.MARCAServLabel.Location = new System.Drawing.Point(380, 192);
            this.MARCAServLabel.Name = "MARCAServLabel";
            this.MARCAServLabel.Size = new System.Drawing.Size(19, 13);
            this.MARCAServLabel.TabIndex = 208;
            this.MARCAServLabel.Text = "...";
            // 
            // LINEAServButton
            // 
            this.LINEAServButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LINEAServButton.BackgroundImage")));
            this.LINEAServButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LINEAServButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LINEAServButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LINEAServButton.Location = new System.Drawing.Point(353, 148);
            this.LINEAServButton.Name = "LINEAServButton";
            this.LINEAServButton.Size = new System.Drawing.Size(21, 23);
            this.LINEAServButton.TabIndex = 202;
            this.LINEAServButton.UseVisualStyleBackColor = true;
            // 
            // LINEAServLabel
            // 
            this.LINEAServLabel.AutoSize = true;
            this.LINEAServLabel.Location = new System.Drawing.Point(380, 153);
            this.LINEAServLabel.Name = "LINEAServLabel";
            this.LINEAServLabel.Size = new System.Drawing.Size(19, 13);
            this.LINEAServLabel.TabIndex = 204;
            this.LINEAServLabel.Text = "...";
            // 
            // PROVEEDOR1RecButton
            // 
            this.PROVEEDOR1RecButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PROVEEDOR1RecButton.BackgroundImage")));
            this.PROVEEDOR1RecButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PROVEEDOR1RecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROVEEDOR1RecButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEEDOR1RecButton.Location = new System.Drawing.Point(353, 110);
            this.PROVEEDOR1RecButton.Name = "PROVEEDOR1RecButton";
            this.PROVEEDOR1RecButton.Size = new System.Drawing.Size(21, 23);
            this.PROVEEDOR1RecButton.TabIndex = 198;
            this.PROVEEDOR1RecButton.UseVisualStyleBackColor = true;
            // 
            // PROVEEDOR1RecLabel
            // 
            this.PROVEEDOR1RecLabel.AutoSize = true;
            this.PROVEEDOR1RecLabel.Location = new System.Drawing.Point(380, 115);
            this.PROVEEDOR1RecLabel.Name = "PROVEEDOR1RecLabel";
            this.PROVEEDOR1RecLabel.Size = new System.Drawing.Size(19, 13);
            this.PROVEEDOR1RecLabel.TabIndex = 200;
            this.PROVEEDOR1RecLabel.Text = "...";
            // 
            // MARCARecButton
            // 
            this.MARCARecButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MARCARecButton.BackgroundImage")));
            this.MARCARecButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MARCARecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MARCARecButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.MARCARecButton.Location = new System.Drawing.Point(353, 72);
            this.MARCARecButton.Name = "MARCARecButton";
            this.MARCARecButton.Size = new System.Drawing.Size(21, 23);
            this.MARCARecButton.TabIndex = 194;
            this.MARCARecButton.UseVisualStyleBackColor = true;
            // 
            // MARCARecLabel
            // 
            this.MARCARecLabel.AutoSize = true;
            this.MARCARecLabel.Location = new System.Drawing.Point(380, 76);
            this.MARCARecLabel.Name = "MARCARecLabel";
            this.MARCARecLabel.Size = new System.Drawing.Size(19, 13);
            this.MARCARecLabel.TabIndex = 196;
            this.MARCARecLabel.Text = "...";
            // 
            // LINEARecButton
            // 
            this.LINEARecButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LINEARecButton.BackgroundImage")));
            this.LINEARecButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LINEARecButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LINEARecButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LINEARecButton.Location = new System.Drawing.Point(353, 32);
            this.LINEARecButton.Name = "LINEARecButton";
            this.LINEARecButton.Size = new System.Drawing.Size(21, 23);
            this.LINEARecButton.TabIndex = 190;
            this.LINEARecButton.UseVisualStyleBackColor = true;
            // 
            // LINEARecLabel
            // 
            this.LINEARecLabel.AutoSize = true;
            this.LINEARecLabel.Location = new System.Drawing.Point(380, 37);
            this.LINEARecLabel.Name = "LINEARecLabel";
            this.LINEARecLabel.Size = new System.Drawing.Size(19, 13);
            this.LINEARecLabel.TabIndex = 192;
            this.LINEARecLabel.Text = "...";
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(297, 471);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(145, 13);
            this.label188.TabIndex = 187;
            this.label188.Text = "Emida pago de servicios";
            // 
            // HABPAGOSERVEMIDACheckBox
            // 
            this.HABPAGOSERVEMIDACheckBox.AutoSize = true;
            this.HABPAGOSERVEMIDACheckBox.Location = new System.Drawing.Point(285, 471);
            this.HABPAGOSERVEMIDACheckBox.Name = "HABPAGOSERVEMIDACheckBox";
            this.HABPAGOSERVEMIDACheckBox.Size = new System.Drawing.Size(15, 14);
            this.HABPAGOSERVEMIDACheckBox.TabIndex = 188;
            this.HABPAGOSERVEMIDACheckBox.UseVisualStyleBackColor = true;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(131, 405);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(179, 13);
            this.label187.TabIndex = 186;
            this.label187.Text = "TimeOut PinDistSale Servicios";
            // 
            // TIMEOUTPINTDISTSALESERVTextBox
            // 
            this.TIMEOUTPINTDISTSALESERVTextBox.Location = new System.Drawing.Point(134, 424);
            this.TIMEOUTPINTDISTSALESERVTextBox.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.TIMEOUTPINTDISTSALESERVTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TIMEOUTPINTDISTSALESERVTextBox.Name = "TIMEOUTPINTDISTSALESERVTextBox";
            this.TIMEOUTPINTDISTSALESERVTextBox.Size = new System.Drawing.Size(108, 20);
            this.TIMEOUTPINTDISTSALESERVTextBox.TabIndex = 185;
            this.TIMEOUTPINTDISTSALESERVTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(256, 356);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(102, 13);
            this.label185.TabIndex = 184;
            this.label185.Text = "TimeOut LookUp";
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(129, 356);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(123, 13);
            this.label184.TabIndex = 183;
            this.label184.Text = "TimeOut PinDistSale";
            // 
            // nudTimeOutLookUp
            // 
            this.nudTimeOutLookUp.Location = new System.Drawing.Point(260, 375);
            this.nudTimeOutLookUp.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTimeOutLookUp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeOutLookUp.Name = "nudTimeOutLookUp";
            this.nudTimeOutLookUp.Size = new System.Drawing.Size(105, 20);
            this.nudTimeOutLookUp.TabIndex = 182;
            this.nudTimeOutLookUp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTimeOutPin
            // 
            this.nudTimeOutPin.Location = new System.Drawing.Point(132, 375);
            this.nudTimeOutPin.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudTimeOutPin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeOutPin.Name = "nudTimeOutPin";
            this.nudTimeOutPin.Size = new System.Drawing.Size(108, 20);
            this.nudTimeOutPin.TabIndex = 181;
            this.nudTimeOutPin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(148, 471);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(94, 13);
            this.label176.TabIndex = 179;
            this.label176.Text = "Emida recargas";
            // 
            // rdbtnEmidaServices
            // 
            this.rdbtnEmidaServices.AutoSize = true;
            this.rdbtnEmidaServices.Location = new System.Drawing.Point(133, 470);
            this.rdbtnEmidaServices.Name = "rdbtnEmidaServices";
            this.rdbtnEmidaServices.Size = new System.Drawing.Size(15, 14);
            this.rdbtnEmidaServices.TabIndex = 180;
            this.rdbtnEmidaServices.UseVisualStyleBackColor = true;
            // 
            // txtUtilidadPagoServicio
            // 
            this.txtUtilidadPagoServicio.AllowNegative = false;
            this.txtUtilidadPagoServicio.Format_Expression = null;
            this.txtUtilidadPagoServicio.Location = new System.Drawing.Point(269, 303);
            this.txtUtilidadPagoServicio.Name = "txtUtilidadPagoServicio";
            this.txtUtilidadPagoServicio.NumericPrecision = 18;
            this.txtUtilidadPagoServicio.NumericScaleOnFocus = 2;
            this.txtUtilidadPagoServicio.NumericScaleOnLostFocus = 2;
            this.txtUtilidadPagoServicio.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUtilidadPagoServicio.Size = new System.Drawing.Size(116, 20);
            this.txtUtilidadPagoServicio.TabIndex = 215;
            this.txtUtilidadPagoServicio.Tag = 34;
            this.txtUtilidadPagoServicio.Text = "0.00";
            this.txtUtilidadPagoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUtilidadPagoServicio.ValidationExpression = null;
            this.txtUtilidadPagoServicio.ZeroIsValid = true;
            this.txtUtilidadPagoServicio.TextChanged += new System.EventHandler(this.txtUtilidadPagoServicio_TextChanged);
            // 
            // txtPorcUtilidadRecargas
            // 
            this.txtPorcUtilidadRecargas.AllowNegative = false;
            this.txtPorcUtilidadRecargas.Format_Expression = null;
            this.txtPorcUtilidadRecargas.Location = new System.Drawing.Point(269, 264);
            this.txtPorcUtilidadRecargas.Name = "txtPorcUtilidadRecargas";
            this.txtPorcUtilidadRecargas.NumericPrecision = 5;
            this.txtPorcUtilidadRecargas.NumericScaleOnFocus = 2;
            this.txtPorcUtilidadRecargas.NumericScaleOnLostFocus = 2;
            this.txtPorcUtilidadRecargas.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorcUtilidadRecargas.Size = new System.Drawing.Size(116, 20);
            this.txtPorcUtilidadRecargas.TabIndex = 213;
            this.txtPorcUtilidadRecargas.Tag = 34;
            this.txtPorcUtilidadRecargas.Text = "0.00";
            this.txtPorcUtilidadRecargas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcUtilidadRecargas.ValidationExpression = null;
            this.txtPorcUtilidadRecargas.ZeroIsValid = true;
            this.txtPorcUtilidadRecargas.TextChanged += new System.EventHandler(this.txtPorcUtilidadRecargas_TextChanged);
            // 
            // PROVEEDOR1IDServTextBox
            // 
            this.PROVEEDOR1IDServTextBox.BotonLookUp = this.PROVEEDOR1ServButton;
            this.PROVEEDOR1IDServTextBox.Condicion = null;
            this.PROVEEDOR1IDServTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDOR1IDServTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDOR1IDServTextBox.DbValue = null;
            this.PROVEEDOR1IDServTextBox.Format_Expression = null;
            this.PROVEEDOR1IDServTextBox.IndiceCampoDescripcion = 2;
            this.PROVEEDOR1IDServTextBox.IndiceCampoSelector = 1;
            this.PROVEEDOR1IDServTextBox.IndiceCampoValue = 0;
            this.PROVEEDOR1IDServTextBox.LabelDescription = this.PROVEEDOR1ServLabel;
            this.PROVEEDOR1IDServTextBox.Location = new System.Drawing.Point(269, 228);
            this.PROVEEDOR1IDServTextBox.MostrarErrores = true;
            this.PROVEEDOR1IDServTextBox.Name = "PROVEEDOR1IDServTextBox";
            this.PROVEEDOR1IDServTextBox.NombreCampoSelector = "clave";
            this.PROVEEDOR1IDServTextBox.NombreCampoValue = "id";
            this.PROVEEDOR1IDServTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 40";
            this.PROVEEDOR1IDServTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 40 and  clave = @clave";
            this.PROVEEDOR1IDServTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 40 and  id = @id";
            this.PROVEEDOR1IDServTextBox.Size = new System.Drawing.Size(82, 20);
            this.PROVEEDOR1IDServTextBox.TabIndex = 209;
            this.PROVEEDOR1IDServTextBox.Tag = 34;
            this.PROVEEDOR1IDServTextBox.TextDescription = null;
            this.PROVEEDOR1IDServTextBox.Titulo = "Proveedores";
            this.PROVEEDOR1IDServTextBox.ValidarEntrada = true;
            this.PROVEEDOR1IDServTextBox.ValidationExpression = null;
            this.PROVEEDOR1IDServTextBox.TextChanged += new System.EventHandler(this.PROVEEDOR1IDServTextBox_TextChanged);
            // 
            // MARCAIDServTextBox
            // 
            this.MARCAIDServTextBox.BotonLookUp = this.MARCAServButton;
            this.MARCAIDServTextBox.Condicion = null;
            this.MARCAIDServTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MARCAIDServTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MARCAIDServTextBox.DbValue = null;
            this.MARCAIDServTextBox.Format_Expression = null;
            this.MARCAIDServTextBox.IndiceCampoDescripcion = 2;
            this.MARCAIDServTextBox.IndiceCampoSelector = 1;
            this.MARCAIDServTextBox.IndiceCampoValue = 0;
            this.MARCAIDServTextBox.LabelDescription = this.MARCAServLabel;
            this.MARCAIDServTextBox.Location = new System.Drawing.Point(269, 189);
            this.MARCAIDServTextBox.MostrarErrores = true;
            this.MARCAIDServTextBox.Name = "MARCAIDServTextBox";
            this.MARCAIDServTextBox.NombreCampoSelector = "clave";
            this.MARCAIDServTextBox.NombreCampoValue = "id";
            this.MARCAIDServTextBox.Query = "select id,clave,nombre from marca";
            this.MARCAIDServTextBox.QueryDeSeleccion = "select id,clave,nombre from marca where clave = @clave";
            this.MARCAIDServTextBox.QueryPorDBValue = "select id,clave,nombre from marca where id = @id";
            this.MARCAIDServTextBox.Size = new System.Drawing.Size(82, 20);
            this.MARCAIDServTextBox.TabIndex = 205;
            this.MARCAIDServTextBox.Tag = 34;
            this.MARCAIDServTextBox.TextDescription = null;
            this.MARCAIDServTextBox.Titulo = "Marcas";
            this.MARCAIDServTextBox.ValidarEntrada = true;
            this.MARCAIDServTextBox.ValidationExpression = null;
            this.MARCAIDServTextBox.TextChanged += new System.EventHandler(this.MARCAIDServTextBox_TextChanged);
            // 
            // LINEAIDServTextBox
            // 
            this.LINEAIDServTextBox.BotonLookUp = this.LINEAServButton;
            this.LINEAIDServTextBox.Condicion = null;
            this.LINEAIDServTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDServTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDServTextBox.DbValue = null;
            this.LINEAIDServTextBox.Format_Expression = null;
            this.LINEAIDServTextBox.IndiceCampoDescripcion = 2;
            this.LINEAIDServTextBox.IndiceCampoSelector = 1;
            this.LINEAIDServTextBox.IndiceCampoValue = 0;
            this.LINEAIDServTextBox.LabelDescription = this.LINEAServLabel;
            this.LINEAIDServTextBox.Location = new System.Drawing.Point(269, 150);
            this.LINEAIDServTextBox.MostrarErrores = true;
            this.LINEAIDServTextBox.Name = "LINEAIDServTextBox";
            this.LINEAIDServTextBox.NombreCampoSelector = "clave";
            this.LINEAIDServTextBox.NombreCampoValue = "id";
            this.LINEAIDServTextBox.Query = "select id,clave,nombre from linea";
            this.LINEAIDServTextBox.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.LINEAIDServTextBox.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.LINEAIDServTextBox.Size = new System.Drawing.Size(82, 20);
            this.LINEAIDServTextBox.TabIndex = 201;
            this.LINEAIDServTextBox.Tag = 34;
            this.LINEAIDServTextBox.TextDescription = null;
            this.LINEAIDServTextBox.Titulo = "Lineas";
            this.LINEAIDServTextBox.ValidarEntrada = true;
            this.LINEAIDServTextBox.ValidationExpression = null;
            this.LINEAIDServTextBox.TextChanged += new System.EventHandler(this.LINEAIDServTextBox_TextChanged);
            // 
            // PROVEEDOR1IDRecTextBox
            // 
            this.PROVEEDOR1IDRecTextBox.BotonLookUp = this.PROVEEDOR1RecButton;
            this.PROVEEDOR1IDRecTextBox.Condicion = null;
            this.PROVEEDOR1IDRecTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDOR1IDRecTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDOR1IDRecTextBox.DbValue = null;
            this.PROVEEDOR1IDRecTextBox.Format_Expression = null;
            this.PROVEEDOR1IDRecTextBox.IndiceCampoDescripcion = 2;
            this.PROVEEDOR1IDRecTextBox.IndiceCampoSelector = 1;
            this.PROVEEDOR1IDRecTextBox.IndiceCampoValue = 0;
            this.PROVEEDOR1IDRecTextBox.LabelDescription = this.PROVEEDOR1RecLabel;
            this.PROVEEDOR1IDRecTextBox.Location = new System.Drawing.Point(269, 112);
            this.PROVEEDOR1IDRecTextBox.MostrarErrores = true;
            this.PROVEEDOR1IDRecTextBox.Name = "PROVEEDOR1IDRecTextBox";
            this.PROVEEDOR1IDRecTextBox.NombreCampoSelector = "clave";
            this.PROVEEDOR1IDRecTextBox.NombreCampoValue = "id";
            this.PROVEEDOR1IDRecTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 40";
            this.PROVEEDOR1IDRecTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 40 and  clave = @clave";
            this.PROVEEDOR1IDRecTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 40 and  id = @id";
            this.PROVEEDOR1IDRecTextBox.Size = new System.Drawing.Size(82, 20);
            this.PROVEEDOR1IDRecTextBox.TabIndex = 197;
            this.PROVEEDOR1IDRecTextBox.Tag = 34;
            this.PROVEEDOR1IDRecTextBox.TextDescription = null;
            this.PROVEEDOR1IDRecTextBox.Titulo = "Proveedores";
            this.PROVEEDOR1IDRecTextBox.ValidarEntrada = true;
            this.PROVEEDOR1IDRecTextBox.ValidationExpression = null;
            this.PROVEEDOR1IDRecTextBox.TextChanged += new System.EventHandler(this.PROVEEDOR1IDRecTextBox_TextChanged);
            // 
            // MARCAIDRecTextBox
            // 
            this.MARCAIDRecTextBox.BotonLookUp = this.MARCARecButton;
            this.MARCAIDRecTextBox.Condicion = null;
            this.MARCAIDRecTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MARCAIDRecTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MARCAIDRecTextBox.DbValue = null;
            this.MARCAIDRecTextBox.Format_Expression = null;
            this.MARCAIDRecTextBox.IndiceCampoDescripcion = 2;
            this.MARCAIDRecTextBox.IndiceCampoSelector = 1;
            this.MARCAIDRecTextBox.IndiceCampoValue = 0;
            this.MARCAIDRecTextBox.LabelDescription = this.MARCARecLabel;
            this.MARCAIDRecTextBox.Location = new System.Drawing.Point(269, 73);
            this.MARCAIDRecTextBox.MostrarErrores = true;
            this.MARCAIDRecTextBox.Name = "MARCAIDRecTextBox";
            this.MARCAIDRecTextBox.NombreCampoSelector = "clave";
            this.MARCAIDRecTextBox.NombreCampoValue = "id";
            this.MARCAIDRecTextBox.Query = "select id,clave,nombre from marca";
            this.MARCAIDRecTextBox.QueryDeSeleccion = "select id,clave,nombre from marca where clave = @clave";
            this.MARCAIDRecTextBox.QueryPorDBValue = "select id,clave,nombre from marca where id = @id";
            this.MARCAIDRecTextBox.Size = new System.Drawing.Size(82, 20);
            this.MARCAIDRecTextBox.TabIndex = 193;
            this.MARCAIDRecTextBox.Tag = 34;
            this.MARCAIDRecTextBox.TextDescription = null;
            this.MARCAIDRecTextBox.Titulo = "Marcas";
            this.MARCAIDRecTextBox.ValidarEntrada = true;
            this.MARCAIDRecTextBox.ValidationExpression = null;
            this.MARCAIDRecTextBox.TextChanged += new System.EventHandler(this.MARCAIDRecTextBox_TextChanged);
            // 
            // LINEAIDRecTextBox
            // 
            this.LINEAIDRecTextBox.BotonLookUp = this.LINEARecButton;
            this.LINEAIDRecTextBox.Condicion = null;
            this.LINEAIDRecTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDRecTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDRecTextBox.DbValue = null;
            this.LINEAIDRecTextBox.Format_Expression = null;
            this.LINEAIDRecTextBox.IndiceCampoDescripcion = 2;
            this.LINEAIDRecTextBox.IndiceCampoSelector = 1;
            this.LINEAIDRecTextBox.IndiceCampoValue = 0;
            this.LINEAIDRecTextBox.LabelDescription = this.LINEARecLabel;
            this.LINEAIDRecTextBox.Location = new System.Drawing.Point(269, 34);
            this.LINEAIDRecTextBox.MostrarErrores = true;
            this.LINEAIDRecTextBox.Name = "LINEAIDRecTextBox";
            this.LINEAIDRecTextBox.NombreCampoSelector = "clave";
            this.LINEAIDRecTextBox.NombreCampoValue = "id";
            this.LINEAIDRecTextBox.Query = "select id,clave,nombre from linea";
            this.LINEAIDRecTextBox.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.LINEAIDRecTextBox.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.LINEAIDRecTextBox.Size = new System.Drawing.Size(82, 20);
            this.LINEAIDRecTextBox.TabIndex = 189;
            this.LINEAIDRecTextBox.Tag = 34;
            this.LINEAIDRecTextBox.TextDescription = null;
            this.LINEAIDRecTextBox.Titulo = "Lineas";
            this.LINEAIDRecTextBox.ValidarEntrada = true;
            this.LINEAIDRecTextBox.ValidationExpression = null;
            this.LINEAIDRecTextBox.TextChanged += new System.EventHandler(this.LINEAIDRecTextBox_TextChanged);
            // 
            // tabPage11
            // 
            this.tabPage11.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.tabPage11.Controls.Add(this.label215);
            this.tabPage11.Controls.Add(this.txtRutaBDAppInventario);
            this.tabPage11.Controls.Add(this.label216);
            this.tabPage11.Controls.Add(this.txtIPWsAppInventario);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(782, 556);
            this.tabPage11.TabIndex = 11;
            this.tabPage11.Text = "App Inventario";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(33, 90);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(151, 13);
            this.label215.TabIndex = 126;
            this.label215.Text = "RUTA BD APP Inventario";
            // 
            // txtRutaBDAppInventario
            // 
            this.txtRutaBDAppInventario.Location = new System.Drawing.Point(36, 106);
            this.txtRutaBDAppInventario.Name = "txtRutaBDAppInventario";
            this.txtRutaBDAppInventario.Size = new System.Drawing.Size(298, 20);
            this.txtRutaBDAppInventario.TabIndex = 127;
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(33, 36);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(108, 13);
            this.label216.TabIndex = 124;
            this.label216.Text = "IP APP Inventario";
            // 
            // txtIPWsAppInventario
            // 
            this.txtIPWsAppInventario.Location = new System.Drawing.Point(36, 52);
            this.txtIPWsAppInventario.Name = "txtIPWsAppInventario";
            this.txtIPWsAppInventario.Size = new System.Drawing.Size(298, 20);
            this.txtIPWsAppInventario.TabIndex = 125;
            // 
            // tabPagePPC
            // 
            this.tabPagePPC.BackColor = System.Drawing.Color.Transparent;
            this.tabPagePPC.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.tabPagePPC.Controls.Add(this.HABPPCTextBox);
            this.tabPagePPC.Controls.Add(this.label259);
            this.tabPagePPC.Location = new System.Drawing.Point(4, 22);
            this.tabPagePPC.Name = "tabPagePPC";
            this.tabPagePPC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePPC.Size = new System.Drawing.Size(782, 556);
            this.tabPagePPC.TabIndex = 12;
            this.tabPagePPC.Text = "PPC";
            // 
            // HABPPCTextBox
            // 
            this.HABPPCTextBox.AutoSize = true;
            this.HABPPCTextBox.Location = new System.Drawing.Point(315, 33);
            this.HABPPCTextBox.Name = "HABPPCTextBox";
            this.HABPPCTextBox.Size = new System.Drawing.Size(15, 14);
            this.HABPPCTextBox.TabIndex = 276;
            this.HABPPCTextBox.UseVisualStyleBackColor = true;
            // 
            // label259
            // 
            this.label259.AutoSize = true;
            this.label259.Location = new System.Drawing.Point(45, 33);
            this.label259.Name = "label259";
            this.label259.Size = new System.Drawing.Size(246, 13);
            this.label259.TabIndex = 275;
            this.label259.Text = "Habilitar Pago Por Proveedor Centralizado";
            // 
            // tabPageImportaciones
            // 
            this.tabPageImportaciones.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.tabPageImportaciones.Controls.Add(this.HABWSDBFTextBox);
            this.tabPageImportaciones.Controls.Add(this.label271);
            this.tabPageImportaciones.Controls.Add(this.label270);
            this.tabPageImportaciones.Controls.Add(this.WSDBFTextBox);
            this.tabPageImportaciones.Controls.Add(this.label269);
            this.tabPageImportaciones.Controls.Add(this.label268);
            this.tabPageImportaciones.Controls.Add(this.label267);
            this.tabPageImportaciones.Controls.Add(this.DIASMAXIMPFTPTextBox);
            this.tabPageImportaciones.Controls.Add(this.DIASMAXEXPFTPTextBox);
            this.tabPageImportaciones.Controls.Add(this.SEGUNDOSCICLOFTPTextBox);
            this.tabPageImportaciones.Location = new System.Drawing.Point(4, 22);
            this.tabPageImportaciones.Name = "tabPageImportaciones";
            this.tabPageImportaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImportaciones.Size = new System.Drawing.Size(782, 556);
            this.tabPageImportaciones.TabIndex = 13;
            this.tabPageImportaciones.Text = "Importaciones";
            this.tabPageImportaciones.UseVisualStyleBackColor = true;
            // 
            // HABWSDBFTextBox
            // 
            this.HABWSDBFTextBox.FormattingEnabled = true;
            this.HABWSDBFTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.HABWSDBFTextBox.Location = new System.Drawing.Point(36, 145);
            this.HABWSDBFTextBox.Name = "HABWSDBFTextBox";
            this.HABWSDBFTextBox.Size = new System.Drawing.Size(100, 21);
            this.HABWSDBFTextBox.TabIndex = 193;
            // 
            // label271
            // 
            this.label271.AutoSize = true;
            this.label271.Location = new System.Drawing.Point(18, 121);
            this.label271.Name = "label271";
            this.label271.Size = new System.Drawing.Size(183, 13);
            this.label271.TabIndex = 194;
            this.label271.Text = "Habilitar envio por webservice:";
            // 
            // label270
            // 
            this.label270.AutoSize = true;
            this.label270.Location = new System.Drawing.Point(511, 31);
            this.label270.Name = "label270";
            this.label270.Size = new System.Drawing.Size(182, 13);
            this.label270.TabIndex = 192;
            this.label270.Text = "Dias maximo registros importar:";
            // 
            // WSDBFTextBox
            // 
            this.WSDBFTextBox.Location = new System.Drawing.Point(290, 145);
            this.WSDBFTextBox.Name = "WSDBFTextBox";
            this.WSDBFTextBox.Size = new System.Drawing.Size(403, 20);
            this.WSDBFTextBox.TabIndex = 189;
            // 
            // label269
            // 
            this.label269.AutoSize = true;
            this.label269.Location = new System.Drawing.Point(287, 121);
            this.label269.Name = "label269";
            this.label269.Size = new System.Drawing.Size(78, 13);
            this.label269.TabIndex = 190;
            this.label269.Text = "Webservice:";
            // 
            // label268
            // 
            this.label268.AutoSize = true;
            this.label268.Location = new System.Drawing.Point(288, 31);
            this.label268.Name = "label268";
            this.label268.Size = new System.Drawing.Size(183, 13);
            this.label268.TabIndex = 188;
            this.label268.Text = "Dias maximo registros exportar:";
            // 
            // label267
            // 
            this.label267.AutoSize = true;
            this.label267.Location = new System.Drawing.Point(34, 31);
            this.label267.Name = "label267";
            this.label267.Size = new System.Drawing.Size(221, 13);
            this.label267.TabIndex = 186;
            this.label267.Text = "Numero de segundos de espera envio";
            // 
            // DIASMAXIMPFTPTextBox
            // 
            this.DIASMAXIMPFTPTextBox.AllowNegative = false;
            this.DIASMAXIMPFTPTextBox.Format_Expression = null;
            this.DIASMAXIMPFTPTextBox.Location = new System.Drawing.Point(513, 48);
            this.DIASMAXIMPFTPTextBox.Name = "DIASMAXIMPFTPTextBox";
            this.DIASMAXIMPFTPTextBox.NumericPrecision = 3;
            this.DIASMAXIMPFTPTextBox.NumericScaleOnFocus = 0;
            this.DIASMAXIMPFTPTextBox.NumericScaleOnLostFocus = 0;
            this.DIASMAXIMPFTPTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DIASMAXIMPFTPTextBox.Size = new System.Drawing.Size(86, 20);
            this.DIASMAXIMPFTPTextBox.TabIndex = 191;
            this.DIASMAXIMPFTPTextBox.Tag = 34;
            this.DIASMAXIMPFTPTextBox.Text = "0";
            this.DIASMAXIMPFTPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DIASMAXIMPFTPTextBox.ValidationExpression = null;
            this.DIASMAXIMPFTPTextBox.ZeroIsValid = true;
            // 
            // DIASMAXEXPFTPTextBox
            // 
            this.DIASMAXEXPFTPTextBox.AllowNegative = false;
            this.DIASMAXEXPFTPTextBox.Format_Expression = null;
            this.DIASMAXEXPFTPTextBox.Location = new System.Drawing.Point(290, 48);
            this.DIASMAXEXPFTPTextBox.Name = "DIASMAXEXPFTPTextBox";
            this.DIASMAXEXPFTPTextBox.NumericPrecision = 3;
            this.DIASMAXEXPFTPTextBox.NumericScaleOnFocus = 0;
            this.DIASMAXEXPFTPTextBox.NumericScaleOnLostFocus = 0;
            this.DIASMAXEXPFTPTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DIASMAXEXPFTPTextBox.Size = new System.Drawing.Size(86, 20);
            this.DIASMAXEXPFTPTextBox.TabIndex = 187;
            this.DIASMAXEXPFTPTextBox.Tag = 34;
            this.DIASMAXEXPFTPTextBox.Text = "0";
            this.DIASMAXEXPFTPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DIASMAXEXPFTPTextBox.ValidationExpression = null;
            this.DIASMAXEXPFTPTextBox.ZeroIsValid = true;
            // 
            // SEGUNDOSCICLOFTPTextBox
            // 
            this.SEGUNDOSCICLOFTPTextBox.AllowNegative = false;
            this.SEGUNDOSCICLOFTPTextBox.Format_Expression = null;
            this.SEGUNDOSCICLOFTPTextBox.Location = new System.Drawing.Point(36, 48);
            this.SEGUNDOSCICLOFTPTextBox.Name = "SEGUNDOSCICLOFTPTextBox";
            this.SEGUNDOSCICLOFTPTextBox.NumericPrecision = 3;
            this.SEGUNDOSCICLOFTPTextBox.NumericScaleOnFocus = 0;
            this.SEGUNDOSCICLOFTPTextBox.NumericScaleOnLostFocus = 0;
            this.SEGUNDOSCICLOFTPTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SEGUNDOSCICLOFTPTextBox.Size = new System.Drawing.Size(86, 20);
            this.SEGUNDOSCICLOFTPTextBox.TabIndex = 185;
            this.SEGUNDOSCICLOFTPTextBox.Tag = 34;
            this.SEGUNDOSCICLOFTPTextBox.Text = "0";
            this.SEGUNDOSCICLOFTPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SEGUNDOSCICLOFTPTextBox.ValidationExpression = null;
            this.SEGUNDOSCICLOFTPTextBox.ZeroIsValid = true;
            // 
            // TabPageComisionesXPrecio
            // 
            this.TabPageComisionesXPrecio.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.TabPageComisionesXPrecio.Controls.Add(this.label299);
            this.TabPageComisionesXPrecio.Controls.Add(this.label298);
            this.TabPageComisionesXPrecio.Controls.Add(this.label297);
            this.TabPageComisionesXPrecio.Controls.Add(this.label296);
            this.TabPageComisionesXPrecio.Controls.Add(this.label295);
            this.TabPageComisionesXPrecio.Controls.Add(this.label294);
            this.TabPageComisionesXPrecio.Controls.Add(this.COMISIONPRECIOOTROTextBox);
            this.TabPageComisionesXPrecio.Controls.Add(this.COMISIONPRECIO5TextBox);
            this.TabPageComisionesXPrecio.Controls.Add(this.COMISIONPRECIO4TextBox);
            this.TabPageComisionesXPrecio.Controls.Add(this.COMISIONPRECIO3TextBox);
            this.TabPageComisionesXPrecio.Controls.Add(this.COMISIONPRECIO2TextBox);
            this.TabPageComisionesXPrecio.Controls.Add(this.COMISIONPRECIO1TextBox);
            this.TabPageComisionesXPrecio.Location = new System.Drawing.Point(4, 22);
            this.TabPageComisionesXPrecio.Name = "TabPageComisionesXPrecio";
            this.TabPageComisionesXPrecio.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageComisionesXPrecio.Size = new System.Drawing.Size(782, 556);
            this.TabPageComisionesXPrecio.TabIndex = 14;
            this.TabPageComisionesXPrecio.Text = "Comisiones x Precio";
            this.TabPageComisionesXPrecio.UseVisualStyleBackColor = true;
            // 
            // label299
            // 
            this.label299.AutoSize = true;
            this.label299.Location = new System.Drawing.Point(201, 201);
            this.label299.Name = "label299";
            this.label299.Size = new System.Drawing.Size(89, 13);
            this.label299.TabIndex = 36;
            this.label299.Text = "Comision Otro:";
            // 
            // label298
            // 
            this.label298.AutoSize = true;
            this.label298.Location = new System.Drawing.Point(201, 168);
            this.label298.Name = "label298";
            this.label298.Size = new System.Drawing.Size(112, 13);
            this.label298.TabIndex = 34;
            this.label298.Text = "Comision Precio 5:";
            // 
            // label297
            // 
            this.label297.AutoSize = true;
            this.label297.Location = new System.Drawing.Point(201, 139);
            this.label297.Name = "label297";
            this.label297.Size = new System.Drawing.Size(112, 13);
            this.label297.TabIndex = 32;
            this.label297.Text = "Comision Precio 4:";
            // 
            // label296
            // 
            this.label296.AutoSize = true;
            this.label296.Location = new System.Drawing.Point(201, 111);
            this.label296.Name = "label296";
            this.label296.Size = new System.Drawing.Size(112, 13);
            this.label296.TabIndex = 30;
            this.label296.Text = "Comision Precio 3:";
            // 
            // label295
            // 
            this.label295.AutoSize = true;
            this.label295.Location = new System.Drawing.Point(201, 82);
            this.label295.Name = "label295";
            this.label295.Size = new System.Drawing.Size(112, 13);
            this.label295.TabIndex = 28;
            this.label295.Text = "Comision Precio 2:";
            // 
            // label294
            // 
            this.label294.AutoSize = true;
            this.label294.Location = new System.Drawing.Point(201, 52);
            this.label294.Name = "label294";
            this.label294.Size = new System.Drawing.Size(112, 13);
            this.label294.TabIndex = 26;
            this.label294.Text = "Comision Precio 1:";
            // 
            // COMISIONPRECIOOTROTextBox
            // 
            this.COMISIONPRECIOOTROTextBox.AllowNegative = false;
            this.COMISIONPRECIOOTROTextBox.Format_Expression = null;
            this.COMISIONPRECIOOTROTextBox.Location = new System.Drawing.Point(315, 198);
            this.COMISIONPRECIOOTROTextBox.Name = "COMISIONPRECIOOTROTextBox";
            this.COMISIONPRECIOOTROTextBox.NumericPrecision = 5;
            this.COMISIONPRECIOOTROTextBox.NumericScaleOnFocus = 2;
            this.COMISIONPRECIOOTROTextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPRECIOOTROTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPRECIOOTROTextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPRECIOOTROTextBox.TabIndex = 35;
            this.COMISIONPRECIOOTROTextBox.Tag = 34;
            this.COMISIONPRECIOOTROTextBox.Text = "0.00";
            this.COMISIONPRECIOOTROTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPRECIOOTROTextBox.ValidationExpression = null;
            this.COMISIONPRECIOOTROTextBox.ZeroIsValid = true;
            this.COMISIONPRECIOOTROTextBox.NumericValueChanged += new System.EventHandler(this.COMISIONPRECIOTextBox_NumericValueChanged);
            // 
            // COMISIONPRECIO5TextBox
            // 
            this.COMISIONPRECIO5TextBox.AllowNegative = false;
            this.COMISIONPRECIO5TextBox.Format_Expression = null;
            this.COMISIONPRECIO5TextBox.Location = new System.Drawing.Point(315, 165);
            this.COMISIONPRECIO5TextBox.Name = "COMISIONPRECIO5TextBox";
            this.COMISIONPRECIO5TextBox.NumericPrecision = 5;
            this.COMISIONPRECIO5TextBox.NumericScaleOnFocus = 2;
            this.COMISIONPRECIO5TextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPRECIO5TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPRECIO5TextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPRECIO5TextBox.TabIndex = 33;
            this.COMISIONPRECIO5TextBox.Tag = 34;
            this.COMISIONPRECIO5TextBox.Text = "0.00";
            this.COMISIONPRECIO5TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPRECIO5TextBox.ValidationExpression = null;
            this.COMISIONPRECIO5TextBox.ZeroIsValid = true;
            this.COMISIONPRECIO5TextBox.NumericValueChanged += new System.EventHandler(this.COMISIONPRECIOTextBox_NumericValueChanged);
            // 
            // COMISIONPRECIO4TextBox
            // 
            this.COMISIONPRECIO4TextBox.AllowNegative = false;
            this.COMISIONPRECIO4TextBox.Format_Expression = null;
            this.COMISIONPRECIO4TextBox.Location = new System.Drawing.Point(315, 136);
            this.COMISIONPRECIO4TextBox.Name = "COMISIONPRECIO4TextBox";
            this.COMISIONPRECIO4TextBox.NumericPrecision = 5;
            this.COMISIONPRECIO4TextBox.NumericScaleOnFocus = 2;
            this.COMISIONPRECIO4TextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPRECIO4TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPRECIO4TextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPRECIO4TextBox.TabIndex = 31;
            this.COMISIONPRECIO4TextBox.Tag = 34;
            this.COMISIONPRECIO4TextBox.Text = "0.00";
            this.COMISIONPRECIO4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPRECIO4TextBox.ValidationExpression = null;
            this.COMISIONPRECIO4TextBox.ZeroIsValid = true;
            this.COMISIONPRECIO4TextBox.NumericValueChanged += new System.EventHandler(this.COMISIONPRECIOTextBox_NumericValueChanged);
            // 
            // COMISIONPRECIO3TextBox
            // 
            this.COMISIONPRECIO3TextBox.AllowNegative = false;
            this.COMISIONPRECIO3TextBox.Format_Expression = null;
            this.COMISIONPRECIO3TextBox.Location = new System.Drawing.Point(315, 108);
            this.COMISIONPRECIO3TextBox.Name = "COMISIONPRECIO3TextBox";
            this.COMISIONPRECIO3TextBox.NumericPrecision = 5;
            this.COMISIONPRECIO3TextBox.NumericScaleOnFocus = 2;
            this.COMISIONPRECIO3TextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPRECIO3TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPRECIO3TextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPRECIO3TextBox.TabIndex = 29;
            this.COMISIONPRECIO3TextBox.Tag = 34;
            this.COMISIONPRECIO3TextBox.Text = "0.00";
            this.COMISIONPRECIO3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPRECIO3TextBox.ValidationExpression = null;
            this.COMISIONPRECIO3TextBox.ZeroIsValid = true;
            this.COMISIONPRECIO3TextBox.NumericValueChanged += new System.EventHandler(this.COMISIONPRECIOTextBox_NumericValueChanged);
            // 
            // COMISIONPRECIO2TextBox
            // 
            this.COMISIONPRECIO2TextBox.AllowNegative = false;
            this.COMISIONPRECIO2TextBox.Format_Expression = null;
            this.COMISIONPRECIO2TextBox.Location = new System.Drawing.Point(315, 79);
            this.COMISIONPRECIO2TextBox.Name = "COMISIONPRECIO2TextBox";
            this.COMISIONPRECIO2TextBox.NumericPrecision = 5;
            this.COMISIONPRECIO2TextBox.NumericScaleOnFocus = 2;
            this.COMISIONPRECIO2TextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPRECIO2TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPRECIO2TextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPRECIO2TextBox.TabIndex = 27;
            this.COMISIONPRECIO2TextBox.Tag = 34;
            this.COMISIONPRECIO2TextBox.Text = "0.00";
            this.COMISIONPRECIO2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPRECIO2TextBox.ValidationExpression = null;
            this.COMISIONPRECIO2TextBox.ZeroIsValid = true;
            this.COMISIONPRECIO2TextBox.NumericValueChanged += new System.EventHandler(this.COMISIONPRECIOTextBox_NumericValueChanged);
            // 
            // COMISIONPRECIO1TextBox
            // 
            this.COMISIONPRECIO1TextBox.AllowNegative = false;
            this.COMISIONPRECIO1TextBox.Format_Expression = null;
            this.COMISIONPRECIO1TextBox.Location = new System.Drawing.Point(315, 49);
            this.COMISIONPRECIO1TextBox.Name = "COMISIONPRECIO1TextBox";
            this.COMISIONPRECIO1TextBox.NumericPrecision = 5;
            this.COMISIONPRECIO1TextBox.NumericScaleOnFocus = 2;
            this.COMISIONPRECIO1TextBox.NumericScaleOnLostFocus = 2;
            this.COMISIONPRECIO1TextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.COMISIONPRECIO1TextBox.Size = new System.Drawing.Size(116, 20);
            this.COMISIONPRECIO1TextBox.TabIndex = 25;
            this.COMISIONPRECIO1TextBox.Tag = 34;
            this.COMISIONPRECIO1TextBox.Text = "0.00";
            this.COMISIONPRECIO1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COMISIONPRECIO1TextBox.ValidationExpression = null;
            this.COMISIONPRECIO1TextBox.ZeroIsValid = true;
            this.COMISIONPRECIO1TextBox.NumericValueChanged += new System.EventHandler(this.COMISIONPRECIOTextBox_NumericValueChanged);
            // 
            // TBComanda
            // 
            this.TBComanda.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.TBComanda.Controls.Add(this.label304);
            this.TBComanda.Controls.Add(this.RECIBOPREVIEWCOMANDATextBox);
            this.TBComanda.Controls.Add(this.label305);
            this.TBComanda.Controls.Add(this.label303);
            this.TBComanda.Controls.Add(this.IMPRESORACOMANDATextBox);
            this.TBComanda.Controls.Add(this.NUMTICKETSCOMANDATextBox);
            this.TBComanda.Location = new System.Drawing.Point(4, 22);
            this.TBComanda.Name = "TBComanda";
            this.TBComanda.Padding = new System.Windows.Forms.Padding(3);
            this.TBComanda.Size = new System.Drawing.Size(782, 556);
            this.TBComanda.TabIndex = 15;
            this.TBComanda.Text = "Comanda";
            this.TBComanda.UseVisualStyleBackColor = true;
            // 
            // label304
            // 
            this.label304.AutoSize = true;
            this.label304.Location = new System.Drawing.Point(334, 50);
            this.label304.Name = "label304";
            this.label304.Size = new System.Drawing.Size(133, 13);
            this.label304.TabIndex = 190;
            this.label304.Text = "Vista previa comanda:";
            // 
            // RECIBOPREVIEWCOMANDATextBox
            // 
            this.RECIBOPREVIEWCOMANDATextBox.FormattingEnabled = true;
            this.RECIBOPREVIEWCOMANDATextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.RECIBOPREVIEWCOMANDATextBox.Location = new System.Drawing.Point(337, 66);
            this.RECIBOPREVIEWCOMANDATextBox.Name = "RECIBOPREVIEWCOMANDATextBox";
            this.RECIBOPREVIEWCOMANDATextBox.Size = new System.Drawing.Size(79, 21);
            this.RECIBOPREVIEWCOMANDATextBox.TabIndex = 189;
            // 
            // label305
            // 
            this.label305.AutoSize = true;
            this.label305.Location = new System.Drawing.Point(568, 50);
            this.label305.Name = "label305";
            this.label305.Size = new System.Drawing.Size(115, 13);
            this.label305.TabIndex = 188;
            this.label305.Text = "# copias comanda:";
            // 
            // label303
            // 
            this.label303.AutoSize = true;
            this.label303.Location = new System.Drawing.Point(97, 50);
            this.label303.Name = "label303";
            this.label303.Size = new System.Drawing.Size(164, 13);
            this.label303.TabIndex = 180;
            this.label303.Text = "Impresora default comanda:";
            // 
            // IMPRESORACOMANDATextBox
            // 
            this.IMPRESORACOMANDATextBox.Location = new System.Drawing.Point(100, 66);
            this.IMPRESORACOMANDATextBox.Name = "IMPRESORACOMANDATextBox";
            this.IMPRESORACOMANDATextBox.Size = new System.Drawing.Size(157, 20);
            this.IMPRESORACOMANDATextBox.TabIndex = 179;
            // 
            // NUMTICKETSCOMANDATextBox
            // 
            this.NUMTICKETSCOMANDATextBox.AllowNegative = false;
            this.NUMTICKETSCOMANDATextBox.Format_Expression = null;
            this.NUMTICKETSCOMANDATextBox.Location = new System.Drawing.Point(570, 67);
            this.NUMTICKETSCOMANDATextBox.Name = "NUMTICKETSCOMANDATextBox";
            this.NUMTICKETSCOMANDATextBox.NumericPrecision = 3;
            this.NUMTICKETSCOMANDATextBox.NumericScaleOnFocus = 0;
            this.NUMTICKETSCOMANDATextBox.NumericScaleOnLostFocus = 0;
            this.NUMTICKETSCOMANDATextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NUMTICKETSCOMANDATextBox.Size = new System.Drawing.Size(86, 20);
            this.NUMTICKETSCOMANDATextBox.TabIndex = 187;
            this.NUMTICKETSCOMANDATextBox.Tag = 34;
            this.NUMTICKETSCOMANDATextBox.Text = "0";
            this.NUMTICKETSCOMANDATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUMTICKETSCOMANDATextBox.ValidationExpression = null;
            this.NUMTICKETSCOMANDATextBox.ZeroIsValid = true;
            // 
            // tabPage12
            // 
            this.tabPage12.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.tabPage12.Controls.Add(this.groupBox3);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(782, 556);
            this.tabPage12.TabIndex = 16;
            this.tabPage12.Text = "Verificador";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO12TextBox);
            this.groupBox3.Controls.Add(this.label315);
            this.groupBox3.Controls.Add(this.L2CAMPO12CheckBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO6TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO11TextBox);
            this.groupBox3.Controls.Add(this.label309);
            this.groupBox3.Controls.Add(this.L2CAMPO11CheckBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO10TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO9TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO8TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO7TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO5TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO3TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO4TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO2TextBox);
            this.groupBox3.Controls.Add(this.L2LBL_CAMPO1TextBox);
            this.groupBox3.Controls.Add(this.label310);
            this.groupBox3.Controls.Add(this.L2CAMPO10CheckBox);
            this.groupBox3.Controls.Add(this.label311);
            this.groupBox3.Controls.Add(this.L2CAMPO9CheckBox);
            this.groupBox3.Controls.Add(this.label312);
            this.groupBox3.Controls.Add(this.L2CAMPO8CheckBox);
            this.groupBox3.Controls.Add(this.label313);
            this.groupBox3.Controls.Add(this.L2CAMPO7CheckBox);
            this.groupBox3.Controls.Add(this.L2CAMPO5CheckBox);
            this.groupBox3.Controls.Add(this.L2CAMPO4CheckBox);
            this.groupBox3.Controls.Add(this.L2CAMPO3CheckBox);
            this.groupBox3.Controls.Add(this.label314);
            this.groupBox3.Controls.Add(this.L2CAMPO2CheckBox);
            this.groupBox3.Controls.Add(this.L2CAMPO6CheckBox);
            this.groupBox3.Controls.Add(this.L2CAMPO1CheckBox);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(34, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 224);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Precios a mostrar";
            // 
            // L2LBL_CAMPO12TextBox
            // 
            this.L2LBL_CAMPO12TextBox.Location = new System.Drawing.Point(132, 190);
            this.L2LBL_CAMPO12TextBox.Name = "L2LBL_CAMPO12TextBox";
            this.L2LBL_CAMPO12TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO12TextBox.TabIndex = 106;
            // 
            // label315
            // 
            this.label315.AutoSize = true;
            this.label315.Location = new System.Drawing.Point(148, 173);
            this.label315.Name = "label315";
            this.label315.Size = new System.Drawing.Size(95, 13);
            this.label315.TabIndex = 105;
            this.label315.Text = "Precio sugerido";
            // 
            // L2CAMPO12CheckBox
            // 
            this.L2CAMPO12CheckBox.AutoSize = true;
            this.L2CAMPO12CheckBox.Location = new System.Drawing.Point(133, 173);
            this.L2CAMPO12CheckBox.Name = "L2CAMPO12CheckBox";
            this.L2CAMPO12CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO12CheckBox.TabIndex = 104;
            this.L2CAMPO12CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2LBL_CAMPO6TextBox
            // 
            this.L2LBL_CAMPO6TextBox.Location = new System.Drawing.Point(11, 134);
            this.L2LBL_CAMPO6TextBox.Name = "L2LBL_CAMPO6TextBox";
            this.L2LBL_CAMPO6TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO6TextBox.TabIndex = 103;
            // 
            // L2LBL_CAMPO11TextBox
            // 
            this.L2LBL_CAMPO11TextBox.Location = new System.Drawing.Point(13, 190);
            this.L2LBL_CAMPO11TextBox.Name = "L2LBL_CAMPO11TextBox";
            this.L2LBL_CAMPO11TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO11TextBox.TabIndex = 102;
            // 
            // label309
            // 
            this.label309.AutoSize = true;
            this.label309.Location = new System.Drawing.Point(29, 173);
            this.label309.Name = "label309";
            this.label309.Size = new System.Drawing.Size(71, 13);
            this.label309.TabIndex = 101;
            this.label309.Text = "Precio caja";
            // 
            // L2CAMPO11CheckBox
            // 
            this.L2CAMPO11CheckBox.AutoSize = true;
            this.L2CAMPO11CheckBox.Location = new System.Drawing.Point(14, 173);
            this.L2CAMPO11CheckBox.Name = "L2CAMPO11CheckBox";
            this.L2CAMPO11CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO11CheckBox.TabIndex = 100;
            this.L2CAMPO11CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2LBL_CAMPO10TextBox
            // 
            this.L2LBL_CAMPO10TextBox.Location = new System.Drawing.Point(510, 134);
            this.L2LBL_CAMPO10TextBox.Name = "L2LBL_CAMPO10TextBox";
            this.L2LBL_CAMPO10TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO10TextBox.TabIndex = 99;
            // 
            // L2LBL_CAMPO9TextBox
            // 
            this.L2LBL_CAMPO9TextBox.Location = new System.Drawing.Point(388, 133);
            this.L2LBL_CAMPO9TextBox.Name = "L2LBL_CAMPO9TextBox";
            this.L2LBL_CAMPO9TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO9TextBox.TabIndex = 98;
            // 
            // L2LBL_CAMPO8TextBox
            // 
            this.L2LBL_CAMPO8TextBox.Location = new System.Drawing.Point(260, 133);
            this.L2LBL_CAMPO8TextBox.Name = "L2LBL_CAMPO8TextBox";
            this.L2LBL_CAMPO8TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO8TextBox.TabIndex = 97;
            // 
            // L2LBL_CAMPO7TextBox
            // 
            this.L2LBL_CAMPO7TextBox.Location = new System.Drawing.Point(133, 133);
            this.L2LBL_CAMPO7TextBox.Name = "L2LBL_CAMPO7TextBox";
            this.L2LBL_CAMPO7TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO7TextBox.TabIndex = 96;
            // 
            // L2LBL_CAMPO5TextBox
            // 
            this.L2LBL_CAMPO5TextBox.Location = new System.Drawing.Point(510, 83);
            this.L2LBL_CAMPO5TextBox.Name = "L2LBL_CAMPO5TextBox";
            this.L2LBL_CAMPO5TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO5TextBox.TabIndex = 95;
            // 
            // L2LBL_CAMPO3TextBox
            // 
            this.L2LBL_CAMPO3TextBox.Location = new System.Drawing.Point(261, 83);
            this.L2LBL_CAMPO3TextBox.Name = "L2LBL_CAMPO3TextBox";
            this.L2LBL_CAMPO3TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO3TextBox.TabIndex = 94;
            // 
            // L2LBL_CAMPO4TextBox
            // 
            this.L2LBL_CAMPO4TextBox.Location = new System.Drawing.Point(387, 83);
            this.L2LBL_CAMPO4TextBox.Name = "L2LBL_CAMPO4TextBox";
            this.L2LBL_CAMPO4TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO4TextBox.TabIndex = 93;
            // 
            // L2LBL_CAMPO2TextBox
            // 
            this.L2LBL_CAMPO2TextBox.Location = new System.Drawing.Point(132, 85);
            this.L2LBL_CAMPO2TextBox.Name = "L2LBL_CAMPO2TextBox";
            this.L2LBL_CAMPO2TextBox.Size = new System.Drawing.Size(96, 20);
            this.L2LBL_CAMPO2TextBox.TabIndex = 92;
            // 
            // L2LBL_CAMPO1TextBox
            // 
            this.L2LBL_CAMPO1TextBox.Location = new System.Drawing.Point(11, 85);
            this.L2LBL_CAMPO1TextBox.Name = "L2LBL_CAMPO1TextBox";
            this.L2LBL_CAMPO1TextBox.Size = new System.Drawing.Size(97, 20);
            this.L2LBL_CAMPO1TextBox.TabIndex = 91;
            // 
            // label310
            // 
            this.label310.AutoSize = true;
            this.label310.Location = new System.Drawing.Point(526, 117);
            this.label310.Name = "label310";
            this.label310.Size = new System.Drawing.Size(87, 13);
            this.label310.TabIndex = 90;
            this.label310.Text = "Precio5 + IMP";
            // 
            // L2CAMPO10CheckBox
            // 
            this.L2CAMPO10CheckBox.AutoSize = true;
            this.L2CAMPO10CheckBox.Location = new System.Drawing.Point(511, 117);
            this.L2CAMPO10CheckBox.Name = "L2CAMPO10CheckBox";
            this.L2CAMPO10CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO10CheckBox.TabIndex = 89;
            this.L2CAMPO10CheckBox.UseVisualStyleBackColor = true;
            // 
            // label311
            // 
            this.label311.AutoSize = true;
            this.label311.Location = new System.Drawing.Point(405, 118);
            this.label311.Name = "label311";
            this.label311.Size = new System.Drawing.Size(87, 13);
            this.label311.TabIndex = 88;
            this.label311.Text = "Precio4 + IMP";
            // 
            // L2CAMPO9CheckBox
            // 
            this.L2CAMPO9CheckBox.AutoSize = true;
            this.L2CAMPO9CheckBox.Location = new System.Drawing.Point(390, 118);
            this.L2CAMPO9CheckBox.Name = "L2CAMPO9CheckBox";
            this.L2CAMPO9CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO9CheckBox.TabIndex = 87;
            this.L2CAMPO9CheckBox.UseVisualStyleBackColor = true;
            // 
            // label312
            // 
            this.label312.AutoSize = true;
            this.label312.Location = new System.Drawing.Point(276, 118);
            this.label312.Name = "label312";
            this.label312.Size = new System.Drawing.Size(87, 13);
            this.label312.TabIndex = 86;
            this.label312.Text = "Precio3 + IMP";
            // 
            // L2CAMPO8CheckBox
            // 
            this.L2CAMPO8CheckBox.AutoSize = true;
            this.L2CAMPO8CheckBox.Location = new System.Drawing.Point(261, 118);
            this.L2CAMPO8CheckBox.Name = "L2CAMPO8CheckBox";
            this.L2CAMPO8CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO8CheckBox.TabIndex = 85;
            this.L2CAMPO8CheckBox.UseVisualStyleBackColor = true;
            // 
            // label313
            // 
            this.label313.AutoSize = true;
            this.label313.Location = new System.Drawing.Point(148, 117);
            this.label313.Name = "label313";
            this.label313.Size = new System.Drawing.Size(87, 13);
            this.label313.TabIndex = 84;
            this.label313.Text = "Precio2 + IMP";
            // 
            // L2CAMPO7CheckBox
            // 
            this.L2CAMPO7CheckBox.AutoSize = true;
            this.L2CAMPO7CheckBox.Location = new System.Drawing.Point(134, 117);
            this.L2CAMPO7CheckBox.Name = "L2CAMPO7CheckBox";
            this.L2CAMPO7CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO7CheckBox.TabIndex = 83;
            this.L2CAMPO7CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2CAMPO5CheckBox
            // 
            this.L2CAMPO5CheckBox.AutoSize = true;
            this.L2CAMPO5CheckBox.Location = new System.Drawing.Point(511, 67);
            this.L2CAMPO5CheckBox.Name = "L2CAMPO5CheckBox";
            this.L2CAMPO5CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L2CAMPO5CheckBox.TabIndex = 82;
            this.L2CAMPO5CheckBox.Text = "Precio 5";
            this.L2CAMPO5CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2CAMPO4CheckBox
            // 
            this.L2CAMPO4CheckBox.AutoSize = true;
            this.L2CAMPO4CheckBox.Location = new System.Drawing.Point(388, 67);
            this.L2CAMPO4CheckBox.Name = "L2CAMPO4CheckBox";
            this.L2CAMPO4CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L2CAMPO4CheckBox.TabIndex = 81;
            this.L2CAMPO4CheckBox.Text = "Precio 4";
            this.L2CAMPO4CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2CAMPO3CheckBox
            // 
            this.L2CAMPO3CheckBox.AutoSize = true;
            this.L2CAMPO3CheckBox.Location = new System.Drawing.Point(261, 67);
            this.L2CAMPO3CheckBox.Name = "L2CAMPO3CheckBox";
            this.L2CAMPO3CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L2CAMPO3CheckBox.TabIndex = 80;
            this.L2CAMPO3CheckBox.Text = "Precio 3";
            this.L2CAMPO3CheckBox.UseVisualStyleBackColor = true;
            // 
            // label314
            // 
            this.label314.AutoSize = true;
            this.label314.Location = new System.Drawing.Point(27, 116);
            this.label314.Name = "label314";
            this.label314.Size = new System.Drawing.Size(87, 13);
            this.label314.TabIndex = 79;
            this.label314.Text = "Precio1 + IMP";
            // 
            // L2CAMPO2CheckBox
            // 
            this.L2CAMPO2CheckBox.AutoSize = true;
            this.L2CAMPO2CheckBox.Location = new System.Drawing.Point(133, 67);
            this.L2CAMPO2CheckBox.Name = "L2CAMPO2CheckBox";
            this.L2CAMPO2CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L2CAMPO2CheckBox.TabIndex = 78;
            this.L2CAMPO2CheckBox.Text = "Precio 2";
            this.L2CAMPO2CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2CAMPO6CheckBox
            // 
            this.L2CAMPO6CheckBox.AutoSize = true;
            this.L2CAMPO6CheckBox.Location = new System.Drawing.Point(12, 116);
            this.L2CAMPO6CheckBox.Name = "L2CAMPO6CheckBox";
            this.L2CAMPO6CheckBox.Size = new System.Drawing.Size(15, 14);
            this.L2CAMPO6CheckBox.TabIndex = 77;
            this.L2CAMPO6CheckBox.UseVisualStyleBackColor = true;
            // 
            // L2CAMPO1CheckBox
            // 
            this.L2CAMPO1CheckBox.AutoSize = true;
            this.L2CAMPO1CheckBox.Location = new System.Drawing.Point(11, 67);
            this.L2CAMPO1CheckBox.Name = "L2CAMPO1CheckBox";
            this.L2CAMPO1CheckBox.Size = new System.Drawing.Size(73, 17);
            this.L2CAMPO1CheckBox.TabIndex = 76;
            this.L2CAMPO1CheckBox.Text = "Precio 1";
            this.L2CAMPO1CheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            this.tabPage13.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.tabPage13.Controls.Add(this.panel2);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(782, 556);
            this.tabPage13.TabIndex = 17;
            this.tabPage13.Text = "Verifone";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.VERIFONEACTIVOCheckBox);
            this.panel2.Controls.Add(this.label322);
            this.panel2.Controls.Add(this.VERIFONE_OPERATORLOCALETextBox);
            this.panel2.Controls.Add(this.label325);
            this.panel2.Controls.Add(this.VERIFONE_MERCHANTIDTextBox);
            this.panel2.Controls.Add(this.label326);
            this.panel2.Controls.Add(this.VERIFONE_SHIFTNUMBERTextBox);
            this.panel2.Controls.Add(this.label327);
            this.panel2.Controls.Add(this.VERIFONE_CONTRASENATextBox);
            this.panel2.Controls.Add(this.lblVerifoneContrasena);
            this.panel2.Controls.Add(this.VERIFONE_USERIDTextBox);
            this.panel2.Controls.Add(this.label328);
            this.panel2.Controls.Add(this.label329);
            this.panel2.Location = new System.Drawing.Point(141, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 293);
            this.panel2.TabIndex = 176;
            // 
            // VERIFONEACTIVOCheckBox
            // 
            this.VERIFONEACTIVOCheckBox.AutoSize = true;
            this.VERIFONEACTIVOCheckBox.Location = new System.Drawing.Point(163, 35);
            this.VERIFONEACTIVOCheckBox.Name = "VERIFONEACTIVOCheckBox";
            this.VERIFONEACTIVOCheckBox.Size = new System.Drawing.Size(15, 14);
            this.VERIFONEACTIVOCheckBox.TabIndex = 183;
            this.VERIFONEACTIVOCheckBox.UseVisualStyleBackColor = true;
            this.VERIFONEACTIVOCheckBox.CheckedChanged += new System.EventHandler(this.VERIFONEACTIVOCheckBox_CheckedChanged);
            // 
            // label322
            // 
            this.label322.AutoSize = true;
            this.label322.ForeColor = System.Drawing.Color.White;
            this.label322.Location = new System.Drawing.Point(19, 35);
            this.label322.Name = "label322";
            this.label322.Size = new System.Drawing.Size(47, 13);
            this.label322.TabIndex = 182;
            this.label322.Text = "Activo:";
            // 
            // VERIFONE_OPERATORLOCALETextBox
            // 
            this.VERIFONE_OPERATORLOCALETextBox.Location = new System.Drawing.Point(164, 190);
            this.VERIFONE_OPERATORLOCALETextBox.MaxLength = 64;
            this.VERIFONE_OPERATORLOCALETextBox.Name = "VERIFONE_OPERATORLOCALETextBox";
            this.VERIFONE_OPERATORLOCALETextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_OPERATORLOCALETextBox.TabIndex = 177;
            this.VERIFONE_OPERATORLOCALETextBox.TextChanged += new System.EventHandler(this.VERIFONE_OPERATORLOCALETextBox_TextChanged);
            // 
            // label325
            // 
            this.label325.AutoSize = true;
            this.label325.ForeColor = System.Drawing.Color.White;
            this.label325.Location = new System.Drawing.Point(20, 193);
            this.label325.Name = "label325";
            this.label325.Size = new System.Drawing.Size(94, 13);
            this.label325.TabIndex = 176;
            this.label325.Text = "Operador local:";
            // 
            // VERIFONE_MERCHANTIDTextBox
            // 
            this.VERIFONE_MERCHANTIDTextBox.Location = new System.Drawing.Point(164, 160);
            this.VERIFONE_MERCHANTIDTextBox.MaxLength = 64;
            this.VERIFONE_MERCHANTIDTextBox.Name = "VERIFONE_MERCHANTIDTextBox";
            this.VERIFONE_MERCHANTIDTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_MERCHANTIDTextBox.TabIndex = 175;
            this.VERIFONE_MERCHANTIDTextBox.TextChanged += new System.EventHandler(this.VERIFONE_MERCHANTIDTextBox_TextChanged);
            // 
            // label326
            // 
            this.label326.AutoSize = true;
            this.label326.ForeColor = System.Drawing.Color.White;
            this.label326.Location = new System.Drawing.Point(20, 163);
            this.label326.Name = "label326";
            this.label326.Size = new System.Drawing.Size(79, 13);
            this.label326.TabIndex = 174;
            this.label326.Text = "Merchant Id:";
            // 
            // VERIFONE_SHIFTNUMBERTextBox
            // 
            this.VERIFONE_SHIFTNUMBERTextBox.Location = new System.Drawing.Point(164, 128);
            this.VERIFONE_SHIFTNUMBERTextBox.MaxLength = 64;
            this.VERIFONE_SHIFTNUMBERTextBox.Name = "VERIFONE_SHIFTNUMBERTextBox";
            this.VERIFONE_SHIFTNUMBERTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_SHIFTNUMBERTextBox.TabIndex = 173;
            this.VERIFONE_SHIFTNUMBERTextBox.TextChanged += new System.EventHandler(this.VERIFONE_SHIFTNUMBERTextBox_TextChanged);
            // 
            // label327
            // 
            this.label327.AutoSize = true;
            this.label327.ForeColor = System.Drawing.Color.White;
            this.label327.Location = new System.Drawing.Point(20, 131);
            this.label327.Name = "label327";
            this.label327.Size = new System.Drawing.Size(84, 13);
            this.label327.TabIndex = 172;
            this.label327.Text = "Shift Number:";
            // 
            // VERIFONE_CONTRASENATextBox
            // 
            this.VERIFONE_CONTRASENATextBox.Location = new System.Drawing.Point(164, 95);
            this.VERIFONE_CONTRASENATextBox.MaxLength = 64;
            this.VERIFONE_CONTRASENATextBox.Name = "VERIFONE_CONTRASENATextBox";
            this.VERIFONE_CONTRASENATextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_CONTRASENATextBox.TabIndex = 171;
            this.VERIFONE_CONTRASENATextBox.TextChanged += new System.EventHandler(this.VERIFONE_CONTRASENATextBox_TextChanged);
            // 
            // lblVerifoneContrasena
            // 
            this.lblVerifoneContrasena.AutoSize = true;
            this.lblVerifoneContrasena.ForeColor = System.Drawing.Color.White;
            this.lblVerifoneContrasena.Location = new System.Drawing.Point(20, 98);
            this.lblVerifoneContrasena.Name = "lblVerifoneContrasena";
            this.lblVerifoneContrasena.Size = new System.Drawing.Size(75, 13);
            this.lblVerifoneContrasena.TabIndex = 170;
            this.lblVerifoneContrasena.Text = "Contraseña:";
            // 
            // VERIFONE_USERIDTextBox
            // 
            this.VERIFONE_USERIDTextBox.Location = new System.Drawing.Point(164, 65);
            this.VERIFONE_USERIDTextBox.MaxLength = 64;
            this.VERIFONE_USERIDTextBox.Name = "VERIFONE_USERIDTextBox";
            this.VERIFONE_USERIDTextBox.Size = new System.Drawing.Size(198, 20);
            this.VERIFONE_USERIDTextBox.TabIndex = 169;
            this.VERIFONE_USERIDTextBox.TextChanged += new System.EventHandler(this.VERIFONE_USERIDTextBox_TextChanged);
            // 
            // label328
            // 
            this.label328.AutoSize = true;
            this.label328.ForeColor = System.Drawing.Color.White;
            this.label328.Location = new System.Drawing.Point(20, 68);
            this.label328.Name = "label328";
            this.label328.Size = new System.Drawing.Size(52, 13);
            this.label328.TabIndex = 168;
            this.label328.Text = "User Id:";
            // 
            // label329
            // 
            this.label329.AutoSize = true;
            this.label329.Enabled = false;
            this.label329.ForeColor = System.Drawing.Color.White;
            this.label329.Location = new System.Drawing.Point(3, 8);
            this.label329.Name = "label329";
            this.label329.Size = new System.Drawing.Size(136, 13);
            this.label329.TabIndex = 167;
            this.label329.Text = "TERMINAL VERIFONE";
            this.label329.Visible = false;
            // 
            // label1191
            // 
            this.label1191.AutoSize = true;
            this.label1191.Location = new System.Drawing.Point(26, 272);
            this.label1191.Name = "label1191";
            this.label1191.Size = new System.Drawing.Size(119, 13);
            this.label1191.TabIndex = 214;
            this.label1191.Text = "% Utilidad Recarga:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.NOMBRELabel.Location = new System.Drawing.Point(48, 9);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // WFEmpresaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(785, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NOMBRELabel);
            this.Controls.Add(this.NOMBRETextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFEmpresaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPRESA";
            this.Load += new System.EventHandler(this.WFEmpresaEdit_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VERSIONWSEXISTENCIASTextBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.TBComisiones.ResumeLayout(false);
            this.TBComisiones.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIMEOUTPINTDISTSALESERVTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutPin)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.tabPagePPC.ResumeLayout(false);
            this.tabPagePPC.PerformLayout();
            this.tabPageImportaciones.ResumeLayout(false);
            this.tabPageImportaciones.PerformLayout();
            this.TabPageComisionesXPrecio.ResumeLayout(false);
            this.TabPageComisionesXPrecio.PerformLayout();
            this.TBComanda.ResumeLayout(false);
            this.TBComanda.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }
  #endregion
        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.TextBox CALLETextBox;
        private System.Windows.Forms.TextBox COLONIATextBox;
        private System.Windows.Forms.TextBox LOCALIDADTextBox;
        private System.Windows.Forms.TextBox CPTextBox;
        private System.Windows.Forms.TextBox TELEFONOTextBox;
        private System.Windows.Forms.TextBox FAXTextBox;
        private System.Windows.Forms.TextBox CORREOETextBox;
        private System.Windows.Forms.TextBox PAGINAWEBTextBox;
        private System.Windows.Forms.TextBox RFCTextBox;
        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Label LBError;
  private CustomValidation.RequiredFieldValidator requiredFieldValidator1;
        private CustomValidation.RequiredFieldValidator RFV_NOMBRE;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.Label CALLELabel;
        private System.Windows.Forms.Label COLONIALabel;
        private System.Windows.Forms.Label LOCALIDADLabel;
        private System.Windows.Forms.Label ESTADOLabel;
        private System.Windows.Forms.Label CPLabel;
        private System.Windows.Forms.Label TELEFONOLabel;
        private System.Windows.Forms.Label FAXLabel;
        private System.Windows.Forms.Label CORREOELabel;
        private System.Windows.Forms.Label PAGINAWEBLabel;
        private System.Windows.Forms.Label RFCLabel;
        private System.Windows.Forms.ComboBox LISTA_PRECIO_DEFTextBox;
        private System.Windows.Forms.NumericTextBox IMP_PROD_DEFTextBox;
        private System.Windows.Forms.Label LISTA_PRECIO_DEFLabel;
        private System.Windows.Forms.Label IMP_PROD_DEFLabel;
        private System.Windows.Forms.Label ESTADO_DEFLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBoxFB SucursalComboBox;
        private System.Windows.Forms.DateTimePicker UltimaFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ID_DOSLETRASTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox HABILITAR_IMPEXP_AUTComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SMTPMAILFROMTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SMTPUSUARIOTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SMTPHOSTTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox FTPPASSWORDTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox FTPHOSTTextBox;
        private System.Windows.Forms.TextBox FTPUSUARIOTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox SMTPPASSWORDTextBox;
        private System.Windows.Forms.NumericTextBox SMTPPORTTextBox;
        private System.Windows.Forms.TextBox SMTPMAILTOTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBCambiarPrecio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox FOOTERTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox HEADERTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox HAB_SEL_CLIENTEComboBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox HAB_IMPR_COTIZACIONComboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage TBComisiones;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericTextBox COMISIONDEPENDIENTETextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericTextBox COMISIONMEDICOTextBox;
        private System.Windows.Forms.ComboBox MOSTRAR_EXIS_SUCComboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox REQ_APROBACION_INVComboBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox REABRIRCORTESComboBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox IMP_PROD_TOTALComboBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox FECHA2TextBox;
        private System.Windows.Forms.TextBox NUMERO4TextBox;
        private System.Windows.Forms.TextBox FECHA1TextBox;
        private System.Windows.Forms.TextBox NUMERO2TextBox;
        private System.Windows.Forms.TextBox NUMERO3TextBox;
        private System.Windows.Forms.TextBox NUMERO1TextBox;
        private System.Windows.Forms.TextBox TEXTO6TextBox;
        private System.Windows.Forms.TextBox TEXTO4TextBox;
        private System.Windows.Forms.TextBox TEXTO5TextBox;
        private System.Windows.Forms.TextBox TEXTO2TextBox;
        private System.Windows.Forms.TextBox TEXTO3TextBox;
        private System.Windows.Forms.TextBox TEXTO1TextBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox NUMEROINTERIORTextBox;
        private System.Windows.Forms.TextBox NUMEROEXTERIORTextBox;
        private System.Windows.Forms.ComboBox HAB_FACTURAELECTRONICAComboBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox USARFISCALESENEXPEDICIONCheckBox;
        private System.Windows.Forms.TextBox SERIESATTextBox;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox TIMBRADOKEYTextBox;
        private System.Windows.Forms.TextBox TIMBRADOARCHIVOKEYTextBox;
        private System.Windows.Forms.TextBox TIMBRADOARCHIVOCERTIFICADOTextBox;
        private System.Windows.Forms.TextBox TIMBRADOPASSWORDTextBox;
        private System.Windows.Forms.TextBox TIMBRADOUSERTextBox;
        private System.Windows.Forms.TextBox FISCALNOMBRETextBox;
        private System.Windows.Forms.TextBox CERTIFICADOCSDTextBox;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox FISCALNUMEROINTERIORTextBox;
        private System.Windows.Forms.TextBox FISCALNUMEROEXTERIORTextBox;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox FISCALCODIGOPOSTALTextBox;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox FISCALMUNICIPIOTextBox;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox FISCALCALLETextBox;
        private System.Windows.Forms.TextBox FISCALCOLONIATextBox;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox FOOTERVENTAAPARTADOTextBox;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.NumericTextBox PORC_COMISIONVENDEDORTextBox;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericTextBox PORC_COMISIONENCARGADOTextBox;
        private System.Windows.Forms.Button VENDEDORButton;
        private Tools.TextBoxFB ENCARGADOIDTextBox;
        private System.Windows.Forms.Label VENDEDORLabel;
        private System.Windows.Forms.Label lblClienteSuc;
        private System.Windows.Forms.TextBox FTPFOLDERPASSTextBox;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox FTPFOLDERTextBox;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox SERIESATDEVOLUCIONTextBox;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox CAMBIARPRECIOXPZACAJAComboBox;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ComboBox CAMBIARPRECIOXUEMPAQUEComboBox;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.NumericTextBox LONGPESOBASCULATextBox;
        private System.Windows.Forms.NumericTextBox LONGPRODBASCULATextBox;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox PREFIJOBASCULATextBox;
        private System.Windows.Forms.ComboBox LISTAPRECIOXUEMPAQUEComboBox;
        private System.Windows.Forms.ComboBox LISTAPRECIOXPZACAJAComboBox;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.ComboBox LISTAPRECIOINIMAYOComboBox;
        private System.Windows.Forms.ComboBox HAYVENDEDORPISOComboBox;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox ENVIOAUTOMATICOEXISTENCIASComboBox;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.ComboBoxFB ESTADO_DEFTextBox;
        private System.Windows.Forms.ComboBoxFB FISCALESTADOTextBox;
        private System.Windows.Forms.ComboBoxFB ESTADOTextBox;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ComboBox MONEDEROAPLICARComboBox;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.NumericTextBox MONEDEROCADUCIDADTextBox;
        private System.Windows.Forms.NumericTextBox MONEDEROMONTOMINIMOTextBox;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.ComboBox IMPRIMIRNUMEROPIEZASComboBox;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox L1CAMPO20CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO19CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO18CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO17CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO16CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO15CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPOOBLIGADO3;
        private System.Windows.Forms.CheckBox L1CAMPO14CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO13CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO12CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO11CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO9CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO10CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO8CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO7CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO6CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO5CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO3CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO4CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO2CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO1CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPOOBLIGADO2;
        private System.Windows.Forms.CheckBox L1CAMPOOBLIGADO1;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox PACUSUARIOTextBox;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox PACNOMBRETextBox;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.CheckBox L1CAMPO21CheckBox;
        private System.Windows.Forms.ComboBox CORTEPORMAILTextBox;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox RUTAREPORTESTextBox;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.ComboBox CAMPOSCUSTOMALIMPORTARTextBox;
        private System.Windows.Forms.NumericTextBox DOBLECOPIATRASLADOTextBox;
        private System.Windows.Forms.NumericTextBox DOBLECOPIACREDITOTextBox;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.ComboBox RECIBOLARGOPREVIEWComboBox;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox RECIBOLARGOPRINTERTextBox;
        private System.Windows.Forms.ComboBox PREGUNTARRAZONPRECIOMENORComboBox;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.ComboBox PREGUNTARDATOSENTREGAComboBox;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TextBox FISCALREGIMENTextBox;
        private System.Windows.Forms.NumericTextBox CORTACADUCIDADTextBox;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.CheckBox ARRENDATARIOCheckBox;
        private System.Windows.Forms.NumericTextBox RETENCIONISRTextBox;
        private System.Windows.Forms.NumericTextBox RETENCIONIVATextBox;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox RUTAIMAGENESPRODUCTOTextBox;
        private System.Windows.Forms.ComboBox MOSTRARIMAGENENVENTATextBox;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.ComboBox MOSTRARMONTOAHORROComboBox;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.ComboBox MOSTRARDESCUENTOFACTURAComboBox;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.ComboBox EXPORTCATALOGOAUXTextBox;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.ComboBox UIVENTACONCANTIDADComboBox;
        private System.Windows.Forms.TextBox FACT_ELECT_FOLDERTextBox;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TextBox PEDIDOS_FOLDERTextBox;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.TextBox PREFIJOCLIENTETextBox;
        private System.Windows.Forms.ComboBox MOSTRARPZACAJAENFACTURAComboBox;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.TextBox CUENTAIEPSTextBox;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.CheckBox DESGLOSEIEPSTextBox;
        private System.Windows.Forms.ComboBox DIVIDIR_REM_FACTTextBox;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.TextBox WEBSERVICETextBox;
        private System.Windows.Forms.Label LABELWEBSERVICE;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.NumericTextBox MINUTILIDADTextBox;
        private System.Windows.Forms.ComboBox MANEJASUPERLISTAPRECIOTextBox;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.ComboBox MANEJAALMACENTextBox;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.ComboBoxFB TIPODESCUENTOPRODIDTextBox;
        private System.Windows.Forms.CheckBox L1CAMPO23CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO22CheckBox;
        private System.Windows.Forms.ComboBox MANEJARECETATextBox;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.ComboBox AUTOCOMPPRODTextBox;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.ComboBoxFB TIPOUTILIDADIDTextBox;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.ComboBox MANEJAQUOTATextBox;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.ComboBox TOUCHTextBox;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.ComboBox ESVENDEDORMOVILTextBox;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.ComboBox CAJASBOTELLASTextBox;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.ComboBox PRECIONETOENPVTextBox;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.ComboBox TIPOSYNCMOVILTextBox;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.ComboBox ORDENIMPRESIONComboBox;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.ComboBox MOSTRARFLASHComboBox;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.ComboBox AUTOCOMPCLIENTETextBox;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.ComboBox PRECIOXCAJAENPVTextBox;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.ComboBox USARCONEXIONLOCALTextBox;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.TextBox LOCALWEBSERVICETextBox;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.TextBox LOCALFTPHOSTTextBox;
        private System.Windows.Forms.TextBox MAILTOINVENTARIOTextBox;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.TextBox RUTARESPALDOSZIPTextBox;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.ComboBox SCREENCONFIGTextBox;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.ComboBox PROMOENTICKETComboBox;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.ComboBox TAMANOLETRATICKETTextBox;
        private System.Windows.Forms.ComboBox MANEJAKITSTextBox;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.ComboBox CAMPOIMPOCOSTOREPOTextBox;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.ComboBox LISTAPRECIOMINIMOComboBox;
        private System.Windows.Forms.ComboBox REBAJAESPECIALTextBox;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.ComboBox PRECIOSMOVILANTESVENTATextBox;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.ComboBox PENDMOVILANTESVENTATextBox;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.ComboBox RECALCULARCAMBIOCLIENTETextBox;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.TextBox BDSERVERWSTextBox;
        private System.Windows.Forms.ComboBox TIPOVENDEDORMOVILTextBox;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.TextBox BDMATRIZMOVILTextBox;
        private System.Windows.Forms.ComboBox MOVILVERIFICARVENTAComboBox;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.NumericTextBox PENDMAXDIASTextBox;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.ComboBox REQAUTCANCELARCOTIComboBox;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.ComboBox RECIBOLARGOCONFACTURAComboBox;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.ComboBox REQAUTELIMDETALLECOTIComboBox;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.ComboBox ABRIRCAJONALFINCORTEComboBox;
        private System.Windows.Forms.ComboBox HABSURTIDOPOSTPUESTOTextBox;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.Button CLIENTECLAVEButton;
        private Tools.TextBoxFB CLIENTECONSOLIDADOIDTextBox;
        private System.Windows.Forms.Label CLIENTECLAVELabel;
        private System.Windows.Forms.TextBox RUTAREPORTESSISTEMATextBox;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.ComboBox REIMPRESIONESCONMARCAComboBox;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.ComboBox DOBLECOPIAREMISIONComboBox;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label149;
        private System.Windows.Forms.ComboBox HABTOTALIZADOSTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericTextBox DESCUENTOVALETextBox;
        private System.Windows.Forms.ComboBox MULTIPLETIPOVALETextBox;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.NumericTextBox DESCUENTOTIPO4PORCTextBox;
        private System.Windows.Forms.TextBox DESCUENTOTIPO4TEXTOTextBox;
        private System.Windows.Forms.NumericTextBox DESCUENTOTIPO3PORCTextBox;
        private System.Windows.Forms.TextBox DESCUENTOTIPO3TEXTOTextBox;
        private System.Windows.Forms.NumericTextBox DESCUENTOTIPO2PORCTextBox;
        private System.Windows.Forms.TextBox DESCUENTOTIPO2TEXTOTextBox;
        private System.Windows.Forms.NumericTextBox DESCUENTOTIPO1PORCTextBox;
        private System.Windows.Forms.TextBox DESCUENTOTIPO1TEXTOTextBox;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.ComboBox HABILITARLOGComboBox;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.TextBox txtRutaRespaldo;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.NumericTextBox MONTORETIROCAJATextBox;
        private System.Windows.Forms.ComboBox MANEJARRETIRODECAJATextBox;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.NumericTextBox COMISIONPORTARJETATextBox;
        private System.Windows.Forms.ComboBox APLICARMAYOREOPORLINEATextBox;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.NumericTextBox PIEZASDIFMAYOREOTextBox;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.NumericTextBox PIEZASIGUALESMAYOREOTextBox;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.NumericTextBox PIEZASDIFMEDIOMAYOREOTextBox;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.NumericTextBox PIEZASIGUALESMEDIOMAYOREOTextBox;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.NumericTextBox COMISIONTARJETAEMPRESATextBox;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.NumericTextBox IVACOMISIONTARJETAEMPRESATextBox;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.ComboBox PREGUNTACANCELACOTIZACIONTextBox;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.ComboBox HABVERIFICACIONCXCTextBox;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.CheckBox L1CAMPO26CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO25CheckBox;
        private System.Windows.Forms.CheckBox L1CAMPO24CheckBox;
        private System.Windows.Forms.Label label172;
        private System.Windows.Forms.CheckBox L1CAMPO30CheckBox;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.CheckBox L1CAMPO29CheckBox;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.CheckBox L1CAMPO28CheckBox;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.CheckBox L1CAMPO27CheckBox;
        private System.Windows.Forms.Label label173;
        private System.Windows.Forms.TextBox MAILEJECUTIVOTextBox;
        private System.Windows.Forms.ComboBox VENTASXCORTEEMAILTextBox;
        private System.Windows.Forms.Label label174;
        private System.Windows.Forms.Label label175;
        private System.Windows.Forms.ComboBox HABVENTASAFUTUROComboBox;
        private System.Windows.Forms.ComboBox FORMATOTICKETCORTOIDComboBox;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.TextBox SERIESATABONOTextBox;
        private System.Windows.Forms.Label label178;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.Label label179;
        private System.Windows.Forms.ComboBox HABIMPRESIONCORTECAJEROComboBox;
        private System.Windows.Forms.Label label181;
        private System.Windows.Forms.Label label182;
        private System.Windows.Forms.ComboBox HABTRASLADOPORAUTORIZACIONComboBox;
        private System.Windows.Forms.Label label183;
        private System.Windows.Forms.CheckBox cbHabVentasMostrador;
        private System.Windows.Forms.TextBox txtRutaAdjuntarArchivo;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.ComboBox HABPROMOXMONTOMINTextBox;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.Label label190;
        private System.Windows.Forms.ComboBox FORMATOFACTURAComboBox;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.NumericTextBox MONTOMAXSALDOMENORNumericTextBox;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.CheckBox HABPAGOSERVEMIDACheckBox;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.NumericUpDown TIMEOUTPINTDISTSALESERVTextBox;
        private System.Windows.Forms.Label label185;
        private System.Windows.Forms.Label label184;
        private System.Windows.Forms.NumericUpDown nudTimeOutLookUp;
        private System.Windows.Forms.NumericUpDown nudTimeOutPin;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.CheckBox rdbtnEmidaServices;
        private System.Windows.Forms.Button LINEARecButton;
        private System.Windows.Forms.Label LINEARecLabel;
        private Tools.TextBoxFB LINEAIDRecTextBox;
        private System.Windows.Forms.Button MARCARecButton;
        private Tools.TextBoxFB MARCAIDRecTextBox;
        private System.Windows.Forms.Label MARCARecLabel;
        private System.Windows.Forms.Button PROVEEDOR1ServButton;
        private Tools.TextBoxFB PROVEEDOR1IDServTextBox;
        private System.Windows.Forms.Label PROVEEDOR1ServLabel;
        private System.Windows.Forms.Button MARCAServButton;
        private Tools.TextBoxFB MARCAIDServTextBox;
        private System.Windows.Forms.Label MARCAServLabel;
        private System.Windows.Forms.Button LINEAServButton;
        private System.Windows.Forms.Label LINEAServLabel;
        private Tools.TextBoxFB LINEAIDServTextBox;
        private System.Windows.Forms.Button PROVEEDOR1RecButton;
        private Tools.TextBoxFB PROVEEDOR1IDRecTextBox;
        private System.Windows.Forms.Label PROVEEDOR1RecLabel;
        private System.Windows.Forms.Label label1191;
        private System.Windows.Forms.NumericTextBox txtPorcUtilidadRecargas;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.NumericTextBox txtUtilidadPagoServicio;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.ComboBox PRECIOSORDENADOSTextBox;
        private System.Windows.Forms.Label label196;
        private System.Windows.Forms.NumericTextBox DECIMALESENCANTIDADTextBox;
        private System.Windows.Forms.Label label195;
        private System.Windows.Forms.TextBox L1LBL_CAMPO19TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO15TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO14TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO8TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO2TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO23TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO22TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO21TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO20TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO18TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO16TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO30TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO29TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO28TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO27TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO26TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO24TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO25TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO17TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO13TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO7TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO12TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO6TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO11TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO5TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO10TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO9TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO4TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO3TextBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO1TextBox;
        private System.Windows.Forms.ComboBox EANPUEDEREPETIRSETextBox;
        private System.Windows.Forms.Label label197;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.CheckBox BANCOMERHABPINPADCheckBox;
        private System.Windows.Forms.ComboBox HAB_PRECIOSCLIENTETextBox;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.ComboBox CXCVALIDARTRASLADOSTextBox;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.TextBox L1LBL_CAMPO31TextBox;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.CheckBox L1CAMPO31CheckBox;
        private System.Windows.Forms.ComboBox PREGUNTARSIESACREDITOTextBox;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.TextBox WSMENSAJERIATextBox;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.ComboBox HABMENSAJERIAComboBox;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.ComboBox SMTPSSLComboBox;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.CheckBox DESCUENTOLINEAPERSONACheckBox;
        private System.Windows.Forms.Label label208;
        private System.Windows.Forms.CheckBox MANEJARLOTEIMPORTACIONCheckBox;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.CheckBox MANEJAGASTOSADICCheckBox;
        private System.Windows.Forms.ComboBox cmbPrecioDifInv;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.CheckBox cbHabBtnPagoVale;
        
        private System.Windows.Forms.NumericTextBox CADUCIDADMINIMATextBox;
        private System.Windows.Forms.Label label213;
        private System.Windows.Forms.CheckBox unicaVisitaPorDoctoCheckBox;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.CheckBox cbPlazosXProducto;
        private System.Windows.Forms.CheckBox autocompleteConExistenciaCB;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.TextBox txtRutaBDAppInventario;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.TextBox txtIPWsAppInventario;
        private System.Windows.Forms.CheckBox L1CAMPO33CheckBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO33TextBox;
        private System.Windows.Forms.CheckBox L1CAMPO32CheckBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO32TextBox;
        private System.Windows.Forms.Label label217;
        private System.Windows.Forms.CheckBox actPrecAutoCB;
        private System.Windows.Forms.NumericTextBox cancelXActNumericTextBox;
        private System.Windows.Forms.Label label219;
        private System.Windows.Forms.CheckBox MANEJACUPONESCheckBox;
        private System.Windows.Forms.TextBox txtRutaDBFExistenciaSuc;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENRECEPCIONIDTextBox;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.ComboBox HAB_DEVOLUCIONSURTIDOSUCComboBox;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.ComboBox HAB_DEVOLUCIONTRASLADOComboBox;
        private System.Windows.Forms.NumericUpDown VERSIONWSEXISTENCIASTextBox;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Label label224;
        private System.Windows.Forms.ComboBox MOSTRARINVINFOADICPRODTextBox;
        private System.Windows.Forms.ComboBox filtroProdSatComboBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO35TextBox;
        private System.Windows.Forms.CheckBox L1CAMPO35CheckBox;
        private System.Windows.Forms.TextBox L1LBL_CAMPO34TextBox;
        private System.Windows.Forms.CheckBox L1CAMPO34CheckBox;
        private System.Windows.Forms.CheckBox MANEJAPRODUCTOSPROMOCIONCheckBox;
        private System.Windows.Forms.Label MANEJAPRODUCTOSPROMOCIONLabel;
        private System.Windows.Forms.Button REGIMENSATFBButton;
        private Tools.TextBoxFB REGIMENSATFBTextBox;
        private System.Windows.Forms.Label REGIMENSATLBL;
        private System.Windows.Forms.Button METPAGOSATIDButton;
        private Tools.TextBoxFB METPAGOSATIDTextBox;
        private System.Windows.Forms.Label METPAGOSATIDValLabel;
        private System.Windows.Forms.Label METPAGOSATIDLabel;
        private System.Windows.Forms.Label label225;
        private System.Windows.Forms.ComboBox PRECIONETOENGRIDSTextBox;
        private System.Windows.Forms.Label label226;
        private System.Windows.Forms.CheckBox PAGOSERVCONSOLIDADOTextBox;
        private System.Windows.Forms.TextBox WSESPECIALEXISTMATRIZTextBox;
        private System.Windows.Forms.Label label227;
        private System.Windows.Forms.TextBox txtRutaReplicadorExe;
        private System.Windows.Forms.Label lblRutaReplicadorExe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.TextBox BDLOCALREPLTextBox;
        private System.Windows.Forms.ComboBox HABILITARREPLTextBox;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.Label label228;
        private System.Windows.Forms.CheckBox HAB_CONSOLIDADOAUTOMATICOCheckBox;
        private System.Windows.Forms.Label label229;
        private System.Windows.Forms.TextBox TICKETESPECIALTextBox;
        private System.Windows.Forms.Label label231;
        private System.Windows.Forms.TextBox RECARGASDEFAULTPRINTERTextBox;
        private System.Windows.Forms.Label label230;
        private System.Windows.Forms.TextBox TICKETDEFAULTPRINTERTextBox;
        private System.Windows.Forms.ComboBox PIEZACAJAENTICKETComboBox;
        private System.Windows.Forms.Label label232;
        private System.Windows.Forms.NumericTextBox NUMTICKETSABONOTextBox;
        private System.Windows.Forms.Label label233;
        private System.Windows.Forms.Label label234;
        private System.Windows.Forms.ComboBox PVCOLOREARTextBox;
        private System.Windows.Forms.CheckBox GENERARFECheckBox;
        private System.Windows.Forms.Label label235;
        private System.Windows.Forms.NumericTextBox INTENTOSRETIROCAJATextBox;
        private System.Windows.Forms.Label label240;
        private System.Windows.Forms.Label label239;
        private System.Windows.Forms.Label label238;
        private System.Windows.Forms.Label label237;
        private System.Windows.Forms.Label label236;
        private System.Windows.Forms.Label label241;
        private System.Windows.Forms.Label VENDEDORMOVILIDLabel;
        private Tools.TextBoxFB VENDEDORMOVILCLAVETextBox;
        private System.Windows.Forms.Button VENDEDORMOVILIDButton;
        private System.Windows.Forms.Label VENDEDORIDLabel;
        private System.Windows.Forms.Label label242;
        private System.Windows.Forms.ComboBox MOVIL_TIENEVENDEDORESComboBox;
        private System.Windows.Forms.TextBox RUTACATALOGOSUPDTextBox;
        private System.Windows.Forms.Label label243;
        private System.Windows.Forms.Label label244;
        private System.Windows.Forms.ComboBox IMPRIMIRCOPIAALMACENComboBox;
        private System.Windows.Forms.Label label245;
        private System.Windows.Forms.CheckBox MOVIL3_PREIMPORTARCheckBox;
        private System.Windows.Forms.TextBox RUTAIMPORTADATOSTextBox;
        private System.Windows.Forms.Label label246;
        private System.Windows.Forms.Label label247;
        private System.Windows.Forms.CheckBox cbBusquedaTipo2;
        private System.Windows.Forms.TextBox VERSIONCFDITextBox;
        private System.Windows.Forms.Label label248;
        private System.Windows.Forms.Button AGRUPACIONVENTAIDButton;
        private Tools.TextBoxFB AGRUPACIONVENTAIDTextBox;
        private System.Windows.Forms.Label AGRUPACIONVENTAIDLabel;
        private System.Windows.Forms.Label label250;
        private System.Windows.Forms.CheckBox CONSFACTOMITIRVALESCheckBox;
        private System.Windows.Forms.TextBox rutaBdVenMovTextBox;
        private System.Windows.Forms.Label label249;
        private System.Windows.Forms.Label label251;
        private System.Windows.Forms.NumericTextBox DOBLECOPIACONTADOTextBox;
        private System.Windows.Forms.Label label252;
        private System.Windows.Forms.CheckBox DESGLOSEIEPSFACTURATextBox;
        private System.Windows.Forms.TextBox RUTAPOLIZAPDFTextBox;
        private System.Windows.Forms.Label label253;
        private System.Windows.Forms.Label label254;
        private System.Windows.Forms.CheckBox IMPRIMIRBANCOSCORTEComboBox;
        private System.Windows.Forms.Label label255;
        private System.Windows.Forms.CheckBox IMPR_CANC_VENTAComboBox;
        private System.Windows.Forms.ComboBox RETIROCAJAALCERRARCORTETextBox;
        private System.Windows.Forms.Label label256;
        private System.Windows.Forms.CheckBox PAGOTARJMENORPRECIOLISTAALLTextBox;
        private System.Windows.Forms.Label label257;
        private System.Windows.Forms.CheckBox PREGUNTARSERVDOMTextBox;
        private System.Windows.Forms.Label label258;
        private System.Windows.Forms.TabPage tabPagePPC;
        private System.Windows.Forms.CheckBox HABPPCTextBox;
        private System.Windows.Forms.Label label259;
        private System.Windows.Forms.Label lblSaldosAplicados;
        private System.Windows.Forms.CheckBox SOLOABONOAPLICADOTextBox;
        private System.Windows.Forms.NumericTextBox VERSIONTOPEIDTextBox;
        private System.Windows.Forms.NumericTextBox VERSIONCOMISIONIDTextBox;
        private System.Windows.Forms.Label label260;
        private System.Windows.Forms.NumericTextBox MAXCOMISIONXCLIENTETextBox;
        private System.Windows.Forms.Label label262;
        private System.Windows.Forms.CheckBox IMPRFORMAVENTATRASLTextBox;
        private System.Windows.Forms.Label label261;
        private System.Windows.Forms.ComboBox HABREVISIONFINALTextBox;
        private System.Windows.Forms.Label label263;
        private System.Windows.Forms.Label label264;
        private System.Windows.Forms.TextBox RECIBOLARGOCOTIPRINTERTextBox;
        private System.Windows.Forms.ComboBox HABFONDODINAMICOTextBox;
        private System.Windows.Forms.Label label265;
        private System.Windows.Forms.ComboBox HABVENTACLISUCTextBox;
        private System.Windows.Forms.Label label266;
        private System.Windows.Forms.TabPage tabPageImportaciones;
        private System.Windows.Forms.TextBox WSDBFTextBox;
        private System.Windows.Forms.Label label269;
        private System.Windows.Forms.NumericTextBox DIASMAXEXPFTPTextBox;
        private System.Windows.Forms.Label label268;
        private System.Windows.Forms.NumericTextBox SEGUNDOSCICLOFTPTextBox;
        private System.Windows.Forms.Label label267;
        private System.Windows.Forms.ComboBox HABWSDBFTextBox;
        private System.Windows.Forms.Label label271;
        private System.Windows.Forms.NumericTextBox DIASMAXIMPFTPTextBox;
        private System.Windows.Forms.Label label270;
        private System.Windows.Forms.Label label273;
        private System.Windows.Forms.NumericTextBox COMISIONDEBTARJETAEMPRESATextBox;
        private System.Windows.Forms.Label label272;
        private System.Windows.Forms.NumericTextBox COMISIONDEBPORTARJETATextBox;
        private System.Windows.Forms.Label label274;
        private System.Windows.Forms.NumericTextBox FACTCONSMAXPORTextBox;
        private System.Windows.Forms.Label label276;
        private System.Windows.Forms.Label label277;
        private System.Windows.Forms.NumericTextBox DOBLECOPIATARJETATextBox;
        private System.Windows.Forms.Label label275;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.DateTimePicker FISCALFECHACANCELACION2TextBox;
        private System.Windows.Forms.Label label278;
        private System.Windows.Forms.Label label279;
        private System.Windows.Forms.NumericTextBox CANTTICKETRETIROTextBox;
        private System.Windows.Forms.Label label282;
        private System.Windows.Forms.NumericTextBox CANTTICKETCIERREBILLETESTextBox;
        private System.Windows.Forms.Label label291;
        private System.Windows.Forms.NumericTextBox CANTTICKETCIERRECORTETextBox;
        private System.Windows.Forms.Label label289;
        private System.Windows.Forms.NumericTextBox CANTTICKETABRIRCORTETextBox;
        private System.Windows.Forms.Label label287;
        private System.Windows.Forms.NumericTextBox CANTTICKETCOMPRASTextBox;
        private System.Windows.Forms.Label label285;
        private System.Windows.Forms.NumericTextBox CANTTICKETGASTOSTextBox;
        private System.Windows.Forms.Label label283;
        private System.Windows.Forms.NumericTextBox CANTTICKETFONDOCAJATextBox;
        private System.Windows.Forms.Label label280;
        private System.Windows.Forms.Label label281;
        private System.Windows.Forms.NumericTextBox CANTTICKETDEPOSITOSTextBox;
        private System.Windows.Forms.ComboBox MANEJAUTILIDADPRECIOSTextBox;
        private System.Windows.Forms.Label label284;
        private System.Windows.Forms.ComboBox HABMULTPLAZOCOMPRATextBox;
        private System.Windows.Forms.Label label286;
        private System.Windows.Forms.Label label288;
        private System.Windows.Forms.ComboBox COSTOREPOIGUALCOSTOULTComboBox;
        private System.Windows.Forms.Label label293;
        private System.Windows.Forms.Label label292;
        private System.Windows.Forms.ComboBox TICKET_DESC_VALE_AL_FINALComboBox;
        private System.Windows.Forms.Label label290;
        private System.Windows.Forms.TabPage TabPageComisionesXPrecio;
        private System.Windows.Forms.Label label299;
        private System.Windows.Forms.NumericTextBox COMISIONPRECIOOTROTextBox;
        private System.Windows.Forms.Label label298;
        private System.Windows.Forms.NumericTextBox COMISIONPRECIO5TextBox;
        private System.Windows.Forms.Label label297;
        private System.Windows.Forms.NumericTextBox COMISIONPRECIO4TextBox;
        private System.Windows.Forms.Label label296;
        private System.Windows.Forms.NumericTextBox COMISIONPRECIO3TextBox;
        private System.Windows.Forms.Label label295;
        private System.Windows.Forms.NumericTextBox COMISIONPRECIO2TextBox;
        private System.Windows.Forms.Label label294;
        private System.Windows.Forms.NumericTextBox COMISIONPRECIO1TextBox;
        private System.Windows.Forms.Label MONEDEROLISTAPRECIOIDLabel;
        private System.Windows.Forms.Label MONEDEROCAMPOREFLabel;
        private System.Windows.Forms.TextBox MONEDEROCAMPOREFTextBox;
        private System.Windows.Forms.ComboBox MONEDEROLISTAPRECIOIDComboBox;
        private System.Windows.Forms.Label label301;
        private System.Windows.Forms.ComboBox HABSURTIDOPREVIOTextBox;
        private System.Windows.Forms.Label label302;
        private System.Windows.Forms.Label label300;
        private System.Windows.Forms.TabPage TBComanda;
        private System.Windows.Forms.Label label304;
        private System.Windows.Forms.ComboBox RECIBOPREVIEWCOMANDATextBox;
        private System.Windows.Forms.Label label305;
        private System.Windows.Forms.NumericTextBox NUMTICKETSCOMANDATextBox;
        private System.Windows.Forms.Label label303;
        private System.Windows.Forms.TextBox IMPRESORACOMANDATextBox;
        private System.Windows.Forms.Label label307;
        private System.Windows.Forms.Label label306;
        private System.Windows.Forms.ComboBox TICKET_IMPR_DESC2ComboBox;
        private System.Windows.Forms.TextBox SERIECOMPRTRASLSATTextBox;
        private System.Windows.Forms.Label label308;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox L2LBL_CAMPO6TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO11TextBox;
        private System.Windows.Forms.Label label309;
        private System.Windows.Forms.CheckBox L2CAMPO11CheckBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO10TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO9TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO8TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO7TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO5TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO3TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO4TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO2TextBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO1TextBox;
        private System.Windows.Forms.Label label310;
        private System.Windows.Forms.CheckBox L2CAMPO10CheckBox;
        private System.Windows.Forms.Label label311;
        private System.Windows.Forms.CheckBox L2CAMPO9CheckBox;
        private System.Windows.Forms.Label label312;
        private System.Windows.Forms.CheckBox L2CAMPO8CheckBox;
        private System.Windows.Forms.Label label313;
        private System.Windows.Forms.CheckBox L2CAMPO7CheckBox;
        private System.Windows.Forms.CheckBox L2CAMPO5CheckBox;
        private System.Windows.Forms.CheckBox L2CAMPO4CheckBox;
        private System.Windows.Forms.CheckBox L2CAMPO3CheckBox;
        private System.Windows.Forms.Label label314;
        private System.Windows.Forms.CheckBox L2CAMPO2CheckBox;
        private System.Windows.Forms.CheckBox L2CAMPO6CheckBox;
        private System.Windows.Forms.CheckBox L2CAMPO1CheckBox;
        private System.Windows.Forms.TextBox L2LBL_CAMPO12TextBox;
        private System.Windows.Forms.Label label315;
        private System.Windows.Forms.CheckBox L2CAMPO12CheckBox;
        private System.Windows.Forms.ComboBox HABSURTIDOPOSTMOVILTextBox;
        private System.Windows.Forms.Label label316;
        private System.Windows.Forms.Label label317;
        private System.Windows.Forms.NumericTextBox PORCUTILIDADLISTADOTextBox;
        private System.Windows.Forms.Label label318;
        private System.Windows.Forms.TextBox RUTAFIRMAIMAGENESTextBox;
        private System.Windows.Forms.ComboBox LISTAPRECMEDMAYLINEAComboBox;
        private System.Windows.Forms.Label label319;
        private System.Windows.Forms.ComboBox LISTAPRECIOMAYLINEAComboBox;
        private System.Windows.Forms.ComboBox AUTPRECIOLISTABAJOTextBox;
        private System.Windows.Forms.Label label320;
        private System.Windows.Forms.Label label321;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox VERIFONEACTIVOCheckBox;
        private System.Windows.Forms.Label label322;
        private System.Windows.Forms.TextBox VERIFONE_OPERATORLOCALETextBox;
        private System.Windows.Forms.Label label325;
        private System.Windows.Forms.TextBox VERIFONE_MERCHANTIDTextBox;
        private System.Windows.Forms.Label label326;
        private System.Windows.Forms.TextBox VERIFONE_SHIFTNUMBERTextBox;
        private System.Windows.Forms.Label label327;
        private System.Windows.Forms.TextBox VERIFONE_CONTRASENATextBox;
        private System.Windows.Forms.Label lblVerifoneContrasena;
        private System.Windows.Forms.TextBox VERIFONE_USERIDTextBox;
        private System.Windows.Forms.Label label328;
        private System.Windows.Forms.Label label329;
        private System.Windows.Forms.NumericTextBox PORCUTILMACROLISTADOTextBox;
        private System.Windows.Forms.Label label323;
        private System.Windows.Forms.TextBox L1LBL_CAMPO36TextBox;
        private System.Windows.Forms.Label lblPrecioMacro;
        private System.Windows.Forms.CheckBox L1CAMPO36CheckBox;
    }
}

