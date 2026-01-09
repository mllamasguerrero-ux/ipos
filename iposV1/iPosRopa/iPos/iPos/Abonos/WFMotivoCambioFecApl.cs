using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Abonos
{
    public partial class WFMotivoCambioFecApl : Form
    {
        public DateTime m_fechaAplicacion = DateTime.Today;
        public long m_motivoId = 0;
        public WFMotivoCambioFecApl()
        {
            InitializeComponent();
        }
        public WFMotivoCambioFecApl(DateTime _fechaAplicacion):this()
        {
            m_fechaAplicacion = _fechaAplicacion;
        }

        private void BTContinuar_Click(object sender, EventArgs e)
        {
            if (this.MOTIVOComboBox.SelectedIndex >= 0)
            {
                m_motivoId = long.Parse(this.MOTIVOComboBox.SelectedValue.ToString());
                m_fechaAplicacion = DTPFechaAplicado.Value;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un motivo valido");
            }
        }

        private void WFMotivoCambioFecApl_Load(object sender, EventArgs e)
        {
            DTPFechaAplicado.Value = m_fechaAplicacion;
            this.MOTIVOComboBox.llenarDatos();
        }
    }
}
