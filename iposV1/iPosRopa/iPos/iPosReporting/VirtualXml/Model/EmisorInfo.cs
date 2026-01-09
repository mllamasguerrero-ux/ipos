using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class EmisorInfo
    {
        private string rfc;

        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
        private string razonSocial;

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        private string regimenFiscal;

        public string RegimenFiscal
        {
            get { return regimenFiscal; }
            set { regimenFiscal = value; }
        }

        private Domicilio domicilio;

        public Domicilio Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public EmisorInfo(string rfc, string razonSocial, string regimenFiscal, Domicilio domicilio)
        {
            this.rfc = rfc;
            this.razonSocial = razonSocial;
            this.regimenFiscal = regimenFiscal;
            this.domicilio = domicilio;
        }
    }
}
