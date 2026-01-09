
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
    public class Sat_tipofactor : EntityBaseGenericPseudoCatalog
    {


        public Sat_tipofactor() : base()
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Sat_clave { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return Sat_clave ?? ""; }
            set { Sat_clave = value; }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_clave ?? ""; }
            set { Sat_clave = value; }
        }


    }
}

