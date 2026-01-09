using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3Sync.ViewModels
{
    public interface IMainWindowCommProvider
    {
        void FillMenuData(long empresaId, long sucursalId, long usuarioId);
        void GoToScreen(BaseScreen.BaseScreen screen);
    }
}
