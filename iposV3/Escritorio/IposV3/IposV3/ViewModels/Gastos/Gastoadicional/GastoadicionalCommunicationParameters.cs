
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class GastoadicionalItemVMInitialParameters : BaseCommonInitialParameters
    {

        public GastoadicionalItemVMInitialParameters() : base(0)
        {
        }

        public GastoadicionalItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class GastoadicionalListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public GastoadicionalListVMInitialParameters() : base(0)
        {
        }

        public GastoadicionalListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class GastoadicionalListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public GastoadicionalListVMEventParameters() : base(false)
        { }

        public GastoadicionalListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public GastoadicionalListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
