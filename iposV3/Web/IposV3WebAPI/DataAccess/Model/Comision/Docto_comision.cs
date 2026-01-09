
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
    public class Docto_comision : EntityBaseExt
    {


        public Docto_comision() : base()
        {
        }

        public Docto_comision(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_comision(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Vendedorfinal { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorfinal")]
        public virtual Usuario? Vendedorfinal_ { get; set; }


        public long? Vendedorejecutivoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorejecutivoid")]
        public virtual Usuario? Vendedorejecutivo { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Comision { get; set; } = 0m;
            
        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

