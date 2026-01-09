
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
    public class Facturaoriginalcompra : EntityBaseExt
    {


        public Facturaoriginalcompra() : base()
        {
        }

        public Facturaoriginalcompra(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Facturaoriginalcompra(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ReferenciaLength)]
    public string? Compra { get; set; }

    [StringLength(Domains.ReferenciaLength)]
    public string? Ordencompra { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Factura { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Provisionada { get; set; } = BoolCN.N;


        public long? Ordencompraid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Ordencompraid")]
        public virtual Docto? Ordencompra_ { get; set; }

        public long? Facturaestatus { get; set; }
        [ForeignKey("Facturaestatus")]
        public virtual Estatusdocto? Facturaestatus_ { get; set; }

        public DateTimeOffset? Fecharecepcion { get; set; }

    public DateTimeOffset? Fechafactura { get; set; }

        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Suma { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Iva { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps8 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps25 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps26 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps26c { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps30 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ieps53 { get; set; } = 0m;

    public int? Comprafolio { get; set; }

    public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }


    }
}

