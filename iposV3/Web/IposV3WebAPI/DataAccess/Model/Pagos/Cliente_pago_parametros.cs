
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
    public class Cliente_pago_parametros : EntityBaseExt
    {


        public Cliente_pago_parametros() : base()
        {
        }

        public Cliente_pago_parametros(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_pago_parametros(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Hab_pagotarjeta { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Hab_pagocredito { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Hab_pagocheque { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_lightLength)]
    public string? Revision { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Pagos { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Bloqueado { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Hab_pagotransferencia { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCS Hab_pagoefectivo { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCN Pagoparcialidades { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_lightLength)]
    public string? Creditoreferenciaabonos { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Bloqueonot { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Exentoiva { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Cargoxventacontarjeta { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Pagotarjmenorpreciolista { get; set; } = BoolCN.N;


        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Limitecredito { get; set; } = 0m;

    public int? Dias { get; set; }

    public long? Creditoformapagoabonos { get; set; }
        [ForeignKey("Creditoformapagoabonos")]
        public virtual Formapago? Creditoformapagoabonos_ { get; set; }

        public long? Monedaid { get; set; }
        [ForeignKey("Monedaid")]
        public virtual Moneda? Moneda { get; set; }


        public int? Dias_extr { get; set; }


    }
}

