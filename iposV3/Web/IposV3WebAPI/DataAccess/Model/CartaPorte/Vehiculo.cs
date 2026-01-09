
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
    public class Vehiculo : EntityBaseExt
    {


        public Vehiculo() : base()
        {
        }

        public Vehiculo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Vehiculo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Sat_Tipopermisoid { get; set; }

        [ForeignKey("Sat_Tipopermisoid")]
        public virtual Sat_tipopermiso? Sat_Tipopermiso { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numpermisosct { get; set; }



        public long? Sat_Configautotransporteid { get; set; }

        [ForeignKey("Sat_Configautotransporteid")]
        public virtual Sat_configautotransporte? Sat_Configautotransporte { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Placavm { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Aniomodelovm { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Asegurarespcivil { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Polizarespcivil { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Aseguramedambiente { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Polizamedambiente { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Aseguracarga { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Polizacarga { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Primaseguro { get; set; }



        public long? Sat_Subtiporem1id { get; set; }

        [ForeignKey("Sat_Subtiporem1id")]
        public virtual Sat_subtiporem? Sat_Subtiporem1 { get; set; }




        [StringLength(Domains.Stdtext_shortLength)]
        public string? Placa1 { get; set; }

        public long? Sat_Subtiporem2id { get; set; }

        [ForeignKey("Sat_Subtiporem2id")]
        public virtual Sat_subtiporem? Sat_Subtiporem2 { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Placa2 { get; set; }

        public long? Duenioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Duenioid")]
        public virtual Usuario? Duenio { get; set; }



        [NotMapped]
        public string? Clave { get { return Numpermisosct; } set { } }

        [NotMapped]
        public string? Nombre { get { return Placavm; } set { } }


    }
}

