
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
    public class Movto_loteimportado : EntityBaseExt
    {


        public Movto_loteimportado() : base()
        {
        }

        public Movto_loteimportado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_loteimportado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Movtoloteimportadorefid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoloteimportadorefid")]
        public virtual Lotesimportados? Movtoloteimportadoref { get; set; }

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

