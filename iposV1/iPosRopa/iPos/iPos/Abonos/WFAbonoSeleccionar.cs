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
    public partial class WFSeleccionarAbono : IposForm
    {
        public long m_numeroAbono = 0;
        public WFSeleccionarAbono()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_numeroAbono = long.Parse(this.numeroAbonoTextBox.Text);
            this.Close();
        }
    }
}
