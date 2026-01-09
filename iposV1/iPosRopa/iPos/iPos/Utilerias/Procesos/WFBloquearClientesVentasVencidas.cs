using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;

namespace iPos.Utilerias.Procesos
{
    public partial class WFBloquearClientesVentasVencidas : Form
    {
        public WFBloquearClientesVentasVencidas()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            CCLIENTED clienteD = new CCLIENTED();
            int iDiasVencidos = (int)DiasNumericTextBox.Value;
            if(clienteD.BloquearClientesConVentasVencidas(iDiasVencidos, null))
            {
                MessageBox.Show("Se hicieron los bloqueos correspondientes");
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error " +  clienteD.iComentario);
            }
        }
    }
}
