
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
    public partial class WFReporteEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID = 0;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFReporteEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,long pId)
        {
            opc = popc;
            ID = pId;
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
                //this.CLAVETextBox.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                llenarGrid();
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
                CREPORTESD reporteD = new CREPORTESD();
                CREPORTESBE reporteBE = new CREPORTESBE();

                reporteBE.IID = ID;
                reporteBE = reporteD.seleccionarREPORTES(reporteBE, null);

                if (reporteBE == null)
                    return false;

                //this.ID = reporteBE.IID;

                this.IDTextBox.Text = reporteBE.IID.ToString();

                this.NOMBRETextBox.Text = reporteBE.INOMBRE;

                this.ACTIVOTextBox.Checked = (reporteBE.IACTIVO == "S") ? true : false;

                this.ARCHIVOTextBox.Text = reporteBE.IARCHIVO;

                this.DESCRIPCIONTextBox.Text = reporteBE.IDESCRIPCION;

                llenarGrid();

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


        private CREPORTESBE ObtenerDatosCapturados()
        {
            CREPORTESBE REPORTEBE = new CREPORTESBE();
            REPORTEBE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";


            if (this.NOMBRETextBox.Text != "")
            {
                REPORTEBE.INOMBRE = this.NOMBRETextBox.Text.ToString();
            }

            if (this.ARCHIVOTextBox.Text != "")
            {
                REPORTEBE.IARCHIVO = this.ARCHIVOTextBox.Text.ToString();
            }


            if (this.DESCRIPCIONTextBox.Text != "")
            {
                REPORTEBE.IDESCRIPCION = this.DESCRIPCIONTextBox.Text.ToString();
            }



            return REPORTEBE;

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
                    CREPORTESD REPORTED = new CREPORTESD();

                    if (opc == "Agregar")
                    {
                        CREPORTESBE REPORTEBE = new CREPORTESBE();
                        REPORTEBE = ObtenerDatosCapturados();

                        REPORTEBE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        REPORTEBE = REPORTED.AgregarREPORTES(REPORTEBE, null);

                        if (REPORTED.IComentario == "" || REPORTED.IComentario == null)
                        {

                            if (SaveChangesPerfilesReportes(REPORTEBE.IID, null))
                            {
                                MessageBox.Show("El registro se ha insertado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);
                                this.Close();
                            }
                            else
                                MessageBox.Show("ERRORES: " + REPORTED.IComentario.Replace("%", "\n"));

                        }
                        else
                            MessageBox.Show("ERRORES: " + REPORTED.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CREPORTESBE REPORTEBEAnt = new CREPORTESBE();

                        CREPORTESBE REPORTEBE = new CREPORTESBE();

                        REPORTEBE = ObtenerDatosCapturados();

                        REPORTEBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        REPORTEBEAnt.IID = this.ID;

                        REPORTED.CambiarREPORTES(REPORTEBE, REPORTEBEAnt, null);
                        if (REPORTED.IComentario == "" || REPORTED.IComentario == null)
                        {
                            if (SaveChangesPerfilesReportes(this.ID, null))
                            {

                                MessageBox.Show("El registro se ha cambiado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);


                                this.Close();
                            }

                        }
                        else
                            MessageBox.Show("ERRORES: " + REPORTED.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CREPORTESBE REPORTEBEAnt = new CREPORTESBE();
                            REPORTEBEAnt.IID = this.ID;
                            REPORTED.BorrarREPORTES(REPORTEBEAnt, null);

                            CPERFIL_REPOBE oUPerBe = new CPERFIL_REPOBE();
                            CPERFIL_REPOD oUPerD = new CPERFIL_REPOD();
                            oUPerBe.IREPORTE = (int)this.ID;
                            oUPerD.BorrarPERFIL_REPOD(oUPerBe, null);


                            if (REPORTED.IComentario == "" || REPORTED.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + REPORTED.IComentario.Replace("%", "\n"));
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




        public Boolean SaveChangesPerfilesReportes(long iId, FbTransaction fTrans)
        {
            CPERFIL_REPOBE oUPerBe = new CPERFIL_REPOBE();
            CPERFIL_REPOD oUPerD = new CPERFIL_REPOD();
            if (iId == -1)
            {
                return false;
            }
            try
            {

                oUPerBe.IREPORTE = (int)iId;
                oUPerD.BorrarPorReportePERFIL_REPOD(oUPerBe, fTrans);
                foreach (DataGridViewRow dataRow in this.pERFILREPORTEDataGridView.Rows)
                {
                    if (
                        dataRow.Cells["dgPermitido"].Value != null
                        && dataRow.Cells["dgPermitido"].Value != DBNull.Value
                        && ((int)dataRow.Cells["dgPermitido"].Value == 1))
                    {


                        if (dataRow.Cells["dgPerfil"].Value != null
                            && dataRow.Cells["dgPerfil"].Value != DBNull.Value)
                        {
                            oUPerBe = new CPERFIL_REPOBE();
                            oUPerBe.IREPORTE = (int)iId;
                            oUPerBe.IPERFIL = (int)dataRow.Cells["dgPerfil"].Value;
                            oUPerD.AgregarPERFIL_REPOD(oUPerBe, fTrans);
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
        }

        private void Limpiar()
        {
            Limpiar(false);
        }

        private void Limpiar(bool bLimpiarKeys)
        {
           
            this.ACTIVOTextBox.Checked = false;

            this.NOMBRETextBox.Text = "";
            this.ARCHIVOTextBox.Text = "";
            this.DESCRIPCIONTextBox.Text = "";

        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.ID != 0 )
            {

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
            //SetMode();
        }


        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            //this.IDTextBox.Focus();
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

        private void llenarGrid()
        {
            try
            {
                this.pERFILREPORTETableAdapter.Fill(this.dSAccessControl.PERFILREPORTE, ID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    }
}
