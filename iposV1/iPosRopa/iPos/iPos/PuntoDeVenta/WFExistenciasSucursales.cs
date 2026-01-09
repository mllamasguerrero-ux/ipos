using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFExistenciasSucursales : IposForm
    {
        string m_productoClave, m_productoDescripcion;
        long   m_ProductoId;
        public WFExistenciasSucursales()
        {
            InitializeComponent();
            m_productoClave = "";
            m_productoDescripcion = "";
            m_ProductoId = 0;
        }

        public WFExistenciasSucursales(string productoClave, long productoId,string productoDescripcion):this()
        {
            m_productoClave = productoClave;
            m_productoDescripcion = productoDescripcion;
            this.LBProducto.Text = "Producto : " + productoClave + " " + productoDescripcion;
            m_ProductoId = productoId;
        }

        private void WFExistenciasSucursales_Load(object sender, EventArgs e)
        {

            bool bVerExistenciasTodos = false;
            bool bVerExistenciasMatriz = false;
            CUSUARIOSD usersD = new CUSUARIOSD();
            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VEREXISTENCIAS_TODOS, null))
            {
                bVerExistenciasTodos = true;
            }

            if (usersD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_VEREXISTENCIAS_MATRIZ, null))
            {
                bVerExistenciasMatriz = true;
            }
            
            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();

            sucursalBE.IID = iPos.CurrentUserID.CurrentParameters.ISUCURSALID;
            sucursalBE = sucursalD.seleccionarSUCURSAL(sucursalBE, null);
            if (sucursalBE == null)
            {
                return ;
            }


            
            long grupoId = bVerExistenciasTodos ? 0 : sucursalBE.IGRUPOSUCURSALID;
            string strMostrarMatriz = bVerExistenciasMatriz ? "S" : "N";
            // TODO: This line of code loads data into the 'dSPuntoVenta.INVENTARIOSUCURSAL' table. You can move, or remove it, as needed.
            this.iNVENTARIOSUCURSALTableAdapter.Fill(this.dSPuntoVenta.INVENTARIOSUCURSAL, (int)m_ProductoId, CurrentUserID.CurrentParameters.ISUCURSALNUMERO, strMostrarMatriz, (int)grupoId);

        }
    }
}
