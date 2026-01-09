
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
    public class Perfil_repo : EntityBaseExt
    {


        public Perfil_repo() : base()
        {
        }

        public Perfil_repo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Perfil_repo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Perfilid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Perfilid")]
        public virtual Perfiles? Perfil { get; set; }

        public long? Reporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Reporteid")]
        public virtual Reportes? Reporte { get; set; }


    }
}

