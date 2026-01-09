using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Tools
{
    public partial class WFFbDbFixer : Form
    {
        private string filePath;
        private FbDbFixer fbDbFixerHelper;
        private bool noErrorsFound;

        public bool NoErrorsFound { get => noErrorsFound; set => noErrorsFound = value; }

        public WFFbDbFixer(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            //Inicializar el helper con el path del archivo a reparar
            fbDbFixerHelper = new FbDbFixer();
            fbDbFixerHelper.FilePath = filePath;

            loadingProgressBar.Style = ProgressBarStyle.Marquee;

            dbFixerBackgroundWorker.WorkerReportsProgress = true;
            dbFixerBackgroundWorker.RunWorkerAsync();
        }

        private void dbFixerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dbFixerBackgroundWorker.ReportProgress(0, "Checando errores...");
            if(fbDbFixerHelper.CheckForErrors())
            {
                dbFixerBackgroundWorker.ReportProgress(0, "Reparando errores...");
                e.Result = fbDbFixerHelper.FixErrors();
            }
            else
            {
                e.Result = "No se encontraron errores en el archivo.";
            }
        }

        private void dbFixerBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = e.Result.ToString();

            if (result.Equals("No se encontraron errores en el archivo.") ||
                result.Contains("New file errors: NO ERRORS FOUND!!!"))
            {
                NoErrorsFound = true;
            }
            else NoErrorsFound = false;

            WFCmdOutput wFCmdOutput = new WFCmdOutput(result);
            wFCmdOutput.ShowDialog();
            wFCmdOutput.Dispose();
            GC.SuppressFinalize(wFCmdOutput);

            Close();
        }

        private void dbFixerBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingMsgLabel.Text = e.UserState.ToString();
        }
    }
}
