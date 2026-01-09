
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
    public class Ajustesiva : EntityBaseExt
    {


        public Ajustesiva() : base()
        {
        }

        public Ajustesiva(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Ajustesiva(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public DateTimeOffset? Fecha { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porc_a_iva { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaiva { get; set; } = 0m;


    }
}

