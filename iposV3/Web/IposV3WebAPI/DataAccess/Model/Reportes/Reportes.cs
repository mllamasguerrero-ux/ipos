
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
    public class Reportes : EntityBaseExt
    {


        public Reportes() : base()
        {
        }

        public Reportes(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Reportes(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Archivo { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Descripcion { get; set; }



  }
}

