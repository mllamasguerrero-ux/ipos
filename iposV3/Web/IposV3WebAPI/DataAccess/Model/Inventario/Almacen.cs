
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
    public class Almacen : EntityBaseExt
    {


        public Almacen() : base()
        {
        }

        public Almacen(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Almacen(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Esprincipal { get; set; } = BoolCS.S;



  }
}

