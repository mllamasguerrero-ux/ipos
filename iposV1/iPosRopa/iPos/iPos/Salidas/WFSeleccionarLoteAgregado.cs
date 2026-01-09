using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFSeleccionarLoteAgregado : Form
    {
        public ArrayList loteList = new ArrayList();
        public string lote = "";
        public WFSeleccionarLoteAgregado()
        {
            InitializeComponent();
        }

        private void WFSeleccionarLoteAgregado_Load(object sender, EventArgs e)
        {
            foreach(string str in loteList)
            {
                CBListLotes.Items.Add(str);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(RBYaAgregado.Checked)
            {
                if(CBListLotes.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un lote valido");
                    return;
                }

                lote = CBListLotes.SelectedItem.ToString();

                
            }
            else
            {
                lote = "";
            }

            this.Close();

           
        }
    }
}
