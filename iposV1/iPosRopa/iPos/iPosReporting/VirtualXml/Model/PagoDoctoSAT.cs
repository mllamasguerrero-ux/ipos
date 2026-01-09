using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class PagoDoctoSAT
    {


        string idDocumento;
        string serie;
        string folio;
        string monedaDR;
        string tipoCambioDR;
        string metodoDePagoDR;
        string numParcialidad;
        string impSaldoAnt;
        string impPagado;
        string impSaldoInsoluto;
        string objetoImpDR;

        public string IdDocumento { get { return idDocumento; } set { idDocumento = value; } }
        public string Serie { get { return serie; } set { serie = value; } }
        public string Folio { get { return folio; } set { folio = value; } }
        public string MonedaDR { get { return monedaDR; } set { monedaDR = value; } }
        public string TipoCambioDR { get { return tipoCambioDR; } set { tipoCambioDR = value; } }
        public string MetodoDePagoDR { get { return metodoDePagoDR; } set { metodoDePagoDR = value; } }
        public string NumParcialidad { get { return numParcialidad; } set { numParcialidad = value; } }
        public string ImpSaldoAnt { get { return impSaldoAnt; } set { impSaldoAnt = value; } }
        public string ImpPagado { get { return impPagado; } set { impPagado = value; } }
        public string ImpSaldoInsoluto { get { return impSaldoInsoluto; } set { impSaldoInsoluto = value; } }
        public string ObjetoImpDR { get { return objetoImpDR; } set { objetoImpDR = value; } }
    }
}
