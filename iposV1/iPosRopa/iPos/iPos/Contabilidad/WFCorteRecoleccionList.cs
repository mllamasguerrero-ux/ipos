using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Contabilidad
{
    public partial class WFCorteRecoleccionList : Form
    {
        public WFCorteRecoleccionList()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {



            try
            {

                string filtrarFecha = CBFecha.Checked ? "S" : "N";
                int folio = CBFolioRecoleccion.Checked ? int.Parse(TBFolioRecoleccion.Text) : 0;
                DateTime fechaini = DTPFechaInicio.Value.Date;
                DateTime fechafin = DTPFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
                int encargadoid = CBEncargado.Checked && this.ENCARGADOCLAVETextBox.Text != "" ? Int32.Parse(this.ENCARGADOCLAVETextBox.DbValue.ToString()) : 0;


                string filtrarfechacorte = CBFechaCorte.Checked ? "S" : "N";
                DateTime fechainicorte = DTPFechaInicioCorte.Value;
                DateTime fechafincorte = DTPFechaFinCorte.Value;
                int cajeroid = CBCajero.Checked && this.CAJEROCLAVETextBox.Text != "" ? Int32.Parse(this.CAJEROCLAVETextBox.DbValue.ToString()) : 0;


                this.cORTERECOLECCIONTableAdapter.Fill(this.dSContabilidad3.CORTERECOLECCION, folio, filtrarFecha, fechaini, fechafin, encargadoid, cajeroid, filtrarfechacorte, fechainicorte, fechafincorte);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            WFCorteRecoleccionEdit rp = new WFCorteRecoleccionEdit();
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);

            LlenarGrid();
        }

        private void cORTERECOLECCIONDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (cORTERECOLECCIONDataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    long dtlId = long.Parse(cORTERECOLECCIONDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());


                    WFCorteRecoleccionEdit rp = new WFCorteRecoleccionEdit(dtlId);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                    LlenarGrid();

                }
            }
        }

        private void WFCorteRecoleccionList_Load(object sender, EventArgs e)
        {
            this.LlenarGrid();
        }
    }
}
