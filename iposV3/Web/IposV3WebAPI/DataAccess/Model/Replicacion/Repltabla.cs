
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
    public class Repltabla : EntityBaseExt
    {


        public Repltabla() : base()
        {
        }

        public Repltabla(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Repltabla(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Replcondinsert { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Replcondupdate { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Replconddelete { get; set; }


    public long? Replidinicio { get; set; }

    public long? Replidfin { get; set; }


  }
}

