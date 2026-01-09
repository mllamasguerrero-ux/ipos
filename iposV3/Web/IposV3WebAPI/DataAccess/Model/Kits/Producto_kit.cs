
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
    public class Producto_kit : EntityBaseExt
    {


        public Producto_kit() : base()
        {
        }

        public Producto_kit(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_kit(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Eskit { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Kittienevig { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Kitimpfijo { get; set; } = BoolCN.N;



        [Column(TypeName = "char(1)")]
        public BoolCN? Valxsuc{ get; set; } 


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Enprocesopartessalida { get; set; } = 0m;

    public DateTimeOffset? Vigenciaprodkit { get; set; }


  }
}

