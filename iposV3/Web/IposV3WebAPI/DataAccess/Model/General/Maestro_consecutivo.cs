
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


    public enum Tipo_consecutivo : long
    { FolioPago = 1, FolioDocto = 2, FolioSatDocto }


    public class Maestro_consecutivo : EntityBaseExt
    {


        public Maestro_consecutivo() : base()
        {
        }

        public Maestro_consecutivo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Maestro_consecutivo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.Stdtext_largeLength)]
    public string? Tabla { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Campo { get; set; }


    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Esquema { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Camposerie { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Serie { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Campoparent { get; set; }


    public long? Cod_tipo_consecutivo { get; set; }

    public long? Cod_parent_consecutivo { get; set; }

    public long? Numero_consecutivo { get; set; }

    public int? Cui { get; set; }

    public DateTimeOffset? Fui { get; set; }

    public string? Hui { get; set; }


  }
}

