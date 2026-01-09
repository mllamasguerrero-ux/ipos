using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class WFPagosCompuestosVMInitialParameters : BaseCommonInitialParameters
    {

        public long? TipoDoctoId { get; set; }

        public WFPagosCompuestosVMInitialParameters() : base(0)
        {
        }

        public WFPagosCompuestosVMInitialParameters(long? tipoDoctoId) : base(0)
        {
            TipoDoctoId = tipoDoctoId;
        }


    }
}
