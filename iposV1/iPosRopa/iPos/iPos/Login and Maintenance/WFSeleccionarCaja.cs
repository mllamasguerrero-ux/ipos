using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Login_and_Maintenance
{
    public partial class WFSeleccionarCaja : IposForm
    {

        public long m_selectedCaja;
        public WFSeleccionarCaja()
        {
            InitializeComponent();
            m_selectedCaja = -1;
        }

        private void WFSeleccionarCaja_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSAccessControl.CAJA' table. You can move, or remove it, as needed.
            this.cAJATableAdapter.Fill(this.dSAccessControl.CAJA);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cAJAComboBox.SelectedIndex >= 0)
            {
                m_selectedCaja = (long)this.cAJAComboBox.SelectedValue;
                this.Close();
            }
        }
    }
}
