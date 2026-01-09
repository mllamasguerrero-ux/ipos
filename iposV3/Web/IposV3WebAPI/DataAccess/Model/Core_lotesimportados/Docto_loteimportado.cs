
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
    public class Docto_loteimportado : EntityBaseExt
    {


        public Docto_loteimportado() : base()
        {
        }

        public Docto_loteimportado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_loteimportado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Loteimportadodoctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Loteimportadodoctoid")]
        public virtual Lotesimportados? Loteimportadodocto { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

