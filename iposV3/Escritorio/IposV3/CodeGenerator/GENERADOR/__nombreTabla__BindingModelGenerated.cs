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
    [XmlRoot]
    |||||110+++++
    public class (nombreTabla)BindingModelGenerated : Validatable, IBaseBindingModel
    |||||120+++++
    public class (nombreTabla)BindingModelGenerated : Validatable, IBaseGenericBindingModel
    |||||130+++++
    {
        
        public (nombreTabla)BindingModelGenerated()
        {
        }
        public (nombreTabla)BindingModelGenerated((nombreTabla) item)
        {
            FillFromEntity(item);
        }


        public T CreateSubEntity<T>() where T : EntityBase, new()
        {
            return new T() { EmpresaId = (long)(EmpresaId ?? 0), SucursalId = (long)(SucursalId ?? 0) };
        }

|||||200+++++
        private (tipoCampoLenguaje)? _(nombreCampoCapitalizado);
        [XmlAttribute](requeridoXmlifnotnull)
        public (tipoCampoLenguaje)? (nombreCampoCapitalizado) { get => _(nombreCampoCapitalizado)(nullableAssignment); set { if (RaiseAcceptPendingChange(value, _(nombreCampoCapitalizado))) { _(nombreCampoCapitalizado) = value(nullableAssignment); OnPropertyChanged(); } } }
|||||300+++++
        public static string GetBaseQuery()
        {
|||||310+++++
            return $@"SELECT * FROM ""(nombreTabla)"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";
|||||320+++++
            return $@"SELECT * FROM ""(nombreTabla)""  ";
|||||330+++++
        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"|||||350+++++(nombreCampoConRuta)(|)|||||400+++++";
        }


        public virtual void FillCatalogRelatedFields((nombreTabla) item)
        {
|||||450+++++
             this._(nombreCampoCapitalizado) = item.(ENTIDADCATALOGOCAMPO)?.(ENTIDADCATALOGOCAMPOREL);
|||||460+++++

        }


        public virtual void FillEntityValues(ref (nombreTabla) item)
        {

|||||500+++++
            item.(nombreCampoCapitalizado) = (nombreCampoCapitalizado) (nullableAssignment);

|||||530+++++
            if (item.(SUBENTIDADCAMPO) != null)
                item.(SUBENTIDADCAMPOFORCED)!.(SUBENTIDADCAMPOREL) = (nombreCampoCapitalizado)(nullableAssignment);
            else if (item.(SUBENTIDADCAMPO) == null && (nombreCampoCapitalizado) != null)
            {
                item.(SUBENTIDADCAMPOFORCED) = CreateSubEntity<(SUBENTIDADTIPO)>();
                item.(SUBENTIDADCAMPOFORCED)!.(SUBENTIDADCAMPOREL) = (nombreCampoCapitalizado)(nullableAssignment);
            }
|||||550+++++

        }

        public virtual void FillFromEntity((nombreTabla) item)
        {
|||||600+++++
            (nombreCampoCapitalizado) = item.(nombreCampoCapitalizado);
|||||630+++++
            if (item.(SUBENTIDADCAMPO) != null && item.(SUBENTIDADCAMPO)?.(SUBENTIDADCAMPOREL) != null)
                    (nombreCampoCapitalizado) = item.(SUBENTIDADCAMPOFORCED)!.(SUBENTIDADCAMPOREL);
|||||650+++++

             FillCatalogRelatedFields(item);


        }



    }
}

!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
110;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
120;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NOPONER;IGNORAR
130;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
200;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR
300;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
310;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;IGNORAR
320;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;YES;IGNORAR
330;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
350;1;0;IGNORAR;IGNORAR;VARCHAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;1;IGNORAR;IGNORAR;IGNORAR;IGNORAR
400;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
450;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;YES
460;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
500;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;NO
530;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;YES;NO
550;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
600;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;NO;NO
630;1;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;YES;NO
650;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
