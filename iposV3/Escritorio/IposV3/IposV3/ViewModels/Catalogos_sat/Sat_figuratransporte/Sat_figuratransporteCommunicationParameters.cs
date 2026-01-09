
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_figuratransporteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_figuratransporteItemVMInitialParameters() : base(0)
        {
        }

        public Sat_figuratransporteItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_figuratransporteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_figuratransporteListVMInitialParameters() : base(0)
        {
        }

        public Sat_figuratransporteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_figuratransporteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_figuratransporteListVMEventParameters() : base(false)
        { }

        public Sat_figuratransporteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_figuratransporteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
