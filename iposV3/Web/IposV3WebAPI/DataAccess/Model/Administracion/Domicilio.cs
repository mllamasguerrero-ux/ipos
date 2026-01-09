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
    [ComplexType]
    public class Domicilio: EntityBase
    {

        public Domicilio() : base()
        {
        }

        public Domicilio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {

        }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Calle { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Numeroexterior { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Numerointerior { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Colonia { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Ciudad { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Municipio { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Estado { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Pais { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Codigopostal { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Referencia { get; set; }


    }
}
