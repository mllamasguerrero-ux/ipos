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

namespace iPos
{
    public partial class WFImportarOrdenesDet : IposForm
    {
        //string m_fileName;
        //DateTime m_fecha;
        //TimeSpan m_time;
        long m_doctoId;
        long m_tipodoctoId;
        bool m_rellenarsurtida = true;

        bool m_recepcionProcesada = false;

        bool m_usuarioPuedeCambiarGastosAdic = false;
        bool m_usuarioPuedeCambiarPrecio = false;


        decimal m_dMontoTransaccionUSD;

        bool m_manejaAlmacen = false;
        bool m_usuarioPuedeCambiarAlmacen = false;


        public WFImportarOrdenesDet()
        {
            InitializeComponent();
        }
        public WFImportarOrdenesDet(long doctoId, long tipodoctoId)
        {
            InitializeComponent();
            m_doctoId = doctoId;
            m_tipodoctoId = tipodoctoId;
            //m_fecha = fecha;
            //m_time = time;
        }
        private void WFImportarOrdenesDet_Load(object sender, EventArgs e)
        {


            CUSUARIOSD usuariosD = new CUSUARIOSD();

            //almacenes
            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));
            if (!m_manejaAlmacen)
            {
                this.ALMACENComboBox.Visible = false;
                this.lblAlmacen.Visible = false;
            }
            else
            {

                this.ALMACENComboBox.Visible = true;
                this.lblAlmacen.Visible = true;

                this.ALMACENComboBox.llenarDatos();
                try
                {
                    this.ALMACENComboBox.SelectedIndex = -1;

                    m_usuarioPuedeCambiarAlmacen = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARDEALMACEN, null);

                    SetDefaultAlmacenEstatus();
                }
                catch
                {
                }
            }


            // TODO: This line of code loads data into the 'dSImportaciones.IMP_RECIBIDOS' table. You can move, or remove it, as needed.
            iMP_REC_DETDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            try
            {
                FormatearCamposPersonalizados();
                LlenarDatosDocto();
                this.rECIBIRTableAdapter.Fill(this.dSImportaciones.RECIBIR, (int)m_doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            //gastos adicionales
            m_usuarioPuedeCambiarGastosAdic = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_GASTOSADIC_COMPRA, null);
            btnGastosAdic.Visible = m_usuarioPuedeCambiarGastosAdic;
            borrarGastosAdicionales();


            m_usuarioPuedeCambiarPrecio = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CAMBIARPRECIORECEPCIONCOMPRA, null);
            DGPRECIOCONIMPUESTO.ReadOnly = !m_usuarioPuedeCambiarPrecio;


            VisibilidadUSDInfo(CBMostrarUSD.Checked);




        }


        public void SetDefaultAlmacenEstatus()
        {
            

            if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
            else
                this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;

            if (m_usuarioPuedeCambiarAlmacen)
                this.ALMACENComboBox.Enabled = true;
            else
                this.ALMACENComboBox.Enabled = false;

        }

        private void LlenarDatosDocto()
        {


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE docBE = new CDOCTOBE();
            docBE.IID = m_doctoId;
            docBE = objDoctoD.seleccionarDOCTO(docBE, null);

            if(docBE != null)
            {

                if(docBE.IREFERENCIAS != null)
                {
                    TBObservaciones.Text = docBE.IREFERENCIAS;
                }

                if(docBE.IALMACENID > 0 && m_manejaAlmacen)
                {
                    this.ALMACENComboBox.SelectedDataValue = docBE.IALMACENID;
                }
            }    
                 

        }

        private void BTRECIBIR_Click(object sender, EventArgs e)
        {

            if (TBReferencias.Text.Trim().Length == 0)
            {
                MessageBox.Show("Necesita ingresar la factura");
                return;
            }

            PreguntarGastosAdicionalesSiAplica();




            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool bRes = false ;


            long? P_LOTEIMPORTADO = null;
            bool bActualizarLoteImportadoEnDocto = false;

            try
            {


                if (CurrentUserID.CurrentParameters.IMANEJARLOTEIMPORTACION == "S")
                {
                    CDOCTOBE docBE = new CDOCTOBE();
                    docBE.IID = m_doctoId;
                    docBE = objDoctoD.seleccionarDOCTO(docBE, null);

                    if(docBE != null)
                    {
                        CPERSONABE provee = obtainCurrentProveedorPorId(docBE.IPERSONAID);

                        if (provee != null && provee.IESIMPORTADOR == "S")
                        {

                                WFDefineLoteImportado pl_ = new WFDefineLoteImportado();
                                pl_.ShowDialog();
                                CLOTESIMPORTADOSBE loteImportado = pl_.loteImportado;
                                pl_.Dispose();
                                GC.SuppressFinalize(pl_);

                                if (loteImportado == null || loteImportado.IID == 0)
                                {
                                    //MessageBox.Show("Debe definir un lote o pedimento de importacion");
                                    //return ;
                                }
                                else
                                {

                                    P_LOTEIMPORTADO = loteImportado.IID;
                                    bActualizarLoteImportadoEnDocto = true;
                                }
                        }  
                    }
                    
                }

               



                fConn.Open();
                fTrans = fConn.BeginTransaction();


                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {
                    
                    if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }
                    objRecBE = new CMOVTOBE();
                    objRecBE.IID = long.Parse(row.Cells["GC_MOVTOID"].Value.ToString());
                    objRecBE.ICANTIDADSURTIDA = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());

                    decimal precioConImpuesto = Decimal.Parse(row.Cells["DGPRECIOCONIMPUESTO"].Value.ToString());
                    decimal tasaIva = Decimal.Parse(row.Cells["DGTASAIVA"].Value.ToString());
                    decimal tasaIeps = Decimal.Parse(row.Cells["DGTASAIEPS"].Value.ToString());
                    objRecBE.IPRECIO = calculaPrecioSinImpuestos(precioConImpuesto, tasaIva, tasaIeps);


                    if (row.Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                    {
                        try{
                            objRecBE.ILOTE = row.Cells["GC_LOTE"].Value.ToString();
                        }
                        catch{
                             objRecBE.ILOTE = "";
                        }


                        try
                        {
                            objRecBE.IFECHAVENCE = (DateTime)row.Cells["FECHAVENCE"].Value;
                        }
                        catch
                        {
                        }

                        if (objRecBE.ILOTE.Trim().Length == 0 && objRecBE.ICANTIDADSURTIDA > 0)
                        {
                            MessageBox.Show("Debe asignar lote al producto " + row.Cells["GC_PRODUCTO"].Value.ToString());
                            fConn.Close();
                            return;
                        }
                    }
                    if (row.Cells["MANEJALOTEIMPORTADO"].Value.ToString().Equals("S") && P_LOTEIMPORTADO != null && P_LOTEIMPORTADO.HasValue)
                    {
                        objRecBE.ILOTEIMPORTADO = P_LOTEIMPORTADO.Value;
                    }


                    

                    objRecBE.ITIPODIFERENCIAINVENTARIOID = 0;
                    try
                    {
                        if(row.Cells["GC_CANTIDAD"].Value != null)
                             if(row.Cells["GC_CANTIDAD"].Value.ToString() != "")
                                objRecBE.ITIPODIFERENCIAINVENTARIOID = long.Parse(row.Cells["DGC_RAZONDIFINVID"].Value.ToString());
                    }
                    catch
                    {
                    }

                    if (objRecBE.ICANTIDADSURTIDA != 0)
                    {

                        if (objRecBE.IID != 0)
                        {
                            //if (objRecD.RECIBIRMOVTOD(objRecBE, fTrans) == false) if (objRecD.RECIBIRMOVTOD(objRecBE, fTrans) == false)
                            if (objDoctoD.RECEPCIONORDENCOMPRA_RECIMOVTO(objRecBE, fTrans) == false)
                            {
                                fTrans.Rollback();
                                fConn.Close();
                                MessageBox.Show(objRecD.IComentario);
                                return;
                            }
                        }
                        else
                        {
                           long movtoRefId  = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());

                           if (objDoctoD.CopiarMovtoOrdenDeCompra(objRecBE, movtoRefId, fTrans) == false)
                            {
                                
                                fTrans.Rollback();
                                fConn.Close();
                                MessageBox.Show(objDoctoD.IComentario);
                                return;
                            }

                        }

                    }
                }



                Hashtable tbl = new Hashtable();
                foreach (DataGridViewRow rowHd in iMP_REC_DETDataGridView.Rows)
                {

                    if (rowHd.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }


                    objDoctoBE.IID = objRecBE.IID = long.Parse(rowHd.Cells["GC_DOCTOID"].Value.ToString());
                    objDoctoBE.IOBSERVACION = TBObservaciones.Text;

                    objDoctoBE.IREFERENCIAS = TBReferencias.Text;
                    objDoctoBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;

                    objDoctoBE.IALMACENID = m_manejaAlmacen ? long.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : DBValues._DOCTO_ALMACEN_DEFAULT;

                    if (!tbl.ContainsKey(objDoctoBE.IID) )
                    {
                        tbl.Add(objDoctoBE.IID, objDoctoBE.IID);

                        if (m_tipodoctoId == DBValues._DOCTO_TIPO_RECEPCIONORDEN_COMPRA)
                            bRes = objDoctoD.ORDENCOMPRA_COMPLETAR(objDoctoBE, CBMantenerAbierta.Checked, fTrans);
                        /*else if (m_tipodoctoId == DBValues._DOCTO_TIPO_TRASPASO_REC)
                            bRes = objDoctoD.TRASLADO_COMPLETAR(objDoctoBE, fTrans);*/

                        if (bRes == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show(objDoctoD.IComentario);
                            return;
                        }
                    }

                }


                fTrans.Commit();
                fConn.Close();


                //actualizar lote importado en docto
                if (bActualizarLoteImportadoEnDocto && P_LOTEIMPORTADO.HasValue)
                {
                    ActualizarLoteImportadoEnDocto(objDoctoBE, P_LOTEIMPORTADO.Value);
                }


                iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_COMPRA, false, false, 1, CBMostrarUSD.Checked);

                //iPos.PosPrinter.ImprimirTicket(m_doctoId, Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION);

                MessageBox.Show("Se han confirmado con exito la recepción de mercancía");

                m_recepcionProcesada = true;

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


        private decimal calculaPrecioSinImpuestos(decimal precioConImpuestos, decimal dTasaIva, decimal dTasaIeps)
        {

            decimal dPrecioSinImpuestos = (precioConImpuestos / (1 + (dTasaIva / 100))) / (1 + (dTasaIeps / 100));
            return Math.Round(dPrecioSinImpuestos, 2);


        }

        private void PreguntarGastosAdicionalesSiAplica()
        {
            if (CurrentUserID.CurrentParameters.IMANEJAGASTOSADIC == "S")
            {
                CMOVTOGASTOSADICD movtoGastoD = new CMOVTOGASTOSADICD();
                int cuenta = movtoGastoD.cuentaGastosXDoctoID(m_doctoId, null);

                if (cuenta <= 0)
                {
                    if (MessageBox.Show("No ha agregado gastos adicionales . Desea hacerlo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AbrirGastosAdicionales();
                    }
                }
            }
        }



        private bool ExportarRecepcionDeCompra(FbTransaction ft)
        {
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            CCAJAD cajaD = new CCAJAD();
            CCAJABE cajaBE = new CCAJABE();


            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            CSUCURSALBE sucursalDestinoBE = new CSUCURSALBE();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);
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

            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

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
            if (!exportDbf.ExportRecepcionCompras(parametroBE, cajaBE, DateTime.Now, objDoctoBE.IID))
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
            //    row.Cells["GC_SURTIDA"].Value = row.Cells["GC_CANTIDAD"].Value;
        }

        private void iMP_REC_DETDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void iMP_REC_DETDataGridView_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {

            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {
                if (m_rellenarsurtida)
                {
                    row.Cells["MOVTOREFID"].Value = row.Cells["GC_MOVTOID"].Value;
                    if (row.Cells["GC_CANTIDAD"].Value != null)
                    {
                        //row.Cells["GC_SURTIDA"].Value = row.Cells["GC_CANTIDAD"].Value;
                    }
                }
            }
        }

        private void iMP_REC_DETDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;


        }

        private void iMP_REC_DETDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =  iMP_REC_DETDataGridView.Columns[e.ColumnIndex].HeaderText;

            e.Cancel = false;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("SURTIDA") && iMP_REC_DETDataGridView.Columns["DGCOSTOENDOLAR"].Index != e.ColumnIndex) return;

            if (headerText.Equals("SURTIDA"))
            {

                try
                {
                    long movtoId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_MOVTOID"].Value.ToString());
                    decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());
                    decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());

                    // checar sumatoria de recepcion
                    long movtoRefId = 0;
                    decimal sumaCantidadGrupo = 0;
                    DataGridViewRow dNewRow = null;
                    if (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                    {

                        movtoRefId = long.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MOVTOREFID"].Value.ToString());
                        sumaCantidadGrupo = getSumCantidadGrupo(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
                        dNewRow = getNewDataGridRowGroup(movtoRefId, iMP_REC_DETDataGridView.Rows[e.RowIndex]);
                        if (sumaCantidadGrupo + dSurtida > dCantidad)
                        {
                            MessageBox.Show("La cantidad surtida ( sumada por producto)  no puede ser mayor que la cantidad del pedido ni menor que cero");
                            e.Cancel = true;
                            return;
                        }
                    }



                    if ((dSurtida > dCantidad && movtoId != 0) || dSurtida < 0)
                    {
                        MessageBox.Show("La cantidad surtida no puede ser mayor que la cantidad del pedido ni menor que cero");
                        e.Cancel = true;
                        return;
                    }
                    else if (dSurtida < dCantidad
                             && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value.ToString() == ""))
                    {


                        /*
                        WFSelRazonDiferencia look = new WFSelRazonDiferencia();
                        look.ShowDialog();


                        DataRow dr = look.m_rtnDataRow;

                        if (dr != null)
                        {
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value = (long)dr[0];
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVTEXT"].Value = dr[7].ToString();
                        }

                        look.Dispose();*/


                        if (dSurtida == 0)
                        {
                            e.Cancel = false;
                        }


                        if (dSurtida > 0 &&
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S")
                            && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value.ToString().Trim().Length == 0))
                        {

                            WFDefineLote pl_ = new WFDefineLote();
                            pl_.m_descripcionProducto = iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_DESCRIPCION"].Value.ToString();
                            pl_.ShowDialog();
                            string lote_ = pl_.m_lote;
                            DateTime fechaVence_ = pl_.m_fechaVence;
                            pl_.Dispose();
                            GC.SuppressFinalize(pl_);
                            if (lote_ == null || lote_.Trim().Length == 0)
                            {
                                e.Cancel = true;
                                MessageBox.Show("Necesita agregar un lote");
                                return;
                            }
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value = lote_;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value = fechaVence_;
                        }



                    }
                    else if (dSurtida == dCantidad)
                    {

                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value = null;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVTEXT"].Value = "";

                        if (dSurtida > 0 &&
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S")
                           && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value.ToString().Trim().Length == 0))
                        {

                            WFDefineLote pl_ = new WFDefineLote();
                            pl_.m_descripcionProducto = iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_DESCRIPCION"].Value.ToString();
                            pl_.ShowDialog();
                            string lote_ = pl_.m_lote;
                            DateTime fechaVence_ = pl_.m_fechaVence;
                            pl_.Dispose();
                            GC.SuppressFinalize(pl_);

                            if (lote_ == null || lote_.Trim().Length == 0)
                            {
                                e.Cancel = true;
                                MessageBox.Show("Necesita agregar un lote");
                                return;
                            }

                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value = lote_;
                            iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value = fechaVence_;

                        }

                    }








                }
                catch
                {
                }
            }

            else if (iMP_REC_DETDataGridView.Columns["DGCOSTOENDOLAR"].Index == e.ColumnIndex)
            {
                try
                {
                    decimal dNuevoCostoEnDolar = decimal.Parse(e.FormattedValue.ToString());
                    decimal dViejoCostoEnDolar = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGCOSTOENDOLAR"].Value.ToString());

                    decimal dSurtida = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_SURTIDA"].Value.ToString());


                    long P_MOVTOID = (long)iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_MOVTOID"].Value;

                    if (dNuevoCostoEnDolar == dViejoCostoEnDolar)
                        return;



                    if (dNuevoCostoEnDolar < 0)
                    {

                        MessageBox.Show("El costo en dolar no puede ser menor que cero");
                        e.Cancel = true;
                    }
                    else
                    {
                        CMOVTOD movtoD = new CMOVTOD();
                        if (!movtoD.CambiarCOSTOENDOLAR(P_MOVTOID, dNuevoCostoEnDolar, null))
                        {

                            MessageBox.Show("Ocurrio un error " + movtoD.IComentario);
                            e.Cancel = true;
                        }
                        else
                        {
                            //iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGIMPORTEENDOLAR"].Value = dSurtida * dNuevoCostoEnDolar;
                            if (CBMostrarUSD.Checked)
                            {
                                GetTotalesPagosUSD();
                                RefreshTotalesTransaccionUSD();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error : Cheque el formato de entrada del valor \n" + ex.Message + ex.StackTrace);
                    e.Cancel = true;
                }
            }


        }


        private void despuesDeValidar(int eRowIndex)
        {

            long movtoId = long.Parse(iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["GC_MOVTOID"].Value.ToString());
            decimal dSurtida = decimal.Parse(iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["GC_SURTIDA"].Value.ToString());
            decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["GC_CANTIDAD"].Value.ToString());


            // checar sumatoria de recepcion
            long movtoRefId = 0;
            decimal sumaCantidadGrupo = 0;
            DataGridViewRow dNewRow = null;
            //string auxdebug = iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["DGIMPORTEENDOLAR"].Value.ToString();
            decimal dCostoEnDolar = decimal.Parse(iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["DGCOSTOENDOLAR"].Value.ToString());
            decimal dImporteEnDolar = 0;
            try
            {
                dImporteEnDolar = decimal.Parse(iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["DGIMPORTEENDOLAR"].Value.ToString() == "" ? "0" : iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["DGIMPORTEENDOLAR"].Value.ToString());
            }
            catch
            {

            }
            decimal dImporteEnDolarNuevo = dCostoEnDolar * dSurtida;
            if (dImporteEnDolarNuevo != dImporteEnDolar)
            {
                iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["DGIMPORTEENDOLAR"].Value = dImporteEnDolarNuevo;
                iMP_REC_DETDataGridView.Refresh();

            }



            if (iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
            {

                movtoRefId = long.Parse(iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["MOVTOREFID"].Value.ToString());
                sumaCantidadGrupo = getSumCantidadGrupo(movtoRefId, iMP_REC_DETDataGridView.Rows[eRowIndex]);
                dNewRow = getNewDataGridRowGroup(movtoRefId, iMP_REC_DETDataGridView.Rows[eRowIndex]);

                if (sumaCantidadGrupo + dSurtida == dCantidad)
                {
                    if (dNewRow != null)
                    {
                        iMP_REC_DETDataGridView.Rows.Remove(dNewRow);
                    }
                }
                else if (sumaCantidadGrupo + dSurtida < dCantidad)
                {
                    if (dNewRow != null)
                    {
                        dNewRow.Cells["RECIBIDAS"].Value = dCantidad - (sumaCantidadGrupo + dSurtida);
                    }
                    else if (dSurtida > 0)
                    {
                        m_rellenarsurtida = false;


                        this.dSImportaciones.RECIBIR.AcceptChanges();
                        Importaciones.DSImportaciones.RECIBIRRow desRow = this.dSImportaciones.RECIBIR.NewRECIBIRRow();
                        Importaciones.DSImportaciones.RECIBIRRow sourceRow = (Importaciones.DSImportaciones.RECIBIRRow)this.dSImportaciones.RECIBIR.Rows[eRowIndex];
                        desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];

                        desRow.LOTE = "";
                        desRow.FECHAVENCE = DateTime.Today;
                        desRow.CANTIDADSURTIDA = 0;
                        desRow.RECIBIDAS = dCantidad - (sumaCantidadGrupo + dSurtida);
                        desRow.MOVTOID = 0;
                        desRow.COSTOENDOLAR = dCostoEnDolar;
                        desRow.IMPORTEENDOLAR = dCostoEnDolar * desRow.CANTIDADSURTIDA;


                        this.dSImportaciones.RECIBIR.Rows.InsertAt(desRow, eRowIndex + 1);
                        iMP_REC_DETDataGridView.Refresh();




                        m_rellenarsurtida = true;

                    }
                }
                decimal currentRecibidas = updateRecibidas(movtoRefId, iMP_REC_DETDataGridView.Rows[eRowIndex]);
                iMP_REC_DETDataGridView.Rows[eRowIndex].Cells["RECIBIDAS"].Value = currentRecibidas;

                m_rellenarsurtida = false;
                this.dSImportaciones.RECIBIR.AcceptChanges();
                iMP_REC_DETDataGridView.Refresh();
                m_rellenarsurtida = true;
            }


            if (CBMostrarUSD.Checked)
            {
                GetTotalesPagosUSD();
                RefreshTotalesTransaccionUSD();
            }

        }


        private void iMP_REC_DETDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            string headerText = iMP_REC_DETDataGridView.Columns[e.ColumnIndex].HeaderText;


            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("SURTIDA") && iMP_REC_DETDataGridView.Columns["DGCOSTOENDOLAR"].Index != e.ColumnIndex) return;

            despuesDeValidar(e.RowIndex);
          
        }








        private CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private void ImprimirTicket(long doctoId)
        {


            CTICKET_DETAILD detailD = new CTICKET_DETAILD();
            CTICKET_FOOTERD footerD = new CTICKET_FOOTERD();
            CTICKET_HEADERD headerD = new CTICKET_HEADERD();


            CTICKET_FOOTERBE footerBE = new CTICKET_FOOTERBE();
            CTICKET_HEADERBE headerBE = new CTICKET_HEADERBE();
            CTICKET_DETAILBE[] ListaDetalles = detailD.seleccionarTICKET_DETAIL(doctoId, false,null);

            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            
            int iXLetraRenglon = 0;
            string cantidadConLetra;

            footerBE.IDOCTOID = doctoId;
            headerBE.IDOCTOID = doctoId; 

            headerBE = headerD.seleccionarTICKET_HEADER(headerBE, null);
            footerBE = footerD.seleccionarTICKET_FOOTER(footerBE, false, null);


            cantidadConLetra = Numalet.ToCardinal(footerBE.ITOTAL).ToUpper();

            Ticket ticket = new Ticket();



            //si es una cancelacion
            if (headerBE.IESTATUSDOCTOID == DBValues._DOCTO_ESTATUS_CANCELADA)
                ticket.AddHeaderLine("CANCELACION");


            //header deacuerdo al tipo
            switch (headerBE.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_TRASPASO_REC:
                    {
                        sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                        ticket.AddHeaderLine("RECEPCION TRASLADO");
                    }
                    break;
                case DBValues._DOCTO_TIPO_COMPRA:
                    {
                        ticket.AddHeaderLine("RECEPCION COMPRA");
                    }
                    break;

                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                    {

                        sucursalBE = DatosSucursal(headerBE.ISUCURSALTID);
                        ticket.AddHeaderLine("TRASLADO");
                    }
                    break;
                default:
                    break;

            }


            ticket.AddHeaderLine("      " + headerBE.INOMBRE);
            ticket.AddHeaderLine(headerBE.IDOMICICIO);
            ticket.AddHeaderLine(headerBE.ICIUDAD.Trim() + " , " + headerBE.IESTADO.Trim());
            ticket.AddHeaderLine("RFC: " + headerBE.IRFC);
            ticket.AddHeaderLine(new string('-', Ticket.maxChar));

            //
            switch (headerBE.ITIPODOCTOID)
            {
                case DBValues._DOCTO_TIPO_TRASPASO_REC:
                    {
                        ticket.AddHeaderLine("TRASLADO DE SUCURSAL : " + sucursalBE.ICLAVE);
                        ticket.AddHeaderLine("SUCURSAL FUENTE: " + sucursalBE.INOMBRE);
                    } 
                    break;

                case DBValues._DOCTO_TIPO_TRASPASO_ENVIO:
                    {
                        ticket.AddHeaderLine("TRASLADO A SUCURSAL : " + sucursalBE.ICLAVE);
                        ticket.AddHeaderLine("SUCURSAL DESTINO: " + sucursalBE.INOMBRE);
                    }
                    break;

                case DBValues._DOCTO_TIPO_VENTA:
                    {
                        ticket.AddHeaderLine("CLIENTE:  0000");
                        ticket.AddHeaderLine("CLIENTE DE MOSTRADOR");
                    }
                    break;

                default:
                    break;

            }

            ticket.AddHeaderLine("Vendedor: " + iPos.CurrentUserID.CurrentUser.INOMBRE);
            ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Ticket " + headerBE.ITICKET);
            ticket.AddHeaderLine(new string('=', Ticket.maxChar));

            ticket.AddHeaderLine("DESCRIPCION               ");
            ticket.AddHeaderLine("CANTIDAD    PRECIO    %IVA      IMPORTE");

            ticket.AddHeaderLine(new string('-', Ticket.maxChar));
            foreach (CTICKET_DETAILBE detailItem in ListaDetalles)
            {
                ticket.AddItem(detailItem.ICANTIDAD.ToString(), detailItem.IDESCRIPCION1, detailItem.IPRECIO.ToString("N2"), detailItem.ISUBTOTAL.ToString("N2"), detailItem.IIVA.ToString(),
                              detailItem.ILOTE,
                              ((bool)detailItem.isnull["IFECHAVENCE"]) ? "" :
                               detailItem.IFECHAVENCE.ToString("dd/MM/yy"), "",
                                  ((bool)detailItem.isnull["ITIPORECARGA"]) ? "" : detailItem.ITIPORECARGA, 
                                  ((int)tipoImpresionItem.i_doslineas).ToString("N0"),
                                  "");
            }
            //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio 
            ticket.AddTotal("Sub-Total:", footerBE.ISUBTOTAL.ToString("N2"));
            ticket.AddTotal("Iva:", footerBE.IIVA.ToString("N2"));
            ticket.AddTotal("Descuento Total:", footerBE.IDESCUENTO_TOTAL.ToString("N2"));
            ticket.AddTotal("Total Compra:", footerBE.ITOTAL.ToString("N2"));
            ticket.AddTotal("Importe Recibido:", (footerBE.ITOTAL + footerBE.ICAMBIO).ToString("N2"));
            ticket.AddTotal("Cambio:", footerBE.ICAMBIO.ToString("N2")); //Ponemos un total en blanco que sirve de espacio 
            ticket.AddTotal("", "");
            ticket.AddTotal("", "");


            ticket.AddFooterLine(new string('-', Ticket.maxChar));

            ticket.AddFooterLine(cantidadConLetra.Substring((Ticket.maxChar * iXLetraRenglon)));

            ticket.AddFooterLine(footerBE.ICAJA /*+ " Turno: " + footerBE.ITURNO*/);
            ticket.AddFooterLine(new string('-', Ticket.maxChar));
            //ticket.AddFooterLine("Gracias por su compra");

            ticket.PrintTicketDirect(Ticket.GetReceiptPrinter());


        }



        private void FormatearCamposPersonalizados()
        {
            try
            {


                if (CurrentUserID.CurrentParameters.ICAMPOSCUSTOMALIMPORTAR.Equals("S"))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void iMP_REC_DETDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.iMP_REC_DETDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "Cambiar Lote")
                {
                    if (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                    {

                        WFDefineLote pl_ = new WFDefineLote();
                        pl_.m_descripcionProducto = iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_DESCRIPCION"].Value.ToString();
                        pl_.ShowDialog();
                        string lote_ = pl_.m_lote;
                        DateTime fechaVence_ = pl_.m_fechaVence;
                        pl_.Dispose();
                        GC.SuppressFinalize(pl_);

                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_LOTE"].Value = lote_;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["FECHAVENCE"].Value = fechaVence_;
                    }

                }
                /*else if (this.iMP_REC_DETDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "Otro Lote")
                {


                    if (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["MANEJALOTE"].Value.ToString().Equals("S"))
                    {


                        WFDefineLoteYCantidad pl = new WFDefineLoteYCantidad();
                        pl.ShowDialog();


                        m_rellenarsurtida = false;
                        this.dSImportaciones.RECIBIR.AcceptChanges();
                        Importaciones.DSImportaciones.RECIBIRRow desRow = this.dSImportaciones.RECIBIR.NewRECIBIRRow();
                        Importaciones.DSImportaciones.RECIBIRRow sourceRow = (Importaciones.DSImportaciones.RECIBIRRow)this.dSImportaciones.RECIBIR.Rows[e.RowIndex];
                        desRow.ItemArray = sourceRow.ItemArray.Clone() as object[];
                        
                        desRow.LOTE = pl.m_lote;
                        desRow.FECHAVENCE = pl.m_fechaVence;
                        desRow.CANTIDADSURTIDA = pl.m_cantidad;
                        desRow.CANTIDAD = 0;
                        desRow.MOVTOID = 0;


                        this.dSImportaciones.RECIBIR.Rows.InsertAt(desRow, e.RowIndex);
                         

                        iMP_REC_DETDataGridView.Refresh();

                        m_rellenarsurtida = true;

                        //rECIBIRBindingSource.ResetBindings(false);
                    }

                }*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private decimal getSumCantidadGrupo(long movtorefid, DataGridViewRow rowExcept)
        {
            decimal dSumCantidad = 0;
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
             {
                    
                 if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                 {
                        continue;
                 }
                 long current_movtoRefId = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());

                 if (current_movtoRefId == movtorefid && rowExcept != row)
                {

                    decimal cantidadSurtida = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    dSumCantidad += cantidadSurtida;
                }
            }

            return dSumCantidad;
        }




        private DataGridViewRow getNewDataGridRowGroup(long movtorefid, DataGridViewRow rowExcept)
        {
            DataGridViewRow dataRow = null;
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }
                long current_movtoRefId = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());
                string lote =  row.Cells["GC_LOTE"].Value.ToString();
                if (current_movtoRefId == movtorefid && rowExcept != row && lote.Trim().Length == 0)
                {

                    decimal cantidadSurtida = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                    dataRow = row;
                }
            }

            return dataRow;
        }


        private decimal updateRecibidas(long movtorefid, DataGridViewRow rowExcept)
        {
            decimal dRecibidasRow = 0;
            decimal dRecibidasCurrent = 0;
            
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }
                long current_movtoRefId = long.Parse(row.Cells["MOVTOREFID"].Value.ToString());
                decimal cantidadSurtida = Decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());
                if (current_movtoRefId == movtorefid)
                {
                    if (rowExcept == row)
                    {
                        dRecibidasRow = dRecibidasCurrent;
                    }
                    else
                    {
                        row.Cells["RECIBIDAS"].Value = dRecibidasCurrent;
                    }

                    dRecibidasCurrent += cantidadSurtida;
                }
            }

            return dRecibidasRow;
        }

        private void WFImportarOrdenesDet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_recepcionProcesada)
            {

                if (MessageBox.Show("Esto eliminara los cambios actuales . ¿Desea realmente cerrar el formulario? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Realmente desea finalizar esta venta a futuro? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            CDOCTOD doctoD = new CDOCTOD();
            if (!doctoD.VENTAFUTUROFINALIZAR(this.m_doctoId, null))
            {
                MessageBox.Show("Hubo un error al finalizar la vanta de futuro " +  doctoD.IComentario);
            }
            else
            {
                m_recepcionProcesada = true;
                this.Close();
            }
        }


        private CPERSONABE obtainCurrentProveedorPorId(long id)
        {
            CPERSONAD provD = new CPERSONAD();

            CPERSONABE proveedorBE = new CPERSONABE();
            proveedorBE.IID = id;
            proveedorBE = provD.seleccionarPERSONA(proveedorBE, null);

            return proveedorBE;
        }

        private bool ActualizarLoteImportadoEnDocto(CDOCTOBE docto, long loteImportado)
        {
            CDOCTOD doctoD = new CDOCTOD();
            docto.ILOTEIMPORTADO = loteImportado;
            return doctoD.CambiarLoteImportadoDOCTOD(docto, null);
        }

        private void btnGastosAdic_Click(object sender, EventArgs e)
        {
            AbrirGastosAdicionales();
        }


        private void AbrirGastosAdicionales()
        {

            WFReciboGastosAdicEdit wf = new WFReciboGastosAdicEdit(m_doctoId, "Cambiar");
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }



        private void borrarGastosAdicionales()
        {



            CMOVTOGASTOSADICD movtoGastosAdicD = new CMOVTOGASTOSADICD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (movtoGastosAdicD.GASTOSADIC_CANCEL(m_doctoId, fTrans))
                {
                    fTrans.Commit();
                    fConn.Close();
                    this.Close();
                    return;
                }
                else
                {

                    fTrans.Rollback();
                    fConn.Close();
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

        private void CBMostrarUSD_CheckedChanged(object sender, EventArgs e)
        {
            VisibilidadUSDInfo(CBMostrarUSD.Checked);


            if (CBMostrarUSD.Checked)
            {
                GetTotalesPagosUSD();
                RefreshTotalesTransaccionUSD();
            }
        }


        public void VisibilidadUSDInfo(bool bVisibilidad)
        {

            this.TBUSDTotal.Visible = bVisibilidad;
            lblEtiquetaTotalUSD.Visible = bVisibilidad;


            iMP_REC_DETDataGridView.Columns["DGCOSTOENDOLAR"].Visible = bVisibilidad;
            iMP_REC_DETDataGridView.Columns["DGIMPORTEENDOLAR"].Visible = bVisibilidad;


        }


        public void GetTotalesPagosUSD()
        {
            try
            {
                m_dMontoTransaccionUSD = 0;


                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {

                    if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }

                    decimal current_costo = 0, current_cantidad = 0, current_tasaiva = 0, current_tasaieps = 0;

                    current_costo = decimal.Parse(row.Cells["DGCOSTOENDOLAR"].Value.ToString());
                    current_cantidad = decimal.Parse(row.Cells["GC_SURTIDA"].Value.ToString());

                    m_dMontoTransaccionUSD += current_costo * current_cantidad;
                   
                    
                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRORES: " + ex.Message);
                LimpiarTotalesPagosTransaccionUSD();
            }

        }


        public void RefreshTotalesTransaccionUSD()
        {
            this.TBUSDTotal.Text = m_dMontoTransaccionUSD.ToString("N3");
        }


        public void LimpiarTotalesPagosTransaccionUSD()
        {
            m_dMontoTransaccionUSD = 0;
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            int eRowIndex = 0;
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {

                if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                {
                    continue;
                }

                decimal cantidadARecibir = Decimal.Parse(row.Cells["GC_CANTIDAD"].Value.ToString());

                row.Cells["GC_SURTIDA"].Value = cantidadARecibir;
                despuesDeValidar(eRowIndex);

                eRowIndex++;



            }
        }



    }
}
