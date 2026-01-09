
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
    public class Bancomerconsecutivo : EntityBaseExt
    {


        public Bancomerconsecutivo() : base()
        {
        }

        public Bancomerconsecutivo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Bancomerconsecutivo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public DateTimeOffset? Fecha { get; set; }

        public long Consecutivo { get; set; } = 0;


  }
}

