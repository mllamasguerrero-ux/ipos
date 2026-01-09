
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_subtiporemItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_subtiporemItemVMInitialParameters() : base(0)
        {
        }

        public Sat_subtiporemItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_subtiporemListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_subtiporemListVMInitialParameters() : base(0)
        {
        }

        public Sat_subtiporemListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_subtiporemListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_subtiporemListVMEventParameters() : base(false)
        { }

        public Sat_subtiporemListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_subtiporemListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
