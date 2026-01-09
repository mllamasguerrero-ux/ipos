using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class PagoSAT
    {


        string? fechaPago;
        string? formaDePagoP;
        string? monedaP;
        string? tipoCambioP;
        string? monto;
        string? numOperacion;
        string? rfcEmisorCtaOrd;
        string? nomBancoOrdExt;
        string? ctaOrdenante;
        string? rfcEmisorCtaBen;
        string? ctaBeneficiario;
        string? tipoCadPago;
        string? certPago;
        string? cadPago;
        string? selloPago;
        long? pagoSatId;

        public string? FechaPago { get { return fechaPago;} set { fechaPago = value; } }
        public string? FormaDePagoP { get { return formaDePagoP;} set { formaDePagoP = value; } }
        public string? MonedaP { get { return monedaP;} set { monedaP = value; } }
        public string? TipoCambioP { get { return tipoCambioP;} set { tipoCambioP = value; } }
        public string? Monto { get { return monto;} set { monto = value; } }
        public string? NumOperacion { get { return numOperacion;} set { numOperacion = value; } }
        public string? RfcEmisorCtaOrd { get { return rfcEmisorCtaOrd;} set { rfcEmisorCtaOrd = value; } }
        public string? NomBancoOrdExt { get { return nomBancoOrdExt;} set { nomBancoOrdExt = value; } }
        public string? CtaOrdenante { get { return ctaOrdenante;} set { ctaOrdenante = value; } }
        public string? RfcEmisorCtaBen { get { return rfcEmisorCtaBen;} set { rfcEmisorCtaBen = value; } }
        public string? CtaBeneficiario { get { return ctaBeneficiario;} set { ctaBeneficiario = value; } }
        public string? TipoCadPago { get { return tipoCadPago;} set { tipoCadPago = value; } }
        public string? CertPago { get { return certPago;} set { certPago = value; } }
        public string? CadPago { get { return cadPago;} set { cadPago = value; } }
        public string? SelloPago { get { return selloPago;} set { selloPago = value; } }
        public long? PagoSatId { get { return pagoSatId; } set { pagoSatId = value; } }


        private List<PagoDoctoSAT>? doctosRelacionados;

        public List<PagoDoctoSAT>? DoctosRelacionados
        {
            get { return doctosRelacionados; }
            set { doctosRelacionados = value; }
        }

        private List<Pagodoctosat_imp>? doctosImpRelacionados;

        public List<Pagodoctosat_imp>? DoctosImpRelacionados
        {
            get { return doctosImpRelacionados; }
            set { doctosImpRelacionados = value; }
        }
    }
}
