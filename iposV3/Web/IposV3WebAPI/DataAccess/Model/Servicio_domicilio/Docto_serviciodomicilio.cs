
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
    public class Docto_serviciodomicilio : EntityBaseExt
    {


        public Docto_serviciodomicilio() : base()
        {
        }

        public Docto_serviciodomicilio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_serviciodomicilio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }




        [Column(TypeName = "char(1)")]
        public BoolCN? Esservdomicilio { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }

        public long? Domicilioentregaid { get; set; }

        [ForeignKey("EmpresaId, SucursalId,Domicilioentregaid")]
        public virtual Domicilio? Domicilioentrega { get; set; }


    }
}

