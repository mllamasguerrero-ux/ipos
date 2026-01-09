using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using iPos.Tools;
using System.IO;
using FastReport;

namespace iPos
{
    public partial class WFExistenciaSucursalProveedor : Form
    {
        public WFExistenciaSucursalProveedor()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucBE = new CSUCURSALBE();


            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();

            
            DataLayer.Importaciones.ImportarDBF imp = new DataLayer.Importaciones.ImportarDBF();


            string personaClave = null;
            string sucursalClave = null;
            
            string personaNombre = "Todos";
            string sucursalNombre = "Todos";

            string path = "";
            string fileName = "";

            RecargarReport();


            if (!CBTodosSucursales.Checked)
            {

                if (this.SUCURSALTextBox.Text != "")
                {
                    try
                    {

                        sucBE.IID = Int32.Parse(this.SUCURSALTextBox.DbValue.ToString());
                        sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

                        if (sucBE == null)
                        {
                            MessageBox.Show("Debe seleccionar una sucursal o checar la opcion de todas las sucursales");
                            return;
                        }
                        sucursalClave = sucBE.ICLAVE;
                        sucursalNombre = sucBE.INOMBRE;
                    }
                    catch(Exception ex)
                    {

                    }

                }
            }


            if (!CBTodosProveedores.Checked)
            {


                if (this.PROVEEDOR1IDTextBox.Text != "")
                {
                    try
                    {
                        personaBE.IID = Int32.Parse(this.PROVEEDOR1IDTextBox.DbValue.ToString());
                        personaBE = personaD.seleccionarPERSONA(personaBE, null);


                        if (personaBE == null)
                        {
                            MessageBox.Show("Debe seleccionar un proveedor o checar la opcion de todos los proveedores");
                            return;
                        }
                        personaClave = personaBE.ICLAVE;
                        personaNombre = personaBE.INOMBRE;
                    }
                    catch(Exception ex)
                    {
                    }
                }
            }


            
            path = Path.GetDirectoryName(CurrentUserID.CurrentParameters.IRUTADBFEXISTENCIASUC);
            fileName = Path.GetFileNameWithoutExtension(CurrentUserID.CurrentParameters.IRUTADBFEXISTENCIASUC);

            List< CEXIST_SUCURSALBE> datos = imp.ExistenciaXProveedor(fileName, path, sucursalClave, personaClave, CBSoloConExistencia.Checked);

            this.pROVEEDORTableAdapter.Fill(this.dSImportaciones2.PROVEEDOR); 
            this.pRODUCTOTableAdapter.Fill(this.dSImportaciones2.PRODUCTO);
            this.sUCURSALTableAdapter.Fill(this.dSImportaciones2.SUCURSAL);

            //ordenar por sucursal
            //datos.Sort((x, y) => x.ISUCURSALCLAVE.CompareTo(y.ISUCURSALCLAVE));

            dSImportaciones2.EXISTENCIAPROVESUC.Clear();
            foreach(CEXIST_SUCURSALBE item in datos)
            {
                iPos.Importaciones.DSImportaciones2.EXISTENCIAPROVESUCRow row = dSImportaciones2.EXISTENCIAPROVESUC.NewEXISTENCIAPROVESUCRow();
                row.CANTIDAD = item.ICANTIDAD;
                row.PROVEEDORCLAVE = item.IPROVEE.Trim();
                row.SUCURSALCLAVE = item.ISUCURSALCLAVE;
                row.PRODUCTOCLAVE = item.IPRODUCTOCLAVE;
                
                row.FECHA = item.IFECHA;

                dSImportaciones2.EXISTENCIAPROVESUC.AddEXISTENCIAPROVESUCRow(row);
                
            }


            //DataRow arrRow;
            DataRow[] arrRows;
            foreach (iPos.Importaciones.DSImportaciones2.EXISTENCIAPROVESUCRow row in dSImportaciones2.EXISTENCIAPROVESUC.Rows)
            {
                    arrRows = row.GetParentRows("PROVEEDOR_EXISTENCIAPROVESUC");
                    if (arrRows != null && arrRows.Count() > 0)
                    {
                        row.PROVEEDORNOMBRE = arrRows[0]["NOMBRE"].ToString();
                    }


                    arrRows = row.GetParentRows("PRODUCTO_EXISTENCIAPROVESUC");
                    if (arrRows != null && arrRows.Count() > 0)
                    {
                        row.PRODUCTONOMBRE = arrRows[0]["NOMBRE"].ToString();
                        row.PRODUCTODESCRIPCION = arrRows[0]["DESCRIPCION1"].ToString();
                    }

                    arrRows = row.GetParentRows("SUCURSAL_EXISTENCIAPROVESUC");
                    if (arrRows != null && arrRows.Count() > 0)
                    {
                        row.SUCURSALNOMBRE = arrRows[0]["NOMBRE"].ToString();
                    }

            }



            //report1.GetDataSource("TABLA1Old").Delete();
            report1.GetDataSource("TABLA1").Name = "TABLA1Old";

            report1.RegisterData(dSImportaciones2.Tables["EXISTENCIAPROVESUC"], "TABLA1");
            report1.GetDataSource("TABLA1").Enabled = true;
            ((DataBand)report1.FindObject("Data1")).DataSource = report1.GetDataSource("TABLA1");

            report1.SetParameterValue("ProveedorNombre", personaNombre);
            report1.SetParameterValue("SucursalNombre", sucursalNombre);


            if (report1.Prepare())
                report1.ShowPrepared();

        }


        private void RecargarReport()
        {

            report1.Load(FastReportsConfig.getPathForFile("EXISTENCIAPROVESUC.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
            report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
            report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
        }

        private void WFExistenciaSucursalProveedor_Load(object sender, EventArgs e)
        {
            RecargarReport();
        }
    }
}
