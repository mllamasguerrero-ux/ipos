
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipodiferenciainventarioParam : TipodiferenciainventarioParamGenerated
    {

        public TipodiferenciainventarioParam():base()
        {

        }

        public TipodiferenciainventarioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipodiferenciainventarioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipodiferenciainventarioParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

