
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class FormapagoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public FormapagoItemVMInitialParameters() : base(0)
        {
        }

        public FormapagoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class FormapagoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public FormapagoListVMInitialParameters() : base(0)
        {
        }

        public FormapagoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class FormapagoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public FormapagoListVMEventParameters() : base(false)
        { }

        public FormapagoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public FormapagoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
