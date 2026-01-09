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


namespace iPos
{
    public partial class WFMatrizImportar : IposForm
    {
        private bool m_importacionExitosa;
        private string m_iComentario;
        private string m_iComentario2;
        public WFMatrizImportar()
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
            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();

            m_iComentario2 = "";

            ArrayList archivosARecargar = new ArrayList();
            ArrayList archivosErrorRecarga = new ArrayList();
            if (!iDBF.ChecarArchivosAImportarPedidosDeSucursales(CurrentUserID.CurrentParameters, ref archivosARecargar))
            {
                if(archivosARecargar != null & archivosARecargar.Count > 0)
                {

                    foreach (CIMP_FILESBE impFileBE in archivosARecargar)
                    {
                        iPos.ImportaDesdeFtp iftp = new ImportaDesdeFtp();
                        iPos.Tools.FileItem fileItem = new iPos.Tools.FileItem();


                        fileItem.FECHA = impFileBE.IIF_FECHA.Add(impFileBE.IIF_TIME);
                        fileItem.FILEPATHNAME = impFileBE.IIF_REMOTE_FILE;

                        fileItem.SUCURSALCLAVE = impFileBE.IIF_SUCURSALCLAVE;
                        fileItem.SUCURSALID = impFileBE.IIF_SUCURSALID ;

                        if (!iftp.DescargarArchivoMatriz(fileItem, null, CIMP_FILESD.FileType_MatrizPedidos))
                         {
                             archivosErrorRecarga.Add(impFileBE);
                        }
                        else if (!iDBF.ChecarPedidoMatrizAImportar(impFileBE, CurrentUserID.CurrentParameters))
                        {
                            archivosErrorRecarga.Add(impFileBE);
                        }
                    }
                }

                   
            }


            if(archivosErrorRecarga.Count > 0)
            {// & Environment.NewLine 
                string strListaArchivos = "";

                foreach (CIMP_FILESBE impFileBE in archivosErrorRecarga)
                {
                    strListaArchivos += " Sucursal " + impFileBE.IIF_SUCURSALCLAVE + " - " + impFileBE.IIF_FILE + Environment.NewLine;
                }

                MessageBox.Show("Los siguientes archivos no se descargaron correctamente y no se pudieron descargar en un nuevo intento... " + strListaArchivos , "Confirmacion");
                
                if (MessageBox.Show(" Desea volver a intentar descargarlos la siguiente vez que le de en importar sucursales? ( recomendable descartar cada cierto tiempo y pedir la recarga de los mismos desde la sucursal cuando ya son muchos)" , "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                    foreach (CIMP_FILESBE fileItem in archivosErrorRecarga)
                    {
                        CIMP_FILESD impFileD = new CIMP_FILESD();
                        fileItem.IIF_STATUS = CIMP_FILESD.Status_Ingresado;
                        impFileD.CambiarIMP_FILES(fileItem, fileItem, null);
                    }
                }
            }
             

            if (iDBF.ImportarPedidosDeSucursales(CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;
                if (strErrores.Count > 0)
                {
                    m_importacionExitosa = false;
                    foreach (string strError in strErrores)
                    {
                        m_iComentario2 += strError + "\n";
                    }
                    //m_iComentario = strComentario;

                }
            }
            else
            {
                m_iComentario = iDBF.IComentario;
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
                MessageBox.Show("Test" + m_iComentario2);
            }

            WFImportarPedidosSucursales fCompras = new WFImportarPedidosSucursales(DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA);
            fCompras.Show();
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

        private void WFMatrizImportar_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;
        }

    }
}
