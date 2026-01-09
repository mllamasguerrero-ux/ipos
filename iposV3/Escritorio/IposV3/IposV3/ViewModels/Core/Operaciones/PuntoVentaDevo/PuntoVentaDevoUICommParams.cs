using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels.core.operaciones.puntoventa
{
    public class PuntoVentaDevoUICommParams
    {
        public string Action { get; set; }
        public List<string> Parameters { get; set; }

        public PuntoVentaDevoUICommParams(string action , List<string> parameters)
        {
            Action = action;

            Parameters = parameters;
        }
    }


    public class PuntoVentaDevoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PuntoVentaDevoListVMInitialParameters() : base(0)
        {
        }

        public PuntoVentaDevoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }



    public class PuntoVentaDevoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public PuntoVentaDevoListVMEventParameters() : base(false)
        { }

        public PuntoVentaDevoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PuntoVentaDevoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }


    public class PuntoVentaToDevoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PuntoVentaToDevoListVMInitialParameters() : base(0)
        {
        }

        public PuntoVentaToDevoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }



    public class PuntoVentaToDevoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public PuntoVentaToDevoListVMEventParameters() : base(false)
        { }

        public PuntoVentaToDevoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PuntoVentaToDevoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }

}
