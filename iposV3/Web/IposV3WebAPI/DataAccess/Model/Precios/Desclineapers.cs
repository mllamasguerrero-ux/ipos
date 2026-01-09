
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
    public class Desclineapers : EntityBaseExt
    {


        public Desclineapers() : base()
        {
        }

        public Desclineapers(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Desclineapers(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Personaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Personaid")]
        public virtual Cliente? Persona { get; set; }

        public long? Lineaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Lineaid")]
        public virtual Linea? Linea { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuento { get; set; } = 0m;


  }
}

