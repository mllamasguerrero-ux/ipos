using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class ImpuestosInfo
    {
        private string? totalTraslados;

        public string? TotalTraslados
        {
            get { return totalTraslados; }
            set { totalTraslados = value; }
        }
        private string? totalRetenciones;

        public string? TotalRetenciones
        {
            get { return totalRetenciones; }
            set { totalRetenciones = value; }
        }

        public ImpuestosInfo()
        {

        }
    }
}
