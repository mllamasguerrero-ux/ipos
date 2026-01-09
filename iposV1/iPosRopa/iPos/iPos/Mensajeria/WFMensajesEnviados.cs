using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Mensajeria
{
    public partial class WFMensajesEnviados : Form
    {
        public WFMensajesEnviados()
        {
            InitializeComponent();
        }

        private void WFMensajesEnviados_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void LlenarGrid()
        {

            // TODO: This line of code loads data into the 'dSMensajeria.MENSAJEENVIADO' table. You can move, or remove it, as needed.
            this.mENSAJEENVIADOTableAdapter.Fill(this.dSMensajeria.MENSAJEENVIADO);
        }

        private void mENSAJEENVIADODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (mENSAJEENVIADODataGridView.Columns[e.ColumnIndex].Name == "btnVer")
                {
                    MostrarRegistro("Consultar");
                }
            }
        }


        private void MostrarRegistro(string opc)
        {
            try
            {


                int iRetornoRowIndex = mENSAJEENVIADODataGridView.CurrentRow.Index;
                long mensajeId = long.Parse(mENSAJEENVIADODataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString());
                WFMensajeEnvio fPi = new WFMensajeEnvio();
                fPi.ReCargar(opc, mensajeId);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
                LlenarGrid();
            }
            catch
            {
            }
        }

        private void btnCrearNuevoMensaje_Click(object sender, EventArgs e)
        {
            WFMensajeEnvio fPi = new WFMensajeEnvio();
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
        }

    }
}
