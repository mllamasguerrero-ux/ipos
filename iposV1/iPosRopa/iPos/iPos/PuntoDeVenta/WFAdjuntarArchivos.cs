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
using System.Windows.Forms;

namespace iPos.PuntoDeVenta
{
    public partial class WFAdjuntarArchivos : Form
    {
        private List<string> adjuntedFiles;
        private DateTime fecha = DateTime.Today;
        private long doctoid;
        private int i = -1;
        public WFAdjuntarArchivos(ref List<string> adjuntedFiles, long doctoid, bool esPago, bool esCerrada, int horasL, DateTime fechaL)
        {
            InitializeComponent();
            this.adjuntedFiles = adjuntedFiles;
            fecha = DateTime.Today;
            this.doctoid = doctoid;
            if(esPago)
            {
                btnAdjuntarArchivos.Visible = true;
                txtHorasTrabajo.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            if(esCerrada)
            {
                txtHorasTrabajo.Text = horasL.ToString();
                dateTimePicker1.Value = fechaL;
                button1.Enabled = false;
            }
        }

        private void WFAdjuntarArchivos_Load(object sender, EventArgs e)
        {
            if(adjuntedFiles.Count > 0 )
            {
                foreach(string s in adjuntedFiles)
                {
                    i++;
                    lvArchivosAdjuntos.Items.Add(s);
                    lvArchivosAdjuntos.SetItemChecked(i, true);
                }
            }
        }

        private string getMonthName(string m)
        {
            switch(int.Parse(m))
            {
                case 1: { return "Enero"; }
                case 2: { return "Febrero"; }
                case 3: { return "Marzo"; }
                case 4: { return "Abril"; }
                case 5: { return "Mayo"; }
                case 6: { return "Junio"; }
                case 7: { return "Julio"; }
                case 8: { return "Agosto"; }
                case 9: { return "Septiembre"; }
                case 10: { return "Octubre"; }
                case 11: { return "Noviembre"; }
                case 12: { return "Diciembre"; }
                default: return "";
            }
        }

        private void btnAdjuntarArchivos_Click(object sender, EventArgs e)
        {

            if(txtHorasTrabajo.Text == null || txtHorasTrabajo.Text == "")
            {
                MessageBox.Show("Las horas de trabajo son un campo obligatorio!");
                txtHorasTrabajo.Focus();
                return;
            }

            try
            {
                fecha = this.dateTimePicker1.Value;
                string adjuntedFilesPath = CurrentUserID.CurrentParameters.IRUTAARCHIVOSADJUNTOS + @"\" + fecha.Year.ToString() + @"\" + getMonthName(fecha.Month.ToString()) + @"\" + fecha.Day.ToString() + @"\";
                string newFileName = CurrentUserID.CurrentCompania.IEM_NOMBRE + "-" + doctoid + "-" + txtHorasTrabajo.Text + " horas-" + fecha.ToString("yyyy-MM-dd") + "-";
                CARCHIVOSADJUNTOSBE adj = new CARCHIVOSADJUNTOSBE();
                CARCHIVOSADJUNTOSD adminAdj = new CARCHIVOSADJUNTOSD();
                Directory.CreateDirectory(adjuntedFilesPath);
                foreach (string s in lvArchivosAdjuntos.CheckedItems)
                {
                    adj = new CARCHIVOSADJUNTOSBE();
                    File.Copy(s, adjuntedFilesPath + newFileName + Path.GetFileName(s));

                    adj.IDOCTOID = doctoid;
                    adj.IFECHA = fecha;
                    adj.IFECHADECREACION = DateTime.Today;
                    adj.IHORASDETRABAJO = int.Parse(txtHorasTrabajo.Text);
                    adj.IRUTAARCHIVO = adjuntedFilesPath + newFileName + Path.GetFileName(s);
                    adj.INOMBREARCHIVO = newFileName + Path.GetFileName(s);

                    adminAdj.AgregarARCHIVOSADJUNTOSD(adj, null);
                }
                
                MessageBox.Show("Elementos adjuntos copiados con éxito!");
                adjuntedFiles.Clear();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Algo ocurrió mal, no se pudieron adjuntar los archivos! \n " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            // openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                if (adjuntedFiles.Contains(openFileDialog1.FileName))
                {
                    MessageBox.Show("Este elemento ya fue seleccionado previamente!");
                    return;
                }
                i++;
                adjuntedFiles.Add(openFileDialog1.FileName);
                lvArchivosAdjuntos.Items.Add(openFileDialog1.FileName);
                lvArchivosAdjuntos.SetItemChecked(i, true);
            }
        }
    }
}
