
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
    public class Sat_pedimentos : EntityBaseGenericPseudoCatalog
    {


        public Sat_pedimentos() : base()
        {
        }




        [StringLength(Domains.Stdtext_shortLength)]
        public string Sat_cantidad { get; set; } = "";


        public int Sat_claveaduana { get; set; } = 0;

        public int Sat_patente { get; set; } = 0;

        public int Sat_ejercicio { get; set; } = 0;

        public DateTimeOffset? Sat_fechainicio { get; set; }

        public DateTimeOffset? Sat_fechafin { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return Sat_claveaduana.ToString() ?? ""; }
            set { Sat_claveaduana = int.Parse(value); }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_claveaduana.ToString() ?? ""; }
            set { Sat_claveaduana = int.Parse(value); }
        }


    }
}

