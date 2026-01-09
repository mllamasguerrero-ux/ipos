
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
    public class Movto_kit_def : EntityBaseExt
    {


        public Movto_kit_def() : base()
        {
        }

        public Movto_kit_def(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_kit_def(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public long? Productokitid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productokitid")]
        public virtual Producto? Productokit { get; set; }

        public long? Productoparteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoparteid")]
        public virtual Producto? Productoparte { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadparte { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoparte { get; set; } = 0m;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadpartetotal { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precioporunidad { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaiva { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaieps { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montosubtotal { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montoiva { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montoieps { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montototal { get; set; } = 0m;


    }
}

