
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
    public class Strucptosbancomer : EntityBaseExt
    {


        public Strucptosbancomer() : base()
        {
        }

        public Strucptosbancomer(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Strucptosbancomer(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.NombreLength)]
    public string? Cardrequest { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Ecoupnumber { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Factorexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesosredimidos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldoanterior { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldodisponible { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldodisponinleexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pesossaldoredimidosexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pooladjusttype { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Poolid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Poolnumber { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Poolunitlabel { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntosredimidos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldoanterior { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldodisponible { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldodisponibleexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Puntossaldoredimidoexp { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Segmentnumber { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Tipopos { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Vigenciapromocionexp { get; set; }



  }
}

