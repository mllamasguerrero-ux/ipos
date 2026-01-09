
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
    public class Docto_utilidad : EntityBaseExt
    {


        public Docto_utilidad() : base()
        {
        }

        public Docto_utilidad(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_utilidad(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Utilidad { get; set; } = 0m;

    public long? Vendedorutilidadid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorutilidadid")]
        public virtual Usuario? Vendedorutilidad { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

