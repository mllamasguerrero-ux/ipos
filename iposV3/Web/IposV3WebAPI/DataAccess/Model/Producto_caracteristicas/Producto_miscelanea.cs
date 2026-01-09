
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
    public class Producto_miscelanea : EntityBaseExt
    {


        public Producto_miscelanea() : base()
        {
        }

        public Producto_miscelanea(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_miscelanea(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        public long? Clasificaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Clasificaid")]
        public virtual Clasifica? Clasifica { get; set; }

        public long? Contenidoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Contenidoid")]
        public virtual Contenido? Contenido { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Contenidovalor { get; set; } = 0m;


        [Column(TypeName = "char(1)")]
        public BoolCS Imprimir { get; set; } = BoolCS.S;



        [Column(TypeName = "char(1)")]
        public BoolCS Imprimircomanda { get; set; } = BoolCS.S;


    }
}

