
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
    public class Emidarespcode : EntityBaseExt
    {


        public Emidarespcode() : base()
        {
        }

        public Emidarespcode(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Emidarespcode(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.DescripcionLength)]
    public string? Descripcion { get; set; }

    [StringLength(Domains.DescripcionLength)]
    public string? Notas { get; set; }

    [StringLength(Domains.DescripcionLength)]
    public string? Mensajecliente { get; set; }


    public int? Codigo { get; set; }


  }
}

