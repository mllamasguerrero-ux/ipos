
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
    public partial class WFVehiculoEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFVehiculoEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,long lID)
        {
            opc = popc;
            ID = lID;
            validadores = new System.Collections.ArrayList();

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
            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; 
            }
        }



        private void VEHICULOEdit_Reg_Load(object sender, EventArgs e)
        {
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                string strBuffer = "";

                CVEHICULOD vehiculoD = new CVEHICULOD();
                CVEHICULOBE vehiculoBE = new CVEHICULOBE();

                vehiculoBE.IID = ID;
                vehiculoBE = vehiculoD.seleccionarVEHICULO(vehiculoBE, null);

                if (vehiculoBE == null)
                    return false;

                this.ID = vehiculoBE.IID;
                this.ACTIVOTextBox.Checked = (vehiculoBE.IACTIVO == "S") ? true : false;




                if (!(bool)vehiculoBE.isnull["ISAT_TIPOPERMISOID"])
                {
                    this.SAT_TIPOPERMISOIDTextBox.DbValue = vehiculoBE.ISAT_TIPOPERMISOID.ToString();
                    this.SAT_TIPOPERMISOIDTextBox.MostrarErrores = false;
                    this.SAT_TIPOPERMISOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_TIPOPERMISOIDTextBox.MostrarErrores = true;
                }



                this.NUMPERMISOSCTTextBox.Text = vehiculoBE.INUMPERMISOSCT;


                if (!(bool)vehiculoBE.isnull["ISAT_CONFIGAUTOTRANSPORTEID"])
                {
                    this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.DbValue = vehiculoBE.ISAT_CONFIGAUTOTRANSPORTEID.ToString();
                    this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.MostrarErrores = false;
                    this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.MostrarErrores = true;
                }


                this.PLACAVMTextBox.Text = vehiculoBE.IPLACAVM;

                this.ANIOMODELOVMTextBox.Text = vehiculoBE.IANIOMODELOVM;

                this.ASEGURARESPCIVILTextBox.Text = vehiculoBE.IASEGURARESPCIVIL;

                this.POLIZARESPCIVILTextBox.Text = vehiculoBE.IPOLIZARESPCIVIL;

                this.ASEGURAMEDAMBIENTETextBox.Text = vehiculoBE.IASEGURAMEDAMBIENTE;

                this.POLIZAMEDAMBIENTETextBox.Text = vehiculoBE.IPOLIZAMEDAMBIENTE;

                this.ASEGURACARGATextBox.Text = vehiculoBE.IASEGURACARGA;

                this.POLIZACARGATextBox.Text = vehiculoBE.IPOLIZACARGA;

                this.PRIMASEGUROTextBox.Text = vehiculoBE.IPRIMASEGURO;

                if (!(bool)vehiculoBE.isnull["ISAT_SUBTIPOREM1ID"])
                {
                    this.SAT_SUBTIPOREM1IDTextBox.DbValue = vehiculoBE.ISAT_SUBTIPOREM1ID.ToString();
                    this.SAT_SUBTIPOREM1IDTextBox.MostrarErrores = false;
                    this.SAT_SUBTIPOREM1IDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_SUBTIPOREM1IDTextBox.MostrarErrores = true;
                }



                this.PLACA1TextBox.Text = vehiculoBE.IPLACA1;


                if (!(bool)vehiculoBE.isnull["ISAT_SUBTIPOREM2ID"])
                {
                    this.SAT_SUBTIPOREM2IDTextBox.DbValue = vehiculoBE.ISAT_SUBTIPOREM2ID.ToString();
                    this.SAT_SUBTIPOREM2IDTextBox.MostrarErrores = false;
                    this.SAT_SUBTIPOREM2IDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SAT_SUBTIPOREM2IDTextBox.MostrarErrores = true;
                }


                this.PLACA2TextBox.Text = vehiculoBE.IPLACA2;


                if (!(bool)vehiculoBE.isnull["IDUENIOID"])
                {
                    this.DUENIOIDTextBox.DbValue = vehiculoBE.IDUENIOID.ToString();
                    this.DUENIOIDTextBox.MostrarErrores = false;
                    this.DUENIOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.DUENIOIDTextBox.MostrarErrores = true;
                }


                if (!(bool)vehiculoBE.isnull["IPESOBRUTOVEHICULAR"])
                    this.PESOBRUTOVEHICULARTextBox.Text = vehiculoBE.IPESOBRUTOVEHICULAR.ToString();

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


        private CVEHICULOBE ObtenerDatosCapturados()
        {
            CVEHICULOBE VEHICULOBE = new CVEHICULOBE();
            VEHICULOBE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";
            
            if (this.ACTIVOTextBox.Text != "")
            {
                VEHICULOBE.IACTIVO = this.ACTIVOTextBox.Text.ToString();
            }
            


            if (this.NUMPERMISOSCTTextBox.Text != "")
            {
                VEHICULOBE.INUMPERMISOSCT = this.NUMPERMISOSCTTextBox.Text.ToString();
            }


            if (this.PLACAVMTextBox.Text != "")
            {
                VEHICULOBE.IPLACAVM = this.PLACAVMTextBox.Text.ToString();
            }


            if (this.ANIOMODELOVMTextBox.Text != "")
            {
                VEHICULOBE.IANIOMODELOVM = this.ANIOMODELOVMTextBox.Text.ToString();
            }


            if (this.ASEGURARESPCIVILTextBox.Text != "")
            {
                VEHICULOBE.IASEGURARESPCIVIL = this.ASEGURARESPCIVILTextBox.Text.ToString();
            }


            if (this.POLIZARESPCIVILTextBox.Text != "")
            {
                VEHICULOBE.IPOLIZARESPCIVIL = this.POLIZARESPCIVILTextBox.Text.ToString();
            }


            if (this.ASEGURAMEDAMBIENTETextBox.Text != "")
            {
                VEHICULOBE.IASEGURAMEDAMBIENTE = this.ASEGURAMEDAMBIENTETextBox.Text.ToString();
            }


            if (this.POLIZAMEDAMBIENTETextBox.Text != "")
            {
                VEHICULOBE.IPOLIZAMEDAMBIENTE = this.POLIZAMEDAMBIENTETextBox.Text.ToString();
            }


            if (this.ASEGURACARGATextBox.Text != "")
            {
                VEHICULOBE.IASEGURACARGA = this.ASEGURACARGATextBox.Text.ToString();
            }


            if (this.POLIZACARGATextBox.Text != "")
            {
                VEHICULOBE.IPOLIZACARGA = this.POLIZACARGATextBox.Text.ToString();
            }


            if (this.PRIMASEGUROTextBox.Text != "")
            {
                VEHICULOBE.IPRIMASEGURO = this.PRIMASEGUROTextBox.Text.ToString();
            }


            if (this.PLACA1TextBox.Text != "")
            {
                VEHICULOBE.IPLACA1 = this.PLACA1TextBox.Text.ToString();
            }


            if (this.PLACA2TextBox.Text != "")
            {
                VEHICULOBE.IPLACA2 = this.PLACA2TextBox.Text.ToString();
            }



            if (this.SAT_TIPOPERMISOIDTextBox.Text != "")
            {
                VEHICULOBE.ISAT_TIPOPERMISOID = Int64.Parse(this.SAT_TIPOPERMISOIDTextBox.DbValue.ToString());
            }



            if (this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Text != "")
            {
                VEHICULOBE.ISAT_CONFIGAUTOTRANSPORTEID = Int64.Parse(this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.DbValue.ToString());
            }


            if (this.SAT_SUBTIPOREM1IDTextBox.Text != "")
            {
                VEHICULOBE.ISAT_SUBTIPOREM1ID = Int64.Parse(this.SAT_SUBTIPOREM1IDTextBox.DbValue.ToString());
            }


            if (this.SAT_SUBTIPOREM2IDTextBox.Text != "")
            {
                VEHICULOBE.ISAT_SUBTIPOREM2ID = Int64.Parse(this.SAT_SUBTIPOREM2IDTextBox.DbValue.ToString());
            }


            if (this.DUENIOIDTextBox.Text != "")
            {
                VEHICULOBE.IDUENIOID = Int64.Parse(this.DUENIOIDTextBox.DbValue.ToString());
            }


            if (this.PESOBRUTOVEHICULARTextBox.Text != "")
            {
                VEHICULOBE.IPESOBRUTOVEHICULAR = long.Parse(this.PESOBRUTOVEHICULARTextBox.Text.Replace(",","").ToString());
            }

            return VEHICULOBE;

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
                    CVEHICULOD VEHICULOD = new CVEHICULOD();

                    if (opc == "Agregar")
                    {
                        CVEHICULOBE VEHICULOBE = new CVEHICULOBE();
                        VEHICULOBE = ObtenerDatosCapturados();

                        VEHICULOD.AgregarVEHICULO(VEHICULOBE, null);

                        if (VEHICULOD.IComentario == "" || VEHICULOD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + VEHICULOD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CVEHICULOBE VEHICULOBEAnt = new CVEHICULOBE();

                        CVEHICULOBE VEHICULOBE = new CVEHICULOBE();

                        VEHICULOBE = ObtenerDatosCapturados();

                        VEHICULOBE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        VEHICULOBEAnt.IID = this.ID;

                        VEHICULOD.CambiarVEHICULO(VEHICULOBE, VEHICULOBEAnt, null);
                        if (VEHICULOD.IComentario == "" || VEHICULOD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + VEHICULOD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CVEHICULOBE VEHICULOBEAnt = new CVEHICULOBE();
                            VEHICULOBEAnt.IID = this.ID;
                            VEHICULOD.BorrarVEHICULO(VEHICULOBEAnt, null);
                            if (VEHICULOD.IComentario == "" || VEHICULOD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + VEHICULOD.IComentario.Replace("%", "\n"));
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
        }

        private void Limpiar()
        {
            Limpiar(false);
        }

        private void Limpiar(bool bLimpiarKeys)
        {
           
            this.ACTIVOTextBox.Checked = false;
            


            this.SAT_TIPOPERMISOIDTextBox.Text = "";


            this.NUMPERMISOSCTTextBox.Text = "";


            this.SAT_CONFIGAUTOTRANSPORTEIDTextBox.Text = "";


            this.PLACAVMTextBox.Text = "";


            this.ANIOMODELOVMTextBox.Text = "";


            this.ASEGURARESPCIVILTextBox.Text = "";


            this.POLIZARESPCIVILTextBox.Text = "";


            this.ASEGURAMEDAMBIENTETextBox.Text = "";


            this.POLIZAMEDAMBIENTETextBox.Text = "";


            this.ASEGURACARGATextBox.Text = "";


            this.POLIZACARGATextBox.Text = "";


            this.PRIMASEGUROTextBox.Text = "";


            this.SAT_SUBTIPOREM1IDTextBox.Text = "";


            this.PLACA1TextBox.Text = "";


            this.SAT_SUBTIPOREM2IDTextBox.Text = "";


            this.PLACA2TextBox.Text = "";

            this.DUENIOIDTextBox.Text = "";

            this.PESOBRUTOVEHICULARTextBox.Text = "0";

        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        

        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            //this.IDTextBox.Focus();
            this.ACTIVOTextBox.Focus();
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
