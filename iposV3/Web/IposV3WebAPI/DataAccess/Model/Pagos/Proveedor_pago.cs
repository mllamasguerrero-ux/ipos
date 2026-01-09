
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
    public class Proveedor_pago : EntityBaseExt
    {


        public Proveedor_pago() : base()
        {
        }

        public Proveedor_pago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Proveedor_pago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldospositivos { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldosnegativos { get; set; } = 0m;

        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }


    }
}

