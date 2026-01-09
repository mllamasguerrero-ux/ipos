
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
    public class Mensajearea : EntityBaseExt
    {


        public Mensajearea() : base()
        {
        }

        public Mensajearea(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Mensajearea(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clavearea { get; set; }


    public long? Idmensaje { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Idmensaje")]
        public virtual Mensaje? Mensaje { get; set; }

        public long? Idarea { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Idarea")]
        public virtual Area? Area { get; set; }


    }
}

