
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
    public partial class WFEncargadoCorteEdicion : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;


        public delegate void AccionHandler(object source, Hashtable evtArgs);
        //public event AccionHandler AccionUsuario;

        public WFEncargadoCorteEdicion()
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
                CENCARGADOCORTED proveedorD = new CENCARGADOCORTED();
                CENCARGADOCORTEBE encargadoCorteBE = new CENCARGADOCORTEBE();

                encargadoCorteBE.m_PersonaBE.ICLAVE = CLAVE;
                encargadoCorteBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_ENCARGADOCORTE;
                encargadoCorteBE.m_PersonaBE = proveedorD.seleccionarPERSONAxCLAVE(encargadoCorteBE.m_PersonaBE, null);

                if (encargadoCorteBE.m_PersonaBE == null)
                    return false;

                this.ID = encargadoCorteBE.m_PersonaBE.IID;




                this.ACTIVOTextBox.Checked = (encargadoCorteBE.m_PersonaBE.IACTIVO == "S") ? true : false;

              

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICLAVE"])
                {
                    this.CLAVETextBox.Text = encargadoCorteBE.m_PersonaBE.ICLAVE.ToString();
                }
                else
                {
                    this.CLAVETextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["INOMBRE"])
                {
                    this.NOMBRETextBox.Text = encargadoCorteBE.m_PersonaBE.INOMBRE.ToString();
                }
                else
                {
                    this.NOMBRETextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IDESCRIPCION"])
                {
                    this.DESCRIPCIONTextBox.Text = encargadoCorteBE.m_PersonaBE.IDESCRIPCION.ToString();
                }
                else
                {
                    this.DESCRIPCIONTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IMEMO"])
                {
                    this.MEMOTextBox.Text = encargadoCorteBE.m_PersonaBE.IMEMO.ToString();
                }
                else
                {
                    this.MEMOTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ISALUDOID"])
                {

                    this.SALUDOIDTextBox.SelectedDataValue = encargadoCorteBE.m_PersonaBE.ISALUDOID;
                }
                else
                {
                    this.SALUDOIDTextBox.SelectedIndex = -1;
                    
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["INOMBRES"])
                {
                    this.NOMBRESTextBox.Text = encargadoCorteBE.m_PersonaBE.INOMBRES.ToString();
                }
                else
                {
                    this.NOMBRESTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IAPELLIDOS"])
                {
                    this.APELLIDOSTextBox.Text = encargadoCorteBE.m_PersonaBE.IAPELLIDOS.ToString();
                }
                else
                {
                    this.APELLIDOSTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IRAZONSOCIAL"])
                {
                    this.RAZONSOCIALTextBox.Text = encargadoCorteBE.m_PersonaBE.IRAZONSOCIAL.ToString();
                }
                else
                {
                    this.RAZONSOCIALTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IRFC"])
                {
                    this.RFCTextBox.Text = encargadoCorteBE.m_PersonaBE.IRFC.ToString();
                }
                else
                {
                    this.RFCTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICONTACTO1"])
                {
                    this.CONTACTO1TextBox.Text = encargadoCorteBE.m_PersonaBE.ICONTACTO1.ToString();
                }
                else
                {
                    this.CONTACTO1TextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICONTACTO2"])
                {
                    this.CONTACTO2TextBox.Text = encargadoCorteBE.m_PersonaBE.ICONTACTO2.ToString();
                }
                else
                {
                    this.CONTACTO2TextBox.Text = "";
                }

              
                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IDOMICILIO"])
                {
                    this.DOMICILIOTextBox.Text = encargadoCorteBE.m_PersonaBE.IDOMICILIO.ToString();
                }
                else
                {
                    this.DOMICILIOTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICOLONIA"])
                {
                    this.COLONIATextBox.Text = encargadoCorteBE.m_PersonaBE.ICOLONIA.ToString();
                }
                else
                {
                    this.COLONIATextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICIUDAD"])
                {
                    this.CIUDADTextBox.Text = encargadoCorteBE.m_PersonaBE.ICIUDAD.ToString();
                }
                else
                {
                    this.CIUDADTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IMUNICIPIO"])
                {
                    this.MUNICIPIOTextBox.Text = encargadoCorteBE.m_PersonaBE.IMUNICIPIO.ToString();
                }
                else
                {
                    this.MUNICIPIOTextBox.Text = "";
                }


                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IESTADO"])
                {
                    this.ESTADOTextBox.SelectedDataDisplaying = encargadoCorteBE.m_PersonaBE.IESTADO.ToString();
                }
                else
                {
                    this.ESTADOTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ISAT_CLAVE_PAIS"])
                {
                    this.PAISComboBoxFb.SelectedValue = encargadoCorteBE.m_PersonaBE.ISAT_CLAVE_PAIS.ToString();
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICODIGOPOSTAL"])
                {
                    this.CODIGOPOSTALTextBox.Text = encargadoCorteBE.m_PersonaBE.ICODIGOPOSTAL.ToString();
                }
                else
                {
                    this.CODIGOPOSTALTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ITELEFONO1"])
                {
                    this.TELEFONO1TextBox.Text = encargadoCorteBE.m_PersonaBE.ITELEFONO1.ToString();
                }
                else
                {
                    this.TELEFONO1TextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ITELEFONO2"])
                {
                    this.TELEFONO2TextBox.Text = encargadoCorteBE.m_PersonaBE.ITELEFONO2.ToString();
                }
                else
                {
                    this.TELEFONO2TextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ITELEFONO3"])
                {
                    this.TELEFONO3TextBox.Text = encargadoCorteBE.m_PersonaBE.ITELEFONO3.ToString();
                }
                else
                {
                    this.TELEFONO3TextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ICELULAR"])
                {
                    this.CELULARTextBox.Text = encargadoCorteBE.m_PersonaBE.ICELULAR.ToString();
                }
                else
                {
                    this.CELULARTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["INEXTEL"])
                {
                    this.NEXTELTextBox.Text = encargadoCorteBE.m_PersonaBE.INEXTEL.ToString();
                }
                else
                {
                    this.NEXTELTextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IEMAIL1"])
                {
                    this.EMAIL1TextBox.Text = encargadoCorteBE.m_PersonaBE.IEMAIL1.ToString();
                }
                else
                {
                    this.EMAIL1TextBox.Text = "";
                }

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IEMAIL2"])
                {
                    this.EMAIL2TextBox.Text = encargadoCorteBE.m_PersonaBE.IEMAIL2.ToString();
                }
                else
                {
                    this.EMAIL2TextBox.Text = "";
                }

               

                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["ILISTAPRECIOID"])
                {
                    this.LISTAPRECIOIDTextBox.Text = encargadoCorteBE.m_PersonaBE.ILISTAPRECIOID.ToString();
                }
                else
                {
                    this.LISTAPRECIOIDTextBox.Text = "";
                }


                if (!(bool)encargadoCorteBE.m_PersonaBE.isnull["IVIGENCIA"])
                {
                    try
                    {
                        this.VIGENCIATextBox.Value = encargadoCorteBE.m_PersonaBE.IVIGENCIA;
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


        private CENCARGADOCORTEBE ObtenerDatosCapturados()
        {
            CENCARGADOCORTEBE encargadoCorteBE = new CENCARGADOCORTEBE();



            //if (this.ACTIVOTextBox.Text != "")
            //{
                encargadoCorteBE.m_PersonaBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N"; 
            //}



            if (this.CLAVETextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            if (this.DESCRIPCIONTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }


            if (this.MEMOTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IMEMO = this.MEMOTextBox.Text.ToString();
            }


            if (this.NOMBRESTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.INOMBRES = this.NOMBRESTextBox.Text.ToString();
            }


            if (this.APELLIDOSTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IAPELLIDOS = this.APELLIDOSTextBox.Text.ToString();
            }


            if (this.RAZONSOCIALTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IRAZONSOCIAL = this.RAZONSOCIALTextBox.Text.ToString();
            }


            if (this.RFCTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IRFC = this.RFCTextBox.Text.ToString();
            }


            if (this.CONTACTO1TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICONTACTO1 = this.CONTACTO1TextBox.Text.ToString();
            }


            if (this.CONTACTO2TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICONTACTO2 = this.CONTACTO2TextBox.Text.ToString();
            }




            if (this.DOMICILIOTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IDOMICILIO = this.DOMICILIOTextBox.Text.ToString();
            }


            if (this.COLONIATextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICOLONIA = this.COLONIATextBox.Text.ToString();
            }


            if (this.CIUDADTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICIUDAD = this.CIUDADTextBox.Text.ToString();
            }


            if (this.MUNICIPIOTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IMUNICIPIO = this.MUNICIPIOTextBox.Text.ToString();
            }


            if (this.ESTADOTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IESTADO = this.ESTADOTextBox.Text.ToString();
            }

            if (this.PAISComboBoxFb.SelectedIndex >= 0)
            {
                encargadoCorteBE.m_PersonaBE.ISAT_CLAVE_PAIS = this.PAISComboBoxFb.SelectedValue.ToString();
                encargadoCorteBE.m_PersonaBE.IPAIS = this.PAISComboBoxFb.SelectedDataDisplaying.ToString();
            }



            if (this.CODIGOPOSTALTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICODIGOPOSTAL = this.CODIGOPOSTALTextBox.Text.ToString();
            }


            if (this.TELEFONO1TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ITELEFONO1 = this.TELEFONO1TextBox.Text.ToString();
            }


            if (this.TELEFONO2TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ITELEFONO2 = this.TELEFONO2TextBox.Text.ToString();
            }


            if (this.TELEFONO3TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ITELEFONO3 = this.TELEFONO3TextBox.Text.ToString();
            }


            if (this.CELULARTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ICELULAR = this.CELULARTextBox.Text.ToString();
            }


            if (this.NEXTELTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.INEXTEL = this.NEXTELTextBox.Text.ToString();
            }


            if (this.EMAIL1TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IEMAIL1 = this.EMAIL1TextBox.Text.ToString();
            }


            if (this.EMAIL2TextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.IEMAIL2 = this.EMAIL2TextBox.Text.ToString();
            }


            if (this.SALUDOIDTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ISALUDOID = (long)this.SALUDOIDTextBox.SelectedDataValue;
            }


            if (this.LISTAPRECIOIDTextBox.Text != "")
            {
                encargadoCorteBE.m_PersonaBE.ILISTAPRECIOID = Int64.Parse(this.LISTAPRECIOIDTextBox.Text.ToString());
            }




            encargadoCorteBE.m_PersonaBE.IVIGENCIA = this.VIGENCIATextBox.Value;


            return encargadoCorteBE;

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
                    CENCARGADOCORTED proveedorD = new CENCARGADOCORTED();

                    if (opc == "Agregar")
                    {
                        CENCARGADOCORTEBE encargadoCorteBE = new CENCARGADOCORTEBE();
                        encargadoCorteBE = ObtenerDatosCapturados();

                        encargadoCorteBE.m_PersonaBE.ITIPOPERSONAID = DBValues._TIPOPERSONA_ENCARGADOCORTE;
                        //encargadoCorteBE.m_PersonaBE.IES = "S";

                        proveedorD.AgregarPERSONA(encargadoCorteBE.m_PersonaBE, null);

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
                        CENCARGADOCORTEBE encargadoCorteBEAnt = new CENCARGADOCORTEBE();
                        CENCARGADOCORTEBE encargadoCorteBE = new CENCARGADOCORTEBE();
                        encargadoCorteBE = ObtenerDatosCapturados();
                        encargadoCorteBEAnt.m_PersonaBE.IID = this.ID;

                        proveedorD.CambiarENCARGADOCORTED(encargadoCorteBE.m_PersonaBE, encargadoCorteBEAnt.m_PersonaBE, null);
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
                            CENCARGADOCORTEBE encargadoCorteBEAnt = new CENCARGADOCORTEBE();
                            encargadoCorteBEAnt.m_PersonaBE.IID = this.ID;

                            proveedorD.BorrarPERSONA(encargadoCorteBEAnt.m_PersonaBE, null);
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
