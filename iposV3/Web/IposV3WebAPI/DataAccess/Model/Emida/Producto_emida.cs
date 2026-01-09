
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
    public class Producto_emida : EntityBaseExt
    {


        public Producto_emida() : base()
        {
        }

        public Producto_emida(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_emida(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.NombreLength)]
    public string? Emidaid { get; set; }


    public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public long? Emidaproductoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Emidaproductoid")]
        public virtual Emidaproduct? Emidaproducto { get; set; }

        


    }
}

