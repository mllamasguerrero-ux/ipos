
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
    public class Monederomovto : EntityBaseExt
    {


        public Monederomovto() : base()
        {
        }

        public Monederomovto(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Monederomovto(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




    public long? Monedero { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Monedero")]
        public virtual Monedero? Monedero_ { get; set; }

        public long? Tipomonederomovtoid { get; set; }
        [ForeignKey("Tipomonederomovtoid")]
        public virtual Tipomonederomovto? Tipomonederomovto { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;

    public DateTimeOffset? Fecha { get; set; }

    public int? Caducidad { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montomonedero { get; set; } = 0m;

    public DateTimeOffset? Vigenciamonedero { get; set; }


  }
}

