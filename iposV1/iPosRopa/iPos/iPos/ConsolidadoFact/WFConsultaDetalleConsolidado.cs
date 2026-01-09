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
    public partial class WFConsultaDetalleConsolidado : Form
    {
        CDOCTOBE m_Docto;
        public WFConsultaDetalleConsolidado()
        {
            InitializeComponent();
            m_Docto = new CDOCTOBE();
        }

        public WFConsultaDetalleConsolidado(CDOCTOBE docto): this()
        {
            m_Docto = docto;
        }
        private void LlenarGrid()
        {
            try
            {
                this.vENTASDENTRODECONSOLIDADOTableAdapter.Fill(this.dSConsolidados.VENTASDENTRODECONSOLIDADO, /*m_Docto.IFECHAINI, m_Docto.IFECHAFIN,*/(int)m_Docto.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFConsultaDetalleConsolidado_Load(object sender, EventArgs e)
        {
            LlenarGrid();

            LBLSERIEFOLIO.Text = ((bool)m_Docto.isnull["ISERIESAT"] ? "" : m_Docto.ISERIESAT) + ((bool)m_Docto.isnull["IFOLIOSAT"] ? "" : m_Docto.IFOLIOSAT.ToString());
            LBLFECHAINI.Text = m_Docto.IFECHAINI.ToString("dd/MM/yyyy");
            LBLFECHAFIN.Text = m_Docto.IFECHAFIN.ToString("dd/MM/yyyy");
            LBLFECHAFACTURA.Text = m_Docto.IFECHA.ToString("dd/MM/yyyy");
        }

        private void LlenaDetalles(long lDoctoId)
        {
            try
            {
                this.dETALLESVENTASDENTROCONSOLIDADOTableAdapter.Fill(this.dSConsolidados.DETALLESVENTASDENTROCONSOLIDADO, (int)lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dETALLESVENTASDENTROCONSOLIDADODataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vENTASDENTRODECONSOLIDADODataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;

                long lDoctoId = long.Parse(vENTASDENTRODECONSOLIDADODataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value.ToString());
                LlenaDetalles(lDoctoId);
            }
            catch
            {
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


        private void ImprimirTickets()
        {

            

            if (this.dSConsolidados.VENTASDENTRODECONSOLIDADO != null)
            {
                foreach (ConsolidadoFact.DSConsolidados.VENTASDENTRODECONSOLIDADORow dr in dSConsolidados.VENTASDENTRODECONSOLIDADO.Rows)
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

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            imprimirFacturaElectronicaPorId(this.m_Docto.IID);
        }

        private void btnImprimirTickets_Click(object sender, EventArgs e)
        {
            ImprimirTickets();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
