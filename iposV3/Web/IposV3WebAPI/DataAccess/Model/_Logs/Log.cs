
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
    public class Log : EntityBaseExt
    {


        public Log() : base()
        {
        }

        public Log(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Log(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Tablaid { get; set; }
        [ForeignKey("Tablaid")]
        public virtual Logtabla? Tabla { get; set; }

        public long? Registroid { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

    public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }

        //[StringLength(Domains.Stdtext_maxLength)]
        public string? Antes { get; set; }

        //[StringLength(Domains.Stdtext_maxLength)]
        public string? Despues { get; set; }


  }
}

