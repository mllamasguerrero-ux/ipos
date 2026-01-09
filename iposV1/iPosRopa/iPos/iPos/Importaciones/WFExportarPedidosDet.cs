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
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using DataLayer.Importaciones;
using ConexionesBD;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;

namespace iPos
{
    public partial class WFExportarPedidosDet : IposForm
    {
        //string m_fileName;
        //DateTime m_fecha;
        //TimeSpan m_time;
        long m_doctoId;
        long m_tipodoctoId;

        decimal dMaxCantidad = 1000;

        public bool m_bCancelar;
        public bool m_bReadOnly = false;

        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        public WFExportarPedidosDet()
        {
            InitializeComponent();
        }
        public WFExportarPedidosDet(long doctoId,long tipodoctoId)
        {
            InitializeComponent();
            m_doctoId = doctoId;
            m_tipodoctoId = tipodoctoId;
            m_bCancelar = true;
            //m_fecha = fecha;
            //m_time = time;
        }


        public WFExportarPedidosDet(long doctoId, long tipodoctoId, bool bReadOnly) :
            this(doctoId,tipodoctoId)
        {
                m_bReadOnly =bReadOnly;

        }


        private void WFExportarPedidosDet_Load(object sender, EventArgs e)
        {

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            objDoctoBE.IID = m_doctoId;
            objDoctoBE = objDoctoD.seleccionarDOCTO(objDoctoBE, null);



            // TODO: This line of code loads data into the 'dSImportaciones.IMP_RECIBIDOS' table. You can move, or remove it, as needed.

            this.iMP_REC_DETDataGridView.ReadOnly = m_bReadOnly;
            this.pnlAdicion.Enabled = !m_bReadOnly;
            this.BTRECIBIR.Enabled = !m_bReadOnly;


            lblEsperandoExisRemota.Text = "";
            if (CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ == null || CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ.Trim().Length == 0)
            {
                btnObtenerExitenciaRemota.Visible = false;
                GC_EXISTENCIAREMOTA.Visible = false;
            }
            else
            {

                btnObtenerExitenciaRemota.Visible = true;
                GC_EXISTENCIAREMOTA.Visible = true;
            }

            try
            {
                this.pEDIRTableAdapter.Fill(this.dSImportaciones.PEDIR, (int)m_doctoId);

                this.iMP_REC_DETDataGridView.Sort(this.iMP_REC_DETDataGridView.Columns["LOCALIDAD"], System.ComponentModel.ListSortDirection.Ascending);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


            if(objDoctoBE != null && objDoctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_SOLICITUDMERCANCIA)
            {
                btnObtenerExitenciaRemota.Visible = false;

               if(objDoctoBE.ITRASLADOAFTP != null && objDoctoBE.ITRASLADOAFTP.Equals("S"))
                {
                    iMP_REC_DETDataGridView.ReadOnly = true;
                    BTAgregar.Enabled = false;
                    BTRECIBIR.Enabled = false;
                    btnReenviar.Visible = true;
                }
            }

            formateaGUIPzaCaja();
        }

        private void BTRECIBIR_Click(object sender, EventArgs e)
        {
            CMOVTOD objRecD = new CMOVTOD();
            CMOVTOBE objRecBE = new CMOVTOBE();

            CDOCTOD objDoctoD = new CDOCTOD();
            CDOCTOBE objDoctoBE = new CDOCTOBE();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            //bool bRes = false ;
            int count = 0;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {
                    
                    if (row.Index == iMP_REC_DETDataGridView.NewRowIndex)
                    {
                        continue;
                    }
                    objRecBE = new CMOVTOBE();
                    objRecBE.IID = long.Parse(row.Cells["GC_MOVTOID"].Value.ToString());
                    objRecBE.ICANTIDADFALTANTE = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());
                    objRecBE.ICANTIDAD = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());

                    count++;
                    objRecBE.IORDEN = count;

                    objRecBE.ITIPODIFERENCIAINVENTARIOID = 0;
                    try
                    {
                        if(row.Cells["GC_CANTIDAD"].Value != null)
                             if(row.Cells["GC_CANTIDAD"].Value.ToString() != "")
                                objRecBE.ITIPODIFERENCIAINVENTARIOID = long.Parse(row.Cells["DGC_RAZONDIFINVID"].Value.ToString());
                    }
                    catch
                    {
                    }

                    //if (objRecBE.ICANTIDAD != 0)
                    //{
                        if (objRecD.PEDIRMOVTOD(objRecBE, fTrans) == false)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            MessageBox.Show(objRecD.IComentario);
                            return;
                        }
                   // }
                }



                fTrans.Commit();
                fConn.Close();

                m_bCancelar = false;
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                try
                {
                    fTrans.Rollback();
                }
                catch
                {
                }
                MessageBox.Show("1" + ex.Message);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
            
            
        }


        private void iMP_REC_DETDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridViewRow row = iMP_REC_DETDataGridView.Rows[e.RowIndex];
            //if(row.Cells["GC_CANTIDAD"].Value != null)
            //    row.Cells["GC_APEDIR"].Value = row.Cells["GC_CANTIDAD"].Value;
        }

        private void iMP_REC_DETDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void iMP_REC_DETDataGridView_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {

            //foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            //{
            //    if(row.Cells["GC_CANTIDAD"].Value != null)
            //        row.Cells["GC_APEDIR"].Value = row.Cells["GC_CANTIDAD"].Value;
            //}
        }

        private void iMP_REC_DETDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            MessageBox.Show("Dato invalido , porfavor ingrese un dato valido");
            e.ThrowException = false;


        }

        private void iMP_REC_DETDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =  iMP_REC_DETDataGridView.Columns[e.ColumnIndex].Name;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("GC_APEDIR") && !headerText.Equals("DGCAJAS") && !headerText.Equals("DGPIEZAS")) return;

            if (headerText.Equals("GC_APEDIR"))
             {
                try
                {
                    decimal piezaCaja = 1;
                    decimal cajasPedidas = 0;
                    decimal piezasPedidas = 0;


                    decimal dSurtida = decimal.Parse(e.FormattedValue.ToString());
                    decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());
                    piezasPedidas = headerText.Equals("DGPIEZAS") ? decimal.Parse(e.FormattedValue.ToString()) : decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value.ToString());

                    piezaCaja = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPZACAJA"].Value.ToString());
                    if (piezaCaja < 1)
                        piezaCaja = 1;
                    
                    cajasPedidas = Math.Truncate(dSurtida / piezaCaja);
                    piezasPedidas = Math.Truncate(dSurtida % piezaCaja);
                    
                    if (/*dSurtida > dCantidad ||*/ dSurtida < 0)
                    {
                        MessageBox.Show("La cantidad surtida no puede ser  menor que cero");
                        e.Cancel = true;
                    }
                    else if (dSurtida != dCantidad
                             && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value.ToString() == ""))
                    {


                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value = null;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVTEXT"].Value = "";
                        //iMP_REC_DETDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);


                    }
                    else if (dSurtida == dCantidad)
                    {

                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value = null;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVTEXT"].Value = "";
                    }



                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGCAJAS"].Value = cajasPedidas;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value = piezasPedidas;
                }
                catch
                {
                }
            }
            else if(headerText.Equals("DGCAJAS") || headerText.Equals("DGPIEZAS"))
            {

                try
                {


                    decimal piezaCaja = 1;
                    decimal cajasPedidas = 0;
                    decimal piezasPedidas = 0;

                    cajasPedidas = headerText.Equals("DGCAJAS") ? decimal.Parse(e.FormattedValue.ToString()) : decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGCAJAS"].Value.ToString());
                    piezasPedidas = headerText.Equals("DGPIEZAS") ? decimal.Parse(e.FormattedValue.ToString()) : decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value.ToString());

                    piezaCaja = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPZACAJA"].Value.ToString());
                    if (piezaCaja < 1)
                        piezaCaja = 1;

                    decimal dSurtida = piezasPedidas + (cajasPedidas * piezaCaja);
                    decimal dCantidad = decimal.Parse(iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_CANTIDAD"].Value.ToString());
                    if ( dSurtida < 0)
                    {
                        MessageBox.Show("La cantidad surtida no puede ser  menor que cero");
                        e.Cancel = true;
                    }
                    else if (dSurtida != dCantidad
                             && (iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value == null || iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value.ToString() == ""))
                    {


                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value = null;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVTEXT"].Value = "";
                        //iMP_REC_DETDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);


                    }
                    else if (dSurtida == dCantidad)
                    {

                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVID"].Value = null;
                        iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGC_RAZONDIFINVTEXT"].Value = "";
                    }


                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGCAJAS"].Value = cajasPedidas;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["DGPIEZAS"].Value = piezasPedidas;
                    iMP_REC_DETDataGridView.Rows[e.RowIndex].Cells["GC_APEDIR"].Value = dSurtida;


                }
                catch
                {
                }
            }

        }





        private CSUCURSALBE DatosSucursal(long lSucursalTid)
        {

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = lSucursalTid;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

            return sucursalBE;

        }

        private void TBCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (TBCodigo.Text.Trim() == "")
                return;

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {
                this.LBProductoDescripcion.Text = "";
                SeleccionarProducto(TBCodigo.Text.Trim());
                return;
            }
            this.LBProductoDescripcion.Text = prod.IDESCRIPCION;

        }


        private bool BuscarProducto(ref CPRODUCTOBE prod)
        {
            CComprasD pvd = new CComprasD();
            prod = pvd.buscarPRODUCTOSPV(TBCodigo.Text.Trim(), CurrentUserID.CurrentParameters, null);
            if (prod != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void SeleccionarProducto(string strDescripcion)
        {

            LOOKPROD look;
            if (strDescripcion == "")
                look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            else
                look = new LOOKPROD(strDescripcion, false, TipoProductoNivel.tp_hijos);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.TBCodigo.Text = dr["CLAVE"].ToString().Trim();
                TBCodigo.Focus();
                TBCodigo.Select(TBCodigo.Text.Length, 0);
            }
        }

        private void TBCodigo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (TBCodigo.Text.Trim() == "")
                {
                    SeleccionarProducto(TBCodigo.Text.Trim());
                    return;
                }
                this.TBLocalidad.Focus();
                TBLocalidad.Select(0, TBLocalidad.Text.Length);
            }
        }

        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.BTAgregar.Focus();
            //}
        }


        private void ProcessAdd()
        {

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = (int)DBValues._DOCTO_ALMACEN_DEFAULT;/*CurrentUserID.CurrentUser.IUS_ALMACENID*/ ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_PEDIDA = null;

            long? P_TIPODIFERENCIAINVENTARIOID = 0;

            long? P_MOVTOID = null;
            
            string P_LOCALIDAD = TBLocalidad.Text;


            if (TBCodigo.Text.Trim() == "")
            {
                MessageBox.Show("El texto de este control no debe estar vacio");
                return;
            }

            CPRODUCTOBE prod = new CPRODUCTOBE();
            if (!BuscarProducto(ref prod))
            {

                MessageBox.Show("El producto no existe");
                return;
            }

            P_IDPRODUCTO = prod.IID;



            if (!bEstaConfiguradoParaPiezasyCajas())
            {
                try
                {
                    P_CANTIDAD_PEDIDA = decimal.Parse(TBCantidad.Text.Trim());

                }
                catch
                {
                    MessageBox.Show("La cantidad no tiene el formato adecuado");
                    return;
                }
            }
            else
            {
                decimal piezasPedidas = 0;
                decimal cajasPedidas = 0;
                decimal piezaCaja = 1;

                if (!(bool)prod.isnull["IPZACAJA"])
                    piezaCaja = prod.IPZACAJA;

                if (piezaCaja < 1)
                    piezaCaja = 1;
                try
                {
                    piezasPedidas = decimal.Parse(TBCantidad.Text.Trim());

                }
                catch
                {
                    MessageBox.Show("La cantidad no tiene el formato adecuado");
                    return;
                }


                try
                {
                    cajasPedidas = decimal.Parse(TBCajas.Text.Trim());

                }
                catch
                {
                    MessageBox.Show("La cantidad no tiene el formato adecuado");
                    return;
                }


                P_CANTIDAD_PEDIDA = piezasPedidas + (cajasPedidas * piezaCaja);

            }







            if (P_CANTIDAD_PEDIDA > dMaxCantidad  )
            {

                if (MessageBox.Show("La cantidad parece ser muy grande , seguro que desea continuar con esa cantidad ", "Cantidad muy grande", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            if (P_CANTIDAD_PEDIDA <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero ", "Cantidad menor o igual a cero", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
            //}



            //if (!(bool)this.m_Docto.isnull["IID"])
            //{
                P_IDDOCTO = m_doctoId;
            //}

                P_CANTIDAD = P_CANTIDAD_PEDIDA;



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;


            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_tipodoctoId, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_CANTIDAD_PEDIDA, ref P_MOVTOID, null, fTrans))
                {
                    fTrans.Commit();


                    decimal piezaCaja = 1;

                    if (!(bool)prod.isnull["IPZACAJA"])
                        piezaCaja = prod.IPZACAJA;

                    if (piezaCaja < 1)
                        piezaCaja = 1;

                    decimal cajas = Math.Truncate(P_CANTIDAD.Value / piezaCaja);
                    decimal piezas = Math.Truncate(P_CANTIDAD.Value % piezaCaja);
                    
                    this.dSImportaciones.PEDIR.AddPEDIRRow(m_doctoId, (long)P_MOVTOID, "+", 0, prod.ICLAVE, prod.IDESCRIPCION1, (decimal)P_CANTIDAD, "", (decimal)P_CANTIDAD, (decimal)P_CANTIDAD, "", "", "", P_LOCALIDAD,0.0m,cajas, piezas, prod.IPZACAJA);
                    
                    PrepararSiguienteEntrada();
                    fConn.Close();
                }
                else
                {
                    fTrans.Rollback();
                    MessageBox.Show(this.IComentario);
                    this.TBCodigo.Focus();
                    fConn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                fConn.Close();
            }
            finally
            {
                fConn.Close();
            }
        }


       



        public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                        decimal? P_CANTIDAD,
                                        long? P_IDPRODUCTO,
                                        string P_VD_VENDEDOR,
                                        long? P_USERID,
                                        string P_LOTE,
                                        int? US_SUPERVISOR,
                                        int? ALMACENID,
                                        long? SUCURSALID,
                                        DateTime P_FECHAVENCE,
                                        long P_TIPO_DOCTO,
                                        long? P_SUCURSALTID,
                                        long? P_ALMACENTID,
                                        string P_PROMOCION,
                                        long? P_TIPODIFERENCIAINVENTARIOID,
                                        decimal? P_CANTIDAD_SURTIDA,
                                        ref long? P_MOVTOID,
                                        long? P_LOTEIMPORTADO,
                                        FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (P_CANTIDAD_SURTIDA.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD_SURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = ""; ;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = ""; ;
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = ""; ;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N"; 
                parts.Add(auxPar);




                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTO_INSERT";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                if (!(arParms[arParms.Length - 2].Value == System.DBNull.Value))
                {
                    
                        P_MOVTOID = (long)arParms[arParms.Length - 2].Value;
                }



                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        private void PrepararSiguienteEntrada()
        {
            this.TBCantidad.Text = "";
            this.TBCajas.Text = "";
            this.TBCodigo.Text = "";
            this.TBLocalidad.Text = "";
            this.TBCodigo.Focus();
            
        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {
            ProcessAdd();
        }

        private void TBLocalidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if(bEstaConfiguradoParaPiezasyCajas())
                {

                    this.TBCajas.Focus();
                    TBCajas.Select(0, TBCajas.Text.Length);
                }
                else
                {

                    this.TBCantidad.Focus();
                    TBCantidad.Select(0, TBCantidad.Text.Length);
                }

            }
        }


        List<CM_PROPBE> prodsExistenciaRemota = new List<CM_PROPBE>();
        string errorExistenciaRemota = "";
        private void btnObtenerExitenciaRemota_Click(object sender, EventArgs e)
        {
            if (CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ == null || CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ.Trim().Length == 0)
            {
                MessageBox.Show("No esta definido el webservice para obtener la existencia");
                return;
            }

            prodsExistenciaRemota = new List<CM_PROPBE>();
            
            lblEsperandoExisRemota.Text = "Esperando existencia remota ..";

            bgExistenciaRemota.RunWorkerAsync();


        }



        private void bgExistenciaRemota_DoWork(object sender, DoWorkEventArgs e)
        {
            errorExistenciaRemota = "";

            CPERSONABE cliente = new CPERSONABE();
            CPERSONAD clienteD = new CPERSONAD();
            cliente.IID = DBValues._CLIENTEMOSTRADOR;
            cliente = clienteD.seleccionarPERSONA(cliente, null);

            if (cliente == null)
            {
                errorExistenciaRemota = "No se pudo obtener el cliente";
                return;
            }




            ArrayList vedps = new ArrayList();
            foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
            {






                CM_VEDPBE retorno = new CM_VEDPBE();
                retorno.IVENTA = "00001";
                retorno.ICLIENTE = "MOSTRADOR";

                retorno.IPRODUCTO = row.Cells["GC_PRODUCTO"].Value.ToString();
                retorno.IID_FECHA = DateTime.Today;
                retorno.IID_HORA = "";
                retorno.ICANTIDAD = 1.0m;
                retorno.IPRECIO = 1.0m;
                retorno.IDESCUENTO = 0.0m;
                retorno.ICLASIFICA = "";

                vedps.Add(retorno);
            }


            CM_VEDPBE[] vedpbes = new CM_VEDPBE[vedps.Count];
            vedps.CopyTo(vedpbes, 0);
            string jsonStr = JsonConvert.SerializeObject(vedpbes, Formatting.Indented);


            com.server.ipos.Service1 service1 = new com.server.ipos.Service1();
            string strWebService = CurrentUserID.CurrentParameters.IWSESPECIALEXISTMATRIZ;

            
            if (strWebService.Trim().Length > 0)
            {
                service1.Url = strWebService.Trim().Equals(".") ? ( CurrentUserID.CurrentParameters.IWEBSERVICE  != null && CurrentUserID.CurrentParameters.IWEBSERVICE.Trim().Length > 0 ?
                                            CurrentUserID.CurrentParameters.IWEBSERVICE : service1.Url) :  
                                            strWebService.Trim();
            }


            string strRespuesta = "";
            try
            {

                if (strWebService.Trim().Equals("."))
                {
                    CSUCURSALD sucursalD = new CSUCURSALD();
                    CSUCURSALBE sucursalMatrizBE = sucursalD.seleccionarSUCURSALMATRIZ(null);
                    string strSucursal = "";
                    if (sucursalMatrizBE != null)
                    {
                        strSucursal = sucursalMatrizBE.ICLAVE;
                    }
                    strRespuesta = service1.LeerExistenciasSucursalMultipleProductosBD(strSucursal, jsonStr,
                                    iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    iPos.Tools.FTPManagement.m_strFTPFolderPassWs
                                    );
                }
                else
                {
                    strRespuesta = service1.ValidarVentaMovil(jsonStr, iPos.CurrentUserID.CurrentParameters.ISUCURSALNUMERO,
                                    "vocero",//iPos.Tools.FTPManagement.m_strFTPFolderWs,
                                    "PK3Qz65ePJo29FdcEqM+Mg=="//iPos.Tools.FTPManagement.m_strFTPFolderPassWs
                                    );
                }


                if (!strRespuesta.StartsWith("["))
                {
                    errorExistenciaRemota = "No se pudo validar la venta: " + strRespuesta;
                }



                prodsExistenciaRemota = JsonConvert.DeserializeObject<List<CM_PROPBE>>(strRespuesta);


            }
            catch (Exception ex)
            {
                errorExistenciaRemota = "No se pudo validar las existencias " + ex.Message;
                return;
            }

        }

        private void bgExistenciaRemota_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblEsperandoExisRemota.Text = "";

            if(errorExistenciaRemota != "")
            {
                MessageBox.Show(errorExistenciaRemota);
                return;
            }


            if (/*prods.Count > 0*/ prodsExistenciaRemota != null && prodsExistenciaRemota.Count > 0)
            {
                bool bHayProblemasDeExistencia = false;

                foreach (DataGridViewRow row in iMP_REC_DETDataGridView.Rows)
                {
                    string productoRow = row.Cells["GC_PRODUCTO"].Value.ToString();
                    decimal cantidadPedida = Decimal.Parse(row.Cells["GC_APEDIR"].Value.ToString());

                    bool productoHayado = false;
                    bool flagFaltaExistencia = false;
                    foreach (CM_PROPBE prod in prodsExistenciaRemota)
                    {
                        if (productoRow.Trim().Equals(prod.IPRODUCTO.Trim()))
                        {
                            row.Cells["GC_EXISTENCIAREMOTA"].Value = prod.IEXIS1;

                            if (cantidadPedida > prod.IEXIS1)
                            {

                                flagFaltaExistencia = true;

                            }
                            productoHayado = true;
                            break;
                        }
                    }
                    if (!productoHayado || flagFaltaExistencia)
                    {
                        bHayProblemasDeExistencia = true;
                    }

                }

                if (!bHayProblemasDeExistencia)
                {
                    //MessageBox.Show("Parece que hay existencias suficiente para todos los productos de esta venta");
                }
            }
        }



        private bool bEstaConfiguradoParaPiezasyCajas()
        {
            return (CurrentUserID.CurrentParameters.ICAJASBOTELLAS.Equals("S") && CurrentUserID.CurrentUser.ICAJASBOTELLAS.Equals("S"));
        }


        private void formateaGUIPzaCaja()
        {
            if (!bEstaConfiguradoParaPiezasyCajas())
            {
                if (TBCajas.Focused || TBCajas.Focused)
                {
                    TBCantidad.Focus();
                }

                lblCaja.Visible = false;
                TBCajas.Visible = false;

                DGCAJAS.Visible = false;


            }
            else
            {

                lblCaja.Visible = true;
                TBCajas.Visible = true;

                DGCAJAS.Visible = true;
            }
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {

            m_bCancelar = false;
            this.Close();
            this.Dispose();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();
            bool bImportacionExitosa = false;
            WFImportarSolicitudPedExcel wf = new WFImportarSolicitudPedExcel();
            wf.ShowDialog();
            datos = wf.m_datos;
            bImportacionExitosa = wf.m_importacionExitosa;
            wf.Dispose();
            GC.SuppressFinalize(wf);

            CPRODUCTOD prodD = new CPRODUCTOD();
            CPRODUCTOBE prod = new CPRODUCTOBE();


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            long? P_IDDOCTO = null;
            decimal? P_CANTIDAD = null;
            long? P_IDPRODUCTO = null;
            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            string P_LOTE = "";
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            int? US_SUPERVISORID = null;
            int? ALMACENID = (int)DBValues._DOCTO_ALMACEN_DEFAULT; ;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;
            long? SUCURSALTID = 0;
            long? ALMACENTID = 0;
            decimal? P_CANTIDAD_PEDIDA = null;
            long? P_TIPODIFERENCIAINVENTARIOID = 0;
            long? P_MOVTOID = null;
            string P_LOCALIDAD = "";
            


            if (bImportacionExitosa)
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                //1ra vuelta

                try
                {
                    foreach (Dictionary<string, object> item in datos)
                    {

                        string claveProducto = item["CLAVE"].ToString();


                        prod.ICLAVE = claveProducto;
                        prod = prodD.seleccionarPRODUCTOxCLAVE(prod, null);

                        if (prod == null)
                        {
                            throw new Exception("Hay claves de producto no existen");
                        }



                        P_IDPRODUCTO = prod.IID;
                        if (!bEstaConfiguradoParaPiezasyCajas())
                        {
                            try
                            {
                                P_CANTIDAD_PEDIDA = decimal.Parse(item["PIEZAS"].ToString());

                            }
                            catch
                            {
                                throw new Exception("La cantidad no tiene el formato adecuado");
                            }
                        }
                        else
                        {
                            decimal piezasPedidas = 0;
                            decimal cajasPedidas = 0;
                            decimal piezaCaja = 1;

                            if (!(bool)prod.isnull["IPZACAJA"])
                                piezaCaja = prod.IPZACAJA;

                            if (piezaCaja < 1)
                                piezaCaja = 1;
                            try
                            {
                                piezasPedidas = decimal.Parse(item["PIEZAS"].ToString());

                            }
                            catch
                            {
                                throw new Exception("La cantidad no tiene el formato adecuado");
                            }


                            try
                            {
                                cajasPedidas = decimal.Parse(item["CAJAS"].ToString());

                            }
                            catch
                            {
                                throw new Exception("La cantidad no tiene el formato adecuado");
                            }


                            P_CANTIDAD_PEDIDA = piezasPedidas + (cajasPedidas * piezaCaja);

                        }
                        P_IDDOCTO = m_doctoId;
                        P_CANTIDAD = P_CANTIDAD_PEDIDA;


                        if (EjecutarAddMOVTO(ref P_IDDOCTO, P_CANTIDAD, P_IDPRODUCTO, P_VD_VENDEDOR, P_USERID, P_LOTE, US_SUPERVISORID, ALMACENID, SUCURSALID, P_FECHAVENCE, m_tipodoctoId, SUCURSALTID, ALMACENTID, "N", P_TIPODIFERENCIAINVENTARIOID, P_CANTIDAD_PEDIDA, ref P_MOVTOID, null, fTrans))
                        {


                            decimal piezaCaja = 1;

                            if (!(bool)prod.isnull["IPZACAJA"])
                                piezaCaja = prod.IPZACAJA;

                            if (piezaCaja < 1)
                                piezaCaja = 1;

                            decimal cajas = Math.Truncate(P_CANTIDAD.Value / piezaCaja);
                            decimal piezas = Math.Truncate(P_CANTIDAD.Value % piezaCaja);

                            this.dSImportaciones.PEDIR.AddPEDIRRow(m_doctoId, (long)P_MOVTOID, "+", 0, prod.ICLAVE, prod.IDESCRIPCION1, (decimal)P_CANTIDAD, "", (decimal)P_CANTIDAD, (decimal)P_CANTIDAD, "", "", "", P_LOCALIDAD, 0.0m, cajas, piezas, prod.IPZACAJA);


                        }
                        else
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            throw new Exception( "Error en producto " + prod.INOMBRE + " " + this.IComentario);
                        }

                    }

                    fTrans.Commit();
                }
                catch (Exception ex)
                {
                    fTrans.Rollback();
                    MessageBox.Show(ex.Message);
                    fConn.Close();
                }
                finally
                {
                    fConn.Close();
                }




            }
        }
    }
}
