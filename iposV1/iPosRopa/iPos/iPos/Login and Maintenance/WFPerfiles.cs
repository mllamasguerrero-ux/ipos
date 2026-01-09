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

namespace iPos
{
    public partial class WFPerfiles : IposForm
    {
        public WFPerfiles()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            string strABuscar;
            int numeroRegistros = 0;
            try
            {
                strABuscar = "%" + TSTPalabrasClave.Text + "%";
                numeroRegistros = this.pERFILESTableAdapter.Fill(this.dSSeguridad.PERFILES, strABuscar);
                if (this.dSSeguridad.PERFILES.Rows.Count > 0)
                    TableDataGridView.Focus();
                else
                    TSTPalabrasClave.Focus();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void TSBBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void WFPerfiles_Load(object sender, EventArgs e)
        {
            if (!verificarPermisos("Consultar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                this.Close();
                return;
            }

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
                int iPF_PERFIL = (int)TableDataGridView.Rows[iRetornoRowIndex].Cells["dgwPF_PERFIL"].Value;
                PERFILEdicion  fPi = new PERFILEdicion();
                fPi.ReCargar(opc, iPF_PERFIL);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
                LlenarGrid();
            }
            catch
            {
            }
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
            int iMenuItem = 61;
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

            PERFILEdicion fPi = new PERFILEdicion();
            fPi.ReCargar("Agregar", 0);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
            LlenarGrid();
        }

    }
}
