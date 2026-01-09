
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
    public class Stockalmacen : EntityBaseExt
    {


        public Stockalmacen() : base()
        {
        }

        public Stockalmacen(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Stockalmacen(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockmin { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockmax { get; set; } = 0m;


  }
}

