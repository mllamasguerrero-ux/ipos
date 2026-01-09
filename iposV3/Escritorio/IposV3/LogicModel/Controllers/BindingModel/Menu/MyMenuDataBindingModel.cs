using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.BindingModel.Menu
{

    public class MyMenuDataBindingModel
    {
        private string _header = "";
        public string MyHeader
        {
            get { return _header; }
            set { _header = value; }
        }

        private int _menuid = -1;
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        private List<MyMenuDataBindingModel> _subitems = new List<MyMenuDataBindingModel>();
        public List<MyMenuDataBindingModel> SubItems
        {
            get { return _subitems; }
            set { _subitems = value; }
        }
        

    }
}
