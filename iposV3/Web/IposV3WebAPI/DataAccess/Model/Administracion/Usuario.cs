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
using System.Transactions;

namespace IposV3.Model
{
    public class Usuario : EntityBaseExt
    {

        public Usuario(): base()
        {
        }

        public Usuario(Empresa empresa, Sucursal sucursal):  base(empresa, sucursal)
        {
            
        }



        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";


        [StringLength(Domains.Stdtext_shortLength)]
        public string UsuarioNombre { get; set; } = "";

        [StringLength(Domains.DescripcionLength)]
        public string Contrasena { get; set; } = "";




        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombres { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Apellidos { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Razonsocial { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Rfc { get; set; }


        public long? Domicilioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioid")]
        public virtual Domicilio? Domicilio { get; set; }


        public long? Contacto1id { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Contacto1id")]
        public virtual Contacto? Contacto1 { get; set; }


        public long? Contacto2id { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Contacto2id")]
        public virtual Contacto? Contacto2 { get; set; }




        [StringLength(Domains.Stdtext_shortLength)]
        public string? Telefono1 { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Telefono2 { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Telefono3 { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Celular { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Nextel { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Email1 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Email2 { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Reset_pass { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string? Gaffete { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN Ticketlargo { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Ticketlargocotizacion { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Ticketlargocredito { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Preguntarticketlargo { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Codigoautorizacion { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Cajasbotellas { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Clieformaspagodef { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esvendedor { get; set; }

        public DateTimeOffset? Vigencia { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esencargadocorte { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Esencargadoguia { get; set; }


        public int PendMaxDias { get; set; } = 0;



        public long? Saludoid { get; set; }

        [ForeignKey("Saludoid")]
        public virtual Saludo? Saludo { get; set; }

        public virtual Usuario_Preferencias? Usuario_Preferencias { get; set; }

        public virtual Personafigura? Usuario_Personafigura { get; set; }


        public virtual Usuario_fact_elect? Usuario_fact_elect { get; set; }

        public virtual Usuario_emida? Usuario_emida { get; set; }




        [NotMapped]
        public string? Clave { get { return this.UsuarioNombre?.ToString() ?? ""; } set {  } }


        public static void ConfigureEntity(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder
                .HasOne(c => c.Usuario_Personafigura)
                .WithOne(e => e.Persona);

            modelBuilder
                .HasOne(c => c.Usuario_fact_elect)
                .WithOne(e => e.Usuario);

            modelBuilder
                .HasOne(c => c.Usuario_emida)
                .WithOne(e => e.Usuario);

        }

    }
}
