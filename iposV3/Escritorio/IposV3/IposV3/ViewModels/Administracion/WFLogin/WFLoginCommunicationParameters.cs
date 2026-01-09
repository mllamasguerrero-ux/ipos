
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class WFLoginItemVMInitialParameters : BaseCommonInitialParameters
    {

        public WFLoginItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class WFLoginListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }
        public WFLoginListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class WFLoginListVMEventParameters : BaseCommonInitialParameters
    {

        public bool IsReloadEvent { get; set; }
        public WFLoginListVMEventParameters(bool isReloadEvent) : base(0)
        {
            IsReloadEvent = isReloadEvent;
        }
    }


}
