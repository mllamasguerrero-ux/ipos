
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
    public class Docto_rutaembarque : EntityBaseExt
    {


        public Docto_rutaembarque() : base()
        {
        }

        public Docto_rutaembarque(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_rutaembarque(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Rutaembarqueid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Rutaembarqueid")]
        public virtual Rutaembarque? Rutaembarque { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

