
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_coloniaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_coloniaItemVMInitialParameters() : base(0)
        {
        }

        public Sat_coloniaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_coloniaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_coloniaListVMInitialParameters() : base(0)
        {
        }

        public Sat_coloniaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_coloniaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_coloniaListVMEventParameters() : base(false)
        { }

        public Sat_coloniaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_coloniaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
