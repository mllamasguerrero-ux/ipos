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
    public partial class WFPagoPreguntarCredito : IposForm
    {
        public bool m_bAsignarCredito = false;
        public WFPagoPreguntarCredito()
        {
            InitializeComponent();
        }

        private void BtnSi_Click(object sender, EventArgs e)
        {
            m_bAsignarCredito = true;
            this.Close();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            m_bAsignarCredito = false;
            this.Close();
        }
    }
}
