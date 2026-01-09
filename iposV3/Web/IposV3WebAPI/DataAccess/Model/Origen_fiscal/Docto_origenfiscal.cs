
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
    public class Docto_origenfiscal : EntityBaseExt
    {


        public Docto_origenfiscal() : base()
        {
        }

        public Docto_origenfiscal(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_origenfiscal(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.DoctoserieLength)]
    public string? Serieorigenfacturado { get; set; }


    public int? Folioorigenfacturado { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Montoorigenfacturado { get; set; } = 0m;

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

