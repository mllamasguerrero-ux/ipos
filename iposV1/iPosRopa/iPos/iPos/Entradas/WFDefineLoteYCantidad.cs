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
    public partial class WFDefineLoteYCantidad : IposForm
    {

        public decimal m_cantidad = 0;
        public string m_lote = "";
        public DateTime m_fechaVence = DateTime.Today;
        public WFDefineLoteYCantidad()
        {
            InitializeComponent();
        }

        private void WFDefineLoteYCantidad_Load(object sender, EventArgs e)
        {

        }

        private void BTAsignar_Click(object sender, EventArgs e)
        {

            if (TBLote.Text.Trim().Equals(""))
            {

                if (MessageBox.Show("El lote esta vacio. Desea dejarlo asi?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }


            m_cantidad = decimal.Parse(TBCantidad.Text);

            if (m_cantidad == 0)
            {
                MessageBox.Show("Ingrese una cantidad mayor de cero");
                return;
            }

            m_lote = TBLote.Text;
            m_fechaVence = DTP.Value;
           
            this.Close();
        }

    }
}
