
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
    public class Cfdi_conc_imp : EntityBaseExt
    {


        public Cfdi_conc_imp() : base()
        {
        }

        public Cfdi_conc_imp(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cfdi_conc_imp(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Tipolinea { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Tipofactor { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Tasacuota { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Impuesto { get; set; }



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Baseimp { get; set; } = 0m;



        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasa { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;

        public long? Cfdi_conc_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdi_conc_id")]
        public virtual Cfdi_conc? Cfdi_conc { get; set; }


    }
}

