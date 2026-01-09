using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class ReceptorInfo
    {
        private string? rfc;

        public string? Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
        private string? razonSocial;

        public string? RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        private Domicilio? domicilio;

        public Domicilio? Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        private string? nombre;

        public string? Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string? residenciaFiscal;

        public string? ResidenciaFiscal
        {
            get { return residenciaFiscal; }
            set { residenciaFiscal = value; }
        }

        private string? numRegIdTrib;

        public string? NumRegIdTrib
        {
            get { return numRegIdTrib; }
            set { numRegIdTrib = value; }
        }

        private string? usoCFDI;

        public string? UsoCFDI
        {
            get { return usoCFDI; }
            set { usoCFDI = value; }
        }


        private string? regimenFiscalReceptor;

        public string? RegimenFiscalReceptor
        {
            get { return regimenFiscalReceptor; }
            set { regimenFiscalReceptor = value; }
        }


        private string? domicilioFiscalReceptor;
        public string? DomicilioFiscalReceptor
        {
            get { return domicilioFiscalReceptor; }
            set { domicilioFiscalReceptor = value; }
        }

        public ReceptorInfo()
        {

        }
    }
}
