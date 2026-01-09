
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
    public class Traza : EntityBaseExt
    {


        public Traza() : base()
        {
        }

        public Traza(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Traza(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Valor { get; set; }



  }
}

