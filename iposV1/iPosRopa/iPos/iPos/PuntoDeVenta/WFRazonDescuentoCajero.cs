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
    public partial class WFRazonDescuentoCajero : IposForm
    {
        public string m_strRazon = "";
        public WFRazonDescuentoCajero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length != 0)
            {
                this.m_strRazon = this.textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor escriba la razon por la cual esta dando un precio menor al precio 1");
            }
        }
    }
}
