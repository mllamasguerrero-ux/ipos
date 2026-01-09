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
    public class Tasaieps : EntityBaseGenericCatalog
    {
        public Tasaieps() : base()
        {

            Tasa = 0m;
        }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Tasa { get; set; } = 0m;

        public string? Gpoimp { get; set; }

        public DateTimeOffset? Ultimafecha { get; set; }

        public DateTimeOffset? Primerafecha { get; set; }
    }
}