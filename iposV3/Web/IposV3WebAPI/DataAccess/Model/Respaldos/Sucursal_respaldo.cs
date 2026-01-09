
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
    public class Sucursal_respaldo : EntityBaseExt
    {


        public Sucursal_respaldo() : base()
        {
        }

        public Sucursal_respaldo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sucursal_respaldo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rutarespaldoorigen { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rutarespaldodestino { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rutarespaldored { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Nombrerespaldobd { get; set; }


        public long? Sucursal_info_opciones_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursal_info_opciones_id")]
        public virtual Sucursal_info_opciones? Sucursal_info_opciones { get; set; }


    }
}

