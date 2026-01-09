
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
    public class Corte : EntityBaseExt
    {


        public Corte() : base()
        {
        }

        public Corte(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Corte(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Cajaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Cajaid")]
        public virtual Caja? Caja { get; set; }


        public long? Cajeroid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cajeroid")]
        public virtual Usuario? Cajero { get; set; }

        public DateTimeOffset? Fechacorte { get; set; }

    public DateTimeOffset? Inicia { get; set; }

    public DateTimeOffset? Termina { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoinicial { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Ingreso { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Egreso { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldofinal { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoreal { get; set; } = 0m;

        public long? Tipocorteid { get; set; }
        [ForeignKey("Tipocorteid")]
        public virtual Tipocorte? Tipocorte { get; set; }

        public long? Corterecoleccionid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Corterecoleccionid")]
        public virtual Corterecoleccion? Corterecoleccion { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Fondodinamico { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Fondodinamicofinal { get; set; } = 0m;




        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


    }
}

