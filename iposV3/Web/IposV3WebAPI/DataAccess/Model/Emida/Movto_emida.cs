
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
    public class Movto_emida : EntityBaseExt
    {


        public Movto_emida() : base()
        {
        }

        public Movto_emida(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_emida(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Emidainvoiceno { get; set; }


    public long? Emidarequestid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Emidarequestid")]
        public virtual Emidarequest? Emidarequest { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Emidacomision { get; set; } = 0m;

    public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

