
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
    public class Sat_claveunidadpeso : EntityBaseCatalogoSat
    {


        public Sat_claveunidadpeso() : base()
        {
        }


        [StringLength(Domains.Stdtext_mediumLength)]
        public new string? Nombre { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Simbolo { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Bandera { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nota { get; set; }




  }
}

