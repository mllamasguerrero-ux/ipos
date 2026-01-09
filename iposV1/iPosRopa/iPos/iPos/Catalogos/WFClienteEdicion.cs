
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
using iPos.Catalogos;
using iPos.Reportes.MultiNivel;
using iPos.Surtir;
using System.Linq;
using System.IO;
using iPos.Utilerias.Mapa;
using System.Globalization;

namespace iPos
{
    public partial class WFClienteEdicion : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;


        public delegate void AccionHandler(object source, Hashtable evtArgs);
        //public event AccionHandler AccionUsuario;

        public CPERSONABE m_clienteOld = null;

        public bool bEntroACuenta = false;
        
        public string m_localidad_Sel_Query = @"SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIPCION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON (LOC.clave_estado = ESTADO.acronimo or (LOC.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO ORDER BY LOC.DESCRIPCION";
        public string m_localidad_Sel_Query_DeSeleccion = @"SELECT  LOC.ID id, LOC.CLAVE_LOCALIDAD clave, LOC.DESCRIPCION nombre ,LOC.DESCRIPCION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON (LOC.clave_estado = ESTADO.acronimo or (LOC.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO  and LOC.CLAVE_LOCALIDAD = @clave";
        
        public string m_municipio_Sel_Query = @"SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIPCION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON (MUN.clave_estado = ESTADO.acronimo or (MUN.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO ORDER BY MUN.DESCRIPCION";
        public string m_municipio_Sel_Query_DeSeleccion = @"SELECT MUN.ID id,  MUN.CLAVE_MUNICIPIO clave, MUN.DESCRIPCION nombre ,MUN.DESCRIPCION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON (MUN.clave_estado = ESTADO.acronimo or (MUN.clave_estado = 'DIF' and ESTADO.acronimo = 'CMX' )) WHERE ESTADO.clave = @CLAVEESTADO and MUN.CLAVE_MUNICIPIO = @clave";

        public string m_colonia_Sel_Query = @"SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_colonia C WHERE c.codigopostal = @CODIGOPOSTAL ORDER BY C.nombre";
        public string m_colonia_Sel_Query_DeSeleccion = @"SELECT  c.ID id, c.COLONIA clave, C.nombre nombre ,C.nombre descripcion FROM sat_colonia C WHERE c.codigopostal = @CODIGOPOSTAL  and c.COLONIA = @clave";

        bool m_terminoLoad = false;


        bool m_bChangeFirmaImage = false;
        string m_firmaImageExtension = "";


        long? m_currentDomicilioId = null;

        public WFClienteEdicion()
        {
            InitializeComponent();
            //this.SALUDOIDTextBox.llenarDatos();
        }


        public void ReCargar(string popc,string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);
            ESTADOTextBox.llenarDatos();
            ENTREGAESTADOTextBox.llenarDatos();
            putDefaultValuesFPClientesCreados();
            //validadores.Add((RFV_ID));
            //validadores.Add(RAV_ID);
            //validadores.Add(RAV_CREADOPOR_USERID);
            //validadores.Add(RAV_MODIFICADOPOR_USERID);
            //validadores.Add(RAV_TIPOPERSONAID);
            //validadores.Add(RAV_SALUDOID);
            //validadores.Add(RAV_EMPRESAID);
            //validadores.Add(RAV_VENDEDORID);
            //validadores.Add(RAV_LISTAPRECIOID);
            //validadores.Add(RAV_RESET_PASS);


            //if (ESTADOTextBox.SelectedText != null && ESTADOTextBox.SelectedText.Trim().Length == 0)
            //    ESTADOTextBox.SelectedDataDisplaying = "JALISCO";

            LlenarCamposRelacionadosAEstado();
            LlenarCamposRelacionadosACodigoPostal();

            ConfigureFirma();




            this.button1.Text = opc;
            if (this.opc != "Agregar" && this.opc != "")
            {
                this.BTAgregarNota.Enabled = true;

                if (this.opc == "Consultar")
                {
                    this.button1.Visible = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.exitNoBack_J;
                }
                else { HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; }
                LlenarDatosDeBase();
                this.CLAVETextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;

                if(CurrentUserID.CurrentUser.IVENDEDORID > 0)
                {
                    string strBuffer = "";
                    this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IVENDEDORID.ToString();
                    this.VENDEDORIDTextBox.MostrarErrores = false;
                    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.VENDEDORIDTextBox.MostrarErrores = true;
                }
                this.CARGOXVENTACONTARJETATextBox.Checked = CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0 || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0;



            }

        }


        private void ConfigureFirma()
        {

            FirmaTabPage.Visible = CurrentUserID.CurrentParameters.IRUTAFIRMAIMAGENES != null && CurrentUserID.CurrentParameters.IRUTAFIRMAIMAGENES.Length > 0;
        }

        private void LlenarCamposRelacionadosAEstado()
        {

            var acronimoEstado = ESTADOTextBox.SelectedDataDisplaying != null ? "'" + ESTADOTextBox.SelectedDataDisplaying.ToString() + "'" : "''";
            

            this.SAT_LOCALIDADIDTextBox.Query = this.m_localidad_Sel_Query.Replace("@CLAVEESTADO", acronimoEstado.Trim());
            this.SAT_LOCALIDADIDTextBox.QueryDeSeleccion = this.m_localidad_Sel_Query_DeSeleccion.Replace("@CLAVEESTADO", acronimoEstado.Trim());


            this.SAT_MUNICIPIOIDTextBox.Query = this.m_municipio_Sel_Query.Replace("@CLAVEESTADO", acronimoEstado.Trim());
            this.SAT_MUNICIPIOIDTextBox.QueryDeSeleccion = this.m_municipio_Sel_Query_DeSeleccion.Replace("@CLAVEESTADO", acronimoEstado.Trim());

            

        }


        private void LlenarCamposRelacionadosACodigoPostal()
        {

            var codigoPostal = this.CODIGOPOSTALTextBox.Text != null ? "'" + this.CODIGOPOSTALTextBox.Text + "'" : "''";
            
            this.SAT_COLONIAIDTextBox.Query = this.m_colonia_Sel_Query.Replace("@CODIGOPOSTAL", codigoPostal);
            this.SAT_COLONIAIDTextBox.QueryDeSeleccion = this.m_colonia_Sel_Query_DeSeleccion.Replace("@CODIGOPOSTAL", codigoPostal);
            

        }



        private void LlenarCamposRelacionadosAEstado_Entrega()
        {

            var acronimoEstado = ENTREGAESTADOTextBox.SelectedDataDisplaying != null ? "'" + ENTREGAESTADOTextBox.SelectedDataDisplaying.ToString() + "'" : "''";


            this.ENTREGA_SAT_LOCALIDADIDTextBox.Query = this.m_localidad_Sel_Query.Replace("@CLAVEESTADO", acronimoEstado);
            this.ENTREGA_SAT_LOCALIDADIDTextBox.QueryDeSeleccion = this.m_localidad_Sel_Query_DeSeleccion.Replace("@CLAVEESTADO", acronimoEstado);


            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Query = this.m_municipio_Sel_Query.Replace("@CLAVEESTADO", acronimoEstado);
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.QueryDeSeleccion = this.m_municipio_Sel_Query_DeSeleccion.Replace("@CLAVEESTADO", acronimoEstado);

        }

        private void LlenarCamposRelacionadosACodigoPostal_Entrega()
        {

            var codigoPostal = this.ENTREGACODIGOPOSTALTextBox.Text != null ? "'" + this.ENTREGACODIGOPOSTALTextBox.Text + "'" : "''";

            this.ENTREGA_SAT_COLONIAIDTextBox.Query = this.m_colonia_Sel_Query.Replace("@CODIGOPOSTAL", codigoPostal);
            this.ENTREGA_SAT_COLONIAIDTextBox.QueryDeSeleccion = this.m_colonia_Sel_Query_DeSeleccion.Replace("@CODIGOPOSTAL", codigoPostal);


        }

        private bool LlenarDatosDeBase()
        {
            string strBuffer = "";
            try
            {
                CCLIENTED clienteD = new CCLIENTED();
                CCLIENTEBE clienteBE = new CCLIENTEBE();

                clienteBE.m_PersonaBE.ICLAVE = CLAVE;
                clienteBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
                clienteBE.m_PersonaBE = clienteD.seleccionarPERSONAxCLAVE(clienteBE.m_PersonaBE, null);

                if (clienteBE.m_PersonaBE == null)
                    return false;

                m_clienteOld = clienteBE.m_PersonaBE;

                this.ID = clienteBE.m_PersonaBE.IID;

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IID"])
                //{
                //    this.IDTextBox.Text = clienteBE.m_PersonaBE.IID.ToString();
                //}
                //else
                //{
                //    this.IDTextBox.Text = "";
                //}



                this.ACTIVOTextBox.Checked = (clienteBE.m_PersonaBE.IACTIVO == "S") ? true : false;

                //if (!(bool)clienteBE.m_PersonaBE.isnull["ICREADOPOR_USERID"])
                //{
                //    this.CREADOPOR_USERIDTextBox.Text = clienteBE.m_PersonaBE.ICREADOPOR_USERID.ToString();
                //}
                //else
                //{
                //    this.CREADOPOR_USERIDTextBox.Text = "";
                //}

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IMODIFICADOPOR_USERID"])
                //{
                //    this.MODIFICADOPOR_USERIDTextBox.Text = clienteBE.m_PersonaBE.IMODIFICADOPOR_USERID.ToString();
                //}
                //else
                //{
                //    this.MODIFICADOPOR_USERIDTextBox.Text = "";
                //}

                //if (!(bool)clienteBE.m_PersonaBE.isnull["ITIPOPERSONAID"])
                //{
                //    this.TIPOPERSONAIDTextBox.Text = clienteBE.m_PersonaBE.ITIPOPERSONAID.ToString();
                //}
                //else
                //{
                //    this.TIPOPERSONAIDTextBox.Text = "";
                //}

                if (!(bool)clienteBE.m_PersonaBE.isnull["ICLAVE"])
                {
                    this.CLAVETextBox.Text = clienteBE.m_PersonaBE.ICLAVE.ToString();
                }
                else
                {
                    this.CLAVETextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["INOMBRE"])
                {
                    this.NOMBRETextBox.Text = clienteBE.m_PersonaBE.INOMBRE.ToString();
                }
                else
                {
                    this.NOMBRETextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IDESCRIPCION"])
                {
                    //this.DESCRIPCIONTextBox.Text = clienteBE.m_PersonaBE.IDESCRIPCION.ToString();
                }
                else
                {
                    //this.DESCRIPCIONTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IMEMO"])
                {
                    this.MEMOTextBox.Text = clienteBE.m_PersonaBE.IMEMO.ToString();
                }
                else
                {
                    this.MEMOTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ISALUDOID"])
                {
                    /*this.SALUDOIDTextBox.Text = clienteBE.m_PersonaBE.ISALUDOID.ToString();

                    this.SALUDOIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.ISALUDOID;*/
                }
                else
                {
                    //this.SALUDOIDTextBox.SelectedIndex = -1;

                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["INOMBRES"])
                {
                    this.NOMBRESTextBox.Text = clienteBE.m_PersonaBE.INOMBRES.ToString();
                }
                else
                {
                    this.NOMBRESTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IAPELLIDOS"])
                {
                    this.APELLIDOSTextBox.Text = clienteBE.m_PersonaBE.IAPELLIDOS.ToString();
                }
                else
                {
                    this.APELLIDOSTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IRAZONSOCIAL"])
                {
                    this.RAZONSOCIALTextBox.Text = clienteBE.m_PersonaBE.IRAZONSOCIAL.ToString();
                }
                else
                {
                    this.RAZONSOCIALTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IRFC"])
                {
                    this.RFCTextBox.Text = clienteBE.m_PersonaBE.IRFC.ToString();
                }
                else
                {
                    this.RFCTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ICONTACTO1"])
                {
                    this.CONTACTO1TextBox.Text = clienteBE.m_PersonaBE.ICONTACTO1.ToString();
                }
                else
                {
                    this.CONTACTO1TextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ICONTACTO2"])
                {
                    this.CONTACTO2TextBox.Text = clienteBE.m_PersonaBE.ICONTACTO2.ToString();
                }
                else
                {
                    this.CONTACTO2TextBox.Text = "";
                }

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IUSERNAME"])
                //{
                //    this.USERNAMETextBox.Text = clienteBE.m_PersonaBE.IUSERNAME.ToString();
                //}
                //else
                //{
                //    this.USERNAMETextBox.Text = "";
                //}

                //if (!(bool)clienteBE.m_PersonaBE.isnull["ICLAVEACCESO"])
                //{
                //    this.CLAVEACCESOTextBox.Text = clienteBE.m_PersonaBE.ICLAVEACCESO.ToString();
                //}
                //else
                //{
                //    this.CLAVEACCESOTextBox.Text = "";
                //}

                if (!(bool)clienteBE.m_PersonaBE.isnull["IDOMICILIO"])
                {
                    this.DOMICILIOTextBox.Text = clienteBE.m_PersonaBE.IDOMICILIO.ToString();
                }
                else
                {
                    this.DOMICILIOTextBox.Text = "";
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["INUMEROEXTERIOR"])
                {
                    this.NUMEROEXTERIORTextBox.Text = clienteBE.m_PersonaBE.INUMEROEXTERIOR.ToString();
                }
                else
                {
                    this.NUMEROEXTERIORTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["INUMEROINTERIOR"])
                {
                    this.NUMEROINTERIORTextBox.Text = clienteBE.m_PersonaBE.INUMEROINTERIOR.ToString();
                }
                else
                {
                    this.NUMEROINTERIORTextBox.Text = "";
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ILATITUD"])
                {
                    this.LATITUDTextBox.Text = clienteBE.m_PersonaBE.ILATITUD.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    this.LATITUDTextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ILONGITUD"])
                {
                    this.LONGITUDTextBox.Text = clienteBE.m_PersonaBE.ILONGITUD.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    this.LONGITUDTextBox.Text = "";
                }


                //if (!(bool)clienteBE.m_PersonaBE.isnull["ICIUDAD"])
                //{
                //    this.CIUDADTextBox.Text = clienteBE.m_PersonaBE.ICIUDAD.ToString();
                //}
                //else
                //{
                //    this.CIUDADTextBox.Text = "";
                //}



                if (!(bool)clienteBE.m_PersonaBE.isnull["IREFERENCIADOM"])
                {
                    this.REFERENCIADOMTextBox.Text = clienteBE.m_PersonaBE.IREFERENCIADOM.ToString();
                }
                else
                {
                    this.REFERENCIADOMTextBox.Text = "";
                }

                /*
                if (!(bool)clienteBE.m_PersonaBE.isnull["IMUNICIPIO"])
                {
                    this.MUNICIPIOTextBox.Text = clienteBE.m_PersonaBE.IMUNICIPIO.ToString();
                }
                else
                {
                    this.MUNICIPIOTextBox.Text = "";
                }*/

                if (!(bool)clienteBE.m_PersonaBE.isnull["IESTADO"])
                {
                    this.ESTADOTextBox.SelectedDataDisplaying = clienteBE.m_PersonaBE.IESTADO.ToString();
                }
                else
                {
                    this.ESTADOTextBox.Text = "";
                }
                LlenarCamposRelacionadosAEstado();


                if (!(bool)clienteBE.m_PersonaBE.isnull["ISAT_LOCALIDADID"])
                {
                    this.SAT_LOCALIDADIDTextBox.DbValue = clienteBE.m_PersonaBE.ISAT_LOCALIDADID.ToString();
                    this.SAT_LOCALIDADIDTextBox.MostrarErrores = false;
                    this.SAT_LOCALIDADIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_LOCALIDADIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.SAT_LOCALIDADIDTextBox.Text = "";
                    if (!(bool)clienteBE.m_PersonaBE.isnull["ILOCALIDAD"])
                    {
                        this.SAT_LOCALIDADIDLabel.Text = clienteBE.m_PersonaBE.ILOCALIDAD;
                    }
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ISAT_MUNICIPIOID"])
                {
                    this.SAT_MUNICIPIOIDTextBox.DbValue = clienteBE.m_PersonaBE.ISAT_MUNICIPIOID.ToString();
                    this.SAT_MUNICIPIOIDTextBox.MostrarErrores = false;
                    this.SAT_MUNICIPIOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_MUNICIPIOIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.SAT_MUNICIPIOIDTextBox.Text = "";
                    if (!(bool)clienteBE.m_PersonaBE.isnull["ICIUDAD"])
                    {
                        this.SAT_MUNICIPIOIDLabel.Text = clienteBE.m_PersonaBE.ICIUDAD;
                    }
                }




                if (!(bool)clienteBE.m_PersonaBE.isnull["ISAT_CLAVE_PAIS"])
                {
                    this.PAISComboBoxFb.SelectedValue = clienteBE.m_PersonaBE.ISAT_CLAVE_PAIS.ToString();
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ICODIGOPOSTAL"])
                {
                    this.CODIGOPOSTALTextBox.Text = clienteBE.m_PersonaBE.ICODIGOPOSTAL.ToString();
                }
                else
                {
                    this.CODIGOPOSTALTextBox.Text = "";
                }
                LlenarCamposRelacionadosACodigoPostal();


                if (!(bool)clienteBE.m_PersonaBE.isnull["ISAT_COLONIAID"])
                {
                    this.SAT_COLONIAIDTextBox.DbValue = clienteBE.m_PersonaBE.ISAT_COLONIAID.ToString();
                    this.SAT_COLONIAIDTextBox.MostrarErrores = false;
                    this.SAT_COLONIAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_COLONIAIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.SAT_COLONIAIDTextBox.Text = "";
                    if (!(bool)clienteBE.m_PersonaBE.isnull["ICOLONIA"])
                    {
                        this.SAT_COLONIAIDLabel.Text = clienteBE.m_PersonaBE.ICOLONIA;
                    }
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["ITELEFONO1"])
                {
                    this.TELEFONO1TextBox.Text = clienteBE.m_PersonaBE.ITELEFONO1.ToString();
                }
                else
                {
                    this.TELEFONO1TextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ITELEFONO2"])
                {
                    this.TELEFONO2TextBox.Text = clienteBE.m_PersonaBE.ITELEFONO2.ToString();
                }
                else
                {
                    this.TELEFONO2TextBox.Text = "";
                }
                /*
                if (!(bool)clienteBE.m_PersonaBE.isnull["ITELEFONO3"])
                {
                    this.TELEFONO3TextBox.Text = clienteBE.m_PersonaBE.ITELEFONO3.ToString();
                }
                else
                {
                    this.TELEFONO3TextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ICELULAR"])
                {
                    this.CELULARTextBox.Text = clienteBE.m_PersonaBE.ICELULAR.ToString();
                }
                else
                {
                    this.CELULARTextBox.Text = "";
                }
                
                if (!(bool)clienteBE.m_PersonaBE.isnull["INEXTEL"])
                {
                    this.NEXTELTextBox.Text = clienteBE.m_PersonaBE.INEXTEL.ToString();
                }
                else
                {
                    this.NEXTELTextBox.Text = "";
                }
                */
                if (!(bool)clienteBE.m_PersonaBE.isnull["IEMAIL1"])
                {
                    this.EMAIL1TextBox.Text = clienteBE.m_PersonaBE.IEMAIL1.ToString();
                }
                else
                {
                    this.EMAIL1TextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IEMAIL2"])
                {
                    this.EMAIL2TextBox.Text = clienteBE.m_PersonaBE.IEMAIL2.ToString();
                }
                else
                {
                    this.EMAIL2TextBox.Text = "";
                }
                /*
                if (!(bool)clienteBE.m_PersonaBE.isnull["IEMPRESAID"])
                {
                    this.EMPRESAIDTextBox.DbValue = clienteBE.m_PersonaBE.IEMPRESAID.ToString();
                    this.EMPRESAIDTextBox.MostrarErrores = false;
                    this.EMPRESAIDTextBox.MValidarEntrada(out strBuffer,1);
                    this.EMPRESAIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.EMPRESAIDTextBox.Text = "";
                }
                */
                if (!(bool)clienteBE.m_PersonaBE.isnull["IVENDEDORID"])
                {
                    this.VENDEDORIDTextBox.DbValue = clienteBE.m_PersonaBE.IVENDEDORID.ToString();
                    this.VENDEDORIDTextBox.MostrarErrores = false;
                    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.VENDEDORIDTextBox.MostrarErrores = true;
                    //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                }
                else
                {
                    this.VENDEDORIDTextBox.Text = "";
                }

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IESCLIENTE"])
                //{
                //    this.ESCLIENTETextBox.Text = clienteBE.m_PersonaBE.IESCLIENTE.ToString();
                //}
                //else
                //{
                //    this.ESCLIENTETextBox.Text = "";
                //}

                // this.ESCLIENTETextBox.Checked = (clienteBE.m_PersonaBE.IESCLIENTE == "S") ? true : false;

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IESCLIENTEGENERAL"])
                //{
                //    this.ESCLIENTEGENERALTextBox.Text = clienteBE.m_PersonaBE.IESCLIENTEGENERAL.ToString();
                //}
                //else
                //{
                //    this.ESCLIENTEGENERALTextBox.Text = "";
                //}
                //this.ESCLIENTEGENERALTextBox.Checked = (clienteBE.m_PersonaBE.IESCLIENTEGENERAL == "S") ? true : false;

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IESCLIENTE"])
                //{
                //    this.ESCLIENTETextBox.Text = clienteBE.m_PersonaBE.IESCLIENTE.ToString();
                //}
                //else
                //{
                //    this.ESCLIENTETextBox.Text = "";
                //}
                //this.ESCLIENTETextBox.Checked = (clienteBE.m_PersonaBE.IESCLIENTE == "S") ? true : false;

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IESUSUARIO"])
                //{
                //    this.ESUSUARIOTextBox.Text = clienteBE.m_PersonaBE.IESUSUARIO.ToString();
                //}
                //else
                //{
                //    this.ESUSUARIOTextBox.Text = "";
                //}
                //this.ESUSUARIOTextBox.Checked = (clienteBE.m_PersonaBE.IESUSUARIO == "S") ? true : false;

                if (!(bool)clienteBE.m_PersonaBE.isnull["ILISTAPRECIOID"])
                {
                    this.LISTAPRECIOIDTextBox.Text = clienteBE.m_PersonaBE.ILISTAPRECIOID.ToString();
                }
                else
                {
                    this.LISTAPRECIOIDTextBox.Text = "";
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ISUPERLISTAPRECIOID"])
                {
                    this.SUPERLISTAPRECIOIDTextBox.Text = clienteBE.m_PersonaBE.ISUPERLISTAPRECIOID.ToString();
                }
                else
                {
                    this.SUPERLISTAPRECIOIDTextBox.Text = "";
                }

                //if (!(bool)clienteBE.m_PersonaBE.isnull["IRESET_PASS"])
                //{
                //    this.RESET_PASSTextBox.Text = clienteBE.m_PersonaBE.IRESET_PASS.ToString();
                //}
                //else
                //{
                //    this.RESET_PASSTextBox.Text = "";
                //}

                if (!(bool)clienteBE.m_PersonaBE.isnull["IVIGENCIA"])
                {
                    try
                    {
                        this.VIGENCIATextBox.Value = clienteBE.m_PersonaBE.IVIGENCIA;
                    }
                    catch
                    {
                    }
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOTARJETA"])
                {
                    this.HAB_PAGOTARJETATextBox.Checked = (clienteBE.m_PersonaBE.IHAB_PAGOTARJETA == "S") ? true : false;
                }
                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOCREDITO"])
                {
                    this.HAB_PAGOCREDITOTextBox.Checked = (clienteBE.m_PersonaBE.IHAB_PAGOCREDITO == "S") ? true : false;
                }
                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOCHEQUE"])
                {
                    this.HAB_PAGOCHEQUETextBox.Checked = (clienteBE.m_PersonaBE.IHAB_PAGOCHEQUE == "S") ? true : false;
                }
                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOEFECTIVO"])
                {
                    this.HAB_PAGOEFECTIVOTextBox.Checked = (clienteBE.m_PersonaBE.IHAB_PAGOEFECTIVO == "S") ? true : false;
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["ILIMITECREDITO"])
                    this.LIMITECREDITOTextBox.Text = clienteBE.m_PersonaBE.ILIMITECREDITO.ToString();

                if (!(bool)clienteBE.m_PersonaBE.isnull["IDIAS"])
                    this.DIASTextBox.Text = clienteBE.m_PersonaBE.IDIAS.ToString();


                if (!(bool)clienteBE.m_PersonaBE.isnull["IREVISION"])
                {
                    this.REVISIONTextBox.Text = clienteBE.m_PersonaBE.IREVISION.ToString();
                }
                if (!(bool)clienteBE.m_PersonaBE.isnull["IPAGOS"])
                {
                    this.PAGOSTextBox.Text = clienteBE.m_PersonaBE.IPAGOS.ToString();
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IBLOQUEADO"])
                {
                    this.BLOQUEADOTextBox.Checked = (clienteBE.m_PersonaBE.IBLOQUEADO == "S") ? true : false;
                }




                if (!(bool)clienteBE.m_PersonaBE.isnull["IHAB_PAGOTRANSFERENCIA"])
                {
                    this.HAB_PAGOTRANSFERENCIATextBox.Checked = (clienteBE.m_PersonaBE.IHAB_PAGOTRANSFERENCIA == "S") ? true : false;
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ICREDITOFORMAPAGOSATABONOS"])
                {


                    switch (clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS)
                    {
                        case 1:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 0;
                            break;
                        case 4:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 1;
                            break;
                        case 28:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 2;
                            break;
                        case 29:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 3;
                            break;
                        case 2:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 4;
                            break;
                        case 8:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 5;
                            break;
                        case 3:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 6;
                            break;
                        case 99:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = 7;
                            break;



                        default:
                            this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex = -1;
                            break;

                    }
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ICREDITOREFERENCIAABONOS"])
                    this.CREDITOREFERENCIAABONOSTextBox.Text = clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS.ToString().Trim();


                this.RETIENEISRTextBox.Checked = (clienteBE.m_PersonaBE.IRETIENEISR == "S") ? true : false;
                this.RETIENEIVATextBox.Checked = (clienteBE.m_PersonaBE.IRETIENEIVA == "S") ? true : false;



                if (!(bool)clienteBE.m_PersonaBE.isnull["IMONEDAID"])
                {
                    this.MONEDAIDTextBox.DbValue = clienteBE.m_PersonaBE.IMONEDAID.ToString();
                    this.MONEDAIDTextBox.MostrarErrores = false;
                    this.MONEDAIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.MONEDAIDTextBox.MostrarErrores = true;
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["IDESGLOSEIEPS"])
                {
                    this.DESGLOSEIEPSTextBox.Checked = (clienteBE.m_PersonaBE.IDESGLOSEIEPS == "S") ? true : false;
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["ISOLICITAORDENCOMPRA"])
                {
                    this.chkOrdenCompra.Checked = (clienteBE.m_PersonaBE.ISOLICITAORDENCOMPRA == "S") ? true : false;
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["ISEPARARPRODXPLAZO"])
                {
                    this.cbSepararProdXPlazo.Checked = (clienteBE.m_PersonaBE.ISEPARARPRODXPLAZO == "S") ? true : false;
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["ICUENTAIEPS"])
                    this.CUENTAIEPSTextBox.Text = clienteBE.m_PersonaBE.ICUENTAIEPS.ToString().Trim();


                CUENTAIEPSTextBox.Enabled = (clienteBE.m_PersonaBE.IDESGLOSEIEPS == "S");


                if (!(bool)clienteBE.m_PersonaBE.isnull["ICUENTACONTPAQ"])
                    this.txtCuentaContpaq.Text = clienteBE.m_PersonaBE.ICUENTACONTPAQ.ToString().Trim();


                if (!(bool)clienteBE.m_PersonaBE.isnull["IEMAIL3"])
                {
                    this.EMAIL3TextBox.Text = clienteBE.m_PersonaBE.IEMAIL3.ToString();
                }
                else
                {
                    this.EMAIL3TextBox.Text = "";
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IEMAIL4"])
                {
                    this.EMAIL4TextBox.Text = clienteBE.m_PersonaBE.IEMAIL4.ToString();
                }
                else
                {
                    this.EMAIL4TextBox.Text = "";
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["IPAGOPARCIALIDADES"])
                {
                    this.PAGOPARCIALIDADESTextBox.Checked = (clienteBE.m_PersonaBE.IPAGOPARCIALIDADES == "S") ? true : false;
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ISERVICIOADOMICILIO"])
                {
                    this.SERVICIOADOMICILIOTextBox.Checked = (clienteBE.m_PersonaBE.ISERVICIOADOMICILIO == "S") ? true : false;
                }



                this.ULTIMAVENTATextBox.Visible = false;
                if (!(bool)clienteBE.m_PersonaBE.isnull["IULTIMAVENTA"])
                {
                    try
                    {
                        this.ULTIMAVENTATextBox.Value = clienteBE.m_PersonaBE.IULTIMAVENTA;
                        this.ULTIMAVENTATextBox.Visible = true;
                    }
                    catch
                    {
                    }
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["IGENERARRECIBOELECTRONICO"])
                {
                    this.GENERARRECIBOELECTRONICOTextBox.Checked = (clienteBE.m_PersonaBE.IGENERARRECIBOELECTRONICO == "S") ? true : false;
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["ICARGOXVENTACONTARJETA"])
                {
                    this.CARGOXVENTACONTARJETATextBox.Checked = (clienteBE.m_PersonaBE.ICARGOXVENTACONTARJETA == "S") ? true : false;
                }

                if (!(bool)clienteBE.m_PersonaBE.isnull["IPAGOTARJMENORPRECIOLISTA"])
                {
                    this.PAGOTARJMENORPRECIOLISTATextBox.Checked = (clienteBE.m_PersonaBE.IPAGOTARJMENORPRECIOLISTA == "S") ? true : false;
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["IPROVEECLIENTEID"])
                {
                    this.PROVEECLIENTEIDTextBox.DbValue = clienteBE.m_PersonaBE.IPROVEECLIENTEID.ToString();
                    this.PROVEECLIENTEIDTextBox.MostrarErrores = false;
                    this.PROVEECLIENTEIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEECLIENTEIDTextBox.MostrarErrores = true;
                    //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                }
                else
                {
                    this.PROVEECLIENTEIDTextBox.Text = "";
                }


                if (!(bool)clienteBE.m_PersonaBE.isnull["ISAT_USOCFDIID"])
                {
                    this.SAT_USOCFDIIDTextBox.DbValue = clienteBE.m_PersonaBE.ISAT_USOCFDIID.ToString();
                    this.SAT_USOCFDIIDTextBox.MostrarErrores = false;
                    this.SAT_USOCFDIIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_USOCFDIIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.SAT_USOCFDIIDTextBox.Text = "";
                }



                if (!(bool)clienteBE.m_PersonaBE.isnull["ISAT_REGIMENFISCALID"])
                {
                    this.SAT_REGIMENFISCALIDTextBox.DbValue = clienteBE.m_PersonaBE.ISAT_REGIMENFISCALID.ToString();
                    this.SAT_REGIMENFISCALIDTextBox.MostrarErrores = false;
                    this.SAT_REGIMENFISCALIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_REGIMENFISCALIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.SAT_REGIMENFISCALIDTextBox.Text = "";
                }

                this.EXENTOIVATextBox.Checked = (clienteBE.m_PersonaBE.IEXENTOIVA == "S") ? true : false;

                if (!(bool)clienteBE.m_PersonaBE.isnull["IDIAS_EXTR"])
                    this.DIAS_EXTRTextBox.Text = clienteBE.m_PersonaBE.IDIAS_EXTR.ToString();



                if (!(bool)clienteBE.m_PersonaBE.isnull["IPOR_COME"])
                    this.POR_COMETextBox.Text = clienteBE.m_PersonaBE.IPOR_COME.ToString();




                if (!(bool)clienteBE.m_PersonaBE.isnull["IRUTAEMBARQUEID"])
                {
                    this.RUTAEMBARQUEIDTextBox.DbValue = clienteBE.m_PersonaBE.IRUTAEMBARQUEID.ToString();
                    this.RUTAEMBARQUEIDTextBox.MostrarErrores = false;
                    this.RUTAEMBARQUEIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.RUTAEMBARQUEIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.RUTAEMBARQUEIDTextBox.Text = "";
                }




                if (!(bool)clienteBE.m_PersonaBE.isnull["ISUBTIPOCLIENTE"])
                {
                    this.SUBTIPOCLIENTETextBox.DbValue = clienteBE.m_PersonaBE.ISUBTIPOCLIENTE.ToString();
                    this.SUBTIPOCLIENTETextBox.MostrarErrores = false;
                    this.SUBTIPOCLIENTETextBox.MValidarEntrada(out strBuffer, 1);
                    this.SUBTIPOCLIENTETextBox.MostrarErrores = true;
                }
                else
                {
                    this.SUBTIPOCLIENTETextBox.Text = "";
                }


                this.PREGUNTARTICKETLARGOTextBox.Checked = (clienteBE.m_PersonaBE.IPREGUNTARTICKETLARGO == "S") ? true : false;

                this.MAYOREOXPRODUCTOTextBox.Checked = (clienteBE.m_PersonaBE.IMAYOREOXPRODUCTO == "S") ? true : false;

                this.GENERACOMPROBTRASLTextBox.Checked = (clienteBE.m_PersonaBE.IGENERACOMPROBTRASL == "S") ? true : false;

                this.GENERACARTAPORTETextBox.Checked = (clienteBE.m_PersonaBE.IGENERACARTAPORTE == "S") ? true : false;


                if (!(bool)clienteBE.m_PersonaBE.isnull["IDISTANCIA"])
                    this.DISTANCIATextBox.Text = clienteBE.m_PersonaBE.IDISTANCIA.ToString();


                if (!(bool)clienteBE.m_PersonaBE.isnull["IFIRMAIMAGEN"])
                {
                    this.FIRMAIMAGENTextBox.Text = clienteBE.m_PersonaBE.IFIRMAIMAGEN;

                    string imagePath = CurrentUserID.CurrentParameters.IRUTAFIRMAIMAGENES + "\\" + clienteBE.m_PersonaBE.IFIRMAIMAGEN;
                    try
                    {
                        if (clienteBE.m_PersonaBE.IFIRMAIMAGEN != "")
                        {

                            FIRMAIMAGENPictureBox.Image = Image.FromFile(imagePath);
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                }

                this.LlenarDomicilios();

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

        private void LlenarDatosDeEntregaDeDomicilio(long domicilioId)
        {
            var rowDomicilio = dSCatalogos3.DOMICILIOSXPERSONA.Where(d => d.ID == domicilioId).FirstOrDefault();


            m_currentDomicilioId = domicilioId;

            string strBuffer = "";

            if (!rowDomicilio.IsESTADONull())
                this.ENTREGAESTADOTextBox.Text = rowDomicilio.ESTADO.Trim();

            this.LlenarCamposRelacionadosAEstado_Entrega();


            if (!rowDomicilio.IsSAT_LOCALIDADIDNull())
            {
                this.ENTREGA_SAT_LOCALIDADIDTextBox.DbValue = rowDomicilio.SAT_LOCALIDADID.ToString();
                this.ENTREGA_SAT_LOCALIDADIDTextBox.MostrarErrores = false;
                this.ENTREGA_SAT_LOCALIDADIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ENTREGA_SAT_LOCALIDADIDTextBox.MostrarErrores = true;
            }
            else
            {
                this.ENTREGA_SAT_LOCALIDADIDTextBox.Text = "";
            }


            if (!rowDomicilio.IsSAT_MUNICIPIOIDNull())
            {
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbValue = rowDomicilio.SAT_MUNICIPIOID.ToString();
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.MostrarErrores = false;
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.MostrarErrores = true;
            }
            else
            {
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text = "";
                if (!rowDomicilio.IsMUNICIPIONull())
                {
                    this.ENTREGA_SAT_MUNICIPIOIDLabel.Text = rowDomicilio.MUNICIPIO;
                }
            }


            if (!rowDomicilio.IsCODIGOPOSTALNull())
                this.ENTREGACODIGOPOSTALTextBox.Text = rowDomicilio.CODIGOPOSTAL.ToString().Trim();

            this.LlenarCamposRelacionadosACodigoPostal_Entrega();


            if (!rowDomicilio.IsSAT_COLONIAIDNull())
            {
                this.ENTREGA_SAT_COLONIAIDTextBox.DbValue = rowDomicilio.SAT_COLONIAID.ToString();
                this.ENTREGA_SAT_COLONIAIDTextBox.MostrarErrores = false;
                this.ENTREGA_SAT_COLONIAIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ENTREGA_SAT_COLONIAIDTextBox.MostrarErrores = true;
            }
            else
            {
                this.ENTREGA_SAT_COLONIAIDTextBox.Text = "";
                if (!rowDomicilio.IsCOLONIANull())
                {
                    this.ENTREGA_SAT_COLONIAIDLabel.Text = rowDomicilio.COLONIA;
                }
            }


            if (!rowDomicilio.IsCALLENull())
                this.ENTREGACALLETextBox.Text = rowDomicilio.CALLE.ToString().Trim();

            if (!rowDomicilio.IsNUMEROINTERIORNull())
                this.ENTREGANUMEROINTERIORTextBox.Text = rowDomicilio.NUMEROINTERIOR.ToString().Trim();

            if (!rowDomicilio.IsNUMEROEXTERIORNull())
                this.ENTREGANUMEROEXTERIORTextBox.Text = rowDomicilio.NUMEROEXTERIOR.ToString().Trim();



            if (!rowDomicilio.IsDISTANCIANull())
                this.ENTREGA_DISTANCIATextBox.Text = rowDomicilio.DISTANCIA.ToString();

            if (!rowDomicilio.IsREFERENCIADOMNull())
                this.ENTREGAREFERENCIADOMTextBox.Text = rowDomicilio.REFERENCIADOM.ToString();


            if (!rowDomicilio.IsLATITUDNull())
            {
                this.ENTREGALATITUDTextBox.Text = rowDomicilio.LATITUD.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                this.ENTREGALATITUDTextBox.Text = "";
            }

            if (!rowDomicilio.IsLONGITUDNull())
            {
                this.ENTREGALONGITUDTextBox.Text = rowDomicilio.LONGITUD.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                this.ENTREGALONGITUDTextBox.Text = "";
            }

        }



        private CCLIENTEBE ObtenerDatosCapturados()
        {
            CCLIENTEBE clienteBE = new CCLIENTEBE();



            //if (this.ACTIVOTextBox.Text != "")
            //{
                clienteBE.m_PersonaBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";
            //}



            //if (this.CREADOTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.ICREADO = this.CREADOTextBox.Text.ToString();
            //}


            //if (this.MODIFICADOTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IMODIFICADO = this.MODIFICADOTextBox.Text.ToString();
            //}


            if (this.CLAVETextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                clienteBE.m_PersonaBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }

            /*
            if (this.DESCRIPCIONTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }
            */

            if (this.MEMOTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IMEMO = this.MEMOTextBox.Text.ToString();
            }


            if (this.NOMBRESTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.INOMBRES = this.NOMBRESTextBox.Text.ToString();
            }
            else if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                clienteBE.m_PersonaBE.INOMBRES = clienteBE.m_PersonaBE.INOMBRE;
            }


            if (this.APELLIDOSTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IAPELLIDOS = this.APELLIDOSTextBox.Text.ToString();
            }
            else if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                clienteBE.m_PersonaBE.IAPELLIDOS = "-";
            }


            if (this.RAZONSOCIALTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IRAZONSOCIAL = this.RAZONSOCIALTextBox.Text.ToString();
            }


            if (this.RFCTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IRFC = this.RFCTextBox.Text.ToString();
            }


            if (this.CONTACTO1TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICONTACTO1 = this.CONTACTO1TextBox.Text.ToString();
            }


            if (this.CONTACTO2TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICONTACTO2 = this.CONTACTO2TextBox.Text.ToString();
            }


            //if (this.USERNAMETextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IUSERNAME = this.USERNAMETextBox.Text.ToString();
            //}


            //if (this.CLAVEACCESOTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.ICLAVEACCESO = this.CLAVEACCESOTextBox.Text.ToString();
            //}


            if (this.DOMICILIOTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IDOMICILIO = this.DOMICILIOTextBox.Text.ToString();
            }

            if (this.NUMEROEXTERIORTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.INUMEROEXTERIOR = this.NUMEROEXTERIORTextBox.Text.ToString();
            }

            if (this.NUMEROINTERIORTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.INUMEROINTERIOR = this.NUMEROINTERIORTextBox.Text.ToString();
            }



            if (this.LATITUDTextBox.Text != "")
            {
                var bufferDouble = ParseNullableDouble(this.LATITUDTextBox.Text);
                if(bufferDouble != null)
                    clienteBE.m_PersonaBE.ILATITUD = bufferDouble.Value;
            }

            if (this.LONGITUDTextBox.Text != "")
            {
                var bufferDouble = ParseNullableDouble(this.LONGITUDTextBox.Text);
                if (bufferDouble != null)
                    clienteBE.m_PersonaBE.ILONGITUD = bufferDouble.Value;
            }


            //if (this.CIUDADTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.ICIUDAD = this.CIUDADTextBox.Text.ToString();
            //}



            if (this.REFERENCIADOMTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IREFERENCIADOM = this.REFERENCIADOMTextBox.Text.ToString();
            }

            /*
            if (this.MUNICIPIOTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IMUNICIPIO = this.MUNICIPIOTextBox.Text.ToString();
            }
            */

            if (this.ESTADOTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IESTADO = this.ESTADOTextBox.Text.ToString();
            }
            
            if (this.SAT_LOCALIDADIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISAT_LOCALIDADID = Int64.Parse(this.SAT_LOCALIDADIDTextBox.DbValue.ToString());
            }
            clienteBE.m_PersonaBE.ILOCALIDAD = this.SAT_LOCALIDADIDLabel.Text;

            


            if (this.SAT_MUNICIPIOIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISAT_MUNICIPIOID = Int64.Parse(this.SAT_MUNICIPIOIDTextBox.DbValue.ToString());
            }
            clienteBE.m_PersonaBE.IMUNICIPIO = this.SAT_MUNICIPIOIDLabel.Text;
            clienteBE.m_PersonaBE.ICIUDAD = this.SAT_MUNICIPIOIDLabel.Text;


            if (this.PAISComboBoxFb.SelectedIndex >= 0)
            {
                clienteBE.m_PersonaBE.ISAT_CLAVE_PAIS = this.PAISComboBoxFb.SelectedValue.ToString();
                clienteBE.m_PersonaBE.IPAIS = this.PAISComboBoxFb.SelectedDataDisplaying.ToString();
            }


            if (this.CODIGOPOSTALTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICODIGOPOSTAL = this.CODIGOPOSTALTextBox.Text.ToString();
            }

            if (this.SAT_COLONIAIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISAT_COLONIAID = Int64.Parse(this.SAT_COLONIAIDTextBox.DbValue.ToString());
            }
            clienteBE.m_PersonaBE.ICOLONIA = this.SAT_COLONIAIDLabel.Text;
            


            if (this.TELEFONO1TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ITELEFONO1 = this.TELEFONO1TextBox.Text.ToString();
            }


            if (this.TELEFONO2TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ITELEFONO2 = this.TELEFONO2TextBox.Text.ToString();
            }

            /*
            if (this.TELEFONO3TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ITELEFONO3 = this.TELEFONO3TextBox.Text.ToString();
            }


            if (this.CELULARTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICELULAR = this.CELULARTextBox.Text.ToString();
            }


            if (this.NEXTELTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.INEXTEL = this.NEXTELTextBox.Text.ToString();
            }

            */
            if (this.EMAIL1TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IEMAIL1 = this.EMAIL1TextBox.Text.ToString();
            }


            if (this.EMAIL2TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IEMAIL2 = this.EMAIL2TextBox.Text.ToString();
            }


            //if (this.ESCLIENTETextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IESCLIENTE = (this.ESCLIENTETextBox.Checked) ? "S" : "N"; 
                
            //}


            //if (this.ESCLIENTEGENERALTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IESCLIENTEGENERAL = (this.ESCLIENTEGENERALTextBox.Checked) ? "S" : "N";
            //}


            //if (this.ESCLIENTETextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IESCLIENTE = (this.ESCLIENTETextBox.Checked) ? "S" : "N";
            //}


            //if (this.ESUSUARIOTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IESUSUARIO = (this.ESUSUARIOTextBox.Checked) ? "S" : "N";
            //}


            //if (this.IDTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IID = Int64.Parse(this.IDTextBox.Text.ToString());
            //}


            //if (this.CREADOPOR_USERIDTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.ICREADOPOR_USERID = Int64.Parse(this.CREADOPOR_USERIDTextBox.Text.ToString());
            //}


            //if (this.MODIFICADOPOR_USERIDTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IMODIFICADOPOR_USERID = Int64.Parse(this.MODIFICADOPOR_USERIDTextBox.Text.ToString());
            //}


            //if (this.TIPOPERSONAIDTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.ITIPOPERSONAID = Int64.Parse(this.TIPOPERSONAIDTextBox.Text.ToString());
            //}

            /*
            if (this.SALUDOIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISALUDOID = (long)this.SALUDOIDTextBox.SelectedDataValue;
            }


            if (this.EMPRESAIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IEMPRESAID = Int64.Parse(this.EMPRESAIDTextBox.DbValue.ToString());
            }
            */

            if (this.VENDEDORIDTextBox.Text != "")
            {
               // clienteBE.m_PersonaBE.IVENDEDORID = (long)this.VENDEDORIDTextBox.SelectedDataValue;
                clienteBE.m_PersonaBE.IVENDEDORID = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            }


            if (this.LISTAPRECIOIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ILISTAPRECIOID = Int64.Parse(this.LISTAPRECIOIDTextBox.Text.ToString());
            }

            if (this.SUPERLISTAPRECIOIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISUPERLISTAPRECIOID = Int64.Parse(this.SUPERLISTAPRECIOIDTextBox.Text.ToString());
            }


            //if (this.RESET_PASSTextBox.Text != "")
            //{
            //    clienteBE.m_PersonaBE.IRESET_PASS = Int16.Parse(this.RESET_PASSTextBox.Text.ToString());
            //}


            clienteBE.m_PersonaBE.IVIGENCIA = this.VIGENCIATextBox.Value;

            clienteBE.m_PersonaBE.IHAB_PAGOTARJETA = (this.HAB_PAGOTARJETATextBox.Checked) ? "S" : "N";
            clienteBE.m_PersonaBE.IHAB_PAGOCREDITO = (this.HAB_PAGOCREDITOTextBox.Checked) ? "S" : "N";
            clienteBE.m_PersonaBE.IHAB_PAGOCHEQUE = (this.HAB_PAGOCHEQUETextBox.Checked) ? "S" : "N";
            clienteBE.m_PersonaBE.IHAB_PAGOEFECTIVO = (this.HAB_PAGOEFECTIVOTextBox.Checked) ? "S" : "N";



            if (this.LIMITECREDITOTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ILIMITECREDITO = decimal.Parse(this.LIMITECREDITOTextBox.Text.ToString());
            }

            if (this.DIASTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IDIAS = int.Parse(this.DIASTextBox.Text.ToString());
            }
            if (this.REVISIONTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IREVISION = this.REVISIONTextBox.Text.ToString();
            }

            if (this.PAGOSTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IPAGOS = this.PAGOSTextBox.Text.ToString();
            }






            switch (this.CREDITOFORMAPAGOABONOSTextBox.SelectedIndex)
            {

                case 0: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 1; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 1; break;
                case 1: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 2; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 4; break;
                case 2: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 2; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 28; break;
                case 3: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 2; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 29; break;
                case 4: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 3; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 2; break;
                case 5: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 5; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 8; break;
                case 6: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 15; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 3; break;
                case 7: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 16; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 99; break;
                default: clienteBE.m_PersonaBE.ICREDITOFORMAPAGOABONOS = 16; clienteBE.m_PersonaBE.ICREDITOFORMAPAGOSATABONOS = 99; break;
            }

            clienteBE.m_PersonaBE.IHAB_PAGOTRANSFERENCIA = (this.HAB_PAGOTRANSFERENCIATextBox.Checked) ? "S" : "N";


            if (this.CREDITOREFERENCIAABONOSTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICREDITOREFERENCIAABONOS = this.CREDITOREFERENCIAABONOSTextBox.Text.ToString();
            }



            clienteBE.m_PersonaBE.IBLOQUEADO = (this.BLOQUEADOTextBox.Checked) ? "S" : "N";

            clienteBE.m_PersonaBE.IRETIENEISR = (this.RETIENEISRTextBox.Checked) ? "S" : "N";
            clienteBE.m_PersonaBE.IRETIENEIVA = (this.RETIENEIVATextBox.Checked) ? "S" : "N";


            if (this.MONEDAIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IMONEDAID = Int64.Parse(this.MONEDAIDTextBox.DbValue.ToString());
            }


            clienteBE.m_PersonaBE.IDESGLOSEIEPS = (this.DESGLOSEIEPSTextBox.Checked) ? "S" : "N";

            if (this.CUENTAIEPSTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ICUENTAIEPS = this.CUENTAIEPSTextBox.Text.ToString();
            }

            if (this.EMAIL3TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IEMAIL3 = this.EMAIL3TextBox.Text.ToString();
            }


            if (this.EMAIL4TextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IEMAIL4 = this.EMAIL4TextBox.Text.ToString();
            }


            clienteBE.m_PersonaBE.IPAGOPARCIALIDADES = (this.PAGOPARCIALIDADESTextBox.Checked) ? "S" : "N";


            clienteBE.m_PersonaBE.ISERVICIOADOMICILIO = (this.SERVICIOADOMICILIOTextBox.Checked) ? "S" : "N";


            clienteBE.m_PersonaBE.IGENERARRECIBOELECTRONICO = (this.GENERARRECIBOELECTRONICOTextBox.Checked) ? "S" : "N";

            clienteBE.m_PersonaBE.ISOLICITAORDENCOMPRA = (this.chkOrdenCompra.Checked) ? "S" : "N";

            if (this.txtCuentaContpaq.Text != "")
            {
                clienteBE.m_PersonaBE.ICUENTACONTPAQ = this.txtCuentaContpaq.Text.ToString();
            }

            clienteBE.m_PersonaBE.ISEPARARPRODXPLAZO = (this.cbSepararProdXPlazo.Checked) ? "S" : "N";


            clienteBE.m_PersonaBE.ICARGOXVENTACONTARJETA = (this.CARGOXVENTACONTARJETATextBox.Checked) ? "S" : "N";

            clienteBE.m_PersonaBE.IPAGOTARJMENORPRECIOLISTA = (this.PAGOTARJMENORPRECIOLISTATextBox.Checked) ? "S" : "N";


            if (this.PROVEECLIENTEIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IPROVEECLIENTEID = Int64.Parse(this.PROVEECLIENTEIDTextBox.DbValue.ToString());
            }

            if (this.SAT_USOCFDIIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISAT_USOCFDIID = Int64.Parse(this.SAT_USOCFDIIDTextBox.DbValue.ToString());
            }

            if (this.SAT_REGIMENFISCALIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISAT_REGIMENFISCALID = Int64.Parse(this.SAT_REGIMENFISCALIDTextBox.DbValue.ToString());
            }

            clienteBE.m_PersonaBE.IEXENTOIVA = (this.EXENTOIVATextBox.Checked) ? "S" : "N";



            if (this.DIAS_EXTRTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IDIAS_EXTR = int.Parse(this.DIAS_EXTRTextBox.Text.ToString());
            }

            if (this.POR_COMETextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IPOR_COME = decimal.Parse(this.POR_COMETextBox.Text.ToString());
            }


            if (this.RUTAEMBARQUEIDTextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IRUTAEMBARQUEID = Int64.Parse(this.RUTAEMBARQUEIDTextBox.DbValue.ToString());
            }

            if (this.SUBTIPOCLIENTETextBox.Text != "")
            {
                clienteBE.m_PersonaBE.ISUBTIPOCLIENTE = this.SUBTIPOCLIENTETextBox.DbValue.ToString();
            }


            clienteBE.m_PersonaBE.IPREGUNTARTICKETLARGO = (this.PREGUNTARTICKETLARGOTextBox.Checked) ? "S" : "N";

            clienteBE.m_PersonaBE.IMAYOREOXPRODUCTO = (this.MAYOREOXPRODUCTOTextBox.Checked) ? "S" : "N";

            clienteBE.m_PersonaBE.IGENERACOMPROBTRASL = (this.GENERACOMPROBTRASLTextBox.Checked) ? "S" : "N";

            clienteBE.m_PersonaBE.IGENERACARTAPORTE = (this.GENERACARTAPORTETextBox.Checked) ? "S" : "N";

            if (this.DISTANCIATextBox.Text != "")
            {
                clienteBE.m_PersonaBE.IDISTANCIA = decimal.Parse(this.DISTANCIATextBox.Text.ToString());
            }

            


            if (m_bChangeFirmaImage)
            {
                if (FIRMAIMAGENPictureBox.Image != null)
                    clienteBE.m_PersonaBE.IFIRMAIMAGEN = clienteBE.m_PersonaBE.ICLAVE + "___1." + Path.GetExtension(NuevaFirmaImagenTextBox.Text);
                else
                    clienteBE.m_PersonaBE.IFIRMAIMAGEN = "";
            }



            return clienteBE;

        }


        private CDOMICILIOBE ObtenerDomicilioCapturado(CDOMICILIOBE domicilioBE)
        {

            domicilioBE.IPERSONAID = this.ID;

            if (m_currentDomicilioId != null)
                domicilioBE.IID = m_currentDomicilioId.Value;


            if (this.ENTREGAESTADOTextBox.Text != "")
            {
                domicilioBE.IESTADO = this.ENTREGAESTADOTextBox.Text.ToString();
            }


            if (this.ENTREGA_SAT_LOCALIDADIDTextBox.Text != "")
            {
                domicilioBE.ISAT_LOCALIDADID = Int64.Parse(this.ENTREGA_SAT_LOCALIDADIDTextBox.DbValue.ToString());
            }




            if (this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text != "")
            {
                domicilioBE.ISAT_MUNICIPIOID = Int64.Parse(this.ENTREGA_SAT_MUNICIPIOIDTextBox.DbValue.ToString());
            }
            domicilioBE.IMUNICIPIO = this.ENTREGA_SAT_MUNICIPIOIDLabel.Text;


            if (this.ENTREGACODIGOPOSTALTextBox.Text != "")
            {
                domicilioBE.ICODIGOPOSTAL = this.ENTREGACODIGOPOSTALTextBox.Text.ToString();
            }


            if (this.ENTREGA_SAT_COLONIAIDTextBox.Text != "")
            {
                domicilioBE.ISAT_COLONIAID = Int64.Parse(this.ENTREGA_SAT_COLONIAIDTextBox.DbValue.ToString());
            }
            domicilioBE.ICOLONIA = this.ENTREGA_SAT_COLONIAIDLabel.Text;



            if (this.ENTREGACALLETextBox.Text != "")
            {
                domicilioBE.ICALLE = this.ENTREGACALLETextBox.Text.ToString();
            }
            if (this.ENTREGANUMEROINTERIORTextBox.Text != "")
            {
                domicilioBE.INUMEROINTERIOR = this.ENTREGANUMEROINTERIORTextBox.Text.ToString();
            }
            if (this.ENTREGANUMEROEXTERIORTextBox.Text != "")
            {
                domicilioBE.INUMEROEXTERIOR = this.ENTREGANUMEROEXTERIORTextBox.Text.ToString();
            }



            if (this.ENTREGA_DISTANCIATextBox.Text != "")
            {
                domicilioBE.IDISTANCIA = decimal.Parse(this.ENTREGA_DISTANCIATextBox.Text.ToString());
            }


            if (this.ENTREGAREFERENCIADOMTextBox.Text != "")
            {
                domicilioBE.IREFERENCIADOM = this.ENTREGAREFERENCIADOMTextBox.Text.ToString();
            }


            if (this.ENTREGALATITUDTextBox.Text != "")
            {
                var bufferDouble = ParseNullableDouble(this.ENTREGALATITUDTextBox.Text);
                if (bufferDouble != null)
                    domicilioBE.ILATITUD = bufferDouble.Value;
            }

            if (this.ENTREGALONGITUDTextBox.Text != "")
            {
                var bufferDouble = ParseNullableDouble(this.ENTREGALONGITUDTextBox.Text);
                if (bufferDouble != null)
                    domicilioBE.ILONGITUD = bufferDouble.Value;
            }

            return domicilioBE;
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
                    CCLIENTED clienteD = new CCLIENTED();

                    if (opc == "Agregar")
                    {
                        CCLIENTEBE clienteBE = new CCLIENTEBE();
                        clienteBE = ObtenerDatosCapturados();
                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                            clienteBE.m_PersonaBE.IESTATUSENVIOID = DBValues._PERSONA_ESTATUSENVIO_NUEVOFALTAENVIO;


                        clienteBE.m_PersonaBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                        clienteBE.m_PersonaBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                        clienteBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
                        clienteBE.m_PersonaBE.IESCLIENTE = "S";

                        if (!HayDatosDeFacturaElectronica(clienteBE) || !ValidarTipoPrecio(clienteBE))
                            return;

                        clienteD.AgregarPERSONA(clienteBE.m_PersonaBE, null);

                        if (clienteD.IComentario == "" || clienteD.IComentario == null)
                        {


                            if (m_bChangeFirmaImage)
                            {
                                string imagePath = CurrentUserID.CurrentParameters.IRUTAFIRMAIMAGENES + "\\" + clienteBE.m_PersonaBE.IFIRMAIMAGEN;
                                GuardarImagenArchivo(imagePath);
                                m_bChangeFirmaImage = false;
                            }

                            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                            {
                                WFExportarClientesMovil expoMovil = new WFExportarClientesMovil(true);
                                expoMovil.ShowDialog();
                                expoMovil.Dispose();
                                GC.SuppressFinalize(expoMovil);
                            }

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + clienteD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {
                        CCLIENTEBE clienteBEAnt = new CCLIENTEBE();
                        CCLIENTEBE clienteBE = new CCLIENTEBE();
                        clienteBE = ObtenerDatosCapturados();

                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                            clienteBE.m_PersonaBE.IESTATUSENVIOID = DBValues._PERSONA_ESTATUSENVIO_CAMBIOFALTAENVIO;

                        clienteBE.m_PersonaBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                        clienteBEAnt.m_PersonaBE.IID = this.ID;

                        if (!HayDatosDeFacturaElectronica(clienteBE) || !ValidarTipoPrecio(clienteBE))
                            return;

                        clienteD.CambiarCLIENTED(clienteBE.m_PersonaBE, clienteBEAnt.m_PersonaBE, null);
                        if (clienteD.IComentario == "" || clienteD.IComentario == null)
                        {

                            if(m_clienteOld != null && m_clienteOld.IBLOQUEADO != clienteBE.m_PersonaBE.IBLOQUEADO)
                            {
                                string tituloNotaIncidencia = clienteBE.m_PersonaBE.IBLOQUEADO == "S" ? "Nota por bloqueo" : "Nota por desbloque";
                                long tipoEventoIncidencia = clienteBE.m_PersonaBE.IBLOQUEADO == "S" ? (int)DBValues._TIPOEVENTOTABLA_BLOQUEO : (int)DBValues._TIPOEVENTOTABLA_DESBLOQUEO;
                                agregarNota(true, tituloNotaIncidencia, tipoEventoIncidencia);
                            }

                            if (m_bChangeFirmaImage)
                            {
                                string imagePath = CurrentUserID.CurrentParameters.IRUTAFIRMAIMAGENES + "\\" + clienteBE.m_PersonaBE.IFIRMAIMAGEN;
                                GuardarImagenArchivo(imagePath);
                                m_bChangeFirmaImage = false;
                            }


                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + clienteD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CCLIENTEBE clienteBEAnt = new CCLIENTEBE();
                            clienteBEAnt.m_PersonaBE.IID = this.ID;

                            clienteD.BorrarPERSONA(clienteBEAnt.m_PersonaBE, null);
                            if (clienteD.IComentario == "" || clienteD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + clienteD.IComentario.Replace("%", "\n"));
                        }

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

        private void GuardarImagenArchivo(string imagePath)
        {
            if (File.Exists(imagePath))
                File.Delete(imagePath);

            if (FIRMAIMAGENPictureBox.Image != null)
            {
                FIRMAIMAGENPictureBox.Image.Save(imagePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                && (String.IsNullOrEmpty(NOMBRETextBox.Text) || String.IsNullOrEmpty(NOMBRESTextBox.Text))
                )
            {
                MessageBox.Show("Debe llenar el campo nombre para poder guardar");
                return;
            }

            if(HAB_PAGOCHEQUETextBox.Checked == false && HAB_PAGOCREDITOTextBox.Checked == false && HAB_PAGOEFECTIVOTextBox.Checked == false
                && HAB_PAGOTARJETATextBox.Checked == false && HAB_PAGOTRANSFERENCIATextBox.Checked == false)
            {
                MessageBox.Show("Seleccione una forma de Pago");
                return;
            }

            if (!validarCodigoPostal(CODIGOPOSTALTextBox.Text) && CODIGOPOSTALTextBox.Text != "")
            {
                MessageBox.Show("El Código Postal Ingresado no es valido!");
                CODIGOPOSTALTextBox.Focus();
                return;
            }

            if (this.SAT_COLONIAIDTextBox.Text == "")
            {
                MessageBox.Show("La colonia ingresada no existe en el catalogo, favor de revisar.");
                this.SAT_COLONIAIDTextBox.Focus();
                return;
            }
            

            if (this.SAT_MUNICIPIOIDTextBox.Text == "")
            {
                MessageBox.Show("La ciudad/municipio no existe en el catalogo, favor de revisar.");
                this.SAT_MUNICIPIOIDTextBox.Focus();
                return;
            }



            if (!validarCodigoPostal(ENTREGACODIGOPOSTALTextBox.Text) && ENTREGACODIGOPOSTALTextBox.Text != "")
            {
                MessageBox.Show("El Código Postal de entrega Ingresado no es valido!");
                ENTREGACODIGOPOSTALTextBox.Focus();
                return;
            }

            if (this.ENTREGACALLETextBox.Text.Trim().Length > 0 &&  this.ENTREGA_SAT_COLONIAIDTextBox.Text == "")
            {
                MessageBox.Show("La colonia de entrega ingresada no existe en el catalogo, favor de revisar.");
                this.ENTREGA_SAT_COLONIAIDTextBox.Focus();
                return;
            }
            

            if (this.ENTREGACALLETextBox.Text.Trim().Length > 0 && this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text == "")
            {
                MessageBox.Show("La ciudad/municipio de entrega  no existe en el catalogo, favor de revisar.");
                this.ENTREGA_SAT_MUNICIPIOIDTextBox.Focus();
                return;
            }


            if ((CurrentUserID.CurrentParameters.IESVENDEDORMOVIL == null || !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")) && 
                String.IsNullOrEmpty(VENDEDORIDTextBox.Text))
            {
                MessageBox.Show("Debe asignar un vendedor para poder guardar los cambios");
                return;
            }


            if(this.CREDITOREFERENCIAABONOSTextBox.Text.Length > 0 && bEntroACuenta && CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {
                string strValidacionCuenta = validarCuentasParaFormasDePago(this.CREDITOREFERENCIAABONOSTextBox.Text);
                MessageBox.Show(strValidacionCuenta);
            }


            string errorMessage = "";
            if(!this.validarPorcentajeComision(decimal.Parse(this.POR_COMETextBox.Text.ToString()), ref errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if(NOMBRESTextBox.Text.Trim().Length == 0 )
            {
                NOMBRESTextBox.Text = NOMBRETextBox.Text;
            }

            //if(APELLIDOSTextBox.Text.Trim().Length == 0)
            //{

            //    APELLIDOSTextBox.Text = ".";
            //}

            SaveChanges();
        }

        private bool validarPorcentajeComision(decimal por_come, ref string errorMessage)
        {
            if (CurrentUserID.CurrentParameters.IVERSIONCOMISIONID != 2 || CurrentUserID.CurrentParameters.IMAXCOMISIONXCLIENTE == 0)
                return true;

            if(por_come > CurrentUserID.CurrentParameters.IMAXCOMISIONXCLIENTE)
            {
                errorMessage = "El porcentaje de comision no puede ser mayor a " + CurrentUserID.CurrentParameters.IMAXCOMISIONXCLIENTE.ToString();
                return false;
            }

            return true;
        }

        private string validarCuentasParaFormasDePago(string cuenta)
        {

            CFORMAPAGOSATBE formaPagoSatBE = new CFORMAPAGOSATBE();
            CFORMAPAGOSATD formaPagoSatD = new CFORMAPAGOSATD();

            List<string> strListValidas = new List<string>();
            List<string> strListInvalidas = new List<string>();
            

            //cheque
            formaPagoSatBE = new CFORMAPAGOSATBE();
            formaPagoSatBE.IID = 2;
            formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSAT(formaPagoSatBE, null);
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONORDENANTE != null && formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                {
                    strListInvalidas.Add("Cheque");
                }
                else
                {
                    strListValidas.Add("Cheque");
                }
            }


            //transferencia 
            formaPagoSatBE = new CFORMAPAGOSATBE();
            formaPagoSatBE.IID = 3;
            formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSAT(formaPagoSatBE, null);
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONORDENANTE != null && formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                {
                    strListInvalidas.Add("Transferencia");
                }
                else
                {
                    strListValidas.Add("Transferencia");
                }
            }


            //tarjeta credito
            formaPagoSatBE = new CFORMAPAGOSATBE();
            formaPagoSatBE.IID = 4;
            formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSAT(formaPagoSatBE, null);
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONORDENANTE != null && formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                {
                    strListInvalidas.Add("Tarjeta Credito");
                }
                else
                {
                    strListValidas.Add("Tarjeta Credito");
                }
            }


            //tarjeta debito
            formaPagoSatBE = new CFORMAPAGOSATBE();
            formaPagoSatBE.IID = 28;
            formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSAT(formaPagoSatBE, null);
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONORDENANTE != null && formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                {
                    strListInvalidas.Add("Tarjeta Debito");
                }
                else
                {
                    strListValidas.Add("Tarjeta Debito");
                }
            }


            //vale
            formaPagoSatBE = new CFORMAPAGOSATBE();
            formaPagoSatBE.IID = 8;
            formaPagoSatBE = formaPagoSatD.seleccionarFORMAPAGOSAT(formaPagoSatBE, null);
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONORDENANTE != null && formaPagoSatBE.ISAT_PATRONORDENANTE.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONORDENANTE, false))
                {
                    strListInvalidas.Add("Vale");
                }
                else
                {
                    strListValidas.Add("Vale");
                }
            }

            string retorno = " ";

            if (strListValidas.Count > 0)
            {
                retorno += "La cuenta ingresada en lo que respecta al timbrado de facturas electronicas seria valida para : ";
                foreach (string str in strListValidas)
                {
                    retorno += "\n " + str;
                }
            }
            if (strListInvalidas.Count > 0)
            {
                retorno += "\nLa cuenta ingresada en lo que respecta al timbrado de facturas electronicas seria Invalida para : ";
                foreach (string str in strListInvalidas)
                {
                    retorno += "\n " + str;
                }
            }

            return retorno;

        }


        private bool HayDatosDeFacturaElectronica(CCLIENTEBE clienteBE)
        {
            string camposfaltantes = "";
            if (clienteBE.m_PersonaBE.INOMBRES == null || clienteBE.m_PersonaBE.INOMBRES.Trim().Length <= 0)
            {
                camposfaltantes += "NOMBRES ";
            }
            if (clienteBE.m_PersonaBE.IAPELLIDOS == null || clienteBE.m_PersonaBE.IAPELLIDOS.Trim().Length <= 0)
            {
                camposfaltantes += "APELLIDOS ";
            }
            if (clienteBE.m_PersonaBE.IRFC == null || clienteBE.m_PersonaBE.IRFC.Trim().Length <= 0)
            {
                camposfaltantes += "RFC ";
            }
            if (clienteBE.m_PersonaBE.ICOLONIA == null || clienteBE.m_PersonaBE.ICOLONIA.Trim().Length <= 0)
            {
                camposfaltantes += "COLONIA ";
            }
            if (clienteBE.m_PersonaBE.ICIUDAD == null || clienteBE.m_PersonaBE.ICIUDAD.Trim().Length <= 0)
            {
                camposfaltantes += "CIUDAD ";
            }
            if (clienteBE.m_PersonaBE.IESTADO == null || clienteBE.m_PersonaBE.IESTADO.Trim().Length <= 0)
            {
                camposfaltantes += "ESTADO ";
            }
            if (clienteBE.m_PersonaBE.ICODIGOPOSTAL == null || clienteBE.m_PersonaBE.ICODIGOPOSTAL.Trim().Length <= 0)
            {
                camposfaltantes += "CODIGOPOSTAL ";
            }
            if (clienteBE.m_PersonaBE.IDOMICILIO == null || clienteBE.m_PersonaBE.IDOMICILIO.Trim().Length <= 0)
            {
                camposfaltantes += "DOMICILIO ";
            }

            if (camposfaltantes.Trim().Length <= 0)
            {
                return true;
            }
            else
            {
                if (MessageBox.Show("Este cliente no tiene datos suficientes para hacerle una factura electronica, faltan " +  camposfaltantes + ". Desea continuar?  ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }


        }

        private bool ValidarTipoPrecio(CCLIENTEBE clienteBE)
        {

            if (m_clienteOld != null &&
                (((bool)m_clienteOld.isnull["ILISTAPRECIOID"] && (bool)clienteBE.m_PersonaBE.isnull["ILISTAPRECIOID"]) ||
                   m_clienteOld.ILISTAPRECIOID == clienteBE.m_PersonaBE.ILISTAPRECIOID
                )
            )
            {
                return true;
            }

            if ((clienteBE.m_PersonaBE.ILISTAPRECIOID == 1 && CurrentUserID.CurrentUser.ILISTAPRECIOID < 1)
               || (clienteBE.m_PersonaBE.ILISTAPRECIOID == 2 && CurrentUserID.CurrentUser.ILISTAPRECIOID < 2)
               ||(clienteBE.m_PersonaBE.ILISTAPRECIOID == 3 && CurrentUserID.CurrentUser.ILISTAPRECIOID < 3)
               ||(clienteBE.m_PersonaBE.ILISTAPRECIOID == 4 && CurrentUserID.CurrentUser.ILISTAPRECIOID < 4)
               || (clienteBE.m_PersonaBE.ILISTAPRECIOID == 5 && CurrentUserID.CurrentUser.ILISTAPRECIOID < 5))
            {
                MessageBox.Show("No tiene autorizacion para asignarle al cliente a esa lista de precio");
                return false;
            }

            return true;

        }


        private void HabilitarEdicion(bool b)
        {

            HabilitarValidadores(false);
            panel1.Enabled = b;
            HabilitarValidadores(true);

        }

        private void LimpiarVariablesForm()
        {
            this.ID = -1;
            this.CLAVE = "";
        }

        private void Limpiar()
        {
            Limpiar(false);
            LimpiarDatosDeEntregaDeDomicilio();
        }

        private void Limpiar(bool bLimpiarKeys)
        {
            if (bLimpiarKeys)
            {

                this.CLAVETextBox.Text = "";

            }



            this.ACTIVOTextBox.Checked = false;


            //this.CREADOTextBox.Text = "";


            //this.CREADOPOR_USERIDTextBox.Text = "";


            //this.MODIFICADOTextBox.Text = "";


            this.MODIFICADOPOR_USERIDTextBox.Text = "";


            //this.TIPOPERSONAIDTextBox.Text = "";


            //this.CLAVETextBox.Text = "";


            this.NOMBRETextBox.Text = "";


            //this.DESCRIPCIONTextBox.Text = "";


            this.MEMOTextBox.Text = "";


            //this.SALUDOIDTextBox.SelectedIndex = -1;


            this.NOMBRESTextBox.Text = "";


            this.APELLIDOSTextBox.Text = "";


            this.RAZONSOCIALTextBox.Text = "";


            this.RFCTextBox.Text = "";


            this.CONTACTO1TextBox.Text = "";


            this.CONTACTO2TextBox.Text = "";


            //this.USERNAMETextBox.Text = "";


            //this.CLAVEACCESOTextBox.Text = "";


            this.DOMICILIOTextBox.Text = "";

            this.NUMEROINTERIORTextBox.Text = "";

            this.NUMEROEXTERIORTextBox.Text = "";




            //this.CIUDADTextBox.Text = "";



            this.REFERENCIADOMTextBox.Text = "";

            //this.MUNICIPIOTextBox.Text = "";


            this.ESTADOTextBox.Text = "";


            this.SAT_LOCALIDADIDTextBox.Text = "";
            this.SAT_LOCALIDADIDLabel.Text = "";

            this.SAT_MUNICIPIOIDTextBox.Text = "";
            this.SAT_MUNICIPIOIDLabel.Text = "";
            
            
            this.CODIGOPOSTALTextBox.Text = "";

            this.SAT_COLONIAIDTextBox.Text = "";
            this.SAT_COLONIAIDLabel.Text = "";


            this.TELEFONO1TextBox.Text = "";


            this.TELEFONO2TextBox.Text = "";


            /*this.TELEFONO3TextBox.Text = "";


            this.CELULARTextBox.Text = "";


            this.NEXTELTextBox.Text = "";

            */
            this.EMAIL1TextBox.Text = "";


            this.EMAIL2TextBox.Text = "";


            //this.EMPRESAIDTextBox.Text = "";


            this.VENDEDORIDTextBox.Text = "";


            //this.ESCLIENTETextBox.Checked = false;


            //this.ESCLIENTEGENERALTextBox.Checked = false;


            //this.ESCLIENTETextBox.Checked = false;


            //this.ESUSUARIOTextBox.Checked = false;


            this.LISTAPRECIOIDTextBox.Text = "";
            this.SUPERLISTAPRECIOIDTextBox.Text = "";


            this.VIGENCIATextBox.Text = "";


            //this.RESET_PASSTextBox.Text = "";
            this.HAB_PAGOTARJETATextBox.Checked = false;
            this.HAB_PAGOCREDITOTextBox.Checked = false;
            this.HAB_PAGOCHEQUETextBox.Checked = false;

            this.BLOQUEADOTextBox.Checked = false;
            this.LIMITECREDITOTextBox.Text = "";
            this.DIASTextBox.Text =  "";
            this.REVISIONTextBox.Text = "";
            this.PAGOSTextBox.Text = "";





            this.RETIENEISRTextBox.Checked = false;

            this.RETIENEIVATextBox.Checked = false;


            this.MONEDAIDTextBox.DbValue = "1";

            this.DESGLOSEIEPSTextBox.Checked = false;

            CUENTAIEPSTextBox.Text = "";

            this.EMAIL3TextBox.Text = "";

            this.EMAIL4TextBox.Text = "";
            this.PAGOPARCIALIDADESTextBox.Checked = false;


            this.SERVICIOADOMICILIOTextBox.Checked = false;

            this.chkOrdenCompra.Checked = false;

            this.txtCuentaContpaq.Text = "";

            this.cbSepararProdXPlazo.Checked = false;


            GENERARRECIBOELECTRONICOTextBox.Checked = false;

            this.CARGOXVENTACONTARJETATextBox.Checked = CurrentUserID.CurrentParameters.ICOMISIONPORTARJETA > 0 || CurrentUserID.CurrentParameters.ICOMISIONDEBPORTARJETA > 0;

            this.PAGOTARJMENORPRECIOLISTATextBox.Checked = false;

            this.EXENTOIVATextBox.Checked = false;

            this.DIAS_EXTRTextBox.Text = "";
            this.POR_COMETextBox.Text = "";


            this.PREGUNTARTICKETLARGOTextBox.Checked = false;

            this.MAYOREOXPRODUCTOTextBox.Checked = false;

            this.GENERACOMPROBTRASLTextBox.Checked = false;

            this.GENERACARTAPORTETextBox.Checked = false;


            this.DISTANCIATextBox.Text = "";



        }


        private void LimpiarDatosDeEntregaDeDomicilio()
        {

            this.m_currentDomicilioId = null;

            this.ENTREGACALLETextBox.Text = "";
            this.ENTREGANUMEROINTERIORTextBox.Text = "";
            this.ENTREGANUMEROEXTERIORTextBox.Text = "";
            this.ENTREGAESTADOTextBox.Text = "";
            this.ENTREGACODIGOPOSTALTextBox.Text = "";

            this.ENTREGA_SAT_LOCALIDADIDTextBox.Text = "";
            this.ENTREGA_SAT_LOCALIDADIDLabel.Text = "";
            this.ENTREGA_SAT_MUNICIPIOIDTextBox.Text = "";
            this.ENTREGA_SAT_MUNICIPIOIDLabel.Text = "";
            this.ENTREGA_SAT_COLONIAIDTextBox.Text = "";
            this.ENTREGA_SAT_COLONIAIDLabel.Text = "";


            this.ENTREGA_DISTANCIATextBox.Text = "";
            this.ENTREGAREFERENCIADOMTextBox.Text = "";
            this.ENTREGALONGITUDTextBox.Text = "";
            this.ENTREGALATITUDTextBox.Text = "";

        }


        //private void button2_Click(object sender, EventArgs e)
        //{

        //    ShowLookUp();
        //}

        //private void ShowLookUp()
        //{

        //    GeneralLookUp look = new GeneralLookUp("select * from PERSONA", "PERSONA");
        //    look.ShowDialog();
        //    DataRow dr = look.m_rtnDataRow;

        //    if (dr != null)
        //    {

        //        this.IDTextBox.Text = dr[0].ToString();


        //    }

        //    look.Dispose();
        //    SetMode();

        //}


        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.F5)
            //{
            //    ShowLookUp();
            //}
        }






        private void SetMode()
        {
            if (this.CLAVETextBox.Text != "")
            {

                this.CLAVE = this.CLAVETextBox.Text;

                if (this.LlenarDatosDeBase())
                {
                    if (this.opc != "Agregar" && this.opc != "")
                    {
                        this.opc = "Cambiar";
                        HabilitarEdicion(true);
                        this.BTIniciaEdicion.Enabled = false;
                    }
                    else
                    {
                        this.BTIniciaEdicion.Enabled = true;
                    }
                }
                else
                {
                    this.opc = "Agregar";
                    Limpiar();
                    HabilitarEdicion(true);
                    //this.btEliminar.Enabled = false;
                    this.BTIniciaEdicion.Enabled = false;
                }
            }
            else
            {
                Limpiar();
                HabilitarEdicion(false);
                //this.btEliminar.Enabled = false;
                this.BTIniciaEdicion.Enabled = false;
            }
        }



        private void IDTextBox_Validated(object sender, EventArgs e)
        {
           // SetMode();
        }


        //private void btEliminar_Click(object sender, EventArgs e)
        //{
        //    this.opc = "Borrar";
        //    SaveChanges();
        //}


        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            //this.IDTextBox.Focus();
            this.CLAVETextBox.Focus(); 
            HabilitarValidadores(true);
            this.HabilitarEdicion(false);
        }

        public void HabilitarValidadores(bool bEnabled) // new for generator
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

                        v.ControlToValidate.Name != "CLAVETextBox"
                        )
                            continue;
                    }
                    if (v.ControlToValidate != null)
                    {
                        v.Validate();
                        if (!v.IsValid)
                        {
                            ErroresValidacion += v.ErrorMessage + "--";
                        }
                    }
                }
                catch
                {
                }
            }
        }


        private void CLAVETextBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.opc != "Agregar" && this.opc != "")
            {
                this.CLAVE = CLAVETextBox.Text;
                if (!LlenarDatosDeBase())
                {
                    e.Cancel = true;
                    MessageBox.Show("No existe una marca con esa clave");
                }
            }
        }

        private void BTIniciaEdicion_Click(object sender, EventArgs e)
        {
            this.opc = "Cambiar";
            HabilitarEdicion(true);
            this.BTIniciaEdicion.Enabled = false;
            this.button1.Visible = true;
            this.button1.Enabled = true;
            this.button1.Text = "Guardar";
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PERSONAEdit_Reg_Load(object sender, EventArgs e)
        {
            pnlDesglosaIEPS.Visible = CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");
            RETIENEIVATextBox.Visible = CurrentUserID.CurrentParameters.IARRENDATARIO.Equals("S");
            RETIENEISRTextBox.Visible = CurrentUserID.CurrentParameters.IARRENDATARIO.Equals("S");

            SUPERLISTAPRECIOIDLabel.Visible = CurrentUserID.CurrentParameters.IMANEJASUPERLISTAPRECIO.Equals("S");
            SUPERLISTAPRECIOIDTextBox.Visible = CurrentUserID.CurrentParameters.IMANEJASUPERLISTAPRECIO.Equals("S");

            HabilitaDeshabilitaCreditoCobranza();

            if(CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {
                LblFormaPago.Visible = false;
                CREDITOFORMAPAGOABONOSTextBox.Visible = false;
                lblReferencia.Text = "No de cuenta:";
            }


            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                ACTIVOTextBox.Visible = false;
                VIGENCIALabel.Visible = false;
                VIGENCIATextBox.Visible = false;
                CREADOPOR_USERIDLabel.Visible = false;
                TextBoxCREADOPOR_USERCLAVE.Visible = false;
                MODIFICADOPOR_USERIDLabel.Visible = false;
                MODIFICADOPOR_USERIDTextBox.Visible = false;
                VENDEDORIDLabel.Visible = false;
                VENDEDORIDTextBox.Visible = false;
                VENDEDORButton.Visible = false;
                VENDEDORLabel.Visible = false;

                 if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL != 2)
                 {

                     NOMBRESLabel.Visible = false;
                     NOMBRESTextBox.Visible = false;
                     APELLIDOSLabel.Visible = false;
                     APELLIDOSTextBox.Visible = false;
                 }

                mONEDAIDLabel.Visible = false;
                MONEDAIDTextBox.Visible = false;
                MONEDAButton.Visible = false;
                MONEDALabel.Visible = false;
                panel3.Visible = false;

                RAZONSOCIALLabel.Visible = false;
                RAZONSOCIALTextBox.Visible = false;

                MEMOLabel.Text = "Cruces";


                this.PAISComboBoxFb.llenarDatos();
                this.PAISComboBoxFb.SelectedValue = "MEX";

            }


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoHistorial = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_BITACORA_CLIENTES, null);
            this.btnHistory.Visible = usuarioTienePermisoHistorial;

            Boolean usuarioTienePermisoEstadistico = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_ESTADISTICOSCLIENTEVENTA, null);
            this.estadisticosToolStripMenuItem.Visible = usuarioTienePermisoEstadistico;

            Boolean usuarioTienePermisoAnalisis = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_ANALISISPRODUCTO, null);
            this.reportesToolStripMenuItem.Visible = usuarioTienePermisoAnalisis;


            Boolean usuarioTienePermisoEditarPrecioPorCliente = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_EDITARPRECIOS_POR_CLIENTE, null);
            this.preciosEspecificosToolStripMenuItem.Visible = usuarioTienePermisoEditarPrecioPorCliente && CurrentUserID.CurrentParameters.IHAB_PRECIOSCLIENTE != null && CurrentUserID.CurrentParameters.IHAB_PRECIOSCLIENTE == "S";


            Boolean usuarioTienePermisoNotasIncidencia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_NOTASINCIDENCIA, null);
            this.btnNotaIncidencia.Visible = usuarioTienePermisoNotasIncidencia;


            //derecho a cambiar vendedor del cliente
            Boolean usuarioTienePermisoCambiarVendedor = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARVENDEDORCLIENTE, null);
            this.VENDEDORIDTextBox.Enabled = usuarioTienePermisoCambiarVendedor;
            this.VENDEDORButton.Enabled = usuarioTienePermisoCambiarVendedor;


            if (CurrentUserID.CurrentParameters.IPLAZOXPRODUCTO != "S")
            {
                this.label28.Visible = false;
                this.cbSepararProdXPlazo.Visible = false;
            }

            this.PAISComboBoxFb.llenarDatos();
            this.PAISComboBoxFb.SelectedValue = "MEX";


            Boolean usuarioTienePermisorRelacionarClienteProveedor = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_RELACIONAR_PROVEE_CLIENTE, null);
            PROVEECLIENTEIDTextBox.Enabled = usuarioTienePermisorRelacionarClienteProveedor;
            PROVEECLIENTEIDButton.Enabled = usuarioTienePermisorRelacionarClienteProveedor;

            Boolean usuarioTienePermisoExentarIvaClientes= usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_EXENTARIVACLIENTES, null);
            EXENTOIVATextBox.Enabled = usuarioTienePermisoExentarIvaClientes;


            m_terminoLoad = true;

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void todasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WFMovimientosCliente wm = new WFMovimientosCliente(this.ID,"N");
            wm.ShowDialog();
            wm.Dispose();
            GC.SuppressFinalize(wm);
        }

        private void conSaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WFMovimientosCliente wm = new WFMovimientosCliente(this.ID, "S");
            wm.ShowDialog();
            wm.Dispose();
            GC.SuppressFinalize(wm);
        }

        private void DESGLOSEIEPSTextBox_CheckedChanged(object sender, EventArgs e)
        {
            CUENTAIEPSTextBox.Enabled = DESGLOSEIEPSTextBox.Checked;
        }

        private void anticiposToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WFMovimientosAnticipo wm = new WFMovimientosAnticipo(this.ID, "N");
            wm.ShowDialog();
            wm.Dispose();
            GC.SuppressFinalize(wm);
        }


        private void HabilitaDeshabilitaCreditoCobranza()
        {


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CREDITOCOBRANZA, null))
            {
                HAB_PAGOCREDITOTextBox.Enabled = true;
                HAB_PAGOCHEQUETextBox.Enabled = true;
                HAB_PAGOTRANSFERENCIATextBox.Enabled = true;
                LIMITECREDITOTextBox.Enabled = true;
                DIASTextBox.Enabled = true;
                REVISIONTextBox.Enabled = true;
                PAGOSTextBox.Enabled = true;
                BLOQUEADOTextBox.Enabled = true;
                DIAS_EXTRTextBox.Enabled = true;
                POR_COMETextBox.Enabled = true;
            }
            else
            {
                HAB_PAGOCREDITOTextBox.Enabled = false;
                HAB_PAGOCHEQUETextBox.Enabled = false;
                HAB_PAGOTRANSFERENCIATextBox.Enabled = false;
                LIMITECREDITOTextBox.Enabled = false;
                DIASTextBox.Enabled = false;
                REVISIONTextBox.Enabled = false;
                PAGOSTextBox.Enabled = false;
                BLOQUEADOTextBox.Enabled = false;
                DIAS_EXTRTextBox.Enabled = false;
                POR_COMETextBox.Enabled = false;

            }
        }

        private void analisisToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (m_clienteOld != null && m_clienteOld.IID != 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("clienteid", m_clienteOld.IID);
                dictionary.Add("fechaini", DateTime.Today);
                dictionary.Add("fechafin", DateTime.Today);
                dictionary.Add("sortorder", "Cantidad");
                dictionary.Add("nombrecliente", m_clienteOld.INOMBRE);


                string strReporte = "InformeProductoXClienteDetalle.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            CCLIENTED clienteD = new CCLIENTED();
            CCLIENTEBE clienteBE = new CCLIENTEBE();

            clienteBE.m_PersonaBE.ICLAVE = CLAVE;
            clienteBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
            clienteBE.m_PersonaBE = clienteD.seleccionarPERSONAxCLAVE(clienteBE.m_PersonaBE, null);

            WFLogItems wfLogItems = new WFLogItems("Cliente", clienteBE);
            wfLogItems.ShowDialog();
            wfLogItems.Dispose();
            GC.SuppressFinalize(wfLogItems);
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", m_clienteOld.IID);
            dictionary.Add("fechaini", DateTime.Today);
            dictionary.Add("fechafin", DateTime.Today);
            dictionary.Add("nombrecliente", m_clienteOld.INOMBRE);

            string strReporte = "InformeLineaXCliente.frx";


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", m_clienteOld.IID);
            dictionary.Add("fechaini", DateTime.Today);
            dictionary.Add("fechafin", DateTime.Today);
            dictionary.Add("nombrecliente", m_clienteOld.INOMBRE);

            string strReporte = "InformeMarcaXCliente.frx";


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", m_clienteOld.IID);
            dictionary.Add("fechaini", DateTime.Today);
            dictionary.Add("fechafin", DateTime.Today);
            dictionary.Add("nombrecliente", m_clienteOld.INOMBRE);

            string strReporte = "InformeProveedorXCliente.frx";


            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void estadisticosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            iPos.WFEstadisticosClienteVenta rp = new iPos.WFEstadisticosClienteVenta(this.ID);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void detalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_clienteOld != null && m_clienteOld.IID != 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("clienteid", m_clienteOld.IID);
                dictionary.Add("fechaini", DateTime.Today);
                dictionary.Add("fechafin", DateTime.Today);
                dictionary.Add("sortorder", "Cantidad");
                dictionary.Add("nombrecliente", m_clienteOld.INOMBRE);


                string strReporte = "InformeProductoXClienteDetalle.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

        private void sumarizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_clienteOld != null && m_clienteOld.IID != 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("clienteid", m_clienteOld.IID);
                dictionary.Add("fechaini", DateTime.Today);
                dictionary.Add("fechafin", DateTime.Today);
                dictionary.Add("sortorder", "Cantidad");
                dictionary.Add("nombrecliente", m_clienteOld.INOMBRE);


                string strReporte = "InformeProductoXClienteSumarizado.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

        private void preciosEspecificosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WFPrecioPersona wf = new WFPrecioPersona(ID);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void descuentosPorLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IHABDESCLINEAPERSONA.Equals("S"))
            {
                WFDescuentoLineaPersona wf = new WFDescuentoLineaPersona(ID);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
            else
            {
                MessageBox.Show("Usted no tiene habilitado esta opción en Empresa");
            }
        }

        private bool validarCodigoPostal(string cp)
        {
            CSAT_CODIGOPOSTALBE codPostal = new CSAT_CODIGOPOSTALBE();
            CSAT_CODIGOPOSTALD daoCodPostal = new CSAT_CODIGOPOSTALD();
            codPostal.ISAT_CLAVE = cp;
            if(daoCodPostal.ExisteSAT_CODIGOPOSTALXCLAVE(codPostal, null) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CREDITOREFERENCIAABONOSTextBox_Enter(object sender, EventArgs e)
        {
            bEntroACuenta = true;
        }

        private void btnCuentasBanco_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                Contabilidad.WFPersonaCuentasBancos wf = new Contabilidad.WFPersonaCuentasBancos(ID);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
        }




        private void putDefaultValuesFPClientesCreados()
        {

            string strValor = CurrentUserID.CurrentUser.ICLIEFORMASPAGODEF;


            if (strValor == null || strValor.Trim().Length == 0)
                return;
            string[] valoresAChecar = strValor.Split(new char[] { '|' });

            foreach (string strChecado in valoresAChecar)
            {

                switch (long.Parse(strChecado))
                {
                    case DBValues._FORMA_PAGO_EFECTIVO:
                        {
                            HAB_PAGOEFECTIVOTextBox.Checked = true;
                            break;
                        }


                    case DBValues._FORMA_PAGO_TARJETA:
                        {
                            HAB_PAGOTARJETATextBox.Checked = true;
                            break;
                        }


                    case DBValues._FORMA_PAGO_CHEQUE:
                        {
                            HAB_PAGOCHEQUETextBox.Checked = true;
                            break;
                        }



                    case DBValues._FORMA_PAGO_TRANSFERENCIA:
                        {
                            this.HAB_PAGOTRANSFERENCIATextBox.Checked = true;
                            break;
                        }


                    case DBValues._FORMA_PAGO_CREDITO:
                        {
                            this.HAB_PAGOCREDITOTextBox.Checked = true;
                            break;
                        }
                }
            }
        }


        private void SeleccionaRutaEmbarque()
        {
            WFRutasEmbarque look = new iPos.Catalogos.WFRutasEmbarque();
            //look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.RUTAEMBARQUEIDDescLabel.Text = dr["NOMBRE"].ToString().Trim();
                RUTAEMBARQUEIDTextBox.Text = dr["CLAVE"].ToString().Trim();
                RUTAEMBARQUEIDTextBox.Focus();
                //m_RutaEmbarqueId = (long)dr["ID"];
            }

        }

        private void RUTAEMBARQUEIDButton_Click(object sender, EventArgs e)
        {
            SeleccionaRutaEmbarque();
        }

        private void historialVentasYNCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            WFClientesProductos wm = new WFClientesProductos(this.ID);
            wm.ShowDialog();
            wm.Dispose();
            GC.SuppressFinalize(wm);
        }


        private void agregarNota(bool forzarNota, string title, long tipoEventoId)
        {

            string strNota = "";
            bool bNotaAgregada = false;
            WFNotaIncidencia look = new WFNotaIncidencia(forzarNota, title);
            look.ShowDialog();
            strNota = look.strNotaIncidencia;
            bNotaAgregada = look.m_notaAgregada;
            look.Dispose();
            GC.SuppressFinalize(look);


            CLOGEVENTOTABLAD logD = new CLOGEVENTOTABLAD();
            CLOGEVENTOTABLABE logBE = new CLOGEVENTOTABLABE();
            if (bNotaAgregada && strNota != null && strNota.Trim().Length > 0)
            {
                logBE.IUSUARIOID = CurrentUserID.CurrentUser.IID;
                logBE.ITIPOEVENTOTABLAID = tipoEventoId;
                logBE.IACTIVO = "S";
                logBE.ITABLA = "Clientes";
                logBE.INOTA = strNota;
                logBE.IRECORDID = this.ID;
                logBE.IFECHAHORA = DateTime.Now;
                logD.AgregarLOGEVENTOTABLAD(logBE, null);
            }

        }

        private void BTAgregarNota_Click(object sender, EventArgs e)
        {
            agregarNota(false, "Nota incidencia cliente", (int)DBValues._TIPOEVENTOTABLA_NOTA);
        }

        private void btnNotaIncidencia_Click(object sender, EventArgs e)
        {

            CCLIENTED clienteD = new CCLIENTED();
            CCLIENTEBE clienteBE = new CCLIENTEBE();

            clienteBE.m_PersonaBE.ICLAVE = CLAVE;
            clienteBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_CLIENTE;
            clienteBE.m_PersonaBE = clienteD.seleccionarPERSONAxCLAVE(clienteBE.m_PersonaBE, null);

            WFLogEventoTable wfLogItems = new WFLogEventoTable("Clientes", clienteBE);
            wfLogItems.ShowDialog();
            wfLogItems.Dispose();
            GC.SuppressFinalize(wfLogItems);
        }

        private void ESTADOTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (m_terminoLoad)
            {
                this.LlenarCamposRelacionadosAEstado();
            }
        }

        private void CODIGOPOSTALTextBox_Validated(object sender, EventArgs e)
        {
            if (m_terminoLoad)
            {
                LlenarCamposRelacionadosACodigoPostal();
            }
        }

        private void ENTREGACODIGOPOSTALTextBox_Validated(object sender, EventArgs e)
        {

            if (m_terminoLoad)
            {
                LlenarCamposRelacionadosACodigoPostal_Entrega();
            }
        }

        private void ENTREGAESTADOTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_terminoLoad)
            {
                this.LlenarCamposRelacionadosAEstado_Entrega();
            }
        }


        private void btnFirmaImageSelector_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Imagenes";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
        "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NuevaFirmaImagenTextBox.Text = openFileDialog1.FileName;

                try
                {
                    FIRMAIMAGENPictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                
                    if (FIRMAIMAGENPictureBox.Image != null)
                    {
                        m_bChangeFirmaImage = true;
                        this.m_firmaImageExtension = Path.GetExtension(openFileDialog1.FileName);
                    }
                }
                catch
                {
                }

            }
        }

        private void btnEliminarFirmaImagen_Click(object sender, EventArgs e)
        {

            m_bChangeFirmaImage = true;
            FIRMAIMAGENPictureBox.Image = null;
        }

        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {

            WFSeleccionLocation wf = new WFSeleccionLocation(LATITUDTextBox.Text, LONGITUDTextBox.Text);
            wf.ShowDialog();

            if (wf.LatitudSelected != null && wf.LongitudSelected != null &&
               wf.LatitudSelected != "" && wf.LongitudSelected != "")
            {
                this.LATITUDTextBox.Text = wf.LatitudSelected;
                this.LONGITUDTextBox.Text = wf.LongitudSelected;
            }

            wf.Dispose();
            GC.SuppressFinalize(wf);
        }


        private double? ParseNullableDouble(string s)
        {
            double v;
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out v))
                return v;
            return null;
        }

        private void LlenarDomicilios()
        {
            try
            {
                this.dOMICILIOSXPERSONATableAdapter.Fill(this.dSCatalogos3.DOMICILIOSXPERSONA, this.ID,"N");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnMapaEntrega_Click(object sender, EventArgs e)
        {

            WFSeleccionLocation wf = new WFSeleccionLocation(ENTREGALATITUDTextBox.Text, ENTREGALONGITUDTextBox.Text);
            wf.ShowDialog();

            if (wf.LatitudSelected != null && wf.LongitudSelected != null &&
               wf.LatitudSelected != "" && wf.LongitudSelected != "")
            {
                this.ENTREGALATITUDTextBox.Text = wf.LatitudSelected;
                this.ENTREGALONGITUDTextBox.Text = wf.LongitudSelected;
            }

            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void dOMICILIOSXPERSONADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (dOMICILIOSXPERSONADataGridView.Columns[e.ColumnIndex].Name == "BTNEDITARDOMICILIO")
                {
                    this.pnlEdicionDatosEntrega.Enabled = true;
                    
                    var domId = long.Parse(dOMICILIOSXPERSONADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    this.LlenarDatosDeEntregaDeDomicilio(domId);
                }
                else if (dOMICILIOSXPERSONADataGridView.Columns[e.ColumnIndex].Name == "BTNELIMINARDOMICILIO")
                {

                    var domId = long.Parse(dOMICILIOSXPERSONADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    this.EliminarDomicilio(domId);


                }
            }
        }

        private void btnGuardarDatosEntrega_Click(object sender, EventArgs e)
        {
            CDOMICILIOD domicilioD = new CDOMICILIOD();
            CDOMICILIOBE domicilioBE = new CDOMICILIOBE(); 
            bool resultado = false;
            if(m_currentDomicilioId != null)
            {
                domicilioBE.IID = m_currentDomicilioId.Value;
                domicilioBE = domicilioD.seleccionarDOMICILIO(domicilioBE, null);
                domicilioBE = ObtenerDomicilioCapturado(domicilioBE);
                domicilioBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                resultado = domicilioD.CambiarDOMICILIOD(domicilioBE, domicilioBE, null);
            }
            else
            {
                domicilioBE = ObtenerDomicilioCapturado(domicilioBE);
                domicilioBE.IACTIVO = "S";
                domicilioBE.IPREDETERMINADO = "N";
                domicilioBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;
                resultado = domicilioD.AgregarDOMICILIOD(domicilioBE, null) != null;
            }

            if (resultado)
            {
                LimpiarDatosDeEntregaDeDomicilio();
                this.pnlEdicionDatosEntrega.Enabled = false;
                this.LlenarDomicilios();
            }
            else
            {
                MessageBox.Show("Ocurrio un error : " +  domicilioD.IComentario);
            }
        }

        private void EliminarDomicilio(long domicilioId)
        {

            CDOMICILIOD domicilioD = new CDOMICILIOD();
            CDOMICILIOBE domicilioBE = new CDOMICILIOBE();
            domicilioBE.IID = domicilioId;
            domicilioBE = domicilioD.seleccionarDOMICILIO(domicilioBE, null);
            domicilioBE.IACTIVO = "N";

            bool resultado = false;

            resultado = domicilioD.CambiarDOMICILIOD(domicilioBE, domicilioBE, null);

            if (resultado)
            {
                LimpiarDatosDeEntregaDeDomicilio();
                this.pnlEdicionDatosEntrega.Enabled = false;
                this.LlenarDomicilios();
            }
            else
            {
                MessageBox.Show("Ocurrio un error : " + domicilioD.IComentario);
            }
        }

        private void BtnAgregarDatosEntrega_Click(object sender, EventArgs e)
        {

            if(this.ID <= 0)
            {
                MessageBox.Show("Primero guarde al cliente antes de guardar datos de entrega");
                return;
            }

            LimpiarDatosDeEntregaDeDomicilio();
            this.pnlEdicionDatosEntrega.Enabled = true;
        }

        private void btnCancelarGuardadoEntrega_Click(object sender, EventArgs e)
        {
            this.pnlEdicionDatosEntrega.Enabled = false;
            this.LimpiarDatosDeEntregaDeDomicilio();
        }
    }
}
