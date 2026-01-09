
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class PerfilesItemVMInitialParameters : BaseCommonInitialParameters
    {

        public PerfilesItemVMInitialParameters() : base(0)
        {
        }

        public PerfilesItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class PerfilesListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PerfilesListVMInitialParameters() : base(0)
        {
        }

        public PerfilesListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class PerfilesListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public PerfilesListVMEventParameters() : base(false)
        { }

        public PerfilesListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PerfilesListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
