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
    public partial class WFMatrizExportPrecTemp : IposForm
    {
        public bool m_importacionExitosa;
        private string m_iComentario;
        public WFMatrizExportPrecTemp()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            ExportarDBF iDBF = new ExportarDBF();
            ArrayList strErrores = new ArrayList();

            if (iDBF.ExportMatrizPreciosTemp(CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, DateTime.Now, ref strErrores))
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
                MessageBox.Show("Los archivos han sido exportados");
                
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
            this.Close();
        }




        private void WFMatrizExportPrecTemp_Load(object sender, EventArgs e)
        {


            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

    }
}
