
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
    public class Ttl_docto_pers_mes : EntityBaseExt
    {


        public Ttl_docto_pers_mes() : base()
        {
        }

        public Ttl_docto_pers_mes(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Ttl_docto_pers_mes(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }

        public long? Tipodoctoid { get; set; }
        [ForeignKey("Tipodoctoid")]
        public virtual Tipodocto? Tipodocto { get; set; }

        public long? Personaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Personaid")]
        public virtual Cliente? Persona { get; set; }

        public int? Mes { get; set; }

    public int? Anio { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Cantidad { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Total { get; set; } = 0m;


        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Utilidad { get; set; } = 0m;

    public long? Subtipodoctoid { get; set; }
        [ForeignKey("Subtipodoctoid")]
        public virtual Subtipodocto? Subtipodocto { get; set; }


    }
}

