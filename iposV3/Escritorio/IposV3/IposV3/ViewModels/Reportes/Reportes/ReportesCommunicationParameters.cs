
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ReportesItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ReportesItemVMInitialParameters() : base(0)
        {
        }

        public ReportesItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ReportesListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ReportesListVMInitialParameters() : base(0)
        {
        }

        public ReportesListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ReportesListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ReportesListVMEventParameters() : base(false)
        { }

        public ReportesListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ReportesListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
