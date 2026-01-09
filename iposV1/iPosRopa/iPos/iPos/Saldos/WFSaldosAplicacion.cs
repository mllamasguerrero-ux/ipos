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
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;

namespace iPos
{
    public partial class WFSaldosAplicacion : IposForm
    {
        CDOCTOBE m_Docto;
        long m_ClienteId;
        tipoTransaccionV m_tipoTransaccion;
        decimal m_montoAAplicar = 0;

        public WFSaldosAplicacion()
        {
            InitializeComponent();
            m_Docto = new CDOCTOBE();
            m_tipoTransaccion = tipoTransaccionV.t_devolucion;
        }


        public WFSaldosAplicacion(tipoTransaccionV tipoTransaccion) :this()
        {
            m_tipoTransaccion = tipoTransaccion;
        }


        public void llenarDatosCliente()
        {
            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = m_ClienteId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);
            if (clienteBE != null)
            {

                lbClieCiudad.Text = ((bool)clienteBE.isnull["ICIUDAD"]) ? "" : clienteBE.ICIUDAD;
                lbClieColonia.Text = ((bool)clienteBE.isnull["ICOLONIA"]) ? "" : clienteBE.ICOLONIA;
                lbClieCP.Text = ((bool)clienteBE.isnull["ICODIGOPOSTAL"]) ? "" : clienteBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)clienteBE.isnull["IDOMICILIO"]) ? "" : clienteBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)clienteBE.isnull["IESTADO"]) ? "" : clienteBE.IESTADO;
                lbClieNombre.Text = ((bool)clienteBE.isnull["INOMBRE"]) ? "" : clienteBE.INOMBRE;
                lbClieRFC.Text = ((bool)clienteBE.isnull["IRFC"]) ? "" : clienteBE.IRFC;
                lbClieTel.Text = ((bool)clienteBE.isnull["ITELEFONO1"]) ? "" : clienteBE.ITELEFONO1;

                LBCliente.Text = clienteBE.ICLAVE;

            }
            else
            {

                lbClieCiudad.Text = "";
                lbClieColonia.Text = "";
                lbClieCP.Text = "";
                lbClieDom.Text = "";
                lbClieEstado.Text = "";
                lbClieNombre.Text = "";
                lbClieRFC.Text = "";
                lbClieTel.Text = "";
            }

        }



        public void llenarDatosTransaccion()
        {
            if (!(bool)m_Docto.isnull["IID"])
            {
                if (!(bool)m_Docto.isnull["IFOLIO"])
                {
                    this.lblFolio.Text = m_Docto.IFOLIO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFECHA"])
                {
                    this.lblFecha.Text = m_Docto.IFECHA.ToString("dd/MM/yyyy");
                }
                if (!(bool)m_Docto.isnull["ITOTAL"])
                {
                    this.lblTotal.Text = m_Docto.ITOTAL.ToString("SALDO");
                }
                if (!(bool)m_Docto.isnull["ISALDO"])
                {
                    this.lblSaldo.Text = (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES  || (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_tipoTransaccion == tipoTransaccionV.t_devolucion)) ? (m_Docto.ISALDO * -1).ToString() : m_Docto.ISALDO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFOLIOORIGENFACTURADO"])
                {
                    this.lblFolioFacturado.Text = m_Docto.IFOLIOORIGENFACTURADO.ToString();
                }

            }
        }

        private void btnListaTransaccione_Click(object sender, EventArgs e)
        {

            int tipoTransaccionAListar = 0;

            switch(this.m_tipoTransaccion)
            {
                case tipoTransaccionV.t_compradevolucion:
                    tipoTransaccionAListar = (int)DBValues._DOCTO_TIPO_COMPRA_DEVO;
                    break;
                case tipoTransaccionV.t_compraDevoSucursal:
                    tipoTransaccionAListar = (int)DBValues._DOCTO_TIPO_COMPRA_DEVO_SUC;
                    break;
                default: tipoTransaccionAListar = (int)DBValues._DOCTO_TIPO_DEVOLUCIONCOMONOTACREDITO; break;
            }

            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoTransaccionAListar);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                Limpiar();

                m_Docto = new CDOCTOBE();
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
                m_ClienteId = m_Docto.IPERSONAID;
                llenarDatosCliente();
                llenarDatosTransaccion();
                LlenarGrid();
                this.BTGuardar.Enabled = true;

            }
        }


        private void LlenarGrid()
        {
            try
            {
                this.gET_CREDITO_LISTA_A_APLICARTableAdapter.Fill(this.dSPuntoDeVentaAux.GET_CREDITO_LISTA_A_APLICAR, m_Docto.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void gET_CREDITO_LISTA_A_APLICARDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void gET_CREDITO_LISTA_A_APLICARDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            string columnName = gET_CREDITO_LISTA_A_APLICARDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGSALDOAAPLICAR")) return;


            try
            {
                decimal dSaldoAAplicar = decimal.Parse(e.FormattedValue.ToString());
                decimal dSaldo = decimal.Parse(gET_CREDITO_LISTA_A_APLICARDataGridView.Rows[e.RowIndex].Cells["DGSALDO"].Value.ToString());


                if (dSaldoAAplicar > dSaldo || dSaldoAAplicar < 0)
                {
                    MessageBox.Show("El saldo a aplicar no puede ser mayor que el saldo de la transaccion ni menor que cero");
                    e.Cancel = true;
                }

                decimal saldoDocto = (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ANTICIPO_CLIENTES || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_ANTICIPO_PROVEEDORES || 
                                        (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && m_tipoTransaccion == tipoTransaccionV.t_devolucion)
                                            ) ? m_Docto.ISALDO * -1 : m_Docto.ISALDO;

                if ((m_montoAAplicar + dSaldoAAplicar) > saldoDocto)
                {

                    MessageBox.Show("se excederia el saldo posible a aplicar");
                    e.Cancel = true;
                }


            }
            catch
            {
            }
        }

        private void SumaAbonos()
        {
            m_montoAAplicar = 0;
            DataRow dr;
            foreach (DataGridViewRow row in gET_CREDITO_LISTA_A_APLICARDataGridView.Rows)
            {
                decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > 0)
                {
                    dr = (row.DataBoundItem as DataRowView).Row;
                    dr["SALDOAAPLICAR"] = dSaldoAAplicar;
                    m_montoAAplicar += dSaldoAAplicar;
                }
            }

            this.lblSumaAAplicar.Text = m_montoAAplicar.ToString("N2");
            
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            m_montoAAplicar = 0;
            DataRow dr;
            CDOCTOPAGOD pagoD = new CDOCTOPAGOD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

            foreach (DataGridViewRow row in gET_CREDITO_LISTA_A_APLICARDataGridView.Rows)
            {
                decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > 0)
                {

                    dr = (row.DataBoundItem as DataRowView).Row;
                    /*dr["SALDOAAPLICAR"] = dSaldoAAplicar;
                    m_montoAAplicar += dSaldoAAplicar;*/




                    CDOCTOPAGOBE pagoManual = new CDOCTOPAGOBE();



                    switch (this.m_tipoTransaccion)
                    {
                        case tipoTransaccionV.t_devolucion:
                            pagoManual.IDOCTOID = long.Parse(dr["DOCTOIDAPLICAR"].ToString());
                            pagoManual.ITIPOPAGOID = DBValues._TIPOPAGO_ENTRADA;
                            pagoManual.IFORMAPAGOID = DBValues._FORMA_PAGO_NOTACREDITO;
                            pagoManual.IDOCTOSALIDAID = m_Docto.IID;
                            pagoManual.IFECHA = DateTime.Today;
                            pagoManual.IFECHAHORA = DateTime.Now;
                            pagoManual.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;  
                            pagoManual.IIMPORTE = decimal.Parse(dr["SALDOAAPLICAR"].ToString());
                            pagoManual.IIMPORTECAMBIO = 0;
                            pagoManual.IIMPORTERECIBIDO = pagoManual.IIMPORTE;
                            pagoManual.IESAPARTADO = "N";
                            break;



                      

                        case tipoTransaccionV.t_compradevolucion:
                        case tipoTransaccionV.t_compraDevoSucursal:

                                pagoManual.IDOCTOID = m_Docto.IID;
                            pagoManual.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;
                            pagoManual.IFORMAPAGOID = DBValues._FORMA_PAGO_NOTADEBITO;
                            pagoManual.IDOCTOSALIDAID = long.Parse(dr["DOCTOIDAPLICAR"].ToString());
                            pagoManual.IFECHA = DateTime.Today;
                            pagoManual.IFECHAHORA = DateTime.Now;
                            pagoManual.ICORTEID = CurrentUserID.CurrentUser.ICORTEID; 
                            pagoManual.IIMPORTE = decimal.Parse(dr["SALDOAAPLICAR"].ToString());
                            pagoManual.IIMPORTECAMBIO = 0;
                            pagoManual.IIMPORTERECIBIDO = pagoManual.IIMPORTE;
                            pagoManual.IESAPARTADO = "N";
                            break;




                       


                    }

                    pagoManual.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;
                    pagoManual.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;

                    if (pagoD.InsertarDOCTOPAGOD(pagoManual, fTrans) == null)
                    {

                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }


                    if (!pagoD.AjustarSaldosPersona(m_Docto.IPERSONAID, fTrans))
                    {

                        fTrans.Rollback();
                        MessageBox.Show(pagoD.IComentario);
                        throw new Exception();
                    }


                }

            }


            fTrans.Commit();
            fConn.Close();
            Limpiar();
            }
            catch
            {

            }
            finally
            {
                fConn.Close();
            }
        }

        private void gET_CREDITO_LISTA_A_APLICARDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            SumaAbonos();
        }


        private void Limpiar()
        {
            this.dSPuntoDeVentaAux.GET_CREDITO_LISTA_A_APLICAR.Clear();
            m_Docto = new CDOCTOBE();
            m_montoAAplicar = 0;
            this.lblSumaAAplicar.Text = "0.00";


            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";

            this.lblFolio.Text = "";
            this.lblFecha.Text = "";
            this.lblTotal.Text = "";
            this.lblSaldo.Text = "";
            this.lblFolioFacturado.Text = "";

        }

        private void WFSaldosAplicacion_Load(object sender, EventArgs e)
        {

            switch (m_tipoTransaccion)
            {
                case tipoTransaccionV.t_compradevolucion:
                    {
                        lblTitulo.Text = "Saldos compras";
                        lblPersona.Text = "Proveedor";
                    }
                    break;

                case tipoTransaccionV.t_compraDevoSucursal:
                    {
                        lblTitulo.Text = "Saldos compras sucursales";
                        lblPersona.Text = "Proveedor";
                    }
                    break;
                default:
                    lblTitulo.Text = "Saldos ventas";
                    lblPersona.Text = "Cliente";
                    break;

            }
        }


    }
}
