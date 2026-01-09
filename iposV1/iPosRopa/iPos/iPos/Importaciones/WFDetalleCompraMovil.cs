using DataLayer.Importaciones;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using iPosReporting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Importaciones
{
    public partial class WFDetalleCompraMovil : Form
    {
        private long doctoId;
        private ImportarDBF impDbfHelper;
        private string m_strFileLog = "";
        private CDOCTOBE m_docto = null;
        private CPERSONABE m_cliente = null;

        public WFDetalleCompraMovil()
        {
            InitializeComponent();
            impDbfHelper = new ImportarDBF();
        }

        public WFDetalleCompraMovil(long doctoId) : this()
        {
            this.doctoId = doctoId;
        }
        

        private void WFDetalleCompraMovil_Load(object sender, EventArgs e)
        {
            //checar si se necesita especificar ruta de embarque
            CUSUARIOSD usersD = new CUSUARIOSD();

            if(CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {

                this.ALMACENComboBox.llenarDatos();
                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;
            }
            else
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;
            }
            

            dETALLE_COMPRA_MOVILDataGridView.Columns["CANTIDADAENVIAR"].Visible = true;

            LlenarGrid(doctoId);
            fullCantEnviar();



            CDOCTOD doctoD = new CDOCTOD();
            CPERSONAD clienteD = new CPERSONAD();
            m_docto = new CDOCTOBE();
            m_docto.IID = doctoId;
            m_docto = doctoD.seleccionarDOCTO(m_docto, null);
             
            if(m_docto != null)
            {
                m_cliente = new CPERSONABE();
                m_cliente.IID = m_docto.IPERSONAID;
                m_cliente = clienteD.seleccionarPERSONA(m_cliente, null);


            }


        }


        private void LlenarGrid(long doctoId)
        {
            int almacenId = 0;
            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                almacenId = int.Parse(this.ALMACENComboBox.SelectedValue.ToString());
            }
                dETALLE_COMPRA_MOVILTableAdapter1.Fill(dSImportaciones3.DETALLE_COMPRA_MOVIL,
                                                  almacenId, (int)doctoId);
        }

     

        private bool CambiarVendedorCajero(long doctoId, long vendedorCajeroId, FbTransaction fTrans)
        {
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = doctoId;
            doctoBE.IVENDEDORID = vendedorCajeroId;

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.CambiarVendedorCajeroDOCTOD(doctoBE, null))
            {
                throw new Exception("Error al actualizar el vendedor " + doctoD.IComentario);
            }
            return true;
        }

        






        private bool procesarVenta(long doctoId, long rutaEmbarqueId, bool imprimirFactura, bool imprimirRecibo, bool marcarComoFacturacionPendiente)
        {
            long doctoVentaId = 0;
            long doctoPago = 0;
            string message = String.Empty;

            


            //obtenemos los datos del docto para conocer algunos detalles utiles
            CDOCTOBE docto = new CDOCTOBE();
            docto.IID = doctoId;
            CDOCTOD doctoD = new CDOCTOD();
            docto = doctoD.seleccionarDOCTO(docto, null);
            if (docto == null)
            {
                MessageBox.Show("El pedido no existe");
                return false;
            }
            
            


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                
                //cambiamos el vendedor para que se tome el usuario actualmente loguead
                //pero mantenemos el vendedorfinal que es el vendedor que hizo efectivamente la venta
                CambiarVendedorCajero(doctoId, CurrentUserID.CurrentUser.IID, fTrans);
                

                bool success = impDbfHelper.COMPRA_MOVIL_COMPLETAR(doctoId, DBValues._DOCTO_TIPO_COMPRA, ref doctoVentaId, ref doctoPago, fTrans);


                if (!success)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Problema al procesar: " + impDbfHelper.IComentario);
                    return false;
                }




                CDOCTOBE doctoGenerado = new CDOCTOBE();
                CDOCTOBE doctoAFacturar = new CDOCTOBE();
                doctoGenerado.IID = doctoVentaId;
                doctoGenerado = doctoD.seleccionarDOCTO(doctoGenerado, fTrans);
                if (doctoGenerado == null)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("hubo un error no se proceso el registro ");
                    return false;
                }

                


                fTrans.Commit();
                fConn.Close();

                

                if (imprimirRecibo)
                    PosPrinter.ImprimirTicket(doctoVentaId, 0, false);

                return true;
            }
            catch (Exception exception)
            {
                fTrans.Rollback();
                fConn.Close();

                MessageBox.Show(exception.Message);

                return false;
            }


        }




        

        private void procesarButton_Click(object sender, EventArgs e)
        {





            if (procesarVenta(doctoId, 0, true, true, false))
            {

                MessageBox.Show("Proceso terminado con éxito.");
                this.Close();
            }

       
            
        }



        private void fullCantEnviar()
        {

            foreach (DataGridViewRow row in dETALLE_COMPRA_MOVILDataGridView.Rows)
            {

                if (row.Index == dETALLE_COMPRA_MOVILDataGridView.NewRowIndex)
                {
                    continue;
                }

                decimal cantidadEnviar = 0;
                try
                {
                    cantidadEnviar = Decimal.Parse(row.Cells["DG_CANTIDAD"].Value.ToString());
                }
                catch
                {
                }

                row.Cells["CANTIDADAENVIAR"].Value = cantidadEnviar;
            }
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
            long dgDoctoId = doctoId;

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

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {

            try
            {
                PosPrinter.ImprimirTicket(doctoId, 0, true);

            }
            catch (Exception ex)
            {
            }
        }

        private void ALMACENComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            LlenarGrid(this.m_docto.IID);
        }


        

    }
}
