
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
    public class Sucursal_traslado : EntityBaseExt
    {


        public Sucursal_traslado() : base()
        {
        }

        public Sucursal_traslado(Empresa empresa, Sucursal sucursal) : base(empresa, sucursal)
        {
        }
        public Sucursal_traslado(Empresa empresa, Sucursal sucursal, Usuario? creadoPor) : base(empresa, sucursal, creadoPor)
        {
        }



        [Column(TypeName = "char(1)")]
        public BoolCN Mostrarprecioreal { get; set; } = BoolCN.N;


        public long? Sucursal_info_opciones_id { get; set; }
        [ForeignKey("EmpresaId, SucursalId, Sucursal_info_opciones_id")]
        public virtual Sucursal_info_opciones? Sucursal_info_opciones { get; set; }

        public long? Preciorecepciontraslado { get; set; }
        [ForeignKey("Preciorecepciontraslado")]
        public virtual Tipo_precio? Preciorecepciontraslado_ { get; set; }

        public long? Precioenviotraslado { get; set; }
        [ForeignKey("Precioenviotraslado")]
        public virtual Tipo_precio? Precioenviotraslado_ { get; set; }

        public long? Lista_precio_traspaso { get; set; }
        [ForeignKey("Lista_precio_traspaso")]
        public virtual Tipo_precio? Lista_precio_traspaso_ { get; set; }



    }
}

