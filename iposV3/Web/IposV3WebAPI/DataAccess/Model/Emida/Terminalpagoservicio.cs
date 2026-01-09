
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
    public class Terminalpagoservicio : EntityBaseExt
    {


        public Terminalpagoservicio() : base()
        {
        }

        public Terminalpagoservicio(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Terminalpagoservicio(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.ClaveLength)]
    public string? Terminal { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN? Esservicio { get; set; }


    public long? Sucursalinfoid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursalinfoid")]
        public virtual Sucursal_info? Sucursalinfo { get; set; }

        public long? Consecutivo { get; set; }


        [NotMapped]
        public  string? Clave
        {
            get { return Terminal ; }
            //set { Terminal = value; }
        }
        [NotMapped]
        public  string? Nombre
        {
            get { return Terminal; }
            //set { Terminal = value; }
        }


    }
}

