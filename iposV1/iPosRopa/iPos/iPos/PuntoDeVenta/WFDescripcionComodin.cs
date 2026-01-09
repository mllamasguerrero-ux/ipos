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
    public partial class WFDescripcionComodin : IposForm
    {

        public bool m_bCancelado = true;
        public string m_descripcion1 = "", m_descripcion2 = "", m_descripcion3 = "";
        public WFDescripcionComodin()
        {
            InitializeComponent();
        }

        public WFDescripcionComodin(string descripcion1 ,string  descripcion2 ,string descripcion3 ):
            this()
        {
            m_descripcion1 = descripcion1;
            m_descripcion2 = descripcion2;
            m_descripcion3 = descripcion3;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            m_bCancelado = true;
            this.Close();
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            if (TBDesc1.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Necesita llenar por lo menos la descripción 1");
            }
            else
            {
                m_descripcion1 = TBDesc1.Text.Trim();
                m_descripcion2 = TBDesc2.Text.Trim();
                m_descripcion3 = TBDesc3.Text.Trim();
                m_bCancelado = false;
                this.Close();
            }
            
        }

        private void WFDescripcionComodin_Load(object sender, EventArgs e)
        {

            TBDesc1.Text = m_descripcion1 ;
            TBDesc2.Text = m_descripcion2 ;
            TBDesc3.Text = m_descripcion3; 
        }
    }
}
