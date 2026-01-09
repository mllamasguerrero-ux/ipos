
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
    public class Llamadoemida : EntityBaseExt
    {


        public Llamadoemida() : base()
        {
        }

        public Llamadoemida(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Llamadoemida(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.DescripcionLength)]
    public string? Operacion { get; set; }

    [StringLength(Domains.Stdtext_lightLength)]
    public string? Referencia { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Responsecode { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Pin { get; set; }


    public long? Emidarequestid { get; set; }

    public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }

        public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }

        public long? Terminalid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Terminalid")]
        public virtual Terminalpagoservicio? Terminal { get; set; }

        public DateTimeOffset? Inicio { get; set; }

    public DateTimeOffset? Fin { get; set; }

    public int? Duracion { get; set; }


  }
}

