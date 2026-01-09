
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    [XmlRoot]
    public class SearchListBindingModel<T>
    {

        private T? _Param;
        [XmlAttribute]
        public T? Param { get => _Param; set { _Param = value; } }

        private KendoParams? _KendoParams;
        [XmlAttribute]
        public KendoParams? KendoParams { get => _KendoParams; set { _KendoParams = value; } }



        public SearchListBindingModel() : base()
        {
        }
        public SearchListBindingModel(T? param, KendoParams? kendoParams)
        {
            _Param = param;
            _KendoParams = kendoParams;
        }



    }


    [XmlRoot]
    public class SelectParamBindingModel<T>
    {

        private T _Param;
        [XmlAttribute]
        public T Param { get => _Param; set { _Param = value; } }


        public string _Search;
        [XmlAttribute]
        public string Search { get => _Search; set { _Search = value; } }

        public string _FieldsSearching;
        [XmlAttribute]
        public string FieldsSearching { get => _FieldsSearching; set { _FieldsSearching = value; } }


        public SelectParamBindingModel(T param, string search, string fieldsSearching)
        {
            _Param = param;
            _Search = search;
            _FieldsSearching = fieldsSearching;
        }



    }
}