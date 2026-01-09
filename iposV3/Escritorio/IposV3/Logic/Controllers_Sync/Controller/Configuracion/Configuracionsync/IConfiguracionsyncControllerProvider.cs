
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using BindingModels;

namespace Controllers.Controller
{
    public interface IConfiguracionsyncControllerProvider : IConfiguracionsyncControllerProviderGenerated
    {

        IposV3.Model.Syncr.Configuracionsync? GetDefaultConfiguracion();

        void Test();

    }
}

