
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
    public class Sat_municipio : EntityBaseGenericPseudoCatalog
    {


        public Sat_municipio() : base()
        {
        }





        [StringLength(Domains.Stdtext_shortLength)]
        public string? Clave_municipio { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Clave_estado { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Descripcion { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return (Clave_municipio ?? "") + (Clave_estado != null ? "-" + Clave_estado : ""); }
            set { Clave_municipio = value; }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Descripcion ?? ""; }
            set { Descripcion = value; }
        }





    }
}

