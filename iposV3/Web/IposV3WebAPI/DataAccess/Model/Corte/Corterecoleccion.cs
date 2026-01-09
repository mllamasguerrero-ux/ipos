
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
    public class Corterecoleccion : EntityBaseExt
    {


        public Corterecoleccion() : base()
        {
        }

        public Corterecoleccion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Corterecoleccion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Observaciones { get; set; }


    public long? Encargadoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Encargadoid")]
        public virtual Usuario? Encargado { get; set; }

        public DateTimeOffset? Fechahora { get; set; }


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Monto { get; set; } = 0m;


        [NotMapped]
        public string Clave { get; set; } = "";


        [NotMapped]
        public string Nombre { get; set; } = "";


    }
}

