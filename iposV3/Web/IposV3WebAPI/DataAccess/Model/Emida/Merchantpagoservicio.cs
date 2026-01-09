
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
    public class Merchantpagoservicio : EntityBaseExt
    {


        public Merchantpagoservicio() : base()
        {
        }

        public Merchantpagoservicio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Merchantpagoservicio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Merchantid { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN? Esservicio { get; set; }


    public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }


    }
}

