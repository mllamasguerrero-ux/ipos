using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPosReporting
{
    public partial class WFReferenciaPago : Form
    {
        public string m_referencia;
        public WFReferenciaPago()
        {
            InitializeComponent();
            m_referencia = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TBReferencia.Text == "")
            {
                MessageBox.Show("porfavor ingrese una referencia valida");
                return;
            }
            else
            {
                m_referencia = TBReferencia.Text;
                this.Close();
            }
        }
    }
}
