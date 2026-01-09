using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class DoctoProvTrans : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Creadopor_userid { get; set; }
        public long Estatusdoctoid { get; set; }
        public long Usuarioid { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public long Cajaid { get; set; }
        public long Almacenid { get; set; }
        public long Origenfiscalid { get; set; }
        public long? Doctoparentid { get; set; }
        public long Tipodoctoid { get; set; }
        public long? Proveedorid { get; set; }
        public long Sucursal_id { get; set; }
        public string? Referencia { get; set; }
        public string? Referencias { get; set; }
        public BoolCN Promocion { get; set; }
        public long? Sucursaltid { get; set; }
        public long? Almacentid { get; set; }
        public string? Folio_c { get; set; }
        public string? Factura_c { get; set; }
        public DateTimeOffset? Fechafactura_c { get; set; }
        public DateTimeOffset? Fechavence_c { get; set; }

    }


    public class MovtoProvTrans : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long? Id { get; set; }
        public long Doctoid { get; set; }
        public int? Partida { get; set; }
        public long Estatusmovtoid { get; set; }
        public long Productoid { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? Descuentoporcentaje { get; set; }
        public decimal? Precio { get; set; }
        public string? Lote { get; set; }
        public DateTimeOffset? Fechavence { get; set; }
        public long? Loteimportado { get; set; }
        public long? Movtoparentid { get; set; }
        public string? Localidad { get; set; }
        public string? Descripcion1 { get; set; }
        public string? Descripcion2 { get; set; }
        public string? Descripcion3 { get; set; }
        public BoolCN? Agrupaporparametro { get; set; }
        public BoolCN? Cargartarjetapreciomanual { get; set; }
        public BoolCN? Precioyavalidado { get; set; }
        public long Usuarioid { get; set; }
        public decimal? Precioconimp { get; set; }
        public long? Anaquelid { get; set; }

        public bool EsMovtoPrincipal { get; set; } = true;

    }
}
