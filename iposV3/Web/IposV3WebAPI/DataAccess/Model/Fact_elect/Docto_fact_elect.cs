
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
    public class Docto_fact_elect : EntityBaseExt
    {


        public Docto_fact_elect() : base()
        {
        }

        public Docto_fact_elect(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_fact_elect(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_64Length)]
    public string? Timbradouuid { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Timbradofecha { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Timbradocertsat { get; set; }

    [StringLength(Domains.SellosatLength)]
    public string? Timbradosellosat { get; set; }

    [StringLength(Domains.SellosatLength)]
    public string? Timbradosellocfdi { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Timbradocancelado { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_64Length)]
    public string? Timbradouuidcancelacion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Timbradoformapagosat { get; set; }

    [StringLength(Domains.DoctoserieLength)]
    public string? Seriesat { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esfacturaelectronica { get; set; } = BoolCN.N;


        public DateTimeOffset? Timbradofechacancelacion { get; set; }

    public DateTimeOffset? Timbradofechafactura { get; set; }

    public int? Foliosat { get; set; }

    public DateTimeOffset? Fechafactura { get; set; }

    public long? Sat_usocfdiid { get; set; }
        [ForeignKey("Sat_usocfdiid")]
        public virtual Sat_usocfdi? Sat_usocfdi { get; set; }

        public long? Cfdiid { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdiid")]
        public virtual Cfdi? Cfdi { get; set; }

        public long? Doctoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ivaretenido { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Isrretenido { get; set; } = 0m;

        [Column(TypeName = "char(1)")]
        public BoolCNI Usardatosentrega { get; set; } = BoolCNI.I;


    }
}

