using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class MovtoInventarioTrans : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long? Id { get; set; }
        public long Doctoid { get; set; }
        public int? Partida { get; set; }
        public long Estatusmovtoid { get; set; }
        public long Productoid { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Cantidad_real { get; set; }
        public decimal? Descuentoporcentaje { get; set; }
        public decimal? Precio { get; set; }
        public string? Lote { get; set; }
        public DateTimeOffset? Fechavence { get; set; }
        public long? Loteimportado { get; set; }
        public long? Movtoparentid { get; set; }
        public string? Localidad { get; set; }
        public BoolCN? Agrupaporparametro { get; set; }
        public long Usuarioid { get; set; }
        public long? Anaquelid { get; set; }

    }


    public class DoctoInventarioTrans : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Creadopor_userid { get; set; }
        public long Estatusdoctoid { get; set; }
        public long Usuarioid { get; set; }
        public DateTimeOffset Fecha { get; set; }
        public long Cajaid { get; set; }
        public long Almacenid { get; set; }
        //public long Origenfiscalid { get; set; }
        //public long? Doctoparentid { get; set; }
        public long Tipodoctoid { get; set; }
        public long Sucursal_id { get; set; }
        public string? Referencia { get; set; }
        public string? Referencias { get; set; }
        public BoolCN Promocion { get; set; }
        public long? Sucursaltid { get; set; }
        public long? Almacentid { get; set; }

        public BoolCN Kitdesglosado { get; set; }
        public DateTimeOffset? Fechavence { get; set; }

    }


    public class Tmp_Inventario_movto_loteInfo
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long ProductoId { get; }
        public string? Lote { get; }
        public DateTimeOffset? Fechavence { get; }
        public string Valor { get; }

        public Tmp_Inventario_movto_loteInfo(long empresaId, long sucursalId, long productoId, string? lote, DateTimeOffset? fechavence, string valor)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            ProductoId = productoId;
            Lote = lote;
            Fechavence = fechavence;
            Valor = valor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_Inventario_movto_loteInfo other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   ProductoId == other.ProductoId &&
                   Lote == other.Lote &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
                   Valor == other.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmpresaId, SucursalId, ProductoId, Lote, Fechavence, Valor);
        }
    }
}
