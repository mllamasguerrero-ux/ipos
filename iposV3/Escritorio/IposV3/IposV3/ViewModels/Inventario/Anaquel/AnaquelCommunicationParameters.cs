
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class AnaquelItemVMInitialParameters : BaseCommonInitialParameters
    {

        public AnaquelItemVMInitialParameters() : base(0)
        {
        }

        public AnaquelItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class AnaquelListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public AnaquelListVMInitialParameters() : base(0)
        {
        }

        public AnaquelListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class AnaquelListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public AnaquelListVMEventParameters() : base(false)
        { }

        public AnaquelListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public AnaquelListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
