
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
    public class Ingresuc_tipolinea : EntityBaseGenericCatalog
    {


        public Ingresuc_tipolinea() : base()
        {
        }


    [StringLength(Domains.DescripcionLength)]
    public string? Descripcion { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Estequileno { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Esfactura { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Escredito { get; set; } = BoolCN.N;

        [StringLength(Domains.UniLength)]
        public string Tiporeg { get; set; } = "";



  }
}

