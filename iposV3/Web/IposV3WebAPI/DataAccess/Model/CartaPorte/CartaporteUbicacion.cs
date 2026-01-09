
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
    public class CartaporteUbicacion : EntityBaseExt
    {


        public CartaporteUbicacion() : base()
        {
        }

        public CartaporteUbicacion(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public CartaporteUbicacion(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Tipoubicacion { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Idubicacion { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Rfcremitentedestinatario { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombreremitentedestinatario { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numregidtrib { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Residenciafiscal { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numestacion { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Nombreestacion { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Navegaciontrafico { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Fechahorasalidallegada { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Tipoestacion { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Distanciarecorrida { get; set; }


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

