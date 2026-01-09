
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
    public class Movto_devolucion : EntityBaseExt
    {


        public Movto_devolucion() : base()
        {
        }

        public Movto_devolucion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_devolucion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }

        public long? Movtorefid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtorefid")]
        public virtual Movto? Movtoref { get; set; }





        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadsurtida { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadfaltante { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidaddevuelta { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadsaldo { get; set; } = 0m;


        public long? Razondiferenciaid { get; set; }
        [ForeignKey("Razondiferenciaid")]
        public virtual Tipodiferenciainventario? Razondiferencia { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Otrarazondiferencia { get; set; }


  }
}

