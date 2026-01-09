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
    public partial class WFProductosSinClaveSat : Form
    {
        public WFProductosSinClaveSat(long doctoId)
        {
            InitializeComponent();
            this.pRODUCTOS_SIN_CLAVESATTableAdapter.Fill(this.dSSatFacturacion.PRODUCTOS_SIN_CLAVESAT, int.Parse(doctoId.ToString()));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
