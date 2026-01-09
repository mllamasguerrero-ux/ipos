
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;
namespace iPos
{
    public partial class WFEmpresaEdit : Form
    {
        public string opc;
        System.Collections.ArrayList validadores;
        string NOMBRE;
        bool bLlenandoDatosDeBase = false;
        bool emidaDataChanged = false;
        bool comisionPreciosChanged = false;
        bool verifoneDataChanged = false;


        CPARAMETROBE m_paremtrosPrevios = null;


        long VERIFONECONFIGID = 0;

        public WFEmpresaEdit()
        {
            InitializeComponent();
        }
        public void ReCargar(string popc,string pNOMBRE)
        {
            opc = popc;
            NOMBRE = pNOMBRE;
            validadores = new System.Collections.ArrayList();

            validadores.Add((RFV_NOMBRE));

            ESTADOTextBox.llenarDatos();
            ESTADO_DEFTextBox.llenarDatos();
            FISCALESTADOTextBox.llenarDatos();
            TIPOUTILIDADIDTextBox.llenarDatos();

            TIPODESCUENTOPRODIDTextBox.llenarDatos();

            ALMACENRECEPCIONIDTextBox.llenarDatos();


            SucursalComboBox.llenarDatos();
            SucursalComboBox.SelectedIndex = -1;

            if (this.opc != "Agregar" && this.opc != "")
            {

                LlenarDatosDeBase();
                LlenarDatosDeBaseLookUps();
                LlenarDatosDeBaseLookUpsVerificador();
                LlenarDatosDeBaseComisionesXLista();
                LlenarDatosDeVerifone();
                SetMode();
            }

        }



        private bool LlenarDatosDeBaseLookUps()
        {
            CLOOKUPD regD = new CLOOKUPD();
            CLOOKUPBE regBE = new CLOOKUPBE();
            regBE.ICLAVE = "PRODUCTO";
            try
            {
                regBE = regD.seleccionarLOOKUPXClave(regBE, null);
                if (regBE != null)
                {

                    if (!(bool)regBE.isnull["ICAMPO1"])
                        this.L1CAMPO1CheckBox.Checked = regBE.ICAMPO1.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO2"])
                        this.L1CAMPO2CheckBox.Checked = regBE.ICAMPO2.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO3"])
                        this.L1CAMPO3CheckBox.Checked = regBE.ICAMPO3.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO4"])
                        this.L1CAMPO4CheckBox.Checked = regBE.ICAMPO4.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO5"])
                        this.L1CAMPO5CheckBox.Checked = regBE.ICAMPO5.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO6"])
                        this.L1CAMPO6CheckBox.Checked = regBE.ICAMPO6.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO7"])
                        this.L1CAMPO7CheckBox.Checked = regBE.ICAMPO7.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO8"])
                        this.L1CAMPO8CheckBox.Checked = regBE.ICAMPO8.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO9"])
                        this.L1CAMPO9CheckBox.Checked = regBE.ICAMPO9.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO10"])
                        this.L1CAMPO10CheckBox.Checked = regBE.ICAMPO10.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO11"])
                        this.L1CAMPO11CheckBox.Checked = regBE.ICAMPO11.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO12"])
                        this.L1CAMPO12CheckBox.Checked = regBE.ICAMPO12.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO13"])
                        this.L1CAMPO13CheckBox.Checked = regBE.ICAMPO13.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO14"])
                        this.L1CAMPO14CheckBox.Checked = regBE.ICAMPO14.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO15"])
                        this.L1CAMPO15CheckBox.Checked = regBE.ICAMPO15.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO16"])
                        this.L1CAMPO16CheckBox.Checked = regBE.ICAMPO16.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO17"])
                        this.L1CAMPO17CheckBox.Checked = regBE.ICAMPO17.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO18"])
                        this.L1CAMPO18CheckBox.Checked = regBE.ICAMPO18.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO19"])
                        this.L1CAMPO19CheckBox.Checked = regBE.ICAMPO19.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO20"])
                        this.L1CAMPO20CheckBox.Checked = regBE.ICAMPO20.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO21"])
                        this.L1CAMPO21CheckBox.Checked = regBE.ICAMPO21.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO22"])
                        this.L1CAMPO22CheckBox.Checked = regBE.ICAMPO22.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO23"])
                        this.L1CAMPO23CheckBox.Checked = regBE.ICAMPO23.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO24"])
                        this.L1CAMPO24CheckBox.Checked = regBE.ICAMPO24.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO25"])
                        this.L1CAMPO25CheckBox.Checked = regBE.ICAMPO25.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO26"])
                        this.L1CAMPO26CheckBox.Checked = regBE.ICAMPO26.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO27"])
                        this.L1CAMPO27CheckBox.Checked = regBE.ICAMPO27.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO28"])
                        this.L1CAMPO28CheckBox.Checked = regBE.ICAMPO28.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO29"])
                        this.L1CAMPO29CheckBox.Checked = regBE.ICAMPO29.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO30"])
                        this.L1CAMPO30CheckBox.Checked = regBE.ICAMPO30.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO32"])
                        this.L1CAMPO32CheckBox.Checked = regBE.ICAMPO32.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO33"])
                        this.L1CAMPO33CheckBox.Checked = regBE.ICAMPO33.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO34"])
                        this.L1CAMPO34CheckBox.Checked = regBE.ICAMPO34.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO35"])
                        this.L1CAMPO35CheckBox.Checked = regBE.ICAMPO35.Trim().Equals("S");

                    if (!(bool)regBE.isnull["ICAMPO36"])
                        this.L1CAMPO36CheckBox.Checked = regBE.ICAMPO36.Trim().Equals("S");

                    this.L1LBL_CAMPO1TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO1"]) ? regBE.ILBL_CAMPO1 : "";
                    this.L1LBL_CAMPO2TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO2"]) ? regBE.ILBL_CAMPO2 : "";
                    this.L1LBL_CAMPO3TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO3"]) ? regBE.ILBL_CAMPO3 : "";
                    this.L1LBL_CAMPO4TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO4"]) ? regBE.ILBL_CAMPO4 : "";
                    this.L1LBL_CAMPO5TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO5"]) ? regBE.ILBL_CAMPO5 : "";
                    this.L1LBL_CAMPO6TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO6"]) ? regBE.ILBL_CAMPO6 : "";
                    this.L1LBL_CAMPO7TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO7"]) ? regBE.ILBL_CAMPO7 : "";
                    this.L1LBL_CAMPO8TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO8"]) ? regBE.ILBL_CAMPO8 : "";
                    this.L1LBL_CAMPO9TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO9"]) ? regBE.ILBL_CAMPO9 : "";
                    this.L1LBL_CAMPO10TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO10"]) ? regBE.ILBL_CAMPO10 : "";
                    this.L1LBL_CAMPO11TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO11"]) ? regBE.ILBL_CAMPO11 : "";
                    this.L1LBL_CAMPO12TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO12"]) ? regBE.ILBL_CAMPO12 : "";
                    this.L1LBL_CAMPO13TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO13"]) ? regBE.ILBL_CAMPO13 : "";
                    this.L1LBL_CAMPO14TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO14"]) ? regBE.ILBL_CAMPO14 : "";
                    this.L1LBL_CAMPO15TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO15"]) ? regBE.ILBL_CAMPO15 : "";
                    this.L1LBL_CAMPO16TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO16"]) ? regBE.ILBL_CAMPO16 : "";
                    this.L1LBL_CAMPO17TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO17"]) ? regBE.ILBL_CAMPO17 : "";
                    this.L1LBL_CAMPO18TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO18"]) ? regBE.ILBL_CAMPO18 : "";
                    this.L1LBL_CAMPO19TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO19"]) ? regBE.ILBL_CAMPO19 : "";
                    this.L1LBL_CAMPO20TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO20"]) ? regBE.ILBL_CAMPO20 : "";
                    this.L1LBL_CAMPO21TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO21"]) ? regBE.ILBL_CAMPO21 : "";
                    this.L1LBL_CAMPO22TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO22"]) ? regBE.ILBL_CAMPO22 : "";
                    this.L1LBL_CAMPO23TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO23"]) ? regBE.ILBL_CAMPO23 : "";
                    this.L1LBL_CAMPO24TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO24"]) ? regBE.ILBL_CAMPO24 : "";
                    this.L1LBL_CAMPO25TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO25"]) ? regBE.ILBL_CAMPO25 : "";
                    this.L1LBL_CAMPO26TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO26"]) ? regBE.ILBL_CAMPO26 : "";
                    this.L1LBL_CAMPO27TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO27"]) ? regBE.ILBL_CAMPO27 : "";
                    this.L1LBL_CAMPO28TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO28"]) ? regBE.ILBL_CAMPO28 : "";
                    this.L1LBL_CAMPO29TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO29"]) ? regBE.ILBL_CAMPO29 : "";
                    this.L1LBL_CAMPO30TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO30"]) ? regBE.ILBL_CAMPO30 : "";
                    this.L1LBL_CAMPO31TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO31"]) ? regBE.ILBL_CAMPO31 : "";
                    this.L1LBL_CAMPO32TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO32"]) ? regBE.ILBL_CAMPO32 : "";
                    this.L1LBL_CAMPO33TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO33"]) ? regBE.ILBL_CAMPO33 : "";
                    this.L1LBL_CAMPO34TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO34"]) ? regBE.ILBL_CAMPO34 : "";
                    this.L1LBL_CAMPO35TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO35"]) ? regBE.ILBL_CAMPO35 : "";
                    this.L1LBL_CAMPO36TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO36"]) ? regBE.ILBL_CAMPO36 : "";

                }

            }
            catch
            {
                return false;
            }


            return true;
        }


        private bool LlenarDatosDeBaseLookUpsVerificador()
        {
            CLOOKUPD regD = new CLOOKUPD();
            CLOOKUPBE regBE = new CLOOKUPBE();
            regBE.ICLAVE = "VERIFICADOR";
            try
            {
                regBE = regD.seleccionarLOOKUPXClave(regBE, null);
                if (regBE != null)
                {

                    if (!(bool)regBE.isnull["ICAMPO1"])
                        this.L2CAMPO1CheckBox.Checked = regBE.ICAMPO1.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO2"])
                        this.L2CAMPO2CheckBox.Checked = regBE.ICAMPO2.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO3"])
                        this.L2CAMPO3CheckBox.Checked = regBE.ICAMPO3.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO4"])
                        this.L2CAMPO4CheckBox.Checked = regBE.ICAMPO4.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO5"])
                        this.L2CAMPO5CheckBox.Checked = regBE.ICAMPO5.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO6"])
                        this.L2CAMPO6CheckBox.Checked = regBE.ICAMPO6.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO7"])
                        this.L2CAMPO7CheckBox.Checked = regBE.ICAMPO7.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO8"])
                        this.L2CAMPO8CheckBox.Checked = regBE.ICAMPO8.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO9"])
                        this.L2CAMPO9CheckBox.Checked = regBE.ICAMPO9.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO10"])
                        this.L2CAMPO10CheckBox.Checked = regBE.ICAMPO10.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO11"])
                        this.L2CAMPO11CheckBox.Checked = regBE.ICAMPO11.Trim().Equals("S");
                    if (!(bool)regBE.isnull["ICAMPO12"])
                        this.L2CAMPO12CheckBox.Checked = regBE.ICAMPO12.Trim().Equals("S");
                    

                    this.L2LBL_CAMPO1TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO1"]) ? regBE.ILBL_CAMPO1 : "";
                    this.L2LBL_CAMPO2TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO2"]) ? regBE.ILBL_CAMPO2 : "";
                    this.L2LBL_CAMPO3TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO3"]) ? regBE.ILBL_CAMPO3 : "";
                    this.L2LBL_CAMPO4TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO4"]) ? regBE.ILBL_CAMPO4 : "";
                    this.L2LBL_CAMPO5TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO5"]) ? regBE.ILBL_CAMPO5 : "";
                    this.L2LBL_CAMPO6TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO6"]) ? regBE.ILBL_CAMPO6 : "";
                    this.L2LBL_CAMPO7TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO7"]) ? regBE.ILBL_CAMPO7 : "";
                    this.L2LBL_CAMPO8TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO8"]) ? regBE.ILBL_CAMPO8 : "";
                    this.L2LBL_CAMPO9TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO9"]) ? regBE.ILBL_CAMPO9 : "";
                    this.L2LBL_CAMPO10TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO10"]) ? regBE.ILBL_CAMPO10 : "";
                    this.L2LBL_CAMPO11TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO11"]) ? regBE.ILBL_CAMPO11 : "";
                    this.L2LBL_CAMPO12TextBox.Text = (!(bool)regBE.isnull["ILBL_CAMPO12"]) ? regBE.ILBL_CAMPO12 : "";

                }

            }
            catch
            {
                return false;
            }


            return true;
        }

        private bool LlenarDatosDeBaseComisionesXLista()
        {
            CCOMISIONPORLISTAD regD = new CCOMISIONPORLISTAD();
            CCOMISIONPORLISTABE regBE = null;
            
            try
            {
                regBE = regD.seleccionarCOMISIONPORLISTA(null);
                if (regBE != null)
                {

                    COMISIONPRECIO1TextBox.Text = regBE.IPRECIO1.ToString().Trim();
                    COMISIONPRECIO2TextBox.Text = regBE.IPRECIO2.ToString().Trim();
                    COMISIONPRECIO3TextBox.Text = regBE.IPRECIO3.ToString().Trim();
                    COMISIONPRECIO4TextBox.Text = regBE.IPRECIO4.ToString().Trim();
                    COMISIONPRECIO5TextBox.Text = regBE.IPRECIO5.ToString().Trim();
                    COMISIONPRECIOOTROTextBox.Text = regBE.IPRECIOOTRO.ToString().Trim();
                }

            }
            catch
            {
                return false;
            }


            return true;
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                m_paremtrosPrevios = CurrentUserID.CurrentParameters;

                bLlenandoDatosDeBase = true;
                DataTable dt = new DataTable();
                dt = DataTablesParaGrid.GetData(this.FbCommand1);
                if (dt.Rows.Count <= 0)
                    return false;
                this.NOMBRETextBox.Text = dt.Rows[0]["NOMBRE"].ToString().Trim();
                this.CALLETextBox.Text = dt.Rows[0]["CALLE"].ToString().Trim();

                this.NUMEROEXTERIORTextBox.Text = dt.Rows[0]["NUMEROEXTERIOR"].ToString().Trim();
                this.NUMEROINTERIORTextBox.Text = dt.Rows[0]["NUMEROINTERIOR"].ToString().Trim();

                this.COLONIATextBox.Text = dt.Rows[0]["COLONIA"].ToString().Trim();
                this.LOCALIDADTextBox.Text = dt.Rows[0]["LOCALIDAD"].ToString().Trim();

                if (dt.Rows[0]["ESTADO"] != DBNull.Value)
                {
                    this.ESTADOTextBox.SelectedDataDisplaying = dt.Rows[0]["ESTADO"].ToString().Trim();
                }
                else
                {
                    this.ESTADOTextBox.Text = "";
                }

                this.CPTextBox.Text = dt.Rows[0]["CP"].ToString().Trim();
                this.TELEFONOTextBox.Text = dt.Rows[0]["TELEFONO"].ToString().Trim();
                this.FAXTextBox.Text = dt.Rows[0]["FAX"].ToString().Trim();
                this.CORREOETextBox.Text = dt.Rows[0]["CORREOE"].ToString().Trim();
                this.PAGINAWEBTextBox.Text = dt.Rows[0]["PAGINAWEB"].ToString().Trim();
                this.RFCTextBox.Text = dt.Rows[0]["RFC"].ToString().Trim();
                this.LISTA_PRECIO_DEFTextBox.Text = dt.Rows[0]["LISTA_PRECIO_DEF"].ToString().Trim();
                this.IMP_PROD_DEFTextBox.Text = dt.Rows[0]["IMP_PROD_DEF"].ToString().Trim();



                if (dt.Rows[0]["ESTADO_DEF"] != DBNull.Value)
                {
                    this.ESTADO_DEFTextBox.SelectedDataDisplaying = dt.Rows[0]["ESTADO_DEF"].ToString().Trim();
                }
                else
                {
                    this.ESTADO_DEFTextBox.Text = "";
                }


                //this.SucursalComboBox.SelectedText = dt.Rows[0]["SUCURSALNUMERO"].ToString();
                this.SucursalComboBox.SelectedDataValue= (dt.Rows[0]["SUCURSALID"]);


                this.UltimaFecha.Value = (DateTime)(dt.Rows[0]["FECHAULTIMA"]);
                this.ID_DOSLETRASTextBox.Text = dt.Rows[0]["ID_DOSLETRAS"].ToString().Trim();
                this.HABILITAR_IMPEXP_AUTComboBox.Text = dt.Rows[0]["HABILITAR_IMPEXP_AUT"].ToString().Trim();

                this.HAB_SEL_CLIENTEComboBox.Text = dt.Rows[0]["HAB_SEL_CLIENTE"].ToString().Trim();

                this.HAB_IMPR_COTIZACIONComboBox.Text = dt.Rows[0]["HAB_IMPR_COTIZACION"].ToString().Trim();

                this.FTPHOSTTextBox.Text = (dt.Rows[0]["FTPHOST"] == DBNull.Value) ? "" : dt.Rows[0]["FTPHOST"].ToString().Trim();
                this.FTPUSUARIOTextBox.Text = (dt.Rows[0]["FTPUSUARIO"] == DBNull.Value) ? "" : dt.Rows[0]["FTPUSUARIO"].ToString().Trim();
                this.FTPPASSWORDTextBox.Text = (dt.Rows[0]["FTPPASSWORD"] == DBNull.Value) ? "" : dt.Rows[0]["FTPPASSWORD"].ToString().Trim();
                this.SMTPHOSTTextBox.Text = (dt.Rows[0]["SMTPHOST"] == DBNull.Value) ? "" : dt.Rows[0]["SMTPHOST"].ToString().Trim();
                this.SMTPUSUARIOTextBox.Text = (dt.Rows[0]["SMTPUSUARIO"] == DBNull.Value) ? "" : dt.Rows[0]["SMTPUSUARIO"].ToString().Trim();
                this.SMTPPASSWORDTextBox.Text = (dt.Rows[0]["SMTPPASSWORD"] == DBNull.Value) ? "" : dt.Rows[0]["SMTPPASSWORD"].ToString().Trim();
                this.SMTPPORTTextBox.Text = (dt.Rows[0]["SMTPPORT"] == DBNull.Value) ? "" : dt.Rows[0]["SMTPPORT"].ToString().Trim();
                this.SMTPMAILFROMTextBox.Text = (dt.Rows[0]["SMTPMAILFROM"] == DBNull.Value) ? "" : dt.Rows[0]["SMTPMAILFROM"].ToString().Trim();
                this.SMTPMAILTOTextBox.Text = (dt.Rows[0]["SMTPMAILTO"] == DBNull.Value) ? "" : dt.Rows[0]["SMTPMAILTO"].ToString().Trim();
                this.MAILTOINVENTARIOTextBox.Text = (dt.Rows[0]["MAILTOINVENTARIO"] == DBNull.Value) ? "" : dt.Rows[0]["MAILTOINVENTARIO"].ToString().Trim();
                this.FTPFOLDERTextBox.Text = (dt.Rows[0]["FTPFOLDER"] == DBNull.Value) ? "" : dt.Rows[0]["FTPFOLDER"].ToString().Trim();
                this.FTPFOLDERPASSTextBox.Text = (dt.Rows[0]["FTPFOLDERPASS"] == DBNull.Value) ? "" : dt.Rows[0]["FTPFOLDERPASS"].ToString().Trim();
                this.SMTPSSLComboBox.Text = dt.Rows[0]["SMTPSSL"].ToString().Trim();

                this.CBCambiarPrecio.Text = dt.Rows[0]["CAMBIARPRECIO"].ToString().Trim();

                this.HEADERTextBox.Text = (dt.Rows[0]["HEADER"] == DBNull.Value) ? "" : dt.Rows[0]["HEADER"].ToString().Trim();
                this.FOOTERTextBox.Text = (dt.Rows[0]["FOOTER"] == DBNull.Value) ? "" : dt.Rows[0]["FOOTER"].ToString().Trim();



                this.COMISIONMEDICOTextBox.Text = dt.Rows[0]["COMISIONMEDICO"].ToString().Trim();
                this.COMISIONDEPENDIENTETextBox.Text = dt.Rows[0]["COMISIONDEPENDIENTE"].ToString().Trim();

                this.cancelXActNumericTextBox.Text = dt.Rows[0]["NUMCANCELACTAUTO"].ToString().Trim();


                this.PORC_COMISIONENCARGADOTextBox.Text = dt.Rows[0]["PORC_COMISIONENCARGADO"].ToString().Trim();
                this.PORC_COMISIONVENDEDORTextBox.Text = dt.Rows[0]["PORC_COMISIONVENDEDOR"].ToString().Trim();


                this.MOSTRAR_EXIS_SUCComboBox.Text = dt.Rows[0]["MOSTRAR_EXIS_SUC"].ToString().Trim();

                this.REQ_APROBACION_INVComboBox.Text = dt.Rows[0]["REQ_APROBACION_INV"].ToString().Trim();

                this.REABRIRCORTESComboBox.Text = dt.Rows[0]["REABRIRCORTES"].ToString().Trim();


                this.DESCUENTOVALETextBox.Text = dt.Rows[0]["DESCUENTOVALE"].ToString().Trim();


                this.IMP_PROD_TOTALComboBox.Text = dt.Rows[0]["IMP_PROD_TOTAL"].ToString().Trim();

                this.TEXTO1TextBox.Text = dt.Rows[0]["TEXTO1"].ToString().Trim();

                this.TEXTO2TextBox.Text = dt.Rows[0]["TEXTO2"].ToString().Trim();
                this.TEXTO3TextBox.Text = dt.Rows[0]["TEXTO3"].ToString().Trim();
                this.TEXTO4TextBox.Text = dt.Rows[0]["TEXTO4"].ToString().Trim();
                this.TEXTO5TextBox.Text = dt.Rows[0]["TEXTO5"].ToString().Trim();
                this.TEXTO6TextBox.Text = dt.Rows[0]["TEXTO6"].ToString().Trim();


                this.NUMERO1TextBox.Text = dt.Rows[0]["NUMERO1"].ToString().Trim();
                this.NUMERO2TextBox.Text = dt.Rows[0]["NUMERO2"].ToString().Trim();
                this.NUMERO3TextBox.Text = dt.Rows[0]["NUMERO3"].ToString().Trim();
                this.NUMERO4TextBox.Text = dt.Rows[0]["NUMERO4"].ToString().Trim();


                this.FECHA1TextBox.Text = dt.Rows[0]["FECHA1"].ToString().Trim();
                this.FECHA2TextBox.Text = dt.Rows[0]["FECHA2"].ToString().Trim();


                this.FISCALCALLETextBox.Text = dt.Rows[0]["FISCALCALLE"].ToString().Trim();
                this.FISCALNUMEROINTERIORTextBox.Text = dt.Rows[0]["FISCALNUMEROINTERIOR"].ToString().Trim();
                this.FISCALNUMEROEXTERIORTextBox.Text = dt.Rows[0]["FISCALNUMEROEXTERIOR"].ToString().Trim();
                this.FISCALCOLONIATextBox.Text = dt.Rows[0]["FISCALCOLONIA"].ToString().Trim();
                this.FISCALMUNICIPIOTextBox.Text = dt.Rows[0]["FISCALMUNICIPIO"].ToString().Trim();


                if (dt.Rows[0]["FISCALESTADO"] != DBNull.Value)
                {
                    this.FISCALESTADOTextBox.SelectedDataDisplaying = dt.Rows[0]["FISCALESTADO"].ToString().Trim();
                }
                else
                {
                    this.FISCALESTADOTextBox.Text = "";
                }


                this.FISCALCODIGOPOSTALTextBox.Text = dt.Rows[0]["FISCALCODIGOPOSTAL"].ToString().Trim();

                this.CERTIFICADOCSDTextBox.Text = dt.Rows[0]["CERTIFICADOCSD"].ToString().Trim();
                this.TIMBRADOUSERTextBox.Text = dt.Rows[0]["TIMBRADOUSER"].ToString().Trim();
                this.TIMBRADOPASSWORDTextBox.Text = dt.Rows[0]["TIMBRADOPASSWORD"].ToString().Trim();
                this.TIMBRADOARCHIVOCERTIFICADOTextBox.Text = dt.Rows[0]["TIMBRADOARCHIVOCERTIFICADO"].ToString().Trim();
                this.TIMBRADOARCHIVOKEYTextBox.Text = dt.Rows[0]["TIMBRADOARCHIVOKEY"].ToString().Trim();
                this.TIMBRADOKEYTextBox.Text = dt.Rows[0]["TIMBRADOKEY"].ToString().Trim();
                this.FISCALNOMBRETextBox.Text = dt.Rows[0]["FISCALNOMBRE"].ToString().Trim();

                this.SERIESATTextBox.Text = dt.Rows[0]["SERIESAT"].ToString().Trim();

                this.USARFISCALESENEXPEDICIONCheckBox.Checked = (dt.Rows[0]["USARFISCALESENEXPEDICION"].ToString().Trim() == "S");

                GENERARFECheckBox.Checked = dt.Rows[0]["GENERARFE"].ToString().Trim().Equals("S");

                this.HAB_FACTURAELECTRONICAComboBox.Text = dt.Rows[0]["HAB_FACTURAELECTRONICA"].ToString().Trim();
                this.FOOTERVENTAAPARTADOTextBox.Text = (dt.Rows[0]["FOOTERVENTAAPARTADO"] == DBNull.Value) ? "" : dt.Rows[0]["FOOTERVENTAAPARTADO"].ToString().Trim();

                this.SERIESATDEVOLUCIONTextBox.Text = dt.Rows[0]["SERIESATDEVOLUCION"].ToString().Trim();

                this.CAMBIARPRECIOXUEMPAQUEComboBox.Text = dt.Rows[0]["CAMBIARPRECIOXUEMPAQUE"].ToString().Trim();
                this.CAMBIARPRECIOXPZACAJAComboBox.Text = dt.Rows[0]["CAMBIARPRECIOXPZACAJA"].ToString().Trim();

                this.PREFIJOBASCULATextBox.Text = dt.Rows[0]["PREFIJOBASCULA"].ToString().Trim();
                this.LONGPRODBASCULATextBox.Text = dt.Rows[0]["LONGPRODBASCULA"].ToString().Trim();
                this.LONGPESOBASCULATextBox.Text = dt.Rows[0]["LONGPESOBASCULA"].ToString().Trim();

                if (dt.Rows[0]["LISTAPRECIOXUEMPAQUE"] != null)
                {
                    this.LISTAPRECIOXUEMPAQUEComboBox.Text = dt.Rows[0]["LISTAPRECIOXUEMPAQUE"].ToString();
                }
                if (dt.Rows[0]["LISTAPRECIOXPZACAJA"] != null)
                {
                    this.LISTAPRECIOXPZACAJAComboBox.Text = dt.Rows[0]["LISTAPRECIOXPZACAJA"].ToString();
                }


                if (dt.Rows[0]["LISTAPRECIOINIMAYO"] != null)
                {
                    this.LISTAPRECIOINIMAYOComboBox.Text = dt.Rows[0]["LISTAPRECIOINIMAYO"].ToString();
                }

                if (dt.Rows[0]["LISTAPRECIOMAYLINEA"] != null)
                {
                    this.LISTAPRECIOMAYLINEAComboBox.Text = dt.Rows[0]["LISTAPRECIOMAYLINEA"].ToString();
                }

                if (dt.Rows[0]["LISTAPRECMEDMAYLINEA"] != null)
                {
                    this.LISTAPRECMEDMAYLINEAComboBox.Text = dt.Rows[0]["LISTAPRECMEDMAYLINEA"].ToString();
                }


                this.HAYVENDEDORPISOComboBox.Text = dt.Rows[0]["HAYVENDEDORPISO"].ToString().Trim();


                this.ENVIOAUTOMATICOEXISTENCIASComboBox.Text = dt.Rows[0]["ENVIOAUTOMATICOEXISTENCIAS"].ToString().Trim();




                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["ENCARGADOID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.ENCARGADOIDTextBox.DbValue = bufferLong.ToString();
                        this.ENCARGADOIDTextBox.MostrarErrores = false;
                        this.ENCARGADOIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.ENCARGADOIDTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }


                this.MONEDEROAPLICARComboBox.Text = dt.Rows[0]["MONEDEROAPLICAR"].ToString().Trim();
                this.MONEDEROCADUCIDADTextBox.Text = dt.Rows[0]["MONEDEROCADUCIDAD"].ToString().Trim();
                this.MONEDEROMONTOMINIMOTextBox.Text = dt.Rows[0]["MONEDEROMONTOMINIMO"].ToString().Trim();


                this.IMPRIMIRNUMEROPIEZASComboBox.Text = dt.Rows[0]["IMPRIMIRNUMEROPIEZAS"].ToString().Trim();


                this.PACNOMBRETextBox.Text = dt.Rows[0]["PACNOMBRE"].ToString().Trim();
                this.PACUSUARIOTextBox.Text = dt.Rows[0]["PACUSUARIO"].ToString().Trim();

                this.CORTEPORMAILTextBox.Text = dt.Rows[0]["CORTEPORMAIL"].ToString().Trim();
                //this.PRECIOREALTRASLADOSTextBox.Text = dt.Rows[0]["PRECIOREALTRASLADOS"].ToString().Trim();

                this.RUTAREPORTESTextBox.Text = dt.Rows[0]["RUTAREPORTES"].ToString().Trim();

                this.RUTAREPORTESSISTEMATextBox.Text = dt.Rows[0]["RUTAREPORTESSISTEMA"].ToString().Trim();

                this.txtRutaRespaldo.Text = dt.Rows[0]["RUTARESPALDO"].ToString().Trim();

                this.txtRutaAdjuntarArchivo.Text = dt.Rows[0]["RUTAARCHIVOSADJUNTOS"].ToString().Trim();


                this.DOBLECOPIACREDITOTextBox.Text = dt.Rows[0]["DOBLECOPIACREDITO"].ToString().Trim();
                this.DOBLECOPIATRASLADOTextBox.Text = dt.Rows[0]["DOBLECOPIATRASLADO"].ToString().Trim();
                this.CAMPOSCUSTOMALIMPORTARTextBox.Text = dt.Rows[0]["CAMPOSCUSTOMALIMPORTAR"].ToString().Trim();

                this.RECIBOLARGOPRINTERTextBox.Text = dt.Rows[0]["RECIBOLARGOPRINTER"].ToString().Trim();
                this.RECIBOLARGOPREVIEWComboBox.Text = dt.Rows[0]["RECIBOLARGOPREVIEW"].ToString().Trim();
                this.RECIBOLARGOCONFACTURAComboBox.Text = dt.Rows[0]["RECIBOLARGOCONFACTURA"].ToString().Trim();

                this.PREGUNTARRAZONPRECIOMENORComboBox.Text = dt.Rows[0]["PREGUNTARRAZONPRECIOMENOR"].ToString().Trim();
                this.PREGUNTARDATOSENTREGAComboBox.Text = dt.Rows[0]["PREGUNTARDATOSENTREGA"].ToString().Trim();

                
                this.MOSTRARPZACAJAENFACTURAComboBox.Text = dt.Rows[0]["MOSTRARPZACAJAENFACTURA"].ToString().Trim();


                this.FISCALREGIMENTextBox.Text = dt.Rows[0]["FISCALREGIMEN"].ToString().Trim();

                this.CORTACADUCIDADTextBox.Text = dt.Rows[0]["CORTACADUCIDAD"].ToString().Trim();


                this.RETENCIONIVATextBox.Text = dt.Rows[0]["RETENCIONIVA"].ToString().Trim();
                this.RETENCIONISRTextBox.Text = dt.Rows[0]["RETENCIONISR"].ToString().Trim();
                this.ARRENDATARIOCheckBox.Checked = (dt.Rows[0]["ARRENDATARIO"].ToString().Trim() == "S");


                this.RUTAIMAGENESPRODUCTOTextBox.Text = dt.Rows[0]["RUTAIMAGENESPRODUCTO"].ToString().Trim();

                this.MOSTRARIMAGENENVENTATextBox.Text = dt.Rows[0]["MOSTRARIMAGENENVENTA"].ToString().Trim();


                this.MOSTRARMONTOAHORROComboBox.Text = dt.Rows[0]["MOSTRARMONTOAHORRO"].ToString().Trim();

                this.MOSTRARDESCUENTOFACTURAComboBox.Text = dt.Rows[0]["MOSTRARDESCUENTOFACTURA"].ToString().Trim();


                this.EXPORTCATALOGOAUXTextBox.Text = dt.Rows[0]["EXPORTCATALOGOAUX"].ToString().Trim();


                this.UIVENTACONCANTIDADComboBox.Text = dt.Rows[0]["UIVENTACONCANTIDAD"].ToString().Trim();

                this.FACT_ELECT_FOLDERTextBox.Text = dt.Rows[0]["FACT_ELECT_FOLDER"].ToString().Trim();
                this.PEDIDOS_FOLDERTextBox.Text = dt.Rows[0]["PEDIDOS_FOLDER"].ToString().Trim();

                this.PREFIJOCLIENTETextBox.Text = dt.Rows[0]["PREFIJOCLIENTE"].ToString().Trim();


                this.DESGLOSEIEPSTextBox.Checked = (dt.Rows[0]["DESGLOSEIEPS"].ToString().Trim() == "S");
                this.CUENTAIEPSTextBox.Text = dt.Rows[0]["CUENTAIEPS"].ToString().Trim();

                this.DIVIDIR_REM_FACTTextBox.Text = dt.Rows[0]["DIVIDIR_REM_FACT"].ToString().Trim();

                this.AUTPRECIOLISTABAJOTextBox.Text = dt.Rows[0]["AUTPRECIOLISTABAJO"].ToString().Trim();

                this.WEBSERVICETextBox.Text = dt.Rows[0]["WEBSERVICE"].ToString().Trim();

                this.MINUTILIDADTextBox.Text = dt.Rows[0]["MINUTILIDAD"].ToString().Trim();

                this.MANEJASUPERLISTAPRECIOTextBox.Text = dt.Rows[0]["MANEJASUPERLISTAPRECIO"].ToString().Trim();

                this.MANEJAALMACENTextBox.Text = dt.Rows[0]["MANEJAALMACEN"].ToString().Trim();

                this.rdbtnEmidaServices.Checked = (dt.Rows[0]["SERVICIOSEMIDA"].ToString().Trim() == "S");

                this.HABPAGOSERVEMIDACheckBox.Checked = (dt.Rows[0]["HABPAGOSERVEMIDA"].ToString().Trim() == "S");

                this.BANCOMERHABPINPADCheckBox.Checked = (dt.Rows[0]["BANCOMERHABPINPAD"].ToString().Trim() == "S");


                this.cbPlazosXProducto.Checked = (dt.Rows[0]["PLAZOXPRODUCTO"].ToString().Trim() == "S");

                this.MANEJACUPONESCheckBox.Checked = (dt.Rows[0]["MANEJACUPONES"].ToString().Trim() == "S");


                if (dt.Rows[0]["TIMEOUTPINDISTSALE"] != DBNull.Value)
                {
                    this.nudTimeOutPin.Value = int.Parse(dt.Rows[0]["TIMEOUTPINDISTSALE"].ToString().Trim());
                }


                if (dt.Rows[0]["TIMEOUTPINDISTSALESERV"] != DBNull.Value)
                {
                    this.TIMEOUTPINTDISTSALESERVTextBox.Value = int.Parse(dt.Rows[0]["TIMEOUTPINDISTSALESERV"].ToString().Trim());
                }


                if (dt.Rows[0]["TIMEOUTLOOKUP"] != DBNull.Value)
                {

                    this.nudTimeOutLookUp.Value = int.Parse(dt.Rows[0]["TIMEOUTLOOKUP"].ToString().Trim());
                }


                if (dt.Rows[0]["TIPODESCUENTOPRODID"] != DBNull.Value)
                {
                    try
                    {
                        this.TIPODESCUENTOPRODIDTextBox.SelectedDataValue = long.Parse(dt.Rows[0]["TIPODESCUENTOPRODID"].ToString().Trim());
                    }
                    catch
                    {
                        this.TIPODESCUENTOPRODIDTextBox.SelectedDataValue = 0; 
                        this.TIPODESCUENTOPRODIDTextBox.Text = "";
                    }
                }
                else
                {
                    this.TIPODESCUENTOPRODIDTextBox.SelectedDataValue = 0;
                    this.TIPODESCUENTOPRODIDTextBox.Text = "";
                }


                this.MANEJARECETATextBox.Text = dt.Rows[0]["MANEJARECETA"].ToString().Trim();
                this.TOUCHTextBox.Text = dt.Rows[0]["TOUCH"].ToString().Trim();
                this.ESVENDEDORMOVILTextBox.Text = dt.Rows[0]["ESVENDEDORMOVIL"].ToString().Trim();
                this.TIPOSYNCMOVILTextBox.Text = dt.Rows[0]["TIPOSYNCMOVIL"].ToString().Trim();
                this.AUTOCOMPPRODTextBox.Text = dt.Rows[0]["AUTOCOMPPROD"].ToString().Trim();
                this.AUTOCOMPCLIENTETextBox.Text = dt.Rows[0]["AUTOCOMPCLIENTE"].ToString().Trim();



                this.MANEJAQUOTATextBox.Text = dt.Rows[0]["MANEJAQUOTA"].ToString().Trim();
                if (dt.Rows[0]["TIPOUTILIDADID"] != DBNull.Value)
                {
                    try
                    {
                        this.TIPOUTILIDADIDTextBox.SelectedDataValue = long.Parse(dt.Rows[0]["TIPOUTILIDADID"].ToString().Trim());
                    }
                    catch
                    {
                        this.TIPOUTILIDADIDTextBox.SelectedDataValue = 0;
                        this.TIPOUTILIDADIDTextBox.Text = "";
                    }
                }
                else
                {
                    this.TIPOUTILIDADIDTextBox.SelectedDataValue = 0;
                    this.TIPOUTILIDADIDTextBox.Text = "";
                }


                this.CAJASBOTELLASTextBox.Text = dt.Rows[0]["CAJASBOTELLAS"].ToString().Trim();
                this.PRECIONETOENPVTextBox.Text = dt.Rows[0]["PRECIONETOENPV"].ToString().Trim();

                this.MOSTRARFLASHComboBox.Text = dt.Rows[0]["MOSTRARFLASH"].ToString().Trim();
                this.ORDENIMPRESIONComboBox.Text = dt.Rows[0]["ORDENIMPRESION"].ToString().Trim();

                this.PRECIOXCAJAENPVTextBox.Text = dt.Rows[0]["PRECIOXCAJAENPV"].ToString().Trim();


                this.LOCALFTPHOSTTextBox.Text = (dt.Rows[0]["LOCALFTPHOST"] == DBNull.Value) ? "" : dt.Rows[0]["LOCALFTPHOST"].ToString().Trim();
                this.LOCALWEBSERVICETextBox.Text = (dt.Rows[0]["LOCALWEBSERVICE"] == DBNull.Value) ? "" : dt.Rows[0]["LOCALWEBSERVICE"].ToString().Trim();
                this.USARCONEXIONLOCALTextBox.Text = dt.Rows[0]["USARCONEXIONLOCAL"].ToString().Trim();

                this.RUTARESPALDOSZIPTextBox.Text = (dt.Rows[0]["RUTARESPALDOSZIP"] == DBNull.Value) ? "" : dt.Rows[0]["RUTARESPALDOSZIP"].ToString().Trim();

                try
                {
                    this.SCREENCONFIGTextBox.SelectedIndex = (dt.Rows[0]["SCREENCONFIG"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["SCREENCONFIG"].ToString().Trim());
                }
                catch
                {
                    this.SCREENCONFIGTextBox.SelectedIndex = 0;
                }


                this.PROMOENTICKETComboBox.Text = dt.Rows[0]["PROMOENTICKET"].ToString().Trim();

                try
                {
                    this.TAMANOLETRATICKETTextBox.SelectedIndex = (dt.Rows[0]["TAMANOLETRATICKET"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["TAMANOLETRATICKET"].ToString().Trim());
                }
                catch
                {
                    this.TAMANOLETRATICKETTextBox.SelectedIndex = 0;
                }

                this.MANEJAKITSTextBox.Text = dt.Rows[0]["MANEJAKITS"].ToString().Trim();


                this.CAMPOIMPOCOSTOREPOTextBox.SelectedIndex = dt.Rows[0]["CAMPOIMPOCOSTOREPO"] != DBNull.Value ? int.Parse(dt.Rows[0]["CAMPOIMPOCOSTOREPO"].ToString().Trim()) : 0;


                if (dt.Rows[0]["LISTAPRECIOMINIMO"] != null)
                {
                    this.LISTAPRECIOMINIMOComboBox.Text = dt.Rows[0]["LISTAPRECIOMINIMO"].ToString();
                }


                this.REBAJAESPECIALTextBox.Text = dt.Rows[0]["REBAJAESPECIAL"].ToString().Trim();


                this.HABILITARREPLTextBox.Text = dt.Rows[0]["HABILITARREPL"].ToString().Trim();
                this.BDLOCALREPLTextBox.Text = (dt.Rows[0]["BDLOCALREPL"] == DBNull.Value) ? "" : dt.Rows[0]["BDLOCALREPL"].ToString().Trim();

                this.PENDMOVILANTESVENTATextBox.Text = dt.Rows[0]["PENDMOVILANTESVENTA"].ToString().Trim();
                this.PRECIOSMOVILANTESVENTATextBox.Text = dt.Rows[0]["PRECIOSMOVILANTESVENTA"].ToString().Trim();
                this.RECALCULARCAMBIOCLIENTETextBox.Text = dt.Rows[0]["RECALCULARCAMBIOCLIENTE"].ToString().Trim();

                 
                try
                {
                    this.TIPOVENDEDORMOVILTextBox.SelectedIndex = (dt.Rows[0]["TIPOVENDEDORMOVIL"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["TIPOVENDEDORMOVIL"].ToString().Trim());
                }
                catch
                {
                    this.TIPOVENDEDORMOVILTextBox.SelectedIndex = 0;
                }

                this.BDSERVERWSTextBox.Text = (dt.Rows[0]["BDSERVERWS"] == DBNull.Value) ? "" : dt.Rows[0]["BDSERVERWS"].ToString().Trim();

                this.BDMATRIZMOVILTextBox.Text = (dt.Rows[0]["BDMATRIZMOVIL"] == DBNull.Value) ? "" : dt.Rows[0]["BDMATRIZMOVIL"].ToString().Trim();


                this.txtIPWsAppInventario.Text = (dt.Rows[0]["IPWEBSERVICEAPPINV"] == DBNull.Value) ? "" : dt.Rows[0]["IPWEBSERVICEAPPINV"].ToString().Trim();

                this.txtRutaBDAppInventario.Text = (dt.Rows[0]["RUTABDAPPINVENTARO"] == DBNull.Value) ? "" : dt.Rows[0]["RUTABDAPPINVENTARO"].ToString().Trim();
                
                this.txtRutaDBFExistenciaSuc.Text = (dt.Rows[0]["RUTADBFEXISTENCIASUC"] == DBNull.Value) ? "" : dt.Rows[0]["RUTADBFEXISTENCIASUC"].ToString().Trim();

                this.MOVILVERIFICARVENTAComboBox.Text = dt.Rows[0]["MOVILVERIFICARVENTA"].ToString().Trim();

                this.PENDMAXDIASTextBox.Text = dt.Rows[0]["PENDMAXDIAS"].ToString().Trim();


                this.REQAUTCANCELARCOTIComboBox.Text = dt.Rows[0]["REQAUTCANCELARCOTI"].ToString().Trim();

                this.REQAUTELIMDETALLECOTIComboBox.Text = dt.Rows[0]["REQAUTELIMDETALLECOTI"].ToString().Trim();

                this.ABRIRCAJONALFINCORTEComboBox.Text = dt.Rows[0]["ABRIRCAJONALFINCORTE"].ToString().Trim();


                this.HABSURTIDOPOSTPUESTOTextBox.Text = dt.Rows[0]["HABSURTIDOPOSTPUESTO"].ToString().Trim();

                this.HABVERIFICACIONCXCTextBox.Text = dt.Rows[0]["HABVERIFICACIONCXC"].ToString().Trim();

                this.MONTOMAXSALDOMENORNumericTextBox.NumericValue = (dt.Rows[0]["MONTOMAXSALDOMENOR"] == DBNull.Value) ? 0 : decimal.Parse(dt.Rows[0]["MONTOMAXSALDOMENOR"].ToString().Trim()); ;


                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["CLIENTECONSOLIDADOID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.CLIENTECONSOLIDADOIDTextBox.DbValue = bufferLong.ToString();
                        this.CLIENTECONSOLIDADOIDTextBox.MostrarErrores = false;
                        this.CLIENTECONSOLIDADOIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.CLIENTECONSOLIDADOIDTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }



                this.DOBLECOPIAREMISIONComboBox.Text = dt.Rows[0]["DOBLECOPIAREMISION"].ToString().Trim();
                this.REIMPRESIONESCONMARCAComboBox.Text = dt.Rows[0]["REIMPRESIONESCONMARCA"].ToString().Trim();

                this.HABTOTALIZADOSTextBox.Text = dt.Rows[0]["HABTOTALIZADOS"].ToString().Trim();


                this.MULTIPLETIPOVALETextBox.Text = dt.Rows[0]["MULTIPLETIPOVALE"].ToString().Trim();
                this.DESCUENTOTIPO1TEXTOTextBox.Text = dt.Rows[0]["DESCUENTOTIPO1TEXTO"].ToString().Trim();
                this.DESCUENTOTIPO2TEXTOTextBox.Text = dt.Rows[0]["DESCUENTOTIPO2TEXTO"].ToString().Trim();
                this.DESCUENTOTIPO3TEXTOTextBox.Text = dt.Rows[0]["DESCUENTOTIPO3TEXTO"].ToString().Trim();
                this.DESCUENTOTIPO4TEXTOTextBox.Text = dt.Rows[0]["DESCUENTOTIPO4TEXTO"].ToString().Trim();

                this.DESCUENTOTIPO1PORCTextBox.Text = dt.Rows[0]["DESCUENTOTIPO1PORC"].ToString().Trim();
                this.DESCUENTOTIPO2PORCTextBox.Text = dt.Rows[0]["DESCUENTOTIPO2PORC"].ToString().Trim();
                this.DESCUENTOTIPO3PORCTextBox.Text = dt.Rows[0]["DESCUENTOTIPO3PORC"].ToString().Trim();
                this.DESCUENTOTIPO4PORCTextBox.Text = dt.Rows[0]["DESCUENTOTIPO4PORC"].ToString().Trim();



                this.HABILITARLOGComboBox.Text = dt.Rows[0]["HABILITARLOG"].ToString().Trim();


                this.MONTORETIROCAJATextBox.Text = dt.Rows[0]["MONTORETIROCAJA"].ToString().Trim();
                this.MANEJARRETIRODECAJATextBox.Text = dt.Rows[0]["MANEJARRETIRODECAJA"].ToString().Trim();



                this.APLICARMAYOREOPORLINEATextBox.Text = dt.Rows[0]["APLICARMAYOREOPORLINEA"].ToString().Trim();
                this.COMISIONPORTARJETATextBox.Text = dt.Rows[0]["COMISIONPORTARJETA"].ToString().Trim();
                this.COMISIONDEBPORTARJETATextBox.Text = dt.Rows[0]["COMISIONDEBPORTARJETA"].ToString().Trim();
                this.PIEZASIGUALESMEDIOMAYOREOTextBox.Text = dt.Rows[0]["PIEZASIGUALESMEDIOMAYOREO"].ToString().Trim();
                this.PIEZASDIFMEDIOMAYOREOTextBox.Text = dt.Rows[0]["PIEZASDIFMEDIOMAYOREO"].ToString().Trim();
                this.PIEZASIGUALESMAYOREOTextBox.Text = dt.Rows[0]["PIEZASIGUALESMAYOREO"].ToString().Trim();
                this.PIEZASDIFMAYOREOTextBox.Text = dt.Rows[0]["PIEZASDIFMAYOREO"].ToString().Trim();


                this.COMISIONTARJETAEMPRESATextBox.Text = dt.Rows[0]["COMISIONTARJETAEMPRESA"].ToString().Trim();
                this.IVACOMISIONTARJETAEMPRESATextBox.Text = dt.Rows[0]["IVACOMISIONTARJETAEMPRESA"].ToString().Trim();


                this.COMISIONDEBTARJETAEMPRESATextBox.Text = dt.Rows[0]["COMISIONDEBTARJETAEMPRESA"].ToString().Trim();
                
                /*if (this.APLICARMAYOREOPORLINEATextBox.Text.Equals("S"))
                {

                    CAMBIARPRECIOXPZACAJAComboBox.Enabled = false;
                    LISTAPRECIOXPZACAJAComboBox.Enabled = false;
                    CAMBIARPRECIOXUEMPAQUEComboBox.Enabled = false;
                    LISTAPRECIOXUEMPAQUEComboBox.Enabled = false;
                }*/


                this.PREGUNTACANCELACOTIZACIONTextBox.Text = dt.Rows[0]["PREGUNTACANCELACOTIZACION"].ToString().Trim();

                this.MAILEJECUTIVOTextBox.Text = (dt.Rows[0]["MAILEJECUTIVO"] == DBNull.Value) ? "" : dt.Rows[0]["MAILEJECUTIVO"].ToString().Trim();


                this.VENTASXCORTEEMAILTextBox.Text = dt.Rows[0]["VENTASXCORTEEMAIL"].ToString().Trim();


                this.HABVENTASAFUTUROComboBox.Text = dt.Rows[0]["HABVENTASAFUTURO"].ToString().Trim();

                try
                {

                    long bufferFormatoTicket = long.Parse(dt.Rows[0]["FORMATOTICKETCORTOID"].ToString());
                    if(bufferFormatoTicket > 0 && bufferFormatoTicket < FORMATOTICKETCORTOIDComboBox.Items.Count)
                    {
                        FORMATOTICKETCORTOIDComboBox.SelectedIndex = (int)bufferFormatoTicket;
                    }
                    else
                    {
                        FORMATOTICKETCORTOIDComboBox.SelectedIndex = 0;
                    }
                }
                catch(Exception ex)
                {
                    FORMATOTICKETCORTOIDComboBox.SelectedIndex = 0;
                }


                this.SERIESATABONOTextBox.Text = dt.Rows[0]["SERIESATABONO"].ToString().Trim();

                this.HABIMPRESIONCORTECAJEROComboBox.Text = dt.Rows[0]["HABIMPRESIONCORTECAJERO"].ToString().Trim();

                this.HABTRASLADOPORAUTORIZACIONComboBox.Text = dt.Rows[0]["HABTRASLADOPORAUTORIZACION"].ToString().Trim();


                this.HABPROMOXMONTOMINTextBox.Text = dt.Rows[0]["HABPROMOXMONTOMIN"].ToString().Trim();


                this.FORMATOFACTURAComboBox.Text = dt.Rows[0]["FORMATOFACTELECT"].ToString().Trim();

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["EMIDARECARGALINEAID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.LINEAIDRecTextBox.DbValue = bufferLong.ToString();
                        this.LINEAIDRecTextBox.MostrarErrores = false;
                        this.LINEAIDRecTextBox.MValidarEntrada(out strBuffer, 1);
                        this.LINEAIDRecTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["EMIDARECARGAMARCAID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.MARCAIDRecTextBox.DbValue = bufferLong.ToString();
                        this.MARCAIDRecTextBox.MostrarErrores = false;
                        this.MARCAIDRecTextBox.MValidarEntrada(out strBuffer, 1);
                        this.MARCAIDRecTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["EMIDARECARGAPROVEEDORID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.PROVEEDOR1IDRecTextBox.DbValue = bufferLong.ToString();
                        this.PROVEEDOR1IDRecTextBox.MostrarErrores = false;
                        this.PROVEEDOR1IDRecTextBox.MValidarEntrada(out strBuffer, 1);
                        this.PROVEEDOR1IDRecTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["EMIDASERVICIOLINEAID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.LINEAIDServTextBox.DbValue = bufferLong.ToString();
                        this.LINEAIDServTextBox.MostrarErrores = false;
                        this.LINEAIDServTextBox.MValidarEntrada(out strBuffer, 1);
                        this.LINEAIDServTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["EMIDASERVICIOMARCAID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.MARCAIDServTextBox.DbValue = bufferLong.ToString();
                        this.MARCAIDServTextBox.MostrarErrores = false;
                        this.MARCAIDServTextBox.MValidarEntrada(out strBuffer, 1);
                        this.MARCAIDServTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["EMIDASERVICIOPROVEEDORID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.PROVEEDOR1IDServTextBox.DbValue = bufferLong.ToString();
                        this.PROVEEDOR1IDServTextBox.MostrarErrores = false;
                        this.PROVEEDOR1IDServTextBox.MValidarEntrada(out strBuffer, 1);
                        this.PROVEEDOR1IDServTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    this.PRECIOSORDENADOSTextBox.Text = dt.Rows[0]["PRECIOSORDENADOS"].ToString().Trim();

                }
                catch
                {

                }

                try
                {

                    this.DECIMALESENCANTIDADTextBox.Text = dt.Rows[0]["DECIMALESENCANTIDAD"].ToString().Trim();
                }
                catch
                {

                }


                try
                {
                    this.EANPUEDEREPETIRSETextBox.Text = dt.Rows[0]["EANPUEDEREPETIRSE"].ToString().Trim();

                }
                catch
                {

                }

                this.txtPorcUtilidadRecargas.Text = dt.Rows[0]["EMIDAPORCUTILIDADRECARGAS"].ToString().Trim();

                this.txtUtilidadPagoServicio.Text = dt.Rows[0]["EMIDAUTILIDADPAGOSERVICIOS"].ToString().Trim();


                this.HAB_PRECIOSCLIENTETextBox.Text = dt.Rows[0]["HAB_PRECIOSCLIENTE"].ToString().Trim();




                try
                {
                    this.CXCVALIDARTRASLADOSTextBox.Text = dt.Rows[0]["CXCVALIDARTRASLADOS"].ToString().Trim();

                }
                catch
                {

                }


                try
                {
                    this.PREGUNTARSIESACREDITOTextBox.Text = dt.Rows[0]["PREGUNTARSIESACREDITO"].ToString().Trim();

                }
                catch
                {

                }



                try
                {
                    this.HABMENSAJERIAComboBox.Text = dt.Rows[0]["HABMENSAJERIA"].ToString().Trim();

                }
                catch
                {

                }

                this.WSMENSAJERIATextBox.Text = dt.Rows[0]["WSMENSAJERIA"].ToString().Trim();


                this.DESCUENTOLINEAPERSONACheckBox.Checked = (dt.Rows[0]["HABDESCLINEAPERSONA"].ToString().Trim() == "S");

                this.MANEJARLOTEIMPORTACIONCheckBox.Checked = (dt.Rows[0]["MANEJARLOTEIMPORTACION"].ToString().Trim() == "S");

                this.MANEJAGASTOSADICCheckBox.Checked = (dt.Rows[0]["MANEJAGASTOSADIC"].ToString().Trim() == "S");

                try
                {
                    string precioAjusteAux =  dt.Rows[0]["PRECIOAJUSTEDIFINV"].ToString().Trim();
                    switch(precioAjusteAux)
                    {
                        case "PRECIO 1":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 0;
                                break;
                            } 
                        case "PRECIO 2":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 1;
                                break;
                            }
                        case "PRECIO 3":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 2;
                                break;
                            }
                        case "PRECIO 4":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 3;
                                break;
                            }
                        case "PRECIO 5":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 4;
                                break;
                            }
                        case "COSTO ULTIMO":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 5;
                                break;
                            }
                        case "REPOSICION":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 6;
                                break;
                            }
                        case "SIN PRECIO":
                            {
                                this.cmbPrecioDifInv.SelectedIndex = 7;
                                break;
                            }
                        default:
                            break;
                    }
                }
                catch
                {

                }

                this.cbHabBtnPagoVale.Checked = (dt.Rows[0]["HABBOTONPAGOVALE"].ToString().Trim() == "S");
                this.CADUCIDADMINIMATextBox.Text = dt.Rows[0]["CADUCIDADMINIMA"].ToString();



                this.unicaVisitaPorDoctoCheckBox.Checked = (dt.Rows[0]["UNICAVISITAPORDOCTO"].ToString().Trim() == "S");

                this.autocompleteConExistenciaCB.Checked = (dt.Rows[0]["AUTOCOMPLETECONEXISENVENTA"].ToString().Trim() == "S");

                this.actPrecAutoCB.Checked = (dt.Rows[0]["APLICARCAMBIOSPRECAUTO"].ToString().Trim() == "S");


                if (dt.Rows[0]["ALMACENRECEPCIONID"] != DBNull.Value)
                {
                    try
                    {
                        this.ALMACENRECEPCIONIDTextBox.SelectedDataValue = long.Parse(dt.Rows[0]["ALMACENRECEPCIONID"].ToString().Trim());
                    }
                    catch
                    {
                        this.ALMACENRECEPCIONIDTextBox.SelectedDataValue = -1;
                        this.ALMACENRECEPCIONIDTextBox.Text = "";
                    }
                }
                else
                {
                    this.ALMACENRECEPCIONIDTextBox.SelectedIndex = -1;
                    this.ALMACENRECEPCIONIDTextBox.SelectedDataValue = 0;
                    this.ALMACENRECEPCIONIDTextBox.Text = "";
                }



                try
                {
                    this.HAB_DEVOLUCIONTRASLADOComboBox.Text = dt.Rows[0]["HAB_DEVOLUCIONTRASLADO"].ToString().Trim();

                }
                catch
                {

                }


                try
                {
                    this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Text = dt.Rows[0]["HAB_DEVOLUCIONSURTIDOSUC"].ToString().Trim();

                }
                catch
                {

                }

                try
                {

                    this.VERSIONWSEXISTENCIASTextBox.Text = dt.Rows[0]["VERSIONWSEXISTENCIAS"].ToString();
                }
                catch
                {

                }

                try
                {

                    this.MOSTRARINVINFOADICPRODTextBox.Text = dt.Rows[0]["MOSTRARINVINFOADICPROD"].ToString().Trim();
                }
                catch
                {

                }

                this.filtroProdSatComboBox.SelectedItem = dt.Rows[0]["TIPOSELECCIONCATALOGOSAT"].ToString().Trim();

                this.MANEJAPRODUCTOSPROMOCIONCheckBox.Checked = (dt.Rows[0]["MANEJAPRODUCTOSPROMOCION"].ToString().Trim() == "S");


                this.PRECIONETOENGRIDSTextBox.Text = dt.Rows[0]["PRECIONETOENGRIDS"].ToString().Trim();


                this.PAGOSERVCONSOLIDADOTextBox.Checked = (dt.Rows[0]["PAGOSERVCONSOLIDADO"].ToString().Trim() == "S");

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["SAT_METODOPAGOID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.METPAGOSATIDTextBox.DbValue = bufferLong.ToString();
                        this.METPAGOSATIDTextBox.MostrarErrores = false;
                        this.METPAGOSATIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.METPAGOSATIDTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {
                    long bufferLong;
                    string strBuffer = "";
                    bufferLong = long.Parse(dt.Rows[0]["SAT_REGIMENFISCALID"].ToString());
                    if (bufferLong > 0)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.REGIMENSATFBTextBox.DbValue = bufferLong.ToString();
                        this.REGIMENSATFBTextBox.MostrarErrores = false;
                        this.REGIMENSATFBTextBox.MValidarEntrada(out strBuffer, 1);
                        this.REGIMENSATFBTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }

                try
                {

                    this.WSESPECIALEXISTMATRIZTextBox.Text = dt.Rows[0]["WSESPECIALEXISTMATRIZ"].ToString().Trim();
                }
                catch
                {

                }


                try
                {

                    this.txtRutaReplicadorExe.Text = dt.Rows[0]["RUTAREPLICADOREXE"].ToString().Trim();
                }
                catch
                {

                }


                this.HAB_CONSOLIDADOAUTOMATICOCheckBox.Checked = (dt.Rows[0]["HAB_CONSOLIDADOAUTOMATICO"].ToString().Trim() == "S");

                try
                {

                    this.TICKETESPECIALTextBox.Text = dt.Rows[0]["TICKETESPECIAL"].ToString().Trim();
                }
                catch
                {

                }


                try
                {

                    this.TICKETDEFAULTPRINTERTextBox.Text = dt.Rows[0]["TICKETDEFAULTPRINTER"].ToString().Trim();
                }
                catch
                {

                }


                try
                {

                    this.RECARGASDEFAULTPRINTERTextBox.Text = dt.Rows[0]["RECARGASDEFAULTPRINTER"].ToString().Trim();
                }
                catch
                {

                }

                this.PIEZACAJAENTICKETComboBox.Text = dt.Rows[0]["PIEZACAJAENTICKET"].ToString().Trim();

                try
                {

                    this.NUMTICKETSABONOTextBox.Text = dt.Rows[0]["NUMTICKETSABONO"].ToString().Trim();
                }
                catch
                {

                }


                try
                {
                    int iPvColorear = 0;
                    if(int.TryParse(dt.Rows[0]["PVCOLOREAR"].ToString(), out iPvColorear))
                    {
                        this.PVCOLOREARTextBox.SelectedIndex = iPvColorear;
                    }
                    
                }
                catch
                {

                }


                try
                {

                    this.INTENTOSRETIROCAJATextBox.Text = dt.Rows[0]["INTENTOSRETIROCAJA"].ToString().Trim();
                }
                catch
                {

                }


                try
                {
                    string bufferStr;
                    string strBuffer = "";
                    bufferStr = dt.Rows[0]["VENDEDORMOVILCLAVE"].ToString();
                    if (bufferStr != null)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.VENDEDORMOVILCLAVETextBox.DbValue = bufferStr;
                        this.VENDEDORMOVILCLAVETextBox.MostrarErrores = false;
                        this.VENDEDORMOVILCLAVETextBox.MValidarEntrada(out strBuffer, 1);
                        this.VENDEDORMOVILCLAVETextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }


                this.MOVIL_TIENEVENDEDORESComboBox.Text = dt.Rows[0]["MOVIL_TIENEVENDEDORES"].ToString().Trim();


                this.RUTACATALOGOSUPDTextBox.Text = dt.Rows[0]["RUTACATALOGOSUPD"].ToString().Trim();


                this.IMPRIMIRCOPIAALMACENComboBox.Text = dt.Rows[0]["IMPRIMIRCOPIAALMACEN"].ToString().Trim();


                this.MOVIL3_PREIMPORTARCheckBox.Checked = (dt.Rows[0]["MOVIL3_PREIMPORTAR"].ToString().Trim() == "S");


                this.RUTAIMPORTADATOSTextBox.Text = dt.Rows[0]["RUTAIMPORTADATOS"].ToString().Trim();

                this.cbBusquedaTipo2.Checked = (dt.Rows[0]["BUSQUEDATIPO2"].ToString().Trim() == "S");

                this.VERSIONCFDITextBox.Text = dt.Rows[0]["VERSIONCFDI"].ToString().Trim() ;



                try
                {
                    string bufferStr;
                    string strBuffer = "";
                    bufferStr = dt.Rows[0]["AGRUPACIONVENTAID"].ToString();
                    if (bufferStr != null)
                    {
                        //this.ENCARGADOIDTextBox.Text = bufferLong.ToString();
                        this.AGRUPACIONVENTAIDTextBox.DbValue = bufferStr;
                        this.AGRUPACIONVENTAIDTextBox.MostrarErrores = false;
                        this.AGRUPACIONVENTAIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.AGRUPACIONVENTAIDTextBox.MostrarErrores = true;
                    }
                }
                catch
                {
                }


                this.CONSFACTOMITIRVALESCheckBox.Checked = (dt.Rows[0]["CONSFACTOMITIRVALES"].ToString().Trim() == "S");


                if(dt.Rows[0]["DESTINOBDVENMOV"] != null)
                    rutaBdVenMovTextBox.Text = dt.Rows[0]["DESTINOBDVENMOV"].ToString().Trim();



                this.DESGLOSEIEPSFACTURATextBox.Checked = (dt.Rows[0]["DESGLOSEIEPSFACTURA"].ToString().Trim() == "S");


                this.DOBLECOPIACONTADOTextBox.Text = dt.Rows[0]["DOBLECOPIACONTADO"].ToString().Trim();

                this.DESGLOSEIEPSFACTURATextBox.Checked = (dt.Rows[0]["DESGLOSEIEPSFACTURA"].ToString().Trim() == "S");


                this.IMPRIMIRBANCOSCORTEComboBox.Checked = (dt.Rows[0]["IMPRIMIRBANCOSCORTE"].ToString().Trim() == "S");


                this.IMPR_CANC_VENTAComboBox.Checked = (dt.Rows[0]["IMPR_CANC_VENTA"].ToString().Trim() == "S");

                this.cbHabVentasMostrador.Checked = (dt.Rows[0]["HABVENTASMOSTRADOR"].ToString().Trim() == "S"); 

                emidaDataChanged = false;

                bLlenandoDatosDeBase = false;

                comisionPreciosChanged = false;

                verifoneDataChanged = false;



                this.RUTAPOLIZAPDFTextBox.Text = dt.Rows[0]["RUTAPOLIZAPDF"].ToString().Trim();


                try
                {
                    this.RETIROCAJAALCERRARCORTETextBox.Text = dt.Rows[0]["RETIROCAJAALCERRARCORTE"].ToString().Trim();
                }
                catch
                {

                }

                try
                {
                    this.PAGOTARJMENORPRECIOLISTAALLTextBox.Checked = (dt.Rows[0]["PAGOTARJMENORPRECIOLISTAALL"].ToString().Trim() == "S");
                    
                }
                catch
                {

                }


                try
                {
                    this.PREGUNTARSERVDOMTextBox.Checked = (dt.Rows[0]["PREGUNTARSERVDOM"].ToString().Trim() == "S");

                }
                catch
                {

                }




                try
                {
                    this.HABPPCTextBox.Checked = (dt.Rows[0]["HABPPC"].ToString().Trim() == "S");

                }
                catch
                {

                }

                try
                {
                    this.SOLOABONOAPLICADOTextBox.Checked = (dt.Rows[0]["SOLOABONOAPLICADO"].ToString().Trim() == "S");

                }
                catch
                {

                }



                this.VERSIONTOPEIDTextBox.Text = dt.Rows[0]["VERSIONTOPEID"].ToString().Trim();

                this.VERSIONCOMISIONIDTextBox.Text = dt.Rows[0]["VERSIONCOMISIONID"].ToString().Trim();
                this.MAXCOMISIONXCLIENTETextBox.Text = dt.Rows[0]["MAXCOMISIONXCLIENTE"].ToString().Trim();

                


                try
                {
                    this.IMPRFORMAVENTATRASLTextBox.Checked = (dt.Rows[0]["IMPRFORMAVENTATRASL"].ToString().Trim() == "S");

                }
                catch
                {

                }


                try
                {
                    this.HABREVISIONFINALTextBox.Text = dt.Rows[0]["HABREVISIONFINAL"].ToString().Trim();

                }
                catch
                {

                }

                try
                {

                    this.RECIBOLARGOCOTIPRINTERTextBox.Text = dt.Rows[0]["RECIBOLARGOCOTIPRINTER"].ToString().Trim();
                }
                catch
                {

                }


                try
                {
                    this.HABFONDODINAMICOTextBox.Text = dt.Rows[0]["HABFONDODINAMICO"].ToString().Trim();

                }
                catch
                {

                }


                try
                {
                    this.HABVENTACLISUCTextBox.Text = dt.Rows[0]["HABVENTACLISUC"].ToString().Trim();

                }
                catch
                {

                }





                


                try
                {
                    this.SEGUNDOSCICLOFTPTextBox.Text = dt.Rows[0]["SEGUNDOSCICLOFTP"].ToString().Trim();
                }
                catch
                { }

                try
                {
                    this.DIASMAXEXPFTPTextBox.Text = dt.Rows[0]["DIASMAXEXPFTP"].ToString().Trim();
                }
                catch
                { }

                try
                {
                    this.DIASMAXIMPFTPTextBox.Text = dt.Rows[0]["DIASMAXIMPFTP"].ToString().Trim();
                }
                catch
                { }

                try
                {
                    this.WSDBFTextBox.Text = dt.Rows[0]["WSDBF"].ToString().Trim();
                }
                catch
                {}
                

                try
                {
                    this.HABWSDBFTextBox.Text = dt.Rows[0]["HABWSDBF"].ToString().Trim();

                }
                catch
                {

                }


                this.FACTCONSMAXPORTextBox.Text = dt.Rows[0]["FACTCONSMAXPOR"].ToString().Trim();

                try
                {
                    this.DOBLECOPIATARJETATextBox.Text = dt.Rows[0]["DOBLECOPIATARJETA"].ToString().Trim();
                }
                catch
                { }

                try
                {

                    this.FISCALFECHACANCELACION2TextBox.Value = (DateTime)(dt.Rows[0]["FISCALFECHACANCELACION2"]);
                }
                catch
                {}


                try
                {
                    this.CANTTICKETRETIROTextBox.Text = dt.Rows[0]["CANTTICKETRETIRO"].ToString().Trim();
                    
                }
                catch { }


                try
                {
                    this.CANTTICKETDEPOSITOSTextBox.Text = dt.Rows[0]["CANTTICKETDEPOSITOS"].ToString().Trim();

                }
                catch { }

                try
                {
                    this.CANTTICKETFONDOCAJATextBox.Text = dt.Rows[0]["CANTTICKETFONDOCAJA"].ToString().Trim();

                }
                catch { }

                try
                {
                    this.CANTTICKETGASTOSTextBox.Text = dt.Rows[0]["CANTTICKETGASTOS"].ToString().Trim();

                }
                catch { }

                try
                {
                    this.CANTTICKETCOMPRASTextBox.Text = dt.Rows[0]["CANTTICKETCOMPRAS"].ToString().Trim();

                }
                catch { }

                try
                {
                    this.CANTTICKETABRIRCORTETextBox.Text = dt.Rows[0]["CANTTICKETABRIRCORTE"].ToString().Trim();

                }
                catch { }

                try
                {
                    this.CANTTICKETCIERRECORTETextBox.Text = dt.Rows[0]["CANTTICKETCIERRECORTE"].ToString().Trim();

                }
                catch { }

                try
                {
                    this.CANTTICKETCIERREBILLETESTextBox.Text = dt.Rows[0]["CANTTICKETCIERREBILLETES"].ToString().Trim();

                }
                catch { }

                try
                {

                    this.MANEJAUTILIDADPRECIOSTextBox.Text = dt.Rows[0]["MANEJAUTILIDADPRECIOS"].ToString().Trim();

                }
                catch { }


                try
                {

                    this.HABMULTPLAZOCOMPRATextBox.Text = dt.Rows[0]["HABMULTPLAZOCOMPRA"].ToString().Trim();

                }
                catch { }


                try
                {

                    this.COSTOREPOIGUALCOSTOULTComboBox.Text = dt.Rows[0]["COSTOREPOIGUALCOSTOULT"].ToString().Trim();

                }
                catch { }


                try
                {

                    this.TICKET_DESC_VALE_AL_FINALComboBox.Text = dt.Rows[0]["TICKET_DESC_VALE_AL_FINAL"].ToString().Trim();

                }
                catch { }

                try
                {
                    if (dt.Rows[0]["MONEDEROLISTAPRECIOID"] != null)
                    {
                        this.MONEDEROLISTAPRECIOIDComboBox.Text = dt.Rows[0]["MONEDEROLISTAPRECIOID"].ToString();
                    }
                }
                catch { }


                try
                {

                    this.MONEDEROCAMPOREFTextBox.Text = dt.Rows[0]["MONEDEROCAMPOREF"].ToString().Trim();

                }
                catch { }


                try
                {

                    this.HABSURTIDOPREVIOTextBox.Text = dt.Rows[0]["HABSURTIDOPREVIO"].ToString().Trim();

                }
                catch { }


                try
                {
                    this.NUMTICKETSCOMANDATextBox.Text = dt.Rows[0]["NUMTICKETSCOMANDA"].ToString().Trim();

                }
                catch { }


                try
                {

                    this.RECIBOPREVIEWCOMANDATextBox.Text = dt.Rows[0]["RECIBOPREVIEWCOMANDA"].ToString().Trim();

                }
                catch { }



                try
                {

                    this.IMPRESORACOMANDATextBox.Text = dt.Rows[0]["IMPRESORACOMANDA"].ToString().Trim();

                }
                catch { }


                try
                {

                    this.TICKET_IMPR_DESC2ComboBox.Text = dt.Rows[0]["TICKET_IMPR_DESC2"].ToString().Trim();

                }
                catch { }


                try
                {
                    this.SERIECOMPRTRASLSATTextBox.Text = dt.Rows[0]["SERIECOMPRTRASLSAT"].ToString().Trim();
                }
                catch { }


                try
                {
                    this.HABSURTIDOPOSTMOVILTextBox.Text = dt.Rows[0]["HABSURTIDOPOSTMOVIL"].ToString().Trim();
                }
                catch { }

                try
                {
                    this.PORCUTILIDADLISTADOTextBox.Text = dt.Rows[0]["PORCUTILIDADLISTADO"].ToString().Trim();
                }
                catch { }

                try
                {
                    this.RUTAFIRMAIMAGENESTextBox.Text = dt.Rows[0]["RUTAFIRMAIMAGENES"].ToString().Trim();
                }
                catch { }


                try
                {
                    this.PORCUTILMACROLISTADOTextBox.Text = dt.Rows[0]["PORCUTILMACROLISTADO"].ToString().Trim();
                }
                catch { }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
                bLlenandoDatosDeBase = false;
                return false;
            }
        }



        private bool LlenarDatosDeVerifone()
        {

            try
            {

                this.LimpiarDatosVerifone();

                CVERIFONECONFIGD verifoneConfigD = new CVERIFONECONFIGD();
                CVERIFONECONFIGBE verifoneConfigBE = new CVERIFONECONFIGBE();

                verifoneConfigBE = verifoneConfigD.seleccionarVERIFONECONFIG_Unico(null);

                if (verifoneConfigBE == null)
                    return false;

                this.VERIFONECONFIGID = verifoneConfigBE.IID;


                this.VERIFONEACTIVOCheckBox.Checked = (verifoneConfigBE.IACTIVO == "S") ? true : false;
                this.VERIFONE_USERIDTextBox.Text = verifoneConfigBE.IUSERID;
                this.VERIFONE_CONTRASENATextBox.Text = verifoneConfigBE.ICONTRASENA;
                this.VERIFONE_SHIFTNUMBERTextBox.Text = verifoneConfigBE.ISHIFTNUMBER;
                this.VERIFONE_MERCHANTIDTextBox.Text = verifoneConfigBE.IMERCHANTID;
                this.VERIFONE_OPERATORLOCALETextBox.Text = verifoneConfigBE.IOPERATORLOCALE;

                

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();

                return false;
            }
        }

        private CPARAMETROBE    ObtenerDatosCapturados()
        {
            CPARAMETROBE EMPRESABE = new CPARAMETROBE();

            if (String.IsNullOrEmpty(this.SucursalComboBox.Text)) return null;

            EMPRESABE.IDESTINOBDVENMOV = rutaBdVenMovTextBox.Text;

            EMPRESABE.IGENERARFE = GENERARFECheckBox.Checked ? "S" : "N";

            if (this.NOMBRETextBox.Text != "")
            {
                EMPRESABE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }
            if (this.CALLETextBox.Text != "")
            {
                EMPRESABE.ICALLE = this.CALLETextBox.Text.ToString();
            }

            if (this.NUMEROEXTERIORTextBox.Text != "")
            {
                EMPRESABE.INUMEROEXTERIOR = this.NUMEROEXTERIORTextBox.Text.ToString();
            }
            if (this.NUMEROINTERIORTextBox.Text != "")
            {
                EMPRESABE.INUMEROINTERIOR = this.NUMEROINTERIORTextBox.Text.ToString();
            }

            if (this.COLONIATextBox.Text != "")
            {
                EMPRESABE.ICOLONIA = this.COLONIATextBox.Text.ToString();
            }
            if (this.LOCALIDADTextBox.Text != "")
            {
                EMPRESABE.ILOCALIDAD = this.LOCALIDADTextBox.Text.ToString();
            }
            if (this.ESTADOTextBox.Text != "")
            {
                EMPRESABE.IESTADO = this.ESTADOTextBox.Text.ToString();
            }
            if (this.CPTextBox.Text != "")
            {
                EMPRESABE.ICP = this.CPTextBox.Text.ToString();
            }
            if (this.TELEFONOTextBox.Text != "")
            {
                EMPRESABE.ITELEFONO = this.TELEFONOTextBox.Text.ToString();
            }
            if (this.FAXTextBox.Text != "")
            {
                EMPRESABE.IFAX = this.FAXTextBox.Text.ToString();
            }
            if (this.CORREOETextBox.Text != "")
            {
                EMPRESABE.ICORREOE = this.CORREOETextBox.Text.ToString();
            }
            if (this.PAGINAWEBTextBox.Text != "")
            {
                EMPRESABE.IPAGINAWEB = this.PAGINAWEBTextBox.Text.ToString();
            }
            if (this.RFCTextBox.Text != "")
            {
                EMPRESABE.IRFC = this.RFCTextBox.Text.ToString();
            }
            if (this.LISTA_PRECIO_DEFTextBox.Text != "")
            {
                EMPRESABE.ILISTA_PRECIO_DEF = this.LISTA_PRECIO_DEFTextBox.Text.ToString();
            }
            if (this.IMP_PROD_DEFTextBox.NumericValue != null)
            {
                EMPRESABE.IIMP_PROD_DEF = decimal.Parse(this.IMP_PROD_DEFTextBox.NumericValue.ToString());
            }
            if (this.ESTADO_DEFTextBox.Text != "")
            {
                EMPRESABE.IESTADO_DEF = this.ESTADO_DEFTextBox.Text.ToString();
            }
            if (this.SucursalComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ISUCURSALNUMERO = this.SucursalComboBox.SelectedDataDisplaying.ToString();
                long lSucursalID = long.Parse(this.SucursalComboBox.SelectedValue.ToString());
                EMPRESABE.ISUCURSALID = (int)lSucursalID;
            }

            EMPRESABE.IFECHAULTIMA = this.UltimaFecha.Value ;

            if (this.ID_DOSLETRASTextBox.Text != "")
            {
                EMPRESABE.IID_DOSLETRAS = this.ID_DOSLETRASTextBox.Text.ToString();
            }

            if (this.HABILITAR_IMPEXP_AUTComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHABILITAR_IMPEXP_AUT = this.HABILITAR_IMPEXP_AUTComboBox.Text;
            }


            if (this.CBCambiarPrecio.SelectedIndex >= 0)
            {
                EMPRESABE.ICAMBIARPRECIO = this.CBCambiarPrecio.Text;
            }


            if (this.HAB_SEL_CLIENTEComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHAB_SEL_CLIENTE = this.HAB_SEL_CLIENTEComboBox.Text;
            }


            if (this.HAB_IMPR_COTIZACIONComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHAB_IMPR_COTIZACION = this.HAB_IMPR_COTIZACIONComboBox.Text;
            }

            if (this.FTPHOSTTextBox.Text != "")
                EMPRESABE.IFTPHOST = this.FTPHOSTTextBox.Text.ToString();

            if (this.FTPUSUARIOTextBox.Text != "")
                EMPRESABE.IFTPUSUARIO = this.FTPUSUARIOTextBox.Text.ToString();

            if (this.FTPPASSWORDTextBox.Text != "")
                EMPRESABE.IFTPPASSWORD = this.FTPPASSWORDTextBox.Text.ToString();

            if (this.SMTPHOSTTextBox.Text != "")
                EMPRESABE.ISMTPHOST = this.SMTPHOSTTextBox.Text.ToString();

            if (this.SMTPUSUARIOTextBox.Text != "")
                EMPRESABE.ISMTPUSUARIO = this.SMTPUSUARIOTextBox.Text.ToString();

            if (this.SMTPPASSWORDTextBox.Text != "")
                EMPRESABE.ISMTPPASSWORD = this.SMTPPASSWORDTextBox.Text.ToString();

            if (this.SMTPPORTTextBox.Text != "")
                EMPRESABE.ISMTPPORT = int.Parse(this.SMTPPORTTextBox.NumericValue.ToString());

            if (this.SMTPMAILFROMTextBox.Text != "")
                EMPRESABE.ISMTPMAILFROM = this.SMTPMAILFROMTextBox.Text.ToString();

            if (this.SMTPMAILTOTextBox.Text != "")
                EMPRESABE.ISMTPMAILTO = this.SMTPMAILTOTextBox.Text.ToString();

            if (this.MAILTOINVENTARIOTextBox.Text != "")
                EMPRESABE.IMAILTOINVENTARIO = this.MAILTOINVENTARIOTextBox.Text.ToString();

            if (this.FTPFOLDERTextBox.Text != "")
                EMPRESABE.IFTPFOLDER = this.FTPFOLDERTextBox.Text.ToString();

            if (this.FTPFOLDERPASSTextBox.Text != "")
                EMPRESABE.IFTPFOLDERPASS = this.FTPFOLDERPASSTextBox.Text.ToString();



            if (this.SMTPSSLComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ISMTPSSL = this.SMTPSSLComboBox.Text;
            }



            if (this.HEADERTextBox.Text != "")
                EMPRESABE.IHEADER = this.HEADERTextBox.Text.ToString();

            if (this.FOOTERTextBox.Text != "")
                EMPRESABE.IFOOTER = this.FOOTERTextBox.Text.ToString();

            if (this.FOOTERVENTAAPARTADOTextBox.Text != "")
                EMPRESABE.IFOOTERVENTAAPARTADO = this.FOOTERVENTAAPARTADOTextBox.Text.ToString();



            if (this.COMISIONMEDICOTextBox.NumericValue != null)
            {
                EMPRESABE.ICOMISIONMEDICO = decimal.Parse(this.COMISIONMEDICOTextBox.NumericValue.ToString());
            }

            if (this.COMISIONDEPENDIENTETextBox.NumericValue != null)
            {
                EMPRESABE.ICOMISIONDEPENDIENTE = decimal.Parse(this.COMISIONDEPENDIENTETextBox.NumericValue.ToString());
            }




            if (this.PORC_COMISIONENCARGADOTextBox.NumericValue != null)
            {
                EMPRESABE.IPORC_COMISIONENCARGADO = decimal.Parse(this.PORC_COMISIONENCARGADOTextBox.NumericValue.ToString());
            }


            if (this.PORC_COMISIONVENDEDORTextBox.NumericValue != null)
            {
                EMPRESABE.IPORC_COMISIONVENDEDOR = decimal.Parse(this.PORC_COMISIONVENDEDORTextBox.NumericValue.ToString());
            }


            if (this.MOSTRAR_EXIS_SUCComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRAR_EXIS_SUC = this.MOSTRAR_EXIS_SUCComboBox.Text;
            }


            if (this.REQ_APROBACION_INVComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IREQ_APROBACION_INV = this.REQ_APROBACION_INVComboBox.Text;
            }

            if (this.REABRIRCORTESComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IREABRIRCORTES = this.REABRIRCORTESComboBox.Text;
            }



            if (this.DESCUENTOVALETextBox.NumericValue != null)
            {
                EMPRESABE.IDESCUENTOVALE = decimal.Parse(this.DESCUENTOVALETextBox.NumericValue.ToString());
            }

            if (this.IMP_PROD_TOTALComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IIMP_PROD_TOTAL = this.IMP_PROD_TOTALComboBox.Text;
            }


            if (this.TEXTO1TextBox.Text != "")
                EMPRESABE.ITEXTO1 = this.TEXTO1TextBox.Text.ToString();


            if (this.TEXTO2TextBox.Text != "")
                EMPRESABE.ITEXTO2 = this.TEXTO2TextBox.Text.ToString();
            if (this.TEXTO3TextBox.Text != "")
                EMPRESABE.ITEXTO3 = this.TEXTO3TextBox.Text.ToString();
            if (this.TEXTO4TextBox.Text != "")
                EMPRESABE.ITEXTO4 = this.TEXTO4TextBox.Text.ToString();
            if (this.TEXTO5TextBox.Text != "")
                EMPRESABE.ITEXTO5 = this.TEXTO5TextBox.Text.ToString();
            if (this.TEXTO6TextBox.Text != "")
                EMPRESABE.ITEXTO6 = this.TEXTO6TextBox.Text.ToString();


            if (this.NUMERO1TextBox.Text != "")
                EMPRESABE.INUMERO1 = this.NUMERO1TextBox.Text.ToString();
            if (this.NUMERO2TextBox.Text != "")
                EMPRESABE.INUMERO2 = this.NUMERO2TextBox.Text.ToString();
            if (this.NUMERO3TextBox.Text != "")
                EMPRESABE.INUMERO3 = this.NUMERO3TextBox.Text.ToString();
            if (this.NUMERO4TextBox.Text != "")
                EMPRESABE.INUMERO4 = this.NUMERO4TextBox.Text.ToString();


            if (this.FECHA1TextBox.Text != "")
                EMPRESABE.IFECHA1 = this.FECHA1TextBox.Text.ToString();
            if (this.FECHA2TextBox.Text != "")
                EMPRESABE.IFECHA2 = this.FECHA2TextBox.Text.ToString();


            if (this.FISCALCALLETextBox.Text != "")
            {
                EMPRESABE.IFISCALCALLE = this.FISCALCALLETextBox.Text.ToString();
            }
            if (this.FISCALNUMEROINTERIORTextBox.Text != "")
            {
                EMPRESABE.IFISCALNUMEROINTERIOR = this.FISCALNUMEROINTERIORTextBox.Text.ToString();
            }
            if (this.FISCALNUMEROEXTERIORTextBox.Text != "")
            {
                EMPRESABE.IFISCALNUMEROEXTERIOR = this.FISCALNUMEROEXTERIORTextBox.Text.ToString();
            }
            if (this.FISCALCOLONIATextBox.Text != "")
            {
                EMPRESABE.IFISCALCOLONIA = this.FISCALCOLONIATextBox.Text.ToString();
            }
            if (this.FISCALMUNICIPIOTextBox.Text != "")
            {
                EMPRESABE.IFISCALMUNICIPIO = this.FISCALMUNICIPIOTextBox.Text.ToString();
            }
            if (this.FISCALESTADOTextBox.Text != "")
            {
                EMPRESABE.IFISCALESTADO = this.FISCALESTADOTextBox.Text.ToString();
            }
            if (this.FISCALCODIGOPOSTALTextBox.Text != "")
            {
                EMPRESABE.IFISCALCODIGOPOSTAL = this.FISCALCODIGOPOSTALTextBox.Text.ToString();
            }

            if (this.CERTIFICADOCSDTextBox.Text != "")
            {
                EMPRESABE.ICERTIFICADOCSD = this.CERTIFICADOCSDTextBox.Text.ToString();
            }
            if (this.TIMBRADOUSERTextBox.Text != "")
            {
                EMPRESABE.ITIMBRADOUSER = this.TIMBRADOUSERTextBox.Text.ToString();
            }
            if (this.TIMBRADOPASSWORDTextBox.Text != "")
            {
                EMPRESABE.ITIMBRADOPASSWORD = this.TIMBRADOPASSWORDTextBox.Text.ToString();
            }
            if (this.TIMBRADOARCHIVOCERTIFICADOTextBox.Text != "")
            {
                EMPRESABE.ITIMBRADOARCHIVOCERTIFICADO = this.TIMBRADOARCHIVOCERTIFICADOTextBox.Text.ToString();
            }
            if (this.TIMBRADOARCHIVOKEYTextBox.Text != "")
            {
                EMPRESABE.ITIMBRADOARCHIVOKEY = this.TIMBRADOARCHIVOKEYTextBox.Text.ToString();
            }
            if (this.TIMBRADOKEYTextBox.Text != "")
            {
                EMPRESABE.ITIMBRADOKEY = this.TIMBRADOKEYTextBox.Text.ToString();
            }
            if (this.FISCALNOMBRETextBox.Text != "")
            {
                EMPRESABE.IFISCALNOMBRE = this.FISCALNOMBRETextBox.Text.ToString();
            }

            if (this.SERIESATTextBox.Text != "")
            {
                EMPRESABE.ISERIESAT = this.SERIESATTextBox.Text.ToString();
            }

            if (this.USARFISCALESENEXPEDICIONCheckBox.Checked)
                EMPRESABE.IUSARFISCALESENEXPEDICION = "S";
            else
                EMPRESABE.IUSARFISCALESENEXPEDICION = "N";


            if (this.HAB_FACTURAELECTRONICAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHAB_FACTURAELECTRONICA = this.HAB_FACTURAELECTRONICAComboBox.Text;
            }



            if (!(this.ENCARGADOIDTextBox.Text == "" || Int64.Parse(this.ENCARGADOIDTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IENCARGADOID = Int64.Parse(this.ENCARGADOIDTextBox.DbValue.ToString());
            }

            if (this.SERIESATDEVOLUCIONTextBox.Text != "")
            {
                EMPRESABE.ISERIESATDEVOLUCION = this.SERIESATDEVOLUCIONTextBox.Text.ToString();
            }

            if (this.SERIESATDEVOLUCIONTextBox.Text != "")
            {
                EMPRESABE.ISERIESATDEVOLUCION = this.SERIESATDEVOLUCIONTextBox.Text.ToString();
            }


            if (this.CAMBIARPRECIOXUEMPAQUEComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ICAMBIARPRECIOXUEMPAQUE = this.CAMBIARPRECIOXUEMPAQUEComboBox.Text;
            }
            if (this.CAMBIARPRECIOXPZACAJAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ICAMBIARPRECIOXPZACAJA = this.CAMBIARPRECIOXPZACAJAComboBox.Text;
            }



            if (this.PREFIJOBASCULATextBox.Text != "")
            {
                EMPRESABE.IPREFIJOBASCULA = this.PREFIJOBASCULATextBox.Text.ToString();
            }
            if (this.LONGPRODBASCULATextBox.NumericValue != null)
            {
                EMPRESABE.ILONGPRODBASCULA = Int16.Parse(this.LONGPRODBASCULATextBox.NumericValue.ToString());
            }
            if (this.LONGPESOBASCULATextBox.NumericValue != null)
            {
                EMPRESABE.ILONGPESOBASCULA = Int16.Parse(this.LONGPESOBASCULATextBox.NumericValue.ToString());
            }

            if(this.cancelXActNumericTextBox.NumericValue != null)
            {
                EMPRESABE.INUMCANCELACTAUTO = int.Parse(this.cancelXActNumericTextBox.NumericValue.ToString());
            }

            if (this.LISTAPRECIOXUEMPAQUEComboBox.Text != "")
            {
                EMPRESABE.ILISTAPRECIOXUEMPAQUE = Int64.Parse(this.LISTAPRECIOXUEMPAQUEComboBox.Text.ToString());
            }
            if (this.LISTAPRECIOXPZACAJAComboBox.Text != "")
            {
                EMPRESABE.ILISTAPRECIOXPZACAJA = Int64.Parse(this.LISTAPRECIOXPZACAJAComboBox.Text.ToString());
            }

            if (this.LISTAPRECIOINIMAYOComboBox.Text != "")
            {
                EMPRESABE.ILISTAPRECIOINIMAYO = Int64.Parse(this.LISTAPRECIOINIMAYOComboBox.Text.ToString());
            }

            if (this.LISTAPRECIOMAYLINEAComboBox.Text != "")
            {
                EMPRESABE.ILISTAPRECIOMAYLINEA = Int64.Parse(this.LISTAPRECIOMAYLINEAComboBox.Text.ToString());
            }

            if (this.LISTAPRECMEDMAYLINEAComboBox.Text != "")
            {
                EMPRESABE.ILISTAPRECMEDMAYLINEA = Int64.Parse(this.LISTAPRECMEDMAYLINEAComboBox.Text.ToString());
            }


            if (this.HAYVENDEDORPISOComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHAYVENDEDORPISO = this.HAYVENDEDORPISOComboBox.Text;
            }


            if (this.ENVIOAUTOMATICOEXISTENCIASComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IENVIOAUTOMATICOEXISTENCIAS = this.ENVIOAUTOMATICOEXISTENCIASComboBox.Text;
            }


            if (this.MONEDEROAPLICARComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMONEDEROAPLICAR = this.MONEDEROAPLICARComboBox.Text;
            }

            if (this.MONEDEROCADUCIDADTextBox.NumericValue != null)
            {
                EMPRESABE.IMONEDEROCADUCIDAD = int.Parse(this.MONEDEROCADUCIDADTextBox.NumericValue.ToString());
            }

            if (this.MONEDEROMONTOMINIMOTextBox.NumericValue != null)
            {
                EMPRESABE.IMONEDEROMONTOMINIMO = decimal.Parse(this.MONEDEROMONTOMINIMOTextBox.NumericValue.ToString());
            }


            if (this.IMPRIMIRNUMEROPIEZASComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IIMPRIMIRNUMEROPIEZAS = this.IMPRIMIRNUMEROPIEZASComboBox.Text;
            }

            if (this.PACUSUARIOTextBox.Text != "")
            {
                EMPRESABE.IPACUSUARIO = this.PACUSUARIOTextBox.Text.ToString();
            }
            if (this.PACNOMBRETextBox.Text != "")
            {
                EMPRESABE.IPACNOMBRE = this.PACNOMBRETextBox.Text.ToString();
            }

            if (this.CORTEPORMAILTextBox.Text != "")
            {
                EMPRESABE.ICORTEPORMAIL = this.CORTEPORMAILTextBox.Text.ToString();
            }


            if (this.RUTAREPORTESTextBox.Text != "")
            {
                EMPRESABE.IRUTAREPORTES = this.RUTAREPORTESTextBox.Text.ToString();
            }

            if (this.RUTAREPORTESSISTEMATextBox.Text != "")
            {
                EMPRESABE.IRUTAREPORTESSISTEMA = this.RUTAREPORTESSISTEMATextBox.Text.ToString();
            }

            if (this.txtRutaRespaldo.Text != "")
            {
                EMPRESABE.IRUTARESPALDO = this.txtRutaRespaldo.Text.ToString();
            }

            if (this.DOBLECOPIATRASLADOTextBox.NumericValue != null)
            {
                EMPRESABE.IDOBLECOPIATRASLADO = int.Parse(this.DOBLECOPIATRASLADOTextBox.NumericValue.ToString());
            }


            if (this.DOBLECOPIACREDITOTextBox.NumericValue != null)
            {
                EMPRESABE.IDOBLECOPIACREDITO = int.Parse(this.DOBLECOPIACREDITOTextBox.NumericValue.ToString());
            }

            if (this.CAMPOSCUSTOMALIMPORTARTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.ICAMPOSCUSTOMALIMPORTAR = this.CAMPOSCUSTOMALIMPORTARTextBox.Text;
            }


            //if (this.PRECIOREALTRASLADOSTextBox.Text != "")
            //{
            //    EMPRESABE.IPRECIOREALTRASLADOS = this.PRECIOREALTRASLADOSTextBox.Text.ToString();
            //}


            if (this.RECIBOLARGOPRINTERTextBox.Text != "")
            {
                EMPRESABE.IRECIBOLARGOPRINTER = this.RECIBOLARGOPRINTERTextBox.Text.ToString();
            }

            if (this.RECIBOLARGOCOTIPRINTERTextBox.Text != "")
            {
                EMPRESABE.IRECIBOLARGOCOTIPRINTER = this.RECIBOLARGOCOTIPRINTERTextBox.Text.ToString();
            }

            if (this.RECIBOLARGOPREVIEWComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IRECIBOLARGOPREVIEW = this.RECIBOLARGOPREVIEWComboBox.Text;
            }


            if (this.RECIBOLARGOCONFACTURAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IRECIBOLARGOCONFACTURA = this.RECIBOLARGOCONFACTURAComboBox.Text;
            }

            if (this.PREGUNTARRAZONPRECIOMENORComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPREGUNTARRAZONPRECIOMENOR = this.PREGUNTARRAZONPRECIOMENORComboBox.Text;
            }

            if (this.PREGUNTARDATOSENTREGAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPREGUNTARDATOSENTREGA = this.PREGUNTARDATOSENTREGAComboBox.Text;
            }


            if (this.FISCALREGIMENTextBox.Text != "")
            {
                EMPRESABE.IFISCALREGIMEN = this.FISCALREGIMENTextBox.Text.ToString();
            }


            if (this.CORTACADUCIDADTextBox.NumericValue != null)
            {
                EMPRESABE.ICORTACADUCIDAD = int.Parse(this.CORTACADUCIDADTextBox.NumericValue.ToString());
            }



            if (this.RETENCIONIVATextBox.NumericValue != null)
            {
                EMPRESABE.IRETENCIONIVA = decimal.Parse(this.RETENCIONIVATextBox.NumericValue.ToString());
            }

            if (this.RETENCIONISRTextBox.NumericValue != null)
            {
                EMPRESABE.IRETENCIONISR = decimal.Parse(this.RETENCIONISRTextBox.NumericValue.ToString());
            }


            if (this.ARRENDATARIOCheckBox.Checked)
                EMPRESABE.IARRENDATARIO = "S";
            else
                EMPRESABE.IARRENDATARIO = "N";


            if (this.RUTAIMAGENESPRODUCTOTextBox.Text != "")
            {
                EMPRESABE.IRUTAIMAGENESPRODUCTO = this.RUTAIMAGENESPRODUCTOTextBox.Text.ToString();
            }


            if (this.MOSTRARIMAGENENVENTATextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRARIMAGENENVENTA = this.MOSTRARIMAGENENVENTATextBox.Text;
            }


            if (this.MOSTRARMONTOAHORROComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRARMONTOAHORRO = this.MOSTRARMONTOAHORROComboBox.Text;
            }



            if (this.MOSTRARDESCUENTOFACTURAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRARDESCUENTOFACTURA = this.MOSTRARDESCUENTOFACTURAComboBox.Text;
            }


            if (this.EXPORTCATALOGOAUXTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IEXPORTCATALOGOAUX = this.EXPORTCATALOGOAUXTextBox.Text;
            }


            if (this.UIVENTACONCANTIDADComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IUIVENTACONCANTIDAD = this.UIVENTACONCANTIDADComboBox.Text;
            }


            if (this.FACT_ELECT_FOLDERTextBox.Text != "")
            {
                EMPRESABE.IFACT_ELECT_FOLDER = this.FACT_ELECT_FOLDERTextBox.Text.ToString();
            }

            if (this.PEDIDOS_FOLDERTextBox.Text != "")
            {
                EMPRESABE.IPEDIDOS_FOLDER = this.PEDIDOS_FOLDERTextBox.Text.ToString();
            }

            if (this.PREFIJOCLIENTETextBox.Text != "")
            {
                EMPRESABE.IPREFIJOCLIENTE = this.PREFIJOCLIENTETextBox.Text.ToString();
            }


            if (this.MOSTRARPZACAJAENFACTURAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRARPZACAJAENFACTURA = this.MOSTRARPZACAJAENFACTURAComboBox.Text;
            }

            EMPRESABE.IDESGLOSEIEPS = (this.DESGLOSEIEPSTextBox.Checked) ? "S" : "N";

            EMPRESABE.ISERVICIOSEMIDA = (this.rdbtnEmidaServices.Checked) ? "S" : "N";

            EMPRESABE.IHABPAGOSERVEMIDA = (this.HABPAGOSERVEMIDACheckBox.Checked) ? "S" : "N";

            EMPRESABE.IBANCOMERHABPINPAD = (this.BANCOMERHABPINPADCheckBox.Checked) ? "S" : "N";

            EMPRESABE.IHABVENTASMOSTRADOR = (this.cbHabVentasMostrador.Checked) ? "S" : "N";

            EMPRESABE.IPLAZOXPRODUCTO = (this.cbPlazosXProducto.Checked) ? "S" : "N";

            EMPRESABE.IAPLICARCAMBIOSPRECAUTO = (this.actPrecAutoCB.Checked) ? "S" : "N";

            EMPRESABE.IMANEJACUPONES = (this.MANEJACUPONESCheckBox.Checked) ? "S" : "N";

            if (this.CUENTAIEPSTextBox.Text != "")
            {
                EMPRESABE.ICUENTAIEPS = this.CUENTAIEPSTextBox.Text.ToString();
            }

            if (this.DIVIDIR_REM_FACTTextBox.Text != "")
            {
                EMPRESABE.IDIVIDIR_REM_FACT = this.DIVIDIR_REM_FACTTextBox.Text.ToString();
            }

            if (this.AUTPRECIOLISTABAJOTextBox.Text != "")
            {
                EMPRESABE.IAUTPRECIOLISTABAJO = this.AUTPRECIOLISTABAJOTextBox.Text.ToString();
            }

            if (this.WEBSERVICETextBox.Text != "")
            {
                EMPRESABE.IWEBSERVICE = this.WEBSERVICETextBox.Text.ToString();
            }

            if (this.MINUTILIDADTextBox.NumericValue != null)
            {
                EMPRESABE.IMINUTILIDAD = decimal.Parse(this.MINUTILIDADTextBox.NumericValue.ToString());
            }
            if (this.MANEJASUPERLISTAPRECIOTextBox.Text != "")
            {
                EMPRESABE.IMANEJASUPERLISTAPRECIO = this.MANEJASUPERLISTAPRECIOTextBox.Text.ToString();
            }
            if (this.MANEJAALMACENTextBox.Text != "")
            {
                EMPRESABE.IMANEJAALMACEN = this.MANEJAALMACENTextBox.Text.ToString();
            }
            
            if (this.TIPODESCUENTOPRODIDTextBox.Text != "")
            {
                EMPRESABE.ITIPODESCUENTOPRODID = long.Parse(this.TIPODESCUENTOPRODIDTextBox.SelectedValue.ToString());
            }

            if (this.MANEJARECETATextBox.Text != "")
            {
                EMPRESABE.IMANEJARECETA = this.MANEJARECETATextBox.Text.ToString();
            }

            if (this.TOUCHTextBox.Text != "")
            {
                EMPRESABE.ITOUCH = this.TOUCHTextBox.Text.ToString();
            }


            if (this.ESVENDEDORMOVILTextBox.Text != "")
            {
                EMPRESABE.IESVENDEDORMOVIL = this.ESVENDEDORMOVILTextBox.Text.ToString();
            }

            if (this.TIPOSYNCMOVILTextBox.Text != "")
            {
                EMPRESABE.ITIPOSYNCMOVIL = this.TIPOSYNCMOVILTextBox.Text.ToString();
            }


            if (this.AUTOCOMPPRODTextBox.Text != "")
            {
                EMPRESABE.IAUTOCOMPPROD = this.AUTOCOMPPRODTextBox.Text.ToString();
            }

            if (this.AUTOCOMPCLIENTETextBox.Text != "")
            {
                EMPRESABE.IAUTOCOMPCLIENTE = this.AUTOCOMPCLIENTETextBox.Text.ToString();
            }



            if (this.MANEJAQUOTATextBox.Text != "")
            {
                EMPRESABE.IMANEJAQUOTA = this.MANEJAQUOTATextBox.Text.ToString();
            }

            if (this.TIPOUTILIDADIDTextBox.Text != "")
            {
                EMPRESABE.ITIPOUTILIDADID = long.Parse(this.TIPOUTILIDADIDTextBox.SelectedValue.ToString());
            }



            if (this.CAJASBOTELLASTextBox.Text != "")
            {
                EMPRESABE.ICAJASBOTELLAS = this.CAJASBOTELLASTextBox.Text.ToString();
            }



            if (this.PRECIONETOENPVTextBox.Text != "")
            {
                EMPRESABE.IPRECIONETOENPV = this.PRECIONETOENPVTextBox.Text.ToString();
            }

            if (this.MOSTRARFLASHComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRARFLASH = this.MOSTRARFLASHComboBox.Text;
            }

            if (this.ORDENIMPRESIONComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IORDENIMPRESION = this.ORDENIMPRESIONComboBox.Text;
            }

            if (this.PRECIOXCAJAENPVTextBox.Text != "")
            {
                EMPRESABE.IPRECIOXCAJAENPV = this.PRECIOXCAJAENPVTextBox.Text.ToString();
            }

            if (this.LOCALFTPHOSTTextBox.Text != "")
                EMPRESABE.ILOCALFTPHOST = this.LOCALFTPHOSTTextBox.Text.ToString();

            if (this.LOCALWEBSERVICETextBox.Text != "")
                EMPRESABE.ILOCALWEBSERVICE = this.LOCALWEBSERVICETextBox.Text.ToString();


            if (this.USARCONEXIONLOCALTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IUSARCONEXIONLOCAL = this.USARCONEXIONLOCALTextBox.Text;
            }

            if (this.RUTARESPALDOSZIPTextBox.Text != "")
                EMPRESABE.IRUTARESPALDOSZIP = this.RUTARESPALDOSZIPTextBox.Text.ToString();

            if (this.SCREENCONFIGTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.ISCREENCONFIG = this.SCREENCONFIGTextBox.SelectedIndex;
            }
            else
            {
                EMPRESABE.ISCREENCONFIG = 0;
            }

            if (this.PROMOENTICKETComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPROMOENTICKET = this.PROMOENTICKETComboBox.Text;
            }


            if (this.TAMANOLETRATICKETTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.ITAMANOLETRATICKET = (short)this.TAMANOLETRATICKETTextBox.SelectedIndex;
            }
            else
            {
                EMPRESABE.ITAMANOLETRATICKET = 0;
            }

            if (this.MANEJAKITSTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMANEJAKITS = this.MANEJAKITSTextBox.Text;
            }


            if (this.CAMPOIMPOCOSTOREPOTextBox.Text != "")
            {
                EMPRESABE.ICAMPOIMPOCOSTOREPO = this.CAMPOIMPOCOSTOREPOTextBox.SelectedIndex;
            }


            if (this.LISTAPRECIOMINIMOComboBox.Text != "")
            {
                EMPRESABE.ILISTAPRECIOMINIMO = Int64.Parse(this.LISTAPRECIOMINIMOComboBox.Text.ToString());
            }

            if (this.REBAJAESPECIALTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IREBAJAESPECIAL = this.REBAJAESPECIALTextBox.Text;
            }


            if (this.HABILITARREPLTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHABILITARREPL = this.HABILITARREPLTextBox.Text;
            }

            if (this.BDLOCALREPLTextBox.Text != "")
                EMPRESABE.IBDLOCALREPL = this.BDLOCALREPLTextBox.Text.ToString();



            if (this.PENDMOVILANTESVENTATextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPENDMOVILANTESVENTA = this.PENDMOVILANTESVENTATextBox.Text;
            }

            if (this.PRECIOSMOVILANTESVENTATextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPRECIOSMOVILANTESVENTA = this.PRECIOSMOVILANTESVENTATextBox.Text;
            }


            if (this.RECALCULARCAMBIOCLIENTETextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IRECALCULARCAMBIOCLIENTE = this.RECALCULARCAMBIOCLIENTETextBox.Text;
            }



            if (this.TIPOVENDEDORMOVILTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.ITIPOVENDEDORMOVIL = (short)this.TIPOVENDEDORMOVILTextBox.SelectedIndex;
            }
            else
            {
                EMPRESABE.ITIPOVENDEDORMOVIL = 0;
            }

            if (this.BDSERVERWSTextBox.Text != "")
                EMPRESABE.IBDSERVERWS = this.BDSERVERWSTextBox.Text.ToString();

            if (this.BDMATRIZMOVILTextBox.Text != "")
                EMPRESABE.IBDMATRIZMOVIL = this.BDMATRIZMOVILTextBox.Text.ToString();

            if (this.txtIPWsAppInventario.Text != "")
                EMPRESABE.IIPWEBSERVICEAPPINV = this.txtIPWsAppInventario.Text.ToString();

            if (this.txtRutaBDAppInventario.Text != "")
                EMPRESABE.IRUTABDAPPINVENTARO = this.txtRutaBDAppInventario.Text.ToString();

            if (this.txtRutaDBFExistenciaSuc.Text != "")
                EMPRESABE.IRUTADBFEXISTENCIASUC = this.txtRutaDBFExistenciaSuc.Text.ToString();


            if (this.MOVILVERIFICARVENTAComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOVILVERIFICARVENTA = this.MOVILVERIFICARVENTAComboBox.Text;
            }


            if (this.PENDMAXDIASTextBox.NumericValue != null)
            {
                EMPRESABE.IPENDMAXDIAS = int.Parse(this.PENDMAXDIASTextBox.NumericValue.ToString());
            }



            if (this.REQAUTCANCELARCOTIComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IREQAUTCANCELARCOTI = this.REQAUTCANCELARCOTIComboBox.Text;
            }


            if (this.REQAUTELIMDETALLECOTIComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IREQAUTELIMDETALLECOTI = this.REQAUTELIMDETALLECOTIComboBox.Text;
            }


            if (this.ABRIRCAJONALFINCORTEComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IABRIRCAJONALFINCORTE = this.ABRIRCAJONALFINCORTEComboBox.Text;
            }



            if (this.HABSURTIDOPOSTPUESTOTextBox.Text != "")
            {
                EMPRESABE.IHABSURTIDOPOSTPUESTO = this.HABSURTIDOPOSTPUESTOTextBox.Text.ToString();
            }

            if (this.HABVERIFICACIONCXCTextBox.Text != "")
            {
                EMPRESABE.IHABVERIFICACIONCXC = this.HABVERIFICACIONCXCTextBox.Text.ToString();
            }

            if (!(this.CLIENTECONSOLIDADOIDTextBox.Text == "" || Int64.Parse(this.CLIENTECONSOLIDADOIDTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.ICLIENTECONSOLIDADOID = Int64.Parse(this.CLIENTECONSOLIDADOIDTextBox.DbValue.ToString());
            }


            if (this.DOBLECOPIAREMISIONComboBox.Text != "")
            {
                EMPRESABE.IDOBLECOPIAREMISION = this.DOBLECOPIAREMISIONComboBox.Text.ToString();
            }



            if (this.REIMPRESIONESCONMARCAComboBox.Text != "")
            {
                EMPRESABE.IREIMPRESIONESCONMARCA = this.REIMPRESIONESCONMARCAComboBox.Text.ToString();
            }


            if (this.HABTOTALIZADOSTextBox.Text != "")
            {
                EMPRESABE.IHABTOTALIZADOS = this.HABTOTALIZADOSTextBox.Text.ToString();
            }



            if (this.MULTIPLETIPOVALETextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMULTIPLETIPOVALE = this.MULTIPLETIPOVALETextBox.Text;
            }


            if (this.DESCUENTOTIPO1TEXTOTextBox.Text != "")
            {
                EMPRESABE.IDESCUENTOTIPO1TEXTO = this.DESCUENTOTIPO1TEXTOTextBox.Text.ToString();
            }


            if (this.DESCUENTOTIPO1PORCTextBox.NumericValue != null)
            {
                EMPRESABE.IDESCUENTOTIPO1PORC = decimal.Parse(this.DESCUENTOTIPO1PORCTextBox.NumericValue.ToString());
            }


            if (this.DESCUENTOTIPO2TEXTOTextBox.Text != "")
            {
                EMPRESABE.IDESCUENTOTIPO2TEXTO = this.DESCUENTOTIPO2TEXTOTextBox.Text.ToString();
            }


            if (this.DESCUENTOTIPO2PORCTextBox.NumericValue != null)
            {
                EMPRESABE.IDESCUENTOTIPO2PORC = decimal.Parse(this.DESCUENTOTIPO2PORCTextBox.NumericValue.ToString());
            }

            if (this.DESCUENTOTIPO3TEXTOTextBox.Text != "")
            {
                EMPRESABE.IDESCUENTOTIPO3TEXTO = this.DESCUENTOTIPO3TEXTOTextBox.Text.ToString();
            }


            if (this.DESCUENTOTIPO3PORCTextBox.NumericValue != null)
            {
                EMPRESABE.IDESCUENTOTIPO3PORC = decimal.Parse(this.DESCUENTOTIPO3PORCTextBox.NumericValue.ToString());
            }


            if (this.DESCUENTOTIPO4TEXTOTextBox.Text != "")
            {
                EMPRESABE.IDESCUENTOTIPO4TEXTO = this.DESCUENTOTIPO4TEXTOTextBox.Text.ToString();
            }


            if (this.DESCUENTOTIPO4PORCTextBox.NumericValue != null)
            {
                EMPRESABE.IDESCUENTOTIPO4PORC = decimal.Parse(this.DESCUENTOTIPO4PORCTextBox.NumericValue.ToString());
            }




            if (this.HABILITARLOGComboBox.Text != "")
            {
                EMPRESABE.IHABILITARLOG = this.HABILITARLOGComboBox.Text.ToString();
            }


            if (this.MONTORETIROCAJATextBox.NumericValue != null)
            {
                EMPRESABE.IMONTORETIROCAJA = decimal.Parse(this.MONTORETIROCAJATextBox.NumericValue.ToString());
            }

            if (this.MANEJARRETIRODECAJATextBox.Text != "")
            {
                EMPRESABE.IMANEJARRETIRODECAJA = this.MANEJARRETIRODECAJATextBox.Text.ToString();
            }



            if (this.APLICARMAYOREOPORLINEATextBox.Text != "")
            {
                EMPRESABE.IAPLICARMAYOREOPORLINEA = this.APLICARMAYOREOPORLINEATextBox.Text.ToString();
            }

            if (this.COMISIONPORTARJETATextBox.NumericValue != null)
            {
                EMPRESABE.ICOMISIONPORTARJETA = decimal.Parse(this.COMISIONPORTARJETATextBox.NumericValue.ToString());
            }

            if (this.COMISIONDEBPORTARJETATextBox.NumericValue != null)
            {
                EMPRESABE.ICOMISIONDEBPORTARJETA = decimal.Parse(this.COMISIONDEBPORTARJETATextBox.NumericValue.ToString());
            }

            if (this.PIEZASIGUALESMEDIOMAYOREOTextBox.NumericValue != null)
            {
                EMPRESABE.IPIEZASIGUALESMEDIOMAYOREO = decimal.Parse(this.PIEZASIGUALESMEDIOMAYOREOTextBox.NumericValue.ToString());
            }


            if (this.PIEZASDIFMEDIOMAYOREOTextBox.NumericValue != null)
            {
                EMPRESABE.IPIEZASDIFMEDIOMAYOREO = decimal.Parse(this.PIEZASDIFMEDIOMAYOREOTextBox.NumericValue.ToString());
            }


            if (this.PIEZASIGUALESMAYOREOTextBox.NumericValue != null)
            {
                EMPRESABE.IPIEZASIGUALESMAYOREO = decimal.Parse(this.PIEZASIGUALESMAYOREOTextBox.NumericValue.ToString());
            }


            if (this.PIEZASDIFMAYOREOTextBox.NumericValue != null)
            {
                EMPRESABE.IPIEZASDIFMAYOREO = decimal.Parse(this.PIEZASDIFMAYOREOTextBox.NumericValue.ToString());
            }


            if (this.COMISIONTARJETAEMPRESATextBox.NumericValue != null)
            {
                EMPRESABE.ICOMISIONTARJETAEMPRESA = decimal.Parse(this.COMISIONTARJETAEMPRESATextBox.NumericValue.ToString());
            }

            if (this.IVACOMISIONTARJETAEMPRESATextBox.NumericValue != null)
            {
                EMPRESABE.IIVACOMISIONTARJETAEMPRESA = decimal.Parse(this.IVACOMISIONTARJETAEMPRESATextBox.NumericValue.ToString());
            }


            if (this.COMISIONDEBTARJETAEMPRESATextBox.NumericValue != null)
            {
                EMPRESABE.ICOMISIONDEBTARJETAEMPRESA = decimal.Parse(this.COMISIONDEBTARJETAEMPRESATextBox.NumericValue.ToString());
            }
            


            if (this.PREGUNTACANCELACOTIZACIONTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPREGUNTACANCELACOTIZACION = this.PREGUNTACANCELACOTIZACIONTextBox.Text;
            }


            if (this.MAILEJECUTIVOTextBox.Text != "")
                EMPRESABE.IMAILEJECUTIVO = this.MAILEJECUTIVOTextBox.Text.ToString();


            if (this.VENTASXCORTEEMAILTextBox.Text != "")
            {
                EMPRESABE.IVENTASXCORTEEMAIL = this.VENTASXCORTEEMAILTextBox.Text.ToString();
            }


            if (this.HABVENTASAFUTUROComboBox.Text != "")
            {
                EMPRESABE.IHABVENTASAFUTURO = this.HABVENTASAFUTUROComboBox.Text.ToString();
            }


            if (this.FORMATOTICKETCORTOIDComboBox.Text != "")
            {
                if (this.FORMATOTICKETCORTOIDComboBox.SelectedIndex > 0)
                {
                    EMPRESABE.IFORMATOTICKETCORTOID = (Int64)this.FORMATOTICKETCORTOIDComboBox.SelectedIndex;
                }
                else
                {
                    EMPRESABE.IFORMATOTICKETCORTOID = 0;
                }
            }


            if (this.SERIESATABONOTextBox.Text != "")
            {
                EMPRESABE.ISERIESATABONO = this.SERIESATABONOTextBox.Text.ToString();
            }



            if (this.HABIMPRESIONCORTECAJEROComboBox.Text != "")
            {
                EMPRESABE.IHABIMPRESIONCORTECAJERO = this.HABIMPRESIONCORTECAJEROComboBox.Text.ToString();
            }


            if (this.HABTRASLADOPORAUTORIZACIONComboBox.Text != "")
            {
                EMPRESABE.IHABTRASLADOPORAUTORIZACION = this.HABTRASLADOPORAUTORIZACIONComboBox.Text.ToString();
            }

           
             EMPRESABE.ITIMEOUTPINDISTSALE = int.Parse(this.nudTimeOutPin.Value.ToString());
            

            
            EMPRESABE.ITIMEOUTPINDISTSALESERV = int.Parse(this.TIMEOUTPINTDISTSALESERVTextBox.Value.ToString());
           



            if (this.nudTimeOutLookUp.Value != null)
            {
                EMPRESABE.ITIMEOUTLOOKUP = int.Parse(this.nudTimeOutLookUp.Value.ToString());
            }

            if (this.txtRutaAdjuntarArchivo.Text != "")
            {
                EMPRESABE.IRUTAARCHIVOSADJUNTOS = this.txtRutaAdjuntarArchivo.Text.ToString();
            }


            if (this.HABPROMOXMONTOMINTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHABPROMOXMONTOMIN = this.HABPROMOXMONTOMINTextBox.Text;
            }


            if (this.FORMATOFACTURAComboBox.Text != "")
            {
                EMPRESABE.IFORMATOFACTELECT = this.FORMATOFACTURAComboBox.Text.ToString();
            }


            if (!(this.LINEAIDRecTextBox.Text == "" || Int64.Parse(this.LINEAIDRecTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IEMIDARECARGALINEAID = Int64.Parse(this.LINEAIDRecTextBox.DbValue.ToString());
            }


            if (!(this.MARCAIDRecTextBox.Text == "" || Int64.Parse(this.MARCAIDRecTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IEMIDARECARGAMARCAID = Int64.Parse(this.MARCAIDRecTextBox.DbValue.ToString());
            }


            if (!(this.PROVEEDOR1IDRecTextBox.Text == "" || Int64.Parse(this.PROVEEDOR1IDRecTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IEMIDARECARGAPROVEEDORID = Int64.Parse(this.PROVEEDOR1IDRecTextBox.DbValue.ToString());
            }


            if (!(this.LINEAIDServTextBox.Text == "" || Int64.Parse(this.LINEAIDServTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IEMIDASERVICIOLINEAID = Int64.Parse(this.LINEAIDServTextBox.DbValue.ToString());
            }


            if (!(this.MARCAIDServTextBox.Text == "" || Int64.Parse(this.MARCAIDServTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IEMIDASERVICIOMARCAID = Int64.Parse(this.MARCAIDServTextBox.DbValue.ToString());
            }


            if (!(this.PROVEEDOR1IDServTextBox.Text == "" || Int64.Parse(this.PROVEEDOR1IDServTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.IEMIDASERVICIOPROVEEDORID = Int64.Parse(this.PROVEEDOR1IDServTextBox.DbValue.ToString());
            }



            if (this.txtPorcUtilidadRecargas.NumericValue != null)
            {
                EMPRESABE.IEMIDAPORCUTILIDADRECARGAS = decimal.Parse(this.txtPorcUtilidadRecargas.NumericValue.ToString());
            }

            EMPRESABE.IMONTOMAXSALDOMENOR = decimal.Parse(this.MONTOMAXSALDOMENORNumericTextBox.NumericValue.ToString());


            if (this.txtUtilidadPagoServicio.NumericValue != null)
            {
                EMPRESABE.IEMIDAUTILIDADPAGOSERVICIOS = decimal.Parse(this.txtUtilidadPagoServicio.NumericValue.ToString());
            }

           

            if (this.PRECIOSORDENADOSTextBox.Text != "")
            {
                EMPRESABE.IPRECIOSORDENADOS = this.PRECIOSORDENADOSTextBox.Text.ToString();
            }


            if (this.DECIMALESENCANTIDADTextBox.NumericValue != null)
            {
                EMPRESABE.IDECIMALESENCANTIDAD = int.Parse(this.DECIMALESENCANTIDADTextBox.NumericValue.ToString());
            }


            if (this.EANPUEDEREPETIRSETextBox.Text != "")
            {
                EMPRESABE.IEANPUEDEREPETIRSE = this.EANPUEDEREPETIRSETextBox.Text.ToString();
            }

            if (this.HAB_PRECIOSCLIENTETextBox.Text != "")
            {
                EMPRESABE.IHAB_PRECIOSCLIENTE = this.HAB_PRECIOSCLIENTETextBox.Text.ToString();
            }


            if (this.CXCVALIDARTRASLADOSTextBox.Text != "")
            {
                EMPRESABE.ICXCVALIDARTRASLADOS = this.CXCVALIDARTRASLADOSTextBox.Text.ToString();
            }


            if (this.PREGUNTARSIESACREDITOTextBox.Text != "")
            {
                EMPRESABE.IPREGUNTARSIESACREDITO = this.PREGUNTARSIESACREDITOTextBox.Text.ToString();
            }

            if (this.HABMENSAJERIAComboBox.Text != "")
            {
                EMPRESABE.IHABMENSAJERIA = this.HABMENSAJERIAComboBox.Text.ToString();
            }


            if (this.WSMENSAJERIATextBox.Text != "")
            {
                EMPRESABE.IWSMENSAJERIA = this.WSMENSAJERIATextBox.Text.ToString();
            }

            if(this.CADUCIDADMINIMATextBox.Text != "")
            {
                EMPRESABE.ICADUCIDADMINIMA = int.Parse(this.CADUCIDADMINIMATextBox.Text.ToString());
            }
            else
            {
                EMPRESABE.ICADUCIDADMINIMA = 0;
            }

            EMPRESABE.IHABDESCLINEAPERSONA = (this.DESCUENTOLINEAPERSONACheckBox.Checked) ? "S" : "N";

            EMPRESABE.IMANEJARLOTEIMPORTACION = (this.MANEJARLOTEIMPORTACIONCheckBox.Checked) ? "S" : "N";

            EMPRESABE.IMANEJAGASTOSADIC = (this.MANEJAGASTOSADICCheckBox.Checked) ? "S" : "N";

            if (this.cmbPrecioDifInv.Text != "")
            {
                EMPRESABE.IPRECIOAJUSTEDIFINV = this.cmbPrecioDifInv.Text.ToString();
            }

            EMPRESABE.IHABBOTONPAGOVALE = (this.cbHabBtnPagoVale.Checked) ? "S" : "N";

            EMPRESABE.IUNICAVISITAPORDOCTO = (this.unicaVisitaPorDoctoCheckBox.Checked) ? "S" : "N";

            EMPRESABE.IAUTOCOMPLETECONEXISENVENTA = (this.autocompleteConExistenciaCB.Checked) ? "S" : "N";


            if (this.ALMACENRECEPCIONIDTextBox.Text != "")
            {
                EMPRESABE.IALMACENRECEPCIONID = long.Parse(this.ALMACENRECEPCIONIDTextBox.SelectedValue.ToString());
            }


            if (this.HAB_DEVOLUCIONTRASLADOComboBox.Text != "")
            {
                EMPRESABE.IHAB_DEVOLUCIONTRASLADO = this.HAB_DEVOLUCIONTRASLADOComboBox.Text.ToString();
            }

            if (this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Text != "")
            {
                EMPRESABE.IHAB_DEVOLUCIONSURTIDOSUC = this.HAB_DEVOLUCIONSURTIDOSUCComboBox.Text.ToString();
            }


            if (this.VERSIONWSEXISTENCIASTextBox.Text != "")
            {
                EMPRESABE.IVERSIONWSEXISTENCIAS = int.Parse(this.VERSIONWSEXISTENCIASTextBox.Text.ToString());
            }
            else
            {
                EMPRESABE.IVERSIONWSEXISTENCIAS = 1;
            }


            if (this.MOSTRARINVINFOADICPRODTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOSTRARINVINFOADICPROD = this.MOSTRARINVINFOADICPRODTextBox.Text;
            }

            if (!(this.METPAGOSATIDTextBox.Text == "" || Int64.Parse(this.METPAGOSATIDTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.ISAT_METODOPAGOID = Int64.Parse(this.METPAGOSATIDTextBox.DbValue.ToString());
            }

            EMPRESABE.IMANEJAPRODUCTOSPROMOCION = (this.MANEJAPRODUCTOSPROMOCIONCheckBox.Checked) ? "S" : "N";

            if(this.filtroProdSatComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ITIPOSELECCIONCATALOGOSAT = filtroProdSatComboBox.SelectedItem.ToString();
            }

            if (!(this.REGIMENSATFBTextBox.Text == "" || Int64.Parse(this.REGIMENSATFBTextBox.DbValue.ToString()) == 0))
            {
                EMPRESABE.ISAT_REGIMENFISCALID = Int64.Parse(this.REGIMENSATFBTextBox.DbValue.ToString());
            }


            if (this.PRECIONETOENGRIDSTextBox.Text != "")
            {
                EMPRESABE.IPRECIONETOENGRIDS = this.PRECIONETOENGRIDSTextBox.Text.ToString();
            }


            EMPRESABE.IPAGOSERVCONSOLIDADO = (this.PAGOSERVCONSOLIDADOTextBox.Checked) ? "S" : "N";



            if (this.WSESPECIALEXISTMATRIZTextBox.Text != "")
            {
                EMPRESABE.IWSESPECIALEXISTMATRIZ = this.WSESPECIALEXISTMATRIZTextBox.Text.ToString();
            }

            if (this.txtRutaReplicadorExe.Text != "")
            {
                EMPRESABE.IRUTAREPLICADOREXE = this.txtRutaReplicadorExe.Text.ToString();
            }

            EMPRESABE.IHAB_CONSOLIDADOAUTOMATICO = (this.HAB_CONSOLIDADOAUTOMATICOCheckBox.Checked) ? "S" : "N";


            if (this.TICKETESPECIALTextBox.Text != "")
            {
                EMPRESABE.ITICKETESPECIAL = this.TICKETESPECIALTextBox.Text.ToString();
            }

            if (this.TICKETDEFAULTPRINTERTextBox.Text != "")
            {
                EMPRESABE.ITICKETDEFAULTPRINTER = this.TICKETDEFAULTPRINTERTextBox.Text.ToString();
            }

            if (this.RECARGASDEFAULTPRINTERTextBox.Text != "")
            {
                EMPRESABE.IRECARGASDEFAULTPRINTER = this.RECARGASDEFAULTPRINTERTextBox.Text.ToString();
            }

            if (this.PIEZACAJAENTICKETComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPIEZACAJAENTICKET = this.PIEZACAJAENTICKETComboBox.Text;
            }


            if (this.NUMTICKETSABONOTextBox.NumericValue != null)
            {
                EMPRESABE.INUMTICKETSABONO = int.Parse(this.NUMTICKETSABONOTextBox.NumericValue.ToString());
            }

            


            if (this.PVCOLOREARTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IPVCOLOREAR = this.PVCOLOREARTextBox.SelectedIndex;
            }
            else
            {
                EMPRESABE.IPVCOLOREAR = 0 ;
            }



            if (this.INTENTOSRETIROCAJATextBox.NumericValue != null)
            {
                EMPRESABE.IINTENTOSRETIROCAJA = int.Parse(this.INTENTOSRETIROCAJATextBox.NumericValue.ToString());
            }
            else
            {
                EMPRESABE.IINTENTOSRETIROCAJA = 0;
            }



            if (!(this.VENDEDORMOVILCLAVETextBox.Text == ""))
            {
                EMPRESABE.IVENDEDORMOVILCLAVE = this.VENDEDORMOVILCLAVETextBox.DbValue.ToString();
            }


            if (this.MOVIL_TIENEVENDEDORESComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMOVIL_TIENEVENDEDORES = this.MOVIL_TIENEVENDEDORESComboBox.Text;
            }


            if (this.RUTACATALOGOSUPDTextBox.Text != "")
            {
                EMPRESABE.IRUTACATALOGOSUPD = this.RUTACATALOGOSUPDTextBox.Text.ToString();
            }


            if (this.IMPRIMIRCOPIAALMACENComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.IIMPRIMIRCOPIAALMACEN = this.IMPRIMIRCOPIAALMACENComboBox.Text;
            }

            EMPRESABE.IMOVIL3_PREIMPORTAR = (this.MOVIL3_PREIMPORTARCheckBox.Checked) ? "S" : "N";


            if (this.RUTAIMPORTADATOSTextBox.Text != "")
            {
                EMPRESABE.IRUTAIMPORTADATOS = this.RUTAIMPORTADATOSTextBox.Text.ToString();
            }

            EMPRESABE.IBUSQUEDATIPO2 = (this.cbBusquedaTipo2.Checked) ? "S" : "N";


            if (this.VERSIONCFDITextBox.Text != "")
            {
                EMPRESABE.IVERSIONCFDI = this.VERSIONCFDITextBox.Text.ToString();
            }


            if (!(this.AGRUPACIONVENTAIDTextBox.Text == ""))
            {
                EMPRESABE.IAGRUPACIONVENTAID = Int64.Parse(this.AGRUPACIONVENTAIDTextBox.DbValue.ToString());
            }


            EMPRESABE.ICONSFACTOMITIRVALES = (this.CONSFACTOMITIRVALESCheckBox.Checked) ? "S" : "N";


            EMPRESABE.IDESGLOSEIEPSFACTURA = (this.DESGLOSEIEPSFACTURATextBox.Checked) ? "S" : "N";

            if (this.DOBLECOPIACONTADOTextBox.NumericValue != null)
            {
                EMPRESABE.IDOBLECOPIACONTADO = int.Parse(this.DOBLECOPIACONTADOTextBox.NumericValue.ToString());
            }


            if (this.RUTAPOLIZAPDFTextBox.Text != "")
            {
                EMPRESABE.IRUTAPOLIZAPDF = this.RUTAPOLIZAPDFTextBox.Text.ToString();
            }


            EMPRESABE.IIMPRIMIRBANCOSCORTE = (this.IMPRIMIRBANCOSCORTEComboBox.Checked) ? "S" : "N";

            EMPRESABE.IIMPR_CANC_VENTA = (this.IMPR_CANC_VENTAComboBox.Checked) ? "S" : "N";


            if (this.RETIROCAJAALCERRARCORTETextBox.Text != "")
            {
                EMPRESABE.IRETIROCAJAALCERRARCORTE = this.RETIROCAJAALCERRARCORTETextBox.Text.ToString();
            }
            

            EMPRESABE.IPAGOTARJMENORPRECIOLISTAALL = (this.PAGOTARJMENORPRECIOLISTAALLTextBox.Checked) ? "S" : "N";

            EMPRESABE.IPREGUNTARSERVDOM = (this.PREGUNTARSERVDOMTextBox.Checked) ? "S" : "N";

            EMPRESABE.IHABPPC = (this.HABPPCTextBox.Checked) ? "S" : "N";

            EMPRESABE.ISOLOABONOAPLICADO = (this.SOLOABONOAPLICADOTextBox.Checked) ? "S" : "N";


            if (this.VERSIONTOPEIDTextBox.NumericValue != null)
            {
                EMPRESABE.IVERSIONTOPEID = long.Parse(this.VERSIONTOPEIDTextBox.NumericValue.ToString());
            }


            if (this.VERSIONCOMISIONIDTextBox.NumericValue != null)
            {
                EMPRESABE.IVERSIONCOMISIONID = long.Parse(this.VERSIONCOMISIONIDTextBox.NumericValue.ToString());
            }

            if (this.MAXCOMISIONXCLIENTETextBox.NumericValue != null)
            {
                EMPRESABE.IMAXCOMISIONXCLIENTE = decimal.Parse(this.MAXCOMISIONXCLIENTETextBox.NumericValue.ToString());
            }


            EMPRESABE.IIMPRFORMAVENTATRASL = (this.IMPRFORMAVENTATRASLTextBox.Checked) ? "S" : "N";

            if (this.HABREVISIONFINALTextBox.Text != "")
            {
                EMPRESABE.IHABREVISIONFINAL = this.HABREVISIONFINALTextBox.Text.ToString();
            }


            if (this.HABFONDODINAMICOTextBox.Text != "")
            {
                EMPRESABE.IHABFONDODINAMICO = this.HABFONDODINAMICOTextBox.Text.ToString();
            }

            if (this.HABVENTACLISUCTextBox.Text != "")
            {
                EMPRESABE.IHABVENTACLISUC = this.HABVENTACLISUCTextBox.Text.ToString();
            }


            

            if (this.SEGUNDOSCICLOFTPTextBox.NumericValue != null)
            {
                EMPRESABE.ISEGUNDOSCICLOFTP = int.Parse(this.SEGUNDOSCICLOFTPTextBox.NumericValue.ToString());
            }
            else
            {
                EMPRESABE.ISEGUNDOSCICLOFTP = 0;
            }

            if (this.DIASMAXEXPFTPTextBox.NumericValue != null)
            {
                EMPRESABE.IDIASMAXEXPFTP = int.Parse(this.DIASMAXEXPFTPTextBox.NumericValue.ToString());
            }
            else
            {
                EMPRESABE.IDIASMAXEXPFTP = 0;
            }


            if (this.DIASMAXIMPFTPTextBox.NumericValue != null)
            {
                EMPRESABE.IDIASMAXIMPFTP = int.Parse(this.DIASMAXIMPFTPTextBox.NumericValue.ToString());
            }
            else
            {
                EMPRESABE.IDIASMAXIMPFTP = 0;
            }



            if (this.WSDBFTextBox.Text != "")
            {
                EMPRESABE.IWSDBF = this.WSDBFTextBox.Text.ToString();
            }

            if (this.HABWSDBFTextBox.Text != "")
            {
                EMPRESABE.IHABWSDBF = this.HABWSDBFTextBox.Text.ToString();
            }


            if (this.FACTCONSMAXPORTextBox.NumericValue != null)
            {
                EMPRESABE.IFACTCONSMAXPOR = decimal.Parse(this.FACTCONSMAXPORTextBox.NumericValue.ToString());
            }



            if (this.DOBLECOPIATARJETATextBox.NumericValue != null)
            {
                EMPRESABE.IDOBLECOPIATARJETA = int.Parse(this.DOBLECOPIATARJETATextBox.NumericValue.ToString());
            }
            else
            {
                EMPRESABE.IDOBLECOPIATARJETA = 0;
            }


            EMPRESABE.IFISCALFECHACANCELACION2 = this.FISCALFECHACANCELACION2TextBox.Value;


            if (this.CANTTICKETRETIROTextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETRETIRO = int.Parse(this.CANTTICKETRETIROTextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETDEPOSITOSTextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETDEPOSITOS = int.Parse(this.CANTTICKETDEPOSITOSTextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETFONDOCAJATextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETFONDOCAJA = int.Parse(this.CANTTICKETFONDOCAJATextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETGASTOSTextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETGASTOS = int.Parse(this.CANTTICKETGASTOSTextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETCOMPRASTextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETCOMPRAS = int.Parse(this.CANTTICKETCOMPRASTextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETABRIRCORTETextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETABRIRCORTE = int.Parse(this.CANTTICKETABRIRCORTETextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETCIERRECORTETextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETCIERRECORTE = int.Parse(this.CANTTICKETCIERRECORTETextBox.NumericValue.ToString());
            }

            if (this.CANTTICKETRETIROTextBox.NumericValue != null)
            {
                EMPRESABE.ICANTTICKETCIERREBILLETES = int.Parse(this.CANTTICKETCIERREBILLETESTextBox.NumericValue.ToString());
            }


            if (this.MANEJAUTILIDADPRECIOSTextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IMANEJAUTILIDADPRECIOS = this.MANEJAUTILIDADPRECIOSTextBox.Text;
            }


            if (this.HABMULTPLAZOCOMPRATextBox.SelectedIndex >= 0)
            {
                EMPRESABE.IHABMULTPLAZOCOMPRA = this.HABMULTPLAZOCOMPRATextBox.Text;
            }


            if (this.COSTOREPOIGUALCOSTOULTComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ICOSTOREPOIGUALCOSTOULT = this.COSTOREPOIGUALCOSTOULTComboBox.Text;
            }

            if (this.TICKET_DESC_VALE_AL_FINALComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ITICKET_DESC_VALE_AL_FINAL = this.TICKET_DESC_VALE_AL_FINALComboBox.Text;
            }


            if (this.MONEDEROLISTAPRECIOIDComboBox.Text != "")
            {
                EMPRESABE.IMONEDEROLISTAPRECIOID = Int64.Parse(this.MONEDEROLISTAPRECIOIDComboBox.Text.ToString());
            }

            if (this.MONEDEROCAMPOREFTextBox.Text != "")
            {
                EMPRESABE.IMONEDEROCAMPOREF = this.MONEDEROCAMPOREFTextBox.Text.ToString();
            }


            if (this.HABSURTIDOPREVIOTextBox.Text != "")
            {
                EMPRESABE.IHABSURTIDOPREVIO = this.HABSURTIDOPREVIOTextBox.Text.ToString();
            }


            


            if (this.NUMTICKETSCOMANDATextBox.NumericValue != null)
            {
                EMPRESABE.INUMTICKETSCOMANDA = int.Parse(this.NUMTICKETSCOMANDATextBox.NumericValue.ToString());
            }



            if (this.IMPRESORACOMANDATextBox.Text != "")
            {
                EMPRESABE.IIMPRESORACOMANDA = this.IMPRESORACOMANDATextBox.Text.ToString();
            }

            if (this.RECIBOPREVIEWCOMANDATextBox.Text != "")
            {
                EMPRESABE.IRECIBOPREVIEWCOMANDA = this.RECIBOPREVIEWCOMANDATextBox.Text.ToString();
            }

            if (this.TICKET_IMPR_DESC2ComboBox.SelectedIndex >= 0)
            {
                EMPRESABE.ITICKET_IMPR_DESC2 = this.TICKET_IMPR_DESC2ComboBox.Text;
            }

            if (this.SERIECOMPRTRASLSATTextBox.Text != "")
            {
                EMPRESABE.ISERIECOMPRTRASLSAT = this.SERIECOMPRTRASLSATTextBox.Text.ToString();
            }


            if (this.HABSURTIDOPOSTMOVILTextBox.Text != "")
            {
                EMPRESABE.IHABSURTIDOPOSTMOVIL = this.HABSURTIDOPOSTMOVILTextBox.Text.ToString();
            }

            if (this.PORCUTILIDADLISTADOTextBox.NumericValue != null)
            {
                EMPRESABE.IPORCUTILIDADLISTADO = decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString());
            }


            if (this.RUTAFIRMAIMAGENESTextBox.Text != "")
            {
                EMPRESABE.IRUTAFIRMAIMAGENES = this.RUTAFIRMAIMAGENESTextBox.Text.ToString();
            }

            if (this.PORCUTILMACROLISTADOTextBox.NumericValue != null)
            {
                EMPRESABE.IPORCUTILMACROLISTADO = decimal.Parse(this.PORCUTILMACROLISTADOTextBox.NumericValue.ToString());
            }
            
            return EMPRESABE;
        }



        private CVERIFONECONFIGBE ObtenerDatosCapturadosVerifone()
        {
            CVERIFONECONFIGBE VERIFONECONFIGBE = new CVERIFONECONFIGBE();
            VERIFONECONFIGBE.IACTIVO = (this.VERIFONEACTIVOCheckBox.Checked) ? "S" : "N";

            if (this.VERIFONE_USERIDTextBox.Text != "")
                VERIFONECONFIGBE.IUSERID = this.VERIFONE_USERIDTextBox.Text.ToString();

            if (this.VERIFONE_CONTRASENATextBox.Text != "")
                VERIFONECONFIGBE.ICONTRASENA = this.VERIFONE_CONTRASENATextBox.Text.ToString();

            if (this.VERIFONE_SHIFTNUMBERTextBox.Text != "")
                VERIFONECONFIGBE.ISHIFTNUMBER = this.VERIFONE_SHIFTNUMBERTextBox.Text.ToString();

            if (this.VERIFONE_MERCHANTIDTextBox.Text != "")
                VERIFONECONFIGBE.IMERCHANTID = this.VERIFONE_MERCHANTIDTextBox.Text.ToString();

            if (this.VERIFONE_OPERATORLOCALETextBox.Text != "")
                VERIFONECONFIGBE.IOPERATORLOCALE = this.VERIFONE_OPERATORLOCALETextBox.Text.ToString();
            




            return VERIFONECONFIGBE;

        }


        private CLOOKUPBE ObtenerDatosCapturadosLookUps()
        {
            CLOOKUPBE lookup = new CLOOKUPBE();

            lookup.ICAMPO1 = (this.L1CAMPO1CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO2 = (this.L1CAMPO2CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO3 = (this.L1CAMPO3CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO4 = (this.L1CAMPO4CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO5 = (this.L1CAMPO5CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO6 = (this.L1CAMPO6CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO7 = (this.L1CAMPO7CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO8 = (this.L1CAMPO8CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO9 = (this.L1CAMPO9CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO10 = (this.L1CAMPO10CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO11 = (this.L1CAMPO11CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO12 = (this.L1CAMPO12CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO13 = (this.L1CAMPO13CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO14 = (this.L1CAMPO14CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO15 = (this.L1CAMPO15CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO16 = (this.L1CAMPO16CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO17 = (this.L1CAMPO17CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO18 = (this.L1CAMPO18CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO19 = (this.L1CAMPO19CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO20 = (this.L1CAMPO20CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO21 = (this.L1CAMPO21CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO22 = (this.L1CAMPO22CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO23 = (this.L1CAMPO23CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO24 = (this.L1CAMPO24CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO25 = (this.L1CAMPO25CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO26 = (this.L1CAMPO26CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO27 = (this.L1CAMPO27CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO28 = (this.L1CAMPO28CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO29 = (this.L1CAMPO29CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO30 = (this.L1CAMPO30CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO31 = (this.L1CAMPO31CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO32 = (this.L1CAMPO32CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO33 = (this.L1CAMPO33CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO34 = (this.L1CAMPO34CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO35 = (this.L1CAMPO35CheckBox.Checked) ? "S" : "N";

            lookup.ICAMPO36 = (this.L1CAMPO36CheckBox.Checked) ? "S" : "N";


            if (this.L1LBL_CAMPO1TextBox.Text != "")
            {
                lookup.ILBL_CAMPO1 = this.L1LBL_CAMPO1TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO2TextBox.Text != "")
            {
                lookup.ILBL_CAMPO2 = this.L1LBL_CAMPO2TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO3TextBox.Text != "")
            {
                lookup.ILBL_CAMPO3 = this.L1LBL_CAMPO3TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO4TextBox.Text != "")
            {
                lookup.ILBL_CAMPO4 = this.L1LBL_CAMPO4TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO5TextBox.Text != "")
            {
                lookup.ILBL_CAMPO5 = this.L1LBL_CAMPO5TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO6TextBox.Text != "")
            {
                lookup.ILBL_CAMPO6 = this.L1LBL_CAMPO6TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO7TextBox.Text != "")
            {
                lookup.ILBL_CAMPO7 = this.L1LBL_CAMPO7TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO8TextBox.Text != "")
            {
                lookup.ILBL_CAMPO8 = this.L1LBL_CAMPO8TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO9TextBox.Text != "")
            {
                lookup.ILBL_CAMPO9 = this.L1LBL_CAMPO9TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO10TextBox.Text != "")
            {
                lookup.ILBL_CAMPO10 = this.L1LBL_CAMPO10TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO11TextBox.Text != "")
            {
                lookup.ILBL_CAMPO11 = this.L1LBL_CAMPO11TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO12TextBox.Text != "")
            {
                lookup.ILBL_CAMPO12 = this.L1LBL_CAMPO12TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO13TextBox.Text != "")
            {
                lookup.ILBL_CAMPO13 = this.L1LBL_CAMPO13TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO14TextBox.Text != "")
            {
                lookup.ILBL_CAMPO14 = this.L1LBL_CAMPO14TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO15TextBox.Text != "")
            {
                lookup.ILBL_CAMPO15 = this.L1LBL_CAMPO15TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO16TextBox.Text != "")
            {
                lookup.ILBL_CAMPO16 = this.L1LBL_CAMPO16TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO17TextBox.Text != "")
            {
                lookup.ILBL_CAMPO17 = this.L1LBL_CAMPO17TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO18TextBox.Text != "")
            {
                lookup.ILBL_CAMPO18 = this.L1LBL_CAMPO18TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO19TextBox.Text != "")
            {
                lookup.ILBL_CAMPO19 = this.L1LBL_CAMPO19TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO20TextBox.Text != "")
            {
                lookup.ILBL_CAMPO20 = this.L1LBL_CAMPO20TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO21TextBox.Text != "")
            {
                lookup.ILBL_CAMPO21 = this.L1LBL_CAMPO21TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO22TextBox.Text != "")
            {
                lookup.ILBL_CAMPO22 = this.L1LBL_CAMPO22TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO23TextBox.Text != "")
            {
                lookup.ILBL_CAMPO23 = this.L1LBL_CAMPO23TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO24TextBox.Text != "")
            {
                lookup.ILBL_CAMPO24 = this.L1LBL_CAMPO24TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO25TextBox.Text != "")
            {
                lookup.ILBL_CAMPO25 = this.L1LBL_CAMPO25TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO26TextBox.Text != "")
            {
                lookup.ILBL_CAMPO26 = this.L1LBL_CAMPO26TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO27TextBox.Text != "")
            {
                lookup.ILBL_CAMPO27 = this.L1LBL_CAMPO27TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO28TextBox.Text != "")
            {
                lookup.ILBL_CAMPO28 = this.L1LBL_CAMPO28TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO29TextBox.Text != "")
            {
                lookup.ILBL_CAMPO29 = this.L1LBL_CAMPO29TextBox.Text.ToString();
            }

            if (this.L1LBL_CAMPO30TextBox.Text != "")
            {
                lookup.ILBL_CAMPO30 = this.L1LBL_CAMPO30TextBox.Text.ToString();
            }
            if (this.L1LBL_CAMPO31TextBox.Text != "")
            {
                lookup.ILBL_CAMPO31 = this.L1LBL_CAMPO31TextBox.Text.ToString();
            }
            if(this.L1LBL_CAMPO32TextBox.Text != "")
            {
                lookup.ILBL_CAMPO32 = this.L1LBL_CAMPO32TextBox.Text.ToString();
            }
            if(this.L1LBL_CAMPO33TextBox.Text != "")
            {
                lookup.ILBL_CAMPO33 = this.L1LBL_CAMPO33TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO34TextBox.Text != "")
            {
                lookup.ILBL_CAMPO34 = this.L1LBL_CAMPO34TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO35TextBox.Text != "")
            {
                lookup.ILBL_CAMPO35 = this.L1LBL_CAMPO35TextBox.Text.ToString();
            }


            if (this.L1LBL_CAMPO36TextBox.Text != "")
            {
                lookup.ILBL_CAMPO36 = this.L1LBL_CAMPO36TextBox.Text.ToString();
            }


            return lookup;
        }


        private CLOOKUPBE ObtenerDatosCapturadosLookUpsVerificador()
        {
            CLOOKUPBE lookup = new CLOOKUPBE();

            lookup.ICAMPO1 = (this.L2CAMPO1CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO2 = (this.L2CAMPO2CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO3 = (this.L2CAMPO3CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO4 = (this.L2CAMPO4CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO5 = (this.L2CAMPO5CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO6 = (this.L2CAMPO6CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO7 = (this.L2CAMPO7CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO8 = (this.L2CAMPO8CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO9 = (this.L2CAMPO9CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO10 = (this.L2CAMPO10CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO11 = (this.L2CAMPO11CheckBox.Checked) ? "S" : "N";
            lookup.ICAMPO12 = (this.L2CAMPO12CheckBox.Checked) ? "S" : "N";


            lookup.ICAMPO13 = "N";
            lookup.ICAMPO14 = "N";
            lookup.ICAMPO15 = "N";
            lookup.ICAMPO16 = "N";
            lookup.ICAMPO17 = "N";
            lookup.ICAMPO18 = "N";
            lookup.ICAMPO19 = "N";
            lookup.ICAMPO20 = "N";
            lookup.ICAMPO21 = "N";
            lookup.ICAMPO22 = "N";
            lookup.ICAMPO23 = "N";
            lookup.ICAMPO24 = "N";
            lookup.ICAMPO25 = "N";
            lookup.ICAMPO26 = "N";
            lookup.ICAMPO27 = "N";
            lookup.ICAMPO28 = "N";
            lookup.ICAMPO29 = "N";
            lookup.ICAMPO30 = "N";
            lookup.ICAMPO31 = "N";
            lookup.ICAMPO32 = "N";
            lookup.ICAMPO33 = "N";
            lookup.ICAMPO34 = "N";
            lookup.ICAMPO35 = "N";
            lookup.ICAMPO36 = "N";


            if (this.L2LBL_CAMPO1TextBox.Text != "")
            {
                lookup.ILBL_CAMPO1 = this.L2LBL_CAMPO1TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO2TextBox.Text != "")
            {
                lookup.ILBL_CAMPO2 = this.L2LBL_CAMPO2TextBox.Text.ToString();
            }


            if (this.L2LBL_CAMPO3TextBox.Text != "")
            {
                lookup.ILBL_CAMPO3 = this.L2LBL_CAMPO3TextBox.Text.ToString();
            }


            if (this.L2LBL_CAMPO4TextBox.Text != "")
            {
                lookup.ILBL_CAMPO4 = this.L2LBL_CAMPO4TextBox.Text.ToString();
            }


            if (this.L2LBL_CAMPO5TextBox.Text != "")
            {
                lookup.ILBL_CAMPO5 = this.L2LBL_CAMPO5TextBox.Text.ToString();
            }


            if (this.L2LBL_CAMPO6TextBox.Text != "")
            {
                lookup.ILBL_CAMPO6 = this.L2LBL_CAMPO6TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO7TextBox.Text != "")
            {
                lookup.ILBL_CAMPO7 = this.L2LBL_CAMPO7TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO8TextBox.Text != "")
            {
                lookup.ILBL_CAMPO8 = this.L2LBL_CAMPO8TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO9TextBox.Text != "")
            {
                lookup.ILBL_CAMPO9 = this.L2LBL_CAMPO9TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO10TextBox.Text != "")
            {
                lookup.ILBL_CAMPO10 = this.L2LBL_CAMPO10TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO11TextBox.Text != "")
            {
                lookup.ILBL_CAMPO11 = this.L2LBL_CAMPO11TextBox.Text.ToString();
            }

            if (this.L2LBL_CAMPO12TextBox.Text != "")
            {
                lookup.ILBL_CAMPO12 = this.L2LBL_CAMPO12TextBox.Text.ToString();
            }

            

            return lookup;
        }

        private CCOMISIONPORLISTABE ObtenerDatosComisionesXLista()
        {
            CCOMISIONPORLISTABE item = new CCOMISIONPORLISTABE();

            if (this.RETENCIONISRTextBox.NumericValue != null)
            {
                item.IPRECIO1 = decimal.Parse(this.COMISIONPRECIO1TextBox.NumericValue.ToString());
                item.IPRECIO2 = decimal.Parse(this.COMISIONPRECIO2TextBox.NumericValue.ToString());
                item.IPRECIO3 = decimal.Parse(this.COMISIONPRECIO3TextBox.NumericValue.ToString());
                item.IPRECIO4 = decimal.Parse(this.COMISIONPRECIO4TextBox.NumericValue.ToString());
                item.IPRECIO5 = decimal.Parse(this.COMISIONPRECIO5TextBox.NumericValue.ToString());
                item.IPRECIOOTRO = decimal.Parse(this.COMISIONPRECIOOTROTextBox.NumericValue.ToString());
            }



            return item;
        }

        public void UpdateEmidaDataProc()
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            CEMIDAPRODUCTD adminEmidaProd = new CEMIDAPRODUCTD();

            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();


                //ante cualquier return o error
                if (!adminEmidaProd.EMIDA_AJUSTARCAMPOSPRODUCTOS(fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();

                    MessageBox.Show("Algo salio mal, no se pudo ajustar los campos de los productos de Emida !");
                    //comentario = "Error tal " ;
                    // bError = true;
                    return;
                }


                //en caso de exito
                fTrans.Commit();
                fConn.Close();
            }
            catch
            {
                try
                {
                    fTrans.Rollback();
                }
                catch { }

                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
        }



        public void UpdateComisionesXLista()
        {
            

            try
            {
                
                CCOMISIONPORLISTAD objD = new CCOMISIONPORLISTAD();
                CCOMISIONPORLISTABE item = ObtenerDatosComisionesXLista();

                //ante cualquier return o error
                if (!objD.SetCOMISIONPORLISTAD(item,null))
                {

                    MessageBox.Show("Algo salio mal, al actualizar las comisiones por lista !" + objD.IComentario);
                    //comentario = "Error tal " ;
                    // bError = true;
                    return;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Algo salio mal, al actualizar las comisiones por lista !" + ex.Message);
            }
            finally
            {
            }
        }



        public void UpdateVerifone()
        {


            try
            {
                CVERIFONECONFIGD verifoneD = new CVERIFONECONFIGD();
                CVERIFONECONFIGBE verifone = this.ObtenerDatosCapturadosVerifone();


                var verifonePrevious = verifoneD.seleccionarVERIFONECONFIG_Unico(null);
                if (verifonePrevious != null)
                {
                    verifone.IID = verifonePrevious.IID;
                    verifoneD.CambiarVERIFONECONFIG(verifone, verifonePrevious, null);
                }
                else
                {
                    verifoneD.AgregarVERIFONECONFIG(verifone, null);
                }

                if (verifoneD.IComentario != "" && verifoneD.IComentario != null)
                {
                    MessageBox.Show("Error al grabar los datos de verifone" + verifoneD.IComentario);
                }
                else
                {
                    PagoVerifoneHelper.LlenarConfiguracionVerifone(CurrentUserID.CurrentCaja.IID);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal, al actualizar las comisiones por lista !" + ex.Message);
            }
            finally
            {
            }
        }


        public void SaveChanges()
        {
            string ErroresValidacion = "";
            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);
            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {
                try
                {
                    CPARAMETROD EMPRESAD = new CPARAMETROD();

                    if (opc == "Cambiar")
                    {
                        CPARAMETROBE EMPRESABEAnt = new CPARAMETROBE();
                        CPARAMETROBE EMPRESABE = new CPARAMETROBE();

                        CLOOKUPBE lookupBE = new CLOOKUPBE();
                        CLOOKUPBE lookupBEVerificador = new CLOOKUPBE();
                        CLOOKUPD lookupD = new CLOOKUPD();

                        EMPRESABE = ObtenerDatosCapturados();

                        if (EMPRESABE != null)
                        {
                            EMPRESABEAnt.INOMBRE = this.NOMBRE;
                            EMPRESAD.CambiarPARAMETRO(EMPRESABE, EMPRESABEAnt, null);
                            if (EMPRESAD.IComentario == "" || EMPRESAD.IComentario == null)
                            {

                                lookupBE = ObtenerDatosCapturadosLookUps();
                                lookupBE.ICLAVE = "PRODUCTO";

                                lookupBEVerificador = ObtenerDatosCapturadosLookUpsVerificador();
                                lookupBEVerificador.ICLAVE = "VERIFICADOR";

                                lookupD.CambiarCamposLOOKUPD(lookupBEVerificador, lookupBEVerificador, null);

                                if (lookupD.CambiarCamposLOOKUPD(lookupBE, lookupBE, null))
                                {

                                    MessageBox.Show("El registro se ha cambiado");
                                    Limpiar(true);
                                    LimpiarLookUps();
                                    this.opc = "";
                                    this.HabilitarEdicion(false);

                                    EMPRESABE = EMPRESAD.seleccionarPARAMETROActual(null);
                                    iPos.CurrentUserID.CurrentParameters = EMPRESABE;
                                    iPos.CurrentUserID.SUCURSAL_CLAVE = EMPRESABE.ISUCURSALNUMERO;
                                    iPos.CurrentUserID.currentPrinter = Ticket.GetReceiptPrinter();
                                    iPos.CurrentUserID.CurrentPrinterRecargas = Ticket.GetReceiptPrinterRecargas();
                                    ConexionesBD.ConexionBD.currentPrinter = iPos.CurrentUserID.currentPrinter;

                                    iPos.Tools.FTPManagement.ObtenerDatosConexionFTP();
                                    EnviosMail.ObtenerDatosConexionSMTP();

                                    if (!iPos.CurrentUserID.listados.ContainsKey("PRODUCTO"))
                                    {
                                        iPos.CurrentUserID.listados.Add("PRODUCTO", lookupBE);
                                    }
                                    else
                                    {
                                        iPos.CurrentUserID.listados["PRODUCTO"] = lookupBE;
                                    }

                                    if (emidaDataChanged)
                                    {
                                        UpdateEmidaDataProc();
                                        emidaDataChanged = false;
                                    }

                                    if(comisionPreciosChanged)
                                    {
                                        UpdateComisionesXLista();
                                        comisionPreciosChanged = false;
                                    }

                                    if (verifoneDataChanged)
                                    {
                                        UpdateVerifone();
                                        verifoneDataChanged = false;
                                    }

                                    SiAplicaReenviarExistenciaAWebService();

                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("ERRORES: " + lookupD.IComentario.Replace("%", "\n"));
                                }


                            }
                            else
                                MessageBox.Show("ERRORES: " + EMPRESAD.IComentario.Replace("%", "\n"));
                        }
                        else
                            MessageBox.Show("ERROR: No puede dejar en blanco el campo sucursal");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(ErroresValidacion);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }
        private void HabilitarEdicion(bool b)
        {
            HabilitarValidadores(false);
            panel1.Enabled = b;
            HabilitarValidadores(true);
        }

        private void LimpiarVariablesForm()
        {
            this.NOMBRE = "";


        }
        private void Limpiar()
        {
            Limpiar(false);
        }
        private void Limpiar(bool bLimpiarKeys)
        {
            if (bLimpiarKeys)
            {
                this.NOMBRETextBox.Text = "";

            }


            this.CALLETextBox.Text = "";


            this.NUMEROEXTERIORTextBox.Text = "";

            this.NUMEROINTERIORTextBox.Text = "";

            this.COLONIATextBox.Text = "";

            this.LOCALIDADTextBox.Text = "";

            this.ESTADOTextBox.Text = "";

            this.CPTextBox.Text = "";

            this.TELEFONOTextBox.Text = "";

            this.FAXTextBox.Text = "";

            this.CORREOETextBox.Text = "";

            this.PAGINAWEBTextBox.Text = "";

            this.RFCTextBox.Text = "";
            this.LISTA_PRECIO_DEFTextBox.Text = "";
            this.IMP_PROD_DEFTextBox.Text = "";
            this.ESTADO_DEFTextBox.Text = "";
            this.SucursalComboBox.SelectedIndex = 0;
            this.UltimaFecha.Value = DateTime.Today;


            this.FTPHOSTTextBox.Text = "";
            this.FTPUSUARIOTextBox.Text = ""; 
            this.FTPPASSWORDTextBox.Text = ""; 
            this.SMTPHOSTTextBox.Text = ""; 
            this.SMTPUSUARIOTextBox.Text = ""; 
            this.SMTPPASSWORDTextBox.Text = "";
            this.SMTPPORTTextBox.Text = ""; 
            this.SMTPMAILFROMTextBox.Text = "";
            this.SMTPMAILTOTextBox.Text = "";
            this.MAILTOINVENTARIOTextBox.Text = "";
            this.FTPFOLDERTextBox.Text = "";
            this.FTPFOLDERPASSTextBox.Text = "";


            this.FISCALCALLETextBox.Text = "";
            this.FISCALNUMEROINTERIORTextBox.Text = "";
            this.FISCALNUMEROEXTERIORTextBox.Text = "";
            this.FISCALCOLONIATextBox.Text = "";
            this.FISCALMUNICIPIOTextBox.Text = "";
            this.FISCALESTADOTextBox.Text = "";
            this.FISCALCODIGOPOSTALTextBox.Text = "";

            this.CERTIFICADOCSDTextBox.Text = "";
            this.TIMBRADOUSERTextBox.Text = "";
            this.TIMBRADOPASSWORDTextBox.Text = "";
            this.TIMBRADOARCHIVOCERTIFICADOTextBox.Text = "";
            this.TIMBRADOARCHIVOKEYTextBox.Text = "";
            this.TIMBRADOKEYTextBox.Text = "";
            this.FISCALNOMBRETextBox.Text = "";

            this.SERIESATTextBox.Text = "";

            this.USARFISCALESENEXPEDICIONCheckBox.Checked = false;

            this.SERIESATDEVOLUCIONTextBox.Text = "";



            this.PREFIJOBASCULATextBox.Text = "";
            this.LONGPESOBASCULATextBox.Text = "";
            this.LONGPRODBASCULATextBox.Text = "";

            this.LISTAPRECIOXUEMPAQUEComboBox.Text = "";
            this.LISTAPRECIOXPZACAJAComboBox.Text = "";
            this.LISTAPRECIOINIMAYOComboBox.Text = "";

            this.LISTAPRECIOMAYLINEAComboBox.Text = "";
            this.LISTAPRECMEDMAYLINEAComboBox.Text = "";

            this.MONEDEROCADUCIDADTextBox.Text = "0";
            this.MONEDEROMONTOMINIMOTextBox.Text = "0.00";


            this.IMPRIMIRNUMEROPIEZASComboBox.SelectedIndex = 0;

            RUTAREPORTESTextBox.Text = "";

            RUTAREPORTESSISTEMATextBox.Text = "";

            this.FISCALREGIMENTextBox.Text = "";

            this.MINUTILIDADTextBox.Text = "";

            this.TIPODESCUENTOPRODIDTextBox.Text = "";

            this.TIPOUTILIDADIDTextBox.Text = "";



            this.LOCALFTPHOSTTextBox.Text = "";
            this.LOCALWEBSERVICETextBox.Text = "";

            this.RUTARESPALDOSZIPTextBox.Text = "";

            this.SCREENCONFIGTextBox.SelectedIndex = 0;

            this.CAMPOIMPOCOSTOREPOTextBox.SelectedIndex = 0;

            this.LISTAPRECIOMINIMOComboBox.Text = "";
            this.MAILEJECUTIVOTextBox.Text = "";
            this.MONTOMAXSALDOMENORNumericTextBox.NumericValue = 0.0;


            this.ALMACENRECEPCIONIDTextBox.Text = "";

            RUTACATALOGOSUPDTextBox.Text = "";
            RUTAIMPORTADATOSTextBox.Text = "";
            RUTAPOLIZAPDFTextBox.Text = "";

            this.SERIESATDEVOLUCIONTextBox.Text = "";



        }



        private void LimpiarDatosVerifone()
        {

            this.VERIFONEACTIVOCheckBox.Checked = false;
            this.VERIFONE_USERIDTextBox.Text = "";
            this.VERIFONE_CONTRASENATextBox.Text = "";
            this.VERIFONE_SHIFTNUMBERTextBox.Text = "";
            this.VERIFONE_MERCHANTIDTextBox.Text = "";
            this.VERIFONE_OPERATORLOCALETextBox.Text = "";


        }

        private void LimpiarLookUps()
        {
            this.L1CAMPO1CheckBox.Checked = false;
            this.L1CAMPO2CheckBox.Checked = false;
            this.L1CAMPO3CheckBox.Checked = false;
            this.L1CAMPO4CheckBox.Checked = false;
            this.L1CAMPO5CheckBox.Checked = false;
            this.L1CAMPO6CheckBox.Checked = false;
            this.L1CAMPO7CheckBox.Checked = false;
            this.L1CAMPO8CheckBox.Checked = false;
            this.L1CAMPO9CheckBox.Checked = false;
            this.L1CAMPO10CheckBox.Checked = false;
            this.L1CAMPO11CheckBox.Checked = false;
            this.L1CAMPO12CheckBox.Checked = false;
            this.L1CAMPO13CheckBox.Checked = false;
            this.L1CAMPO14CheckBox.Checked = false;
            this.L1CAMPO15CheckBox.Checked = false;
            this.L1CAMPO16CheckBox.Checked = false;
            this.L1CAMPO17CheckBox.Checked = false;
            this.L1CAMPO18CheckBox.Checked = false;
            this.L1CAMPO19CheckBox.Checked = false;
            this.L1CAMPO20CheckBox.Checked = false;
        }


        private void NOMBRETextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if (
              this.NOMBRETextBox.Text != ""
          )
            {


                this.NOMBRE = this.NOMBRETextBox.Text;
                this.opc = "Cambiar";
                HabilitarEdicion(true);

                /*if (this.LlenarDatosDeBase())
                {
                    this.opc = "Cambiar";
                    HabilitarEdicion(true);

                }
                else
                {
                    this.opc = "Agregar";
                    Limpiar();
                    HabilitarEdicion(true);

                }*/
            }
            else
            {
                Limpiar();
                HabilitarEdicion(false);

            }
        }

        private void NOMBRETextBox_Validated(object sender, EventArgs e)
        {
            SetMode();
        }
        private void btEliminar_Click(object sender, EventArgs e)
        {
            this.opc = "Borrar";
            SaveChanges();
        }
        public void Resetear()
        {
            HabilitarValidadores(false);
            Limpiar(true);
            this.opc = "";


            this.NOMBRETextBox.Focus();


            HabilitarValidadores(true);
            this.HabilitarEdicion(false);
        }
        public void HabilitarValidadores(bool bEnabled)
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    v.Enabled = bEnabled;
                }
                catch
                {
                }
            }
        }
        public void Validar(ref string ErroresValidacion, int iCamposAValidar)
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    if (iCamposAValidar == (int)CamposAValidar.ValidarKeys)
                    {
                        if (

                        v.ControlToValidate.Name != "NOMBRETextBox"
                        )
                            continue;
                    }
                    v.Validate();
                    if (!v.IsValid)
                    {
                        ErroresValidacion += v.ErrorMessage + "--";
                    }
                }
                catch
                {
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           //this.FTPFOLDERPASSTextBox.Text = EncDec.Encrypt(this.FTPFOLDERTextBox.Text, EncDec.PasswordDefault());
            if(emidaDataChanged)
            {
                if (MessageBox.Show("Se ha detectado cambios en los parametros de Emida, ¿Desea realizar los cambios de todas formas?", "Advertencia!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            if (!validarCodigoPostal(CPTextBox.Text) && CPTextBox.Text != "")
            {
                MessageBox.Show("El Código Postal Ingresado no es valido!");
                CPTextBox.Focus();
                return;
            }

            if (!validarCodigoPostal(FISCALCODIGOPOSTALTextBox.Text) && FISCALCODIGOPOSTALTextBox.Text != "")
            {
                MessageBox.Show("El Código Postal Fiscal Ingresado no es valido!");
                FISCALCODIGOPOSTALTextBox.Focus();
                return;
            }

            this.SaveChanges();
        }

        private void WFEmpresaEdit_Load(object sender, EventArgs e)
        {
            //pnlMovil.Visible = CurrentUserID.HABILITARVENDEDOR_MOVIL;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoModificarPagoServCons = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_MODIFICARPAGOSERVCONSOLIDADO, null);
            PAGOSERVCONSOLIDADOTextBox.Enabled = usuarioTienePermisoModificarPagoServCons; 

            if(CurrentUserID.CurrentCompania.IREPLICADOR != "S")
            {
                lblRutaReplicadorExe.Visible = false;
                txtRutaReplicadorExe.Visible = false;
            }
        }

        private void APLICARMAYOREOPORLINEATextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (!bLlenandoDatosDeBase && APLICARMAYOREOPORLINEATextBox.SelectedText.Equals("S"))
            {
                MessageBox.Show("Se deshabilitaran los campos de precio x caja y precio x empaque");
                CAMBIARPRECIOXPZACAJAComboBox.Enabled = false;
                LISTAPRECIOXPZACAJAComboBox.Enabled = false;
                CAMBIARPRECIOXUEMPAQUEComboBox.Enabled = false;
                LISTAPRECIOXUEMPAQUEComboBox.Enabled = false;
            }*/
        }

        private void FORMATOFACTURATextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void LINEAIDRecTextBox_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void MARCAIDRecTextBox_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void PROVEEDOR1IDRecTextBox_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void LINEAIDServTextBox_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void MARCAIDServTextBox_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void PROVEEDOR1IDServTextBox_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void txtPorcUtilidadRecargas_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }

        private void txtUtilidadPagoServicio_TextChanged(object sender, EventArgs e)
        {
            emidaDataChanged = true;
        }


        private void SiAplicaReenviarExistenciaAWebService()
        {
            if (m_paremtrosPrevios == null)
                return;


            if(m_paremtrosPrevios.IVERSIONWSEXISTENCIAS < iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS 
                && iPos.CurrentUserID.CurrentParameters.IVERSIONWSEXISTENCIAS > 1)
            {

                MessageBox.Show("Como cambio la version del webservice de existencias el sistema intentara exportar todas las existencias, este proceso puede tardar unos minutos, cuando finalize enviara un mensaje con el resultado de la exportacion, por mientras puede seguir trabajando");
                HiloExistencias._IFLAGENVIARINVENTARIO++;
            }
        }

        private bool validarCodigoPostal(string cp)
        {
            CSAT_CODIGOPOSTALBE codPostal = new CSAT_CODIGOPOSTALBE();
            CSAT_CODIGOPOSTALD daoCodPostal = new CSAT_CODIGOPOSTALD();
            codPostal.ISAT_CLAVE = cp;
            if (daoCodPostal.ExisteSAT_CODIGOPOSTALXCLAVE(codPostal, null) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void REGIMENSATLBL_TextChanged(object sender, EventArgs e)
        {
            this.FISCALREGIMENTextBox.Text = REGIMENSATLBL.Text;
        }

        private void SucursalComboBox_Click(object sender, EventArgs e)
        {
            
        }

        private void SucursalComboBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SucursalComboBox_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SucursalComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void SucursalComboBox_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Cambiar la sucursal podrá modificar los inventarios, ventas y almacen", "ALERTA");
        }

        private void TBComisiones_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

       

        private void COMISIONPRECIOTextBox_NumericValueChanged(object sender, EventArgs e)
        {
            comisionPreciosChanged = true;
        }

        private void VERIFONE_USERIDTextBox_TextChanged(object sender, EventArgs e)
        {
            verifoneDataChanged = true;
        }

        private void VERIFONE_CONTRASENATextBox_TextChanged(object sender, EventArgs e)
        {
            verifoneDataChanged = true;
        }

        private void VERIFONE_SHIFTNUMBERTextBox_TextChanged(object sender, EventArgs e)
        {
            verifoneDataChanged = true;
        }

        private void VERIFONE_MERCHANTIDTextBox_TextChanged(object sender, EventArgs e)
        {
            verifoneDataChanged = true;
        }

        private void VERIFONE_OPERATORLOCALETextBox_TextChanged(object sender, EventArgs e)
        {
            verifoneDataChanged = true;
        }

        private void VERIFONEACTIVOCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            verifoneDataChanged = true;
        }
    }
}
