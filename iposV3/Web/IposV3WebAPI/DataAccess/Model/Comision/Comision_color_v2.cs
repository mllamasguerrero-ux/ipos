
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
    public class Comision_color_v2 : EntityBaseExt
    {


        public Comision_color_v2() : base()
        {
        }

        public Comision_color_v2(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Comision_color_v2(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Proveedorclave { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Color { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Margenmin { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Margenmax { get; set; } = 0m;


    }
}

