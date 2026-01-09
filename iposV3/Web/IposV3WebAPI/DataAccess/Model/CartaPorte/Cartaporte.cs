
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Cartaporte : EntityBaseExt
    {


        public Cartaporte() : base()
        {
        }

        public Cartaporte(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cartaporte(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? TranspInternac { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? EntradaSalidaMerc { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? PaisOrigenDestino { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? ViaEntradaSalida { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? TotalDistRec { get; set; }


        [NotMapped]
        public string? Clave { get { return ""; } set { } }

        [NotMapped]
        public string? Nombre { get { return ""; } set { } }



        public virtual CartaporteAutotransp? CartaporteAutotransps { get; set; }
        public virtual CartaporteCanttransp? CartaporteCanttransps { get; set; }
        public virtual ICollection<CartaporteMercancia>? CartaporteMercancias { get; set; }
        public virtual CartaporteTotalmercancias? CartaporteTotalmercancias { get; set; }
        public virtual ICollection<CartaporteTransptipofigura>? CartaporteTransptipofiguras { get; set; }
        public virtual ICollection<CartaporteUbicacion>? CartaporteUbicacions { get; set; }


        public static void ConfigureEntity(EntityTypeBuilder<Cartaporte> modelBuilder)
        {
            ConfigureEntityBaseKey(modelBuilder);

            modelBuilder
                .HasOne(c => c.CartaporteAutotransps)
                .WithOne(e => e.Cartaporte);

            modelBuilder
                .HasOne(c => c.CartaporteCanttransps)
                .WithOne(e => e.Cartaporte);

            modelBuilder
                .HasMany(c => c.CartaporteMercancias)
                .WithOne(e => e.Cartaporte);

            modelBuilder
                .HasOne(c => c.CartaporteTotalmercancias)
                .WithOne(e => e.Cartaporte);

            modelBuilder
                .HasMany(c => c.CartaporteTransptipofiguras)
                .WithOne(e => e.Cartaporte);

            modelBuilder
                .HasMany(c => c.CartaporteUbicacions)
                .WithOne(e => e.Cartaporte);
        }


    }
}

