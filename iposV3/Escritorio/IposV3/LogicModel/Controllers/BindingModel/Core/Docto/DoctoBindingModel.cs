
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
    public class DoctoBindingModel: DoctoBindingModelGenerated
    {


        public DoctoBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public DoctoBindingModel(Docto item):base(item)
        {
        }

        public DoctoBindingModel(Docto item, Docto itemSecondaryInfo) : this(MergeDoctoInfo(item, itemSecondaryInfo))
        {


        }

        public static Docto MergeDoctoInfo(Docto item, Docto itemSecondaryInfo)
        {
            var retorno = item;

            retorno.Docto_fact_elect_consolidacion = itemSecondaryInfo.Docto_fact_elect_consolidacion;
            retorno.Docto_fact_elect_pagos = itemSecondaryInfo.Docto_fact_elect_pagos;
            retorno.Docto_fact_elect_sustitucion = itemSecondaryInfo.Docto_fact_elect_sustitucion;
            retorno.Docto_poliza = itemSecondaryInfo.Docto_poliza;
            retorno.Docto_kit = itemSecondaryInfo.Docto_kit;
            retorno.Docto_ventafuturo = itemSecondaryInfo.Docto_ventafuturo;
            retorno.Docto_guia = itemSecondaryInfo.Docto_guia;
            retorno.Docto_info_pago = itemSecondaryInfo.Docto_info_pago;
            return retorno;
        }
        #endif




    }
}

