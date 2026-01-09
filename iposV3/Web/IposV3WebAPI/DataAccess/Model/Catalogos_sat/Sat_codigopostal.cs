
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
    public class Sat_codigopostal : EntityBaseGenericPseudoCatalog
    {


        public Sat_codigopostal() : base()
        {
        }



    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_clave { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_estado { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_municipio { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_localidad { get; set; }


  }
}

