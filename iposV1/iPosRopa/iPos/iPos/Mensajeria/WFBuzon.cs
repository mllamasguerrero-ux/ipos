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

namespace iPos.Mensajeria
{
    public partial class WFBuzon : Form
    {


        long usuarioId = CurrentUserID.CurrentUser.IID;

        bool ES_ADMINISTRADOR = false;
        bool ES_SUPERVISOR = false;

        public WFBuzon(long usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
        }

        private void WFBuzon_Load(object sender, EventArgs e)
        {


           CPERSONAD userD = new CPERSONAD();
           ES_ADMINISTRADOR = userD.UsuarioEsAdmin(usuarioId, null);
           ES_SUPERVISOR = userD.UsuarioEsAdmin(usuarioId, null);
           LlenarGrid();

        }

        private void LlenarGrid()
        {

            string esAdmin = ES_ADMINISTRADOR || ES_SUPERVISOR ? "S" : "N";

            // TODO: This line of code loads data into the 'dSMensajeria.BUZON' table. You can move, or remove it, as needed.
            this.bUZONTableAdapter.Fill(this.dSMensajeria.BUZON, (int)usuarioId, esAdmin);
        }

        private void bUZONDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                if (bUZONDataGridView.Columns[e.ColumnIndex].Name == "btnVer")
                {
                    MostrarRegistro();
                }
            }
        }

        private void MostrarRegistro()
        {
            try
            {


                int iRetornoRowIndex = bUZONDataGridView.CurrentRow.Index;
                long mensajeId = long.Parse(bUZONDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString());
                long mensajeEstadoId = long.Parse(bUZONDataGridView.Rows[iRetornoRowIndex].Cells["DGMENSAJEESTADOID"].Value.ToString());
                WFLeerMensaje wfLeerMensaje = new WFLeerMensaje(mensajeId, this.usuarioId, mensajeEstadoId);
                wfLeerMensaje.ShowDialog();
                wfLeerMensaje.Dispose();
                GC.SuppressFinalize(wfLeerMensaje);

                LlenarGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void coloreaRow(DataGridViewRow row)
        {
            long mensajeEstadoId = DBValues._ESTADO_MENSAJE_RECIBIDO;

            try
            {
                if (row.Cells["DGMENSAJEESTADOID"].Value != DBNull.Value)
                {
                    mensajeEstadoId = long.Parse(row.Cells["DGMENSAJEESTADOID"].Value.ToString());
                }


                if (mensajeEstadoId == DBValues._ESTADO_MENSAJE_RECIBIDO)
                {

                    row.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                else
                {
                    row.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
                }

            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }

        private void bUZONDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            coloreaRow(bUZONDataGridView.Rows[e.RowIndex]);
        }
    }
}
