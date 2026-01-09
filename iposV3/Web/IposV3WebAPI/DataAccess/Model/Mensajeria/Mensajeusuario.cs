
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
    public class Mensajeusuario : EntityBaseExt
    {


        public Mensajeusuario() : base()
        {
        }

        public Mensajeusuario(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Mensajeusuario(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Idmensaje { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Idmensaje")]
        public virtual Mensaje? Mensaje { get; set; }

        public long? Usuarioid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Usuarioid")]
        public virtual Usuario? Usuario { get; set; }

        public long? Mensajeestadoid { get; set; }
        [ForeignKey("Mensajeestadoid")]
        public virtual Mensajeestado? Mensajeestado { get; set; }


    }
}

