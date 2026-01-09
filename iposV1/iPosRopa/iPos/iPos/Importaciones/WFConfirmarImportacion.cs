using DataLayer.Importaciones;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace iPos.Importaciones
{
    public partial class WFConfirmarImportacion : Form
    {
       private bool m_importacionExitosa = false;
        private string m_iComentario;
        private Thread timerThread;
        private Dispatcher dispatcher;
        private bool processCompleted;
        private bool acceptButtonClicked;
        

        public bool ProcessCompleted
        {
            get { return processCompleted; }
            set { processCompleted = value; }
        }


        public bool M_importacionExitosa
        {
            get { return m_importacionExitosa; }
            set { m_importacionExitosa = value; }
        }


        public WFConfirmarImportacion()
        {
            InitializeComponent();
            this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            acceptButtonClicked = false;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            acceptButtonClicked = true;

            if (timerThread.IsAlive)
            {
                timerThread.Abort();
            }

            ApplyChanges();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CurrentUserID.CurrentParameters.INUMCANCELACTAUTOUSUARIO++;
            if(ActualizarParametro(CurrentUserID.CurrentParameters))
            {
                processCompleted = false;
                timerThread.Abort();
                this.Close();
            }
            else
            {
                MessageBox.Show("Problema al actualizar el parametro NUMCANCELACTAUTOUSUARIO");
            }
        }

        private void WFConfirmarImportacion_Load(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.INUMCANCELACTAUTOUSUARIO >= CurrentUserID.CurrentParameters.INUMCANCELACTAUTO)
            {
                cancelButton.Enabled = false;
            }

            timerThread = new Thread(new ThreadStart(timerLoop));
            timerThread.Start();
        }

        private void importBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();

            if (iDBF.ImportarArchivosCatalogos(CIMP_FILESD.FileType_Producto, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;
            }
            else
            {
                //m_iComentario = iDBF.IComentario;
                string strMensajeError = "";
                foreach (string str in strErrores)
                {
                    strMensajeError = str + "\n";
                }
                m_iComentario = strMensajeError;
            }
        }

        private void importBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if(m_importacionExitosa)
            {

                mainMessageLabel.Text = "Datos importados";
                progressBar.Visible = false;
            }
            else
            {

                mainMessageLabel.Text = m_iComentario + "\n Se reintentara importar de nuevo en 20 minutos";
                progressBar.Visible = false;
            }

        }

        private void timerLoop()
        {
            int count = 30;

            while (count > 0)
            {
                count--;

                this.dispatcher.Invoke(new Action(() =>
                {
                    this.counterLabel.Text = count.ToString();
                }));

                Thread.Sleep(1000);
            }


            this.dispatcher.Invoke(new Action(() =>
            {
                ApplyChanges();
            }));

        }

        private void WFConfirmarImportacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                timerThread.Abort();
                if (m_importacionExitosa)
                {
                    WFProductoCambioPrecio pcpForm = new WFProductoCambioPrecio();
                    pcpForm.Show();
                 }
            }
            catch
            {

            }
        }

        private void ApplyChanges()
        {
            CurrentUserID.CurrentParameters.INUMCANCELACTAUTOUSUARIO = 0;
            if (ActualizarParametro(CurrentUserID.CurrentParameters))
            {
                cancelButton.Visible = false;
                secondaryMessageLabel.Visible = false;
                acceptButton.Visible = false;
                mainMessageLabel.Text = "Importando datos";
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Marquee;
                counterLabel.Visible = false;
                importBackgroundWorker.RunWorkerAsync();
                processCompleted = true;
                this.ControlBox = true;
            }
            else
            {
                MessageBox.Show("Error al actualizar el parametro NUMCANCELACTAUTOUSUARIO");
            }
        }

        private bool ActualizarParametro(CPARAMETROBE param)
        {
            CPARAMETROD paramDao = new CPARAMETROD();

            return paramDao.CambiarNUMCANCELACTAUTOUSUARIO(param, param, null);
        }
    }
}
