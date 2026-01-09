
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
    public class Producto_existencia : EntityBaseExt
    {


        public Producto_existencia() : base()
        {
        }

        public Producto_existencia(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_existencia(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existencia { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Enprocesodesalida { get; set; } = 0m;

        public DateTimeOffset? Ultimocambioexistencia { get; set; }


  }
}

