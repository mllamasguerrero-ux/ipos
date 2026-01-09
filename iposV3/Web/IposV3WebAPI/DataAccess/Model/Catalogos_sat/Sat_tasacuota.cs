
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
    public class Sat_tasacuota : EntityBaseGenericPseudoCatalog
    {


        public Sat_tasacuota() : base()
        {
        }




    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_rangofijo { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_impuesto { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_factor { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_traslado { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_retencion { get; set; }

        
    [Column(TypeName = Domains.NumericSatDomain)]
    public decimal? Sat_valorminimo { get; set; }

    [Column(TypeName = Domains.NumericSatDomain)]
    public decimal? Sat_valormaximo { get; set; }

    public DateTimeOffset? Sat_fechainicio { get; set; }

    public DateTimeOffset? Sat_fechafin { get; set; }


        [NotMapped]
        public override string Clave
        {
            get { return Sat_rangofijo ?? ""; }
            set { Sat_rangofijo = value; }
        }
        [NotMapped]
        public override string Nombre
        {
            get { return Sat_impuesto ?? ""; }
            set { Sat_impuesto = value; }
        }


    }
}

