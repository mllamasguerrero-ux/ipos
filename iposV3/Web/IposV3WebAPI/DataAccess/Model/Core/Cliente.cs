
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
    public class Cliente : EntityBaseExt
    {


        public Cliente() : base()
        {
        }

        public Cliente(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string Clave { get; set; } = "";


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombres { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Apellidos { get; set; }




        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Razonsocial { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Rfc { get; set; }


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


        public long? Domicilioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioid")]
        public virtual Domicilio? Domicilio { get; set; }


        public long? Contacto1id { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Contacto1id")]
        public virtual Contacto? Contacto1 { get; set; }

        public long? Contacto2id { get; set; } 

        [ForeignKey("EmpresaId, SucursalId,Contacto2id")]
        public virtual Contacto? Contacto2 { get; set; }


        public long? Domicilioentregaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioentregaid")]
        public virtual Domicilio? Domicilioentrega { get; set; }



        public long? Subtipoclienteid { get; set; }

        [ForeignKey("Subtipoclienteid")]

        public virtual Subtipocliente? Subtipocliente { get; set; }

        public long? Proveeclienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveeclienteid")]
        public virtual Proveedor? Proveecliente { get; set; }



        public DateTimeOffset? Vigencia { get; set; }


        [StringLength(Domains.Stdtext_largeLength)]
        public string? Firma { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Email3 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Email4 { get; set; }



        public virtual Cliente_bancomer? Cliente_bancomer { get; set; }
        public virtual Cliente_comision? Cliente_comision { get; set; }
        public virtual Cliente_fact_elect? Cliente_fact_elect { get; set; }
        public virtual Cliente_ordencompra? Cliente_ordencompra { get; set; }
        public virtual Cliente_pago? Cliente_pago { get; set; }
        public virtual Cliente_pago_parametros? Cliente_pago_parametros { get; set; }
        public virtual Cliente_poliza? Cliente_poliza { get; set; }
        public virtual Cliente_precio? Cliente_precio { get; set; }
        public virtual Cliente_rutaembarque? Cliente_rutaembarque { get; set; }



        [NotMapped]
        public string Nombre
        {
            get { return $"{(Nombres ?? "")} {(Apellidos ?? "")}"; }
            set
            {
            }
        }

        public static void ConfigureEntity(EntityTypeBuilder<Cliente> modelBuilder)
        {
           



        }

    }
}

