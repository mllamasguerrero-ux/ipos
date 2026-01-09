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
    public partial class WFCorteLista : Form
    {

        public List<long> m_selectedTransactions = new List<long>();

        public WFCorteLista()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            

            try
            {
                
                DateTime fechainicorte = DTPFechaInicioCorte.Value;
                DateTime fechafincorte = DTPFechaFinCorte.Value;
                int cajeroid = CBCajero.Checked && this.CAJEROCLAVETextBox.Text != "" ? Int32.Parse(this.CAJEROCLAVETextBox.DbValue.ToString()) : 0;



                this.cORTESSINRECOLECCIONTableAdapter.Fill(this.dSContabilidad3.CORTESSINRECOLECCION, fechainicorte, fechafincorte, cajeroid);
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

        private void WFCorteLista_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            m_selectedTransactions = new List<long>();

            bool bHaySeleccionados = false;

            foreach (DataGridViewRow row in cORTESSINRECOLECCIONDataGridView.Rows)
            {
                if (row.Index == cORTESSINRECOLECCIONDataGridView.NewRowIndex)
                {
                    continue;
                }
                try
                {
                    if ((bool)row.Cells["DGCHECK"].Value)
                    {
                        long doctoId = long.Parse(row.Cells["DGFOLIO"].Value.ToString());
                        m_selectedTransactions.Add(doctoId);
                        bHaySeleccionados = true;
                    }
                }
                catch
                {
                }
            }

            if (bHaySeleccionados)
                this.Close();
        }
    }
}
