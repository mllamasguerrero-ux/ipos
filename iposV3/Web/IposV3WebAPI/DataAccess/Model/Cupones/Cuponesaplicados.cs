
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
    public class Cuponesaplicados : EntityBaseExt
    {


        public Cuponesaplicados() : base()
        {
        }

        public Cuponesaplicados(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cuponesaplicados(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        public long? Promocioncuponid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Promocioncuponid")]
        public virtual Promocion? Promocioncupon { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Cantidad { get; set; } = 0m;


  }
}

