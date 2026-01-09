
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
    public class Docto_guia : EntityBaseExt
    {


        public Docto_guia() : base()
        {
        }

        public Docto_guia(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Docto_guia(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }


        [Column(TypeName = "char(1)")]
        public BoolCNI Usardatosentrega { get; set; } = BoolCNI.I;


    public long? Estadoguiaid { get; set; }

        [ForeignKey(" Estadoguiaid")]
        public virtual Estadoguia? Estadoguia { get; set; }

        public long? Guiaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Guiaid")]
        public virtual Guia? Guia { get; set; }

        public DateTimeOffset? Fechaguiaenviado { get; set; }

    public DateTimeOffset? Fechaguiarecibido { get; set; }

    public long? Personaidguiarecibio { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Personaidguiarecibio")]
        public virtual Usuario? Personaguiarecibio { get; set; }

        public long? Doctoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Doctoid")]
        public virtual Docto? Docto { get; set; }


    }
}

