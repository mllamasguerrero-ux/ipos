
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
    public class Producto_poliza : EntityBaseExt
    {


        public Producto_poliza() : base()
        {
        }

        public Producto_poliza(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_poliza(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        public long? Plazoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Plazoid")]
        public virtual Plazo? Plazo { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Cuentapredial { get; set; }



    }
}

