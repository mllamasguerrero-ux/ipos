
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
    public class Personacuentabanco : EntityBaseExt
    {


        public Personacuentabanco() : base()
        {
        }

        public Personacuentabanco(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Personacuentabanco(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Nocuenta { get; set; }


    public long? Bancoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Bancoid")]
        public virtual Banco? Banco { get; set; }

        public long? Personaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaid")]
        public virtual Cliente? Persona { get; set; }


    }
}

