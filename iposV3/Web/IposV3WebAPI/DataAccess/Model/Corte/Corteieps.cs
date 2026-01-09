
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
    public class Corteieps : EntityBaseExt
    {


        public Corteieps() : base()
        {
        }

        public Corteieps(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Corteieps(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaieps { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;


  }
}

