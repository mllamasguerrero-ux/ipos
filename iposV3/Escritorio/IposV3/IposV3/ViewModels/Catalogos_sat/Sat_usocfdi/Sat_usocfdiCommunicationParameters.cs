
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_usocfdiItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_usocfdiItemVMInitialParameters() : base(0)
        {
        }

        public Sat_usocfdiItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_usocfdiListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_usocfdiListVMInitialParameters() : base(0)
        {
        }

        public Sat_usocfdiListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_usocfdiListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_usocfdiListVMEventParameters() : base(false)
        { }

        public Sat_usocfdiListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_usocfdiListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
