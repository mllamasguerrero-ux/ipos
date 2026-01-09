using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Importaciones;
using System.Collections;
using iPosData;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;

namespace iPos
{
    public partial class WFImportarPrecTemp : IposForm
    {
        public bool m_importacionExitosa;
        private string m_iComentario;
        public WFImportarPrecTemp()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            ImportarDBF iDBF = new ImportarDBF();
            ArrayList strErrores = new ArrayList();

            if (iDBF.ImportarArchivosPreciosTemp(CIMP_FILESD.FileType_PreciosTemp, CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref strErrores))
            {
                m_importacionExitosa = true;

            }
            else
            {
                m_iComentario = iDBF.IComentario;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {
                //MessageBox.Show("Los archivos han sido importados");
                
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
            this.Close();
        }




        private void WFImportarPrecTemp_Load(object sender, EventArgs e)
        {


            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

    }
}
