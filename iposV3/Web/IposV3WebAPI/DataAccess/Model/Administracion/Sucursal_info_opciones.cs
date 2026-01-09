
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
    public class Sucursal_info_opciones : EntityBaseExt
    {


        public Sucursal_info_opciones() : base()
        {
        }

        public Sucursal_info_opciones(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sucursal_info_opciones(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Sucursal_infoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_infoid")]
        public virtual Sucursal_info? Sucursal_info { get; set; }


        public long? Gruposucursalid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Gruposucursalid")]
        public virtual Gruposucursal? Gruposucursal { get; set; }


        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }

        public long? Proveedorid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveedorid")]
        public virtual Proveedor? Proveedor { get; set; }

        public long? Bancoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Bancoid")]
        public virtual Banco? Banco { get; set; }

        public long? Empprovid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Empprovid")]
        public virtual Proveedor? Empprov { get; set; }



        public virtual Sucursal_fact_elect? Sucursal_fact_elect { get; set; }
        public virtual Sucursal_importacion? Sucursal_importacion { get; set; }
        public virtual Sucursal_respaldo? Sucursal_respaldo { get; set; }
        public virtual Sucursal_traslado? Sucursal_traslado { get; set; }


    }
}
