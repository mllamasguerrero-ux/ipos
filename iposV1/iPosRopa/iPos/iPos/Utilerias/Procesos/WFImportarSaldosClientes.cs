using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Utilerias.Procesos
{
    public partial class WFImportarSaldosClientes : Form
    {
        private bool m_importacionExitosa;
        private string m_iComentario;

        public WFImportarSaldosClientes()
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
            List<string> mensajesDeError = new List<string>();
            ImportFromExcel ife = new ImportFromExcel();
            m_iComentario = "";

            if (ife.ImportarSaldosClientesFromExcel(this.TBImpCatalogos.Text, CurrentUserID.CurrentUser.IID, ref mensajesDeError))
            {
                m_importacionExitosa = true;

                if(mensajesDeError.Count > 0)
                {
                    foreach (string error in mensajesDeError)
                    {
                        m_iComentario += error;
                    }
                }
            }
            else
            {
                foreach(string error in mensajesDeError)
                {
                    m_iComentario += error; 
                }

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {

                if (!m_iComentario.Equals(""))
                {
                    MessageBox.Show(m_iComentario);
                }

                MessageBox.Show("EL catalogo ha sido importado");


                /*WFProductoCambioPrecio wfp = new WFProductoCambioPrecio();
                wfp.ShowDialog();*/

                this.Close();
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }


        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void WFImportarSaldosClientes_Load(object sender, EventArgs e)
        {
            ChecarCorteActivo();
        }
    }
}
