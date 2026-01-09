
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
    public class Contrarecibohdr : EntityBaseExt
    {


        public Contrarecibohdr() : base()
        {
        }

        public Contrarecibohdr(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Contrarecibohdr(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Observaciones { get; set; }


    public DateTimeOffset? Fecha { get; set; }

    public long? Personaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaid")]
        public virtual Cliente? Persona { get; set; }

        public long? Vendedorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorid")]
        public virtual Usuario? Vendedor { get; set; }

        public long? Estatusid { get; set; }
        [ForeignKey("Estatusid")]
        public virtual Estatusdocto? Estatus { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abono { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;

    public int? Folio { get; set; }

    public long? Estatuspagoid { get; set; }
        [ForeignKey("Estatuspagoid")]
        public virtual Estadopagocontrarecibo? Estatuspago { get; set; }


        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


    }
}

