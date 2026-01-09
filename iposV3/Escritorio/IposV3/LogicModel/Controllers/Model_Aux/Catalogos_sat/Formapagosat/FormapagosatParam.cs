
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class FormapagosatParam : FormapagosatParamGenerated
    {

        public FormapagosatParam():base()
        {

        }

        public FormapagosatParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public FormapagosatParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public FormapagosatParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

