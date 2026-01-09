
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
    public class Mensaje : EntityBaseExt
    {


        public Mensaje() : base()
        {
        }

        public Mensaje(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Mensaje(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



    [StringLength(Domains.Stdtext_largeLength)]
    public string? Asunto { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Codigolectura { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Paratodassuc { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Paratodasareas { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCS Soloadmin { get; set; } = BoolCS.S;

        [Column(TypeName = "char(1)")]
        public BoolCN Restrictivo { get; set; } = BoolCN.N;

        [StringLength(Domains.ClaveLength)]
    public string? Sucursalfuenteclave { get; set; }



    public long? Mensajetipoid { get; set; }
        [ForeignKey("Mensajetipoid")]
        public virtual Mensajetipo? Mensajetipo { get; set; }

        public DateTimeOffset? Fecha { get; set; }

    public DateTimeOffset? Fechahora { get; set; }

    public long? Mensajeraizid { get; set; }

    public long? Mensajepadreid { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Mensajepadreid")]
        public virtual Mensaje? Mensajepadre { get; set; }


        public long? Mensajeestadoid { get; set; }
        [ForeignKey("Mensajeestadoid")]
        public virtual Mensajeestado? Mensajeestado { get; set; }

        public long? Mensajeusuario { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Mensajeusuario")]
        public virtual Usuario? Mensajeusuario_ { get; set; }


        public long? Niveldeurgenciaid { get; set; }
        [ForeignKey("Niveldeurgenciaid")]
        public virtual Mensajenivelurgencia? Niveldeurgencia { get; set; }

        public string? MensajeTexto { get; set; }



        [NotMapped]
        public string? Clave { get { return this.Id.ToString() ?? ""; } set { throw new NotSupportedException("setBaseA"); } }

        [NotMapped]
        public string? Nombre { get { return this.Asunto ?? ""; } set { throw new NotSupportedException("setBaseA"); } }



    }
}

