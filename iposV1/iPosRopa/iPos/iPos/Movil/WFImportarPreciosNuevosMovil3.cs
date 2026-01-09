using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using Newtonsoft.Json;

using System.EnterpriseServices;
using FirebirdSql.Data.FirebirdClient;
using ConexionesBD;
using Microsoft.ApplicationBlocks.Data;
using DataLayer.Importaciones;

namespace iPos
{
    public partial class WFImportarPreciosNuevosMovil3 : IposForm
    {
        bool bError = false;
        string strError = "";

        //bool bCancelar = false;
        bool m_bShowMensajesError = false;

        bool bPrecZipImportado = false;

        public WFImportarPreciosNuevosMovil3()
        {
            InitializeComponent();
        }


        public WFImportarPreciosNuevosMovil3(bool bShowMensajesError)
            : this()
        {
            m_bShowMensajesError = bShowMensajesError;

            m_bShowMensajesError = true;
        }

        private void WFImportarPreciosNuevosMovil3_Load(object sender, EventArgs e)
        {
            if (ConexionAInternet())
                IntentarEnvio();
            else
            {
                MessageBox.Show("No se detecto internet para enviar la venta, quedara pendiente de enviar");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //bCancelar = true;
        }

        private void ProcesarPendientes()
        {
            bError = false;
            ImportarArchivosProd();

            if(bPrecZipImportado)
            {
                bError = !ImportarPrecZip();
            }
            else
            {
                strError = "no se detecto un arhivo nuevo de productos a importar";
                bError = true;
            }


        }

        private void IntentarEnvio()
        {

            btnReintentar.Enabled = false;
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private bool ConexionAInternet()
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            try
            {
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcesarPendientes();

            CPARAMETROD paramD = new CPARAMETROD();
            CurrentUserID.CurrentParameters = paramD.seleccionarPARAMETROActual(null);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Style = ProgressBarStyle.Blocks;
            if (bError)
            {
                btnReintentar.Enabled = true;

                if (m_bShowMensajesError)
                    MessageBox.Show("Ocurrio un error: " + strError);
                else
                    this.Close();
            }
            else
            {

                if (m_bShowMensajesError)
                {
                    CurrentUserID.GetAutoSourceCollectionFromTable(true);
                    MessageBox.Show("Se han actualizado los precios");
                }

                this.Close();

            }
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            IntentarEnvio();
        }




        private void ImportarArchivosProd()
        {

            //importa prec.zip si hay uno nuevo
            bPrecZipImportado = false;
            ImportaDesdeFtp iftp = new ImportaDesdeFtp();
            
            bPrecZipImportado = iftp.DescargarArchivoPreciosDeFtp();
            
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


    }
}
