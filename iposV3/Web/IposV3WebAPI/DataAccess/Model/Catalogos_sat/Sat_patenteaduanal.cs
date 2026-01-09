
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
    public class Sat_patenteaduanal : EntityBaseGenericPseudoCatalog
    {


        public Sat_patenteaduanal() : base()
        {
        }



        public int Sat_clave { get; set; } = 0;

    public DateTimeOffset? Sat_fechainicio { get; set; }

    public DateTimeOffset? Sat_fechafin { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return Sat_clave.ToString() ?? ""; }
            set { Sat_clave = int.Parse(value); }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_clave.ToString() ?? ""; }
            set { Sat_clave = int.Parse(value); }
        }


    }
}

