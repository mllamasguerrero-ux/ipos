
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
    public class Movto_cancelacion : EntityBaseExt
    {


        public Movto_cancelacion() : base()
        {
        }

        public Movto_cancelacion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_cancelacion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public long? Movtorefid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtorefid")]
        public virtual Movto? Movtoref { get; set; }


    }
}

