
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
    public class Receta : EntityBaseExt
    {


        public Receta() : base()
        {
        }

        public Receta(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Receta(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Nombre { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Cedula { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Recetanumero { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Retenida { get; set; } = BoolCN.N;


        public long? Medicoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Medicoid")]
        public virtual Medico? Medico { get; set; }

        public long? Ventaid { get; set; }
        [ForeignKey("EmpresaId, SucursalId,Ventaid")]
        public virtual Docto? Venta { get; set; }

        public int? Folio { get; set; }


  }
}

