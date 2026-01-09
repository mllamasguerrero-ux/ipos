using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class Impuesto
    {
        private string? impuesto;

        public string? ImpuestoVal
        {
            get { return impuesto; }
            set { impuesto = value; }
        }
        private string? tasa;

        public string? Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }
        private string? importe;

        public string? Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public Impuesto()
        {

        }
    }
}
