
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
    public class Caja_emida : EntityBaseExt
    {


        public Caja_emida() : base()
        {
        }

        public Caja_emida(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Caja_emida(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Cajaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Cajaid")]
        public virtual Caja? Caja { get; set; }

        public long? Terminalid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Terminalid")]
        public virtual Terminalpagoservicio? Terminal { get; set; }

        public long? Terminalserviciosid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Terminalserviciosid")]
        public virtual Terminalpagoservicio? Terminalservicios { get; set; }


    }
}

