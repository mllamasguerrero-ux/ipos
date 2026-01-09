
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
    public class Docto_precio : EntityBaseExt
    {


        public Docto_precio() : base()
        {
        }

        public Docto_precio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_precio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Tipomayoreoid { get; set; }
        [ForeignKey("Tipomayoreoid")]
        public virtual Tipomayoreo? Tipomayoreo { get; set; }

        public long? Tipodescuentovale { get; set; }
        [ForeignKey("Tipodescuentovale")]
        public virtual Tipodescuentovale? Tipodescuentovale_ { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

