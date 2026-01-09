using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace IposV3.Model
{
    public class Usuario_Preferencias:EntityBase
    {

        public Usuario_Preferencias() : base()
        {

        }

        public Usuario_Preferencias(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {

        }

        public long? Usuarioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }



        public long? Grupousuarioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Grupousuarioid")]
        public virtual Grupousuario? Grupousuario { get; set; }


        public long? Almacenid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Almacenid")]
        public virtual Almacen? Almacen { get; set; }


        public long? Listaprecioid { get; set; }

        [ForeignKey(" Listaprecioid")]
        public virtual Tipoprecio? Listaprecio { get; set; }


        public virtual ICollection<Usuario_perfil>? Perfiles { get; set; }


        public virtual Usuario_emida? Usuario_emida { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombreimpresora { get; set; }



        public DateTimeOffset? Ultimavistacompra { get; set; }



    }
}
