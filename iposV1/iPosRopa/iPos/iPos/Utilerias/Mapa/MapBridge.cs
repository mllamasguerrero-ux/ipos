using System;
using System.Runtime.InteropServices;

namespace iPos.Utilerias.Mapa
{
    // Bridge exposed to JavaScript (window.external)
    [ComVisible(true)]
    public class MapBridge
    {
        private readonly Action<double, double> _onLocationSelected;

        public MapBridge(Action<double, double> onLocationSelected)
        {
            _onLocationSelected = onLocationSelected;
        }

        // Called from JS: window.external.setLocation(lat, lng)
        public void setLocation(string lat, string lng)
        {
            double dlat, dlng;
            if (double.TryParse(lat, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out dlat)
                && double.TryParse(lng, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out dlng))
            {
                _onLocationSelected?.Invoke(dlat, dlng);
            }
        }
    }
}