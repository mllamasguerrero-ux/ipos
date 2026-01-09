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

namespace iPos.Catalogos
{
    public partial class WFClientesApartado : IposForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;

        public WFClientesApartado()
        {
            InitializeComponent();
            m_bRetornarValor = false;
        }


        public WFClientesApartado(string palabrasBusqueda)
            : this()
        {
            m_bRetornarValor = true;
        }

        private void WFClientesApartado_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.PERSONAAPARTADO' table. You can move, or remove it, as needed.
            this.pERSONAAPARTADOTableAdapter.Fill(this.dSCatalogos.PERSONAAPARTADO, "");
            /*if (!verificarPermisos("Consultar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                this.Close();
                return;
            }*/

            LlenarGrid();
        }

        private void TableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }




        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && TableDataGridView.CurrentRow.Index < (TableDataGridView.RowCount - 1))
                                       ? TableDataGridView.CurrentRow.Index - 1 :*/ TableDataGridView.CurrentRow.Index;
                DataGridViewRow dr = TableDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
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
            }
        }





        private void LlenarGrid()
        {
            string strABuscar;
            int numeroRegistros = 0;
            try
            {
                if (TSTPalabrasClave.Text == "")
                    strABuscar = "TODOS";
                else
                    strABuscar = "%" + TSTPalabrasClave.Text + "%";

                numeroRegistros = this.pERSONAAPARTADOTableAdapter.Fill(this.dSCatalogos.PERSONAAPARTADO, strABuscar);
                if (this.dSCatalogos.PERSONAAPARTADO.Rows.Count > 0)
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
        /*
        private void TSBAgregar_Click(object sender, EventArgs e)
        {

        }*/


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

        /*
        private bool verificarPermisos(string opc)
        {
            int iMenuItem = 2;
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

        }*/
        /*
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/

        private void WFClientesApartado_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void TableDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ManejaTecla(e.KeyCode);
        }


        private void ManejaTecla(Keys key)
        {
            switch (key)
            {
                
                case Keys.Escape:
                    this.Close();
                    break;


                case Keys.Enter:
                    RetornarSeleccion(false);
                    break;
            }
        }



    }
}
