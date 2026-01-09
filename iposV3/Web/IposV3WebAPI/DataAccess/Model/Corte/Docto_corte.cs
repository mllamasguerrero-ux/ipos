
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
    public class Docto_corte : EntityBaseExt
    {


        public Docto_corte() : base()
        {
        }

        public Docto_corte(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_corte(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public DateTimeOffset? Fechacorte { get; set; }

    public long? Montobilletesid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Montobilletesid")]
        public virtual Montobilletes? Montobilletes { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

