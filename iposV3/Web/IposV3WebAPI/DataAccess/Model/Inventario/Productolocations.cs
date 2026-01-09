
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
    public class Productolocations : EntityBaseExt
    {


        public Productolocations() : base()
        {
        }

        public Productolocations(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Productolocations(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.LocacionLength)]
    public string? Localidad { get; set; }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public long? Anaquelid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Anaquelid")]
        public virtual Anaquel? Anaquel { get; set; }

        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }


    }
}

