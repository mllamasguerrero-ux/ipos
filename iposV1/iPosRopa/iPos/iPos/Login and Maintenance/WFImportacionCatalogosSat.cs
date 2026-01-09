
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;

namespace iPos.Login_and_Maintenance
{
    public partial class WFImportacionCatalogosSat : Form
    {
        public bool importSuccess;

        private CatalogosSatHelper catSatHelper;

        private ArrayList strErrores;
        
        private bool m_bEsImportacionInicial = false;

        private string m_versionCatalogToUpdate = "";

        public WFImportacionCatalogosSat(bool bEsImportacionInicial, string versionCatalogToUpdate)
        {
            InitializeComponent();
            m_bEsImportacionInicial = bEsImportacionInicial;
            m_versionCatalogToUpdate = versionCatalogToUpdate;

            progressBar.Style = ProgressBarStyle.Marquee;
            catSatBackgroundWorker = new BackgroundWorker();
            catSatBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(catSatBackgroundWorker_DoWork);
            catSatBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(catSatBackgroundWorker_RunWorkerCompleted);
            catSatBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(catSatBackgroundWorker_ProgressChanged);
            catSatBackgroundWorker.WorkerReportsProgress = true;

            importSuccess = false;
            catSatHelper = new CatalogosSatHelper();

            catSatBackgroundWorker.RunWorkerAsync();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void catSatBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (m_versionCatalogToUpdate.Equals("2022"))
            {
                importSuccess = catSatHelper.ImportarCatalogos_2022(ref strErrores, m_bEsImportacionInicial);
            }
            if (m_versionCatalogToUpdate.Equals("2022A"))
            {
                importSuccess = catSatHelper.ImportarCatalogos_2022_A(ref strErrores, m_bEsImportacionInicial);
            }
            else if (m_versionCatalogToUpdate.Equals("201x"))
            {
                importSuccess = catSatHelper.ImportarCatalogos(ref strErrores, m_bEsImportacionInicial);
            }
        }

        private void catSatBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void catSatBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Blocks;


            if (importSuccess)
            {
                //MessageBox.Show("Importacion exitosa");
                this.Close();
            }
            else
            {
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }

                MessageBox.Show("Error " + strMensajeError);
            }
        }
    }
}
