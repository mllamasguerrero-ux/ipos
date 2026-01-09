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
    public class UsuarioPerfilItemBindingModel : Validatable
    {

        public UsuarioPerfilItemBindingModel()
        {
            FillCatalogRelatedFields();
        }


#if PROYECTO_WEB
        public UsuarioPerfilItemBindingModel(Perfiles perfil) : this()
        {

            _Perfilid = perfil.Id;
            _Perfildescripcion = perfil.Descripcion;
            _Permitido = false;
            _Id = null;
        }


        public UsuarioPerfilItemBindingModel(Usuario_perfil usuario_perfil) : this()
        {

            _Perfilid = usuario_perfil.Perfilid;
            _Perfildescripcion = usuario_perfil?.Perfil?.Descripcion;
            _Permitido = true;
            _Id = usuario_perfil?.Id;
        }
#endif


        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }



        private long? _Perfilid;
        [XmlAttribute]
        public long? Perfilid { get => _Perfilid; set { if (RaiseAcceptPendingChange(value, _Perfilid)) { _Perfilid = value; OnPropertyChanged(); } } }

        private string? _Perfildescripcion;
        [XmlAttribute]
        public string? Perfildescripcion { get => _Perfildescripcion; set { if (RaiseAcceptPendingChange(value, _Perfildescripcion)) { _Perfildescripcion = value; OnPropertyChanged(); } } }

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
        public static List<UsuarioPerfilItemBindingModel> GetUsuarioPefilList(List<Perfiles> perfilesList, List<Usuario_perfil> usuarioPerfilList)
        {
            var listUsuarioPerfiles = perfilesList.Select(perfil => new UsuarioPerfilItemBindingModel(perfil)).ToList();

            foreach (var usuarioPerfil in usuarioPerfilList)
            {
                var buffer = listUsuarioPerfiles.FirstOrDefault(x => x.Perfilid == usuarioPerfil.Perfilid);
                if (buffer != null)
                    buffer.Permitido = true;
            }




            return listUsuarioPerfiles;
        }
#endif





    }



}

