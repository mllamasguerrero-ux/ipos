
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
    public class Cuenta : EntityBaseExt
    {


        public Cuenta() : base()
        {
        }

        public Cuenta(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cuenta(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Numucuenta { get; set; }

    [StringLength(Domains.DescripcionLength)]
    public string? Descripcion { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCNI Esfact { get; set; } = BoolCNI.I;

        [StringLength(Domains.Stdtext_shortLength)]
    public string? Leyenda { get; set; }


        public long? Tipolineapolizaid { get; set; }
        [ForeignKey("Tipolineapolizaid")]
        public virtual Tipolineapoliza? Tipolineapoliza { get; set; }

        public long? Formapagosatid { get; set; }
        [ForeignKey("Formapagosatid")]
        public virtual Formapagosat? Formapagosat { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Tasa { get; set; } = 0m;

    public long? Tipolineapolizaespecialid { get; set; }
        [ForeignKey("Tipolineapolizaespecialid")]
        public virtual Tipolineapoliza? Tipolineapolizaespecial { get; set; }

        public int? Orden { get; set; }


        [NotMapped]
        public virtual string Nombre
        {
            get { return Descripcion ?? ""; }
            //set { Descripcion = value; }
        }


    }
}

