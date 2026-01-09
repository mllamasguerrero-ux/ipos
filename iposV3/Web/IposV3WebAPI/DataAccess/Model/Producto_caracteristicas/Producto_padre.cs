
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
    public class Producto_padre : EntityBaseExt
    {


        public Producto_padre() : base()
        {
        }

        public Producto_padre(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_padre(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Esproductopadre { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Essubproducto { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Tomarpreciopadre { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Tomarcomisionpadre { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Tomarofertapadre { get; set; } = BoolCN.N;


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        public long? Productopadreid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productopadreid")]
        public virtual Producto? Productopadre { get; set; }


    }
}

