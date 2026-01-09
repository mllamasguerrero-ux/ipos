
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
    public class Cliente_bancomer : EntityBaseExt
    {


        public Cliente_bancomer() : base()
        {
        }

        public Cliente_bancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_bancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public long? Bancomerdoctopendid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Bancomerdoctopendid")]
        public virtual Docto? Bancomerdoctopend { get; set; }

        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }


    }
}

