using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using DataLayer.Importaciones;
using System.IO;

namespace iPos.Utilerias.Procesos
{
    public partial class WFImportarVentasDBFGiralda : Form
    {
        public bool m_importacionExitosa = true;
        public bool m_huboClientesNoEncontrados = false;
        public string m_iComentario;

        public WFImportarVentasDBFGiralda()
        {
            InitializeComponent();
        }

        private void WFImportarVentasDBFGiralda_Load(object sender, EventArgs e)
        {

        }

        private void btnImportHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnImportDetail_Click(object sender, EventArgs e)
        {
            if (this.TBImpVentasHeader.Text != "" && this.TBImpVentasDetalle.Text != "" && this.TBImpDevolucionesHeader.Text != "")
            {
                m_importacionExitosa = true;
                m_iComentario = "";
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void BTImpCatalogos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "dbf files (*.dbf)|*.dbf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBImpVentasHeader.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BTImpVentas_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "dbf files (*.dbf)|*.dbf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBImpVentasDetalle.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BTImpDevHeader_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "dbf files (*.dbf)|*.dbf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBImpDevolucionesHeader.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportarDBF impo = new ImportarDBF();

            if (!impo.ImportarHeaderVentasGiralda(Path.GetFileNameWithoutExtension(this.TBImpVentasHeader.Text), Path.GetDirectoryName(this.TBImpVentasHeader.Text),
                                                 Path.GetFileNameWithoutExtension(this.TBImpVentasDetalle.Text), Path.GetDirectoryName(this.TBImpVentasDetalle.Text), CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref m_huboClientesNoEncontrados))
            {
                m_importacionExitosa = false;
                MessageBox.Show(impo.IComentario);
            }

            //if(!impo.ImportarDetalleVentaGiralda_2("DETALLEVENTAS", @"C:\temporal\oblatos\tienda contado", CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser))
            if (!impo.ImportarHeaderDevolucionesGiralda(Path.GetFileNameWithoutExtension(this.TBImpDevolucionesHeader.Text), Path.GetDirectoryName(this.TBImpDevolucionesHeader.Text), 
                                                  Path.GetFileNameWithoutExtension(this.TBImpVentasDetalle.Text), Path.GetDirectoryName(this.TBImpVentasDetalle.Text), CurrentUserID.CurrentParameters, CurrentUserID.CurrentUser, ref m_huboClientesNoEncontrados))
            {
                m_importacionExitosa = false;
                MessageBox.Show(impo.IComentario);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {
                if(m_huboClientesNoEncontrados)
                {

                    MessageBox.Show("hubo clientes no encontrados");
                }

                MessageBox.Show("Los Datos han sido importados");

                this.Close();
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }
    }
}
