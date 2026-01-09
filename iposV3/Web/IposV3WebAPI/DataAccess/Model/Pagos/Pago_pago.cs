
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
    public class Pago_pago : EntityBaseExt
    {


        public Pago_pago() : base()
        {
        }

        public Pago_pago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Pago_pago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Pagoid1 { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoid1")]
        public virtual Pago? Pago1 { get; set; }

        public long? Pagoid2 { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoid2")]
        public virtual Pago? Pago2 { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;

    public long? Tiporelacionpagoid { get; set; }
        [ForeignKey("Tiporelacionpagoid")]
        public virtual Tiporelacionpago? Tiporelacionpago { get; set; }


    }
}

