
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{

    public class ConfiguracionItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ConfiguracionItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ConfiguracionListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }
        public ConfiguracionListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ConfiguracionListVMEventParameters : BaseCommonInitialParameters
    {

        public bool IsReloadEvent { get; set; }
        public ConfiguracionListVMEventParameters(bool isReloadEvent) : base(0)
        {
            IsReloadEvent = isReloadEvent;
        }
    }


}
