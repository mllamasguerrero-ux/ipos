
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
    public class Menuitems : EntityBaseGeneric
    {


        public Menuitems() : base()
        {
        }




    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Etiqueta { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion { get; set; }


        public long? Parentid { get; set; }
        [ForeignKey("Parentid")]
        public virtual Menuitems? Parent { get; set; }

        public long? Derechoid { get; set; }
        [ForeignKey("Derechoid")]
        public virtual Derechos? Derecho { get; set; }

        public short Nivel { get; set; } = 0;

        public int Orden { get; set; } = 0;



  }
}

