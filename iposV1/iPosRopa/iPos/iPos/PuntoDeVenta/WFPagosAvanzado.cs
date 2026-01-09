using iPosBusinessEntity;
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

namespace iPos
{


    public partial class WFPagosAvanzado : IposForm
    {
        public Decimal TotalTransaccion { get; set; }
        public Decimal SaldoTransaccion { get; set; }

        public Boolean AplicarCambios { get; set; }

        public iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable TablaPagos
        {
            get { return dSPuntoDeVentaAux2.PAGOSAVANZADO; }
        }

        public WFPagosAvanzado()
        {
            InitializeComponent();
        }

        public WFPagosAvanzado(iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADODataTable pagosAvanzadoTable,
                                List<String> formasPago,
                                decimal totalTransaccion) : this()
        {

            AplicarCambios = false;

            TotalTransaccion = totalTransaccion;

            FormaPagoComboBox.Items.Clear();
            foreach(string strItem in formasPago)
            {
                FormaPagoComboBox.Items.Add(strItem);
            }

            SaldoTransaccion = totalTransaccion;
            dSPuntoDeVentaAux2.PAGOSAVANZADO.Clear();
            int iConsecutivo = 1;
            foreach(iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row in pagosAvanzadoTable)
            {
                //dSPuntoDeVentaAux2.PAGOSAVANZADO.AddPAGOSAVANZADORow(row);


                iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow rowTable = dSPuntoDeVentaAux2.PAGOSAVANZADO.NewPAGOSAVANZADORow();
                rowTable.FORMAPAGOID = row.FORMAPAGOID;
                rowTable.FORMAPAGONOMBRE = row.FORMAPAGONOMBRE;
                rowTable.FORMAPAGOSATID = row.FORMAPAGOSATID;
                rowTable.MONTO = row.MONTO;
                if(!row.IsBANCOIDNull())
                    rowTable.BANCOID =   row.BANCOID;
                if (!row.IsBANCONOMBRENull())
                    rowTable.BANCONOMBRE = row.BANCONOMBRE;
                if (!row.IsREFERENCIANull())
                    rowTable.REFERENCIA = row.REFERENCIA;
                rowTable.CONSECUTIVO = iConsecutivo++;
                dSPuntoDeVentaAux2.PAGOSAVANZADO.AddPAGOSAVANZADORow(rowTable);

                SaldoTransaccion -= row.MONTO;
            }

            lblTotal.Text = TotalTransaccion.ToString();
            lblSaldo.Text = SaldoTransaccion.ToString();
        }


        private void ClearEdit()
        {

            PA_ABONOTextBox.Text = "0.00";
            FormaPagoComboBox.SelectedIndex = -1;
            ComboBanco.SelectedIndex = -1;
            TBReferencia.Text = "";

            TBReferencia.Enabled = false;
            ComboBanco.Enabled = false;
            

        }

        private void updateSaldo()
        {

            SaldoTransaccion = TotalTransaccion;
            foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row in dSPuntoDeVentaAux2.PAGOSAVANZADO.Rows)
            {
                SaldoTransaccion -= row.MONTO;
            }
            lblSaldo.Text = SaldoTransaccion.ToString();
        }

        private void WFPagosAvanzado_Load(object sender, EventArgs e)
        {

            this.ComboBanco.llenarDatos();
            this.ComboBanco.SelectedIndex = -1;
        }

        private void FormaPagoSeleccionada(out long formaPagoSeleccionada, out string formaPagoDescripcion, out long formaPagoSatSeleccionada)
        {
            if (FormaPagoComboBox.SelectedItem != null)
                formaPagoDescripcion = FormaPagoComboBox.SelectedItem.ToString();
            else
                formaPagoDescripcion = "";

            switch (formaPagoDescripcion)
            {
                
            

                case PagosAvanzadoFormas.Efectivo : formaPagoSeleccionada = DBValues._FORMA_PAGO_EFECTIVO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                case PagosAvanzadoFormas.Tarjeta_de_credito: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETACREDITO; break;
                case PagosAvanzadoFormas.Tarjeta_de_debito: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETADEBITO; break;
                case PagosAvanzadoFormas.Tarjeta_de_servicio: formaPagoSeleccionada = DBValues._FORMA_PAGO_TARJETA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TARJETASERVICIO; break;
                case PagosAvanzadoFormas.Cheque_nominativo: formaPagoSeleccionada = DBValues._FORMA_PAGO_CHEQUE; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_CHEQUE; break;
                case PagosAvanzadoFormas.Vales_de_despensa: formaPagoSeleccionada = DBValues._FORMA_PAGO_VALE; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_VALE; break;
                case PagosAvanzadoFormas.Transferencia_electronica_de_fondos: formaPagoSeleccionada = DBValues._FORMA_PAGO_TRANSFERENCIA; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_TRANSFERENCIA; break;
                case PagosAvanzadoFormas.Intercambio_de_mercancia: formaPagoSeleccionada = DBValues._FORMA_PAGO_INTERCAMBIOMERCANCIACREDITO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_COMPENSACION; break;
                case PagosAvanzadoFormas.Otros: formaPagoSeleccionada = DBValues._FORMA_PAGO_NOIDENTIFICADO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_OTRO; break;
                case PagosAvanzadoFormas.Deposito: formaPagoSeleccionada = DBValues._FORMA_PAGO_DEPOSITO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                case PagosAvanzadoFormas.Deposito_a_terceros: formaPagoSeleccionada = DBValues._FORMA_PAGO_DEPOSITOTERCERO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO; break;
                default: formaPagoSeleccionada = DBValues._FORMA_PAGO_EFECTIVO; formaPagoSatSeleccionada = DBValues._FORMA_PAGOSAT_EFECTIVO;  formaPagoDescripcion = "Efectivo"; break;
            }
        }

        private int nextConsecutivo()
        {
            int nextCons = 1;


            foreach (iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row in dSPuntoDeVentaAux2.PAGOSAVANZADO.Rows)
            {
                if(!row.IsCONSECUTIVONull() && row.CONSECUTIVO >= nextCons)
                {
                    nextCons = row.CONSECUTIVO + 1;
                }
            }
            return nextCons;
        }

        private void BtnAvanzado_Click(object sender, EventArgs e)
        {
            
            //validacion 1
            if(FormaPagoComboBox.SelectedIndex   < 0)
            {
                MessageBox.Show("Ingrese una forma de pago");
                return;
            }

            decimal monto = decimal.Parse(PA_ABONOTextBox.NumericValue.ToString());
            if (monto <= 0)
            {

                MessageBox.Show("Ingrese un monto mayor a cero");
                return;
            }


            long formaPagoSeleccionada = 0;
            long formaPagoSatSeleccionada = 0;
            string formaPagoDescripcion = "";
            FormaPagoSeleccionada(out formaPagoSeleccionada, out formaPagoDescripcion, out formaPagoSatSeleccionada);


            if(formaPagoSeleccionada == DBValues._FORMA_PAGO_EFECTIVO)
            {

                foreach(iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow fila in dSPuntoDeVentaAux2.PAGOSAVANZADO.Rows)
                {
                    if(fila.FORMAPAGOID == DBValues._FORMA_PAGO_EFECTIVO)
                    {
                        fila.MONTO += monto;
                        ClearEdit();
                        updateSaldo();
                        return;
                    }
                }
            }


            int nextCons = nextConsecutivo(); 

            iPos.PuntoDeVenta.DSPuntoDeVentaAux2.PAGOSAVANZADORow row = dSPuntoDeVentaAux2.PAGOSAVANZADO.NewPAGOSAVANZADORow();
            row.MONTO = monto;

            row.FORMAPAGOID = formaPagoSeleccionada;
            row.FORMAPAGONOMBRE = formaPagoDescripcion;

            row.FORMAPAGOSATID = formaPagoSatSeleccionada;
            




            if(RequiereInfoBanco(formaPagoSeleccionada) && (this.ComboBanco.SelectedIndex < 0 || this.TBReferencia.Text.Trim().Length == 0))
            {

                MessageBox.Show("Se requiere informacion bancaria para esta forma de pago");
                return;
            }

            //if(formaPagoSeleccionada == DBValues._FORMA_PAGO_VALE && this.TBReferencia.Text.Trim().Length == 0)
            //{

            //    MessageBox.Show("Se requiere ingresar el numero de vale en el campo referencia para esta forma de pago");
            //    return;
            //}

            if (this.ComboBanco.SelectedIndex >= 0)
            {
                row.BANCOID = long.Parse(this.ComboBanco.SelectedValue.ToString());
                row.BANCONOMBRE = this.ComboBanco.SelectedDataDisplaying.ToString();
            }

            row.REFERENCIA = this.TBReferencia.Text;
            row.CONSECUTIVO = nextCons;

            dSPuntoDeVentaAux2.PAGOSAVANZADO.AddPAGOSAVANZADORow(row);
            ClearEdit();
            updateSaldo();

        }

        private bool RequiereInfoBanco(long formaPagoSeleccionada)
        {
            bool retorno = false;
            switch (formaPagoSeleccionada)
            {
                case DBValues._FORMA_PAGO_TARJETA:
                case DBValues._FORMA_PAGO_CHEQUE:
                case DBValues._FORMA_PAGO_TRANSFERENCIA:
                case DBValues._FORMA_PAGO_DEPOSITO:
                case DBValues._FORMA_PAGO_DEPOSITOTERCERO:
                    retorno = true;
                    break;

                default:
                    retorno = false;
                    break;


            }

            return retorno;
        }

        private void FormaPagoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            long formaPagoSeleccionada = 0;
            long formaPagoSatSeleccionada = 0;
            string formaPagoDescripcion = "";
            FormaPagoSeleccionada(out formaPagoSeleccionada, out formaPagoDescripcion, out formaPagoSatSeleccionada);

            bool requiereInfoBanco = RequiereInfoBanco(formaPagoSeleccionada);


            TBReferencia.Enabled = requiereInfoBanco;//|| formaPagoSeleccionada == DBValues._FORMA_PAGO_VALE;
            ComboBanco.Enabled = requiereInfoBanco;


        }

        private void pAGOSAVANZADODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex != -1)
            {

                if (pAGOSAVANZADODataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    DataRow row = ((DataRowView)pAGOSAVANZADODataGridView.CurrentRow.DataBoundItem).Row;
                    long lFormaPagoId = long.Parse(pAGOSAVANZADODataGridView.Rows[e.RowIndex].Cells["FORMAPAGOID"].Value.ToString());

                    if(lFormaPagoId == DBValues._FORMA_PAGO_NOIDENTIFICADO)
                    {
                        MessageBox.Show("Este pago no puede ser eliminado en esta interfaz");
                        return;
                    }

                    if (MessageBox.Show("Realmente quiere eliminar el registro?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        row.Delete();
                        updateSaldo();
                    }
                }
            }
        }

        private void BTGuardar_Click(object sender, EventArgs e)
        {
            AplicarCambios = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    public static class PagosAvanzadoFormas
    {
        public const String Efectivo = "Efectivo";
        public const String Tarjeta_de_credito = "Tarjeta de credito";
        public const String Tarjeta_de_debito = "Tarjeta de debito";
        public const String Tarjeta_de_servicio = "Tarjeta de servicio";
        public const String Cheque_nominativo = "Cheque nominativo";
        public const String Vales_de_despensa = "Vales de despensa";
        public const String Transferencia_electronica_de_fondos = "Transferencia electronica de fondos";
        public const String Intercambio_de_mercancia = "Intercambio de mercancia";
        public const String Otros = "Otros";
        public const String Deposito = "Deposito";
        public const String Deposito_a_terceros = "Deposito a terceros";
        public const String Monedero = "Monedero";
        public const String CreditoAutomatico = "Credito automatico";
        public const String SaldoCompraRelacionada = "Saldo compra relacionada";
    }
}
