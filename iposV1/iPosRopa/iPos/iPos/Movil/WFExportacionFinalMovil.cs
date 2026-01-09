using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using iPosData;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using iPosBusinessEntity;

using Newtonsoft.Json;

namespace iPos
{
    public partial class WFExportacionFinalMovil : iPos.Tools.ScreenConfigurableForm
    {
        ProgressBar[] progressBars;
        BackgroundWorker[] backgroundWorkers;
        CheckBox[] checkboxes;
        int currentProgress = 0;
        bool bError = false;
        string strError = "";

        ProgressBar progBar = null;
        BackgroundWorker bgworker = null;
        CheckBox chBox = null;

        public WFExportacionFinalMovil()
        {
            InitializeComponent();
        }

        void inicializar()
        {
            bError = false;
            strError = "";
            currentProgress = 0;
            foreach (CheckBox cb in checkboxes)
            {
                cb.Visible = false;
            }
        }

        void recursiveChecking()
        {
            if (currentProgress > 0 && progBar != null)
            {

                progBar.Style = ProgressBarStyle.Blocks;


                if (bError)
                {
                    MessageBox.Show(strError);
                    inicializar();
                    return;
                }

                if(chBox != null)
                    chBox.Visible = true;
            }

            if (currentProgress >= 4)
            {
                if(!bError)
                {
                    MessageBox.Show("Finalizacion exitosa");
                    this.Close();
                }
                return;
            }
                


            progBar = progressBars[currentProgress];
            bgworker = backgroundWorkers[currentProgress];
            chBox = checkboxes[currentProgress];
            progBar.Style = ProgressBarStyle.Marquee;
            bgworker.RunWorkerAsync();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ImportaFtpMovil.ConexionAInternet())
            {
                MessageBox.Show("Parece que no hay conexion de internet. La conexion de internet es necesaria para la finalizacion");
                return;
            }


            if (!CBFinalizarCobranza.Checked && !CBFinalizarVenta.Checked)
                return;

            if (!CBFinalizarVenta.Checked)
            {
                progressBar0A.Visible = false;
                checkBoxA.Visible = false;
                lblExportacionVentas.Visible = false;
            }
            else
            {
                progressBar0A.Visible = true;
                lblExportacionVentas.Visible = true;
            }

            if (!CBFinalizarCobranza.Checked)
            {
                progressBar00.Visible = false;
                checkBox0.Visible = false;
                lblAbonos.Visible = false;
            }
            else
            {
                progressBar00.Visible = true;
                lblAbonos.Visible = true;
            }

            GBProgreso.Visible = true;




            inicializar();
            recursiveChecking();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (currentProgress)
            {

                case 0: ExportarClientes(); break;
                case 1:
                    if (CBFinalizarVenta.Checked)
                    {

                        if (!CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
                        {
                            ExportarDBFVentas();
                        }
                        else
                        {
                            EnviarCierreDeVentas();
                        }
                    }
                    else
                    {
                        chBox = null;
                    }
                    break;
                case 2:
                    if (CBFinalizarCobranza.Checked)
                    {
                        //ExportarAbonos();
                       EnviarCierreDeCobranza();
                    }
                    else
                    {
                        chBox = null;
                    }
                    break;
                case 3:
                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 1)
                    {
                        ActualizarUltimaVisita();
                        EnviarVisitasPendientes();
                    }
                    break;
                default: break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentProgress++;
            recursiveChecking();

        }

        private void WFExportacionFinalMovil_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(false, true);

            progressBars = new ProgressBar[] { progressBar02, progressBar0A, progressBar00, progressBar03 };
            backgroundWorkers = new BackgroundWorker[] { backgroundWorker2, backgroundWorkerA, backgroundWorker0, backgroundWorker3 };
            checkboxes = new CheckBox[] { checkBox2, checkBoxA, checkBox0, checkBox3 };

            GBProgreso.Visible = false;

            if (!CurrentUserID.CurrentParameters.ITIPOSYNCMOVIL.Equals(DBValues._TIPOSYNC_WS))
            {
                /*progressBar0A.Visible = false;
                checkBoxA.Visible = false;
                lblExportacionVentas.Visible = false;*/

                CBFinalizarCobranza.Checked = true;
                CBFinalizarCobranza.Enabled = false;
                CBFinalizarVenta.Checked = true;
                CBFinalizarVenta.Checked = true;

            }
            else
            {
                /*progressBar0A.Visible = true;
                lblExportacionVentas.Visible = true;*/
            }


            while(HayPendientesDeExportar())
            {
                if (MessageBox.Show("Hay exportaciones pendientes de informacion de venta y/o cobranza. Es necesario enviarlas antes de finalizar. Desea hacerlo?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    WFImportarPendientesMovilcs wf = new WFImportarPendientesMovilcs();
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                }
                else
                {
                    this.Close();
                }
            }

        }


        private void ExportarClientes()
        {
            ImportaFtpMovil.EnvioClientes(false, ref bError, ref strError);


        }
        /*
        private void ExportarAbonos()
        {
            Thread.Sleep(2000);
            //bError = !ImportaFtpMovil.ImportarArchivos();

            if (bError)
            {
                this.strError = "Error al importar archivos del ftp";
            }
        }
        */

        private void ExportarDBFVentas()
        {
            CCORTEBE m_corteBE = new CCORTEBE();
            CCORTED corteD = new CCORTED();

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;

            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                return;
            }

            m_corteBE.IFECHACORTE = fechaCorte;
            m_corteBE.ICAJEROID = iPos.CurrentUserID.CurrentUser.IID;
            m_corteBE = corteD.seleccionarCORTEXDIAyCAJERO(m_corteBE, null);
            if (m_corteBE == null)
            {
                bError = true;
                strError = "Corte no encontrado";
                return;
            }


            string refComentario = "";
            bError = !ImportaFtpMovil.exportarVentasMoviles(null, m_corteBE.IID, ref refComentario);
            strError = refComentario;


        }


        public bool HayPendientesDeExportar()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            bool bHayCambios = true;
            if(!pvd.MOVTO_HAYPENDIENTES_EXPORT(null, ref bHayCambios))
            {
                MessageBox.Show(pvd.IComentario);
                return true;
            }

            return bHayCambios;
        }

        public bool EnviarCierreDeVentas()
        {

            long folioLong = 0;
            string folioStr = "";
            string strRespuesta = "";
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if(!pvd.MOVIL_GETNEXTVENTAFOLIO(null, ref folioLong))
            {

                bError = true;
                strError = " /Error al generar folio de venta "  + pvd.IComentario;
                return false;
            }
            folioStr = folioLong.ToString();

            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }

            strRespuesta = service1.CerrarCorteVentaMovil(folioStr,
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError += " /No se pudo cerrar el corte de ventas"  + strRespuesta;
                }
                else
                {

                    CPARAMETROD parametroD = new CPARAMETROD();
                    CurrentUserID.CurrentParameters.IMOVILCIERREVENTA = (int)folioLong;
                    parametroD.CambiarMOVILCIERREVENTA(CurrentUserID.CurrentParameters, null);

                    return true;
                }



            return false;
        }


        public bool EnviarCierreDeCobranza()
        {

            long folioLong = 0;
            string folioStr = "";
            string strRespuesta = "";
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (!pvd.MOVIL_GETNEXTCOBRANZAFOLIO(null, ref folioLong))
            {

                bError = true;
                strError = " /Error al generar folio de cobranza " + pvd.IComentario;
                return false;
            }
            folioStr = folioLong.ToString();

            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }

            strRespuesta = service1.CerrarCorteCobranzaMovil(folioStr,
                                iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

            if (!strRespuesta.Equals("exito"))
            {

                bError = true;
                strError += " /No se pudo cerrar el corte de cobranza" + strRespuesta;
            }
            else
            {


                CPARAMETROD parametroD = new CPARAMETROD();
                CurrentUserID.CurrentParameters.IMOVILCIERRECOBRANZA = (int)folioLong;
                parametroD.CambiarMOVILCIERRECOBRANZA(CurrentUserID.CurrentParameters, null);
                return true;
            }



            return false;
        }


        private void EnviarVisitasPendientes()
        {


           

            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim();
            }
            CVISITAD visitaD = new CVISITAD();
            CVISITABE[] visitas = visitaD.seleccionarVISITASNOENVIADAS(null);



            if (visitas == null)
            {
                return;
            }



            ArrayList visis = new ArrayList();
            foreach (CVISITABE visita in visitas)
            {

                CM_VISIBE visibe = CM_VISID.convertVisitaIntoVISI(visita);
                if (visibe == null)
                {

                    bError = true;
                    strError += " /No se pudieron convertir algunas visitas para enviarlos  " + visita.IID.ToString();
                    return;
                }

                visis.Add(visibe);
            }


            CM_VISIBE[] visibes = new CM_VISIBE[visis.Count];
            visis.CopyTo(visibes, 0);
            string jsonStr = JsonConvert.SerializeObject(visibes, Formatting.Indented);

            string strRespuesta = "";
            try
            {

                strRespuesta = service1.AgregarVisitaMovil(jsonStr, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                iPos.Tools.FTPManagement.m_strFTPFolderPassWs);

                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError += " /No se pudo enviar las visitas: " + strRespuesta;
                }
                else
                {
                    visitaD.setEnviadoWSPENDINGSVISITAD(null);

                }
            }
            catch (Exception ex)
            {
                bError = true;
                strError += "Excepcion al procesar las visitas: " + ex.Message + ex.StackTrace;
                return;
            }



        }



        private void ActualizarUltimaVisita()
        {
            CVISITAD visitaD = new CVISITAD();
            CVISITABE visitaBE = new CVISITABE();
            visitaBE = visitaD.seleccionarULTIMAVISITA(null);

            if (visitaBE != null)
            {
                visitaD.MOVILVISITA_ASIGNARHIZOPEDIDO(visitaBE, null);
            }
        }

        private void GBProgreso_Enter(object sender, EventArgs e)
        {

        }
    }
}
