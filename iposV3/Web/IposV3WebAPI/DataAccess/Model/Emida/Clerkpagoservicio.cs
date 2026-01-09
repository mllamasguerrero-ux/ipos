
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
    public class Clerkpagoservicio : EntityBaseExt
    {


        public Clerkpagoservicio() : base()
        {
        }

        public Clerkpagoservicio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Clerkpagoservicio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Clerkid { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN? Esservicio { get; set; }


    public long? Sucursal_id { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Sucursal_id")]
        public virtual Sucursal_info? Sucursal_info { get; set; }


        [NotMapped]
        public string Clave
        {
            get { return Clerkid ?? ""; }
        }

        [NotMapped]
        public string Nombre
        {
            get { return Clerkid ?? ""; }
        }


    }
}

