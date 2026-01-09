using IposV3.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using DataLayer;
using static CodeGenerator.DSGeneracion;
using Controllers.Controller;

namespace CodeGenerator
{

    public class CommonGenerationLogic
    {
        List<Type> _excludingFieldTypes;
        List<String> _commonKeys;
        List<String> _commonBusqueda;
        Hashtable _list_eq;
        List<String> _foreignKeysToIgnore;
        List<String> _excludingFieldNames;
        List<String> _excludingFieldNamesInSubEntity;


        List<string> _excludingMethodNames;
        public CommonGenerationLogic()
        {


            _excludingFieldTypes = new List<Type>();
            _excludingFieldTypes.Add(typeof(Empresa));
            _excludingFieldTypes.Add(typeof(Sucursal));
            _excludingFieldTypes.Add(typeof(EntityBaseExt));
            _excludingFieldTypes.Add(typeof(EntityBaseGeneric));
            _excludingFieldTypes.Add(typeof(EntityBaseGenericCatalog));
            _excludingFieldTypes.Add(typeof(EntityBase));
            _excludingFieldTypes.Add(typeof(EntityBaseGenericPseudoCatalog));
            _excludingFieldTypes.Add(typeof(EntityBaseCatalogoSat));

            _excludingFieldNames = new List<String>();
            _excludingFieldNames.Add("CreadoPor");
            _excludingFieldNames.Add("ModificadoPor");

            _excludingFieldNamesInSubEntity = new List<String>();
            _excludingFieldNamesInSubEntity.Add("Id");
            _excludingFieldNamesInSubEntity.Add("Activo");
            _excludingFieldNamesInSubEntity.Add("EmpresaId");
            _excludingFieldNamesInSubEntity.Add("SucursalId");
            _excludingFieldNamesInSubEntity.Add("CreadoPor");
            _excludingFieldNamesInSubEntity.Add("ModificadoPor");
            _excludingFieldNamesInSubEntity.Add("Creado");
            _excludingFieldNamesInSubEntity.Add("Modificado");
            _excludingFieldNamesInSubEntity.Add("CreadoPorId");
            _excludingFieldNamesInSubEntity.Add("ModificadoPorId");

            _excludingMethodNames = new List<String>();
            _excludingMethodNames.Add("GetById");
            _excludingMethodNames.Add("GetAll");
            _excludingMethodNames.Add("SelectList");
            _excludingMethodNames.Add("Insert");
            _excludingMethodNames.Add("Select");
            _excludingMethodNames.Add("SelectById");
            _excludingMethodNames.Add("Update");
            _excludingMethodNames.Add("Delete");
            _excludingMethodNames.Add("QueryableWithIncludes");
            _excludingMethodNames.Add("Select");
            _excludingMethodNames.Add("FillDefaultSort");
            _excludingMethodNames.Add("GetType");
            _excludingMethodNames.Add("ToString");
            _excludingMethodNames.Add("Equals");
            _excludingMethodNames.Add("GetHashCode");




            _commonKeys = new List<String>();
            _commonKeys.Add("EmpresaId");
            _commonKeys.Add("SucursalId");
            _commonKeys.Add("Id");

            _commonBusqueda = new List<String>();
            _commonBusqueda.Add("Clave");
            _commonBusqueda.Add("Nombre");

            _list_eq = new Hashtable();
            _list_eq.Add("BOOL", "BOOLEAN");
            _list_eq.Add("SHORT", "SMALLINT");
            _list_eq.Add("INT", "INTEGER");
            _list_eq.Add("INT16", "SMALLINT");
            _list_eq.Add("INT32", "INTEGER");
            _list_eq.Add("INT64", "BIGINT");
            _list_eq.Add("LONG", "BIGINT");
            _list_eq.Add("FLOAT", "REAL");
            _list_eq.Add("DOUBLE", "DOUBLE PRECISION");
            _list_eq.Add("DECIMAL", "NUMERIC");
            //_list_eq.Add("DECIMAL", "MONEY");
            //_list_eq.Add("STRING", "TEXT");
            _list_eq.Add("BOOLCN", "BoolCN");
            _list_eq.Add("BOOLCNI", "BoolCNI");
            _list_eq.Add("BOOLCS", "BoolCS");
            _list_eq.Add("STRING", "VARCHAR");
            //_list_eq.Add("STRING", "CITEXT");
            //_list_eq.Add("STRING", "JSON");
            //_list_eq.Add("STRING", "JSONB");
            //_list_eq.Add("STRING", "XML");
            _list_eq.Add("NPGSQLPOINT", "POINT");
            _list_eq.Add("NPGSQLLSEG", "LSEG");
            _list_eq.Add("NPGSQLPATH", "PATH");
            _list_eq.Add("NPGSQLPOLYGON", "POLYGON");
            _list_eq.Add("NPGSQLLINE", "LINE");
            _list_eq.Add("NPGSQLCIRCLE", "CIRCLE");
            _list_eq.Add("NPGSQLBOX", "BOX");
            //_list_eq.Add("BOOL", "BIT");
            //_list_eq.Add("BOOL", "BIT VARYING");
            _list_eq.Add("GUID", "UUID");
            _list_eq.Add("PHYSICALADDRESS", "MACADDR");
            _list_eq.Add("NPGSQLTSQUERY", "TSQUERY");
            _list_eq.Add("NPGSQLTSVECTOR", "TSVECTOR");
            //_list_eq.Add("DATETIME", "DATE");
            //_list_eq.Add("STRING", "INTERVAL");
            _list_eq.Add("DATETIME", "TIMESTAMP");
            _list_eq.Add("DATETIMEOFFSET", "DateTimeOffset");
            //_list_eq.Add("STRING", "TIMESTAMP WITH TIME ZONE");
            //_list_eq.Add("DATETIME", "TIMESTAMP WITHOUT TIME ZONE");
            //_list_eq.Add("DATETIME", "TIME");
            //_list_eq.Add("STRING", "TIME WITH TIME ZONE");
            _list_eq.Add("BYTE[]", "BYTEA");
            _list_eq.Add("UINT", "OID");
            //_list_eq.Add("UINT", "XID");
            //_list_eq.Add("UINT", "CID");
            _list_eq.Add("UINT[]", "OIDVECTOR");
            //_list_eq.Add("STRING", "NAME");
            _list_eq.Add("BYTE", "(INTERNAL) CHAR");

            _foreignKeysToIgnore = new List<string>();
            _foreignKeysToIgnore.Add("Empresa");
            _foreignKeysToIgnore.Add("Sucursal");
            _foreignKeysToIgnore.Add("CreadoPor");
            _foreignKeysToIgnore.Add("ModificadoPor");
        }



        public bool IsInExcludingFieldTypes(Type type)
        {
            foreach (var exludingType in this._excludingFieldTypes)
            {
                if (exludingType.IsAssignableFrom(type))
                    return true;
            }

            var interf = type.GetInterfaces();

            if (type.FullName?.StartsWith("System.Collections.Generic.ICollection") ?? false )
                return true;


            return false;
        }


        public bool IsInExcludingFieldNames(PropertyInfo prop, bool isSubEntity)
        {
            if (isSubEntity)
            {
                return _excludingFieldNamesInSubEntity.Contains(prop.Name);
            }

            return _excludingFieldNames.Contains(prop.Name);

        }



        public string CalculateLengthType(PropertyInfo prop)
        {
            if (prop.CustomAttributes != null && prop.CustomAttributes.Count() > 0)
            {
                foreach (var attr in prop.CustomAttributes)
                {
                    //attr.ArgumentType
                    if (attr.AttributeType.IsAssignableFrom(typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute)))
                        return ((int?)attr.ConstructorArguments[0].Value ?? 0).ToString();
                    //return (attr as System.ComponentModel.DataAnnotations.StringLengthAttribute).MaximumLength.ToString();
                }
            }
            return "255";
        }

        public string CalculateIsKey(PropertyInfo prop)
        {
            if (_commonKeys.Contains(prop.Name))
                return "SI";

            return "NO";
        }

        public string CalculateEnBusquedaLista(PropertyInfo prop)
        {

            if (_commonBusqueda.Contains(prop.Name))
                return "SI";

            return "NO";
        }

        public string CalculateTipoControl(PropertyInfo prop)
        {

            if (typeof(BoolCN).IsAssignableFrom(prop.PropertyType) ||
                typeof(BoolCS).IsAssignableFrom(prop.PropertyType) ||
                typeof(BoolCNI).IsAssignableFrom(prop.PropertyType))
                return "CHECKBOX";

            return "DEFAULT";
        }


        public string CalculateDataType(PropertyInfo prop)
        {
            string tipoLenguaje = prop.PropertyType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "");

            if (_list_eq.ContainsKey(tipoLenguaje!.ToUpper()))
            {
                return _list_eq[tipoLenguaje!.ToUpper()]!.ToString() ?? "VARCHAR";
            }
            else
            {
                return "VARCHAR";
            }


        }

        public string CalculateDataType(MethodInfo prop)
        {
            string tipoLenguaje = prop.ReturnType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "");

            if (_list_eq.ContainsKey(tipoLenguaje!.ToUpper()))
            {
                return _list_eq[tipoLenguaje!.ToUpper()]!.ToString() ?? "VARCHAR";
            }
            else
            {
                return "VARCHAR";
            }


        }

        

        public string CalculateDataType(ParameterInfo prop)
        {
            string tipoLenguaje = prop.ParameterType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "");

            if (_list_eq.ContainsKey(tipoLenguaje!.ToUpper()))
            {
                return _list_eq[tipoLenguaje!.ToUpper()]!.ToString() ?? "VARCHAR";
            }
            else
            {
                return "VARCHAR";
            }


        }

        public string CalculateLenguajeType(ParameterInfo prop)
        {
            string tipoLenguaje = prop.ParameterType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "")
                                    .Replace("Collections.Generic.List`1[", "List<")
                                    .Replace("Collections.Generic.Dictionary`2[", "Dictionary<")
                                    .Replace("IposV3.Services.", "")
                                    .Replace("BindingModels.", "")
                                    ;

            if (prop.ParameterType.ToString().Contains("Collections.Generic.List`1[") ||
                prop.ParameterType.ToString().Contains("Collections.Generic.Dictionary`2"))
                tipoLenguaje += ">";

            if (Nullable.GetUnderlyingType(prop.ParameterType) != null)
                tipoLenguaje += "?";

            if(tipoLenguaje.Contains("&"))
            {

                tipoLenguaje = tipoLenguaje.Replace("&", "");
                tipoLenguaje = "out " +  tipoLenguaje;
            }



            return tipoLenguaje;


        }

        public string CalculateLenguajeType(MethodInfo prop)
        {
            string tipoLenguaje = prop.ReturnType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "")
                                    .Replace("Collections.Generic.List`1[", "List<")
                                    .Replace("Collections.Generic.Dictionary`2[", "Dictionary<")
                                    .Replace("IposV3.Services.", "")
                                    .Replace("BindingModels.", "");

            if (prop.ReturnType.ToString().Contains("Collections.Generic.List`1[") ||
                prop.ReturnType.ToString().Contains("Collections.Generic.Dictionary`2"))
                tipoLenguaje += ">";

            if (Nullable.GetUnderlyingType(prop.ReturnType) != null)
                tipoLenguaje += "?";

            if (tipoLenguaje.Contains("&"))
            {

                tipoLenguaje = tipoLenguaje.Replace("&", "");
                tipoLenguaje = "out " + tipoLenguaje;
            }

            return tipoLenguaje;


        }

        public string esTablaGeneral(Type type)
        {
                if (type.IsAssignableFrom(typeof(EntityBaseGenericCatalog)))
                    return "YES";

            return "NO";
        }


        public string esTablaWebControllerGeneral(Type type)
        {
            if ((typeof(BaseGenericController)).IsAssignableFrom(type))
                return "SI";

            return "NO";
        }


        public string CalculateSubtipo(PropertyInfo prop)
        {
            string tipoLenguaje = prop.PropertyType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "")
                                    .Replace("Collections.Generic.List`1[", "List<")
                                    .Replace("Collections.Generic.Dictionary`2[", "Dictionary<")
                                    .Replace("IposV3.Services.", "")
                                    .Replace("BindingModels.", "");

            if (prop.PropertyType.ToString().Contains("Collections.Generic.List`1[") ||
                prop.PropertyType.ToString().Contains("Collections.Generic.Dictionary`2"))
                tipoLenguaje += ">";

            if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                tipoLenguaje += "?";

            if (tipoLenguaje.Contains("&"))
            {

                tipoLenguaje = tipoLenguaje.Replace("&", "");
                tipoLenguaje = "out " + tipoLenguaje;
            }

            return tipoLenguaje;

        }

        public string CalculateSubtipo(ParameterInfo prop)
        {
            string tipoLenguaje = prop.ParameterType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "")
                                    .Replace("Collections.Generic.List`1[", "List<")
                                    .Replace("Collections.Generic.Dictionary`2[", "Dictionary<")
                                    .Replace("IposV3.Services.", "")
                                    .Replace("BindingModels.", "");

            if (prop.ParameterType.ToString().Contains("Collections.Generic.List`1[") ||
                prop.ParameterType.ToString().Contains("Collections.Generic.Dictionary`2"))
                tipoLenguaje += ">";

            if (Nullable.GetUnderlyingType(prop.ParameterType) != null)
                tipoLenguaje += "?";

            if (tipoLenguaje.Contains("&"))
            {

                tipoLenguaje = tipoLenguaje.Replace("&", "");
                tipoLenguaje = "out " + tipoLenguaje;
            }

            return tipoLenguaje;

        }

        public string CalculateSubtipo(MethodInfo prop)
        {
            string tipoLenguaje = prop.ReturnType.ToString().Replace("System.", "")
                                    .Replace("Nullable`1[", "")
                                    .Replace("]", "")
                                    .Replace("]", "")
                                    .Replace("IposV3.Model.", "")
                                    .Replace("Collections.Generic.List`1[", "List<")
                                    .Replace("Collections.Generic.Dictionary`2[", "Dictionary<")
                                    .Replace("IposV3.Services.", "")
                                    .Replace("BindingModels.", "");

            if (prop.ReturnType.ToString().Contains("Collections.Generic.List`1[") ||
                prop.ReturnType.ToString().Contains("Collections.Generic.Dictionary`2"))
                tipoLenguaje += ">";

            if (Nullable.GetUnderlyingType(prop.ReturnType) != null)
                tipoLenguaje += "?";

            if (tipoLenguaje.Contains("&"))
            {

                tipoLenguaje = tipoLenguaje.Replace("&", "");
                tipoLenguaje = "out " + tipoLenguaje;
            }

            return tipoLenguaje;

        }

        public List<ForeignKeyObj> ListAllForeignKeys(Type type)
        {

            List<ForeignKeyObj> res = new List<ForeignKeyObj>();
            foreach (var prop in type.GetProperties())
            {
                if (_foreignKeysToIgnore.Contains(prop.Name))
                    continue;


                if (!typeof(EntityBaseExt).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBaseGeneric).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBaseGenericCatalog).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBase).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBaseGenericPseudoCatalog).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBaseCatalogoSat).IsAssignableFrom(prop.PropertyType)
                   )
                    continue;


                if (typeof(Contacto).IsAssignableFrom(prop.PropertyType) ||
                    typeof(Domicilio).IsAssignableFrom(prop.PropertyType)
                   )
                    continue;



                foreach (var attr in prop.CustomAttributes)
                {
                    //attr.ArgumentType
                    if (attr.AttributeType.IsAssignableFrom(typeof(System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute)))
                    {
                        var strBuffer = attr.ConstructorArguments[0].Value?.ToString();
                        if (strBuffer != null && strBuffer.Length > 0)
                        {
                            var strBufferSplit = strBuffer.Replace(" ", "").Split(",");
                            for (int i = 0; i < strBufferSplit.Count(); i++)
                            {
                                var str = strBufferSplit[i];
                                if (!str.Equals("EmpresaId") && !str.Equals("SucursalId"))
                                {
                                    var foreignKeyObj = new ForeignKeyObj();


                                    foreignKeyObj.FieldId = str;
                                    foreignKeyObj.ExternalTableName = prop.PropertyType.Name;
                                    foreignKeyObj.ClassSubtype =
                                        typeof(EntityBaseGenericPseudoCatalog).IsAssignableFrom(prop.PropertyType) ? "EntityBaseGenericCatalog" :
                                        typeof(EntityBaseCatalogoSat).IsAssignableFrom(prop.PropertyType) ? "EntityBaseGenericCatalog" :
                                        typeof(EntityBaseGenericCatalog).IsAssignableFrom(prop.PropertyType) ? "EntityBaseGenericCatalog" :
                                        (typeof(EntityBaseGeneric).IsAssignableFrom(prop.PropertyType) ? "EntityBaseGeneric" :
                                        (typeof(EntityBaseExt).IsAssignableFrom(prop.PropertyType) ? "EntityBaseExt" : "EntityBase"));
                                    foreignKeyObj.Name = prop.Name;
                                    res.Add(foreignKeyObj);
                                    break;

                                }
                            }
                        }
                    }
                    //return (attr as System.ComponentModel.DataAnnotations.StringLengthAttribute).MaximumLength.ToString();
                }
            }

            return res;

        }

        public List<ExternComponent> ListAllExternComponents(Type type)
        {

            List<ExternComponent> res = new List<ExternComponent>();
            foreach (var prop in type.GetProperties())
            {
                if (_foreignKeysToIgnore.Contains(prop.Name))
                    continue;

                if (!typeof(EntityBaseExt).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBaseGeneric).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(EntityBase).IsAssignableFrom(prop.PropertyType) )
                    continue;



                bool isForeignKey = false;
                foreach (var attr in prop.CustomAttributes)
                {
                    if (attr.AttributeType.IsAssignableFrom(typeof(System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute)) )
                        isForeignKey = true;
                }

                if (isForeignKey &&
                    !typeof(Contacto).IsAssignableFrom(prop.PropertyType) &&
                    !typeof(Domicilio).IsAssignableFrom(prop.PropertyType)
                    )
                    continue;

                var externComponent = new ExternComponent();
                externComponent.Field = prop.Name;
                externComponent.ExternalEntityType = prop.PropertyType;

                res.Add(externComponent);


            }

            return res;

        }

        public List<PropertyInfo> PropertiesOrdered(Type type)
        {

            var typeProperties = new List<PropertyInfo>();

            var typePropertiesHeaderEntityBase = new List<PropertyInfo>();
            var typePropertiesHeaderEntityBaseGenericCatalog = new List<PropertyInfo>();
            var typePropertiesHeaderEntityBaseGeneric = new List<PropertyInfo>();
            var typePropertiesHeaderEntityBaseExt = new List<PropertyInfo>();
            var typePropertiesBody = new List<PropertyInfo>();


            foreach (var prop in type.GetProperties())
            {
                if (prop.DeclaringType!.Name.Contains("EntityBase"))
                    typePropertiesHeaderEntityBase.Add(prop);
                else if (prop.DeclaringType.Name.Contains("EntityBaseExt"))
                    typePropertiesHeaderEntityBaseExt.Add(prop);
                else if (prop.DeclaringType.Name.Contains("EntityBaseGenericCatalog"))
                    typePropertiesHeaderEntityBaseGenericCatalog.Add(prop);
                else if (prop.DeclaringType.Name.Contains("EntityBaseGeneric"))
                    typePropertiesHeaderEntityBaseGeneric.Add(prop);
                else
                    typePropertiesBody.Add(prop);


            }

            typeProperties.AddRange(typePropertiesHeaderEntityBase);
            typeProperties.AddRange(typePropertiesHeaderEntityBaseExt);
            typeProperties.AddRange(typePropertiesHeaderEntityBaseGenericCatalog);
            typeProperties.AddRange(typePropertiesHeaderEntityBaseGeneric);
            typeProperties.AddRange(typePropertiesBody);

            return typeProperties;
        }

        public List<MethodInfo> MethodsOrdered(Type type, int numeroMinimoDeParametros = 0)
        {

            var typeProperties = new List<MethodInfo>();


            foreach (var prop in type.GetMethods())
            {
                if (_excludingMethodNames.Contains(prop.Name))
                    continue;

                if (prop.GetParameters().Length < numeroMinimoDeParametros)
                    continue;

                    typeProperties.Add(prop);


            }


            return typeProperties;
        }

        public List<ParameterInfo> ParameterOfMethodsOrdered(Type type, string methodName)
        {

            var typeProperties = new List<ParameterInfo>();

            var method = type.GetMethods().Where(p => p.Name == methodName).FirstOrDefault();
            if(method != null )
            {

                foreach (var prop in method.GetParameters())
                {
                    typeProperties.Add(prop);


                }
            }

            return typeProperties;
        }

    }


    public class ForeignKeyObj
    {

        public string? Name { get; set; }
        public string? FieldId { get; set; }
        public string? ExternalTableName { get; set; }

        public string? ClassSubtype { get; set; }

        public ForeignKeyObj()
        {

        }
    }


    public class ExternComponent
    {
        public string? Field { get; set; }
        public Type? ExternalEntityType { get; set; }

        public ExternComponent()
        {

        }
    }
}
