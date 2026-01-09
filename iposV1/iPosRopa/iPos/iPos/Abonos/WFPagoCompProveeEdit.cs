using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;
using iPosReporting;
using iPos.Abonos;

namespace iPos
{
    public partial class WFPagoCompProveeEdit : Form
    {
        private decimal m_montoTotal = 0.0m;
        private decimal m_montoAAplicar = 0.0m;

        private long m_proveedorId = 0;
        private long folioPago = 0;
        public bool m_bPorSucursal = true;

        public WFPagoCompProveeEdit()
        {
            InitializeComponent();
            m_bPorSucursal = true;
        }

        public WFPagoCompProveeEdit(bool bPorSucursal):this()
        {
            m_bPorSucursal = bPorSucursal;
        }

        public WFPagoCompProveeEdit(long folioPago, bool bPorSucursal) : this(bPorSucursal)
        {
            this.folioPago = folioPago;
        }


        private void configurarPorSucursal()
        {
            this.pnlSeleccionarEmpresa.Visible = m_bPorSucursal;
            this.pnlEdicionDetalle.Visible = m_bPorSucursal;
        }

        public void llenarDatosPersona(long proveedorId)
        {
            m_proveedorId = proveedorId;



            //LlenarGridSaldos();

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = personaD.SeleccionarPersonaPorId(proveedorId, null);

            if (personaBE != null)
                llenarDatosPersona(personaBE);
            else
                limpiarDatosPersona();

        }


        public void llenarDatosPersona(CPERSONABE personaBE)
        {
            limpiarDatosPersona();

            if (personaBE != null)
            {

                lbClieCiudad.Text = ((bool)personaBE.isnull["ICIUDAD"]) ? "" : personaBE.ICIUDAD;
                lbClieColonia.Text = ((bool)personaBE.isnull["ICOLONIA"]) ? "" : personaBE.ICOLONIA;
                lbClieCP.Text = ((bool)personaBE.isnull["ICODIGOPOSTAL"]) ? "" : personaBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)personaBE.isnull["IDOMICILIO"]) ? "" : personaBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)personaBE.isnull["IESTADO"]) ? "" : personaBE.IESTADO;
                lbClieNombre.Text = ((bool)personaBE.isnull["INOMBRE"]) ? "" : personaBE.INOMBRE;
                lbClieRFC.Text = ((bool)personaBE.isnull["IRFC"]) ? "" : personaBE.IRFC;
                lbClieTel.Text = ((bool)personaBE.isnull["ITELEFONO1"]) ? "" : personaBE.ITELEFONO1;

                //LBCliente.Text = personaBE.ICLAVE;

                if (folioPago == 0)
                {

                    TBCuentaPago.Text = ((bool)personaBE.isnull["ICREDITOREFERENCIAABONOS"]) ? "" : personaBE.ICREDITOREFERENCIAABONOS;
                }

            }

        }



        public void limpiarDatosPersona()
        {

            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";

            //LBCliente.Text = "";
        }

        private void WFPagoCompProveeEdit_Load(object sender, EventArgs e)
        {

            if (!ChecarCorteActivo())
                return;


            this.ComboBanco.llenarDatos();
            this.ComboBanco.SelectedIndex = -1;


            HabilitarPagoEdicion();


            if (folioPago > 0)
            {
                tabControl1.TabPages.Remove(tabPage1);
                LlenarDatosDeBase();
                DeshabilitarCamposCreacion();
            }
            else
            {
                TBIdPago.Visible = false;
                label7.Visible = false;
                tabControl1.TabPages.Remove(tabPage2);
            }

            configurarPorSucursal();

        }


        private void HabilitarAdicionDeDetalles()
        {
            if (folioPago > 0)
                return;

            bool bEdicionDetalle = true;
            decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());

            if (ITEMIDTextBox.Text.Trim().Length <= 0 || 
                this.FormaPagoComboBox.SelectedIndex == -1 || 
                GRUPOSUCURSALIDTextBox.Text.Trim().Length <= 0 ||
                monto <= 0)
            {
                bEdicionDetalle = false;
            }
            

            pnlEdicionDetalle.Enabled = bEdicionDetalle;

        }

        private bool ChecarCorteActivo()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if (!pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
            {
                MessageBox.Show("Necesita abrir un corte");
                this.Close();
                return false;
            }
            else
            {
                TimeSpan ts = DateTime.Now - fechaCorte/*((fechaCorte == null) ? DateTime.MinValue : fechaCorte)*/;
                if (fechaCorte != null && fechaCorte < DateTime.Today && ts.Hours > 6)
                {

                    MessageBox.Show("Se tiene abierto un corte de una fecha pasada porfavor cierrelo antes de continuar");
                    this.Close();
                    return false;
                }
                else
                    return true;
            }

            //return true;

        }

        private void HabilitarPagoEdicion()
        {
            this.PA_ABONOTextBox.Text = "0";
            this.FormaPagoComboBox.SelectedIndex = -1;
            this.ComboBanco.SelectedIndex = -1;
            this.TBReferencia.Text = "";
            this.TBCuentaPago.Text = "";
            this.TBNotas.Text = "";
            this.DTPFechaElaboracion.Value = DateTime.Now;
            this.DTPFechaRecepcion.Value = DateTime.Now;

            this.pnlAbono.Enabled = true;
            this.pnlBancario.Enabled = false;
            this.BTGuardar.Enabled = true;

            this.BTRecibo.Enabled = false;

            DGQUITAR.Visible = true;
        }


        private void DeshabilitarCamposCreacion()
        {
            TBIdPago.Enabled = false;
            ITEMIDTextBox.Enabled = false;
            ITEMButton.Enabled = false;
            FormaPagoComboBox.Enabled = false;
            TBNotas.Enabled = false;
            TBReferencia.Enabled = false;
            ComboBanco.Enabled = false;
            TBCuentaPago.Enabled = false;
            PA_ABONOTextBox.Enabled = false;
            DTPFechaElaboracion.Enabled = false;
            DTPFechaRecepcion.Enabled = false;
            BTGuardar.Enabled = false;


            DGQUITAR.Visible = false;
        }


        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionaProveedor();
        }


        private void SeleccionaProveedor()
        {
            iPos.Catalogos.WFProveedores look = new iPos.Catalogos.WFProveedores();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.ITEMIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                llenarDatosPersona((long)dr["ID"]);

                if (!this.m_bPorSucursal)
                {
                    LlenarGridComprasProveedorGeneral();
                }
            }

        }



        private void BTSeleccionar_Click(object sender, EventArgs e)
        {

            if (ITEMIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Primero seleccione un proveedor");
                this.TBFolio.Text = "";
                this.TBFolio.Focus();
                return;
            }

            long proveeId = long.Parse(ITEMIDTextBox.DbValue.ToString());
            


            long sucursalDestinoId = 0;
            if (this.SUCURSALIDTextBox.Text != "")
            {
                sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }


            WFLookUpCompraSucursales wfl = new WFLookUpCompraSucursales(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_COMPRA_SUC, proveeId,false, sucursalDestinoId, true);
            wfl.ShowDialog();

            DataRow dr = wfl.m_rtnDataRow;

            wfl.Dispose();
            GC.SuppressFinalize(wfl);

            if (dr != null)
            {
                this.TBFolio.Text = dr[15].ToString();
                this.TBFolio.Focus();
            }

        }

        private iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow obtenerFilaSucursalSaldo(int folio, long sucursalDestinoId)
        {

            cOMPRASSUCSALDOTableAdapter.Fill(dsAbonosAux.COMPRASSUCSALDO, folio, (int)sucursalDestinoId, 1011, "N",0);

            if (dsAbonosAux.COMPRASSUCSALDO != null && dsAbonosAux.COMPRASSUCSALDO.Rows.Count > 0)
            {


                iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow dr = (iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow)dsAbonosAux.COMPRASSUCSALDO.Rows[0];
                return dr;
            }
            return null;
        }

        private void LlenarGridComprasProveedorGeneral()
        {
            try
            {
                dsAbonosAux.COMPRASSUCSALDO.Clear();

                if (ITEMIDTextBox.DbValue == null || ITEMIDTextBox.DbValue.ToString().Length == 0)
                {
                    MessageBox.Show("Seleccione un proveedor");
                }

                long proveeId = long.Parse(ITEMIDTextBox.DbValue.ToString());

                cOMPRASSUCSALDOTableAdapter.Fill(dSAbonos2.COMPRASSUCSALDO, 0, 0, DBValues._DOCTO_TIPO_COMPRA, "S", proveeId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void llenarDatosCompra()
        {

            LBTotalCompra.Text = "";
            LBSaldoCompra.Text = "";

            long sucursalDestinoId = 0;
            if (this.SUCURSALIDTextBox.Text != "")
            {
                sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }



            int folio = 0;
            if (TBFolio.Text.Length > 0)
            {
                try
                {
                    folio = int.Parse(TBFolio.Text);
                }
                catch
                {

                }
            }

            if (sucursalDestinoId == 0 || folio == 0)
                return;

            iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow dr = obtenerFilaSucursalSaldo(folio, sucursalDestinoId);



            if (dr != null)
            {

                if (ITEMIDTextBox.Text.Trim().Length <= 0)
                {
                    long proveeId = long.Parse(ITEMIDTextBox.DbValue.ToString());
                    if (dr.PROVEEDORID > 0 && dr.PROVEEDORID != proveeId)
                    {

                        MessageBox.Show("La compra no es del proveedor seleccionado");
                        this.TBFolio.Focus();
                        return;
                    }
                }


                LBTotalCompra.Text = dr.TOTAL.ToString("N2");
                LBSaldoCompra.Text = dr.SALDO.ToString("N2");
            }
            else
            {
                MessageBox.Show("El folio no existe en la sucursal");
                this.TBFolio.Focus();
            }

        }




        private void btnAgregarAplicacion_Click(object sender, EventArgs e)
        {


            string mensaje = "";


            if (ITEMIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Primero seleccione un proveedor");
                return;
            }

            if (GRUPOSUCURSALIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Primero seleccione un grupo de sucursal");
                return;
            }




            long sucursalDestinoId = 0;
            if (this.SUCURSALIDTextBox.Text != "")
            {
                if (!ValidarSucursal(ref mensaje))
                {
                    MessageBox.Show(mensaje);
                    SUCURSALIDTextBox.Text = "";
                    SUCURSALIDTextBox.Focus();
                    return;
                }

                sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }





            int folio = 0;
            if (TBFolio.Text.Length > 0)
            {
                try
                {
                    folio = int.Parse(TBFolio.Text);
                }
                catch
                {

                }
            }
            decimal monto = 0;

            if (montoAplicarAdd.Text.Length > 0)
            {

                try
                {
                    monto = decimal.Parse(montoAplicarAdd.NumericValue.ToString());
                }
                catch
                {

                }
            }


            //cOMPRASSUCSALDOTableAdapter.Fill(dsAbonosAux.COMPRASSUCSALDO, folio, (int)sucursalDestinoId);
            iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow dr = obtenerFilaSucursalSaldo(folio, sucursalDestinoId);

            if (dr != null)
            {


                if (ITEMIDTextBox.Text.Trim().Length <= 0)
                {
                    long proveeId = long.Parse(ITEMIDTextBox.DbValue.ToString());
                    if (dr.PROVEEDORID > 0 && dr.PROVEEDORID != proveeId)
                    {

                        MessageBox.Show("La compra no es del proveedor seleccionado");
                        return;
                    }
                }

                if (monto > dr.SALDO)
                {
                    MessageBox.Show("El monto no puede ser mayor al saldo de la compra");
                    return;

                }

                IEnumerable<iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow> drExistente = dSAbonos2.COMPRASSUCSALDO.AsEnumerable().Where(r => ((int)r["FOLIO"]) == dr.FOLIO && ((long)r["SUCURSALID"]) == dr.SUCURSALID);

                if (drExistente != null && drExistente.Count() > 0)
                {
                    MessageBox.Show("El registro ya se agrego, modifique el monto en el grid si lo desea");
                    return;
                }


                iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow drNew = (iPos.Abonos.DSAbonos2.COMPRASSUCSALDORow)dSAbonos2.COMPRASSUCSALDO.NewRow();

                drNew.SUCURSALID = dr.SUCURSALID;
                drNew.SUCURSALCLAVE = dr.SUCURSALCLAVE;
                drNew.SUCURSALNOMBRE = dr.SUCURSALNOMBRE;
                drNew.FOLIO = dr.FOLIO;
                drNew.FECHA = dr.FECHA;
                drNew.FACTURA = dr.FACTURA;
                drNew.FECHAFACTURA = dr.FECHAFACTURA;
                drNew.TOTAL = dr.TOTAL;
                drNew.SALDO = dr.SALDO;
                drNew.ABONO = dr.ABONO;
                drNew.MONTOAPLICAR = monto;
                drNew.ORIGENFISCALID = dr.ORIGENFISCALID;
                drNew.ORIGENFISCALNOMBRE = dr.ORIGENFISCALNOMBRE;
                drNew.DOCTOID = dr.DOCTOID;


                dSAbonos2.COMPRASSUCSALDO.Rows.Add(drNew);

            }

            mostrarSaldoAbonos();

        }

        private void ITEMIDTextBox_Validated(object sender, EventArgs e)
        {

            try
            {
                long clienteId = Int64.Parse(this.ITEMIDTextBox.DbValue.ToString());
                llenarDatosPersona(clienteId);

                if (!this.m_bPorSucursal)
                {
                    if (ITEMIDTextBox.DbValue == null || ITEMIDTextBox.DbValue.ToString().Length == 0)
                        return;

                    LlenarGridComprasProveedorGeneral();
                }


            }
            catch
            {

                return;
            }
            finally
            {

                HabilitarAdicionDeDetalles();
            }
        }

        private void FormaPagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (FormaPagoComboBox.SelectedIndex > 0)
            {
                this.pnlBancario.Enabled = true;

            }
            else
            {
                pnlBancario.Enabled = false;
                this.ComboBanco.SelectedIndex = -1;
                this.TBReferencia.Text = "";

            }

            if (FormaPagoComboBox.SelectedIndex == 4)
            {
                this.CBAplicado.Checked = false;
                this.CBAplicado.Enabled = true;

            }
            else
            {
                this.CBAplicado.Checked = true;
                this.CBAplicado.Enabled = false;
            }


            if (FormaPagoComboBox.Text == "Cheque nominativo")
            {
                DTPFechaAplicado.Enabled = true;
                CBAplicado.Enabled = true;
            }
            else
            {
                DTPFechaAplicado.Enabled = false;
                CBAplicado.Enabled = false;
                CBAplicado.Checked = true;
                DTPFechaAplicado.Value = DTPFechaRecepcion.Value;
            }

            HabilitarAdicionDeDetalles();

            //CalcularMontosXCaptura();
        }


        private void CalcularMontosXCaptura()
        {
            m_montoTotal = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
        }

        private void PA_ABONOTextBox_Validated(object sender, EventArgs e)
        {
            this.CalcularMontosXCaptura();
            mostrarSaldoAbonos();
            HabilitarAdicionDeDetalles();

        }



        private int ObtenerFormaPagoIndex(long formaPagoId, long formaPagoSatId)
        {

            if (formaPagoId == DBValues._FORMA_PAGO_EFECTIVO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 0;
            else if (formaPagoId == DBValues._FORMA_PAGO_TARJETA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TARJETACREDITO)
                return 1;
            else if (formaPagoId == DBValues._FORMA_PAGO_TARJETA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TARJETADEBITO)
                return 2;
            else if (formaPagoId == DBValues._FORMA_PAGO_TARJETA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TARJETASERVICIO)
                return 3;
            else if (formaPagoId == DBValues._FORMA_PAGO_CHEQUE && formaPagoSatId == DBValues._FORMA_PAGOSAT_CHEQUE)
                return 4;
            else if (formaPagoId == DBValues._FORMA_PAGO_VALE && formaPagoSatId == DBValues._FORMA_PAGOSAT_VALE)
                return 5;
            else if (formaPagoId == DBValues._FORMA_PAGO_TRANSFERENCIA && formaPagoSatId == DBValues._FORMA_PAGOSAT_TRANSFERENCIA)
                return 6;
            else if (formaPagoId == DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO && (formaPagoSatId == DBValues._FORMA_PAGOSAT_COMPENSACION || formaPagoSatId == DBValues._FORMA_PAGOSAT_OTRO))
                return 7;
            else if (formaPagoId == DBValues._FORMA_PAGO_NOIDENTIFICADO && formaPagoSatId == DBValues._FORMA_PAGOSAT_OTRO)
                return 8;
            else if (formaPagoId == DBValues._FORMA_PAGO_DEPOSITO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 9;
            else if (formaPagoId == DBValues._FORMA_PAGO_DEPOSITOTERCERO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 10;
            else if (formaPagoId == DBValues._FORMA_PAGO_EFECTIVO && formaPagoSatId == DBValues._FORMA_PAGOSAT_EFECTIVO)
                return 11;

            else return -1;
        }

        private void FijarFormaPago(ref CPAGOBE pagoBE)
        {
            switch (FormaPagoComboBox.SelectedIndex)
            {

                case 0:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
                case 1:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETACREDITO;
                    break;
                case 2:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETADEBITO;
                    break;
                case 3:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TARJETA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TARJETASERVICIO;
                    break;
                case 4:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_CHEQUE;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_CHEQUE;
                    break;
                case 5:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_VALE;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_VALE;
                    break;
                case 6:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_TRANSFERENCIA;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_TRANSFERENCIA;
                    break;
                case 7:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_COMPENSACION;
                    break;
                case 8:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_NOIDENTIFICADO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_OTRO;
                    break;
                case 9:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_DEPOSITO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
                case 10:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_DEPOSITOTERCERO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
                default:
                    pagoBE.IFORMAPAGOID = DBValues._FORMA_PAGO_EFECTIVO;
                    pagoBE.IFORMAPAGOSATID = DBValues._FORMA_PAGOSAT_EFECTIVO;
                    break;
            }
        }


        public void imprimirRecibo(long pagoId)
        {
            string strReporte = "";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("itemid", pagoId);

            strReporte = "ReciboPagoProveedorMultiple.frx";



            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }



        private decimal SumaAbonos()
        {
            m_montoAAplicar = 0;
            DataRow dr;
            foreach (DataGridViewRow row in cOMPRASSUCSALDODataGridView.Rows)
            {
                decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > 0)
                {
                    dr = (row.DataBoundItem as DataRowView).Row;
                    dr["MONTOAPLICAR"] = dSaldoAAplicar;
                    m_montoAAplicar += dSaldoAAplicar;
                }
            }

            return m_montoAAplicar;
        }

        private decimal ObtenerSaldo()
        {
            return decimal.Parse(PA_ABONOTextBox.Text) - SumaAbonos();
        }

        private void cOMPRASSUCSALDODataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            mostrarSaldoAbonos();
        }


        private void mostrarSaldoAbonos()
        {

            decimal sumaAbonos = SumaAbonos();
            decimal saldo = decimal.Parse(PA_ABONOTextBox.Text);
            this.lblSumaAAplicar.Text = sumaAbonos.ToString("N2");
            lblSaldo.Text = (saldo - sumaAbonos).ToString("N2");
        }

        private void cOMPRASSUCSALDODataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            string columnName = cOMPRASSUCSALDODataGridView.Columns[e.ColumnIndex].Name;


            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGSALDOAAPLICAR")) return;


            try
            {
                decimal dSaldoAAplicar = decimal.Parse(e.FormattedValue.ToString());
                decimal dSaldo = decimal.Parse(cOMPRASSUCSALDODataGridView.Rows[e.RowIndex].Cells["DGSALDO"].Value.ToString());
                decimal dOldValue = decimal.Parse(cOMPRASSUCSALDODataGridView.Rows[e.RowIndex].Cells["DGSALDOAAPLICAR"].Value.ToString());

                if (dSaldoAAplicar > dSaldo || dSaldoAAplicar < 0)
                {
                    MessageBox.Show("El saldo a aplicar no puede ser mayor que el saldo de la transaccion ni menor que cero");
                    e.Cancel = true;
                }



                if ((m_montoAAplicar - dOldValue + dSaldoAAplicar) > m_montoTotal)
                {

                    MessageBox.Show("se excederia el saldo posible a aplicar");
                    e.Cancel = true;
                }


            }
            catch
            {
            }
        }

        private void cOMPRASSUCSALDODataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;
        }

        private void TBFolio_Validated(object sender, EventArgs e)
        {

            if (this.TBFolio.Text.Trim() != "")
            {

                if (ITEMIDTextBox.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Primero seleccione un proveedor");
                    this.TBFolio.Text = "";
                    this.TBFolio.Focus();
                    return;
                }
            }


            llenarDatosCompra();
        }

        private bool ValidarSucursal(ref string message)
        {

            if (GRUPOSUCURSALIDTextBox.Text.Trim().Length <= 0)
            {
                message = "Primero seleccione un grupo de sucursal";
                return false;
            }

            string empprov = this.GRUPOSUCURSALIDTextBox.DbValue.ToString();
            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            if (this.SUCURSALIDTextBox.Text != "")
            {
                sucursalBE.IID = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }


            if (sucursalBE.IID != 0)
            {
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
                if (sucursalBE == null)
                {
                    message = "La sucursal no existe";
                    return false;
                }

                if (((sucursalBE.IEMPPROV == null || sucursalBE.IEMPPROV.Equals("")) && !(empprov == null || empprov.Equals(""))) ||
                    (sucursalBE.IEMPPROV != null && empprov != null && !sucursalBE.IEMPPROV.Equals(empprov)))
                {

                    message = "La sucursal no pertenece al grupo de sucursal";
                    return false;


                }
            }

            return true;
        }

        private void SUCURSALIDTextBox_Validated(object sender, EventArgs e)
        {


            if (SUCURSALIDTextBox.Text.Trim() != "")
            {

                string mensaje = "";
                if (!ValidarSucursal(ref mensaje))
                {
                    MessageBox.Show(mensaje);
                    SUCURSALIDTextBox.Text = "";
                    SUCURSALIDTextBox.Focus();
                    return;
                }

            }

            llenarDatosCompra();
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {

            if (GuardarPago())
            {
                Close();
            }
        }



        private bool GuardarPago()
        {

            this.lblSumaAAplicar.Text = SumaAbonos().ToString("N2");

            if (m_montoAAplicar != m_montoTotal)
            {
                MessageBox.Show(" el pago debe estar aplicado para que pueda guardarse");
                return false;
            }


            if ((FormaPagoComboBox.SelectedIndex == 1 || FormaPagoComboBox.SelectedIndex == 2 || FormaPagoComboBox.SelectedIndex == 3 || FormaPagoComboBox.SelectedIndex == 4 || FormaPagoComboBox.SelectedIndex == 6)
                 && (this.TBReferencia.Text.Trim().Length == 0 || this.ComboBanco.SelectedIndex < 0))
            {
                MessageBox.Show("Debe seleccionar el banco y la referencia si esta pagando con tarjeta , cheque o transferencia");
                return false;
            }

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            CPAGOBE pagoBE = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            try
            {





                pagoBE = new CPAGOBE();
                pagoBE.IFECHA = DateTime.Now;
                pagoBE.IFECHAHORA = DateTime.Now;
                pagoBE.ICORTEID = CurrentUserID.CurrentUser.ICORTEID;
                if (this.ComboBanco.SelectedIndex >= 0)
                    pagoBE.IBANCO = long.Parse(this.ComboBanco.SelectedValue.ToString());
                pagoBE.IREFERENCIABANCARIA = this.TBReferencia.Text;
                pagoBE.IIMPORTE = m_montoTotal;
                pagoBE.INOTAS = TBNotas.Text;

                pagoBE.IIMPORTERECIBIDO = m_montoTotal;

                pagoBE.IFECHAELABORACION = DTPFechaElaboracion.Value;
                pagoBE.IFECHARECEPCION = DTPFechaRecepcion.Value;

                pagoBE.ICUENTABANCOEMPRESAID = -1;


                FijarFormaPago(ref pagoBE);

                //pagoBE.ICOMISION = m_montoComision;


                pagoBE.ITIPOPAGOID = DBValues._TIPOPAGO_SALIDA;


                pagoBE.IESAPARTADO = "N";
                pagoBE.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;

                pagoBE.ITIPOABONOID = DBValues._TIPO_ABONO_ABONO;
                pagoBE.ICUENTAPAGOCREDITO = TBCuentaPago.Text;


                //pagoBE.IBANCOMERPARAMID = bancomerParamId;

                pagoBE.IPERSONAID = long.Parse(ITEMIDTextBox.DbValue);

                pagoBE.ISUBTIPOPAGOID = DBValues._SUBTIPOPAGO_SUCURSALPROVEE;

                pagoBE.IREFINTERNO = TBRefInterno.Text;


                fConn.Open();
                fTrans = fConn.BeginTransaction();

                pagoBE = pagoD.InsertarPAGOD(pagoBE, fTrans);
                if (pagoBE == null)
                {
                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }



                DataRow dr;


                foreach (DataGridViewRow row in cOMPRASSUCSALDODataGridView.Rows)
                {
                    decimal dSaldoAAplicar = decimal.Parse(row.Cells["DGSALDOAAPLICAR"].Value.ToString());

                    if (dSaldoAAplicar > 0)
                    {

                        dr = (row.DataBoundItem as DataRowView).Row;
                        /*dr["SALDOAAPLICAR"] = dSaldoAAplicar;
                        m_montoAAplicar += dSaldoAAplicar;*/




                        CDOCTOPAGOBE pagoManual = new CDOCTOPAGOBE();




                        pagoManual.IDOCTOSALIDAID = long.Parse(dr["DOCTOID"].ToString());
                        pagoManual.ITIPOPAGOID = pagoBE.ITIPOPAGOID;
                        pagoManual.IFORMAPAGOID = pagoBE.IFORMAPAGOID;
                        pagoManual.IFORMAPAGOSATID = pagoBE.IFORMAPAGOSATID;
                        //pagoManual.IDOCTOSALIDAID = long.Parse(dr["DOCTOIDAPLICAR"].ToString());
                        pagoManual.IFECHA = pagoBE.IFECHA;
                        pagoManual.IFECHAHORA = pagoBE.IFECHAHORA;
                        pagoManual.ICORTEID = pagoBE.ICORTEID;
                        pagoManual.IIMPORTE = dSaldoAAplicar;
                        pagoManual.IIMPORTECAMBIO = 0.00m;
                        pagoManual.IIMPORTERECIBIDO = dSaldoAAplicar;
                        pagoManual.IESAPARTADO = pagoBE.IESAPARTADO;

                        pagoManual.IESPAGOINICIAL = DBValues._DB_BOOLVALUE_NO;
                        pagoManual.ITIPOABONOID = pagoBE.ITIPOABONOID;
                        pagoManual.IPAGOID = pagoBE.IID;


                        pagoManual.ICUENTABANCOEMPRESAID = pagoBE.ICUENTABANCOEMPRESAID;



                        pagoManual.IAPLICADO = CBAplicado.Checked ? "S" : "N";
                        pagoManual.IFECHAAPLICADO = DTPFechaAplicado.Value;

                        if (pagoBE.IBANCO > 0)
                            pagoManual.IBANCO = pagoBE.IBANCO;

                        pagoManual.IREFERENCIABANCARIA = pagoBE.IREFERENCIABANCARIA;
                        pagoManual.ICUENTAPAGOCREDITO = pagoBE.ICUENTAPAGOCREDITO;

                        pagoManual.ISUBTIPOPAGOID = pagoBE.ISUBTIPOPAGOID;

                        if (doctoPagoD.InsertarDOCTOPAGOD(pagoManual, fTrans) == null)
                        {

                            fTrans.Rollback();
                            MessageBox.Show(pagoD.IComentario);
                            throw new Exception();
                        }



                    }

                }



                //if (!doctoPagoD.AjustarSaldosPersona(m_proveedorId, fTrans))
                //{

                //    fTrans.Rollback();
                //    MessageBox.Show(pagoD.IComentario);
                //    throw new Exception();
                //}


                fTrans.Commit();
                fConn.Close();

                folioPago = pagoBE.IID;

                //preguntarReciboElectronico(pagoBE.IID);


                if (MessageBox.Show("Desea imprimir el recibo? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    imprimirRecibo(pagoBE.IID);
                }



            }
            catch (Exception ex)
            {
                //fTrans.Rollback();
                fConn.Close();
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;
        }


        private void LlenarDatosDeBase()
        {
            CPAGOBE pago = new CPAGOBE();
            CPAGOD pagoDao = new CPAGOD();

            pago.IID = folioPago;
            pago = pagoDao.seleccionarPAGO(pago, null);

            TBIdPago.Text = pago.IID.ToString();
            //.DbValue = pago.IPERSONAID.ToString();



            if (pago.IREVERTIDO == null || !pago.IREVERTIDO.Equals("S"))
            {
                BTEliminar.Enabled = true;
            }
            else
            {

                BTEliminar.Enabled = false;
            }

            if (!(bool)pago.isnull["IBANCO"])
            {
                ComboBanco.SelectedValue = pago.IBANCO;
            }
            else
            {
                ComboBanco.SelectedValue = -1;
            }



            string strBuffer = "";
            if (!(bool)pago.isnull["IPERSONAID"])
            {
                this.ITEMIDTextBox.DbValue = pago.IPERSONAID.ToString();
                this.ITEMIDTextBox.MostrarErrores = false;
                this.ITEMIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.ITEMIDTextBox.MostrarErrores = true;

                llenarDatosPersona(pago.IPERSONAID);
            }

            PA_ABONOTextBox.Text = pago.IIMPORTE.ToString();
            DTPFechaElaboracion.Value = pago.IFECHAELABORACION;
            DTPFechaRecepcion.Value = pago.IFECHAELABORACION;

            int formaPagoIndex = ObtenerFormaPagoIndex(pago.IFORMAPAGOID, pago.IFORMAPAGOSATID);

            if (formaPagoIndex >= 0) FormaPagoComboBox.SelectedIndex = formaPagoIndex;

            TBNotas.Text = pago.INOTAS;

            TBReferencia.Text = pago.IREFERENCIABANCARIA;
            TBCuentaPago.Text = pago.ICUENTAPAGOCREDITO;

            if (CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("3.3") || CurrentUserID.CurrentParameters.IVERSIONCFDI.Equals("4.0"))
            {
                if (pago.IAPLICADO == "S")
                {

                    DTPFechaAplicado.Value = pago.IFECHAAPLICADO;
                    CBAplicado.Checked = true;
                }
                else
                {

                    DTPFechaAplicado.Value = DateTime.Today;
                    CBAplicado.Checked = false;
                }

            }

            this.pAGOSAPLICADOSSUCTableAdapter.Fill(this.dSAbonos2.PAGOSAPLICADOSSUC, pago.IID);
        }

        private void BTEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta seguro que desea revertir el abono? ", "Confirmacion", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (RevertirPago())
            {
                MessageBox.Show("El pago se ha revertido");
            }
        }





        private bool RevertirPago()
        {
            bool retorno = false;
            long pagoRevertidoId = 0;


            CPAGOBE pagoActual = new CPAGOBE();
            CPAGOD pagoD = new CPAGOD();
            pagoActual.IID = folioPago;
            pagoActual = pagoD.seleccionarPAGO(pagoActual, null);

            if (pagoActual == null)
                return false;





            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();


                if (!pagoD.RevertirPAGOD(folioPago, CurrentUserID.CurrentUser.IID, false, "", ref pagoRevertidoId, fTrans))
                {

                    fTrans.Rollback();
                    MessageBox.Show(pagoD.IComentario);
                    throw new Exception();
                }




                fTrans.Commit();
                fConn.Close();
                retorno = true;



                this.Close();

            }
            catch
            {

                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }


            return retorno;
        }

        private void SUCURSALIDButton_Click(object sender, EventArgs e)
        {
            if (GRUPOSUCURSALIDTextBox.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Primero seleccione un grupo de sucursal");
                return;
            }

            string empprov = this.GRUPOSUCURSALIDTextBox.DbValue.ToString();
            string query = "select id,clave,nombre from sucursal  where empprov = '" + empprov + "'";
            GeneralLookUp look = new GeneralLookUp(query, "Sucursales de " + empprov);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.SUCURSALIDTextBox.Text = dr[1].ToString();
                this.SUCURSALIDTextBox.Focus();
            }
        }

        private void cOMPRASSUCSALDODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (cOMPRASSUCSALDODataGridView.Columns[e.ColumnIndex].Name == "DGQUITAR")
                {
                    long consecutivo = long.Parse(cOMPRASSUCSALDODataGridView.Rows[e.RowIndex].Cells["CONSECUTIVO"].Value.ToString());

                    string selectStr = "DOCTOID = " + consecutivo.ToString();
                    DataRow[] rows = dSAbonos2.COMPRASSUCSALDO.Select(selectStr);

                    if (rows != null && rows.Length > 0)
                    {
                        DataRow rowToDelete = rows[0];
                        rowToDelete.Delete();
                    }

                }
            }
        }

        private void GRUPOSUCURSALIDTextBox_Validated(object sender, EventArgs e)
        {

            HabilitarAdicionDeDetalles();
        }
    }
}
