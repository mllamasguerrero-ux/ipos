
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
    public class Movto_kit : EntityBaseExt
    {


        public Movto_kit() : base()
        {
        }

        public Movto_kit(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_kit(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Eskit { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Kitimpfijo { get; set; } = BoolCN.N;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Enprocesopartes { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaiepsparte { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasasubtotalparte { get; set; } = 0m;


        [Column(TypeName = Domains.DecimalExactDomain)]
        public decimal Tasaivaparte { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

