
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
    public class Docto_ordencompra : EntityBaseExt
    {


        public Docto_ordencompra() : base()
        {
        }

        public Docto_ordencompra(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_ordencompra(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Ordencompra { get; set; }


        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Doctorefid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctorefid")]
        public virtual Docto? Doctoref { get; set; }


    }
}

