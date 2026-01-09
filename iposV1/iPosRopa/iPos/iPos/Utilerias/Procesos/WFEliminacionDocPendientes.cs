using FirebirdSql.Data.FirebirdClient;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Utilerias.Procesos
{
    public partial class WFEliminacionDocPendientes : Form
    {
        public WFEliminacionDocPendientes()
        {
            InitializeComponent();
        }

        private void btnVerDocumentosPendientes_Click(object sender, EventArgs e)
        {


            WFLOOKUPVENTAS look = new WFLOOKUPVENTAS();
            look.m_busquedaInicialAmplia = true;
            look.ShowDialog();
            look.Dispose();
            GC.SuppressFinalize(look);
        }

        private void LimpiarRegistrosPendientes()
        {

            CDOCTOD doctoD = new CDOCTOD();


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (doctoD.LIMPIARVENTASPENDIENTES(fTrans))
                {
                    fTrans.Commit();
                    fConn.Close();
                    MessageBox.Show("Se han limpiado los registros pendientes");
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

        private void btnEliminarDocPendientes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Realmente desea eliminar los registros pendientes?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LimpiarRegistrosPendientes();
            }
        }
    }
}
