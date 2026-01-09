
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
    public class Estadopais : EntityBaseGenericCatalog
    {


        public Estadopais() : base()
        {
        }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Acronimo { get; set; }



    }
}

