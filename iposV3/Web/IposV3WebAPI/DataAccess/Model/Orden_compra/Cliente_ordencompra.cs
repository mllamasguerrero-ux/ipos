
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
    public class Cliente_ordencompra : EntityBaseExt
    {


        public Cliente_ordencompra() : base()
        {
        }

        public Cliente_ordencompra(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_ordencompra(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = "char(1)")]
        public BoolCN Solicitaordencompra { get; set; } = BoolCN.N;


        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }


    }
}

