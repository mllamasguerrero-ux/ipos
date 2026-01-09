
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
    public class CartaporteMercancia : EntityBaseExt
    {


        public CartaporteMercancia() : base()
        {
        }

        public CartaporteMercancia(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public CartaporteMercancia(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }






        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Bienestransp { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Clavestcc { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descripcion { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Cantidad { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Claveunidad { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Unidad { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Dimensiones { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Materialpeligroso { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Cvematerialpeligroso { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Embalaje { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Descripembalaje { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pesoenkg { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Valormercancia { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Moneda { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Fraccionarancelaria { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Uuidcomercioext { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Unidadpesomerc { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pesobruto { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pesoneto { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pesotara { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numpiezas { get; set; }




  }
}

