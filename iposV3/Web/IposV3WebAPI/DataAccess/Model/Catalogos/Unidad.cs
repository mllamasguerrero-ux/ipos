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
    public class Unidad : EntityBaseExt
    {



        public Unidad() : base()
        {
        }

        public Unidad(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Unidad(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";




        public short CantidadDecimales { get; set; }

        public long? Sat_unidadmedidaid { get; set; }
        [ForeignKey("Sat_unidadmedidaid")]
        public virtual Sat_unidadmedida? Sat_unidadmedida { get; set; }

    }
}
