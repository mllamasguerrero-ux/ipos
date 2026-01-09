using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CatalogSelector
{
    public class CatalogRelatedFields
    {
        public CatalogRelatedFields()
        {

        }

        public CatalogRelatedFields(string? objectName, string? catalogName, string? idField, string? claveField, string? nombreField,
                                    string? listVMName, string? listVMSelectingObjectName, string? listVMSelectingFieldClaveName)
        {
            ObjectName = objectName;
            CatalogName = catalogName;
            IdField = idField;
            ClaveField = claveField;
            NombreField = nombreField;

            ListVMName = listVMName;
            ListVMSelectingObjectName = listVMSelectingObjectName;
            ListVMSelectingFieldClaveName = listVMSelectingFieldClaveName;


        }


        public CatalogRelatedFields(string? objectName, string? catalogName, string? idField, string? claveField, string? nombreField,
                                    string? listVMName, string? listVMSelectingObjectName, string? listVMSelectingFieldClaveName,
                                    string? listVMSelectingFieldNombreName): this(objectName, catalogName,  idField, claveField,  nombreField,
                                                                                 listVMName,  listVMSelectingObjectName,  listVMSelectingFieldClaveName)
        {

            ListVMSelectingFieldNombreName = listVMSelectingFieldNombreName;
        }

        public CatalogRelatedFields(string? objectName, string? catalogName, string? idField, string? claveField, string? nombreField,
                                    string? listVMName, string? listVMSelectingObjectName, string? listVMSelectingFieldClaveName,
                                    string? listVMSelectingFieldNombreName,string? listTable, string? listTitle) : this(objectName, catalogName, idField, claveField, nombreField,
                                                                                 listVMName, listVMSelectingObjectName, listVMSelectingFieldClaveName, listVMSelectingFieldNombreName)
        {

            ListTable = listTable;
            ListTitle = listTitle;
        }

        public CatalogRelatedFields(string? objectName, string? catalogName, string? idField, string? claveField, string? nombreField,
                                    string? listVMName, string? listVMSelectingObjectName, string? listVMSelectingFieldClaveName,
                                    string? listVMSelectingFieldNombreName, string? listTable, string? listTitle, object kendoParams) : this(objectName, catalogName, idField, claveField, nombreField,
                                                                                 listVMName, listVMSelectingObjectName, listVMSelectingFieldClaveName, listVMSelectingFieldNombreName, listTable, listTitle)
        {
            KendoParams = kendoParams;
        }

        public CatalogRelatedFields(string? objectName, string? catalogName, string? idField, string? claveField, string? nombreField,
                                    string? listVMName, string? listVMSelectingObjectName, string? listVMSelectingFieldClaveName,
                                    string? listVMSelectingFieldNombreName, string? listTable, string? listTitle, object kendoParams, bool mostrarPopUpIfNorFound) : this(objectName, catalogName, idField, claveField, nombreField,
                                                                                 listVMName, listVMSelectingObjectName, listVMSelectingFieldClaveName, listVMSelectingFieldNombreName, listTable, listTitle, kendoParams)
        {
            MostrarPopUpIfNorFound = mostrarPopUpIfNorFound;
        }

        public string? ObjectName { get; set; }
        public string? CatalogName { get; set; }
        public string? IdField { get; set; }
        public string? ClaveField { get; set; }
        public string? NombreField { get; set; }

        public string? ListVMName { get; set; }
        public string? ListVMSelectingObjectName { get; set; }
        public string? ListVMSelectingFieldClaveName { get; set; }
        public string? ListVMSelectingFieldNombreName { get; set; }

        public string? ListTable { get; set; }
        public string? ListTitle { get; set; }

        public object? KendoParams { get; set; }

        public bool MostrarPopUpIfNorFound { get; set; } = true;

    }
}
