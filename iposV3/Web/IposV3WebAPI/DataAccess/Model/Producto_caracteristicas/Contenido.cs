
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
    public class Contenido : EntityBaseExt
    {


        public Contenido() : base()
        {
        }

        public Contenido(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Contenido(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Clave_uniLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }



  }
}

