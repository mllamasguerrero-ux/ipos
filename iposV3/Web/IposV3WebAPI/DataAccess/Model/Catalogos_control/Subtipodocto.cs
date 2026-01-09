
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
    public class Subtipodocto : EntityBaseGenericCatalog
    {


        public Subtipodocto() : base()
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Saltar_verif_exist { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Forzar_verif_exist { get; set; } = BoolCN.N;


    }
}

