
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
    public class Movto_monedero : EntityBaseExt
    {


        public Movto_monedero() : base()
        {
        }

        public Movto_monedero(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_monedero(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monederoabono { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

