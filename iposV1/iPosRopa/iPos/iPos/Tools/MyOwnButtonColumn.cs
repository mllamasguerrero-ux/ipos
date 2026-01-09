using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace iPos
{
    public class MyOwnButtonCell:DataGridViewButtonCell
    {
        
        public override object DefaultNewRowValue
        {
            
            
            get
            {
            
            
                
                return "Nuevo";
            }
        }
       
       
       
       
        
        public class MyOwnButtonColumn:DataGridViewButtonColumn
        {
public MyOwnButtonColumn():base()
{
      this.CellTemplate = new MyOwnButtonCell();
}
}
}
   
}
