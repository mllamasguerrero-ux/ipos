
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
    public class Producto_precios : EntityBaseExt
    {


        public Producto_precios() : base()
        {
        }

        public Producto_precios(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_precios(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Mayokgs { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Tipoabc { get; set; } = BoolCN.N;


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio1 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio2 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio3 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio4 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio5 { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precio6 { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoultimo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costopromedio { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costorepo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Superprecio1 { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Superprecio2 { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Superprecio3 { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Superprecio4 { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Superprecio5 { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Ini_mayo { get; set; }



        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Limiteprecio2 { get; set; }



        public long? Listaprecmediomayid { get; set; }

        [ForeignKey("Listaprecmediomayid")]
        public virtual Camporeferenciaprecio? Listaprecmediomay { get; set; }

        public long? Listaprecmayoreoid { get; set; }

        [ForeignKey("Listaprecmayoreoid")]
        public virtual Camporeferenciaprecio? Listaprecmayoreo { get; set; }



        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantmediomay { get; set; }

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantmayoreo { get; set; }






        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuento { get; set; } = 0;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Menudeo { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciomaximopublico { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoendolar { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciosugerido { get; set; } = 0m;


        [Column(TypeName = "char(1)")]
        public BoolCN Cambiarprecio { get; set; } = BoolCN.N;
        public DateTimeOffset? Fechacambioprecio { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Preciomat { get; set; } = BoolCN.N;




        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Oferta { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciotope { get; set; } = 0m;


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Desctope { get; set; } = 0;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Margen { get; set; } = 0;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descpes { get; set; } = 0;



        public long? Monedaid { get; set; }
        [ForeignKey("Monedaid")]
        public virtual Moneda? Moneda { get; set; }



    }
}

