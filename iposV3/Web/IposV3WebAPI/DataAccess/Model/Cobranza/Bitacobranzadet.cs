
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Bitacobranzadet : EntityBaseExt
    {


        public Bitacobranzadet() : base()
        {
        }

        public Bitacobranzadet(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Bitacobranzadet(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.Stdtext_lightLength)]
    public string? Diapagos { get; set; }

    public string? Observaciones { get; set; }


        public long? Bitcobranzaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Bitcobranzaid")]
        public virtual Bitacobranza? Bitcobranza { get; set; }

        public DateTimeOffset? Fecha { get; set; }

        public long? Cobradorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cobradorid")]
        public virtual Usuario? Cobrador { get; set; }

        public long? Personaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaid")]
        public virtual Cliente? Persona { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;

    public DateTimeOffset? Fechavence { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abono { get; set; } = 0m;

    public long? Doctopagoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctopagoid")]
        public virtual Doctopago? Doctopago { get; set; }

        public long? Estado { get; set; }
        [ForeignKey("Estado")]
        public virtual Estadocobranza? Estadocobranza { get; set; }

        public DateTimeOffset? Nuevafechacobro { get; set; }


  }
}

