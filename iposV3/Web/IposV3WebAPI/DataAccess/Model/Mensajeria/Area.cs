
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
    public class Area : EntityBaseExt
    {


        public Area() : base()
        {
        }

        public Area(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Area(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.NombreLength)]
    public string? Nombrearea { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    //public long? Idarea { get; set; }


  }
}

