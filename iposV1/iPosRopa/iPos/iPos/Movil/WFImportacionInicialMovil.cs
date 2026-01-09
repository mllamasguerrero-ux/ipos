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
using System.IO;
using iPos.Tools;
using Newtonsoft.Json;

namespace iPos
{
    public partial class WFImportacionInicialMovil : IposForm
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

        bool m_derechoMovilAbreviadoImpProd = false;

        public WFImportacionInicialMovil()
        {
            InitializeComponent();
        }


        void inicializar()
        {
            bError = false;
            strError = "";
            currentProgress = 0;
            foreach(CheckBox cb in checkboxes)
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
                
                chBox.Visible = true;
            }

            if (currentProgress >= 7)
            {
                MessageBox.Show("La inicialización se ha terminado ");
                this.Close();
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
            if (LastMovilFinalized())
            {
                inicializar();
                recursiveChecking();
            }
            else
            {
                if (MessageBox.Show("Necesita primero hacer cierre de lo anterior. Desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                    {
                        WFExportacionFinalMovil_3 wf = new WFExportacionFinalMovil_3();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }
                    else
                    {

                        WFExportacionFinalMovil wf = new WFExportacionFinalMovil();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (currentProgress)
            {
                case 0:

                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                        ImportarArchivos_3();
                    else
                        ImportarArchivos();
                    break;
                case 1: LimpiarBD(); break;
                case 2: AbrirCorte(); break;
                case 3: ImportarCatalogos();
                    break;
                case 4: ImportarClientes(); break;
                case 5: ImportarCobranza(); break;
                case 6:
                        ImportarHistorial();

                    if (!bError && CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                    {
                        this.InicializarSesion();
                        this.AJUSTEINICIALIZACIONMOVIL(null);
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

        private void WFImportacionInicialMovil_Load(object sender, EventArgs e)
        {
            progressBars = new ProgressBar[] { progressBar02, progressBar00, progressBar01, progressBar03, progressBar04, progressBar05, progressBar06 };
            backgroundWorkers = new BackgroundWorker[] { backgroundWorker2, backgroundWorker0, backgroundWorker1, backgroundWorker3, backgroundWorker4, backgroundWorker5, backgroundWorker6 };
            checkboxes = new CheckBox[] { checkBox2, checkBox0, checkBox1, checkBox3, checkBox4, checkBox5, checkBox6 };




            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_derechoMovilAbreviadoImpProd = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_MOVIL_ABREVIADOIMPOPROD, null);
            CBAbreviado.Visible = (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3) && m_derechoMovilAbreviadoImpProd;

        }


        private void LimpiarBD()
        {
            if (ImportaFtpMovil.ZippearBackupBD())
            {

                LIMPIARPARAMOVIL(null);

                string comentario = "";
                //bError = !ImportaFtpMovil.AbrirCorte(ref comentario);

                this.strError = "";
                if (bError)
                {
                    strError = comentario;
                }
                //Thread.Sleep(2000);
            }
            else
            {
                bError = true;
                strError = "Error al respaldar la bd";
            }
        }

        private void ImportarArchivos()
        {
            //Thread.Sleep(2000);
            bError = !ImportaFtpMovil.ImportarArchivos();

            if (bError)
            {
                this.strError = "Error al importar archivos del ftp";
            }
        }

        private void ImportarArchivos_3()
        {
            try
            {

                // create an instance fo the web service
                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }



                byte[] fileContent = service1.DownloadPrecZipMovil_3(CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);


                string strMovilFileLocalPath = System.AppDomain.CurrentDomain.BaseDirectory + "sampdata\\Movil\\out\\";
                string strCatalogosFileName = "PREC_" + CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE + ".ZIP";

                string strFullFileName = strMovilFileLocalPath + strCatalogosFileName;

                if (File.Exists(strFullFileName))
                {
                    try
                    {
                        File.Delete(strFullFileName);
                    }
                    catch
                    {
                        bError = true;
                        strError = "Parece que el archivo de catalogos quedo atorado y sera necesario cerrar y abrir de nuevo la aplicacion";
                        return;
                    }
                }



                File.WriteAllBytes(strFullFileName , fileContent);


                string strMovilFileLocal = strMovilFileLocalPath + strCatalogosFileName;
                string strMovilFolderUnzipLocalPath = strMovilFileLocal.Replace(".ZIP", "\\");


                ZipUtil.UnZipFiles(strMovilFileLocal, strMovilFolderUnzipLocalPath, null, false);


            }
            catch (Exception ex)
            {

                bError = true;
                strError = "Error " + ex.Message;
                
            }
        }

        private void ImportarCatalogos()
        {
            //return;
            ArrayList errores = new ArrayList();


            bError = !ImportaFtpMovil.ImportarCatalogo(ref errores, CurrentUserID.CurrentParameters , true, CBAbreviado.Checked);


            //Thread.Sleep(2000);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
            else
            {
                CurrentUserID.GetAutoSourceCollectionFromTable(true);
            }
        }

        private void ImportarClientes()
        {

            ArrayList errores = new ArrayList();
            bError = !ImportaFtpMovil.ImportarClientes(ref errores, CurrentUserID.CurrentParameters);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
            else
            {
                CPERSONAD personaD = new CPERSONAD();
                bError = !personaD.limpiarClientesInactivos(null);
                if (bError)
                {
                    strError = personaD.IComentario;
                }
            }
        }

        private void ImportarCobranza()
        {
            string error = "";
            bError = !ImportaFtpMovil.ImportarCobranza(ref error);

            this.strError = "";
            if (bError)
            {
                strError = error;

            }

        }

        private void ImportarHistorial()
        {


            string error = "";
            bError = !ImportaFtpMovil.ImportarHistorial(ref error);

            this.strError = "";
            if (bError)
            {
                strError = error;
                
            }
        }


        private void InicializarSesion()
        {


            string error = "";
            bError = !ImportaFtpMovil.ImportarHistorial(ref error);





            try
            {


                long folioCobranzaLong = 0;
                CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                if (!pvd.MOVIL_GETNEXTCOBRANZAFOLIO(null, ref folioCobranzaLong))
                {

                    bError = true;
                    strError = " /Error al generar folio de cobranza " + pvd.IComentario;
                    return ;
                }



                long folioVentaLong = 0;
                if (!pvd.MOVIL_GETNEXTVENTAFOLIO(null, ref folioVentaLong))
                {

                    bError = true;
                    strError = " /Error al generar folio de venta " + pvd.IComentario;
                    return;
                }
                

                // create an instance fo the web service
                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                CMOVILSESIONBE movilSesion = new CMOVILSESIONBE();
                movilSesion.IVENDEDORCLAVE = CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE;
                movilSesion.IFECHAINICIOCOBRA = DateTime.Now;
                movilSesion.IFECHAINICIOVENTA = DateTime.Now;
                movilSesion.IFOLIOINICIOCOBRA = folioCobranzaLong;
                movilSesion.IFOLIOINICIOVENTA = folioVentaLong;
                movilSesion.IACTIVO = "S";

                string jsonStr = JsonConvert.SerializeObject(movilSesion, Formatting.Indented);


                string strRespuesta = service1.AbrirCorteMovil_3(jsonStr,CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                       iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                       iPos.Tools.FTPManagement.m_strFTPFolderPassWs);


                if (!strRespuesta.Equals("exito"))
                {

                    bError = true;
                    strError += "  No se pudo abrir el corte en el servidor : " + strRespuesta;
                }

            }
            catch (Exception ex)
            {

                bError = true;
                strError = "Error " + ex.Message;

            }


            this.strError = "";
            if (bError)
            {
                strError = error;

            }
        }



        private bool LIMPIARPARAMOVIL(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"LIMPIARPARAMOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }



        private bool AJUSTEINICIALIZACIONMOVIL(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"AJUSTEINICIALIZACIONMOVIL";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }


        private void AbrirCorte()
        {
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            DateTime fechaCorteActiva = DateTime.MinValue;
            if (corteD.HayCorteActivo(iPos.CurrentUserID.CurrentUser.IID, null, ref fechaCorteActiva))
            {
               strError = "Ya hay un corte activo";
               bError = true;
                return;
            }
            corteBE.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            corteBE.ICAJAID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
            corteBE.ICAJEROID = CurrentUserID.CurrentUser.IID;
            corteBE.IFECHACORTE = DateTime.Now;
            corteBE.ISALDOINICIAL = 0;
            corteBE.ITIPOCORTEID = DBValues._TIPO_CORTEABIERTO;



            corteBE = corteD.AbrirCORTED(corteBE, null);
            if (corteBE == null)
            {
                bError = true;
                strError = corteD.IComentario;
            }
            else
            {
                //MessageBox.Show("El corte se ha abierto con exito");
                ActualizaCurrentUser();
            }

           
        }




        private void ActualizaCurrentUser()
        {
            CPERSONAD personaD = new CPERSONAD();
            CurrentUserID.CurrentUser = personaD.seleccionarPERSONA(CurrentUserID.CurrentUser, null);
        }



        public bool LastMovilFinalized()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            bool bEstaFinalizado = true;
            if (!pvd.MOVIL_ESTA_FINALIZADO(null, ref bEstaFinalizado))
            {
                MessageBox.Show(pvd.IComentario);
                return true;
            }

            return bEstaFinalizado;
        }

    }
}
