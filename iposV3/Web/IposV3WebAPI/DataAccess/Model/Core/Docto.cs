
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
    public class Docto : EntityBaseExt
    {


        public Docto() : base()
        {
        }

        public Docto(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.DoctoserieLength)]
    public string? Serie { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esapartado { get; set; } = BoolCN.N;


    [StringLength(Domains.ReferenciaLength)]
    public string? Referencia { get; set; }

    [StringLength(Domains.DescripcionLength)]
    public string? Referencias { get; set; }



        public long? Estatusdoctoid { get; set; }

        [ForeignKey(" Estatusdoctoid")]
        public virtual Estatusdocto? Estatusdocto { get; set; }



        public long? Usuarioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }



        public long? Corteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }


        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

    public int? Folio { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Descuento { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Subtotal { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Iva { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Cargo { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abono { get; set; } = 0;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0;


        public long? Cajaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cajaid")]
        public virtual Caja? Caja { get; set; }

        public long? Almacenid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }

        public long? Origenfiscalid { get; set; }
        [ForeignKey("Origenfiscalid")]
        public virtual Origenfiscal? Origenfiscal { get; set; }

        public long? Doctoparentid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoparentid")]
        public virtual Docto? Doctoparent { get; set; }

        public long? Clienteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }

        public long? Tipodoctoid { get; set; }
        [ForeignKey("Tipodoctoid")]
        public virtual Tipodocto? Tipodocto { get; set; }

        public long? Proveedorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }


        public long? Sucursal_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }

        public long? Subtipodoctoid { get; set; }
        [ForeignKey("Subtipodoctoid")]
        public virtual Subtipodocto? Subtipodocto { get; set; }




        public long? Tipodiferenciainventarioid { get; set; }
        [ForeignKey("Tipodiferenciainventarioid")]
        public virtual Tipodiferenciainventario? Tipodiferenciainventario { get; set; }


        [NotMapped]
        public string? Clave { get; set; }

        [NotMapped]
        public string? Nombre { get; set; }

        public DateTimeOffset? Fechavence { get; set; }


        public virtual Docto_alerta? Docto_alerta { get; set; }
        public virtual Docto_apartado? Docto_apartado { get; set; }
        public virtual Docto_bancomer? Docto_bancomer { get; set; }
        public virtual Docto_cobranza? Docto_cobranza { get; set; }
        public virtual Docto_comision? Docto_comision { get; set; }
        public virtual Docto_compra? Docto_compra { get; set; }
        public virtual Docto_contrarecibo? Docto_contrarecibo { get; set; }
        public virtual Docto_cancelacion? Docto_cancelacion { get; set; }
        public virtual Docto_devolucion? Docto_devolucion { get; set; }

        public virtual ICollection<Docto_impuestos>? Docto_impuestos { get; set; }
        public virtual Docto_loteimportado? Docto_loteimportado { get; set; }
        public virtual Docto_corte? Docto_corte { get; set; }
        public virtual Docto_fact_elect? Docto_fact_elect { get; set; }
        public virtual Docto_fact_elect_consolidacion? Docto_fact_elect_consolidacion { get; set; }
        public virtual Docto_fact_elect_pagos? Docto_fact_elect_pagos { get; set; }
        public virtual Docto_fact_elect_sustitucion? Docto_fact_elect_sustitucion { get; set; }
        public virtual Docto_farmacia? Docto_farmacia { get; set; }
        public virtual Docto_guia? Docto_guia { get; set; }
        public virtual Docto_kit? Docto_kit { get; set; }
        public virtual Docto_monedero? Docto_monedero { get; set; }
        public virtual Docto_ordencompra? Docto_ordencompra { get; set; }
        public virtual Docto_origenfiscal? Docto_origenfiscal { get; set; }
        public virtual Docto_info_pago? Docto_info_pago { get; set; }
        public virtual Docto_poliza? Docto_poliza { get; set; }
        public virtual Docto_precio? Docto_precio { get; set; }
        public virtual Docto_promocion? Docto_promocion { get; set; }
        public virtual Docto_rebajaespecial? Docto_rebajaespecial { get; set; }
        public virtual Docto_revision? Docto_revision { get; set; }
        public virtual Docto_rutaembarque? Docto_rutaembarque { get; set; }
        public virtual Docto_serviciodomicilio? Docto_serviciodomicilio { get; set; }
        public virtual Docto_surtido? Docto_surtido { get; set; }
        public virtual Docto_traslado? Docto_traslado { get; set; }
        public virtual Docto_utilidad? Docto_utilidad { get; set; }
        public virtual Docto_ventafuturo? Docto_ventafuturo { get; set; }



        //Archivosadjuntos


        public virtual ICollection<Doctonota>? Docto_notas { get; set; }
        public virtual ICollection<Doctocomprobante>? Docto_comprobantes { get; set; }

        public virtual ICollection<Doctopago> Doctopagos { get; set; }

        public static void ConfigureEntity(EntityTypeBuilder<Docto> modelBuilder)
        {



            modelBuilder
                .HasOne(c => c.Docto_cancelacion)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_devolucion)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_fact_elect_consolidacion)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_fact_elect_sustitucion)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_kit)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_ordencompra)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_poliza)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_traslado)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasOne(c => c.Docto_ventafuturo)
                .WithOne(e => e.Docto);


            modelBuilder
                .HasMany(c => c.Docto_impuestos)
                .WithOne(e => e.Docto);


            modelBuilder
                .HasMany(c => c.Docto_notas)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasMany(c => c.Docto_comprobantes)
                .WithOne(e => e.Docto);

            modelBuilder
                .HasMany(c => c.Doctopagos)
                .WithOne(e => e.Docto);

        }

    }
}

