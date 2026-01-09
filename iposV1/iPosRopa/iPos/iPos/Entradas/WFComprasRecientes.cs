using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Entradas
{
    partial class WFComprasRecientes : IposForm
    {


        public WFComprasRecientes()
        {
            InitializeComponent();
        }


        private void WFComprasRecientes_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarGridUltimasCompras();
                LlenarGridUltimasCompras3dias();
            }
            catch { }

        }


        private void LlenarGridUltimasCompras()
        {
            uLTIMASCOMPRASTableAdapter.Fill(this.dSEntrada3.ULTIMASCOMPRAS, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1), DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
        }


        private void LlenarGridUltimasCompras3dias()
        {
            uLTIMASCOMPRAS3DIASTableAdapter.Fill(this.dSEntrada3.ULTIMASCOMPRAS3DIAS, DateTime.Today.AddDays(-4), DateTime.Today.AddDays(-2), DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-2));
        }
    }
}
