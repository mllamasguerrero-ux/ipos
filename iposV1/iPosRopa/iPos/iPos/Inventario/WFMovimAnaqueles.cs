using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using System.Collections;

namespace iPos
{
    public partial class WFMovimAnaqueles : IposForm
    {
        public WFMovimAnaqueles()
        {
            InitializeComponent();
        }

        private void LlenarGrid()
        {
            if (!m_bFormShown)
                return;

            try
            {

                int almacenId = ALMACENComboBox.SelectedIndex >= 0 ? int.Parse(this.ALMACENComboBox.SelectedValue.ToString()) : 0;
                int anaquelId = CBAnaquel.SelectedIndex >= 0 ? int.Parse(CBAnaquel.SelectedValue.ToString()) : 0;

                if(anaquelId == 0 )
                {
                    this.dSLocationProducts.ANAQUELCONTENT.Clear();
                }
                else
                {

                    this.aNAQUELCONTENTTableAdapter.Fill(this.dSLocationProducts.ANAQUELCONTENT, int.Parse(this.CBAnaquel.SelectedValue.ToString()), almacenId);
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFMovimAnaqueles_Load(object sender, EventArgs e)
        {
            this.CBAnaquel.llenarDatos();
            this.CBAnaquel.SelectedIndex = -1;
            this.CBAnaquelDestino.llenarDatos();
            this.CBAnaquelDestino.SelectedIndex = -1;


            this.ALMACENComboBox.llenarDatos();
            this.ALMACENComboBox.SelectedIndex = -1;
            this.ALMACENComboBox.Visible = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");
            this.lblAlmacen.Visible = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");


            this.ALMACENNuevoComboBox.llenarDatos();
            this.ALMACENNuevoComboBox.SelectedIndex = -1;
            this.ALMACENNuevoComboBox.Visible = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");
            this.lblAlmacenNuevo.Visible = (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S");
        }

        private void CBAnaquel_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnSelectEliminarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
            {
                dr.Cells["DGELIMINAR"].Value = true;
                dr.Cells["DGMOVER"].Value = false;
            }
        }

        private void btnDeselectEliminarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
            {
                dr.Cells["DGELIMINAR"].Value = false;
            }
        }

        private void btnSelectMoverTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
            {
                dr.Cells["DGMOVER"].Value = true;
                dr.Cells["DGELIMINAR"].Value = false;
            }
        }

        private void btnDeselectMoverTodos_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
            {
                dr.Cells["DGMOVER"].Value = false;
            }
        }

        private void btnCopiarLocalidadAnt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
            {
                dr.Cells["DGLOCNUEVA"].Value = dr.Cells["DGLOCALIDAD"].Value;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArrayList erroresDeValidacion = validadMovimientos();
            if(erroresDeValidacion.Count == 0)
            {
                Process();
            }
            else
            {
                
                    string strResumen = "";
                    foreach(string strerror in erroresDeValidacion )
                    {
                        strResumen = strResumen + strerror + Environment.NewLine;
                    }
                    MessageBox.Show("Corriga primero los siguientes errores " + Environment.NewLine +  strResumen);
            }

            

            
        }



        private ArrayList validadMovimientos()
        {

            System.Collections.ArrayList errores = new ArrayList();
            foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
            {
                if (dr.Cells["DGMOVER"].Value != null && bool.Parse(dr.Cells["DGMOVER"].Value.ToString()))
                {

                    if (dr.Cells["DGLOCNUEVA"].Value == null || dr.Cells["DGLOCNUEVA"].Value.ToString().Trim().Length == 0)
                        errores.Add("Producto : " + dr.Cells["DGCLAVE"].Value.ToString() + " Error: Debe ingresar la localidad en el nuevo anaquel");
                }
            }

            return errores;
        }
        private void Process()
        {

            string P_VD_VENDEDOR = CurrentUserID.CurrentUser.INOMBRE;
            long? P_USERID = iPos.CurrentUserID.CurrentUser.IID;
            long? SUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;
            DateTime P_FECHAVENCE = DateTime.MinValue;


            System.Collections.ArrayList errores = new ArrayList();


            if (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S" && ALMACENNuevoComboBox.SelectedIndex < 0)
            {

                MessageBox.Show("Debe seleccionar el almacen");
                return;
            }


            try
            {

                foreach (DataGridViewRow dr in aNAQUELCONTENTDataGridView.Rows)
                {
                    CPRODUCTOLOCATIONSD prodLocD = new CPRODUCTOLOCATIONSD();

                    string claveProducto = dr.Cells["DGCLAVE"].Value.ToString();

                    if (dr.Cells["DGMOVER"].Value != null && bool.Parse(dr.Cells["DGMOVER"].Value.ToString()))
                    {

                        CPRODUCTOLOCATIONSBE prodLocBE = new CPRODUCTOLOCATIONSBE();
                        prodLocBE.IPRODUCTOID = long.Parse(dr.Cells["DGPRODUCTOID"].Value.ToString());
                        prodLocBE.ILOCALIDAD = dr.Cells["DGLOCNUEVA"].Value.ToString();
                        prodLocBE.IANAQUELID = long.Parse(this.CBAnaquelDestino.SelectedValue.ToString());
                        prodLocBE.IANAQUEL = this.CBAnaquelDestino.Text;


                        if (CurrentUserID.CurrentParameters.IMANEJAALMACEN == "S")
                        {
                            prodLocBE.IALMACENID = long.Parse(this.ALMACENNuevoComboBox.SelectedValue.ToString());
                        }


                        if (prodLocD.ExistePRODUCTOLOCATIONS(prodLocBE, null) == 1)
                        {
                            //MessageBox.Show("Locacion del producto ya ingresada");
                            //return;
                        }
                        else
                        {
                            if (!prodLocD.AgregarPRODUCTOLOCATIONSD(prodLocBE, null))
                            {

                                errores.Add("Producto : " + claveProducto + " Error:"  + prodLocD.IComentario);
                                
                            }


                        }
                    }


                    if ((dr.Cells["DGMOVER"].Value != null && bool.Parse(dr.Cells["DGMOVER"].Value.ToString())) || (dr.Cells["DGELIMINAR"].Value != null && bool.Parse(dr.Cells["DGELIMINAR"].Value.ToString())))
                    {
                        CPRODUCTOLOCATIONSBE prodLocBEOld = new CPRODUCTOLOCATIONSBE();


                        prodLocBEOld.IID = long.Parse(dr.Cells["DGID"].Value.ToString());

                        if (prodLocD.BorrarPRODUCTOLOCATIONSD(prodLocBEOld, null))
                        {

                        }
                        else
                        {
                            errores.Add("Producto : " + claveProducto + " Error: Ocurrio un error al intentar borrar " + prodLocD.IComentario);
                           
                        }
                    }
                }




                LlenarGrid();

                if(errores.Count > 0)
                {
                    string strResumen = "";
                    foreach(string strerror in errores )
                    {
                        strResumen = strResumen + strerror + Environment.NewLine;
                    }
                    MessageBox.Show("Hubo los siguientes errores " + Environment.NewLine +  strResumen);
                }
                else
                {
                    MessageBox.Show("Se realizaron las operaciones");
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }

        private void ALMACENComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }


        bool m_bFormShown = false;
        private void WFMovimAnaqueles_Shown(object sender, EventArgs e)
        {
            m_bFormShown = true;
        }



    }
}
