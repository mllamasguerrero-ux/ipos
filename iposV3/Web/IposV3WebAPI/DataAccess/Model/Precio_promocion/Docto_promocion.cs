
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
    public class Docto_promocion : EntityBaseExt
    {


        public Docto_promocion() : base()
        {
        }

        public Docto_promocion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_promocion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Promocion { get; set; } = BoolCN.N;



        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }
        public long? Doctoid { get; set; }


  }
}

