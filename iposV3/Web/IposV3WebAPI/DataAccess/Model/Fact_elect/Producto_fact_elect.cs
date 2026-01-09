
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
    public class Producto_fact_elect : EntityBaseExt
    {


        public Producto_fact_elect() : base()
        {
        }

        public Producto_fact_elect(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_fact_elect(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public long? Sat_productoservicioid { get; set; }
        [ForeignKey("Sat_productoservicioid")]
        public virtual Sat_productoservicio? Sat_productoservicio { get; set; }





        [Column(TypeName = "char(1)")]
        public BoolCN Generacomprobtrasl { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Generacartaporte { get; set; }

        public long? Sat_Tipoembalajeid { get; set; }

        [ForeignKey("Sat_Tipoembalajeid")]
        public virtual Sat_tipoembalaje? Sat_Tipoembalaje { get; set; }

        public long? Sat_Claveunidadpesoid { get; set; }

        [ForeignKey("Sat_Claveunidadpesoid")]
        public virtual Sat_claveunidadpeso? Sat_Claveunidadpeso { get; set; }

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Peso { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Espeligroso { get; set; } = BoolCN.N;

        public long? Sat_Matpeligrosoid { get; set; }

        [ForeignKey("Sat_Matpeligrosoid")]
        public virtual Sat_matpeligroso? Sat_Matpeligroso { get; set; }





    }
}

