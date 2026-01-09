
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
    public class Doctocomprobante : EntityBaseExt
    {


        public Doctocomprobante() : base()
        {
        }

        public Doctocomprobante(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Doctocomprobante(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }
        public long? Doctoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }




        [StringLength(Domains.Stdtext_64Length)]
        public string? Tipocomprobante { get; set; }

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

        public int? Foliosat { get; set; }

        [StringLength(Domains.DoctoserieLength)]
        public string? Seriesat { get; set; }






    }
}

