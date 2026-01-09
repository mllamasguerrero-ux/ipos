
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
    public class Quota : EntityBaseExt
    {


        public Quota() : base()
        {
        }

        public Quota(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Quota(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_shortLength)]
    public string? Anio { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Mes { get; set; }


    public long? Vendedorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorid")]
        public virtual Usuario? Vendedor { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal QuotaAmt { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Logro { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Utilidad { get; set; } = 0m;


  }
}

