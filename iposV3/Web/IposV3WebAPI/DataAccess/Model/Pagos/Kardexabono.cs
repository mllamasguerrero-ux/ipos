
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
    public class Kardexabono : EntityBaseExt
    {


        public Kardexabono() : base()
        {
        }

        public Kardexabono(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Kardexabono(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Tipomovimientokardexabonoid { get; set; }
        [ForeignKey("Tipomovimientokardexabonoid")]
        public virtual Tipomovimientokardexabono? Tipomovimientokardexabono { get; set; }

        public DateTimeOffset? Fechahora { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importecambio { get; set; } = 0m;

        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }

        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }

        public long? Pagoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoid")]
        public virtual Pago? Pago { get; set; }

        public long? Doctopagoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctopagoid")]
        public virtual Doctopago? Doctopago { get; set; }

        public long? Formapagoid { get; set; }
        [ForeignKey("Formapagoid")]
        public virtual Formapago? Formapago { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Tipodoctoid { get; set; }
        [ForeignKey("Tipodoctoid")]
        public virtual Tipodocto? Tipodocto { get; set; }

        public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }

        public int? Sentidoabonodocto { get; set; }

    public int? Sentidoabonocliente { get; set; }

    public int? Sentidoabonoproveedor { get; set; }

    public int? Sentidoabonocorte { get; set; }


  }
}

