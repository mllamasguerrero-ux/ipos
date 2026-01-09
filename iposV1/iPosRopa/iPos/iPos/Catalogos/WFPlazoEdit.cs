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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Catalogos
{
    public partial class WFPlazoEdit : Form
    {
        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);


        bool m_manejaAlmacen = false;

        public WFPlazoEdit()
        {
            InitializeComponent();
        }

        public void ReCargar(string popc, string pCLAVE)
        {
            opc = popc;
            CLAVE = pCLAVE;
            validadores = new System.Collections.ArrayList();
            validadores.Add(RFV_CLAVE);


            LlenarDatosCatalogos();


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
                this.cbComisionista.Enabled = true;
                if (cbComisionista.Checked == true)
                {
                    this.txtLeyenda.Enabled = true;
                }
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
                this.cbComisionista.Enabled = true;
                if (cbComisionista.Checked == true)
                {
                    this.txtLeyenda.Enabled = true;
                }
            }
        }

        private bool LlenarDatosDeBase()
        {
            try
            {
                CPLAZOD PLAZOD = new CPLAZOD();
                CPLAZOBE PLAZOBE = new CPLAZOBE();

                PLAZOBE.ICLAVE = CLAVE;
                PLAZOBE = PLAZOD.seleccionarPlazoXCLAVE(PLAZOBE, null);

                if (PLAZOBE == null)
                    return false;

                this.ID = PLAZOBE.IID;

                this.CLAVETextBox.Text = PLAZOBE.ICLAVE;

                this.NOMBRETextBox.Text = PLAZOBE.INOMBRE;


                this.ACTIVOTextBox.Checked = (PLAZOBE.IACTIVO == "S") ? true : false;

                this.cbComisionista.Checked = (PLAZOBE.ICOMISIONISTA == "S") ? true : false;

                if(PLAZOBE.IALMACENID > 0)
                {
                    this.ALMACENComboBox.SelectedDataValue = PLAZOBE.IALMACENID;
                }

                this.txtLeyenda.Text = PLAZOBE.ILEYENDA;

                if(this.cbComisionista.Checked == false)
                {
                    this.txtLeyenda.Enabled = false;
                }

                this.DIASTextBox.Text = PLAZOBE.IDIAS.ToString();


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

        private CPLAZOBE ObtenerDatosCapturados()
        {
            CPLAZOBE PLAZOBE = new CPLAZOBE();
            PLAZOBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                PLAZOBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                PLAZOBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }

            PLAZOBE.ICOMISIONISTA = (this.cbComisionista.Checked) ? "S" : "N";

            if (this.txtLeyenda.Text != "")
            {
                PLAZOBE.ILEYENDA = this.txtLeyenda.Text.ToString();
            }


            if (this.DIASTextBox.Text != "")
            {
                PLAZOBE.IDIAS = int.Parse(this.DIASTextBox.Text.ToString());
            }

            PLAZOBE.IALMACENID = this.ALMACENComboBox.SelectedDataValue != null ? long.Parse(this.ALMACENComboBox.SelectedDataValue.ToString()) : 0;

            return PLAZOBE;

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
                    CPLAZOD PLAZOD = new CPLAZOD();

                    if (opc == "Agregar")
                    {
                        CPLAZOBE PLAZOBE = new CPLAZOBE();
                        PLAZOBE = ObtenerDatosCapturados();

                        PLAZOD.AgregarPLAZOD(PLAZOBE, null);

                        if (PLAZOD.IComentario == "" || PLAZOD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + PLAZOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CPLAZOBE PLAZOBEAnt = new CPLAZOBE();

                        CPLAZOBE PLAZOBE = new CPLAZOBE();

                        PLAZOBE = ObtenerDatosCapturados();

                        PLAZOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        PLAZOBEAnt.IID = this.ID;

                        PLAZOD.CambiarPLAZO(PLAZOBE, PLAZOBEAnt, null);
                        if (PLAZOD.IComentario == "" || PLAZOD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + PLAZOD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CPLAZOBE GASTOAnt = new CPLAZOBE();
                            GASTOAnt.IID = this.ID;
                            PLAZOD.BorrarPLAZO(GASTOAnt, null);
                            if (PLAZOD.IComentario == "" || PLAZOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + PLAZOD.IComentario.Replace("%", "\n"));
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

            this.cbComisionista.Checked = false;

            this.txtLeyenda.Text = "";


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
                    MessageBox.Show("No existe un GASTO con esa clave");
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

        private void cbComisionista_CheckedChanged(object sender, EventArgs e)
        {
            if(cbComisionista.Checked == false)
            {
                this.txtLeyenda.Enabled = false;
            }
            else
            {
                this.txtLeyenda.Enabled = true;
            }
        }

        private void LlenarDatosCatalogos()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!this.m_manejaAlmacen)
            {
                pnlAlmacen.Visible = false;
            }
            else
            {
                pnlAlmacen.Visible = true;
                this.ALMACENComboBox.llenarDatos();
            }

            if (this.opc == "Agregar")
            {
                SetDefaultAlmacenEstatus();
            }
        }

        private void WFPlazoEdit_Load(object sender, EventArgs e)
        {

        }


        public void SetDefaultAlmacenEstatus()
        {


            if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

        }
    }
}
