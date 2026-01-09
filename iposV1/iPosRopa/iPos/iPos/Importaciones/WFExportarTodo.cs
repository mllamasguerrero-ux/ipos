using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosData;
using iPosBusinessEntity;

namespace iPos
{
    public partial class WFExportarTodo : IposForm
    {
       DateTime m_dateFrom;
       //int m_turnoIdFrom;
       DateTime m_dateTo;

       int m_tipoStockSelectedIndex = 0;

       int m_reenviarPedidoExistente = 0;
       long m_expFileExistente = 0;
       DateTime m_fechaPedidoExistente;

       Boolean bForzarPedido = false;

        public WFExportarTodo()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            ArrayList resultadosExportacion = new ArrayList();
            string strResultado = "";

            iDBF.EnvirArchivosAFtp(ref resultadosExportacion);   

            foreach (string strComm in resultadosExportacion)
                {
                    strResultado += strComm + "\n";
                }
            MessageBox.Show(strResultado);
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Marquee;
            backgroundWorker1.RunWorkerAsync();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void WFExportarTodo_Load(object sender, EventArgs e)
        {

            if (!ChecarPermisos())
            {
                this.Close();
                return;
            }

            if (CurrentUserID.CurrentCompania.IESMATRIZ == "S")
            {

                CSUCURSALD sucursalD = new CSUCURSALD();
                CSUCURSALBE sucursalBE = new CSUCURSALBE();
                sucursalBE.IID = CurrentUserID.CurrentParameters.ISUCURSALID;
                sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);

                if(sucursalBE != null && ((bool)sucursalBE.isnull["ISURTIDOR"] || sucursalBE.ISURTIDOR == null || sucursalBE.ISURTIDOR.Trim().Length == 0))
                {
                    /*MessageBox.Show("Siendo matriz no puede hacer este tipo de exportaciones");
                    this.Close();
                    return;*/
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage4);

                }
            }

            this.CBTipoStock.SelectedIndex = 0;

            //this.CBTurnoFrom.llenarDatos();
        }

        private void BTExportar_Click(object sender, EventArgs e)
        {
            m_dateFrom = this.DateFrom.Value.Date;
            //m_turnoIdFrom  =  int.Parse(this.CBTurnoFrom.SelectedValue.ToString()) ;
            m_dateTo = this.DateTo.Value.Date;

            WFPedidosYaExportados wf = new WFPedidosYaExportados(m_dateFrom, m_dateTo/*, m_turnoIdFrom*/);
            wf.ShowDialog();

            if (!wf.m_Confirmar)
                return;

            if (wf.m_reenviarPedidoExistente != 0)
            {
                m_reenviarPedidoExistente = wf.m_reenviarPedidoExistente;
                m_fechaPedidoExistente = wf.m_fechaPedidoExistente;
                m_expFileExistente = wf.m_expFileExistente;
                
            }

            wf.Dispose();
            GC.SuppressFinalize(wf);


            progressBar2.Style = ProgressBarStyle.Marquee;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            ArrayList resultadosExportacion = new ArrayList();
            string strResultado = "";

            if (m_reenviarPedidoExistente == 0)
            {
                iDBF.ProcesoPedido(ref resultadosExportacion,
                                                m_dateFrom,
                                                m_dateTo,
                                                m_reenviarPedidoExistente,
                                                CBIncluirApartado.Checked,
                                                DBValues._DOCTO_SUBTIPO_PEDIDOXFECHA,
                                                m_expFileExistente);
                if (bForzarPedido)
                    bForzarPedido = false;
            }
            else
            {
                iDBF.ProcesoPedido(ref resultadosExportacion,
                                                m_fechaPedidoExistente,
                                                m_fechaPedidoExistente,
                                                m_reenviarPedidoExistente,
                                                CBIncluirApartado.Checked,
                                                DBValues._DOCTO_SUBTIPO_PEDIDOXFECHA, m_expFileExistente);
                if (bForzarPedido)
                    bForzarPedido = false;
            }

            foreach (string strComm in resultadosExportacion)
            {
                strResultado += strComm + "\n";
            }
            m_reenviarPedidoExistente = 0;
            m_expFileExistente = 0;
            MessageBox.Show(strResultado);

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar2.Style = ProgressBarStyle.Blocks;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El sistema intentara exportar todas las existencias, este proceso puede tardar unos minutos, cuando finalize enviara un mensaje con el resultado de la exportacion, por mientras puede seguir trabajando");
            HiloExistencias._IFLAGENVIARINVENTARIO++;
            
        }


        private bool ChecarPermisos()
        {

            CPERSONAD personaD = new CPERSONAD();
            int iMenu = int.Parse(DBValues._MENUID_EXPORTAR.ToString());
            if (!personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, iMenu, null))
            {
                MessageBox.Show("El usuario no tiene derecho a este form");
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("El sistema intentara exportar todas las existencias, este proceso puede tardar unos minutos, cuando finalize enviara un mensaje con el resultado de la exportacion, por mientras puede seguir trabajando");
            HiloExistencias._IFLAGENVIAREXISTENCIASMANUAL++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m_dateFrom = this.dateDBF.Value.Date;
            m_dateTo = this.dateDBF.Value.Date;

            WFPedidosYaExportados wf = new WFPedidosYaExportados(m_dateFrom, m_dateTo);
            wf.ShowDialog();

            if (!wf.m_Confirmar)
            {
                wf.Dispose();
                GC.SuppressFinalize(wf);
                return;
            }

            if (wf.m_reenviarPedidoExistente != 0)
            {
                m_reenviarPedidoExistente = wf.m_reenviarPedidoExistente;
                m_fechaPedidoExistente = wf.m_fechaPedidoExistente;
                m_expFileExistente = wf.m_expFileExistente;

            }

            wf.Dispose();
            GC.SuppressFinalize(wf);

            progressBar3.Style = ProgressBarStyle.Marquee;
            backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            ArrayList resultadosExportacion = new ArrayList();
            string strResultado = "";

            iDBF.EnvirDesdeDBFAFtpDePedidos(ref resultadosExportacion,
                                                m_dateFrom,
                                                m_reenviarPedidoExistente);

            foreach (string strComm in resultadosExportacion)
            {
                strResultado += strComm + "\n";
            }
            m_reenviarPedidoExistente = 0;
            m_expFileExistente = 0;
            MessageBox.Show(strResultado);
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar3.Style = ProgressBarStyle.Blocks;
        }

        private void btnSeleccionarPedido_Click(object sender, EventArgs e)
        {
            WFListaPedidosExportacion wf = new WFListaPedidosExportacion();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {

            ImportaDesdeFtp iDBF = new ImportaDesdeFtp();
            ArrayList resultadosExportacion = new ArrayList();
            string strResultado = "";

                iDBF.ProcesoPedido(ref resultadosExportacion,
                                                DateTime.Today,
                                                DateTime.Today,
                                                m_reenviarPedidoExistente,
                                                CBIncluirApartadoStock.Checked,
                                                m_tipoStockSelectedIndex == 1 ? DBValues._DOCTO_SUBTIPO_PEDIDOXSTOCKMAX : DBValues._DOCTO_SUBTIPO_PEDIDOXSTOCK,
                                                0);

                if (bForzarPedido)
                    bForzarPedido = false;
           

            foreach (string strComm in resultadosExportacion)
            {
                strResultado += strComm + "\n";
            }
            m_reenviarPedidoExistente = 0;
            m_expFileExistente = 0;
            MessageBox.Show(strResultado);
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar4.Style = ProgressBarStyle.Blocks;
        }

        private void btnPedidoxStock_Click(object sender, EventArgs e)
        {
            m_dateFrom = this.DateFrom.Value.Date;
            m_dateTo = this.DateTo.Value.Date;
            m_tipoStockSelectedIndex = this.CBTipoStock.SelectedIndex;

            progressBar4.Style = ProgressBarStyle.Marquee;
            backgroundWorker4.RunWorkerAsync();
        }

    }
}
