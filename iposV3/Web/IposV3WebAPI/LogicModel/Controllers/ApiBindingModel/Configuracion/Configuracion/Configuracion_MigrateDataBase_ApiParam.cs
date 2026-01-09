
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using BindingModels;

namespace ApiParam
{
    [XmlRoot]
    
    public class Configuracion_MigrateDataBase_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Configuracion_MigrateDataBase_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Boolean? _CreateIfNotExist;
        [XmlAttribute]
        public Boolean? CreateIfNotExist { get => _CreateIfNotExist; set { _CreateIfNotExist = value;  } } 

        private String? _RutaInstalacionPostgresql;
        [XmlAttribute]
        public String? RutaInstalacionPostgresql { get => _RutaInstalacionPostgresql; set { _RutaInstalacionPostgresql = value;  } } 

        private ConfiguracionBindingModel? _Configuracion;
        [XmlAttribute]
        public ConfiguracionBindingModel? Configuracion { get => _Configuracion; set { _Configuracion = value;  } } 





    }
}

