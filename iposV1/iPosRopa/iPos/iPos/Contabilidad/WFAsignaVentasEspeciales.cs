using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFAsignaVentasEspeciales : IposForm
    {
        public WFAsignaVentasEspeciales()
        {
            InitializeComponent();
        }

        private void llenarApartados()
        {
            try
            {
                long clienteId = 0;
                int folio = 0;

                if (!CBTodosClientes.Checked)
                {
                    try
                    {
                        clienteId = Int64.Parse(this.CLIENTETextBox.DbValue.ToString());
                    }
                    catch
                    {
                    }
                }


                if (!CBTodosFolios.Checked)
                {
                    try
                    {
                        folio = Int32.Parse(this.TBFolio.Text);
                    }
                    catch
                    {
                    }
                }

                this.vENTASESPECIALESASIGNACIONESTableAdapter.Fill(this.dSContabilidad3.VENTASESPECIALESASIGNACIONES, this.DPInicio.Value, this.DPFin.Value, clienteId, folio);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarApartados();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int iParaApartar = 0;
            foreach (DataGridViewRow row in aPARTADOSPENDIENTESDataGridView.Rows)
            {
                if (row.Index == aPARTADOSPENDIENTESDataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    if ((bool)row.Cells["DGCHECK"].Value)
                    {
                        iParaApartar++;
                    }
                }
                catch
                {
                }
            }





            int iApartados = 0;
            foreach (DataGridViewRow row in aPARTADOSPENDIENTESDataGridView.Rows)
            {
                if (row.Index == aPARTADOSPENDIENTESDataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    if (row.Cells["DGMODIFICADO"].Value.ToString() == "S")
                    {
                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        doctoBE.IID = (long)row.Cells["DGID"].Value;
                        doctoBE.IESVENTAESPECIAL = row.Cells["DGESVENTAESPECIAL"].Value.ToString() == "S" ? "S" : "N";



                        doctoD.CambiarESVENTAESPECIAL(doctoBE,  null);
                        

                        iApartados++;
                        backgroundWorker1.ReportProgress((int)((iApartados / iParaApartar) * 100));
                    }
                }
                catch
                {
                }
            }


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar00.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar00.Style = ProgressBarStyle.Blocks;
            progressBar00.Value = 0;

            llenarApartados();

            MessageBox.Show("Se aplicaron los cambios");

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Quiere realmente guardar los cambios?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                backgroundWorker1.RunWorkerAsync();

                progressBar00.Style = ProgressBarStyle.Blocks;
                progressBar00.Value = 0;
            }
        }
        

        private void aPARTADOSPENDIENTESDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.RowIndex == aPARTADOSPENDIENTESDataGridView.NewRowIndex)
                return;

            if (aPARTADOSPENDIENTESDataGridView.Columns["DGESVENTAESPECIAL"].Index != e.ColumnIndex)
                return;
            

            aPARTADOSPENDIENTESDataGridView.Rows[e.RowIndex].Cells["DGMODIFICADO"].Value = "S";
        }
    }
}
