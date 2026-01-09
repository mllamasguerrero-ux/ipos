
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class GrupodiferenciainventarioParam : GrupodiferenciainventarioParamGenerated
    {

        public GrupodiferenciainventarioParam():base()
        {

        }

        public GrupodiferenciainventarioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public GrupodiferenciainventarioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public GrupodiferenciainventarioParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

