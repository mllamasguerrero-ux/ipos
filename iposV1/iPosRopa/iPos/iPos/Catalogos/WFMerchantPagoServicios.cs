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
    public partial class WFMerchantPagoServicios : IposForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;

        public WFMerchantPagoServicios()
        {
            InitializeComponent();
            m_bRetornarValor = false;
        }


        public WFMerchantPagoServicios(string palabrasBusqueda)
            : this()
        {
            m_bRetornarValor = true;
        }

        private void WFMerchantPagoServicios_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.MERCHANTPAGOSERVICIO_VIEW' table. You can move, or remove it, as needed.
            
            if(!verificarPermisos("Consultar"))
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
                long lID = long.Parse(TableDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString());
                //string strCLAVE = TableDataGridView.Rows[iRetornoRowIndex].Cells["DGMERCHANTID"].Value.ToString();
                WFMerchantPagoServicioEdit fPi = new WFMerchantPagoServicioEdit();
                fPi.ReCargar(opc, lID);
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
                numeroRegistros = this.TableTableAdapter.Fill(this.dSCatalogos.MERCHANTPAGOSERVICIO_VIEW, strABuscar);
                if (this.dSCatalogos.TIPOTRANSACCION_VIEW.Rows.Count > 0)
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
            int iMenuItem = 83;
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


            WFMerchantPagoServicioEdit fPi = new WFMerchantPagoServicioEdit();
            fPi.ReCargar("Agregar", 0);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
            LlenarGrid();
        }

    }
}
