
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
    public class Cfdi_conc_part : EntityBaseExt
    {


        public Cfdi_conc_part() : base()
        {
        }

        public Cfdi_conc_part(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cfdi_conc_part(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_64Length)]
    public string? Claveprodserv { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Noidentificacion { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Unidad { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Numeropedimento { get; set; }




        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Valorunitario { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;

    public long? Cfdi_conc_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdi_conc_id")]
        public virtual Cfdi_conc? Cfdi_conc { get; set; }

        public long? Movtokitid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtokitid")]
        public virtual Movto? Movtokit { get; set; }


    }
}

