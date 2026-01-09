
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
    public class Docto_monedero : EntityBaseExt
    {


        public Docto_monedero() : base()
        {
        }

        public Docto_monedero(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_monedero(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public long? Monedero { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Monedero")]
        public virtual Monedero? Monedero_ { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Descmonedero { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abonomonedero { get; set; } = 0m;

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

