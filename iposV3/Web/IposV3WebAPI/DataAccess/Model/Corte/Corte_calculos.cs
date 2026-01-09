
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
    public class Corte_calculos : EntityBaseExt
    {


        public Corte_calculos() : base()
        {
        }

        public Corte_calculos(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Corte_calculos(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }

        public long? Corte_calculo_def_id { get; set; }
        [ForeignKey("Corte_calculo_def_id")]
        public virtual Corte_calculo_def? Corte_calculo_def { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;


  }
}

