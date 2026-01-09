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
    public partial class WFSeleccionVendedor : IposForm
    {
        public long m_vendedorfinal = 0;
        public string m_clavevendedor = "";
        public bool m_bseleccionado = false;
        public WFSeleccionVendedor()
        {
            InitializeComponent();
        }

        public WFSeleccionVendedor(long vendedorfinal,string clavevendedor) : this()
        {
            m_clavevendedor = clavevendedor;
            m_vendedorfinal = vendedorfinal;

        }

        private void WFSeleccionVendedor_Load(object sender, EventArgs e)
        {
            string strBuffer = "";
            if (m_vendedorfinal > 0)
            {
                this.VENDEDORIDTextBox.Text = m_clavevendedor;
                this.VENDEDORIDTextBox.DbValue = m_vendedorfinal.ToString();
                this.VENDEDORIDTextBox.MostrarErrores = false;
                this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.VENDEDORIDTextBox.MostrarErrores = true;
            }
            this.VENDEDORIDTextBox.Focus();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (this.VENDEDORIDTextBox.Text == "" || Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString()) == 0)
            {

                MessageBox.Show("Debe seleccionar el vendedor final ");
                this.VENDEDORIDTextBox.Focus();
                return;
            }

            m_vendedorfinal = Int64.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
            m_clavevendedor = this.VENDEDORIDTextBox.Text;
            m_bseleccionado = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            m_vendedorfinal = 0;
            m_clavevendedor = "";

        }
    }
}
