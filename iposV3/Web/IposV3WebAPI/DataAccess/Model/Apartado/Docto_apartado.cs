
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
    public class Docto_apartado : EntityBaseExt
    {


        public Docto_apartado() : base()
        {
        }

        public Docto_apartado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_apartado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Mercanciaentregada { get; set; } = BoolCN.N;


        public long? Personaapartadoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Personaapartadoid")]
        public virtual Personaapartado? Personaapartado { get; set; }


        public long? Doctoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

