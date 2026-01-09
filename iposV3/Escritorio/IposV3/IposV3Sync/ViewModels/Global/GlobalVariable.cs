
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IposV3Sync.BindingModel;

namespace IposV3Sync.ViewModels
{
    public static class GlobalVariable
    {
        public static GlobalSession? CurrentSession { get; set; }

        public static Func<string>? CurrentDataBaseConnectionFnc { get; set; }

    }
}
