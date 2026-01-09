using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Login_and_Maintenance
{
    public partial class TestLog : Form
    {
        public TestLog()
        {
            InitializeComponent();
        }

        private void TestLog_Load(object sender, EventArgs e)
        {

            string testJsonStr = "{ \"PRECIO1\":201.00, \"PRECIO2\":198.00, \"EAN\":\"PRODUCTO1test2\", \"FECHACAMBIOPRECIO\":\"2016-05-12\"}";
            string testJsonStrDespues = "{ \"PRECIO1\":202.00, \"PRECIO2\":199.00, \"EAN\":\"PRODUCTO1test3\", \"FECHACAMBIOPRECIO\":\"2016-05-13\"}";
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(testJsonStr);
            Dictionary<string, string> valuesDespues = JsonConvert.DeserializeObject<Dictionary<string, string>>(testJsonStrDespues);

            foreach(string keystr in values.Keys)
            {
               DSSeguridad.DETALLELOGRow dr =  this.dSSeguridad.DETALLELOG.NewDETALLELOGRow();
               dr.CAMPO = keystr;
               dr.ANTES = values[keystr].ToString();
               dr.DESPUES = valuesDespues[keystr].ToString();
               this.dSSeguridad.DETALLELOG.AddDETALLELOGRow(dr);

            }


        }
    }
}
