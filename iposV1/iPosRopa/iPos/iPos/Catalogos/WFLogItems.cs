using iPosBusinessEntity;
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

namespace iPos
{
    public partial class WFLogItems : IposForm
    {
        bool isClient;
        bool isInicialized;
        bool isDefined;
        long definedId;

        Boolean usuarioTienePermisoHistorialClientes = true;
        Boolean usuarioTienePermisoHistorialProductos = true;
        public WFLogItems()
        {
            InitializeComponent();
        }

        public WFLogItems(string tableType, CPRODUCTOBE actualProduct)
        {
            InitializeComponent();
            if(tableType == "Producto")
            {
                isDefined = true;
                isInicialized = true;
                isClient = false;
                cmbTableType.SelectedIndex = 0;
                this.definedId = actualProduct.IID;
                this.txtLogElement.Text = actualProduct.ICLAVE;
                this.lblLogElementDetail.Text = actualProduct.IDESCRIPCION1;
            }
        }

        public WFLogItems(string tableType, CCLIENTEBE actualClient)
        {
            InitializeComponent();
            if(tableType == "Cliente")
            {
                isDefined = true;
                isInicialized = true;
                isClient = true;
                cmbTableType.SelectedIndex = 1;
                this.definedId = actualClient.m_PersonaBE.IID;
                this.txtLogCliente.Text = actualClient.m_PersonaBE.INOMBRE;
                this.label6.Text = actualClient.m_PersonaBE.IDESCRIPCION;
            }
        }

        public WFLogItems(string tableType)
        {
            InitializeComponent();
            if (tableType == "Cliente")
            {
                isDefined = false;
                isInicialized = false;
                isClient = true;
                cmbTableType.SelectedIndex = 1;
            }
            else if (tableType == "Producto")
            {
                isDefined = false;
                isInicialized = false;
                isClient = false;
                cmbTableType.SelectedIndex = 0;
            }
        }


        private void WFLogItems_Load(object sender, EventArgs e)
        {
            dateTimePickerBegin.Value = DateTime.Now.AddDays(-30);
            dateTimePickerEnd.Value = DateTime.Now;

            if(isDefined == true && isInicialized == true)
            {
                LlenarGrid();
                isInicialized = false;
            }
            
                CUSUARIOSD usuariosD = new CUSUARIOSD();
                usuarioTienePermisoHistorialClientes = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_BITACORA_CLIENTES, null);
                usuarioTienePermisoHistorialProductos = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_BITACORA_PRODUCTO, null);
                
            
        }


        private void LlenarGrid()
        {
            try
            {
                int iTablaId = 1;
                int iRegistroId = 0;
                int iUsuarioId = 0;
                switch(cmbTableType.SelectedIndex)
                {
                    case 0 : iTablaId = 1; break;
                    case 1 : iTablaId = 2; break;
                    default : break;
                }

                if (iTablaId == 1 && isDefined == false)
                {

                    if(!usuarioTienePermisoHistorialProductos)
                    {

                        MessageBox.Show("No tiene permisos para consultar el historial de cambios de productos");
                        return;
                    }

                    try
                    {
                        iRegistroId = int.Parse(this.txtLogElement.DbValue.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un registro valido");
                        return;
                    }
                }
                else if (iTablaId == 2 && isDefined == false)
                {

                    if (!usuarioTienePermisoHistorialClientes)
                    {

                        MessageBox.Show("No tiene permisos para consultar el historial de cambios de clientes");
                        return;
                    }
                    try
                    {
                        iRegistroId = int.Parse(this.txtLogCliente.DbValue.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un registro valido");
                        return;
                    }
                }
                else if (isDefined == true)
                {
                    try
                    {
                        iRegistroId = int.Parse(definedId.ToString());

                    }
                    catch
                    {
                        MessageBox.Show("Seleccione un registro valido");
                        return;
                    }
                }


                if(txtLogUser.Text.Trim().Length > 0)
                {

                    try
                    {
                        iUsuarioId = int.Parse(txtLogUser.DbValue.ToString());
                    }
                    catch (Exception ex)
                    {

                        return;
                    }
                }



                this.lOGTableAdapter.Fill(this.dSCatalogos.LOG,iTablaId,iRegistroId, this.dateTimePickerBegin.Value.Date, this.dateTimePickerEnd.Value.Date.AddDays(1), iUsuarioId);
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnSearchLog_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void ITEMButton_Click(object sender, EventArgs e)
        {

            LOOKPROD look;
            look = new LOOKPROD("", false, TipoProductoNivel.tp_hijos);
            //look.m_showEmptyIfNoFilter = false;
            look.ShowDialog();


            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.txtLogElement.Text = dr["CLAVE"].ToString().Trim();
                txtLogElement.Focus();
                txtLogElement.Select(txtLogElement.Text.Length, 0);
            }
        }

        private void cmbTableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbTableType.SelectedIndex )
            {
                case 0:
                    pnlCliente.Visible = false;
                    pnlProducto.Visible = true;
                    break;
                case 1:
                    pnlCliente.Visible = true;
                    pnlProducto.Visible = false; 
                    break;
                default:
                    pnlCliente.Visible = false;
                    pnlProducto.Visible = true; 
                    break;
            }
        }

        private void lOGDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = lOGDataGridView.CurrentRow;
            WFLogDetail wfLogDetail = new WFLogDetail(txtLogElement.Text, row);
            wfLogDetail.ShowDialog();
            wfLogDetail.Dispose();
            GC.SuppressFinalize(wfLogDetail);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
