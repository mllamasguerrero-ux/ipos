
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
using FirebirdSql.Data.FirebirdClient;
using iPos.Catalogos;

namespace iPos
{
    
    public struct WFAsignacionProdSatCampo
    {
        public string   strNombreCampo;
        public int      iTipoCampoBusq;
        public Type     tTipoDato;
    }


    public partial class WFAsignacionProdSat : IposForm
    {
        
        public DataRow m_rtnDataRow; 
        
        System.Collections.Hashtable m_htCamposQuery; 
        
        String m_strQuery;
        String m_initialQuery;
        
        int  m_iArrayFieldsFilled;
        bool m_bColumnsAdjusted;
        
        int  m_iGridWidth;

        int m_iConsecutivoFiltro = 0;
        List<FiltroAcum> m_filtros = new List<FiltroAcum>();
       
        
        public WFAsignacionProdSat( )
        {           
            InitializeComponent();
            Marquesina.Enabled = true;

            string title = "Asignacion de claves sat";
            string query = @"select linea.clave lineaclave,
       linea.nombre lineanombre,
       marca.clave marcaclave,
       marca.nombre marcanombre,
       producto.clave productoclave,
       producto.nombre productonombre,
       producto.descripcion productodescripcion,
       producto.descripcion1 productodescripcion1,
       sat_productoservicio.sat_claveprodserv clavesat,
       producto.id productoid
       from producto
       left join linea on linea.id = producto.lineaid
       left join marca on marca.id = producto.marcaid
       left join sat_productoservicio on sat_productoservicio.id = producto.sat_productoservicioid";

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

            LlenarCamposABuscar();

        }

        


        
        //private void AjustarAnchoCol()
        //{
        //    if (!m_bColumnsAdjusted)
        //    {
        //        if (m_iGridWidth < this.Width)
        //        {
        //            this.dataGridView1_LOOKUP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //        }
                
        //        m_bColumnsAdjusted = true;
        //    }
        //}
        private void LlenarDataGrid_LOOKUP()
        {
            try
            {
                CargarFiltro_LOOKUP();
                dataGridView1_LOOKUP.AutoGenerateColumns = false;
                bindingSource1_LOOKUP.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_LOOKUP);
                dataGridView1_LOOKUP.DataSource = bindingSource1_LOOKUP;
                dataGridView1_LOOKUP.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1_LOOKUP.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1_LOOKUP.EditMode = DataGridViewEditMode.EditOnEnter;
               // AjustarAnchoCol();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error. Asegures de que el formato de entrada es correcto para el campo de busqueda" + ex.Message);
               // MessageBox.Show(ex.Message + ex.StackTrace, "ERROR",
                //MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private void ActualizarFiltros()
        {
            try
            {
                aplcarFilros();
                dataGridView1_LOOKUP.AutoGenerateColumns = false;
                bindingSource1_LOOKUP.DataSource = DataTablesParaGrid.GetData(this.FbCommand1_LOOKUP);
                dataGridView1_LOOKUP.DataSource = bindingSource1_LOOKUP;
                dataGridView1_LOOKUP.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1_LOOKUP.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1_LOOKUP.EditMode = DataGridViewEditMode.EditOnEnter;
               // AjustarAnchoCol();
            }
            catch (Exception ex)
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
            this.DDOperador_LOOKUP.SelectedIndex = 0;


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
            WFAsignacionProdSatCampo fld = (WFAsignacionProdSatCampo)m_htCamposQuery[this.DDBuscar_LOOKUP.SelectedItem.ToString().Replace(" ", "")];
            try
            {
                switch (fld.iTipoCampoBusq)
                {
                    case (int)eTipoDatosBusqueda.tipoBusqNumero:
                    case (int)eTipoDatosBusqueda.tipoBusqString:


                //        CmdTxt = m_strQuery + " where " + this.DDBuscar_LOOKUP.SelectedItem.ToString() + " " + strOperador + " @v" + this.DDBuscar_LOOKUP.SelectedItem.ToString();
                //        this.FbCommand1_LOOKUP.CommandText = CmdTxt;
                //        this.FbCommand1_LOOKUP.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
                //new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + this.DDBuscar_LOOKUP.SelectedItem.ToString(), GetFbDbType(fld.tTipoDato))});
                //        this.FbCommand1_LOOKUP.Parameters["@v" + fld.strNombreCampo].Value = TBValor_LOOKUP.Text;



                        m_iConsecutivoFiltro++;
                        FbParameter param = new FirebirdSql.Data.FirebirdClient.FbParameter("@v" + m_iConsecutivoFiltro.ToString() + this.DDBuscar_LOOKUP.SelectedItem.ToString().Replace(" ",""), GetFbDbType(fld.tTipoDato));
                        param.Value = TBValor_LOOKUP.Text;
                        List<FbParameter> listParam = new List<FbParameter>();
                        listParam.Add(param);
                        FiltroAcum filtro = new FiltroAcum(this.DDBuscar_LOOKUP.SelectedItem.ToString().Replace(" ","") + " " + strOperador + " @v" + m_iConsecutivoFiltro.ToString() + this.DDBuscar_LOOKUP.SelectedItem.ToString().Replace(" ",""),
                                                           listParam);

                        m_filtros.Add(filtro);
                        aplcarFilros();
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



        private void aplcarFilros()
        {
            string CmdTxt = m_strQuery;
            this.FbCommand1_LOOKUP.Parameters.Clear();
            //lstFiltrosBox.Items.Clear();
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Items.Clear();
           

            if (m_filtros.Count > 0)
            {
                bool bEsPrimero = true;
                foreach (FiltroAcum filtro in m_filtros)
                {
                    if(bEsPrimero)
                    {
                        CmdTxt += " where ";
                        bEsPrimero = false;
                    }
                    else
                    {
                        CmdTxt += " and ";
                    }

                    CmdTxt += " " + filtro.CmdText ;
                    this.FbCommand1_LOOKUP.Parameters.AddRange(filtro.Parametros.ToArray());
                    //lstFiltrosBox.Items.Add(filtro.CmdText);
                    checkedListBox1.Items.Add(filtro.CmdText,true);                                   

                } 
            }
            else
            {
               
                this.FbCommand1_LOOKUP.CommandText = CmdTxt;
            }
            this.FbCommand1_LOOKUP.CommandText = CmdTxt;
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


        private void LlenarCamposABuscar()
        {
            this.DDBuscar_LOOKUP.Items.Add("LINEA CLAVE");
            WFAsignacionProdSatCampo fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "LINEACLAVE";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("LINEACLAVE", fld);

            this.DDBuscar_LOOKUP.Items.Add("LINEA NOMBRE");
             fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "LINEANOMBRE";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("LINEANOMBRE", fld);

            this.DDBuscar_LOOKUP.Items.Add("MARCA CLAVE");
            fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "MARCACLAVE";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("MARCACLAVE", fld);

            this.DDBuscar_LOOKUP.Items.Add("MARCA NOMBRE");
            fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "MARCANOMBRE";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("MARCANOMBRE", fld);



            this.DDBuscar_LOOKUP.Items.Add("PRODUCTO CLAVE");
            fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "PRODUCTOCLAVE";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("PRODUCTOCLAVE", fld);

            this.DDBuscar_LOOKUP.Items.Add("PRODUCTO NOMBRE");
            fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "PRODUCTONOMBRE";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("PRODUCTONOMBRE", fld);



            this.DDBuscar_LOOKUP.Items.Add("PRODUCTO DESCRIPCION");
            fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "PRODUCTODESCRIPCION";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("PRODUCTODESCRIPCION", fld);

            this.DDBuscar_LOOKUP.Items.Add("PRODUCTO DESCRIPCION1");
            fld = new WFAsignacionProdSatCampo();
            fld.strNombreCampo = "PRODUCTODESCRIPCION1";
            fld.tTipoDato = typeof(System.String);
            fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            m_htCamposQuery.Add("PRODUCTODESCRIPCION1", fld);


        }

        private void dataGridView1_LOOKUP_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //if (m_iArrayFieldsFilled <= e.Column.Index)
            //{
            //    WFAsignacionProdSatCampo fld = new WFAsignacionProdSatCampo();
            //    fld.strNombreCampo = e.Column.DataPropertyName;
            //    fld.tTipoDato = e.Column.ValueType;
            //    this.DDBuscar_LOOKUP.Items.Add(e.Column.DataPropertyName);
            //    if (e.Column.ValueType == typeof(System.Int32)
            //        || e.Column.ValueType == typeof(System.Int16)
            //        || e.Column.ValueType == typeof(System.Int64)
            //        || e.Column.ValueType == typeof(System.Double)
            //        || e.Column.ValueType == typeof(System.Decimal))
            //    {
            //        fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqNumero;
            //    }
            //    if (e.Column.ValueType == typeof(System.DateTime)
            //        )
            //    {
            //        fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqFecha;
            //    }
            //    if (e.Column.ValueType == typeof(System.String)
            //        )
            //    {
            //        fld.iTipoCampoBusq = (int)eTipoDatosBusqueda.tipoBusqString;
            //    }
            //    m_htCamposQuery.Add(e.Column.DataPropertyName, fld);
            //    m_iArrayFieldsFilled++;
            //    m_iGridWidth += e.Column.Width;
            //}
        }
        private void dataGridView1_LOOKUP_EnterKeyDownEvent(object sender, EventArgs e)
        {
            RetornarSeleccion();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                //Console.WriteLine("Hola");
                //Console.WriteLine(e.Index.ToString());
                //Console.WriteLine(m_filtros[e.Index].CmdText.ToString());
                //checkedListBox1.Items.Remove(m_filtros[e.Index].CmdText.ToString());
                m_filtros.RemoveAt(e.Index);
                //Console.WriteLine("Deberia estar vacio");
                //Console.WriteLine(m_filtros.Count);
                ////Console.WriteLine(m_filtros[e.Index].CmdText.ToString());
                //ActualizarFiltros();

                //// If there are no items left, skip the CheckState.Checked call
                //if (checkedListBox1.Items.Count > 0)
                //{
                //    e.NewValue = CheckState.Checked;
                //}
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
            ActualizarFiltros();
        }

        private void PRODUCTOSATButton_Click(object sender, EventArgs e)
        {

            try
            {

                WFProductoServicioSat form = new WFProductoServicioSat();

                form.ShowDialog();

                DataRow rowSeleccionada = form.Retorno;

                form.Dispose();
                GC.SuppressFinalize(form);

                if (rowSeleccionada != null)
                {
                    string strBuffer = "";
                    this.productoSatTextBoxFb.DbValue = ((long)rowSeleccionada["ID"]).ToString();
                    this.productoSatTextBoxFb.MostrarErrores = false;
                    this.productoSatTextBoxFb.MValidarEntrada(out strBuffer, 1);
                    this.productoSatTextBoxFb.MostrarErrores = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " " + ex.StackTrace);
            }
        }

        private void actualizarCatalogoSAT(long productoId, long claveSatId)               
        {
            CPRODUCTOD cPRODUCTOD = new CPRODUCTOD();
            cPRODUCTOD.CambiarClaveSAT(claveSatId, productoId, null);
        }

        private void btnAsignarClaveSat_Click(object sender, EventArgs e)
        {
            //

            long claveSatId = 0;
            if (!String.IsNullOrEmpty(this.productoSatTextBoxFb.Text))
            {
                claveSatId = Int32.Parse(this.productoSatTextBoxFb.DbValue.ToString());
            }
            else
            {
                MessageBox.Show("Ingrese una clave sat");
                return;
            }


            foreach(DataGridViewRow dr in dataGridView1_LOOKUP.Rows)
            {
                long productoID = (long)dr.Cells["DGPRODUCTOID"].Value;

                actualizarCatalogoSAT(productoID, claveSatId);
                //update producto set sat_productoservicioid = @claveSatId where id = @productoid
            }

            LlenarDataGrid_LOOKUP();

            
        }

        private void Marquesina_Tick(object sender, EventArgs e)
        {
            if (productoSatLabel.Width >= 194)
            {
                productoSatLabel.Left -= 3;
                if (productoSatLabel.Left <= 0 - productoSatLabel.Width)
                {
                    productoSatLabel.Left = panel3.Width + 10;
                }
            }

            if (productoSatLabel.Width < 194)
                productoSatLabel.Left = 0;
        }
    }


    public class FiltroAcum
    {
        private string cmdText;
        private List<FirebirdSql.Data.FirebirdClient.FbParameter> parametros;

        public FiltroAcum()
        {
            CmdText = "";
            Parametros = new List<FirebirdSql.Data.FirebirdClient.FbParameter>();

        }

        public FiltroAcum(string _cmdText, List<FirebirdSql.Data.FirebirdClient.FbParameter> _parametros)
        {
            CmdText = _cmdText;
            Parametros = _parametros;

        }

        public string CmdText { get => cmdText; set => cmdText = value; }
        public List<FbParameter> Parametros { get => parametros; set => parametros = value; }
    }
}

