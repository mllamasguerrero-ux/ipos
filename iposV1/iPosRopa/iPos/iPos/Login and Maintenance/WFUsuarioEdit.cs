
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
using System.Printing;
using System.Linq;

namespace iPos
{
    public partial class WFUsuarioEdit : IposForm
    {
        string opc;
        System.Collections.ArrayList validadores;
        long m_personaId;//US_USERID
        string m_password = "";
        short m_resetPass = 0;

        public WFUsuarioEdit()
        {
            InitializeComponent();
        }
        public void ReCargar(string popc,long  personaId)
        {
            opc = popc;
            m_personaId = personaId;
            validadores = new System.Collections.ArrayList();
            
            validadores.Add((RFV_US_USUARIO));
            
            
            //validadores.Add(RAV_US_LIMITE_CONEXIONES);
            //validadores.Add(RAV_US_CONEXIONES_ABIERTAS);
            this.button1.Text = opc;
            
            if (this.opc != "Agregar")
            {
                if (this.opc == "Consultar")
                {
                    this.button1.Visible = false; panel1.Enabled = false; this.BTCambiarPassword.Visible = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.Exit;
                }
                else { this.BTCambiarPassword.Visible = true; }
                
                LlenarDatosDeBase();
                llenarGrid((int)m_personaId);
                this.US_USERNAMETextBox.Enabled = false;
            }



        }
        private void USUARIOSEdit_Load(object sender, EventArgs e)
        {

        }

        private bool LlenarDatosDeBase()
        {
            try
            {

                this.ALMACENComboBox.llenarDatos();
                CPERSONAD usuarioD = new CPERSONAD();
                CPERSONABE usuarioBE = new CPERSONABE();

                usuarioBE.IID = m_personaId;
                usuarioBE = usuarioD.seleccionarPERSONA(usuarioBE, null);

                if (usuarioBE == null)
                    return false;

                if (usuarioBE.ICLAVEACCESO != null && usuarioBE.ICLAVEACCESO != "")
                {
                    //m_password = iPos.EncDec.Decrypt(usuarioBE.ICLAVEACCESO, "DryHit");
                    m_password = iPos.EncDec.Decrypt(usuarioBE.ICLAVEACCESO, "DryHit" + usuarioBE.IUSERNAME.Trim());
                }
                else
                {
                    m_password = usuarioBE.ICLAVEACCESO;
                }

                m_resetPass = usuarioBE.IRESET_PASS;


                //this.FbCommand1.Parameters["@US_USERID"].Value = this.m_personaId;
                //DataTable dt = new DataTable();
                //dt = DataTablesParaGrid.GetData(this.FbCommand1);
                //this.US_USERIDTextBox.Text = dt.Rows[0]["ID"].ToString();
                //this.US_USUARIOTextBox.Text = dt.Rows[0]["USERNAME"].ToString();
                //this.US_PASSWORDTextBox.Text = dt.Rows[0]["CLAVEACCESO"].ToString();


                if(!(bool)usuarioBE.isnull["IUSERNAME"])
                    this.US_USERNAMETextBox.Text = usuarioBE.IUSERNAME;
                if (!(bool)usuarioBE.isnull["INOMBRE"])
                    this.US_NOMBRETextBox.Text = usuarioBE.INOMBRE;
                if (!(bool)usuarioBE.isnull["IGAFFETE"])
                    this.US_GAFFETETextBox.Text = usuarioBE.IGAFFETE;

                //this.US_VENDEDORTextBox.Text = dt.Rows[0]["US_VENDEDOR"].ToString();
                //this.US_EMPRESATextBox.Text = dt.Rows[0]["US_EMPRESA"].ToString();
                //this.US_R_PASSWORDTextBox.Text = dt.Rows[0]["RESET_PASS"].ToString();
                //this.US_LIMITE_CONEXIONESTextBox.Text = dt.Rows[0]["US_LIMITE_CONEXIONES"].ToString();
                //this.US_CONEXIONES_ABIERTASTextBox.Text = dt.Rows[0]["US_CONEXIONES_ABIERTAS"].ToString();
                try
                {
                    this.US_VIGENCIATextBox.Value = usuarioBE.IVIGENCIA;
                }
                catch
                {
                }
                //this.US_ALMACENIDTextBox.Text = dt.Rows[0]["US_ALMACENID"].ToString();

                if (!(bool)usuarioBE.isnull["ILISTAPRECIOID"])
                {
                    this.LISTAPRECIOIDTextBox.Text = usuarioBE.ILISTAPRECIOID.ToString();
                }
                else
                {
                    this.LISTAPRECIOIDTextBox.Text = "";
                }


                this.TICKETLARGOTextBox.Checked = (usuarioBE.ITICKETLARGO == "S") ? true : false;


                object value = this.ALMACENComboBox.SelectedItem;

                bool condition = (bool)usuarioBE.isnull["IALMACENID"];

                if (!(bool)usuarioBE.isnull["IALMACENID"])

                    this.ALMACENComboBox.SelectedDataValue = usuarioBE.IALMACENID;
                else
                    this.ALMACENComboBox.SelectedIndex = -1;




                if (!(bool)usuarioBE.isnull["ICAJASBOTELLAS"])
                    this.CAJASBOTELLASTextBox.Text = usuarioBE.ICAJASBOTELLAS;
                else
                    this.CAJASBOTELLASTextBox.Text = "";


                this.TICKETLARGOCREDITOTextBox.Checked = (usuarioBE.ITICKETLARGOCREDITO == "S") ? true : false;


                string strBuffer = "";
                if (!(bool)usuarioBE.isnull["IVENDEDORID"])
                {
                    this.VENDEDORIDTextBox.DbValue = usuarioBE.IVENDEDORID.ToString();
                    this.VENDEDORIDTextBox.MostrarErrores = false;
                    this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.VENDEDORIDTextBox.MostrarErrores = true;
                    //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                }
                else
                {
                    this.VENDEDORIDTextBox.Text = "";
                }


                if (!(bool)usuarioBE.isnull["IPENDMAXDIAS"])
                    this.PENDMAXDIASTextBox.Text = usuarioBE.IPENDMAXDIAS.ToString();
                else
                    this.PENDMAXDIASTextBox.Text = "";


                if (!(bool)usuarioBE.isnull["IGRUPOUSUARIOID"])
                {
                    this.GRUPOUSUARIOIDTextBox.DbValue = usuarioBE.IGRUPOUSUARIOID.ToString();
                    this.GRUPOUSUARIOIDTextBox.MostrarErrores = false;
                    this.GRUPOUSUARIOIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.GRUPOUSUARIOIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.GRUPOUSUARIOIDTextBox.Text = "";
                }



                if (!(bool)usuarioBE.isnull["ICLERKPAGOSERVICIOSID"])
                {
                    this.CLERKIDTextBox.DbValue = usuarioBE.ICLERKPAGOSERVICIOSID.ToString();
                    this.CLERKIDTextBox.MostrarErrores = false;
                    this.CLERKIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.CLERKIDTextBox.MostrarErrores = true;
                }
                else
                {
                    this.CLERKIDTextBox.Text = "";
                }



                if (!(bool)usuarioBE.isnull["ICLERKSERVICIOS"])
                {
                    this.CLERKSERVICIOSTextBox.DbValue = usuarioBE.ICLERKSERVICIOS.ToString();
                    this.CLERKSERVICIOSTextBox.MostrarErrores = false;
                    this.CLERKSERVICIOSTextBox.MValidarEntrada(out strBuffer, 1);
                    this.CLERKSERVICIOSTextBox.MostrarErrores = true;
                }
                else
                {
                    this.CLERKSERVICIOSTextBox.Text = "";
                }

                if (!(bool)usuarioBE.isnull["IEMAIL1"])
                    this.EMAIL1TextBox.Text = usuarioBE.IEMAIL1;


                this.TICKETLARGOCOTIZACIONTextBox.Checked = (usuarioBE.ITICKETLARGOCOTIZACION == "S") ? true : false;

                if (!(bool)usuarioBE.isnull["ICODIGOAUTORIZACION"])
                    this.CODIGOAUTORIZACIONTextBox.Text = usuarioBE.ICODIGOAUTORIZACION;

                if (!(bool)usuarioBE.isnull["INOMBREIMPRESORA"])
                    this.NOMBREIMPRESORATextBox.Text = usuarioBE.INOMBREIMPRESORA;

                putValuesFPClientesCreados(usuarioBE.ICLIEFORMASPAGODEF);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //System.Threading.Thread.CurrentThread.Abort();
                return false;
            }

            return true;
        }
        private CPERSONABE ObtenerDatosCapturados()
        {
            CPERSONABE USUARIOSBE = new CPERSONABE();
            if (this.US_USERNAMETextBox.Text != "")
            {
                USUARIOSBE.IUSERNAME = this.US_USERNAMETextBox.Text.ToString();
                USUARIOSBE.ICLAVE = this.US_USERNAMETextBox.Text.ToString();
            }
            //if (this.US_PASSWORDTextBox.Text != "")
            //{
            //    USUARIOSBE.ICLAVEACCESO = this.US_PASSWORDTextBox.Text.ToString();
            //}
            USUARIOSBE.ICLAVEACCESO = m_password;
            if (this.US_NOMBRETextBox.Text != "")
            {
                USUARIOSBE.INOMBRE = this.US_NOMBRETextBox.Text.ToString();
            }


            if (this.US_GAFFETETextBox.Text != "")
            {
                USUARIOSBE.IGAFFETE = this.US_GAFFETETextBox.Text.ToString();
            }

            //if (this.US_VENDEDORTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_VENDEDOR = this.US_VENDEDORTextBox.Text.ToString();
            //}
            //if (this.US_EMPRESATextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_EMPRESA = this.US_EMPRESATextBox.Text.ToString();
            //}
            USUARIOSBE.IRESET_PASS = m_resetPass;

            USUARIOSBE.IID = m_personaId;

            //if (this.US_USERIDTextBox.Text != "")
            //{
            //    USUARIOSBE.IID = long.Parse(this.US_USERIDTextBox.Text.ToString());
            //}
            //if (this.US_LIMITE_CONEXIONESTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_LIMITE_CONEXIONES = long.Parse(this.US_LIMITE_CONEXIONESTextBox.Text.ToString());
            //}
            //if (this.US_CONEXIONES_ABIERTASTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_CONEXIONES_ABIERTAS = long.Parse(this.US_CONEXIONES_ABIERTASTextBox.Text.ToString());
            //}
            USUARIOSBE.IVIGENCIA = this.US_VIGENCIATextBox.Value;
            //if (this.US_ALMACENIDTextBox.Text != "")
            //{
            //    USUARIOSBE.IUS_ALMACENID = Int32.Parse(this.US_ALMACENIDTextBox.Text.ToString());
            //}

            if (this.LISTAPRECIOIDTextBox.Text != "")
            {
                USUARIOSBE.ILISTAPRECIOID = Int64.Parse(this.LISTAPRECIOIDTextBox.Text.ToString());
            }

            USUARIOSBE.ITICKETLARGO = (this.TICKETLARGOTextBox.Checked) ? "S" : "N";

            try
            {
                USUARIOSBE.IALMACENID = long.Parse(this.ALMACENComboBox.SelectedValue.ToString());
            }
            catch
            {
                USUARIOSBE.IALMACENID = DBValues._ALMACEN_DEFAULT;
            }


            if (this.CAJASBOTELLASTextBox.Text != "")
            {
                USUARIOSBE.ICAJASBOTELLAS = this.CAJASBOTELLASTextBox.Text.ToString();
            }


            USUARIOSBE.ITICKETLARGOCREDITO = (this.TICKETLARGOCREDITOTextBox.Checked) ? "S" : "N";


            if (this.VENDEDORIDTextBox.Text != "")
            {
                USUARIOSBE.IVENDEDORID = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            }


            if (this.PENDMAXDIASTextBox.NumericValue != null)
            {
                USUARIOSBE.IPENDMAXDIAS = int.Parse(this.PENDMAXDIASTextBox.NumericValue.ToString());
            }


            if (this.GRUPOUSUARIOIDTextBox.Text != "")
            {
                USUARIOSBE.IGRUPOUSUARIOID = Int64.Parse(this.GRUPOUSUARIOIDTextBox.DbValue.ToString());
            }


            if (this.EMAIL1TextBox.Text != "")
            {
                USUARIOSBE.IEMAIL1 = this.EMAIL1TextBox.Text;
            }


            if (this.CLERKIDTextBox.Text != "")
            {
                USUARIOSBE.ICLERKPAGOSERVICIOSID = Int64.Parse(this.CLERKIDTextBox.DbValue.ToString());
            }


            if (this.CLERKSERVICIOSTextBox.Text != "")
            {
                USUARIOSBE.ICLERKSERVICIOS = Int64.Parse(this.CLERKSERVICIOSTextBox.DbValue.ToString());
            }


            USUARIOSBE.ITICKETLARGOCOTIZACION = (this.TICKETLARGOCOTIZACIONTextBox.Checked) ? "S" : "N";

            if (this.CODIGOAUTORIZACIONTextBox.Text != "")
            {
                USUARIOSBE.ICODIGOAUTORIZACION = this.CODIGOAUTORIZACIONTextBox.Text;
            }

            USUARIOSBE.ICLIEFORMASPAGODEF = getValuesFPClientesCreados();

            if (this.NOMBREIMPRESORATextBox.Text != "")
            {
                USUARIOSBE.INOMBREIMPRESORA = this.NOMBREIMPRESORATextBox.Text;
            }


            return USUARIOSBE;
        }
        public void LimpiarDatos()
        {
            //this.US_USERIDTextBox.Enabled = true;
            //this.US_USERIDTextBox.Text = "";
            //this.US_USUARIOTextBox.Text = "";
            //this.US_PASSWORDTextBox.Text = "";
            this.US_NOMBRETextBox.Text = "";
            this.US_GAFFETETextBox.Text = "";
            //this.US_VENDEDORTextBox.Text = "";
            //this.US_EMPRESATextBox.Text = "";
            //this.US_R_PASSWORDTextBox.Text = "";
            //this.US_LIMITE_CONEXIONESTextBox.Text = "";
            //this.US_CONEXIONES_ABIERTASTextBox.Text = "";
            try
            {
                this.US_VIGENCIATextBox.Value = DateTime.Today;
            }
            catch
            {
            }

            this.LISTAPRECIOIDTextBox.Text = "";

            this.ALMACENComboBox.SelectedIndex = -1;


            this.CAJASBOTELLASTextBox.SelectedIndex = -1;

            this.EMAIL1TextBox.Text = "";

            //this.US_ALMACENIDTextBox.Text = "";
        }
        public bool Eliminar()
        {
            CPERSONAD USUARIOSD = new CPERSONAD();
            try
            {
                CPERSONABE USUARIOSBEAnt = new CPERSONABE();
                USUARIOSBEAnt.IID = this.m_personaId;
                USUARIOSD.BorrarPERSONAD(USUARIOSBEAnt, null);
                if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                {
                    
                    MessageBox.Show("El registro se ha eliminado");
                }
                else
                {
                    MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                return false;
            }
            return true;
        }
        public bool SaveChanges(FbTransaction fTrans, ref CPERSONABE uReturnUser)
        {
            string ErroresValidacion = "";
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    v.Validate();
                    if (!v.IsValid)
                    {
                        ErroresValidacion += v.ErrorMessage + "--";
                    }
                }
                catch
                {
                    return false;
                }
            }
            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {
                try
                {
                    CPERSONAD USUARIOSD = new CPERSONAD();
                    if (opc == "Agregar")
                    {
                        CPERSONABE USUARIOSBE = new CPERSONABE();
                        USUARIOSBE = ObtenerDatosCapturados();
                        USUARIOSBE.IRESET_PASS = 1;
                        uReturnUser = USUARIOSD.AgregarPERSONAUSUARIOD(USUARIOSBE, fTrans);
                        if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                        {
                            //US_USERIDTextBox.Text = USUARIOSBE.IID.ToString();
                            this.m_personaId = USUARIOSBE.IID;
                            if(SaveChangesPerfilesDeUsuario(m_personaId, fTrans))
                                MessageBox.Show("El registro se ha insertado");
                            else
                               return false;
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    else if (opc == "Cambiar")
                    {
                        CPERSONABE USUARIOSBEAnt = new CPERSONABE();
                        CPERSONABE USUARIOSBE = new CPERSONABE();
                        USUARIOSBE = ObtenerDatosCapturados();
                        USUARIOSBEAnt.IID = this.m_personaId;
                        USUARIOSD.CambiarPERSONAUSUARIOD(USUARIOSBE, USUARIOSBEAnt, fTrans);
                        if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                        {
                            uReturnUser = USUARIOSBE;
                            if (SaveChangesPerfilesDeUsuario(m_personaId, fTrans))
                                MessageBox.Show("El registro se ha cambiado");
                            else
                            {
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                    else if (opc == "Borrar")
                    {
                        CPERSONABE USUARIOSBEAnt = new CPERSONABE();
                        USUARIOSBEAnt.IID = this.m_personaId;
                        USUARIOSD.BorrarPERSONAD(USUARIOSBEAnt, null);
                        if (USUARIOSD.IComentario == "" || USUARIOSD.IComentario == null)
                        {
                            uReturnUser = USUARIOSBEAnt;
                            MessageBox.Show("El registro se ha eliminado");
                        }
                        else
                        {
                            MessageBox.Show("ERRORES: " + USUARIOSD.IComentario.Replace("%", "\n"));
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                    return false;
                }
            }
            return true;
        }
        //public void SetUsuarioField(string strUsuario)
        //{
        //    this.US_USUARIOTextBox.Text = strUsuario;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans;
            CPERSONABE user = new CPERSONABE();
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                if (SaveChanges(fTrans, ref user))
                {
                    fTrans.Commit();


                    if (user.IID == CurrentUserID.CurrentUser.IID)
                    {

                        CPERSONAD USUARIOSD = new CPERSONAD();
                        CurrentUserID.CurrentUser = USUARIOSD.seleccionarPERSONA(user, null);
                    }
                            

                    this.Close();
                }
                else
                {
                    fTrans.Rollback();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
        }

        private void llenarGrid(int lPersonaId)
        {
            try
            {
                this.pERFILES_ASIGNADOSTableAdapter.Fill(this.dSSeguridad.PERFILES_ASIGNADOS, lPersonaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }




        public Boolean SaveChangesPerfilesDeUsuario(long iUserId, FbTransaction fTrans)
        {
            CUSUARIO_PERFILBE oUPerBe = new CUSUARIO_PERFILBE();
            CUSUARIO_PERFILD oUPerD = new CUSUARIO_PERFILD();
            if (iUserId == -1)
            {
                return false;
            }
            try
            {

                oUPerBe.IUP_PERSONAID = iUserId;
                oUPerD.BorrarPerfilesDeUsuario(oUPerBe, fTrans);
                foreach (DataGridViewRow dataRow in this.pERFILES_ASIGNADOSDataGridView.Rows)
                {
                    if (
                        dataRow.Cells["dgPermitido"].Value != null
                        && dataRow.Cells["dgPermitido"].Value != DBNull.Value
                        && ((int)dataRow.Cells["dgPermitido"].Value == 1))
                    {


                        if (dataRow.Cells["dgPerfil"].Value != null
                            && dataRow.Cells["dgPerfil"].Value != DBNull.Value)
                        {
                            oUPerBe = new CUSUARIO_PERFILBE();
                            oUPerBe.IUP_PERSONAID = iUserId;
                            oUPerBe.IUP_PERFIL = (int)dataRow.Cells["dgPerfil"].Value;
                            oUPerD.AgregarUSUARIO_PERFIL(oUPerBe, fTrans);
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

        private void BTCambiarPassword_Click(object sender, EventArgs e)
        {

            FPasswordInicial fPi = new FPasswordInicial(m_personaId, false, false);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string getValuesFPClientesCreados()
        {
            

            string strRetorno = "";
            bool esInicial = true;
            foreach ( Object obj in CBFormasPago.CheckedItems)
            {
                switch(obj.ToString())
                {
                    case "Efectivo":
                        {
                            if (esInicial)
                                esInicial = false;
                            else
                                strRetorno += "|";

                            strRetorno += DBValues._FORMA_PAGO_EFECTIVO.ToString();

                            break;
                        }


                    case "Tarjeta":
                        {
                            if (esInicial)
                                esInicial = false;
                            else
                                strRetorno += "|";

                            strRetorno += DBValues._FORMA_PAGO_TARJETA.ToString();

                            break;
                        }


                    case "Cheque":
                        {
                            if (esInicial)
                                esInicial = false;
                            else
                                strRetorno += "|";

                            strRetorno += DBValues._FORMA_PAGO_CHEQUE.ToString();

                            break;
                        }



                    case "Transferencia":
                        {
                            if (esInicial)
                                esInicial = false;
                            else
                                strRetorno += "|";

                            strRetorno += DBValues._FORMA_PAGO_TRANSFERENCIA.ToString();

                            break;
                        }


                    case "Credito":
                        {
                            if (esInicial)
                                esInicial = false;
                            else
                                strRetorno += "|";

                            strRetorno += DBValues._FORMA_PAGO_CREDITO.ToString();

                            break;
                        }
                }
            }

            return strRetorno;
        }


        private void putValuesFPClientesCreados(string strValor)
        {
            CBFormasPago.ClearSelected();
            if (strValor == null || strValor.Trim().Length == 0)
                return;
            string[] valoresAChecar = strValor.Split(new char[] { '|' });

            foreach(string strChecado in valoresAChecar)
            {

                switch (long.Parse(strChecado))
                {
                    case DBValues._FORMA_PAGO_EFECTIVO:
                        {
                            CBFormasPago.SetItemChecked(0, true);
                            break;
                        }


                    case DBValues._FORMA_PAGO_TARJETA:
                        {
                            CBFormasPago.SetItemChecked(1, true);
                            break;
                        }


                    case DBValues._FORMA_PAGO_CHEQUE:
                        {
                            CBFormasPago.SetItemChecked(2, true);
                            break;
                        }



                    case DBValues._FORMA_PAGO_TRANSFERENCIA:
                        {
                            CBFormasPago.SetItemChecked(3, true);
                            break;
                        }


                    case DBValues._FORMA_PAGO_CREDITO:
                        {
                            CBFormasPago.SetItemChecked(4, true);
                            break;
                        }
                }
            }
        }

        private void btnSelectPrinterName_Click(object sender, EventArgs e)
        {

            ShowPrinters showPrinters = new ShowPrinters(GetPrinters());
            showPrinters.ShowDialog();
            NOMBREIMPRESORATextBox.Text = ShowPrinters.auxPrinterName;
            showPrinters.Dispose();
            GC.SuppressFinalize(showPrinters);
        }

        List<string> GetPrinters()
        {

            PrintServer localPrintServer = new PrintServer();

            PrintQueueCollection printQueues = localPrintServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });

            var printerList = (from printer in printQueues

                               select printer.FullName).ToList();

            return printerList;

        }

    }
}
