using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class ComprobanteCFDInfo
    {
        private string numeroAprobacion;

        public string NumeroAprobacion
        {
            get { return numeroAprobacion; }
            set { numeroAprobacion = value; }
        }
        private string anoAprobacion;

        public string AnoAprobacion
        {
            get { return anoAprobacion; }
            set { anoAprobacion = value; }
        }

        public ComprobanteCFDInfo(string numeroAprobacion, string anoAprobacion)
        {
            this.numeroAprobacion = numeroAprobacion;
            this.anoAprobacion = anoAprobacion;
        }
    }
}
