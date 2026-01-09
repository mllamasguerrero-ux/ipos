
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
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFAreaEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        string CLAVE;
        public delegate void AccionHandler(object source, Hashtable evtArgs);
        int AR_AREA;

        public WFAreaEdit()
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
                    this.aREADERECHOSDataGridView.ReadOnly = true;
                }
                else { HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; }
                LlenarDatosDeBase();
                this.CLAVETextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
                this.aREADERECHOSDataGridView.ReadOnly = false;
            }
        }



        private void AREAEdit_Reg_Load(object sender, EventArgs e)
        {
            aREADERECHOSDataGridView.DefaultCellStyle.ForeColor = Color.Black;
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CAREAD areaD = new CAREAD();
                CAREABE areaBE = new CAREABE();

                areaBE.ICLAVE = CLAVE;
                areaBE = areaD.seleccionarAREAXCLAVE(areaBE, null);

                if (areaBE == null)
                    return false;

                this.ID = areaBE.IID;

                //this.AR_AREA = int.Parse(areaBE.IIDAREA.ToString()); 

                this.CLAVETextBox.Text = areaBE.ICLAVE;

                this.NOMBRETextBox.Text = areaBE.INOMBREAREA;


                this.ACTIVOTextBox.Checked = (areaBE.IACTIVO == "S") ? true : false;

                LlenarGrid((int)this.ID);

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


        private void LlenarGrid(Int32 iAreaId)
        {
            try
            {
                this.aREADERECHOSTableAdapter.Fill(this.dSCatalogos.AREADERECHOS, iAreaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private CAREABE ObtenerDatosCapturados()
        {
            CAREABE AREABE = new CAREABE();
            AREABE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";

            if (this.CLAVETextBox.Text != "")
            {
                AREABE.ICLAVE = this.CLAVETextBox.Text.ToString();
            }


            if (this.NOMBRETextBox.Text != "")
            {
                AREABE.INOMBREAREA = this.NOMBRETextBox.Text.ToString();
            }

            return AREABE;

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
                    CAREAD AREAD = new CAREAD();

                    if (opc == "Agregar")
                    {
                        CAREABE AREABE = new CAREABE();
                        AREABE = ObtenerDatosCapturados();

                        AREAD.AgregarAREA(AREABE, null);
                        this.AR_AREA = int.Parse(AREABE.IIDAREA.ToString());
                        this.GuardarDerechos((int)this.ID, null);


                        if (AREAD.IComentario == "" || AREAD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + AREAD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CAREABE AREABEAnt = new CAREABE();

                        CAREABE AREABE = new CAREABE();

                        AREABE = ObtenerDatosCapturados();

                        AREABE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        AREABEAnt.IID = this.ID;

                        AREAD.CambiarAREA(AREABE, AREABEAnt, null);
                        this.AR_AREA = int.Parse(AREABE.IIDAREA.ToString());
                        this.GuardarDerechos((int)this.ID, null);
                        
                        if (AREAD.IComentario == "" || AREAD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + AREAD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CAREABE AREABEAnt = new CAREABE();
                            AREABEAnt.IID = this.ID;
                            AREAD.BorrarAREA(AREABEAnt, null);
                            if (AREAD.IComentario == "" || AREAD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + AREAD.IComentario.Replace("%", "\n"));
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




        public Boolean GuardarDerechos(Int32 iAreaId, FbTransaction fTrans)
        {
            CAREADERECHOSBE oUPerBe = new CAREADERECHOSBE();
            CAREADERECHOSD oUPerD = new CAREADERECHOSD();

            if (iAreaId == -1)
            {
                return false;
            }

            try
            {

                oUPerBe.IIDAREA = iAreaId;
                oUPerD.BorrarDerechosDeArea(oUPerBe, fTrans);
                foreach (DataGridViewRow dataRow in this.aREADERECHOSDataGridView.Rows)
                {
                    if (
                        dataRow.Cells["dgPermitido"].Value != null
                        && dataRow.Cells["dgPermitido"].Value != DBNull.Value
                        && ((int)dataRow.Cells["dgPermitido"].Value == 1))
                    {


                        if (dataRow.Cells["dgDerecho"].Value != null
                            && dataRow.Cells["dgDerecho"].Value != DBNull.Value)
                        {
                            oUPerBe = new CAREADERECHOSBE();
                            oUPerBe.IIDAREA = iAreaId;
                            oUPerBe.IIDDERECHO = (int)dataRow.Cells["dgDerecho"].Value;
                            oUPerD.AgregarAREADERECHOS(oUPerBe, fTrans);
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
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
                    MessageBox.Show("No existe una area con esa clave");
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
