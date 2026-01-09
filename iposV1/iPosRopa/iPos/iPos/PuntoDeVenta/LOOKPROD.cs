using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using Newtonsoft.Json;

namespace iPos
{
    public enum TipoProductoNivel { tp_todos, tp_hijos, tp_padres };
    public partial class LOOKPROD : iPos.Tools.ScreenConfigurableForm
    {
        public DataRow m_rtnDataRow;
        public bool m_bRetornarValor;
        public bool m_bMostrarDescontinuados;

        public long m_almacenIdPredeterminado = 0;

        TipoProductoNivel m_nivelProducto = TipoProductoNivel.tp_todos;

        bool m_manejaAlmacen = false;
        bool m_mostrarDesgloseAlmacen = false;

        public long m_personaid = 0;

        public Boolean bAlreadyShown = false;

        public Boolean m_showEmptyIfNoFilter = true;

        public bool m_tienePermisoParaPrecioConUtilMacro = true;


        public LOOKPROD()
        {
            InitializeComponent();
            m_bRetornarValor = false;
            m_bMostrarDescontinuados = false;
            //RefrescarGrid();
        }

        public LOOKPROD(string palabrasBusqueda):this()
        {
            m_bRetornarValor = true;
            m_bMostrarDescontinuados = false;
            busquedaToolStripTextBox.Text = palabrasBusqueda.ToUpper();
            
        }


        public LOOKPROD(string palabrasBusqueda, bool soloConExistencias)
            :this(palabrasBusqueda)
        {

            m_bMostrarDescontinuados = false;
            CBMostrarExistencias.Checked = soloConExistencias;
        }



        public LOOKPROD(string palabrasBusqueda, bool soloConExistencias, TipoProductoNivel nivelProducto)
            : this(palabrasBusqueda, soloConExistencias)
        {
            m_nivelProducto = nivelProducto;
        }

        public LOOKPROD(string palabrasBusqueda, bool soloConExistencias, TipoProductoNivel nivelProducto, long personaid)
            : this(palabrasBusqueda, soloConExistencias, nivelProducto)
        {
            m_personaid = personaid;
        }


        
        public LOOKPROD(string palabrasBusqueda, bool soloConExistencias, TipoProductoNivel nivelProducto, long personaid, Boolean showEmptyIfNoFilter)
            : this(palabrasBusqueda, soloConExistencias, nivelProducto, personaid)
        {
            m_showEmptyIfNoFilter = showEmptyIfNoFilter;
        }

        


        private void RetornarSeleccion(bool bEnterKey)
        {
            try
            {
                int iRetornoRowIndex = /*(bEnterKey && pRODUCTOSDataGridView.CurrentRow.Index < (pRODUCTOSDataGridView.RowCount - 1)) 
                                       ? pRODUCTOSDataGridView.CurrentRow.Index - 1 :*/ pRODUCTOSDataGridView.CurrentRow.Index;
                DataGridViewRow dr = pRODUCTOSDataGridView.Rows[iRetornoRowIndex];

                m_rtnDataRow = (dr.DataBoundItem as DataRowView).Row;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }


        private bool RequiereRecalculoUtilidad()
        {
            return decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString()) != CurrentUserID.CurrentParameters.IPORCUTILIDADLISTADO;
        }

        private void RecalculateAllCostoWithUtilidad()
        {


            DataTable dtSource = this.dSPuntoVenta.PRODUCTOS;
            decimal porcUtilidadListado = decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString());

            if (dtSource.Rows.Count > 0)
            {
                // cloned to get the structure of source

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                        RecalculateCostoWithUtilidad(dtSource.Rows[i], porcUtilidadListado);
                    
                }
            }
        }

        private void RecalculateCostoWithUtilidad(DataRow row, decimal porcUtilidadListado)
        {
            try
            {
                decimal costoReposicion = decimal.Parse(row["COSTOREPOSICION"].ToString().Trim());
                decimal tasaIepsAplicable = decimal.Parse(row["TASAIEPSAPLICABLE"].ToString().Trim());
                decimal tasaIvaAplicable = decimal.Parse(row["TASAIVAAPLICABLE"].ToString().Trim());
                //decimal porcUtilidadListado = decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString());
                decimal newPrecioConUtilidad = (1m - porcUtilidadListado / 100.00m) > 0m ?
                                                Math.Round(costoReposicion / (1m - porcUtilidadListado / 100.00m), 4) :
                                                Math.Round(costoReposicion * (1m + porcUtilidadListado / 100.00m), 4);
                newPrecioConUtilidad = Math.Round(newPrecioConUtilidad * (1m + tasaIepsAplicable / 100.00m), 4);
                newPrecioConUtilidad = Math.Round(newPrecioConUtilidad * (1m + tasaIvaAplicable / 100.00m), 4);
                row["COSTOREPOCONUTILIMP"] = newPrecioConUtilidad;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void RefrescarGrid()
        {

            if (!bAlreadyShown)
                return;

            bool requiereRecalculoUtilidad = RequiereRecalculoUtilidad();
            decimal porcUtilidadListado = decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString());

            string strABuscar;
            int numeroRegistros = 0;
            try
                    // Get the header row.

            {


                string bufferBusquedaText = busquedaToolStripTextBox.Text;
                if (bufferBusquedaText.Contains(" <(("))
                {
                    string[] strSeparators = new string[]{" <(("};

                    string[] strBuffert = bufferBusquedaText.Split(strSeparators,StringSplitOptions.RemoveEmptyEntries);
                    if(strBuffert.Count() > 0 )
                        bufferBusquedaText = strBuffert[0];
                }
                strABuscar = "%" + bufferBusquedaText + "%";

                string p_esproductopadre;
                switch(this.m_nivelProducto)
                {
                    case TipoProductoNivel.tp_todos: p_esproductopadre = "I"; break;
                    case TipoProductoNivel.tp_hijos: p_esproductopadre = "N"; break;
                    case TipoProductoNivel.tp_padres: p_esproductopadre = "S"; break;
                    default: p_esproductopadre = "I"; break;
                }

                // desglose almacenes
                int almacenId1 = 0; 
                int almacenId2 = 0;
                int almacenId3 = 0;
                int almacenId4 = 0;
                int almacenId5 = 0;
                string strAlmacen1 = "", strAlmacen2 = "", strAlmacen3 = "", strAlmacen4 = "", strAlmacen5 = "";

                if (m_manejaAlmacen )
                {

                    try
                    {
                        almacenId1 = int.Parse(this.ALMACENComboBox.SelectedValue.ToString());
                        strAlmacen1 = this.ALMACENComboBox.SelectedDataDisplaying.ToString();
                    }
                    catch
                    {
                    }


                    CALMACEND almacenD = new CALMACEND();
                    ArrayList lista = almacenD.lista(null);
                    int count = 0;
                    foreach (CALMACENBE almacen in lista)
                    {
                        if (almacen.IID == (long)almacenId1 ||
                            almacen.IID == (long)almacenId2 ||
                            almacen.IID == (long)almacenId3 ||
                            almacen.IID == (long)almacenId4 ||
                            almacen.IID == (long)almacenId5)
                            continue;
                        if (count == 0)
                        {
                            almacenId2 = (int)almacen.IID;
                            strAlmacen2 = almacen.INOMBRE;
                            count++;
                        }
                        else if (count == 1)
                        {
                            almacenId3 = (int)almacen.IID;
                            strAlmacen3 = almacen.INOMBRE;
                            count++;
                        }
                        else if (count == 2)
                        {
                            almacenId4 = (int)almacen.IID;
                            strAlmacen4 = almacen.INOMBRE;
                            count++;
                        }
                        else if (count == 3)
                        {
                            almacenId5 = (int)almacen.IID;
                            strAlmacen5 = almacen.INOMBRE;
                            count++;
                            break;
                        }
                    }

                    if(m_mostrarDesgloseAlmacen)
                    {

                        if (count < 1)
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN2"].Visible = false;
                        }

                        if (count < 2)
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN3"].Visible = false;
                        }

                        if (count < 3)
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN4"].Visible = false;
                        }

                        if (count < 4)
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN5"].Visible = false;
                        }
                    }

                }


                if (((CBSoloAlmacen.Checked && this.ALMACENComboBox.SelectedIndex >= 0) || m_mostrarDesgloseAlmacen) && m_manejaAlmacen)
                {
                    string POREXISTENCIATOTAL = CBSoloAlmacen.Checked ? "N" : "S";
                    pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN1"].Visible = true;
                    pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN1"].HeaderText = strAlmacen1;
                    pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN2"].HeaderText = strAlmacen2;
                    pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN3"].HeaderText = strAlmacen3;
                    pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN4"].HeaderText = strAlmacen4;
                    pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN5"].HeaderText = strAlmacen5;


                    if (strABuscar.Equals("%%") && m_showEmptyIfNoFilter)
                    {
                        this.dSPuntoDeVentaAux2.PRODUCTOSSINBUSQUEDA.Clear();
                        m_showEmptyIfNoFilter = false;
                    }
                    else
                    {
                        this.pRODUCTOSPORALMACENTableAdapter.Fill(this.dSPuntoDeVentaAux.PRODUCTOSPORALMACEN, strABuscar, (this.m_bMostrarDescontinuados) ? "S" : "N", p_esproductopadre, almacenId1, almacenId2, almacenId3, almacenId4, almacenId5, POREXISTENCIATOTAL, ((CBMostrarExistencias.Checked) ? "S" : "N"));
                        CopyDataTableAux(requiereRecalculoUtilidad, porcUtilidadListado);
                    }

                }
                else if(CBSoloHistorial.Checked && m_personaid != 0)
                {
                    int? pid = (int?)m_personaid;
                    numeroRegistros = this.pRODUCTOSCONHISTORIALTableAdapter.Fill(this.dSPuntoDeVentaAux.PRODUCTOSCONHISTORIAL, strABuscar, ((CBMostrarExistencias.Checked) ? "S" : "N"), CurrentUserID.CurrentParameters.IESVENDEDORMOVIL, (this.m_bMostrarDescontinuados) ? "S" : "N", p_esproductopadre,
                        "N", (this.CBSoloProm.Checked) ? "S" : "N", pid);
                    CopyDataTableAuxHistorial(requiereRecalculoUtilidad, porcUtilidadListado);

                }
                else if(strABuscar.Equals("%%"))
                {
                    if (!m_showEmptyIfNoFilter)
                    {
                        numeroRegistros = this.pRODUCTOSSINBUSQUEDATableAdapter.Fill(this.dSPuntoDeVentaAux2.PRODUCTOSSINBUSQUEDA, ((CBMostrarExistencias.Checked) ? "S" : "N"), CurrentUserID.CurrentParameters.IESVENDEDORMOVIL, (this.m_bMostrarDescontinuados) ? "S" : "N", p_esproductopadre 
                            , (this.CBSoloHistorial.Checked) ? "S" : "N"
                            , (this.CBSoloProm.Checked) ? "S" : "N");
                        CopyDataTableAuxSinBusqueda(requiereRecalculoUtilidad, porcUtilidadListado);
                    }
                    else
                    {
                        this.dSPuntoDeVentaAux2.PRODUCTOSSINBUSQUEDA.Clear();
                        m_showEmptyIfNoFilter = false;

                    }
                }
                else if(CurrentUserID.CurrentParameters.IBUSQUEDATIPO2 == "S")
                {
                    CopyDataTableTipoBusqueda2(strABuscar, p_esproductopadre);
                }
                else
                {

                    numeroRegistros = this.pRODUCTOSTableAdapter.Fill(this.dSPuntoVenta.PRODUCTOS, strABuscar, ((CBMostrarExistencias.Checked) ? "S" : "N"), CurrentUserID.CurrentParameters.IESVENDEDORMOVIL, (this.m_bMostrarDescontinuados) ? "S" : "N", p_esproductopadre  
                        , (this.CBSoloHistorial.Checked) ? "S" : "N"
                        , (this.CBSoloProm.Checked) ? "S" : "N");
                    if(requiereRecalculoUtilidad)
                        RecalculateAllCostoWithUtilidad();
                }
                
                if (this.dSPuntoVenta.PRODUCTOS.Rows.Count > 0)
                    pRODUCTOSDataGridView.Focus();
                else
                    busquedaToolStripTextBox.Focus();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }



        public void CopyDataTableAux(bool requiereRecalculoUtilidad, decimal porcUtilidadListado)
        {

            DataTable dtSource = this.dSPuntoDeVentaAux.PRODUCTOSPORALMACEN;
            DataTable dtDestination = this.dSPuntoVenta.PRODUCTOS;
            dtDestination.Clear();

            if (dtSource.Rows.Count > 0)
            {
                // cloned to get the structure of source
                
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    if (requiereRecalculoUtilidad)
                        RecalculateCostoWithUtilidad(dtSource.Rows[i], porcUtilidadListado);

                    dtDestination.ImportRow(dtSource.Rows[i]);
                }
            }
        }

        public void CopyDataTableAuxHistorial(bool requiereRecalculoUtilidad, decimal porcUtilidadListado)
        {

            DataTable dtSource = this.dSPuntoDeVentaAux.PRODUCTOSCONHISTORIAL;
            DataTable dtDestination = this.dSPuntoVenta.PRODUCTOS;
            dtDestination.Clear();

            if (dtSource.Rows.Count > 0)
            {
                // cloned to get the structure of source

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    if (requiereRecalculoUtilidad)
                        RecalculateCostoWithUtilidad(dtSource.Rows[i], porcUtilidadListado);

                    dtDestination.ImportRow(dtSource.Rows[i]);
                }
            }
        }

        public void CopyDataTableTipoBusqueda2(string strBusquedaOriginal, string esproductopadre)
        {
            string busqueda = this.busquedaToolStripTextBox.Text;
            bool requiereRecalculoUtilidad = RequiereRecalculoUtilidad();

            //si se selecciona por autocomplete entonces llena el data set de la manera basica
            if (busqueda.Contains(" <(("))
            {

                this.pRODUCTOSTableAdapter.Fill(this.dSPuntoVenta.PRODUCTOS, strBusquedaOriginal, ((CBMostrarExistencias.Checked) ? "S" : "N"), CurrentUserID.CurrentParameters.IESVENDEDORMOVIL, (this.m_bMostrarDescontinuados) ? "S" : "N", esproductopadre
                           , (this.CBSoloHistorial.Checked) ? "S" : "N"
                           , (this.CBSoloProm.Checked) ? "S" : "N");

                if (requiereRecalculoUtilidad)
                    RecalculateAllCostoWithUtilidad();

                return;
            }

            CPRODUCTOD daoProd = new CPRODUCTOD();
            DataTable dtSource = daoProd.getProductosTipoBusqueda2(busqueda, CBMostrarExistencias.Checked);//this.dSPuntoDeVentaAux.PRODUCTOSCONHISTORIAL;
            DataTable dtDestination = this.dSPuntoVenta.PRODUCTOS;
            dtDestination.Clear();

            if (dtSource.Rows.Count > 0)
            {
                // cloned to get the structure of source

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    dtDestination.ImportRow(dtSource.Rows[i]);
                }
            }
        }

        public void CopyDataTableAuxSinBusqueda(bool requiereRecalculoUtilidad, decimal porcUtilidadListado)
        {

            DataTable dtSource = this.dSPuntoDeVentaAux2.PRODUCTOSSINBUSQUEDA;
            DataTable dtDestination = this.dSPuntoVenta.PRODUCTOS;
            dtDestination.Clear();

            if (dtSource.Rows.Count > 0)
            {
                // cloned to get the structure of source

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    if(requiereRecalculoUtilidad)
                        RecalculateCostoWithUtilidad(dtSource.Rows[i], porcUtilidadListado);

                    dtDestination.ImportRow(dtSource.Rows[i]);
                }
            }
        }



        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            RefrescarGrid();

        }

        private void pRODUCTOSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                if(this.m_bRetornarValor)
                    RetornarSeleccion(false);
                else
                    MostrarProducto();
            }
        }



        private void pRODUCTOSDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fillToolStrip_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RefrescarGrid();
        }

        private void LOOKPROD_Load(object sender, EventArgs e)
        {
            this.PORCUTILIDADLISTADOTextBox.Text = CurrentUserID.CurrentParameters.IPORCUTILIDADLISTADO.ToString();

            // TODO: This line of code loads data into the 'dSPuntoDeVentaAux.PRODUCTONOMBRE' table. You can move, or remove it, as needed.
            configuraLaPantalla(true, true);

            if (!verificarPermisos("Consultar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                this.Close();
                return;
            }

            bool tienePermisoParaPrecioConUtilidad = verificarPermisos("PrecioConUtilidad");
            m_tienePermisoParaPrecioConUtilMacro = verificarPermisos("PrecioConUtilMacro");
            PORCUTILIDADLISTADOTextBox.Visible = tienePermisoParaPrecioConUtilidad;
            COSTOREPOCONUTILIMP.Visible = tienePermisoParaPrecioConUtilidad;
            PORCUTILIDADLISTADOLabel.Visible = tienePermisoParaPrecioConUtilidad;
            

            if (CurrentUserID.CurrentParameters.IMOSTRAR_EXIS_SUC == DBValues._DB_BOOLVALUE_NO)
            {
                this.TSBExistenciasSucursales.Visible = false;
            }
            FormatearColumnasPersonalizados();


            m_manejaAlmacen = !((bool)CurrentUserID.CurrentParameters.isnull["IMANEJAALMACEN"] || !CurrentUserID.CurrentParameters.IMANEJAALMACEN.Equals("S"));

            m_mostrarDesgloseAlmacen = getDesgloseXAlmacen();

            HabilitateDesgloseAlmacen();

            if (m_manejaAlmacen)
            {
                ALMACENComboBox.llenarDatos();

                CBSoloAlmacen.Checked = true;

                if (!(bool)CurrentUserID.CurrentUser.isnull["IALMACENID"])
                {
                    if(m_almacenIdPredeterminado == 0)
                        this.ALMACENComboBox.SelectedDataValue = CurrentUserID.CurrentUser.IALMACENID;
                    else
                        this.ALMACENComboBox.SelectedDataValue = m_almacenIdPredeterminado;
                }
                else
                    this.ALMACENComboBox.SelectedDataValue = DBValues._ALMACEN_DEFAULT;


            }
            else
            {
                ALMACENComboBox.Visible = false;
                CBSoloAlmacen.Visible = false;
            }



            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                //if (1 == 1 /*!CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S")*/)
                //{
                        
                    try
                    {

                        this.busquedaToolStripTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.busquedaToolStripTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        this.busquedaToolStripTextBox.AutoCompleteCustomSource = CurrentUserID.GetAutoSourceCollectionFromTable();



                    }
                    catch
                    {
                    }
                //}
                //else
                //{
                //    this.addCustomAutoCompletePair(ref this.busquedaToolStripTextBox, ref lstProductoComplete,  CurrentUserID.GetAutoSourceCollectionFromTable());
                //}


            }




            if (m_personaid == 0)
            {
                pRODUCTOSDataGridView.Columns["BTHistorialProducto"].Visible = false;
            }

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                pRODUCTOSDataGridView.Columns["BTExistencia"].Visible = true;
                this.CBSoloProm.Visible = true;
                this.CBSoloHistorial.Visible = true;
            }
            else
            {
                pRODUCTOSDataGridView.Columns["BTExistencia"].Visible = false;
                this.CBSoloProm.Visible = false;
                this.CBSoloHistorial.Visible = false;

                this.CBSoloProm.Checked = false;
                this.CBSoloHistorial.Checked = false;
            }


            if(CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null &&
                CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3)
                {

                    this.pRODUCTOSDataGridView.RowTemplate.Height = 30;

                    this.CBSoloHistorial.Text = "C/Hist";
                    this.CBSoloProm.Text = "C/Prom";
                    this.CBMostrarExistencias.Text = "C/Exis";
                    this.CBMostrarExistencias.Checked = true;


                    this.CBMostrarExistencias.Location = new Point(this.toolStripButton1.Location.X + 150, 1);
                    this.CBSoloHistorial.Location = new Point(this.CBMostrarExistencias.Location.X + this.CBMostrarExistencias.Width + 50, 1);
                    this.CBSoloProm.Location = new Point(this.CBSoloHistorial.Location.X + this.CBSoloHistorial.Width + 50, 1);

                    this.toolStripButton1.Visible = false;
                    this.panel1.Location = new Point(busquedaToolStripTextBox.Location.X + busquedaToolStripTextBox.Width - 40, 1);
                }
                else
                {

                    this.pRODUCTOSDataGridView.RowTemplate.Height = 30;

                    this.CBSoloHistorial.Text = "C/Hist";
                    this.CBSoloProm.Text = "C/Prom";
                    this.CBMostrarExistencias.Text = "C/Exis";
                    this.CBMostrarExistencias.Checked = true;


                    this.CBMostrarExistencias.Location = new Point(this.toolStripButton1.Location.X, 1);
                    this.CBSoloHistorial.Location = new Point(this.CBMostrarExistencias.Location.X + this.CBMostrarExistencias.Width, 1);
                    this.CBSoloProm.Location = new Point(this.CBSoloHistorial.Location.X + this.CBSoloHistorial.Width, 1);

                    this.toolStripButton1.Visible = false;
                    this.panel1.Location = new Point(busquedaToolStripTextBox.Location.X + busquedaToolStripTextBox.Width - 40, 1);
                }
            }
        }


        private void LOOKPROD_Shown(object sender, EventArgs e)
        {
            bAlreadyShown = true;
            //if (busquedaToolStripTextBox.Text.Trim() != "")
            RefrescarGrid();

            if (busquedaToolStripTextBox.Text == "")
            {
                busquedaToolStripTextBox.Focus();
            }
        }

        private void TSBExistenciasSucursales_Click(object sender, EventArgs e)
        {
            if (pRODUCTOSDataGridView.Rows.Count <= 0)
                return;

            WFImportandoExistencias impExist_ = new WFImportandoExistencias(pRODUCTOSDataGridView.CurrentRow.Cells["DGCLAVE"].Value.ToString());
            impExist_.ShowDialog();
            impExist_.Dispose();
            GC.SuppressFinalize(impExist_);

            try
            {

                string strProductId = pRODUCTOSDataGridView.CurrentRow.Cells["DGID"].Value.ToString();
                long lProductId = long.Parse(strProductId);
                WFExistenciasSucursales exSucursales = new WFExistenciasSucursales(pRODUCTOSDataGridView.CurrentRow.Cells["DGCLAVE"].Value.ToString(), lProductId, pRODUCTOSDataGridView.CurrentRow.Cells["DGDESCRIPCION1"].Value.ToString());
                exSucursales.ShowDialog();
                exSucursales.Dispose();
                GC.SuppressFinalize(exSucursales);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pRODUCTOSDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (pRODUCTOSDataGridView.Columns[e.ColumnIndex].Name == "BTVerProducto")
            {
                MostrarProducto();
            }
            else if (pRODUCTOSDataGridView.Columns[e.ColumnIndex].Name == "BTEditar")
            {
                EditarProducto();
            }
            else if (pRODUCTOSDataGridView.Columns[e.ColumnIndex].Name == "BTHistorialProducto")
            {
                if (m_personaid != 0)
                {
                    MostrarHistorial();
                }
            }
            else if (pRODUCTOSDataGridView.Columns[e.ColumnIndex].Name == "BTExistencia")
            {
                ObtenerExistenciaProducto();
            }
        }


        private void MostrarHistorial()
        {
            try
            {

                if (!verificarPermisos("Consultar"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }

                int iRetornoRowIndex = pRODUCTOSDataGridView.CurrentRow.Index;
                long iProductId = (long)pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value;

                WFProductoClienteHistorial form = new WFProductoClienteHistorial(iProductId, m_personaid);
                form.ShowDialog();
                form.Dispose();
                GC.SuppressFinalize(form);

            }
            catch
            {
            }
        }

        private void MostrarProducto()
        {
            try
            {

                if (!verificarPermisos("Consultar"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }

                int iRetornoRowIndex =  pRODUCTOSDataGridView.CurrentRow.Index;
                long iProductId = (long)pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value;

                CUSUARIOSD usuariosD = new CUSUARIOSD();
                Boolean usuarioTienePermisoEstadisticoCompra = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_ESTADISTICOSPRODUCTOCOMPRA, null);
                Boolean usuarioTienePermisoEstadisticoVenta = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_ESTADISTICOSPRODUCTOVENTA, null);
                
                iPosReporting.FormProductoFicha fPi = new iPosReporting.FormProductoFicha((int)iProductId, (int)CurrentUserID.CurrentUser.IID, CurrentUserID.CurrentUser, CurrentUserID.CurrentParameters, VerHistorialProducto);

                if(usuarioTienePermisoEstadisticoCompra)
                    fPi.m_estadisticoCompraDelegate = VerEstadisticoCompra;

                if(usuarioTienePermisoEstadisticoVenta)
                    fPi.m_estadisticoVentaDelegate = VerEstadisticoVenta;

                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);
            }
            catch
            {
            }
        }


        private void EditarProducto()
        {
            try
            {

                if (!verificarPermisos("Cambiar"))
                {
                    MessageBox.Show("No tiene permisos para acceder");
                    return;
                }

                int iRetornoRowIndex = pRODUCTOSDataGridView.CurrentRow.Index;
                string strProductClave = pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["DGCLAVE"].Value.ToString();
                WFProductoEdit fPi = new WFProductoEdit();
                fPi.ReCargar("Cambiar", strProductClave);
                fPi.ShowDialog();
                fPi.Dispose();
                GC.SuppressFinalize(fPi);


            }
            catch
            {
            }
        }

        private void TSBAgregar_Click(object sender, EventArgs e)
        {
            if (!verificarPermisos("Agregar"))
            {
                MessageBox.Show("No tiene permisos para acceder");
                return;
            }

            WFProductoEdit fPi = new WFProductoEdit();
            fPi.ReCargar("Agregar", "");
            fPi.ShowDialog();
            fPi.Dispose();
            GC.SuppressFinalize(fPi);

            RefrescarGrid();
        }



        private bool verificarPermisos(string opc)
        {
            int iMenuItem = 21;
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            switch (opc)
            {
                case "Cambiar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 1000, null);


                case "Agregar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 3000, null);

                case "Consultar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem, null);

                case "Borrar":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, iMenuItem + 2000, null);

                case "PrecioConUtilidad":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, int.Parse(DBValues._DERECHO_VERUTILIDAD_LISTADOPROD.ToString()), null);


                case "PrecioConUtilMacro":
                    return usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, int.Parse(DBValues._DERECHO_VERUTILMACRO_LISTADOPROD.ToString()), null);

            }

            return false;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBMostrarExistencias_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private void pRODUCTOSDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                RetornarSeleccion(true);
        }


        private bool getDesgloseXAlmacen()
        {
            
                if (CurrentUserID.listados.ContainsKey("PRODUCTO"))
                {
                    CLOOKUPBE lookup = (CLOOKUPBE)CurrentUserID.listados["PRODUCTO"];
                    
                        if (!(bool)lookup.isnull["ICAMPO23"] &&   lookup.ICAMPO23.Equals("S"))
                        {
                            return true;
                        }
                }
                return false;
        }

        private void HabilitateDesgloseAlmacen()
        {
                        if (m_mostrarDesgloseAlmacen && m_manejaAlmacen )
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN1"].Visible = true;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN2"].Visible = true;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN3"].Visible = true;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN4"].Visible = true;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN5"].Visible = true;
                        }
                        else
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN1"].Visible = false;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN2"].Visible = false;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN3"].Visible = false;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN4"].Visible = false;
                            pRODUCTOSDataGridView.Columns["EXISTENCIAALMACEN5"].Visible = false;
                        }
        }

        private void FormatearColumnasPersonalizados()
        {

            try
            {
                if (CurrentUserID.listados.ContainsKey("PRODUCTO"))
                {
                    CLOOKUPBE lookup = (CLOOKUPBE)CurrentUserID.listados["PRODUCTO"];
                    if (lookup != null)
                    {
                        if (!(bool)lookup.isnull["ICAMPO1"])
                        {
                            pRODUCTOSDataGridView.Columns["DGDESCRIPCION2"].Visible = lookup.ICAMPO1.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO1"] && lookup.ILBL_CAMPO1 != null && lookup.ILBL_CAMPO1.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGDESCRIPCION2"].HeaderText = lookup.ILBL_CAMPO1;
                        }
                        if (!(bool)lookup.isnull["ICAMPO2"])
                        {
                            pRODUCTOSDataGridView.Columns["DGTEXTO1"].Visible = lookup.ICAMPO2.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO2"] && lookup.ILBL_CAMPO2 != null && lookup.ILBL_CAMPO2.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGTEXTO1"].HeaderText = lookup.ILBL_CAMPO2;
                        }
                        if (!(bool)lookup.isnull["ICAMPO3"])
                        {
                            pRODUCTOSDataGridView.Columns["DGTEXTO2"].Visible = lookup.ICAMPO3.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO3"] && lookup.ILBL_CAMPO3 != null && lookup.ILBL_CAMPO3.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGTEXTO2"].HeaderText = lookup.ILBL_CAMPO3;
                        }
                        if (!(bool)lookup.isnull["ICAMPO4"])
                        {
                            pRODUCTOSDataGridView.Columns["DGTEXTO3"].Visible = lookup.ICAMPO4.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO4"] && lookup.ILBL_CAMPO4 != null && lookup.ILBL_CAMPO4.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGTEXTO3"].HeaderText = lookup.ILBL_CAMPO4;
                        }
                        if (!(bool)lookup.isnull["ICAMPO5"])
                        {
                            pRODUCTOSDataGridView.Columns["DGTEXTO4"].Visible = lookup.ICAMPO5.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO5"] && lookup.ILBL_CAMPO5 != null && lookup.ILBL_CAMPO5.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGTEXTO4"].HeaderText = lookup.ILBL_CAMPO5;
                        }
                        if (!(bool)lookup.isnull["ICAMPO6"])
                        {
                            pRODUCTOSDataGridView.Columns["DGTEXTO5"].Visible = lookup.ICAMPO6.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO6"] && lookup.ILBL_CAMPO6 != null && lookup.ILBL_CAMPO6.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGTEXTO5"].HeaderText = lookup.ILBL_CAMPO6;
                        }
                        if (!(bool)lookup.isnull["ICAMPO7"])
                        {
                            pRODUCTOSDataGridView.Columns["DGTEXTO6"].Visible = lookup.ICAMPO7.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO7"] && lookup.ILBL_CAMPO7 != null && lookup.ILBL_CAMPO7.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGTEXTO6"].HeaderText = lookup.ILBL_CAMPO7;
                        }
                        if (!(bool)lookup.isnull["ICAMPO8"])
                        {
                            pRODUCTOSDataGridView.Columns["DGNUMERO1"].Visible = lookup.ICAMPO8.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO8"] && lookup.ILBL_CAMPO8 != null && lookup.ILBL_CAMPO8.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGNUMERO1"].HeaderText = lookup.ILBL_CAMPO8;
                        }
                        if (!(bool)lookup.isnull["ICAMPO9"])
                        {
                            pRODUCTOSDataGridView.Columns["DGNUMERO2"].Visible = lookup.ICAMPO9.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO9"] && lookup.ILBL_CAMPO9 != null && lookup.ILBL_CAMPO9.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGNUMERO2"].HeaderText = lookup.ILBL_CAMPO9;
                        }
                        if (!(bool)lookup.isnull["ICAMPO10"])
                        {
                            pRODUCTOSDataGridView.Columns["DGNUMERO3"].Visible = lookup.ICAMPO10.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO10"] && lookup.ILBL_CAMPO10 != null && lookup.ILBL_CAMPO10.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGNUMERO3"].HeaderText = lookup.ILBL_CAMPO10;
                        }
                        if (!(bool)lookup.isnull["ICAMPO11"])
                        {
                            pRODUCTOSDataGridView.Columns["DGNUMERO4"].Visible = lookup.ICAMPO11.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO11"] && lookup.ILBL_CAMPO11 != null && lookup.ILBL_CAMPO11.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGNUMERO4"].HeaderText = lookup.ILBL_CAMPO11;
                        }
                        if (!(bool)lookup.isnull["ICAMPO12"])
                        {
                            pRODUCTOSDataGridView.Columns["DGFECHA1"].Visible = lookup.ICAMPO12.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO12"] && lookup.ILBL_CAMPO12 != null && lookup.ILBL_CAMPO12.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGFECHA1"].HeaderText = lookup.ILBL_CAMPO12;
                        }
                        if (!(bool)lookup.isnull["ICAMPO13"])
                        {
                            pRODUCTOSDataGridView.Columns["DGFECHA2"].Visible = lookup.ICAMPO13.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO13"] && lookup.ILBL_CAMPO13 != null && lookup.ILBL_CAMPO13.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGFECHA2"].HeaderText = lookup.ILBL_CAMPO13;
                        }
                        if (!(bool)lookup.isnull["ICAMPO14"])
                        {
                            pRODUCTOSDataGridView.Columns["DGPRECIO1"].Visible = lookup.ICAMPO14.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO14"] && lookup.ILBL_CAMPO14 != null && lookup.ILBL_CAMPO14.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGPRECIO1"].HeaderText = lookup.ILBL_CAMPO14;
                        }
                        if (!(bool)lookup.isnull["ICAMPO15"])
                        {
                            pRODUCTOSDataGridView.Columns["TASAIVA"].Visible = lookup.ICAMPO15.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO15"] && lookup.ILBL_CAMPO15 != null && lookup.ILBL_CAMPO15.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["TASAIVA"].HeaderText = lookup.ILBL_CAMPO15;
                        }
                        if (!(bool)lookup.isnull["ICAMPO16"])
                        {
                            pRODUCTOSDataGridView.Columns["DGLIMITEPRECIO2"].Visible = lookup.ICAMPO16.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO16"] && lookup.ILBL_CAMPO16 != null && lookup.ILBL_CAMPO16.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGLIMITEPRECIO2"].HeaderText = lookup.ILBL_CAMPO16;
                        }
                        if (!(bool)lookup.isnull["ICAMPO17"])
                        {
                            pRODUCTOSDataGridView.Columns["DGPRECIO2"].Visible = lookup.ICAMPO17.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO17"] && lookup.ILBL_CAMPO17 != null && lookup.ILBL_CAMPO17.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGPRECIO2"].HeaderText = lookup.ILBL_CAMPO17;
                        }
                        if (!(bool)lookup.isnull["ICAMPO18"])
                        {
                            pRODUCTOSDataGridView.Columns["DGEAN"].Visible = lookup.ICAMPO18.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO18"] && lookup.ILBL_CAMPO18 != null && lookup.ILBL_CAMPO18.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["DGEAN"].HeaderText = lookup.ILBL_CAMPO18;
                        }
                        if (!(bool)lookup.isnull["ICAMPO19"])
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIA"].Visible = lookup.ICAMPO19.Equals("S");

                            if(CurrentUserID.CurrentParameters.ICAJASBOTELLAS != null && CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S"))
                            {
                                pRODUCTOSDataGridView.Columns["DGCAJAS"].Visible = true;
                                pRODUCTOSDataGridView.Columns["DGPIEZAS"].Visible = true;
                            }

                            if (!(bool)lookup.isnull["ILBL_CAMPO19"] && lookup.ILBL_CAMPO19 != null && lookup.ILBL_CAMPO19.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["EXISTENCIA"].HeaderText = lookup.ILBL_CAMPO19;
                        }
                        if (!(bool)lookup.isnull["ICAMPO20"])
                        {
                            pRODUCTOSDataGridView.Columns["EXISTENCIAAPARTADO"].Visible = lookup.ICAMPO20.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO20"] && lookup.ILBL_CAMPO20 != null && lookup.ILBL_CAMPO20.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["EXISTENCIAAPARTADO"].HeaderText = lookup.ILBL_CAMPO20;
                        }
                        if (!(bool)lookup.isnull["ICAMPO21"])
                        {
                            pRODUCTOSDataGridView.Columns["ENPROCESODESALIDA"].Visible = lookup.ICAMPO21.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO21"] && lookup.ILBL_CAMPO21 != null && lookup.ILBL_CAMPO21.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["ENPROCESODESALIDA"].HeaderText = lookup.ILBL_CAMPO21;
                        }
                        if (!(bool)lookup.isnull["ICAMPO22"])
                        {
                            pRODUCTOSDataGridView.Columns["TASAIEPS"].Visible = lookup.ICAMPO22.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO22"] && lookup.ILBL_CAMPO22 != null && lookup.ILBL_CAMPO22.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["TASAIEPS"].HeaderText = lookup.ILBL_CAMPO22;
                        }
                        
                        if (!(bool)lookup.isnull["ICAMPO24"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO3"].Visible = lookup.ICAMPO24.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 3;
                            if (!(bool)lookup.isnull["ILBL_CAMPO24"] && lookup.ILBL_CAMPO24 != null && lookup.ILBL_CAMPO24.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO3"].HeaderText = lookup.ILBL_CAMPO24;
                        }

                        if (!(bool)lookup.isnull["ICAMPO25"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO4"].Visible = lookup.ICAMPO25.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 4;
                            if (!(bool)lookup.isnull["ILBL_CAMPO25"] && lookup.ILBL_CAMPO25 != null && lookup.ILBL_CAMPO25.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO4"].HeaderText = lookup.ILBL_CAMPO25;
                        }

                        if (!(bool)lookup.isnull["ICAMPO26"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO5"].Visible = lookup.ICAMPO26.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 5;
                            if (!(bool)lookup.isnull["ILBL_CAMPO26"] && lookup.ILBL_CAMPO26 != null && lookup.ILBL_CAMPO26.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO5"].HeaderText = lookup.ILBL_CAMPO26;
                        }


                        if (!(bool)lookup.isnull["ICAMPO27"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO2_MAS_IMPUESTO"].Visible = lookup.ICAMPO27.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 2;
                            if (!(bool)lookup.isnull["ILBL_CAMPO27"] && lookup.ILBL_CAMPO27 != null && lookup.ILBL_CAMPO27.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO2_MAS_IMPUESTO"].HeaderText = lookup.ILBL_CAMPO27;
                        }

                        if (!(bool)lookup.isnull["ICAMPO28"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO3_MAS_IMPUESTO"].Visible = lookup.ICAMPO28.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 3;
                            if (!(bool)lookup.isnull["ILBL_CAMPO28"] && lookup.ILBL_CAMPO28 != null && lookup.ILBL_CAMPO28.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO3_MAS_IMPUESTO"].HeaderText = lookup.ILBL_CAMPO28;
                        }

                        if (!(bool)lookup.isnull["ICAMPO29"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO4_MAS_IMPUESTO"].Visible = lookup.ICAMPO29.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 4;
                            if (!(bool)lookup.isnull["ILBL_CAMPO29"] && lookup.ILBL_CAMPO29 != null && lookup.ILBL_CAMPO29.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO4_MAS_IMPUESTO"].HeaderText = lookup.ILBL_CAMPO29;
                        }

                        if (!(bool)lookup.isnull["ICAMPO30"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIO5_MAS_IMPUESTO"].Visible = lookup.ICAMPO30.Equals("S") && CurrentUserID.CurrentUser.ILISTAPRECIOID >= 5;
                            if (!(bool)lookup.isnull["ILBL_CAMPO30"] && lookup.ILBL_CAMPO30 != null && lookup.ILBL_CAMPO30.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIO5_MAS_IMPUESTO"].HeaderText = lookup.ILBL_CAMPO30;
                        }

                        if (!(bool)lookup.isnull["ICAMPO31"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIOCAJA_MAS_IMPUESTO"].Visible = lookup.ICAMPO31.Equals("S") ;
                            if (!(bool)lookup.isnull["ILBL_CAMPO31"] && lookup.ILBL_CAMPO31 != null && lookup.ILBL_CAMPO31.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIOCAJA_MAS_IMPUESTO"].HeaderText = lookup.ILBL_CAMPO31;
                        }

                        if (!(bool)lookup.isnull["ICAMPO32"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIOMEDIOMAYOREOCONTARJETA"].Visible = lookup.ICAMPO32.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO32"] && lookup.ILBL_CAMPO32 != null && lookup.ILBL_CAMPO32.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIOMEDIOMAYOREOCONTARJETA"].HeaderText = lookup.ILBL_CAMPO32;
                        }

                        if (!(bool)lookup.isnull["ICAMPO33"])
                        {
                            pRODUCTOSDataGridView.Columns["PRECIOMAYOREOCONTARJETA"].Visible = lookup.ICAMPO33.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO33"] && lookup.ILBL_CAMPO33 != null && lookup.ILBL_CAMPO33.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PRECIOMAYOREOCONTARJETA"].HeaderText = lookup.ILBL_CAMPO33;
                        }


                        if (!(bool)lookup.isnull["ICAMPO34"])
                        {
                            pRODUCTOSDataGridView.Columns["U_EMPAQUE"].Visible = lookup.ICAMPO34.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO34"] && lookup.ILBL_CAMPO34 != null && lookup.ILBL_CAMPO34.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["U_EMPAQUE"].HeaderText = lookup.ILBL_CAMPO34;
                        }


                        if (!(bool)lookup.isnull["ICAMPO35"])
                        {
                            pRODUCTOSDataGridView.Columns["PZACAJA"].Visible = lookup.ICAMPO35.Equals("S");
                            if (!(bool)lookup.isnull["ILBL_CAMPO35"] && lookup.ILBL_CAMPO35 != null && lookup.ILBL_CAMPO35.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["PZACAJA"].HeaderText = lookup.ILBL_CAMPO35;
                        }

                        if (!(bool)lookup.isnull["ICAMPO36"])
                        {
                            pRODUCTOSDataGridView.Columns["COSTOREPOCONUTILMACROIMP"].Visible = lookup.ICAMPO36.Equals("S") && m_tienePermisoParaPrecioConUtilMacro;
                            if (!(bool)lookup.isnull["ILBL_CAMPO36"] && lookup.ILBL_CAMPO36 != null && lookup.ILBL_CAMPO36.Trim().Length > 0)
                                pRODUCTOSDataGridView.Columns["COSTOREPOCONUTILMACROIMP"].HeaderText = lookup.ILBL_CAMPO36;
                        }

                    }
                }
                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO1"] && CurrentUserID.CurrentParameters.ITEXTO1 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO1"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO1;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO1"].Visible = false;
                }



                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO2"] && CurrentUserID.CurrentParameters.ITEXTO2 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO2"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO2;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO2"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO3"] && CurrentUserID.CurrentParameters.ITEXTO3 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO3"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO3;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO4"] && CurrentUserID.CurrentParameters.ITEXTO4 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO4"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO4;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO4"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO5"] && CurrentUserID.CurrentParameters.ITEXTO5 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO5"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO5;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO5"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["ITEXTO6"] && CurrentUserID.CurrentParameters.ITEXTO6 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO6"].HeaderText = CurrentUserID.CurrentParameters.ITEXTO6;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGTEXTO6"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO1"] && CurrentUserID.CurrentParameters.INUMERO1 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO1"].HeaderText = CurrentUserID.CurrentParameters.INUMERO1;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO2"] && CurrentUserID.CurrentParameters.INUMERO2 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO2"].HeaderText = CurrentUserID.CurrentParameters.INUMERO2;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO2"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO3"] && CurrentUserID.CurrentParameters.INUMERO3 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO3"].HeaderText = CurrentUserID.CurrentParameters.INUMERO3;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO3"].Visible = false;
                }

                if (!(bool)CurrentUserID.CurrentParameters.isnull["INUMERO4"] && CurrentUserID.CurrentParameters.INUMERO4 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO4"].HeaderText = CurrentUserID.CurrentParameters.INUMERO4;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGNUMERO4"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA1"] && CurrentUserID.CurrentParameters.IFECHA1 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGFECHA1"].HeaderText = CurrentUserID.CurrentParameters.IFECHA1;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGFECHA1"].Visible = false;
                }


                if (!(bool)CurrentUserID.CurrentParameters.isnull["IFECHA2"] && CurrentUserID.CurrentParameters.IFECHA2 != "")
                {
                    pRODUCTOSDataGridView.Columns["DGFECHA2"].HeaderText = CurrentUserID.CurrentParameters.IFECHA2;
                }
                else
                {
                    pRODUCTOSDataGridView.Columns["DGFECHA2"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSoloAlmacen.Checked)
            {
                RefrescarGrid();
            }
        }

        private void CBSoloAlmacen_CheckedChanged(object sender, EventArgs e)
        {

                RefrescarGrid();
        }


        private void ObtenerExistenciaProducto()
        {
            WFEspera wf = new WFEspera();
            wf.Show();

            try
            {

                com.server.ipos.Service1 service1 = new com.server.ipos.Service1();

                string strWebService = CurrentUserID.CurrentParameters.IUSARCONEXIONLOCAL.Equals("S") ? (CurrentUserID.CurrentParameters.ILOCALWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.ILOCALWEBSERVICE.Trim()) : (CurrentUserID.CurrentParameters.IWEBSERVICE == null ? "" : CurrentUserID.CurrentParameters.IWEBSERVICE.Trim());
                if (strWebService.Trim().Length > 0)
                {
                    service1.Url = strWebService.Trim();
                }

                int iRetornoRowIndex = pRODUCTOSDataGridView.CurrentRow.Index;
                string strProductClave = pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["DGCLAVE"].Value.ToString();
                decimal existenciaActual = Decimal.Parse(pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["EXISTENCIA"].Value.ToString());

                long prodId = long.Parse(pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["DGID"].Value.ToString());


                CM_VEDPBE retorno = new CM_VEDPBE();
                retorno.IVENTA = "X";
                retorno.ICLIENTE = "X";
                retorno.IPRODUCTO = strProductClave;
                retorno.IID_FECHA = DateTime.Now;
                retorno.ICANTIDAD = existenciaActual;
                retorno.IPRECIO = 0;
                retorno.IDESCUENTO = 0;
                retorno.ICLASIFICA = "N";

                CM_VEDPBE[] vedpbes = new CM_VEDPBE[] { retorno };
                string jsonStr = JsonConvert.SerializeObject(vedpbes, Formatting.Indented);
                string strRespuesta = "";
                try
                {


                    if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                    {
                        strRespuesta = service1.ValidarVentaMovil_2(jsonStr, iPos.CurrentUserID.CurrentParameters.IBDSERVERWS, iPos.CurrentUserID.CurrentUser.IUSERNAME,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }
                    else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3)
                    {
                            strRespuesta = service1.ValidarVentaMovil_3(jsonStr, iPos.CurrentUserID.CurrentParameters.IVENDEDORMOVILCLAVE,iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                            iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                            iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                     }
                    else
                    {
                        strRespuesta = service1.ValidarVentaMovil(jsonStr, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                        iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                        iPos.Tools.FTPManagement.m_strFTPFolderPassWs);
                    }

                    if (!strRespuesta.StartsWith("["))
                    {
                        MessageBox.Show("No se pudo obtener la existencia: " + strRespuesta);
                    }



                    List<CM_PROPBE> prods = JsonConvert.DeserializeObject<List<CM_PROPBE>>(strRespuesta);
                    if (prods.Count > 0)
                    {
                        CM_PROPBE prod = prods[0];

                        if (prod.IEXIS1 != existenciaActual)
                        {
                            CPRODUCTOD prodD = new CPRODUCTOD();
                            if (prodD.CambiarExistenciaMovilPRODUCTOD(prodId, prod.IEXIS1, null))
                                pRODUCTOSDataGridView.Rows[iRetornoRowIndex].Cells["EXISTENCIA"].Value = prod.IEXIS1;
                        }

                        string strCantidad = "";
                        if (prod.IBOTCAJA > 1)
                        {
                            decimal bufferCajas = Math.Floor(prod.IEXIS1 / prod.IBOTCAJA);
                            decimal bufferPzasSueltas = prod.IEXIS1 - (prod.IBOTCAJA * bufferCajas);

                            strCantidad = bufferCajas.ToString("N0") + " CJA " + bufferPzasSueltas.ToString() + " PZA";
                        }
                        else
                        {
                            strCantidad = prod.IEXIS1.ToString("N0") + " PZA";
                        }


                        CurrentUserID.UpdataAutoCompleteExistenceSingleProduct(strProductClave, strCantidad);

                    }
                }
                catch
                {
                }
            }
            catch
            {
            }

            finally
            {
                wf.Close();
            }
        }

        private void CBSoloHistorial_CheckedChanged(object sender, EventArgs e)
        {

            RefrescarGrid();
        }

        private void CBSoloProm_CheckedChanged(object sender, EventArgs e)
        {

            RefrescarGrid();
        }

        private void busquedaToolStripTextBox_Enter(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                busquedaToolStripTextBox.Width = 500;
            }
        }

        private void busquedaToolStripTextBox_Leave(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IAUTOCOMPPROD.Equals("S"))
            {
                busquedaToolStripTextBox.Width = 246;
            }
        }

        private void btnLimpiarTextoBusqueda_Click(object sender, EventArgs e)
        {
            busquedaToolStripTextBox.Text = "";
            busquedaToolStripTextBox.Focus();
        }

        private void busquedaToolStripTextBox_DoubleClick(object sender, EventArgs e)
        {
            if(CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                string bufferBusquedaText = busquedaToolStripTextBox.Text;
                if (bufferBusquedaText.Contains(" <(("))
                {
                    string[] strSeparators = new string[] { " <((" };

                    string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (strBuffert.Count() > 0)
                        bufferBusquedaText = strBuffert[0];
                }

                if (bufferBusquedaText.Length > 12)
                    bufferBusquedaText = bufferBusquedaText.Substring(0, 12);


                busquedaToolStripTextBox.Text = bufferBusquedaText;


            }
        }


        public static void VerHistorialProducto(int productoid)
        {
            CPRODUCTOD productoD = new CPRODUCTOD();
            CPRODUCTOBE productoBE = new CPRODUCTOBE();

            productoBE.IID = productoid;
            productoBE = productoD.seleccionarPRODUCTO(productoBE, null);


            WFLogItems wfLogItems = new WFLogItems("Producto", productoBE);
            wfLogItems.ShowDialog();
            wfLogItems.Dispose();
            GC.SuppressFinalize(wfLogItems);
        }

        public static void VerEstadisticoCompra(int productoid)
        {

            WFEstadisticosProductoCompra wf = new WFEstadisticosProductoCompra(productoid);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }


        public static void VerEstadisticoVenta(int productoid)
        {


            WFEstadisticosProductoVenta wf = new WFEstadisticosProductoVenta(productoid);
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void LOOKPROD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        

        decimal m_porcUtilPrevValue = 0;
        private void PORCUTILIDADLISTADOTextBox_Enter(object sender, EventArgs e)
        {
            m_porcUtilPrevValue = decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString());
        }

        private void PORCUTILIDADLISTADOTextBox_Leave(object sender, EventArgs e)
        {
            decimal newValue = decimal.Parse(this.PORCUTILIDADLISTADOTextBox.NumericValue.ToString());
            if(newValue != m_porcUtilPrevValue)
                this.RecalculateAllCostoWithUtilidad();
        }

        /*
        private void fillToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.pRODUCTOSCONHISTORIALTableAdapter.Fill(this.dSPuntoDeVentaAux.PRODUCTOSCONHISTORIAL, busquedaToolStripTextBox1.Text, soloConExistenciaToolStripTextBox.Text, mostrarDescontinuadosToolStripTextBox.Text, eSPRODUCTOPADREToolStripTextBox.Text, soloConPromoToolStripTextBox.Text, new System.Nullable<int>(((int)(System.Convert.ChangeType(pERSONAIDToolStripTextBox.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/






        /*
        private void fillToolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.pRODUCTOSPORALMACENTableAdapter.Fill(this.dSPuntoDeVentaAux.PRODUCTOSPORALMACEN, new System.Nullable<int>(((int)(System.Convert.ChangeType(aLMACENIDToolStripTextBox.Text, typeof(int))))), busquedaToolStripTextBox1.Text, soloConExistenciaToolStripTextBox.Text, mostrarDescontinuadosToolStripTextBox.Text, eSPRODUCTOPADREToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/


    }
}
