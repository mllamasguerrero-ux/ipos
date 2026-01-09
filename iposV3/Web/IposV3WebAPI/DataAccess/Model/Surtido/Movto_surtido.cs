
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
    public class Movto_surtido : EntityBaseExt
    {


        public Movto_surtido() : base()
        {
        }

        public Movto_surtido(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_surtido(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCS Surtible { get; set; } = BoolCS.S;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Maxsurtible { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

