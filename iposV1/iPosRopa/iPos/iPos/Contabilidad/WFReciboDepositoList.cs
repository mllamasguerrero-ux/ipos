using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFReciboDepositoList : Form
    {

        int m_statusdocto = 1;
        public WFReciboDepositoList()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {


            try
            {
                int? p_statusdocto, p_cajero;
                p_cajero = (this.CBCajerosTodos.Checked) ? 0 : Int32.Parse(this.VENDEDORIDTextBox.DbValue.ToString());
                
                
                switch(ComboEstado.SelectedIndex)
                {
                    case 0: p_statusdocto = -1; break;
                    case 1: p_statusdocto = 1; break;
                    case 2: p_statusdocto = 0; break;
                    case 3: p_statusdocto = 2; break;
                    default: p_statusdocto = -1; break;
                }
                //p_statusdocto = m_statusdocto;


                DateTime? fechaQuery = DateTime.Parse("1980-01-01");
                fechaQuery = DTPFecha.Value;

                this.dEPOSITOSTableAdapter.Fill(this.dSContabilidad.DEPOSITOS, p_statusdocto, p_cajero.Value, fechaQuery, (CBCorteActual.Checked ? "S" : "N"));
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnMostrarRegistros_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void gASTOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (gASTOSDataGridView.Columns[e.ColumnIndex].Name == "DGVER")
                {
                    
                    long doctoId = long.Parse(gASTOSDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                    WFReciboDepositoEdit wf = new WFReciboDepositoEdit(doctoId, "Consultar");
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();

                }
                else if (gASTOSDataGridView.Columns[e.ColumnIndex].Name == "DGCANCELAR")
                {
                    long doctoId = long.Parse(gASTOSDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                    CancelarGasto(doctoId);
                    LlenarGrid();
                }
            }
        }



        private CDOCTOBE ObtenerDoctoDeBD(long lDoctoID, FbTransaction st)
        {
            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOD vDocto = new CDOCTOD();
            docto = new CDOCTOBE();
            docto.IID = lDoctoID;
            docto = vDocto.seleccionarDOCTO(docto, st);
            return docto;
        }


        private void CancelarGasto(long doctoId)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();

            CDOCTOBE m_Docto = ObtenerDoctoDeBD(doctoId, null);
            if(m_Docto == null)
            {
                MessageBox.Show("el registro no existe");
                return;
            }



            //checar derechos
            if(m_Docto.ICORTEID == CurrentUserID.CurrentUser.ICORTEID)
            {

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCANCELAR, null))
                {
                    MessageBox.Show("No tiene derechos para cancelar gastos en el corte actual");
                    return;

                }
            }
            else if (m_Docto.IVENDEDORID == CurrentUserID.CurrentUser.IID)
            {

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCANCELAR, null))
                {

                    MessageBox.Show("No tiene derechos para cancelar gastos en un corte no activo");
                    return;
                }
            }
            else 
            {

                if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCANCELAR, null))
                {

                    MessageBox.Show("No tiene derechos para cancelar gastos de otro cajero");
                    return;
                }
            }


            if (MessageBox.Show("Esta seguro de cancelar este registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_BORRADOR)
            {

                CDOCTOD doctoD = new CDOCTOD();


                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if (doctoD.BorrarDOCTOD(m_Docto, fTrans))
                    {
                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("El registro se ha eliminado");
                        return;
                    }
                    else
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error " + doctoD.IComentario);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    MessageBox.Show(ex.Message + " " + ex.StackTrace);
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }



            }
            else if (m_Docto.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_COMPLETO)
            {

                CDOCTOD doctoD = new CDOCTOD();

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;

                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    if (doctoD.DEPOSITO_CANCEL(m_Docto,  fTrans))
                    {
                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("El registro se ha cancelado");
                        return;
                    }
                    else
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Ocurrio un error " + doctoD.IComentario);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    MessageBox.Show(ex.Message + " " + ex.StackTrace);
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }

            }
        }


        


        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            WFReciboDepositoEdit wf = new WFReciboDepositoEdit();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
            LlenarGrid();
        }

        private void WFReciboDepositoList_Load(object sender, EventArgs e)
        {

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCONSULTAROTROSCORTES, null))
            {
                this.pnlCorteActual.Enabled = false;

            }



            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOCONSULTAROTROSCORTES, null))
            {
                this.pnlCajero.Enabled = true;
            }
            else
            {
                this.pnlCajero.Enabled = false;
            }


            string strBuffer = "";
            this.VENDEDORIDTextBox.DbValue = CurrentUserID.CurrentUser.IID.ToString();
            this.VENDEDORIDTextBox.MostrarErrores = false;
            this.VENDEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
            this.VENDEDORIDTextBox.MostrarErrores = true;

            ComboEstado.SelectedIndex = 1;

            LlenarGrid();
        }

        private void btnAgregarGastoOtroCajero_Click(object sender, EventArgs e)
        {
            long autorizoId = CurrentUserID.CurrentUser.IID;

             CUSUARIOSD usuariosD = new CUSUARIOSD();
             if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_DEPOSITOAGREGAR_OTROCORTE, null))
             {

                 WFPreguntaAutorizacion ps2 = new WFPreguntaAutorizacion();
                 ps2.m_requiereAdminOrSupervisor = false;
                 ps2.ShowDialog();
                 CPERSONABE userBE = ps2.m_userBE;
                 bool bPassValido = ps2.m_bPassValido;
                 ps2.Dispose();
                 GC.SuppressFinalize(ps2);

                if (!bPassValido || userBE != null)
                 {
                     return;
                 }

                 if (!usuariosD.UsuarioTienePermisos((int)userBE.IID, (int)DBValues._DERECHO_DEPOSITOAGREGAR_OTROCORTE, null))
                 {
                     MessageBox.Show("El usuario ingresado no tiene tampoco el derecho de editar un gasto de otro cajero");
                     return;
                 }
                 autorizoId = userBE.IID;



             }



            WFReciboDepositoEdit wf = new WFReciboDepositoEdit(true, autorizoId);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
            LlenarGrid();
        }

        
    }
}
