
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class WFPagosItemVMInitialParameters : BaseCommonInitialParameters
    {

        public long? TipoDoctoId { get; set; }

        public string? Mode { get; set; }

        public WFPagosItemVMInitialParameters() : base(0)
        {
        }

        public WFPagosItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class WFPagosListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public WFPagosListVMInitialParameters() : base(0)
        {
        }

        public WFPagosListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class WFPagosListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public WFPagosListVMEventParameters() : base(false)
        { }

        public WFPagosListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public WFPagosListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }



}
