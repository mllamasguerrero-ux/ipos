
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
    public class Tipolineapoliza : EntityBaseGenericCatalog
    {


        public Tipolineapoliza() : base()
        {
        }


        [Column(TypeName = "char(1)")]
        public BoolCN Sumarizado { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Manejatasa { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Manejaformapago { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Manejaesfact { get; set; } = BoolCN.N;


        public int? Orden { get; set; }

    public long? Tipoentrada { get; set; }


    }
}

