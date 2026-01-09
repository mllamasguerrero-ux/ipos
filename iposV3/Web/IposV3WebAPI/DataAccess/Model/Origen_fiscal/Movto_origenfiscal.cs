
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
    public class Movto_origenfiscal : EntityBaseExt
    {


        public Movto_origenfiscal() : base()
        {
        }

        public Movto_origenfiscal(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Movto_origenfiscal(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidaddefactura { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidadderemision { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidaddeindefinido { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantdevueltadefactura { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantdevueltaderemision { get; set; } = 0m;

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantdevueltadeindefinido { get; set; } = 0m;

        public long? Movtoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Movtoid")]
        public virtual Movto? Movto { get; set; }


    }
}

