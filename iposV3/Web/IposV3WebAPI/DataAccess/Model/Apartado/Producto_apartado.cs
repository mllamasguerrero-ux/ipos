
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
    public class Producto_apartado : EntityBaseExt
    {


        public Producto_apartado() : base()
        {
        }

        public Producto_apartado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_apartado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Productoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciafacturadoapartado { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciaremisionadoapartado { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciaindefinidoapartado { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciaapartado { get; set; } = 0m;


    }
}

