using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataLayer;
using iPosData;

namespace iPos
{
    public partial class WFImportarCatalogoDeExcel : IposForm
    {

        private bool m_importacionExitosa;
        private string m_iComentario;

        public WFImportarCatalogoDeExcel()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }

        private void BTImpCatalogos_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBImpCatalogos.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {        
            if (this.TBImpCatalogos.Text != "")
            {
                m_importacionExitosa = false;
                m_iComentario = "";
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                ImportFromExcel ife = new ImportFromExcel();
                if (ife.ImportarProductosFromExcel(this.TBImpCatalogos.Text))
                {
                    m_importacionExitosa = true; 
                }
                else
                {
                   m_iComentario = "No se pudo importar el catalogo " + ife.IComentario;
                }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {
                MessageBox.Show("EL catalogo ha sido importado");
               
                WFProductoCambioPrecio wfp = new WFProductoCambioPrecio();
                wfp.ShowDialog();
                wfp.Dispose();
                GC.SuppressFinalize(wfp);

                this.Close();
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }


    }
}
