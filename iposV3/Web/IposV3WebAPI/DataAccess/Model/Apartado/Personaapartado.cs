
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
    public class Personaapartado : EntityBaseExt
    {


        public Personaapartado() : base()
        {
        }

        public Personaapartado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Personaapartado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [StringLength(Domains.ClaveLength)]
        public string? Clave { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombres { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Apellidos { get; set; }

        public long? Domicilioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioid")]
        public virtual Domicilio? Domicilio { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Telefono1 { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Celular { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Email1 { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string? Sat_clave_pais { get; set; }

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoapartado { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoapartadopositivo { get; set; } = 0m;

        [Column(TypeName = Domains.PrecioDomain)]
        public decimal Saldoapartadonegativo { get; set; } = 0m;





        [NotMapped]
        public string? Nombre { get { return ""; } }

    }
}

