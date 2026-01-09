
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
    public class Docto_cobranza : EntityBaseExt
    {


        public Docto_cobranza() : base()
        {
        }

        public Docto_cobranza(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_cobranza(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public DateTimeOffset? Fechaaprobacioncxc { get; set; }

    public long? Personaidaprobacioncxc { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaidaprobacioncxc")]
        public virtual Usuario? Personaaprobacioncxc { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

