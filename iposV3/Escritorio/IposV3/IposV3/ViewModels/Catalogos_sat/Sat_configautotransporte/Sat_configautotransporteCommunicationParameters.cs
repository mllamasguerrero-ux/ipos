
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_configautotransporteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_configautotransporteItemVMInitialParameters() : base(0)
        {
        }

        public Sat_configautotransporteItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_configautotransporteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_configautotransporteListVMInitialParameters() : base(0)
        {
        }

        public Sat_configautotransporteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_configautotransporteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_configautotransporteListVMEventParameters() : base(false)
        { }

        public Sat_configautotransporteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_configautotransporteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
