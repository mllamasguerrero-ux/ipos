
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
    public class Movto_rebajaespecial : EntityBaseExt
    {


        public Movto_rebajaespecial() : base()
        {
        }

        public Movto_rebajaespecial(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_rebajaespecial(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precioconrebaja { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totalconrebaja { get; set; } = 0m;

        public long? Estadorebaja { get; set; }

        [ForeignKey("Estadorebaja")]
        public virtual Estatusrebaja? Estadorebaja_ { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantautrebaja { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montorebaja { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

