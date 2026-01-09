
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
    public partial class WFPersonaCuentaBancoEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public CPERSONABE m_personaBE = null;

        public WFPersonaCuentaBancoEdit()
        {
            InitializeComponent();
            m_personaBE = new CPERSONABE();

        }

        public WFPersonaCuentaBancoEdit(CPERSONABE _personaBE) :this()
        {
            m_personaBE = _personaBE;
        }



        public void ReCargar(string popc, long pID)
        {
            opc = popc;
            ID = pID;
            validadores = new System.Collections.ArrayList();

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
                this.IDTextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; 
            }
        }



        private void LINEAEdit_Reg_Load(object sender, EventArgs e)
        {
            lblCliente.Text = m_personaBE.INOMBRE;
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CPERSONACUENTABANCOD CUENTABANCOD = new CPERSONACUENTABANCOD();
                CPERSONACUENTABANCOBE CUENTABANCOBE = new CPERSONACUENTABANCOBE();
                
                CUENTABANCOBE.IID = ID;
                CUENTABANCOBE = CUENTABANCOD.seleccionarPERSONACUENTABANCO(CUENTABANCOBE, null);

                if (CUENTABANCOBE == null)
                    return false;

                this.ID = CUENTABANCOBE.IID;

                this.IDTextBox.Text = CUENTABANCOBE.IID.ToString();
                


                this.ACTIVOTextBox.Checked = (CUENTABANCOBE.IACTIVO == "S") ? true : false;


                string strBuffer = "";
                if (!(bool)CUENTABANCOBE.isnull["IBANCOID"])
                {
                    this.BANCOIDTextBox.DbValue = CUENTABANCOBE.IBANCOID.ToString();
                    this.BANCOIDTextBox.MostrarErrores = false;
                    this.BANCOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.BANCOIDTextBox.MostrarErrores = true;
                }
                

                this.NOCUENTATextBox.Text = CUENTABANCOBE.INOCUENTA;
                

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


        private CPERSONACUENTABANCOBE ObtenerDatosCapturados()
        {
            CPERSONACUENTABANCOBE CUENTABANCOBE = new CPERSONACUENTABANCOBE();
            CUENTABANCOBE.IPERSONAID = m_personaBE.IID;

            CUENTABANCOBE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.IDTextBox.Text != "")
            {
                CUENTABANCOBE.IID = ID;
            }
            



            if (this.BANCOIDTextBox.Text != "")
            {
                CUENTABANCOBE.IBANCOID = Int64.Parse(this.BANCOIDTextBox.DbValue.ToString());
            }

            

            if (this.NOCUENTATextBox.Text != "")
            {
                CUENTABANCOBE.INOCUENTA = this.NOCUENTATextBox.Text.ToString();
            }
            

            return CUENTABANCOBE;

        }

        public void SaveChanges()
        {


            string ErroresValidacion = "";

            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);


            if ( CurrentUserID.CurrentParameters.IVERSIONCFDI != null && (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {
                string strValidacionCuenta = validarCuentasParaFormasDePago(this.NOCUENTATextBox.Text);
                MessageBox.Show(strValidacionCuenta);
            }


            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {

                try
                {
                    CPERSONACUENTABANCOD CUENTABANCOD = new CPERSONACUENTABANCOD();

                    if (opc == "Agregar")
                    {
                        CPERSONACUENTABANCOBE CUENTABANCOBE = new CPERSONACUENTABANCOBE();
                        CUENTABANCOBE = ObtenerDatosCapturados();

                        CUENTABANCOBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        CUENTABANCOD.AgregarPERSONACUENTABANCOD(CUENTABANCOBE, null);

                        if (CUENTABANCOD.IComentario == "" || CUENTABANCOD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + CUENTABANCOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CPERSONACUENTABANCOBE CUENTABANCOBEAnt = new CPERSONACUENTABANCOBE();

                        CPERSONACUENTABANCOBE CUENTABANCOBE = new CPERSONACUENTABANCOBE();

                        CUENTABANCOBE = ObtenerDatosCapturados();

                        CUENTABANCOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        CUENTABANCOBEAnt.IID = this.ID;

                        CUENTABANCOD.CambiarPERSONACUENTABANCOD(CUENTABANCOBE, CUENTABANCOBEAnt, null);
                        if (CUENTABANCOD.IComentario == "" || CUENTABANCOD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + CUENTABANCOD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CPERSONACUENTABANCOBE CUENTABANCOBEAnt = new CPERSONACUENTABANCOBE();
                            CUENTABANCOBEAnt.IID = this.ID;
                            CUENTABANCOD.BorrarPERSONACUENTABANCOD(CUENTABANCOBEAnt, null);
                            if (CUENTABANCOD.IComentario == "" || CUENTABANCOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + CUENTABANCOD.IComentario.Replace("%", "\n"));
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
           
            this.ACTIVOTextBox.Checked = false;

            this.IDTextBox.Text = "";
            




        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.IDTextBox.Text != "" )
            {
                this.CLAVE = this.IDTextBox.Text;

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
            SetMode();
        }


        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            //this.IDTextBox.Focus();
            this.IDTextBox.Focus();
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
                        if (v.ControlToValidate.Name != "CLAVETextBox")
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
                this.CLAVE = IDTextBox.Text;
                if (!LlenarDatosDeBase())
                {
                    e.Cancel = true;
                    MessageBox.Show("No existe una linea con esa clave");
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
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
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
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
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
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
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
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
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
            if (formaPagoSatBE != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO != null && formaPagoSatBE.ISAT_PATRONBENEFICIARIO.Trim().Length > 0)
            {

                if (!iPosReporting.VirtualXml.VirtualXmlHelper.MatchPatronFormaPago(cuenta, formaPagoSatBE.ISAT_PATRONBENEFICIARIO, false))
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

    }
}
