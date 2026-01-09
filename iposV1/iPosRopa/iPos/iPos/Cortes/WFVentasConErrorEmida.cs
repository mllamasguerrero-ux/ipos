using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Cortes
{
    public partial class WFVentasConErrorEmida : Form
    {
        public WFVentasConErrorEmida()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                long corteActual = CurrentUserID.CurrentUser.ICORTEID;

                //DateTime.Today.AddDays(-30)
                this.vENTASCONERROREMIDATableAdapter.Fill(this.dSCortes2.VENTASCONERROREMIDA, int.Parse(corteActual.ToString()));

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        private void vENTASCONERROREMIDADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (vENTASCONERROREMIDADataGridView.Columns[e.ColumnIndex].Name == "DGPagar")
                {


                    long docId = (long)vENTASCONERROREMIDADataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    try
                    {

                        WFPuntoDeVenta wf = new WFPuntoDeVenta(docId, true);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);

                        LlenarGrid();

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }


                }
            }
        }

        private void WFVentasConErrorEmida_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
