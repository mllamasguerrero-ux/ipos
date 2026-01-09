
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
    public class Movto : EntityBaseExt
    {


        public Movto() : base()
        {
        }

        public Movto(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        [StringLength(Domains.LoteLength)]
        public string? Lote { get; set; }

        [Column(TypeName = "char(1)")] 
        public BoolCS Afectainventario { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Afectatotales { get; set; } = BoolCS.S;


        [Column(TypeName = "char(1)")]
        public BoolCN Eskit { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Kitimpfijo { get; set; } = BoolCN.N;


        public int Partida { get; set; } = 0;

        public long? Estatusmovtoid { get; set; }
        [ForeignKey("Estatusmovtoid")]
        public virtual Estatusmovto? Estatusmovto { get; set; }


        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciolista { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentoporcentaje { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Descuento { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Subtotal { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Iva { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps { get; set; } = 0m;

        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaiva { get; set; } = 0m;

        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaieps { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;

        public DateTimeOffset? Fechavence { get; set; }

    public long? Loteimportado { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Loteimportado")]
        public virtual Lotesimportados? Loteimportado_ { get; set; }

        public long? Movtoparentid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoparentid")]
        public virtual Movto? Movtoparent { get; set; }

        public int Movtonivel { get; set; } = 0;

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Cargo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abono { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciomanual { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciomaximopublico { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Isrretenido { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ivaretenido { get; set; } = 0m;

        public int Orden { get; set; } = 0;

        
        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaisrretenido { get; set; } = 0m;

        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaivaretenido { get; set; } = 0m;




        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }

        public virtual Movto_comision? Movto_comision { get; set; }
        public virtual Movto_comodin? Movto_comodin { get; set; }
        public virtual Movto_cancelacion? Movto_cancelacion { get; set; }
        public virtual Movto_devolucion? Movto_devolucion { get; set; }
        public virtual Movto_loteimportado? Movto_loteimportado { get; set; }
        public virtual Movto_emida? Movto_emida { get; set; }
        public virtual Movto_fact_elect_consolidacion? Movto_fact_elect_consolidacion { get; set; }
        public virtual Movto_inventario? Movto_inventario { get; set; }
        public virtual Movto_kit? Movto_kit { get; set; }

        public virtual ICollection<Movto_kit_def>? Movto_kit_defs { get; set; }
        public virtual Movto_monedero? Movto_monedero { get; set; }
        public virtual Movto_ordencompra? Movto_ordencompra { get; set; }
        public virtual Movto_origenfiscal? Movto_origenfiscal { get; set; }
        public virtual Movto_poliza? Movto_poliza { get; set; }
        public virtual Movto_precio? Movto_precio { get; set; }
        public virtual Movto_promocion? Movto_promocion { get; set; }
        public virtual Movto_rebajaespecial? Movto_rebajaespecial { get; set; }
        public virtual Movto_revision? Movto_revision { get; set; }
        public virtual Movto_surtido? Movto_surtido { get; set; }
        public virtual Movto_traslado? Movto_traslado { get; set; }
        public virtual Movto_utilidad? Movto_utilidad { get; set; }
        public virtual Movto_ventafuturo? Movto_ventafuturo { get; set; }


        public static void ConfigureEntity(EntityTypeBuilder<Movto> modelBuilder)
        {



            modelBuilder
                .HasOne(c => c.Movto_cancelacion)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_devolucion)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_fact_elect_consolidacion)
                .WithOne(e => e.Movto);


            modelBuilder
                .HasOne(c => c.Movto_kit)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_ordencompra)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_poliza)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_traslado)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_promocion)
                .WithOne(e => e.Movto);

            modelBuilder
                .HasOne(c => c.Movto_ventafuturo)
                .WithOne(e => e.Movto);



        }

    }
}

