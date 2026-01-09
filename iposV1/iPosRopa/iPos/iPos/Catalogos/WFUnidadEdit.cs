
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
    public partial class WFUnidadEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFUnidadEdit()
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
                CUNIDADD unidadD = new CUNIDADD();
                CUNIDADBE unidadBE = new CUNIDADBE();

                unidadBE.ICLAVE = CLAVE;
                unidadBE = unidadD.seleccionarUNIDADxCLAVE(unidadBE, null);

                if (unidadBE == null)
                    return false;

                this.ID = unidadBE.IID;

                this.CLAVETextBox.Text = unidadBE.ICLAVE;

                this.NOMBRETextBox.Text = unidadBE.INOMBRE;

                this.ACTIVOTextBox.Checked = (unidadBE.IACTIVO == "S") ? true : false;

                this.CANTIDADDECIMALESTextBox.Value = !(bool)unidadBE.isnull["ICANTIDADDECIMALES"] ? unidadBE.ICANTIDADDECIMALES : 2;

                string strBuffer = "";
                if (unidadBE.ISAT_UNIDADMEDIDAID != 0)
                {
                    this.UNIDADSATIDTextBox.DbValue = unidadBE.ISAT_UNIDADMEDIDAID.ToString();
                    this.UNIDADSATIDTextBox.MostrarErrores = false;
                    this.UNIDADSATIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.UNIDADSATIDTextBox.MostrarErrores = true;
                    //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                }
                else
                {
                    this.UNIDADSATIDTextBox.Text = "";
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


        private CUNIDADBE ObtenerDatosCapturados()
        {
            CUNIDADBE UNIDADBE = new CUNIDADBE();
            UNIDADBE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                UNIDADBE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                UNIDADBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }


            UNIDADBE.ICANTIDADDECIMALES = (short)this.CANTIDADDECIMALESTextBox.Value;

            if (this.UNIDADSATIDTextBox.Text != "")
            {
                UNIDADBE.ISAT_UNIDADMEDIDAID = Int64.Parse(this.UNIDADSATIDTextBox.DbValue.ToString());
            }

            return UNIDADBE;

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
                    CUNIDADD UNIDADD = new CUNIDADD();

                    if (opc == "Agregar")
                    {
                        CUNIDADBE UNIDADBE = new CUNIDADBE();
                        UNIDADBE = ObtenerDatosCapturados();

                        UNIDADBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        UNIDADD.AgregarUNIDAD(UNIDADBE, null);

                        if (UNIDADD.IComentario == "" || UNIDADD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + UNIDADD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CUNIDADBE UNIDADBEAnt = new CUNIDADBE();

                        CUNIDADBE UNIDADBE = new CUNIDADBE();

                        UNIDADBE = ObtenerDatosCapturados();

                        UNIDADBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        UNIDADBEAnt.IID = this.ID;

                        UNIDADD.CambiarUNIDAD(UNIDADBE, UNIDADBEAnt, null);
                        if (UNIDADD.IComentario == "" || UNIDADD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + UNIDADD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CUNIDADBE UNIDADBEAnt = new CUNIDADBE();
                            UNIDADBEAnt.IID = this.ID;
                            UNIDADD.BorrarUNIDAD(UNIDADBEAnt, null);
                            if (UNIDADD.IComentario == "" || UNIDADD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + UNIDADD.IComentario.Replace("%", "\n"));
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

            this.CANTIDADDECIMALESTextBox.Value = 2;



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
