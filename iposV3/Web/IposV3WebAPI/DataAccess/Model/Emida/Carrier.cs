
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
    public class Carrier : EntityBaseExt
    {


        public Carrier() : base()
        {
        }

        public Carrier(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Carrier(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Carrierid { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Description { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Productcount { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN? Esservicio { get; set; }



  }
}

