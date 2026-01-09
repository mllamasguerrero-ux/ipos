
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
    public class Archivosadjuntos : EntityBaseExt
    {


        public Archivosadjuntos() : base()
        {
        }

        public Archivosadjuntos(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Archivosadjuntos(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rutaarchivo { get; set; }

    [StringLength(Domains.NombreLength)]
    public string? Nombrearchivo { get; set; }


        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public int? Horasdetrabajo { get; set; }

    public DateTimeOffset? Fechadecreacion { get; set; }

    public DateTimeOffset? Fecha { get; set; }


  }
}

