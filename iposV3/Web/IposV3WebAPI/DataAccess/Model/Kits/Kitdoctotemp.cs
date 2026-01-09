
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
    public class Kitdoctotemp : EntityBaseExt
    {


        public Kitdoctotemp() : base()
        {
        }

        public Kitdoctotemp(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Kitdoctotemp(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Productokitid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productokitid")]
        public virtual Producto? Productokit { get; set; }

        public long? Origenfiscalid { get; set; }
        [ForeignKey("Origenfiscalid")]
        public virtual Origenfiscal? Origenfiscal { get; set; }

        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }


        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

