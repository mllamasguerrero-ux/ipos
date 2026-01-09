
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
enum eTipoDatosBusqueda : int
{
    tipoBusqNumero = 1,
    tipoBusqFecha,
    tipoBusqString
}
namespace iPos
{
    
    public struct generalLookUpCampo
    {
        public string   strNombreCampo;
        public int      iTipoCampoBusq;
        public Type     tTipoDato;
    }
    public partial class GeneralLookUp : IposForm
    {
        
        public DataRow m_rtnDataRow; 
        
        System.Collections.Hashtable m_htCamposQuery; 
        
        String m_strQuery;
        String m_initialQuery;
        
        int  m_iArrayFieldsFilled;
        bool m_bColumnsAdjusted;
        
        int  m_iGridWidth;
        
        public GeneralLookUp(string query, string title)
        {
            InitializeComponent();
            m_htCamposQuery = new Hashtable();
            m_iArrayFieldsFilled = 0;
            m_bColumnsAdjusted = false;
            m_iGridWidth = 0;
            m_strQuery = "Select * from ( " + query + " ) mainQry ";
            m_initialQuery = "";
            
            this.FbCommand1_LOOKUP.Parameters.Clear();
            this.FbCommand1_LOOKUP.CommandText = m_strQuery;
            this.label4_LOOKUP.Text = title;
            this.Text = title;

        }


        public GeneralLookUp(string query, string title, string initialQuery)
            : this(query, title)
        {
            //int iIndexOperador = this.DDOperador_LOOKUP.FindStringExact(operador);         
            //int iIndexCampo    = this.DDBuscar_LOOKUP.FindStringExact(campo);
            //if(iIndexCampo >= 0)
            //    this.DDBuscar_LOOKUP.SelectedIndex   = iIndexCampo;
            //if (iIndexOperador >= 0)
            //    this.DDOperador_LOOKUP.SelectedIndex = iIndexOperador;
            m_initialQuery = initialQuery; 
            //this.TBValor_LOOKUP.Text = valor;
        }


        
        private void AjustarAnchoCol()
        {
            if (!m_bColumnsAdjusted)
            {
                if (m_iGridWidth < this.Width)
                {
                    this.dataGridView1_LOOKUP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                }
                
                m_bColumnsAdjusted = true;
            }
        }
        private void LlenarDataGrid_LOOKUP()
        {
            try
            {
                CargarFiltro_LOOKUP();
                dataGridView1_LOOKUP.AutoGenerateColumns = true;
                bindingSource1_LOOKUP.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_LOOKUP);
                dataGridView1_LOOKUP.DataSource = bindingSource1_LOOKUP;
                dataGridView1_LOOKUP.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1_LOOKUP.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1_LOOKUP.EditMode = DataGridViewEditMode.EditOnEnter;
                AjustarAnchoCol();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error. Asegures de que el formato de entrada es correcto para el campo de busqueda" + ex.Message);
               // MessageBox.Show(ex.Message + ex.StackTrace, "ERROR",
                //MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //System.Threading.Thread.CurrentThread.Abort();
            }
        }
        private void LOOKUPLookUp_Load(object sender, EventArgs e)
        {
            LlenarDataGrid_LOOKUP();
            this.DDBuscar_LOOKUP.SelectedIndex = 0;
            this.DDOperador_LOOKUP.SelectedIndex = 2;
            
            // poner por default el campo de nombre si existe
            for(int i = 0; i < this.DDBuscar_LOOKUP.Items.Count; i++)
            {
                if (this.DDBuscar_LOOKUP.Items[i].ToString().ToUpper().Equals("NOMBRE"))
                {
                    this.DDBuscar_LOOKUP.SelectedIndex = i;
                    break;
                }
            }
        }
        public FirebirdSql.Data.FirebirdClient.FbDbType GetFbDbType(Type langType)
        {
            if (langType == typeof(System.Int32))
                return FirebirdSql.Data.FirebirdClient.FbDbType.Integer;
            if (langType == typeof(System.Int16))
                return FirebirdSql.Data.FirebirdClient.FbDbType.SmallInt;
            if (langType == typeof(System.Int64))
                return FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            if (langType == typeof(System.Double))
                return FirebirdSql.Data.FirebirdClient.FbDbType.Double;
            if (langType == typeof(System.Decimal))
                return FirebirdSql.Data.FirebirdClient.FbDbType.Decimal;
            if (langType == typeof(System.DateTime))
                return FirebirdSql.Data.FirebirdClient.FbDbType.Date;
            if (langType == typeof(System.String))
                return FirebirdSql.Data.FirebirdClient.FbDbType.VarChar;
            return FirebirdSql.Data.FirebirdClient.FbDbType.VarChar;
        }
        private void CargarFiltro_LOOKUP()
        {
            String CmdTxt, strOperador = "";
            this.FbCommand1_LOOKUP.Parameters.Clear();
            try
            {
                if (this.DDOperador_LOOKUP.SelectedItem == null || this.TBValor_LOOKUP.Text == "")
                {
                    if (m_initialQuery != "")
                    {
                        CmdTxt = m_initialQuery;
                        m_initialQuery = "";
                    }
                    else
                        CmdTxt = m_strQuery;

                    this.FbCommand1_LOOKUP.CommandText = CmdTxt;
                    return;
                }

                switch (this.DDOperador_LOOKUP.SelectedItem.ToString())
                {
                    case "Igual":
                        strOperador = "=";
                        break;
                    case "Menor Igual":
                        strOperador = "<=";
                        break;
                    case "Mayor Igual":
                        strOperador = ">=";
                        break;
                    case "Empiece":
                        strOperador = "starting with";
                        break;
                    case "Contenga":
                        strOperador = "containing";
                        break;
                    default:
                        return;
                }
            }
            catch
            {
                return;
            }
            generalLookUpCampo fld = (generalLookUpCampo)m_htCamposQuery[this.DDBuscar_LOOKUP.SelectedItem.ToString()];
            try
            {
                switch (fld.iTipoCampoBusq)
                {
                    case (int)eTipoDatosBusqueda.tipoBusqNumero:
                    case (int)eTipoDatosBusqueda.tipoBusqString:
                        CmdTxt = m_strQuery + " where " + this.DDBuscar_LOOKUP.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_LOOKUP.SelectedItem.ToString();
                        this.FbCommand1_LOOKUP.CommandText = CmdTxt;
                        this.FbCommand1_LOOKUP.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
                new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_LOOKUP.SelectedItem.ToString(), GetFbDbType(fld.tTipoDato))});
                        this.FbCommand1_LOOKUP.Parameters["@v" + fld.strNombreCampo].Value = TBValor_LOOKUP.Text;
                        break;
                    default:
                        CmdTxt = m_strQuery;
                        break;
                }
            }
            catch
            {
            }
        }
        private void button1_LOOKUP_Click(object sender, EventArgs e)
        {
            LlenarDataGrid_LOOKUP();
        }
        private void button3_LOOKUP_Click(object sender, EventArgs e)
        {
            try
            {
                this.FbCommand1_LOOKUP.Parameters.Clear();
                this.FbCommand1_LOOKUP.CommandText = m_strQuery;
                dataGridView1_LOOKUP.AutoGenerateColumns = false;
                bindingSource1_LOOKUP.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_LOOKUP);
                dataGridView1_LOOKUP.DataSource = bindingSource1_LOOKUP;
                dataGridView1_LOOKUP.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1_LOOKUP.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1_LOOKUP.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
     private void dataGridView1_LOOKUP_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dataGridView1_LOOKUP.Rows[e.RowIndex].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_LOOKUP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridView1_LOOKUP.CurrentCell = dataGridView1_LOOKUP[e.ColumnIndex, e.RowIndex];
            bindingSource1_LOOKUP.CancelEdit();
            MessageBox.Show("Ocurrio un error");
        }
        private void dataGridView1_LOOKUP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void RetornarSeleccion()
        {
            try
            {
                m_rtnDataRow = (this.dataGridView1_LOOKUP.CurrentRow.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        private void dataGridView1_LOOKUP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RetornarSeleccion();
        }
        private void dataGridView1_LOOKUP_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            
            
        }
        private void dataGridView1_LOOKUP_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (m_iArrayFieldsFilled <= e.Column.Index)
            {
                generalLookUpCampo fld = new generalLookUpCampo();
                fld.strNombreCampo = e.Column.DataPropertyName;
                fld.tTipoDato = e.Column.ValueType;
                this.DDBuscar_LOOKUP.Items.Add(e.Column.DataPropertyName);
                if (e.Column.ValueType == typeof(System.Int32)
                    || e.Column.ValueType == typeof(System.Int16)
                    || e.Column.ValueType == typeof(System.Int64)
                    || e.Column.ValueType == typeof(System.Double)
                    || e.Column.ValueType == typeof(System.Decimal))
                {
                    fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqNumero;
                }
                if (e.Column.ValueType == typeof(System.DateTime)
                    )
                {
                    fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqFecha;
                }
                if (e.Column.ValueType == typeof(System.String)
                    )
                {
                    fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
                }
                m_htCamposQuery.Add(e.Column.DataPropertyName, fld);
                m_iArrayFieldsFilled++;
                m_iGridWidth += e.Column.Width;
            }
        }
        private void dataGridView1_LOOKUP_EnterKeyDownEvent(object sender, EventArgs e)
        {
            RetornarSeleccion();
        }
    }
}

