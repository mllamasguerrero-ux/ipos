using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Inventario
{
    public partial class WFActualizandoKITMultiNivel : Form
    {
        public WFActualizandoKITMultiNivel()
        {
            InitializeComponent();
        }

        private void WFActualizandoKITMultiNivel_Load(object sender, EventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CINVENTARIOD invD = new CINVENTARIOD();
            invD.KITDEFUNNIVEL_REFRESH_SI_REQ(null);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
