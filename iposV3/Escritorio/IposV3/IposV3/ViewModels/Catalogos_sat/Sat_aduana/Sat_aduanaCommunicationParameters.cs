
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_aduanaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_aduanaItemVMInitialParameters() : base(0)
        {
        }

        public Sat_aduanaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_aduanaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_aduanaListVMInitialParameters() : base(0)
        {
        }

        public Sat_aduanaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_aduanaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_aduanaListVMEventParameters() : base(false)
        { }

        public Sat_aduanaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_aduanaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
