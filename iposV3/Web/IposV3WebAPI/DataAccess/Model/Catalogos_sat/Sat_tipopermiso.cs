
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
    public class Sat_tipopermiso : EntityBaseCatalogoSat
    {


        public Sat_tipopermiso() : base()
        {
        }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Clavetransporte { get; set; }



  }
}

