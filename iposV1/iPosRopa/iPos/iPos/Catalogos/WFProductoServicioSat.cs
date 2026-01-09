using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Catalogos
{
    public partial class WFProductoServicioSat : Form
    {
        private long lineaId;
        private string filter;

        private DataRow retorno;

        public DataRow Retorno
        {
            get { return retorno; }
            set { retorno = value; }
        }

        public WFProductoServicioSat()
        {
            InitializeComponent();
        }

        public WFProductoServicioSat(long lineaId, string filter)
        {
            InitializeComponent();

            this.lineaId = lineaId;
            this.filter = filter;

        }

        private void sAT_PRODUCTOSERVICIO_FILTRODataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.retorno = this.dSCatalogosSat3.SAT_PRODUCTOSERVICIO_FILTRO.Rows[e.RowIndex];

            //this.Close();
        }

        private void LlenarGrid()
        {
            try
            {
                this.sAT_PRODUCTOSERVICIO_FILTROTableAdapter.Fill(this.dSCatalogosSat3.SAT_PRODUCTOSERVICIO_FILTRO, this.filter, this.lineaId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void sAT_PRODUCTOSERVICIO_FILTRODataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.retorno = (this.sAT_PRODUCTOSERVICIO_FILTRODataGridView.CurrentRow.DataBoundItem as DataRowView).Row;//this.dSCatalogosSat3.SAT_PRODUCTOSERVICIO_FILTRO.Rows[e.RowIndex];

            this.Close();
        }

        private void lineaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lineaRadioButton.Checked)
            {
                filter = "Linea";
                LlenarGrid();
            }
        }

        private void operativosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (operativosRadioButton.Checked)
            {
                filter = "Parcial";
                LlenarGrid();
            }
        }

        private void todosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (todosRadioButton.Checked)
            {
                filter = "Todos";
                LlenarGrid();
            }
        }

        private void WFProductoServicioSat_Load(object sender, EventArgs e)
        {

            switch(this.filter)
            {
                case "Todos": todosRadioButton.Checked = true; break;
                case "Linea": lineaRadioButton.Checked = true; break;
                case "Parcial": operativosRadioButton.Checked = true; break;
                default: todosRadioButton.Checked = true; break; 

            }
            //LlenarGrid();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(this.dSCatalogosSat3.SAT_PRODUCTOSERVICIO_FILTRO);
            dv.RowFilter = string.Format("SAT_DESCRIPCION LIKE '%{0}%'", buscarTextBox.Text);
            sAT_PRODUCTOSERVICIO_FILTRODataGridView.DataSource = dv;
        }

       
    }
}
