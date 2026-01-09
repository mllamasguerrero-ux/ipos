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
using System.Globalization;
using iPos.Surtir;

namespace iPos
{
    public partial class WFLogEventoTransaccion : IposForm
    {
        long definedId;
        string m_table = "";
        long tipoEventoTablaId = DBValues._TIPOEVENTOTABLA_NOTACOMPRA;


        public WFLogEventoTransaccion()
        {
            InitializeComponent();
            
        }
        
        public WFLogEventoTransaccion(string table, long doctoId, long tipoEventoTablaId):this(table)
        {
            this.definedId = doctoId;
            this.tipoEventoTablaId = tipoEventoTablaId;
        }
        
        public WFLogEventoTransaccion(string table):this()
        {
            m_table = table;
        }


        private void WFLogEventoTransaccion_Load(object sender, EventArgs e)
        {

            LlenarGrid();

        }


        private void LlenarGrid()
        {
            try
            {
                var minDateStr = "1984-03-16 13:26";
                var maxDateStr = "2084-03-16 13:26";
                DateTime minDate = DateTime.ParseExact(minDateStr, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                DateTime maxDate = DateTime.ParseExact(maxDateStr, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                lOGEVENTOTABLATableAdapter.Fill(this.dSCatalogos.LOGEVENTOTABLA, m_table, (int?)definedId, minDate, maxDate,0, (int)tipoEventoTablaId);
                
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

        private void BTAgregarNota_Click(object sender, EventArgs e)
        {

            agregarNota(false, "Negociacion transaccion", tipoEventoTablaId);
        }

        private void agregarNota(bool forzarNota, string title, long tipoEventoId)
        {

            string strNota = "";
            string strEncabezado = "";
            bool bNotaAgregada = false;
            WFNotaIncidencia look = new WFNotaIncidencia(forzarNota, title, true);
            look.ShowDialog();
            strNota = look.strNotaIncidencia;
            strEncabezado = look.strEncabezadoIncidencia;
            bNotaAgregada = look.m_notaAgregada;
            look.Dispose();
            GC.SuppressFinalize(look);


            CLOGEVENTOTABLAD logD = new CLOGEVENTOTABLAD();
            CLOGEVENTOTABLABE logBE = new CLOGEVENTOTABLABE();
            if (bNotaAgregada && strNota != null && strNota.Trim().Length > 0)
            {
                logBE.IUSUARIOID = CurrentUserID.CurrentUser.IID;
                logBE.ITIPOEVENTOTABLAID = tipoEventoId;
                logBE.IACTIVO = "S";
                logBE.ITABLA = "Doctos";
                logBE.INOTA = strNota;
                logBE.IENCABEZADO = strEncabezado;
                logBE.IRECORDID = this.definedId;
                logBE.IFECHAHORA = DateTime.Now;
                logD.AgregarLOGEVENTOTABLAD(logBE, null);
            }

            LlenarGrid();

        }

    }
}
