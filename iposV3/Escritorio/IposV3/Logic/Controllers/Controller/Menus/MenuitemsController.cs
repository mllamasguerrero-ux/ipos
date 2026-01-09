using Controllers.BindingModel;
using Controllers.BindingModel.Menu;
using DataAccess;
using IposV3.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using IposV3.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Forms;

namespace Controllers.Controller
{
    public class MenuitemsController : BaseGenericController
    {
        private OperationsContextFactory _operationsContextFactory;

        public MenuitemsController(OperationsContextFactory operationsContextFactory)
        {
            this._operationsContextFactory = operationsContextFactory;
        }

        public List<MyMenuDataBindingModel> SelectPorUsuario(long empresaId, long sucursalId, long usuarioId)
        {
            using var applicationDbContext = this._operationsContextFactory.Create();

            var data = new List<MyMenuDataBindingModel>();
            var dataDerechosIds = applicationDbContext.Usuario_perfil//.Include(d => d.Perfil).ThenInclude(p => p!.Derechos)
                .Where(y => y.EmpresaId == empresaId && y.SucursalId == sucursalId && y.Usuarioid == usuarioId)
                .Select(j => j.Perfil).Where(d => d!.Derechos != null).SelectMany(d => d!.Derechos!)
                .Select(d => d.Id).ToList();

            var menuItems = applicationDbContext.Menuitems.Where(d => d.Id >= 0 && d.Derechoid != null && dataDerechosIds!.Contains(d.Derechoid!.Value)).ToList();



            AddMenu(0, menuItems, ref data);
            return data;
        }




        public int AddMenu(int idParent , List<Menuitems>? menuItems, ref List<MyMenuDataBindingModel> data)
        {

            List<Menuitems> submenus = menuItems!.Where(x => x.Parentid == idParent).ToList();
            foreach (Menuitems fila in submenus)
            {


                if (!ValidMenu(fila.Id.ToString()))
                    continue;


                MyMenuDataBindingModel _item = new MyMenuDataBindingModel();
                _item.MyHeader = fila.Descripcion!;
                _item.MenuId = int.Parse(fila.Id.ToString());
                AddMenuRecursive(_item,  menuItems);
                data.Add(_item);

            }

            return 1;
        }
        public int AddMenuRecursive(MyMenuDataBindingModel mnuItem, List<Menuitems>? menuItems)
        {

            List<Menuitems> submenus = menuItems!.Where(x => x.Parentid == mnuItem.MenuId).ToList();

            if (submenus == null || submenus.Count == 0)
                return 0;

            foreach (Menuitems fila in submenus)
            {

                //esto es para excluir hardcoded algunos menus
                int menuID = int.Parse(fila.Id.ToString());
                bool bSkip = false;
                //foreach (int iX in DBValues._MENUS_EXCLUDED)
                //{
                //    if (iX == menuID)
                //    {
                //        bSkip = true;
                //    }
                //}


                if (!ValidMenu(fila.Id.ToString()))
                    bSkip = true;

                if (bSkip)
                    continue;

                MyMenuDataBindingModel _item = new MyMenuDataBindingModel();
                _item.MyHeader = fila.Etiqueta!;
                _item.MenuId = int.Parse(fila.Id.ToString());
                AddMenuRecursive(_item, menuItems);
                mnuItem.SubItems.Add(_item);

            }
            return 1;
        }



        public bool ValidMenu(string menu)
        {

            switch (menu)
            {
                default:
                    return true;
            }


        }
    }
}
