using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class PagoDoctoImpSAT:Impuesto
    {


        public PagoDoctoImpSAT()
        {

        }

        string? baseImp;
        public string? BaseImp
        {
            get { return baseImp; }
            set { baseImp = value; }
        }


        private string? tipoFactor;

        public string? TipoFactor
        {
            get { return tipoFactor; }
            set { tipoFactor = value; }
        }

        private string? tasaCuota;

        public string? TasaCuota
        {
            get { return tasaCuota; }
            set { tasaCuota = value; }
        }


        string? idDocumento;
        public string? IdDocumento { get { return idDocumento; } set { idDocumento = value; } }

    }
}
