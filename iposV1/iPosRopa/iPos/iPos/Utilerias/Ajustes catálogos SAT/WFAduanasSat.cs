using FirebirdSql.Data.FirebirdClient;
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

namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    public partial class WFAduanasSat : Form
    {
        private int aduanaSeleccionada;

        public WFAduanasSat()
        {
            InitializeComponent();

            aduanaSeleccionada = -1;
        }

        private void WFAduanasSat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogosSat3.LOTESIMPORTADOS' table. You can move, or remove it, as needed.
            this.lOTESIMPORTADOSTableAdapter.Fill(this.dSCatalogosSat3.LOTESIMPORTADOS);
            // TODO: This line of code loads data into the 'dSCatalogosSat3.LOTESIMPORTADOS' table. You can move, or remove it, as needed.
            this.lOTESIMPORTADOSTableAdapter.Fill(this.dSCatalogosSat3.LOTESIMPORTADOS);

        }

        private void lOTESIMPORTADOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn & e.RowIndex >= 0)
            {
                this.descripcionContentLabel.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.aduanaSeleccionada = e.RowIndex;
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if(aduanaSeleccionada < 0)
            {
                MessageBox.Show("Primero debe seleccionar una aduana con el botón asignar.");
            }
            else
            {
                this.lOTESIMPORTADOSDataGridView.Rows[aduanaSeleccionada].Cells[1].Value = this.aduanaTextBoxFb.DbValue;
                this.aduanaSeleccionada = -1;
                this.descripcionContentLabel.Text = String.Empty;
                this.aduanaLabel.Text = String.Empty; 
                this.aduanaTextBoxFb.Text = String.Empty;
                this.lOTESIMPORTADOSDataGridView.Refresh();
            }
        }

        private void aplicarCambiosButton_Click(object sender, EventArgs e)
        {
            FbConnection fbConnection = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fbTrans = null;

            try
            {
                fbConnection.Open();
                fbTrans = fbConnection.BeginTransaction();

                foreach (DataGridViewRow dr in this.lOTESIMPORTADOSDataGridView.Rows)
                {
                    if (dr.Cells["ADUANAASIGNADA"].Value != null)
                    {
                        if (!String.IsNullOrEmpty(dr.Cells["ADUANAASIGNADA"].Value.ToString()))
                        {
                            CLOTESIMPORTADOSD lotesImportadosDao = new CLOTESIMPORTADOSD();

                            long satAdaunaId = long.Parse(dr.Cells["ADUANAASIGNADA"].Value.ToString());
                            string aduana = dr.Cells[0].Value.ToString();

                            if (!lotesImportadosDao.CambiarSATADUANAID(satAdaunaId, aduana, fbTrans))
                            {
                                throw new Exception();
                            }
                        }
                    }
                }

                fbTrans.Commit();
                fbConnection.Close();

                MessageBox.Show("Se han aplicado los cambios");

                this.Close();
            }
            catch(Exception ex)
            {
                fbTrans.Rollback();
                fbConnection.Close();

                MessageBox.Show("Error: " + ex.Message + ex.StackTrace);
            }
        }
    }
}
