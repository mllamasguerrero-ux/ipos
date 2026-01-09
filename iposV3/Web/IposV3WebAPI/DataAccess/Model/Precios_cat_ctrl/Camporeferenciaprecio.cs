
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
    public class Camporeferenciaprecio : EntityBaseGenericCatalog
    {


        public Camporeferenciaprecio() : base()
        {
        }





        [Column(TypeName = "char(1)")]
        public BoolCN Listacliente { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Listatraslado { get; set; } = BoolCN.N;



    }
}

