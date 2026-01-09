
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ProductoParam : ProductoParamGenerated
    {
        public string? CadenaBusqueda { get; set; }

        public bool PorExistenciaDeAlmacen { get; set; } = false;
        public long? AlmacenId { get; set; }

        public long? AlmacenId1 { get; set; }
        public long? AlmacenId2 { get; set; }
        public long? AlmacenId3 { get; set; }

        public bool SoloConExistencias { get; set; } = false;
        public TipoProductoPorPadreHijo? TipoProductoPorPadreHijo { get; set; } = IposV3.Model.TipoProductoPorPadreHijo.tp_todos;


        public bool ConHistorialMovil { get; set; } = false;
        public bool PromoMovil { get; set; } = false;
        public bool MostrarDescontinuados { get; set; } = true;

        public long? ClienteId { get; set; }
        public long? ProveedorId { get; set; }

        public decimal PorcUtilidad { get; set; } = 0m;


        public ProductoParam():base()
        {

        }

        public ProductoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ProductoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ProductoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }


    public enum TipoProductoPorPadreHijo { tp_todos, tp_hijos, tp_padres };
}

