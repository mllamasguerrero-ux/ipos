|||||100+++++
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
    |||||110+++++
    [XmlRoot]
    public class (nombreTabla)WFBindingModel : Validatable
    {

        public (nombreTabla)WFBindingModel()
        {
            FillCatalogRelatedFields();
        }



|||||250+++++
        private (tipoCampoLenguaje)? _(nombreCampoCapitalizado);
        [XmlAttribute](requeridoXmlifnotnull)
        public (tipoCampoLenguaje)? (nombreCampoCapitalizado) { get => _(nombreCampoCapitalizado)(nullableAssignment); set { if (RaiseAcceptPendingChange(value, _(nombreCampoCapitalizado))) { _(nombreCampoCapitalizado) = value(nullableAssignment); OnPropertyChanged(); } } }
|||||460+++++
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


        public static (nombreTabla)WFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_(nombreTabla)WFBindingModel = new (nombreTabla)WFBindingModel();
|||||461+++++
        	buffer_(nombreTabla)WFBindingModel._(nombreCampoCapitalizado) = obj.(nombreCampoCapitalizado);
|||||462+++++
            return buffer_(nombreTabla)WFBindingModel;
        }


    }

    |||||510+++++
    [XmlRoot]
    public class (nombreTabla)WF_(nombreGrid)BindingModel : Validatable
    {

        public (nombreTabla)WF_(nombreGrid)BindingModel()
        {
            FillCatalogRelatedFields();
        }



|||||550+++++
        private (tipoCampoLenguaje)? _(nombreCampoCapitalizado);
        [XmlAttribute](requeridoXmlifnotnull)
        public (tipoCampoLenguaje)? (nombreCampoCapitalizado) { get => _(nombreCampoCapitalizado)(nullableAssignment); set { if (RaiseAcceptPendingChange(value, _(nombreCampoCapitalizado))) { _(nombreCampoCapitalizado) = value(nullableAssignment); OnPropertyChanged(); } } }
|||||560+++++
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

|||||570+++++
     
}

!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
110;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
250;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR
460;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
461;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR
462;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
510;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADOR_GRIDIN;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
550;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADO;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI
560;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;SI_AGRUPADOR_GRIDFI;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
570;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR


