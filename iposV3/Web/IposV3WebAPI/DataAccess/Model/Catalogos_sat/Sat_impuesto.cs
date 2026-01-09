
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
    public class Sat_impuesto : EntityBaseGenericPseudoCatalog
    {


        public Sat_impuesto() : base()
        {
        }




    [StringLength(Domains.ClaveLength)]
    public string? Sat_clave { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_descripcion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_retencion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_traslado { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_localfederal { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sat_entidadaplica { get; set; }




  }
}

