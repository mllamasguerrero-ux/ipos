
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class WFGuiaPopUpItemVMInitialParameters : BaseCommonInitialParameters
    {

        public WFGuiaPopUpItemVMInitialParameters() : base(0)
        {
        }

        public WFGuiaPopUpItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class WFGuiaPopUpListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public WFGuiaPopUpListVMInitialParameters() : base(0)
        {
        }

        public WFGuiaPopUpListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class WFGuiaPopUpListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public WFGuiaPopUpListVMEventParameters() : base(false)
        { }

        public WFGuiaPopUpListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public WFGuiaPopUpListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
