
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
    public class Caja_bancomer : EntityBaseExt
    {


        public Caja_bancomer() : base()
        {
        }

        public Caja_bancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Caja_bancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.Stdtext_shortLength)]
    public string? Nombrecertificadobancomer { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Afiliacionbancomer { get; set; }


    public long? Cajaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Cajaid")]
        public virtual Caja? Caja { get; set; }

        public long? Numeroterminalbancomer { get; set; }


  }
}

