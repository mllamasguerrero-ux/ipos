
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
    public class Mensajeadjuntos : EntityBaseExt
    {


        public Mensajeadjuntos() : base()
        {
        }

        public Mensajeadjuntos(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Mensajeadjuntos(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Rutaadjunto { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Nombrearchivo { get; set; }

    [StringLength(Domains.Stdtext_largeLength)]
    public string? Ftpadjunto { get; set; }


    public long? Idmensaje { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Idmensaje")]
        public virtual Mensaje? Mensaje { get; set; }


    }
}

