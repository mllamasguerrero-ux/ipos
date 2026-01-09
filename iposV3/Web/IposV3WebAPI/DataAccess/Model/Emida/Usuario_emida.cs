
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
    public class Usuario_emida : EntityBaseExt
    {


        public Usuario_emida() : base()
        {
        }

        public Usuario_emida(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Usuario_emida(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Clerkpagoserviciosid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Clerkpagoserviciosid")]
        public virtual Clerkpagoservicio? Clerkpagoservicios { get; set; }

        public long? Clerkservicios { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Clerkservicios")]
        public virtual Clerkpagoservicio? Clerkservicios_ { get; set; }

        public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }


    }
}

