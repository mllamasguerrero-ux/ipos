
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
    public class Logeventotabla : EntityBaseExt
    {


        public Logeventotabla() : base()
        {
        }

        public Logeventotabla(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Logeventotabla(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.NombreLength)]
    public string? Tabla { get; set; }

    [StringLength(Domains.DescripcionLength)]
    public string? Nota { get; set; }


    public DateTimeOffset? Fechahora { get; set; }

    public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }

        public long? Tipoeventotablaid { get; set; }
        [ForeignKey("Tipoeventotablaid")]
        public virtual Tipoeventotabla? Tipoeventotabla { get; set; }

        public long? Recordid { get; set; }


  }
}

