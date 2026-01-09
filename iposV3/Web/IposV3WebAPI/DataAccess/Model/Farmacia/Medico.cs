
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
    public class Medico : EntityBaseExt
    {


        public Medico() : base()
        {
        }

        public Medico(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Medico(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Cedula { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Medicopropio { get; set; } = BoolCN.N;



    }
}

