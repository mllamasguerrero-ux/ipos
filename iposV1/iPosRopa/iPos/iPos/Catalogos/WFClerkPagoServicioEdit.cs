
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
    public partial class WFClerkPagoServicioEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFClerkPagoServicioEdit()
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
                this.CLERKIDTextBox.Enabled = false;
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
                CCLERKPAGOSERVICIOD clerkPagoServicioD = new CCLERKPAGOSERVICIOD();
                CCLERKPAGOSERVICIOBE clerkPagoServicioBE = new CCLERKPAGOSERVICIOBE();

                clerkPagoServicioBE.IID = ID;
                clerkPagoServicioBE = clerkPagoServicioD.seleccionarCLERKPAGOSERVICIO(clerkPagoServicioBE, null);

                if (clerkPagoServicioBE == null)
                    return false;

                this.ID = clerkPagoServicioBE.IID;

                this.CLERKIDTextBox.Text = clerkPagoServicioBE.ICLERKID;

                CLAVE = clerkPagoServicioBE.ICLERKID; 


                string strBuffer = "";
                if (!(bool)clerkPagoServicioBE.isnull["ISUCURSALID"])
                {
                    this.SUCURSALIDTextBox.DbValue = clerkPagoServicioBE.ISUCURSALID.ToString();
                    this.SUCURSALIDTextBox.MostrarErrores = false;
                    this.SUCURSALIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SUCURSALIDTextBox.MostrarErrores = true;
                }



                this.ACTIVOTextBox.Checked = (clerkPagoServicioBE.IACTIVO == "S") ? true : false;

                this.ESSERVICIOTextBox.Checked = (clerkPagoServicioBE.IESSERVICIO == "S") ? true : false;

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


        private CCLERKPAGOSERVICIOBE ObtenerDatosCapturados()
        {
            CCLERKPAGOSERVICIOBE CLERKPAGOSERVICIOBE = new CCLERKPAGOSERVICIOBE();
            CLERKPAGOSERVICIOBE.IACTIVO = (this.ACTIVOTextBox.Checked) ? "S" : "N";
            CLERKPAGOSERVICIOBE.IESSERVICIO = (this.ESSERVICIOTextBox.Checked) ? "S" : "N";

            if (this.CLERKIDTextBox.Text != "")
            {
                CLERKPAGOSERVICIOBE.ICLERKID = this.CLERKIDTextBox.Text.ToString();
            }


            if (this.SUCURSALIDTextBox.Text != "")
            {
                CLERKPAGOSERVICIOBE.ISUCURSALID = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
                CLERKPAGOSERVICIOBE.ISUCURSALCLAVE = this.SUCURSALIDTextBox.Text;
            }

            return CLERKPAGOSERVICIOBE;

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
                    CCLERKPAGOSERVICIOD CLERKPAGOSERVICIOD = new CCLERKPAGOSERVICIOD();

                    if (opc == "Agregar")
                    {
                        CCLERKPAGOSERVICIOBE CLERKPAGOSERVICIOBE = new CCLERKPAGOSERVICIOBE();
                        CLERKPAGOSERVICIOBE = ObtenerDatosCapturados();

                        CLERKPAGOSERVICIOBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        CLERKPAGOSERVICIOD.AgregarCLERKPAGOSERVICIOD(CLERKPAGOSERVICIOBE, null);

                        if (CLERKPAGOSERVICIOD.IComentario == "" || CLERKPAGOSERVICIOD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + CLERKPAGOSERVICIOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CCLERKPAGOSERVICIOBE CLERKPAGOSERVICIOBEAnt = new CCLERKPAGOSERVICIOBE();

                        CCLERKPAGOSERVICIOBE CLERKPAGOSERVICIOBE = new CCLERKPAGOSERVICIOBE();

                        CLERKPAGOSERVICIOBE = ObtenerDatosCapturados();

                        CLERKPAGOSERVICIOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        CLERKPAGOSERVICIOBEAnt.IID = this.ID;

                        CLERKPAGOSERVICIOD.CambiarCLERKPAGOSERVICIOD(CLERKPAGOSERVICIOBE, CLERKPAGOSERVICIOBEAnt, null);
                        if (CLERKPAGOSERVICIOD.IComentario == "" || CLERKPAGOSERVICIOD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + CLERKPAGOSERVICIOD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CCLERKPAGOSERVICIOBE CLERKPAGOSERVICIOBEAnt = new CCLERKPAGOSERVICIOBE();
                            CLERKPAGOSERVICIOBEAnt.IID = this.ID;
                            CLERKPAGOSERVICIOD.BorrarCLERKPAGOSERVICIOD(CLERKPAGOSERVICIOBEAnt, null);
                            if (CLERKPAGOSERVICIOD.IComentario == "" || CLERKPAGOSERVICIOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + CLERKPAGOSERVICIOD.IComentario.Replace("%", "\n"));
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

            this.CLERKIDTextBox.Text = "";


            this.SUCURSALIDTextBox.Text = "";




        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.CLERKIDTextBox.Text != "" )
            {
                this.CLAVE = this.CLERKIDTextBox.Text;

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
            this.CLERKIDTextBox.Focus();
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
                this.CLAVE = CLERKIDTextBox.Text;
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
