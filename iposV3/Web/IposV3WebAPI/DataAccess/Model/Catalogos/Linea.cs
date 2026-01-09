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
    public class Linea : EntityBaseExt
    {



        public Linea() : base()
        {
        }

        public Linea(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Linea(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";


        [Column(TypeName = "char(1)")]
        public BoolCN Acumulapromocion { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCS Aplicamayoreoxlinea { get; set; } = BoolCS.S;


        [StringLength(Domains.ClaveLength)]
        public string? Gpoimp { get; set; }


        [StringLength(Domains.ClaveLength)]
        public string? Tiporecarga { get; set; }


        [Column(TypeName = Domains.PorcentajeDomain)]
        public decimal Descuentovale { get; set; } = 0m;


    }
}
