
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
    public class Cliente_rutaembarque : EntityBaseExt
    {


        public Cliente_rutaembarque() : base()
        {
        }

        public Cliente_rutaembarque(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_rutaembarque(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Rutaembarqueid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Rutaembarqueid")]
        public virtual Rutaembarque? Rutaembarque { get; set; }

        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }


    }
}

