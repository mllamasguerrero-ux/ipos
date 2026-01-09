
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
    public class Sucursal_info : EntityBaseExt
    {


        public Sucursal_info() : base()
        {
        }

        public Sucursal_info(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sucursal_info(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Esmatriz { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Esfranquicia { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_lightLength)]
        public string? Cuentareferencia { get; set; }

        [StringLength(Domains.Stdtext_shortLength)]
        public string? Cuentapoliza { get; set; }

        [StringLength(Domains.ClaveLength)]
        public string Clave { get; set; } = "";

        [StringLength(Domains.NombreLength)]
        public string Nombre { get; set; } = "";

        [StringLength(Domains.DescripcionLength)]
        public string? Descripcion { get; set; }

        public string? Memo { get; set; }

        public int Maxdoctospendientes { get; set; } = 0;


        public virtual Sucursal_info_opciones? Sucursal_info_opciones { get; set; }


    }
}

