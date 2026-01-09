using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;

namespace iPos
{
    public partial class WFListaInventarios : IposForm
    {
        public WFListaInventarios()
        {
            InitializeComponent();
        }


        private void LlenarGrid()
        {
            try
            {
                this.dSInventarioFisico.ListaInventarioFisico.Clear();
                int estatusDocto;
                estatusDocto = (this.RB_Estatus_Cerradas.Checked) ? 1 : (this.RB_Estatus_Pendientes.Checked) ? 0 : 3;

                string activo = this.RBCiclicos.Checked ? "N" : (this.RBNoCiclicos.Checked ? "S" : "ALL");

                this.listaInventarioFisicoTableAdapter.Fill(this.dSInventarioFisico.ListaInventarioFisico, estatusDocto,  DTPFecha.Value, activo);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BTCapturar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("La creacion de un nuevo inventario fisico, eliminara los inventarios fisicos pendientes, desea continuar? ", "Confirmar creacion de nuevo inventario fisico ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (INVFIS_DEL_PENDIENTES(null))
                {

                    bool bEsInventarioCiclico = false;
                    Inventario.WFIsInventarioCiclico wfI = new Inventario.WFIsInventarioCiclico();
                    wfI.ShowDialog();
                    bEsInventarioCiclico = wfI.EsInventarioCiclico;
                    wfI.Dispose();
                    GC.SuppressFinalize(wfI);

                    WFInventarioFisico wf = new WFInventarioFisico(bEsInventarioCiclico);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();
                }

            }

        }

        private void BTLlenar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void WFListaInventarios_Load(object sender, EventArgs e)
        {
            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            this.DTPFecha.Value = DateTime.Today.AddMonths(-1);
            LlenarGrid();
        }

        private void EditarConsultar()
        {
            if (this.dataGridView1.CurrentRow.Index >= 0)
            {

                long iEstatusDoctoId = (long)this.dataGridView1.CurrentRow.Cells["ESTATUSDOCTOID"].Value;
                long iDoctoId = (long)this.dataGridView1.CurrentRow.Cells["CONSECUTIVO"].Value;
                long iTipoDoctoId = (long)this.dataGridView1.CurrentRow.Cells["DGTIPODOCTOID"].Value;

                if (iEstatusDoctoId == DBValues._DOCTO_ESTATUS_COMPLETO)
                {
                    WFConsultaInventarioFisico wfc = new WFConsultaInventarioFisico(iDoctoId);
                    wfc.ShowDialog();
                    wfc.Dispose();
                    return;
                }
                else if (iEstatusDoctoId == DBValues._DOCTO_ESTATUS_INVENTARIOFIN)
                {

                    WFListaDiferencias wfc = new WFListaDiferencias(iDoctoId);
                    wfc.ShowDialog();
                    wfc.Dispose();
                    LlenarGrid();
                    return;
                }

                switch(iTipoDoctoId)
                {
                    case 50:
                        {
                            WFInventarioFisico wf = new WFInventarioFisico(iDoctoId);
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }
                        break;

                    case 53:
                        {
                            WFInventarioFisicoXLoc wf = new WFInventarioFisicoXLoc(iDoctoId);
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                            GC.SuppressFinalize(wf);
                        }
                        break;
                }
                LlenarGrid();
            }
        }

        private void BTEditar_Click(object sender, EventArgs e)
        {
            EditarConsultar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarConsultar();
        }



        private bool INVFIS_DEL_PENDIENTES( FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_DEL_PENDIENTES";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionesBD.ConexionBD.ConexionString(), null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }


        private bool INVFIS_DEL_NOTERMINADOS(FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_DEL_NOTERMINADOS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionesBD.ConexionBD.ConexionString(), null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }



        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_INVENTARIOFISICO.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }
            return true;
        }

        private void BTCapturarXLoc_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("La creacion de un nuevo inventario fisico, eliminara los inventarios fisicos pendientes, desea continuar? ", "Confirmar creacion de nuevo inventario fisico ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (INVFIS_DEL_PENDIENTES(null))
                {

                    bool bEsInventarioCiclico = false;
                    Inventario.WFIsInventarioCiclico wfI = new Inventario.WFIsInventarioCiclico();
                    wfI.ShowDialog();
                    bEsInventarioCiclico = wfI.EsInventarioCiclico;
                    wfI.Dispose();
                    GC.SuppressFinalize(wfI);

                    WFInventarioFisicoXLoc wf = new WFInventarioFisicoXLoc(bEsInventarioCiclico);
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();
                }

            }
        }

        private void btnImprimirInvActual_Click(object sender, EventArgs e)
        {
            WFImpresionInventario wf = new WFImpresionInventario();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void btnLimpiarInventariosNoTerminados_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de querer eliminar todos los inventarios fisicos pendientes o no terminados? ", "Confirmar limpieza de inventarios ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (MessageBox.Show("Por favor confirme una vez mas que quiere eliminar todos los inventarios fisicos pendientes o no terminados ", "Confirmar limpieza de inventarios ", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (INVFIS_DEL_NOTERMINADOS(null))
                    {
                        LlenarGrid();
                        MessageBox.Show("Los inventarios no terminados han sido eliminados");
                    }
                }


            }
        }

        private void btnReconteo_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.CurrentRow.Index >= 0)
            {

                long iEstatusDoctoId = (long)this.dataGridView1.CurrentRow.Cells["ESTATUSDOCTOID"].Value;
                long iDoctoId = (long)this.dataGridView1.CurrentRow.Cells["CONSECUTIVO"].Value;
                long iTipoDoctoId = (long)this.dataGridView1.CurrentRow.Cells["DGTIPODOCTOID"].Value;

                WFReconteo wfc = new WFReconteo(iDoctoId);
                wfc.ShowDialog();
                wfc.Dispose();
                return;
            }
        }
    }
}
