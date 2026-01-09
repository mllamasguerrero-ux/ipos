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
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using DataLayer.Importaciones;
using ConexionesBD;
using Microsoft.ApplicationBlocks.Data;
using iPosReporting;
using Newtonsoft.Json;

namespace iPos
{
    public partial class WFProcesarPedidoSucursalDet : IposForm
    {
        //string m_fileName;
        //DateTime m_fecha;
        //TimeSpan m_time;
        long m_doctoId;
        long m_tipodoctoId;
        string m_strSucursal = "";
        string m_strDescripcionPedido = "";

        decimal dMaxCantidad = 1000;

        public bool m_bCancelar;


        CDOCTOBE m_doctoBE = null;

        bool m_bTieneDerechoExisSucPed = false; 


        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        public WFProcesarPedidoSucursalDet()
        {
            InitializeComponent();
        }
        public WFProcesarPedidoSucursalDet(long doctoId,long tipodoctoId,string strSucursal, string strDescripcionPedido)
        {
            InitializeComponent();
            m_doctoId = doctoId;
            m_tipodoctoId = tipodoctoId;
            m_bCancelar = true;
            m_strSucursal = strSucursal;
            m_strDescripcionPedido = strDescripcionPedido;
            //m_fecha = fecha;
            //m_time = time;
        }
        private void WFProcesarPedidoSucursalDet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSImportaciones.IMP_RECIBIDOS' table. You can move, or remove it, as needed.

            //existencia remota
            ponerTieneExisSucPed();
            lblEsperandoExisRemota.Text = "";
            if (!m_bTieneDerechoExisSucPed || CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ == null || CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ.Trim().Length == 0)
            {
                btnObtenerExitenciaRemota.Visible = false;
                GC_EXISTENCIAREMOTA.Visible = false;
            }
            else
            {

                btnObtenerExitenciaRemota.Visible = true;
                GC_EXISTENCIAREMOTA.Visible = true;
            }



            this.lblDescripcionPedido.Text = this.m_strDescripcionPedido;
            this.lblSucursalPedido.Text = this.m_strSucursal;

            LlenarDoctoBE(m_doctoId);
            if(m_doctoBE != null)
            {
                DefaultFacturaElectronica(m_doctoBE);
            }



            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                this.ALMACENComboBox.llenarDatos();
                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;

                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID != 0 ? CurrentUserID.CurrentUser.IALMACENID : DBValues._DOCTO_ALMACEN_DEFAULT;
            }
            else
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;
            }


            FormatearColumnasPersonalizados();
            LlenarGrid();



            //this.reportViewer1.RefreshReport();


            if (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S"))
            {
                CBSurtidoPostpuesto.Visible = true;
                CBSurtidoPostpuesto.Checked = true;
            }
            else
                CBSurtidoPostpuesto.Visible = false;


            if (CurrentUserID.CurrentParameters.IHABREVISIONFINAL != null && CurrentUserID.CurrentParameters.IHABREVISIONFINAL.Equals("S"))
            {
                CBRevisionFinal.Visible = true;
                CBRevisionFinal.Checked = true;
            }
            else
                CBRevisionFinal.Visible = false;

        }


        private long ObtainAlmacenId()
        {

            long almacenId = DBValues._DOCTO_ALMACEN_DEFAULT;
            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                almacenId = int.Parse(this.ALMACENComboBox.SelectedValue.ToString());
            }
            return almacenId;
        }

        private void LlenarGrid()
        {

            int almacenId = 0;
            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
            {
                almacenId = (int)ObtainAlmacenId();
            }

            try
            {
                this.eNVIARASUCURSALTableAdapter1.Fill(this.dSImportaciones3.ENVIARASUCURSAL, almacenId, (int)m_doctoId);

                //this.iMP_REC_DETDataGridView.Sort(this.iMP_REC_DETDataGridView.Columns["DESCRIPCION2"], System.ComponentModel.ListSortDirection.Ascending);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void ponerTieneExisSucPed()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            m_bTieneDerechoExisSucPed = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VER_EXIS_SUC_PEDIDO, null);
        }

        private void LlenarDoctoBE(long m_doctoId)
        {
            m_doctoBE = new CDOCTOBE();
            m_doctoBE.IID = m_doctoId;

            CDOCTOD doctoD = new CDOCTOD();
            m_doctoBE = doctoD.seleccionarDOCTO(m_doctoBE, null);
        }

        private void DefaultFacturaElectronica(CDOCTOBE doctoBE)
        {
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            CSUCURSALD sucursalD = new CSUCURSALD();
            sucursalBE.IID = doctoBE.ISUCURSALTID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE,null);

            if (sucursalBE != null)
            {
                CBFacturaElectronica.Checked = sucursalBE.IPOR_FACT_ELECT.Equals("S");
            }

        }

        private void BTRECIBIR_Click(object sender, EventArgs e)
        {

            bool bMostrarFacturaElectronica = false;

            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            if(!validarExistencias())
            {
                MessageBox.Show("No hay existencias suficiente para procesar el pedido");
                return;

            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false ;

            long doctoVentaId = 0;


            ArrayList resultadosExportacion = new ArrayList();

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                int count = 0;
                bool bPedidoPostPuesto = false;

                if (CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"))
                {
                    long almacenId = ObtainAlmacenId();
                    objDoctoD.CambiarALMACENID(this.m_doctoId, almacenId, fTrans);
                }

                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {
                    
                    if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }
                    objRecBE = new CMOVTOBE();
                    objRecBE.IID = long.Parse(row.Cells["GC_MOVTOID"].Value.ToString());
                    objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                    objRecBE.ICANTIDADFALTANTE = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString()) - objRecBE.ICANTIDAD;

                    count++;
                    objRecBE.IORDEN = count;

                    objRecBE.ITIPODIFERENCIAINVENTARIOID = 0;
                    try
                    {
                        if(row.Cells["DGC_RAZONDIFINVID"].Value != null)
                             if(row.Cells["DGC_RAZONDIFINVID"].Value.ToString() != "")
                                objRecBE.ITIPODIFERENCIAINVENTARIOID = long.Parse(row.Cells["DGC_RAZONDIFINVID"].Value.ToString());
                    }
                    catch
                    {
                    }

                    //if (objRecBE.ICANTIDAD != 0)
                    //{
                        if (objRecD.PEDIRMOVTOD(objRecBE, fTrans) == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show(objRecD.IComentario);
                            return;
                        }
                   // }
                }


                objDoctoBE.IID = this.m_doctoId;

                if (!AsignarClienteXSucursal(objDoctoBE, fTrans))
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(objDoctoD.IComentario);
                    return;
                }


                /* surtido estado */
                
                if (CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO != null && CurrentUserID.CurrentParameters.IHABSURTIDOPOSTPUESTO.Equals("S"))
                {
                    CDOCTOD doctoD = new CDOCTOD();
                    objDoctoBE.IID = this.m_doctoId;
                    //objDoctoBE.IESTADOSURTIDOID = CBSurtidoPostpuesto.Checked ? 2 : 1;



                    objDoctoBE.IESTADOSURTIDOID = CBSurtidoPostpuesto.Checked ? (
                        CurrentUserID.CurrentParameters.ICXCVALIDARTRASLADOS != null && CurrentUserID.CurrentParameters.ICXCVALIDARTRASLADOS.Equals("S") && 
                        CurrentUserID.CurrentParameters.IHABVERIFICACIONCXC != null && CurrentUserID.CurrentParameters.IHABVERIFICACIONCXC.Equals("S") ? DBValues._DOCTO_SURTIDOESTADO_CXC
                        : DBValues._DOCTO_SURTIDOESTADO_PENDIENTE)
                        : DBValues._DOCTO_SURTIDOESTADO_SURTIDO;



                    if (!doctoD.CambiarESTADOSURTIDOID(objDoctoBE, fTrans))
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("ERRORES: " + doctoD.IComentario.Replace("%", "\n"));
                        return;
                    }
                    bPedidoPostPuesto = true;
                }

                /* revisado estado */
                if (CurrentUserID.CurrentParameters.IHABREVISIONFINAL != null && CurrentUserID.CurrentParameters.IHABREVISIONFINAL.Equals("S"))
                {

                    CDOCTOD doctoD = new CDOCTOD();
                    objDoctoBE.IID = this.m_doctoId;

                    if (!doctoD.CambiarESTADOREVISADOID(objDoctoBE, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show("ERRORES al cambiar estado revision : " + doctoD.IComentario.Replace("%", "\n"));
                        throw new Exception();
                    }
                }


                objDoctoBE.IID = this.m_doctoId;
                objDoctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;


                bRes = objDoctoD.MATRIZ_ENVIOPEDIDO_COMPLETAR(objDoctoBE, ref doctoVentaId, CBFacturaElectronica.Checked, fTrans);

                if (bRes == false)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(objDoctoD.IComentario);
                    return;
                }


                if (!bPedidoPostPuesto)
                {
                    if (!ExportarEnvioPedido(fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show(objDoctoD.IComentario);
                        return;
                    }
                }


                CDOCTOD doctD = new CDOCTOD();
                objDoctoBE.IID = this.m_doctoId;
                objDoctoBE = doctD.seleccionarDOCTO(objDoctoBE, fTrans);


                CDOCTOBE doctoVentaBE = new CDOCTOBE();

                if (doctoVentaId != 0)
                {

                    doctoVentaBE.IID = doctoVentaId;
                    doctoVentaBE = doctD.seleccionarDOCTO(doctoVentaBE, fTrans);

                    if (!GuardarPago(doctoVentaBE, ((doctoVentaBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) ? DBValues._FORMA_PAGO_CREDITO : DBValues._FORMA_PAGO_EFECTIVO), fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show(objDoctoD.IComentario);
                        return;
                    }

                    if (!bPedidoPostPuesto && CBFacturaElectronica.Checked && doctoVentaId != 0)
                    {

                        if (!FacturaElectronica(doctoVentaBE, fTrans))
                        {

                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show("No se pudo generar la factura electronica");
                            return;
                        }
                        bMostrarFacturaElectronica = true;
                    }
                }
                else
                {



                    if (!GuardarPago(objDoctoBE, ((objDoctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA) ? DBValues._FORMA_PAGO_CREDITO : DBValues._FORMA_PAGO_EFECTIVO), fTrans))
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show(objDoctoD.IComentario);
                        return;
                    }
                }

               

                fTrans.Commit();
                fConn.Close();

                resultadosExportacion.Add("Archivo de sincronizacion creado");


                objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);


                PosPrinter.ImprimirTicket(objDoctoBE.IID);


                if (!bPedidoPostPuesto)
                {
                    iPos.ImportaDesdeFtp iDBF = new iPos.ImportaDesdeFtp();
                    if (iDBF.EnviarArchivosAFtpDeMatrizPedidos(ref resultadosExportacion, objDoctoBE.IFOLIO, null))
                    {
                        resultadosExportacion.Add("Archivo de sincronizacion enviado a ftp");
                    }




                    StringBuilder strBuffer = new StringBuilder("");
                    strBuffer.Append(iDBF.IComentario + "\n");
                    foreach (string str in resultadosExportacion)
                    {
                        strBuffer.Append(str);
                    }
                    MessageBox.Show(strBuffer.ToString() + "\n");

                    if (bMostrarFacturaElectronica && doctoVentaId != 0)
                    {
                        imprimirFacturaElectronica(doctoVentaBE, null);
                    }


                }
                else
                {
                    MessageBox.Show("Registros generados, se exportaran en surtido");
                }
                
                m_bCancelar = false;
                

                //exportando
                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;


                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                try
                {
                    fTrans.Rollback();
                }
                catch
                {
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fConn.Close();
            }
            
            
        }



        private bool ExportarEnvioPedido(FbTransaction ft)
        {
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            CSUCURSALBE sucursalDestinoBE = new CSUCURSALBE();

            parametroBE = parametroD.seleccionarPARAMETROActual(ft);
            if (parametroBE == null)
            {
                MessageBox.Show(parametroD.IComentario);
                return false;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {

                MessageBox.Show("Define la sucursal en la pantalla de empresa");
                return false;
            }


            cajaBE.IID = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;

            cajaBE = cajaD.seleccionarCAJA(cajaBE, ft);

            if (cajaBE == null)
            {
                MessageBox.Show(cajaD.IComentario);
                return false;
            }

            objDoctoBE.IID = m_doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, ft);

            if (objDoctoBE == null)
            {
                MessageBox.Show(objDoctoD.IComentario);
                return false;
            }

            ExportarDBF exportDbf = new ExportarDBF();

            if (parametroBE.IEXPORTCATALOGOAUX.Equals("S"))
            {
                if (!exportDbf.ExportEnvioMatrizPedidoAux(parametroBE, cajaBE, DateTime.Now, objDoctoBE, CurrentUserID.CurrentUser, ft))
                {
                    MessageBox.Show(exportDbf.IComentario);
                    return false;
                }
            }


            if (!exportDbf.ExportEnvioMatrizPedido(parametroBE, cajaBE, DateTime.Now, objDoctoBE,ft))
            {
                MessageBox.Show(exportDbf.IComentario);
                return false;
            }
            return true;
        }


        private void iMP_REC_DETDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridViewRow row = iMP_REC_DETDataGridView.Rows[e.RowIndex];
            //if(row.Cells["GC_CANTIDAD"].Value != null)
            //    row.Cells["GC_APEDIR"].Value = row.Cells["GC_CANTIDAD"].Value;
        }

        private void iMP_REC_DETDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void iMP_REC_DETDataGridView_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {

            //foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            //{
            //    if(row.Cells["GC_CANTIDAD"].Value != null)
            //        row.Cells["GC_APEDIR"].Value = row.Cells["GC_CANTIDAD"].Value;
            //}
        }

        private void iMP_REC_DETDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            //MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;


        }

        private void iMP_REC_DETDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =  iMP_REC_DETDataGridView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("A ENVIAR")) return;

            try
            {
                decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());
                decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());
                if (/*dSurtida > dCantidad ||*/ dSurtida < 0)
                {
                    MessageBox.Show("La cantidad surtida no puede ser  menor que cero");
                    e.Cancel = true;
                }
                else if (dSurtida != dCantidad
                         && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value.ToString() == ""))
                {


                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value = null;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDADFALTANTE"].Value = "";
                    //iMP_REC_DETDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);


                }
                else if(dSurtida == dCantidad)
                {

                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value = null;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDADFALTANTE"].Value = "";
                }
            }
            catch
            {
            }

        }





        private CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (TBCodigo.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                this.LBProductoDescripcion.Text = "";
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION;

        }


        private void TBCodigo_Validated(object sender, EventArgs e)
        {

        }



        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(TBCodigo.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCodigo.Text = dr["CLAVE"].ToString().Trim();
                TBCodigo.Focus();
                TBCodigo.Select(TBCodigo.Text.Length, 0);
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (TBCodigo.Text.Trim() == "")
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                    return;
                }
                this.TBCantidad.Focus();
                TBCantidad.Select(0, TBCantidad.Text.Length);
            }
        }

        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.BTAgregar.Focus();
            //}
        }


        private void ProcessAdd()
        {

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = (int)this.ObtainAlmacenId() ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_PEDIDA = null;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            long? P_MOVTOID = null;

            string P_LOCALIDAD = "";// TBLocalidad.Text;


            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }

            if (prod.IESPRODUCTOPADRE == "S")
            {
                MessageBox.Show("No puede seleccionar un producto padre");
                return;
            }

            P_IDPRODUCTO = prod.IID;

            try
            {
                P_CANTIDAD_PEDIDA = decimal.Parse(TBCantidad.Text.Trim());
                
            }
            catch
            {
                MessageBox.Show("La cantidad no tiene el formato adecuado");
                return;
            }


            if (P_CANTIDAD_PEDIDA > dMaxCantidad  )
            {

                if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            if (P_CANTIDAD_PEDIDA <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero ", "Cantidad menor o igual a cero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }


            if (prod.IINVENTARIABLE != null && prod.IINVENTARIABLE.Equals("S") &&
                (prod.INEGATIVOS != null && prod.INEGATIVOS.Equals("N")))
            {

                if ((bool)prod.isnull["IEXISTENCIA"])
                {

                    MessageBox.Show("No hay existencia suficiente");
                    return;
                }

                if (P_CANTIDAD_PEDIDA > prod.IEXISTENCIA)
                {
                    MessageBox.Show("No hay existencia suficiente");
                    return;
                }
            }

            ////}
            //if (P_CANTIDAD_PEDIDA > prod.I)
            //{

            //    if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //    {
            //        return;
            //    }
            //}




            //if (!(bool)this.m_Docto.isnull["IID"])
            //{
                P_IDDOCTO = m_doctoId;
            //}

                P_CANTIDAD = P_CANTIDAD_PEDIDA;



                iPos.Importaciones.DSImportaciones3.ENVIARASUCURSALRow rowEdicion = null;

                // aqui se decidira si agregar a un registro ya existente o no
                foreach (iPos.Importaciones.DSImportaciones3.ENVIARASUCURSALRow dr in this.dSImportaciones3.ENVIARASUCURSAL.Rows)
                {
                    if (dr.PRODUCTOID == prod.IID)
                    {
                        if (MessageBox.Show("Ya existe un detalle con ese producto, desea agregarlo a ese registro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            rowEdicion = dr;
                            P_MOVTOID = dr.MOVTOID;
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                }



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_tipodoctoId, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_CANTIDAD_PEDIDA, ref P_MOVTOID, null, fTrans))
                {
                    fTrans.Commit();
                    //this.dSImportaciones.PEDIR.AcceptChanges();

                    if (rowEdicion == null)
                    {
                        this.dSImportaciones3.ENVIARASUCURSAL.AddENVIARASUCURSALRow(m_doctoId, (long)P_MOVTOID, "+", 0, prod.ICLAVE, prod.IDESCRIPCION1, (decimal)P_CANTIDAD, "", (decimal)P_CANTIDAD, (decimal)P_CANTIDAD, P_LOCALIDAD, prod.IEXISTENCIA, prod.IINVENTARIABLE,
                                                          prod.ITEXTO1, prod.ITEXTO2, prod.ITEXTO3, prod.ITEXTO4, prod.ITEXTO5, prod.ITEXTO6,
                                                          prod.INUMERO1, prod.INUMERO2, prod.INUMERO3, prod.INUMERO4,
                                                          prod.IFECHA1, prod.IFECHA2, prod.IDESCRIPCION2, prod.INEGATIVOS, prod.IID,0);
                    }
                    else
                    {
                        rowEdicion.CANTIDAD = rowEdicion.CANTIDAD + (decimal)P_CANTIDAD;
                        rowEdicion.CANTIDADSURTIDA = ( rowEdicion.IsCANTIDADSURTIDANull() ? 0 : rowEdicion.CANTIDADSURTIDA) + (decimal)P_CANTIDAD;
                    }
                    //this.pEDIRTableAdapter.Fill(this.dSImportaciones.PEDIR, (int)m_doctoId);
                    //ObtenerDoctoDeBD((long)P_IDDOCTO);
                    PrepararSiguienteEntrada();

                }
                else
                {
                    fTrans.Rollback();
                    MessageBox.Show(this.IComentario);
                    this.TBCodigo.Focus();
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



        public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                        decimal? P_CANTIDAD,
                                        long? P_IDPRODUCTO,
                                        string P_VD_VENDEDOR,
                                        long? P_USERID,
                                        string P_LOTE,
                                        int? US_SUPERVISOR,
                                        int? ALMACENID,
                                        long? SUCURSALID,
                                        DateTime P_FECHAVENCE,
                                        long P_TIPO_DOCTO,
                                        long? P_SUCURSALTID,
                                        long? P_ALMACENTID,
                                        string P_PROMOCION,
                                        long? P_TIPODIFERENCIAINVENTARIOID,
                                        decimal? P_CANTIDAD_SURTIDA,
                                        ref long? P_MOVTOID,
                                        long? P_LOTEIMPORTADO,
                                        FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (P_CANTIDAD_SURTIDA.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD_SURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTO_INSERT";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    
                        P_MOVTOID = (long)arParms[arParms.Length - 2].Value;
                }



                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        private void PrepararSiguienteEntrada()
        {
            this.TBCantidad.Text = "";
            this.TBCodigo.Text = "";
            //this.TBLocalidad.Text = "";
            this.TBCodigo.Focus();
            
        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {
            ProcessAdd();
        }

        private void TBLocalidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.TBCantidad.Focus();
                TBCantidad.Select(0, TBCantidad.Text.Length);
            }
        }




        private bool validarExistencias()
        {
            foreach (DataGridViewRow row in this.iMP_REC_DETDataGridView.Rows)
            {
                if(!row.IsNewRow)
                {
                    if (!validarExistenciaRow(row))
                        return false;
                }
            }
            return true;
        }

        private bool validarExistenciaRow(DataGridViewRow row)
        {

            decimal existenciaMatriz = 0, cantidadPedido = 0;
            string inventariable = "N", negativos = "N";

            try
            {
                if (row.Cells["GC_EXISTENCIA"].Value != DBNull.Value)
                {
                    existenciaMatriz = decimal.Parse(row.Cells["GC_EXISTENCIA"].Value.ToString());
                }


                if (row.Cells["GC_APEDIR"].Value != DBNull.Value)
                {
                    cantidadPedido = decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                }


                if (row.Cells["GC_INVENTARIABLE"].Value != DBNull.Value)
                {
                    inventariable = row.Cells["GC_INVENTARIABLE"].Value.ToString();
                }


                if (row.Cells["DG_NEGATIVOS"].Value != DBNull.Value)
                {
                    negativos = row.Cells["DG_NEGATIVOS"].Value.ToString();
                }

                if (cantidadPedido > existenciaMatriz && inventariable == "S" && negativos == "N")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return true;
            }
        }



        private void coloreaGrid()
        {
            foreach (DataGridViewRow row in this.iMP_REC_DETDataGridView.Rows)
            {

                coloreaRow(row);
            }
        }


        private void coloreaRow(DataGridViewRow row)
        {
            

            try
            {
                

                if (!validarExistenciaRow(row))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch
            {

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            row.Cells["GC_APEDIR"].Style.BackColor = Color.GreenYellow;
            row.Cells["GC_APEDIR"].Style.ForeColor = Color.Black;

        }

        private void iMP_REC_DETDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (iMP_REC_DETDataGridView.Columns[e.ColumnIndex].Name == "GC_PRODUCTO" && e.Value != null && e.Value != DBNull.Value)
            {
                coloreaRow(iMP_REC_DETDataGridView.Rows[e.RowIndex]);
            }
        }

        private void iMP_REC_DETDataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && iMP_REC_DETDataGridView["GC_PRODUCTO", e.RowIndex].Value != null && iMP_REC_DETDataGridView["GC_PRODUCTO", e.RowIndex].Value != DBNull.Value)
            {
                coloreaRow(iMP_REC_DETDataGridView.Rows[e.RowIndex]);
            }
        }

        private void FormatearColumnasPersonalizados()
        {
            try
            {
                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO1"].Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO2"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO2"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO3"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO4"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO4"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO5"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO5"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO6"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGTEXTO6"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO1"].HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO2"].HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO2"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO3"].HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO4"].HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGNUMERO4"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGFECHA1"].HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGFECHA1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                {
                    iMP_REC_DETDataGridView.Columns["DGFECHA2"].HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                }
                else
                {
                    iMP_REC_DETDataGridView.Columns["DGFECHA2"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }



        
        private void BTActualizarReporte_Click(object sender, EventArgs e)
        {


            report1.Load(FastReportsConfig.getPathForFile("EnvioPedidoMatriz.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
                report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
                report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);

                report1.RegisterData(this.dSImportaciones3.Tables["ENVIARASUCURSAL"], "Table");
                report1.GetDataSource("Table").Enabled = true;

                report1.SetParameterValue("soloconexistencias", CBMostrarExistencias.Checked);
                report1.SetParameterValue("descripcionpedido", this.m_strDescripcionPedido);
                report1.SetParameterValue("sucursal", this.m_strSucursal);





                //FastReport.Data.DataSourceBase databand = (FastReport.Data.TableDataSource)report1.FindObject("Table");
                //FastReport.Data.DataSourceBase src = report1.GetDataSource("items");
                //FastReport.DataBand databand = (bs as FastReport.DataBand);
                //databand = report1.GetDataSource("items");

                if (report1.Prepare())
                    report1.ShowPrepared();

        }

        private void CBMostrarExistencias_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAjustarExistencias_Click(object sender, EventArgs e)
        {
            LlenarGrid();
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }

                decimal cantidadAPedir = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                decimal existencia = 0;
                try
                {
                   existencia = Decimal.Parse(row.Cells["GC_EXISTENCIA"].Value.ToString());
                }
                catch
                {
                }

                if (cantidadAPedir > existencia)
                {
                    if (existencia < 0)
                    {
                        row.Cells["GC_APEDIR"].Value = 0;
                    }
                    else
                    {
                        row.Cells["GC_APEDIR"].Value = existencia;
                    }
                    coloreaRow(row);
                }


            }
        }



        private bool GuardarPago(CDOCTOBE objDoctoBE, long formaPagoId, FbTransaction ft)
        {
            
            CDOCTOPAGOBE pagoBE;
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();


                pagoBE = new CDOCTOPAGOBE();
                pagoBE.IDOCTOID = objDoctoBE.IID;
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                pagoBE.IIMPORTE = objDoctoBE.ITOTAL;
                pagoBE.INOTAS = "";

                pagoBE.IIMPORTERECIBIDO = objDoctoBE.ITOTAL;

                pagoBE.IFORMAPAGOID = /*1*/formaPagoId;
                pagoBE.IDOCTOID = objDoctoBE.IID;
                pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;

                pagoBE.IESAPARTADO = "N";
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;

                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;

                if (pagoBE.IFORMAPAGOID == DBValues._FORMA_PAGO_EFECTIVO)
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;

                pagoBE = pagoD.InsertarDOCTOPAGOD(pagoBE, ft);

                if (ft == null)
                {
                    return false;
                }
                return true;
            
        }
        

        private bool AsignarClienteXSucursal(CDOCTOBE objDoctoBE, FbTransaction ft)
        {


            CDOCTOD vData = new CDOCTOD();
            return vData.DOCTO_ASIGNARCLIENTEXSUCURSALT(objDoctoBE.IID, ft);

        }

        private bool FacturaElectronica(CDOCTOBE objDoctoBE,FbTransaction ft)
        {



            if (objDoctoBE != null && objDoctoBE.IID > 0)
            {


                bool retorno;

                if (ValidarDatosParaFacturaElectronica(objDoctoBE,ft))
                {
                    iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(objDoctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_TIMBRAR, ft, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
                    CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
                    fe.ShowDialog();
                    retorno = fe.m_facturacionRealizada;
                    fe.Dispose();
                    GC.SuppressFinalize(fe);
                }
                else
                {
                    retorno = false;
                }
                return retorno;


            }
            return false;
        }



        private bool ValidarDatosParaFacturaElectronica(CDOCTOBE docto, FbTransaction ft)
        {
            CPuntoDeVentaD pd = new CPuntoDeVentaD();
            if (!pd.VALIDAR_PARAFACTURAELECTRONICA(docto, ft))
            {
                MessageBox.Show("Errores " + pd.IComentario);
                if (pd.IComentario.Contains("HAY PRODUCTOS SIN CLAVE SAT"))
                {
                    PuntoDeVenta.WFProductosSinClaveSat wfProdSat = new PuntoDeVenta.WFProductosSinClaveSat(docto.IID);
                    wfProdSat.ShowDialog();
                    wfProdSat.Dispose();
                    GC.SuppressFinalize(wfProdSat);
                }
                return false;
            }
            return true;
        }



        private bool imprimirFacturaElectronica(CDOCTOBE objDoctoBE, FbTransaction ft)
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            objDoctoBE = doctoD.seleccionarDOCTO(objDoctoBE, null);

            if ((bool)objDoctoBE.isnull["IFOLIOSAT"] || (bool)objDoctoBE.isnull["IESTATUSDOCTOID"]
                || objDoctoBE.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || objDoctoBE.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }

            WFFacturaElectronica fe = new WFFacturaElectronica(objDoctoBE, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }

        private void btnImprimirLoQuePiden_Click(object sender, EventArgs e)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
            long dgDoctoId = m_doctoId;

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


        List<CM_PROPBE> prodsExistenciaRemota = new List<CM_PROPBE>();
        string errorExistenciaRemota = "";
        private void btnObtenerExitenciaRemota_Click(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ == null || CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ.Trim().Length == 0)
            {
                MessageBox.Show("No esta definido el webservice para obtener la existencia");
                return;
            }

            prodsExistenciaRemota = new List<CM_PROPBE>();

            lblEsperandoExisRemota.Text = "Esperando existencia remota ..";

            bgExistenciaRemota.RunWorkerAsync();


        }



        private void bgExistenciaRemota_DoWork(object sender, DoWorkEventArgs e)
        {
            errorExistenciaRemota = "";

            CPERSONABE cliente = new CPERSONABE();
            CPERSONAD clienteD = new CPERSONAD();
            cliente.IID = DBValues._CLIENTEMOSTRADOR;
            cliente = clienteD.seleccionarPERSONA(cliente, null);

            if (cliente == null)
            {
                errorExistenciaRemota = "No se pudo obtener el cliente";
                return;
            }




            ArrayList vedps = new ArrayList();
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {






                CM_VEDPBE retorno = new CM_VEDPBE();
                retorno.IVENTA = "00001";
                retorno.ICLIENTE = "MOSTRADOR";

                retorno.IPRODUCTO = row.Cells["GC_PRODUCTO"].Value.ToString();
                retorno.IID_FECHA = DateTime.Today;
                retorno.IID_HORA = "";
                retorno.ICANTIDAD = 1.0m;
                retorno.IPRECIO = 1.0m;
                retorno.IDESCUENTO = 0.0m;
                retorno.ICLASIFICA = "";

                vedps.Add(retorno);
            }


            CM_VEDPBE[] vedpbes = new CM_VEDPBE[vedps.Count];
            vedps.CopyTo(vedpbes, 0);
            string jsonStr = JsonConvert.SerializeObject(vedpbes, Formatting.Indented);


            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ;


            if (strWebService.Trim().Length > 0)
            {
                string strUrl = strWebService.Trim().Equals(".") ? (CurrentUserID.CurrentParameters.IWEBSERVICE != null && CurrentUserID.CurrentParameters.IWEBSERVICE.Trim().Length > 0 ?
                                            CurrentUserID.CurrentParameters.IWEBSERVICE : service1.Url) :
                                            strWebService.Trim();
                service1.Url = strUrl;
            }


            string strRespuesta = "";
            try
            {

                if (strWebService.Trim().Equals("."))
                {
                    string strSucursal = m_strSucursal;
                    strRespuesta = service1.LeerExistenciasSucursalMultipleProductosBD(strSucursal, jsonStr,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs
                                    );
                }
                else
                {
                    strRespuesta = service1.ValidarVentaMovil(jsonStr, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    "vocero",//iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    "PK3Qz65ePJo29FdcEqM+Mg=="//iPos.Tools.FTPManagement.m_strFTPFolderPassWs
                                    );
                }


                if (!strRespuesta.StartsWith("["))
                {
                    errorExistenciaRemota = "No se pudo validar la venta: " + strRespuesta;
                }



                prodsExistenciaRemota = JsonConvert.DeserializeObject<List<CM_PROPBE>>(strRespuesta);


            }
            catch (Exception ex)
            {
                errorExistenciaRemota = "No se pudo validar las existencias " + ex.Message;
                return;
            }

        }

        private void bgExistenciaRemota_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblEsperandoExisRemota.Text = "";

            if (errorExistenciaRemota != "")
            {
                MessageBox.Show(errorExistenciaRemota);
                return;
            }


            if (/*prods.Count > 0*/ prodsExistenciaRemota != null && prodsExistenciaRemota.Count > 0)
            {
                bool bHayProblemasDeExistencia = false;

                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {
                    string productoRow = row.Cells["GC_PRODUCTO"].Value.ToString();
                    decimal cantidadPedida = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());

                    bool productoHayado = false;
                    bool flagFaltaExistencia = false;
                    foreach (CM_PROPBE prod in prodsExistenciaRemota)
                    {
                        if (productoRow.Trim().Equals(prod.IPRODUCTO.Trim()))
                        {
                            row.Cells["GC_EXISTENCIAREMOTA"].Value = prod.IEXIS1;

                            if (cantidadPedida > prod.IEXIS1)
                            {

                                flagFaltaExistencia = true;

                            }
                            productoHayado = true;
                            break;
                        }
                    }
                    if (!productoHayado || flagFaltaExistencia)
                    {
                        bHayProblemasDeExistencia = true;
                    }

                }

                if (!bHayProblemasDeExistencia)
                {
                    //MessageBox.Show("Parece que hay existencias suficiente para todos los productos de esta venta");
                }
            }
        }

        private void iMP_REC_DETDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ALMACENComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            LlenarGrid();
        }

        private void iMP_REC_DETDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
