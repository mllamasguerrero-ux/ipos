
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
    public class Kitsunnivel : EntityBaseExt
    {


        public Kitsunnivel() : base()
        {
        }

        public Kitsunnivel(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Kitsunnivel(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public long? Productokitid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productokitid")]
        public virtual Producto? Productokit { get; set; }

        public long? Productoparteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoparteid")]
        public virtual Producto? Productoparte { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadparte { get; set; } = 0m;


  }
}

