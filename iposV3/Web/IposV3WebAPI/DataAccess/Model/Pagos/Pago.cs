
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
    public class Pago : EntityBaseExt
    {


        public Pago() : base()
        {
        }

        public Pago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Pago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_lightLength)]
    public string? Referenciabancaria { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Notas { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Aplicado { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Cuentapagocredito { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Revertido { get; set; } = BoolCN.N;


        public long? Formapagoid { get; set; }
        [ForeignKey("Formapagoid")]
        public virtual Formapago? Formapago { get; set; }

        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

    public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importerecibido { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importecambio { get; set; } = 0m;

    public long? Tipopagoid { get; set; }
        [ForeignKey("Tipopagoid")]
        public virtual Tipopago? Tipopago { get; set; }

        public long? Estatuspagoid { get; set; }

        [ForeignKey("Estatuspagoid")]
        public virtual Estatuspago? Estatuspago { get; set; }

        public long? Bancoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Bancoid")]
        public virtual Banco? Banco { get; set; }

        public DateTimeOffset? Fechaelaboracion { get; set; }

    public DateTimeOffset? Fecharecepcion { get; set; }

    public long? Pagoparentid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoparentid")]
        public virtual Pago? Pagoparent { get; set; }

        public long? Formapagosatid { get; set; }
        [ForeignKey("Formapagosatid")]
        public virtual Formapagosat? Formapagosat { get; set; }

        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }

        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }


        public int? Sentidopago { get; set; }

    public int? Folio { get; set; }

    public DateTimeOffset? Fechaaplicado { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comision { get; set; } = 0m;

    public long? Cuentabancoempresaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cuentabancoempresaid")]
        public virtual Cuentabanco? Cuentabancoempresa { get; set; }

        public long? Reciboelectronicoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Reciboelectronicoid")]
        public virtual Docto? Reciboelectronico { get; set; }


        public long? Pagosatid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagosatid")]
        public virtual Pagosat? Pagosat { get; set; }


        public virtual Pago_bancomer? Pago_bancomer { get; set; }

        //public virtual ICollection<Pago_pago>? Pago_pagos { get; set; }

        
        [StringLength(Domains.Stdtext_shortLength)]
        public string? Refinterno { get; set; }


        public virtual ICollection<Doctopago>? Doctopagos { get; set; }



        [NotMapped]
        public string? Clave { get { return ""; } set { } }

        [NotMapped]
        public string? Nombre { get { return ""; } set { } }


        public static void ConfigureEntity(EntityTypeBuilder<Pago> modelBuilder)
        {


            //modelBuilder
            //    .HasMany(c => c.Pago_pagos)
            //    .WithOne(e => e.Pago1);


        }
    }
}

