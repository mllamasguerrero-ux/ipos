
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
    public class Cliente_precio : EntityBaseExt
    {


        public Cliente_precio() : base()
        {
        }

        public Cliente_precio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_precio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Listaprecioid { get; set; }
        [ForeignKey("Listaprecioid")]
        public virtual Tipoprecio? Listaprecio { get; set; }

        public long? Superlistaprecioid { get; set; }
        [ForeignKey("Superlistaprecioid")]
        public virtual Tipoprecio? Superlistaprecio { get; set; }

        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Mayoreoxproducto { get; set; } = BoolCN.N;


    }
}

