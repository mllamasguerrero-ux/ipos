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
    public class Tasaiva : EntityBaseGenericCatalog
    {
        public Tasaiva() : base()
        {
            Tasa = 0m;
        }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Tasa { get; set; } = 0m;

        public DateTimeOffset? Fechainicia { get; set; }
    }
}