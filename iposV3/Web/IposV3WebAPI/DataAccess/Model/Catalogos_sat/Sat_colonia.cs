
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
    public class Sat_colonia : EntityBaseGenericPseudoCatalog
    {


        public Sat_colonia() : base()
        {
        }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Colonia { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Codigopostal { get; set; }


        [StringLength(Domains.Stdtext_largeLength)]
        public new string? Nombre { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return (Colonia ?? "") + (Codigopostal != null ? "-" +  Codigopostal : ""); }
            set { Colonia = value; }
        }


    }
}

