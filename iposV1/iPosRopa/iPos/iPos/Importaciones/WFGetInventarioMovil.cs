using iPos.WebServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSGetProducta4App.DAO.businessEntity;

namespace iPos.Importaciones
{
    public partial class WFGetInventarioMovil : Form
    {
        private string urlWSGetInventarioContainer = @"http://" +
                      CurrentUserID.CurrentParameters.IIPWEBSERVICEAPPINV + 
                      "/InventarioWS/WSInventarioApp.svc/getContainers";

        private bool m_importacionExitosa;
        private string m_iComentario;
        List<InvMovilContainerResponse> items = new List<InvMovilContainerResponse>();
        public WFGetInventarioMovil()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void WFGetInventarioMovil_Load(object sender, EventArgs e)
        {
            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            if (backgroundWorker1.IsBusy != true)
            {
                //Empieza la operacion asincrona
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //Funcion para cargar los docto en importacion de inventario
        {
            items = new List<InvMovilContainerResponse>();
            WSConnectionInventarioApp WSInvApp = new WSConnectionInventarioApp();
            try
            {
                if (WSInvApp.getLocationContainer(ref items))
                {
                    m_importacionExitosa = true;

                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Error:" + exc);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;

            if (m_importacionExitosa)
            {
                
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }

            iPos.Importaciones.WFImportacionInventarioMovil rp = new iPos.Importaciones.WFImportacionInventarioMovil(items);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
            this.Close();
        }

        
    }
}
