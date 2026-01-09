
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
    public class Cliente_pago : EntityBaseExt
    {


        public Cliente_pago() : base()
        {
        }

        public Cliente_pago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_pago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoapartadonegativo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoapartadopositivo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldospositivos { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldosnegativos { get; set; } = 0m;

        public DateTimeOffset? Ultimaventa { get; set; }


  }
}

