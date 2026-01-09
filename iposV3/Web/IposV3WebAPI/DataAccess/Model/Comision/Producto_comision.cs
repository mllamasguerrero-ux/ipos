
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
    public class Producto_comision : EntityBaseExt
    {


        public Producto_comision() : base()
        {
        }

        public Producto_comision(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_comision(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comision { get; set; } = 0m;


  }
}

