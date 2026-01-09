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
    public partial class WFLogEventoTable : IposForm
    {
        long definedId;
        string m_table = "";
        CCLIENTEBE m_actualClient;
        CPROVEEDORBE m_actualProveedor;

        Boolean usuarioTienePermisoHistorialClientes = true;
        Boolean usuarioTienePermisoHistorialProveedores = true;
        Boolean usuarioTienePermisoHistorialProductos = true;


        long tipoEventoTablaId = DBValues._TIPOEVENTOTABLA_NOTA;

        public WFLogEventoTable()
        {
            InitializeComponent();

            m_actualClient = null;
            m_actualProveedor = null;
        }
        
        public WFLogEventoTable(string table, CCLIENTEBE actualClient):this(table)
        {
            m_actualClient = actualClient;
            this.definedId = actualClient.m_PersonaBE.IID;
            tipoEventoTablaId = DBValues._TIPOEVENTOTABLA_NOTA;
        }

        public WFLogEventoTable(string table, CPROVEEDORBE actualProveedor) : this(table)
        {
            m_actualProveedor = actualProveedor;
            this.definedId = actualProveedor.m_PersonaBE.IID;
            tipoEventoTablaId = DBValues._TIPOEVENTOTABLA_NOTAPROVEEDOR;
        }

        public WFLogEventoTable(string table):this()
        {
            m_table = table;
        }


        private void WFLogEventoTable_Load(object sender, EventArgs e)
        {
            dateTimePickerBegin.Value = DateTime.Now.AddYears(-10);
            dateTimePickerEnd.Value = DateTime.Now;

            pnlProveedor.Visible = false;
            pnlCliente.Visible = false;

            if (m_table == "Clientes")
            {
                cmbTableType.SelectedIndex = 0;
                pnlCliente.Visible= true;

                if (m_actualClient != null)
                {
                    this.txtLogCliente.Text = m_actualClient.m_PersonaBE.INOMBRE;
                    this.label6.Text = m_actualClient.m_PersonaBE.IDESCRIPCION;

                    string strBuffer = "";
                    this.txtLogCliente.DbValue = m_actualClient.m_PersonaBE.IID.ToString();
                    this.txtLogCliente.MostrarErrores = false;
                    this.txtLogCliente.MValidarEntrada(out strBuffer, 1);
                    this.txtLogCliente.MostrarErrores = true;
                }
                if (this.txtLogCliente.Text != null )
                {
                    LlenarGrid();
                }
            }
            else if (m_table == "Proveedores")
            {
                cmbTableType.SelectedIndex = 1;
                pnlProveedor.Visible = true;

                if (m_actualProveedor != null)
                {
                    this.txtLogProveedor.Text = m_actualProveedor.m_PersonaBE.INOMBRE;
                    this.LogProveedorLabel.Text = m_actualProveedor.m_PersonaBE.IDESCRIPCION;

                    string strBuffer = "";
                    this.txtLogProveedor.DbValue = m_actualProveedor.m_PersonaBE.IID.ToString();
                    this.txtLogProveedor.MostrarErrores = false;
                    this.txtLogProveedor.MValidarEntrada(out strBuffer, 1);
                    this.txtLogProveedor.MostrarErrores = true;
                }
                if (this.txtLogProveedor.Text != null)
                {
                    LlenarGrid();
                }
            }



        }


        private void LlenarGrid()
        {
            try
            {
                string strTabla  = cmbTableType.SelectedItem.ToString();
                int iRegistroId = 0;
                int iUsuarioId = 0;

                if (strTabla == null)
                {
                    return;
                }



                if ( strTabla == "Clientes" && txtLogCliente.Text.Trim().Length > 0)
                {

                    try
                    {
                        iRegistroId = int.Parse(txtLogCliente.DbValue.ToString());
                    }
                    catch (Exception ex)
                    {

                        return;
                    }
                }


                if (strTabla == "Proveedores" && txtLogProveedor.Text.Trim().Length > 0)
                {

                    try
                    {
                        iRegistroId = int.Parse(txtLogProveedor.DbValue.ToString());
                    }
                    catch (Exception ex)
                    {

                        return;
                    }
                }


                if (txtLogUser.Text.Trim().Length > 0)
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



                lOGEVENTOTABLATableAdapter.Fill(this.dSCatalogos.LOGEVENTOTABLA, strTabla, iRegistroId, this.dateTimePickerBegin.Value.Date, this.dateTimePickerEnd.Value.Date.AddDays(1), iUsuarioId, (int)tipoEventoTablaId);
                
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
        
        private void cmbTableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbTableType.SelectedIndex )
            {
                case 0:
                    pnlCliente.Visible = false;
                    break;
                default:
                    pnlCliente.Visible = false;
                    break;
            }
        }

      
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
