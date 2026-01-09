using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels.core.operaciones.puntoventa
{
    public class PuntoVentaUICommParams
    {
        public string Action { get; set; }
        public List<string> Parameters { get; set; }

        public PuntoVentaUICommParams(string action , List<string> parameters)
        {
            Action = action;

            Parameters = parameters;
        }
    }


    public class PuntoVentaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PuntoVentaListVMInitialParameters() : base(0)
        {
        }

        public PuntoVentaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }

    public class PuntoVentaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public PuntoVentaListVMEventParameters() : base(false)
        { }

        public PuntoVentaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PuntoVentaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }

}
