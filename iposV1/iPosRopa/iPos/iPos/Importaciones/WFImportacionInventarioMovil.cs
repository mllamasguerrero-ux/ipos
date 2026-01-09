using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using WSGetProducta4App.DAO.businessEntity;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using iPosData;
using ConexionesBD;
using iPosBusinessEntity;
using iPos.WebServices;

namespace iPos.Importaciones
{
    public partial class WFImportacionInventarioMovil : Form
    {

        private List<InvMovilContainerResponse> inventarios = new List<InvMovilContainerResponse>();
        private int lastSelectedDoctoIndex;
        private int lastSelectedDoctoId;
        private long? doctoId = null;
        private CINVENTARIOD daoInv = new CINVENTARIOD();
        private Dictionary<string, long?> agrupacionPorAlmacen = new Dictionary<string, long?>();
        WSConnectionInventarioApp WSInvApp = new WSConnectionInventarioApp();

        //Constructor
        public WFImportacionInventarioMovil(List<InvMovilContainerResponse> items)
        {
            InitializeComponent();
            inventarios = items;
        }

        //Carga del WF
        private void WFImportacionInventarioMovil_Load(object sender, EventArgs e)
        {
            this.datosInventarioListView.CheckBoxes = true;
            this.datosInventarioListView.FullRowSelect = true;
            for (var i = 0; i < inventarios.Count; i++)
            {
                ListViewItem newList = new ListViewItem(inventarios[i].InvMovilDocto.Id.ToString());
                newList.SubItems.Add(inventarios[i].InvMovilDocto.SucursalClave);
                newList.SubItems.Add(inventarios[i].InvMovilDocto.Usuario);
                newList.SubItems.Add(inventarios[i].InvMovilDocto.Dispositivo);
                newList.SubItems.Add(inventarios[i].InvMovilDocto.Estatus);
                newList.SubItems.Add(inventarios[i].InvMovilDocto.Fecha.ToString());
                if(inventarios[i].InvMovilDocto.Estatus.Equals("BORRADOR"))
                {
                    newList.BackColor = Color.Orange;
                }
                datosInventarioListView.Items.Add(newList);
            }
        }


        //Eventos de los botones
        private void button1_Click(object sender, EventArgs e) //Agregar todos los inventarios
        {
            if (hayInventariosEnBorrador("ALL"))
            {
                DialogResult dialogResult = MessageBox.Show("Hay Inventarios que ya fueron procesadoes en borrador, desea continuar?", "Seguro?",
                                                            MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            for (int i=0; i < datosInventarioListView.Items.Count; i++)
            {
                int idLista = Int32.Parse(datosInventarioListView.Items[i].SubItems[0].Text);

                if (!importarABorradorInventario(getInvMovilById(idLista)))
                {
                    daoInv.EliminarBorradoresInventario(null);
                    MessageBox.Show("Error al procesar el inventario");
                    return;
                }
                else
                {
                    if (!WSInvApp.changeInventarioStatus("BORRADOR", idLista, getInvMovilById(idLista).InvMovilDocto.SucursalClave, ""))
                    {
                        daoInv.EliminarBorradoresInventario(null);
                        MessageBox.Show("Error al cambiar el estatus del inventario");
                        return;
                    }
                }
            }
            datosInventarioListView.Items.Clear();
            productosInventarioListView.Items.Clear();
            MessageBox.Show("Inventario procesado");
        }

        private bool importarABorradorInventario(InvMovilContainerResponse container)
        {
            string errorMessage = "";
            foreach(InventarioMovilMovto movto in container.InventarioMovilMovto)
            {
                if (!importarMovtoBorradorInventario(ref doctoId, movto.Clave, movto.Cantidad, movto.Lote,
                                                   movto.FechaVence, movto.AlmacenClave, container.InvMovilDocto.Usuario, errorMessage))
                {
                    MessageBox.Show("Error: " + errorMessage);
                    return false;
                }


            }
            //por cada  inventarios capturados que quieres que se importen
                //por cada movto de dicho inventario
                    //importarMovtoBorradorInventario
                     //si hay un error eliminarborradores

            //fin recorrer

            // eliminar los inventarios que estan en el servidor (pediente)

            return true;
        }


        private bool importarMovtoBorradorInventario(ref long? doctoInventario, string productoClave, decimal? cantidad,
                                             string lote, string fechaVence, string almacenClave, string vendedorApp,
                                             string referencia/*, long? usuarioId*/)
        {

            bool retorno;
            long? productoId = 0;//obtener la clave del producto
            int? almacenId = 0;//obtener la clave del almacen
            long? sucursalId = CurrentUserID.CurrentParameters.ISUCURSALID;
            long tipoDoctoId = DBValues._DOCTO_TIPO_INVENTARIO_FISICO;
            //string refMessage = "";
            string vendedorNombre = CurrentUserID.CurrentUser.INOMBRE;
            long? usuarioId = CurrentUserID.CurrentUser.IID;
            string referenciaCapturador = vendedorApp; // "El del app";
            DateTime fechaVenceAux = fechaVence == "" ? DateTime.MinValue : DateTime.Parse(fechaVence);
            CPRODUCTOD daoProd = new CPRODUCTOD();
            CPRODUCTOBE prod = new CPRODUCTOBE();
            CALMACEND daoAlmacen = new CALMACEND();
            CALMACENBE almacenBe = new CALMACENBE();

            prod.ICLAVE = productoClave;
            prod = daoProd.seleccionarPRODUCTOPorClave(prod, null);
            productoId = prod.IID;
            almacenBe.ICLAVE = almacenClave;
            almacenBe = daoAlmacen.seleccionarALMACENxCLAVE(almacenBe, null);
            almacenId = int.Parse(almacenBe.IID.ToString());

            if(!agrupacionPorAlmacen.ContainsKey(almacenClave))
            {
                agrupacionPorAlmacen.Add(almacenClave, 0);
            }

            doctoInventario = agrupacionPorAlmacen[almacenClave];
            


            retorno = daoInv.EjecutarAddMOVTO(ref doctoInventario, null, productoId, vendedorNombre, usuarioId, lote,
                                null, almacenId, sucursalId, fechaVenceAux,
                                tipoDoctoId, null, null, "N", 0, cantidad, null, referenciaCapturador, ref referencia, 
                                iPos.CurrentUserID.CurrentCompania.IEM_CAJA, null);

            agrupacionPorAlmacen[almacenClave] = doctoInventario;

            return retorno;
        } 



        

        /*private bool EliminarBorradoresInventario( FbTransaction st)
        {

            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_DEL_NOTERMINADOS";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionesBD.ConexionBD.ConexionString(), null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }

        }*/


        private InvMovilContainerResponse getInvMovilById(int id)
        {
            foreach(InvMovilContainerResponse item in inventarios)
            {
                if(item.InvMovilDocto.Id == id)
                {
                    return item;
                }
            }
            return null;
        }


        private void button2_Click(object sender, EventArgs e) //Agrega el inventario actual
        {
            if(datosInventarioListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Hay mas de un un item seleccionado!");
                return;
            }
            else if(datosInventarioListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Seleccione un item!");
                return;
            }
            if(getInvMovilById(this.lastSelectedDoctoId).InvMovilDocto.Estatus.Equals("BORRADOR"))
            {
                DialogResult dialogResult = MessageBox.Show("Este inventario ya habia sido procesado a borrador, desea continuar de todos modos?",
                                                            "Seguro?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            if(!importarABorradorInventario(getInvMovilById(this.lastSelectedDoctoId)))
            {
                daoInv.EliminarBorradoresInventario(null);
                MessageBox.Show("Error al procesar el inventario");
            }
            else
            {
                if (!WSInvApp.changeInventarioStatus("BORRADOR", lastSelectedDoctoId, getInvMovilById(lastSelectedDoctoId).InvMovilDocto.SucursalClave, ""))
                {
                    daoInv.EliminarBorradoresInventario(null);
                    MessageBox.Show("Error al cambiar el estatus del inventario");
                    return;
                }
                datosInventarioListView.Items[this.lastSelectedDoctoIndex].Remove();
                productosInventarioListView.Items.Clear();
                MessageBox.Show("Inventario procesado");
            }
        }

        private bool hayInventariosEnBorrador(string tipoDeBusqueda)
        {
            if(tipoDeBusqueda.Equals("SELECTED"))
            {
                foreach (ListViewItem item in datosInventarioListView.CheckedItems)
                {
                    int idLista = Int32.Parse(item.SubItems[0].Text);
                    if (getInvMovilById(idLista).InvMovilDocto.Estatus.Equals("BORRADOR"))
                    {
                        return true;
                    }
                }
            }
            else if(tipoDeBusqueda.Equals("ALL"))
            {
                foreach(ListViewItem item in datosInventarioListView.Items)
                {
                    int idLista = Int32.Parse(item.SubItems[0].Text);
                    if (getInvMovilById(idLista).InvMovilDocto.Estatus.Equals("BORRADOR"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void button3_Click(object sender, EventArgs e) //Agrega los inventarios seleccionados
        {
            if(datosInventarioListView.CheckedItems.Count < 1)
            {
                MessageBox.Show("No hay marcado ningun inventario");
                return;
            }
            if(hayInventariosEnBorrador("SELECTED"))
            {
                DialogResult dialogResult = MessageBox.Show("Hay Inventarios que ya fueron procesadoes en borrador, desea continuar?", "Seguro?",
                                                            MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            foreach (ListViewItem item in datosInventarioListView.CheckedItems)
            {
                int idLista = Int32.Parse(item.SubItems[0].Text);

                if (!importarABorradorInventario(getInvMovilById(idLista)))
                {
                    daoInv.EliminarBorradoresInventario(null);
                    MessageBox.Show("Error al procesar el inventario");
                    return;
                }
                else
                {
                    if (!WSInvApp.changeInventarioStatus("BORRADOR", idLista, getInvMovilById(idLista).InvMovilDocto.SucursalClave, ""))
                    {
                        daoInv.EliminarBorradoresInventario(null);
                        MessageBox.Show("Error al cambiar el estatus del inventario");
                        return;
                    }
                }
            }

            foreach (ListViewItem item in datosInventarioListView.CheckedItems)
            {
                datosInventarioListView.Items.Remove(item);
            }

            productosInventarioListView.Items.Clear();
            MessageBox.Show("Inventario procesado");
        }

        //Operaciones con los list views
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void productosInventarioListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void datosInventarioListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int idLista = Int32.Parse(datosInventarioListView.Items[e.ItemIndex].SubItems[0].Text);
            lastSelectedDoctoId = idLista;
            lastSelectedDoctoIndex = e.ItemIndex;
            for (var i=0; i<inventarios.Count; i++)
            {
                if (inventarios[i].InvMovilDocto.Id == idLista)
                {
                    productosInventarioListView.Items.Clear();
                    for (var j=0; j<inventarios[i].InventarioMovilMovto.Count; j++)
                    {
                        ListViewItem newList = new ListViewItem(inventarios[i].InventarioMovilMovto[j].Id.ToString());
                        newList.SubItems.Add(inventarios[i].InventarioMovilMovto[j].AlmacenClave);
                        newList.SubItems.Add(inventarios[i].InventarioMovilMovto[j].Lote);
                        newList.SubItems.Add(inventarios[i].InventarioMovilMovto[j].Clave);
                        newList.SubItems.Add(inventarios[i].InventarioMovilMovto[j].Cantidad.ToString());
                        newList.SubItems.Add(inventarios[i].InventarioMovilMovto[j].FechaVence.ToString());
                        productosInventarioListView.Items.Add(newList);
                    }                    
                }
            }
        }






        /*public bool EjecutarAddMOVTO(ref long? P_IDDOCTO,
                                        decimal? P_CANTIDAD,
                                        long? P_IDPRODUCTO,
                                        string P_VD_VENDEDOR,
                                        long? P_USERID,
                                        string P_LOTE,
                                        int? US_SUPERVISOR,
                                        int? ALMACENID,
                                        long? SUCURSALID,
                                        DateTime P_FECHAVENCE,
                                        long P_TIPO_DOCTO,
                                        long? P_SUCURSALTID,
                                        long? P_ALMACENTID,
                                        string P_PROMOCION,
                                        long? P_TIPODIFERENCIAINVENTARIOID,
                                        decimal? P_CANTIDAD_SURTIDA,
                                        long? P_LOTEIMPORTADO,
                                        string referencia,
                                        ref string refMessage,
                                        FbTransaction st)
        {
            try
            {
                ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@DOCTOACTUALID", FbDbType.BigInt);
                if (P_IDDOCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDDOCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (ALMACENID.HasValue)
                {
                    auxPar.Value = (long)ALMACENID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUCURSALID", FbDbType.BigInt);
                if (SUCURSALID.HasValue)
                {
                    auxPar.Value = (long)SUCURSALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = P_TIPO_DOCTO;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSDOCTOPAGOID", FbDbType.BigInt);
                auxPar.Value = DBValues._DOCTO_ESTATUS_PAGO_BORRADOR;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (P_USERID.HasValue)
                {
                    auxPar.Value = (long)P_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CAJAID", FbDbType.BigInt);
                auxPar.Value = iPos.CurrentUserID.CurrentCompania.IEM_CAJA;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PARTIDA", FbDbType.SmallInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRODUCTOID", FbDbType.BigInt);
                if (P_IDPRODUCTO.HasValue)
                {
                    auxPar.Value = (long)P_IDPRODUCTO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTE", FbDbType.VarChar);
                if (P_LOTE != null && P_LOTE != "")
                {
                    auxPar.Value = P_LOTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FECHAVENCE", FbDbType.Date);
                if (P_FECHAVENCE > DateTime.MinValue)
                    auxPar.Value = P_FECHAVENCE;
                else
                    auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDAD", FbDbType.Numeric);
                if (P_CANTIDAD.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSURTIDA", FbDbType.Numeric);
                if (P_CANTIDAD_SURTIDA.HasValue)
                {
                    auxPar.Value = (decimal)P_CANTIDAD_SURTIDA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADFALTANTE", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADDEVUELTA", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@CANTIDADSALDO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSMOVTOID", FbDbType.BigInt);
                auxPar.Value = (long)DBValues._MOVTO_ESTATUS_BORRADOR;
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIA", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAS", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@COSTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);





                auxPar = new FbParameter("@SUCURSALTID", FbDbType.BigInt);
                if (P_SUCURSALTID.HasValue)
                {
                    auxPar.Value = (long)P_SUCURSALTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ALMACENTID", FbDbType.BigInt);
                if (P_ALMACENTID.HasValue)
                {
                    auxPar.Value = (long)P_ALMACENTID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PROMOCION", FbDbType.Char);
                auxPar.Value = P_PROMOCION;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPODIFERENCIAINVENTARIOID", FbDbType.BigInt);
                if (P_TIPODIFERENCIAINVENTARIOID.HasValue)
                {
                    auxPar.Value = (long)P_TIPODIFERENCIAINVENTARIOID;
                }
                else
                {
                    parts.Add(auxPar);
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@FECHA", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENCE", FbDbType.Date);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PORCENTAJEDESCUENTO", FbDbType.Numeric);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ANAQUELID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);


                auxPar = new FbParameter("@P_MOVTOREFID", FbDbType.BigInt);
                auxPar.Value = System.DBNull.Value;
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION1", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION2", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESCRIPCION3", FbDbType.VarChar);
                auxPar.Value = "";
                parts.Add(auxPar);


                auxPar = new FbParameter("@PRECIOYAVALIDADO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@LOTEIMPORTADO", FbDbType.BigInt);
                if (P_LOTEIMPORTADO.HasValue)
                {
                    auxPar.Value = (long)P_LOTEIMPORTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CARGOTARJPRECIOMANUAL", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);

                auxPar = new FbParameter("@AGRUPAPORPARAMETRO", FbDbType.VarChar);
                auxPar.Value = "N";
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@MOVTOID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);





                string commandText = @"MOVTO_INSERT";
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    SqlHelper.ExecuteNonQuery(ConexionBD.ConexionString(), CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);

                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), ConexionBD.ConexionString(), st);
                        refMessage = "ERROR : " + strMensajeErr;
                        return false;
                    }
                }

                P_IDDOCTO = (long)arParms[arParms.Length - 3].Value;
                return true;
            }
            catch (Exception e)
            {
                //this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }*/

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
