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
    public class Grupousuario : EntityBaseExt
    {



        public Grupousuario() : base()
        {
        }

        public Grupousuario(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Grupousuario(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";

        [StringLength(Domains.DescripcionLength)]
        public string? Descripcion { get; set; }
    }
}
