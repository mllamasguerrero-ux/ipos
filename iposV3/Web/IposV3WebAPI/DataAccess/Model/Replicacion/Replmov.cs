
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
    public class Replmov : EntityBaseExt
    {


        public Replmov() : base()
        {
        }

        public Replmov(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Replmov(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Tipomovid { get; set; }
        [ForeignKey("Tipomovid")]
        public virtual Repltipomov? Tipomov { get; set; }

        public long? Repltablaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Repltablaid")]
        public virtual Repltabla? Repltabla { get; set; }

        public long? Idregistro { get; set; }


  }
}

