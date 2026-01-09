
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
    public class Subtipocliente : EntityBaseGenericCatalog
    {


        public Subtipocliente() : base()
        {
        }



        [StringLength(Domains.DescripcionLength)]
        public string? Descripcion { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esmostrador { get; set; } = BoolCN.N;



  }
}

