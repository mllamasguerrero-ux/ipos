using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Cortes
{
    public partial class CorteBilletesRazonCambio : Form
    {
        public string m_nota;

        public bool m_continuaredicion; 
        

        public CorteBilletesRazonCambio()
        {
            InitializeComponent();
            m_continuaredicion = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textAreaRazon.Text))
            {
                MessageBox.Show("Ingrese la razon antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_nota = textAreaRazon.Text;
                m_continuaredicion = true;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
