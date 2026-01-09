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
    public partial class WFPreguntarClaveConf : IposForm
    {
        public bool m_permitido;
        public WFPreguntarClaveConf()
        {
            InitializeComponent();
            m_permitido = false;
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if (TBClave.Text == "Twincept.l")
            {
                m_permitido = true;
            }
            this.Close();
        }
    }
}
