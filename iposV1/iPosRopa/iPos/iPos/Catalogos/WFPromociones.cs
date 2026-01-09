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
using iPos.Tools;
using FirebirdSql.Data.FirebirdClient;

namespace iPos.Catalogos
{
    public partial class WFPromociones : IposForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;

        public WFPromociones()
        {
            InitializeComponent();
            m_bRetornarValor = false;
        }


        public WFPromociones(string palabrasBusqueda)
            : this()
        {
            m_bRetornarValor = true;
        }

        private void WFPromociones_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.PROMOCION_VIEW' table. You can move, or remove it, as needed.

            if (!verificarPermisos("Consultar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                this.Close();
                return;
            }

            if (verificarPermisos("BorrarTodo"))
            {
                TSBEliminarTodas.Visible = true;
            }
            else TSBEliminarTodas.Visible = false;

            LlenarGrid();
        }

        private void TableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (TableDataGridView.Columns[e.ColumnIndex].Name == "ColVer")
                {
                    MostrarRegistro("Consultar");
                }
                else if (TableDataGridView.Columns[e.ColumnIndex].Name == "colEditar")
                {
                    MostrarRegistro("Cambiar");
                }
                else if (TableDataGridView.Columns[e.ColumnIndex].Name == "ColDesactivar")
                {
                    if (TableDataGridView.Rows[e.RowIndex].Cells["DGACTIVO"].Value.ToString().Equals("S"))
                        ActivarDesactivarRegistro("Desactivar");
                    else
                        ActivarDesactivarRegistro("Activar");

                    LlenarGrid();
                }
            }
        }

        private void ActivarDesactivarRegistro(string opcion)
        {
            try
            {
                if(!verificarPermisos(opcion))
                {
                    MessageBox.Show("No tiene permisos para activar o desactivar promociones");
                    return;
                }

                string activo = opcion.Equals("Activar") ? "S" : "N";
                int currentRowIndex = TableDataGridView.CurrentRow.Index;

                CambiarActivoEnPromo((long)TableDataGridView.Rows[currentRowIndex].Cells["DGID"].Value,
                                                    activo,
                                                    null);

            }
            catch(Exception e)
            {
                MessageBox.Show("Hubo un problema: " + e.Message);
            }
        }

        private void CambiarActivoEnPromo(long promoId,string activo, FbTransaction transaction)
        {
            try
            {

                CPROMOCIOND promocionDao = new CPROMOCIOND();

                if (promocionDao.CambiarActivo(promoId, activo, transaction))
                {
                    MessageBox.Show("Se ha cambiado el estado de la promoción");
                }
                else
                {
                    MessageBox.Show("Hubo un problema en la consulta para cambiar el estado de la selección");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un problema: " + e.Message);
            }
        }

        private void MostrarRegistro(string opc)
        {
            try
            {

                if (!verificarPermisos(opc))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }

                int iRetornoRowIndex = TableDataGridView.CurrentRow.Index;
                string strCLAVE = TableDataGridView.Rows[iRetornoRowIndex].Cells["dgwCLAVE"].Value.ToString();
                WFPromocionEdit fPi = new WFPromocionEdit();
                fPi.ReCargar(opc, strCLAVE);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
                LlenarGrid();
            }
            catch
            {
            }
        }

        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex =  TableDataGridView.CurrentRow.Index;
                DataGridViewRow dr = TableDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void TableDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                if (m_bRetornarValor || TableDataGridView.Columns[e.ColumnIndex].Name != "ColVer")
                {
                    RetornarSeleccion(false);
                }
                else
                {
                    MostrarRegistro("Consultar");
                }
            }
        }





        private void LlenarGrid()
        {
            string strABuscar;
            int numeroRegistros = 0;
            try
            {
                strABuscar = "%" + TSTPalabrasClave.Text + "%";
                numeroRegistros = TableTableAdapter.Fill(dSCatalogos.PROMOCION_VIEW, strABuscar, CBSoloVigentes.Checked?"S":"N", DateTime.Today);
                if (dSCatalogos.LINEA_VIEW.Rows.Count > 0)
                    TableDataGridView.Focus();
                else
                    TSTPalabrasClave.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TSBBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void TSBAgregar_Click(object sender, EventArgs e)
        {
            MostrarAgregar();
        }

        private void TSTPalabrasClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenarGrid();
            }
            else
            {
                ManejaTecla(e.KeyCode);
            }
        }


        private bool verificarPermisos(string opc)
        {
            int iMenuItem = 97;
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            switch (opc)
            {
                case "Cambiar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 1000, null);

                case "Agregar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 3000, null);

                case "Consultar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem, null);

                case "Borrar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 2000, null);
                case "BorrarTodo":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_BORRAR_TODAS_LAS_PROMOCIONES, null);
                case "Desactivar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ACTIVAR_DESACTIVAR_PROMOCION, null);
                case "Activar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ACTIVAR_DESACTIVAR_PROMOCION, null);
            }

            return false;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TableDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ManejaTecla(e.KeyCode);
        }


        private void ManejaTecla(Keys key)
        {
            switch (key)
            {
                case Keys.Insert:
                    MostrarAgregar();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F2:
                    MostrarRegistro("Cambiar");
                    break;
            }
        }

        private void MostrarAgregar()
        {
            if (!verificarPermisos("Agregar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }


            WFPromocionEdit fPi = new WFPromocionEdit();
            fPi.ReCargar("Agregar", "");
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
            LlenarGrid();
        }

        private void TSBEliminarTodas_Click(object sender, EventArgs e)
        {
            CPROMOCIONBE promocion = new CPROMOCIONBE();
            CPROMOCIOND promocionDao = new CPROMOCIOND();

            CPROMOCIONSUCURSALBE promocionSucursal = new CPROMOCIONSUCURSALBE();
            CPROMOCIONSUCURSALD promocionSucursalDao = new CPROMOCIONSUCURSALD();

            WFCustomMessageBox ms = new WFCustomMessageBox();

            ms.Show("Borrar/Desactivar Promociones",
                    "Desea eliminar o desactivar las promociones?",
                    "Elimniar", "Desactivar", "Cancelar");

            if (ms.result == "Eliminar")
            {
                promocionDao.BorrarTodoPROMOCION(null);
                promocionSucursalDao.BorrarTodoPROMOCIONSUCURSAL(null);
            }
            else if (ms.result == "Desactivar")
            {
                promocionDao.CambiarActivoPROMOCION(null);
            }
            else if (ms.result == "Cancelar")
            {

            }
        }

        private void CBSoloVigentes_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
