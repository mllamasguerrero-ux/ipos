
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
    public class Doctopago : EntityBaseExt
    {


        public Doctopago() : base()
        {
        }

        public Doctopago(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Doctopago(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Esapartado { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Espagoinicial { get; set; } = BoolCN.N;


        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

    public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Importe { get; set; } = 0m;

        public long? Tipopagoid { get; set; }
        [ForeignKey("Tipopagoid")]
        public virtual Tipopago? Tipopago { get; set; }

        public long? Tipoabonoid { get; set; }
        [ForeignKey("Tipoabonoid")]
        public virtual Tipoabono? Tipoabono { get; set; }

        public long? Estatusdoctopagoid { get; set; }

        [ForeignKey(" Estatusdoctopagoid")]
        public virtual Estatusdoctopago? Estatusdoctopago { get; set; }

        public int? Sentidopago { get; set; }

    public long? Formapagoid { get; set; }
        [ForeignKey("Formapagoid")]
        public virtual Formapago? Formapago { get; set; }

        public long? Pagoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoid")]
        public virtual Pago? Pago { get; set; }

        public int? Sentidoabonodocto { get; set; }

    public int? Sentidoabonocliente { get; set; }

    public int? Sentidoabonoproveedor { get; set; }

    public int? Sentidoabonocorte { get; set; }

    public int? Sentidoabonopago { get; set; }

    public long? Tipoaplicacioncreditoid { get; set; }
        [ForeignKey("Tipoaplicacioncreditoid")]
        public virtual Tipoaplicacioncredito? Tipoaplicacioncredito { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Refinterno { get; set; }


        public long? Pagodoctosatid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagodoctosatid")]
        public virtual Pagodoctosat? Pagodoctosat { get; set; }



        public long? Doctopagoparentid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctopagoparentid")]
        public virtual Doctopago? Doctopagoparent { get; set; }


    }
}

