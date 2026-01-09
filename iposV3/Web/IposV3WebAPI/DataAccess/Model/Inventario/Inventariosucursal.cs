
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
    public class Inventariosucursal : EntityBaseExt
    {


        public Inventariosucursal() : base()
        {
        }

        public Inventariosucursal(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Inventariosucursal(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Sucursalclave { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Almacenclave { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Productoclave { get; set; }


    public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }

        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }

        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }

        public string? Hora { get; set; }

    public DateTimeOffset? Fecha { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costoultimo { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Costopromedio { get; set; } = 0m;

    public DateTimeOffset? Ultimafechacompra { get; set; }

    public DateTimeOffset? Ultimafechaventa { get; set; }


  }
}

