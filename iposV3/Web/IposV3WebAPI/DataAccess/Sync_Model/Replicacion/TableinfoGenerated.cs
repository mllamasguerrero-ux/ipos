
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class TableinfoGenerated
    {


    public TableinfoGenerated() { }

    public TableinfoGenerated(
		long? empresaid,
		long? sucursalid,
		long? id
		) {

    this.Empresaid = empresaid;
    this.Sucursalid = sucursalid;
    this.Id = id;

    }



    public string? Activo { get; set; }

    public string? Tablename { get; set; }

    public string? Schemaname { get; set; }

    public long? Empresaid { get; set; }

    public long? Sucursalid { get; set; }

    public long? Id { get; set; }

    public DateTime? Creado { get; set; }

    public long? Creadopor_userid { get; set; }

    public DateTime? Modificado { get; set; }

    public long? Modificadopor_userid { get; set; }


  }
}

