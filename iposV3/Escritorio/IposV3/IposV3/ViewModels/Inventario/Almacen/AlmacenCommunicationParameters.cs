
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class AlmacenItemVMInitialParameters : BaseCommonInitialParameters
    {

        public AlmacenItemVMInitialParameters() : base(0)
        {
        }

        public AlmacenItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class AlmacenListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public AlmacenListVMInitialParameters() : base(0)
        {
        }

        public AlmacenListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class AlmacenListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public AlmacenListVMEventParameters() : base(false)
        { }

        public AlmacenListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public AlmacenListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
