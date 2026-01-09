using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
namespace iPos
{
    public partial class UCAsignarPerfil : UserControl
    {
        long m_iUserId;
        Boolean m_bIsEdited;
        public UCAsignarPerfil()
        {
            m_iUserId = -1;
            m_bIsEdited = false;
            InitializeComponent();
        }
        public void LlenaGrid(long iUserId)
        {
            try
            {
                this.pERFILES_ASIGNADOSTableAdapter.Fill(this.dSAccessControl.PERFILES_ASIGNADOS, (int)iUserId);
                m_iUserId = iUserId;
            }
            catch (System.Exception ex)
            {
                m_iUserId = -1;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            m_bIsEdited = false;
        }
        private void UCAsignarPerfil_Load(object sender, EventArgs e)
        {
            
        }
        public void SetIsEditedFlag(Boolean bIsEdited)
        {
            m_bIsEdited = bIsEdited;
        }
        public void ClearGrid()
        {
            this.dSAccessControl.PERFILES_ASIGNADOS.Clear();
        }
        public Boolean SaveChanges(long iUserId, FbTransaction fTrans)
        {
            CUSUARIO_PERFILBE oUPerBe = new CUSUARIO_PERFILBE();
            CUSUARIO_PERFILD oUPerD = new CUSUARIO_PERFILD();
            if (iUserId == -1)
            {
                return false;
            }
            try
            {
                
                oUPerBe.IUP_PERSONAID = iUserId;
                oUPerD.BorrarPerfilesDeUsuario(oUPerBe, fTrans);
                foreach (DataGridViewRow dataRow in this.pERFILES_ASIGNADOSDataGridView.Rows)
                {
                    if (
                        dataRow.Cells["dgPermitido"].Value != null
                        && dataRow.Cells["dgPermitido"].Value != DBNull.Value
                        && ((int)dataRow.Cells["dgPermitido"].Value == 1))
                    {
                        
                        
                        if (dataRow.Cells["dgPerfil"].Value != null
                            && dataRow.Cells["dgPerfil"].Value != DBNull.Value)
                        {
                            oUPerBe = new CUSUARIO_PERFILBE();
                            oUPerBe.IUP_PERSONAID = iUserId;
                            oUPerBe.IUP_PERFIL = (int)dataRow.Cells["dgPerfil"].Value;
                            oUPerD.AgregarUSUARIO_PERFIL(oUPerBe, fTrans);
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans;
            if (m_iUserId == -1)
            {
                return;
            }
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                
                if (SaveChanges(m_iUserId, fTrans))
                {
                    fTrans.Commit();
                    m_bIsEdited = false;
                }
                else
                {
                    fTrans.Rollback();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
        }
        private void pERFILES_ASIGNADOSDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            m_bIsEdited = true;
        }

        private void pERFILES_ASIGNADOSDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (pERFILES_ASIGNADOSDataGridView.IsCurrentCellDirty)
            {
                pERFILES_ASIGNADOSDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            } 
        }
    }
}
