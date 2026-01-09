
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
    public class Tipodocto : EntityBaseGenericCatalog
    {


        public Tipodocto() : base()
        {
        }




        [StringLength(Domains.ClaveLength)]
        public string Clavesis { get; set; } = "";


        [Column(TypeName = "char(1)")]
        public BoolCN Hacereferencia { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Verif_exist { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Ensamblarkits { get; set; } = BoolCN.N;


        public short Sentidoinventario { get; set; } = 0;

        public short Sentidopago { get; set; } = 0;


        public long? Clasedoctoid { get; set; }
        [ForeignKey("Clasedoctoid")]
        public virtual Clasedocto? Clasedocto { get; set; }


        public long? Tipodistloteimportadoid { get; set; }
        [ForeignKey("Tipodistloteimportadoid")]
        public virtual Tipodistloteimportado? Tipodistloteimportado { get; set; }


        public long? Tipodoctocancelacionid { get; set; }
        [ForeignKey("Tipodoctocancelacionid")]
        public virtual Tipodocto? Tipodoctocancelacion { get; set; }



        public short Sentidoinventarioapartados { get; set; } = 0;

        public short Sentidopagoapartados { get; set; } = 0;

        public short Sentidocostopromedio { get; set; } = 0;

        public short Sentidoabonocliente { get; set; } = 0;

        public short Sentidoabonoproveedor { get; set; } = 0;

        public short Sentidoabonomismocorte { get; set; } = 0;

        public short Sentidoabonootrocorte { get; set; } = 0;

        public short Sentidoenprocesosalida { get; set; } = 0;


    }
}

