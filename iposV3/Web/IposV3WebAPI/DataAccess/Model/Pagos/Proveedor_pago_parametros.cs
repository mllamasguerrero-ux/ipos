
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
    public class Proveedor_pago_parametros : EntityBaseExt
    {


        public Proveedor_pago_parametros() : base()
        {
        }

        public Proveedor_pago_parametros(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Proveedor_pago_parametros(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_lightLength)]
    public string? Revision { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Pagos { get; set; }


        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }


        public int? Dias { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Adescpes { get; set; } = 0m;


  }
}

