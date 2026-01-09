
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
    public class Sat_pais : EntityBaseGenericPseudoCatalog
    {


        public Sat_pais() : base()
        {
        }




    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_clave { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Sat_descripcion { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Sat_formatocp { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Sat_formatorit { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_validacionrit { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_agrupaciones { get; set; }



        [NotMapped]
        public override string Clave
        {
            get { return Sat_clave ?? ""; }
            set { Sat_clave = value; }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_descripcion ?? ""; }
            set { Sat_descripcion = value; }
        }
    }
}

