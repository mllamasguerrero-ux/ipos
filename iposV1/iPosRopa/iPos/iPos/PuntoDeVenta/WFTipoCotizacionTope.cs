using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.PuntoDeVenta
{
    public partial class WFTipoCotizacionTope : Form
    {
        public bool m_conTopes = false;

        public WFTipoCotizacionTope()
        {
            InitializeComponent();
        }

        private void btnConsiderandoTopes_Click(object sender, EventArgs e)
        {
            m_conTopes = true;
            this.Close();
        }

        private void btnSinTopes_Click(object sender, EventArgs e)
        {
            m_conTopes = false;
            this.Close();
        }
    }
}
