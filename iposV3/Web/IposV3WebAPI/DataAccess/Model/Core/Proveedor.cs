
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
    public class Proveedor : EntityBaseExt
    {


        public Proveedor() : base()
        {
        }

        public Proveedor(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Proveedor(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

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
        public BoolCN Esimportador { get; set; } = BoolCN.N;



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombres { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Apellidos { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Razonsocial { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Rfc { get; set; }


        public long? Contacto1id { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Contacto1id")]
        public virtual Contacto? Contacto1 { get; set; }

        public long? Contacto2id { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Contacto2id")]
        public virtual Contacto? Contacto2 { get; set; }


        public long? Domicilioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioid")]
        public virtual Domicilio? Domicilio { get; set; }



        public long? Proveeclienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Proveeclienteid")]
        public virtual Cliente? Proveecliente { get; set; }


        public long? Vendedorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorid")]
        public virtual Usuario? Vendedor { get; set; }

        public long? Listaprecioid { get; set; }
        [ForeignKey("Listaprecioid")]
        public virtual Tipoprecio? Listaprecio { get; set; }

        public long? Saludoid { get; set; }

        [ForeignKey("Saludoid")]
        public virtual Saludo? Saludo { get; set; }



        public virtual Proveedor_pago? Proveedor_pago { get; set; }
        public virtual Proveedor_pago_parametros? Proveedor_pago_parametros { get; set; }


        [NotMapped]
        public string Nombre {
            get { return $"{(Nombres ?? "")} {(Apellidos ?? "")}"; }
            set
            {
                //throw new NotSupportedException("setBaseA");
            }
        }

        public static void ConfigureEntity(EntityTypeBuilder<Proveedor> modelBuilder)
        {




        }

    }
}

