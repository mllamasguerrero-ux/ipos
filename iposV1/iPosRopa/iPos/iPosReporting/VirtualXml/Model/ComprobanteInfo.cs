using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class ComprobanteInfo
    {
        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        private string folio;

        public string Folio
        {
            get { return folio; }
            set { folio = value; }
        }

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string tipoComprobante;

        public string TipoComprobante
        {
            get { return tipoComprobante; }
            set { tipoComprobante = value; }
        }

        private string formaPago;

        public string FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        private string subtotal;

        public string Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        private string descuento;

        public string Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private string total;

        public string Total
        {
            get { return total; }
            set { total = value; }
        }

        private string moneda;

        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        private string condicionesPago;

        public string CondicionesPago
        {
            get { return condicionesPago; }
            set { condicionesPago = value; }
        }

        private string metodoPago;

        public string MetodoPago
        {
            get { return metodoPago; }
            set { metodoPago = value; }
        }

        private string motivoDescuento;

        public string MotivoDescuento
        {
            get { return motivoDescuento; }
            set { motivoDescuento = value; }
        }

        private string tipoCambio;

        public string TipoCambio
        {
            get { return tipoCambio; }
            set { tipoCambio = value; }
        }

        private string lugarExpedicion;

        public string LugarExpedicion
        {
            get { return lugarExpedicion; }
            set { lugarExpedicion = value; }
        }

        private string confirmacion;

        public string Confirmacion
        {
            get { return confirmacion; }
            set { confirmacion = value; }
        }


        private string exportacion;

        public string Exportacion
        {
            get { return exportacion; }
            set { exportacion = value; }
        }

        public ComprobanteInfo(string serie, string folio, string fecha, string tipoComprobante, 
                               string formaPago, string subtotal, string descuento, string total,
                               string moneda, string tipoCambio, string condicionesPago, string metodoPago,
                               string motivoDescuento)
        {
            this.serie = serie;
            this.folio = folio;
            this.fecha = fecha;
            this.tipoComprobante = tipoComprobante;
            this.formaPago = formaPago;
            this.subtotal = subtotal;
            this.descuento = descuento;
            this.total = total;
            this.moneda = moneda;
            this.tipoCambio = tipoCambio;
            this.condicionesPago = condicionesPago;
            this.metodoPago = metodoPago;
            this.motivoDescuento = motivoDescuento;

        }



        public ComprobanteInfo(string serie, string folio, string fecha, string tipoComprobante,
                               string formaPago, string subtotal, string descuento, string total,
                               string moneda, string tipoCambio, string condicionesPago, string metodoPago,
                               string motivoDescuento, string lugarExpedicion) : 
            this(serie, folio,  fecha, tipoComprobante,
                                formaPago, subtotal, descuento,  total,
                                moneda,  tipoCambio,  condicionesPago,  metodoPago,
                                motivoDescuento)
        {
            this.lugarExpedicion = lugarExpedicion;
        }


        public ComprobanteInfo(string serie, string folio, string fecha, string tipoComprobante,
                               string formaPago, string subtotal, string descuento, string total,
                               string moneda, string tipoCambio, string condicionesPago, string metodoPago,
                               string motivoDescuento, string lugarExpedicion, string exportacion) :
            this(serie, folio, fecha, tipoComprobante,
                                formaPago, subtotal, descuento, total,
                                moneda, tipoCambio, condicionesPago, metodoPago,
                                motivoDescuento, lugarExpedicion)
        {
            this.exportacion = exportacion;
        }


    }
}
