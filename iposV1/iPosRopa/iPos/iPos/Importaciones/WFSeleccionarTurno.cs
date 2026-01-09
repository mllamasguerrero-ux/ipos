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
    public partial class WFSeleccionarTurno : IposForm
    {
        public long lTurnoId;
        public WFSeleccionarTurno()
        {
            InitializeComponent();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            lTurnoId = long.Parse(CBTurno.SelectedValue.ToString());
            this.Close();
        }

        private void WFExportarPedidos_Load(object sender, EventArgs e)
        {
            lTurnoId = 0;
            CBTurno.llenarDatos();
            CBTurno.SelectedIndex = 0;
        }
    }
}
