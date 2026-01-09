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
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFImportar : IposForm
    {
        private bool m_importacionExitosa;
        private string m_iComentario;
        private string m_iComentario2;
        public WFImportar()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
            m_iComentario2 = "";
        }

        private void WFImportarProd_Load(object sender, EventArgs e)
        {

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            ActualizarEstatusBotones();
        }

        private void BTCatalogos_Click(object sender, EventArgs e)
        {
            if (!ChecarCorteActivo() || !ChecarKitsPendientes())
                return;

            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar2.Style = ProgressBarStyle.Marquee;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();

            if (iDBF.ImportarArchivosCatalogos(CIMP_FILESD.FileType_Producto, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;
            }
            else
            {
                //m_iComentario = iDBF.IComentario;
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }
                m_iComentario = strMensajeError;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Blocks;
            ActualizarEstatusBotones();
            if (m_importacionExitosa)
            {
                MessageBox.Show("Los archivos han sido importados");
                WFProductoCambioPrecio wfp = new WFProductoCambioPrecio();
                wfp.ShowDialog();
                wfp.Dispose();
                GC.SuppressFinalize(wfp);
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();
            if (iDBF.ImportarArchivosComprasTraslados(CIMP_FILESD.FileType_RecCompras, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;
            }
            else
            {
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError += str + "\n";
                }
               m_iComentario = strMensajeError;
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar2.Style = ProgressBarStyle.Blocks;
            ActualizarEstatusBotones();
            this.Hide();

            if(!m_importacionExitosa)
                MessageBox.Show(m_iComentario);

            WFImportarCompras fCompras = new WFImportarCompras();
            fCompras.Show();

            
        }

        private void bgWorkTraslados_DoWork(object sender, DoWorkEventArgs e)
        {

            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();
            if (iDBF.ImportarArchivosComprasTraslados(CIMP_FILESD.FileType_Traslados, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
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




        private void bgWorkTraslados_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.prBrTraslados.Style = ProgressBarStyle.Blocks;
            ActualizarEstatusBotones();
            this.Hide();


            if (!m_importacionExitosa)
                MessageBox.Show(m_iComentario);

            WFImportarCompras fCompras = new WFImportarCompras(DBValues._DOCTO_TIPO_TRASPASO_REC);
            fCompras.Show();
        }

      

        private void BTImportarTraslados_Click(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            m_importacionExitosa = false;
            m_iComentario = "";
            prBrTraslados.Style= ProgressBarStyle.Marquee;
            bgWorkTraslados.RunWorkerAsync();
        }

        private void BTImportarExistencias_Click(object sender, EventArgs e)
        {

            m_importacionExitosa = false;
            m_iComentario = "";
            prBrExistencias.Style = ProgressBarStyle.Marquee;
            this.bgWorkExistencias.RunWorkerAsync();
        }

        private void bgWorkExistencias_DoWork(object sender, DoWorkEventArgs e)
        {

            ImportarDBF iDBF = new ImportarDBF();
            if (iDBF.ImportarArchivosExistencias(CIMP_FILESD.FileType_ExistenciasGen, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
            {
                m_importacionExitosa = true;
            }
            else
            {
                m_iComentario = iDBF.IComentario;
            }
        }

        private void bgWorkExistencias_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            prBrExistencias.Style = ProgressBarStyle.Blocks;
            ActualizarEstatusBotones();

            if (m_importacionExitosa)
            {
                MessageBox.Show("Los archivos han sido importados");
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }



        private void ActualizarEstatusBotones()
        {

            CSUCURSALBE sucBE = new CSUCURSALBE();
            CSUCURSALD sucD = new CSUCURSALD();
            sucBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;

            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            


            CIMP_FILESD impFiles = new CIMP_FILESD();
            bool bStatusBtCatalogos, bStatusBtCompras, bStatusBtTraslados, bStatusBtTrasladosDevo;

            bStatusBtCatalogos = impFiles.HayImportacionesPendientes(CIMP_FILESD.FileType_Producto) && 
                (sucBE.IESMATRIZ == null || !sucBE.IESMATRIZ.Equals("S") || (sucBE.ISURTIDOR != null && sucBE.ISURTIDOR.Trim().Length > 0));
            bStatusBtCompras = impFiles.HayImportacionesPendientes(CIMP_FILESD.FileType_RecCompras);
            bStatusBtTraslados = impFiles.HayImportacionesPendientes(CIMP_FILESD.FileType_Traslados);

            if (CurrentUserID.CurrentParameters.IHAB_DEVOLUCIONTRASLADO == "S")
                bStatusBtTrasladosDevo = impFiles.HayImportacionesPendientes(CIMP_FILESD.FileType_TrasladosDevo);
            else
                bStatusBtTrasladosDevo = false;

            this.BTCatalogos.Enabled = bStatusBtCatalogos;
            this.button1.Enabled = bStatusBtCompras;
            this.BTImportarTraslados.Enabled = bStatusBtTraslados;
            this.BTImportarTrasladosDevo.Enabled = bStatusBtTrasladosDevo;

        }

        private void BTLimpiarCat_Click(object sender, EventArgs e)
        {
            if (LIMPIARIMPORTACIONCATALOGOS(null))
            {
                ActualizarEstatusBotones();
                MessageBox.Show("Las importaciones de catalogos han sido limpiadas");
            }
        }

        private bool LIMPIARIMPORTACIONCATALOGOS(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"LIMPIARIMPORTACIONCATALOGOS ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if(st == null)
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



        private bool ChecarKitsPendientes()
        {
            if (CurrentUserID.CurrentParameters.IMANEJAKITS == "S")
            {

                CPRODUCTOD prodD = new CPRODUCTOD();
                if (prodD.GetCountEnProcesoPartesSalida(null) > 0)
                {

                    MessageBox.Show("Hay productos kit que aun estan en proceso en algunas ventas o documentos de salida, por favor completelos o cancelelos para proceder con la importacion");
                    return false;
                }
            }

            return true;
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

        private void BTImportarPreciosNuevos_Click(object sender, EventArgs e)
        {

            iPos.WFPreciosTemp rp = new iPos.WFPreciosTemp();
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
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
        }

        private void bgWorkSolicitudesMerca_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();

            m_iComentario2 = "";

            ArrayList archivosARecargar = new ArrayList();
            ArrayList archivosErrorRecarga = new ArrayList();
            if (!iDBF.ChecarArchivosAImportarPedidosDeSucursales(CurrentUserID.CurrentParameters, ref archivosARecargar))
            {
                if (archivosARecargar != null & archivosARecargar.Count > 0)
                {

                    foreach (CIMP_FILESBE impFileBE in archivosARecargar)
                    {
                        iPos.ImportaDesdeFtp iftp = new ImportaDesdeFtp();
                        iPos.Tools.FileItem fileItem = new iPos.Tools.FileItem();


                        fileItem.FECHA = impFileBE.IIF_FECHA.Add(impFileBE.IIF_TIME);
                        fileItem.FILEPATHNAME = impFileBE.IIF_REMOTE_FILE;

                        fileItem.SUCURSALCLAVE = impFileBE.IIF_SUCURSALCLAVE;
                        fileItem.SUCURSALID = impFileBE.IIF_SUCURSALID;

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


            if (archivosErrorRecarga.Count > 0)
            {// & Environment.NewLine 
                string strListaArchivos = "";

                foreach (CIMP_FILESBE impFileBE in archivosErrorRecarga)
                {
                    strListaArchivos += " Sucursal " + impFileBE.IIF_SUCURSALCLAVE + " - " + impFileBE.IIF_FILE + Environment.NewLine;
                }

                MessageBox.Show("Los siguientes archivos no se descargaron correctamente y no se pudieron descargar en un nuevo intento... " + strListaArchivos, "Confirmacion");

                if (MessageBox.Show(" Desea volver a intentar descargarlos la siguiente vez que le de en importar sucursales? ( recomendable descartar cada cierto tiempo y pedir la recarga de los mismos desde la sucursal cuando ya son muchos)", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
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

        private void bgWorkSolicitudesMerca_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            prBrSolicitudesMerca.Style = ProgressBarStyle.Blocks;
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

        private void BTImportarSolicitudesMercancia_Click(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;

            m_importacionExitosa = false;
            m_iComentario = "";
            m_iComentario2 = "";
            prBrSolicitudesMerca.Style = ProgressBarStyle.Marquee;
            bgWorkSolicitudesMerca.RunWorkerAsync();
        }
    }
}
