
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class SyncGenerated
    {


    public SyncGenerated() { }

    public SyncGenerated(
		long? empresaid,
		long? sucursalid,
		long? id
		) {

    this.Empresaid = empresaid;
    this.Sucursalid = sucursalid;
    this.Id = id;

    }



    public string? Activo { get; set; }

    public string? Archivoremoto { get; set; }

    public string? Nombre { get; set; }

    public string? Tiposyncclave { get; set; }

    public string? Tiposyncnombre { get; set; }

    public string? Tiposyncpathtemplate { get; set; }

    public string? Estadosyncclave { get; set; }

    public string? Estadosyncnombre { get; set; }

    public string? Reenviado { get; set; }

    public string? Sucursaldestinoclave { get; set; }

    public string? Doctotipoclave { get; set; }

    public string? Personaclave { get; set; }

    public string? Personanombres { get; set; }

    public string? Usuarioclave { get; set; }

    public string? Usuarionombres { get; set; }

    public string? Referenciarecepcion { get; set; }

    public string? Usuariorecepcionclave { get; set; }

    public string? Usuariorecepcionnombres { get; set; }

    public long? Empresaid { get; set; }

    public long? Sucursalid { get; set; }

    public long? Id { get; set; }

    public DateTime? Creado { get; set; }

    public long? Creadopor_userid { get; set; }

    public DateTime? Modificado { get; set; }

    public long? Modificadopor_userid { get; set; }

    public long? Tiposyncid { get; set; }

    public long? Estadosyncid { get; set; }

    public DateTime? Fechahoracreacion { get; set; }

    public DateTime? Fechahoraenvio { get; set; }

    public long? Sucursaldestinoid { get; set; }

    public int? Doctofolio { get; set; }

    public DateTime? Fechahorarecepcion { get; set; }



  }
}

