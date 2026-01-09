
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
    public class Monedero : EntityBaseExt
    {


        public Monedero() : base()
        {
        }

        public Monedero(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Monedero(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldo { get; set; } = 0m;

    public DateTimeOffset? Vigencia { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Perdido { get; set; } = 0m;


  }
}

