
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
    public class Replgroup : EntityBaseExt
    {


        public Replgroup() : base()
        {
        }

        public Replgroup(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Replgroup(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Idgroupdef { get; set; }
        [ForeignKey("Idgroupdef")]
        public virtual Replgroupdef? Groupdef { get; set; }


    }
}

