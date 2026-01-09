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
using iPosBusinessEntity;

namespace iPos.Exportaciones
{
    public partial class WFExportarCubo : Form
    {
        private bool m_importacionExitosa;
        private string m_iComentario;
        public WFExportarCubo()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            ExportarCuboDBF iDBF = new ExportarCuboDBF();
            ArrayList strErrores = new ArrayList();
            
            if(CBTransacciones.Checked)
            {
                LlenarGridVEDME();
            }

            if (iDBF.ExportCuboInfo(CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, DateTime.Now, 
                                    this.CBCatalogos.Checked,
                                    this.CBPersonas.Checked,
                                    this.CBTransacciones.Checked,
                                    this.dSCubo.CUBOINFOVEDME,
                                    ref strErrores))
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
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            m_importacionExitosa = false;
            m_iComentario = "";
            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

        private void WFExportarCubo_Load(object sender, EventArgs e)
        {
            
        }

        private void LlenarGridVEDME()
        {
            try
            {
                this.cUBOINFOVEDMETableAdapter.Fill(this.dSCubo.CUBOINFOVEDME, this.DTPInicial.Value, this.DTPFinal.Value);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
