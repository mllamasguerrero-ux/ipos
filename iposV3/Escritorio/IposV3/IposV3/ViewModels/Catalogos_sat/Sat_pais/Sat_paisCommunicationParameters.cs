
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_paisItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_paisItemVMInitialParameters() : base(0)
        {
        }

        public Sat_paisItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_paisListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_paisListVMInitialParameters() : base(0)
        {
        }

        public Sat_paisListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_paisListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_paisListVMEventParameters() : base(false)
        { }

        public Sat_paisListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_paisListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
