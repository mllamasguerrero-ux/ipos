
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
    public class Configuracionsync : EntityBaseExt
    {


        public Configuracionsync() : base()
        {
        }

        public Configuracionsync(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Configuracionsync(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Empresaclave { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Empresanombre { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Sucursalclave { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Sucursalnombre { get; set; }

    [StringLength(Domains.Stdtext_verylargeLength)]
    public string? Dblocal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Usuariolocal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Passwordlocal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Dbdestino { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Usuariodestino { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Passworddestino { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Dbtype { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Logactivo { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Correraliniciar { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Limitarhora { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Horainicial { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Horafinal { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Timeformat { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Nummaxregistros { get; set; }


    public int? Lastlog { get; set; }

    public int? Firstlog { get; set; }

    public int? Esperaentreenvios { get; set; }


  }
}

