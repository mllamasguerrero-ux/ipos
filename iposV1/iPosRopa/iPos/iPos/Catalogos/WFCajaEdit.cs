
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
    public partial class WFCajaEditForm : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;

        long VERIFONECAJACONFIGID = 0;

        CVERIFONECONFIGBE empresaVerifoneConfig;
        bool verifoneHabilitado = false;

        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFCajaEditForm()
        {
            InitializeComponent();

            empresaVerifoneConfig = new CVERIFONECONFIGBE();
        }


        private void CAJAEdit_Reg_Load(object sender, EventArgs e)
        {
            string strCometnario = "";
           

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" &&
                usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_BANCOMER, null))
            {
                this.label4.Enabled = true;
                this.label4.Visible = true;
                this.label6.Enabled = true;
                this.label6.Visible = true;
                this.label7.Enabled = true;
                this.label7.Visible = true;
                this.txtBancomerTerminal.Enabled = true;
                this.txtBancomerTerminal.Visible = true;
                this.txtBancomerCert.Enabled = true;
                this.txtBancomerCert.Visible = true;
                this.afiliacionTextBox.Enabled = true;
                this.afiliacionTextBox.Visible = true;
            }

            this.pnlVerifone.Visible = verifoneHabilitado;
        }

        public void ReCargar(string popc,string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);


            LlenarDatosDeVerifoneEmpresa();
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            verifoneHabilitado = this.empresaVerifoneConfig != null && this.empresaVerifoneConfig.IACTIVO == "S" &&
                                        usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_VERIFONE, null);


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
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
                this.NOMBREIMPRESORATextBox.Text = CurrentUserID.CurrentParameters.ITICKETDEFAULTPRINTER;
                this.IMPRESORACOMANDATextBox.Text = CurrentUserID.CurrentParameters.ITICKETDEFAULTPRINTER;//"IposPrinter3";
            }
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CCAJAD cajaD = new CCAJAD();
                CCAJABE cajaBE = new CCAJABE();

                cajaBE.ICLAVE = CLAVE;
                cajaBE = cajaD.seleccionarCAJAxCLAVE(cajaBE, null);

                if (cajaBE == null)
                    return false;

                this.ID = cajaBE.IID;

                this.CLAVETextBox.Text = cajaBE.ICLAVE;

                this.NOMBRETextBox.Text = cajaBE.INOMBRE;


                this.ACTIVOTextBox.Checked = (cajaBE.IACTIVO == "S") ? true : false;

                this.DESCRIPCIONTextBox.Text = cajaBE.IDESCRIPCION;

                this.NOMBREIMPRESORATextBox.Text = cajaBE.INOMBREIMPRESORA;
                this.IMPRESORACOMANDATextBox.Text = cajaBE.IIMPRESORACOMANDA;

                string strBuffer = "";
                if (!(bool)cajaBE.isnull["ITERMINAL"])
                {
                    this.TERMINALTextBox.DbValue = cajaBE.ITERMINAL.ToString();
                    this.TERMINALTextBox.MostrarErrores = false;
                    this.TERMINALTextBox.MValidarEntrada(out strBuffer, 1);
                    this.TERMINALTextBox.MostrarErrores = true;
                }


                if (!(bool)cajaBE.isnull["ITERMINALSERVICIOS"])
                {
                    this.TERMINALSERVICIOSTextBox.DbValue = cajaBE.ITERMINALSERVICIOS.ToString();
                    this.TERMINALSERVICIOSTextBox.MostrarErrores = false;
                    this.TERMINALSERVICIOSTextBox.MValidarEntrada(out strBuffer, 1);
                    this.TERMINALSERVICIOSTextBox.MostrarErrores = true;
                }


                try
                {
                    this.txtBancomerTerminal.Text = cajaBE.INUMEROTERMINALBANCOMER.ToString();
                }
                catch
                {

                }

                this.txtBancomerCert.Text = cajaBE.INOMBRECERTIFICADOBANCOMER;

                if (cajaBE.IAFILIACIONBANCOMER != null)
                {
                    this.afiliacionTextBox.Text = cajaBE.IAFILIACIONBANCOMER;
                }
                else this.afiliacionTextBox.Text = String.Empty;


                if(verifoneHabilitado)
                    LlenarDatosDeVerifone();

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


        private void LlenarDatosDeVerifoneEmpresa()
        {
            CVERIFONECONFIGD vERIFONECONFIGD = new CVERIFONECONFIGD();
            this.empresaVerifoneConfig = vERIFONECONFIGD.seleccionarVERIFONECONFIG_Unico(null);
        }

        private bool LlenarDatosDeVerifone()
        {

            try
            {
                CVERIFONECAJACONFIGD verifoneCajaConfigD = new CVERIFONECAJACONFIGD();
                CVERIFONECAJACONFIGBE verifoneCajaConfigBE = new CVERIFONECAJACONFIGBE();

                verifoneCajaConfigBE.ICAJAID = this.ID;
                verifoneCajaConfigBE = verifoneCajaConfigD.seleccionarVERIFONECAJACONFIG_x_CAJAID(verifoneCajaConfigBE, null);

                if (verifoneCajaConfigBE == null)
                    return false;

                this.VERIFONECAJACONFIGID = verifoneCajaConfigBE.IID;


                this.VERIFONEACTIVOCheckBox.Checked = (verifoneCajaConfigBE.IACTIVO == "S") ? true : false;
                this.VERIFONE_USERIDTextBox.Text = verifoneCajaConfigBE.IUSERID;
                this.VERIFONE_CONTRASENATextBox.Text = verifoneCajaConfigBE.ICONTRASENA;
                this.VERIFONE_SHIFTNUMBERTextBox.Text = verifoneCajaConfigBE.ISHIFTNUMBER;
                this.VERIFONE_MERCHANTIDTextBox.Text = verifoneCajaConfigBE.IMERCHANTID;
                this.VERIFONE_OPERATORLOCALETextBox.Text = verifoneCajaConfigBE.IOPERATORLOCALE;


                if(!string.IsNullOrEmpty( verifoneCajaConfigBE.IDEVICECONNECTIONTYPEKEY))
                {
                    this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.SelectedItem = verifoneCajaConfigBE.IDEVICECONNECTIONTYPEKEY;
                }

                this.VERIFONE_DEVICEADDRESSKEYTextBox.Text = verifoneCajaConfigBE.IDEVICEADDRESSKEY;

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

        

        private CCAJABE ObtenerDatosCapturados()
        {
            CCAJABE CAJABE = new CCAJABE();
            CAJABE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                CAJABE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                CAJABE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }

            if (this.DESCRIPCIONTextBox.Text != "")
            {
                CAJABE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }


            if (this.NOMBREIMPRESORATextBox.Text != "")
            {
                CAJABE.INOMBREIMPRESORA = this.NOMBREIMPRESORATextBox.Text.ToString();
            }

            if (this.IMPRESORACOMANDATextBox.Text != "")
            {
                CAJABE.IIMPRESORACOMANDA = this.IMPRESORACOMANDATextBox.Text.ToString();
            }

            if (this.TERMINALTextBox.Text != "")
            {
                CAJABE.ITERMINAL = this.TERMINALTextBox.Text.ToString();
            }

            if (this.TERMINALSERVICIOSTextBox.Text != "")
            {
                CAJABE.ITERMINALSERVICIOS = this.TERMINALSERVICIOSTextBox.Text.ToString();
            }

            if (this.txtBancomerTerminal.Text != "")
            {
                try
                {

                    CAJABE.INUMEROTERMINALBANCOMER = long.Parse(this.txtBancomerTerminal.Text);
                }
                catch
                {

                }
            }

            if (this.afiliacionTextBox.Text != null)
            {
                CAJABE.IAFILIACIONBANCOMER = afiliacionTextBox.Text;
            }
            else CAJABE.IAFILIACIONBANCOMER = String.Empty;


            if (this.txtBancomerCert.Text != "")
            {
                CAJABE.INOMBRECERTIFICADOBANCOMER = this.txtBancomerCert.Text.ToString();
            }



            return CAJABE;

        }



        private CVERIFONECAJACONFIGBE ObtenerDatosCapturadosVerifone()
        {
            CVERIFONECAJACONFIGBE VERIFONECAJACONFIGBE = new CVERIFONECAJACONFIGBE();
            VERIFONECAJACONFIGBE.IACTIVO = (this.VERIFONEACTIVOCheckBox.Checked) ? "S" : "N";

            if (this.VERIFONE_USERIDTextBox.Text != "")
                VERIFONECAJACONFIGBE.IUSERID = this.VERIFONE_USERIDTextBox.Text.ToString();

            if (this.VERIFONE_CONTRASENATextBox.Text != "")
                VERIFONECAJACONFIGBE.ICONTRASENA = this.VERIFONE_CONTRASENATextBox.Text.ToString();

            if (this.VERIFONE_SHIFTNUMBERTextBox.Text != "")
                VERIFONECAJACONFIGBE.ISHIFTNUMBER = this.VERIFONE_SHIFTNUMBERTextBox.Text.ToString();

            if (this.VERIFONE_MERCHANTIDTextBox.Text != "")
                VERIFONECAJACONFIGBE.IMERCHANTID = this.VERIFONE_MERCHANTIDTextBox.Text.ToString();

            if (this.VERIFONE_OPERATORLOCALETextBox.Text != "")
                VERIFONECAJACONFIGBE.IOPERATORLOCALE = this.VERIFONE_OPERATORLOCALETextBox.Text.ToString();

            if (this.VERIFONE_DEVICEADDRESSKEYTextBox.Text != "")
                VERIFONECAJACONFIGBE.IDEVICEADDRESSKEY = this.VERIFONE_DEVICEADDRESSKEYTextBox.Text.ToString();

            if(this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.SelectedIndex >= 0)
                VERIFONECAJACONFIGBE.IDEVICECONNECTIONTYPEKEY = this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.SelectedItem.ToString();
            else
                VERIFONECAJACONFIGBE.IDEVICECONNECTIONTYPEKEY = "";

            


            return VERIFONECAJACONFIGBE;

        }


        public void 
            SaveChanges()
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
                    CCAJAD CAJAD = new CCAJAD();

                    if (opc == "Agregar")
                    {
                        CCAJABE CAJABE = new CCAJABE();
                        CAJABE = ObtenerDatosCapturados();

                        CAJAD.AgregarCAJA(CAJABE, null);

                        if (CAJAD.IComentario == "" || CAJAD.IComentario == null)
                        {
                            //VERIFONE - INICIO
                            if (verifoneHabilitado)
                            {
                                var cajaSaved = CAJAD.seleccionarCAJAxCLAVE(CAJABE, null);
                                CVERIFONECAJACONFIGBE verifoneCaja = new CVERIFONECAJACONFIGBE();
                                CVERIFONECAJACONFIGD verifoneCajaD = new CVERIFONECAJACONFIGD();
                                verifoneCaja = ObtenerDatosCapturadosVerifone();
                                verifoneCaja.ICAJAID = cajaSaved.IID;
                                verifoneCajaD.AgregarVERIFONECAJACONFIG(verifoneCaja, null);

                                if (verifoneCajaD.IComentario != "" && verifoneCajaD.IComentario != null)
                                {
                                    MessageBox.Show("Error al grabar los datos de verifone" + verifoneCajaD.IComentario);
                                }
                            }
                            //VERIFONE - FIN



                            iPos.CurrentUserID.currentPrinter = Ticket.GetReceiptPrinter();
                            iPos.CurrentUserID.CurrentPrinterRecargas = Ticket.GetReceiptPrinterRecargas();
                            ConexionesBD.ConexionBD.currentPrinter = iPos.CurrentUserID.currentPrinter;

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + CAJAD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CCAJABE CAJABEAnt = new CCAJABE();

                        CCAJABE CAJABE = new CCAJABE();

                        CAJABE = ObtenerDatosCapturados();

                        CAJABE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        CAJABEAnt.IID = this.ID;

                        CAJAD.CambiarCAJA(CAJABE, CAJABEAnt, null);
                        if (CAJAD.IComentario == "" || CAJAD.IComentario == null)
                        {

                            //VERIFONE - INICIO
                            if (verifoneHabilitado)
                            {
                                CVERIFONECAJACONFIGBE verifoneCaja = new CVERIFONECAJACONFIGBE();
                                CVERIFONECAJACONFIGD verifoneCajaD = new CVERIFONECAJACONFIGD();
                                verifoneCaja = ObtenerDatosCapturadosVerifone();
                                verifoneCaja.ICAJAID = this.ID;

                                var verifoneCajaPrevious = verifoneCajaD.seleccionarVERIFONECAJACONFIG_x_CAJAID(verifoneCaja, null);
                                if (verifoneCajaPrevious != null)
                                {
                                    verifoneCaja.IID = verifoneCajaPrevious.IID;
                                    verifoneCajaD.CambiarVERIFONECAJACONFIG(verifoneCaja, verifoneCajaPrevious, null);
                                }
                                else
                                {
                                    verifoneCajaD.AgregarVERIFONECAJACONFIG(verifoneCaja, null);
                                }

                                if (verifoneCajaD.IComentario != "" && verifoneCajaD.IComentario != null)
                                {
                                    MessageBox.Show("Error al grabar los datos de verifone" + verifoneCajaD.IComentario);
                                }
                            }
                            
                            // VERIFONE - FIN


                            iPos.CurrentUserID.currentPrinter = Ticket.GetReceiptPrinter();
                            iPos.CurrentUserID.CurrentPrinterRecargas = Ticket.GetReceiptPrinterRecargas();
                            ConexionesBD.ConexionBD.currentPrinter = iPos.CurrentUserID.currentPrinter;

                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);

                            if(CurrentUserID.CurrentCaja != null && CurrentUserID.CurrentCaja.ICLAVE != null &&
                                CurrentUserID.CurrentCaja.ICLAVE == CAJABE.ICLAVE)
                            {
                                CurrentUserID.CurrentCaja = CAJABE;
                            }


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + CAJAD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {


                            //VERIFONE - INICIO
                            if (verifoneHabilitado)
                            {
                                CVERIFONECAJACONFIGBE verifoneCaja = new CVERIFONECAJACONFIGBE();
                                CVERIFONECAJACONFIGD verifoneCajaD = new CVERIFONECAJACONFIGD();
                                verifoneCaja.ICAJAID = this.ID;
                                verifoneCaja = verifoneCajaD.seleccionarVERIFONECAJACONFIG_x_CAJAID(verifoneCaja, null);
                                if (verifoneCaja != null)
                                {
                                    verifoneCajaD.BorrarVERIFONECAJACONFIG(verifoneCaja, null);
                                }
                                if (verifoneCajaD.IComentario != "" && verifoneCajaD.IComentario == null)
                                    MessageBox.Show("Error al borrar los datos de verifone" + verifoneCajaD.IComentario);
                            }

                            // VERIFONE - FIN



                            CCAJABE CAJABEAnt = new CCAJABE();
                            CAJABEAnt.IID = this.ID;
                            CAJAD.BorrarCAJA(CAJABEAnt, null);



                            if (CAJAD.IComentario == "" || CAJAD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + CAJAD.IComentario.Replace("%", "\n"));
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

            this.CLAVETextBox.Text = "";


            this.NOMBRETextBox.Text = "";

            this.LimpiarDatosVerifone();




        }

        private void LimpiarDatosVerifone()
        {

            this.VERIFONEACTIVOCheckBox.Checked =  false;
            this.VERIFONE_USERIDTextBox.Text = "";
            this.VERIFONE_CONTRASENATextBox.Text = "";
            this.VERIFONE_SHIFTNUMBERTextBox.Text = "";
            this.VERIFONE_MERCHANTIDTextBox.Text = "";
            this.VERIFONE_OPERATORLOCALETextBox.Text = "";
            this.VERIFONE_DEVICECONNECTIONTYPEKEYComboBox.SelectedIndex = -1;
            this.VERIFONE_DEVICEADDRESSKEYTextBox.Text = "";


        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.CLAVETextBox.Text != "" )
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
            SetMode();
        }


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
                this.CLAVE = CLAVETextBox.Text;
                if (!LlenarDatosDeBase())
                {
                    e.Cancel = true;
                    MessageBox.Show("No existe una caja con esa clave");
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

        private void txtBancomerTerminal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
