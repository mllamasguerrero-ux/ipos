
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
    public class Cfdi_conc : EntityBaseExt
    {


        public Cfdi_conc() : base()
        {
        }

        public Cfdi_conc(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cfdi_conc(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_64Length)]
    public string? Unidad { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Noidentificacion { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Cuentapredial { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Claveprodserv { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Claveunidad { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Valorunitario { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Descuento { get; set; } = 0m;

    public long? Cfdiid { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdiid")]
        public virtual Cfdi? Cfdi { get; set; }

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public long? Doctoconceptoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoconceptoid")]
        public virtual Docto? Doctoconcepto { get; set; }

        public int? Consecutivo { get; set; }


        [StringLength(Domains.Stdtext_64Length)]
        public string? Objetoimp { get; set; }



        public virtual ICollection<Cfdi_conc_part>? ConceptoPartes { get; set; }

        public virtual ICollection<Cfdi_conc_imp>? Impuestos { get; set; }

        public virtual ICollection<Cfdi_conc_adu>? InformacionesAduaneras { get; set; }

    }
}

