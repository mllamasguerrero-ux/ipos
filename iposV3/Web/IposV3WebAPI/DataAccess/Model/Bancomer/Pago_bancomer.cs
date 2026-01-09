
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
    public class Pago_bancomer : EntityBaseExt
    {


        public Pago_bancomer() : base()
        {
        }

        public Pago_bancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Pago_bancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        public long? Pagoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoid")]
        public virtual Pago? Pago { get; set; }


        public long? Bancomerparamid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Bancomerparamid")]
        public virtual Bancomerparam? Bancomerparam { get; set; }


    }
}

