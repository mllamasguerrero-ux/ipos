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
    public class PerfilDerechoItemBindingModel : Validatable
    {

        public PerfilDerechoItemBindingModel()
        {
            FillCatalogRelatedFields();
        }


#if PROYECTO_WEB
        public PerfilDerechoItemBindingModel(Derechos derecho) : this()
        {

            _Dr_derecho = derecho.Id;
            _Dr_descripcion = derecho.Descripcion;
            _Permitido = false;
            _Id = null;
        }


        public PerfilDerechoItemBindingModel(Perfil_der perfil_der) : this()
        {

            _Dr_derecho = perfil_der.Derechoid;
            _Dr_descripcion = perfil_der?.Derecho?.Descripcion;
            _Permitido = true;
            _Id = perfil_der?.Id;
        }
#endif





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


#if PROYECTO_WEB
        public static List<PerfilDerechoItemBindingModel> GetPerfilesDerechosList(List<Derechos> derechosList, List<Perfil_der> perfilDerList)
        {
            var listPefilesDerechos = derechosList.Select(derecho => new PerfilDerechoItemBindingModel(derecho)).ToList();

            foreach (var perfilDer in perfilDerList)
            {
                var buffer = listPefilesDerechos.FirstOrDefault(x => x.Dr_derecho == perfilDer.Derechoid);
                if (buffer != null)
                    buffer.Permitido = true;
            }




            return listPefilesDerechos;
        }
#endif




    }
}
