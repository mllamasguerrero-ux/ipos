using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using FirebirdSql.Data.FirebirdClient;
using iPos;
namespace System.Windows.Forms
{
    class ComboBoxFB:ComboBox
    {
        private string query;
        public string Query
        {
            get
            {
                return query;
            }
            set
            {
                this.query = value;
            }
        }
        private string condicion;
        public string Condicion
        {
            get
            {
                return condicion;
            }
            set
            {
                this.condicion = value;
            }
        }
        private string queryDeSeleccion;
        public string QueryDeSeleccion
        {
            get
            {
                return queryDeSeleccion;
            }
            set
            {
                this.queryDeSeleccion = value;
            }
        }
        private FbDbType dataBaseType;
        public FbDbType DataBaseType
        {
            get
            {
                return dataBaseType;
            }
            set
            {
                this.dataBaseType = value;
            }
        }
        private string nombreCampoSelector;
        public string NombreCampoSelector
        {
            get
            {
                return nombreCampoSelector;
            }
            set
            {
                this.nombreCampoSelector = value;
            }
        }
        private Label labelDescription;
    
        public Label LabelDescription
        {
            get
            {
                return labelDescription;
            }
            set
            {
                this.labelDescription = value;
            }
        }
        [DefaultValue(0)]
        private int indiceCampoSelector;
        public int IndiceCampoSelector
        {
            get
            {
                return indiceCampoSelector;
            }
            set
            {
                this.indiceCampoSelector = value;
            }
        }
        public object SelectedDataValue
        {
            get
            {
                if (this.SelectedIndex < 0)
                {
                    return null;
                }
                return ((System.Data.DataRowView)this.Items[this.SelectedIndex])[this.ValueMember];
            
               
            }
            set
            {
                
                IEnumerable<System.Data.DataRowView> itemsDR = this.Items.OfType<System.Data.DataRowView>();
                int contador = 0;
                foreach (System.Data.DataRowView itemDR in itemsDR)
                {
                    if (itemDR[this.ValueMember].ToString() == value.ToString())
                    {
                        this.SelectedIndex = contador;
                        this.Text = itemDR[this.DisplayMember].ToString();
                        return;
                    }
                    contador++;
                }
            }
        }



        public object SelectedDataDisplaying
        {
            get
            {
                if (this.SelectedIndex < 0)
                {
                    return null;
                }
                return ((System.Data.DataRowView)this.Items[this.SelectedIndex])[this.DisplayMember];


            }
            set
            {

                IEnumerable<System.Data.DataRowView> itemsDR = this.Items.OfType<System.Data.DataRowView>();
                int contador = 0;
                foreach (System.Data.DataRowView itemDR in itemsDR)
                {
                    if (itemDR[this.DisplayMember].ToString().Trim() == value.ToString().Trim())
                    {
                        this.SelectedIndex = contador;
                        this.Text = itemDR[this.DisplayMember].ToString();
                        return;
                    }
                    contador++;
                }
            }
        }

        public ComboBoxFB()
        {
        }
        public void llenarDatos()
        {
            try
            {
                BindingSource bindingSource1_LOOKUP;
                FbCommand FbCommand1_LOOKUP;
                bindingSource1_LOOKUP = new System.Windows.Forms.BindingSource();
                FbCommand1_LOOKUP = new FirebirdSql.Data.FirebirdClient.FbCommand();
                FbCommand1_LOOKUP.CommandTimeout = 30;
                FbCommand1_LOOKUP.CommandText = this.Query;
                bindingSource1_LOOKUP.DataSource = DataTablesParaGrid.GetData(FbCommand1_LOOKUP);
                DataSource = bindingSource1_LOOKUP;
            }
            catch
            {
            }
           
            
            
        }
        //public bool SelectDataValue(object value)
        //{
        //    IEnumerable<System.Data.DataRowView> itemsDR = this.Items.OfType<System.Data.DataRowView>();
        //    int contador=0;
        //    foreach (System.Data.DataRowView itemDR in itemsDR)
        //    {
        //        if (itemDR[this.ValueMember].ToString() == value.ToString())
        //        {
        //            this.SelectedIndex = contador;
        //            this.Text = itemDR[this.DisplayMember].ToString();
        //            return true;
        //        }
        //            contador ++;
        //     }
        //    return false;
        //}
        //public object SelectedDataValue()
        //{
        //    if (this.SelectedIndex < 0)
        //    {
        //        return null;
        //    }
        //    return ((System.Data.DataRowView)this.Items[this.SelectedIndex])[this.ValueMember];
        //    /*IEnumerable<System.Data.DataRowView> itemsDR = this.Items.OfType<System.Data.DataRowView>();
        //    int contador = 0;
        //    foreach (System.Data.DataRowView itemDR in itemsDR)
        //    {
        //        if (itemDR[this.ValueMember].ToString() == value.ToString())
        //        {
        //            this.SelectedItem = itemDR;
        //            this.SelectedText = itemDR[this.DisplayMember].ToString();
        //            return true;
        //        }
        //        contador++;
        //    }
        //    return false;*/
        //}
    }
}
