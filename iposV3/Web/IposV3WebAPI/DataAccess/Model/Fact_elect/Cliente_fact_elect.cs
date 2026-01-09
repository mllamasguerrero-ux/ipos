
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
    public class Cliente_fact_elect : EntityBaseExt
    {


        public Cliente_fact_elect() : base()
        {
        }

        public Cliente_fact_elect(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Cliente_fact_elect(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN? Generarreciboelectronico { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN Retieneisr { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Retieneiva { get; set; } = BoolCN.N;

        [Column(TypeName = "char(1)")]
        public BoolCN Desglosaieps{ get; set; } = BoolCN.N;


        public long? Creditoformapagosatabonos { get; set; }
        [ForeignKey("Creditoformapagosatabonos")]
        public virtual Formapagosat? Creditoformapagosatabonos_ { get; set; }

        public long? Sat_usocfdiid { get; set; }
        [ForeignKey("Sat_usocfdiid")]
        public virtual Sat_usocfdi? Sat_usocfdi { get; set; }

        public long? Sat_id_pais { get; set; }
        [ForeignKey("Sat_id_pais")]
        public virtual Sat_pais? Sat_pais { get; set; }

        public long? Clienteid { get; set; }

        [ForeignKey("EmpresaId, SucursalId, Clienteid")]
        public virtual Cliente? Cliente { get; set; }




        public long? Sat_Coloniaid { get; set; }

        [ForeignKey("Sat_Coloniaid")]
        public virtual Sat_colonia? Sat_Colonia { get; set; }

        public long? Sat_Localidadid { get; set; }

        [ForeignKey("Sat_Localidadid")]
        public virtual Sat_localidad? Sat_Localidad { get; set; }

        public long? Sat_Municipioid { get; set; }

        [ForeignKey("Sat_Municipioid")]
        public virtual Sat_municipio? Sat_Municipio { get; set; }

        [Column(TypeName = Domains.CantidadDomain)]
        public decimal Distancia { get; set; }

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

        public long? Sat_Regimenfiscalid { get; set; }

        [ForeignKey("Sat_Regimenfiscalid")]
        public virtual Sat_regimenfiscal? Sat_Regimenfiscal { get; set; }


        [Column(TypeName = "char(1)")]
        public BoolCN? Generacomprobtrasl { get; set; }

        [Column(TypeName = "char(1)")]
        public BoolCN? Generacartaporte { get; set; }




    }
}

