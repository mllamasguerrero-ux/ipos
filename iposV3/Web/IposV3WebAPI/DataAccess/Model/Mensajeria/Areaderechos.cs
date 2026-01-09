
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
    public class Areaderechos : EntityBaseExt
    {


        public Areaderechos() : base()
        {
        }

        public Areaderechos(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Areaderechos(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    public long? Idarea { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Idarea")]
        public virtual Area? Area { get; set; }

        public long? Idderecho { get; set; }
        [ForeignKey("Idderecho")]
        public virtual Derechos? Derecho { get; set; }


    }
}

