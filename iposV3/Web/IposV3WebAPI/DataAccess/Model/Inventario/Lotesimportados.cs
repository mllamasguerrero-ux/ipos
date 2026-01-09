
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
    public class Lotesimportados : EntityBaseExt
    {


        public Lotesimportados() : base()
        {
        }

        public Lotesimportados(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Lotesimportados(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.PedimentoLength)]
    public string? Pedimento { get; set; }


    public DateTimeOffset? Fechaimportacion { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Tipocambio { get; set; } = 0m;

    public long? Sataduanaid { get; set; }
        [ForeignKey("Sataduanaid")]
        public virtual Sat_aduana? Sataduana { get; set; }



        [NotMapped]
        public string? Clave { get { return ""; } set { } }

        [NotMapped]
        public string? Nombre { get { return ""; } set { } }


    }
}

