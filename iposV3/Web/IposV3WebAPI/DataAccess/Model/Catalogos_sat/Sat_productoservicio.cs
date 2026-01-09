
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
    public class Sat_productoservicio : EntityBaseGenericPseudoCatalog
    {


        public Sat_productoservicio() : base()
        {
        }




    [StringLength(Domains.ClaveLength)]
    public string? Sat_claveprodserv { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Sat_descripcion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_ivatrasladado { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_iepstrasladado { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Sat_complemento { get; set; }


    public DateTimeOffset? Sat_fechainicio { get; set; }

    public DateTimeOffset? Sat_fechafin { get; set; }


        [NotMapped]
        public new string Clave { get { return Sat_claveprodserv ?? ""; } set { Sat_claveprodserv = value; } } 

        [NotMapped]
        public new string Nombre { get { return Sat_descripcion ?? "";  } set { Sat_descripcion = value; } } 


    }
}

