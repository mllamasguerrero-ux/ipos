
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
    public class Listapreciodetalle : EntityBaseExt
    {


        public Listapreciodetalle() : base()
        {
        }

        public Listapreciodetalle(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Listapreciodetalle(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Tienevig { get; set; } = BoolCN.N;


        public long? Listaprecioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Listaprecioid")]
        public virtual Listaprecio? Listaprecio { get; set; }


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

        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoreposicion { get; set; } = 0m;

    public DateTimeOffset? Fechavig { get; set; }


  }
}

