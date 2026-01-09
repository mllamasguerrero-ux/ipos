
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
    public class Movto_utilidad : EntityBaseExt
    {


        public Movto_utilidad() : base()
        {
        }

        public Movto_utilidad(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_utilidad(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Utilidad { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoreposicion { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costopromedio { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoimporte { get; set; } = 0m;


  }
}

