
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class Tableinfo:TableinfoGenerated
    {


    public Tableinfo() { }

    public Tableinfo(
		long? empresaid,
		long? sucursalid,
		long? id
		):base( 
     empresaid, sucursalid, id){

    }



  }


    public class OleTable
    {
        public int Id { get; set; }
        public string? Realname { get; set; }
        public string? Dbfname { get; set; }
    }



    public class OleField
    {
        public int Id { get; set; }
        public int Tableid { get; set; }
        public string? Realfnme { get; set; }
        public string? Dbffnme { get; set; }
        public int Fsize { get; set; }
        public int Fscale { get; set; }
        public string? Ftype { get; set; }
        public int Fprec { get; set; }

    }

}

