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
    public partial class WFSurtidoVentasMoviles : IposForm
    {
        public WFSurtidoVentasMoviles()
        {
            InitializeComponent();
        }

        private void WFSurtidoVentasMoviles_Load(object sender, EventArgs e)
        {

            if(CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S"))
            {
                MessageBox.Show("Como esta configurado el surtido postpuesto, las ventas moviles estan por ser surtidas en el menu de 'SURTIDO' como las demas ventas, por lo que este formulario no aplica");
                this.Close();
                return;
            }

            LlenarGrid();

        }

        public void LlenarGrid()
        {
            // TODO: This line of code loads data into the 'dSMovil3.SurtidoVentasMoviles' table. You can move, or remove it, as needed.
            this.surtidoVentasMovilesTableAdapter.Fill(this.dSMovil3.SurtidoVentasMoviles);
        }

        /*
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int iParaSurtir = 1;
            foreach (DataGridViewRow row in surtidoVentasMovilesDataGridView.Rows)
            {
                if (row.Index == surtidoVentasMovilesDataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    if ((bool)row.Cells["DGCHECK"].Value)
                    {
                        iParaSurtir++;
                    }
                }
                catch
                {
                }
            }





            int iSurtidos = 0;
            foreach (DataGridViewRow row in surtidoVentasMovilesDataGridView.Rows)
            {
                if (row.Index == surtidoVentasMovilesDataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    if ((bool)row.Cells["DGCHECK"].Value)
                    {
                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        doctoBE.IID = (long)row.Cells["DGID"].Value;
                        doctoBE.IPROCESOSURTIDO = "S";


                        doctoD.CambiarProcesoSurtidoDOCTOD(doctoBE, null);


                        iSurtidos++;
                        backgroundWorker1.ReportProgress((int)((iSurtidos / iParaSurtir) * 100));
                    }
                }
                catch
                {
                }
            }

            CPARAMETROD parametroD = new CPARAMETROD();
            parametroD.MOVILPROCESOSURTIDOUPDATE(null);

            CurrentUserID.CurrentParameters = parametroD.seleccionarPARAMETROActual(null);


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar00.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar00.Style = ProgressBarStyle.Blocks;
            progressBar00.Value = 0;

            LlenarGrid();

        }

        private void btnSeleccionarVenta_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Quiere realmente guardar los cambios?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                backgroundWorker1.RunWorkerAsync();

                progressBar00.Style = ProgressBarStyle.Blocks;
                progressBar00.Value = 0;
            }
        }*/




        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in this.surtidoVentasMovilesDataGridView.Rows)
            {

                coloreaRow(row);
            }
        }

        private void coloreaRow(DataGridViewRow row)
        {

            string observacionfacturacion = "";

            try
            {


                if (row.Cells["DGOBSERVACIONFACTURACION"].Value != DBNull.Value)
                {
                    observacionfacturacion = row.Cells["DGOBSERVACIONFACTURACION"].Value.ToString();
                }


                if (observacionfacturacion == "CON PROBLEMAS DE FACTURACION")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            row.Cells["DGCHECK"].Style.BackColor = Color.GreenYellow;
            row.Cells["DGCHECK"].Style.ForeColor = Color.Black;

        }

        private void surtidoVentasMovilesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (surtidoVentasMovilesDataGridView.Columns[e.ColumnIndex].Name == "DGFOLIO" && e.Value != null && e.Value != DBNull.Value)
            {
                coloreaRow(surtidoVentasMovilesDataGridView.Rows[e.RowIndex]);
            }
        }

        private void surtidoVentasMovilesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && !CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {

                if (surtidoVentasMovilesDataGridView.Columns[e.ColumnIndex].Name == "DGVER")
                {
                    long dgDoctoId =  (long)surtidoVentasMovilesDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    int dgFolio =  (int)surtidoVentasMovilesDataGridView.Rows[e.RowIndex].Cells["DGFOLIO"].Value;
                    string strNombreCliente = (string)surtidoVentasMovilesDataGridView.Rows[e.RowIndex].Cells["DGNOMBRECLIENTE"].Value;
                    DateTime fecha = (DateTime)surtidoVentasMovilesDataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value;

                    WFSurtidoVentasMovilesDetalle wf = new WFSurtidoVentasMovilesDetalle(dgDoctoId,dgFolio, strNombreCliente, fecha);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();

                }
                else if (surtidoVentasMovilesDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIR")
                {
                    long dgDoctoId = (long)surtidoVentasMovilesDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    PosPrinter.ImprimirTicket(dgDoctoId);
                    

                }
                else if (surtidoVentasMovilesDataGridView.Columns[e.ColumnIndex].Name == "DGSURTIDO")
                {
                    long dgDoctoId = (long)surtidoVentasMovilesDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    sutirDocto(dgDoctoId);
                    PosPrinter.ImprimirTicket(dgDoctoId);
                    LlenarGrid();

                }
            }
        }



        private void sutirDocto(long lDoctoId)
        {

            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = lDoctoId;
            doctoBE.IPROCESOSURTIDO = "S";


            if (!doctoD.CambiarProcesoSurtidoDOCTOD(doctoBE, null))
            {
                MessageBox.Show("No se pudo cambiar el flag de surtido");
                return;
            }
            else
            {
                CPARAMETROD parametroD = new CPARAMETROD();
                parametroD.MOVILPROCESOSURTIDOUPDATE(null);
                CurrentUserID.CurrentParameters = parametroD.seleccionarPARAMETROActual(null);

            }
        }


    }
}
