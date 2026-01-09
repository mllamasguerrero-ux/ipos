
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
    public class Movto_poliza : EntityBaseExt
    {


        public Movto_poliza() : base()
        {
        }

        public Movto_poliza(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_poliza(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Nutil { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Nprec { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Cdescr { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

