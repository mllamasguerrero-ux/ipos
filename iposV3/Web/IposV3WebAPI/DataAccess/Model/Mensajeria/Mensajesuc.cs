
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
    public class Mensajesuc : EntityBaseExt
    {


        public Mensajesuc() : base()
        {
        }

        public Mensajesuc(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Mensajesuc(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clavesuc { get; set; }


    public long? Idmensaje { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Idmensaje")]
        public virtual Mensaje? Mensaje { get; set; }

        public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }


    }
}

