
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
    public class Producto_inventario : EntityBaseExt
    {


        public Producto_inventario() : base()
        {
        }

        public Producto_inventario(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_inventario(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCS Inventariable { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCN Negativos { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Manejastock { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Surtirporcaja { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Manejalote { get; set; } = BoolCN.N;


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stock { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockmax { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockmincaja { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockmaxcaja { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockminpieza { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Stockmaxpieza { get; set; } = 0m;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Pzacaja { get; set; } = 0m;



        [Column(TypeName = Domains.CantidadDomain)]
        public decimal U_empaque { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantxpieza { get; set; } = 0m;


    }
}

