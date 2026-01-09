
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

namespace iPos
{
    public partial class WFVendedorEdicion : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;


        public delegate void AccionHandler(object source, Hashtable evtArgs);
        //public event AccionHandler AccionUsuario;

        public WFVendedorEdicion()
        {
            InitializeComponent();
            this.SALUDOIDTextBox.llenarDatos();
        }


        public void ReCargar(string popc,string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);
            ESTADOTextBox.llenarDatos();
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

            this.button1.Text = opc;
            if (this.opc != "Agregar" && this.opc != "")
            {
                if (this.opc == "Consultar")
                {
                    this.button1.Visible = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.Exit;
                }
                else { HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; }
                LlenarDatosDeBase();
                this.CLAVETextBox.Enabled = false;


                this.btnQuotas.Visible = true;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
            }

        }



        private void PERSONAEdit_Reg_Load(object sender, EventArgs e)
        {
            this.PAISComboBoxFb.llenarDatos();
            this.PAISComboBoxFb.SelectedValue = "MEX";
        }


        private bool LlenarDatosDeBase()
        {
            //string strBuffer = "";
            try
            {
                CVENDEDORD proveedorD = new CVENDEDORD();
                CVENDEDORBE proveedorBE = new CVENDEDORBE();

                proveedorBE.m_PersonaBE.ICLAVE = CLAVE;
                proveedorBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_VENDEDOR;
                proveedorBE.m_PersonaBE = proveedorD.seleccionarPERSONAxCLAVE(proveedorBE.m_PersonaBE, null);

                if (proveedorBE.m_PersonaBE == null)
                    return false;

                this.ID = proveedorBE.m_PersonaBE.IID;

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IID"])
                //{
                //    this.IDTextBox.Text = proveedorBE.m_PersonaBE.IID.ToString();
                //}
                //else
                //{
                //    this.IDTextBox.Text = "";
                //}



                this.ACTIVOTextBox.Checked = (proveedorBE.m_PersonaBE.IACTIVO == "S") ? true : false;

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["ICREADOPOR_USERID"])
                //{
                //    this.CREADOPOR_USERIDTextBox.Text = proveedorBE.m_PersonaBE.ICREADOPOR_USERID.ToString();
                //}
                //else
                //{
                //    this.CREADOPOR_USERIDTextBox.Text = "";
                //}

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IMODIFICADOPOR_USERID"])
                //{
                //    this.MODIFICADOPOR_USERIDTextBox.Text = proveedorBE.m_PersonaBE.IMODIFICADOPOR_USERID.ToString();
                //}
                //else
                //{
                //    this.MODIFICADOPOR_USERIDTextBox.Text = "";
                //}

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["ITIPOPERSONAID"])
                //{
                //    this.TIPOPERSONAIDTextBox.Text = proveedorBE.m_PersonaBE.ITIPOPERSONAID.ToString();
                //}
                //else
                //{
                //    this.TIPOPERSONAIDTextBox.Text = "";
                //}

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICLAVE"])
                {
                    this.CLAVETextBox.Text = proveedorBE.m_PersonaBE.ICLAVE.ToString();
                }
                else
                {
                    this.CLAVETextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["INOMBRE"])
                {
                    this.NOMBRETextBox.Text = proveedorBE.m_PersonaBE.INOMBRE.ToString();
                }
                else
                {
                    this.NOMBRETextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IDESCRIPCION"])
                {
                    this.DESCRIPCIONTextBox.Text = proveedorBE.m_PersonaBE.IDESCRIPCION.ToString();
                }
                else
                {
                    this.DESCRIPCIONTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IMEMO"])
                {
                    this.MEMOTextBox.Text = proveedorBE.m_PersonaBE.IMEMO.ToString();
                }
                else
                {
                    this.MEMOTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ISALUDOID"])
                {
                    //this.SALUDOIDTextBox.Text = proveedorBE.m_PersonaBE.ISALUDOID.ToString();

                    this.SALUDOIDTextBox.SelectedDataValue = proveedorBE.m_PersonaBE.ISALUDOID;
                }
                else
                {
                    this.SALUDOIDTextBox.SelectedIndex = -1;
                    
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["INOMBRES"])
                {
                    this.NOMBRESTextBox.Text = proveedorBE.m_PersonaBE.INOMBRES.ToString();
                }
                else
                {
                    this.NOMBRESTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IAPELLIDOS"])
                {
                    this.APELLIDOSTextBox.Text = proveedorBE.m_PersonaBE.IAPELLIDOS.ToString();
                }
                else
                {
                    this.APELLIDOSTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IRAZONSOCIAL"])
                {
                    this.RAZONSOCIALTextBox.Text = proveedorBE.m_PersonaBE.IRAZONSOCIAL.ToString();
                }
                else
                {
                    this.RAZONSOCIALTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IRFC"])
                {
                    this.RFCTextBox.Text = proveedorBE.m_PersonaBE.IRFC.ToString();
                }
                else
                {
                    this.RFCTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICONTACTO1"])
                {
                    this.CONTACTO1TextBox.Text = proveedorBE.m_PersonaBE.ICONTACTO1.ToString();
                }
                else
                {
                    this.CONTACTO1TextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICONTACTO2"])
                {
                    this.CONTACTO2TextBox.Text = proveedorBE.m_PersonaBE.ICONTACTO2.ToString();
                }
                else
                {
                    this.CONTACTO2TextBox.Text = "";
                }

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IUSERNAME"])
                //{
                //    this.USERNAMETextBox.Text = proveedorBE.m_PersonaBE.IUSERNAME.ToString();
                //}
                //else
                //{
                //    this.USERNAMETextBox.Text = "";
                //}

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["ICLAVEACCESO"])
                //{
                //    this.CLAVEACCESOTextBox.Text = proveedorBE.m_PersonaBE.ICLAVEACCESO.ToString();
                //}
                //else
                //{
                //    this.CLAVEACCESOTextBox.Text = "";
                //}

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IDOMICILIO"])
                {
                    this.DOMICILIOTextBox.Text = proveedorBE.m_PersonaBE.IDOMICILIO.ToString();
                }
                else
                {
                    this.DOMICILIOTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICOLONIA"])
                {
                    this.COLONIATextBox.Text = proveedorBE.m_PersonaBE.ICOLONIA.ToString();
                }
                else
                {
                    this.COLONIATextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICIUDAD"])
                {
                    this.CIUDADTextBox.Text = proveedorBE.m_PersonaBE.ICIUDAD.ToString();
                }
                else
                {
                    this.CIUDADTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IMUNICIPIO"])
                {
                    this.MUNICIPIOTextBox.Text = proveedorBE.m_PersonaBE.IMUNICIPIO.ToString();
                }
                else
                {
                    this.MUNICIPIOTextBox.Text = "";
                }


                if (!(bool)proveedorBE.m_PersonaBE.isnull["IESTADO"])
                {
                    this.ESTADOTextBox.SelectedDataDisplaying = proveedorBE.m_PersonaBE.IESTADO.ToString();
                }
                else
                {
                    this.ESTADOTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ISAT_CLAVE_PAIS"])
                {
                    this.PAISComboBoxFb.SelectedValue = proveedorBE.m_PersonaBE.ISAT_CLAVE_PAIS.ToString();
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICODIGOPOSTAL"])
                {
                    this.CODIGOPOSTALTextBox.Text = proveedorBE.m_PersonaBE.ICODIGOPOSTAL.ToString();
                }
                else
                {
                    this.CODIGOPOSTALTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ITELEFONO1"])
                {
                    this.TELEFONO1TextBox.Text = proveedorBE.m_PersonaBE.ITELEFONO1.ToString();
                }
                else
                {
                    this.TELEFONO1TextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ITELEFONO2"])
                {
                    this.TELEFONO2TextBox.Text = proveedorBE.m_PersonaBE.ITELEFONO2.ToString();
                }
                else
                {
                    this.TELEFONO2TextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ITELEFONO3"])
                {
                    this.TELEFONO3TextBox.Text = proveedorBE.m_PersonaBE.ITELEFONO3.ToString();
                }
                else
                {
                    this.TELEFONO3TextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ICELULAR"])
                {
                    this.CELULARTextBox.Text = proveedorBE.m_PersonaBE.ICELULAR.ToString();
                }
                else
                {
                    this.CELULARTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["INEXTEL"])
                {
                    this.NEXTELTextBox.Text = proveedorBE.m_PersonaBE.INEXTEL.ToString();
                }
                else
                {
                    this.NEXTELTextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IEMAIL1"])
                {
                    this.EMAIL1TextBox.Text = proveedorBE.m_PersonaBE.IEMAIL1.ToString();
                }
                else
                {
                    this.EMAIL1TextBox.Text = "";
                }

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IEMAIL2"])
                {
                    this.EMAIL2TextBox.Text = proveedorBE.m_PersonaBE.IEMAIL2.ToString();
                }
                else
                {
                    this.EMAIL2TextBox.Text = "";
                }

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IEMPRESAID"])
                //{
                //    this.EMPRESAIDTextBox.Text = proveedorBE.m_PersonaBE.IEMPRESAID.ToString();
                //    this.EMPRESAIDTextBox.MostrarErrores = false;
                //    this.EMPRESAIDTextBox.MValidarEntrada(out strBuffer);
                //    this.EMPRESAIDTextBox.MostrarErrores = true;
                //}
                //else
                //{
                //    this.EMPRESAIDTextBox.Text = "";
                //}

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IVENDEDORID"])
                //{
                //    this.VENDEDORIDTextBox.Text = proveedorBE.m_PersonaBE.IVENDEDORID.ToString();
                //    //this.VENDEDORIDTextBox.SelectedDataValue = proveedorBE.m_PersonaBE.IVENDEDORID;
                //    this.VENDEDORIDTextBox.MostrarErrores = false;
                //    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer);
                //    this.VENDEDORIDTextBox.MostrarErrores = true;
                //}
                //else
                //{
                //    this.VENDEDORIDTextBox.Text = "";
                //}

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IESVENDEDOR"])
                //{
                //    this.ESVENDEDORTextBox.Text = proveedorBE.m_PersonaBE.IESVENDEDOR.ToString();
                //}
                //else
                //{
                //    this.ESVENDEDORTextBox.Text = "";
                //}

               // this.ESVENDEDORTextBox.Checked = (proveedorBE.m_PersonaBE.IESVENDEDOR == "S") ? true : false;

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IESVENDEDORGENERAL"])
                //{
                //    this.ESVENDEDORGENERALTextBox.Text = proveedorBE.m_PersonaBE.IESVENDEDORGENERAL.ToString();
                //}
                //else
                //{
                //    this.ESVENDEDORGENERALTextBox.Text = "";
                //}
                //this.ESVENDEDORGENERALTextBox.Checked = (proveedorBE.m_PersonaBE.IESVENDEDORGENERAL == "S") ? true : false;

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IESVENDEDOR"])
                //{
                //    this.ESVENDEDORTextBox.Text = proveedorBE.m_PersonaBE.IESVENDEDOR.ToString();
                //}
                //else
                //{
                //    this.ESVENDEDORTextBox.Text = "";
                //}
                //this.ESVENDEDORTextBox.Checked = (proveedorBE.m_PersonaBE.IESVENDEDOR == "S") ? true : false;

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IESUSUARIO"])
                //{
                //    this.ESUSUARIOTextBox.Text = proveedorBE.m_PersonaBE.IESUSUARIO.ToString();
                //}
                //else
                //{
                //    this.ESUSUARIOTextBox.Text = "";
                //}
                //this.ESUSUARIOTextBox.Checked = (proveedorBE.m_PersonaBE.IESUSUARIO == "S") ? true : false;

                if (!(bool)proveedorBE.m_PersonaBE.isnull["ILISTAPRECIOID"])
                {
                    this.LISTAPRECIOIDTextBox.Text = proveedorBE.m_PersonaBE.ILISTAPRECIOID.ToString();
                }
                else
                {
                    this.LISTAPRECIOIDTextBox.Text = "";
                }

                //if (!(bool)proveedorBE.m_PersonaBE.isnull["IRESET_PASS"])
                //{
                //    this.RESET_PASSTextBox.Text = proveedorBE.m_PersonaBE.IRESET_PASS.ToString();
                //}
                //else
                //{
                //    this.RESET_PASSTextBox.Text = "";
                //}

                if (!(bool)proveedorBE.m_PersonaBE.isnull["IVIGENCIA"])
                {
                    try
                    {
                        this.VIGENCIATextBox.Value = proveedorBE.m_PersonaBE.IVIGENCIA;
                    }
                    catch
                    {
                    }
                }
                

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


        private CVENDEDORBE ObtenerDatosCapturados()
        {
            CVENDEDORBE proveedorBE = new CVENDEDORBE();



            //if (this.ACTIVOTextBox.Text != "")
            //{
                proveedorBE.m_PersonaBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N"; 
            //}


            //if (this.CREADOTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.ICREADO = this.CREADOTextBox.Text.ToString();
            //}


            //if (this.MODIFICADOTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IMODIFICADO = this.MODIFICADOTextBox.Text.ToString();
            //}


            if (this.CLAVETextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            if (this.DESCRIPCIONTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }


            if (this.MEMOTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IMEMO = this.MEMOTextBox.Text.ToString();
            }


            if (this.NOMBRESTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.INOMBRES = this.NOMBRESTextBox.Text.ToString();
            }


            if (this.APELLIDOSTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IAPELLIDOS = this.APELLIDOSTextBox.Text.ToString();
            }


            if (this.RAZONSOCIALTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IRAZONSOCIAL = this.RAZONSOCIALTextBox.Text.ToString();
            }


            if (this.RFCTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IRFC = this.RFCTextBox.Text.ToString();
            }


            if (this.CONTACTO1TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICONTACTO1 = this.CONTACTO1TextBox.Text.ToString();
            }


            if (this.CONTACTO2TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICONTACTO2 = this.CONTACTO2TextBox.Text.ToString();
            }


            //if (this.USERNAMETextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IUSERNAME = this.USERNAMETextBox.Text.ToString();
            //}


            //if (this.CLAVEACCESOTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.ICLAVEACCESO = this.CLAVEACCESOTextBox.Text.ToString();
            //}


            if (this.DOMICILIOTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IDOMICILIO = this.DOMICILIOTextBox.Text.ToString();
            }


            if (this.COLONIATextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICOLONIA = this.COLONIATextBox.Text.ToString();
            }


            if (this.CIUDADTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICIUDAD = this.CIUDADTextBox.Text.ToString();
            }


            if (this.MUNICIPIOTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IMUNICIPIO = this.MUNICIPIOTextBox.Text.ToString();
            }


            if (this.ESTADOTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IESTADO = this.ESTADOTextBox.Text.ToString();
            }


            if (this.PAISComboBoxFb.SelectedIndex >= 0)
            {
                proveedorBE.m_PersonaBE.ISAT_CLAVE_PAIS = this.PAISComboBoxFb.SelectedValue.ToString();
                proveedorBE.m_PersonaBE.IPAIS = this.PAISComboBoxFb.SelectedDataDisplaying.ToString();
            }

            if (this.CODIGOPOSTALTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICODIGOPOSTAL = this.CODIGOPOSTALTextBox.Text.ToString();
            }


            if (this.TELEFONO1TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ITELEFONO1 = this.TELEFONO1TextBox.Text.ToString();
            }


            if (this.TELEFONO2TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ITELEFONO2 = this.TELEFONO2TextBox.Text.ToString();
            }


            if (this.TELEFONO3TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ITELEFONO3 = this.TELEFONO3TextBox.Text.ToString();
            }


            if (this.CELULARTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ICELULAR = this.CELULARTextBox.Text.ToString();
            }


            if (this.NEXTELTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.INEXTEL = this.NEXTELTextBox.Text.ToString();
            }


            if (this.EMAIL1TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IEMAIL1 = this.EMAIL1TextBox.Text.ToString();
            }


            if (this.EMAIL2TextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.IEMAIL2 = this.EMAIL2TextBox.Text.ToString();
            }


            //if (this.ESVENDEDORTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IESVENDEDOR = (this.ESVENDEDORTextBox.Checked) ? "S" : "N"; 
                
            //}


            //if (this.ESVENDEDORGENERALTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IESVENDEDORGENERAL = (this.ESVENDEDORGENERALTextBox.Checked) ? "S" : "N";
            //}


            //if (this.ESVENDEDORTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IESVENDEDOR = (this.ESVENDEDORTextBox.Checked) ? "S" : "N";
            //}


            //if (this.ESUSUARIOTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IESUSUARIO = (this.ESUSUARIOTextBox.Checked) ? "S" : "N";
            //}


            //if (this.IDTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IID = Int64.Parse(this.IDTextBox.Text.ToString());
            //}


            //if (this.CREADOPOR_USERIDTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.ICREADOPOR_USERID = Int64.Parse(this.CREADOPOR_USERIDTextBox.Text.ToString());
            //}


            //if (this.MODIFICADOPOR_USERIDTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IMODIFICADOPOR_USERID = Int64.Parse(this.MODIFICADOPOR_USERIDTextBox.Text.ToString());
            //}


            //if (this.TIPOPERSONAIDTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.ITIPOPERSONAID = Int64.Parse(this.TIPOPERSONAIDTextBox.Text.ToString());
            //}


            if (this.SALUDOIDTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ISALUDOID = (long)this.SALUDOIDTextBox.SelectedDataValue;
            }


            //if (this.EMPRESAIDTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IEMPRESAID = Int64.Parse(this.EMPRESAIDTextBox.Text.ToString());
            //}


            //if (this.VENDEDORIDTextBox.Text != "")
            //{
            //   // proveedorBE.m_PersonaBE.IVENDEDORID = (long)this.VENDEDORIDTextBox.SelectedDataValue;
            //    proveedorBE.m_PersonaBE.IVENDEDORID = Int64.Parse(this.VENDEDORIDTextBox.Text.ToString());
            //}


            if (this.LISTAPRECIOIDTextBox.Text != "")
            {
                proveedorBE.m_PersonaBE.ILISTAPRECIOID = Int64.Parse(this.LISTAPRECIOIDTextBox.Text.ToString());
            }


            //if (this.RESET_PASSTextBox.Text != "")
            //{
            //    proveedorBE.m_PersonaBE.IRESET_PASS = Int16.Parse(this.RESET_PASSTextBox.Text.ToString());
            //}


            proveedorBE.m_PersonaBE.IVIGENCIA = this.VIGENCIATextBox.Value;


            return proveedorBE;

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
                    CVENDEDORD proveedorD = new CVENDEDORD();

                    if (opc == "Agregar")
                    {
                        CVENDEDORBE proveedorBE = new CVENDEDORBE();
                        proveedorBE = ObtenerDatosCapturados();

                        proveedorBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_VENDEDOR;
                        //proveedorBE.m_PersonaBE.IES = "S";

                        proveedorD.AgregarPERSONA(proveedorBE.m_PersonaBE, null);

                        if (proveedorD.IComentario == "" || proveedorD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + proveedorD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {
                        CVENDEDORBE proveedorBEAnt = new CVENDEDORBE();
                        CVENDEDORBE proveedorBE = new CVENDEDORBE();
                        proveedorBE = ObtenerDatosCapturados();
                        proveedorBEAnt.m_PersonaBE.IID = this.ID;

                        proveedorD.CambiarVENDEDORD(proveedorBE.m_PersonaBE, proveedorBEAnt.m_PersonaBE, null);
                        if (proveedorD.IComentario == "" || proveedorD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + proveedorD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CVENDEDORBE proveedorBEAnt = new CVENDEDORBE();
                            proveedorBEAnt.m_PersonaBE.IID = this.ID;

                            proveedorD.BorrarPERSONA(proveedorBEAnt.m_PersonaBE, null);
                            if (proveedorD.IComentario == "" || proveedorD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + proveedorD.IComentario.Replace("%", "\n"));
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarCodigoPostal(CODIGOPOSTALTextBox.Text) && CODIGOPOSTALTextBox.Text != "")
            {
                MessageBox.Show("El Código Postal Ingresado no es valido!");
                CODIGOPOSTALTextBox.Focus();
                return;
            }

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
            this.ID = -1;
            this.CLAVE = "";
        }

        private void Limpiar()
        {
            Limpiar(false);
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


            this.DESCRIPCIONTextBox.Text = "";


            this.MEMOTextBox.Text = "";


            this.SALUDOIDTextBox.SelectedIndex = -1;


            this.NOMBRESTextBox.Text = "";


            this.APELLIDOSTextBox.Text = "";


            this.RAZONSOCIALTextBox.Text = "";


            this.RFCTextBox.Text = "";


            this.CONTACTO1TextBox.Text = "";


            this.CONTACTO2TextBox.Text = "";


            //this.USERNAMETextBox.Text = "";


            //this.CLAVEACCESOTextBox.Text = "";


            this.DOMICILIOTextBox.Text = "";


            this.COLONIATextBox.Text = "";


            this.CIUDADTextBox.Text = "";


            this.MUNICIPIOTextBox.Text = "";


            this.ESTADOTextBox.Text = "";


            this.CODIGOPOSTALTextBox.Text = "";


            this.TELEFONO1TextBox.Text = "";


            this.TELEFONO2TextBox.Text = "";


            this.TELEFONO3TextBox.Text = "";


            this.CELULARTextBox.Text = "";


            this.NEXTELTextBox.Text = "";


            this.EMAIL1TextBox.Text = "";


            this.EMAIL2TextBox.Text = "";


            //this.EMPRESAIDTextBox.Text = "";


            //this.VENDEDORIDTextBox.Text = "";


            //this.ESVENDEDORTextBox.Checked = false;


            //this.ESVENDEDORGENERALTextBox.Checked = false;


            //this.ESVENDEDORTextBox.Checked = false;


            //this.ESUSUARIOTextBox.Checked = false;


            this.LISTAPRECIOIDTextBox.Text = "";


            this.VIGENCIATextBox.Text = "";


            //this.RESET_PASSTextBox.Text = "";




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

        private void btnQuotas_Click(object sender, EventArgs e)
        {

            WFQuotaMgmt frm = new WFQuotaMgmt(false,this.ID);
            frm.ShowDialog();
            frm.Dispose();
            GC.SuppressFinalize(frm);
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
    }
}
