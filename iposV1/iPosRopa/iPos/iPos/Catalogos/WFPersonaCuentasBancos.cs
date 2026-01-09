using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace iPos.Contabilidad
{
    public partial class WFPersonaCuentasBancos : IposForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;

        public CPERSONABE m_personaBE = null;

        public WFPersonaCuentasBancos()
        {
            InitializeComponent();
            m_bRetornarValor = false;
            m_personaBE = new CPERSONABE();
        }


        public WFPersonaCuentasBancos(long personaId):this()
        {
            m_personaBE.IID = personaId;
        }

        public WFPersonaCuentasBancos(long personaId, string palabrasBusqueda)
            : this(personaId)
        {
            m_bRetornarValor = true;
            
        }

        private void WFPersonaCuentasBancos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.CUENTABANCO_VIEW' table. You can move, or remove it, as needed.

            if (!verificarPermisos("Consultar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                this.Close();
                return;
            }

            CPERSONAD pERSONAD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = m_personaBE.IID;
            personaBE = pERSONAD.seleccionarPERSONA(personaBE, null);

            if(personaBE == null)
            {
                MessageBox.Show("EL cliente no se encontro");
            }

            lblCliente.Text = "Cliente: " + personaBE.INOMBRE;

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
                long lId = long.Parse(TableDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString());
                WFPersonaCuentaBancoEdit fPi = new WFPersonaCuentaBancoEdit(m_personaBE);
                fPi.ReCargar(opc, lId);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
                LlenarGrid();
            }
            catch(Exception ex)
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
                if (m_bRetornarValor)
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
                strABuscar = "%" + TSTPalabrasClave.Text + "%";
                numeroRegistros = this.pERSONACUENTABANCO_VIEWTableAdapter.Fill(this.dSCatalogos.PERSONACUENTABANCO_VIEW, (int)m_personaBE.IID, strABuscar);
                if (this.dSCatalogos.PERSONACUENTABANCO_VIEW.Rows.Count > 0)
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
            int iMenuItem = 329;
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


            WFPersonaCuentaBancoEdit fPi = new WFPersonaCuentaBancoEdit(m_personaBE);
            fPi.ReCargar("Agregar", 0);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
            LlenarGrid();
        }
    }
}
