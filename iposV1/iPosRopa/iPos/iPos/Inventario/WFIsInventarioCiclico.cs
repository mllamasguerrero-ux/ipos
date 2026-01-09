using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Inventario
{
    public partial class WFIsInventarioCiclico : Form
    {
        public bool EsInventarioCiclico = false;
        public WFIsInventarioCiclico()
        {
            InitializeComponent();
        }

        private void WFIsInventarioCiclico_Load(object sender, EventArgs e)
        {
            this.BTContinuar.Focus();
        }

        private void BTContinuar_Click(object sender, EventArgs e)
        {
            this.EsInventarioCiclico = false;
            this.Close();
        }

        private void BTInventarioCiclico_Click(object sender, EventArgs e)
        {

            this.EsInventarioCiclico = true;
            this.Close();
        }
    }
}
