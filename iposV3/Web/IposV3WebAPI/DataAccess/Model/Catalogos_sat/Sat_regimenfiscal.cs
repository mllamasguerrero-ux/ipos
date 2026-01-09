
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
    public class Sat_regimenfiscal : EntityBaseGenericPseudoCatalog
    {


        public Sat_regimenfiscal() : base()
        {
        }




    [StringLength(Domains.ClaveLength)]
    public string? Sat_clave { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Sat_description { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_personafisica { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_personamoral { get; set; }


    public DateTimeOffset? Sat_fechainicio { get; set; }

    public DateTimeOffset? Sat_fechafin { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return Sat_clave ?? ""; }
            set { Sat_clave = value; }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_description ?? ""; }
            set { Sat_description = value; }
        }


    }
}

