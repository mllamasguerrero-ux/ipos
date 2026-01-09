
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
    public class Productoalmacen : EntityBaseExt
    {


        public Productoalmacen() : base()
        {
        }

        public Productoalmacen(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Productoalmacen(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Productoclave { get; set; }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Enprocesodesalida { get; set; } = 0m;


  }
}

