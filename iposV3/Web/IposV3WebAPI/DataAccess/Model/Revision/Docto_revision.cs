
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
    public class Docto_revision : EntityBaseExt
    {


        public Docto_revision() : base()
        {
        }

        public Docto_revision(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_revision(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Estadorevisadoid { get; set; }

        [ForeignKey("Estadorevisadoid")]
        public virtual Estadorevisado? Estadorevisado { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

