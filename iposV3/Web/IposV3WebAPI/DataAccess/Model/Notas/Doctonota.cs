
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
    public class Doctonota : EntityBaseExt
    {


        public Doctonota() : base()
        {
        }

        public Doctonota(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Doctonota(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




        public long? Doctoid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


        public long? Tipodoctonotaid { get; set; }

        [ForeignKey("Tipodoctonotaid")]
        public virtual Tipodoctonota? Tipodoctonota { get; set; }

        public DateTimeOffset? Fechahora { get; set; }

        public long? Usuarioid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }



        [StringLength(Domains.DescripcionLength)]
        public string? Nota { get; set; }


    }
}

