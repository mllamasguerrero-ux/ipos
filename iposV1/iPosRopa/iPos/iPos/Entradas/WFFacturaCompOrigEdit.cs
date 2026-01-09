
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
using static iPos.Abonos.DSAbonos2;
using iPos.Abonos;

namespace iPos
{
    public partial class WFFacturaCompOrigEdit : IposForm
    {

        public string opc;
        System.Collections.ArrayList validadores;
        long ID;
        public delegate void AccionHandler(object source, Hashtable evtArgs);

        public WFFacturaCompOrigEdit()
        {
            InitializeComponent();
        }


        public void ReCargar(string popc,long pid)
        {
            opc = popc;
            ID = pid;
            validadores = new System.Collections.ArrayList();

            this.button1.Text = opc;
            if (this.opc != "Agregar" && this.opc != "")
            {
                if (this.opc == "Consultar")
                {
                    this.button1.Visible = false;
                    this.BTCancelar.Text = "Salir";
                    this.BTCancelar.Image = global::iPos.Properties.Resources.Exit;
                }
                else { HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false; }
                LlenarDatosDeBase();
                this.FACTURATextBox.Enabled = false;

                lblIngresoManual.Visible = false;

                this.pnlCargaPorFolio.Enabled = false;
                lblCargarInformacion.Visible = false;
                btnCargarInformacion.Visible = false;

            }
            else if (this.opc == "Agregar")
            {
                HabilitarEdicion(true); this.BTIniciaEdicion.Enabled = false;
                this.pnlCargaPorFolio.Enabled = true;
                lblIngresoManual.Visible = true;
                lblCargarInformacion.Visible = true;
                btnCargarInformacion.Visible = true;
            }
        }



        private void LINEAEdit_Reg_Load(object sender, EventArgs e)
        {
        }


        private bool LlenarDatosDeBase()
        {
            try
            {
                CFACTURAORIGINALCOMPRAD facturaOrigCompraD = new CFACTURAORIGINALCOMPRAD();
                CFACTURAORIGINALCOMPRABE facturaOrigCompraBE = new CFACTURAORIGINALCOMPRABE();

                facturaOrigCompraBE.IID = ID;
                facturaOrigCompraBE = facturaOrigCompraD.seleccionarFACTURAORIGINALCOMPRA(facturaOrigCompraBE, null);

                if (facturaOrigCompraBE == null)
                    return false;

                this.ID = facturaOrigCompraBE.IID;

                this.FACTURATextBox.Text = facturaOrigCompraBE.IFACTURA;

                this.ACTIVOTextBox.Checked = (facturaOrigCompraBE.IACTIVO == "S") ? true : false;
                this.PROVISIONADACheckBox.Checked = (facturaOrigCompraBE.IPROVISIONADA == "S") ? true : false;


                if (!(bool)facturaOrigCompraBE.isnull["IFECHAFACTURA"])
                {
                    try
                    {
                        this.FECHAFACTURATextBox.Value = facturaOrigCompraBE.IFECHAFACTURA;
                    }
                    catch
                    {
                    }
                }


                if (!(bool)facturaOrigCompraBE.isnull["IFECHARECEPCION"])
                {
                    try
                    {
                        this.FECHARECEPCIONTextBox.Value = facturaOrigCompraBE.IFECHARECEPCION;
                    }
                    catch
                    {
                    }
                }

                string strBuffer = "";

                if (!(bool)facturaOrigCompraBE.isnull["IPROVEEDORID"])
                {
                    this.PROVEEDORIDTextBox.DbValue = facturaOrigCompraBE.IPROVEEDORID.ToString();
                    this.PROVEEDORIDTextBox.MostrarErrores = false;
                    this.PROVEEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.PROVEEDORIDTextBox.MostrarErrores = true;
                    //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                }
                else
                {
                    this.PROVEEDORIDTextBox.Text = "";
                }

                if (!(bool)facturaOrigCompraBE.isnull["ISUMA"])
                    this.SUMATextBox.Text = facturaOrigCompraBE.ISUMA.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIVA"])
                    this.IVATextBox.Text = facturaOrigCompraBE.IIVA.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["ITOTAL"])
                    this.TOTALTextBox.Text = facturaOrigCompraBE.ITOTAL.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIEPS8"])
                    this.IEPS8TextBox.Text = facturaOrigCompraBE.IIEPS8.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIEPS25"])
                    this.IEPS25TextBox.Text = facturaOrigCompraBE.IIEPS25.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIEPS26"])
                    this.IEPS26TextBox.Text = facturaOrigCompraBE.IIEPS26.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIEPS26C"])
                    this.IEPS26CTextBox.Text = facturaOrigCompraBE.IIEPS26C.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIEPS30"])
                    this.IEPS30TextBox.Text = facturaOrigCompraBE.IIEPS30.ToString();

                if (!(bool)facturaOrigCompraBE.isnull["IIEPS53"])
                    this.IEPS53TextBox.Text = facturaOrigCompraBE.IIEPS53.ToString();


                if (!(bool)facturaOrigCompraBE.isnull["ISUCURSALID"])
                {
                    this.SUCURSALIDTextBox.DbValue = facturaOrigCompraBE.ISUCURSALID.ToString();
                    this.SUCURSALIDTextBox.MostrarErrores = false;
                    this.SUCURSALIDTextBox.MValidarEntrada(out strBuffer, 1);
                    this.SUCURSALIDTextBox.MostrarErrores = true;
                    //this.VENDEDORIDTextBox.SelectedDataValue = clienteBE.m_PersonaBE.IVENDEDORID;
                }
                else
                {
                    this.SUCURSALIDTextBox.Text = "";
                }


                if (!(bool)facturaOrigCompraBE.isnull["ICOMPRAFOLIO"])
                    this.TBFolio.Text = facturaOrigCompraBE.ICOMPRAFOLIO.ToString();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();

                return false;
            }
        }


        private CFACTURAORIGINALCOMPRABE ObtenerDatosCapturados()
        {
            CFACTURAORIGINALCOMPRABE FACTORIGCOMPRABE = new CFACTURAORIGINALCOMPRABE();
            FACTORIGCOMPRABE.IACTIVO= (this.ACTIVOTextBox.Checked) ? "S" : "N";
            FACTORIGCOMPRABE.IPROVISIONADA = (this.PROVISIONADACheckBox.Checked) ? "S" : "N";

            FACTORIGCOMPRABE.IFECHARECEPCION = this.FECHARECEPCIONTextBox.Value;
            FACTORIGCOMPRABE.IFECHAFACTURA = this.FECHAFACTURATextBox.Value;

            if (this.FACTURATextBox.Text != "")
            {
                FACTORIGCOMPRABE.IFACTURA = this.FACTURATextBox.Text.ToString();
            }


            if (this.PROVEEDORIDTextBox.Text != "")
            {
                FACTORIGCOMPRABE.IPROVEEDORID = Int64.Parse(this.PROVEEDORIDTextBox.DbValue.ToString());
            }



            if (this.SUMATextBox.Text != "")
            {
                FACTORIGCOMPRABE.ISUMA = decimal.Parse(this.SUMATextBox.Text.ToString());
            }


            if (this.IVATextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIVA = decimal.Parse(this.IVATextBox.Text.ToString());
            }


            if (this.TOTALTextBox.Text != "")
            {
                FACTORIGCOMPRABE.ITOTAL = decimal.Parse(this.TOTALTextBox.Text.ToString());
            }


            if (this.IEPS8TextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIEPS8 = decimal.Parse(this.IEPS8TextBox.Text.ToString());
            }


            if (this.IEPS25TextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIEPS25 = decimal.Parse(this.IEPS25TextBox.Text.ToString());
            }


            if (this.IEPS26TextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIEPS26 = decimal.Parse(this.IEPS26TextBox.Text.ToString());
            }


            if (this.IEPS26CTextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIEPS26C = decimal.Parse(this.IEPS26CTextBox.Text.ToString());
            }


            if (this.IEPS30TextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIEPS30 = decimal.Parse(this.IEPS30TextBox.Text.ToString());
            }


            if (this.IEPS53TextBox.Text != "")
            {
                FACTORIGCOMPRABE.IIEPS53 = decimal.Parse(this.IEPS53TextBox.Text.ToString());
            }


            if (this.SUCURSALIDTextBox.Text != "")
            {
                FACTORIGCOMPRABE.ISUCURSALID = Int64.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }

            if (this.TBFolio.Text != "")
            {
                FACTORIGCOMPRABE.ICOMPRAFOLIO = int.Parse(this.TBFolio.Text.ToString());
            }


            return FACTORIGCOMPRABE;

        }

        public void SaveChanges()
        {


            string ErroresValidacion = "";

            if (this.opc == "Borrar")
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarKeys);
            else
                Validar(ref ErroresValidacion, (int)CamposAValidar.ValidarTodos);

            this.LBError.Text = ErroresValidacion;
            if (ErroresValidacion == "")
            {

                try
                {
                    CFACTURAORIGINALCOMPRAD FACTORIGCOMPRAD = new CFACTURAORIGINALCOMPRAD();

                    if (opc == "Agregar")
                    {
                        CFACTURAORIGINALCOMPRABE FACTORIGCOMPRABE = new CFACTURAORIGINALCOMPRABE();
                        FACTORIGCOMPRABE = ObtenerDatosCapturados();

                        FACTORIGCOMPRABE.ICREADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        if (FACTORIGCOMPRABE.IIEPS25 + FACTORIGCOMPRABE.IIEPS26 + FACTORIGCOMPRABE.IIEPS26C +
                            FACTORIGCOMPRABE.IIEPS30 + FACTORIGCOMPRABE.IIEPS53 + FACTORIGCOMPRABE.IIEPS8 + FACTORIGCOMPRABE.ISUMA +
                            FACTORIGCOMPRABE.IIVA != FACTORIGCOMPRABE.ITOTAL)
                        {
                            MessageBox.Show("La suma de los impuestos y el subtotal no da el total");
                            return;
                        }


                        FACTORIGCOMPRAD.AgregarFACTURAORIGINALCOMPRAD(FACTORIGCOMPRABE, null);

                        if (FACTORIGCOMPRAD.IComentario == "" || FACTORIGCOMPRAD.IComentario == null)
                        {

                            MessageBox.Show("El registro se ha insertado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);
                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + FACTORIGCOMPRAD.IComentario.Replace("%", "\n"));



                    }
                    else if (opc == "Cambiar")
                    {


                        CFACTURAORIGINALCOMPRABE FACTORIGCOMPRABEAnt = new CFACTURAORIGINALCOMPRABE();

                        CFACTURAORIGINALCOMPRABE FACTORIGCOMPRABE = new CFACTURAORIGINALCOMPRABE();

                        FACTORIGCOMPRABE = ObtenerDatosCapturados();

                        FACTORIGCOMPRABE.IMODIFICADOPOR_USERID = CurrentUserID.CurrentUser.IID;

                        FACTORIGCOMPRABEAnt.IID = this.ID;

                        if(FACTORIGCOMPRABE.IIEPS25 + FACTORIGCOMPRABE.IIEPS26 + FACTORIGCOMPRABE.IIEPS26C +
                            FACTORIGCOMPRABE.IIEPS30 + FACTORIGCOMPRABE.IIEPS53 + FACTORIGCOMPRABE.IIEPS8  + FACTORIGCOMPRABE.ISUMA +
                            FACTORIGCOMPRABE.IIVA  != FACTORIGCOMPRABE.ITOTAL)
                        {
                            MessageBox.Show("La suma de los impuestos y el subtotal no da el total");
                            return;
                        }

                        FACTORIGCOMPRAD.CambiarFACTURAORIGINALCOMPRAD(FACTORIGCOMPRABE, FACTORIGCOMPRABEAnt, null);
                        if (FACTORIGCOMPRAD.IComentario == "" || FACTORIGCOMPRAD.IComentario == null)
                        {
                            MessageBox.Show("El registro se ha cambiado");
                            Limpiar(true);
                            this.opc = "";
                            this.HabilitarEdicion(false);


                            this.Close();

                        }
                        else
                            MessageBox.Show("ERRORES: " + FACTORIGCOMPRAD.IComentario.Replace("%", "\n"));


                    }
                    else if (opc == "Borrar")
                    {

                        if (MessageBox.Show("Estas seguro de que quieres eliminar el registro", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            CFACTURAORIGINALCOMPRABE FACTORIGCOMPRABEAnt = new CFACTURAORIGINALCOMPRABE();
                            FACTORIGCOMPRABEAnt.IID = this.ID;
                            FACTORIGCOMPRAD.BorrarFACTURAORIGINALCOMPRAD(FACTORIGCOMPRABEAnt, null);
                            if (FACTORIGCOMPRAD.IComentario == "" || FACTORIGCOMPRAD.IComentario == null)
                            {
                                MessageBox.Show("El registro se ha eliminado");
                                Limpiar(true);
                                this.opc = "";
                                this.HabilitarEdicion(false);

                            }
                            else
                                MessageBox.Show("ERRORES: " + FACTORIGCOMPRAD.IComentario.Replace("%", "\n"));
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error Asegurese de que metio los datos en el formato correcto " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(ErroresValidacion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void HabilitarEdicion(bool b)
        {

            HabilitarValidadores(false);
            panel1.Enabled = b;
            HabilitarValidadores(true);

        }

        private void LimpiarVariablesForm()
        {
            this.ID = -1;
        }

        private void Limpiar()
        {
            Limpiar(false);
        }

        private void Limpiar(bool bLimpiarKeys)
        {
           
            this.ACTIVOTextBox.Checked = false;

            this.FACTURATextBox.Text = "";







        }



        private void IDTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void SetMode()
        {
            if ( this.FACTURATextBox.Text != "" )
            {

                if (this.LlenarDatosDeBase())
                {
                    if (this.opc != "Agregar" && this.opc != "")
                    {
                        this.opc = "Cambiar";
                        HabilitarEdicion(true);
                        this.BTIniciaEdicion.Enabled = false;
                    }
                    else
                    {
                        this.BTIniciaEdicion.Enabled = true;
                    }

                }
                else
                {
                    this.opc = "Agregar";
                    Limpiar();
                    HabilitarEdicion(true);
                    //this.btEliminar.Enabled = false;
                    this.BTIniciaEdicion.Enabled = false;
                }
            }
            else
            {
                Limpiar();
                HabilitarEdicion(false);
                //this.btEliminar.Enabled = false;
                this.BTIniciaEdicion.Enabled = false;
            }
        }



        private void IDTextBox_Validated(object sender, EventArgs e)
        {
            SetMode();
        }


        public void Resetear() // new for generator
        {
            HabilitarValidadores(false); // new generator
            Limpiar(true);
            this.opc = "";
            //this.IDTextBox.Focus();
            this.FACTURATextBox.Focus();
            HabilitarValidadores(true);
            this.HabilitarEdicion(false);
        }

        public void HabilitarValidadores(bool bEnabled) // new for generator
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {
                    v.Enabled = bEnabled;
                }
                catch
                {
                }
            }
        }


        public void Validar(ref string ErroresValidacion, int iCamposAValidar)
        {
            CustomValidation.BaseValidator[] validors = new CustomValidation.BaseValidator[this.validadores.Count];
            this.validadores.CopyTo(validors, 0);
            foreach (CustomValidation.BaseValidator v in validors)
            {
                try
                {

                    if (iCamposAValidar == (int)CamposAValidar.ValidarKeys)
                    {
                        if (v.ControlToValidate.Name != "CLAVETextBox")
                            continue;
                    }
                    v.Validate();
                    if (!v.IsValid)
                    {
                        ErroresValidacion += v.ErrorMessage + "--";
                    }
                }
                catch
                {
                }
            }
        }

        private void CLAVETextBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.opc != "Agregar" && this.opc != "")
            {
                if (!LlenarDatosDeBase())
                {
                    e.Cancel = true;
                    MessageBox.Show("No existe una linea con esa clave");
                }
            }
        }

        private void BTIniciaEdicion_Click(object sender, EventArgs e)
        {
            this.opc = "Cambiar";
            HabilitarEdicion(true);
            this.BTIniciaEdicion.Enabled = false;
            this.button1.Visible = true;
            this.button1.Enabled = true;
            this.button1.Text = "Guardar";
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {
            SeleccionaProveedor();
        }

        private void SeleccionaProveedor()
        {
            iPos.Catalogos.WFProveedores look = new iPos.Catalogos.WFProveedores();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                string strBuffer = "";
                this.PROVEEDORIDTextBox.DbValue = ((long)dr["ID"]).ToString();
                this.PROVEEDORIDTextBox.MostrarErrores = false;
                this.PROVEEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PROVEEDORIDTextBox.MostrarErrores = true;

            }
        }

        private void btnCargarInformacion_Click(object sender, EventArgs e)
        {

            long sucursalDestinoId = 0;
            if (this.SUCURSALIDTextBox.Text != "")
            {
                sucursalDestinoId = Int32.Parse(this.SUCURSALIDTextBox.DbValue.ToString());
            }

            int folio = 0;
            if (TBFolio.Text.Length > 0)
            {
                try
                {
                    folio = int.Parse(TBFolio.Text);
                }
                catch
                {

                }
            }

            LlenarInformacionDeCompraFactura(folio, sucursalDestinoId);


            if (this.dSAbonos2.COMPRASFACTURA.Rows.Count > 0)
            {
                COMPRASFACTURARow fr = (COMPRASFACTURARow)this.dSAbonos2.COMPRASFACTURA.Rows[0];

                bool bFacturaExiste = false;
                if (!fr.IsFACTURANull())
                {

                    CFACTURAORIGINALCOMPRAD regD = new CFACTURAORIGINALCOMPRAD();
                    CFACTURAORIGINALCOMPRABE reg = new CFACTURAORIGINALCOMPRABE();
                    reg.IFACTURA = fr.FACTURA;

                    reg = regD.seleccionarFACTURAORIGINALCOMPRA_XFACT(reg, null);
                    bFacturaExiste = reg != null && reg.IID > 0;

                    

                    if (bFacturaExiste)
                        LlenarDatosPorFactura(reg);
                    else
                        LlenarDatosPorDataRow(fr);

                }




            }

        }

        private void LlenarDatosPorFactura(CFACTURAORIGINALCOMPRABE fr)
        {

            /*FACTURATextBox.Text = fr.IFACTURA;

            if (!(bool)fr.isnull["IFECHAFACTURA"])
                FECHAFACTURATextBox.Value = fr.IFECHAFACTURA;

            if (!(bool)fr.isnull["IFECHARECEPCION"])
                FECHARECEPCIONTextBox.Value = fr.IFECHARECEPCION;

            if (!(bool)fr.isnull["ISUMA"])
                SUMATextBox.Text = fr.ISUMA.ToString();

            if (!(bool)fr.isnull["IIVA"])
                IVATextBox.NumericValue = fr.IIVA.ToString();

            if (!(bool)fr.isnull["ITOTAL"])
                TOTALTextBox.Text = fr.ITOTAL.ToString();


            if (!(bool)fr.isnull["IIEPS8"])
                IEPS8TextBox.Text = fr.IIEPS8.ToString();

            if (!(bool)fr.isnull["IIEPS25"])
                IEPS25TextBox.Text = fr.IIEPS25.ToString();

            if (!(bool)fr.isnull["IIEPS26"])
                IEPS26TextBox.Text = fr.IIEPS26.ToString();

            if (!(bool)fr.isnull["IIEPS30"])
                IEPS30TextBox.Text = fr.IIEPS30.ToString();

            if (!(bool)fr.isnull["IIEPS53"])
                IEPS53TextBox.Text = fr.IIEPS53.ToString();


            string strBuffer = "";
            if (!!(bool)fr.isnull["IPROVEEDORID"])
            {
                this.PROVEEDORIDTextBox.DbValue = fr.IPROVEEDORID.ToString();
                this.PROVEEDORIDTextBox.MostrarErrores = false;
                this.PROVEEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PROVEEDORIDTextBox.MostrarErrores = true;
            }*/
            ReCargar("Cambiar", fr.IID);
            this.PROVISIONADACheckBox.Checked = true;
        }


        private void LlenarDatosPorDataRow(COMPRASFACTURARow fr)
        {

            FACTURATextBox.Text = fr.FACTURA;

            if (!fr.IsFECHAFACTURANull())
                FECHAFACTURATextBox.Value = fr.FECHAFACTURA;

            if (!fr.IsFECHANull())
                FECHARECEPCIONTextBox.Value = fr.FECHA;


            //FECHARECEPCIONTextBox.Value = DateTime.Today;

            if (!fr.IsSUBTOTALNull())
                SUMATextBox.Text = fr.SUBTOTAL.ToString();

            if (!fr.IsIVANull())
                IVATextBox.NumericValue = fr.IVA.ToString();

            if (!fr.IsTOTALNull())
                TOTALTextBox.Text = fr.TOTAL.ToString();


            if (!fr.IsIEPS8Null())
                IEPS8TextBox.Text = fr.IEPS8.ToString();

            if (!fr.IsIEPS25Null())
                IEPS25TextBox.Text = fr.IEPS25.ToString();

            if (!fr.IsIEPS26Null())
                IEPS26TextBox.Text = fr.IEPS26.ToString();

            if (!fr.IsIEPS30Null())
                IEPS30TextBox.Text = fr.IEPS30.ToString();

            if (!fr.IsIEPS53Null())
                IEPS53TextBox.Text = fr.IEPS53.ToString();


            string strBuffer = "";
            if (!fr.IsPERSONAIDNull())
            {
                this.PROVEEDORIDTextBox.DbValue = fr.PERSONAID.ToString();
                this.PROVEEDORIDTextBox.MostrarErrores = false;
                this.PROVEEDORIDTextBox.MValidarEntrada(out strBuffer, 1);
                this.PROVEEDORIDTextBox.MostrarErrores = true;
            }

            
        }

        private void LlenarInformacionDeCompraFactura(int folio, long sucursalId)
        {
            try
            {
                this.cOMPRASFACTURATableAdapter.Fill(this.dSAbonos2.COMPRASFACTURA,folio, (int)sucursalId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {

            WFLookUpCompraSucursales wfl = new WFLookUpCompraSucursales(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_COMPRA_SUC,0);
            wfl.ShowDialog();

            DataRow dr = wfl.m_rtnDataRow;

            wfl.Dispose();
            GC.SuppressFinalize(wfl);

            if (dr != null)
            {
                this.TBFolio.Text = dr[15].ToString();
                this.TBFolio.Focus();
            }
        }
    }
}
