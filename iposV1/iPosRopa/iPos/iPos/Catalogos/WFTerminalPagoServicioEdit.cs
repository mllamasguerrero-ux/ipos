
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
    public partial class WFTerminalPagoServicioEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFTerminalPagoServicioEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,long pID)
        {
            opc = popc;
            ID = pID;
            //CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);

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
                this.TERMINALTextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; 
            }
        }



        private void TERMINALPAGOSERVICIOEdit_Reg_Load(object sender, EventArgs e)
        {
            
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CTERMINALPAGOSERVICIOD terminalpagoservicioD = new CTERMINALPAGOSERVICIOD();
                CTERMINALPAGOSERVICIOBE terminalpagoservicioBE = new CTERMINALPAGOSERVICIOBE();

                terminalpagoservicioBE.IID = ID;
                terminalpagoservicioBE = terminalpagoservicioD.seleccionarTERMINALPAGOSERVICIO(terminalpagoservicioBE, null);

                if (terminalpagoservicioBE == null)
                    return false;

                this.ID = terminalpagoservicioBE.IID;

                this.TERMINALTextBox.Text = terminalpagoservicioBE.ITERMINAL;

                CLAVE = terminalpagoservicioBE.ITERMINAL;

                this.ACTIVOTextBox.Checked = (terminalpagoservicioBE.IACTIVO == "S") ? true : false;

                this.ESSERVICIOTextBox.Checked = (terminalpagoservicioBE.IESSERVICIO == "S") ? true : false;



                string strBuffer = "";
                if (!(bool)terminalpagoservicioBE.isnull["ISUCURSALID"])
                {
                    this.SUCURSALIDTextBox.DbValue = terminalpagoservicioBE.ISUCURSALID.ToString();
                    this.SUCURSALIDTextBox.MostrarErrores = false;
                    this.SUCURSALIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SUCURSALIDTextBox.MostrarErrores = true;
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


        private CTERMINALPAGOSERVICIOBE ObtenerDatosCapturados()
        {
            CTERMINALPAGOSERVICIOBE TERMINALPAGOSERVICIOBE = new CTERMINALPAGOSERVICIOBE();
            TERMINALPAGOSERVICIOBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";
            TERMINALPAGOSERVICIOBE.IESSERVICIO = (this.ESSERVICIOTextBox.Checked) ? "S" : "N";

            if (this.TERMINALTextBox.Text != "")
            {
                TERMINALPAGOSERVICIOBE.ITERMINAL = this.TERMINALTextBox.Text.ToString();
            }


            if (this.SUCURSALIDTextBox.Text != "")
            {
                TERMINALPAGOSERVICIOBE.ISUCURSALID = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
                TERMINALPAGOSERVICIOBE.ISUCURSALCLAVE = this.SUCURSALIDTextBox.Text;
            }



            return TERMINALPAGOSERVICIOBE;

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
                    CTERMINALPAGOSERVICIOD TERMINALPAGOSERVICIOD = new CTERMINALPAGOSERVICIOD();

                    if (opc == "Agregar")
                    {
                        CTERMINALPAGOSERVICIOBE TERMINALPAGOSERVICIOBE = new CTERMINALPAGOSERVICIOBE();
                        TERMINALPAGOSERVICIOBE = ObtenerDatosCapturados();

                        TERMINALPAGOSERVICIOD.AgregarTERMINALPAGOSERVICIO(TERMINALPAGOSERVICIOBE, null);

                        if (TERMINALPAGOSERVICIOD.IComentario == "" || TERMINALPAGOSERVICIOD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + TERMINALPAGOSERVICIOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CTERMINALPAGOSERVICIOBE TERMINALPAGOSERVICIOBEAnt = new CTERMINALPAGOSERVICIOBE();

                        CTERMINALPAGOSERVICIOBE TERMINALPAGOSERVICIOBE = new CTERMINALPAGOSERVICIOBE();

                        TERMINALPAGOSERVICIOBE = ObtenerDatosCapturados();

                        TERMINALPAGOSERVICIOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        TERMINALPAGOSERVICIOBEAnt.IID = this.ID;

                        TERMINALPAGOSERVICIOD.CambiarTERMINALPAGOSERVICIO(TERMINALPAGOSERVICIOBE, TERMINALPAGOSERVICIOBEAnt, null);
                        if (TERMINALPAGOSERVICIOD.IComentario == "" || TERMINALPAGOSERVICIOD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + TERMINALPAGOSERVICIOD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CTERMINALPAGOSERVICIOBE TERMINALPAGOSERVICIOBEAnt = new CTERMINALPAGOSERVICIOBE();
                            TERMINALPAGOSERVICIOBEAnt.IID = this.ID;
                            TERMINALPAGOSERVICIOD.BorrarTERMINALPAGOSERVICIO(TERMINALPAGOSERVICIOBEAnt, null);
                            if (TERMINALPAGOSERVICIOD.IComentario == "" || TERMINALPAGOSERVICIOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + TERMINALPAGOSERVICIOD.IComentario.Replace("%", "\n"));
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

            this.ESSERVICIOTextBox.Checked = false;

            this.TERMINALTextBox.Text = "";


            this.SUCURSALIDTextBox.Text = "";




        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.TERMINALTextBox.Text != "" )
            {
                this.CLAVE = this.TERMINALTextBox.Text;

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
            this.TERMINALTextBox.Focus();
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
                this.CLAVE = TERMINALTextBox.Text;
                if (!LlenarDatosDeBase())
                {
                    e.Cancel = true;
                    MessageBox.Show("No existe una terminalpagoservicio con esa clave");
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

    }
}
