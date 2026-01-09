
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
    public class Clasifica : EntityBaseExt
    {


        public Clasifica() : base()
        {
        }

        public Clasifica(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Clasifica(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Clave_triLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }



  }
}

