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
    public partial class WFReportes : IposForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;

        public WFReportes()
        {
            InitializeComponent();
            m_bRetornarValor = false;
        }


        public WFReportes(string palabrasBusqueda)
            : this()
        {
            m_bRetornarValor = true;
        }

        private void WFReportes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.REPORTE_VIEW' table. You can move, or remove it, as needed.
            try
            {
                if (!verificarPermisos("Consultar"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    this.Close();
                    return;
                }

                LlenarGrid();
            }
            catch
            {
            }
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
                else if (TableDataGridView.Columns[e.ColumnIndex].Name == "verReporte")
                {
                    MostrarReporte(false);
                }
                else if (TableDataGridView.Columns[e.ColumnIndex].Name == "disenarReporte")
                {
                    MostrarReporte(true);
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
                string strID = TableDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString();
                long lId = long.Parse(strID);
                WFReporteEdit fPi = new WFReporteEdit();
                fPi.ReCargar(opc, lId);
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
                    MostrarReporte(false);
                }
                else
                {
                    MostrarRegistro("Consultar");

                }
            }
        }


        private void MostrarReporte(bool diseno)
        {



            try
            {

                if (!verificarPermisos(diseno ? "ReporteEditar" : "ReporteVer"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }
                int iRetornoRowIndex = TableDataGridView.CurrentRow.Index;
                string strArchivo = TableDataGridView.Rows[iRetornoRowIndex].Cells["dgARCHIVO"].Value.ToString();

                string reporteRuta = CurrentUserID.CurrentParameters.IRUTAREPORTES.Replace(@"{BaseDirectory}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location))
                                 + "\\" + strArchivo;

                switch(strArchivo.ToLower())
                {
                    case "webexis_totales":
                        {
                            iPosReporting.ReportesWebExis.WFReporteTotalesWebExis rp = new iPosReporting.ReportesWebExis.WFReporteTotalesWebExis();
                            rp.ShowDialog();
                            rp.Dispose();
                            GC.SuppressFinalize(rp);
                        }

                        break;
                    default:
                        {

                            if (!diseno)
                            {
                                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(reporteRuta);
                                rp.ShowDialog();
                                rp.Dispose();
                                GC.SuppressFinalize(rp);
                            }
                            else
                            {
                                iPos.Login_and_Maintenance.WFReporteDesigning rp = new Login_and_Maintenance.WFReporteDesigning(reporteRuta);
                                rp.ShowDialog();
                                rp.Dispose();
                                GC.SuppressFinalize(rp);
                            }
                        }
                        break;
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error " + ex.Message + ex.StackTrace);
            }

        }






        private void LlenarGrid()
        {
            string strABuscar;
            int numeroRegistros = 0;
            try
            {
                strABuscar = "%" + TSTPalabrasClave.Text + "%";
                numeroRegistros = this.TableTableAdapter.Fill(this.dSCatalogos.REPORTE_VIEW, strABuscar, CurrentUserID.CurrentUser.IID);
                if (this.dSCatalogos.LINEA_VIEW.Rows.Count > 0)
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
            int iMenuItem = 139;
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            switch (opc)
            {
                case "Cambiar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 3000, null);


                case "Agregar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 3000, null);

                case "Consultar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem, null);

                case "Borrar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 2000, null);

                case "ReporteVer":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 4000, null);

                case "ReporteEditar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 5000, null);
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


            WFReporteEdit fPi = new WFReporteEdit();
            fPi.ReCargar("Agregar", 0);
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);
            LlenarGrid();
        }

    }
}
