
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
    public class Docto_compra : EntityBaseExt
    {


        public Docto_compra() : base()
        {
        }

        public Docto_compra(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_compra(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Folio { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Factura { get; set; }


        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public DateTimeOffset? Fechafactura { get; set; }



  }
}

