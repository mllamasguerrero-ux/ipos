
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
    public class Incidencia : EntityBaseExt
    {


        public Incidencia() : base()
        {
        }

        public Incidencia(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Incidencia(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Nota1 { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Nota2 { get; set; }


    public long? Tipoincidenciaid { get; set; }
        [ForeignKey("Tipoincidenciaid")]
        public virtual Tipoincidencia? Tipoincidencia { get; set; }

        public DateTimeOffset? Fechahora { get; set; }

    public long? Vendedorid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Vendedorid")]
        public virtual Usuario? Vendedor { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public long? Productoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Productoid")]
        public virtual Producto? Producto { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad1 { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad2 { get; set; } = 0m;


  }
}

