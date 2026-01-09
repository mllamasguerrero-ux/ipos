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
    public partial class WFUpdateProductosMovil_2 : IposForm
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

        public WFUpdateProductosMovil_2()
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

            if (currentProgress >= 5)
            {
                MessageBox.Show("La actualizaciòn se ha terminado ");
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
                case 0: PreparandoInfoEnServer(); break;
                case 1: ImportarArchivos(); break;
                case 2: LimpiarInventario(); break;
                case 3: ImportarInventario(); break;
                case 4: ImportarClientes(); break;
                default: break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            currentProgress++;
            recursiveChecking();

        }

        private void WFUpdateProductosMovil_2_Load(object sender, EventArgs e)
        {
            progressBars = new ProgressBar[] { progressBar0A, progressBar00, progressBar01, progressBar02, progressBar03 };
            backgroundWorkers = new BackgroundWorker[] { backgroundWorkerA, backgroundWorker0, backgroundWorker1, backgroundWorker2, backgroundWorker3 };
            checkboxes = new CheckBox[] { checkBoxA, checkBox0, checkBox1, checkBox2, checkBox3 };


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

            bError = !ImportaFtpMovil.ImportarProdOnly_2(ref errores, CurrentUserID.CurrentParameters, true);

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


        private void PreparandoInfoEnServer()
        {


            string error = "";
            bError = !ImportaFtpMovil.PrepareFileInServerForMovil(ref error);

            this.strError = "";
            if (bError)
            {
                strError = error;

            }

        }


        private void ImportarArchivos()
        {
            //Thread.Sleep(2000);
            bError = !ImportaFtpMovil.ImportarArchivos();

            if (bError)
            {
                this.strError = "Error al importar archivos del ftp";
            }
        }


        private void ImportarClientes()
        {

            ArrayList errores = new ArrayList();
            bError = !ImportaFtpMovil.ImportarClientes(ref errores, CurrentUserID.CurrentParameters);

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
                CPERSONAD personaD = new CPERSONAD();
                bError = !personaD.limpiarClientesInactivos(null);
                if (bError)
                {
                    strError = personaD.IComentario;
                }
            }
        }



    }
}
