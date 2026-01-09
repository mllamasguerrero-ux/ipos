
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
    public class Formapagosat : EntityBaseGenericCatalog
    {


        public Formapagosat() : base()
        {
        }




        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_bancarizado { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_numoperacion { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_rfcemisorordenante { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_cuentaordenante { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Sat_patronordenante { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_rfcemisorbeneficiario { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_cuentabeneficiario { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Sat_patronbeneficiario { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Sat_tipocadenapago { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Sat_bancoemisor { get; set; }

        public long? Formapagoid { get; set; }
        [ForeignKey("Formapagoid")]
        public virtual Formapago? Formapago { get; set; }


    }
}

