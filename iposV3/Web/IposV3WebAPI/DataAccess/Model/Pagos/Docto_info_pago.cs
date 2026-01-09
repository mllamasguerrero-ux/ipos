
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
    public class Docto_info_pago : EntityBaseExt
    {


        public Docto_info_pago() : base()
        {
        }

        public Docto_info_pago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_info_pago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Notapago { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Hatenidocredito { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Pagoacredito { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public TipoPagoConTarjeta? Pagocontarjeta { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abononoaplicado { get; set; } = 0m;

    public long? Pagodevid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagodevid")]
        public virtual Pago? Pagodev { get; set; }

        public long? Estatusanticipoid { get; set; }

        [ForeignKey("Estatusanticipoid")]
        public virtual Estatuspago? Estatusanticipo { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totalanticipo { get; set; } = 0m;

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comisionpagotarjeta { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comisiontarjetaempresa { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ivacomisiontarjetaempresa { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Abonotarjeta { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comisiondebtarjetaempresa { get; set; } = 0m;


    }
}

