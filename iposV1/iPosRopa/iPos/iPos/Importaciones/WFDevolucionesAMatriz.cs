using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataLayer.Importaciones;
using System.Collections;
using iPosData;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;

namespace iPos
{
    public partial class WFDevolucionesAMatriz : Form
    {

        private bool m_importacionExitosa;
        private string m_iComentario;

        public WFDevolucionesAMatriz()
        {
            InitializeComponent();

            m_importacionExitosa = false;
            m_iComentario = "";
        }

        private void BTImportarTrasladosDevo_Click(object sender, EventArgs e)
        {


            if (!ChecarCorteActivo())
                return;

            m_importacionExitosa = false;
            m_iComentario = "";
            prBrTrasladosDevo.Style = ProgressBarStyle.Marquee;
            bgWorkTrasladosDevo.RunWorkerAsync();
        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void bgWorkTrasladosDevo_DoWork(object sender, DoWorkEventArgs e)
        {

            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();
            if (iDBF.ImportarArchivosComprasTraslados(CIMP_FILESD.FileType_TrasladosDevo, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;
            }
            else
            {
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }
                m_iComentario = strMensajeError;
            }
        }

        private void bgWorkTrasladosDevo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.prBrTrasladosDevo.Style = ProgressBarStyle.Blocks;
            ActualizarEstatusBotones();
            this.Hide();


            if (!m_importacionExitosa)
                MessageBox.Show(m_iComentario);

            WFImportarCompras fCompras = new WFImportarCompras(DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO);
            fCompras.ShowDialog();
            fCompras.Dispose();
            GC.SuppressFinalize(fCompras);
        }

        private void WFDevolucionesAMatriz_Load(object sender, EventArgs e)
        {


            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            ActualizarEstatusBotones();
        }


        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_IMPORTAR.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }
            return true;
        }


        private void ActualizarEstatusBotones()
        {
            CIMP_FILESD impFiles = new CIMP_FILESD();
            bool bStatusBtTrasladosDevo, bStatusBtPedidosDevo;

            if (CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONTRASLADO == "S")
                bStatusBtTrasladosDevo = impFiles.HayImportacionesPendientes(CIMP_FILESD.FileType_TrasladosDevo);
            else
                bStatusBtTrasladosDevo = false;

            this.BTImportarTrasladosDevo.Enabled = bStatusBtTrasladosDevo;


            if (CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONSURTIDOSUC == "S")
                bStatusBtPedidosDevo = impFiles.HayImportacionesPendientes(CIMP_FILESD.FileType_PedidosDevo);
            else
                bStatusBtPedidosDevo = false;

            this.BTImportarPedidosDevo.Enabled = bStatusBtPedidosDevo;

        }

        private void BTImportarPedidosDevo_Click(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            m_importacionExitosa = false;
            m_iComentario = "";
            prBrPedidosDevo.Style = ProgressBarStyle.Marquee;
            bgWorkPedidosDevo.RunWorkerAsync();
        }




        private void bgWorkPedidosDevo_DoWork(object sender, DoWorkEventArgs e)
        {

            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();
            if (iDBF.ImportarArchivosComprasTraslados(CIMP_FILESD.FileType_PedidosDevo, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;
            }
            else
            {
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }
                m_iComentario = strMensajeError;
            }
        }

        private void bgWorkPedidosDevo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.prBrPedidosDevo.Style = ProgressBarStyle.Blocks;
            ActualizarEstatusBotones();
            this.Hide();


            if (!m_importacionExitosa)
                MessageBox.Show(m_iComentario);

            WFImportarCompras fCompras = new WFImportarCompras(DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO);
            fCompras.ShowDialog();
            fCompras.Dispose();
            GC.SuppressFinalize(fCompras);
        }


    }
}
