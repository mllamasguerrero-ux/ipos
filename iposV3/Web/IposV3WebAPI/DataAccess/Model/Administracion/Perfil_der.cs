
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
    public class Perfil_der : EntityBaseExt
    {


        public Perfil_der() : base()
        {
        }

        public Perfil_der(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Perfil_der(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Perfilid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Perfilid")]
        public virtual Perfiles? Perfil { get; set; }

        public long? Derechoid { get; set; }
        [ForeignKey("Derechoid")]
        public virtual Derechos? Derecho { get; set; }


    }
}

