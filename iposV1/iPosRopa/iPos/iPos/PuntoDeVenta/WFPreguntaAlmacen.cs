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
    public partial class WFPreguntaAlmacen : IposForm
    {
        public long m_almacenorigenid = 0;
        public long m_almacendestinoid = 0;
        public string m_destino = "";

        public WFPreguntaAlmacen()
        {
            InitializeComponent();
        }

        private void btnTraspasoAlmacenes_Click(object sender, EventArgs e)
        {

            if (this.ALMACENORIGENComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                return;
            }

            if (this.ALMACENDESTINOComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("por favor seleccione un almacen valido de la lista ");
                return;
            }

            m_almacenorigenid = long.Parse(this.ALMACENORIGENComboBox.SelectedValue.ToString());
            m_almacendestinoid = long.Parse(this.ALMACENDESTINOComboBox.SelectedValue.ToString());

            if (m_almacendestinoid == m_almacenorigenid)
            {
                m_almacendestinoid = 0;
                m_almacenorigenid = 0;
                MessageBox.Show("los almacenes origen y destino no pueden ser iguales ");
                return;
            }

            m_destino = this.ALMACENDESTINOComboBox.SelectedDataDisplaying.ToString();

            this.Close();

        }

        private void WFPreguntaAlmacen_Load(object sender, EventArgs e)
        {
            this.ALMACENORIGENComboBox.llenarDatos();
            this.ALMACENDESTINOComboBox.llenarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
