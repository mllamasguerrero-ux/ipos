using DataLayer;
using FastReport;
using iPos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iPosReporting.ReportesWebExis
{
    public partial class WFReporteTotalesWebExis : Form
    {
        Report report1 = new Report();

        public WFReporteTotalesWebExis()
        {
            InitializeComponent();
        }

        private void BTWebExisPath_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "dbf (*.dbf)|*.dbf|Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBDBFPath.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {

            if(TBDBFPath.Text == null || TBDBFPath.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un archivo dbf");
                return;
            }

            // TODO: This line of code loads data into the 'dSWebExis.EXISTENCIAWEBEXIS' table. You can move, or remove it, as needed.
            this.eXISTENCIAWEBEXISTableAdapter.Fill(this.dSWebExis.EXISTENCIAWEBEXIS);
            this.ActualizarCantidadesConWebExis();

            report1.Load(FastReportsConfig.getPathForFile("WebExisTotales.frx", FastReportsTipoFile.desistema));
            report1.Preview = this.previewControl1;
            report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;



            report1.RegisterData(this.dSWebExis.Tables["EXISTENCIAWEBEXIS"], "Table");
            report1.GetDataSource("Table").Enabled = true;;
            


            if (report1.Prepare())
                report1.ShowPrepared();
            
        }

        private void WFReporteTotalesWebExis_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        public void ActualizarCantidadesConWebExis()
        {
            var path = Path.GetDirectoryName(TBDBFPath.Text);
            var fileName = Path.GetFileName(TBDBFPath.Text);
            var sCadenaConexion = "Provider=VFPOLEDB.1;Data Source=\"" + path + "\";User ID=admin";

            OleDbConnection con = new OleDbConnection(sCadenaConexion);
            
            try
            {

                

                System.Collections.ArrayList parts = new ArrayList();
                OleDbParameter auxPar;
                

                String CmdTxt = "select PRODUCTO, SUM(CANTIDAD) CANTIDAD FROM " + fileName + " GROUP BY PRODUCTO";
                
                

                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                OleDbDataReader dr;
                con.Open();
                dr = OleDbHelper.ExecuteReader(con, CommandType.Text, CmdTxt, arParms);

                while (dr.Read())
                {
                    string producto = "";
                    decimal cantidad = 0m;
                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {
                        producto = (string)(dr["PRODUCTO"]);
                    }
                    
                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        cantidad = (decimal)(dr["CANTIDAD"]);
                    }
                    
                    if(!string.IsNullOrEmpty(producto))
                    {
                        foreach (DataRow row in this.dSWebExis.Tables["EXISTENCIAWEBEXIS"].Select("CLAVE = '" + producto + "'"))
                        {
                            row["EXISTENCIA"] = cantidad;
                        }

                    }

                }

                this.dSWebExis.Tables["EXISTENCIAWEBEXIS"].AcceptChanges();
                dr.Close();
                
                //return retorno;
            }
            catch (Exception e)
            {
                //return retorno;
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
            

        }

    }
}
