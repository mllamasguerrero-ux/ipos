using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class ConceptoParte
    {


        private string? claveProdServ;
        private string? noIdentificacion;
        private string? cantidad;
        private string? unidad;
        private string? descripcion;
        private string? valorUnitario;
        private string? importe;
        private string? numeroPedimento;

        private long? movtoKitId;

        public string? ClaveProdServ { get { return claveProdServ; } set { claveProdServ = value; } }
        public string? NoIdentificacion { get { return noIdentificacion; } set { noIdentificacion = value; } }
        public string? Cantidad { get { return cantidad; } set { cantidad = value; } }
        public string? Unidad { get { return unidad; } set { unidad = value; } }
        public string? Descripcion { get { return descripcion; } set { descripcion = value; } }
        public string? ValorUnitario { get { return valorUnitario; } set { valorUnitario = value; } }
        public string? Importe { get { return importe; } set { importe = value; } }
        public string? NumeroPedimento { get { return numeroPedimento; } set { numeroPedimento = value; } }
        public long? MovtoKitId { get { return movtoKitId; } set { movtoKitId = value; } }
    }
}
