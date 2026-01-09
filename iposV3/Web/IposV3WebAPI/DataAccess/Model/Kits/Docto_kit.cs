
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
    public class Docto_kit : EntityBaseExt
    {


        public Docto_kit() : base()
        {
        }

        public Docto_kit(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_kit(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Kitdesglosado { get; set; } = BoolCN.N;


        public long? Doctokitrefid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctokitrefid")]
        public virtual Docto? Doctokitref { get; set; }

        public long? Prekitestatus { get; set; }
        [ForeignKey("Prekitestatus")]
        public virtual Estatusdocto? Prekitestatus_ { get; set; }

        public long? Postkitestatus { get; set; }
        [ForeignKey("Postkitestatus")]
        public virtual Estatusdocto? Postkitestatus_ { get; set; }

        public int? Versionkit { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

