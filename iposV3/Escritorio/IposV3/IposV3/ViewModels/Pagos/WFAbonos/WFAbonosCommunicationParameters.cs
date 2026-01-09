
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class WFAbonosItemVMInitialParameters : BaseCommonInitialParameters
    {

        public long? TipoDoctoId { get; set; }

        public WFAbonosItemVMInitialParameters() : base(0)
        {
        }

        public WFAbonosItemVMInitialParameters(long? tipoDoctoId) : base(0)
        {
            TipoDoctoId = tipoDoctoId;
        }


    }


    public class WFAbonosListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public WFAbonosListVMInitialParameters() : base(0)
        {
        }

        public WFAbonosListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class WFAbonosListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public WFAbonosListVMEventParameters() : base(false)
        { }

        public WFAbonosListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public WFAbonosListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
