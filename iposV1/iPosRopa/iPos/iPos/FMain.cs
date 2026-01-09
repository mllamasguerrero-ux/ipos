using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using DynamicMenuApp;
using System.Collections;
using LoginInfo;
using iPosReporting;
using DataLayer.Importaciones;
using iPos.Catalogos;
using System.Diagnostics;
using EglobalBBVA;
using Newtonsoft.Json;
using iPos.Reportes.Bancomer;
using iPos.Utilerias.Procesos;
using iPos.Utilerias.Ajustes_catálogos_SAT;
using System.IO;
using iPos.Importaciones;
using iPos.WebServices;
using DataLayer.Utilerias.Respuestas.CatalogoSat;
using iPos.Threads;
using iPos.Entradas;
using iPos.Reportes.Entradas;
using iPos.Reportes.Ventas;
using iPos.Utilerias;
using FastReport.Export.Text;
using iPos.Exportaciones;
using iPos.Contabilidad;

namespace iPos
{

    /**wpf only starts*
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public class MyMenuData
    {
        private string _header;
        public string MyHeader
        {
            get { return _header; }
            set { _header = value; }
        }

        private int _menuid;
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        private List<MyMenuData> _subitems = new List<MyMenuData>();
        public List<MyMenuData> SubItems
        {
            get { return _subitems; }
            set { _subitems = value; }
        }

        private ICommand _importRecentItemCommand;

        public ICommand ImportRecentItemCommand
        {
            get { return _importRecentItemCommand ?? (_importRecentItemCommand = new RelayCommand(ImportRecentItemCommandExecuted)); }
        }

        private void ImportRecentItemCommandExecuted(object parameter)
        {
            MyMenuData mData = (MyMenuData)parameter;
            FMain.MenuItemClickEvent(mData.MenuId.ToString());


        }



    }
    /**wpf only ends**/

    public partial class FMain : IposForm
    {
        private long m_idUserId;
        HiloDeImportaciones hiloImp;
        HiloExistencias hiloExist;
        HiloFacturacionMovil hiloFactMovil;
        HiloTotalizados hiloTotalizados;
        HiloMensajes hiloMensajes;
        HiloAutoCompletes hiloAutoCompletes;
        HiloMovil3 hiloMovil3;
        CatalogoSatThread catalogoSatThread;
        //HiloPPC hiloPPC;

        public bool m_cambiandoEmpresa = false;
        public string m_empresaSeleccionada;


        /**wpf only starts*
        List<MyMenuData> data = new List<MyMenuData>();
        /**wpf only ends**/

        public FMain()
        {
            InitializeComponent();
            this.MaximumSize = SystemInformation.WorkingArea.Size;
            this.MaximizedBounds = SystemInformation.WorkingArea;
            m_idUserId = -1;

            try
            {
                /**winforms only starts**/
                AddMenuAyuda();
                AddMenu(0);
                /**winforms only ends**/
            }
            catch { }

            Control.CheckForIllegalCrossThreadCalls = false;

        }
        public FMain(long idUser)
        {
            InitializeComponent();
            this.MaximumSize = SystemInformation.WorkingArea.Size;
            this.MaximizedBounds = SystemInformation.WorkingArea;
            m_idUserId = idUser;
            LoginInfo.CurrentUser.m_IdUserId = m_idUserId;
            /**winforms only starts**/
            LlenarMenuItemPorUsuario(m_idUserId);
            AddMenuAyuda();
            AddMenu(0);
            /**winforms only ends**/

            string testFtpPass = EncDec.Encrypt(@"desarrollo", EncDec.PasswordDefault());





        }

        public bool ValidMenu(string menu)
        {

            switch(menu)
            {
                case "84":
                case "85":
                case "86":
                    {
                        if (CurrentUserID.CurrentCompania.IESMATRIZ == "S")
                            return true;
                        else
                            return false;
                    }
                case "155":
                    {
                        
                        if (CurrentUserID.HABILITARVENDEDOR_MOVIL)
                            return true;
                        else
                            return false;
                    }
                default:
                    return true;
            }

            
        }

        /**winforms only starts**/
        public int AddMenu(int idParent)
        {
            DynamicMenuMgr _dMenuMgr;
            DynamicMenuItem _item;
            CMENUITEMSD MENUITEMSD = new CMENUITEMSD();
            DynamicMenuItem.DynamicMenuItemTextData MnuIter;
            _dMenuMgr = new DynamicMenuMgr(
                 rootToolStripMenuItem, null,
                DynamicMenuMgr.DynamicMenuType.Inline,
                DynamicMenuMgr.ItemInsertMode.Append, 50);
            //DataSet ds = MENUITEMSD.GetChild_MENUITEMS(0, m_idUserId);
            DataRow[] submenus = GetChild_MENUITEMS(0);
            foreach (DataRow fila in submenus)
            {


                if (!ValidMenu(fila["MN_ID"].ToString()))
                    continue;

                MnuIter = new DynamicMenuItem.DynamicMenuItemTextData(fila["MN_ETIQUETA"].ToString(), fila["MN_ID"].ToString());
                _item = _dMenuMgr.AddMenuItem(MnuIter.MenuText, MnuIter.MenuData, this.MenuItemClick);
                AddMenuRecursive(_item);
            }

            return 1;
        }
        public int AddMenuRecursive(DynamicMenuItem mnuItem)
        {
            DynamicMenuMgr _dMenuMgr;
            DynamicMenuItem _item;
            CMENUITEMSD MENUITEMSD = new CMENUITEMSD();
            DynamicMenuItem.DynamicMenuItemTextData MnuIter;
            //DataSet ds = MENUITEMSD.GetChild_MENUITEMS(int.Parse(mnuItem.Data), m_idUserId);
            DataRow[] submenus = GetChild_MENUITEMS(int.Parse(mnuItem.Data));

            if (submenus == null || submenus.Length == 0)
                return 0;
            _dMenuMgr = new DynamicMenuMgr(
                mnuItem, null,
                DynamicMenuMgr.DynamicMenuType.Submenu,
                DynamicMenuMgr.ItemInsertMode.Append, 50);

            foreach (DataRow fila in submenus)
            {

                //esto es para excluir hardcoded algunos menus
                int menuID = int.Parse(fila["MN_ID"].ToString());
                bool bSkip = false;
                foreach (int iX in DBValues._MENUS_EXCLUDED)
                {
                    if (iX == menuID)
                    {
                        bSkip = true;
                    }
                }


                if (!ValidMenu(fila["MN_ID"].ToString()))
                    bSkip = true;

                if (bSkip)
                    continue;



                MnuIter = new DynamicMenuItem.DynamicMenuItemTextData(fila["MN_ETIQUETA"].ToString(), fila["MN_ID"].ToString());
                _item = _dMenuMgr.AddMenuItem(MnuIter.MenuText, MnuIter.MenuData, this.MenuItemClick);
                AddMenuRecursive(_item);
            }
            return 1;
        }


        public void AddMenuAyuda()
        {
            DynamicMenuMgr _dMenuMgr;
            DynamicMenuItem _item;
            //DynamicMenuItem.DynamicMenuItemTextData MnuIter;
            _dMenuMgr = new DynamicMenuMgr(
                 rootToolStripMenuItem, null,
                DynamicMenuMgr.DynamicMenuType.Inline,
                DynamicMenuMgr.ItemInsertMode.Append, 50);

            _item = _dMenuMgr.AddMenuItem("Ayuda", "1001", this.MenuItemClick);


            DynamicMenuMgr _dMenuMgrTree;

            _dMenuMgrTree = new DynamicMenuMgr(
                _item, null,
                DynamicMenuMgr.DynamicMenuType.Submenu,
                DynamicMenuMgr.ItemInsertMode.Append, 50);
            _dMenuMgrTree.AddMenuItem("Acerca de", "1002", this.MenuItemClick);
            _dMenuMgrTree.AddMenuItem("Soporte", "1003", this.MenuItemClick);

        }
        /**winforms only ends**/


        /**wpf only starts*
         
        public int AddMenu(int idParent)
        {
            
            DataRow[] submenus = GetChild_MENUITEMS(0);
            foreach (DataRow fila in submenus)
            {


                if (!ValidMenu(fila["MN_ID"].ToString()))
                    continue;


                MyMenuData _item = new MyMenuData();
                _item.MyHeader = fila["MN_ETIQUETA"].ToString();
                _item.MenuId = int.Parse(fila["MN_ID"].ToString());
                AddMenuRecursive(_item);
                data.Add(_item);

            }

            return 1;
        }
        public int AddMenuRecursive( MyMenuData mnuItem)
        {
            
            DataRow[] submenus = GetChild_MENUITEMS(mnuItem.MenuId);

            if ( submenus == null || submenus.Length == 0)
                return 0;

            foreach (DataRow fila in submenus)
            {

                //esto es para excluir hardcoded algunos menus
                int menuID = int.Parse(fila["MN_ID"].ToString());
                bool bSkip = false;
                foreach (int iX in DBValues._MENUS_EXCLUDED)
                {
                    if (iX == menuID)
                    {
                        bSkip = true;
                    }
                }


                if (!ValidMenu(fila["MN_ID"].ToString()))
                    bSkip = true;

                if (bSkip)
                    continue;

                MyMenuData _item = new MyMenuData();
                _item.MyHeader = fila["MN_ETIQUETA"].ToString();
                _item.MenuId = int.Parse(fila["MN_ID"].ToString());
                AddMenuRecursive(_item);
                mnuItem.SubItems.Add(_item);

            }
            return 1;
        }
        /**wpf only ends**/


        private void PreguntaDatosGenerales()
        {
            CPARAMETROBE parametroBE = new CPARAMETROBE();
            CPARAMETROD parametroD = new CPARAMETROD();

            parametroBE = parametroD.seleccionarPARAMETROActual(null);
            if (parametroBE == null)
            {
                MessageBox.Show(parametroD.IComentario);
                return;
            }
            if (parametroBE.ISUCURSALNUMERO == "")
            {

                WFEmpresaEdit frm = new WFEmpresaEdit();
                frm.ReCargar("Cambiar", "");
                frm.ShowDialog();
                frm.Dispose();
                GC.SuppressFinalize(frm);
            }


        }



        private void PreparaPinPadSiEsNecesario()
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();

            if (CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD != null && CurrentUserID.CurrentParameters.IBANCOMERHABPINPAD == "S" &&
                 (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_BANCOMER, null)))
            {
                try
                {

                PagoBancomerHelper.PreparaPinPadSC();
            }
                catch(Exception ex)
                {

                }
            }


            if(CurrentUserID.CurrentVerifoneCajaConfig != null && CurrentUserID.CurrentVerifoneCajaConfig.IACTIVO == "S" &&
                    usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_VERIFONE, null))

            {
                try
                {

                    PagoVerifoneHelper.PreparaPinPad(false);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            

        }

        

        private void EjecutarReplicadorSiEstaInstalado()
        {
            string mensaje = "";

            if (CurrentUserID.CurrentCompania.IREPLICADOR == "S")
            {
                if (!Utils.EjecutarReplicadorSiEstaInstalado(ref mensaje))
                {

                    MessageBox.Show(mensaje);
                }
            }

           
        }

        private void IniciarThreadCatalogoSat()
        {
            catalogoSatThread = new CatalogoSatThread();
            catalogoSatThread.IniciarProceso();
        }

        private void DetenerThreadCatalogoSat()
        {
            catalogoSatThread.PararProceso();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PagoBancomerHelper.CargarConfiguracionDePinPad();
            //PagoBancomerHelper.ImprimirVoucher(47, true, true); //sin puntos 
            //PagoBancomerHelper.ImprimirVoucher(80, true);
            //for (int i = 70; i <= 91; i++)
            //{
            //    PagoBancomerHelper.ImprimirVoucher(i, true);
            //    PagoBancomerHelper.ImprimirVoucher(i, false); 
            //}
            

            PreparaPinPadSiEsNecesario();

            EjecutarReplicadorSiEstaInstalado();

            CurrentUserID.mainWinSize = new Size((int)this.Size.Width, (int)this.Size.Height);

            if (CurrentUserID.CurrentParameters.ISCREENCONFIG == 1)
            {
                this.panel1.Height += 18;
                this.panel3.Location = new Point(panel3.Location.X, this.panel3.Location.Y + 18);

                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }


            /*
            CBANCOMERPARAMBE buf = new CBANCOMERPARAMBE();
            CBANCOMERPARAMD bufD = new CBANCOMERPARAMD();
            buf.ITIPOTRANSACCION = "001";
            buf.IDOCTOID = -2;
            buf.IESTADOTRANSACCIONID = 0;

            if(bufD.BANCOMERPARAM_GUARDAR(ref buf, null))
            {
                MessageBox.Show("Guardado " + buf.IID.ToString());
            }
            else 
            {
                MessageBox.Show("Error " +  bufD.IComentario);
            }*/



            /**wpf only starts*
            LlenarMenuItemPorUsuario(m_idUserId);
            //AddMenuAyuda();
            AddMenu(0);
            this.menuStrip1.ItemsSource = data;
            /**wpf only ends**/


            //this.MainMenuStrip.ForeColor = Color.DarkMagenta;
            this.Text = this.Text + " Usuario: " + CurrentUserID.CurrentUser.IUSERNAME + " Empresa: " + CurrentUserID.CurrentCompania.IEM_NOMBRE;
            this.panel1.BackColor = Color.FromArgb(255, CurrentUserID.CurrentCompania.IRED, CurrentUserID.CurrentCompania.IGREEN, CurrentUserID.CurrentCompania.IBLUE);
            this.panel3.BackColor = Color.FromArgb(255, CurrentUserID.CurrentCompania.IRED, CurrentUserID.CurrentCompania.IGREEN, CurrentUserID.CurrentCompania.IBLUE);
            PreguntaDatosGenerales();            
            hiloImp = new HiloDeImportaciones();
            try
            {
                hiloImp.IniciarImportacionDeArchivos();
            }
            catch(Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }
            


            hiloExist = new HiloExistencias();
            try
            {
                hiloExist.IniciarHiloExistencias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }

            
            hiloFactMovil = new HiloFacturacionMovil();
            try
            {
                hiloFactMovil.IniciarFacturacionMovil();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }



            hiloTotalizados = new HiloTotalizados();
            try
            {
                hiloTotalizados.IniciarHiloTotalizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }


            hiloMensajes = new HiloMensajes();
            try
            {
                hiloMensajes.IniciarHiloMensajes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }


            //hiloPPC = new HiloPPC();
            //try
            //{
            //    hiloPPC.IniciarHiloPPC();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            //}



            hiloAutoCompletes = new HiloAutoCompletes();
            try
            {
                hiloAutoCompletes.IniciarHiloAutoCompletes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }



            hiloMovil3 = new HiloMovil3();
            try
            {
                hiloMovil3.IniciarHiloMovil3();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mensaje : " + ex.Message + " " + ex.StackTrace);
            }


            IniciarThreadCatalogoSat();


            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
            {
                BTProveedores.Visible = false;
                button4.Visible = false;
                button8.Visible = false;
                button5.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                btnCortesDelDia.Visible = false;
                button7.Visible = false;
            }
            else
            {
                button4.Visible = true;
                button8.Visible = true;
                button5.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                btnCortesDelDia.Visible = true;
                button7.Visible = true;
            }

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CORTESDELDIA, null))
            {
                btnCortesDelDia.Visible = false;
            }


            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_CAMBIAR_EMPRESA, null))
            {
                btnCambiarEmpresa.Visible = true;
            }
            else
            {
                btnCambiarEmpresa.Visible = false;

            }

            if (!usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PUNTOVENTA, null))
            {
                button3.Visible = false;
            }
            else
            {

                button3.Visible = true;
            }

        }
        


        private void ShowBarButtons()
        {


            CPERSONAD personaD = new CPERSONAD();
            BTClientes.Visible = personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, 2, null);

            BTProveedores.Visible = personaD.UsuarioTieneDerechoAMenu(CurrentUserID.CurrentUser.IID, 18, null);


        }



        public static void MenuItemClickEvent(string strCodigoMenu)
        {

            switch (strCodigoMenu)
            {


                case "1002":
                    {
                        WFAbout fq = new WFAbout();
                        fq.ShowDialog();
                        fq.Dispose();
                        GC.SuppressFinalize(fq);
                        break;
                    }


                case "1003":
                    {
                        Process.Start("TeamViewerQS_es-idcqd99f3q.exe");
                        break;
                    }



                case "18":
                    {
                        WFProveedores fq = new WFProveedores();
                        fq.ShowDialog();
                        fq.Dispose();
                        GC.SuppressFinalize(fq);
                        break;
                    }
                case "19":
                    {

                        WFLineas fq = new WFLineas();
                        fq.ShowDialog();
                        fq.Dispose();
                        GC.SuppressFinalize(fq);
                        break;
                    }
                case "20":
                    {
                        WFMarcas fq = new WFMarcas();
                        fq.ShowDialog();
                        fq.Dispose();
                        GC.SuppressFinalize(fq);
                        break;
                    }
                case "238":
                    {
                        WFRutasEmbarque fq = new WFRutasEmbarque();
                        fq.ShowDialog();
                        fq.Dispose();
                        GC.SuppressFinalize(fq);
                        break;
                    }
                case DBValues._MENUID_PRODUCTOS:
                    {
                        //FormProductoFicha fq = new FormProductoFicha();

                        LOOKPROD fq = new LOOKPROD();
                        fq.m_bMostrarDescontinuados = true;
                        //fq.Owner = this;
                        fq.ShowDialog();
                        break;
                    }
                case "23":
                    {
                        WFUsuarios uEdit = new WFUsuarios();
                        uEdit.ShowDialog();
                        uEdit.Dispose();
                        GC.SuppressFinalize(uEdit);
                        break;
                    }
                case "24":
                    {
                        PERFILEdicion pEdicion = new PERFILEdicion();
                        pEdicion.ShowDialog();
                        pEdicion.Dispose();
                        GC.SuppressFinalize(pEdicion);
                        break;
                    }
                case "25":
                    {
                        FPasswordInicial fPi = new FPasswordInicial(LoginInfo.CurrentUser.m_IdUserId, false, true);
                        fPi.ShowDialog();
                        fPi.Dispose();
                        GC.SuppressFinalize(fPi);
                        return;
                    }
                    //case "27":
                    // {
                    //FRptClientes fPi = new FRptClientes();
                    //fPi.ShowDialog();
                    //fPi.Dispose();
                    //GC.SuppressFinalize(fPi);
                //return;
                //}
                case "28":
                    {
                        iPosReporting.FormKardex2 fPi = new iPosReporting.FormKardex2();
                        fPi.ShowDialog();
                        fPi.Dispose();
                        GC.SuppressFinalize(fPi);
                        return;
                    }
                case "2":
                    {
                        WFClientes fq = new WFClientes();
                        //fq.Owner = this;
                        fq.Show();

                        break;
                    }
                case "3":
                    {
                        WFVendedores fq = new WFVendedores();
                        fq.ShowDialog();
                        break;
                    }
                case DBValues._MENUID_IMPORTAR:
                    {
                        //ImportFromExcel ife = new ImportFromExcel();
                        //ife.ImportarProductosFromExcel(@"C:\temporal\productos.xls");

                        WFImportar frm = new WFImportar();
                        frm.Show();
                        break;
                    }
                case DBValues._MENUID_PUNTODEVENTA:
                    {
                        try
                        {

                            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") && 
                                (CurrentUserID.CurrentParameters.ISCREENCONFIG == 1 || CurrentUserID.CurrentParameters.ISCREENCONFIG == 2))
                            {
                                WFMovilPuntoDeVenta frm = new WFMovilPuntoDeVenta();
                                frm.ShowDialog();
                                frm.Dispose();
                                GC.SuppressFinalize(frm);
                            }
                            else
                            {
                                try
                                {
                                    WFPuntoDeVenta frm = new WFPuntoDeVenta();
                                    frm.ShowDialog();
                                    frm.Dispose();
                                    GC.SuppressFinalize(frm);
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message + "   " + ex.StackTrace);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : " + ex.Message + ex.StackTrace);
                        }
                        break;
                    }
                case "29":
                    {
                        //iPos.EMPRESAEdit_Reg uEdit = new iPos.EMPRESAEdit_Reg("Cambiar","");
                        //uEdit.ShowDialog();
                        WFEmpresaEdit frm = new WFEmpresaEdit();
                        frm.ReCargar("Cambiar", "");
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case DBValues._MENUID_CORTECERRAR:
                    {
                        //iPos.CORTESEdit_Reg frm = new iPos.CORTESEdit_Reg("Agregar", 0,DateTime.Today,DateTime.Now.TimeOfDay);
                        CorteCerrar frm = new CorteCerrar();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "7":
                    {
                        //iPos.M_OTROEdit_Reg frm = new iPos.M_OTROEdit_Reg("Agregar", 0);
                        //frm.ShowDialog();
                        break;

                    }
                case DBValues._MENUID_EXPORTAR:
                    {
                        iPos.WFExportarTodo frm = new iPos.WFExportarTodo();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "16":
                    {

                        WFCompras frm = new WFCompras();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "15":
                    {
                        iPos.WFReimpresionTickets frm = new iPos.WFReimpresionTickets();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "50":
                    {
                        WFProductoCambioPrecio frm = new WFProductoCambioPrecio();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case DBValues._MENUID_INVENTARIOFISICO:
                    {
                        WFListaInventarios frm = new WFListaInventarios();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case DBValues._MENUID_CORTEABRIR:
                    {
                        CorteAbrir frm = new CorteAbrir();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }



                case "53":
                    {
                        WFInventarioInicial frm = new WFInventarioInicial();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "55":
                    {
                        //iPosReporting.FRptCalcComisiones frm = new FRptCalcComisiones();
                        iPosReporting.FRptComisiones frm = new FRptComisiones();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "56":
                    {


                        iPosReporting.FRptVentas frm = new FRptVentas(CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S") || CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S"));
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "57":
                    {
                        iPosReporting.FRptDetVentas frm = new FRptDetVentas(CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S") || CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S"));
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "58":
                    {
                        iPosReporting.FRptCompras frm = new FRptCompras(CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S") || CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S"));
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "59":
                    {
                        iPosReporting.FRptDetCompras frm = new FRptDetCompras(CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S") || CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S"));
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "60":
                    {
                        iPosReporting.FRptStockFaltante frm = new FRptStockFaltante();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "61":
                    {
                        WFPerfiles frm = new WFPerfiles();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "62":
                    {
                        WFImportarDeExcel frm = new WFImportarDeExcel();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "63":
                    {
                        WFExportarAExcel frm = new WFExportarAExcel();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }



                case "64":
                    {
                        iPosReporting.FormKardexResumido frm = new iPosReporting.FormKardexResumido();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "65":
                    {
                        iPosReporting.FRptInvCosteado frm = new iPosReporting.FRptInvCosteado(CurrentUserID.CurrentParameters);
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "66":
                    {
                        iPosReporting.FRptDoctoPagos frm = new iPosReporting.FRptDoctoPagos();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "67":
                    {
                        iPos.CortesDelDia frm = new iPos.CortesDelDia();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "68":
                    {
                        iPos.WFLocacionProductos frm = new iPos.WFLocacionProductos();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "69":
                    {
                        iPos.WFRetiros frm = new iPos.WFRetiros();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "70":
                    {
                        iPos.WFVentaDevolucion frm = new iPos.WFVentaDevolucion();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "79":
                    {
                        iPos.WFAbonos frm = new iPos.WFAbonos();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "72":
                    {
                        iPos.WFSaldosAplicacion frm = new iPos.WFSaldosAplicacion();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "78":
                    {
                        iPos.WFAbonos frm = new iPos.WFAbonos(tipoTransaccionV.t_compra);
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "74":
                    {
                        iPos.WFSaldosAplicacion frm = new iPos.WFSaldosAplicacion(tipoTransaccionV.t_compradevolucion);
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "75":
                    {
                        iPos.WFDevolucionCompras frm = new iPos.WFDevolucionCompras();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "80":
                    {
                        iPosReporting.FRptTimbresCancelados frm = new iPosReporting.FRptTimbresCancelados();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "83":
                    {
                        iPos.Catalogos.WFBancos frm = new iPos.Catalogos.WFBancos();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "82":
                    {
                        iPos.Catalogos.WFMonedas frm = new iPos.Catalogos.WFMonedas();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "81":
                    {
                        iPos.Catalogos.WFTasaIvas frm = new iPos.Catalogos.WFTasaIvas();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "85":
                    {
                        iPos.WFMatrizImportar frm = new iPos.WFMatrizImportar();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "86":
                    {
                        iPos.WFMatrizExportar frm = new iPos.WFMatrizExportar();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "87":
                    {
                        FRptProductoLocations frm = new FRptProductoLocations();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }







                case "88":
                    {
                        WFSucursales frm = new WFSucursales();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "89":
                    {
                        WFGruposSucursal frm = new WFGruposSucursal();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "90":
                    {
                        WFStockProductos frm = new WFStockProductos();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "91":
                    {
                        WFAnaqueles frm = new WFAnaqueles();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "92":
                    {
                        iPosReporting.FRptTesting frm = new iPosReporting.FRptTesting();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "93":
                    {
                        WFImprimirEtiquetas frm = new WFImprimirEtiquetas();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "94":
                    {
                        WFEstados frm = new WFEstados();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "95":
                    {
                        WFUnidades frm = new WFUnidades();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "96":
                    {
                        WFMontoMonedero frm = new WFMontoMonedero();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "97":
                    {
                        WFPromociones frm = new WFPromociones();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "136":
                    {
                        iPos.Reportes.WFTrasladoXSucursal frm = new iPos.Reportes.WFTrasladoXSucursal();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "138":
                    {
                        WFTipoTicket frm = new WFTipoTicket();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "139":
                    {
                        WFReportes frm = new WFReportes();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "140":
                    {
                        iPos.CortesDelDiaConAjuste frm = new iPos.CortesDelDiaConAjuste();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "141":
                    {
                        WFImprimirCorteCortoConAjuste fr = new WFImprimirCorteCortoConAjuste();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "143":
                    {
                        iPos.Reportes.Ventas.WFReporteDescuentosCajero fr = new iPos.Reportes.Ventas.WFReporteDescuentosCajero();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "144":
                    {
                        iPos.WFImportarOrdenes fr = new iPos.WFImportarOrdenes(DBValues._DOCTO_TIPO_RECEPCIONORDEN_COMPRA);
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "101":
                    {
                        WFReimprimirFacturaElectronica fr = new WFReimprimirFacturaElectronica();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "113":
                    {
                        iPos.Reportes.WFClienteEstadoCuenta fr = new iPos.Reportes.WFClienteEstadoCuenta();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "114":
                    {
                        iPos.Reportes.WFClienteXProducto fr = new iPos.Reportes.WFClienteXProducto();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "115":
                    {
                        iPos.Reportes.WFClienteXMarca fr = new iPos.Reportes.WFClienteXMarca();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "116":
                    {
                        iPos.Reportes.WFClienteXLinea fr = new iPos.Reportes.WFClienteXLinea();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "118":
                    {
                        MostrarReporte("InformeCatalogoProveedores.frx");
                        break;
                    }




                case "122":
                    {
                        iPos.Reportes.WFProductosXLinea fr = new iPos.Reportes.WFProductosXLinea();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }



                case "121":
                    {
                        iPos.Reportes.WFProductosListaPrecios fr = new iPos.Reportes.WFProductosListaPrecios();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "117":
                    {
                        iPos.Reportes.WFInformeVendedores fr = new iPos.Reportes.WFInformeVendedores();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "120":
                    {
                        iPos.Reportes.WFInformeCatalogoProductos fr = new iPos.Reportes.WFInformeCatalogoProductos();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "132":
                case "123":
                    {
                        iPos.Reportes.WFVentaXLinea fr = new iPos.Reportes.WFVentaXLinea();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "128":
                    {
                        iPos.Reportes.WFComprasXLinea fr = new iPos.Reportes.WFComprasXLinea();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "127":
                    {
                        iPos.Reportes.WFComprasXMarca fr = new iPos.Reportes.WFComprasXMarca();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "134":
                    {
                        iPos.Reportes.WFVentaXProveedor fr = new iPos.Reportes.WFVentaXProveedor();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "131":
                    {
                        iPos.Reportes.WFVentaXCliente fr = new iPos.Reportes.WFVentaXCliente();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "135":
                    {
                        iPos.Reportes.WFVentaXVendedor fr = new iPos.Reportes.WFVentaXVendedor();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "129":
                    {
                        iPos.Reportes.WFInformeNotasDeCredito fr = new iPos.Reportes.WFInformeNotasDeCredito();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "130":
                    {
                        iPos.Reportes.WFInformeRecepcionTraslado fr = new iPos.Reportes.WFInformeRecepcionTraslado();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "126":
                    {
                        iPos.Reportes.WFComprasXProducto fr = new iPos.Reportes.WFComprasXProducto();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }



                case "133":
                case "125":
                    {
                        iPos.Reportes.WFVentaXMarca fr = new iPos.Reportes.WFVentaXMarca();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "124":
                    {
                        iPos.Reportes.WFProductosXMarca fr = new iPos.Reportes.WFProductosXMarca();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "145":
                    {
                        iPosReporting.FRptVentasConSaldo fr = new iPosReporting.FRptVentasConSaldo();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "146":
                    {
                        iPos.Reportes.WFVentaXVendedorDelCliente fr = new iPos.Reportes.WFVentaXVendedorDelCliente();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "147":
                    {

                        WFAnticipos frm = new WFAnticipos(tipoTransaccionV.t_compra);
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;



                    }

                case "148":
                    {
                        WFAnticipos fr = new WFAnticipos();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }


                case "149":
                    {
                        iPos.Reportes.WFClienteXVendedor fr = new iPos.Reportes.WFClienteXVendedor();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "150":
                    {
                        FRptInventarioXAlmacen frm = new FRptInventarioXAlmacen();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "151":
                    {
                        WFQuotaMgmt frm = new WFQuotaMgmt();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "152":
                    {
                        iPos.Reportes.WFQuotaXVendedor frm = new iPos.Reportes.WFQuotaXVendedor();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "153":
                    {
                        iPos.WFUtilidadesAsignar frm = new iPos.WFUtilidadesAsignar();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "154":
                    {

                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {
                            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                            {
                                iPos.WFImportacionInicialMovil_2 frm = new iPos.WFImportacionInicialMovil_2();
                                frm.ShowDialog();
                                frm.Dispose();
                                GC.SuppressFinalize(frm);

                            }
                            else
                            {
                                iPos.WFImportacionInicialMovil frm = new iPos.WFImportacionInicialMovil();
                                frm.ShowDialog();
                                frm.Dispose();
                                GC.SuppressFinalize(frm);

                            }
                        }

                        break;
                    }

                case "156":
                    {
                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {
                            iPos.WFResumenMovilSync frm = new iPos.WFResumenMovilSync();
                            frm.ShowDialog();
                            frm.Dispose();
                            GC.SuppressFinalize(frm);
                        }
                        break;
                    }


                case "157":
                    {
                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {
                            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                            {

                                iPos.WFExportacionFinalMovil_02 frm = new iPos.WFExportacionFinalMovil_02();
                                frm.ShowDialog();
                                frm.Dispose();
                                GC.SuppressFinalize(frm);
                            }
                            else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                            {

                                iPos.WFExportacionFinalMovil_3 frm = new iPos.WFExportacionFinalMovil_3();
                                frm.ShowDialog();
                                frm.Dispose();
                                GC.SuppressFinalize(frm);
                            }
                            else
                            {
                                iPos.WFExportacionFinalMovil frm = new iPos.WFExportacionFinalMovil();
                                frm.ShowDialog();
                                frm.Dispose();
                                GC.SuppressFinalize(frm);
                            }
                        }
                        break;
                    }
                case "158":
                    {
                        iPos.Reportes.WFInformeProductosStock frm = new iPos.Reportes.WFInformeProductosStock();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case "159":
                    {
                        MostrarReporte("InformeCorteCajaXCajero.frx");
                        break;
                    }
                case "160":
                    {
                        MostrarReporte("InformeCobranzaAplicadaXCajero.frx");
                        break;
                    }
                case "161":
                    {
                        MostrarReporte("InformeCarteraVencida.frx");
                        break;
                    }


                case "162":
                    {
                        iPosReporting.FRptVentasXCorte wf = new iPosReporting.FRptVentasXCorte();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                        break;
                    }
                case "163":
                    {
                        iPosReporting.FRptVentasXCorteDetalle wf = new iPosReporting.FRptVentasXCorteDetalle();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                        break;
                    }
                case "164":
                    {
                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {

                            iPos.WFCobranzaMovil wf = new iPos.WFCobranzaMovil();
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }
                        break;
                    }
                case "165":
                    {

                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {
                            iPos.WFPagoMovilList wf = new iPos.WFPagoMovilList();
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }
                        break;
                    }
                case "166":
                    {

                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {
                            iPos.Movil.WFMovilReportes wf = new iPos.Movil.WFMovilReportes();
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }
                        break;
                    }

                case "167":
                    {

                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {
                            WFMovilLocalRemote wf = new WFMovilLocalRemote();
                            wf.ShowDialog();
                            wf.Dispose();
                            GC.SuppressFinalize(wf);
                        }
                        break;
                    }

                case "168":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeInventarioXFecha.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "169":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeCambioPreciosMovil.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "170":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeInventarioActual.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "171":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeInventarioHistorico.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "172":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeInventarioHistoricoResumen.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "173":
                    {

                        iPos.WFCancelacionDocumentos rp = new WFCancelacionDocumentos();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "174":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("MasVendidos.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "175":
                    {

                        if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL != null && CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S"))
                        {

                            if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 2)
                            {

                                iPos.WFUpdateProductosMovil_2 rp = new iPos.WFUpdateProductosMovil_2();
                                rp.ShowDialog();
                                rp.Dispose();
                                GC.SuppressFinalize(rp);
                            }
                            else if (CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 3 || CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                            {

                                iPos.WFUpdateProductosMovil_3 rp = new iPos.WFUpdateProductosMovil_3();
                                rp.ShowDialog();
                                rp.Dispose();
                                GC.SuppressFinalize(rp);
                            }
                            else
                            {

                                iPos.WFUpdateProductosMovil rp = new iPos.WFUpdateProductosMovil();
                                rp.ShowDialog();
                                rp.Dispose();
                                GC.SuppressFinalize(rp);
                            }
                        }
                        break;
                    }
                case "176":
                    {

                        iPos.WFMovilVisita rp = new iPos.WFMovilVisita();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "177":
                    {

                        iPos.Reportes.WFMovimientosXProductoLote rp = new iPos.Reportes.WFMovimientosXProductoLote();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "179":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeRecetasDetalle.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "180":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeVentasXDiaConUtilidad.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "181":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeProductosXCaducar.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "183":
                    {

                        iPos.WFEnsambleKit rp = new iPos.WFEnsambleKit();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "184":
                    {

                        iPos.WFDesEnsambleKit rp = new iPos.WFDesEnsambleKit();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "185":
                    {

                        iPos.WFCancelacionApartados rp = new iPos.WFCancelacionApartados();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "186":
                    {

                        iPos.WFCambioVenceTrans rp = new iPos.WFCambioVenceTrans();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "187":
                    {

                        iPos.WFAutorizacioRebaja rp = new iPos.WFAutorizacioRebaja();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "188":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeRebajasAuth.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }



                case "189":
                    {

                        iPos.WFMovimAnaqueles rp = new WFMovimAnaqueles();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "191":
                    {

                        iPos.Cobranza.WFBitacoraCobranzaList rp = new iPos.Cobranza.WFBitacoraCobranzaList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "192":
                    {

                        if(CurrentUserID.CurrentParameters.ITIPOVENDEDORMOVIL == 4)
                        {

                            iPos.Movil.WFMovilSolicitarArchivosRemotos3 rp = new iPos.Movil.WFMovilSolicitarArchivosRemotos3();
                            rp.ShowDialog();
                            rp.Dispose();
                            GC.SuppressFinalize(rp);
                        }
                        else
                        {

                            iPos.WFMovilSolicitarArchivosRemotos rp = new iPos.WFMovilSolicitarArchivosRemotos();
                            rp.ShowDialog();
                            rp.Dispose();
                            GC.SuppressFinalize(rp);
                        }
                        break;
                    }

                case "193":
                    {

                        iPos.WFPreciosTemp rp = new iPos.WFPreciosTemp();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "194":
                    {

                        iPos.WFContraRecibosList rp = new iPos.WFContraRecibosList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "195":
                case "372":
                    {

                        iPos.WFSurtidoVentasMoviles rp = new iPos.WFSurtidoVentasMoviles();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "196":
                    {

                        iPos.WFFacturasMovilesConError rp = new iPos.WFFacturasMovilesConError();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "197":
                    {

                        iPos.WFPedidosMovilesNoProcesados rp = new iPos.WFPedidosMovilesNoProcesados();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "198":
                    {

                        iPos.WFSurtirPedido rp = new iPos.WFSurtirPedido();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }



                case "199":
                    {

                        iPos.WFVentasConErrorDeSurtido rp = new iPos.WFVentasConErrorDeSurtido();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "200":
                    {

                        iPos.WFIntercambioLotes rp = new iPos.WFIntercambioLotes();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "203":
                    {

                        iPos.WFConsolidado rp = new iPos.WFConsolidado();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "204":
                    {

                        iPos.WFConsultaConsolidado rp = new iPos.WFConsultaConsolidado();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "205":
                    {

                        iPos.WFConsultaOrdenesCompra rp = new iPos.WFConsultaOrdenesCompra();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }




                case "207":
                    {

                        iPos.WFEstadisticosProductoVenta rp = new iPos.WFEstadisticosProductoVenta();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "208":
                    {

                        iPos.WFEstadisticosProductoCompra rp = new iPos.WFEstadisticosProductoCompra();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "209":
                    {

                        iPos.WFEstadisticosClienteVenta rp = new iPos.WFEstadisticosClienteVenta();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "210":
                    {

                        iPos.WFEstadisticosProveedorCompra rp = new iPos.WFEstadisticosProveedorCompra();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "211":
                    {

                        WFLogItems wfLogItems = new WFLogItems("Producto");
                        wfLogItems.ShowDialog();
                        wfLogItems.Dispose();
                        GC.SuppressFinalize(wfLogItems);
                        break;
                    }

                case "212":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeEntradasSalidasReqReceta.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "213":
                    {

                        WFGruposUsuario rp = new WFGruposUsuario();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "214":
                    {
                        WFRespaldosSucursales respaldos = new WFRespaldosSucursales();
                        respaldos.ShowDialog();
                        respaldos.Dispose();
                        GC.SuppressFinalize(respaldos);

                        break;
                    }

                case "215":
                    {
                        WFProveedorSaldo wfProveedorSaldo = new WFProveedorSaldo();
                        wfProveedorSaldo.ShowDialog();
                        /* iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeSaldosProveedor.frx", FastReportsTipoFile.desistema));
                         rp.ShowDialog();*/
                        wfProveedorSaldo.Dispose();
                        GC.SuppressFinalize(wfProveedorSaldo);
                        break;
                    }

                case "216":
                    {


                        WFGastos rp = new WFGastos();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "217":
                    {

                        WFCuentas rp = new WFCuentas();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "219":
                    {

                        WFRetirosDeCajaList rp = new WFRetirosDeCajaList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "220":
                    {

                        WFReciboGastoList rp = new WFReciboGastoList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "222":
                    {

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        string strReporte = "InformeEstatisticosVentaXProd.frx";

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);

                        break;
                    }



                case "221":
                    {

                        iPos.Reportes.Catalogos.WFInformeProductosMula rp = new iPos.Reportes.Catalogos.WFInformeProductosMula();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "223":
                    {

                        iPos.Contabilidad.WFGenerarPolizas rp = new iPos.Contabilidad.WFGenerarPolizas();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "224":
                    {

                        WFOtrasEntradas rp = new WFOtrasEntradas();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "225":
                    {

                        WFOtrasSalidas rp = new WFOtrasSalidas(DBValues._DOCTO_TIPO_OTRASSALIDAS);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "226":
                    {

                        WFTipoTransacciones rp = new WFTipoTransacciones();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "227":
                    {

                        WFVerificarCXCPedido rp = new WFVerificarCXCPedido();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "228":
                    {
                        try
                        {
                            CSUCURSALD suc = new CSUCURSALD();
                            CSUCURSALBE[] sucs = new CSUCURSALBE[] { };
                            string cadena = "";
                            string sucFueraReport = "";
                            sucs = suc.seleccionarSUCURSALES();
                            //initial catalog=C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\IPOSDB.fdb;
                            //server=localhost;user id=sysdba;password=masterkey
                            for (int i = 0; i < sucs.Length; i++)
                            {
                                if (sucs[i].INOMBRERESPALDOBD != null && sucs[i].INOMBRERESPALDOBD != "")
                                {
                                    if (sucs[i].IRUTARESPALDORED != null && sucs[i].IRUTARESPALDORED != "")
                                    {
                                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDORED + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                                    }
                                    else
                                    {
                                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDODESTINO + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                                    }

                                }
                                else
                                {
                                    sucFueraReport += sucs[i].INOMBRE + "\n";
                                }
                            }


                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary.Add("conexiones", cadena);
                            dictionary.Add("fechaini", DateTime.Today);
                            dictionary.Add("fechafin", DateTime.Today);
                            string strReporte = "InformeVentasXDiaConUtilidadMultiSucursal.frx";

                            if (sucFueraReport.Length > 1)
                            {
                                MessageBox.Show("Las siguientes sucursales no se pudieron incluir en el reporte debido a que no se encuentran debidamente localizads en la ruta de destino:" +
                                sucFueraReport);
                            }

                            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                            rp.ShowDialog();
                            rp.Dispose();
                            GC.SuppressFinalize(rp);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo generar el reporte, intentelo nuevamente, verifique que todas las bases de datos se encutentren descomprimidas en la rta de destino.");
                        }


                        break;
                    }
                case "229":
                    {
                        try
                        {
                            CSUCURSALD suc = new CSUCURSALD();
                            CSUCURSALBE[] sucs = new CSUCURSALBE[] { };
                            string cadena = "";
                            string sucFueraReport = "";
                            sucs = suc.seleccionarSUCURSALES();
                            //initial catalog=C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\IPOSDB.fdb;
                            //server=localhost;user id=sysdba;password=masterkey
                            for (int i = 0; i < sucs.Length; i++)
                            {
                                if (sucs[i].INOMBRERESPALDOBD != null && sucs[i].INOMBRERESPALDOBD != "")
                                {
                                    if (sucs[i].IRUTARESPALDORED != null && sucs[i].IRUTARESPALDORED != "")
                                    {
                                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDORED + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                                    }
                                    else
                                    {
                                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDODESTINO + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                                    }

                                }
                                else
                                {
                                    sucFueraReport += sucs[i].INOMBRE + "\n";
                                }

                            }


                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary.Add("conexiones", cadena);
                            dictionary.Add("fechaini", DateTime.Today);
                            dictionary.Add("fechafin", DateTime.Today);
                            string strReporte = "InformeTrasladosXDoctoMultiSucursal.frx";

                            if (sucFueraReport.Length > 1)
                            {
                                MessageBox.Show("Las siguientes sucursales no se pudieron incluir en el reporte debido a que no se encuentran debidamente localizads en la ruta de destino:" +
                                sucFueraReport);
                            }

                            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                            rp.ShowDialog();
                            rp.Dispose();
                            GC.SuppressFinalize(rp);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo generar el reporte, intentelo nuevamente, verifique que todas las bases de datos se encutentren descomprimidas en la rta de destino.");
                        }


                        break;
                    }
                case "230":
                    {
                        try
                        {
                            CSUCURSALD suc = new CSUCURSALD();
                            CSUCURSALBE[] sucs = new CSUCURSALBE[] { };
                            string cadena = "";
                            string sucFueraReport = "";
                            sucs = suc.seleccionarSUCURSALES();
                            //initial catalog=C:\IposProject\iPosRopa\iPos\iPos\bin\Debug\sampdata\IPOSDB.fdb;
                            //server=localhost;user id=sysdba;password=masterkey
                            for (int i = 0; i < sucs.Length; i++)
                            {
                                if (sucs[i].INOMBRERESPALDOBD != null && sucs[i].INOMBRERESPALDOBD != "")
                                {
                                    if (sucs[i].IRUTARESPALDORED != null && sucs[i].IRUTARESPALDORED != "")
                                    {
                                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDORED + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                                    }
                                    else
                                    {
                                        cadena += "initial catalog=" + sucs[i].IRUTARESPALDODESTINO + @"\" + sucs[i].INOMBRERESPALDOBD + ".fdb;" +
                                        "server=" + CurrentUserID.CurrentCompania.IEM_SERVER + ";user id=sysdba;password=masterkey";
                                    }
                                }
                                else
                                {
                                    sucFueraReport += sucs[i].INOMBRE + "\n";
                                }

                            }


                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary.Add("conexiones", cadena);
                            string strReporte = "InformeUltimaVentaMultiSucursal.frx";

                            if (sucFueraReport.Length > 1)
                            {
                                MessageBox.Show("Las siguientes sucursales no se pudieron incluir en el reporte debido a que no se encuentran debidamente localizads en la ruta de destino:" +
                                sucFueraReport);
                            }

                            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                            rp.ShowDialog();
                            rp.Dispose();
                            GC.SuppressFinalize(rp);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo generar el reporte, intentelo nuevamente, verifique que todas las bases de datos se encutentren descomprimidas en la rta de destino.");
                        }


                        break;
                    }



                case "232":
                    {

                        WFCajas rp = new WFCajas();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "233":
                    {

                        WFTerminalesPagoServicio rp = new WFTerminalesPagoServicio();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "235":
                    {

                        FRptImpresionPreciosXLocalidad rp = new FRptImpresionPreciosXLocalidad();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "236":
                    {
                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        string strReporte = "InformeRecargasEmida.frx";

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "234":
                    {

                        WFEntregarVentaFuturo rp = new WFEntregarVentaFuturo();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "237":
                    {
                        iPosReporting.FRptVentasSubtotales frm = new FRptVentasSubtotales(CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S") || CurrentUserID.CurrentParameters.IMANEJAKITS.Equals("S"));
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "242":
                    {

                        WFContenidos rp = new WFContenidos();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "243":
                    {

                        WFClasificas rp = new WFClasificas();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "245":
                    {

                        iPos.Reportes.Ventas.WFReporteDeVentasXRuta rp = new iPos.Reportes.Ventas.WFReporteDeVentasXRuta();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "247":
                    {

                        iPos.Reportes.Ventas.WFReporteDeConcentradoDeRuta rp = new iPos.Reportes.Ventas.WFReporteDeConcentradoDeRuta();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "246":
                    {

                        WFTipoDiferenciaInventarios rp = new WFTipoDiferenciaInventarios();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "249":
                    {
                        string esServicio = "N";
                        iPos.Reportes.Ventas.WFReporteConciliacionEmida rp = new iPos.Reportes.Ventas.WFReporteConciliacionEmida(esServicio);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }




                case "250":
                    {
                        WFMerchantPagoServicios rp = new WFMerchantPagoServicios();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "251":
                    {
                        WFClerkPagoServicios rp = new WFClerkPagoServicios();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "252":
                    {
                        string esServicio = "S";
                        iPos.Reportes.Ventas.WFReporteConciliacionEmida rp = new iPos.Reportes.Ventas.WFReporteConciliacionEmida(esServicio);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "253":
                    {
                        iPos.Reportes.WFProveedorEstadoCuenta fr = new iPos.Reportes.WFProveedorEstadoCuenta();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "254":
                    {
                        iPos.Reportes.Entradas.WFAbonoProveedores fr = new iPos.Reportes.Entradas.WFAbonoProveedores();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "255":
                    {
                        iPos.Reportes.Catalogos.WFInventarioCosteadoMultiSucursal fr = new iPos.Reportes.Catalogos.WFInventarioCosteadoMultiSucursal();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "256":
                    {
                        iPos.Reportes.Ventas.WFVentaXProveedorMultiSucursal fr = new iPos.Reportes.Ventas.WFVentaXProveedorMultiSucursal();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "257":
                    {
                        DRptDetComprasMultiSucursal fr = new DRptDetComprasMultiSucursal();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "258":
                    {
                        iPos.CortesEdicion fr = new iPos.CortesEdicion();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "262":
                    {
                        Reportes.Contabilidad.WFReciboGastoReporte2 fr = new Reportes.Contabilidad.WFReciboGastoReporte2();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "259":
                    {
                        iPos.Reportes.Entradas.WFFaltantesOrdenesCompraConHistorial fr = new iPos.Reportes.Entradas.WFFaltantesOrdenesCompraConHistorial();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "266":
                    {
                        iPos.Utilerias.Procesos.WFPagoAProveedoresPorFecha fr = new iPos.Utilerias.Procesos.WFPagoAProveedoresPorFecha();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "267":
                    {
                        iPos.Utilerias.Procesos.WFBajaSaldosMenores fr = new iPos.Utilerias.Procesos.WFBajaSaldosMenores();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "268":
                    {
                        iPos.Utilerias.WFReportePagoAProveedoresProceso fr = new iPos.Utilerias.WFReportePagoAProveedoresProceso();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "270":
                    {
                        iPos.WFReciboGastoReporteMultiSucursal fr = new iPos.WFReciboGastoReporteMultiSucursal();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "273":
                    {
                        iPos.WFGuias fr = new iPos.WFGuias();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "275":
                    {
                        iPos.Utilerias.Procesos.WFReajustarCamposProductosEmida fr = new iPos.Utilerias.Procesos.WFReajustarCamposProductosEmida();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "276":
                    {
                        iPos.Utilerias.Procesos.WFRecalcularUtilidadesTransaccionesEmida fr = new iPos.Utilerias.Procesos.WFRecalcularUtilidadesTransaccionesEmida();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "271":
                    {
                        iPos.Catalogos.WFEncargadosGuias fr = new iPos.Catalogos.WFEncargadosGuias();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "277":
                    {
                        iPos.WFExportarDatosParaInventario fr = new iPos.WFExportarDatosParaInventario();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "279":
                    {
                        iPos.Utilerias.Procesos.WFCargaDeLlavesBancomer fr = new iPos.Utilerias.Procesos.WFCargaDeLlavesBancomer();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "280":
                    {
                        string strReporte = "ReporteBancomer.frx";

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);

                        break;
                    }
                case "281":
                    {
                        iPos.Utilerias.Procesos.WFObtenerPuntosBancomer fr = new iPos.Utilerias.Procesos.WFObtenerPuntosBancomer(false);
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "283":
                    {
                        iPos.Mensajeria.WFBuzon fr = new iPos.Mensajeria.WFBuzon(CurrentUserID.CurrentUser.IID);
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "284":
                    {
                        iPos.WFMensajeEnvio fr = new iPos.WFMensajeEnvio();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "285":
                    {
                        iPos.Mensajeria.WFMensajesEnviados fr = new iPos.Mensajeria.WFMensajesEnviados();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "286":
                    {
                        iPos.Catalogos.WFAreas fr = new iPos.Catalogos.WFAreas();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "288":
                    {
                        WFImportarClientesDesdeExcel fr = new WFImportarClientesDesdeExcel();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "289":
                    {



                        WFGastosAdicionales fr = new WFGastosAdicionales();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "290":
                    {
                        iPos.Reportes.Catalogos.WFReporteInventarioXLote fr = new iPos.Reportes.Catalogos.WFReporteInventarioXLote();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "291":
                    {
                        iPos.Reportes.Contabilidad.WFReporteAperturaCierreCortes fr = new iPos.Reportes.Contabilidad.WFReporteAperturaCierreCortes();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "292":
                    {
                        WFAlmacenes fr = new WFAlmacenes();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "293":
                    {
                        WFReporteTransBancomer form = new WFReporteTransBancomer();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }
                case "295":
                    {
                        WFPlazos fr = new WFPlazos();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "296":
                    {
                        WFImportarSaldosClientes fr = new WFImportarSaldosClientes();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "297":
                    {
                        iPos.Reportes.Ventas.WFReporteDeFacturacionIEPS fr = new iPos.Reportes.Ventas.WFReporteDeFacturacionIEPS();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "298":
                    {
                        iPos.Importaciones.WFPedidosXProductos fr = new iPos.Importaciones.WFPedidosXProductos();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "299":
                    {
                        iPos.WFDevolucionesAMatriz fr = new iPos.WFDevolucionesAMatriz();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "300":
                    {
                        iPos.Inventario.WFStockAlmacen fr = new iPos.Inventario.WFStockAlmacen();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }
                case "301":
                    {
                        iPos.Contabilidad.WFCuentasPVC fr = new iPos.Contabilidad.WFCuentasPVC();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "302":
                    {
                        iPos.WFExistenciaSucursalProveedor fr = new iPos.WFExistenciaSucursalProveedor();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "303":
                    {
                        WFImportarVentasDBFGiralda fr = new WFImportarVentasDBFGiralda();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "309":
                    {
                        WFTrasladoProdProm fr = new WFTrasladoProdProm();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "310":
                    {
                        WFDesTrasladoProdProm fr = new WFDesTrasladoProdProm();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "311":
                    {
                        iPos.Reportes.WFProveedorTrasladosProdPromo fr = new iPos.Reportes.WFProveedorTrasladosProdPromo();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }





                case "305":
                    {
                        WFCatalogosSatOperativos form = new WFCatalogosSatOperativos();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }
                case "306":
                    {
                        WFCatalogosSatLinea form = new WFCatalogosSatLinea();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }
                case "307":
                    {
                        WFAduanasSat form = new WFAduanasSat();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }
                case "312":
                    {
                        iPos.Reportes.Entradas.WFAbonoIntercambioProveedores form = new iPos.Reportes.Entradas.WFAbonoIntercambioProveedores();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }
                case "313":
                    {
                        WFImportarSaldosProveedorExcel form = new WFImportarSaldosProveedorExcel();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }

                case "314":
                    {
                        WFReciboDepositoList form = new WFReciboDepositoList();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }

                case "315":
                    {
                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeVentasConAutorizacionXPrecioBajo.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "316":
                    {
                        iPos.Utilerias.Procesos.WFBloquearClientesVentasVencidas wf = new iPos.Utilerias.Procesos.WFBloquearClientesVentasVencidas();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                        break;
                    }

                case "317":
                    {
                        //iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("PolizaDet.frx", FastReportsTipoFile.desistema));
                        //rp.ShowDialog();

                        MessageBox.Show("Vaya al menu de generar poliza, boton enviar pdf");
                        break;
                    }

                case "318":
                    {
                        WFAsignarDevolucionACorte rp = new WFAsignarDevolucionACorte();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "319":
                    {
                        iPos.Importaciones.WFGetInventarioMovil rp = new iPos.Importaciones.WFGetInventarioMovil();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "322":
                    {
                        iPos.Importaciones.WFImportacionPedidosMovil wf = new iPos.Importaciones.WFImportacionPedidosMovil();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                        break;
                    }
                case "321":
                    {
                        iPos.Movil.WFBitacoraCobranzaListMovil rp = new iPos.Movil.WFBitacoraCobranzaListMovil();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "323":
                    {
                        iPos.Movil.WFGenerarDatosParaMovil rp = new iPos.Movil.WFGenerarDatosParaMovil();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "324":
                    {
                        iPos.Movil.WFPagosPorVendedorMovil rp = new iPos.Movil.WFPagosPorVendedorMovil();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "325":
                    {

                        iPos.WFFacturasMovilesConError rp = new iPos.WFFacturasMovilesConError();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "326":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeNoSurtidosVendedorMovil.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "327":
                    {

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("CorteDetallado.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "328":
                    {

                        WFCatalogosSatUsoCFDIOperativo rp = new WFCatalogosSatUsoCFDIOperativo();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "329":
                    {

                        Contabilidad.WFCuentasBancos rp = new Contabilidad.WFCuentasBancos();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "330":
                    {

                        iPos.WFPagosCompuestosList rp = new iPos.WFPagosCompuestosList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "331":
                    {


                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("RecuperacionCobranzaPorMes.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "332":
                    {


                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("MasVendidosListaPrecio.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "333":
                    {


                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("ComisionesXProd.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "334":
                    {

                        WFEditarClaveProductoSat form = new WFEditarClaveProductoSat();
                        form.ShowDialog();
                        form.Dispose();
                        GC.SuppressFinalize(form);
                        break;
                    }
                case "335":
                    {

                        WFAsignacionProdSat filtro = new WFAsignacionProdSat();
                        filtro.Show();
                        filtro.Dispose();
                        GC.SuppressFinalize(filtro);
                        break;
                    }
                case "336":
                    {

                        WFListaPrecios filtro = new WFListaPrecios();
                        filtro.Show();
                        break;
                    }

                case "337":
                    {

                        WFMaxFactEdicion maxFact = new WFMaxFactEdicion();
                        maxFact.Show();
                        break;
                    }



                case "340":
                    {

                        WFReasignarTotalesSinVale maxFact = new WFReasignarTotalesSinVale();
                        maxFact.Show();
                        break;
                    }

                 case "341":
                    {

                        WFFondeoCajaList form = new WFFondeoCajaList();
                        form.Show();
                        break;
                    }


                case "342":
                    {
                        WFAsignarDevolucionACorte rp = new WFAsignarDevolucionACorte(DBValues._DOCTO_TIPO_CANCELACION);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "343":
                    {


                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeVentasXHoraXSucursal.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "344":
                    {


                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeVentasADomicilio.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "345":
                    {
                        iPos.WFAbonos frm = new iPos.WFAbonos(tipoTransaccionV.t_compraSucursal);
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "346":
                    {
                        iPos.WFPagoCompProveeList frm = new iPos.WFPagoCompProveeList();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "371":
                    {
                        iPos.WFPagoCompProveeList frm = new iPos.WFPagoCompProveeList(false);
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }


                case "347":
                    {
                        WFFactOrigCompraLst frm = new WFFactOrigCompraLst();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "348":
                    {
                        iPos.Abonos.WFPagosVentasCheque frm = new iPos.Abonos.WFPagosVentasCheque();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "349":
                    {
                        WFMotivoCamFecs frm = new WFMotivoCamFecs();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }

                case "350":
                    {


                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("ComisionesTipo2.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "351":
                    {


                        WFReporteComprasSuc rp = new WFReporteComprasSuc();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "352":
                    {


                        WFReporteFactCompraSuc rp = new WFReporteFactCompraSuc();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "353":
                    {


                        WFDiarioGeneral1 rp = new WFDiarioGeneral1();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "354":
                    {


                        WFEliminacionDocPendientes rp = new WFEliminacionDocPendientes();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "355":
                    {
                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeReversionAbonos.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "356":
                    {
                        WFRevisarPedido rp = new WFRevisarPedido() ;
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "357":
                    {
                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeIncidencias.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "358":
                    {
                        WFSubTipoClientes rp = new WFSubTipoClientes() ;
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "359":
                    {
                        iPos.Exportaciones.WFExportarCubo rp = new iPos.Exportaciones.WFExportarCubo();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "360":
                    {
                        WFMovtosCompraProd rp = new WFMovtosCompraProd();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "361":
                    {
                        WFAutorizacioRebajaMovil rp = new WFAutorizacioRebajaMovil();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "362":
                    {
                        WFVerificarCXCPedidoMovil rp = new WFVerificarCXCPedidoMovil();
                        rp.WindowState = FormWindowState.Maximized;
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }



                case "363":
                    {
                        WFSolicitudMercanciaList rp = new WFSolicitudMercanciaList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "364":
                    {
                        WFCorteRecoleccionList rp = new WFCorteRecoleccionList();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "365":
                    {
                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("ReporteCorteRecoleccion.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }
                case "366":
                    {
                        WFEncargadosCortes rp = new WFEncargadosCortes();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "367":
                    {

                        Dictionary<string, object> dictionary = new Dictionary<string, object>();
                        string strReporte = "InformeAbonosPorReferencia.frx";

                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);

                        break;
                    }

                case "368":
                    {
                        iPos.Importaciones.WFImportacionPedidosMovil wf = new iPos.Importaciones.WFImportacionPedidosMovil((int)DBValues._DOCTO_TIPO_COMPRAMOVIL);
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                        break;
                    }


                case "369":
                    {
                        WFAutorizacioRebajaMovil rp = new WFAutorizacioRebajaMovil(DBValues._ESTADOREBAJA_PENDIENTEXPRECIOMIN);
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                case "370":
                    {
                        WFVehiculos fr = new WFVehiculos();
                        fr.ShowDialog();
                        fr.Dispose();
                        GC.SuppressFinalize(fr);
                        break;
                    }

                case "373":
                    {

                        iPos.WFValidarFirmaDocumento rp = new iPos.WFValidarFirmaDocumento();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "374":
                    {
                        WFTipoGastos rp = new WFTipoGastos();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "375":
                    {
                        WFCentroCostos rp = new WFCentroCostos();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "376":
                    {
                        WFAsignaVentasEspeciales rp = new WFAsignaVentasEspeciales();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "377":
                    {
                        WFSat_colonias rp = new WFSat_colonias();
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }

                case "378":
                    {
                        iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile("InformeNoSurtidosSolicitudTraslado.frx", FastReportsTipoFile.desistema));
                        rp.ShowDialog();
                        rp.Dispose();
                        GC.SuppressFinalize(rp);
                        break;
                    }


                default:
                    break;
            }
        }

        private void MenuItemClick(object sender, EventArgs e)
        {

            DynamicMenuItem item = (DynamicMenuItem)sender;
            MenuItemClickEvent(item.Data.ToString());
        }
        private void menuItem1_Click(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void BTProductos_Click(object sender, EventArgs e)
        {
            LOOKPROD wf = new LOOKPROD();
            wf.m_bMostrarDescontinuados = true; 
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (CurrentUserID.CurrentParameters.IESVENDEDORMOVIL.Equals("S") &&
                                (CurrentUserID.CurrentParameters.ISCREENCONFIG == 1 || CurrentUserID.CurrentParameters.ISCREENCONFIG == 2))
            {
                WFMovilPuntoDeVenta frm = new WFMovilPuntoDeVenta();
                frm.ShowDialog();
                frm.Dispose();
                GC.SuppressFinalize(frm);
            }
            else
            {

                try
                {
                    WFPuntoDeVenta frm = new WFPuntoDeVenta();
                    frm.ShowDialog();
                    frm.Dispose();
                    GC.SuppressFinalize(frm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "   " + ex.StackTrace);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            WFListaInventarios frm = new WFListaInventarios();
            frm.ShowDialog();
            frm.Dispose();
            GC.SuppressFinalize(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            switch (DBValues._IPOSTYPE)
            {
                case (int)IposTypes.FARMA23:
                    {
                        iPos.WFImportarDeExcel frm = new iPos.WFImportarDeExcel();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case (int)IposTypes.FARMAFREE:
                    {

                        WFImportar frm = new WFImportar();
                        frm.Show();
                        break;
                    }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (DBValues._IPOSTYPE)
            {
                case (int)IposTypes.FARMA23:
                    {
                        iPos.WFExportarAExcel frm = new iPos.WFExportarAExcel();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
                case (int)IposTypes.FARMAFREE:
                    {

                        iPos.WFExportarTodo frm = new iPos.WFExportarTodo();
                        frm.ShowDialog();
                        frm.Dispose();
                        GC.SuppressFinalize(frm);
                        break;
                    }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            DateTime fechaCorteActiva = DateTime.MinValue;
            if (corteD.HayCorteActivo(iPos.CurrentUserID.CurrentUser.IID, null, ref fechaCorteActiva))
            {*/
                CorteCerrar frm = new CorteCerrar();
                frm.ShowDialog();
                frm.Dispose();
                GC.SuppressFinalize(frm);
            /* }
             else
             {

                 CorteAbrir frm = new CorteAbrir();
                 frm.ShowDialog();
             }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WFImprimirCorteCorto fr = new WFImprimirCorteCorto();
            fr.ShowDialog();
            fr.Dispose();
            GC.SuppressFinalize(fr);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            iPos.WFRetiros frm = new iPos.WFRetiros();
            frm.ShowDialog();
            frm.Dispose();
            GC.SuppressFinalize(frm);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            DateTime fechaCorteActiva = DateTime.MinValue;
            if (corteD.HayCorteActivo(iPos.CurrentUserID.CurrentUser.IID, null, ref fechaCorteActiva))
            {

                iPos.CorteBilletes wf = new iPos.CorteBilletes();
                //iPos.CorteBilletes wf = new iPos.CorteBilletes(1320, 863, true);
                wf.Fm = this;
                wf.ShowDialog();
                wf.Dispose();
                GC.SuppressFinalize(wf);
            }
            else
            {

                CorteAbrir frm = new CorteAbrir();
                frm.ShowDialog();
                frm.Dispose();
                GC.SuppressFinalize(frm);
            }
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
        //    fileToolStripMenuItem.ForeColor = Color.Red;
            //this.MainMenuStrip.ForeColor = Color.Red; 
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            DateTime fechaCorte = DateTime.MinValue;
            if(!m_cambiandoEmpresa)
            {
                if (pvd.HayCorteActivo(ref fechaCorte, iPos.CurrentUserID.CurrentUser.IID))
                {

                    if (MessageBox.Show("Desea cerrar el corte?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        CorteCerrar wf = new CorteCerrar();
                        wf.ShowDialog();
                        wf.Dispose();
                        GC.SuppressFinalize(wf);
                    }

                }
                if (MessageBox.Show("Desea realmente cerrar la aplicacion?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }


            WFClosingWait wfc = new WFClosingWait();
            wfc.Show();
            hiloImp.DetenerImportacionDeArchivos();
            hiloExist.DetenerHiloExistencias();

            hiloFactMovil.DetenerFacturacionMovil();
            hiloTotalizados.DetenerHiloTotalizados();
            hiloMensajes.DetenerHiloMensajes();
            hiloAutoCompletes.DetenerHiloAutoCompletes();
            hiloMovil3.DetenerHiloMovil3();
            DetenerThreadCatalogoSat();
            //hiloPPC.DetenerHiloPPC();
            wfc.Close();
        }



        private static void MostrarReporte(string reporteNombreEnSistema)
        {



            try
            {
                string reporteRuta = FastReportsConfig.getPathForFile(reporteNombreEnSistema, FastReportsTipoFile.desistema);
                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(reporteRuta);
                    rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error " + ex.Message + ex.StackTrace);
            }

        }

        private void BTClientes_Click(object sender, EventArgs e)
        {

            WFClientes wf = new WFClientes();
            wf.Owner = this;
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void BTProveedores_Click(object sender, EventArgs e)
        {
            WFProveedores wf = new WFProveedores();
            wf.ShowDialog();
            wf.Dispose();
            GC.SuppressFinalize(wf);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

            /**winforms only starts**/
            iPos.CurrentUserID.mainWinSize = this.Size;
            /**winforms only ends**/
        }

        private void LlenarMenuItemPorUsuario(long usuarioId)
        {
            try
            {
                this.mENUITEMSTableAdapter.Fill(this.dSAccessControl.MENUITEMS, (int)usuarioId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private DataRow[] GetChild_MENUITEMS(int idParent)
        {
            return this.dSAccessControl.MENUITEMS.Select(string.Format("{0} = {1} ", "MN_IDPARENT", idParent.ToString()));


        }

        private void btnCambiarEmpresa_Click(object sender, EventArgs e)
        {
            m_cambiandoEmpresa = true;
            this.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }







        /*private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F1:
                    WFChecadorPrecio wf = new WFChecadorPrecio();
                    wf.ShowDialog();
                    wf.Dispose();
                    GC.SuppressFinalize(wf);
                    break;
            }
        }*/



    }
}