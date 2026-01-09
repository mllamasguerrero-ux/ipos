using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFCancelacionAltSeleccion : Form
    {
        public string strSeleccionCancelacion = "NotaCredito";
        public WFCancelacionAltSeleccion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelacion_Click(object sender, EventArgs e)
        {
            strSeleccionCancelacion = "Salir";
            this.Close();
        }

        private void SeleccionarPorRadioButton()
        {

            if (RBNotaCredito.Checked)
                strSeleccionCancelacion = "NotaCredito";
            else
                strSeleccionCancelacion = "Sustitucion";
        }

        private void RBNotaCredito_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionarPorRadioButton();
        }

        private void RBSustitucion_CheckedChanged(object sender, EventArgs e)
        {

            SeleccionarPorRadioButton();
        }
    }
}
