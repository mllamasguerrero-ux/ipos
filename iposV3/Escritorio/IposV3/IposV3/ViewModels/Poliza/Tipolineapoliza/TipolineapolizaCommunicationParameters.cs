
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipolineapolizaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipolineapolizaItemVMInitialParameters() : base(0)
        {
        }

        public TipolineapolizaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipolineapolizaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipolineapolizaListVMInitialParameters() : base(0)
        {
        }

        public TipolineapolizaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipolineapolizaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipolineapolizaListVMEventParameters() : base(false)
        { }

        public TipolineapolizaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipolineapolizaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
