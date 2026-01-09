
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
    public class Movtogasto : EntityBaseExt
    {


        public Movtogasto() : base()
        {
        }

        public Movtogasto(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movtogasto(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Estatusmovtoid { get; set; }

        [ForeignKey(" Estatusmovtoid")]
        public virtual Estatusmovto? Estatusmovto { get; set; }

        public long? Gastoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Gastoid")]
        public virtual Gasto? Gasto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;

    public int? Partida { get; set; }


  }
}

