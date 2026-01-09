
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class RutaembarqueItemVMInitialParameters : BaseCommonInitialParameters
    {

        public RutaembarqueItemVMInitialParameters() : base(0)
        {
        }

        public RutaembarqueItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class RutaembarqueListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public RutaembarqueListVMInitialParameters() : base(0)
        {
        }

        public RutaembarqueListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class RutaembarqueListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public RutaembarqueListVMEventParameters() : base(false)
        { }

        public RutaembarqueListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public RutaembarqueListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
