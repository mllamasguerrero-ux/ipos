
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
    public class Docto_ventafuturo : EntityBaseExt
    {


        public Docto_ventafuturo() : base()
        {
        }

        public Docto_ventafuturo(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_ventafuturo(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


    public long? Ventafutuid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Ventafutuid")]
        public virtual Docto? Ventafutu { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

