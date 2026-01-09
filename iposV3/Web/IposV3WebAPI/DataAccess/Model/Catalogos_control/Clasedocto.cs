
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
    public class Clasedocto : EntityBaseGenericCatalog
    {


        public Clasedocto() : base()
        {
        }





        [StringLength(Domains.ClaveLength)]
        public string Clavesis { get; set; } = "";

        [Column(TypeName = "char(1)")]
        public BoolCN Escompra { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Esventa { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Estraslado { get; set; } = BoolCN.N;


    }
}

