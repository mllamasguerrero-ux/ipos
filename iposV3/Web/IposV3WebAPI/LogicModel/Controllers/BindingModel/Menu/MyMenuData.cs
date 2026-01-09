using Controllers.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 

namespace Controllers.BindingModel.Menu
{
    public class MyMenuData: MyMenuDataBindingModel
    {
        public MyMenuData():base()
        {

        }


        private List<MyMenuData> _subitems = new List<MyMenuData>();
        new public List<MyMenuData> SubItems
        {
            get { return _subitems; }
            set { _subitems = value; }
        }

        public MyMenuData(MyMenuDataBindingModel obj):this()
        {
            MenuId = obj.MenuId;
            MyHeader = obj.MyHeader;
            this.SubItems = obj.SubItems.Select(x => new MyMenuData(x)).ToList();
        }


        //private ICommand? _importRecentItemCommand;

        //public ICommand ImportRecentItemCommand
        //{
        //    get { return _importRecentItemCommand ?? (_importRecentItemCommand = new RelayCommand(ImportRecentItemCommandExecuted)); }
        //}

        private void ImportRecentItemCommandExecuted(object? parameter)
        {
            var mData = (MyMenuData?)parameter;
        }
        }
}
