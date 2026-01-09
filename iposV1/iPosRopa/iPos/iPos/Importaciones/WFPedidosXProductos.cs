using DataLayer.Importaciones;
using FirebirdSql.Data.FirebirdClient;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPos.Importaciones
{
    public partial class WFPedidosXProductos : Form
    {
        public string sucursal = "";
        public WFPedidosXProductos()
        {
            InitializeComponent();
        }


        private void WFPedidosXProductos_Load(object sender, EventArgs e)
        {
            comboTipoReporte.SelectedIndex = 0;

            SucursalComboBox.llenarDatos();
            SucursalComboBox.SelectedIndex = 0;
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            string tipo = "";
            string fileName = "";
            string path = "";
            Dictionary<string, decimal> datosDBF = new Dictionary<string, decimal>();

            switch (comboTipoReporte.SelectedIndex)
            {
                case 0: tipo = "0"; break;
                case 1: tipo = "1"; break;
            }

            sucursal = this.SucursalComboBox.SelectedValue.ToString();

            this.eXISTENCIAPEDIDOTableAdapter.Fill(this.dSImportaciones.EXISTENCIAPEDIDO, tipo);

            path = Path.GetDirectoryName(CurrentUserID.CurrentParameters.IRUTADBFEXISTENCIASUC);
            fileName = Path.GetFileNameWithoutExtension(CurrentUserID.CurrentParameters.IRUTADBFEXISTENCIASUC);

            ImportarDBF import = new ImportarDBF();
            datosDBF = import.ImportarExistenciaProductosXSucursal(fileName, path, sucursal);

            try
            {
                foreach (DataGridViewRow dataRow in this.eXISTENCIAPEDIDODataGridView.Rows)
                {
                    foreach (KeyValuePair<string, decimal> item in datosDBF)
                    {
                        if (dataRow.Cells["DGCLAVE"].Value.Equals(item.Key))
                        {
                            dataRow.Cells["EXISTENCIASUCURSAL"].Value = item.Value;
                        }
                    }
                }
            }
            catch { }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            bool exito = false;
            ImportarDBF import = new ImportarDBF();
            CIMPORTAR_DBF_LINE_SPBE importDbf = new CIMPORTAR_DBF_LINE_SPBE();
            long doctoIDAnterior = 0;
            string refDate = DateTime.Now.ToString("ddMMyyHHmm");
            CSUCURSALBE auxSuc = new CSUCURSALBE();
            CSUCURSALD daoSuc = new CSUCURSALD();
            auxSuc.ICLAVE = sucursal;
            auxSuc = daoSuc.seleccionarSUCURSALPorClave(auxSuc, null);
            long sucursalTid = auxSuc.IID;
            string referencia = "MNL " + refDate;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();
                foreach (DataGridViewRow dataRow in this.eXISTENCIAPEDIDODataGridView.Rows)
                {
                    importDbf = new CIMPORTAR_DBF_LINE_SPBE();

                    if (doctoIDAnterior != 0)
                        importDbf.IDOCTOACTUALID = doctoIDAnterior;

                    importDbf.IPRODUCTO = dataRow.Cells["DGCLAVE"].Value.ToString();

                    importDbf.IDESCRIPCION = dataRow.Cells["DGDESC"].Value.ToString();

                    try
                    {
                        object value = dataRow.Cells["CANTIDADPEDIDO"].Value;
                        if (value != null)
                        {
                            if (decimal.Parse(dataRow.Cells["CANTIDADPEDIDO"].Value.ToString()) > 0)
                            {
                                importDbf.ICANTIDAD = decimal.Parse(dataRow.Cells["CANTIDADPEDIDO"].Value.ToString());
                            }
                            else
                            {
                                continue;
                            }

                        }
                        else
                        {
                            //importDbf.ICANTIDAD = 0;
                            continue;
                        }

                    }
                    catch(Exception error)
                    {
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("Error, una de las cantidades a tomar es incorrecta: " + error.Message + error.StackTrace);
                        return;
                    }

                    importDbf.IREFERENCIA = referencia;

                    importDbf.IREFERENCIAS = referencia;

                    importDbf.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA;
                    importDbf.IALMACENTID = DBValues._DOCTO_ALMACEN_DEFAULT;

                    importDbf.IUSERID = CurrentUserID.CurrentUser.IID;
                    importDbf.ISUCURSALID = CurrentUserID.CurrentParameters.ISUCURSALID;

                    importDbf.ISUCURSALTID = sucursalTid;


                    if (import.IMPORTAR_DBF_LINE_PEDIDOSUCURSAL(importDbf, fTrans, ref doctoIDAnterior) == false)
                    {
                        //this.IComentario = impRecD.IComentario;
                        fTrans.Rollback();
                        fConn.Close();
                        MessageBox.Show("No se puieron cargar los pedidos");
                        return;
                    }

                }
                     fTrans.Commit();
                     exito = true;
            }
            catch (Exception ex)
            {
                 fTrans.Rollback();
                 fConn.Close();
                 MessageBox.Show("Error, algo salio mal: "+ex.Message + ex.StackTrace);
                 exito = false;
                 return;
            }
            finally
            {
                  fConn.Close();
            }

            if(exito)
            {
                MessageBox.Show("Pedidos convertidos con exito!");
                WFProcesarPedidoSucursalDet pedidosSucDet = new WFProcesarPedidoSucursalDet(doctoIDAnterior, DBValues._DOCTO_TIPO_PEDIDO_TRASPASO_SALIDA
                        , sucursal, referencia);
                this.dSImportaciones.EXISTENCIAPEDIDO.Clear();
                pedidosSucDet.ShowDialog();
                pedidosSucDet.Dispose();
                GC.SuppressFinalize(pedidosSucDet);
            }
        }
    }
}
