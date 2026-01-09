
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
    public class Perfiles : EntityBaseExt
    {


        public Perfiles() : base()
        {
        }

        public Perfiles(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Perfiles(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion { get; set; }


        public virtual ICollection<Perfil_der>? Derechos { get; set; }



    }
}

