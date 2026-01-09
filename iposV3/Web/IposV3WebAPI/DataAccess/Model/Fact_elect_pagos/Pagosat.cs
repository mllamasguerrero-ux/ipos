
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Pagosat : EntityBaseExt
    {


        public Pagosat() : base()
        {
        }

        public Pagosat(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Pagosat(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_shortLength)]
    public string? Formadepagop { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Monedap { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Numoperacion { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Rfcemisorctaord { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombancoordext { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Ctaordenante { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Rfcemisorctaben { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Ctabeneficiario { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Tipocadpago { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Certpago { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Cadpago { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Sellopago { get; set; }


    public long? Doctosatid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctosatid")]
        public virtual Docto? Doctosat { get; set; }

        public DateTimeOffset? Fechapago { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Tipocambiop { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;

    public long? Cfdiid { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Cfdiid")]
        public virtual Cfdi? Cfdi { get; set; }

        public long? Pagoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Pagoid")]
        public virtual Pago? Pago { get; set; }




        [NotMapped]
        public string? Clave { get { return ""; } }

        [NotMapped]
        public string? Nombre { get { return ""; } }


        public virtual ICollection<Pagodoctosat>? Pagodoctosats { get; set; }


        public static void ConfigureEntity(EntityTypeBuilder<Pagosat> modelBuilder)
        {


            //modelBuilder
            //    .HasOne(c => c.Pago)
            //    .WithOne(e => e.Pagosat);


        }
    }
}

