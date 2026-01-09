
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
    public class Corte_calculo_formapago : EntityBaseExt
    {


        public Corte_calculo_formapago() : base()
        {
        }

        public Corte_calculo_formapago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Corte_calculo_formapago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Corte_calculoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corte_calculoid")]
        public virtual Corte_calculos? Corte_calculo { get; set; }

        public short? Sentido { get; set; }

        public long? Formapagoid { get; set; }
        [ForeignKey("Formapagoid")]
        public virtual Formapago? Formapago { get; set; }



  }
}

