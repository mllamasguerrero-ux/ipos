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
    public class Contacto : EntityBase
    {


        public Contacto() : base()
        {
        }

        public Contacto(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {

        }

        [StringLength(Domains.NombreLength)]
        public string? Nombre { get; set; }


        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Email { get; set; }


        [StringLength(Domains.Stdtext_shortLength)]
        public string? Telefono1 { get; set; }


        public long? Domicilioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioid")]
        public virtual Domicilio? Domicilio { get; set; }
    }
}
