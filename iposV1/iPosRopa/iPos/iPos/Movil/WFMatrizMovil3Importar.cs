using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Importaciones;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using iPos.Importaciones;

namespace iPos
{
    public partial class WFMatrizMovil3Importar : IposForm
    {
        private bool m_importacionExitosa;
        private string m_iComentario;
        private string m_iComentario2;


        private bool m_aplicacionExitosa;
        private string m_iComentarioAplicacion;
        public WFMatrizMovil3Importar()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
            m_iComentario2 = "";
        }

        private void BTCatalogos_Click(object sender, EventArgs e)
        {
            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            m_importacionExitosa = iPos.Movil.Movil3Sync.ObtenerDatosDelServer(ref m_iComentario2);
        }


        private void backgroundWorker1_DoWork_old(object sender, DoWorkEventArgs e)
        {
            //ArrayList strErrores = new ArrayList();

            ImportarDBF iDBF = new ImportarDBF();

            m_iComentario2 = "";

            string strRespuesta = "";

            m_importacionExitosa = true;



            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }


            //ventas

            strRespuesta = service1.ObtenerVentasMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                m_importacionExitosa = false;
                this.m_iComentario2 = "Al verificar :" + strRespuesta;
                return;

            }
            else
            {

                List<FM_VENPBE> ventasMoviles = JsonConvert.DeserializeObject<List<FM_VENPBE>>(strRespuesta);
                foreach (FM_VENPBE ventaMovil in ventasMoviles)
                {
                    if (!iDBF.ImportarDatosPedidoMovilMatriz(ventaMovil, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
                    {
                        ventaMovil.IPROCESADO = "E";
                    }
                    else
                    {
                        ventaMovil.IPROCESADO = "S";
                    }
                }


                var serialized = JsonConvert.SerializeObject(ventasMoviles);

                strRespuesta = service1.ActualizarProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                if (!strRespuesta.StartsWith("S"))
                {
                    m_importacionExitosa = false;
                    this.m_iComentario2 = "Al actualizar el estado en el ws :" + strRespuesta;
                    return;

                }
            }


            //compras
            try
            {
                strRespuesta = service1.ObtenerComprasMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.StartsWith("["))
                {
                    m_importacionExitosa = false;
                    this.m_iComentario2 += "\nAl verificar :" + strRespuesta;

                }
                else
                {

                    List<FM_CMNPBE> ventasMoviles = JsonConvert.DeserializeObject<List<FM_CMNPBE>>(strRespuesta);
                    foreach (FM_CMNPBE ventaMovil in ventasMoviles)
                    {
                        if (!iDBF.ImportarDatosCompraMovilMatriz(ventaMovil, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
                        {
                            ventaMovil.IPROCESADO = "E";
                        }
                        else
                        {
                            ventaMovil.IPROCESADO = "S";
                        }
                    }


                    var serialized = JsonConvert.SerializeObject(ventasMoviles);

                    strRespuesta = service1.ActualizarCompraProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    if (!strRespuesta.StartsWith("S"))
                    {
                        m_importacionExitosa = false;
                        this.m_iComentario2 += "\nAl actualizar el estado en el ws :" + strRespuesta;


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //cobranza

            strRespuesta = service1.ObtenerCobranzaMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                m_importacionExitosa = false;
                this.m_iComentario2 = "Al verificar :" + strRespuesta;
                return;

            }
            else
            {
                CR_PAGOMOVILD pagoMovilD = new CR_PAGOMOVILD();
                CR_DOCTOPAGOMOVILD doctoPagoMovilD = new CR_DOCTOPAGOMOVILD();
                List<CR_PAGOMOVILBE> pagosMoviles = JsonConvert.DeserializeObject<List<CR_PAGOMOVILBE>>(strRespuesta);


                bool bErrorCobranza = false;
                foreach (CR_PAGOMOVILBE header in pagosMoviles)
                {
                    header.IR_PAGOMOVILREFID = header.IID;

                    int iExiste = pagoMovilD.ExisteR_PAGOMOVILXORIGINALID(header, null);
                    if(iExiste > 0)
                    {
                        header.IPROCESADO = "S";
                        continue;
                    }
                    else if(iExiste < 0)
                    {
                        bErrorCobranza = true;
                        break;
                    }


                    CR_PAGOMOVILBE pagoMovilNuevo = pagoMovilD.AgregarR_PAGOMOVILD(header, null);
                    if (pagoMovilNuevo == null)
                    {
                        header.IPROCESADO = "E";
                        continue;
                        //m_importacionExitosa = false;
                        //this.m_iComentario2 = "Al verificar :" + pagoMovilD.IComentario;
                        //return;
                    }

                    foreach (CR_DOCTOPAGOMOVILBE detallePago in header.Detalles)
                    {
                        detallePago.IPAGOMOVILID = pagoMovilNuevo.IID;
                        detallePago.IR_DOCTOPAGOMOVILREFID = detallePago.IID;

                        CR_DOCTOPAGOMOVILBE doctoPagoMovilNuevo = doctoPagoMovilD.AgregarR_DOCTOPAGOMOVILD(detallePago, null);
                        if (doctoPagoMovilNuevo == null)
                        {
                            //m_importacionExitosa = false;
                            //this.m_iComentario2 = "Al verificar :" + doctoPagoMovilD.IComentario;
                            //return;

                            header.IPROCESADO = "E";
                            continue;
                        }
                    }
                    header.IPROCESADO = "S";
                    header.IID = header.IR_PAGOMOVILREFID;

                }


                if (!bErrorCobranza)
                {
                    var serialized = JsonConvert.SerializeObject(pagosMoviles);

                    strRespuesta = service1.ActualizarCobranzaProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    if (!strRespuesta.StartsWith("S"))
                    {
                        m_importacionExitosa = false;
                        this.m_iComentario2 = "Al actualizar el estado en el ws :" + strRespuesta;
                        return;

                    }
                }
            }




            //clientes

            strRespuesta = service1.ObtenerClienteMovil_3("100", "N", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                m_importacionExitosa = false;
                this.m_iComentario2 = "Al verificar :" + strRespuesta;
                return;

            }
            else
            {

                List<CF_CLIPBE> clientes = JsonConvert.DeserializeObject<List<CF_CLIPBE>>(strRespuesta);
                foreach (CF_CLIPBE item in clientes)
                {
                    List<CF_CLIPBE> listaItemUnico = new List<CF_CLIPBE>();
                    listaItemUnico.Add(item);
                    string comentario = "";
                    if (!ImportaFtpMovil.ImportarDatosCliente_FromMovil3(listaItemUnico, false, ref comentario))
                    {
                        item.IPROCESADO = "E";
                    }
                    else
                    {
                        item.IPROCESADO = "S";
                    }
                }


                var serialized = JsonConvert.SerializeObject(clientes);

                strRespuesta = service1.ActualizarClienteProcesadoMovil_3(serialized, "", iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                   iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                   iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                if (!strRespuesta.StartsWith("S"))
                {
                    m_importacionExitosa = false;
                    this.m_iComentario2 = "Al actualizar el estado en el ws :" + strRespuesta;
                    return;

                }
            }


            //estado de sesion


            strRespuesta = service1.getUpdatedMovilSesion(DateTime.MinValue, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                               iPos.Tools.FTPManagement.m_strFTPFolderWs,
                               iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.StartsWith("["))
            {
                m_importacionExitosa = false;
                this.m_iComentario2 = "Al verificar :" + strRespuesta;
                return;

            }
            else
            {

                CMOVILSESIOND movilSesionD = new CMOVILSESIOND();
                List<CMOVILSESIONBE> sesiones = JsonConvert.DeserializeObject<List<CMOVILSESIONBE>>(strRespuesta);
                foreach (CMOVILSESIONBE item in sesiones)
                {
                    CMOVILSESIONBE saved = new CMOVILSESIONBE();
                    saved.IVENDEDORCLAVE = item.IVENDEDORCLAVE;
                    saved = movilSesionD.seleccionarMOVILSESION(saved, null);

                    if (saved != null)
                    {
                        if (!movilSesionD.CambiarMOVILSESIOND_X_VEND(item, saved, null))
                        {

                            m_importacionExitosa = false;
                            this.m_iComentario2 = "Error al cambiar sesion" + movilSesionD.IComentario;
                        }
                    }
                    else
                    {
                        if (movilSesionD.AgregarMOVILSESIOND(item, null) == null)
                        {

                            m_importacionExitosa = false;
                            this.m_iComentario2 = "Error al agregar sesion" + movilSesionD.IComentario;
                        }
                    }

                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {
                MessageBox.Show("Los archivos han sido importados");
            }
            else
            {
                MessageBox.Show("Errores " + m_iComentario2);
            }

        }



        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {

                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void WFMatrizMovil3Importar_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;
        }

        private void btnAplicarDatosVendedorMovil_Click(object sender, EventArgs e)
        {
            /*m_aplicacionExitosa = false;
            m_iComentarioAplicacion = "";
            progressBar2.Style = ProgressBarStyle.Marquee;
            backgroundWorker2.RunWorkerAsync();*/

            WFImportacionPedidosMovil wf = new WFImportacionPedidosMovil();
            wf.Show();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            CDOCTOD doctoD = new CDOCTOD();

            CR_PAGOMOVILD pagoMovilD = new CR_PAGOMOVILD();

            ImportarDBF iDBF = new ImportarDBF();


            m_aplicacionExitosa = true;


            //ventas
            try
            {
                List<long> pedidosMovil = doctoD.seleccionarDOCTOPEDIDOMOVILPendiente(null);
                if (pedidosMovil == null)
                {

                    m_aplicacionExitosa = false;
                    this.m_iComentarioAplicacion = "Error al obtener la lista de pedidos " + doctoD.IComentario;
                    return;
                }


                foreach (long doctoId in pedidosMovil)
                {
                    long lDoctoVenta = 0;
                    long lDoctoPago = 0;



                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();


                        if (!iDBF.PEDIDO_MOVIL_COMPLETAR(doctoId, ref lDoctoVenta, ref lDoctoPago, fTrans))
                        {
                            m_aplicacionExitosa = false;
                            this.m_iComentarioAplicacion = "Error al obtener la lista de pedidos " + doctoD.IComentario;
                            fTrans.Rollback();
                            fConn.Close();
                            return;
                        }

                        fTrans.Commit();
                        fConn.Close();
                    }
                    catch
                    {
                        fTrans.Rollback();
                        fConn.Close();
                    }
                    finally
                    {
                        fConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }



            //cobranza
            try
            {
                List<long> pagosMovil = pagoMovilD.seleccionarPAGOMOVILPendiente(null);
                if (pagosMovil == null)
                {

                    m_aplicacionExitosa = false;
                    this.m_iComentarioAplicacion = "Error al obtener la lista de pagos " + pagoMovilD.IComentario;
                    return;
                }


                foreach (long pagoId in pagosMovil)
                {



                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();


                        if (!pagoMovilD.MOVILPAGO_PROCESAR(pagoId, CurrentUserID.CurrentUser.IID, fTrans))
                        {
                            m_aplicacionExitosa = false;
                            this.m_iComentarioAplicacion = "Error al procesar el pago " + doctoD.IComentario;
                            fTrans.Rollback();
                            fConn.Close();
                            return;
                        }

                        fTrans.Commit();
                        fConn.Close();
                        //fTrans.Rollback();
                        //fConn.Close();
                    }
                    catch
                    {
                        fTrans.Rollback();
                        fConn.Close();
                    }
                    finally
                    {
                        fConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }




        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar2.Style = ProgressBarStyle.Blocks;
            if (m_aplicacionExitosa)
            {
                MessageBox.Show("Los registros han sido aplicados");
            }
            else
            {
                MessageBox.Show("Errores " + m_iComentarioAplicacion);
            }
        }
    }
}
