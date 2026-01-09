
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
    public class Movto_traslado : EntityBaseExt
    {


        public Movto_traslado() : base()
        {
        }

        public Movto_traslado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_traslado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Otromotivodevolucion { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Preciovisibletraslado { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public long? Movtoimportadoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoimportadoid")]
        public virtual Movto? Movtoimportado { get; set; }

        public long? Motivodevolucionid { get; set; }
        [ForeignKey("Motivodevolucionid")]
        public virtual Motivo_devolucion? Motivodevolucion { get; set; }


    }
}

