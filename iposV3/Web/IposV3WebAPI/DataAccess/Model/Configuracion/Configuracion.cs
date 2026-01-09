using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Configuracion: BaseSerializationObj
    {



        public Configuracion() { }



        public string? Activo { get; set; }

        public string? Clave { get; set; }

        public string? Nombre { get; set; }

        public long? Empresaid { get; set; }

        public long? Sucursalid { get; set; }

        public DateTimeOffset? Creado { get; set; }

        public long? Creadopor_userid { get; set; }

        public DateTimeOffset? Modificado { get; set; }

        public long? Modificadopor_userid { get; set; }


        public string? Database { get; set; }
        public string? Usuario { get; set; }
        public string? Password { get; set; }
        public string? Habilitar_impexp_aut { get; set; }



        public string? Empresaclave { get; set; }
        public string? Empresanombre { get; set; }


        public string? Sucursalclave { get; set; }
        public string? Sucursalnombre { get; set; }


        public long? Cajaid { get; set; }
        public string? Cajaclave { get; set; }
        public string? Cajanombre { get; set; }
        public string? Esmatriz { get; set; }
        public string? Basedirectory { get; set; }
        public int? Red { get; set; }
        public int? Blue { get; set; }
        public int? Green { get; set; }
        public string? Hab_pooling { get; set; }
        public string? Replicador { get; set; }
        public string? Servidor { get; set; }
        public string? Puerto { get; set; }

        public string? Esdefault { get; set; }



    }
}
