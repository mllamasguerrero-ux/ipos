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
using System.Collections;
namespace iPos.Tools
{
    public class CustomAutoCompleteStruct
    {
        public TextBox textBox = null;
        public ListBox listBox = null;
        public AutoCompleteStringCollection collection = null;

        public CustomAutoCompleteStruct(ref TextBox _textBox,ref ListBox _listBox, ref AutoCompleteStringCollection _collection)
        {
            textBox = _textBox;
            listBox = _listBox;
            collection = _collection;
        }

    }
}
