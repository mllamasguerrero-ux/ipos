using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFPagoMovilList : iPos.Tools.ScreenConfigurableForm
    {
        public WFPagoMovilList()
        {
            InitializeComponent();
        }

        private void LlenarGrid(String strBusqueda)
        {
            try
            {

                this.pAGOMOVILTableAdapter.Fill(this.dSMovil2.PAGOMOVIL, strBusqueda);
                HabilitaBotonChequeo(); 
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            formateaGrid();

        }


        private void formateaGrid()
        {
            foreach (DataGridViewRow row in this.pAGOMOVILDataGridView.Rows)
            {

                long lEstatus = 0;

                try
                {
                    if (row.Cells["DGESTATUS"].Value != DBNull.Value)
                    {
                        lEstatus = long.Parse(row.Cells["DGESTATUS"].Value.ToString());
                    }

                    if (lEstatus == 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.Cells["DGENVIAR"].Value = "ENVIAR";
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.Cells["DGENVIAR"].Value = "";
                    }
                }
                catch
                {

                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
        }

        private void pAGOMOVILDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pAGOMOVILDataGridView.Columns[e.ColumnIndex].Name == "VERPAGO")
            {
                long pagoMovilId = long.Parse(pAGOMOVILDataGridView.Rows[e.RowIndex].Cells["DGPAGOMOVILID"].Value.ToString());
                WFPagoMovil wf = new WFPagoMovil("",pagoMovilId);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
            else if (pAGOMOVILDataGridView.Columns[e.ColumnIndex].Name == "DGENVIAR")
            {
                long lEstatus = long.Parse(pAGOMOVILDataGridView.Rows[e.RowIndex].Cells["DGESTATUS"].Value.ToString());
                if (lEstatus != 1)
                    return;

                long pagoMovilId = long.Parse(pAGOMOVILDataGridView.Rows[e.RowIndex].Cells["DGPAGOMOVILID"].Value.ToString());
                WFEnvioPagoMovil wf = new WFEnvioPagoMovil(pagoMovilId);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            WFPagoMovil wf = new WFPagoMovil();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (TBBusqueda.Text.Trim().Length > 0)
                LlenarGrid("%" + TBBusqueda.Text.Trim() + " % ");
            else
                LlenarGrid("");
        }

        private void WFPagoMovilList_Load(object sender, EventArgs e)
        {
            configuraLaPantalla(true, true);
            LlenarGrid("");
        }


        public void HabilitaBotonChequeo()
        {

            foreach (DataGridViewRow row in this.pAGOMOVILDataGridView.Rows)
            {

                string procesado = "";

                if (row.Cells["DGENVIADOWS"].Value != DBNull.Value)
                {
                    procesado = row.Cells["DGENVIADOWS"].Value.ToString().Trim();
                }


                if (procesado.Equals("S"))
                {
                    row.Cells["DGENVIAR"].ReadOnly = true;
                    row.Cells["DGENVIAR"].Style.BackColor = Color.Red;
                }

            }
        }
    }
}
