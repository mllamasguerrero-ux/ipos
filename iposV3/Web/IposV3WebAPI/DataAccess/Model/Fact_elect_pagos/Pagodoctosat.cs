
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Pagodoctosat : EntityBaseExt
    {


        public Pagodoctosat() : base()
        {
        }

        public Pagodoctosat(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Pagodoctosat(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Iddocumento { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Serie { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Folio { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Monedadr { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Tipocambiodr { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Metododepagodr { get; set; }


    public long? Doctopagoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctopagoid")]
        public virtual Doctopago? Doctopago { get; set; }

        public long? Pagosatid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagosatid")]
        public virtual Pagosat? Pagosat { get; set; }

        public int? Numparcialidad { get; set; }



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Impsaldoant { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Imppagado { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Impsaldoinsoluto { get; set; } = 0m;


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Objetoimpdr { get; set; }

        public virtual ICollection<Pagodoctosat_imp>? Pagodoctosat_imps { get; set; }



        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


        public static void ConfigureEntity(EntityTypeBuilder<Pagodoctosat> modelBuilder)
        {
            modelBuilder
                .HasMany(c => c.Pagodoctosat_imps)
                .WithOne(e => e.Pagodoctosat);
        }

    }
}

