
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
    public class Comisionporlista : EntityBaseExt
    {


        public Comisionporlista() : base()
        {
        }

        public Comisionporlista(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Comisionporlista(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Precio1 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Precio2 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal? Precio3 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Precio4 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Precio5 { get; set; } = 0m;

        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Preciootro { get; set; } = 0m;


    }
}

