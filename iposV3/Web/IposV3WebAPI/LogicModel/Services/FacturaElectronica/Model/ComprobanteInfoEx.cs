using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class ComprobanteInfoEx
    {
        private string? lugarExpedicion;

        public string? LugarExpedicion
        {
            get { return lugarExpedicion; }
            set { lugarExpedicion = value; }
        }
        private string? numeroCtaPago;

        public string? NumeroCtaPago
        {
            get { return numeroCtaPago; }
            set { numeroCtaPago = value; }
        }
        private string? serieFolioFiscalOriginal;

        public string? SerieFolioFiscalOriginal
        {
            get { return serieFolioFiscalOriginal; }
            set { serieFolioFiscalOriginal = value; }
        }
        private string? folioFiscalOriginal;

        public string? FolioFiscalOriginal
        {
            get { return folioFiscalOriginal; }
            set { folioFiscalOriginal = value; }
        }
        private string? montoFolioFiscalOriginal;

        public string? MontoFolioFiscalOriginal
        {
            get { return montoFolioFiscalOriginal; }
            set { montoFolioFiscalOriginal = value; }
        }
        private string? fechaFolioFiscalOriginal;

        public string? FechaFolioFiscalOriginal
        {
            get { return fechaFolioFiscalOriginal; }
            set { fechaFolioFiscalOriginal = value; }
        }

        public ComprobanteInfoEx()
        {
        }

        public ComprobanteInfoEx(string lugarExpedicion, string numeroCtaPago, string serieFolioFiscalOriginal,
                                 string folioFiscalOriginal, string montoFolioFiscalOriginal, string fechaFolioFiscalOriginal)
        {
            this.lugarExpedicion = lugarExpedicion;
            this.numeroCtaPago = numeroCtaPago;
            this.serieFolioFiscalOriginal = serieFolioFiscalOriginal;
            this.folioFiscalOriginal = folioFiscalOriginal;
            this.montoFolioFiscalOriginal = montoFolioFiscalOriginal;
            this.fechaFolioFiscalOriginal = fechaFolioFiscalOriginal;
        }
    }
}
