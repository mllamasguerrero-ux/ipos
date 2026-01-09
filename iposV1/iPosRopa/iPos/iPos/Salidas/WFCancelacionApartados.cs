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
    public partial class WFCancelacionApartados : IposForm
    {
        public WFCancelacionApartados()
        {
            InitializeComponent();
        }

        private void llenarApartados()
        {
            try
            {
                this.aPARTADOSPENDIENTESTableAdapter.Fill(this.dSSalidas.APARTADOSPENDIENTES, this.DPInicio.Value, this.DPFin.Value);
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

        private void CBTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in aPARTADOSPENDIENTESDataGridView.Rows)
            {
                if (row.Index == aPARTADOSPENDIENTESDataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    row.Cells["DGCHECK"].Value = CBTodos.Checked;
                }
                catch
                {
                    //this.m_montoVentaConVale += Decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
                }
            }
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
                    if ((bool)row.Cells["DGCHECK"].Value)
                    {
                        CPuntoDeVentaD pvd = new CPuntoDeVentaD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        doctoBE.IID = (long)row.Cells["DGID"].Value;
                        doctoBE.IESTATUSDOCTOID = DBValues._DOCTO_ESTATUS_COMPLETO;


                        long doctoIDCancelacion = 0;
                        pvd.CancelarApartado(doctoBE, CurrentUserID.CurrentUser,ref doctoIDCancelacion, null);
                        

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

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Quiere cancelar realmente las ventas de apartado seleccionadas?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                backgroundWorker1.RunWorkerAsync();

                progressBar00.Style = ProgressBarStyle.Blocks;
                progressBar00.Value = 0;
            }
        }
    }
}
