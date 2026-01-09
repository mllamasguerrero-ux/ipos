
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
    public class Usuario_perfil : EntityBaseExt
    {


        public Usuario_perfil() : base()
        {
        }

        public Usuario_perfil(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Usuario_perfil(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Perfilid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Perfilid")]
        public virtual Perfiles? Perfil { get; set; }

        public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }



    }
}

