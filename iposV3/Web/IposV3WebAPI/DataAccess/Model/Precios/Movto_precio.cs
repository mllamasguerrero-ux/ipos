
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
    public class Movto_precio : EntityBaseExt
    {


        public Movto_precio() : base()
        {
        }

        public Movto_precio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_precio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_64Length)]
    public string? Razondescuentocajero { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Preciomanualmasbajo { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Ingresopreciomanual { get; set; } = BoolCN.N;


        [Column(TypeName = "char(1)")]
        public BoolCN? Calc_imp_de_total { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentovale { get; set; } = 0m;


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentovaleporcentaje { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porcentajedescuentomanual { get; set; } = 0m;

    public long? Listaprecioid { get; set; }
        [ForeignKey("Listaprecioid")]
        public virtual Tipoprecio? Listaprecio { get; set; }

        public int? Precioclasificacion { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Precioconimp { get; set; } = 0m;


  }
}

