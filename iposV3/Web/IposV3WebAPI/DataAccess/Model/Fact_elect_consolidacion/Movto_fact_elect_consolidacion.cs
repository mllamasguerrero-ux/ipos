
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
    public class Movto_fact_elect_consolidacion : EntityBaseExt
    {


        public Movto_fact_elect_consolidacion() : base()
        {
        }

        public Movto_fact_elect_consolidacion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_fact_elect_consolidacion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_subtotal { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_iva { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_ieps { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_total { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_iva_ret { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_isr_ret { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

