
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
    public class Ttlcontrol : EntityBaseExt
    {


        public Ttlcontrol() : base()
        {
        }

        public Ttlcontrol(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Ttlcontrol(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public DateTimeOffset? Fecha_ttl_prod_tipo_mes { get; set; }

    public DateTimeOffset? Fecha_ttl_docto_pers_mes { get; set; }


  }
}

