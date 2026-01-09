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
using iPos.Tools;
using System.IO;



namespace iPos.Catalogos
{
    public partial class WFRespaldosSucursales : Form
    {
        public WFRespaldosSucursales()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (SUCURSALTextBox.Text.Trim().Length == 0)
                return;

            CSUCURSALD sucD = new CSUCURSALD();
            CSUCURSALBE sucBE = new CSUCURSALBE();
            sucBE.IID = Int32.Parse(this.SUCURSALTextBox.DbValue.ToString());
            sucBE = sucD.seleccionarSUCURSAL(sucBE, null);

            if(sucBE == null)
            {
                MessageBox.Show("No se encontro el registro");
                return;
            }

            if (sucBE.IESMATRIZ != null && sucBE.IESMATRIZ.Equals("S"))
                return;

            if(sucBE.IACTIVO == "S")
            {
               string[] files = Directory.GetFiles(sucBE.IRUTARESPALDOORIGEN);

                foreach (string fileName in files)
                {
                    try
                    {
                        if (fileName.ToLower().EndsWith(".zip"))
                        {
                            ZipUtil.UnZipFiles(fileName, sucBE.IRUTARESPALDODESTINO, null, false);

                        }
                        MessageBox.Show("Archivo " + fileName +  "descomprimido, base de datos guardada en la ruta de destino!");
                        
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("El siguiente archivo no se pudo descomprimir: " + fileName);
                        continue;

                    }

                }
                
            }
        }

        private void btnUnZipAll_Click(object sender, EventArgs e)
        {
            string strRespaldos = "";
            string strRespaldosFails = "";
            foreach(DataRow dr in this.dSCatalogos.SUCURSAL.Rows)
            {

                if(dr == null)
                {
                    MessageBox.Show("No se encontro el registro");
                    continue;
                }

                if (dr != null && dr["ESMATRIZ"].Equals("S"))
                    continue;



                if (dr["ACTIVO"].ToString() == "S")
                {
                    //string strAuxR = dr["RUTARESPALDOORIGEN"].ToString();
                    
                    if (dr["RUTARESPALDOORIGEN"].ToString() != null && dr["RUTARESPALDOORIGEN"].ToString() != "")
                    {
                        string strAux = dr["RUTARESPALDOORIGEN"].ToString();
                        string[] files = Directory.GetFiles(dr["RUTARESPALDOORIGEN"].ToString());

                        foreach (string fileName in files)
                        {
                            try
                            {
                                if (fileName.ToLower().EndsWith(".zip"))
                                {
                                    ZipUtil.UnZipFiles(fileName, dr["RUTARESPALDODESTINO"].ToString(), null, false);

                                }
                                //MessageBox.Show("Archivo " + fileName + "descomprimido, base de datos guardada en la ruta de destino!");
                                strRespaldos += fileName + "\n";
                            }
                            catch (Exception exc)
                            {
                                strRespaldosFails += fileName + "\n";
                                continue;

                            }

                        }
                        
                    }
                }
            }
            MessageBox.Show("Los siguientes archivos han sido descomprimidos: \n" + strRespaldos + "\n" + "Los siguientes archivos no se pudieron descomprimir: \n" + strRespaldosFails);
        }

        private void WFRespaldosSucursales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCatalogos.SUCURSAL' table. You can move, or remove it, as needed.
            this.sUCURSALTableAdapter.Fill(this.dSCatalogos.SUCURSAL);

        }





    }
}
