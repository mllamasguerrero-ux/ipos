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
    public partial class WFPasswordSupervisor : IposForm
    {
        public bool bPassValido;
        public WFPasswordSupervisor()
        {
            InitializeComponent();
            bPassValido = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarContrasena();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidarContrasena()
        {
            if (TBPassword.Text == "1234")
            {
                bPassValido = true;
                this.Close();
            }
            else
                MessageBox.Show("La contraseña proporcionada es incorrecta");
        }

        private void TBPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ValidarContrasena();
            }

        }
    }
}
