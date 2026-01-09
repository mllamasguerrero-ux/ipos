
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
    public class CartaporteTransptipofigura : EntityBaseExt
    {


        public CartaporteTransptipofigura() : base()
        {
        }

        public CartaporteTransptipofigura(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public CartaporteTransptipofigura(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Tipofigura { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Rfcfigura { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numlicencia { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombrefigura { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numregidtribfigura { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Residenciafiscalfigura { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Partetransporte { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Calle { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numeroexterior { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numerointerior { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Colonia { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Localidad { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Referencia { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Municipio { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Estado { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pais { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Codigopostal { get; set; }




  }
}

