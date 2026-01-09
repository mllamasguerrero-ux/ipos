using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace iPos
{
    public partial class WFSeleccionarFormaPagoFE : IposForm
    {
        ArrayList m_formaspago ;
        public string m_formapagoselected = "";
        public WFSeleccionarFormaPagoFE()
        {
            InitializeComponent();
        }

        public WFSeleccionarFormaPagoFE(ArrayList  formaspago): this()
        {
            m_formaspago = formaspago;
            foreach( string str in m_formaspago)
            {
                this.comboBox1.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex >= 0)
            {
                m_formapagoselected = this.comboBox1.SelectedItem.ToString();
                this.Close();
            }
            else{
                MessageBox.Show("Debe seleccionar una forma de pago");
            }
        }
    }
}
