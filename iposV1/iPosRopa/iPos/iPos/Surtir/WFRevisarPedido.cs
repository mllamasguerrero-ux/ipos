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
using System.Collections;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using DataLayer.Importaciones;


namespace iPos
{
    public partial class WFRevisarPedido : Form
    {


        public WFRevisarPedido()
        {
            InitializeComponent();
        }


        private void WFRevisarPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSSurtido.CANCDEVOSURTIR' table. You can move, or remove it, as needed.

            this.DTSurtidoVenta.Value = DateTime.Today.AddDays(-30);

            LlenarGrid();
            LlenarGridSurtidos();

            TBTransacccion.Focus();

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoReimprimirRevision = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REIMPRIMIR_REVISION, null);
            DGTICKETREVISION.Visible = usuarioTienePermisoReimprimirRevision;

        }

        private void LlenarGrid()
        {
            int folioDocumento = 0;

            this.dOCTOSAREVISARTableAdapter.Fill(this.dSSurtido.DOCTOSAREVISAR, folioDocumento, DBValues._DOCTO_REVISIONFINAL_PENDIENTE, DTSurtidoVenta.Value);
        }

        

        private void dOCTOSASURTIRDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 )
            {

                if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGSURTIR")
                {
                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
                    int dgFolio = 0;
                    try
                    {
                        dgFolio = (int)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGFOLIO"].Value;
                    }
                    catch { }
                    string strNombreCliente = (string)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGNOMBRECLIENTE"].Value;
                    DateTime fecha = (DateTime)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGFECHA"].Value;
                    long dgAlmacenId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGALMACENID"].Value;
                    
                    WFRevisarPedidoDetalle wf = new WFRevisarPedidoDetalle(dgDoctoId, dgFolio, strNombreCliente, fecha, dgAlmacenId);

                    
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    LlenarGrid();


                    TBTransacccion.Text = "";
                    TBTransacccion.Focus();

                }
                else if (dOCTOSASURTIRDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIR")
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                    long dgDoctoId = (long)dOCTOSASURTIRDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("pdoctoid", dgDoctoId);
                    dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                    dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                    dictionary.Add("creadoPorUserId", 0);
                    string strReporte = "recibolargo.frx";


                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
            }
        }




        


        

        
        


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        
        
        
        private void LlenarGridSurtidos()
        {
            int folioDocumento = 0;

            this.dOCTOSREVISADOSTableAdapter.Fill(this.dSSurtido.DOCTOSREVISADOS, folioDocumento, DBValues._DOCTO_REVISIONFINAL_REVISADO, DTVentasSurtidas.Value);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "DGIMPRIMIRSURTIDO")
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                    long dgDoctoId = (long)dataGridView1.Rows[e.RowIndex].Cells["DGIDSURTIDO"].Value;

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("pdoctoid", dgDoctoId);
                    dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                    dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                    dictionary.Add("creadoPorUserId", 0);
                    string strReporte = "recibolargo.frx";


                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "DGTICKETREVISION")
                {
                    long dgDoctoId = (long)dataGridView1.Rows[e.RowIndex].Cells["DGIDSURTIDO"].Value;

                    WFRevisarPedidoDetalle.ImprimirTicketRevision(dgDoctoId);
                }
            }
        }

        private void btnActualizarSurtidos_Click(object sender, EventArgs e)
        {
            LlenarGridSurtidos();
        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }

        private void SeleccionarTransaccion()
        {


            WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, 0, DBValues._DOCTO_TIPO_VENTA);
            wfl.ShowDialog();

            DataRow dr = wfl.m_rtnDataRow;

            wfl.Dispose();
            GC.SuppressFinalize(wfl);

            if (dr != null)
            {
                this.TBTransacccion.Text = dr[15].ToString();
            }
        }

        private void TBTransacccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() == "")
                {
                    SeleccionarTransaccion();
                }
                else
                {
                    try
                    {

                        CDOCTOD doctoD = new CDOCTOD();
                        CDOCTOBE doctoBE = new CDOCTOBE();
                        doctoBE.IFOLIO = int.Parse(TBTransacccion.Text);
                        doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;

                        doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);
                        if(doctoBE != null)
                        {
                            if(doctoBE.IESTADOREVISADOID != DBValues._DOCTO_REVISIONFINAL_PENDIENTE )
                            {
                                MessageBox.Show("El registro ya esta revisado");
                                return;
                            }

                            CPERSONABE personaBE = new CPERSONABE();
                            CPERSONAD personaD = new CPERSONAD();
                            personaBE.IID = doctoBE.IPERSONAID;
                            personaBE = personaD.seleccionarPERSONA(personaBE, null);

                            string personaNombre = personaBE == null ? "" : personaBE.INOMBRE;

                            WFRevisarPedidoDetalle wf = new WFRevisarPedidoDetalle(doctoBE.IID, doctoBE.IFOLIO, personaNombre, doctoBE.IFECHA, doctoBE.IALMACENID);


                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                            LlenarGrid();

                            TBTransacccion.Text = "";
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
