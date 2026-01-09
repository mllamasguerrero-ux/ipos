
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
    public class Producto_utilidad : EntityBaseExt
    {


        public Producto_utilidad() : base()
        {
        }

        public Producto_utilidad(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_utilidad(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Minutilidad { get; set; } = 0;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcutilprecio1 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcutilprecio2 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcutilprecio3 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcutilprecio4 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcutilprecio5 { get; set; } = 0m;


  }
}

