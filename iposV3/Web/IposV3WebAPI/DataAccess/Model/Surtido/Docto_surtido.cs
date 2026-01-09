
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
    public class Docto_surtido : EntityBaseExt
    {


        public Docto_surtido() : base()
        {
        }

        public Docto_surtido(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_surtido(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Procesosurtido { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_mediumLength)]
    public string? Notasurtido { get; set; }


    public DateTimeOffset? Pendmaxfecha { get; set; }

    public long? Estadosurtidoid { get; set; }

        [ForeignKey("Estadosurtidoid")]
        public virtual Estadosurtido? Estadosurtido { get; set; }

        public long? Estatusdoctopedidoid { get; set; }

        [ForeignKey("Estatusdoctopedidoid")]
        public virtual Estatusdoctopedido? Estatusdoctopedido { get; set; }

        public DateTimeOffset? Fechasurtido { get; set; }

    public long? Personaidsurtido { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaidsurtido")]
        public virtual Usuario? Personasurtido { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

