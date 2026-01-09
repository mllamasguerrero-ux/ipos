
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class LineaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public LineaItemVMInitialParameters() : base(0)
        {
        }

        public LineaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class LineaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public LineaListVMInitialParameters() : base(0)
        {
        }

        public LineaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class LineaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public LineaListVMEventParameters() : base(false)
        { }

        public LineaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public LineaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
