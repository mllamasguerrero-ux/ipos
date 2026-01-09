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

namespace iPos
{
    public partial class WFCobranzaMovilDetalle : iPos.Tools.ScreenConfigurableForm
    {

        CCOBRANZAMOVILBE m_cobranzaMovilBE = null;
        long m_cobranzaMovilId = 0;

        public WFCobranzaMovilDetalle()
        {
            InitializeComponent();
        }

        public WFCobranzaMovilDetalle(long cobranzaMovilId):this()
        {
            m_cobranzaMovilId = cobranzaMovilId;
        }

        private void LlenarGrid(int cobranzaId)
        {
            try
            {
                this.pAGOPORCOBRANZATableAdapter.Fill(this.dSMovil2.PAGOPORCOBRANZA, cobranzaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFCobranzaMovilDetalle_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(false, true);

            CCOBRANZAMOVILBE cobranzaBE = new CCOBRANZAMOVILBE();
            CCOBRANZAMOVILD cobranzaD = new CCOBRANZAMOVILD();

            if(m_cobranzaMovilId != 0)
            {
                cobranzaBE.IID = m_cobranzaMovilId;
                cobranzaBE = cobranzaD.seleccionarCOBRANZAMOVIL(cobranzaBE, null);

                COBRANZATEXT.Text = cobranzaBE.ICOBRANZA;
                FACTURATEXT.Text = cobranzaBE.IFACTURA;
                VENTATEXT.Text = cobranzaBE.IVENTA;

                if (cobranzaBE != null)
                {
                    m_cobranzaMovilBE = cobranzaBE;
                    LlenarGrid((int)m_cobranzaMovilId);
                }
            }
            else
            {
                m_cobranzaMovilBE = cobranzaBE;
            }
        }

        private void pAGOPORCOBRANZADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (pAGOPORCOBRANZADataGridView.Columns[e.ColumnIndex].Name == "VERPAGO")
            {
                    long pagoMovilId = long.Parse(pAGOPORCOBRANZADataGridView.Rows[e.RowIndex].Cells["DGPAGOMOVILID"].Value.ToString());
                    WFPagoMovil wf = new WFPagoMovil("", pagoMovilId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
            }
        }
    }
}
