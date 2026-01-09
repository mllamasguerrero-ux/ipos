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
    public partial class WFAnticipoConcepto : IposForm
    {
        public string m_concepto = "";
        public WFAnticipoConcepto()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            m_concepto = textBox1.Text;
            this.Close();
        }
    }
}
