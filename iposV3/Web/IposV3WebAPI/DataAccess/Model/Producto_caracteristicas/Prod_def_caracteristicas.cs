
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
    public class Prod_def_caracteristicas : EntityBaseExt
    {


        public Prod_def_caracteristicas() : base()
        {
        }

        public Prod_def_caracteristicas(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Prod_def_caracteristicas(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Texto1 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Texto2 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Texto3 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Texto4 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Texto5 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Texto6 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Numero1 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Numero2 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Numero3 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Numero4 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Fecha1 { get; set; }

    [StringLength(Domains.TitulocaracteristicaLength)]
    public string? Fecha2 { get; set; }



  }
}

