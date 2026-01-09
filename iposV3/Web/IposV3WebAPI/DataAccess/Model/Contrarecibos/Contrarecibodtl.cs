
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
    public class Contrarecibodtl : EntityBaseExt
    {


        public Contrarecibodtl() : base()
        {
        }

        public Contrarecibodtl(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Contrarecibodtl(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.DoctoserieLength)]
    public string? Serie { get; set; }

    [StringLength(Domains.DoctoserieLength)]
    public string? Seriesat { get; set; }


    public long? Contrareciboid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Contrareciboid")]
        public virtual Contrarecibohdr? Contrarecibo { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechavence { get; set; }

    public int? Folio { get; set; }

    public int? Foliosat { get; set; }

        public long? Estatusid { get; set; }
        [ForeignKey("Estatusid")]
        public virtual Estatusdocto? Estatus { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totaldocto { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abonodocto { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldodocto { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abono { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;


    }
}

