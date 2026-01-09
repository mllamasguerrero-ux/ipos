
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
    public class Sat_aduana : EntityBaseGenericPseudoCatalog
    {


        public Sat_aduana() : base()
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Sat_claveaduana { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Sat_descripcion { get; set; }

        [NotMapped]
        public override string Clave { get { return Sat_claveaduana ?? ""; } 
                                       set { Sat_claveaduana = value; } }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_descripcion ?? ""; }
            set { Sat_descripcion = value; }
        }


    }
}

