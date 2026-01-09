
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
    public class Sucursal_importacion : EntityBaseExt
    {


        public Sucursal_importacion() : base()
        {
        }

        public Sucursal_importacion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sucursal_importacion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Manejaprecioxdescuento { get; set; } = BoolCN.N;

        [StringLength(Domains.PrefijoLength)]
    public string? Prefijoprecioxdescuento { get; set; }


    public long? Sucursalinfoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursalinfoid")]
        public virtual Sucursal_info? Sucursalinfo { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Porc_aumento_precio { get; set; } = 0m;

    public long? Listaprecioid { get; set; }
        [ForeignKey("Listaprecioid")]
        public virtual Tipoprecio? Listaprecio { get; set; }

        public long? Surtidorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Surtidorid")]
        public virtual Sucursal_info? Surtidor { get; set; }


        public long? Sucursal_info_opciones_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursal_info_opciones_id")]
        public virtual Sucursal_info_opciones? Sucursal_info_opciones { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Imnuprod { get; set; }


    }
}

