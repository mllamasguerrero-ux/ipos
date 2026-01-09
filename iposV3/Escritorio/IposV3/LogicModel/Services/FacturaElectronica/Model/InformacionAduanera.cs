using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class InformacionAduanera
    {
        private string? fecha;

        public string? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string? numero;

        public string? Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private string? aduana;

        public string? Aduana
        {
            get { return aduana; }
            set { aduana = value; }
        }

        public InformacionAduanera()
        {

        }
    }
}
