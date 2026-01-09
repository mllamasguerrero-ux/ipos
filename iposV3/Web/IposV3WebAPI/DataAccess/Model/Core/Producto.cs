
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Producto : EntityBaseExt
    {

        public Producto() : base()
        {
        }

        public Producto(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";

        [StringLength(Domains.DescripcionLength)]
        public string Descripcion { get; set; } = "";

        [StringLength(Domains.ClaveLength)]
        public string? Ean { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descripcion1 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descripcion2 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descripcion3 { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string? Cbarras { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string? Cempaque { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string? Plug { get; set; }




        public long? Proveedor1id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedor1id")]
        public virtual Proveedor? Proveedor1 { get; set; }


        public long? Proveedor2id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedor2id")]
        public virtual Proveedor? Proveedor2 { get; set; }

        public long? Lineaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Lineaid")]
        public virtual Linea? Linea { get; set; }

        public long? Marcaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Marcaid")]
        public virtual Marca? Marca { get; set; }

        public long? Unidadid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Unidadid")]
        public virtual Unidad? Unidad { get; set; }


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Ivaimpuesto { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Iepsimpuesto { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Impuesto { get; set; } = 0m;


        public long? Substitutoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Substitutoid")]
        public virtual Producto? Substituto { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Imagen { get; set; }

        public virtual Producto_apartado? Producto_apartado { get; set; }
        public virtual Producto_comision? Producto_comision { get; set; }
        public virtual Producto_comodin? Producto_comodin { get; set; }
        public virtual Producto_loteimportado? Producto_loteimportado { get; set; }
        public virtual Producto_emida? Producto_emida { get; set; }
        public virtual Producto_fact_elect? Producto_fact_elect { get; set; }
        public virtual Producto_farmacia? Producto_farmacia { get; set; }
        public virtual Producto_existencia? Producto_existencia { get; set; }
        public virtual Producto_inventario? Producto_inventario { get; set; }
        public virtual Producto_kit? Producto_kit { get; set; }
        public virtual Producto_origenfiscal? Producto_origenfiscal { get; set; }
        public virtual Producto_poliza? Producto_poliza { get; set; }
        public virtual Producto_precios? Producto_precios { get; set; }
        public virtual Producto_promocion? Producto_promocion { get; set; }
        public virtual Producto_miscelanea? Producto_miscelanea { get; set; }
        public virtual Producto_padre? Producto_padre { get; set; }
        public virtual Producto_utilidad? Producto_utilidad { get; set; }
        public virtual Productocaracteristicas? Productocaracteristicas { get; set; }


        public virtual ICollection<Kitdefinicion>? KitDefinicionSet { get; set; }


        public virtual ICollection<Inventario>? Inventarios { get; set; }



        public static void ConfigureEntity(EntityTypeBuilder<Producto> modelBuilder)
        {
            modelBuilder
                .HasMany(c => c.KitDefinicionSet)
                .WithOne(k => k.Productokit);

            modelBuilder
                .HasOne(c => c.Producto_promocion)
                .WithOne(e => e.Producto);

            modelBuilder
                .HasOne(c => c.Producto_padre)
                .WithOne(e => e.Producto);


            modelBuilder
                .HasMany(c => c.Inventarios)
                .WithOne(k => k.Producto);


        }

    }
}

