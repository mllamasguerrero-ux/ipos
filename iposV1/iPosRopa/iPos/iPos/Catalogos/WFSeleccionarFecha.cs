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
    public partial class WFSeleccionarFecha : Form
    {
        public DateTime? m_dateSelected = null;

        public WFSeleccionarFecha()
        {
            InitializeComponent();
        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {
            m_dateSelected = dateTimePicker1.Value;
            this.Close();
        }
    }
}
