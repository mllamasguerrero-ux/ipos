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
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;

namespace iPos
{
    public partial class WFRecepcionAlmacenDetalle : Form
    {

        long m_lDoctoId = 0;
        long m_almacenId = 0;
        int m_folio = 0;
        string m_nombrecliente = "";
        DateTime m_fecha = DateTime.MinValue;



        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        public WFRecepcionAlmacenDetalle()
        {
            InitializeComponent();
        }


        public WFRecepcionAlmacenDetalle(long doctoId, int folio, string nombreCliente, DateTime fecha, long almacenid)
            : this()
        {
            m_lDoctoId = doctoId;
            m_folio = folio;
            m_nombrecliente = nombreCliente;
            m_fecha = fecha;
            m_almacenId = almacenid;
        }

        private void LlenarGrid()
        {
            try
            {
                this.mOVTO_POR_LOTE_VIEWTableAdapter.Fill(this.dSInventarioFisico3.MOVTO_POR_LOTE_VIEW, (int)m_lDoctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFRecepcionAlmacenDetalle_Load(object sender, EventArgs e)
        {

            lblFolio.Text = m_folio.ToString();
            lblCliente.Text = m_nombrecliente;
            lblFecha.Text = m_fecha.ToString("dd/MM/yyyy");
            LlenarGrid();
        }


        private ArrayList filterHayCantidadASurtir(ArrayList reasignaciones)
        {
            ArrayList retorno = new ArrayList();

            if (reasignaciones == null)
                return null;

            foreach(CReAsignacionLote reasignacion in reasignaciones)
            {
                if(reasignacion.cantidad > 0)
                    retorno.Add(reasignacion);
            }
            return retorno;
        }

        private void mOVTO_POR_LOTE_VIEWDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


           
        }











        private void btnMarcarComoSurtido_Click(object sender, EventArgs e)
        {
            CSURTIDOD surtidoD = new CSURTIDOD();

            if (!surtidoD.SURTIDO_ASIGNARESTADO(m_lDoctoId, TBNotaSurtido.Text, DBValues._DOCTO_SURTIDOESTADO_SURTIDO, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {

                this.Close();
            }

        }

        private void btnMarcarComoNoSurtido_Click(object sender, EventArgs e)
        {

            CSURTIDOD surtidoD = new CSURTIDOD();

            if (!surtidoD.SURTIDO_ASIGNARESTADO(m_lDoctoId, TBNotaSurtido.Text, DBValues._DOCTO_SURTIDOESTADO_ERROR, CurrentUserID.CurrentUser.IID, null))
            {
                MessageBox.Show(surtidoD.IComentario);
            }
            else
            {
                this.Close();
            }
        }






       




    }
}
