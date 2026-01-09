
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
    public class CartaporteCanttransp : EntityBaseExt
    {


        public CartaporteCanttransp() : base()
        {
        }

        public CartaporteCanttransp(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public CartaporteCanttransp(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        public long? Cartaporteid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Cartaporteid")]
        public virtual Cartaporte? Cartaporte { get; set; }



        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Cantidad { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Idorigen { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Iddestino { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Cvestransporte { get; set; }




  }
}

