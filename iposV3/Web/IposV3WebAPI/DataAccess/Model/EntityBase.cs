using Castle.Core.Resource;
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

    public enum BoolCS
    {
        S = 0,
        N = 1
    }
    public enum BoolCN
    {
        N = 0,
        S = 1
    }


    public enum BoolCNI
    {
        I = 0,
        N = 1,
        S = 2
    }


    public enum TipoPagoConTarjeta
    {
        I = 0,
        N = 1,
        S = 2,
        D = 3,
        C = 4
    }



    public enum BoolManejoReceta
    {
        N = 0,
        S = 1,
        R = 2
    }

    public static class Domains
    {
        public const int ClaveLength = 31;

        public const int Stdtext_mediumLength = 128;
        public const int Stdtext_shortLength = 32;
        public const int Stdtext_largeLength = 255;
        public const int Stdtext_verylargeLength = 512;
        public const int DescripcionLength = 255;
        public const int NombreLength = 127;
        public const int DoctoserieLength = 31;
        public const int ReferenciaLength = 31;
        public const int LoteLength = 31;
        public const int TitulocaracteristicaLength = 127;
        public const int Stdtext_64Length = 64;
        public const int SellosatLength = 512;

        public const int TyposyncmovilLength = 5;

        public const int Stdtext_lightLength = 64;
        public const int Clave_uniLength = 1;
        public const int PrefijoLength = 5;
        public const int PedimentoLength = 31;
        public const int LocalidadLength = 30;
        public const int LocacionLength = 25;
        public const int Clave_triLength = 3;
        public const int ZebraConfigLength = 10;


        public const int Stdtext_maxLength = 65535;

        public const int UniLength = 1;


        public const string TipoCambioDomain = "decimal(15, 2)";
        public const string PorcentajeDomain = "decimal(18, 4)";
        public const string NumericSatDomain = "numeric(15, 6)";
        public const string PrecioDomain = "numeric(20, 4)";
        public const string CantidadDomain = "numeric(18, 4)";
        public const string DecimalExactDomain = "numeric(18, 6)";
    }

    //[PrimaryKey(nameof(EmpresaId), nameof(SucursalId), nameof(Id))]
    public class EntityBase
    {


        #pragma warning disable CS8618
        public EntityBase()
        {
            Creado = DateTime.UtcNow;
            Modificado = DateTime.UtcNow;

            Activo = BoolCS.S;
        }
        #pragma warning restore CS8618


        public EntityBase(Empresa empresa, Sucursal sucursal) : this()
        {
            Empresa = empresa;
            Sucursal = sucursal;
        }

        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; } 

        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SucursalId { get; set; }


        [ForeignKey("EmpresaId, SucursalId")]
        public virtual Sucursal Sucursal { get; set; } 

        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Activo { get; set; }


        public DateTimeOffset Creado { get; set; }

        public DateTimeOffset Modificado { get; set; }


        public static void ConfigureEntityBaseKey<T>(EntityTypeBuilder<T> modelBuilder) where T: EntityBase
        {
            modelBuilder
                .HasKey(c => new { c.EmpresaId, c.SucursalId, c.Id });

        }


        [NotMapped]
        public virtual long? CreadoPorId { get; set; }

        [NotMapped]
        public virtual long? ModificadoPorId { get; set; }


    }


    public class EntityBaseExt: EntityBase
    {
        public EntityBaseExt():base() { }
        public EntityBaseExt(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal) { }
        public EntityBaseExt(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal) {
            CreadoPor = creadoPor;
        }



        public new long? CreadoPorId { get; set; }

        [ForeignKey("EmpresaId, SucursalId, CreadoPorId")]
        public virtual Usuario? CreadoPor { get; set; }


        public new long? ModificadoPorId { get; set; }

        [ForeignKey("EmpresaId, SucursalId, ModificadoPorId")]
        public virtual Usuario? ModificadoPor { get; set; }




    }


    //[PrimaryKey( nameof(Id))]
    public class EntityBaseGenericCatalog
    {

        public EntityBaseGenericCatalog()
        {
            Creado = DateTime.UtcNow;
            Modificado = DateTime.UtcNow;

            Activo = BoolCS.S;

            Clave = "";
            Nombre = "";
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Activo { get; set; }


        public DateTimeOffset Creado { get; set; }

        public DateTimeOffset Modificado { get; set; }



        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; }

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; }




        [NotMapped]
        public long EmpresaId { get; set; }


        [NotMapped]
        public long SucursalId { get; set; }


        [NotMapped]
        public virtual long? CreadoPorId { get; set; }

        [NotMapped]
        public virtual long? ModificadoPorId { get; set; }
    }



    public class EntityBaseCatalog : EntityBaseExt
    {

        public EntityBaseCatalog() : base()
        {
            Clave = "";
            Nombre = "";
        }
        public EntityBaseCatalog(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
            Clave = "";
            Nombre = "";
        }

        public EntityBaseCatalog(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
            Clave = "";
            Nombre = "";
        }



        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; }

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; }



    }




    public class EntityBaseGenericPseudoCatalog
    {

        public EntityBaseGenericPseudoCatalog()
        {
            Creado = DateTime.UtcNow;
            Modificado = DateTime.UtcNow;

            Activo = BoolCS.S;
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Activo { get; set; }


        public DateTimeOffset Creado { get; set; }

        public DateTimeOffset Modificado { get; set; }




        [NotMapped]
        public long EmpresaId { get; set; } = 0;


        [NotMapped]
        public long SucursalId { get; set; } = 0;


        [NotMapped]
        public virtual string Clave { get; set; } = "";

        [NotMapped]
        public virtual string Nombre { get; set; } = "";


        [NotMapped]
        public virtual long? CreadoPorId { get; set; }

        [NotMapped]
        public virtual long? ModificadoPorId { get; set; }


    }

    //[PrimaryKey(nameof(Id))]
    public class EntityBaseGeneric
    {

        public EntityBaseGeneric()
        {
            Creado = DateTime.UtcNow;
            Modificado = DateTime.UtcNow;

            Activo = BoolCS.S;
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Activo { get; set; }


        public DateTimeOffset Creado { get; set; }

        public DateTimeOffset Modificado { get; set; }




        [NotMapped]
        public long EmpresaId { get; set; } = 0;


        [NotMapped]
        public long SucursalId { get; set; } = 0;


        [NotMapped]
        public virtual long? CreadoPorId { get; set; }

        [NotMapped]
        public virtual long? ModificadoPorId { get; set; }


    }


    public class EntityBaseCatalogoSat
    {

        public EntityBaseCatalogoSat()
        {
            Creado = DateTime.UtcNow;
            Modificado = DateTime.UtcNow;

            Activo = BoolCS.S;
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCS Activo { get; set; }


        public DateTimeOffset Creado { get; set; }

        public DateTimeOffset Modificado { get; set; }





        [NotMapped]
        public long EmpresaId { get; set; } = 0;


        [NotMapped]
        public long SucursalId { get; set; } = 0;


        [NotMapped]
        public virtual long? CreadoPorId { get; set; }

        [NotMapped]
        public virtual long? ModificadoPorId { get; set; }



        [StringLength(Domains.Stdtext_64Length)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.DescripcionLength)]
        public string Descripcion { get; set; } = "";


        public DateTimeOffset? Fechainicio { get; set; }

        public DateTimeOffset? Fechafin { get; set; }

        [NotMapped]
        public virtual string Nombre
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
    }


}
