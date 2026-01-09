using iPos.Catalogos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFLogDetail : IposForm
    {
        DataGridViewRow row;
        string before;
        string after;


        public WFLogDetail()
        {
            InitializeComponent();
        }

        public WFLogDetail(string table, DataGridViewRow row)
        {
            InitializeComponent();
            this.row = row;
            txtLogTable.Text = table;
            txtLogUser.Text = row.Cells["NOMBREUSUARIO"].Value.ToString();
            txtLogDate.Text = row.Cells["DGFECHAHORA"].Value.ToString();
            txtLogRegistry.Text = row.Cells["DGID"].Value.ToString();
            try
            {
                before = row.Cells["ANTES"].Value.ToString();
                after = row.Cells["DESPUES"].Value.ToString();
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(before);
                Dictionary<string, string> valuesDespues = JsonConvert.DeserializeObject<Dictionary<string, string>>(after);

                foreach (string keystr in values.Keys)
                {
                    DSCatalogos.DETALLELOGRow dr = this.dSCatalogos.DETALLELOG.NewDETALLELOGRow();
                    dr.CAMPO = keystr;
                    dr.ANTES = values[keystr].ToString();
                    dr.DESPUES = valuesDespues[keystr].ToString();
                    this.dSCatalogos.DETALLELOG.AddDETALLELOGRow(dr);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pueden mostrar las diferencias");
                this.Close();
            }
        }


    }
}
