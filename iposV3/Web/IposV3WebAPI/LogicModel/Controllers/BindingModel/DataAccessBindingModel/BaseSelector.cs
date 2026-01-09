using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class BaseSelector
    {

        public BaseSelector()
        {
        }



        public BaseSelector(long? empresaId, long? sucursalId, long? id, string? clave, string? nombre)
        {


            Empresaid = empresaId;
            Sucursalid = sucursalId;
            Id = id;
            Clave = clave;
            Nombre = nombre;
        }

        public BaseSelector(long? empresaId, long? sucursalId, long? id, string? clave, string? nombre, string? texto1, long? long1 ) :
            this(empresaId, sucursalId, id,  clave,  nombre)
        {
            Texto1 = texto1;
            Long1 = long1;
        }

        public BaseSelector( long? id, string? clave, string? nombre):
            this(0, 0, id,  clave, nombre)
        {


            Empresaid = 0;
            Sucursalid = 0;
            Id = id;
            Clave = clave;
            Nombre = nombre;
        }



        public long? Empresaid { get; set; }

        public long? Sucursalid { get; set; }
        public long? Id { get; set; }
        public string? Clave { get; set; }
        public string? Nombre { get; set; }

        public string? Texto1 { get; set; }
        public long? Long1 { get; set; }
    }
}
