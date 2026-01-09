
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class Configuracionsync: BaseSerializationObj
    {


    public Configuracionsync() { }

    public Configuracionsync(
		long? empresaid,
		long? sucursalid,
		long? id
		){
            Empresaid = empresaid;
            Sucursalid = sucursalid;
            Id = id;
    }


        public string? Activo { get; set; }

        public string? Empresaclave { get; set; }

        public string? Empresanombre { get; set; }

        public string? Sucursalclave { get; set; }

        public string? Sucursalnombre { get; set; }

        public string? Dblocal { get; set; }

        public string? Usuariolocal { get; set; }

        public string? Passwordlocal { get; set; }

        public string? Dbdestino { get; set; }

        public string? Usuariodestino { get; set; }

        public string? Passworddestino { get; set; }

        public string? Dbtype { get; set; }

        public string? Logactivo { get; set; }

        public string? Correraliniciar { get; set; }

        public string? Limitarhora { get; set; }

        public string? Horainicial { get; set; }

        public string? Horafinal { get; set; }

        public string? Timeformat { get; set; }

        public string? Nummaxregistros { get; set; }

        public long? Empresaid { get; set; }

        public long? Sucursalid { get; set; }

        public DateTimeOffset? Creado { get; set; }

        public long? Creadopor_userid { get; set; }

        public DateTimeOffset? Modificado { get; set; }

        public long? Modificadopor_userid { get; set; }

        public int? Lastlog { get; set; }

        public int? Firstlog { get; set; }

        public int? Esperaentreenvios { get; set; }


        public string? Usuarioiposlocal { get; set; }

        public string? Passwordiposlocal { get; set; }

        public string? Activarreplicacion { get; set; }

        public string? Activarsyncsuc { get; set; }


        public string? Serverlocal { get; set; }

        public string? Serverdestino { get; set; }

        public string? Portlocal { get; set; }

        public string? Portdestino { get; set; }


    }
}

