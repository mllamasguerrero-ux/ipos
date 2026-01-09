
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
    public class Movtogastosadic : EntityBaseExt
    {


        public Movtogastosadic() : base()
        {
        }

        public Movtogastosadic(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movtogastosadic(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Movtogastosadicid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtogastosadicid")]
        public virtual Gastoadicional? Gastoadicional { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Monto { get; set; } = 0m;

    public int? Partida { get; set; }


  }
}

