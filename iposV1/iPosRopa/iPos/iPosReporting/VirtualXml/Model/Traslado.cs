using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class Traslado : Impuesto
    {

        public Traslado()
        {

        }

       string baseImp;
        public string BaseImp
        {
            get { return baseImp; }
            set { baseImp = value; }
        }


        private string tipoFactor;

        public string TipoFactor
        {
            get { return tipoFactor; }
            set { tipoFactor = value; }
        }

        private string tasaCuota;

        public string TasaCuota
        {
            get { return tasaCuota; }
            set { tasaCuota = value; }
        }
    }
}
