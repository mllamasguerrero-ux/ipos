
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_metodopagoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_metodopagoItemVMInitialParameters() : base(0)
        {
        }

        public Sat_metodopagoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_metodopagoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_metodopagoListVMInitialParameters() : base(0)
        {
        }

        public Sat_metodopagoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_metodopagoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_metodopagoListVMEventParameters() : base(false)
        { }

        public Sat_metodopagoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_metodopagoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
