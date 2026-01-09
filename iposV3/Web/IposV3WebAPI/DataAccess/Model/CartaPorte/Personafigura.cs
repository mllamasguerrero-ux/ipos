
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
    public class Personafigura : EntityBaseExt
    {


        public Personafigura() : base()
        {
        }

        public Personafigura(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Personafigura(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        public long? Personaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Personaid")]
        public virtual Usuario? Persona { get; set; }



        public long? Sat_Figuratransporteid { get; set; }

        [ForeignKey("Sat_Figuratransporteid")]
        public virtual Sat_figuratransporte? Sat_Figuratransporte { get; set; }

        [StringLength(Domains.Stdtext_lightLength)]
        public string? Numlicencia { get; set; }

        [StringLength(Domains.Stdtext_lightLength)]
        public string? Numregidtrib { get; set; }

        [StringLength(Domains.Stdtext_largeLength)]
        public string? Residenciafiscal { get; set; }

        public long? Sat_Partetransporteid { get; set; }

        [ForeignKey("Sat_Partetransporteid")]
        public virtual Sat_partetransporte? Sat_Partetransporte { get; set; }





   }
}

