using iPosData;
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
    public partial class CortesEdicion : Form
    {

        bool bTienePermisosParaEditarCortesHoy = false;
        bool bTienePermisosParaEditarCortesOtroDia = false;
        public CortesEdicion()
        {
            InitializeComponent();
        }

        private void LlenarDatos(DateTime fecha)
        {
            try
            {
                this.cortesDeFechaTableAdapter.Fill(this.dSCortes.CortesDeFecha, fecha);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cortesDeFechaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (cortesDeFechaDataGridView.Columns[e.ColumnIndex].Name == "btnEditarCorte")
                {
                    // considerar la fecha
                    if(DTFecha.Value == DateTime.Now)
                    {
                        if (!bTienePermisosParaEditarCortesHoy)
                        {
                            MessageBox.Show("No tiene derecho para editar cortes actuales.");
                            return;
                        }
                        else
                        {
                            long corteId = long.Parse(cortesDeFechaDataGridView.Rows[e.RowIndex].Cells["DGCORTEID"].Value.ToString());
                            long cajeroId = long.Parse(cortesDeFechaDataGridView.Rows[e.RowIndex].Cells["DGCAJEROID"].Value.ToString());
                            CorteBilletes corteBilletes = new CorteBilletes(corteId, cajeroId, true);
                            corteBilletes.ShowDialog();
                            corteBilletes.Dispose();
                            GC.SuppressFinalize(corteBilletes);
                            LlenarDatos(DTFecha.Value);
                        }
                    }
                    else
                    {
                        if (!bTienePermisosParaEditarCortesOtroDia)
                        {
                            MessageBox.Show("No tiene derecho para editar cortes pasados.");
                            return;
                        }
                        else
                        {
                            long corteId = long.Parse(cortesDeFechaDataGridView.Rows[e.RowIndex].Cells["DGCORTEID"].Value.ToString());
                            long cajeroId = long.Parse(cortesDeFechaDataGridView.Rows[e.RowIndex].Cells["DGCAJEROID"].Value.ToString());
                            CorteBilletes corteBilletes = new CorteBilletes(corteId, cajeroId, true);
                            corteBilletes.ShowDialog();
                            corteBilletes.Dispose();
                            GC.SuppressFinalize(corteBilletes);
                            LlenarDatos(DTFecha.Value);
                        }
                    }
                }
                else if (cortesDeFechaDataGridView.Columns[e.ColumnIndex].Name == "btnReporte")
                {
                    long corteid = long.Parse(cortesDeFechaDataGridView.Rows[e.RowIndex].Cells["DGCORTEID"].Value.ToString());
                    

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("corteid", corteid);
                    string strReporte = "InformeCorteBilletesPostEdicion.frx";

                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
            }
        }

        private void cortesDeFechaDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            LlenarDatos(DTFecha.Value);
        }

        private void CortesEdicion_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            bTienePermisosParaEditarCortesHoy = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_EDITAR_CORTE_ACTUAL, null);
            bTienePermisosParaEditarCortesOtroDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_EDITAR_CORTE_PASADO, null);
            
            DTFecha.Enabled = bTienePermisosParaEditarCortesOtroDia;
            LlenarDatos(DTFecha.Value);
        }
    }
}
