
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
    public class Docto_rebajaespecial : EntityBaseExt
    {


        public Docto_rebajaespecial() : base()
        {
        }

        public Docto_rebajaespecial(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_rebajaespecial(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Estadorebaja { get; set; }

        [ForeignKey("Estadorebaja")]
        public virtual Estatusrebaja? Estadorebaja_ { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Montorebaja { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totalconrebaja { get; set; } = 0m;

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

