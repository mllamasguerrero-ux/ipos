
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
    public class Formapago : EntityBaseGenericCatalog
    {


        public Formapago() : base()
        {
        }


        [Column(TypeName = "char(1)")]
        public BoolCN Esefectivo { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCS Abona { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Afectasaldopersona { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCN Afectasaldoapartados { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCS Afectasaldocorte { get; set; } = BoolCS.S;


        public int? Sentidoabonopago { get; set; }

    public int? Sentidoabono { get; set; }


  }
}

