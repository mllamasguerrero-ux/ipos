
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
    public class Promocionsucursal : EntityBaseExt
    {


        public Promocionsucursal() : base()
        {
        }

        public Promocionsucursal(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Promocionsucursal(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public long? Promocionid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Promocionid")]
        public virtual Promocion? Promocion { get; set; }

        public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }


    }
}

