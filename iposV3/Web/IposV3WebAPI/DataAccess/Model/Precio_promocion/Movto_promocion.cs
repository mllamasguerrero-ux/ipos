
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
    public class Movto_promocion : EntityBaseExt
    {


        public Movto_promocion() : base()
        {
        }

        public Movto_promocion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_promocion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Promocion { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_64Length)]
    public string? Promociondesglose { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Aplicopromoxmontomin { get; set; }


    public long? Promocionid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Promocionid")]
        public virtual Promocion? Promocion_ { get; set; }


        public long? Promocionmultidetalleid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Promocionmultidetalleid")]
        public virtual Promocion? Promocionmultidetalle { get; set; }


        public long? Tipomayoreolineaid { get; set; }
        [ForeignKey("Tipomayoreolineaid")]
        public virtual Tipomayoreo? Tipomayoreolinea { get; set; }

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

