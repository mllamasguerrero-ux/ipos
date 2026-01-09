
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
    public class Montobilletes : EntityBaseExt
    {


        public Montobilletes() : base()
        {
        }

        public Montobilletes(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Montobilletes(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Corteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corteid")]
        public virtual Corte? Corte { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Tipodecambio { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal P1000 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal P500 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal P200 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal P100 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal P50 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal P20 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D100 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D50 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D20 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D10 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D5 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D2 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal D1 { get; set; } = 0m;



        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Morrallapesos { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Morralladolares { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Morralladedolarenpesos { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldofinal { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Cheques { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Vales { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Tarjeta { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Credito { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monedero { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Transferencia { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Indefinido { get; set; } = 0m;

        public long? Tipomontobilletesid { get; set; }
        [ForeignKey("Tipomontobilletesid")]
        public virtual Tipomontobilletes? Tipomontobilletes { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Deposito { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Deptercero { get; set; } = 0m;





        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


    }
}

