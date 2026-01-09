
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
    public class Pagodoctosat_imp : EntityBaseExt
    {


        public Pagodoctosat_imp() : base()
        {
        }

        public Pagodoctosat_imp(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Pagodoctosat_imp(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Pagodoctosatid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagodoctosatid")]
        public virtual Pagodoctosat? Pagodoctosat { get; set; }




        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Baseimp { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Tipofactor { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Tasacuota { get; set; }

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Tasa { get; set; }

        [StringLength(Domains.Stdtext_64Length)]
        public string? Impuesto { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Importe { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Tipoimpuesto { get; set; }



        public string? Iddocumento { get; set; }


    }
}

