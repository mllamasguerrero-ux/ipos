
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
    public class Docto_poliza : EntityBaseExt
    {


        public Docto_poliza() : base()
        {
        }

        public Docto_poliza(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_poliza(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Doctoplazoorigenid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoplazoorigenid")]
        public virtual Docto? Doctoplazoorigen { get; set; }

        public long? Plazoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Plazoid")]
        public virtual Plazo? Plazo { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

