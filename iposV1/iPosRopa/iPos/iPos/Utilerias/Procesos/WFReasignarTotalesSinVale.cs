using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;

namespace iPos.Utilerias.Procesos
{
    public partial class WFReasignarTotalesSinVale : Form
    {
        public WFReasignarTotalesSinVale()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            CDOCTOD doctoD = new CDOCTOD();

            if(!doctoD.ASIGNARTOTALESSINVALE_FECHAS(dateTimePicker1.Value, dateTimePicker2.Value, null) )
            {
                MessageBox.Show("Ocurrio un error");
            }
            else
            {
                MessageBox.Show("Las asignaciones de valores pendientes han sido llenadas");
                this.Close();
            }
        }
    }
}
