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
    public partial class WFPreguntaPrecio : IposForm
    {
        public decimal m_precio = 0;
        public bool m_bProcesado = false;

        public decimal M_precio
        {
            get
            {
                return this.m_precio;
            }
            set
            {
                this.m_precio = value;
            }
        }



        public WFPreguntaPrecio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_precio = decimal.Parse(NTPrecio.Text);
            m_bProcesado = true;
            this.Close();
        }
    }
}
