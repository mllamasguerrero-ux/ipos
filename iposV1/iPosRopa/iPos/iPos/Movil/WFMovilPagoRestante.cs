using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFMovilPagoRestante : IposForm
    {
        public int m_iRestanteSelection = -1;
        public DataRow m_rtnDataRow = null;

        public WFMovilPagoRestante()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RBAnticipo.Checked)
                m_iRestanteSelection = 1;


            else if (this.RBAplicarOtra.Checked)
            {
                if(m_rtnDataRow == null)
                {
                    MessageBox.Show("Debe seleccionar una venta");
                    return;
                }
                m_iRestanteSelection = 2;
            }

            /*else if (this.RBCambio.Checked)
                m_iRestanteSelection = 3;*/

            this.Close();
        }

        private void btnSeleccionarVenta_Click(object sender, EventArgs e)
        {
            WFCobranzaMovil wf = new WFCobranzaMovil(true);
            wf.ShowDialog();
            m_rtnDataRow = wf.m_rtnDataRow;
            wf.Dispose();
            GC.SuppressFinalize(wf);


            if(m_rtnDataRow != null)
            {
                try
                {
                    lblOtraVenta.Text = m_rtnDataRow["COBRANZA"].ToString() + " - " + m_rtnDataRow["VENTA"].ToString();
                }
                catch
                {

                }
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
