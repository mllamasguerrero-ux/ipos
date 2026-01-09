
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
    public class Cliente_comision : EntityBaseExt
    {


        public Cliente_comision() : base()
        {
        }

        public Cliente_comision(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_comision(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public long? Vendedorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorid")]
        public virtual Usuario? Vendedor { get; set; }

        public long? Clienteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }



        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Por_come { get; set; } = 0;


        [Column(TypeName = "char(1)")]
        public BoolCN? Servicioadomicilio { get; set; }


    }
}

