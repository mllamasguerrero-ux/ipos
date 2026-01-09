
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
    public class Bitacobranza : EntityBaseExt
    {


        public Bitacobranza() : base()
        {
        }

        public Bitacobranza(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Bitacobranza(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public DateTimeOffset? Fecha { get; set; }

    public long? Cobradorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cobradorid")]
        public virtual Usuario? Cobrador { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Totalabonado { get; set; } = 0m;

    public long? Estado { get; set; }
        [ForeignKey("Estado")]
        public virtual Estadocobranza? Estadocobranza { get; set; }


    }
}

