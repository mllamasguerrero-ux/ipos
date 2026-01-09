using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using iPosData;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFUpdateProductosMovil : IposForm
    {
        ProgressBar[] progressBars;
        BackgroundWorker[] backgroundWorkers;
        CheckBox[] checkboxes;
        int currentProgress = 0;
        bool bError = false;
        string strError = "";

        ProgressBar progBar = null;
        BackgroundWorker bgworker = null;
        CheckBox chBox = null;

        public WFUpdateProductosMovil()
        {
            InitializeComponent();
        }


        void inicializar()
        {
            bError = false;
            strError = "";
            currentProgress = 0;
            foreach(CheckBox cb in checkboxes)
            {
                cb.Visible = false;
            }
        }

        void recursiveChecking()
        {
            if (currentProgress > 0 && progBar != null)
            {

                progBar.Style = ProgressBarStyle.Blocks;


                if (bError)
                {
                    MessageBox.Show(strError);
                    inicializar();
                    return;
                }
                
                chBox.Visible = true;
            }

            if (currentProgress >= 3)
            {
                MessageBox.Show("La inicialización se ha terminado ");
                this.Close();
                return;
            }


            progBar = progressBars[currentProgress];
            bgworker = backgroundWorkers[currentProgress];
            chBox = checkboxes[currentProgress];
            progBar.Style = ProgressBarStyle.Marquee;
            bgworker.RunWorkerAsync();


        }

        private void button1_Click(object sender, EventArgs e)
        {
                inicializar();
                recursiveChecking();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (currentProgress)
            {
                case 0: ImportarArchivosProd();  break;
                case 1: LimpiarInventario(); break;
                case 2: ImportarInventario(); break;
                default: break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentProgress++;
            recursiveChecking();

        }

        private void WFUpdateProductosMovil_Load(object sender, EventArgs e)
        {
            progressBars = new ProgressBar[] { progressBar00, progressBar01, progressBar02};
            backgroundWorkers = new BackgroundWorker[] {backgroundWorker0, backgroundWorker1, backgroundWorker2};
            checkboxes = new CheckBox[] { checkBox0, checkBox1, checkBox2};


        }



        private void ImportarArchivosProd()
        {
            //Thread.Sleep(2000);
            bError = !ImportaFtpMovil.ImportarArchivosOnlyProd();

            if (bError)
            {
                this.strError = "Error al importar archivos del ftp";
            }
        }


        private void LimpiarInventario()
        {

            ArrayList errores = new ArrayList();
            string strError = "";
            bError = !ImportaFtpMovil.MOVIL_PRE_INVENTARIO_UPDATE(ref strError, null);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
        }




        private void ImportarInventario()
        {
            ArrayList errores = new ArrayList();
            string strError = "";


            bError = !ImportaFtpMovil.ImportarDatosProdOnly( ref strError);

            this.strError = "";
            if (bError)
            {
                foreach (string str in errores)
                {
                    strError = str + "\n";
                }
            }
            else
            {

                CurrentUserID.GetAutoSourceCollectionFromTable(true);
            }
        }



    }
}
