using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class LookUpSucursales : IposForm
    {
        int m_sucursalId;
        public DataRow m_rtnDataRow;

        bool m_tieneDerechoTrasladarTodasLasSucursales = false;

        public LookUpSucursales()
        {
            m_sucursalId = 0;
            InitializeComponent();
        }

        public LookUpSucursales(int p_sucursalId):this()
        {


            CUSUARIOSD usersD = new CUSUARIOSD();
            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_TRASLADAR_TODASSUCURSALES, null))
                m_tieneDerechoTrasladarTodasLasSucursales = true;

            m_sucursalId = p_sucursalId;
            try
            {
                this.sUCURSALTRASLADOSTableAdapter1.Fill(this.dSPuntoDeVentaAux2.SUCURSALTRASLADOS, 
                                                        (m_tieneDerechoTrasladarTodasLasSucursales ? "S" : "N") ,
                                                        m_sucursalId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }




        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && sUCURSALTRASLADOSDataGridView.CurrentRow.Index < (sUCURSALTRASLADOSDataGridView.RowCount - 1)) 
                                       ? sUCURSALTRASLADOSDataGridView.CurrentRow.Index - 1 :*/ sUCURSALTRASLADOSDataGridView.CurrentRow.Index;
                DataGridViewRow dr = sUCURSALTRASLADOSDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void sUCURSALTRASLADOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                RetornarSeleccion(false);
        }

        private void sUCURSALTRASLADOSDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //    RetornarSeleccion(true);
        }

        private void sUCURSALTRASLADOSDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }

        private void LookUpSucursales_Load(object sender, EventArgs e)
        {


        }
        
    }
}
