
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
    public class CartaporteAutotransp : EntityBaseExt
    {


        public CartaporteAutotransp() : base()
        {
        }

        public CartaporteAutotransp(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public CartaporteAutotransp(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? TranspInternac { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Permsct { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numpermisosct { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Configvehicular { get; set; }

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

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Subtiporem1 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Placa1 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Subtiporem2 { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Placa2 { get; set; }





    }
}

