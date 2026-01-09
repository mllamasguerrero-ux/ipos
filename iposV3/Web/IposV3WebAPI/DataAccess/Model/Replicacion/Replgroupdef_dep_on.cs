
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
    public class Replgroupdef_dep_on : EntityBaseExt
    {


        public Replgroupdef_dep_on() : base()
        {
        }

        public Replgroupdef_dep_on(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Replgroupdef_dep_on(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




    public long? Idgroupdef { get; set; }
        [ForeignKey("Idgroupdef")]
        public virtual Replgroupdef? Groupdef { get; set; }

        public long? Idgroupdef_dep_on { get; set; }
        [ForeignKey("Idgroupdef_dep_on")]
        public virtual Replgroupdef? Groupdef_dep_on { get; set; }


    }
}

