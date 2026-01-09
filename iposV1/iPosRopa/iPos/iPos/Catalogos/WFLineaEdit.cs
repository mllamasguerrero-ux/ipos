
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
    public partial class WFLineaEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFLineaEdit()
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
            if(CurrentUserID.CurrentParameters.IAPLICARMAYOREOPORLINEA != null && CurrentUserID.CurrentParameters.IAPLICARMAYOREOPORLINEA == "S")
            {
                APLICAMAYOREOXLINEALabel.Visible = true;
                APLICAMAYOREOXLINEATextBox.Visible = true;
            }
            else
            {

                APLICAMAYOREOXLINEALabel.Visible = false;
                APLICAMAYOREOXLINEATextBox.Visible = false;
            }
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CLINEAD lineaD = new CLINEAD();
                CLINEABE lineaBE = new CLINEABE();

                lineaBE.ICLAVE = CLAVE;
                lineaBE = lineaD.seleccionarLINEAxCLAVE(lineaBE, null);

                if (lineaBE == null)
                    return false;

                this.ID = lineaBE.IID;

                this.CLAVETextBox.Text = lineaBE.ICLAVE;

                this.NOMBRETextBox.Text = lineaBE.INOMBRE;

                this.ACUMULAPROMOCIONTextBox.Checked = (lineaBE.IACUMULAPROMOCION == "S")? true: false;

                this.ACTIVOTextBox.Checked = (lineaBE.IACTIVO == "S") ? true : false;

                if (!(bool)lineaBE.isnull["ITIPORECARGA"] && lineaBE.ITIPORECARGA != null)
                {
                    this.TIPORECARGATextBox.Text = lineaBE.ITIPORECARGA.Trim();
                }


                this.APLICAMAYOREOXLINEATextBox.Checked = (lineaBE.IAPLICAMAYOREOXLINEA == "S") ? true : false;

                this.GPOIMPTextBox.Text = lineaBE.IGPOIMP;


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


        private CLINEABE ObtenerDatosCapturados()
        {
            CLINEABE LINEABE = new CLINEABE();
            LINEABE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                LINEABE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                LINEABE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }

            LINEABE.IACUMULAPROMOCION = (this.ACUMULAPROMOCIONTextBox.Checked)? "S" : "N";

            if (this.TIPORECARGATextBox.SelectedIndex >= 0)
            {
                LINEABE.ITIPORECARGA = this.TIPORECARGATextBox.Text;
            }

            LINEABE.IAPLICAMAYOREOXLINEA = (this.APLICAMAYOREOXLINEATextBox.Checked) ? "S" : "N";


            if (this.GPOIMPTextBox.Text != "")
            {
                LINEABE.IGPOIMP = this.GPOIMPTextBox.Text.ToString();
            }

            return LINEABE;

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
                    CLINEAD LINEAD = new CLINEAD();

                    if (opc == "Agregar")
                    {
                        CLINEABE LINEABE = new CLINEABE();
                        LINEABE = ObtenerDatosCapturados();

                        LINEAD.AgregarLINEA(LINEABE, null);

                        if (LINEAD.IComentario == "" || LINEAD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + LINEAD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CLINEABE LINEABEAnt = new CLINEABE();

                        CLINEABE LINEABE = new CLINEABE();

                        LINEABE = ObtenerDatosCapturados();

                        LINEABE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        LINEABEAnt.IID = this.ID;

                        LINEAD.CambiarLINEA(LINEABE, LINEABEAnt, null);
                        if (LINEAD.IComentario == "" || LINEAD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + LINEAD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CLINEABE LINEABEAnt = new CLINEABE();
                            LINEABEAnt.IID = this.ID;
                            LINEAD.BorrarLINEA(LINEABEAnt, null);
                            if (LINEAD.IComentario == "" || LINEAD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + LINEAD.IComentario.Replace("%", "\n"));
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


            this.ACUMULAPROMOCIONTextBox.Checked = false;

            this.TIPORECARGATextBox.Text = "";


            this.GPOIMPTextBox.Text = "";


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
