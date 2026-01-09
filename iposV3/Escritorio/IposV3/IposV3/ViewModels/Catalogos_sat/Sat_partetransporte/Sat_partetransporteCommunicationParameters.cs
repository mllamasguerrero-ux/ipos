
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_partetransporteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_partetransporteItemVMInitialParameters() : base(0)
        {
        }

        public Sat_partetransporteItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_partetransporteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_partetransporteListVMInitialParameters() : base(0)
        {
        }

        public Sat_partetransporteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_partetransporteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_partetransporteListVMEventParameters() : base(false)
        { }

        public Sat_partetransporteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_partetransporteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
