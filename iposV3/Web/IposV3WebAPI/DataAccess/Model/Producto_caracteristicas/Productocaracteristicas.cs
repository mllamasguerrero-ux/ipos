
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
    public class Productocaracteristicas : EntityBaseExt
    {


        public Productocaracteristicas() : base()
        {
        }

        public Productocaracteristicas(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Productocaracteristicas(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Texto1 { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Texto2 { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Texto3 { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Texto4 { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Texto5 { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Texto6 { get; set; }


        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Numero1 { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Numero2 { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Numero3 { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal? Numero4 { get; set; }


    public DateTimeOffset? Fecha1 { get; set; }

    public DateTimeOffset? Fecha2 { get; set; }


  }
}

