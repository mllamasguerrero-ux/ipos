
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
    public class Sat_versioncatalogo : EntityBaseGenericPseudoCatalog
    {


        public Sat_versioncatalogo() : base()
        {
        }



        public DateTimeOffset? Fecha { get; set; }

        public long Version_catalogo { get; set; } = 0;


        [NotMapped]
        public override string Clave
        {
            get { return Version_catalogo.ToString() ?? ""; }
            set { Version_catalogo = long.Parse(value); }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Version_catalogo.ToString() ?? ""; }
            set { Version_catalogo = long.Parse(value); }
        }


    }
}

