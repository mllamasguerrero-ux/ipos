using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvFiles;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using iPos.WebServices;

namespace iPos
{
    public partial class WFExportarDatosParaInventario : Form
    {


        private bool m_exportacionExitosa;
        private string m_iComentario;
        public WFExportarDatosParaInventario()
        {
            InitializeComponent();
        }

        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            int result = (int)this.folderBrowserDialog1.ShowDialog();
            if (result == (int)System.Windows.Forms.FolderBrowserResult.OK)
            {
                TBCarpetaArchivos.Text = this.folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            m_exportacionExitosa = false;
            m_iComentario = "";


            if (RBPorArchivos.Checked)
            {
                progressBar2.Style = ProgressBarStyle.Marquee;
            }
            else{
                WSConnectionInventarioApp wsAppInv = new WSConnectionInventarioApp();
                string numInvAbiertos = "";
                wsAppInv.inventariosAbiertos(ref numInvAbiertos);

                if (numInvAbiertos != "0")
                {
                    DialogResult dialogResult = MessageBox.Show("Sure", "Se detectaron inventarios capturados sin cerrar, desea seguir de todos modos?, recuerde que se borraran antes de exportar los datos", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                progressBar1.Style = ProgressBarStyle.Marquee;
            }
            
            backgroundWorker1.RunWorkerAsync();

           

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (RBPorArchivos.Checked)
            {

                if (TBCarpetaArchivos.Text == "" || TBPrefijo.Text == "")
                {
                    MessageBox.Show("Debe definir tanto la carpeta destino como el prefijo para los archivos");
                    return;
                }

                CINVENTARIOSYNCD syncD = new CINVENTARIOSYNCD();
                ArrayList errores = new ArrayList();
                if (!syncD.ExportDataInventario(TBCarpetaArchivos.Text, TBPrefijo.Text, ref errores))
                {
                    string strError = "Errores: \n";
                    foreach (string str in errores)
                    {
                        strError += str + "\n";
                    }
                    m_iComentario = strError;
                    m_exportacionExitosa = false;
                }
                else
                {
                    m_exportacionExitosa = true;
                }
            }
            else
            {
                WSConnectionInventarioApp wsAppInv = new WSConnectionInventarioApp();
                CINVENTARIOD invD = new CINVENTARIOD();
                List<CINVMOVALMACENSUCURSALBE> almacenes = new List<CINVMOVALMACENSUCURSALBE>();
                List<CINVMOVINVENTARIOSSUCURSALBE> inventarios = new List<CINVMOVINVENTARIOSSUCURSALBE>();
                List<CINVMOVPRODUCTOSUCURSALBE> productos = new List<CINVMOVPRODUCTOSUCURSALBE>();
                List<CSUCURSALINVBE> sucursales = new List<CSUCURSALINVBE>();
                List<CINVMOVPRODLOCATIONBE> locations = new List<CINVMOVPRODLOCATIONBE>();
                List<Usuario> usuarios = new List<Usuario>();
                Dictionary<string, object> datos = new Dictionary<string,object>();


                try
                {

                    almacenes = invD.getAlmacenInv(CurrentUserID.SUCURSAL_CLAVE ,null);
                    inventarios = invD.getInventario(CurrentUserID.SUCURSAL_CLAVE, null);
                    productos = invD.getProductsInv(CurrentUserID.SUCURSAL_CLAVE, null);
                    sucursales = invD.getSucursalesInv(null);
                    usuarios = invD.getUsuariosInv(CurrentUserID.SUCURSAL_CLAVE, null);
                    locations = invD.getProdLocation(CurrentUserID.SUCURSAL_CLAVE, null);

                    datos.Add("Almacenes", almacenes);
                    datos.Add("Inventarios", inventarios);
                    datos.Add("Productos", productos);
                    datos.Add("Sucursales", sucursales);
                    datos.Add("Usuarios", usuarios);
                    datos.Add("Locations", locations);

                    string resultSuccess = "";
                    wsAppInv.setInventarioWithBody(datos, ref resultSuccess);


                    if (resultSuccess == "1")
                    {
                        m_exportacionExitosa = true;
                    }
                    else
                    {
                        m_exportacionExitosa = false;
                    }

                }
                catch(Exception exc)
                {
                    m_exportacionExitosa = false;
                    MessageBox.Show("Error:" + exc);
                }

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (RBPorArchivos.Checked)
            {
                progressBar2.Style = ProgressBarStyle.Blocks;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
            }


            
            if (m_exportacionExitosa)
            {
                MessageBox.Show("Los archivos han sido exportados");
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }

        }

        private void RBPorArchivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
