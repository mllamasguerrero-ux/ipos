
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
    public class Emidacomision : EntityBaseExt
    {


        public Emidacomision() : base()
        {
        }

        public Emidacomision(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Emidacomision(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Versionemida { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Responsecode { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Productid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Productdescription { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Productufee { get; set; }



  }
}

