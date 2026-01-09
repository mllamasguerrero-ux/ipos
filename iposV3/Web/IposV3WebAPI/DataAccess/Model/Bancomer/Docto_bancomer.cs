
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
    public class Docto_bancomer : EntityBaseExt
    {


        public Docto_bancomer() : base()
        {
        }

        public Docto_bancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_bancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = "char(1)")]
        public BoolCN Pagobancomeraplicado { get; set; } = BoolCN.N;


        public long? Doctoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

