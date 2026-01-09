
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
    public class Docto_impuestos : EntityBaseExt
    {


        public Docto_impuestos() : base()
        {
        }

        public Docto_impuestos(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_impuestos(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Tipoimpuestoid { get; set; }
        [ForeignKey("Tipoimpuestoid")]
        public virtual Sat_impuesto? Tipoimpuesto { get; set; }


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaimpuesto { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Base { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_Base { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Consolidado_Monto { get; set; } = 0m;


    }
}

