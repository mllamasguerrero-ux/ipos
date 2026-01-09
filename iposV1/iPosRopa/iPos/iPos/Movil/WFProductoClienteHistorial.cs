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
    public partial class WFProductoClienteHistorial : iPos.Tools.ScreenConfigurableForm
    {
        long m_productoid = 0;
        long m_personaid = 0;

        public WFProductoClienteHistorial()
        {
            InitializeComponent();
        }


        public WFProductoClienteHistorial(long productoid, long personaid): this()
        {
            m_productoid = productoid;
            m_personaid = personaid;
        }

        private void LlenarGrid()
        {
            try
            {
                this.hISTORIALTableAdapter.Fill(this.dSMovil.HISTORIAL, m_personaid, m_productoid);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFProductoClienteHistorial_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(true, true);
            LlenarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
