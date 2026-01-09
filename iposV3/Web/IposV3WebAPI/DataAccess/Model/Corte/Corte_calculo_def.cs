
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
    public class Corte_calculo_def : EntityBaseGenericCatalog
    {


        public Corte_calculo_def() : base()
        {
        }



        [StringLength(Domains.NombreLength)]
        public new string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public new string Nombre { get; set; } = "";


        [StringLength(Domains.Stdtext_shortLength)]
    public string? Direccion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Mismocorte { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Traslado { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Concepto { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Reversionabono { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Montoocuenta { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Clasedoctocorte { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Importecambio { get; set; }


    public long? Tipodoctoid { get; set; }
        [ForeignKey("Tipodoctoid")]
        public virtual Tipodocto? Tipodocto { get; set; }

        public long? Formapagoid { get; set; }
        [ForeignKey("Formapagoid")]
        public virtual Formapago? Formapago { get; set; }


    }
}

