using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;
using System.IO;

namespace iPos
{
    public partial class WFCambiarTASAIVA : IposForm
    {
        long movtoid = 0;
        long personaid = 0;
        public bool m_cambiotasa = false;

        public WFCambiarTASAIVA()
        {
            InitializeComponent();
        }

        public WFCambiarTASAIVA(long p_movtoid, long p_personaid) : this()
        {
            movtoid = p_movtoid;
            personaid = p_personaid;
        }


        private void BTEnviar_Click(object sender, EventArgs e)
        {

            CMOVTOD movtoD = new CMOVTOD();
            
            decimal tasaiva = decimal.Parse(TBTASAIVA.Text);
            if (movtoD.CambiarTASAIVA(movtoid, tasaiva, personaid, null))
            {
                m_cambiotasa = true;
                MessageBox.Show("Se ha cambiado la tasa del iva en el registro");
                this.Close();
            }
            else{
                MessageBox.Show(movtoD.IComentario);
            }
        }
    }
}
