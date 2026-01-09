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
using DataLayer.Importaciones;

namespace iPos
{
    public partial class WFUpdateProductosMovil_3 : IposForm
    {
        ProgressBar[] progressBars;
        BackgroundWorker[] backgroundWorkers;
        CheckBox[] checkboxes;
        int currentProgress = 0;
        bool bError = false;
        string strError = "";

        bool m_derechoMovilImpoPrecios = false;

        ProgressBar progBar = null;
        BackgroundWorker bgworker = null;
        CheckBox chBox = null;

        List<CM_PROPBE> prodsFromWs = new List<CM_PROPBE>();

        bool bPrecZipImportado = false;


        public WFUpdateProductosMovil_3()
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

            if (currentProgress >= 3)
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
                inicializar();
                recursiveChecking();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (currentProgress)
            {
                case 0: ImportarArchivosProd();  break;
                case 1: LimpiarInventario(); break;
                case 2:

                    if (bPrecZipImportado)
                        ImportarPrecZip();

                    ImportarInventario();

                    break;
                default: break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentProgress++;
            recursiveChecking();

        }

        private void WFUpdateProductosMovil_3_Load(object sender, EventArgs e)
        {

            progressBars = new ProgressBar[] { progressBar00, progressBar01, progressBar02 };
            backgroundWorkers = new BackgroundWorker[] { backgroundWorker0, backgroundWorker1, backgroundWorker2 };
            checkboxes = new CheckBox[] { checkBox0, checkBox1, checkBox2 };



            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_derechoMovilImpoPrecios = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_MOVIL_HABIMPOPRECIOS, null);
        }


        private void ImportarArchivosProd()
        {

            //importa prec.zip si hay uno nuevo
            bPrecZipImportado = false;
            if (m_derechoMovilImpoPrecios)
            {
                ImportaDesdeFtp iftp = new ImportaDesdeFtp();

                
                bPrecZipImportado = iftp.DescargarArchivoPreciosDeFtp();
            }

            bError = !ObtenerDatosPorWebService();

            if (bError)
            {
                this.strError = "Error al importar datos del webservice " +  strError;
            }
        }


        private bool ObtenerDatosPorWebService()
        {

            try
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }


                // TODO: This line of code loads data into the 'dSMovil5.PRODUCTOSINVENTARIABLES' table. You can move, or remove it, as needed.
                this.pRODUCTOSINVENTARIABLESTableAdapter.Fill(this.dSMovil5.PRODUCTOSINVENTARIABLES);

                List<CM_VEDPBE> listDetalles = new List<CM_VEDPBE>();

                //foreach (Movil.DSMovil5.PRODUCTOSINVENTARIABLESRow row in this.dSMovil5.PRODUCTOSINVENTARIABLES)
                //{
                //    CM_VEDPBE retorno = new CM_VEDPBE();
                //    retorno.IVENTA = "X";
                //    retorno.ICLIENTE = "X";
                //    retorno.IPRODUCTO = row.CLAVE;
                //    retorno.IID_FECHA = DateTime.Now;
                //    retorno.ICANTIDAD = row.EXISTENCIA;
                //    retorno.IPRECIO = 0;
                //    retorno.IDESCUENTO = 0;
                //    retorno.ICLASIFICA = "N";
                //    listDetalles.Add(retorno);
                //}

                //CM_VEDPBE[] vedpbes = listDetalles.ToArray();


                string jsonStr = "*";// JsonConvert.SerializeObject(vedpbes, Formatting.Indented);
                string strRespuesta = "";
                try
                {

                    
                        strRespuesta = service1.ValidarVentaMovil_3(jsonStr, iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    
                    if (!strRespuesta.StartsWith("["))
                    {
                        strError = "Error de webservice " + strRespuesta;
                        return false;
                    }

                    prodsFromWs = JsonConvert.DeserializeObject<List<CM_PROPBE>>(strRespuesta);


                }
                catch(Exception ex)
                {
                    strError = ex.Message + " " + ex.StackTrace;
                    return false;
                }
            }
            catch(Exception ex)
            {
                strError = ex.Message + " " +  ex.StackTrace;
                return false;
            }

            finally
            {
            }

            return true;
        }


        private bool ImportarPrecZip()
        {
            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();
            bool bRetorno = true;

            if (iDBF.ImportarArchivosCatalogos(CIMP_FILESD.FileType_Producto, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                bRetorno = true;
            }
            else
            {
                //m_iComentario = iDBF.IComentario;
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }
                strError = strMensajeError;
                bRetorno = false;
            }

            return bRetorno;
        }

        private bool ImportarExistenciaEnBd()
        {
            try
            {
                strError = "";
                if (prodsFromWs.Count > 0)
                {

                    CPRODUCTOD prodD = new CPRODUCTOD();

                    foreach (CM_PROPBE prod in prodsFromWs)
                    {

                        CPRODUCTOBE prodBE = new CPRODUCTOBE();
                        prodBE.ICLAVE = prod.IPRODUCTO;

                        prodBE = prodD.seleccionarPRODUCTOxCLAVE(prodBE, null);

                        if (prodBE == null)
                            continue;

                        if (!prodD.CambiarExistenciaMovilPRODUCTOD(prodBE.IID, prod.IEXIS1, null))
                        {
                            strError += "No se pudo importar " + prod.IPRODUCTO + "\n";
                        }
                      

                        string strCantidad = "";
                        if (prod.IBOTCAJA > 1)
                        {
                            decimal bufferCajas = Math.Floor(prod.IEXIS1 / prod.IBOTCAJA);
                            decimal bufferPzasSueltas = prod.IEXIS1 - (prod.IBOTCAJA * bufferCajas);

                            strCantidad = bufferCajas.ToString("N0") + " CJA " + bufferPzasSueltas.ToString() + " PZA";
                        }
                        else
                        {
                            strCantidad = prod.IEXIS1.ToString("N0") + " PZA";
                        }
                    }

                    

                }
            }
            catch
            {

            }
            finally
            {

            }

            return strError.Equals("");
        }




        private void LimpiarInventario()
        {

            ArrayList errores = new ArrayList();
            string strError = "";
            bError = !ImportaFtpMovil.MOVIL_PRE_INVENTARIO_UPDATE(ref strError, null);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
        }




        private void ImportarInventario()
        {
            string strError = "";


            bError = !ImportarExistenciaEnBd();

            this.strError = "";
            if (bError)
            {
                
                    this.strError = "Error al actualizar la existencia en la bd " + strError;
                
            }
            else
            {

                CurrentUserID.GetAutoSourceCollectionFromTable(true);
            }
        }



    }
}
