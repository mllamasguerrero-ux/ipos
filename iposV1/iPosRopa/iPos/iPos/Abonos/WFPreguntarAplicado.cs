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
    public partial class WFPreguntarAplicado : Form
    {
        public bool bAplicado = false;
        public DateTime fechaAplicado = DateTime.Today;
        public WFPreguntarAplicado()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            bAplicado = CBAplicado.Checked;
            fechaAplicado = DTPFechaAplicado.Value;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bAplicado = false;
            this.Close();
        }
    }
}
