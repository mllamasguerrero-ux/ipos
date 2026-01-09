using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Catalogos
{
    public partial class WFRutaEmbarqueEdit : Form
    {
        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFRutaEmbarqueEdit()
        {
            InitializeComponent();
        }

        public void ReCargar(string popc, string pCLAVE)
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

        private bool LlenarDatosDeBase()
        {
            try
            {
                CRUTAEMBARQUED rutaEmbarqueD = new CRUTAEMBARQUED();
                CRUTAEMBARQUEBE rutaEmbarqueBE = new CRUTAEMBARQUEBE();

                rutaEmbarqueBE.ICLAVE = CLAVE;
                rutaEmbarqueBE = rutaEmbarqueD.seleccionarRUTAEMBARQUExCLAVE(rutaEmbarqueBE, null);

                if (rutaEmbarqueBE == null)
                    return false;

                this.ID = rutaEmbarqueBE.IID;

                this.CLAVETextBox.Text = rutaEmbarqueBE.ICLAVE;

                this.NOMBRETextBox.Text = rutaEmbarqueBE.INOMBRE;


                this.ACTIVOTextBox.Checked = (rutaEmbarqueBE.IACTIVO == "S") ? true : false;

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

        private CRUTAEMBARQUEBE ObtenerDatosCapturados()
        {
            CRUTAEMBARQUEBE REBE = new CRUTAEMBARQUEBE();
            REBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                REBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                REBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            return REBE;

        }

        public void SaveChanges()
        {


            string ErroresValidacion = "";

            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);

            //this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {

                try
                {
                    CRUTAEMBARQUED RUTASEMBARQUED = new CRUTAEMBARQUED();

                    if (opc == "Agregar")
                    {
                        CRUTAEMBARQUEBE RUTASEMBARQUEBE = new CRUTAEMBARQUEBE();
                        RUTASEMBARQUEBE = ObtenerDatosCapturados();

                        RUTASEMBARQUEBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        RUTASEMBARQUED.AgregarRUTAEMBARQUE(RUTASEMBARQUEBE, null);

                        if (RUTASEMBARQUED.IComentario == "" || RUTASEMBARQUED.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + RUTASEMBARQUED.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CRUTAEMBARQUEBE BANCOBEAnt = new CRUTAEMBARQUEBE();

                        CRUTAEMBARQUEBE BANCOBE = new CRUTAEMBARQUEBE();

                        BANCOBE = ObtenerDatosCapturados();

                        BANCOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        BANCOBEAnt.IID = this.ID;

                        RUTASEMBARQUED.CambiarRUTAEMBARQUE(BANCOBE, BANCOBEAnt, null);
                        if (RUTASEMBARQUED.IComentario == "" || RUTASEMBARQUED.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + RUTASEMBARQUED.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CRUTAEMBARQUEBE BANCOBEAnt = new CRUTAEMBARQUEBE();
                            BANCOBEAnt.IID = this.ID;
                            RUTASEMBARQUED.BorrarRUTAEMBARQUE(BANCOBEAnt, null);
                            if (RUTASEMBARQUED.IComentario == "" || RUTASEMBARQUED.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + RUTASEMBARQUED.IComentario.Replace("%", "\n"));
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
                    MessageBox.Show("No existe una Ruta de Embarque con esa clave");
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

        private void WFRutaEmbarqueEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
