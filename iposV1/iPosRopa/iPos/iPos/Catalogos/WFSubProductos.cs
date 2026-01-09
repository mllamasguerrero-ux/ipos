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
    public partial class WFSubProductos : IposForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;
        public bool m_bMostrarDescontinuados;
        public long m_productoPadreid = 0;


        public WFSubProductos()
        {
            InitializeComponent();
        }

        public WFSubProductos(long productoPadreid)
        {
            InitializeComponent();
            m_bRetornarValor = false;
            m_bMostrarDescontinuados = false;
            m_productoPadreid = productoPadreid;
            //RefrescarGrid();
        }

        public WFSubProductos(long productoPadreid, string palabrasBusqueda)
            : this(productoPadreid)
        {
            m_bRetornarValor = true;
            m_bMostrarDescontinuados = false;
            busquedaToolStripTextBox.Text = palabrasBusqueda.ToUpper();
            
        }


        public WFSubProductos(long productoPadreid, string palabrasBusqueda, bool soloConExistencias)
            : this(productoPadreid,palabrasBusqueda)
        {

            m_bMostrarDescontinuados = false;
            CBMostrarExistencias.Checked = soloConExistencias;
        }


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && pRODUCTOSDataGridView.CurrentRow.Index < (pRODUCTOSDataGridView.RowCount - 1)) 
                                       ? pRODUCTOSDataGridView.CurrentRow.Index - 1 :*/ pRODUCTOSDataGridView.CurrentRow.Index;
                DataGridViewRow dr = pRODUCTOSDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }


        private void RefrescarGrid()
        {
            string strABuscar;
            int numeroRegistros = 0;
            try
            {
                strABuscar = "%" + busquedaToolStripTextBox.Text + "%";
                numeroRegistros = this.sUBPRODUCTOSEXTENDEDTableAdapter.Fill(this.dSCatalogos.SUBPRODUCTOSEXTENDED, strABuscar, ((CBMostrarExistencias.Checked) ? "S" : "N"), (this.m_bMostrarDescontinuados) ? "S" : "N", m_productoPadreid);
                if (this.dSCatalogos.SUBPRODUCTOSEXTENDED.Rows.Count > 0)
                    pRODUCTOSDataGridView.Focus();
                else
                    busquedaToolStripTextBox.Focus();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            RefrescarGrid();

        }

        private void pRODUCTOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if(this.m_bRetornarValor)
                    RetornarSeleccion(false);
                else
                    MostrarProducto();
            }
        }



        private void pRODUCTOSDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fillToolStrip_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RefrescarGrid();
        }

        private void WFSubProductos_Load(object sender, EventArgs e)
        {
            if (!verificarPermisos("Consultar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                this.Close();
                return;
            }
            FormatearCamposPersonalizados();
            if (CurrentUserID.CurrentParameters.IMOSTRAR_EXIS_SUC == DBValues._DB_BOOLVALUE_NO)
            {
                this.TSBExistenciasSucursales.Visible = false;
            }
        }

        private void WFSubProductos_Shown(object sender, EventArgs e)
        {
            RefrescarGrid();

            if (busquedaToolStripTextBox.Text == "")
            {
                busquedaToolStripTextBox.Focus();
            }
        }

        private void TSBExistenciasSucursales_Click(object sender, EventArgs e)
        {
            if (pRODUCTOSDataGridView.Rows.Count <= 0)
                return;

            WFImportandoExistencias impExist_ = new WFImportandoExistencias(pRODUCTOSDataGridView.CurrentRow.Cells[1].Value.ToString());
            impExist_.ShowDialog();
            impExist_.Dispose();
            GC.SuppressFinalize(impExist_);

            try
            {

                string strProductId = pRODUCTOSDataGridView.CurrentRow.Cells[0].Value.ToString();
                long lProductId = long.Parse(strProductId);
                WFExistenciasSucursales exSucursales = new WFExistenciasSucursales(pRODUCTOSDataGridView.CurrentRow.Cells[2].Value.ToString(), lProductId, pRODUCTOSDataGridView.CurrentRow.Cells[3].Value.ToString());
                exSucursales.ShowDialog();
                exSucursales.Dispose();
                GC.SuppressFinalize(exSucursales);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pRODUCTOSDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (pRODUCTOSDataGridView.Columns[e.ColumnIndex].Name == "BTVerProducto")
            {
                MostrarProducto();
            }
            else if (pRODUCTOSDataGridView.Columns[e.ColumnIndex].Name == "BTEditar")
            {
                EditarProducto();
            }
        }


        private void MostrarProducto()
        {
            try
            {

                if (!verificarPermisos("Consultar"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }

                int iRetornoRowIndex =  pRODUCTOSDataGridView.CurrentRow.Index;
                long iProductId = (long)pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells[0].Value;
                iPosReporting.FormProductoFicha fPi = new iPosReporting.FormProductoFicha((int)iProductId, (int)CurrentUserID.CurrentUser.IID, CurrentUserID.CurrentUser, CurrentUserID.CurrentParameters);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
            }
            catch
            {
            }
        }


        private void EditarProducto()
        {
            try
            {

                if (!verificarPermisos("Cambiar"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }

                int iRetornoRowIndex = pRODUCTOSDataGridView.CurrentRow.Index;
                string strProductClave = pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells[1].Value.ToString();
                WFProductoEdit fPi = new WFProductoEdit();
                fPi.ReCargar("Cambiar", strProductClave);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
            }
            catch
            {
            }
        }

        private void TSBAgregar_Click(object sender, EventArgs e)
        {
            if (!verificarPermisos("Agregar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            WFProductoEdit fPi = new WFProductoEdit();
            fPi.ReCargar("Agregar", "");
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
        }



        private bool verificarPermisos(string opc)
        {
            int iMenuItem = 21;
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

        private void CBMostrarExistencias_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private void pRODUCTOSDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }




        private void FormatearCamposPersonalizados()
        {
            if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO1"].Visible = false;
            }



            if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO2"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO2"].Visible = false;
            }

            if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO3"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO3"].Visible = false;
            }

            if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO4"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO4"].Visible = false;
            }

            if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO5"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO5"].Visible = false;
            }

            if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO6"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGTEXTO6"].Visible = false;
            }


            if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO1"].HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO1"].Visible = false;
            }


            if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO2"].HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO2"].Visible = false;
            }


            if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO3"].HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO3"].Visible = false;
            }

            if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO4"].HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGNUMERO4"].Visible = false;
            }


            if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
            {
                pRODUCTOSDataGridView.Columns["DGFECHA1"].HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGFECHA1"].Visible = false;
            }


            if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
            {
                pRODUCTOSDataGridView.Columns["DGFECHA2"].HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["DGFECHA2"].Visible = false;
            }
        }


        
    }
}
