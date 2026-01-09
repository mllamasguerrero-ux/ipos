
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_regimenfiscalItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_regimenfiscalItemVMInitialParameters() : base(0)
        {
        }

        public Sat_regimenfiscalItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_regimenfiscalListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_regimenfiscalListVMInitialParameters() : base(0)
        {
        }

        public Sat_regimenfiscalListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_regimenfiscalListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_regimenfiscalListVMEventParameters() : base(false)
        { }

        public Sat_regimenfiscalListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_regimenfiscalListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
