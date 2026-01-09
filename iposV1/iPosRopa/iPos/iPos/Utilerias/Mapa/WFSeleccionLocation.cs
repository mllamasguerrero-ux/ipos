using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Utilerias.Mapa
{
    public partial class WFSeleccionLocation : Form
    {

        public string LatitudSelected { get; set; } = null;
        public string LongitudSelected { get; set; } = null;

        public WFSeleccionLocation()
        {
            InitializeComponent();

            webBrowserMap.ObjectForScripting = new MapBridge(OnMapLocationSelected);
            LoadMapHtml(null, null); // initial map with no marker
        }


        public WFSeleccionLocation(string latitud, string longitud)
        {
            InitializeComponent();

            this.LatitudSelected = latitud;
            this.LongitudSelected = longitud;

            webBrowserMap.ObjectForScripting = new MapBridge(OnMapLocationSelected);
            

            if (LatitudSelected != null && LongitudSelected != null &&
               LatitudSelected != "" && LongitudSelected != "")
            {
                double lat, lng;
                if (double.TryParse(latitud, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lat)
                    && double.TryParse(longitud, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lng))
                {
                    LoadMapHtml(lat, lng); // initial map with no marker
                }
            }
            else
                LoadMapHtml(null, null); // initial map with no marker

        }


            private void OnMapLocationSelected(double lat, double lng)
        {
            // Update UI from map callbacks
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnMapLocationSelected(lat, lng)));
                return;
            }

            txtLatitude.Text = lat.ToString(CultureInfo.InvariantCulture);
            txtLongitude.Text = lng.ToString(CultureInfo.InvariantCulture);
        }
        

        // Injects HTML map into the WebBrowser control.
        // If lat/lng are provided it will show a marker there.
        private void LoadMapHtml(double? latitude, double? longitude)
        {
            var latText = latitude.HasValue ? latitude.Value.ToString(CultureInfo.InvariantCulture) : "null";
            var lngText = longitude.HasValue ? longitude.Value.ToString(CultureInfo.InvariantCulture) : "null";

            string html = $@"
<!DOCTYPE html>
<html>
<head>
  <meta charset='utf-8' />
  <meta http-equiv='X-UA-Compatible' content='IE=Edge' />
  <title>Map</title>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css' />
  <style>html,body,#map{{height:100%;margin:0;padding:0}}</style>
</head>
<body>
  <div id='map'></div>
  <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
  <script>
    var initialLat = {latText};
    var initialLng = {lngText};
    var map = L.map('map').setView(initialLat === null ? [20,0] : [initialLat, initialLng], initialLat === null ? 2 : 13);
    L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{
      attribution: '© OpenStreetMap contributors'
    }}).addTo(map);
    var marker = null;
    if (initialLat !== null) {{
      marker = L.marker([initialLat, initialLng]).addTo(map);
    }}
    map.on('click', function(e) {{
      if (marker) map.removeLayer(marker);
      marker = L.marker(e.latlng).addTo(map);
      // call into WinForms
      try {{
        window.external.setLocation(e.latlng.lat.toString(), e.latlng.lng.toString());
      }} catch (ex) {{ console.log(ex); }}
    }});

    function setMarkerFromCs(lat, lng) {{
      if (marker) map.removeLayer(marker);
      marker = L.marker([lat, lng]).addTo(map);
      map.setView([lat, lng], 13);
    }}
  </script>
</body>
</html>";
            webBrowserMap.DocumentText = html;
        }

        // Called by designer when user updates the lat/lng textboxes manually (optional)
        private void txtLatitude_Leave(object sender, EventArgs e)
        {
            TryUpdateMapFromTextBoxes();
        }

        private void txtLongitude_Leave(object sender, EventArgs e)
        {
            TryUpdateMapFromTextBoxes();
        }

        private void TryUpdateMapFromTextBoxes()
        {
            this.TryUpdateMapFromStrings(this.txtLatitude.Text, this.txtLongitude.Text);
        }

        private void TryUpdateMapFromStrings( string latitud, string longitud)
        {
            double lat, lng;
            if (double.TryParse(latitud, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lat)
                && double.TryParse(longitud, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lng))
            {
                // call JS function to set marker
                if (webBrowserMap.Document != null)
                {
                    try
                    {
                        webBrowserMap.Document.InvokeScript("setMarkerFromCs", new object[] { lat.ToString(CultureInfo.InvariantCulture), lng.ToString(CultureInfo.InvariantCulture) });
                    }
                    catch { /* ignore if script not ready */ }
                }
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.LatitudSelected = txtLatitude.Text;
            this.LongitudSelected = txtLongitude.Text;
            this.Close();
        }

        private void WFSeleccionLocation_Load(object sender, EventArgs e)
        {
            if(LatitudSelected != null && LongitudSelected != null &&
               LatitudSelected != "" && LongitudSelected != "")
            {

                txtLatitude.Text = LatitudSelected;
                txtLongitude.Text = LongitudSelected;
                
            }
        }
    }
}
