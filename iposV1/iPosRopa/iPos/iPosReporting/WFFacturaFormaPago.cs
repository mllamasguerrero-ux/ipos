using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;

namespace iPosReporting
{
    public partial class WFFacturaFormaPago : Form
    {
        int m_doctoId;
        public DataRow m_rtnDataRow;
        //bool m_PagoNoRegistrado;


        FbTransaction m_fTrans = null;


        public WFFacturaFormaPago()
        {
            InitializeComponent();
        }

        public WFFacturaFormaPago(int doctoId)
        {
            InitializeComponent();
            m_doctoId = doctoId;

        }


        public WFFacturaFormaPago(int doctoId, FbTransaction fTrans):this(doctoId)
        {
            this.m_fTrans = fTrans;
        }


        private void LlenarTabla()
        {
            try
            {
                if(m_fTrans != null)
                {
                    this.dOCTOPAGOTableAdapter.Transaction = m_fTrans;
                    this.dOCTOPAGOTableAdapter.Connection = m_fTrans.Connection;
                }
                this.dOCTOPAGOTableAdapter.Fill(this.dSIposReportingC.DOCTOPAGO, m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }




        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && TableDataGridView.CurrentRow.Index < (TableDataGridView.RowCount - 1))
                                       ? TableDataGridView.CurrentRow.Index - 1 :*/ TableDataGridView.CurrentRow.Index;
                DataGridViewRow dr = TableDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void TableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
               RetornarSeleccion(false);
            }
        }

        private void TableDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private bool SeleccionarPagoPara33SiAplica()
        {
            DSIposReportingC.DOCTOPAGORow rowTope = null;
            bool duplicadosEnTope = false;

            List<DSIposReportingC.DOCTOPAGORow> formasDePagoAQuitar = new List<DSIposReportingC.DOCTOPAGORow>();
            List<DSIposReportingC.DOCTOPAGORow> formasDePagoDuplicados = new List<DSIposReportingC.DOCTOPAGORow>();

            foreach (DSIposReportingC.DOCTOPAGORow dr in dSIposReportingC.DOCTOPAGO.Rows)
            {
                if(dr.FORMAPAGOID ==  DBValues._FORMA_PAGO_CREDITO)
                {
                    m_rtnDataRow = dr;
                    return true;

                }

                if (rowTope != null)
                {
                    if (rowTope.IMPORTE > dr.IMPORTE)
                    {
                        formasDePagoAQuitar.Add(dr);
                    }
                    else if (rowTope.IMPORTE < dr.IMPORTE)
                    {
                        formasDePagoAQuitar.Add(rowTope);
                        formasDePagoAQuitar.AddRange(formasDePagoDuplicados);
                        rowTope = dr;
                        formasDePagoDuplicados.Clear();
                        duplicadosEnTope = false;
                    }
                    else
                    {
                        duplicadosEnTope = true;
                        formasDePagoDuplicados.Add(dr);
                    }
                }
                else
                {
                    rowTope = dr;
                }

            }

            if(duplicadosEnTope)
            {
                foreach (DSIposReportingC.DOCTOPAGORow dr in formasDePagoAQuitar)
                {
                    dSIposReportingC.DOCTOPAGO.Rows.Remove(dr);
                }
                
            }
            else
            {

                m_rtnDataRow = rowTope;
                return true;
            }

            return false;
        }

        private void WFFacturaFormaPago_Load(object sender, EventArgs e)
        {

            LlenarTabla();
            //m_PagoNoRegistrado = false;

            if (this.dSIposReportingC.DOCTOPAGO.Rows.Count == 1)
            {

                m_rtnDataRow = this.dSIposReportingC.DOCTOPAGO.Rows[0];
                this.Close();
                return;
            }
            else if (this.dSIposReportingC.DOCTOPAGO.Rows.Count == 0)
            {
                //m_PagoNoRegistrado = true;
                this.Close();
                return;
            }

            if(ConexionesBD.ConexionBD.CurrentParameters.IVERSIONCFDI != null && (ConexionesBD.ConexionBD.CurrentParameters.IVERSIONCFDI.Equals("3.3") || ConexionesBD.ConexionBD.CurrentParameters.IVERSIONCFDI.Equals("4.0")))
            {
                if(SeleccionarPagoPara33SiAplica())
                {
                    this.Close();
                    return;
                }
            }

            
        }




    }
}
