
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class CorteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public CorteItemVMInitialParameters() : base(0)
        {
        }

        public CorteItemVMInitialParameters(long? Id) : base(Id)
        {
        }

        public long? Cajeroid { get; set; }
    }


    public class CorteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public CorteListVMInitialParameters() : base(0)
        {
        }

        public CorteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class CorteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public CorteListVMEventParameters() : base(false)
        { }

        public CorteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public CorteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
