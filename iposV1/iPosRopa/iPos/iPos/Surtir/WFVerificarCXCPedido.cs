using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using DataLayer.Importaciones;
using System.Net.Mail;
using System.Data;
using System.Net.Mime;
using System.IO;


namespace iPos
{
    public partial class WFVerificarCXCPedido : Form
    {


        public WFVerificarCXCPedido()
        {
            InitializeComponent();
        }


        private void WFVerificarCXCPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSSurtido.CANCDEVOSURTIR' table. You can move, or remove it, as needed.

            this.DTSurtidoVenta.Value = DateTime.Today.AddDays(-30);

            LlenarGrid();
        }

        private void LlenarGrid()
        {
            this.dOCTOSASURTIRTableAdapter.Fill(this.dSInventarioFisico3.DOCTOSASURTIR, (int)DBValues._DOCTO_SURTIDOESTADO_CXC, DTSurtidoVenta.Value);
        }


        private void dOCTOSASURTIRDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 )
            {

                if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIR")
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("pdoctoid", dgDoctoId);
                    dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                    dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                    dictionary.Add("creadoPorUserId", 0);
                    string strReporte = "recibolargo.frx";


                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
                else if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGSURTIRDIRECTO")
                {

                    if (MessageBox.Show("Realmente desea aprobar este registro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = dgDoctoId;
                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
                    if (doctoBE == null)
                    {

                        MessageBox.Show("El registro ya no existe");
                        LlenarGrid();
                    }
                    
                        APROBAR_PEDIDO_DIRECTO(dgDoctoId, "");
                    

                }
                else if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGRECHAZAR")
                {

                    if (MessageBox.Show("Realmente desea rechazar este registro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = dgDoctoId;
                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
                    if(doctoBE == null)
                    {

                        MessageBox.Show("El registro ya no existe");
                        LlenarGrid();
                    }

                    if (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_VENDMOVIL)
                    {

                        WFDesaprobarMovilCXC wfCxc_ = new WFDesaprobarMovilCXC();
                        wfCxc_.ShowDialog();
                        bool cancelProceso = wfCxc_.cancelProceso;
                        bool bSeleccionCancel = wfCxc_.m_bSeleccionCancel;
                        wfCxc_.Dispose();
                        GC.SuppressFinalize(wfCxc_);

                        if (cancelProceso)
                        {
                            MessageBox.Show("Se cancelo el proceso");
                            return;
                        }

                        if (!bSeleccionCancel)
                        {
                            RECHAZAR_PEDIDO_DIRECTO(dgDoctoId);
                            EnviarCorreoRechazo(doctoBE);
                            

                            return;
                        }
                        else
                        {

                            CancelarVenta(doctoBE, null);
                            LlenarGrid();
                            EnviarCorreoRechazo(doctoBE);
                        }
                    }
                    else
                    {
                        RECHAZAR_PEDIDO_DIRECTO(dgDoctoId);
                        EnviarCorreoRechazo(doctoBE);
                    }


                }
            }
        }


        private void EnviarCorreoRechazo(CDOCTOBE doctoBE)
        {

            CPERSONABE personaBE = new CPERSONABE();
            CPERSONAD personaD = new CPERSONAD();
            personaBE.IID = doctoBE.IVENDEDORID;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            if (personaBE == null)
                return;

            if (personaBE.IEMAIL1 == null || !personaBE.IEMAIL1.Contains("@"))
                return;


            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = doctoBE.IPERSONAID;
            clienteBE = personaD.seleccionarPERSONA(clienteBE, null);

            if (clienteBE == null)
                return;

            EnviarMail(
                    CurrentUserID.CurrentParameters.ISMTPHOST,
                    CurrentUserID.CurrentParameters.ISMTPMAILFROM,
                    personaBE.IEMAIL1,
                    "Pedido rechazado",
                    "El pedido al cliente " + clienteBE.INOMBRE + " de la fecha " + doctoBE.IFECHA.ToString("dd/MM/yyyy") + " fue rechazado",
                    CurrentUserID.CurrentParameters.ISMTPPORT,
                    CurrentUserID.CurrentParameters.ISMTPSSL.Equals("S"),
                    CurrentUserID.CurrentParameters.ISMTPUSUARIO,
                    CurrentUserID.CurrentParameters.ISMTPPASSWORD);
        }



        private void APROBAR_PEDIDO_DIRECTO(long doctoId, string notaSurtido)
        {
            CSURTIDOD surtidoD = new CSURTIDOD();

            if (!surtidoD.SURTIDO_ASIGNARESTADO(doctoId, notaSurtido, DBValues._DOCTO_SURTIDOESTADO_PENDIENTE, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {
                MessageBox.Show("Se aprobo el pedido");
                this.LlenarGrid();
            }

        }


       

        private void RECHAZAR_PEDIDO_DIRECTO(long doctoId)
        {
            CSURTIDOD surtidoD = new CSURTIDOD();

            string notaSurtido = "CXC";
            WFCXCMotivoRechazo wf = new WFCXCMotivoRechazo();
            wf.ShowDialog();
            notaSurtido = wf.strMotivoRechazo;
            bool bCancelProceso = wf.cancelProceso;
            wf.Dispose();
            GC.SuppressFinalize(wf);

            if (bCancelProceso)
            {
                MessageBox.Show("Se cancelo el proceso");
                return;
            }

            if (!surtidoD.SURTIDO_ASIGNARESTADO(doctoId, notaSurtido, DBValues._DOCTO_SURTIDOESTADO_ERROR, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {
                MessageBox.Show("Se rechazo el pedido");
                this.LlenarGrid();
            }

        }

        private bool generarFacturaElectronica(CDOCTOBE docto)
        {


            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REMISIONAFACTURA, null))
            {
                MessageBox.Show("No tiene derecho para cambiar una remision ya hecha a factura");
                return false;
            }

            if (docto.IFECHAHORA.Month != DateTime.Now.Month)
            {
                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_FACTURARFUERADEMES, null))
                {
                    MessageBox.Show("No tiene derecho para facturar una remision fuera de este mes");
                    return false;
                }
            }



            bool retorno = false;


            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            /*if (retorno)
            {
                CDOCTOD doctoD = new CDOCTOD();
                m_Docto.IESFACTURAELECTRONICA = "S";
                doctoD.ACTUALIZARESFACTURAELECTRONICA(m_Docto, null);
            }*/

            return retorno;
        }



        private bool imprimirFacturaElectronica(CDOCTOBE docto)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            docto = doctoD.seleccionarDOCTO(docto, null);

            if ((bool)docto.isnull["IFOLIOSAT"] || (bool)docto.isnull["IESTATUSDOCTOID"]
                || docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, iPosReporting.WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }


        private void ExportarTraslados(int folio)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";

            ArrayList resultadosExportacion = new ArrayList();
            if (!iDBF.EnviarArchivosAFtpDeTraslados(ref resultadosExportacion, folio))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show(strBuffer.ToString() + "\n");
            }
            else
                MessageBox.Show("La exportacion se ha realizado");


        }


        private void ExportarTrasladosPedidosMatriz(int folio, long doctoid)
        {


            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            //string strResultado = "";
            ExportarDBF eDBF = new ExportarDBF();

            if (!eDBF.ExportarEnvioPedido(doctoid, CurrentUserID.CurrentUser, null))
            {
                return;
            }


            ArrayList resultadosExportacion = new ArrayList();
            if (iDBF.EnviarArchivosAFtpDeMatrizPedidos(ref resultadosExportacion, folio, null))
            {

                StringBuilder strBuffer = new StringBuilder("");
                strBuffer.Append(iDBF.IComentario + "\n");
                foreach (string str in resultadosExportacion)
                {
                    strBuffer.Append(str);
                }
                MessageBox.Show(strBuffer.ToString() + "\n");
            }
            else
            {
                MessageBox.Show("Hubo problemas al realizar al exportacion");
                if (resultadosExportacion.Count > 0)
                {

                    StringBuilder strBuffer = new StringBuilder("");
                    strBuffer.Append(iDBF.IComentario + "\n");
                    foreach (string str in resultadosExportacion)
                    {
                        strBuffer.Append(str);
                    }
                    MessageBox.Show(strBuffer.ToString() + "\n");
                }
            }


        }



        private void EnviarTraslado(CDOCTOBE doctoBE)
        {


            if (MessageBox.Show("¿Desea reimprimir el ticket de traslado?", "Confirmacion de re impresion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PosPrinter.ImprimirTicket(doctoBE.IID);
            }



            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
            {
                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);

                ExportarTraslados(doctoBE.IFOLIO);
            }

            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA)
            {
                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);

                ExportarTrasladosPedidosMatriz(doctoBE.IFOLIO, doctoBE.IID);
            }


            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA)
            {

                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);
                CDOCTOBE doctoBEAux = new CDOCTOBE();
                doctoBEAux.IID = doctoBE.IDOCTOREFID;
                doctoBEAux = vData.seleccionarDOCTO(doctoBEAux, null);

                ExportarTraslados(doctoBEAux.IFOLIO);
            }


            if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA)
            {

                CDOCTOD vData = new CDOCTOD();
                doctoBE = vData.seleccionarDOCTO(doctoBE, null);
                CDOCTOBE doctoBEAux = new CDOCTOBE();
                doctoBEAux.IID = doctoBE.IDOCTOREFID;
                doctoBEAux = vData.seleccionarDOCTO(doctoBEAux, null);

                ExportarTrasladosPedidosMatriz(doctoBEAux.IFOLIO, doctoBEAux.IID);
            }




        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnActualizarCancDevo_Click(object sender, EventArgs e)
        {
            
        }


        private bool CancelarVenta(CDOCTOBE doctoBE, FbTransaction st)
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            try
            {

                pvd.CancelarVenta(doctoBE, CurrentUserID.CurrentUser, null);
                if (pvd.IComentario == "" || pvd.IComentario == null)
                {
                    HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
                    MessageBox.Show("Venta cancelada");
                     PosPrinter.ImprimirTicket(doctoBE.IID);


                }
                else
                {
                    MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message + ex.StackTrace);
                return false;
            }
            finally
            {
            }

            return true;
        }



        public static bool EnviarMail(
         string p_smtpServer,
         string p_mailFrom,
         string p_mailTo,
         string p_mailSubject,
         string p_body,
         int p_smtpPort,
         bool p_EnableSsl,
         string p_smtpuser,
         string p_smtpPass
         )
        {
            bool retorno = true;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(p_smtpServer);

                mail.From = new MailAddress(p_mailFrom);
                mail.To.Add(p_mailTo);
                mail.Subject = p_mailSubject;
                mail.Body = p_body;
                SmtpServer.Port = p_smtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(p_smtpuser, p_smtpPass);
                SmtpServer.EnableSsl = p_EnableSsl;



                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
                retorno = false;
            }
            return retorno;
        }

        
    }
}
