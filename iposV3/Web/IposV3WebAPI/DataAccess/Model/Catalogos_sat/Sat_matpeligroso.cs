
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
    public class Sat_matpeligroso : EntityBaseCatalogoSat
    {


        public Sat_matpeligroso() : base()
        {
        }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Clase { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Peligro_secundario { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Nombre_tecnico { get; set; }



  }
}

