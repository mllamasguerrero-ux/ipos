
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TiporecargaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TiporecargaItemVMInitialParameters() : base(0)
        {
        }

        public TiporecargaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TiporecargaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TiporecargaListVMInitialParameters() : base(0)
        {
        }

        public TiporecargaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TiporecargaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TiporecargaListVMEventParameters() : base(false)
        { }

        public TiporecargaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TiporecargaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
