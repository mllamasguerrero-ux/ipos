
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class LotesimportadosParam : LotesimportadosParamGenerated
    {

        public LotesimportadosParam():base()
        {

        }

        public LotesimportadosParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public LotesimportadosParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public LotesimportadosParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

