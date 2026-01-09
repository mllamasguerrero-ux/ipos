
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipodescuentoprodItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipodescuentoprodItemVMInitialParameters() : base(0)
        {
        }

        public TipodescuentoprodItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipodescuentoprodListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipodescuentoprodListVMInitialParameters() : base(0)
        {
        }

        public TipodescuentoprodListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipodescuentoprodListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipodescuentoprodListVMEventParameters() : base(false)
        { }

        public TipodescuentoprodListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipodescuentoprodListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
