using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;

namespace iPos.Cobranza
{
    public partial class WFBitacoraCobranzaList : IposForm
    {

        bool bTienePermisosEditarBitacoraMismoDia = false;
        bool bTienePermisosEditarBitacoraOtroDia = false;
        bool bTienePermisosEditarBitacoraOtroUsuario = false;
        bool bTienePermisosEliminarBitacoraMismoDia = false;
        bool bTienePermisosEliminarBitacoraOtroDia = false;
        bool bTienePermisoModificarEstadoBitacoraDet = false;


        public WFBitacoraCobranzaList()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            try
            {
                int estado = CBSoloPendientes.Checked ? 1 : -1;
                this.bITACOBRANZATableAdapter.Fill(this.dSCobranza.BITACOBRANZA, dtpFechaInicial.Value, dtpFechaFinal.Value, estado);
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

        private void btnAgregarBitacora_Click(object sender, EventArgs e)
        {
            WFBitacoraEdit wf = new WFBitacoraEdit();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);

            LlenarGrid();
        }

        private void bITACOBRANZADataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (bITACOBRANZADataGridView.Columns[e.ColumnIndex].Name == "DGEDITAR")
                {
                    long bitId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    long cobradorId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGCOBRADORID"].Value.ToString());

                    DateTime fecha;
                    try
                    {
                        fecha = DateTime.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value.ToString());
                    }
                    catch
                    {
                        return;
                    }


                    if(fecha.Date == DateTime.Today && !bTienePermisosEditarBitacoraMismoDia)
                    {
                        MessageBox.Show("No tiene permisos para editar la bitacora del mismo dia");
                        return;
                    }


                    if (fecha.Date != DateTime.Today && !bTienePermisosEditarBitacoraOtroDia)
                    {
                        MessageBox.Show("No tiene permisos para editar la bitacora de otro dia");
                        return;
                    }


                    if (fecha.Date != DateTime.Today && !bTienePermisosEditarBitacoraOtroDia)
                    {
                        MessageBox.Show("No tiene permisos para editar la bitacora de otro dia");
                        return;
                    }

                    if(cobradorId != CurrentUserID.CurrentUser.IID && !bTienePermisosEditarBitacoraOtroUsuario)
                    {

                        MessageBox.Show("No tiene permisos para editar la bitacora de otro usuario");
                        return;
                    }

                   


                    WFBitacoraEdit wf = new WFBitacoraEdit("Cambiar", bitId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarGrid();
                }
                else if (bITACOBRANZADataGridView.Columns[e.ColumnIndex].Name == "DGVER")
                {
                    long bitId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    WFBitacoraEdit wf = new WFBitacoraEdit("Consultar", bitId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);

                    LlenarGrid();
                }
                else if (bITACOBRANZADataGridView.Columns[e.ColumnIndex].Name == "DGREGISTRARPAGOS")
                {
                    /*long bitId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    CBITACOBRANZAD bitacoraCobranzaD = new CBITACOBRANZAD();
                    CBITACOBRANZABE bitacoraCobranzaBE = new CBITACOBRANZABE();
                    bitacoraCobranzaBE.IID = bitId;
                    bitacoraCobranzaBE.IESTADO = 2;

                    if(!bitacoraCobranzaD.CambiarBITACOBRANZA_ESTADO(bitacoraCobranzaBE, bitacoraCobranzaBE, null))
                    {

                        MessageBox.Show("Ocurrio un error " + bitacoraCobranzaD.IComentario);
                        return;
                    }
                    LlenarGrid();*/
                    if((bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["ESTADONOMBRE"].Value.Equals("TERMINADA")))
                    {
                        if (!bTienePermisoModificarEstadoBitacoraDet)
                        {
                            MessageBox.Show("El usuario no tiene el derecho para editar bitacoras en estado terminado!.");
                            return;
                        }
                    }

                    long bitId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    WFBitacoraEdit wf = new WFBitacoraEdit("Recibir", bitId);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();
                }
                else if (bITACOBRANZADataGridView.Columns[e.ColumnIndex].Name == "DGImprimir")
                {
                    long bitId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("pbitacoracobranzaid", bitId);

                    string strReporte = "BitacoraCobranza.frx";

                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
                else if (bITACOBRANZADataGridView.Columns[e.ColumnIndex].Name == "DGCancelar")
                {

                    if (MessageBox.Show("Seguro que desea cerrar el corte?  ", "Confirmacion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }

                    long bitId = long.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    DateTime fecha;
                    try
                    {
                        fecha = DateTime.Parse(bITACOBRANZADataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value.ToString());
                    }
                    catch
                    {
                        return;
                    }

                    if (fecha.Date == DateTime.Today && !bTienePermisosEliminarBitacoraMismoDia)
                    {
                        MessageBox.Show("No tiene permisos para eliminar la bitacora del mismo dia");
                        return;
                    }

                    if (fecha.Date != DateTime.Today && !bTienePermisosEliminarBitacoraOtroDia)
                    {
                        MessageBox.Show("No tiene permisos para eliminar la bitacora de otro dia");
                        return;
                    }

                    
                    
                    CBITACOBRANZAD bitacoraCobranzaD = new CBITACOBRANZAD();
                    CBITACOBRANZABE bitacoraCobranzaBE = new CBITACOBRANZABE();
                    bitacoraCobranzaBE.IID = bitId;
                    bitacoraCobranzaBE.IESTADO = 3;

                    if (!bitacoraCobranzaD.CambiarBITACOBRANZA_ESTADO(bitacoraCobranzaBE, bitacoraCobranzaBE, null))
                    {

                        MessageBox.Show("Ocurrio un error " + bitacoraCobranzaD.IComentario);
                        return;
                    }
                    LlenarGrid();

                }
                
            }
        }

        private void WFBitacoraCobranzaList_Load(object sender, EventArgs e)
        {
            LlenarGrid();


            CUSUARIOSD usuariosD = new CUSUARIOSD();

            bTienePermisosEditarBitacoraMismoDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAEDITAR_MISMODIA, null);
            bTienePermisosEditarBitacoraOtroDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAEDITAR_OTRODIA, null);
            bTienePermisosEditarBitacoraOtroUsuario = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAEDITAR_OTROUSUARIO, null);
            bTienePermisosEliminarBitacoraMismoDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAELIMINAR_MISMODIA, null);
            bTienePermisosEliminarBitacoraOtroDia = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BITACORAELIMINAR_OTRODIA, null);
            bTienePermisoModificarEstadoBitacoraDet = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_MODIFICAR_ESTADO_BITACORA, null);

            

        }
    }
}
