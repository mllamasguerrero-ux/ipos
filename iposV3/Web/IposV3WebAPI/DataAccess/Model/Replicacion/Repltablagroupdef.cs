
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
    public class Repltablagroupdef : EntityBaseGeneric
    {


        public Repltablagroupdef() : base()
        {
        }




    [StringLength(Domains.NombreLength)]
    public string? Nombretabla { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Replcondinsert { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Replcondupdate { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Replconddelete { get; set; }


    public long? Idgroupdef { get; set; }
        [ForeignKey("Idgroupdef")]
        public virtual Replgroupdef? Groupdef { get; set; }


    }
}

