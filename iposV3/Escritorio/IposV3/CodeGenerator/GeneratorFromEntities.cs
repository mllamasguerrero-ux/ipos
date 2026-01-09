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
using System.CodeDom;
using Microsoft.EntityFrameworkCore.Internal;
using System.Xml.Linq;
using Controllers.Controller;
using System.Collections.ObjectModel;

namespace CodeGenerator
{


    public class GeneratorFromEntities
    {


        public CodeGenerator.DSGeneracion dsGeneracion1;

        public CommonGenerationLogic commonGenerationLogic;

        public GeneratorFromEntities(CodeGenerator.DSGeneracion dsGeneracion1)
        {
            this.dsGeneracion1 = dsGeneracion1;
            commonGenerationLogic = new CommonGenerationLogic();


        }



        public void loadControllerClasses()
        {

            this.dsGeneracion1.UserTables.Clear();



            var listTypes = new List<Type>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(UnidadController))!.GetTypes()
                .Where(myType => myType.IsClass && !myType.Name.StartsWith("BaseController") &&
                                 !myType.Name.StartsWith("BaseGenericController") && //myType.Name.StartsWith("UsuarioController") &&
                                 (IsSubclassOfRawGeneric(typeof(BaseController<>), myType) /*|| IsSubclassOfRawGeneric(typeof(BaseGenericController), myType)*/) && 
                                 !myType.IsAbstract))
            {
                listTypes.Add(type);
            }


            foreach (var type in listTypes)
            {
                var className = type.Name.Replace("Controller", "");

                //Console.WriteLine(type.Name);
                var newRecord = this.dsGeneracion1.UserTables.NewUserTablesRow();
                newRecord.Name = className;
                newRecord.cb = 1;
                newRecord.NameRealTable = type.AssemblyQualifiedName;
                newRecord.NameHyphenized = className;
                newRecord.Schema_ = FindLocation(type);
                newRecord.Folder = "(nombreEsquema)/(nombreTabla)";
                newRecord.Tipo = "tabla";
                newRecord.NameParent = type.Name;
                newRecord.Query = "-";
                newRecord.Title = className;

                newRecord.ForeignMainKey = "None";
                newRecord.CampoClave = "clave";
                newRecord.CampoNombre = "nombre";
                newRecord.EsTablaGeneral = this.commonGenerationLogic.esTablaWebControllerGeneral(type);//  this.commonGenerationLogic.esTablaGeneral(type);

                this.dsGeneracion1.UserTables.AddUserTablesRow(newRecord);
            }
        }





        public void loadParameterControllerClasses()
        {

            this.dsGeneracion1.UserTables.Clear();



            var listTypes = new List<Type>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(UnidadController))!.GetTypes()
                .Where(myType => myType.IsClass && !myType.Name.StartsWith("BaseController") &&
                                 !myType.Name.StartsWith("BaseGenericController") &&
                                 (IsSubclassOfRawGeneric(typeof(BaseController<>), myType) /*|| IsSubclassOfRawGeneric(typeof(BaseGenericController), myType)*/) &&
                                 !myType.IsAbstract))
            {
                listTypes.Add(type);
            }


            var consecutivo = 1;

            foreach (var type in listTypes)
            {

                
                var methodsOrdered = commonGenerationLogic.MethodsOrdered(type, 2);

                var classParentName = type.Name.Replace("Controller", "");


                foreach (var method in methodsOrdered)
                {
                    var modelName = classParentName + "_" + method.Name; //string.Concat(((classParentName + "_" + method.Name)).Take(31));

                    //Console.WriteLine(type.Name);
                    var newRecord = this.dsGeneracion1.UserTables.NewUserTablesRow();
                    newRecord.Name = modelName;
                    newRecord.cb = 1;
                    newRecord.NameRealTable = modelName;
                    newRecord.NameHyphenized = "T_" + consecutivo.ToString();
                    newRecord.Schema_ = FindLocation(type);
                    newRecord.Folder = "(nombreEsquema)/"+ classParentName;
                    newRecord.Tipo = "tabla";
                    newRecord.NameParent = type.AssemblyQualifiedName;
                    newRecord.Query = "-";
                    newRecord.Title = method.Name;

                    newRecord.ForeignMainKey = "None";
                    newRecord.CampoClave = "clave";
                    newRecord.CampoNombre = type.Name;
                    newRecord.EsTablaGeneral = "NO";

                    this.dsGeneracion1.UserTables.AddUserTablesRow(newRecord);

                    consecutivo++;

                }

            }
        }



        public void loadEntityClasses()
        {

            this.dsGeneracion1.UserTables.Clear();



            var listTypes = GetAllTypes<EntityBaseExt, EntityBaseGenericCatalog, EntityBaseGeneric, EntityBaseCatalogoSat, EntityBase, EntityBaseGenericPseudoCatalog, TransitionClass>(); //TransitionClass

            //var listTypesB = GetAllTypes<EntityBaseExt, EntityBaseGenericCatalog, EntityBaseGeneric, EntityBaseCatalogoSat, EntityBase, EntityBaseGenericPseudoCatalog, TransitionClass>();


            foreach (var type in listTypes)
            {
                //Console.WriteLine(type.Name);
                var newRecord = this.dsGeneracion1.UserTables.NewUserTablesRow();
                newRecord.Name = type.Name;
                newRecord.cb = 1;
                newRecord.NameRealTable = type.AssemblyQualifiedName;
                newRecord.NameHyphenized = type.Name;
                newRecord.Schema_ = FindLocation(type);
                newRecord.Folder = "(nombreEsquema)/(nombreTabla)";
                newRecord.Tipo = "tabla";
                newRecord.NameParent = type.Name;
                newRecord.Query = "-";
                newRecord.Title = type.Name;

                newRecord.ForeignMainKey = "None";
                newRecord.CampoClave = "clave";
                newRecord.CampoNombre = "nombre";
                newRecord.EsTablaGeneral = this.commonGenerationLogic.esTablaGeneral(type);

                this.dsGeneracion1.UserTables.AddUserTablesRow(newRecord);
            }
        }

        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        private string? FindLocation(Type type_)
        {
            string typeName = type_.Name;
            string[] files = Directory.GetFiles(@"C:\ProyectosPrueba\IposV3\IposV3\IposV3", $"{typeName}.cs", SearchOption.AllDirectories);

            if (files.Length > 0)
                return Path.GetFileName(Path.GetDirectoryName(files[0]));

            return "";


        }

        private List<Type> GetAllTypes<T,U,V,W, Y, Z, A>()
        {

            Type tipoEntidad = typeof(T);
            Type tipoEntidad2 = typeof(U);
            Type tipoEntidad3 = typeof(V);
            Type tipoEntidad4 = typeof(W);
            Type tipoEntidad5 = typeof(Y);
            Type tipoEntidad6 = typeof(Z);
            Type tipoEntidad7 = typeof(A);

            List<Type> objects = new List<Type>();
            foreach (Type type in
                Assembly.GetAssembly(tipoEntidad)!.GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && 
                (myType.IsSubclassOf(tipoEntidad) || myType.IsSubclassOf(tipoEntidad2) ||
                 myType.IsSubclassOf(tipoEntidad3) || myType.IsSubclassOf(tipoEntidad4) || 
                 myType.IsSubclassOf(tipoEntidad5) || myType.IsSubclassOf(tipoEntidad6) || 
                 myType.IsSubclassOf(tipoEntidad7))))
            {
                objects.Add(type);
            }


            foreach (Type type in
                Assembly.GetAssembly(typeof(IposV3.Services.DoctoTransaction))!.GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract &&
                (myType.IsSubclassOf(tipoEntidad) || myType.IsSubclassOf(tipoEntidad2) ||
                 myType.IsSubclassOf(tipoEntidad3) || myType.IsSubclassOf(tipoEntidad4) ||
                 myType.IsSubclassOf(tipoEntidad5) || myType.IsSubclassOf(tipoEntidad6) ||
                 myType.IsSubclassOf(tipoEntidad7))))
            {

                if(!objects.Contains(type))
                    objects.Add(type);
            }
            //objects.Sort();
            //return objects;
            return objects;
        }




        bool IsNullable( PropertyInfo prop, object? obj)
        {
            Type typeX = prop.PropertyType;
            if (typeX.FullName != null && typeX.FullName.ToLower().Contains("nullable"))
                return true;

            if (prop.GetValue(obj) == null)
                return true;


            //if (!typeX.IsValueType ) return true; // ref-type
            if (Nullable.GetUnderlyingType(typeX) != null) return true; // Nullable<T>
            
            return false; // value-type
        }


        bool IsNullable(MethodInfo prop)
        {
            Type typeX = prop.ReturnType;
            if (typeX.FullName != null && typeX.FullName.ToLower().Contains("nullable"))
                return true;



            //if (!typeX.IsValueType ) return true; // ref-type
            if (Nullable.GetUnderlyingType(typeX) != null) return true; // Nullable<T>

            return false; // value-type
        }

        bool IsNullable(ParameterInfo prop)
        {
            Type typeX = prop.ParameterType;
            if (typeX.FullName != null && typeX.FullName.ToLower().Contains("nullable"))
                return true;

            if (Nullable.GetUnderlyingType(typeX) != null) return true; // Nullable<T>

            return false; // value-type

            //return IsNullableHelper(prop.ParameterType, prop.Member, prop.CustomAttributes);
        }


        private static bool IsNullableHelper(Type memberType, MemberInfo? declaringType, IEnumerable<CustomAttributeData> customAttributes)
        {
            if (memberType.IsValueType)
                return Nullable.GetUnderlyingType(memberType) != null;

            var nullable = customAttributes
                .FirstOrDefault(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableAttribute");
            if (nullable != null && nullable.ConstructorArguments.Count == 1)
            {
                var attributeArgument = nullable.ConstructorArguments[0];
                if (attributeArgument.ArgumentType == typeof(byte[]))
                {
                    var args = (ReadOnlyCollection<CustomAttributeTypedArgument>)attributeArgument.Value!;
                    if (args.Count > 0 && args[0].ArgumentType == typeof(byte))
                    {
                        return (byte)args[0].Value! == 2;
                    }
                }
                else if (attributeArgument.ArgumentType == typeof(byte))
                {
                    return (byte)attributeArgument.Value! == 2;
                }
            }

            for (var type = declaringType; type != null; type = type.DeclaringType)
            {
                var context = type.CustomAttributes
                    .FirstOrDefault(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.NullableContextAttribute");
                if (context != null &&
                    context.ConstructorArguments.Count == 1 &&
                    context.ConstructorArguments[0].ArgumentType == typeof(byte))
                {
                    return (byte)context.ConstructorArguments[0].Value! == 2;
                }
            }

            // Couldn't find a suitable attribute
            return false;
        }

        private string DefaultValue(PropertyInfo prop, object? obj)
        {
            object? varobj = prop.GetValue(obj);

            if(prop.PropertyType== typeof(string))
                return @"""""";


            if (prop.PropertyType == typeof(BoolCN))
                return @"BoolCN.N";

            if (prop.PropertyType == typeof(BoolCNI))
                return @"BoolCNI.N";

            if (prop.PropertyType == typeof(BoolCS))
                return @"BoolCS.S";

            if (prop.PropertyType == typeof(DateTimeOffset))
                return @"DateTime.UtcNow";

            if (prop.PropertyType == typeof(DateTime))
                return @"DateTime.Now";

            if (varobj != null)
                return varobj.ToString() ?? @"""""";


            return @""""""; 
        }

        private string DefaultValue(MethodInfo prop)
        {
            //object? varobj = prop.GetValue(obj);

            if (prop.ReturnType == typeof(string))
                return @"""""";


            if (prop.ReturnType == typeof(BoolCN))
                return @"BoolCN.N";

            if (prop.ReturnType == typeof(BoolCNI))
                return @"BoolCNI.N";

            if (prop.ReturnType == typeof(BoolCS))
                return @"BoolCS.S";

            if (prop.ReturnType == typeof(DateTimeOffset))
                return @"DateTime.UtcNow";

            if (prop.ReturnType == typeof(DateTime))
                return @"DateTime.Now";

            //if (varobj != null)
            //    return varobj.ToString() ?? @"""""";


            return @"""""";
        }


        private void AddEntityPropertiesToGrid(Type? type, string? entityName, bool isSubEntity, string? campoPadre)
        {

            var campoPadreWithPath = campoPadre;
            campoPadre = campoPadre?.Replace("?.", "_");

            if (entityName == null)
                return;

            if (type == null)
                return;

            var instance = Activator.CreateInstance(type);


            var listOfForeignKeys = commonGenerationLogic.ListAllForeignKeys(type);

            var propertiesOrdered = commonGenerationLogic.PropertiesOrdered(type);


            var listOfExternComponents = isSubEntity && !typeof(Contacto).IsAssignableFrom(type) ? new List<ExternComponent>() : commonGenerationLogic.ListAllExternComponents(type);



            foreach (var prop in propertiesOrdered)
            {

                var externComponent = listOfExternComponents.Where(y => y.Field == prop.Name).FirstOrDefault();

                if (externComponent != null)
                {
                    AddEntityPropertiesToGrid(externComponent.ExternalEntityType, entityName, true, (campoPadre != null && campoPadre.Length > 0 ? campoPadre + "?." : "") + externComponent.Field);
                    continue;
                }


                if (commonGenerationLogic.IsInExcludingFieldTypes(prop.PropertyType))
                    continue;

                if (commonGenerationLogic.IsInExcludingFieldNames(prop, isSubEntity))
                    continue;


                if (isSubEntity)
                {
                    if (prop.Name.Equals(entityName + "id"))
                        continue;
                }

                var foreignKeyInfo = listOfForeignKeys.Where(y => y.FieldId == prop.Name).FirstOrDefault();

                var propNameWithPrefix = campoPadre != null && campoPadre.Length > 0 ? campoPadre + "_" + prop.Name : prop.Name;


                var propNameEntityWithPrefix = foreignKeyInfo != null ?
                                                    (campoPadre != null && campoPadre.Length > 0 ? campoPadre + "_" + foreignKeyInfo.Name : foreignKeyInfo.Name) : ""; 

                var row = this.dsGeneracion1.columnas.NewcolumnasRow();


                row.TABLE_NAME = entityName.ToString();
                row.COLUMN_NAME = propNameWithPrefix;
                row.IS_NULLABLE = IsNullable(prop, instance) ? "YES" : "NO";
                row.DATA_TYPE = commonGenerationLogic.CalculateDataType(prop);
                row.IDENTIDAD = "NO";
                row.SIZE = commonGenerationLogic.CalculateLengthType(prop);
                row.IS_KEY = commonGenerationLogic.CalculateIsKey(prop);
                row.ESCALCULADO = "NO";
                row.ESCOMBO = "NO";
                row.ENLISTA = "SI";
                row.ENEDICION = "SI";
                row.ORDEN = dsGeneracion1.columnas.Rows.Count.ToString();
                row.ENUPDATE = "SI";
                row.ENINSERT = "SI";
                row.TIPOCONTROL = foreignKeyInfo != null ? "SELECTOR" : commonGenerationLogic.CalculateTipoControl(prop);
                row.CATALOGO = foreignKeyInfo != null ? foreignKeyInfo.ExternalTableName : "";
                row.CATALOGOCAMPOCLAVE = foreignKeyInfo != null ? propNameEntityWithPrefix + "Clave" : "";
                row.CATALOGOCAMPONOMBRE = foreignKeyInfo != null ? propNameEntityWithPrefix + "Nombre" : "";
                row.CATALOGOLISTAVMNAME = foreignKeyInfo != null ? foreignKeyInfo.ExternalTableName + "ListViewModel" : "";
                row.CATALOGOSELECTOBJECTNAME = foreignKeyInfo != null ? "SelectedItem" : "";
                row.CATALOGOSELECTFIELDTNAME = foreignKeyInfo != null ? "Clave" : "";
                row.ORDEN2 = "0";
                row.NOMBREENFORM = propNameWithPrefix;
                row.TAB = "";
                row.ANCHOB12 = "3";
                row.GRUPOFORM = "";
                row.SUBTIPO = commonGenerationLogic.CalculateSubtipo(prop);
                row.ENBUSQUEDALISTA = commonGenerationLogic.CalculateEnBusquedaLista(prop);
                row.ESSUBENTIDAD = isSubEntity ? "YES" : "NO";
                row.SUBENTIDADTIPO = isSubEntity ? type.Name : "";
                row.SUBENTIDADCAMPO = isSubEntity ? campoPadreWithPath : "";
                row.SUBENTIDADCAMPOREL = isSubEntity ? prop.Name : "";
                row.DEFAULTVALUE = DefaultValue(prop, instance);
                row.ESCAMPODECATALOGO = "NO";
                row.ENTIDADCATALOGO = "";
                row.ENTIDADCATALOGOCAMPO = "";
                row.ENTIDADCATALOGOCAMPOREL = "";
                row.ESCATALOGOGENERICO = "NO";
                row.GRID = "";
                row.OBJETOPROPIEDAD = "";
                row.PROPIEDAD = "";


                dsGeneracion1.columnas.AddcolumnasRow(row);


                if (foreignKeyInfo != null)
                {

                    string campoPadrePref = campoPadre != null && campoPadre.Length > 0 ? campoPadre + "." : "";
                    string campoPadrePrefNullable = campoPadre != null && campoPadre.Length > 0 ? campoPadre + "?." : "";

                    row = this.dsGeneracion1.columnas.NewcolumnasRow();

                    row.TABLE_NAME = entityName.ToString();
                    row.COLUMN_NAME = propNameEntityWithPrefix + "Clave";
                    row.IS_NULLABLE = "YES";
                    row.DATA_TYPE = "VARCHAR";
                    row.IDENTIDAD = "NO";
                    row.SIZE = "31";
                    row.IS_KEY = "NO";
                    row.ESCALCULADO = "NO";
                    row.ESCOMBO = "NO";
                    row.ENLISTA = "SI";
                    row.ENEDICION = "NO";
                    row.ORDEN = dsGeneracion1.columnas.Rows.Count.ToString();
                    row.ENUPDATE = "NO";
                    row.ENINSERT = "NO";
                    row.TIPOCONTROL = "DEFAULT";
                    row.CATALOGO = "";
                    row.CATALOGOCAMPOCLAVE = "";
                    row.CATALOGOCAMPONOMBRE = "";
                    row.CATALOGOLISTAVMNAME = "";
                    row.CATALOGOSELECTOBJECTNAME = "";
                    row.CATALOGOSELECTFIELDTNAME = "";
                    row.ORDEN2 = "0";
                    row.NOMBREENFORM = propNameEntityWithPrefix + "Clave";
                    row.TAB = "";
                    row.ANCHOB12 = "3";
                    row.GRUPOFORM = "";
                    row.SUBTIPO = "";
                    row.ENBUSQUEDALISTA = "NO";
                    row.ESSUBENTIDAD = isSubEntity ? "YES" : "NO";
                    row.SUBENTIDADTIPO = isSubEntity ? type.Name : "";
                    row.SUBENTIDADCAMPO = isSubEntity ? campoPadreWithPath : "";
                    row.SUBENTIDADCAMPOREL = "Clave"; 
                    row.DEFAULTVALUE = "";
                    row.ESCAMPODECATALOGO = "YES";
                    row.ENTIDADCATALOGO =  foreignKeyInfo.ExternalTableName;
                    row.ENTIDADCATALOGOCAMPO = campoPadrePrefNullable + foreignKeyInfo.Name ;
                    row.ENTIDADCATALOGOCAMPOREL = "Clave";
                    row.ESCATALOGOGENERICO = foreignKeyInfo.ClassSubtype == "EntityBaseGenericCatalog" ? "YES" : "NO" ;
                    row.GRID = "";
                    row.OBJETOPROPIEDAD = "";
                    row.PROPIEDAD = "";

                    dsGeneracion1.columnas.AddcolumnasRow(row);


                    row = this.dsGeneracion1.columnas.NewcolumnasRow();

                    row.TABLE_NAME = entityName.ToString();
                    row.COLUMN_NAME = propNameEntityWithPrefix + "Nombre";
                    row.IS_NULLABLE = "YES";
                    row.DATA_TYPE = "VARCHAR";
                    row.IDENTIDAD = "NO";
                    row.SIZE = "128";
                    row.IS_KEY = "NO";
                    row.ESCALCULADO = "NO";
                    row.ESCOMBO = "NO";
                    row.ENLISTA = "SI";
                    row.ENEDICION = "NO";
                    row.ORDEN = dsGeneracion1.columnas.Rows.Count.ToString();
                    row.ENUPDATE = "NO";
                    row.ENINSERT = "NO";
                    row.TIPOCONTROL = "DEFAULT";
                    row.CATALOGO = "";
                    row.CATALOGOCAMPOCLAVE = "";
                    row.CATALOGOCAMPONOMBRE = "";
                    row.CATALOGOLISTAVMNAME = "";
                    row.CATALOGOSELECTOBJECTNAME = "";
                    row.CATALOGOSELECTFIELDTNAME = "";
                    row.ORDEN2 = "0";
                    row.NOMBREENFORM = propNameEntityWithPrefix + "Nombre";
                    row.TAB = "";
                    row.ANCHOB12 = "3";
                    row.GRUPOFORM = "";
                    row.SUBTIPO = "";
                    row.ENBUSQUEDALISTA = "NO";
                    row.ESSUBENTIDAD = isSubEntity ? "YES" : "NO";
                    row.SUBENTIDADTIPO = isSubEntity ? type.Name : "";
                    row.SUBENTIDADCAMPO = isSubEntity ? campoPadreWithPath : "";
                    row.SUBENTIDADCAMPOREL = "Nombre";
                    row.DEFAULTVALUE = "";
                    row.ESCAMPODECATALOGO = "YES";
                    row.ENTIDADCATALOGO = foreignKeyInfo.ExternalTableName;
                    row.ENTIDADCATALOGOCAMPO = campoPadrePrefNullable + foreignKeyInfo.Name;
                    row.ENTIDADCATALOGOCAMPOREL = "Nombre";
                    row.ESCATALOGOGENERICO = foreignKeyInfo.ClassSubtype == "EntityBaseGenericCatalog" ? "YES" : "NO";

                    dsGeneracion1.columnas.AddcolumnasRow(row);
                }



            }
        }


        public string? mayusculaPrimeraLetra(string? str)
        {
            if (str == null)
                return null;

            Int32 auxlen = str.Length - 1;
            string aux = str.Substring(0, 1).ToUpper() + str.Substring(1, auxlen);
            return aux;
        }


        private void AddEntityMethodsToGrid(Type? type, string? entityName)
        {


            if (entityName == null)
                return;

            if (type == null)
                return;
                

            var listOfForeignKeys = new List<ForeignKeyObj>();// commonGenerationLogic.ListAllForeignKeys(type);

            var propertiesOrdered = commonGenerationLogic.MethodsOrdered(type, 1);




            foreach (var prop in propertiesOrdered)
            {


                var propNameWithPrefix = prop.Name;

                var row = this.dsGeneracion1.columnas.NewcolumnasRow();

                var strParamConTipos = "";
                var strParamSinTipos = "";
                var strParamAsignaciones = "";
                var strApiParamCall = "";

                foreach(var param in prop.GetParameters())
                {
                    if(strParamConTipos.Length > 0)
                    {
                        strParamConTipos += ", ";
                        strParamSinTipos += ", ";
                        strParamAsignaciones += ", ";
                        strApiParamCall += ", ";
                    }

                    strParamConTipos += commonGenerationLogic.CalculateLenguajeType(param) + " " + param.Name;
                    strParamSinTipos +=  param.Name;
                    strParamAsignaciones += mayusculaPrimeraLetra(param.Name) + " = " + param.Name;
                    strApiParamCall += "apiParam." + mayusculaPrimeraLetra(param.Name) +
                                        (param.ParameterType.IsValueType ? "!.Value" : "");

                }



                row.TABLE_NAME = entityName.ToString();
                row.COLUMN_NAME = propNameWithPrefix;
                row.IS_NULLABLE = IsNullable(prop) ? "YES" : "NO";
                row.DATA_TYPE = commonGenerationLogic.CalculateLenguajeType(prop);
                row.IDENTIDAD = "NO";
                row.SIZE = "255";// commonGenerationLogic.CalculateLengthType(prop);
                row.IS_KEY = "NO";//  commonGenerationLogic.CalculateIsKey(prop);
                row.ESCALCULADO = "NO";
                row.ESCOMBO = "NO";
                row.ENLISTA = "SI";
                row.ENEDICION = "SI";
                row.ORDEN = dsGeneracion1.columnas.Rows.Count.ToString();
                row.ENUPDATE = "SI";
                row.ENINSERT = "SI";
                row.TIPOCONTROL = prop.GetParameters().Count() > 1 ? "VARIOSPARAMETROS" : "UNPARAMETRO"; //"DEFAULT"; // foreignKeyInfo != null ? "SELECTOR" : commonGenerationLogic.CalculateTipoControl(prop);
                row.CATALOGO = "";
                row.CATALOGOCAMPOCLAVE = strParamConTipos;
                row.CATALOGOCAMPONOMBRE = strParamSinTipos;
                row.CATALOGOLISTAVMNAME = strParamAsignaciones;
                row.CATALOGOSELECTOBJECTNAME = commonGenerationLogic.CalculateSubtipo(prop.GetParameters().First());
                row.CATALOGOSELECTFIELDTNAME = prop.GetParameters().First().Name;
                row.ORDEN2 = "0";
                row.NOMBREENFORM = propNameWithPrefix;
                row.TAB = "";
                row.ANCHOB12 = "3";
                row.GRUPOFORM = "";
                row.SUBTIPO = commonGenerationLogic.CalculateSubtipo(prop);
                row.ENBUSQUEDALISTA = "NO";//  commonGenerationLogic.CalculateEnBusquedaLista(prop);
                row.ESSUBENTIDAD = "NO";
                row.SUBENTIDADTIPO = "";
                row.SUBENTIDADCAMPO = strApiParamCall;
                row.SUBENTIDADCAMPOREL = "";
                row.DEFAULTVALUE = DefaultValue(prop);
                row.ESCAMPODECATALOGO = "NO";
                row.ENTIDADCATALOGO = "";
                row.ENTIDADCATALOGOCAMPO = "";
                row.ENTIDADCATALOGOCAMPOREL = "";
                row.ESCATALOGOGENERICO = "NO";
                row.GRID = "";
                row.OBJETOPROPIEDAD = "";
                row.PROPIEDAD = "";


                dsGeneracion1.columnas.AddcolumnasRow(row);





            }
        }



        private void AddParameterMethodsToGrid(Type? type, string? entityName, string? methodName, string methodWithPath)
        {


            if (entityName == null)
                return;

            if (methodName == null)
                return;


            if (type == null)
                return;


            var parametrosOrdered = commonGenerationLogic.ParameterOfMethodsOrdered(type, methodName!);




            foreach (var prop in parametrosOrdered)
            {



                var propNameWithPrefix =  prop.Name;



                var row = this.dsGeneracion1.columnas.NewcolumnasRow();


                row.TABLE_NAME = methodWithPath.ToString();
                row.COLUMN_NAME = propNameWithPrefix;
                row.IS_NULLABLE = IsNullable(prop) ? "YES" : "NO";
                row.DATA_TYPE = commonGenerationLogic.CalculateLenguajeType(prop);
                row.IDENTIDAD = "NO";
                row.SIZE = "255";// commonGenerationLogic.CalculateLengthType(prop);
                row.IS_KEY = "NO";//  commonGenerationLogic.CalculateIsKey(prop);
                row.ESCALCULADO = "NO";
                row.ESCOMBO = "NO";
                row.ENLISTA = "SI";
                row.ENEDICION = "SI";
                row.ORDEN = dsGeneracion1.columnas.Rows.Count.ToString();
                row.ENUPDATE = "SI";
                row.ENINSERT = "SI";
                row.TIPOCONTROL = "DEFAULT"; // foreignKeyInfo != null ? "SELECTOR" : commonGenerationLogic.CalculateTipoControl(prop);
                row.CATALOGO = "";
                row.CATALOGOCAMPOCLAVE = "";
                row.CATALOGOCAMPONOMBRE =  "";
                row.CATALOGOLISTAVMNAME = "";
                row.CATALOGOSELECTOBJECTNAME = "";
                row.CATALOGOSELECTFIELDTNAME = "";
                row.ORDEN2 = "0";
                row.NOMBREENFORM = propNameWithPrefix;
                row.TAB = "";
                row.ANCHOB12 = "3";
                row.GRUPOFORM = "";
                row.SUBTIPO = commonGenerationLogic.CalculateSubtipo(prop);
                row.ENBUSQUEDALISTA = "NO";//  commonGenerationLogic.CalculateEnBusquedaLista(prop);
                row.ESSUBENTIDAD =  "NO";
                row.SUBENTIDADTIPO =  "";
                row.SUBENTIDADCAMPO =  "";
                row.SUBENTIDADCAMPOREL =  "";
                row.DEFAULTVALUE = ""; // DefaultValue(prop);
                row.ESCAMPODECATALOGO = "NO";
                row.ENTIDADCATALOGO = "";
                row.ENTIDADCATALOGOCAMPO = "";
                row.ENTIDADCATALOGOCAMPOREL = "";
                row.ESCATALOGOGENERICO = "NO";
                row.GRID = "";
                row.OBJETOPROPIEDAD = "";
                row.PROPIEDAD = "";


                dsGeneracion1.columnas.AddcolumnasRow(row);





            }
        }





        public void LoadColumnInfoFromEntities()
        {

            this.dsGeneracion1.columnas.Clear();


            foreach (DataRow dr in this.dsGeneracion1.UserTables.Rows)
            {
                if (int.Parse(dr["cb"].ToString()!) == 1)
                {

                    string? typeName = dr["NameRealTable"].ToString();
                    if (typeName == null)
                        return;

                    Type? type = Type.GetType(typeName);
                    AddEntityPropertiesToGrid(type, dr["Name"].ToString(), false, "");
                }
            }
        }


        public void generarExcel(string archivoExcel)
        {


            if ((this.dsGeneracion1.UserTables.Rows.Count <= 0))
            {
                MessageBox.Show("Primero logueese al sistema");
                return;
            }

            if ((string.IsNullOrEmpty(archivoExcel)))
            {
                MessageBox.Show("Primero seleccione un excel destino");
                return;
            }


            if (File.Exists(archivoExcel))
                File.Delete(archivoExcel);

            File.Copy("molde.xlsx", archivoExcel);


            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;MAXSCANROWS=15;READONLY=FALSE\"";


            String oleCmdTxt = "";
            System.Collections.ArrayList oleParts = new ArrayList();
            OleDbParameter[] oleArParms = new OleDbParameter[oleParts.Count];
            oleParts.CopyTo(oleArParms, 0);



            foreach (DataRow dr in this.dsGeneracion1.UserTables.Rows)
            {
                //If (Boolean.Parse(dr("cb").ToString()) = True) Then


                oleParts = new ArrayList();
                oleArParms = new OleDbParameter[oleParts.Count];
                oleParts.CopyTo(oleArParms, 0);

                string strNameTable = (string)dr["Name"];
                string strNameTableHyphenized = (string)dr["NameHyphenized"];
                string strNameTableTitle = (string)dr["Title"];
                string strNameTableReal = (string)dr["NameRealTable"];
                string strSchema = (string)dr["Schema_"];
                string strFolder = (string)dr["Folder"];
                string strTipo = (string)dr["Tipo"];
                string strNameParent = (string)dr["NameParent"];
                string strQuery = (string)dr["Query"];
                string strForeignMainKey = (string)dr["ForeignMainKey"];
                string strCampoClave = (string)dr["CampoClave"];
                string strCampoNombre = (string)dr["CampoNombre"];
                string strEsTablaGeneral = (string)dr["EsTablaGeneral"];

                string strNameTableSheet =  strNameTable.Length > 27 ? strNameTable.Substring(0, 27) : strNameTable;



                if ((dr["cb"].ToString() == "1"))
                {

                    //crea la tabla especifica
                    try
                    {

                        oleCmdTxt = @"DROP TABLE [" + strNameTableSheet + "] ; ";
                        try
                        {
                            OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                            //MessageBox.Show("Error droping table " + ex.Message);
                            //return;
                        }
                        oleCmdTxt = @"CREATE TABLE [" + strNameTableSheet + "] (TABLE_NAME VARCHAR,COLUMN_NAME VARCHAR,COLUMN_DEFAULT VARCHAR,IS_NULLABLE VARCHAR,DATA_TYPE VARCHAR,IDENTIDAD VARCHAR,'SIZE' VARCHAR,COLLATION_NAME VARCHAR,IS_KEY VARCHAR,COLUMN_NAME_KEY VARCHAR,TABLE_NAME_KEY VARCHAR,COLUMN_NAME_KEY_TEXT VARCHAR,SUBTIPO VARCHAR, ESCALCULADO VARCHAR, ESCOMBO VARCHAR, ENLISTA VARCHAR, " +
                            "ENEDICION VARCHAR, DOMAIN_NAME VARCHAR,TABLE_SCHEMA VARCHAR, ORDEN VARCHAR,ENUPDATE VARCHAR,ENINSERT VARCHAR,TIPOCONTROL VARCHAR,CATALOGO VARCHAR,CATALOGOCAMPOCLAVE VARCHAR,CATALOGOCAMPONOMBRE VARCHAR,CATALOGOLISTAVMNAME VARCHAR,CATALOGOSELECTOBJECTNAME VARCHAR,CATALOGOSELECTFIELDTNAME VARCHAR, ORDEN2 VARCHAR, NOMBREENFORM VARCHAR, ANCHOB12 VARCHAR, TAB VARCHAR, GRUPOFORM VARCHAR, ENBUSQUEDALISTA VARCHAR," +
                            "ESSUBENTIDAD VARCHAR, SUBENTIDADTIPO VARCHAR, SUBENTIDADCAMPO VARCHAR, SUBENTIDADCAMPOREL VARCHAR,DEFAULTVALUE VARCHAR, ESCAMPODECATALOGO VARCHAR, ENTIDADCATALOGO VARCHAR, ENTIDADCATALOGOCAMPO VARCHAR, ENTIDADCATALOGOCAMPOREL VARCHAR, ESCATALOGOGENERICO VARCHAR, GRID VARCHAR, OBJETOPROPIEDAD VARCHAR, PROPIEDAD VARCHAR); ";
                        OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error creating table " + ex.Message);
                        return;
                    }





                    //agrega la tabla a la lista de tablas en el excel
                    try
                    {


                        oleCmdTxt = "INSERT INTO [tables$] (Name, NameHyphenized,Title,NameRealTable,Schema_,Folder, Tipo, NameParent, Query,ForeignMainKey, CampoClave, CampoNombre, EsTablaGeneral) VALUES (@Name, @NameHyphenized, @Title, @NameRealTable, @Schema_,@Folder,@Tipo, @NameParent, @Query, @ForeignMainKey,@CampoClave, @CampoNombre, @EsTablaGeneral)";

                        oleParts = new ArrayList();



                        OleDbParameter oleAuxPar = new OleDbParameter("@Name", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTable;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameHyphenized", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableHyphenized;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Title", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableTitle;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameRealTable", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableReal;
                        oleParts.Add(oleAuxPar);



                        oleAuxPar = new OleDbParameter("@Schema_", OleDbType.VarChar);
                        oleAuxPar.Value = strSchema;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Folder", OleDbType.VarChar);
                        oleAuxPar.Value = strFolder;
                        oleParts.Add(oleAuxPar);


                        oleAuxPar = new OleDbParameter("@Tipo", OleDbType.VarChar);
                        oleAuxPar.Value = strTipo;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameParent", OleDbType.VarChar);
                        oleAuxPar.Value = strNameParent;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Query", OleDbType.LongVarChar);
                        oleAuxPar.Value = strQuery;
                        oleParts.Add(oleAuxPar);


                        oleAuxPar = new OleDbParameter("@ForeignMainKey", OleDbType.LongVarChar);
                        oleAuxPar.Value = strForeignMainKey;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@CampoClave", OleDbType.VarChar);
                        oleAuxPar.Value = strCampoClave;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@CampoNombre", OleDbType.VarChar);
                        oleAuxPar.Value = strCampoNombre;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@EsTablaGeneral", OleDbType.VarChar);
                        oleAuxPar.Value = strEsTablaGeneral;
                        oleParts.Add(oleAuxPar);

                        oleArParms = new OleDbParameter[oleParts.Count];
                        oleParts.CopyTo(oleArParms, 0);

                        OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    //LlenarDatosColumnas(fuente, dr[0].ToString());

                    this.dsGeneracion1.columnas.Clear();


                    string? typeName = dr["NameRealTable"].ToString();
                    if (typeName == null)
                        return;

                    Type? type = Type.GetType(typeName);
                    AddEntityPropertiesToGrid(type, dr["Name"].ToString(), false, "");



                    try
                    {



                        oleCmdTxt = "INSERT INTO [" + strNameTableSheet + "$] (TABLE_NAME,COLUMN_NAME,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,IDENTIDAD,'SIZE',COLLATION_NAME,IS_KEY,COLUMN_NAME_KEY,TABLE_NAME_KEY,COLUMN_NAME_KEY_TEXT,SUBTIPO, ESCALCULADO, ESCOMBO, ENLISTA, ENEDICION, DOMAIN_NAME,TABLE_SCHEMA, ORDEN  ,ENUPDATE ,ENINSERT ,TIPOCONTROL ,CATALOGO ,CATALOGOCAMPOCLAVE ,CATALOGOCAMPONOMBRE ,CATALOGOLISTAVMNAME ,CATALOGOSELECTOBJECTNAME ,CATALOGOSELECTFIELDTNAME ,ORDEN2 ,NOMBREENFORM ,GRUPOFORM, ANCHOB12, TAB,  ENBUSQUEDALISTA, ESSUBENTIDAD , SUBENTIDADTIPO , SUBENTIDADCAMPO , SUBENTIDADCAMPOREL, DEFAULTVALUE ,ESCAMPODECATALOGO , ENTIDADCATALOGO , ENTIDADCATALOGOCAMPO , ENTIDADCATALOGOCAMPOREL, ESCATALOGOGENERICO, GRID, OBJETOPROPIEDAD, PROPIEDAD ) " +
                            "VALUES (@TABLE_NAME,@COLUMN_NAME,@COLUMN_DEFAULT,@IS_NULLABLE,@DATA_TYPE,@IDENTIDAD,@SIZE,@COLLATION_NAME,@IS_KEY,@COLUMN_NAME_KEY,@TABLE_NAME_KEY,@COLUMN_NAME_KEY_TEXT,@SUBTIPO, @ESCALCULADO, @ESCOMBO, @ENLISTA, @ENEDICION, @DOMAIN_NAME, @TABLE_SCHEMA, @ORDEN  ,@ENUPDATE ,@ENINSERT ,@TIPOCONTROL ,@CATALOGO ,@CATALOGOCAMPOCLAVE ,@CATALOGOCAMPONOMBRE ,@CATALOGOLISTAVMNAME ,@CATALOGOSELECTOBJECTNAME ,@CATALOGOSELECTFIELDTNAME, @ORDEN2 ,@NOMBREENFORM ,@GRUPOFORM, @ANCHOB12, @TAB, @ENBUSQUEDALISTA, @ESSUBENTIDAD , @SUBENTIDADTIPO , @SUBENTIDADCAMPO , @SUBENTIDADCAMPOREL, @DEFAULTVALUE , @ESCAMPODECATALOGO , @ENTIDADCATALOGO , @ENTIDADCATALOGOCAMPO , @ENTIDADCATALOGOCAMPOREL, @ESCATALOGOGENERICO, @GRID, @OBJETOPROPIEDAD, @PROPIEDAD)";

                        oleParts = new ArrayList();




                        int contadorCampos = 0;
                        foreach (DataRow dr2 in this.dsGeneracion1.columnas.Rows)
                        {
                            contadorCampos = contadorCampos + 1;

                            oleParts = new ArrayList();

                            oleParts.Add(createParameterFromDataRow(dr2, "TABLE_NAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_DEFAULT"));
                            oleParts.Add(createParameterFromDataRow(dr2, "IS_NULLABLE"));
                            oleParts.Add(createParameterFromDataRow(dr2, "DATA_TYPE"));
                            oleParts.Add(createParameterFromDataRow(dr2, "IDENTIDAD"));
                            oleParts.Add(createParameterFromDataRow(dr2, "SIZE"));
                            oleParts.Add(createParameterFromDataRow(dr2, "COLLATION_NAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "IS_KEY"));
                            oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME_KEY"));
                            oleParts.Add(createParameterFromDataRow(dr2, "TABLE_NAME_KEY"));
                            oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME_KEY_TEXT"));
                            oleParts.Add(createParameterFromDataRow(dr2, "SUBTIPO"));


                            oleParts.Add(createParameterFromDataRow(dr2, "ESCALCULADO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ESCOMBO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENLISTA"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENEDICION"));
                            oleParts.Add(createParameterFromDataRow(dr2, "DOMAIN_NAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "TABLE_SCHEMA"));

                            oleParts.Add(createParameterFromDataRow(dr2, "ORDEN"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENUPDATE"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENINSERT"));
                            oleParts.Add(createParameterFromDataRow(dr2, "TIPOCONTROL"));
                            oleParts.Add(createParameterFromDataRow(dr2, "CATALOGO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOCAMPOCLAVE"));
                            oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOCAMPONOMBRE"));
                            oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOLISTAVMNAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOSELECTOBJECTNAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOSELECTFIELDTNAME"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ORDEN2"));
                            oleParts.Add(createParameterFromDataRow(dr2, "NOMBREENFORM"));
                            oleParts.Add(createParameterFromDataRow(dr2, "GRUPOFORM"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ANCHOB12"));
                            oleParts.Add(createParameterFromDataRow(dr2, "TAB"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENBUSQUEDALISTA"));


                            oleParts.Add(createParameterFromDataRow(dr2, "ESSUBENTIDAD"));
                            oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADTIPO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADCAMPO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADCAMPOREL"));
                            oleParts.Add(createParameterFromDataRow(dr2, "DEFAULTVALUE"));

                            oleParts.Add(createParameterFromDataRow(dr2, "ESCAMPODECATALOGO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGOCAMPO"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGOCAMPOREL"));
                            oleParts.Add(createParameterFromDataRow(dr2, "ESCATALOGOGENERICO"));


                            oleParts.Add(createParameterFromDataRow(dr2, "GRID"));
                            oleParts.Add(createParameterFromDataRow(dr2, "OBJETOPROPIEDAD"));
                            oleParts.Add(createParameterFromDataRow(dr2, "PROPIEDAD"));


                            oleArParms = new OleDbParameter[oleParts.Count];
                            oleParts.CopyTo(oleArParms, 0);

                            OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);


                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }




                }
            }



            MessageBox.Show("Se ha creado el excel ");
        }



        public void generarExcelParameterControllers(string archivoExcel)
        {


            if ((this.dsGeneracion1.UserTables.Rows.Count <= 0))
            {
                MessageBox.Show("Primero logueese al sistema");
                return;
            }

            if ((string.IsNullOrEmpty(archivoExcel)))
            {
                MessageBox.Show("Primero seleccione un excel destino");
                return;
            }


            if (File.Exists(archivoExcel))
                File.Delete(archivoExcel);

            File.Copy("molde.xlsx", archivoExcel);


            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;MAXSCANROWS=15;READONLY=FALSE\"";


            String oleCmdTxt = "";
            System.Collections.ArrayList oleParts = new ArrayList();
            OleDbParameter[] oleArParms = new OleDbParameter[oleParts.Count];
            oleParts.CopyTo(oleArParms, 0);



            foreach (DataRow dr in this.dsGeneracion1.UserTables.Rows)
            {
                //If (Boolean.Parse(dr("cb").ToString()) = True) Then


                oleParts = new ArrayList();
                oleArParms = new OleDbParameter[oleParts.Count];
                oleParts.CopyTo(oleArParms, 0);

                string strNameTable = (string)dr["Name"];
                string strNameTableHyphenized = (string)dr["NameHyphenized"];
                string strNameTableTitle = (string)dr["Title"];
                string strNameTableReal = (string)dr["NameRealTable"];
                string strSchema = (string)dr["Schema_"];
                string strFolder = (string)dr["Folder"];
                string strTipo = (string)dr["Tipo"];
                string strNameParent = (string)dr["NameParent"];
                string strQuery = (string)dr["Query"];
                string strForeignMainKey = (string)dr["ForeignMainKey"];
                string strCampoClave = (string)dr["CampoClave"];
                string strCampoNombre = (string)dr["CampoNombre"];
                string strEsTablaGeneral = (string)dr["EsTablaGeneral"];

                string strNameTableSheet = strNameTableHyphenized; // strNameTable.Length > 27 ? strNameTable.Substring(0, 27) : strNameTable;



                if ((dr["cb"].ToString() == "1"))
                {



                    //LlenarDatosColumnas(fuente, dr[0].ToString());

                    this.dsGeneracion1.columnas.Clear();


                    string? typeName = strNameParent;
                    if (typeName == null)
                        return;

                    Type? type = Type.GetType(typeName);
                    AddParameterMethodsToGrid(type, dr["Name"].ToString(), strNameTableTitle, strNameTable);


                    if (this.dsGeneracion1.columnas.Rows.Count > 0)
                    {
                        //crea la tabla especifica
                        try
                        {

                            oleCmdTxt = @"DROP TABLE [" + strNameTableSheet + "] ; ";
                            try
                            {
                                OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                                //MessageBox.Show("Error droping table " + ex.Message);
                                //return;
                            }
                            oleCmdTxt = @"CREATE TABLE [" + strNameTableSheet + "] (TABLE_NAME VARCHAR,COLUMN_NAME VARCHAR,COLUMN_DEFAULT VARCHAR,IS_NULLABLE VARCHAR,DATA_TYPE VARCHAR,IDENTIDAD VARCHAR,'SIZE' VARCHAR,COLLATION_NAME VARCHAR,IS_KEY VARCHAR,COLUMN_NAME_KEY VARCHAR,TABLE_NAME_KEY VARCHAR,COLUMN_NAME_KEY_TEXT VARCHAR,SUBTIPO VARCHAR, ESCALCULADO VARCHAR, ESCOMBO VARCHAR, ENLISTA VARCHAR, " +
                                "ENEDICION VARCHAR, DOMAIN_NAME VARCHAR,TABLE_SCHEMA VARCHAR, ORDEN VARCHAR,ENUPDATE VARCHAR,ENINSERT VARCHAR,TIPOCONTROL VARCHAR,CATALOGO VARCHAR,CATALOGOCAMPOCLAVE VARCHAR,CATALOGOCAMPONOMBRE VARCHAR,CATALOGOLISTAVMNAME VARCHAR,CATALOGOSELECTOBJECTNAME VARCHAR,CATALOGOSELECTFIELDTNAME VARCHAR, ORDEN2 VARCHAR, NOMBREENFORM VARCHAR, ANCHOB12 VARCHAR, TAB VARCHAR, GRUPOFORM VARCHAR, ENBUSQUEDALISTA VARCHAR," +
                                "ESSUBENTIDAD VARCHAR, SUBENTIDADTIPO VARCHAR, SUBENTIDADCAMPO VARCHAR, SUBENTIDADCAMPOREL VARCHAR,DEFAULTVALUE VARCHAR, ESCAMPODECATALOGO VARCHAR, ENTIDADCATALOGO VARCHAR, ENTIDADCATALOGOCAMPO VARCHAR, ENTIDADCATALOGOCAMPOREL VARCHAR, ESCATALOGOGENERICO VARCHAR, GRID VARCHAR, OBJETOPROPIEDAD VARCHAR, PROPIEDAD VARCHAR); ";
                            OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error creating table " + ex.Message);
                            return;
                        }
                    }





                    //agrega la tabla a la lista de tablas en el excel
                    try
                    {


                        oleCmdTxt = "INSERT INTO [tables$] (Name, NameHyphenized,Title,NameRealTable,Schema_,Folder, Tipo, NameParent, Query,ForeignMainKey, CampoClave, CampoNombre, EsTablaGeneral) VALUES (@Name, @NameHyphenized, @Title, @NameRealTable, @Schema_,@Folder,@Tipo, @NameParent, @Query, @ForeignMainKey,@CampoClave, @CampoNombre, @EsTablaGeneral)";

                        oleParts = new ArrayList();



                        OleDbParameter oleAuxPar = new OleDbParameter("@Name", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTable;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameHyphenized", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableHyphenized;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Title", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableTitle;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameRealTable", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableReal;
                        oleParts.Add(oleAuxPar);



                        oleAuxPar = new OleDbParameter("@Schema_", OleDbType.VarChar);
                        oleAuxPar.Value = strSchema;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Folder", OleDbType.VarChar);
                        oleAuxPar.Value = strFolder;
                        oleParts.Add(oleAuxPar);


                        oleAuxPar = new OleDbParameter("@Tipo", OleDbType.VarChar);
                        oleAuxPar.Value = strTipo;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameParent", OleDbType.VarChar);
                        oleAuxPar.Value = strNameParent;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Query", OleDbType.LongVarChar);
                        oleAuxPar.Value = strQuery;
                        oleParts.Add(oleAuxPar);


                        oleAuxPar = new OleDbParameter("@ForeignMainKey", OleDbType.LongVarChar);
                        oleAuxPar.Value = strForeignMainKey;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@CampoClave", OleDbType.VarChar);
                        oleAuxPar.Value = strCampoClave;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@CampoNombre", OleDbType.VarChar);
                        oleAuxPar.Value = strCampoNombre;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@EsTablaGeneral", OleDbType.VarChar);
                        oleAuxPar.Value = strEsTablaGeneral;
                        oleParts.Add(oleAuxPar);

                        oleArParms = new OleDbParameter[oleParts.Count];
                        oleParts.CopyTo(oleArParms, 0);

                        OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }



                    if (this.dsGeneracion1.columnas.Rows.Count > 0)
                    {

                        try
                        {



                            oleCmdTxt = "INSERT INTO [" + strNameTableSheet + "$] (TABLE_NAME,COLUMN_NAME,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,IDENTIDAD,'SIZE',COLLATION_NAME,IS_KEY,COLUMN_NAME_KEY,TABLE_NAME_KEY,COLUMN_NAME_KEY_TEXT,SUBTIPO, ESCALCULADO, ESCOMBO, ENLISTA, ENEDICION, DOMAIN_NAME,TABLE_SCHEMA, ORDEN  ,ENUPDATE ,ENINSERT ,TIPOCONTROL ,CATALOGO ,CATALOGOCAMPOCLAVE ,CATALOGOCAMPONOMBRE ,CATALOGOLISTAVMNAME ,CATALOGOSELECTOBJECTNAME ,CATALOGOSELECTFIELDTNAME ,ORDEN2 ,NOMBREENFORM ,GRUPOFORM, ANCHOB12, TAB,  ENBUSQUEDALISTA, ESSUBENTIDAD , SUBENTIDADTIPO , SUBENTIDADCAMPO , SUBENTIDADCAMPOREL, DEFAULTVALUE ,ESCAMPODECATALOGO , ENTIDADCATALOGO , ENTIDADCATALOGOCAMPO , ENTIDADCATALOGOCAMPOREL, ESCATALOGOGENERICO, GRID, OBJETOPROPIEDAD, PROPIEDAD ) " +
                                "VALUES (@TABLE_NAME,@COLUMN_NAME,@COLUMN_DEFAULT,@IS_NULLABLE,@DATA_TYPE,@IDENTIDAD,@SIZE,@COLLATION_NAME,@IS_KEY,@COLUMN_NAME_KEY,@TABLE_NAME_KEY,@COLUMN_NAME_KEY_TEXT,@SUBTIPO, @ESCALCULADO, @ESCOMBO, @ENLISTA, @ENEDICION, @DOMAIN_NAME, @TABLE_SCHEMA, @ORDEN  ,@ENUPDATE ,@ENINSERT ,@TIPOCONTROL ,@CATALOGO ,@CATALOGOCAMPOCLAVE ,@CATALOGOCAMPONOMBRE ,@CATALOGOLISTAVMNAME ,@CATALOGOSELECTOBJECTNAME ,@CATALOGOSELECTFIELDTNAME, @ORDEN2 ,@NOMBREENFORM ,@GRUPOFORM, @ANCHOB12, @TAB, @ENBUSQUEDALISTA, @ESSUBENTIDAD , @SUBENTIDADTIPO , @SUBENTIDADCAMPO , @SUBENTIDADCAMPOREL, @DEFAULTVALUE , @ESCAMPODECATALOGO , @ENTIDADCATALOGO , @ENTIDADCATALOGOCAMPO , @ENTIDADCATALOGOCAMPOREL, @ESCATALOGOGENERICO, @GRID, @OBJETOPROPIEDAD, @PROPIEDAD)";

                            oleParts = new ArrayList();




                            int contadorCampos = 0;
                            foreach (DataRow dr2 in this.dsGeneracion1.columnas.Rows)
                            {
                                contadorCampos = contadorCampos + 1;

                                oleParts = new ArrayList();

                                oleParts.Add(createParameterFromDataRow(dr2, "TABLE_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_DEFAULT"));
                                oleParts.Add(createParameterFromDataRow(dr2, "IS_NULLABLE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "DATA_TYPE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "IDENTIDAD"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SIZE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLLATION_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "IS_KEY"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME_KEY"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TABLE_NAME_KEY"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME_KEY_TEXT"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBTIPO"));


                                oleParts.Add(createParameterFromDataRow(dr2, "ESCALCULADO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ESCOMBO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENLISTA"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENEDICION"));
                                oleParts.Add(createParameterFromDataRow(dr2, "DOMAIN_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TABLE_SCHEMA"));

                                oleParts.Add(createParameterFromDataRow(dr2, "ORDEN"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENUPDATE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENINSERT"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TIPOCONTROL"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOCAMPOCLAVE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOCAMPONOMBRE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOLISTAVMNAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOSELECTOBJECTNAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOSELECTFIELDTNAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ORDEN2"));
                                oleParts.Add(createParameterFromDataRow(dr2, "NOMBREENFORM"));
                                oleParts.Add(createParameterFromDataRow(dr2, "GRUPOFORM"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ANCHOB12"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TAB"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENBUSQUEDALISTA"));


                                oleParts.Add(createParameterFromDataRow(dr2, "ESSUBENTIDAD"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADTIPO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADCAMPO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADCAMPOREL"));
                                oleParts.Add(createParameterFromDataRow(dr2, "DEFAULTVALUE"));

                                oleParts.Add(createParameterFromDataRow(dr2, "ESCAMPODECATALOGO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGOCAMPO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGOCAMPOREL"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ESCATALOGOGENERICO"));


                                oleParts.Add(createParameterFromDataRow(dr2, "GRID"));
                                oleParts.Add(createParameterFromDataRow(dr2, "OBJETOPROPIEDAD"));
                                oleParts.Add(createParameterFromDataRow(dr2, "PROPIEDAD"));


                                oleArParms = new OleDbParameter[oleParts.Count];
                                oleParts.CopyTo(oleArParms, 0);

                                OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);


                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }



                }
            }



            MessageBox.Show("Se ha creado el excel ");
        }


        public void generarExcelControllers(string archivoExcel)
        {


            if ((this.dsGeneracion1.UserTables.Rows.Count <= 0))
            {
                MessageBox.Show("Primero logueese al sistema");
                return;
            }

            if ((string.IsNullOrEmpty(archivoExcel)))
            {
                MessageBox.Show("Primero seleccione un excel destino");
                return;
            }


            if (File.Exists(archivoExcel))
                File.Delete(archivoExcel);

            File.Copy("molde.xlsx", archivoExcel);


            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;MAXSCANROWS=15;READONLY=FALSE\"";


            String oleCmdTxt = "";
            System.Collections.ArrayList oleParts = new ArrayList();
            OleDbParameter[] oleArParms = new OleDbParameter[oleParts.Count];
            oleParts.CopyTo(oleArParms, 0);



            foreach (DataRow dr in this.dsGeneracion1.UserTables.Rows)
            {
                //If (Boolean.Parse(dr("cb").ToString()) = True) Then


                oleParts = new ArrayList();
                oleArParms = new OleDbParameter[oleParts.Count];
                oleParts.CopyTo(oleArParms, 0);

                string strNameTable = (string)dr["Name"];
                string strNameTableHyphenized = (string)dr["NameHyphenized"];
                string strNameTableTitle = (string)dr["Title"];
                string strNameTableReal = (string)dr["NameRealTable"];
                string strSchema = (string)dr["Schema_"];
                string strFolder = (string)dr["Folder"];
                string strTipo = (string)dr["Tipo"];
                string strNameParent = (string)dr["NameParent"];
                string strQuery = (string)dr["Query"];
                string strForeignMainKey = (string)dr["ForeignMainKey"];
                string strCampoClave = (string)dr["CampoClave"];
                string strCampoNombre = (string)dr["CampoNombre"];
                string strEsTablaGeneral = (string)dr["EsTablaGeneral"];

                string strNameTableSheet = strNameTable.Length > 27 ? strNameTable.Substring(0, 27) : strNameTable;



                if ((dr["cb"].ToString() == "1"))
                {



                    //LlenarDatosColumnas(fuente, dr[0].ToString());

                    this.dsGeneracion1.columnas.Clear();


                    string? typeName = dr["NameRealTable"].ToString();
                    if (typeName == null)
                        return;

                    Type? type = Type.GetType(typeName);
                    AddEntityMethodsToGrid(type, dr["Name"].ToString());


                    if (this.dsGeneracion1.columnas.Rows.Count > 0)
                    {
                        //crea la tabla especifica
                        try
                        {

                            oleCmdTxt = @"DROP TABLE [" + strNameTableSheet + "] ; ";
                            try
                            {
                                OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                                //MessageBox.Show("Error droping table " + ex.Message);
                                //return;
                            }
                            oleCmdTxt = @"CREATE TABLE [" + strNameTableSheet + "] (TABLE_NAME VARCHAR,COLUMN_NAME VARCHAR,COLUMN_DEFAULT VARCHAR,IS_NULLABLE VARCHAR,DATA_TYPE VARCHAR,IDENTIDAD VARCHAR,'SIZE' VARCHAR,COLLATION_NAME VARCHAR,IS_KEY VARCHAR,COLUMN_NAME_KEY VARCHAR,TABLE_NAME_KEY VARCHAR,COLUMN_NAME_KEY_TEXT VARCHAR,SUBTIPO VARCHAR, ESCALCULADO VARCHAR, ESCOMBO VARCHAR, ENLISTA VARCHAR, " +
                                "ENEDICION VARCHAR, DOMAIN_NAME VARCHAR,TABLE_SCHEMA VARCHAR, ORDEN VARCHAR,ENUPDATE VARCHAR,ENINSERT VARCHAR,TIPOCONTROL VARCHAR,CATALOGO VARCHAR,CATALOGOCAMPOCLAVE VARCHAR,CATALOGOCAMPONOMBRE VARCHAR,CATALOGOLISTAVMNAME VARCHAR,CATALOGOSELECTOBJECTNAME VARCHAR,CATALOGOSELECTFIELDTNAME VARCHAR, ORDEN2 VARCHAR, NOMBREENFORM VARCHAR, ANCHOB12 VARCHAR, TAB VARCHAR, GRUPOFORM VARCHAR, ENBUSQUEDALISTA VARCHAR," +
                                "ESSUBENTIDAD VARCHAR, SUBENTIDADTIPO VARCHAR, SUBENTIDADCAMPO VARCHAR, SUBENTIDADCAMPOREL VARCHAR,DEFAULTVALUE VARCHAR, ESCAMPODECATALOGO VARCHAR, ENTIDADCATALOGO VARCHAR, ENTIDADCATALOGOCAMPO VARCHAR, ENTIDADCATALOGOCAMPOREL VARCHAR, ESCATALOGOGENERICO VARCHAR, GRID VARCHAR, OBJETOPROPIEDAD VARCHAR, PROPIEDAD VARCHAR); ";
                            OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error creating table " + ex.Message);
                            return;
                        }
                    }





                    //agrega la tabla a la lista de tablas en el excel
                    try
                    {


                        oleCmdTxt = "INSERT INTO [tables$] (Name, NameHyphenized,Title,NameRealTable,Schema_,Folder, Tipo, NameParent, Query,ForeignMainKey, CampoClave, CampoNombre, EsTablaGeneral) VALUES (@Name, @NameHyphenized, @Title, @NameRealTable, @Schema_,@Folder,@Tipo, @NameParent, @Query, @ForeignMainKey,@CampoClave, @CampoNombre, @EsTablaGeneral)";

                        oleParts = new ArrayList();



                        OleDbParameter oleAuxPar = new OleDbParameter("@Name", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTable;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameHyphenized", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableHyphenized;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Title", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableTitle;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameRealTable", OleDbType.VarChar);
                        oleAuxPar.Value = strNameTableReal;
                        oleParts.Add(oleAuxPar);



                        oleAuxPar = new OleDbParameter("@Schema_", OleDbType.VarChar);
                        oleAuxPar.Value = strSchema;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Folder", OleDbType.VarChar);
                        oleAuxPar.Value = strFolder;
                        oleParts.Add(oleAuxPar);


                        oleAuxPar = new OleDbParameter("@Tipo", OleDbType.VarChar);
                        oleAuxPar.Value = strTipo;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@NameParent", OleDbType.VarChar);
                        oleAuxPar.Value = strNameParent;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@Query", OleDbType.LongVarChar);
                        oleAuxPar.Value = strQuery;
                        oleParts.Add(oleAuxPar);


                        oleAuxPar = new OleDbParameter("@ForeignMainKey", OleDbType.LongVarChar);
                        oleAuxPar.Value = strForeignMainKey;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@CampoClave", OleDbType.VarChar);
                        oleAuxPar.Value = strCampoClave;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@CampoNombre", OleDbType.VarChar);
                        oleAuxPar.Value = strCampoNombre;
                        oleParts.Add(oleAuxPar);

                        oleAuxPar = new OleDbParameter("@EsTablaGeneral", OleDbType.VarChar);
                        oleAuxPar.Value = strEsTablaGeneral;
                        oleParts.Add(oleAuxPar);

                        oleArParms = new OleDbParameter[oleParts.Count];
                        oleParts.CopyTo(oleArParms, 0);

                        OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }



                    if (this.dsGeneracion1.columnas.Rows.Count > 0)
                    {

                        try
                        {



                            oleCmdTxt = "INSERT INTO [" + strNameTableSheet + "$] (TABLE_NAME,COLUMN_NAME,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE,IDENTIDAD,'SIZE',COLLATION_NAME,IS_KEY,COLUMN_NAME_KEY,TABLE_NAME_KEY,COLUMN_NAME_KEY_TEXT,SUBTIPO, ESCALCULADO, ESCOMBO, ENLISTA, ENEDICION, DOMAIN_NAME,TABLE_SCHEMA, ORDEN  ,ENUPDATE ,ENINSERT ,TIPOCONTROL ,CATALOGO ,CATALOGOCAMPOCLAVE ,CATALOGOCAMPONOMBRE ,CATALOGOLISTAVMNAME ,CATALOGOSELECTOBJECTNAME ,CATALOGOSELECTFIELDTNAME ,ORDEN2 ,NOMBREENFORM ,GRUPOFORM, ANCHOB12, TAB,  ENBUSQUEDALISTA, ESSUBENTIDAD , SUBENTIDADTIPO , SUBENTIDADCAMPO , SUBENTIDADCAMPOREL, DEFAULTVALUE ,ESCAMPODECATALOGO , ENTIDADCATALOGO , ENTIDADCATALOGOCAMPO , ENTIDADCATALOGOCAMPOREL, ESCATALOGOGENERICO, GRID, OBJETOPROPIEDAD, PROPIEDAD ) " +
                                "VALUES (@TABLE_NAME,@COLUMN_NAME,@COLUMN_DEFAULT,@IS_NULLABLE,@DATA_TYPE,@IDENTIDAD,@SIZE,@COLLATION_NAME,@IS_KEY,@COLUMN_NAME_KEY,@TABLE_NAME_KEY,@COLUMN_NAME_KEY_TEXT,@SUBTIPO, @ESCALCULADO, @ESCOMBO, @ENLISTA, @ENEDICION, @DOMAIN_NAME, @TABLE_SCHEMA, @ORDEN  ,@ENUPDATE ,@ENINSERT ,@TIPOCONTROL ,@CATALOGO ,@CATALOGOCAMPOCLAVE ,@CATALOGOCAMPONOMBRE ,@CATALOGOLISTAVMNAME ,@CATALOGOSELECTOBJECTNAME ,@CATALOGOSELECTFIELDTNAME, @ORDEN2 ,@NOMBREENFORM ,@GRUPOFORM, @ANCHOB12, @TAB, @ENBUSQUEDALISTA, @ESSUBENTIDAD , @SUBENTIDADTIPO , @SUBENTIDADCAMPO , @SUBENTIDADCAMPOREL, @DEFAULTVALUE , @ESCAMPODECATALOGO , @ENTIDADCATALOGO , @ENTIDADCATALOGOCAMPO , @ENTIDADCATALOGOCAMPOREL, @ESCATALOGOGENERICO, @GRID, @OBJETOPROPIEDAD, @PROPIEDAD)";

                            oleParts = new ArrayList();




                            int contadorCampos = 0;
                            foreach (DataRow dr2 in this.dsGeneracion1.columnas.Rows)
                            {
                                contadorCampos = contadorCampos + 1;

                                oleParts = new ArrayList();

                                oleParts.Add(createParameterFromDataRow(dr2, "TABLE_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_DEFAULT"));
                                oleParts.Add(createParameterFromDataRow(dr2, "IS_NULLABLE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "DATA_TYPE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "IDENTIDAD"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SIZE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLLATION_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "IS_KEY"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME_KEY"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TABLE_NAME_KEY"));
                                oleParts.Add(createParameterFromDataRow(dr2, "COLUMN_NAME_KEY_TEXT"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBTIPO"));


                                oleParts.Add(createParameterFromDataRow(dr2, "ESCALCULADO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ESCOMBO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENLISTA"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENEDICION"));
                                oleParts.Add(createParameterFromDataRow(dr2, "DOMAIN_NAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TABLE_SCHEMA"));

                                oleParts.Add(createParameterFromDataRow(dr2, "ORDEN"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENUPDATE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENINSERT"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TIPOCONTROL"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOCAMPOCLAVE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOCAMPONOMBRE"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOLISTAVMNAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOSELECTOBJECTNAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "CATALOGOSELECTFIELDTNAME"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ORDEN2"));
                                oleParts.Add(createParameterFromDataRow(dr2, "NOMBREENFORM"));
                                oleParts.Add(createParameterFromDataRow(dr2, "GRUPOFORM"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ANCHOB12"));
                                oleParts.Add(createParameterFromDataRow(dr2, "TAB"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENBUSQUEDALISTA"));


                                oleParts.Add(createParameterFromDataRow(dr2, "ESSUBENTIDAD"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADTIPO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADCAMPO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "SUBENTIDADCAMPOREL"));
                                oleParts.Add(createParameterFromDataRow(dr2, "DEFAULTVALUE"));

                                oleParts.Add(createParameterFromDataRow(dr2, "ESCAMPODECATALOGO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGOCAMPO"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ENTIDADCATALOGOCAMPOREL"));
                                oleParts.Add(createParameterFromDataRow(dr2, "ESCATALOGOGENERICO"));


                                oleParts.Add(createParameterFromDataRow(dr2, "GRID"));
                                oleParts.Add(createParameterFromDataRow(dr2, "OBJETOPROPIEDAD"));
                                oleParts.Add(createParameterFromDataRow(dr2, "PROPIEDAD"));


                                oleArParms = new OleDbParameter[oleParts.Count];
                                oleParts.CopyTo(oleArParms, 0);

                                OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);


                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }



                }
            }



            MessageBox.Show("Se ha creado el excel ");
        }


        private OleDbParameter createParameterFromDataRow(DataRow dr2, string field)
        {

            OleDbParameter oleAuxPar = new OleDbParameter("@" + field, OleDbType.VarChar);
            oleAuxPar.Value = dr2[field];

            if (dr2[field] != null && dr2[field].ToString().Length > 256)
                oleAuxPar.Value = dr2[field].ToString().Substring(0,255);

            return oleAuxPar;
        }


        public void LoadTableInfoFromExcel(string archivoExcel)
        {
            try
            {
                this.dsGeneracion1.UserTables.Clear();

                string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
                System.Collections.ArrayList parts = new ArrayList();
                //OleDbParameter auxPar;
                String CmdTxt = @"select * from [tables$]";// order by Name";
                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                OleDbDataReader dr;
                dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);

                try
                {


                    while (dr.Read())
                    {

                        UserTablesRow row = this.dsGeneracion1.UserTables.NewUserTablesRow();

                        row.cb = 0;

                        if (dr["Name"] != System.DBNull.Value)
                        {
                            row.Name = (dr["Name"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }

                        if (dr["NameHyphenized"] != System.DBNull.Value)
                        {
                            row.NameHyphenized = (dr["NameHyphenized"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["Title"] != System.DBNull.Value)
                        {
                            row.Title = (dr["Title"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }

                        if (dr["NameRealTable"] != System.DBNull.Value)
                        {
                            row.NameRealTable = (dr["NameRealTable"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["Schema_"] != System.DBNull.Value)
                        {
                            row.Schema_ = (dr["Schema_"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }



                        if (dr["Folder"] != System.DBNull.Value)
                        {
                            row.Folder = (dr["Folder"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["Tipo"] != System.DBNull.Value)
                        {
                            row.Tipo = (dr["Tipo"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["NameParent"] != System.DBNull.Value)
                        {
                            row.NameParent = (dr["NameParent"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }

                        if (dr["Query"] != System.DBNull.Value)
                        {
                            row.Query = (dr["Query"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["ForeignMainKey"] != System.DBNull.Value)
                        {
                            row.ForeignMainKey = (dr["ForeignMainKey"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }




                        if (dr["CampoClave"] != System.DBNull.Value)
                        {
                            row.CampoClave = (dr["CampoClave"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["CampoNombre"] != System.DBNull.Value)
                        {
                            row.CampoNombre = (dr["CampoNombre"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }


                        if (dr["EsTablaGeneral"] != System.DBNull.Value)
                        {
                            row.EsTablaGeneral = (dr["EsTablaGeneral"]).ToString()!.Trim();
                        }
                        else
                        {
                            continue;
                        }

                        this.dsGeneracion1.UserTables.AddUserTablesRow(row);

                    }

                    dr.Close();





                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error 1 " + ex.Message);
                    return;
                }
                finally
                {
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error 2 " + ex.Message);
                return;
            }
        }

    }

}
