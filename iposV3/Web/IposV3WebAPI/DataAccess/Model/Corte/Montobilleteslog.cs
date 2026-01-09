
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
    public class Montobilleteslog : EntityBaseExt
    {


        public Montobilleteslog() : base()
        {
        }

        public Montobilleteslog(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Montobilleteslog(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Nota { get; set; }


    public long? Montobilletesid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Montobilletesid")]
        public virtual Montobilletes? Montobilletes { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldofinalanterior { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldofinalnuevo { get; set; } = 0m;

    public DateTimeOffset? Fechacambio { get; set; }

    public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }


    }
}

