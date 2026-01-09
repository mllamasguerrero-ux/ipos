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


namespace iPos
{
    public partial class WFSurtirPedido : Form
    {


        public WFSurtirPedido()
        {
            InitializeComponent();
        }


        private void WFSurtirPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSSurtido.CANCDEVOSURTIR' table. You can move, or remove it, as needed.

            this.DTSurtidoVenta.Value = DateTime.Today.AddDays(-30);
            this.DTRecepcion.Value = DateTime.Today.AddDays(-30);

            LlenarGrid();
            LlenarGridCancDevo();
            LlenarGridSurtidos();
        }

        private void LlenarGrid()
        {
            this.dOCTOSASURTIRTableAdapter.Fill(this.dSInventarioFisico3.DOCTOSASURTIR, (int)DBValues._DOCTO_SURTIDOESTADO_PENDIENTE , DTSurtidoVenta.Value);
        }

        private void LlenarGridCancDevo()
        {
            this.cANCDEVOSURTIRTableAdapter.Fill(this.dSSurtido.CANCDEVOSURTIR, DTRecepcion.Value);
        }

        private void dOCTOSASURTIRDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 )
            {

                if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGSURTIR")
                {
                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    int dgFolio = 0;
                    try
                    {
                        dgFolio = (int)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGFOLIO"].Value;
                    }
                    catch { }
                    string strNombreCliente = (string)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGNOMBRECLIENTE"].Value;
                    DateTime fecha = (DateTime)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value;
                    long dgAlmacenId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGALMACENID"].Value;

                    WFSurtirPedidoDetalle wf = new WFSurtirPedidoDetalle(dgDoctoId, dgFolio, strNombreCliente, fecha,dgAlmacenId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();

                }
                else if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIR")
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

                    if (MessageBox.Show("Realmente desea marcar este registro como surtido? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;

                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    SURTIR_PEDIDO_DIRECTO(dgDoctoId, "");
                }
            }
        }





        private void SURTIR_PEDIDO_DIRECTO(long doctoId, string notaSurtido)
        {
            CSURTIDOD surtidoD = new CSURTIDOD();

            if (!surtidoD.SURTIDO_ASIGNARESTADO(doctoId, notaSurtido, DBValues._DOCTO_SURTIDOESTADO_SURTIDO, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();
                doctoBE.IID = doctoId;
                doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                if (doctoBE != null && doctoBE.IESFACTURAELECTRONICA == "S")
                {
                    if (generarFacturaElectronica(doctoBE))
                    {

                        MessageBox.Show("Se facturo");
                        imprimirFacturaElectronica(doctoBE);

                    }
                    else
                    {
                        surtidoD.SURTIDO_ASIGNARESTADO(doctoId, notaSurtido, DBValues._DOCTO_SURTIDOESTADO_PENDIENTE, CurrentUserID.CurrentUser.IID, null);
                        this.LlenarGrid();
                        MessageBox.Show("No se pudo facturar");
                        return;
                    }
                }


                if (
                    doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO ||
                    doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA ||
                    (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA_SALIDA) ||
                    (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_TRASPASOFRANQUICIA))
                {
                    EnviarTraslado(doctoBE);
                }


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
            LlenarGridCancDevo();
        }

        private void cANCDEVOSURTIRDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (cANCDEVOSURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGRECIBIR")
                {
                    long dgDoctoId = (long)cANCDEVOSURTIRDataGridView.Rows[e.RowIndex].Cells["DGIDCANCDEVO"].Value;
                    int dgFolio = (int)cANCDEVOSURTIRDataGridView.Rows[e.RowIndex].Cells["DGFOLIOCANCDEVO"].Value;
                    string strNombreCliente = (string)cANCDEVOSURTIRDataGridView.Rows[e.RowIndex].Cells["DGNOMBRECLIENTECANCDEVO"].Value;
                    DateTime fecha = (DateTime)cANCDEVOSURTIRDataGridView.Rows[e.RowIndex].Cells["DGFECHACANCDEVO"].Value;
                    long dgAlmacenId = (long)cANCDEVOSURTIRDataGridView.Rows[e.RowIndex].Cells["DGALMACENIDCANCDEVO"].Value;

                    WFRecepcionAlmacenDetalle wf = new WFRecepcionAlmacenDetalle(dgDoctoId, dgFolio, strNombreCliente, fecha, dgAlmacenId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    this.LlenarGridCancDevo();

                }
            }
        }

        
        private void LlenarGridSurtidos()
        {
            this.dOCTOSSURTIDOSTableAdapter.Fill(this.dSInventarioFisico3.DOCTOSSURTIDOS, (int)DBValues._DOCTO_SURTIDOESTADO_SURTIDO, DTVentasSurtidas.Value);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "DGIMPRIMIRSURTIDO")
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                    long dgDoctoId = (long)dataGridView1.Rows[e.RowIndex].Cells["DGIDSURTIDO"].Value;

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
            }
        }

        private void btnActualizarSurtidos_Click(object sender, EventArgs e)
        {
            LlenarGridSurtidos();
        }

        private void btnSumarizadoDeProductos_Click(object sender, EventArgs e)
        {

            string strReporte = "SumarizadoProductosXSurtir.frx";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }
    }
}
