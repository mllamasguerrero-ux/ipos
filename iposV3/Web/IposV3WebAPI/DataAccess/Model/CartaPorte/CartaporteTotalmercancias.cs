
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
    public class CartaporteTotalmercancias : EntityBaseExt
    {


        public CartaporteTotalmercancias() : base()
        {
        }

        public CartaporteTotalmercancias(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public CartaporteTotalmercancias(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }






        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pesobrutototal { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Unidadpeso { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Pesonetototal { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Numtotalmercancias { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Cargoportasacion { get; set; }



  }
}

