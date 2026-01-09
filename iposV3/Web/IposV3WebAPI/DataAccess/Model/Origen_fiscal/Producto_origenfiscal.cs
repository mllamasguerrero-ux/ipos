
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
    public class Producto_origenfiscal : EntityBaseExt
    {


        public Producto_origenfiscal() : base()
        {
        }

        public Producto_origenfiscal(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Producto_origenfiscal(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciafacturado { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciaremisionado { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Existenciaindefinido { get; set; } = 0m;

    public long? Ultimoorigenfiscalventa { get; set; }
        [ForeignKey("Ultimoorigenfiscalventa")]
        public virtual Origenfiscal? Ultimoorigenfiscalventa_ { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Exist_fac_intercambio { get; set; } = 0m;


  }
}

