
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
    public class Cuentabanco : EntityBaseExt
    {


        public Cuentabanco() : base()
        {
        }

        public Cuentabanco(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cuentabanco(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    [StringLength(Domains.ClaveLength)]
    public string? Clave { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Nocuenta { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Rfc { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Predeterminada { get; set; } = BoolCN.N;


        public long? Bancoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Bancoid")]
        public virtual Banco? Banco { get; set; }


    }
}

