using DataLayer.Utilerias;
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

namespace iPos.Utilerias.Ajustes_catálogos_SAT
{
    public partial class WFEditarClaveProductoSat : Form
    {
        private ExcelHelper excelHelper;
        public WFEditarClaveProductoSat()
        {
            InitializeComponent();
        }

        private void exportarButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    CPRODUCTOD productoDAO = new CPRODUCTOD();
                    List<Dictionary<string, string>> registros = productoDAO.SeleccionarProductosParaEdicionSAT(null);

                    if (registros != null)
                    {
                        excelHelper = new ExcelHelper
                        {
                            RutaArchivo = saveFileDialog1.FileName
                        };

                        if (File.Exists(saveFileDialog1.FileName))
                            File.Delete(saveFileDialog1.FileName);

                        if (excelHelper.ExportarDatos(registros))
                        {
                            MessageBox.Show("Se han exportado los datos con éxito en la dirección que seleccionó"); 
                        }
                        else
                        {
                            throw new Exception(
                            "Ocurrió un error al exportar los datos a Excel: " +
                            excelHelper.Comentario
                            );
                        }
                    }
                    else
                    {
                        throw new Exception(
                            "Ocurrió un error al obtener los registros de la base de datos: " +
                            productoDAO.IComentario
                            );
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void importarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    excelHelper = new ExcelHelper
                    {
                        RutaArchivo = openFileDialog1.FileName
                    };
                    DataSet excelDataSet = excelHelper.ImportarDatos();

                    if (excelDataSet == null)
                        throw new Exception(
                            "Problema al importar datos de excel: " +
                            excelHelper.Comentario);
                    CPRODUCTOD productoDAO = new CPRODUCTOD();

                    if(productoDAO.ActualizarClaveSAT(excelDataSet))
                    {
                        File.Delete(openFileDialog1.FileName);
                        MessageBox.Show("Se importaron las nuevas claves con éxito");
                    }
                    else
                    {
                        throw new Exception(
                            "Problema al actualizar las claves en la BD: " +
                            productoDAO.IComentario);
                  
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
