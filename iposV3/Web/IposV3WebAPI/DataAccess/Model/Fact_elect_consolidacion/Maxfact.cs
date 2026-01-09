
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
    public class Maxfact : EntityBaseExt
    {


        public Maxfact() : base()
        {
        }

        public Maxfact(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Maxfact(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Sucursalclave { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Lun_hay { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Mar_hay { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Mie_hay { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Jue_hay { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Vie_hay { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Sab_hay { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Dom_hay { get; set; } = BoolCN.N;


        public int? Anio { get; set; }

    public int? Mes { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Lun_max { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Mar_max { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Mie_max { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Jue_max { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Vie_max { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Sab_max { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Dom_max { get; set; } = 0m;


    }
}

