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
    public partial class WFImpComprasMovPorVendedor : Form
    {
        private long vendedorId;
        private int enRuta;
        private ImportarDBF impDbfHelper;
        bool bTieneDerechoEliminarPedido = false;
        private string vendedorClave = "";

        private string m_strFileLog = "";



        public WFImpComprasMovPorVendedor()
        {
            InitializeComponent();
            impDbfHelper = new ImportarDBF();
        }

        public WFImpComprasMovPorVendedor(long vendedorId, int enRuta) : this()
        {
            this.vendedorId = vendedorId;
            this.enRuta = enRuta;
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void WFImpComprasMovPorVendedor_Load(object sender, EventArgs e)
        {
            CPERSONABE persona = new CPERSONABE();
            CPERSONAD personaDao = new CPERSONAD();

            persona = personaDao.SeleccionarPersonaPorId(vendedorId, null);

            datosVendedorLabel.Text = persona.ICLAVE + "-" + persona.INOMBRE;

            vendedorClave = persona.ICLAVE;


            CUSUARIOSD usersD = new CUSUARIOSD();

            if (!usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ELIMINARCOMPRAMOVIL, null))
            {
                bTieneDerechoEliminarPedido = false;
            }
            else
            {
                bTieneDerechoEliminarPedido = true;
            }



            if (CurrentUserID.CurrentParameters.IMOVIL3_PREIMPORTAR == "S")
            {
                procesarTodosButton.Visible = false;
                iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Columns["PROCESAR"].Visible = false;
            }

            LlenarGrid();
        }


        private void LlenarGrid()
        {
            


            iNFO_COMPRAS_MOVIL_X_VENDEDORTableAdapter.Fill(dSImportaciones.INFO_COMPRAS_MOVIL_X_VENDEDOR,
                                                             enRuta.ToString(), DateTime.Today.AddDays(-5),
                                                            (int)vendedorId,
                                                            0);

            


        }

        private void iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long doctoId = (long)iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Rows[e.RowIndex].Cells["DGID"].Value;
            if (iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("VER"))
            {
                
                WFDetalleCompraMovil wf = new WFDetalleCompraMovil(doctoId);
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
                LlenarGrid();
            }
            else if(iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString().Equals("PROCESAR"))
            {
                string errorProceso = "";
                procesarCompra(doctoId, true, out errorProceso);
                LlenarGrid();
            }
            else if (iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Columns[e.ColumnIndex].Name.Equals("DGORDENCOMPRA"))
            {
                if (MessageBox.Show("Realmente desea procesar el registro como orden de compra? ",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string errorProceso = "";
                    procesarCompra(doctoId, true, out errorProceso, DBValues._DOCTO_TIPO_ORDEN_COMPRA);
                    LlenarGrid();
                }
            }
            else if (iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Columns[e.ColumnIndex].Name.Equals("DGELIMINAR"))
            {

                if(!bTieneDerechoEliminarPedido)
                {
                    MessageBox.Show("No tiene derecho a eliminar pedido");
                    return;
                }


                if (MessageBox.Show("Desea eliminar el registro? ",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    eliminarVenta(doctoId, true);
                    LlenarGrid();
                }
            }


        }




        private bool procesarCompra(long doctoId, bool imprimirRecibo, out string error, long tipoDoctoId = DBValues._DOCTO_TIPO_COMPRA )
        {
            long doctoVentaId = 0;
            long doctoPago = 0;
            string message = String.Empty;

            error = "";


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

            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = docto.IPERSONAID;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);

            
            

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                

                //cambiamos el vendedor para que se tome el usuario actualmente loguead
                //pero mantenemos el vendedorfinal que es el vendedor que hizo efectivamente la venta
                CambiarVendedorCajero(doctoId, CurrentUserID.CurrentUser.IID, fTrans);


                bool success = impDbfHelper.COMPRA_MOVIL_COMPLETAR(doctoId, tipoDoctoId, ref doctoVentaId, ref doctoPago, fTrans);


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

                

                if(imprimirRecibo)
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

      

        private bool eliminarVenta(long doctoId, bool imprimirRecibo)
        {
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

            bool bEsFacturaElectronica = docto.IESFACTURAELECTRONICA != null && docto.IESFACTURAELECTRONICA.Equals("S");



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if(!doctoD.BorrarDOCTO(docto,fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("No se pudo borrar el registro ");
                    return false;

                }

                fTrans.Commit();
                fConn.Close();
                

                return true;
            }
            catch (Exception exception)
            {
                fTrans.Rollback();
                fConn.Close();

                MessageBox.Show(exception.Message);

                return false;
            }
            finally
            {
                fConn.Close();
            }
            


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


        private void procesarTodosButton_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Realmente desea procesar todos los registros? ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            string message = String.Empty;

            
            

            try
            {
                int registrosConErrorBloqueo = 0;
                foreach (DataGridViewRow row in iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView.Rows)
                {
                    long doctoId = (long)row.Cells["DGID"].Value;
                    string errorProceso = "";
                    if (!this.procesarCompra(doctoId, true, out errorProceso))
                    {
                        if (errorProceso == "bloqueado")
                        {
                            registrosConErrorBloqueo++;
                            continue;
                        }
                        if (MessageBox.Show("Desea continuar el procesado de las siguientes ventas moviles?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }

                }

                if (registrosConErrorBloqueo > 0)
                {
                    MessageBox.Show("Hubo registros que no se pudiero procesar porque el cliente esta bloqueado o se excedio en su limite de credito");
                }

            }
            catch (Exception exception)
            {
            }

            

            LlenarGrid();
        }


        private void iNFO_COMPRAS_MOVIL_X_VENDEDORDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }
    }
}
