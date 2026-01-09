
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
    public class Docto_fact_elect_sustitucion : EntityBaseExt
    {


        public Docto_fact_elect_sustitucion() : base()
        {
        }

        public Docto_fact_elect_sustitucion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_fact_elect_sustitucion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public long? Doctosustitutoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctosustitutoid")]
        public virtual Docto? Doctosustituto { get; set; }

        public long? Doctoasustituirid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoasustituirid")]
        public virtual Docto? Doctoasustituir { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

