using BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels.core.operaciones.puntocompra
{
    public class PuntoCompraDevoUICommParams
    {
        public string Action { get; set; }
        public List<string> Parameters { get; set; }

        public PuntoCompraDevoUICommParams(string action , List<string> parameters)
        {
            Action = action;

            Parameters = parameters;
        }
    }



    public class PuntoCompraDevoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PuntoCompraDevoListVMInitialParameters() : base(0)
        {
        }

        public PuntoCompraDevoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }



    public class PuntoCompraDevoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public PuntoCompraDevoListVMEventParameters() : base(false)
        { }

        public PuntoCompraDevoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PuntoCompraDevoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }



    public class PuntoCompraToDevoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PuntoCompraToDevoListVMInitialParameters() : base(0)
        {
        }

        public PuntoCompraToDevoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }



    public class PuntoCompraToDevoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public PuntoCompraToDevoListVMEventParameters() : base(false)
        { }

        public PuntoCompraToDevoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PuntoCompraToDevoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }

}
