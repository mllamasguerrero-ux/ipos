
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
    public class Sucursal_fact_elect : EntityBaseExt
    {


        public Sucursal_fact_elect() : base()
        {
        }

        public Sucursal_fact_elect(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sucursal_fact_elect(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }

        

        [Column(TypeName = "char(1)")]
        public BoolCN Por_fact_elect { get; set; } = BoolCN.N;

        [StringLength(Domains.Stdtext_mediumLength)]
    public string? Entregacalle { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Entreganumeroexterior { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Entreganumerointerior { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Entregacolonia { get; set; }

    [StringLength(Domains.Stdtext_mediumLength)]
    public string? Entregamunicipio { get; set; }

    [StringLength(Domains.Stdtext_shortLength)]
    public string? Entregacodigopostal { get; set; }


    public long? Sucursal_info_opciones_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursal_info_opciones_id")]
        public virtual Sucursal_info_opciones? Sucursal_info_opciones { get; set; }

        public long? Entregaestadoid { get; set; }
        [ForeignKey("Entregaestadoid")]
        public virtual Estadopais? Entregaestado { get; set; }





        public long? Entrega_Sat_Coloniaid { get; set; }

        [ForeignKey("Entrega_Sat_Coloniaid")]
        public virtual Sat_colonia? Entrega_Sat_Colonia { get; set; }

        public long? Entrega_Sat_Localidadid { get; set; }

        [ForeignKey("Entrega_Sat_Localidadid")]
        public virtual Sat_localidad? Entrega_Sat_Localidad { get; set; }

        public long? Entrega_Sat_Municipioid { get; set; }

        [ForeignKey("Entrega_Sat_Municipioid")]
        public virtual Sat_municipio? Entrega_Sat_Municipio { get; set; }


        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Entrega_Distancia { get; set; }

        [StringLength(Domains.Stdtext_mediumLength)]
        public string? Entregareferenciadom { get; set; }


    }
}

