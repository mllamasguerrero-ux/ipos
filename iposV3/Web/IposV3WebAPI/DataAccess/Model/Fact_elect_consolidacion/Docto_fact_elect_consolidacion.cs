
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
    public class Docto_fact_elect_consolidacion : EntityBaseExt
    {


        public Docto_fact_elect_consolidacion() : base()
        {
        }

        public Docto_fact_elect_consolidacion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_fact_elect_consolidacion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




        [Column(TypeName = "char(1)")]
        public BoolCN? Factconsaplicado { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Omitirvales { get; set; }


    public long? Factconsid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Factconsid")]
        public virtual Docto? Factcons { get; set; }

        public long? Devconsid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Devconsid")]
        public virtual Docto? Devcons { get; set; }

        public long? Doctorefid2 { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctorefid2")]
        public virtual Docto? Doctoref2 { get; set; }


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

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }



        public DateTimeOffset? Fecha_ini { get; set; }

        public DateTimeOffset? Fecha_fin { get; set; }


    }
}

