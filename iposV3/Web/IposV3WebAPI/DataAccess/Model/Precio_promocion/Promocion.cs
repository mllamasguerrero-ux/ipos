
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
    public class Promocion : EntityBaseExt
    {


        public Promocion() : base()
        {
        }

        public Promocion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Promocion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.DescripcionLength)]
    public string? Descripcion { get; set; }

    
    public string? Memo { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN EsPromocion { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCS Lunes { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Martes { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Miercoles { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Jueves { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Viernes { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Sabado { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCS Domingo { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCN Enmonedero { get; set; } = BoolCN.N;


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Cantidad { get; set; }

        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal? Utilidad { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal? Cantidadllevate { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Importe { get; set; } 


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal? Porcentajedescuento { get; set; }

        public long? Tipopromocionid { get; set; }
        [ForeignKey("Tipopromocionid")]
        public virtual Tipopromocion? Tipopromocion { get; set; }

        public long? Rangopromocionid { get; set; }
        [ForeignKey("Rangopromocionid")]
        public virtual Rangopromocion? Rangopromocion { get; set; }

        public long? Lineaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Lineaid")]
        public virtual Linea? Linea { get; set; }

        public DateTimeOffset? Fechainicio { get; set; }

    public DateTimeOffset? Fechafin { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Porimporte { get; set; } = 0m;

        public string? Imagen { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Mostrardatoscliente { get; set; } = BoolCN.N;


        [Column(TypeName = "char(1)")]
        public BoolCN Esmultidetalle { get; set; } = BoolCN.N;


        [StringLength(Domains.Stdtext_largeLength)]
        public string? Descmultidetalle { get; set; }




    }
}

