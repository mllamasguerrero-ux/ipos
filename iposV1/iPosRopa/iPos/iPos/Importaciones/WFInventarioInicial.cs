using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Importaciones;
using iPosData;
using iPosBusinessEntity;
using System.IO;

namespace iPos
{
    public partial class WFInventarioInicial : IposForm
    {
        public WFInventarioInicial()
        {
            InitializeComponent();
        }

        private void BTInvInicial_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "dbf files (*.dbf)|*.dbf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBInvInicial.Text = openFileDialog1.FileName;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {
            ImportarDBF impD = new ImportarDBF();
            string fileName = Path.GetFileName(this.TBInvInicial.Text);
            string path = Path.GetDirectoryName(this.TBInvInicial.Text);
            if (!impD.ImportarInventarioIncial(fileName,path))
            {
                MessageBox.Show(impD.IComentario);
            }
            else
            {
                HiloExistencias._IFLAGENVIARINVENTARIO++;
                MessageBox.Show("Inventario Inicial Cargado....." + impD.IComentario);
            }

        }
    }
}
