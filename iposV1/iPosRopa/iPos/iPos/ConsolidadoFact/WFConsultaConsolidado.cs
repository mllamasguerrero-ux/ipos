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
using iPosReporting;

namespace iPos
{
    public partial class WFConsultaConsolidado : Form
    {
        public WFConsultaConsolidado()
        {
            InitializeComponent();
        }

        private void LlenarFacturasConsolidadas()
        {
            try
            {
                this.fACTURASDECONSOLIDACIONTableAdapter.Fill(this.dSConsolidados.FACTURASDECONSOLIDACION, DTPFechaInicial.Value, DTPFechaFinal.Value);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LlenarFacturasConsolidadas();
        }

        private void LlenarDevolucionesConsolidadas()
        {
            try
            {
                this.dEVOLUCIONESDECONSOLIDACIONTableAdapter.Fill(this.dSConsolidados.DEVOLUCIONESDECONSOLIDACION,  DTPDevFechaInicial.Value, DTPDevFechaFinal.Value);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnDevActualizar_Click(object sender, EventArgs e)
        {
            LlenarDevolucionesConsolidadas();
        }

        private void WFConsultaConsolidado_Load(object sender, EventArgs e)
        {

            this.DTPFechaInicial.Value = DateTime.Today.AddDays(-90);
            this.DTPFechaFinal.Value = DateTime.Today;


            this.DTPDevFechaInicial.Value = DateTime.Today.AddDays(-90);
            this.DTPDevFechaFinal.Value = DateTime.Today;

            LlenarFacturasConsolidadas();
            LlenarDevolucionesConsolidadas();


        }

        private void fACTURASDECONSOLIDACIONDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (fACTURASDECONSOLIDACIONDataGridView.Columns[e.ColumnIndex].Name == "DGDETALLE")
                {
                    long dgDoctoId = (long)fACTURASDECONSOLIDACIONDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                   

                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = dgDoctoId;
                    doctoBE = doctoD.seleccionarDOCTO(doctoBE,null);
                    if (doctoBE != null)
                    {
                        WFConsultaDetalleConsolidado wf = new WFConsultaDetalleConsolidado(doctoBE);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }

                }
                else if (fACTURASDECONSOLIDACIONDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIRFACT")
                {
                    long dgDoctoId = (long)fACTURASDECONSOLIDACIONDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    imprimirFacturaElectronicaPorId(dgDoctoId);
                    if (MessageBox.Show("Desea imprimir el ticket de la factura electronica ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        imprimirTicketFacturaElectronicaPorId(dgDoctoId);
                    }

                }
                else if (fACTURASDECONSOLIDACIONDataGridView.Columns[e.ColumnIndex].Name == "DGTICKETS")
                {
                    long dgDoctoId = (long)fACTURASDECONSOLIDACIONDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    ImprimirTickets(dgDoctoId);

                }
                else if (fACTURASDECONSOLIDACIONDataGridView.Columns[e.ColumnIndex].Name == "DGABONOS")
                {
                    long dgDoctoId = (long)fACTURASDECONSOLIDACIONDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("itemid", dgDoctoId);
                    string strReporte = "InformeAbonosPorConsolidado.frx";


                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);

                }
                else if (fACTURASDECONSOLIDACIONDataGridView.Columns[e.ColumnIndex].Name == "DGCANCELAR")
                {
                    //confirmar que el usuario quiere cancelar la factura consolidada
                    if (MessageBox.Show("Esta seguro de que desea cancelar la factura consolidada ?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    long dgDoctoId = (long)fACTURASDECONSOLIDACIONDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    CCONSOLIDADOD consolidadoD = new CCONSOLIDADOD();
                    long doctoCancelacionId = 0;

                    if (!consolidadoD.CONSOLIDADO_CHECARPOSIBILIDAD_CANCELAR(dgDoctoId, CurrentUserID.CurrentUser.IID,  null))
                    {
                        MessageBox.Show("No se pudo cancelar : " + consolidadoD.IComentario);
                        return;
                    }

                    CDOCTOD doctoD = new CDOCTOD();
                    CDOCTOBE doctoBE = new CDOCTOBE();
                    doctoBE.IID = dgDoctoId;
                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
                    if (doctoBE == null)
                    {

                        MessageBox.Show("La factura ya no aparece en el sistema");
                        return;
                    }



                    //Cancelar la factura en SAT
                    WFFacturaElectronica fe = new WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_CANCELAR, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                    CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                    fe.ShowDialog();
                    bool facturacionCancelada = fe.m_facturacionCancelada;
                    fe.Dispose();
                    GC.SuppressFinalize(fe);
                    if (!facturacionCancelada)
                    {
                        if (MessageBox.Show("No se pudo cancelar la factura electronica en el SAT desde el sistema. Como la venta actual fue facturada electronicamente, tendra que cancelarla tambien en el SAT. Desea continuar con la cancelacion en el sistema?", "Cancelar la transaccion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                            return;
                    }
                    
                    
                    
                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();
                        if(!consolidadoD.CONSOLIDADO_CANCELAR(dgDoctoId, CurrentUserID.CurrentUser.IID, ref doctoCancelacionId, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("No se pudo cancelar : " + consolidadoD.IComentario );
                            return;
                        }



                        fTrans.Commit();
                        fConn.Close();


                        MessageBox.Show("Se cancelo la factura consolidada en el sistema.");




                        LlenarFacturasConsolidadas();

                    }
                    catch(Exception ex)
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("No se pudo cancelar : " + ex.Message);
                    }
                }
            }
        }



        private bool imprimirFacturaElectronicaPorId(long doctoId)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return false;
            }


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





        private bool imprimirTicketFacturaElectronicaPorId(long doctoId)
        {
            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

            if ((bool)doctoBE.isnull["IFOLIOSAT"] || (bool)doctoBE.isnull["IESTATUSDOCTOID"]
               || doctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || doctoBE.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(doctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, doctoBE, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_bForzarImpresionTicket = true;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;

        }

        private void dEVOLUCIONESDECONSOLIDACIONDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (dEVOLUCIONESDECONSOLIDACIONDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIRDEV")
                {
                    long dgDoctoId = (long)dEVOLUCIONESDECONSOLIDACIONDataGridView.Rows[e.RowIndex].Cells["DGDEVID"].Value;
                    imprimirFacturaElectronicaPorId(dgDoctoId);

                }
            }
        }

        private void LlenarRegistrosConsolidados(long doctoId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                this.vENTASDENTRODECONSOLIDADOTableAdapter.Fill(this.dSConsolidados.VENTASDENTRODECONSOLIDADO, /*fechaInicio, fechaFin,*/ (int)doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void ImprimirTickets(long doctoId)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            if (docto == null)
            {

                MessageBox.Show("No se encontro la factura electronica");
                return ;
            }

            LlenarRegistrosConsolidados(docto.IID, docto.IFECHAINI, docto.IFECHAFIN);


            if(this.dSConsolidados.VENTASDENTRODECONSOLIDADO != null)
            {
                foreach(ConsolidadoFact.DSConsolidados.VENTASDENTRODECONSOLIDADORow dr in dSConsolidados.VENTASDENTRODECONSOLIDADO.Rows)
                {
                    try
                    {
                        PosPrinter.ImprimirTicket(dr.ID, 0, true);

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }




    }
}
