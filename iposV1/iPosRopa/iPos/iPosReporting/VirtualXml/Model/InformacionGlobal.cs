using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class InformacionGlobal
    {



        private string periodicidad;

        public string Periodicidad
        {
            get { return periodicidad; }
            set { periodicidad = value; }
        }

        private string meses;

        public string Meses
        {
            get { return meses; }
            set { meses = value; }
        }

        private string anio;

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public InformacionGlobal(string periodicidad, string meses, string anio)
        {
            this.periodicidad = periodicidad;
            this.meses = meses;
            this.anio = anio;


        }


    }
}
