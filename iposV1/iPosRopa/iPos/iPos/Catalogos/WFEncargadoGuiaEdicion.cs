
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
    public partial class WFEncargadoGuiaEdicion : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;

        public string m_localidadComboQuery = @"SELECT  LOC.ID clave, LOC.DESCRIPCION nombre ,LOC.DESCRIPCION descripcion FROM sat_localidad LOC LEFT JOIN ESTADO ON LOC.clave_estado = ESTADO.acronimo WHERE ESTADO.clave = @CLAVEESTADO ORDER BY LOC.DESCRIPCION";

        public string m_municipioComboQuery = @"SELECT  MUN.ID clave, MUN.DESCRIPCION nombre ,MUN.DESCRIPCION descripcion FROM sat_municipio MUN LEFT JOIN ESTADO ON MUN.clave_estado = ESTADO.acronimo WHERE ESTADO.clave = @CLAVEESTADO ORDER BY MUN.DESCRIPCION";

        public string m_coloniaComboQuery = @"SELECT  c.ID clave, C.nombre nombre ,C.nombre descripcion FROM sat_colonia C WHERE c.codigopostal = @CODIGOPOSTAL ORDER BY C.nombre";

        bool m_terminoLoad = false;


        public delegate void AccionHandler(object source, Hashtable evtArgs);
        //public event AccionHandler AccionUsuario;

        public WFEncargadoGuiaEdicion()
        {
            InitializeComponent();
            this.SALUDOIDTextBox.llenarDatos();
        }


        public void ReCargar(string popc,string pCLAVE)
        {

            m_terminoLoad = false;

            opc = popc;
            CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);
            ESTADOTextBox.llenarDatos();
            LlenarDatosCombos();

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

            m_terminoLoad = true;
        }



        private void LlenarDatosCombos()
        {

            this.PAISComboBoxFb.llenarDatos();
            this.PAISComboBoxFb.SelectedValue = "MEX";

            this.ESTADOTextBox.llenarDatos();

            SAT_FIGURATRANSPORTEIDTextBox.llenarDatos();
            SAT_FIGURATRANSPORTEIDTextBox.SelectedIndex = -1;

            SAT_PARTETRANSPORTEIDTextBox.llenarDatos();
            SAT_PARTETRANSPORTEIDTextBox.SelectedIndex = -1;
        }

        private void PERSONAEdit_Reg_Load(object sender, EventArgs e)
        {
        }


        private bool LlenarDatosDeBase()
        {
            //string strBuffer = "";
            try
            {
                CENCARGADOGUIAD proveedorD = new CENCARGADOGUIAD();
                CENCARGADOGUIABE encargadoGuiaBE = new CENCARGADOGUIABE();


                CPERSONAFIGURAD figuraD = new CPERSONAFIGURAD();

                encargadoGuiaBE.m_PersonaBE.ICLAVE = CLAVE;
                encargadoGuiaBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_ENCARGADOGUIA;
                encargadoGuiaBE.m_PersonaBE = proveedorD.seleccionarPERSONAxCLAVE(encargadoGuiaBE.m_PersonaBE, null);

                if (encargadoGuiaBE.m_PersonaBE == null)
                    return false;

                this.ID = encargadoGuiaBE.m_PersonaBE.IID;


                encargadoGuiaBE.m_FigureBE.IPERSONAID = encargadoGuiaBE.m_PersonaBE.IID;
                encargadoGuiaBE.m_FigureBE = figuraD.seleccionarPERSONAFIGURAxPERSONA(encargadoGuiaBE.m_FigureBE, null);


                this.ACTIVOTextBox.Checked = (encargadoGuiaBE.m_PersonaBE.IACTIVO == "S") ? true : false;

              

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ICLAVE"])
                {
                    this.CLAVETextBox.Text = encargadoGuiaBE.m_PersonaBE.ICLAVE.ToString();
                }
                else
                {
                    this.CLAVETextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["INOMBRE"])
                {
                    this.NOMBRETextBox.Text = encargadoGuiaBE.m_PersonaBE.INOMBRE.ToString();
                }
                else
                {
                    this.NOMBRETextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IDESCRIPCION"])
                {
                    this.DESCRIPCIONTextBox.Text = encargadoGuiaBE.m_PersonaBE.IDESCRIPCION.ToString();
                }
                else
                {
                    this.DESCRIPCIONTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IMEMO"])
                {
                    this.MEMOTextBox.Text = encargadoGuiaBE.m_PersonaBE.IMEMO.ToString();
                }
                else
                {
                    this.MEMOTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ISALUDOID"])
                {

                    this.SALUDOIDTextBox.SelectedDataValue = encargadoGuiaBE.m_PersonaBE.ISALUDOID;
                }
                else
                {
                    this.SALUDOIDTextBox.SelectedIndex = -1;
                    
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["INOMBRES"])
                {
                    this.NOMBRESTextBox.Text = encargadoGuiaBE.m_PersonaBE.INOMBRES.ToString();
                }
                else
                {
                    this.NOMBRESTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IAPELLIDOS"])
                {
                    this.APELLIDOSTextBox.Text = encargadoGuiaBE.m_PersonaBE.IAPELLIDOS.ToString();
                }
                else
                {
                    this.APELLIDOSTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IRAZONSOCIAL"])
                {
                    this.RAZONSOCIALTextBox.Text = encargadoGuiaBE.m_PersonaBE.IRAZONSOCIAL.ToString();
                }
                else
                {
                    this.RAZONSOCIALTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IRFC"])
                {
                    this.RFCTextBox.Text = encargadoGuiaBE.m_PersonaBE.IRFC.ToString();
                }
                else
                {
                    this.RFCTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ICONTACTO1"])
                {
                    this.CONTACTO1TextBox.Text = encargadoGuiaBE.m_PersonaBE.ICONTACTO1.ToString();
                }
                else
                {
                    this.CONTACTO1TextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ICONTACTO2"])
                {
                    this.CONTACTO2TextBox.Text = encargadoGuiaBE.m_PersonaBE.ICONTACTO2.ToString();
                }
                else
                {
                    this.CONTACTO2TextBox.Text = "";
                }

              
                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IDOMICILIO"])
                {
                    this.DOMICILIOTextBox.Text = encargadoGuiaBE.m_PersonaBE.IDOMICILIO.ToString();
                }
                else
                {
                    this.DOMICILIOTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["INUMEROEXTERIOR"])
                {
                    this.NUMEROEXTERIORTextBox.Text = encargadoGuiaBE.m_PersonaBE.INUMEROEXTERIOR.ToString();
                }
                else
                {
                    this.NUMEROEXTERIORTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["INUMEROINTERIOR"])
                {
                    this.NUMEROINTERIORTextBox.Text = encargadoGuiaBE.m_PersonaBE.INUMEROINTERIOR.ToString();
                }
                else
                {
                    this.NUMEROINTERIORTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IREFERENCIADOM"])
                {
                    this.REFERENCIADOMTextBox.Text = encargadoGuiaBE.m_PersonaBE.IREFERENCIADOM.ToString();
                }
                else
                {
                    this.REFERENCIADOMTextBox.Text = "";
                }
                


                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IESTADO"])
                {
                    this.ESTADOTextBox.SelectedDataDisplaying = encargadoGuiaBE.m_PersonaBE.IESTADO.ToString();
                }
                else
                {
                    this.ESTADOTextBox.Text = "";
                }

                LlenarCamposRelacionadosAEstado();



                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ISAT_LOCALIDADID"])
                {
                    this.LocalidadComboBox.SelectedDataValue = encargadoGuiaBE.m_PersonaBE.ISAT_LOCALIDADID;
                }
                else
                {
                    this.LocalidadComboBox.SelectedIndex = -1;
                }


                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ISAT_MUNICIPIOID"])
                {
                    this.MunicipioComboBox.SelectedDataValue = encargadoGuiaBE.m_PersonaBE.ISAT_MUNICIPIOID;
                }
                else
                {
                    this.MunicipioComboBox.SelectedIndex = -1;
                }



                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ISAT_CLAVE_PAIS"])
                {
                    this.PAISComboBoxFb.SelectedValue = encargadoGuiaBE.m_PersonaBE.ISAT_CLAVE_PAIS.ToString();
                }


                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ICODIGOPOSTAL"])
                {
                    this.CODIGOPOSTALTextBox.Text = encargadoGuiaBE.m_PersonaBE.ICODIGOPOSTAL.ToString();
                }
                else
                {
                    this.CODIGOPOSTALTextBox.Text = "";
                }
                LlenarCamposRelacionadosACodigoPostal();


                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ISAT_COLONIAID"])
                {
                    this.ColoniaComboBox.SelectedDataValue = encargadoGuiaBE.m_PersonaBE.ISAT_COLONIAID;
                }
                else
                {
                    this.ColoniaComboBox.SelectedIndex = -1;
                }
                

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ITELEFONO1"])
                {
                    this.TELEFONO1TextBox.Text = encargadoGuiaBE.m_PersonaBE.ITELEFONO1.ToString();
                }
                else
                {
                    this.TELEFONO1TextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ITELEFONO2"])
                {
                    this.TELEFONO2TextBox.Text = encargadoGuiaBE.m_PersonaBE.ITELEFONO2.ToString();
                }
                else
                {
                    this.TELEFONO2TextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ITELEFONO3"])
                {
                    this.TELEFONO3TextBox.Text = encargadoGuiaBE.m_PersonaBE.ITELEFONO3.ToString();
                }
                else
                {
                    this.TELEFONO3TextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ICELULAR"])
                {
                    this.CELULARTextBox.Text = encargadoGuiaBE.m_PersonaBE.ICELULAR.ToString();
                }
                else
                {
                    this.CELULARTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["INEXTEL"])
                {
                    this.NEXTELTextBox.Text = encargadoGuiaBE.m_PersonaBE.INEXTEL.ToString();
                }
                else
                {
                    this.NEXTELTextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IEMAIL1"])
                {
                    this.EMAIL1TextBox.Text = encargadoGuiaBE.m_PersonaBE.IEMAIL1.ToString();
                }
                else
                {
                    this.EMAIL1TextBox.Text = "";
                }

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IEMAIL2"])
                {
                    this.EMAIL2TextBox.Text = encargadoGuiaBE.m_PersonaBE.IEMAIL2.ToString();
                }
                else
                {
                    this.EMAIL2TextBox.Text = "";
                }

               

                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["ILISTAPRECIOID"])
                {
                    this.LISTAPRECIOIDTextBox.Text = encargadoGuiaBE.m_PersonaBE.ILISTAPRECIOID.ToString();
                }
                else
                {
                    this.LISTAPRECIOIDTextBox.Text = "";
                }


                if (!(bool)encargadoGuiaBE.m_PersonaBE.isnull["IVIGENCIA"])
                {
                    try
                    {
                        this.VIGENCIATextBox.Value = encargadoGuiaBE.m_PersonaBE.IVIGENCIA;
                    }
                    catch
                    {
                    }
                }


                if (encargadoGuiaBE.m_FigureBE != null)
                {


                    if (!(bool)encargadoGuiaBE.m_FigureBE.isnull["INUMLICENCIA"])
                    {
                        this.NUMLICENCIATextBox.Text = encargadoGuiaBE.m_FigureBE.INUMLICENCIA.ToString();
                    }
                    else
                    {
                        this.NUMLICENCIATextBox.Text = "";
                    }


                    if (!(bool)encargadoGuiaBE.m_FigureBE.isnull["INUMREGIDTRIB"])
                    {
                        this.NUMREGIDTRIBTextBox.Text = encargadoGuiaBE.m_FigureBE.INUMREGIDTRIB.ToString();
                    }
                    else
                    {
                        this.NUMREGIDTRIBTextBox.Text = "";
                    }


                    if (!(bool)encargadoGuiaBE.m_FigureBE.isnull["IRESIDENCIAFISCAL"])
                    {
                        this.RESIDENCIAFISCALTextBox.Text = encargadoGuiaBE.m_FigureBE.IRESIDENCIAFISCAL.ToString();
                    }
                    else
                    {
                        this.RESIDENCIAFISCALTextBox.Text = "";
                    }


                    if (!(bool)encargadoGuiaBE.m_FigureBE.isnull["ISAT_FIGURATRANSPORTEID"])
                    {
                        this.SAT_FIGURATRANSPORTEIDTextBox.SelectedValue = encargadoGuiaBE.m_FigureBE.ISAT_FIGURATRANSPORTEID;
                    }


                    if (!(bool)encargadoGuiaBE.m_FigureBE.isnull["ISAT_PARTETRANSPORTEID"])
                    {
                        this.SAT_PARTETRANSPORTEIDTextBox.SelectedValue = encargadoGuiaBE.m_FigureBE.ISAT_PARTETRANSPORTEID;
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


        private CENCARGADOGUIABE ObtenerDatosCapturados()
        {
            CENCARGADOGUIABE encargadoGuiaBE = new CENCARGADOGUIABE();



            //if (this.ACTIVOTextBox.Text != "")
            //{
                encargadoGuiaBE.m_PersonaBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N"; 
            //}



            if (this.CLAVETextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            if (this.DESCRIPCIONTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }


            if (this.MEMOTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IMEMO = this.MEMOTextBox.Text.ToString();
            }


            if (this.NOMBRESTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.INOMBRES = this.NOMBRESTextBox.Text.ToString();
            }


            if (this.APELLIDOSTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IAPELLIDOS = this.APELLIDOSTextBox.Text.ToString();
            }


            if (this.RAZONSOCIALTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IRAZONSOCIAL = this.RAZONSOCIALTextBox.Text.ToString();
            }


            if (this.RFCTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IRFC = this.RFCTextBox.Text.ToString();
            }


            if (this.CONTACTO1TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ICONTACTO1 = this.CONTACTO1TextBox.Text.ToString();
            }


            if (this.CONTACTO2TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ICONTACTO2 = this.CONTACTO2TextBox.Text.ToString();
            }




            if (this.DOMICILIOTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IDOMICILIO = this.DOMICILIOTextBox.Text.ToString();
            }

            if (this.NUMEROEXTERIORTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.INUMEROEXTERIOR = this.NUMEROEXTERIORTextBox.Text.ToString();
            }

            if (this.NUMEROINTERIORTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.INUMEROINTERIOR = this.NUMEROINTERIORTextBox.Text.ToString();
            }


            if (this.REFERENCIADOMTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IREFERENCIADOM = this.REFERENCIADOMTextBox.Text.ToString();
            }


            if (this.ESTADOTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IESTADO = this.ESTADOTextBox.Text.ToString();
            }
            if (this.LocalidadComboBox.SelectedDataValue != null)
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_LOCALIDADID = long.Parse(this.LocalidadComboBox.SelectedDataValue.ToString());
                encargadoGuiaBE.m_PersonaBE.ILOCALIDAD = this.LocalidadComboBox.SelectedDataDisplaying.ToString();
            }
            else
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_LOCALIDADID = 0;
                encargadoGuiaBE.m_PersonaBE.ILOCALIDAD = "";
            }


            if (this.MunicipioComboBox.SelectedDataValue != null)
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_MUNICIPIOID = long.Parse(this.MunicipioComboBox.SelectedDataValue.ToString());
                encargadoGuiaBE.m_PersonaBE.ICIUDAD = this.MunicipioComboBox.SelectedDataDisplaying.ToString();
            }
            else
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_MUNICIPIOID = 0;
                encargadoGuiaBE.m_PersonaBE.ICIUDAD = "";
            }


            if (this.PAISComboBoxFb.SelectedIndex >= 0)
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_CLAVE_PAIS = this.PAISComboBoxFb.SelectedValue.ToString();
                encargadoGuiaBE.m_PersonaBE.IPAIS = this.PAISComboBoxFb.SelectedDataDisplaying.ToString();
            }

            if (this.CODIGOPOSTALTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ICODIGOPOSTAL = this.CODIGOPOSTALTextBox.Text.ToString();
            }

            if (this.ColoniaComboBox.SelectedDataValue != null)
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_COLONIAID = long.Parse(this.ColoniaComboBox.SelectedDataValue.ToString());
                encargadoGuiaBE.m_PersonaBE.ICOLONIA = this.ColoniaComboBox.SelectedDataDisplaying.ToString();
            }
            else
            {
                encargadoGuiaBE.m_PersonaBE.ISAT_COLONIAID = 0;
                encargadoGuiaBE.m_PersonaBE.ICOLONIA = "";
            }

            





            if (this.TELEFONO1TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ITELEFONO1 = this.TELEFONO1TextBox.Text.ToString();
            }


            if (this.TELEFONO2TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ITELEFONO2 = this.TELEFONO2TextBox.Text.ToString();
            }


            if (this.TELEFONO3TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ITELEFONO3 = this.TELEFONO3TextBox.Text.ToString();
            }


            if (this.CELULARTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ICELULAR = this.CELULARTextBox.Text.ToString();
            }


            if (this.NEXTELTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.INEXTEL = this.NEXTELTextBox.Text.ToString();
            }


            if (this.EMAIL1TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IEMAIL1 = this.EMAIL1TextBox.Text.ToString();
            }


            if (this.EMAIL2TextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.IEMAIL2 = this.EMAIL2TextBox.Text.ToString();
            }


            if (this.SALUDOIDTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ISALUDOID = (long)this.SALUDOIDTextBox.SelectedDataValue;
            }


            if (this.LISTAPRECIOIDTextBox.Text != "")
            {
                encargadoGuiaBE.m_PersonaBE.ILISTAPRECIOID = Int64.Parse(this.LISTAPRECIOIDTextBox.Text.ToString());
            }




            encargadoGuiaBE.m_PersonaBE.IVIGENCIA = this.VIGENCIATextBox.Value;
            

            if (this.RESIDENCIAFISCALTextBox.Text != "")
            {
                encargadoGuiaBE.m_FigureBE.IRESIDENCIAFISCAL = this.RESIDENCIAFISCALTextBox.Text.ToString();
            }

            if (this.NUMREGIDTRIBTextBox.Text != "")
            {
                encargadoGuiaBE.m_FigureBE.INUMREGIDTRIB = this.NUMREGIDTRIBTextBox.Text.ToString();
            }

            if (this.NUMLICENCIATextBox.Text != "")
            {
                encargadoGuiaBE.m_FigureBE.INUMLICENCIA = this.NUMLICENCIATextBox.Text.ToString();
            }


            if (this.SAT_FIGURATRANSPORTEIDTextBox.SelectedIndex >= 0)
            {
                encargadoGuiaBE.m_FigureBE.ISAT_FIGURATRANSPORTEID = long.Parse(this.SAT_FIGURATRANSPORTEIDTextBox.SelectedValue.ToString());
            }

            if (this.SAT_PARTETRANSPORTEIDTextBox.SelectedIndex >= 0)
            {
                encargadoGuiaBE.m_FigureBE.ISAT_PARTETRANSPORTEID = long.Parse(this.SAT_PARTETRANSPORTEIDTextBox.SelectedValue.ToString());
            }

            return encargadoGuiaBE;

        }


        public void SaveChangesFigura(CENCARGADOGUIABE encargadoGuiaBE)
        {

            CPERSONAFIGURAD personaFiguraD = new CPERSONAFIGURAD();
            CPERSONAFIGURABE personaFiguraBEAnt = new CPERSONAFIGURABE();
            CPERSONAD personaD = new CPERSONAD();

            encargadoGuiaBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_ENCARGADOGUIA;

            CPERSONABE personaBE = personaD.seleccionarPERSONAxCLAVEyTIPO(encargadoGuiaBE.m_PersonaBE, null);
            personaFiguraBEAnt.IPERSONAID = personaBE.IID;

            personaFiguraBEAnt = personaFiguraD.seleccionarPERSONAFIGURAxPERSONA(personaFiguraBEAnt, null);

            encargadoGuiaBE.m_FigureBE.IPERSONAID = personaBE.IID;
            encargadoGuiaBE.m_FigureBE.IACTIVO = "S";

            if (personaFiguraBEAnt == null)
            {
                personaFiguraD.AgregarPERSONAFIGURAD(encargadoGuiaBE.m_FigureBE, null);
            }
            else
            {
                encargadoGuiaBE.m_FigureBE.IID = personaFiguraBEAnt.IID;
                personaFiguraD.CambiarPERSONAFIGURAD(encargadoGuiaBE.m_FigureBE, encargadoGuiaBE.m_FigureBE, null);
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
                    CENCARGADOGUIAD proveedorD = new CENCARGADOGUIAD();

                    if (opc == "Agregar")
                    {
                        CENCARGADOGUIABE encargadoGuiaBE = new CENCARGADOGUIABE();
                        encargadoGuiaBE = ObtenerDatosCapturados();

                        encargadoGuiaBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_ENCARGADOGUIA;
                        //encargadoGuiaBE.m_PersonaBE.IES = "S";

                        proveedorD.AgregarPERSONA(encargadoGuiaBE.m_PersonaBE, null);

                        if (proveedorD.IComentario == "" || proveedorD.IComentario == null)
                        {
                            SaveChangesFigura(encargadoGuiaBE);


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
                        CENCARGADOGUIABE encargadoGuiaBEAnt = new CENCARGADOGUIABE();
                        CENCARGADOGUIABE encargadoGuiaBE = new CENCARGADOGUIABE();
                        encargadoGuiaBE = ObtenerDatosCapturados();
                        encargadoGuiaBEAnt.m_PersonaBE.IID = this.ID;

                        proveedorD.CambiarENCARGADOGUIAD(encargadoGuiaBE.m_PersonaBE, encargadoGuiaBEAnt.m_PersonaBE, null);
                        if (proveedorD.IComentario == "" || proveedorD.IComentario == null)
                        {
                            SaveChangesFigura(encargadoGuiaBE);

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
                            CENCARGADOGUIABE encargadoGuiaBEAnt = new CENCARGADOGUIABE();
                            encargadoGuiaBEAnt.m_PersonaBE.IID = this.ID;

                            proveedorD.BorrarPERSONA(encargadoGuiaBEAnt.m_PersonaBE, null);
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

            this.NUMEROINTERIORTextBox.Text = "";

            this.NUMEROEXTERIORTextBox.Text = "";

            this.REFERENCIADOMTextBox.Text = "";

            this.LocalidadComboBox.SelectedIndex = -1;

            this.MunicipioComboBox.SelectedIndex = -1;

            this.ColoniaComboBox.SelectedIndex = -1;


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



        private void LlenarCamposRelacionadosAEstado()
        {

            var acronimoEstado = ESTADOTextBox.SelectedDataDisplaying != null ? "'" + ESTADOTextBox.SelectedDataDisplaying.ToString() + "'" : "''";

            this.LocalidadComboBox.Query = this.m_localidadComboQuery.Replace("@CLAVEESTADO", acronimoEstado);
            this.LocalidadComboBox.llenarDatos();
            this.LocalidadComboBox.SelectedIndex = -1;


            this.MunicipioComboBox.Query = this.m_municipioComboQuery.Replace("@CLAVEESTADO", acronimoEstado);
            this.MunicipioComboBox.llenarDatos();
            this.MunicipioComboBox.SelectedIndex = -1;

        }


        private void LlenarCamposRelacionadosACodigoPostal()
        {

            var codigoPostal = this.CODIGOPOSTALTextBox.Text != null ? "'" + this.CODIGOPOSTALTextBox.Text + "'" : "''";

            this.ColoniaComboBox.Query = this.m_coloniaComboQuery.Replace("@CODIGOPOSTAL", codigoPostal);
            this.ColoniaComboBox.llenarDatos();
            this.ColoniaComboBox.SelectedIndex = -1;


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
    }
}
