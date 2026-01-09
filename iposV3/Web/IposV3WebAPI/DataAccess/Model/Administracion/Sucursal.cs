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
    //[PrimaryKey(nameof(EmpresaId), nameof(Id))]
    public class Sucursal
    {

        #pragma warning disable CS8618
        public Sucursal()
        {
            Creado = DateTime.UtcNow;
            Modificado = DateTime.UtcNow;

            Activo = BoolCS.S;
            Clave = "";
            Nombre = "";
        }

        #pragma warning restore CS8618

        public Sucursal(Empresa empresa):this()
        {
            Empresa = empresa;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCS Activo { get; set; }


        public DateTimeOffset Creado { get; set; }

        public DateTimeOffset Modificado { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string Nombre { get; set; }

        [StringLength(Domains.DescripcionLength)]
        public string? Descripcion { get; set; }


        public static void ConfigureEntity(EntityTypeBuilder<Sucursal> modelBuilder)
        {
            modelBuilder
                .HasKey(c => new { c.EmpresaId, c.Id });

        }

    }
}
