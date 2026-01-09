
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
    public class Ticketstemplates : EntityBaseExt
    {


        public Ticketstemplates() : base()
        {
        }

        public Ticketstemplates(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Ticketstemplates(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Tipo { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo1 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo2 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo3 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo4 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo5 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo6 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo7 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Subtipo8 { get; set; }

    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rutafinalreporte { get; set; }


    public string? Template { get; set; }


  }
}

