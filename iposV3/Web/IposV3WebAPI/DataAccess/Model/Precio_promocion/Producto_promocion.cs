
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
    public class Producto_promocion : EntityBaseExt
    {


        public Producto_promocion() : base()
        {
        }

        public Producto_promocion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_promocion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Esprodpromo { get; set; } = BoolCN.N;


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public long? Baseprodpromoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Baseprodpromoid")]
        public virtual Producto? Baseprodpromo { get; set; }

        public DateTimeOffset? Vigenciaprodpromo { get; set; }


  }
}

