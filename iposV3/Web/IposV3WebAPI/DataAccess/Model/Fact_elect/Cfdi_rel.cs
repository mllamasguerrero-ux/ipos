
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
    public class Cfdi_rel : EntityBaseExt
    {


        public Cfdi_rel() : base()
        {
        }

        public Cfdi_rel(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cfdi_rel(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_64Length)]
    public string? Tiporelacion { get; set; }

    [StringLength(Domains.Stdtext_64Length)]
    public string? Uuid { get; set; }

    public long? Cfdiid { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdiid")]
        public virtual Cfdi? Cfdi { get; set; }


    }
}

