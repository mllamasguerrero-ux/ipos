
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
    public partial class WFTasaIvaEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFTasaIvaEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;
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
                this.CLAVETextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; 
            }
        }



        private void LINEAEdit_Reg_Load(object sender, EventArgs e)
        {
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CTASAIVAD tasaivaD = new CTASAIVAD();
                CTASAIVABE tasaivaBE = new CTASAIVABE();

                tasaivaBE.ICLAVE = CLAVE;
                tasaivaBE = tasaivaD.seleccionarTASAIVAxCLAVE(tasaivaBE, null);

                if (tasaivaBE == null)
                    return false;

                this.ID = tasaivaBE.IID;

                this.CLAVETextBox.Text = tasaivaBE.ICLAVE;

                this.NOMBRETextBox.Text = tasaivaBE.INOMBRE;


                this.ACTIVOTextBox.Checked = (tasaivaBE.IACTIVO == "S") ? true : false;

                if (!(bool)tasaivaBE.isnull["ITASA"])
                    this.TASATextBox.Text = tasaivaBE.ITASA.ToString();

                try
                {
                    this.FECHAINICIATextBox.Value = tasaivaBE.IFECHAINICIA;
                }
                catch
                {
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


        private CTASAIVABE ObtenerDatosCapturados()
        {
            CTASAIVABE TASAIVABE = new CTASAIVABE();
            TASAIVABE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                TASAIVABE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                TASAIVABE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }



            if (this.TASATextBox.Text != "")
            {
                TASAIVABE.ITASA = decimal.Parse(this.TASATextBox.Text.ToString());
            }


            TASAIVABE.IFECHAINICIA= this.FECHAINICIATextBox.Value;




            return TASAIVABE;

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
                    CTASAIVAD TASAIVAD = new CTASAIVAD();

                    if (opc == "Agregar")
                    {
                        CTASAIVABE TASAIVABE = new CTASAIVABE();
                        TASAIVABE = ObtenerDatosCapturados();
                        TASAIVABE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        TASAIVAD.AgregarTASAIVA(TASAIVABE, null);

                        if (TASAIVAD.IComentario == "" || TASAIVAD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + TASAIVAD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CTASAIVABE TASAIVABEAnt = new CTASAIVABE();

                        CTASAIVABE TASAIVABE = new CTASAIVABE();

                        TASAIVABE = ObtenerDatosCapturados();

                        TASAIVABE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        TASAIVABEAnt.IID = this.ID;

                        TASAIVAD.CambiarTASAIVA(TASAIVABE, TASAIVABEAnt, null);
                        if (TASAIVAD.IComentario == "" || TASAIVAD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + TASAIVAD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CTASAIVABE TASAIVABEAnt = new CTASAIVABE();
                            TASAIVABEAnt.IID = this.ID;
                            TASAIVAD.BorrarTASAIVA(TASAIVABEAnt, null);
                            if (TASAIVAD.IComentario == "" || TASAIVAD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + TASAIVAD.IComentario.Replace("%", "\n"));
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

            this.TASATextBox.Text = "";

            this.FECHAINICIATextBox.Value = DateTime.Today;




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

    }
}
