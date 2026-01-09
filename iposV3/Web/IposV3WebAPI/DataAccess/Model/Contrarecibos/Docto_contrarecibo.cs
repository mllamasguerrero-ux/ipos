
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
    public class Docto_contrarecibo : EntityBaseExt
    {


        public Docto_contrarecibo() : base()
        {
        }

        public Docto_contrarecibo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_contrarecibo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Contrareciboid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Contrareciboid")]
        public virtual Contrarecibohdr? Contrarecibo { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }



        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


    }
}

