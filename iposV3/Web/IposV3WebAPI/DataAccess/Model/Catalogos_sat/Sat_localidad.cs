
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
    public class Sat_localidad : EntityBaseGenericPseudoCatalog
    {


        public Sat_localidad() : base()
        {
        }



        [StringLength(Domains.Stdtext_shortLength)]
        public string? Clave_localidad { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Clave_estado { get; set; }


        [StringLength(Domains.Stdtext_largeLength)]
        public string? Descripcion { get; set; }



        [NotMapped]
        public override string Clave
        {
            get { return (Clave_localidad ?? "") + (Clave_estado != null ? "-" + Clave_estado : ""); }
            set { Clave_localidad = value; }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Descripcion ?? ""; }
            set { Descripcion = value; }
        }



    }
}

