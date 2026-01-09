
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
    public class PERFILEdicionWFBindingModel : Validatable
    {

        public PERFILEdicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Pf_descripcion;
        [XmlAttribute]
        public long? Pf_descripcion { get => _Pf_descripcion; set { if (RaiseAcceptPendingChange(value, _Pf_descripcion)) { _Pf_descripcion = value; OnPropertyChanged(); } } }

        private string? _Pf_descripcionClave;
        [XmlAttribute]
        public string? Pf_descripcionClave { get => _Pf_descripcionClave; set { if (RaiseAcceptPendingChange(value, _Pf_descripcionClave)) { _Pf_descripcionClave = value; OnPropertyChanged(); } } }

        private string? _Pf_descripcionNombre;
        [XmlAttribute]
        public string? Pf_descripcionNombre { get => _Pf_descripcionNombre; set { if (RaiseAcceptPendingChange(value, _Pf_descripcionNombre)) { _Pf_descripcionNombre = value; OnPropertyChanged(); } } }

        private string? _Tbbuscar;
        [XmlAttribute]
        public string? Tbbuscar { get => _Tbbuscar; set { if (RaiseAcceptPendingChange(value, _Tbbuscar)) { _Tbbuscar = value; OnPropertyChanged(); } } }

        private long? _Cbbuscar;
        [XmlAttribute]
        public long? Cbbuscar { get => _Cbbuscar; set { if (RaiseAcceptPendingChange(value, _Cbbuscar)) { _Cbbuscar = value; OnPropertyChanged(); } } }

        private string? _CbbuscarClave;
        [XmlAttribute]
        public string? CbbuscarClave { get => _CbbuscarClave; set { if (RaiseAcceptPendingChange(value, _CbbuscarClave)) { _CbbuscarClave = value; OnPropertyChanged(); } } }

        private string? _CbbuscarNombre;
        [XmlAttribute]
        public string? CbbuscarNombre { get => _CbbuscarNombre; set { if (RaiseAcceptPendingChange(value, _CbbuscarNombre)) { _CbbuscarNombre = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }



    }

    
    [XmlRoot]
    public class PERFILEdicionWF_Perfiles_derechosBindingModel : Validatable
    {

        public PERFILEdicionWF_Perfiles_derechosBindingModel()
        {
            FillCatalogRelatedFields();
        }

        public PERFILEdicionWF_Perfiles_derechosBindingModel(DerechosBindingModel derecho):this()
        {

            _Dr_derecho = derecho.Id;
            _Dr_descripcion = derecho.Descripcion;
            _Permitido = false;
            _Id = null;
        }


        public PERFILEdicionWF_Perfiles_derechosBindingModel(Perfil_derBindingModel perfil_der) : this()
        {

            _Dr_derecho = perfil_der.Derechoid;
            _Dr_descripcion = perfil_der?.DerechoNombre;
            _Permitido = true;
            _Id = perfil_der?.Id;
        }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }



        private long? _Dr_derecho;
        [XmlAttribute]
        public long? Dr_derecho { get => _Dr_derecho; set { if (RaiseAcceptPendingChange(value, _Dr_derecho)) { _Dr_derecho = value; OnPropertyChanged(); } } }

        private string? _Dr_descripcion;
        [XmlAttribute]
        public string? Dr_descripcion { get => _Dr_descripcion; set { if (RaiseAcceptPendingChange(value, _Dr_descripcion)) { _Dr_descripcion = value; OnPropertyChanged(); } } }

        private bool? _Permitido;
        [XmlAttribute]
        public bool? Permitido { get => _Permitido; set { if (RaiseAcceptPendingChange(value, _Permitido)) { _Permitido = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }


        public static List<PERFILEdicionWF_Perfiles_derechosBindingModel> GetPerfilesDerechosList( List<DerechosBindingModel> derechosList, List<Perfil_derBindingModel> perfilDerList  )
        {
            var listPefilesDerechos = derechosList.Select(derecho => new PERFILEdicionWF_Perfiles_derechosBindingModel(derecho)).ToList();

            foreach(var perfilDer in perfilDerList)
            {
                var buffer = listPefilesDerechos.FirstOrDefault(x => x.Dr_derecho == perfilDer.Derechoid);
                if(buffer != null)
                    buffer.Permitido = true;
            }
            



            return listPefilesDerechos;
        }



    }



}

