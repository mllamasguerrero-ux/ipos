using Castle.Core.Internal;
using DataLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeGenerator.DSGeneracion;
using IposV3.Extensions;

namespace CodeGenerator
{
    public class RealCodeGenerator
    {
        public CodeGenerator.DSGeneracion DataSetSchema1;
        public CodeGenerator.ExcelWebCustomCtrls ExcelWebCustomCtrls1;

        public CommonGenerationLogic commonGenerationLogic;

        public RealCodeGenerator(CodeGenerator.DSGeneracion DataSetSchema1, CodeGenerator.ExcelWebCustomCtrls ExcelWebCustomCtrls1)
        {
            this.DataSetSchema1 = DataSetSchema1;
            this.ExcelWebCustomCtrls1 = ExcelWebCustomCtrls1;
            commonGenerationLogic = new CommonGenerationLogic();


        }




        private void LlenarDatosPlantilla(string archivo)
        {
            this.ExcelWebCustomCtrls1.Tables["Hoja1"]?.Clear();

            string fileText = System.IO.File.ReadAllText(archivo);
            string[] fileTextSplit = fileText.Split(new string[] { "!!!!!" }, StringSplitOptions.None);




            List<ExcelWebCustomCtrls.Hoja1Row> rows = new List<ExcelWebCustomCtrls.Hoja1Row>();

            Dictionary<string, string> textosItems = new Dictionary<string, string>();

            if (fileTextSplit.Length >= 2)
            {

                string[] dataPartText = fileTextSplit[0].Split(new string[] { "|||||" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string strItemDual in dataPartText)
                {
                    string[] strItem = strItemDual.Split(new string[] { "+++++" }, StringSplitOptions.None);
                    textosItems.Add(strItem[0], strItem[1]);
                }

            }
            else
            {
                textosItems.Add("0", fileTextSplit[0]);
            }

            string[] defPartLines = new string[1] { "0;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0" };
            if (fileTextSplit.Length >= 2)
            {
                defPartLines = fileTextSplit[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string strLine in defPartLines)
            {
                string[] defPartPart = strLine.Split(new string[] { ";" }, StringSplitOptions.None);

                ExcelWebCustomCtrls.Hoja1Row row = this.ExcelWebCustomCtrls1.Hoja1.NewHoja1Row();

                if (defPartPart.Length >= 1)
                    row.ID = defPartPart[0];

                if (defPartPart.Length >= 2)
                    row.TIPOREPETICION = double.Parse(defPartPart[1]);
                if (defPartPart.Length >= 3)
                    row.ORDEN = double.Parse(defPartPart[2]);
                if (defPartPart.Length >= 4)
                    row.EQUIVALENCIASTIPOFORMSIGUAL = defPartPart[3];
                if (defPartPart.Length >= 5)
                    row.EQUIVALENCIASTIPOFORMSDIFERENTE = defPartPart[4];
                if (defPartPart.Length >= 6)
                    row.TIPODEDATATYPEIGUAL = defPartPart[5];
                if (defPartPart.Length >= 7)
                    row.TIPODEDATATYPEDIFERENTE = defPartPart[6];
                if (defPartPart.Length >= 8)
                    row.IDENTIDAD = defPartPart[7];
                if (defPartPart.Length >= 9)
                    row.IS_KEY = defPartPart[8];
                if (defPartPart.Length >= 10)
                    row.ISNULLEABLE = defPartPart[9];
                if (defPartPart.Length >= 11)
                    row.QUITARCHR_FINAL = short.Parse(defPartPart[10]);


                row.ESCALCULADO = defPartPart.Length >= 12 ? defPartPart[11] : "IGNORAR";
                row.ESCOMBO = defPartPart.Length >= 13 ? defPartPart[12] : "IGNORAR";
                row.ENLISTA = defPartPart.Length >= 14 ? defPartPart[13] : "IGNORAR";
                row.ENEDICION = defPartPart.Length >= 15 ? defPartPart[14] : "IGNORAR";
                row.DOMAIN_NAME = defPartPart.Length >= 16 ? defPartPart[15] : "IGNORAR";

                row.ORDENAR = defPartPart.Length >= 17 ? defPartPart[16] : "IGNORAR";
                row.ENUPDATE = defPartPart.Length >= 18 ? defPartPart[17] : "IGNORAR";
                row.ENINSERT = defPartPart.Length >= 19 ? defPartPart[18] : "IGNORAR";
                row.TIPOCONTROL = defPartPart.Length >= 20 ? defPartPart[19] : "IGNORAR";
                row.TIPOCONTROLDIFERENTE = defPartPart.Length >= 21 ? defPartPart[20] : "IGNORAR";
                row.SUBTIPOIGUAL = defPartPart.Length >= 22 ? defPartPart[21] : "IGNORAR";
                row.SUBTIPODIFERENTE = defPartPart.Length >= 23 ? defPartPart[22] : "IGNORAR";
                row.TIPOARCHIVO = defPartPart.Length >= 24 ? defPartPart[23] : "IGNORAR";
                row.TIPOARCHIVODIFERENTE = defPartPart.Length >= 25 ? defPartPart[24] : "IGNORAR";
                row.ENBUSQUEDALISTA = defPartPart.Length >= 26 ? defPartPart[25] : "IGNORAR";
                row.ESTABLAGENERAL = defPartPart.Length >= 27 ? defPartPart[26] : "IGNORAR";
                row.ESSUBENTIDAD = defPartPart.Length >= 28 ? defPartPart[27] : "IGNORAR";
                row.ESCAMPODECATALOGO = defPartPart.Length >= 29 ? defPartPart[28] : "IGNORAR";
                row.ESCATALOGOGENERICO = defPartPart.Length >= 30 ? defPartPart[29] : "IGNORAR";
                row.ENGRIDDEFINIDO = defPartPart.Length >= 31 ? defPartPart[30] : (row.TIPOREPETICION == 0 ? "IGNORAR": "NO");

                Console.WriteLine(archivo);
                row.TEXTO = textosItems[row.ID];
                this.ExcelWebCustomCtrls1.Hoja1.AddHoja1Row(row);

            }






        }



        string modoGenerador = "normal";//"migracion""normal";
        public void GenerarCodigo(string fuente, string nombreSistema, string carpetaDestino, string excelPath, string? generationOption = null)
        {
            this.modoGenerador = generationOption != null ? generationOption! : this.modoGenerador;

            if ((this.DataSetSchema1.Tables["UserTables"]!.Rows.Count <= 0))
            {
                MessageBox.Show("Primero logueese al sistema");
                return;
            }


            if ((string.IsNullOrEmpty(carpetaDestino)))
            {
                MessageBox.Show("Primero seleccione una carpeta destino");
                return;
            }

            if(this.ExcelWebCustomCtrls1.Tables["Hoja1"] == null)
            {
                MessageBox.Show("No hay datos en la hoja 1");
                return;
            }



            /*try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "BaseAngular", carpetaDestino, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex.Message + ex.StackTrace);
            }*/


            string carpetaProyecto = @"C:\iPos_v2\IposV3";
            List<ImplConf> realImplConf = new List<ImplConf>();
            List<ImplConfMisc> realConfMiscleneaList = new List<ImplConfMisc>();


            /*Pass*/string _relativeProjectFolderControllersCSharp = @"\Controllers";
            //string _relativeProjectFolderControls = @"\Controls";
            string _relativeProjectFolderDataAccess = @"\DataAccess";
            /*Pass*/string _relativeProjectFolderIposV3 = @"\Views";
            /*Pass*/string _relativeProjectFolderIposV3_ViewModels = @"\ViewModels";
            //string _relativeProjectFolderIposV3_ViewModels_Tests = @"\IposV3.ViewModels.Tests";
            //string _relativeProjectFolderIposV3CustomInstallerActions = @"\IposV3CustomInstallerActions";
            /*Pass*/string _relativeProjectFolderModels = @"\Model";
            /*Pass*/string _relativeProjectFolderModelsAux = @"\Model_Aux";
            //string _relativeProjectFolderQueryTools = @"\QueryTools";


            /*Pass*/string projectFolderControllersCSharp = carpetaProyecto + _relativeProjectFolderControllersCSharp;
            //string projectFolderControls = carpetaProyecto + _relativeProjectFolderControls;
            string projectFolderDataAccess = carpetaProyecto + _relativeProjectFolderDataAccess;
            /*Pass*/string projectFolderIposV3 = carpetaProyecto + _relativeProjectFolderIposV3;
            /*Pass*/string projectFolderIposV3_ViewModels = carpetaProyecto + _relativeProjectFolderIposV3_ViewModels;
            //string projectFolderIposV3_ViewModels_Tests = carpetaProyecto + _relativeProjectFolderIposV3_ViewModels_Tests;
            //string projectFolderIposV3CustomInstallerActions = carpetaProyecto + _relativeProjectFolderIposV3CustomInstallerActions;
            /*Pass*/string projectFolderModels = carpetaProyecto + _relativeProjectFolderModels;
            //string projectFolderQueryTools = carpetaProyecto + _relativeProjectFolderQueryTools;
            /*Pass*/string projectFolderRoot = carpetaProyecto + @"";


            ///*Pass*/string sectionControllersGenerated = "ControllersGenerated";
            /*Pass*/string sectionControllersInherited = "ControllersInherited";
            /*Pass*/string sectionBindingGenerated = "BindingGenerated";
            /*Pass*/string sectionBindingInherited = "BindingInherited";
            //string sectionDaoGenerated = "DaoGenerated";
            //string sectionDaoInherited = "DaoInherited";
            /*Pass*/string sectionView = "View";
            /*Pass*/string sectionViewModels = "ViewModels";
            ///*Pass*/string sectionViewModelsGenerated = "ViewModelsGenerated";
            //string sectionViewModelsTest = "ViewModelsTest";
            /*Pass*/string sectionModelsGenerated = "ModelsGenerated";
            /*Pass*/string sectionModelsInherited = "ModelsInherited";
            //string sectionQueryToolsGenerated = "QueryToolsGenerated";
            ///*Pass*/string sectionSelector = "Selector";
            ///*Pass*/string sectionOther = "Other";
            //string sectionQueryTools = "QueryTools";


            /*Pass*/string projectFileNameControllersCSharp = "Controllers.csproj";
            //string projectFileNameControls = "Controls.csproj";
            ///*Pass*/string projectFileNameDataAccess = "DataAccess.csproj";
            /*Pass*/string projectFileNameIposV3 = "IposV3.csproj";
            /*Pass*/string projectFileNameIposV3_ViewModels = "IposV3.ViewModels.csproj";
            //string projectFileNameIposV3_ViewModels_Tests = "IposV3.ViewModels.Tests.csproj";
            //string projectFileNameIposV3CustomInstallerActions = "IposV3CustomInstallerActions.csproj";
            /*Pass*/string projectFileNameModels = "Models.csproj";
            //string projectFileNameQueryTools = "QueryTools.csproj";
            string projectFileNameRoot = carpetaProyecto + @"";


            /*Pass*/string _bufferFolderControllersCSharp = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderControllersCSharp;
            //string _bufferFFolderControls = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderControls;
            string _bufferFolderDataAccess = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderDataAccess;
            /*Pass*/string _bufferFolderIposV3 = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderIposV3;
            /*Pass*/string _bufferFolderIposV3_ViewModels = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderIposV3_ViewModels;
            //string _bufferFolderIposV3_ViewModels_Tests = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderIposV3_ViewModels_Tests;
            //string _bufferFolderIposV3CustomInstallerActions = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderIposV3CustomInstallerActions;
            /*Pass*/string _bufferFolderModels = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderModels;
            /*Pass*/string _bufferFolderModelsAux = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderModelsAux;
            //string _bufferFolderQueryTools = carpetaDestino + @"\BaseAngular" + _relativeProjectFolderQueryTools;
            /*Pass*/string _bufferFolderRoot = carpetaDestino + @"\BaseAngular";
            /*Pass*/string _bufferFolderMiscelanea = carpetaDestino + @"\BaseAngular\Miscelanea";


            /*Pass*/string _relativeFolderModelsCSharp = "";
            /*Pass*/string _relativeFolderModelsCSharpAux = @"";
            string _relativeFolderDaoCSharp = @"\DAO";
            //string _relativeFolderDaoCSharpGenerated = @"\DAO";
            //string _relativeFolderAngularComponents = @"\ClientApp\src\app\admin\(nombreTablaMinPrimeraLetra)";
            //string _relativeFolderAngularModel = @"\ClientApp\src\app\admin\services\api\models";
            /*Pass*/string _relativeFolderControllersCSharp = @"";
            //string _relativeFolderControllersWebCSharp = @"\Web\Controllers";
            //string _relativeFolderAngularWS = @"\ClientApp\src\app\admin\services\api\rest\";
            /*Pass*/string _relativeFolderViewModel = "";
            /*Pass*/string _relativeFolderView = "";
            /*Pass*/string _relativeFolderController = @"\Controller";
            /*Pass*/string _relativeFolderBindingModel = @"\BindingModel";
            /*Pass*/string _relativeFolderMiscelanea = "";
            //string _relativeFolderDaoCSharpGeneratedinto = @"\DAO\GeneratedDAOs";
            //string _relativeFolderDaoCSharpGeneratedStoreProc = @"\Storeproc";
            //string _relativeFolderAngularAdminServices = @"\ClientApp\src\app\admin\services\";
            //string _relativeFolderAngularAdmin = @"\ClientApp\src\app\admin\";
            //string _relativeFolderAngularAdminLayout = @"\ClientApp\src\app\adminLayout\";
            /*Pass*/string _relativeFolderModelsGeneratedCSharp = @"\Generated";
            /*Pass*/string _relativeFolderBindingModelGenerated = @"\BindingModel";
            //string _relativeFolderControllerGenerated = @"\Controller\Generated";
            //string _relativeFolderDaoQueryToolsGeneratedinto = @"\Generated";
            //string _relativeFolderPruebasUnitariasExcel = @"\PruebasUnitariasExcel";
            //string _relativeFolderPruebasUnitariasTest = "";
            //string _relativeFolderDaoQueryToolsinto = @"";
            /*Pass*/string _relativeFolderViewModelGenerated = @"\Generated";





            /*Pass*/string projFolderModelsCSharp = projectFolderModels + _relativeFolderModelsCSharp;
            string projFolderDaoCSharp = projectFolderDataAccess + _relativeFolderDaoCSharp;
            //string projFolderDaoCSharpGenerated = projectFolderDataAccess + _relativeFolderDaoCSharpGenerated;
            //string projFolderAngularComponents = projectFolderRoot + _relativeFolderAngularComponents;
            //string projFolderAngularModel = projectFolderRoot + _relativeFolderAngularModel;
            /*Pass*/string projFolderControllersCSharp = projectFolderControllersCSharp + _relativeFolderControllersCSharp;
            //string projFolderControllersWebCSharp = projectFolderRoot + _relativeFolderControllersWebCSharp;
            //string projFolderAngularWS = projectFolderRoot + _relativeFolderAngularWS;
            /*Pass*/string projFolderViewModel = projectFolderIposV3_ViewModels + _relativeFolderViewModel;
            /*Pass*/string projFolderView = projectFolderIposV3 + _relativeFolderView;
            /*Pass*/string projFolderController = projectFolderControllersCSharp + _relativeFolderController;
            /*Pass*/string projFolderBindingModel = projectFolderControllersCSharp + _relativeFolderBindingModel;
            /*Pass*/string projFolderMiscelanea = projectFolderIposV3 + _relativeFolderMiscelanea;
            //string projFolderDaoCSharpGeneratedinto = projectFolderDataAccess + _relativeFolderDaoCSharpGeneratedinto;
            //string projFolderDaoCSharpGeneratedStoreProc = projectFolderDataAccess + _relativeFolderDaoCSharpGeneratedStoreProc;
            //string projFolderAngularAdminServices = projectFolderRoot + _relativeFolderAngularAdminServices;
            //string projFolderAngularAdmin = projectFolderRoot + _relativeFolderAngularAdmin;
            //string projFolderAngularAdminLayout = projectFolderRoot + _relativeFolderAngularAdminLayout;
            /*Pass*/string projFolderModelsGeneratedCSharp = projectFolderModels + _relativeFolderModelsGeneratedCSharp;
            /*Pass*/string projFolderBindingModelGenerated = projectFolderControllersCSharp + _relativeFolderBindingModelGenerated;
            //string projFolderControllerGenerated = projectFolderControllersCSharp + _relativeFolderControllerGenerated;
            //string projFolderDaoQueryToolsGeneratedinto = projectFolderQueryTools + _relativeFolderDaoQueryToolsGeneratedinto;
            //string projFolderPruebasUnitariasExcel = projectFolderRoot + _relativeFolderPruebasUnitariasExcel;
            //string projFolderPruebasUnitariasTest = projectFolderIposV3_ViewModels_Tests + _relativeFolderPruebasUnitariasTest;
            //string projFolderDaoQueryToolsinto = projectFolderQueryTools;
            /*Pass*/string projFolderViewModelGenerated = projectFolderIposV3_ViewModels + _relativeFolderViewModelGenerated;





            //string folderModelsCSharp = _bufferFolderModels + _relativeFolderModelsCSharp;
            /*Pass*/string folderModelsCSharpAux = _bufferFolderModelsAux + _relativeFolderModelsCSharpAux;
            string folderDaoCSharp = _bufferFolderDataAccess + _relativeFolderDaoCSharp;
            //string folderDaoCSharpGenerated = _bufferFolderDataAccess + _relativeFolderDaoCSharpGenerated;
            //string folderAngularComponents = _bufferFolderRoot + _relativeFolderAngularComponents;
            //string folderAngularModel = _bufferFolderRoot + _relativeFolderAngularModel;
            /*Pass*/string folderControllersCSharp = _bufferFolderControllersCSharp + _relativeFolderControllersCSharp;
            //string folderControllersWebCSharp = _bufferFolderRoot + _relativeFolderControllersWebCSharp;
            //string folderAngularWS = _bufferFolderRoot + _relativeFolderAngularWS;
            /*Pass*/string folderViewModel = _bufferFolderIposV3_ViewModels + _relativeFolderViewModel;
            /*Pass*/string folderView = _bufferFolderIposV3 + _relativeFolderView;
            /*Pass*/string folderController = _bufferFolderControllersCSharp + _relativeFolderController;
            /*Pass*/string folderBindingModel = _bufferFolderControllersCSharp + _relativeFolderBindingModel;
            /*Pass*/string folderMiscelanea = _bufferFolderMiscelanea + _relativeFolderMiscelanea;
            //string folderDaoCSharpGeneratedinto = _bufferFolderDataAccess + _relativeFolderDaoCSharpGeneratedinto;
            //string folderDaoCSharpGeneratedStoreProc = _bufferFolderDataAccess + _relativeFolderDaoCSharpGeneratedStoreProc;
            //string folderAngularAdminServices = _bufferFolderRoot + _relativeFolderAngularAdminServices;
            //string folderAngularAdmin = _bufferFolderRoot + _relativeFolderAngularAdmin;
            //string folderAngularAdminLayout = _bufferFolderRoot + _relativeFolderAngularAdminLayout;
            //string folderModelsGeneratedCSharp = _bufferFolderModels + _relativeFolderModelsGeneratedCSharp;
            /*Pass*/string folderBindingModelGenerated = _bufferFolderControllersCSharp + _relativeFolderBindingModelGenerated;
            //string folderControllerGenerated = _bufferFolderControllersCSharp + _relativeFolderControllerGenerated;
            //string folderDaoQueryToolsGeneratedinto = _bufferFolderQueryTools + _relativeFolderDaoQueryToolsGeneratedinto;
            //string folderPruebasUnitariasExcel = _bufferFolderRoot + _relativeFolderPruebasUnitariasExcel;
            //string folderPruebasUnitariasTest = _bufferFolderIposV3_ViewModels_Tests + _relativeFolderPruebasUnitariasTest;
            //string folderDaoQueryToolsinto = _bufferFolderQueryTools;
            //string folderViewModelGenerated = _bufferFolderIposV3_ViewModels + _relativeFolderViewModelGenerated;



            //System.IO.Directory.CreateDirectory(folderModelsCSharp);
            //System.IO.Directory.CreateDirectory(folderDaoCSharp);
            //System.IO.Directory.CreateDirectory(folderDaoCSharpGenerated);

            //System.IO.Directory.CreateDirectory(folderAngularModel);
            /*Pass*/System.IO.Directory.CreateDirectory(folderControllersCSharp);
            //System.IO.Directory.CreateDirectory(folderAngularWS);


            //System.IO.Directory.CreateDirectory(folderAngularAdminServices);
            //System.IO.Directory.CreateDirectory(folderAngularAdmin);
            //System.IO.Directory.CreateDirectory(folderAngularAdminLayout);


            //System.IO.Directory.CreateDirectory(folderDaoCSharpGeneratedinto);
            //System.IO.Directory.CreateDirectory(folderDaoCSharpGeneratedStoreProc);

            //System.IO.Directory.CreateDirectory(folderModelsGeneratedCSharp);
            /*Pass*/System.IO.Directory.CreateDirectory(folderModelsCSharpAux);
            /*Pass*/System.IO.Directory.CreateDirectory(folderBindingModelGenerated);
            //System.IO.Directory.CreateDirectory(folderControllerGenerated);


            //System.IO.Directory.CreateDirectory(folderDaoQueryToolsGeneratedinto);
            //System.IO.Directory.CreateDirectory(folderPruebasUnitariasExcel);

            //System.IO.Directory.CreateDirectory(folderPruebasUnitariasTest);

            //System.IO.Directory.CreateDirectory(folderDaoQueryToolsinto);

            //System.IO.Directory.CreateDirectory(folderViewModelGenerated);


            //Me.SqlConnection1.ConnectionString = "Data Source=" + TBServidor.Text.ToString() + ";Initial Catalog=" + Me.TBBaseDatos.Text.ToString() + ";Persist Security Info=True;User ID=" + Me.TBUsuario.Text.ToString() + "" & _
            //         ";Password=" + Me.TBPassword.Text.ToString() + ""
            // this.SqlConnection1.ConnectionString = "Server=" + TBServidor.Text.ToString() + ";Port=5432;Database=" + this.TBBaseDatos.Text.ToString() + ";Uid=" + this.TBUsuario.Text.ToString() + ";Pwd=" + this.TBPassword.Text.ToString() + "; ";
            //Global.GeneradorW.My.MySettings.Default.ConnectionString1 



            //Put user code to initialize the page here
            //Me.Label1.Text = Me.SqlCommand1.CommandText


            //Me.DataSetSchema1.Tables("UserTables").Clear()
            //Me.SqlDataAdapter1.Fill(Me.DataSetSchema1)


            Hashtable? tableKeys = default(Hashtable);
            //If Not IsPostBack Then
            tableKeys = llenarTableKeys(excelPath);



            Hashtable? numtableKeys = default(Hashtable);
            //If Not IsPostBack Then
            //Me.DataSetSchema1.Tables("UserTables").Clear()
            numtableKeys = this.TablasNumKeys(excelPath);


            //Me.DataSetSchema1.Tables("UserTables").Clear()
            //Me.SqlDataAdapter1.Fill(Me.DataSetSchema1)



            string[] auxFiles = new string[33];
            //auxFiles[0] = "__nombreTabla__GeneratedDao.cs";
            //auxFiles[1] = "__nombreTabla__StoreProcs.sql";
            //auxFiles[2] = "__nombreTabla__.cs";
            //auxFiles[3] = "__nombreTabla__ControllerW.cs";
            //auxFiles[4] = "__nombreTabla__Dao.cs";
            /*Pass*/auxFiles[0] = "__nombreTabla__ListViewModel.cs";
            /*Pass*/auxFiles[1] = "__nombreTabla__AddEditView.xaml.cs";
            /*Pass*/auxFiles[2] = "__nombreTabla__AddEditView.xaml";
            /*Pass*/auxFiles[3] = "__nombreTabla__ListView.xaml.cs";
            /*Pass*/auxFiles[4] = "__nombreTabla__ListView.xaml";
            /*Pass*/auxFiles[5] = "__nombreTabla__ItemViewModel.cs";
            /*Pass*/auxFiles[6] = "__nombreTabla__Controller.cs";
            /*Pass*/auxFiles[7] = "__nombreTabla__BindingModel.cs";
            //auxFiles[13] = "__nombreTabla__Result.cs";
            /*Pass*/auxFiles[8] = "__nombreTabla__Param.cs";
            //auxFiles[15] = "__nombreTabla__ParamBindingModel.cs";
            //auxFiles[16] = "__nombreTabla__ResultBindingModel.cs";
            //auxFiles[9] = "__nombreTabla__SelectorDao.cs";
            //auxFiles[18] = "__nombreTabla__GeneratedListDao.cs";
            //auxFiles[19] = "I__nombreTabla__ControllerProvider.cs";
            //auxFiles[20] = "I__nombreTabla__DaoProvider.cs";
            //auxFiles[21] = "__nombreTabla__SelectListIControllerPart.txt";
            //auxFiles[22] = "__nombreTabla__SelectListControllerPart.txt";
            //auxFiles[23] = "__nombreTabla__SelectListIDaoPart.txt";
            //auxFiles[24] = "__nombreTabla__SelectListDaoPart.txt";
            //auxFiles[25] = "__nombreTabla__Generated.cs";
            //auxFiles[26] = "__nombreTabla__ResultGenerated.cs";
            /*Pass*/auxFiles[9] = "__nombreTabla__ParamGenerated.cs";
            /*Pass*/auxFiles[10] = "__nombreTabla__BindingModelGenerated.cs";
            //auxFiles[29] = "__nombreTabla__ParamBindingModelGenerated.cs";
            //auxFiles[30] = "__nombreTabla__ResultBindingModelGenerated.cs";
            //auxFiles[31] = "I__nombreTabla__DaoProviderGenerated.cs";
            //auxFiles[32] = "__nombreTabla__ControllerGenerated.cs";
            //auxFiles[33] = "I__nombreTabla__ControllerProviderGenerated.cs";
            //auxFiles[34] = "__nombreTabla__ListSubViewModel.cs";
            //auxFiles[35] = "__nombreTabla__ListSubView.xaml";
            //auxFiles[36] = "__nombreTabla__ListSubView.xaml.cs";
            //auxFiles[37] = "__nombreTabla__AddEditSubView.xaml.cs";
            //auxFiles[38] = "__nombreTabla__AddEditSubView.xaml";
            //auxFiles[39] = "__nombreTabla__ItemSubViewModel.cs";
            //auxFiles[40] = "__nombreTabla__GeneratedCommandDao.cs";
            //auxFiles[41] = "__nombreTabla__CommandDaoPart.txt";
            //auxFiles[42] = "__nombreTabla__CommandIDaoPart.txt";
            //auxFiles[43] = "__nombreTabla__CommandControllerPart.txt";
            //auxFiles[44] = "__nombreTabla__CommandIControllerPart.txt";
            //auxFiles[45] = "__nombreTabla__AddEditCommandView.xaml";
            //auxFiles[46] = "__nombreTabla__AddEditCommandView.xaml.cs";
            //auxFiles[47] = "__nombreTabla__ItemCommandViewModel.cs";
            //auxFiles[48] = "__nombreTabla__ListCommandView.xaml";
            //auxFiles[49] = "__nombreTabla__ListCommandView.xaml.cs";
            //auxFiles[50] = "__nombreTabla__ListCommandViewModel.cs";
            //auxFiles[51] = "__nombreTabla__PQueriesGenerated.cs";
            //auxFiles[52] = "__nombreTabla__VQueriesGenerated.cs";
            //auxFiles[53] = "__nombreTabla__QueriesGenerated.cs";
            //auxFiles[54] = "__nombreTabla__CreatePruebasUnitarias.txt";
            //auxFiles[55] = "__nombreTabla__InsertPruebasUnitarias.txt";
            //auxFiles[56] = "__nombreTabla__ViewModelUnitTest.cs";
            //auxFiles[57] = "__nombreTabla__ControllerUnitTest.cs";
            //auxFiles[58] = "__nombreTabla__DaoUnitTest.cs";
            //auxFiles[59] = "__nombreTabla__BaseUnitTest.cs";
            //auxFiles[60] = "__nombreTabla__BaseUnitTestSubViewPart.cs";
            //auxFiles[61] = "__nombreTabla__BaseUnitTestSubProcPart.cs";
            //auxFiles[62] = "__nombreTabla__DaoUnitTestSubViewPart.cs";
            //auxFiles[63] = "__nombreTabla__DaoUnitTestSubProcPart.cs";
            //auxFiles[64] = "__nombreTabla__ControllerUnitTestSubViewPart.cs";
            //auxFiles[65] = "__nombreTabla__ControllerUnitTestSubProcPart.cs";
            /*Pass*/auxFiles[11] = "__nombreTabla__CommunicationParameters.cs";

            /*Pass*/auxFiles[12] = "misc___nombreTabla__main_view_menu_general_lst_2.txt";
            /*Pass*/auxFiles[13] = "misc___nombreTabla__main_view_menu_general_lst_1.txt";
            //auxFiles[69] = "misc___nombreTabla__main_view_menu_sublist_lst_2.txt";
            //auxFiles[70] = "misc___nombreTabla__main_view_menu_sublist_lst_1.txt";
            //auxFiles[71] = "misc___nombreTabla__main_view_menu_sublist_edit_2.txt";
            //auxFiles[72] = "misc___nombreTabla__main_view_menu_sublist_edit_1.txt";
            //auxFiles[73] = "misc___nombreTabla__main_view_menu_subproc_lst_2.txt";
            //auxFiles[74] = "misc___nombreTabla__main_view_menu_subproc_lst_1.txt";
            //auxFiles[75] = "misc___nombreTabla__main_view_menu_subproc_edit_1.txt";
            //auxFiles[76] = "misc___nombreTabla__main_view_menu_subproc_edit_2.txt";
            //auxFiles[77] = "misc___nombreTabla__bootstraper_controller_dao.txt";
            /*Pass*/auxFiles[14] = "misc___nombreTabla__bootstraper_viewlocator_general_lst.txt";
            /*Pass*/auxFiles[15] = "misc___nombreTabla__bootstraper_viewlocator_general_edit.txt";
            //auxFiles[80] = "misc___nombreTabla__bootstraper_viewlocator_sublist_lst.txt";
            //auxFiles[81] = "misc___nombreTabla__bootstraper_viewlocator_sublist_edit.txt";
            //auxFiles[82] = "misc___nombreTabla__bootstraper_viewlocator_subproc_edit.txt";
            //auxFiles[83] = "misc___nombreTabla__bootstraper_viewlocator_subproc_lst.txt";
            /*Pass*/auxFiles[16] = "misc___nombreTabla__bootstraper_container_viewmodel_lst.txt";
            //auxFiles[85] = "misc___nombreTabla__bootstraper_container_viewmodel_sublist_lst.txt";
            //auxFiles[86] = "misc___nombreTabla__bootstraper_container_viewmodel_subproc_lst.txt";
            /*Pass*/auxFiles[17] = "misc___nombreTabla__bootstraper_container_viewmodel_edit.txt";
            //auxFiles[88] = "misc___nombreTabla__bootstraper_container_viewmodel_sublist_edit.txt";
            //auxFiles[89] = "misc___nombreTabla__bootstraper_container_viewmodel_subproc_edit.txt";
            /*Pass*/auxFiles[18] = "misc___nombreTabla__catalog_selector_1.txt";
            /*Pass*/auxFiles[19] = "misc___nombreTabla__catalog_selector_2.txt";
            /*Pass*/auxFiles[20] = "misc___nombreTabla__catalog_selector_3.txt";
            /*Pass*/auxFiles[21] = "misc___nombreTabla__catalog_selector_4.txt";
            /*Pass*/auxFiles[22] = "misc___nombreTabla__catalog_selector_5.txt";
            /*Pass*/auxFiles[23] = "misc___nombreTabla__catalog_selector_6.txt";
            /*Pass*/auxFiles[24] = "misc___nombreTabla__catalog_selector_7.txt";
            //auxFiles[97] = "_nombreTabla__Queries.cs";
            //auxFiles[26] = "__nombreTabla__ListViewModelGenerated.cs";
            //auxFiles[27] = "__nombreTabla__ItemViewModelGenerated.cs";
            //auxFiles[100] = "__nombreTabla__ListSubViewModelGenerated.cs";
            //auxFiles[101] = "__nombreTabla__ItemSubViewModelGenerated.cs";
            //auxFiles[102] = "__nombreTabla__ListCommandViewModelGenerated.cs";
            //auxFiles[103] = "__nombreTabla__ItemCommandViewModelGenerated.cs";

            //auxFiles[104] = "__nombreTabla__GeneratedImpoDao.cs";
            //auxFiles[105] = "__nombreTabla__ImpoExpoDaoPart.txt";
            //auxFiles[106] = "__nombreTabla__ImpoExpoIDaoPart.txt";
            //auxFiles[107] = "__nombreTabla__ImpoExpoControllerPart.txt";
            //auxFiles[108] = "__nombreTabla__ImpoExpoIControllerPart.txt";
            //auxFiles[109] = "__nombreTabla__IQueriesGenerated.cs";

            auxFiles[25] = "__nombreTabla__WFView.xaml.cs";
            auxFiles[26] = "__nombreTabla__WFView.xaml";
            auxFiles[27] = "__nombreTabla__WFViewModel.cs";
            auxFiles[28] = "__nombreTabla__WFBindingModel.cs";
            auxFiles[29] = "__nombreTabla__ImpoExpoService.cs";
            auxFiles[30] = "__nombreTabla___ApiParam.cs";
            auxFiles[31] = "__nombreTabla__WebController.cs";
            auxFiles[32] = "__nombreTabla___ApiController.cs";

            Hashtable? auxTipoFiles = default(Hashtable);
            auxTipoFiles = new Hashtable();
            //auxTipoFiles.Add("__nombreTabla__GeneratedDao.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__StoreProcs.sql", "tabla,subimpo");
            //auxTipoFiles.Add("__nombreTabla__.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ControllerW.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__Dao.cs", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__ListViewModel.cs", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__AddEditView.xaml.cs", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__AddEditView.xaml", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__ListView.xaml.cs", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__ListView.xaml", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__ItemViewModel.cs", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__Controller.cs", "tabla");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__BindingModel.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__Result.cs", "subview,subproc,subimpo");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__Param.cs", "tabla,subview,subproc,subimpo");
            //auxTipoFiles.Add("__nombreTabla__ParamBindingModel.cs", "subview,subproc,subimpo");
            //auxTipoFiles.Add("__nombreTabla__ResultBindingModel.cs", "subview,subproc,subimpo");
            //auxTipoFiles.Add("__nombreTabla__SelectorDao.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__GeneratedListDao.cs", "subview");
            //auxTipoFiles.Add("I__nombreTabla__ControllerProvider.cs", "tabla");
            //auxTipoFiles.Add("I__nombreTabla__DaoProvider.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__SelectListIControllerPart.txt", "subview");
            //auxTipoFiles.Add("__nombreTabla__SelectListControllerPart.txt", "subview");
            //auxTipoFiles.Add("__nombreTabla__SelectListIDaoPart.txt", "subview");
            //auxTipoFiles.Add("__nombreTabla__SelectListDaoPart.txt", "subview");
            //auxTipoFiles.Add("__nombreTabla__Generated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ResultGenerated.cs", "subview,subproc,subimpo");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__ParamGenerated.cs", "tabla,subview,subproc,subimpo");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__BindingModelGenerated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ParamBindingModelGenerated.cs", "subview,subproc,subimpo");
            //auxTipoFiles.Add("__nombreTabla__ResultBindingModelGenerated.cs", "subview,subproc,subimpo");
            //auxTipoFiles.Add("I__nombreTabla__DaoProviderGenerated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ControllerGenerated.cs", "tabla");
            //auxTipoFiles.Add("I__nombreTabla__ControllerProviderGenerated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ListSubViewModel.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__ListSubView.xaml", "subview");
            //auxTipoFiles.Add("__nombreTabla__ListSubView.xaml.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__AddEditSubView.xaml.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__AddEditSubView.xaml", "subview");
            //auxTipoFiles.Add("__nombreTabla__ItemSubViewModel.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__GeneratedCommandDao.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__CommandDaoPart.txt", "subproc");
            //auxTipoFiles.Add("__nombreTabla__CommandIDaoPart.txt", "subproc");
            //auxTipoFiles.Add("__nombreTabla__CommandControllerPart.txt", "subproc");
            //auxTipoFiles.Add("__nombreTabla__CommandIControllerPart.txt", "subproc");
            //auxTipoFiles.Add("__nombreTabla__AddEditCommandView.xaml", "subproc");
            //auxTipoFiles.Add("__nombreTabla__AddEditCommandView.xaml.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__ItemCommandViewModel.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__ListCommandView.xaml", "subproc");
            //auxTipoFiles.Add("__nombreTabla__ListCommandView.xaml.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__ListCommandViewModel.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__PQueriesGenerated.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__VQueriesGenerated.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__QueriesGenerated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__CreatePruebasUnitarias.txt", "tabla,subview,subproc,subimpo");
            //auxTipoFiles.Add("__nombreTabla__InsertPruebasUnitarias.txt", "tabla,subview,subproc,subimpo");
            //auxTipoFiles.Add("__nombreTabla__ViewModelUnitTest.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ControllerUnitTest.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__DaoUnitTest.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__BaseUnitTest.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__BaseUnitTestSubViewPart.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__BaseUnitTestSubProcPart.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__DaoUnitTestSubViewPart.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__DaoUnitTestSubProcPart.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__ControllerUnitTestSubViewPart.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__ControllerUnitTestSubProcPart.cs", "subproc");
            /*Pass*/auxTipoFiles.Add("__nombreTabla__CommunicationParameters.cs", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__main_view_menu_general_lst_2.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__main_view_menu_general_lst_1.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_sublist_lst_2.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_sublist_lst_1.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_sublist_edit_2.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_sublist_edit_1.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_subproc_lst_2.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_subproc_lst_1.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_subproc_edit_1.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__main_view_menu_subproc_edit_2.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_controller_dao.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__bootstraper_viewlocator_general_lst.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__bootstraper_viewlocator_general_edit.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_viewlocator_sublist_lst.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_viewlocator_sublist_edit.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_viewlocator_subproc_edit.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_viewlocator_subproc_lst.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__bootstraper_container_viewmodel_lst.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_container_viewmodel_sublist_lst.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_container_viewmodel_subproc_lst.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__bootstraper_container_viewmodel_edit.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_container_viewmodel_sublist_edit.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("misc___nombreTabla__bootstraper_container_viewmodel_subproc_edit.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_1.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_2.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_3.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_4.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_5.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_6.txt", "tabla,subview,subproc");
            /*Pass*/auxTipoFiles.Add("misc___nombreTabla__catalog_selector_7.txt", "tabla,subview,subproc");
            //auxTipoFiles.Add("__nombreTabla__Queries.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ListViewModelGenerated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ItemViewModelGenerated.cs", "tabla");
            //auxTipoFiles.Add("__nombreTabla__ListSubViewModelGenerated.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__ItemSubViewModelGenerated.cs", "subview");
            //auxTipoFiles.Add("__nombreTabla__ListCommandViewModelGenerated.cs", "subproc");
            //auxTipoFiles.Add("__nombreTabla__ItemCommandViewModelGenerated.cs", "subproc");

            //auxTipoFiles.Add("__nombreTabla__GeneratedImpoDao.cs", "subimpo");
            //auxTipoFiles.Add("__nombreTabla__ImpoExpoDaoPart.txt", "subimpo");
            //auxTipoFiles.Add("__nombreTabla__ImpoExpoIDaoPart.txt", "subimpo");
            //auxTipoFiles.Add("__nombreTabla__ImpoExpoControllerPart.txt", "subimpo");
            //auxTipoFiles.Add("__nombreTabla__ImpoExpoIControllerPart.txt", "subimpo");
            //auxTipoFiles.Add("__nombreTabla__IQueriesGenerated.cs", "subimpo");

            auxTipoFiles.Add("__nombreTabla__WFView.xaml.cs", "tabla");
            auxTipoFiles.Add("__nombreTabla__WFView.xaml", "tabla");
            auxTipoFiles.Add("__nombreTabla__WFViewModel.cs", "tabla");
            auxTipoFiles.Add("__nombreTabla__WFBindingModel.cs", "tabla");
            auxTipoFiles.Add("__nombreTabla__ImpoExpoService.cs", "tabla");

            auxTipoFiles.Add("__nombreTabla___ApiParam.cs", "tabla");
            auxTipoFiles.Add("__nombreTabla__WebController.cs", "tabla");
            auxTipoFiles.Add("__nombreTabla___ApiController.cs", "tabla");


            Hashtable? auxFolders = default(Hashtable);
            auxFolders = new Hashtable();
            //auxFolders.Add("__nombreTabla__GeneratedDao.cs", folderDaoCSharpGeneratedinto);
            //auxFolders.Add("__nombreTabla__StoreProcs.sql", folderDaoCSharpGeneratedStoreProc);
            //auxFolders.Add("__nombreTabla__.cs", folderModelsCSharp);
            //auxFolders.Add("__nombreTabla__ControllerW.cs", folderControllersWebCSharp);
            //auxFolders.Add("__nombreTabla__Dao.cs", folderDaoCSharp);
            /*Pass*/auxFolders.Add("__nombreTabla__ListViewModel.cs", folderViewModel);
            /*Pass*/auxFolders.Add("__nombreTabla__AddEditView.xaml.cs", folderView);
            /*Pass*/auxFolders.Add("__nombreTabla__AddEditView.xaml", folderView);
            /*Pass*/auxFolders.Add("__nombreTabla__ListView.xaml.cs", folderView);
            /*Pass*/auxFolders.Add("__nombreTabla__ListView.xaml", folderView);
            /*Pass*/auxFolders.Add("__nombreTabla__ItemViewModel.cs", folderViewModel);
            /*Pass*/auxFolders.Add("__nombreTabla__Controller.cs", folderController);
            /*Pass*/auxFolders.Add("__nombreTabla__BindingModel.cs", folderBindingModel);
            //auxFolders.Add("__nombreTabla__Result.cs", folderModelsCSharp);
            /*Pass*/auxFolders.Add("__nombreTabla__Param.cs", folderModelsCSharpAux);
            //auxFolders.Add("__nombreTabla__ParamBindingModel.cs", folderBindingModel);
            //auxFolders.Add("__nombreTabla__ResultBindingModel.cs", folderBindingModel);
            //auxFolders.Add("__nombreTabla__SelectorDao.cs", folderDaoCSharp);
            //auxFolders.Add("__nombreTabla__GeneratedListDao.cs", folderDaoCSharpGeneratedinto);
            //auxFolders.Add("I__nombreTabla__ControllerProvider.cs", folderController);
            //auxFolders.Add("I__nombreTabla__DaoProvider.cs", folderDaoCSharp);
            //auxFolders.Add("__nombreTabla__SelectListIControllerPart.txt", folderController + "\\parts");
            //auxFolders.Add("__nombreTabla__SelectListControllerPart.txt", folderController + "\\parts");
            //auxFolders.Add("__nombreTabla__SelectListIDaoPart.txt", folderDaoCSharp + "\\parts");
            //auxFolders.Add("__nombreTabla__SelectListDaoPart.txt", folderDaoCSharp + "\\parts");
            //auxFolders.Add("__nombreTabla__Generated.cs", folderModelsGeneratedCSharp);
            //auxFolders.Add("__nombreTabla__ResultGenerated.cs", folderModelsGeneratedCSharp);
            /*Pass*/auxFolders.Add("__nombreTabla__ParamGenerated.cs", folderModelsCSharpAux);
            /*Pass*/auxFolders.Add("__nombreTabla__BindingModelGenerated.cs", folderBindingModelGenerated);
            //auxFolders.Add("__nombreTabla__ParamBindingModelGenerated.cs", folderBindingModelGenerated);
            //auxFolders.Add("__nombreTabla__ResultBindingModelGenerated.cs", folderBindingModelGenerated);
            //auxFolders.Add("I__nombreTabla__DaoProviderGenerated.cs", folderDaoCSharpGeneratedinto);
            //auxFolders.Add("__nombreTabla__ControllerGenerated.cs", folderControllerGenerated);
            //auxFolders.Add("I__nombreTabla__ControllerProviderGenerated.cs", folderControllerGenerated);
            //auxFolders.Add("__nombreTabla__ListSubViewModel.cs", folderViewModel);
            //auxFolders.Add("__nombreTabla__ListSubView.xaml", folderView);
            //auxFolders.Add("__nombreTabla__ListSubView.xaml.cs", folderView);
            //auxFolders.Add("__nombreTabla__AddEditSubView.xaml.cs", folderView);
            //auxFolders.Add("__nombreTabla__AddEditSubView.xaml", folderView);
            //auxFolders.Add("__nombreTabla__ItemSubViewModel.cs", folderViewModel);
            //auxFolders.Add("__nombreTabla__GeneratedCommandDao.cs", folderDaoCSharpGeneratedinto);
            //auxFolders.Add("__nombreTabla__CommandDaoPart.txt", folderDaoCSharp + "\\parts");
            //auxFolders.Add("__nombreTabla__CommandIDaoPart.txt", folderDaoCSharp + "\\parts");
            //auxFolders.Add("__nombreTabla__CommandControllerPart.txt", folderController + "\\parts");
            //auxFolders.Add("__nombreTabla__CommandIControllerPart.txt", folderController + "\\parts");
            //auxFolders.Add("__nombreTabla__AddEditCommandView.xaml", folderView);
            //auxFolders.Add("__nombreTabla__AddEditCommandView.xaml.cs", folderView);
            //auxFolders.Add("__nombreTabla__ItemCommandViewModel.cs", folderViewModel);
            //auxFolders.Add("__nombreTabla__ListCommandView.xaml", folderView);
            //auxFolders.Add("__nombreTabla__ListCommandView.xaml.cs", folderView);
            //auxFolders.Add("__nombreTabla__ListCommandViewModel.cs", folderViewModel);
            //auxFolders.Add("__nombreTabla__PQueriesGenerated.cs", folderDaoQueryToolsGeneratedinto);
            //auxFolders.Add("__nombreTabla__VQueriesGenerated.cs", folderDaoQueryToolsGeneratedinto);
            //auxFolders.Add("__nombreTabla__QueriesGenerated.cs", folderDaoQueryToolsGeneratedinto);
            //auxFolders.Add("__nombreTabla__CreatePruebasUnitarias.txt", folderPruebasUnitariasExcel);
            //auxFolders.Add("__nombreTabla__InsertPruebasUnitarias.txt", folderPruebasUnitariasExcel);
            //auxFolders.Add("__nombreTabla__ViewModelUnitTest.cs", folderPruebasUnitariasTest);
            //auxFolders.Add("__nombreTabla__ControllerUnitTest.cs", folderPruebasUnitariasTest);
            //auxFolders.Add("__nombreTabla__DaoUnitTest.cs", folderPruebasUnitariasTest);
            //auxFolders.Add("__nombreTabla__BaseUnitTest.cs", folderPruebasUnitariasTest);
            //auxFolders.Add("__nombreTabla__BaseUnitTestSubViewPart.cs", folderPruebasUnitariasTest + "\\parts");
            //auxFolders.Add("__nombreTabla__BaseUnitTestSubProcPart.cs", folderPruebasUnitariasTest + "\\parts");
            //auxFolders.Add("__nombreTabla__DaoUnitTestSubViewPart.cs", folderPruebasUnitariasTest + "\\parts");
            //auxFolders.Add("__nombreTabla__DaoUnitTestSubProcPart.cs", folderPruebasUnitariasTest + "\\parts");
            //auxFolders.Add("__nombreTabla__ControllerUnitTestSubViewPart.cs", folderPruebasUnitariasTest + "\\parts");
            //auxFolders.Add("__nombreTabla__ControllerUnitTestSubProcPart.cs", folderPruebasUnitariasTest + "\\parts");
            /*Pass*/auxFolders.Add("__nombreTabla__CommunicationParameters.cs", folderViewModel);
            /*Pass*/auxFolders.Add("misc___nombreTabla__main_view_menu_general_lst_2.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__main_view_menu_general_lst_1.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_sublist_lst_2.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_sublist_lst_1.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_sublist_edit_2.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_sublist_edit_1.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_subproc_lst_2.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_subproc_lst_1.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_subproc_edit_1.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__main_view_menu_subproc_edit_2.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_controller_dao.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__bootstraper_viewlocator_general_lst.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__bootstraper_viewlocator_general_edit.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_viewlocator_sublist_lst.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_viewlocator_sublist_edit.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_viewlocator_subproc_edit.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_viewlocator_subproc_lst.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__bootstraper_container_viewmodel_lst.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_container_viewmodel_sublist_lst.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_container_viewmodel_subproc_lst.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__bootstraper_container_viewmodel_edit.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_container_viewmodel_sublist_edit.txt", folderMiscelanea);
            //auxFolders.Add("misc___nombreTabla__bootstraper_container_viewmodel_subproc_edit.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_1.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_2.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_3.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_4.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_5.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_6.txt", folderMiscelanea);
            /*Pass*/auxFolders.Add("misc___nombreTabla__catalog_selector_7.txt", folderMiscelanea);
            //auxFolders.Add("__nombreTabla__Queries.cs", folderDaoQueryToolsinto);
            //auxFolders.Add("__nombreTabla__ListViewModelGenerated.cs", folderViewModelGenerated);
            //auxFolders.Add("__nombreTabla__ItemViewModelGenerated.cs", folderViewModelGenerated);
            //auxFolders.Add("__nombreTabla__ListSubViewModelGenerated.cs", folderViewModelGenerated);
            //auxFolders.Add("__nombreTabla__ItemSubViewModelGenerated.cs", folderViewModelGenerated);
            //auxFolders.Add("__nombreTabla__ListCommandViewModelGenerated.cs", folderViewModelGenerated);
            //auxFolders.Add("__nombreTabla__ItemCommandViewModelGenerated.cs", folderViewModelGenerated);

            //auxFolders.Add("__nombreTabla__GeneratedImpoDao.cs", folderDaoCSharpGeneratedinto);
            //auxFolders.Add("__nombreTabla__ImpoExpoDaoPart.txt", folderDaoCSharp + "\\parts");
            //auxFolders.Add("__nombreTabla__ImpoExpoIDaoPart.txt", folderDaoCSharp + "\\parts");
            //auxFolders.Add("__nombreTabla__ImpoExpoControllerPart.txt", folderController + "\\parts");
            //auxFolders.Add("__nombreTabla__ImpoExpoIControllerPart.txt", folderController + "\\parts");
            //auxFolders.Add("__nombreTabla__IQueriesGenerated.cs", folderDaoQueryToolsGeneratedinto);

            auxFolders.Add("__nombreTabla__WFView.xaml.cs", folderView);
            auxFolders.Add("__nombreTabla__WFView.xaml", folderView);
            auxFolders.Add("__nombreTabla__WFViewModel.cs", folderViewModel);
            auxFolders.Add("__nombreTabla__WFBindingModel.cs", folderBindingModel);
            auxFolders.Add("__nombreTabla__ImpoExpoService.cs", folderBindingModel);

            auxFolders.Add("__nombreTabla___ApiParam.cs", folderBindingModel);
            auxFolders.Add("__nombreTabla__WebController.cs", folderController);
            auxFolders.Add("__nombreTabla___ApiController.cs", folderView);







            Hashtable? auxPrefijosNecesarios = default(Hashtable);
            auxPrefijosNecesarios = new Hashtable();
            //auxPrefijosNecesarios.Add("__nombreTabla__GeneratedDao.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__StoreProcs.sql", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ControllerW.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__Dao.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__ListViewModel.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__AddEditView.xaml.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__AddEditView.xaml", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__ListView.xaml.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__ListView.xaml", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__ItemViewModel.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__Controller.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__BindingModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__Result.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__Param.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ParamBindingModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ResultBindingModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__SelectorDao.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__GeneratedListDao.cs", "");
            //auxPrefijosNecesarios.Add("I__nombreTabla__ControllerProvider.cs", "");
            //auxPrefijosNecesarios.Add("I__nombreTabla__DaoProvider.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__SelectListIControllerPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__SelectListControllerPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__SelectListIDaoPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__SelectListDaoPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__Generated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ResultGenerated.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__ParamGenerated.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__BindingModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ParamBindingModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ResultBindingModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("I__nombreTabla__DaoProviderGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ControllerGenerated.cs", "");
            //auxPrefijosNecesarios.Add("I__nombreTabla__ControllerProviderGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListSubViewModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListSubView.xaml", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListSubView.xaml.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__AddEditSubView.xaml.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__AddEditSubView.xaml", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ItemSubViewModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__GeneratedCommandDao.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__CommandDaoPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__CommandIDaoPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__CommandControllerPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__CommandIControllerPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__AddEditCommandView.xaml", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__AddEditCommandView.xaml.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ItemCommandViewModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListCommandView.xaml", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListCommandView.xaml.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListCommandViewModel.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__PQueriesGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__VQueriesGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__QueriesGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__CreatePruebasUnitarias.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__InsertPruebasUnitarias.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ViewModelUnitTest.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ControllerUnitTest.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__DaoUnitTest.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__BaseUnitTest.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__BaseUnitTestSubViewPart.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__BaseUnitTestSubProcPart.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__DaoUnitTestSubViewPart.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__DaoUnitTestSubProcPart.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ControllerUnitTestSubViewPart.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ControllerUnitTestSubProcPart.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("__nombreTabla__CommunicationParameters.cs", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_general_lst_2.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_general_lst_1.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_sublist_lst_2.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_sublist_lst_1.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_sublist_edit_2.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_sublist_edit_1.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_subproc_lst_2.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_subproc_lst_1.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_subproc_edit_1.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__main_view_menu_subproc_edit_2.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_controller_dao.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_viewlocator_general_lst.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_viewlocator_general_edit.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_viewlocator_sublist_lst.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_viewlocator_sublist_edit.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_viewlocator_subproc_edit.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_viewlocator_subproc_lst.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_container_viewmodel_lst.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_container_viewmodel_sublist_lst.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_container_viewmodel_subproc_lst.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_container_viewmodel_edit.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_container_viewmodel_sublist_edit.txt", "");
            //auxPrefijosNecesarios.Add("misc___nombreTabla__bootstraper_container_viewmodel_subproc_edit.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_1.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_2.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_3.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_4.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_5.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_6.txt", "");
            /*Pass*/auxPrefijosNecesarios.Add("misc___nombreTabla__catalog_selector_7.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__Queries.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListViewModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ItemViewModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListSubViewModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ItemSubViewModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ListCommandViewModelGenerated.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ItemCommandViewModelGenerated.cs", "");

            //auxPrefijosNecesarios.Add("__nombreTabla__GeneratedImpoDao.cs", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ImpoExpoDaoPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ImpoExpoIDaoPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ImpoExpoControllerPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__ImpoExpoIControllerPart.txt", "");
            //auxPrefijosNecesarios.Add("__nombreTabla__IQueriesGenerated.cs", "");

            auxPrefijosNecesarios.Add("__nombreTabla__WFView.xaml.cs", "");
            auxPrefijosNecesarios.Add("__nombreTabla__WFView.xaml", "");
            auxPrefijosNecesarios.Add("__nombreTabla__WFViewModel.cs", "");
            auxPrefijosNecesarios.Add("__nombreTabla__WFBindingModel.cs", "");
            auxPrefijosNecesarios.Add("__nombreTabla__ImpoExpoService.cs", "");

            auxPrefijosNecesarios.Add("__nombreTabla___ApiParam.cs", "");
            auxPrefijosNecesarios.Add("__nombreTabla__WebController.cs", "");
            auxPrefijosNecesarios.Add("__nombreTabla___ApiController.cs", "");


            Hashtable confArray = new Hashtable();
            //confArray.Add("__nombreTabla__GeneratedDao.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharpGeneratedinto, projFolderDaoCSharpGeneratedinto, _relativeFolderDaoCSharpGeneratedinto, true, true, true, sectionDaoGenerated));
            //confArray.Add("__nombreTabla__StoreProcs.sql", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharpGeneratedStoreProc, projFolderDaoCSharpGeneratedStoreProc, _relativeFolderDaoCSharpGeneratedStoreProc, false, false, false, sectionDaoGenerated));
            //confArray.Add("__nombreTabla__.cs", new ImplConf(projectFolderModels + @"\" + projectFileNameModels, folderModelsCSharp, projFolderModelsCSharp, _relativeFolderModelsCSharp, true, false, true, sectionModelsInherited));
            //confArray.Add("__nombreTabla__ControllerW.cs", new ImplConf(projectFolderRoot + @"\" + projectFileNameRoot, folderControllersWebCSharp, projFolderControllersWebCSharp, _relativeFolderControllersWebCSharp, false, false, false, sectionOther));
            //confArray.Add("__nombreTabla__Dao.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp, projFolderDaoCSharp, _relativeFolderDaoCSharp, true, false, true, sectionDaoInherited));
            /*Pass*/confArray.Add("__nombreTabla__ListViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            /*Pass*/confArray.Add("__nombreTabla__AddEditView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            /*Pass*/confArray.Add("__nombreTabla__AddEditView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            /*Pass*/confArray.Add("__nombreTabla__ListView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            /*Pass*/confArray.Add("__nombreTabla__ListView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView/*sectionViewModelsGenerated*/));
            /*Pass*/confArray.Add("__nombreTabla__ItemViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            /*Pass*/confArray.Add("__nombreTabla__Controller.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController, projFolderController, _relativeFolderController, true, false, true, sectionControllersInherited));
            /*Pass*/confArray.Add("__nombreTabla__BindingModel.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModel, projFolderBindingModel, _relativeFolderBindingModel, true, false, true, sectionBindingInherited));
            //confArray.Add("__nombreTabla__Result.cs", new ImplConf(projectFolderModels + @"\" + projectFileNameModels, folderModelsCSharp, projFolderModelsCSharp, _relativeFolderModelsCSharp, true, false, true, sectionModelsInherited));
            /*Pass*/confArray.Add("__nombreTabla__Param.cs", new ImplConf(projectFolderModels + @"\" + projectFileNameModels, folderModelsCSharpAux, projFolderModelsCSharp, _relativeFolderModelsCSharp, true, false, true, sectionModelsInherited));
            //confArray.Add("__nombreTabla__ParamBindingModel.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModel, projFolderBindingModel, _relativeFolderBindingModel, true, false, true, sectionBindingInherited));
            //confArray.Add("__nombreTabla__ResultBindingModel.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModel, projFolderBindingModel, _relativeFolderBindingModel, true, false, true, sectionBindingInherited));
            //confArray.Add("__nombreTabla__SelectorDao.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp, projFolderDaoCSharp, _relativeFolderDaoCSharp, true, false, true, sectionSelector));
            //confArray.Add("__nombreTabla__GeneratedListDao.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharpGeneratedinto, projFolderDaoCSharpGeneratedinto, _relativeFolderDaoCSharpGeneratedinto, true, true, true, sectionDaoGenerated));
            //confArray.Add("I__nombreTabla__ControllerProvider.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController, projFolderController, _relativeFolderController, true, false, true, sectionControllersInherited));
            //confArray.Add("I__nombreTabla__DaoProvider.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp, projFolderDaoCSharp, _relativeFolderDaoCSharp, true, false, true, sectionDaoInherited));
            //confArray.Add("__nombreTabla__SelectListIControllerPart.txt", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController + "\\parts", projFolderController + "\\parts", _relativeFolderController + "\\parts", false, false, false, sectionControllersInherited));
            //confArray.Add("__nombreTabla__SelectListControllerPart.txt", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController + "\\parts", projFolderController + "\\parts", _relativeFolderController + "\\parts", false, false, false, sectionControllersInherited));
            //confArray.Add("__nombreTabla__SelectListIDaoPart.txt", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp + "\\parts", projFolderDaoCSharp + "\\parts", _relativeFolderDaoCSharp + "\\parts", false, false, false, sectionDaoInherited));
            //confArray.Add("__nombreTabla__SelectListDaoPart.txt", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp + "\\parts", projFolderDaoCSharp + "\\parts", _relativeFolderDaoCSharp + "\\parts", false, false, false, sectionDaoInherited));
            //confArray.Add("__nombreTabla__Generated.cs", new ImplConf(projectFolderModels + @"\" + projectFileNameModels, folderModelsGeneratedCSharp, projFolderModelsGeneratedCSharp, _relativeFolderModelsGeneratedCSharp, true, true, true, sectionModelsGenerated));
            //confArray.Add("__nombreTabla__ResultGenerated.cs", new ImplConf(projectFolderModels + @"\" + projectFileNameModels, folderModelsGeneratedCSharp, projFolderModelsGeneratedCSharp, _relativeFolderModelsGeneratedCSharp, true, true, true, sectionModelsGenerated));
            /*Pass*/confArray.Add("__nombreTabla__ParamGenerated.cs", new ImplConf(projectFolderModels + @"\" + projectFileNameModels, folderModelsCSharpAux, projFolderModelsCSharp, _relativeFolderModelsCSharp, true, true, true, sectionModelsGenerated));
            /*Pass*/confArray.Add("__nombreTabla__BindingModelGenerated.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModelGenerated, projFolderBindingModelGenerated, _relativeFolderBindingModelGenerated, true, true, true, sectionBindingGenerated));
            //confArray.Add("__nombreTabla__ParamBindingModelGenerated.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModelGenerated, projFolderBindingModelGenerated, _relativeFolderBindingModelGenerated, true, true, true, sectionBindingGenerated));
            //confArray.Add("__nombreTabla__ResultBindingModelGenerated.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModelGenerated, projFolderBindingModelGenerated, _relativeFolderBindingModelGenerated, true, true, true, sectionBindingGenerated));
            //confArray.Add("I__nombreTabla__DaoProviderGenerated.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharpGeneratedinto, projFolderDaoCSharpGeneratedinto, _relativeFolderDaoCSharpGeneratedinto, true, true, true, sectionDaoGenerated));
            //confArray.Add("__nombreTabla__ControllerGenerated.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderControllerGenerated, projFolderControllerGenerated, _relativeFolderControllerGenerated, true, true, true, sectionControllersGenerated));
            //confArray.Add("I__nombreTabla__ControllerProviderGenerated.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderControllerGenerated, projFolderControllerGenerated, _relativeFolderControllerGenerated, true, true, true, sectionControllersGenerated));
            //confArray.Add("__nombreTabla__ListSubViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            //confArray.Add("__nombreTabla__ListSubView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__ListSubView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__AddEditSubView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__AddEditSubView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__ItemSubViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            //confArray.Add("__nombreTabla__GeneratedCommandDao.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharpGeneratedinto, projFolderDaoCSharpGeneratedinto, _relativeFolderDaoCSharpGeneratedinto, true, true, true, sectionDaoGenerated));
            //confArray.Add("__nombreTabla__CommandDaoPart.txt", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp + "\\parts", projFolderDaoCSharp + "\\parts", _relativeFolderDaoCSharp + "\\parts", false, false, false, sectionDaoInherited));
            //confArray.Add("__nombreTabla__CommandIDaoPart.txt", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp + "\\parts", projFolderDaoCSharp + "\\parts", _relativeFolderDaoCSharp + "\\parts", false, false, false, sectionDaoInherited));
            //confArray.Add("__nombreTabla__CommandControllerPart.txt", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController + "\\parts", projFolderController + "\\parts", _relativeFolderController + "\\parts", false, false, false, sectionControllersInherited));
            //confArray.Add("__nombreTabla__CommandIControllerPart.txt", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController + "\\parts", projFolderController + "\\parts", _relativeFolderController + "\\parts", false, false, false, sectionControllersInherited));
            //confArray.Add("__nombreTabla__AddEditCommandView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__AddEditCommandView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__ItemCommandViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            //confArray.Add("__nombreTabla__ListCommandView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__ListCommandView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            //confArray.Add("__nombreTabla__ListCommandViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            //confArray.Add("__nombreTabla__PQueriesGenerated.cs", new ImplConf(projectFolderQueryTools + @"\" + projectFileNameQueryTools, folderDaoQueryToolsGeneratedinto, projFolderDaoQueryToolsGeneratedinto, _relativeFolderDaoQueryToolsGeneratedinto, true, true, true, sectionQueryToolsGenerated));
            //confArray.Add("__nombreTabla__VQueriesGenerated.cs", new ImplConf(projectFolderQueryTools + @"\" + projectFileNameQueryTools, folderDaoQueryToolsGeneratedinto, projFolderDaoQueryToolsGeneratedinto, _relativeFolderDaoQueryToolsGeneratedinto, true, true, true, sectionQueryToolsGenerated));
            //confArray.Add("__nombreTabla__QueriesGenerated.cs", new ImplConf(projectFolderQueryTools + @"\" + projectFileNameQueryTools, folderDaoQueryToolsGeneratedinto, projFolderDaoQueryToolsGeneratedinto, _relativeFolderDaoQueryToolsGeneratedinto, true, true, true, sectionQueryToolsGenerated));
            //confArray.Add("__nombreTabla__CreatePruebasUnitarias.txt", new ImplConf(projectFolderRoot + @"\" + projectFileNameRoot, folderPruebasUnitariasExcel, projFolderPruebasUnitariasExcel, _relativeFolderPruebasUnitariasExcel, false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__InsertPruebasUnitarias.txt", new ImplConf(projectFolderRoot + @"\" + projectFileNameRoot, folderPruebasUnitariasExcel, projFolderPruebasUnitariasExcel, _relativeFolderPruebasUnitariasExcel, false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__ViewModelUnitTest.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest, projFolderPruebasUnitariasTest, _relativeFolderPruebasUnitariasTest, false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__ControllerUnitTest.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest, projFolderPruebasUnitariasTest, _relativeFolderPruebasUnitariasTest, false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__DaoUnitTest.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest, projFolderPruebasUnitariasTest, _relativeFolderPruebasUnitariasTest, false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__BaseUnitTest.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest, projFolderPruebasUnitariasTest, _relativeFolderPruebasUnitariasTest, false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__BaseUnitTestSubViewPart.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest + "\\parts", projFolderPruebasUnitariasTest + "\\parts", _relativeFolderPruebasUnitariasTest + "\\parts", false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__BaseUnitTestSubProcPart.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest + "\\parts", projFolderPruebasUnitariasTest + "\\parts", _relativeFolderPruebasUnitariasTest + "\\parts", false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__DaoUnitTestSubViewPart.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest + "\\parts", projFolderPruebasUnitariasTest + "\\parts", _relativeFolderPruebasUnitariasTest + "\\parts", false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__DaoUnitTestSubProcPart.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest + "\\parts", projFolderPruebasUnitariasTest + "\\parts", _relativeFolderPruebasUnitariasTest + "\\parts", false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__ControllerUnitTestSubViewPart.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest + "\\parts", projFolderPruebasUnitariasTest + "\\parts", _relativeFolderPruebasUnitariasTest + "\\parts", false, false, false, sectionViewModelsTest));
            //confArray.Add("__nombreTabla__ControllerUnitTestSubProcPart.cs", new ImplConf(projectFolderIposV3_ViewModels_Tests + @"\" + projectFileNameIposV3_ViewModels_Tests, folderPruebasUnitariasTest + "\\parts", projFolderPruebasUnitariasTest + "\\parts", _relativeFolderPruebasUnitariasTest + "\\parts", false, false, false, sectionViewModelsTest));
            /*Pass*/confArray.Add("__nombreTabla__CommunicationParameters.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            //confArray.Add("__nombreTabla__Queries.cs", new ImplConf(projectFolderQueryTools + @"\" + projectFileNameQueryTools, folderDaoQueryToolsinto, projFolderDaoQueryToolsinto, _relativeFolderDaoQueryToolsinto, true, false, true, sectionQueryTools));
            //confArray.Add("__nombreTabla__ListViewModelGenerated.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModelGenerated, projFolderViewModelGenerated, _relativeFolderViewModelGenerated, false, false, true, sectionViewModelsGenerated));
            //confArray.Add("__nombreTabla__ItemViewModelGenerated.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModelGenerated, projFolderViewModelGenerated, _relativeFolderViewModelGenerated, false, false, true, sectionViewModelsGenerated));
            //confArray.Add("__nombreTabla__ListSubViewModelGenerated.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModelGenerated, projFolderViewModelGenerated, _relativeFolderViewModelGenerated, false, false, true, sectionViewModelsGenerated));
            //confArray.Add("__nombreTabla__ItemSubViewModelGenerated.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModelGenerated, projFolderViewModelGenerated, _relativeFolderViewModelGenerated, false, false, true, sectionViewModelsGenerated));
            //confArray.Add("__nombreTabla__ListCommandViewModelGenerated.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModelGenerated, projFolderViewModelGenerated, _relativeFolderViewModelGenerated, false, false, true, sectionViewModelsGenerated));
            //confArray.Add("__nombreTabla__ItemCommandViewModelGenerated.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModelGenerated, projFolderViewModelGenerated, _relativeFolderViewModelGenerated, false, false, true, sectionViewModelsGenerated));

            //confArray.Add("__nombreTabla__GeneratedImpoDao.cs", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharpGeneratedinto, projFolderDaoCSharpGeneratedinto, _relativeFolderDaoCSharpGeneratedinto, true, true, true, sectionDaoGenerated));
            //confArray.Add("__nombreTabla__ImpoExpoDaoPart.txt", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp + "\\parts", projFolderDaoCSharp + "\\parts", _relativeFolderDaoCSharp + "\\parts", false, false, false, sectionDaoInherited));
            //confArray.Add("__nombreTabla__ImpoExpoIDaoPart.txt", new ImplConf(projectFolderDataAccess + @"\" + projectFileNameDataAccess, folderDaoCSharp + "\\parts", projFolderDaoCSharp + "\\parts", _relativeFolderDaoCSharp + "\\parts", false, false, false, sectionDaoInherited));
            //confArray.Add("__nombreTabla__ImpoExpoControllerPart.txt", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController + "\\parts", projFolderController + "\\parts", _relativeFolderController + "\\parts", false, false, false, sectionControllersInherited));
            //confArray.Add("__nombreTabla__ImpoExpoIControllerPart.txt", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController + "\\parts", projFolderController + "\\parts", _relativeFolderController + "\\parts", false, false, false, sectionControllersInherited));
            //confArray.Add("__nombreTabla__IQueriesGenerated.cs", new ImplConf(projectFolderQueryTools + @"\" + projectFileNameQueryTools, folderDaoQueryToolsGeneratedinto, projFolderDaoQueryToolsGeneratedinto, _relativeFolderDaoQueryToolsGeneratedinto, true, true, true, sectionQueryToolsGenerated));

            confArray.Add("__nombreTabla__WFView.xaml.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            confArray.Add("__nombreTabla__WFView.xaml", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            confArray.Add("__nombreTabla__WFViewModel.cs", new ImplConf(projectFolderIposV3_ViewModels + @"\" + projectFileNameIposV3_ViewModels, folderViewModel, projFolderViewModel, _relativeFolderViewModel, false, false, true, sectionViewModels));
            confArray.Add("__nombreTabla__WFBindingModel.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModel, projFolderBindingModel, _relativeFolderBindingModel, true, false, true, sectionBindingInherited));
            confArray.Add("__nombreTabla__ImpoExpoService.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModel, projFolderBindingModel, _relativeFolderBindingModel, true, false, true, sectionBindingInherited));

            confArray.Add("__nombreTabla___ApiParam.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderBindingModel, projFolderBindingModel, _relativeFolderBindingModel, true, false, true, sectionBindingInherited));
            confArray.Add("__nombreTabla__WebController.cs", new ImplConf(projectFolderControllersCSharp + @"\" + projectFileNameControllersCSharp, folderController, projFolderController, _relativeFolderController, true, false, true, sectionControllersInherited));
            confArray.Add("__nombreTabla___ApiController.cs", new ImplConf(projectFolderIposV3 + @"\" + projectFileNameIposV3, folderView, projFolderView, _relativeFolderView, false, false, true, sectionView));
            /*NUll miscelaneas*/





            List<ImplConfMisc> confMiscleneaList = new List<ImplConfMisc>();
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_general_lst_2.txt", "__nombreTabla__ListViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //CaseTest Menu Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_general_lst_1.txt", "__nombreTabla__ListViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //NewTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_sublist_lst_2.txt", "__nombreTabla__ListSubViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //CaseTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_sublist_lst_1.txt", "__nombreTabla__ListSubViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //NewTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_sublist_edit_2.txt", "__nombreTabla__ItemSubViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //CaseTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_sublist_edit_1.txt", "__nombreTabla__ItemSubViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //NewTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_subproc_lst_2.txt", "__nombreTabla__ListCommandViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //CaseTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_subproc_lst_1.txt", "__nombreTabla__ListCommandViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //NewTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_subproc_edit_1.txt", "__nombreTabla__ItemCommandViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //NewTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__main_view_menu_subproc_edit_2.txt", "__nombreTabla__ItemCommandViewModel.cs", projectFolderIposV3_ViewModels + "\\MainWindowViewModel.cs", "            //CaseTest Menu Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_controller_dao.txt", "__nombreTabla__GeneratedDao.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Component Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_viewlocator_general_lst.txt", "__nombreTabla__ListViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //ViewLocator Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_viewlocator_general_edit.txt", "__nombreTabla__ItemViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //ViewLocator Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_viewlocator_sublist_lst.txt", "__nombreTabla__ListSubViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //ViewLocator Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_viewlocator_sublist_edit.txt", "__nombreTabla__ItemSubViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //ViewLocator Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_viewlocator_subproc_edit.txt", "__nombreTabla__ItemCommandViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //ViewLocator Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_viewlocator_subproc_lst.txt", "__nombreTabla__ListCommandViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //ViewLocator Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_container_viewmodel_lst.txt", "__nombreTabla__ListViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Container Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_container_viewmodel_sublist_lst.txt", "__nombreTabla__ListSubViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Container Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_container_viewmodel_subproc_lst.txt", "__nombreTabla__ListCommandViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Container Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_container_viewmodel_edit.txt", "__nombreTabla__ItemViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Container Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_container_viewmodel_sublist_edit.txt", "__nombreTabla__ItemSubViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Container Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__bootstraper_container_viewmodel_subproc_edit.txt", "__nombreTabla__ItemCommandViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "            //Container Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_1.txt", "__nombreTabla__ListViewModel.cs", projectFolderControllersCSharp + "\\Controller\\catalog_selector\\CatalogSelector.cs", "//DAO Declaration Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_2.txt", "__nombreTabla__ListViewModel.cs", projectFolderControllersCSharp + "\\Controller\\catalog_selector\\CatalogSelector.cs", "//DAO Parameter Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_3.txt", "__nombreTabla__ListViewModel.cs", projectFolderControllersCSharp + "\\Controller\\catalog_selector\\CatalogSelector.cs", "//DAO Assignement Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_4.txt", "__nombreTabla__ListViewModel.cs", projectFolderControllersCSharp + "\\Controller\\catalog_selector\\CatalogSelector.cs", "//Case ObtainCatalogs Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_5.txt", "__nombreTabla__ListViewModel.cs", projectFolderControllersCSharp + "\\Controller\\catalog_selector\\CatalogSelector.cs", "//Case ObtainItemByClave Generator Flag"));
            /*Pass*/confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_6.txt", "__nombreTabla__ListViewModel.cs", projectFolderIposV3 + "\\Bootstrapper.cs", "//Case DaoSelector Generator Flag"));
            //confMiscleneaList.Add(new ImplConfMisc("misc___nombreTabla__catalog_selector_7.txt", "__nombreTabla__SelectorDao.cs", projectFolderIposV3_ViewModels_Tests + "\\BaseViewModelUnitTest.cs", "//DAO Parameter calling Generator Flag"));


            
            var plantillasModoMigracion = new List<string>()
            {
                "__nombreTabla__WFView.xaml.cs",
                "__nombreTabla__WFView.xaml", 
                "__nombreTabla__WFViewModel.cs", 
                "__nombreTabla__WFBindingModel.cs",

                "__nombreTabla__ImpoExpoService.cs"
            };


            var plantillasModoParametrosControladores = new List<string>()
            {
                "__nombreTabla___ApiParam.cs",
            };

            var plantillasModoControladores = new List<string>()
            {
                "__nombreTabla__WebController.cs",
                "__nombreTabla___ApiController.cs",
                "miscelaneawpf.txt"
            };

            var plantillasModoComun = new List<string>()
            {
                "__nombreTabla__ListViewModel.cs",
                "__nombreTabla__ListView.xaml.cs",
                "__nombreTabla__ListView.xaml",
                "__nombreTabla__CommunicationParameters.cs"
        };


            string[] auxFilesConcentrado = new string[1];
            auxFilesConcentrado[0] = "miscelaneawpf.txt";





            Hashtable? auxFoldersConcentrado = default(Hashtable);
            auxFoldersConcentrado = new Hashtable();


            auxFoldersConcentrado.Add("miscelaneawpf.txt", folderMiscelanea);






            string? plantillas = null;
            foreach (string plantillas_loopVariable in auxFiles)
            {
                //if (plantillas_loopVariable != "__nombreTabla__AddEditView.xaml")
                //    continue;

                if ((modoGenerador == "migracion" && !plantillasModoMigracion.Contains(plantillas_loopVariable) && !plantillasModoComun.Contains(plantillas_loopVariable) )||
                    (modoGenerador == "parametroscontroladores" && !plantillasModoParametrosControladores.Contains(plantillas_loopVariable)) ||
                    (modoGenerador == "controladores" && !plantillasModoControladores.Contains(plantillas_loopVariable)) ||
                    (modoGenerador != "migracion" && plantillasModoMigracion.Contains(plantillas_loopVariable)))
                    continue;

                plantillas = plantillas_loopVariable;

                if ((plantillas != null))
                {

                    this.ExcelWebCustomCtrls1.Tables["Hoja1"]?.Clear();

                    string? myDocumentsFolder = null;
                    myDocumentsFolder = System.AppDomain.CurrentDomain.BaseDirectory + "GENERADOR";
                    LlenarDatosPlantilla(myDocumentsFolder + "\\" + plantillas);


                    string stringPrimerArch = "";
                    foreach (DataRow dr in this.DataSetSchema1.Tables["UserTables"]!.Rows)
                    {
                        if (!auxTipoFiles[plantillas]!.ToString()!.Split(',').Contains(dr["Tipo"].ToString()))
                            continue;




                        if ((dr["cb"].ToString() == "1"))
                        {
                            
                            if ((modoGenerador == "migracion" && !plantillasModoMigracion.Contains(plantillas_loopVariable) && !plantillasModoComun.Contains(plantillas_loopVariable)) ||
                                (modoGenerador == "parametroscontroladores" && !plantillasModoParametrosControladores.Contains(plantillas_loopVariable)) ||
                                (modoGenerador == "controladores" && !plantillasModoControladores.Contains(plantillas_loopVariable)) ||
                                (modoGenerador != "migracion" && plantillasModoMigracion.Contains(plantillas_loopVariable)))
                                continue;

                            LlenarDatosColumnas(excelPath, (modoGenerador == "migracion" || modoGenerador == "parametroscontroladores") ? dr["NameHyphenized"].ToString()!:  dr["Name"].ToString()!);

                            var includeCommandForWholeEntity = IncludeCommandForWholeEntity();

                            int parrafoConsecutivo = 0;
                            Parrafo?[] auxParrafoSecuencia = new Parrafo?[this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count + 1];

                            int i = 0;

                            for (i = 0; i <= this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count; i++)
                            {
                                //auxSecuencia[i] = "";
                                auxParrafoSecuencia[i] = null;
                            }


                            stringPrimerArch = "";
                            //stringPrimerArchPorParrafos = "";


                            int contadorCampos = 0, contadorCamposAplicado = 0;

                            foreach (DataRow dr2 in this.DataSetSchema1.Tables["Columnas"]!.Rows)
                            {
                                contadorCampos = contadorCampos + 1;


                                int contadorParrafosPlantilla = 0;
                                bool bCampoAparecio = false;
                                foreach (DataRow drRegInt in this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows)
                                {


                                    Parrafo? parrafo = null;

                                    if (auxParrafoSecuencia[contadorParrafosPlantilla] != null)
                                        parrafo = auxParrafoSecuencia[contadorParrafosPlantilla];
                                    else
                                    {
                                        parrafo = new Parrafo(drRegInt["ID"].ToString(),
                                                                drRegInt["ORDENAR"].ToString(), 0);
                                        auxParrafoSecuencia[contadorParrafosPlantilla] = parrafo;
                                    }

                                    if (parrafo == null)
                                        continue;


                                    try
                                    {
                                        if ((!string.IsNullOrEmpty(drRegInt["QUITARCHR_FINAL"].ToString())))
                                        {
                                            //auxQuitarChrFin[contadorParrafosPlantilla] = int.Parse(drRegInt["QUITARCHR_FINAL"].ToString());
                                            parrafo.QuitarChrFin = int.Parse(drRegInt["QUITARCHR_FINAL"].ToString()!);
                                        }
                                        else
                                        {
                                            //    auxQuitarChrFin[contadorParrafosPlantilla] = 0;
                                            parrafo.QuitarChrFin = 0;
                                        }

                                    }
                                    catch
                                    {
                                        //auxQuitarChrFin[contadorParrafosPlantilla] = 0;
                                        parrafo.QuitarChrFin = 0;
                                    }


                                    //string? x = null;
                                    //if (drRegInt["TEXTO"].ToString()!.Contains("297"))
                                    //{
                                    //    x = "";
                                    //}



                                    if ((
                                    (double.Parse(drRegInt["TIPOREPETICION"].ToString()!) == 1 | contadorCampos == 1) &
                                    (Array.IndexOf(drRegInt["EQUIVALENCIASTIPOFORMSIGUAL"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), equivalenciasTipoForms(tipificacionEnBase(dr2["DATA_TYPE"].ToString()!, dr2["SUBTIPO"].ToString()!)).ToUpper()) != -1 | drRegInt["EQUIVALENCIASTIPOFORMSIGUAL"].ToString()!.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["EQUIVALENCIASTIPOFORMSDIFERENTE"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), equivalenciasTipoForms(tipificacionEnBase(dr2["DATA_TYPE"].ToString()!, dr2["SUBTIPO"].ToString()!)).ToUpper()) == -1 | drRegInt["EQUIVALENCIASTIPOFORMSDIFERENTE"].ToString()!.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPODEDATATYPEIGUAL"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr2["DATA_TYPE"].ToString()!.ToUpper()) != -1 | drRegInt["TIPODEDATATYPEIGUAL"].ToString()!.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPODEDATATYPEDIFERENTE"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr2["DATA_TYPE"].ToString()!.ToUpper()) == -1 | drRegInt["TIPODEDATATYPEDIFERENTE"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["IDENTIDAD"].ToString()!.ToUpper() == dr2["IDENTIDAD"].ToString()!.ToUpper() | drRegInt["IDENTIDAD"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["IS_KEY"].ToString()!.ToUpper() == dr2["IS_KEY"].ToString()!.ToUpper() | drRegInt["IS_KEY"].ToString()!.ToUpper() == "IGNORAR" | int.Parse(numtableKeys[quitaAcentos(dr["Name"].ToString()!)!]!.ToString()!) == 0 | (dr2["COLUMN_NAME"].ToString()!.Contains("PK__") & drRegInt["IS_KEY"].ToString()!.ToUpper() == "SI")) &
                                    (drRegInt["ISNULLEABLE"].ToString()!.ToUpper() == dr2["IS_NULLABLE"].ToString()?.ToUpper() | drRegInt["ISNULLEABLE"].ToString()!.ToUpper() == "IGNORAR") &

                                    (drRegInt["ESCALCULADO"].ToString()!.ToUpper() == dr2["ESCALCULADO"].ToString()?.ToUpper() | drRegInt["ESCALCULADO"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ESCOMBO"].ToString()!.ToUpper() == dr2["ESCOMBO"].ToString()?.ToUpper() | drRegInt["ESCOMBO"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ENLISTA"].ToString()!.ToUpper() == dr2["ENLISTA"].ToString()?.ToUpper() | drRegInt["ENLISTA"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ENEDICION"].ToString()!.ToUpper() == dr2["ENEDICION"].ToString()?.ToUpper() | drRegInt["ENEDICION"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["DOMAIN_NAME"].ToString()!.ToUpper() == dr2["DOMAIN_NAME"].ToString()?.ToUpper() | drRegInt["DOMAIN_NAME"].ToString()!.ToUpper() == "IGNORAR" | (drRegInt["DOMAIN_NAME"].ToString()?.ToUpper() == "VACIO" & "" == dr2["DOMAIN_NAME"].ToString()?.ToUpper()) | (drRegInt["DOMAIN_NAME"].ToString()?.ToUpper() == "CONDATOS" & "" != dr2["DOMAIN_NAME"].ToString()?.ToUpper())) &
                                    (drRegInt["ENUPDATE"].ToString()!.ToUpper() == dr2["ENUPDATE"].ToString()?.ToUpper() | drRegInt["ENUPDATE"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ENINSERT"].ToString()!.ToUpper() == dr2["ENINSERT"].ToString()?.ToUpper() | drRegInt["ENINSERT"].ToString()!.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPOCONTROL"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr2["TIPOCONTROL"].ToString()!.ToUpper()) != -1 | drRegInt["TIPOCONTROL"].ToString()?.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPOCONTROLDIFERENTE"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr2["TIPOCONTROL"].ToString()!.ToUpper()) == -1 | drRegInt["TIPOCONTROLDIFERENTE"].ToString()?.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["SUBTIPOIGUAL"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr2["SUBTIPO"].ToString()!.ToUpper()) != -1 | drRegInt["SUBTIPOIGUAL"].ToString()?.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["SUBTIPODIFERENTE"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr2["SUBTIPO"].ToString()!.ToUpper()) == -1 | drRegInt["SUBTIPODIFERENTE"].ToString()?.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPOARCHIVO"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr["Tipo"].ToString()!.ToUpper()) != -1 | drRegInt["TIPOARCHIVO"].ToString()?.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPOARCHIVODIFERENTE"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr["Tipo"].ToString()!.ToUpper()) == -1 | drRegInt["TIPOARCHIVODIFERENTE"].ToString()?.ToUpper() == "IGNORAR") &
                                    (drRegInt["ENBUSQUEDALISTA"].ToString()!.ToUpper() == dr2["ENBUSQUEDALISTA"].ToString()!.ToUpper() | drRegInt["ENBUSQUEDALISTA"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ESTABLAGENERAL"].ToString()!.ToUpper() == dr["ESTABLAGENERAL"].ToString()!.ToUpper() | drRegInt["ESTABLAGENERAL"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ESSUBENTIDAD"].ToString()!.ToUpper() == dr2["ESSUBENTIDAD"].ToString()!.ToUpper() | drRegInt["ESSUBENTIDAD"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ESCAMPODECATALOGO"].ToString()!.ToUpper() == dr2["ESCAMPODECATALOGO"].ToString()!.ToUpper() | drRegInt["ESCAMPODECATALOGO"].ToString()!.ToUpper() == "IGNORAR") &
                                    (drRegInt["ESCATALOGOGENERICO"].ToString()!.ToUpper() == dr2["ESCATALOGOGENERICO"].ToString()!.ToUpper() | drRegInt["ESCATALOGOGENERICO"].ToString()!.ToUpper() == "IGNORAR") &
                                    ((drRegInt["ENGRIDDEFINIDO"].ToString()!.ToUpper() == "SI" && dr2["GRID"] !=  null && dr2["GRID"].ToString()!.Length > 0 ) | (drRegInt["ENGRIDDEFINIDO"].ToString()!.ToUpper() == "NO" && (dr2["GRID"] == null || dr2["GRID"].ToString()?.Length == 0)) | drRegInt["ENGRIDDEFINIDO"].ToString()?.ToUpper() == "IGNORAR")


                                    ))
                                    {



                                        string auxStr = drRegInt["TEXTO"].ToString()!;



                                        auxStr = auxStr.Replace("(nombreEsquema)", minusculaPrimeraLetra(quitaAcentos(dr["Schema_"].ToString())));
                                        auxStr = auxStr.Replace("(nombreTabla)", mayusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString())));
                                        auxStr = auxStr.Replace("(nombreTablaParent)", mayusculaPrimeraLetra(quitaAcentos(dr["NameParent"].ToString())));
                                        auxStr = auxStr.Replace("(nombreTablaGuionizado)", minusculaPrimeraLetra(dr["NameHyphenized"].ToString()));
                                        auxStr = auxStr.Replace("(nombreTablaTitle)", mayusculaPrimeraLetra(dr["Title"].ToString()));
                                        auxStr = auxStr.Replace("(nombreTablaReal)", dr["NameRealTable"].ToString());
                                        auxStr = auxStr.Replace("(nombreTablaMinPrimeraLetra)", minusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString())));

                                        auxStr = auxStr.Replace("(nombreTablaSinNormalizar)", dr["Name"].ToString());
                                        auxStr = auxStr.Replace("(nombreTablaSinPrefijoCtrl)", dr["Name"].ToString()?.Replace("CtlPers__", ""));
                                        auxStr = auxStr.Replace("(nombreSistema)", nombreSistema);
                                        auxStr = auxStr.Replace("(nombreCampo)", quitaAcentos(dr2["COLUMN_NAME"].ToString()));
                                        auxStr = auxStr.Replace("(nombreCampoCapitalizado)", mayusculaPrimeraLetra(quitaAcentos(dr2["COLUMN_NAME"].ToString())));
                                        auxStr = auxStr.Replace("(nombreCampoMayuscula)", (quitaAcentos(dr2["COLUMN_NAME"].ToString())).ToUpper() );
                                        try
                                        {
                                            auxStr = auxStr.Replace("(nombreTablaRel)", dr2["TABLE_NAME_KEY"].ToString());
                                            auxStr = auxStr.Replace("(nombreCampoRel)", quitaAcentos(dr2["COLUMN_NAME_KEY"].ToString()));
                                            auxStr = auxStr.Replace("(nombreCampoRelText)", dr2["COLUMN_NAME_KEY_TEXT"].ToString());

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }



                                        auxStr = auxStr.Replace("(tipoCampoLenguaje2)", equivalenciasTipoForms(tipificacionEnBase(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString())));
                                        auxStr = auxStr.Replace("(nombreCampoSinNormalizar)", dr2["COLUMN_NAME"].ToString());


                                        auxStr = auxStr.Replace("(dominioBase)", dr2.IsNull("DOMAIN_NAME") ? "" : dr2["DOMAIN_NAME"].ToString());
                                        auxStr = auxStr.Replace("(tipoCampoEnBaseODominio)", tipificacionEnBaseODominio(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString(), dr2.IsNull("DOMAIN_NAME") ? "" : dr2["DOMAIN_NAME"].ToString(), true));
                                        auxStr = auxStr.Replace("(tipoCampoEnBase)", tipificacionEnBase(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString(), true));
                                        auxStr = auxStr.Replace("(tipoCampoEnDBType)", tipificacionEnDBType(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString(), true));

                                        auxStr = auxStr.Replace("(consecutivo)", contadorCampos.ToString());
                                        auxStr = auxStr.Replace("(consecutivoAplicado)", contadorCamposAplicado.ToString());
                                        int auxConsecutivo30 = (contadorCampos * 30) + 20;
                                        auxStr = auxStr.Replace("(consecutivo30)", auxConsecutivo30.ToString());
                                        auxStr = auxStr.Replace("(tipoCampoLenguaje)", equivalenciasTipo(tipificacionEnBase(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString()), dr2["SUBTIPO"].ToString()!));
                                        auxStr = auxStr.Replace("(tipoCampoLenguaje3)", dr2["DATA_TYPE"].ToString());
                                        if (object.ReferenceEquals(dr2["SIZE"], System.DBNull.Value))
                                        {
                                            auxStr = auxStr.Replace("((longitudDeCampoEnBase))", "");
                                        }
                                        else
                                        {
                                            auxStr = auxStr.Replace("(longitudDeCampoEnBase)", dr2["SIZE"].ToString());

                                        }


                                        auxStr = auxStr.Replace("(tipoCampoAngular)", equivalenciasTipoAngular(tipificacionEnBase(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString())));
                                        auxStr = auxStr.Replace("(tipoCampoJsonSquema)", this.equivalenciasTipoJsonSquema(tipificacionEnBase(dr2["DATA_TYPE"].ToString(), dr2["SUBTIPO"].ToString())));

                                        auxStr = auxStr.Replace("(anchoB12)", dr2["ANCHOB12"] != null && dr2["ANCHOB12"].ToString()!.Length > 0 ? dr2["ANCHOB12"].ToString() : "3");
                                        auxStr = auxStr.Replace("(nombreCampoEnForm)", dr2["NOMBREENFORM"] != null && dr2["NOMBREENFORM"].ToString()!.Length > 0 ? dr2["NOMBREENFORM"].ToString() : quitaAcentos(dr2["COLUMN_NAME"].ToString()));

                                        //tab
                                        auxStr = auxStr.Replace("(tab)", dr2["TAB"] != null && dr2["TAB"].ToString()!.Length > 0 ? dr2["TAB"].ToString() : "");

                                        //especiales
                                        auxStr = auxStr.Replace("(asteriscoifnotnull)", dr2["IS_NULLABLE"] != null && dr2["IS_NULLABLE"].ToString() == "NO" ? "*" : "");
                                        auxStr = auxStr.Replace("(requeridoXmlifnotnull)", dr2["IS_NULLABLE"] != null && dr2["IS_NULLABLE"].ToString() == "NO" &&
                                                                                           dr2["ENEDICION"] != null && dr2["ENEDICION"].ToString() == "SI" ? "[Required(ErrorMessage = \"Es requerido\")]" : "");

                                        auxStr = auxStr.Replace("(queryStringList)", dr["Query"].ToString());

                                        auxStr = auxStr.Replace("(tipoCampoEnExcel)", equivalenciasTipoConExcel(dr2["DATA_TYPE"].ToString()!));
                                        auxStr = auxStr.Replace("(defaultExcelValue)", defaultTestValueParaExcel(dr2["DATA_TYPE"].ToString()!));

                                        try
                                        {
                                            auxStr = auxStr.Replace("(catalogo)", dr2["CATALOGO"].ToString());
                                            auxStr = auxStr.Replace("(catalogocampoclave)", dr2["CATALOGOCAMPOCLAVE"].ToString());
                                            auxStr = auxStr.Replace("(catalogocampoclave_capitalizado)", (dr2["CATALOGOCAMPOCLAVE"].ToString() ?? "").ToUpper());
                                            auxStr = auxStr.Replace("(catalogocamponombre)", dr2["CATALOGOCAMPONOMBRE"].ToString());
                                            auxStr = auxStr.Replace("(catalogolistavmname)", dr2["CATALOGOLISTAVMNAME"].ToString());
                                            auxStr = auxStr.Replace("(catalogoselectobjectname)", dr2["CATALOGOSELECTOBJECTNAME"].ToString());
                                            auxStr = auxStr.Replace("(catalogoselectfieldtname)", dr2["CATALOGOSELECTFIELDTNAME"].ToString());

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        try
                                        {
                                            auxStr = auxStr.Replace("(nombreCampoCallIns)", NombreCampoCallInsert(quitaAcentos(dr2["COLUMN_NAME"].ToString()), ForeignKeyToStr(dr["ForeignMainKey"].ToString(), dr["NameRealTable"].ToString()), dr["NameRealTable"].ToString()));
                                            auxStr = auxStr.Replace("(nombreCampoCallUpd)", NombreCampoCallUpdate(quitaAcentos(dr2["COLUMN_NAME"].ToString()), ForeignKeyToStr(dr["ForeignMainKey"].ToString(), dr["NameRealTable"].ToString()), dr["NameRealTable"].ToString()));
                                            auxStr = auxStr.Replace("(foreign_main_key)", ForeignKeyToStr(dr["ForeignMainKey"].ToString(), dr["NameRealTable"].ToString()));
                                        }
                                        catch { }


                                        try
                                        {
                                            auxStr = auxStr.Replace("(nombreCampoClave)", quitaAcentos(dr["CampoClave"].ToString()));
                                            auxStr = auxStr.Replace("(nombreCampoNombre)", quitaAcentos(dr["CampoNombre"].ToString()));
                                        }
                                        catch { }



                                        try
                                        {
                                            auxStr = auxStr.Replace("(SUBENTIDADTIPO)", dr2["SUBENTIDADTIPO"].ToString());
                                            auxStr = auxStr.Replace("(SUBENTIDADCAMPO)", dr2["SUBENTIDADCAMPO"].ToString());
                                            auxStr = auxStr.Replace("(SUBENTIDADCAMPOFORCED)", dr2["SUBENTIDADCAMPO"].ToString()?.Replace("?","!"));
                                            auxStr = auxStr.Replace("(SUBENTIDADCAMPOREL)", dr2["SUBENTIDADCAMPOREL"].ToString());

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }


                                        try
                                        {
                                            auxStr = auxStr.Replace("(defaultValue)", (dr2["DEFAULTVALUE"].ToString() ?? "").Length > 0 ? dr2["DEFAULTVALUE"].ToString() : "null");
                                            auxStr = auxStr.Replace("(nullableSign)", NullableSign(dr2));
                                            auxStr = auxStr.Replace("(nullableAssignment)", NullableAssignment(dr2));
                                            auxStr = auxStr.Replace("(nullableValueAssignment)", NullableValueAssignment(dr2));

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }



                                        try
                                        {
                                            auxStr = auxStr.Replace("(ENTIDADCATALOGO)", dr2["ENTIDADCATALOGO"].ToString());
                                            auxStr = auxStr.Replace("(ENTIDADCATALOGOCAMPO)", dr2["ENTIDADCATALOGOCAMPO"].ToString());
                                            auxStr = auxStr.Replace("(ENTIDADCATALOGOCAMPOREL)", dr2["ENTIDADCATALOGOCAMPOREL"].ToString());

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        try
                                        {

                                            auxStr = auxStr.Replace("(nombreCampoConRuta)", nombreCampoEnRuta(dr2));

                                        }
                                        catch(Exception ex) {
                                            Console.WriteLine(ex.Message);
                                        }


                                        try
                                        {
                                            auxStr = auxStr.Replace("(includeCommandForWholeEntity)", includeCommandForWholeEntity);  
                                        }
                                        catch  { }


                                        try
                                        {
                                            auxStr = auxStr.Replace("(GRID)", dr2["GRID"].ToString());
                                            auxStr = auxStr.Replace("(OBJETOPROPIEDAD)", dr2["OBJETOPROPIEDAD"].ToString());
                                            auxStr = auxStr.Replace("(PROPIEDAD)", dr2["PROPIEDAD"].ToString());

                                        }
                                        catch { }

                                        auxStr = auxStr.Replace("(|)", "|");

                                        ParrafoLinea parrafoLinea = new ParrafoLinea(++parrafoConsecutivo, auxStr, dr2["ORDEN"].ToString(), dr2["ORDEN2"].ToString(),
                                            dr2["GRUPOFORM"] != null ? dr2["GRUPOFORM"].ToString() : "", dr2["TAB"] != null ? dr2["TAB"].ToString() : "",
                                            dr2["GRID"] != null ? dr2["GRID"].ToString() : "", drRegInt["ORDENAR"].ToString());
                                        parrafo.ParrafoLineas.Add(parrafoLinea);

                                        bCampoAparecio = true;
                                    }

                                    contadorParrafosPlantilla += 1;
                                }

                                if (bCampoAparecio)
                                {
                                    contadorCamposAplicado++;
                                    bCampoAparecio = false;
                                }

                            }

                            //for (i = 0; i <= this.ExcelWebCustomCtrls1.Tables["Hoja1"].Rows.Count; i++)
                            //{


                            //    if(auxSecuencia[i].Length - auxQuitarChrFin[i] > 0)
                            //        auxSecuencia[i] = auxSecuencia[i].Substring(0, auxSecuencia[i].Length - auxQuitarChrFin[i]);


                            //    stringPrimerArch += auxSecuencia[i];
                            //}



                            List<ParrafoLinea> parrafoLineaACodificar = new List<ParrafoLinea>();
                            for (i = 0; i <= this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count; i++)
                            {
                                if (auxParrafoSecuencia[i] == null)
                                    continue;


                                bool esParrafoEnAgrupacionOrdenada = auxParrafoSecuencia[i]?.Ordenar == "SI" || auxParrafoSecuencia[i]?.Ordenar == "SI2";
                                bool esParrafoEnAgrupacionOrdenadaYContinua = auxParrafoSecuencia[i + 1] != null && (auxParrafoSecuencia[i + 1]?.Ordenar == "SI" || auxParrafoSecuencia[i + 1]?.Ordenar == "SI2");


                                parrafoLineaACodificar.AddRange(auxParrafoSecuencia[i]!.ParrafoLineas);
                                if (esParrafoEnAgrupacionOrdenada)
                                {
                                    if (esParrafoEnAgrupacionOrdenadaYContinua)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        bool esParrafoEnAgrupacionAgrupada = auxParrafoSecuencia[i]?.Agrupado == "SI";
                                        if (esParrafoEnAgrupacionAgrupada)
                                        {
                                            List<ParrafoLinea> parrafoLineaBuffer = new List<ParrafoLinea>();
                                            var parrafoInicioMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_inicio == "SI").FirstOrDefault();
                                            var parrafoFinMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_fin == "SI").FirstOrDefault();


                                            var parrafoTabInicioMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_tab_inicio == "SI").FirstOrDefault();
                                            var parrafoTabFinMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_tab_fin == "SI").FirstOrDefault();

                                            var parrafoTabcInicioMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_tabc_inicio == "SI").FirstOrDefault();
                                            var parrafoTabcFinMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_tabc_fin == "SI").FirstOrDefault();


                                            var parrafoGridInicioMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_grid_inicio == "SI").FirstOrDefault();
                                            var parrafoGridFinMolde = parrafoLineaACodificar.Where(x => x.Agrupador == "SI" && x.Agrupador_grid_fin == "SI").FirstOrDefault();


                                            var parrafoTabs = parrafoLineaACodificar.Where(x => x.Agrupador == "NO" && x.Tab != null).OrderBy(x => x.Tab).Select(x => x.Tab!).Distinct().ToList();
                                            var hayTabs = parrafoTabs.Any(y => y != null && y.Length > 0);


                                            if (hayTabs && parrafoTabcInicioMolde != null)
                                            {
                                                parrafoLineaBuffer.Add(FormatearCabeceraTab(parrafoTabcInicioMolde, "")!);
                                            }

                                            foreach (string strTab in parrafoTabs)
                                            {


                                                if (parrafoTabInicioMolde != null && strTab != null && strTab.Length > 0)
                                                    parrafoLineaBuffer.Add(FormatearCabeceraTab(parrafoTabInicioMolde, strTab)!);


                                                var parrafoGridsInTab = parrafoLineaACodificar.Where(x => x.Agrupador == "NO" && (!hayTabs || x.Tab == strTab) && x.Grid != null).OrderBy(x => x.Grid).Select(x => x.Grid!).Distinct().ToList();
                                                var hayGridsInTab = parrafoGridsInTab.Any(y => y != null && y.Length > 0);

                                                foreach (string strGrid in parrafoGridsInTab)
                                                {

                                                    if (parrafoGridInicioMolde != null && ((strGrid != null && strGrid.Length > 0) || parrafoGridInicioMolde.Agrupador_siempre == "SI"))
                                                        parrafoLineaBuffer.Add(FormatearCabeceraGrid(parrafoGridInicioMolde, strGrid, dr["Name"].ToString()!)!);



                                                    var parrafoGroups = parrafoLineaACodificar.Where(x => x.Agrupador == "NO" && (!hayTabs || x.Tab == strTab) && (!hayGridsInTab || x.Grid == strGrid) && x.Grupo != null).OrderBy(x => x.Grupo).Select(x => x.Grupo!).Distinct().ToList();
                                                    foreach (string strGrupo in parrafoGroups)
                                                    {
                                                        if (parrafoInicioMolde != null && strGrid == "")
                                                            parrafoLineaBuffer.Add(FormatearCabeceraGrupo(parrafoInicioMolde, strGrupo)!);

                                                        List<ParrafoLinea> parrafoLineaInternalBuffer = new List<ParrafoLinea>();

                                                        if (auxParrafoSecuencia[i]?.Ordenar == "SI2")
                                                            parrafoLineaInternalBuffer = parrafoLineaACodificar.Where(x => x.Grupo == strGrupo && x.Agrupador != "SI" && (!hayTabs || x.Tab == strTab) && (!hayGridsInTab || x.Grid == strGrid)).OrderBy(x => x.Orden2).ToList();
                                                        else
                                                            parrafoLineaInternalBuffer = parrafoLineaACodificar.Where(x => x.Grupo == strGrupo && x.Agrupador != "SI" && (!hayTabs || x.Tab == strTab) && (!hayGridsInTab || x.Grid == strGrid)).OrderBy(x => x.Orden).ToList();

                                                        parrafoLineaBuffer.AddRange(parrafoLineaInternalBuffer);


                                                        if (parrafoFinMolde != null && strGrid == "")
                                                            parrafoLineaBuffer.Add(FormatearCabeceraGrupo(parrafoFinMolde, strGrupo)!);
                                                    }


                                                    if (parrafoGridFinMolde != null && ((strGrid != null && strGrid.Length > 0) || parrafoGridInicioMolde?.Agrupador_siempre == "SI"))
                                                        parrafoLineaBuffer.Add(FormatearCabeceraGrid(parrafoGridFinMolde, strGrid, dr["Name"].ToString() ?? "")!);

                                                }

                                                if (parrafoTabFinMolde != null && strTab != null && strTab.Length > 0)
                                                    parrafoLineaBuffer.Add(FormatearCabeceraTab(parrafoTabFinMolde, strTab)!);


                                            }

                                            if (hayTabs && parrafoTabcFinMolde != null)
                                                parrafoLineaBuffer.Add(FormatearCabeceraTab(parrafoTabcFinMolde, "")!);

                                            parrafoLineaACodificar = parrafoLineaBuffer;
                                        }
                                        else
                                        {

                                            if (auxParrafoSecuencia[i]?.Ordenar == "SI2")
                                                parrafoLineaACodificar = parrafoLineaACodificar.OrderBy(x => x.Orden2).ToList();
                                            else
                                                parrafoLineaACodificar = parrafoLineaACodificar.OrderBy(x => x.Orden).ToList();
                                        }



                                    }
                                }

                                string strBufferParrafoCompleto = String.Join("", parrafoLineaACodificar.Select(x => x.Texto));

                                if (strBufferParrafoCompleto.Length - auxParrafoSecuencia[i]?.QuitarChrFin > 0)
                                    strBufferParrafoCompleto = strBufferParrafoCompleto.Substring(0, strBufferParrafoCompleto.Length - auxParrafoSecuencia[i]!.QuitarChrFin);



                                stringPrimerArch += strBufferParrafoCompleto;
                                parrafoLineaACodificar = new List<ParrafoLinea>();
                            }

                            if ((string.IsNullOrEmpty(auxPrefijosNecesarios[plantillas]?.ToString()) | (quitaAcentos(dr["Name"].ToString())  ?? "").Contains(auxPrefijosNecesarios[plantillas]!.ToString()!)))
                            {
                                //string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(plantillas);
                                //string fileNameExtension = Path.GetExtension(plantillas);
                                //string[] fileNameToSaveSplit = fileNameWithoutExtension.Split(new string[] { "---" }, StringSplitOptions.None);

                                //string fileNameToSave = fileNameToSaveSplit[0];

                                //fileNameToSave = fileNameToSave.Replace("__nombreTabla__", mayusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString())));
                                //fileNameToSave = fileNameToSave.Replace("__nombreTablaGuionizado__", minusculaPrimeraLetra(dr["NameHyphenized"].ToString()));

                                //fileNameToSave = fileNameToSave  + fileNameExtension;



                                //string customSubFolder = "/" + dr["Folder"].ToString().Replace("(nombreEsquema)", dr["Schema_"].ToString()).Replace("(nombreTabla)", dr["Name"].ToString()).Replace("(nombreTablaParent)", dr["NameParent"].ToString());
                                //string folderDestino = auxFolders[plantillas].ToString().Replace("(nombreTablaMinPrimeraLetra)", minusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString()))) + customSubFolder;


                                string folderDestino = "";
                                string fileNameToSave = "";
                                string archivo = obtenerNombreArchivoPorPlantillaTabla(plantillas, dr, auxFolders, out folderDestino, out fileNameToSave);

                                if (!Directory.Exists(folderDestino))
                                    System.IO.Directory.CreateDirectory(folderDestino);


                                guardarArchivo(/*folderDestino + "\\" + fileNameToSave*/archivo, stringPrimerArch);


                                ImplConf? conf = obtenerImplConfPorPlantillaTabla(confArray, plantillas, dr, auxFolders);
                                if (conf != null)
                                    realImplConf.Add(conf);

                                ImplConfMisc? confMisc = obtenerImplConfMiscPorPlantillaTabla(confMiscleneaList, plantillas, dr, auxFolders);
                                if (confMisc != null)
                                    realConfMiscleneaList.Add(confMisc);

                            }
                        }
                    }
                }

            }




            foreach (string plantillas_loopVariable in auxFilesConcentrado)
            {
                plantillas = plantillas_loopVariable;

                if ((plantillas != null))
                {

                    this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Clear();

                    string? myDocumentsFolder = null;
                    myDocumentsFolder = System.AppDomain.CurrentDomain.BaseDirectory + "GENERADOR";
                    LlenarDatosPlantilla(myDocumentsFolder + "\\" + plantillas);


                    int contadorCampos = 0, contadorCamposAplicado = 0;

                    string stringPrimerArch = "";

                    string[] auxSecuencia = new string[this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count + 1];
                    int[] auxQuitarChrFin = new int[this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count + 1];

                    int i = 0;
                    for (i = 0; i <= this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count; i++)
                    {
                        auxSecuencia[i] = "";
                    }

                    int contadorParrafosPlantilla = 0;



                    foreach (DataRow drRegInt in this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows)
                    {



                        contadorCampos = 0;
                        contadorCamposAplicado = 0;

                        foreach (DataRow dr in this.DataSetSchema1.Tables["UserTables"]!.Rows)
                        {
                            if ((dr["cb"].ToString() == "1") &
                                    (Array.IndexOf(drRegInt["TIPOARCHIVO"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr["Tipo"].ToString()!.ToUpper()) != -1 | drRegInt["TIPOARCHIVO"].ToString()!.ToUpper() == "IGNORAR") &
                                    (Array.IndexOf(drRegInt["TIPOARCHIVODIFERENTE"].ToString()!.ToUpper().Split(new string[] { "," }, StringSplitOptions.None), dr["Tipo"].ToString()!.ToUpper()) == -1 | drRegInt["TIPOARCHIVODIFERENTE"].ToString()!.ToUpper() == "IGNORAR"))
                            {

                                contadorCampos++;
                                try
                                {
                                    if ((!string.IsNullOrEmpty(drRegInt["QUITARCHR_FINAL"].ToString())))
                                    {
                                        auxQuitarChrFin[contadorParrafosPlantilla] = int.Parse(drRegInt["QUITARCHR_FINAL"].ToString()!);
                                    }
                                    else
                                    {
                                        auxQuitarChrFin[contadorParrafosPlantilla] = 0;
                                    }

                                }
                                catch
                                {
                                    auxQuitarChrFin[contadorParrafosPlantilla] = 0;
                                }





                                if ((
                                (double.Parse(drRegInt["TIPOREPETICION"].ToString()!) == 3 | contadorCampos == 1)

                                ))
                                {



                                    string auxStr = drRegInt["TEXTO"].ToString()!;


                                    auxStr = auxStr.Replace("(nombreEsquema)", minusculaPrimeraLetra(quitaAcentos(dr["Schema_"].ToString())));
                                    auxStr = auxStr.Replace("(nombreTabla)", mayusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString())));
                                    auxStr = auxStr.Replace("(nombreTablaGuionizado)", minusculaPrimeraLetra(dr["NameHyphenized"].ToString()));
                                    auxStr = auxStr.Replace("(nombreTablaTitle)", mayusculaPrimeraLetra(dr["Title"].ToString()));
                                    auxStr = auxStr.Replace("(nombreTablaReal)", dr["NameRealTable"].ToString());
                                    auxStr = auxStr.Replace("(nombreTablaMinPrimeraLetra)", minusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString())));

                                    auxStr = auxStr.Replace("(nombreTablaSinNormalizar)", dr["Name"].ToString());
                                    auxStr = auxStr.Replace("(nombreTablaSinPrefijoCtrl)", dr["Name"].ToString()!.Replace("CtlPers__", ""));
                                    auxStr = auxStr.Replace("(nombreSistema)", nombreSistema);
                                    auxStr = auxStr.Replace("(consecutivo)", contadorCampos.ToString());
                                    auxStr = auxStr.Replace("(consecutivoAplicado)", contadorCamposAplicado.ToString());
                                    int auxConsecutivo30 = (contadorCampos * 30) + 20;

                                    auxSecuencia[contadorParrafosPlantilla] += auxStr;



                                    contadorCamposAplicado++;
                                }
                            }
                        }


                        contadorParrafosPlantilla += 1;



                    }

                    for (int y = 0; y <= this.ExcelWebCustomCtrls1.Tables["Hoja1"]!.Rows.Count; y++)
                    {
                        if (auxSecuencia[y].Length - auxQuitarChrFin[y] > 0)
                            auxSecuencia[y] = auxSecuencia[y].Substring(0, auxSecuencia[y].Length - auxQuitarChrFin[y]);

                        stringPrimerArch += auxSecuencia[y];
                    }



                    //if ((string.IsNullOrEmpty(auxPrefijosNecesarios[plantillas].ToString()) | quitaAcentos(dr["Name"].ToString()).Contains(auxPrefijosNecesarios[plantillas].ToString())))
                    //{
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(plantillas);
                    string fileNameExtension = Path.GetExtension(plantillas);
                    // string[] auxFileNameArch = plantillas.Split(new string[] { "." }, StringSplitOptions.None);
                    string[] fileNameToSaveSplit = fileNameWithoutExtension.Split(new string[] { "---" }, StringSplitOptions.None);

                    string fileNameToSave = fileNameToSaveSplit[0];

                    fileNameToSave = fileNameToSave + fileNameExtension;


                    string folderDestino = auxFoldersConcentrado[plantillas]!.ToString()!;

                    if (!Directory.Exists(folderDestino))
                        System.IO.Directory.CreateDirectory(folderDestino);


                    guardarArchivo(folderDestino + "\\" + fileNameToSave, stringPrimerArch);
                    //}

                }
            }



            // segunda vuelta
            string bufferFolderStr = "";
            string bufferFileNameStr = "";
            foreach (string plantillas_loopVariable in auxFiles)
            {

                if ((modoGenerador == "migracion" && !plantillasModoMigracion.Contains(plantillas_loopVariable) && !plantillasModoComun.Contains(plantillas_loopVariable)) ||
                    (modoGenerador == "parametroscontroladores" && !plantillasModoParametrosControladores.Contains(plantillas_loopVariable)) ||
                    (modoGenerador == "controladores" && !plantillasModoControladores.Contains(plantillas_loopVariable)) ||
                    (modoGenerador != "migracion" && plantillasModoMigracion.Contains(plantillas_loopVariable)))
                    continue;


                plantillas = plantillas_loopVariable;


                foreach (DataRow dr in this.DataSetSchema1.Tables["UserTables"]!.Rows)
                {
                    if (!auxTipoFiles[plantillas]!.ToString()!.Split(',').Contains(dr["Tipo"].ToString()))
                        continue;

                    if ((dr["cb"].ToString() != "1"))
                        continue;


                    if (modoGenerador == "migracion" && this.IgnorarFormEnMigracion(dr["Name"].ToString()))
                        continue;

                    if ((string.IsNullOrEmpty(auxPrefijosNecesarios[plantillas]!.ToString()) | (quitaAcentos(dr["Name"].ToString()) ?? "").Contains(auxPrefijosNecesarios[plantillas]!.ToString()!)))
                    {
                        string archivo = obtenerNombreArchivoPorPlantillaTabla(plantillas, dr, auxFolders, out bufferFolderStr, out bufferFileNameStr);

                        string contentFileToCheck = File.ReadAllText(archivo);


                        foreach (string plantillas_intern in auxFiles)
                        {
                            if (contentFileToCheck.Contains("(" + plantillas_intern + ")"))
                            {
                                // ...
                                string strContentToChange = "";
                                foreach (DataRow drintern in this.DataSetSchema1.Tables["UserTables"]!.Rows)
                                {
                                    try
                                    {
                                        if (drintern["NameParent"].ToString() == dr["Name"].ToString() &&
                                           drintern["Name"].ToString() != dr["Name"].ToString())
                                        {

                                            string archivoParte = obtenerNombreArchivoPorPlantillaTabla(plantillas_intern, drintern, auxFolders, out bufferFolderStr, out bufferFileNameStr);
                                            strContentToChange += File.ReadAllText(archivoParte);
                                        }
                                    }
                                    catch { continue; }
                                }

                                contentFileToCheck = contentFileToCheck.Replace("(" + plantillas_intern + ")", strContentToChange);
                            }

                        }

                        guardarArchivo(archivo, contentFileToCheck);



                    }

                }
            }

            //bool createXlsPruebasUnitarias = fuente == "BD" ? CBPruebasUnitariasBD.Checked : (fuente == "EXCEL" ? CBPruebasUnitariasXLS.Checked : CBPruebasUnitariasAdapter.Checked);
            //string rutaExcel = fuente == "BD" ? TBPruebasUnitariasBD.Text : (fuente == "EXCEL" ? TBPruebasUnitariasXLS.Text : TBPruebasUnitariasAdapter.Text);

            //if (createXlsPruebasUnitarias)
            //    generarExcelesPruebasUnitarias(fuente, rutaExcel, auxFiles, auxFolders);

            MessageBox.Show("Se ha generado el codigo ");


            //ImplementacionForm implForm = new ImplementacionForm(realImplConf, realConfMiscleneaList);
            //implForm.Show();

        }


        private string obtenerNombreArchivoPorPlantillaTabla(string plantillas, DataRow dr, Hashtable auxFolders, out string folderDestino, out string fileNameToSave)
        {

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(plantillas);
            string fileNameExtension = Path.GetExtension(plantillas);
            string[] fileNameToSaveSplit = fileNameWithoutExtension.Split(new string[] { "---" }, StringSplitOptions.None);

            //string 
            fileNameToSave = fileNameToSaveSplit[0];

            fileNameToSave = fileNameToSave.Replace("__nombreTabla__", mayusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString())));
            fileNameToSave = fileNameToSave.Replace("__nombreTablaGuionizado__", minusculaPrimeraLetra(dr["NameHyphenized"].ToString()));

            fileNameToSave = fileNameToSave + fileNameExtension;



            string customSubFolder = "/" + dr["Folder"].ToString()!.Replace("(nombreEsquema)", dr["Schema_"].ToString()).Replace("(nombreTabla)", dr["Name"].ToString()).Replace("(nombreTablaParent)", dr["NameParent"].ToString());
            folderDestino = auxFolders[plantillas]!.ToString()!.Replace("(nombreTablaMinPrimeraLetra)", minusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString()))) + customSubFolder;
            string archivo = folderDestino + "\\" + fileNameToSave;
            return archivo;
        }



        private ImplConf? obtenerImplConfPorPlantillaTabla(Hashtable confArray, string plantillas, DataRow dr, Hashtable auxFolders)
        {



            ImplConf? baseConf = (ImplConf?)confArray[plantillas];

            if (baseConf == null || !baseConf.DefaultAparecerComoOpcion)
                return null;

            string folderFuente = "";
            string fileNameToSave = "";
            string archivoBuffer = obtenerNombreArchivoPorPlantillaTabla(plantillas, dr, auxFolders, out folderFuente, out fileNameToSave);

            string customSubFolderReal = "/" + dr["Folder"].ToString()!.Replace("(nombreEsquema)", dr["Schema_"].ToString()).Replace("(nombreTabla)", dr["Name"].ToString()).Replace("(nombreTablaParent)", dr["NameParent"].ToString());
            string folderDestinoReal = baseConf.RutaProyecto!.ToString().Replace("(nombreTablaMinPrimeraLetra)", minusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString()!))) + customSubFolderReal;

            string folderDestinoRelativo = baseConf!.RutaRelativa!.ToString().Replace("(nombreTablaMinPrimeraLetra)", minusculaPrimeraLetra(quitaAcentos(dr["Name"].ToString()!))) + customSubFolderReal;


            ImplConf retorno = new ImplConf();

            retorno.Tabla = dr["Name"].ToString()!;
            retorno.Projecto = baseConf.Projecto?.Replace("/", "\\");
            retorno.RutaBuffer = archivoBuffer.Replace("/", "\\");
            retorno.RutaProyecto = (folderDestinoReal + "\\" + fileNameToSave).Replace("/", "\\");
            retorno.RutaRelativa = (folderDestinoRelativo + "\\" + fileNameToSave).Replace("/", "\\");
            retorno.RutaRelativa = retorno.RutaRelativa.StartsWith("\\") ? retorno.RutaRelativa.Substring(1, retorno.RutaRelativa.Length - 1) : retorno.RutaRelativa;
            retorno.DefaultInsertarSiNoExiste = baseConf.DefaultInsertarSiNoExiste;
            retorno.DefaultSobreEscribirSiExiste = baseConf.DefaultSobreEscribirSiExiste;
            retorno.DefaultAparecerComoOpcion = baseConf.DefaultAparecerComoOpcion;
            retorno.Section = baseConf.Section;

            return retorno;


        }



        private ImplConfMisc? obtenerImplConfMiscPorPlantillaTabla(List<ImplConfMisc> confMiscleneaList, string plantillas, DataRow dr, Hashtable auxFolders)
        {



            ImplConfMisc? baseConf = confMiscleneaList.Where(y => y.ArchivoMiscelanea == plantillas).FirstOrDefault();

            if (baseConf == null)
                return null;

            string folderFuente = "";
            string fileNameToSave = "";
            string archivoMiscelanea = obtenerNombreArchivoPorPlantillaTabla(plantillas, dr, auxFolders, out folderFuente, out fileNameToSave);


            string folderFuenteRelacionado = "";
            string fileNameToSaveRelacionado = "";
            string archivoRelacionado = obtenerNombreArchivoPorPlantillaTabla(baseConf!.ArchivoRelacionado!, dr, auxFolders, out folderFuenteRelacionado, out fileNameToSaveRelacionado);




            ImplConfMisc retorno = new ImplConfMisc();

            retorno.ArchivoMiscelanea = archivoMiscelanea.Replace("/", "\\");
            retorno.ArchivoRelacionado = archivoRelacionado.Replace("/", "\\");
            retorno.ArchivoDestino = baseConf?.ArchivoDestino?.Replace("/", "\\");
            retorno.TextoUbicacion = baseConf?.TextoUbicacion;

            return retorno;


        }

        private ParrafoLinea? FormatearCabeceraGrupo(ParrafoLinea parrafoLinea, string grupo)
        {
            var grupoDef = grupo.Split('|');
            var grupoId = grupoDef[0];
            var grupoNombre = grupoDef.Length > 1 ? grupoDef[1] : "";
            var grupoAncho = grupoDef.Length > 2 ? grupoDef[2] : "12";

            var retorno = new ParrafoLinea(parrafoLinea);

            if(retorno != null && retorno.Texto != null)
                retorno.Texto = retorno.Texto.Replace("(nombreGrupo)", grupoNombre).Replace("(anchoGrupo)", grupoAncho);

            return retorno;
        }

        private ParrafoLinea? FormatearCabeceraTab(ParrafoLinea parrafoLinea, string tab)
        {

            var retorno = new ParrafoLinea(parrafoLinea);

            if(retorno != null && retorno.Texto != null)
                retorno.Texto = retorno.Texto.Replace("(nombreTab)", tab);

            return retorno;
        }


        private ParrafoLinea? FormatearCabeceraGrid(ParrafoLinea parrafoLinea, string? grid, string tabla)
        {

            var retorno = new ParrafoLinea(parrafoLinea);


            if (retorno != null && retorno.Texto != null)
            {
                retorno.Texto = retorno.Texto.Replace("(nombreGrid)", grid);
                retorno.Texto = retorno.Texto.Replace("(nombreGridOTabla)", grid != null && grid != "" ? grid : tabla);
            }
            
            return retorno;
        }




        public string obtenerContenidoArchivo(string fileName)
        {
            string retorno = "";
            StreamReader r = File.OpenText(fileName);
            string? line = null;
            line = r.ReadLine();
            while ((line != null))
            {
                retorno += line + System.Environment.NewLine; // Microsoft.VisualBasic.Constants.vbNewLine;
                line = r.ReadLine();
            }
            r.Close();
            return retorno;

        }

        public void guardarArchivo(string fileName, string contenido)
        {
            StreamWriter sw = new StreamWriter(fileName);
            // Add some text to the file.
            sw.Write(contenido);

            sw.Close();
        }

        public string equivalenciasTipo(string tipoEnBase, string subTipo)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "bool");
            list_eq.Add("SMALLINT", "short");
            list_eq.Add("INTEGER", "int");
            list_eq.Add("BIGINT", "long");
            list_eq.Add("REAL", "float");
            list_eq.Add("DOUBLE PRECISION", "double");
            list_eq.Add("NUMERIC", "decimal");
            list_eq.Add("MONEY", "decimal");
            list_eq.Add("TEXT", "string");
            list_eq.Add("CHAR", "string");
            list_eq.Add("VARCHAR", "string");
            list_eq.Add("CITEXT", "string");
            list_eq.Add("JSON", "string");
            list_eq.Add("JSONB", "string");
            list_eq.Add("XML", "string");
            list_eq.Add("POINT", "NpgsqlPoint");
            list_eq.Add("LSEG", "NpgsqlLSeg");
            list_eq.Add("PATH", "NpgsqlPath");
            list_eq.Add("POLYGON", "NpgsqlPolygon");
            list_eq.Add("LINE", "NpgsqlLine");
            list_eq.Add("CIRCLE", "NpgsqlCircle");
            list_eq.Add("BOX", "NpgsqlBox");
            list_eq.Add("BIT", "bool");
            list_eq.Add("BIT VARYING", "bool");
            list_eq.Add("UUID", "Guid");
            list_eq.Add("MACADDR", "PhysicalAddress");
            list_eq.Add("TSQUERY", "NpgsqlTsQuery");
            list_eq.Add("TSVECTOR", "NpgsqlTsVector");
            list_eq.Add("DATE", "DateTime");
            list_eq.Add("INTERVAL", "string");
            list_eq.Add("TIMESTAMP", "DateTime");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "string");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "DateTime");
            list_eq.Add("TIME", "DateTime");
            list_eq.Add("TIME WITH TIME ZONE", "string");
            list_eq.Add("BYTEA", "byte[]");
            list_eq.Add("OID", "uint");
            list_eq.Add("XID", "uint");
            list_eq.Add("CID", "uint");
            list_eq.Add("OIDVECTOR", "uint[]");
            list_eq.Add("NAME", "string");
            list_eq.Add("(INTERNAL) CHAR", "byte");


            Hashtable list_eq_subtypes = new Hashtable();
            list_eq_subtypes.Add("BOOLCN", "BoolCN");
            list_eq_subtypes.Add("BOOLCNI", "BoolCNI");
            list_eq_subtypes.Add("BOOLCS", "BoolCS");
            list_eq_subtypes.Add("DATETIMEOFFSET", "DateTimeOffset");
            list_eq_subtypes.Add("LETRAENTICKET", "LetraEnTicket");
            list_eq_subtypes.Add("FORMATTICKETCORTO", "FormatTicketCorto");
            list_eq_subtypes.Add("ORDENIMPRESION", "OrdenImpresion ");
            list_eq_subtypes.Add("FORMATOFACTURA", "FormatoFactura");
            list_eq_subtypes.Add("FILTROPRODUCTOSAT", "FiltroProductoSat");
            list_eq_subtypes.Add("MODOALERTAPV", "ModoAlertaPV ");
            list_eq_subtypes.Add("CONFIGPANTALLA", "ConfigPantalla");
            list_eq_subtypes.Add("TIPOSYNCMOVIL", "TipoSyncMovil");
            list_eq_subtypes.Add("TIPOCONEXIONMOVIL", "TipoConexionMovil");
            list_eq_subtypes.Add("BOOLMANEJORECETA", "BoolManejoReceta");







            if (list_eq_subtypes.ContainsKey(subTipo.ToUpper()))
            {
                return list_eq_subtypes[subTipo.ToUpper()]?.ToString() ?? "string";
            }


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "string";
            }
            else
            {
                return "string";
            }


        }


        public string? ForeignKeyToStr(string? foreignKey, string? nombreTabla)
        {

            string? foreignKeyStr = foreignKey;

            if (nombreTabla != null && nombreTabla.ToLower().StartsWith("cliente") && foreignKey == "None")
                foreignKeyStr = "clienteid";

            return foreignKeyStr;

        }


        public string? NombreCampoCall(string? campo, string? foreignKey, string? nombreTabla)
        {
            if (campo == null)
                return null;

            if (foreignKey != null && foreignKey.ToLower().Equals(campo))
                return "p_id";


            switch ( campo.ToLower())
            {
                case "creado":
                case "modificado":
                    return "cast(current_timestamp as public.d_timestamp)";
                default:
                    return "p_" + campo.ToLower();
            }

        }


        public string? NombreCampoCallInsert(string? campo, string? foreignKey, string? nombreTabla)
        {
            if (campo == null)
                return null;

            if (campo.ToLower() == "id")
            {
                return "cast(0 as d_id)";
            }
            return NombreCampoCall(campo, foreignKey, nombreTabla);
        }


        public string? NombreCampoCallUpdate(string? campo, string? foreignKey, string? nombreTabla)
        {
            if (campo == null)
                return null;

            if (campo.ToLower() == "id")
            {
                return "_bufferid";
            }
            return NombreCampoCall(campo, foreignKey, nombreTabla);
        }


        public string equivalenciasTipoForms(string tipoEnBase)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "Boolean");
            list_eq.Add("SMALLINT", "Int16");
            list_eq.Add("INTEGER", "Int32");
            list_eq.Add("BIGINT", "Int64");
            list_eq.Add("REAL", "double");
            list_eq.Add("DOUBLE PRECISION", "double");
            list_eq.Add("NUMERIC", "decimal");
            list_eq.Add("MONEY", "decimal");
            list_eq.Add("TEXT", "String");
            list_eq.Add("CHAR", "String");
            list_eq.Add("VARCHAR", "String");
            list_eq.Add("CITEXT", "String");
            list_eq.Add("JSON", "String");
            list_eq.Add("JSONB", "String");
            list_eq.Add("XML", "String");
            list_eq.Add("POINT", "NpgsqlPoint");
            list_eq.Add("LSEG", "NpgsqlLSeg");
            list_eq.Add("PATH", "NpgsqlPath");
            list_eq.Add("POLYGON", "NpgsqlPolygon");
            list_eq.Add("LINE", "NpgsqlLine");
            list_eq.Add("CIRCLE", "NpgsqlCircle");
            list_eq.Add("BOX", "NpgsqlBox");
            list_eq.Add("BIT", "Boolean");
            list_eq.Add("BIT VARYING", "Boolean");
            list_eq.Add("UUID", "Guid");
            list_eq.Add("MACADDR", "PhysicalAddress");
            list_eq.Add("TSQUERY", "NpgsqlTsQuery");
            list_eq.Add("TSVECTOR", "NpgsqlTsVector");
            list_eq.Add("DATE", "DateTime");
            list_eq.Add("INTERVAL", "String");
            list_eq.Add("TIMESTAMP", "DateTime");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "String");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "DateTime");
            list_eq.Add("TIME", "DateTime");
            list_eq.Add("TIME WITH TIME ZONE", "String");
            list_eq.Add("BYTEA", "byte[]");
            list_eq.Add("OID", "uint");
            list_eq.Add("XID", "uint");
            list_eq.Add("CID", "uint");
            list_eq.Add("OIDVECTOR", "uint[]");
            list_eq.Add("NAME", "string");
            list_eq.Add("(INTERNAL) CHAR", "byte");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "String";
            }
            else
            {
                return "String";
            }


        }



        public string equivalenciasTipoAngular(string tipoEnBase)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "boolean");
            list_eq.Add("SMALLINT", "number");
            list_eq.Add("INTEGER", "number");
            list_eq.Add("BIGINT", "number");
            list_eq.Add("REAL", "number");
            list_eq.Add("DOUBLE PRECISION", "number");
            list_eq.Add("NUMERIC", "number");
            list_eq.Add("MONEY", "number");
            list_eq.Add("TEXT", "string");
            list_eq.Add("CHAR", "string");
            list_eq.Add("VARCHAR", "string");
            list_eq.Add("CITEXT", "string");
            list_eq.Add("JSON", "string");
            list_eq.Add("JSONB", "string");
            list_eq.Add("XML", "string");
            list_eq.Add("POINT", "any");
            list_eq.Add("LSEG", "any");
            list_eq.Add("PATH", "any");
            list_eq.Add("POLYGON", "any");
            list_eq.Add("LINE", "any");
            list_eq.Add("CIRCLE", "any");
            list_eq.Add("BOX", "any");
            list_eq.Add("BIT", "boolean");
            list_eq.Add("BIT VARYING", "boolean");
            list_eq.Add("UUID", "string");
            list_eq.Add("MACADDR", "any");
            list_eq.Add("TSQUERY", "any");
            list_eq.Add("TSVECTOR", "any");
            list_eq.Add("DATE", "string");
            list_eq.Add("INTERVAL", "string");
            list_eq.Add("TIMESTAMP", "string");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "string");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "string");
            list_eq.Add("TIME", "string");
            list_eq.Add("TIME WITH TIME ZONE", "string");
            list_eq.Add("BYTEA", "number[]");
            list_eq.Add("OID", "number");
            list_eq.Add("XID", "number");
            list_eq.Add("CID", "number");
            list_eq.Add("OIDVECTOR", "number[]");
            list_eq.Add("NAME", "string");
            list_eq.Add("(INTERNAL) CHAR", "number");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "string";
            }
            else
            {
                return "string";
            }


        }


        public string equivalenciasTipoJsonSquema(string tipoEnBase)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "boolean");
            list_eq.Add("SMALLINT", "number");
            list_eq.Add("INTEGER", "number");
            list_eq.Add("BIGINT", "number");
            list_eq.Add("REAL", "number");
            list_eq.Add("DOUBLE PRECISION", "number");
            list_eq.Add("NUMERIC", "number");
            list_eq.Add("MONEY", "number");
            list_eq.Add("TEXT", "string");
            list_eq.Add("CHAR", "string");
            list_eq.Add("VARCHAR", "string");
            list_eq.Add("CITEXT", "string");
            list_eq.Add("JSON", "string");
            list_eq.Add("JSONB", "string");
            list_eq.Add("XML", "string");
            list_eq.Add("POINT", "any");
            list_eq.Add("LSEG", "any");
            list_eq.Add("PATH", "any");
            list_eq.Add("POLYGON", "any");
            list_eq.Add("LINE", "any");
            list_eq.Add("CIRCLE", "any");
            list_eq.Add("BOX", "any");
            list_eq.Add("BIT", "boolean");
            list_eq.Add("BIT VARYING", "boolean");
            list_eq.Add("UUID", "string");
            list_eq.Add("MACADDR", "any");
            list_eq.Add("TSQUERY", "any");
            list_eq.Add("TSVECTOR", "any");
            list_eq.Add("DATE", "date");
            list_eq.Add("INTERVAL", "time");
            list_eq.Add("TIMESTAMP", "time");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "time");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "time");
            list_eq.Add("TIME", "time");
            list_eq.Add("TIME WITH TIME ZONE", "time");
            list_eq.Add("BYTEA", "number[]");
            list_eq.Add("OID", "number");
            list_eq.Add("XID", "number");
            list_eq.Add("CID", "number");
            list_eq.Add("OIDVECTOR", "number[]");
            list_eq.Add("NAME", "string");
            list_eq.Add("(INTERNAL) CHAR", "number");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "string";
            }
            else
            {
                return "string";
            }


        }





        public string equivalenciasTipoConExcel(string tipoEnBase)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "BOOLEAN");
            list_eq.Add("SMALLINT", "INTEGER");
            list_eq.Add("INTEGER", "INTEGER");
            list_eq.Add("BIGINT", "INTEGER");
            list_eq.Add("REAL", "NUMERIC");
            list_eq.Add("DOUBLE PRECISION", "NUMERIC");
            list_eq.Add("NUMERIC", "NUMERIC");
            list_eq.Add("MONEY", "NUMERIC");
            list_eq.Add("TEXT", "VARCHAR");
            list_eq.Add("CHAR", "VARCHAR");
            list_eq.Add("VARCHAR", "VARCHAR");
            list_eq.Add("CITEXT", "VARCHAR");
            list_eq.Add("JSON", "VARCHAR");
            list_eq.Add("JSONB", "VARCHAR");
            list_eq.Add("XML", "VARCHAR");
            list_eq.Add("UUID", "VARCHAR");
            list_eq.Add("DATE", "DATETIME");
            list_eq.Add("INTERVAL", "DATETIME");
            list_eq.Add("TIMESTAMP", "DATETIME");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "DATETIME");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "DATETIME");
            list_eq.Add("TIME", "DATETIME");
            list_eq.Add("TIME WITH TIME ZONE", "DATETIME");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "VARCHAR";
            }
            else
            {
                return "VARCHAR";
            }


        }




        public string defaultTestValueParaExcel(string tipoEnBase)
        {
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "true");
            list_eq.Add("SMALLINT", "1");
            list_eq.Add("INTEGER", "1");
            list_eq.Add("BIGINT", "1");
            list_eq.Add("REAL", "1");
            list_eq.Add("DOUBLE PRECISION", "1");
            list_eq.Add("NUMERIC", "1");
            list_eq.Add("MONEY", "1");
            list_eq.Add("TEXT", "'Test'");
            list_eq.Add("CHAR", "'Test'");
            list_eq.Add("VARCHAR", "'Test'");
            list_eq.Add("CITEXT", "'Test'");
            list_eq.Add("JSON", "'Test'");
            list_eq.Add("JSONB", "'Test'");
            list_eq.Add("XML", "'Test'");
            list_eq.Add("UUID", "'Test'");
            list_eq.Add("DATE", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            list_eq.Add("INTERVAL", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            list_eq.Add("TIMESTAMP", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            list_eq.Add("TIME", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            list_eq.Add("TIME WITH TIME ZONE", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                return list_eq[tipoEnBase.ToUpper()]?.ToString() ?? "'Test'";
            }
            else
            {
                return "'Test'";
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


        public string nombreCampoEnRuta(DataRow dr2)
        {

            if (dr2["ESCAMPODECATALOGO"] != DBNull.Value && dr2["ESCAMPODECATALOGO"].ToString() == "YES")
                return mayusculaPrimeraLetra(quitaAcentos(dr2["ENTIDADCATALOGOCAMPO"].ToString()!.Replace("?", ""))) + "." + mayusculaPrimeraLetra(quitaAcentos(dr2["ENTIDADCATALOGOCAMPOREL"].ToString()!.Replace("?","")));


            if (dr2["ESSUBENTIDAD"] != DBNull.Value && dr2["ESSUBENTIDAD"].ToString() == "YES")
                return mayusculaPrimeraLetra(quitaAcentos(dr2["SUBENTIDADCAMPO"].ToString()!.Replace("?", ""))) + "." + mayusculaPrimeraLetra(quitaAcentos(dr2["SUBENTIDADCAMPOREL"].ToString()!.Replace("?", "")));

            return mayusculaPrimeraLetra(quitaAcentos(dr2["COLUMN_NAME"].ToString()!)) ?? "";
        }

        public string? minusculaPrimeraLetra(string? str)
        {
            if (str == null)
                return null;

            Int32 auxlen = str.Length - 1;
            string aux = str.Substring(0, 1).ToLower() + str.Substring(1, auxlen);
            return aux;
        }



        public string? tipificacionEnDBType(string? tipoEnBase, string? subTipo, bool withSize = false)
        {
            if (tipoEnBase == null)
                return null;

            tipoEnBase = tipoEnBase.Trim();
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "Boolean");
            list_eq.Add("SMALLINT", "Smallint");
            list_eq.Add("INTEGER", "Integer");
            list_eq.Add("BIGINT", "Bigint");
            list_eq.Add("REAL", "Real");
            list_eq.Add("DOUBLE PRECISION", "Double");
            list_eq.Add("NUMERIC", "Numeric");
            list_eq.Add("MONEY", "Money");
            list_eq.Add("TEXT", "Text");
            list_eq.Add("CHAR", "Varchar");
            list_eq.Add("VARCHAR", "Char");
            list_eq.Add("CITEXT", "Citext");
            list_eq.Add("JSON", "Json");
            list_eq.Add("JSONB", "Jsonb");
            list_eq.Add("XML", "Xml");
            list_eq.Add("POINT", "Point");
            list_eq.Add("LSEG", "LSeg");
            list_eq.Add("PATH", "Path");
            list_eq.Add("POLYGON", "Polygon");
            list_eq.Add("LINE", "Line");
            list_eq.Add("CIRCLE", "Circle");
            list_eq.Add("BOX", "Box");
            list_eq.Add("BIT", "Bit");
            list_eq.Add("BIT VARYING", "Varbit");
            list_eq.Add("UUID", "Uuid");
            list_eq.Add("MACADDR", "MacAddr");
            list_eq.Add("TSQUERY", "TsQuery");
            list_eq.Add("TSVECTOR", "TsVector");
            list_eq.Add("DATE", "Date");
            list_eq.Add("INTERVAL", "Interval");
            list_eq.Add("TIMESTAMP", "Timestamp");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "TimestampTz");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "Timestamp");
            list_eq.Add("TIME", "Time");
            list_eq.Add("TIME WITH TIME ZONE", "TimeTz");
            list_eq.Add("BYTEA", "Bytea");
            list_eq.Add("OID", "Oid");
            list_eq.Add("XID", "Xid");
            list_eq.Add("CID", "Cid");
            list_eq.Add("OIDVECTOR", "Oidvector");
            list_eq.Add("NAME", "Name");
            list_eq.Add("(INTERNAL) CHAR", "InternalChar");


            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                if (withSize == true & ((list_eq[tipoEnBase.ToUpper()]?.ToString()) == "Decimal" | ((list_eq[tipoEnBase.ToUpper()]?.ToString())) == "Numeric"))
                {
                    return (list_eq[tipoEnBase.ToUpper()]!.ToString()!);
                    // & subTipo
                }
                else if (withSize == true & ((list_eq[tipoEnBase.ToUpper()]?.ToString())) == "Double")
                {
                    return "Double precision";
                }
                else
                {
                    return (list_eq[tipoEnBase.ToUpper()]!.ToString()!);
                }

            }
            else
            {
                return "Varchar";
            }

        }


        public string? tipificacionEnBaseODominio(string? tipoEnBase, string? subTipo, string? dominio, bool withSize = false)
        {
            if (dominio == null || dominio.Equals(""))
                return tipificacionEnBase(tipoEnBase, subTipo, withSize);

            return "public." + dominio;
        }

        public string tipificacionEnBase(string? tipoEnBase, string? subTipo, bool withSize = false)
        {
            if(tipoEnBase == null)
                return "Varchar";

            tipoEnBase = tipoEnBase.Trim();
            Hashtable list_eq = new Hashtable();
            list_eq.Add("BOOLEAN", "Boolean");
            list_eq.Add("SMALLINT", "Smallint");
            list_eq.Add("INTEGER", "Integer");
            list_eq.Add("BIGINT", "Bigint");
            list_eq.Add("REAL", "Float4");
            list_eq.Add("DOUBLE PRECISION", "Float8");
            list_eq.Add("NUMERIC", "Numeric");
            list_eq.Add("MONEY", "Money");
            list_eq.Add("TEXT", "Text");
            list_eq.Add("CHAR", "Varchar");
            list_eq.Add("VARCHAR", "Char");
            list_eq.Add("CITEXT", "Citext");
            list_eq.Add("JSON", "Json");
            list_eq.Add("JSONB", "Jsonb");
            list_eq.Add("XML", "Xml");
            list_eq.Add("POINT", "Point");
            list_eq.Add("LSEG", "LSeg");
            list_eq.Add("PATH", "Path");
            list_eq.Add("POLYGON", "Polygon");
            list_eq.Add("LINE", "Line");
            list_eq.Add("CIRCLE", "Circle");
            list_eq.Add("BOX", "Box");
            list_eq.Add("BIT", "Bit");
            list_eq.Add("BIT VARYING", "Varbit");
            list_eq.Add("UUID", "Uuid");
            list_eq.Add("MACADDR", "MacAddr");
            list_eq.Add("TSQUERY", "TsQuery");
            list_eq.Add("TSVECTOR", "TsVector");
            list_eq.Add("DATE", "Date");
            list_eq.Add("INTERVAL", "Interval");
            list_eq.Add("TIMESTAMP", "Timestamp");
            list_eq.Add("TIMESTAMP WITH TIME ZONE", "TimestampTz");
            list_eq.Add("TIMESTAMP WITHOUT TIME ZONE", "Timestamp");
            list_eq.Add("TIME", "Time");
            list_eq.Add("TIME WITH TIME ZONE", "TimeTz");
            list_eq.Add("BYTEA", "Bytea");
            list_eq.Add("OID", "Oid");
            list_eq.Add("XID", "Xid");
            list_eq.Add("CID", "Cid");
            list_eq.Add("OIDVECTOR", "Oidvector");
            list_eq.Add("NAME", "Name");
            list_eq.Add("(INTERNAL) CHAR", "InternalChar");

            if (list_eq.ContainsKey(tipoEnBase.ToUpper()))
            {
                if (withSize == true & ((list_eq[tipoEnBase.ToUpper()]?.ToString()) == "Decimal" | ((list_eq[tipoEnBase.ToUpper()]?.ToString())) == "Numeric"))
                {
                    return (list_eq[tipoEnBase.ToUpper()]!.ToString()! );
                    // & subTipo
                }
                else if (withSize == true & ((list_eq[tipoEnBase.ToUpper()]?.ToString())) == "Double")
                {
                    return "Double precision";
                }
                else
                {
                    return (list_eq[tipoEnBase.ToUpper()]!.ToString()!);
                }

            }
            else
            {
                return "Varchar";
            }

        }


        public string? quitaAcentos(string? texto)
        {
            string? retorno = null;
            retorno = texto;
            string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ #@-";
            string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC____";
            Int32 v = 0;
            for (v = 0; v <= sinsignos.Length - 1; v++)
            {
                string i = consignos.Substring(v, 1);
                string j = sinsignos.Substring(v, 1);
                retorno = retorno?.Replace(i, j);
            }
            retorno = retorno?.Replace("PK__", "");
            return retorno;
        }



        public Hashtable llenarTableKeys(string excelPath)
        {

            Hashtable retorno = new Hashtable();



            foreach (DataRow dr in this.DataSetSchema1.Tables["UserTables"]!.Rows)
            {

                LlenarDatosColumnas(excelPath, (modoGenerador == "migracion" || modoGenerador == "parametroscontroladores") ? dr["NameHyphenized"].ToString()! : dr["Name"].ToString()!);

                ArrayList AL = new ArrayList();


                foreach (DataRow dr2 in this.DataSetSchema1.Tables["Columnas"]!.Rows)
                {
                    if (dr2["IS_KEY"].ToString() == "SI")
                    {
                        AL.Add(quitaAcentos(dr2["COLUMN_NAME"].ToString()));
                    }
                }
                retorno.Add(quitaAcentos(dr["Name"].ToString()) ?? "", AL);
            }

            return retorno;

        }

        public Hashtable TablasNumKeys(string excelPath)
        {

            Hashtable retorno2 = new Hashtable();



            foreach (DataRow dr in this.DataSetSchema1.Tables["UserTables"]!.Rows)
            {


                LlenarDatosColumnas(excelPath, (modoGenerador == "migracion" || modoGenerador == "parametroscontroladores") ? dr["NameHyphenized"].ToString()! : dr["Name"].ToString()!);


                int aux = 0;

                foreach (DataRow dr2 in this.DataSetSchema1.Tables["Columnas"]!.Rows)
                {
                    if (dr2["IS_KEY"].ToString() == "SI" | dr2["COLUMN_NAME"].ToString()!.ToString().Contains("PK__"))
                    {
                        aux += 1;
                    }
                }
                retorno2.Add(quitaAcentos(dr["Name"].ToString())!, aux);
            }

            return retorno2;

        }

        private void LlenarDatosColumnas(string excelFuente, string tableName)
        {

            this.DataSetSchema1.Tables["columnas"]!.Clear();


            string strNameTableSheet = tableName.Length > 27 ? tableName.Substring(0, 27) : tableName;
            LlenarDatosDeColumnasDesdeExcel(excelFuente, strNameTableSheet);
        }

        private string NullableSign(DataRow dr)
        {
            if (dr["IS_NULLABLE"].ToString() == "YES")
                return "?";

            return "";
        }


        private string NullableAssignment(DataRow dr)
        {
            if (dr["IS_NULLABLE"].ToString() == "NO")
                return "?? " + dr["DEFAULTVALUE"].ToString();

            return "";
        }

        private string NullableValueAssignment(DataRow dr)
        {
            if (dr["IS_NULLABLE"].ToString() == "NO")
                return "(value != null ? value!.Value : " + dr["DEFAULTVALUE"].ToString() + ")";

            return "value";
        }

        private void LlenarDatosDeColumnasDesdeExcel(string excelFuente, string tableName)
        {



            this.DataSetSchema1.Tables["columnas"]!.Clear();

            try
            {

                string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFuente + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
                System.Collections.ArrayList parts = new ArrayList();
                //OleDbParameter auxPar;
                String CmdTxt = @"select * from [" + tableName + "$] ";
                OleDbParameter[] arParms = new OleDbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                OleDbDataReader dr;
                dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);


                List<string> camposCamposCatalogo = new List<string>();

                try
                {


                    while (dr.Read())
                    {

                        columnasRow row = this.DataSetSchema1.columnas.NewcolumnasRow();


                        if (dr["TABLE_NAME"] != System.DBNull.Value)
                        {
                            row.TABLE_NAME = (dr["TABLE_NAME"]).ToString()!.Trim();
                        }

                        if (dr["COLUMN_NAME"] != System.DBNull.Value)
                        {
                            row.COLUMN_NAME = (dr["COLUMN_NAME"]).ToString()!.Trim();
                        }

                        if (dr["COLUMN_DEFAULT"] != System.DBNull.Value)
                        {
                            row.COLUMN_DEFAULT = (dr["COLUMN_DEFAULT"]).ToString()!.Trim();
                        }

                        if (dr["IS_NULLABLE"] != System.DBNull.Value)
                        {
                            row.IS_NULLABLE = (dr["IS_NULLABLE"]).ToString()!.Trim();
                        }

                        if (dr["DATA_TYPE"] != System.DBNull.Value)
                        {
                            row.DATA_TYPE = (dr["DATA_TYPE"]).ToString()!.Trim();
                        }

                        if (dr["IDENTIDAD"] != System.DBNull.Value)
                        {
                            row.IDENTIDAD = (dr["IDENTIDAD"]).ToString()!.Trim();
                        }

                        if (dr["'SIZE'"] != System.DBNull.Value)
                        {
                            row.SIZE = (dr["'SIZE'"]).ToString()!.Trim();
                        }

                        if (dr["COLLATION_NAME"] != System.DBNull.Value)
                        {
                            row.COLLATION_NAME = (dr["COLLATION_NAME"]).ToString()!.Trim();
                        }

                        if (dr["IS_KEY"] != System.DBNull.Value)
                        {
                            row.IS_KEY = (dr["IS_KEY"]).ToString()!.Trim();
                        }

                        if (dr["COLUMN_NAME_KEY"] != System.DBNull.Value)
                        {
                            row.COLUMN_NAME_KEY = (dr["COLUMN_NAME_KEY"]).ToString()!.Trim();
                        }

                        if (dr["TABLE_NAME_KEY"] != System.DBNull.Value)
                        {
                            row.TABLE_NAME_KEY = (dr["TABLE_NAME_KEY"]).ToString()!.Trim();
                        }

                        if (dr["COLUMN_NAME_KEY_TEXT"] != System.DBNull.Value)
                        {
                            row.COLUMN_NAME_KEY_TEXT = (dr["COLUMN_NAME_KEY_TEXT"]).ToString()!.Trim();
                        }

                        if (dr["SUBTIPO"] != System.DBNull.Value)
                        {
                            row.SUBTIPO = (dr["SUBTIPO"]).ToString()!.Trim();
                        }

                        if (row["SUBTIPO"] == DBNull.Value || row.SUBTIPO == null || row.SUBTIPO.Length == 0)
                        {
                            if (row.COLUMN_NAME.ToLower().StartsWith("empresaid") || row.COLUMN_NAME.ToLower().StartsWith("sucursalid") || 
                                row.COLUMN_NAME.ToLower().StartsWith("creado") || row.COLUMN_NAME.ToLower().StartsWith("modificado") ||
                                row.COLUMN_NAME.ToLower().StartsWith("creadoporid") || row.COLUMN_NAME.ToLower().StartsWith("modificadoporid") ||
                                row.COLUMN_NAME.ToLower().StartsWith("p_empresaid") || row.COLUMN_NAME.ToLower().StartsWith("p_sucursalid"))
                            {
                                row.SUBTIPO = "ESBASE";
                            }
                            else
                            {
                                row.SUBTIPO = "";
                            }
                        }


                        if (dr["ESCALCULADO"] != System.DBNull.Value)
                        {
                            row.ESCALCULADO = (dr["ESCALCULADO"]).ToString()!.Trim();
                        }

                        if (dr["ESCOMBO"] != System.DBNull.Value)
                        {
                            row.ESCOMBO = (dr["ESCOMBO"]).ToString()!.Trim();
                        }

                        if (dr["ENLISTA"] != System.DBNull.Value)
                        {
                            row.ENLISTA = (dr["ENLISTA"]).ToString()!.Trim();
                        }

                        if (dr["ENEDICION"] != System.DBNull.Value)
                        {
                            row.ENEDICION = (dr["ENEDICION"]).ToString()!.Trim();
                        }

                        if (dr["DOMAIN_NAME"] != System.DBNull.Value)
                        {
                            row.DOMAIN_NAME = (dr["DOMAIN_NAME"]).ToString()!.Trim();
                        }

                        if (dr["TABLE_SCHEMA"] != System.DBNull.Value)
                        {
                            row.TABLE_SCHEMA = (dr["TABLE_SCHEMA"]).ToString()!.Trim();
                        }


                        if (dr["ORDEN"] != System.DBNull.Value)
                        {
                            row.ORDEN = (dr["ORDEN"]).ToString()!.Trim();
                        }


                        if (dr["ENUPDATE"] != System.DBNull.Value)
                        {
                            row.ENUPDATE = (dr["ENUPDATE"]).ToString()!.Trim();
                        }

                        if (dr["ENINSERT"] != System.DBNull.Value)
                        {
                            row.ENINSERT = (dr["ENINSERT"]).ToString()!.Trim();
                        }

                        if (dr["TIPOCONTROL"] != System.DBNull.Value)
                        {
                            row.TIPOCONTROL = (dr["TIPOCONTROL"]).ToString()!.Trim();
                        }

                        if (dr["CATALOGO"] != System.DBNull.Value)
                        {
                            row.CATALOGO = (dr["CATALOGO"]).ToString()!.Trim();
                        }

                        if (dr["CATALOGOCAMPOCLAVE"] != System.DBNull.Value)
                        {
                            row.CATALOGOCAMPOCLAVE = (dr["CATALOGOCAMPOCLAVE"])!.ToString()!.Trim();
                            camposCamposCatalogo.Add(row.CATALOGOCAMPOCLAVE);
                        }

                        if (dr["CATALOGOCAMPONOMBRE"] != System.DBNull.Value)
                        {
                            row.CATALOGOCAMPONOMBRE = (dr["CATALOGOCAMPONOMBRE"])!.ToString()!.Trim();
                            camposCamposCatalogo.Add(row.CATALOGOCAMPONOMBRE);
                        }

                        if (dr["CATALOGOLISTAVMNAME"] != System.DBNull.Value)
                        {
                            row.CATALOGOLISTAVMNAME = (dr["CATALOGOLISTAVMNAME"])!.ToString()!.Trim();
                        }

                        if (dr["CATALOGOSELECTOBJECTNAME"] != System.DBNull.Value)
                        {
                            row.CATALOGOSELECTOBJECTNAME = (dr["CATALOGOSELECTOBJECTNAME"])!.ToString()!.Trim();
                        }

                        if (dr["CATALOGOSELECTFIELDTNAME"] != System.DBNull.Value)
                        {
                            row.CATALOGOSELECTFIELDTNAME = (dr["CATALOGOSELECTFIELDTNAME"])!.ToString()!.Trim();
                        }

                        if (dr["ORDEN2"] != System.DBNull.Value)
                        {
                            row.ORDEN2 = (dr["ORDEN2"]).ToString()!.Trim();
                        }

                        if (dr["NOMBREENFORM"] != System.DBNull.Value)
                        {
                            row.NOMBREENFORM = (dr["NOMBREENFORM"]).ToString()!.Trim();
                        }


                        if (dr["ANCHOB12"] != System.DBNull.Value)
                        {
                            row.ANCHOB12 = (dr["ANCHOB12"]).ToString()!.Trim();
                        }



                        if (dr["GRUPOFORM"] != System.DBNull.Value)
                        {
                            row.GRUPOFORM = (dr["GRUPOFORM"]).ToString()!.Trim();
                        }

                        if (dr["ENBUSQUEDALISTA"] != System.DBNull.Value)
                        {
                            row.ENBUSQUEDALISTA = (dr["ENBUSQUEDALISTA"]).ToString()!.Trim();
                        }



                        if (dr["ESSUBENTIDAD"] != System.DBNull.Value)
                        {
                            row.ESSUBENTIDAD = (dr["ESSUBENTIDAD"]).ToString()!.Trim();
                        }

                        if (dr["SUBENTIDADTIPO"] != System.DBNull.Value)
                        {
                            row.SUBENTIDADTIPO = (dr["SUBENTIDADTIPO"]).ToString()!.Trim();
                        }

                        if (dr["SUBENTIDADCAMPO"] != System.DBNull.Value)
                        {
                            row.SUBENTIDADCAMPO = (dr["SUBENTIDADCAMPO"]).ToString()!.Trim();
                        }

                        if (dr["SUBENTIDADCAMPOREL"] != System.DBNull.Value)
                        {
                            row.SUBENTIDADCAMPOREL = (dr["SUBENTIDADCAMPOREL"]).ToString()!.Trim();
                        }

                        if (dr["DEFAULTVALUE"] != System.DBNull.Value)
                        {
                            row.DEFAULTVALUE = (dr["DEFAULTVALUE"]).ToString()!.Trim();
                        }

                        if (dr["ESCAMPODECATALOGO"] != System.DBNull.Value)
                        {
                            row.ESCAMPODECATALOGO = (dr["ESCAMPODECATALOGO"]).ToString()!.Trim();
                        }

                        if (dr["ENTIDADCATALOGO"] != System.DBNull.Value)
                        {
                            row.ENTIDADCATALOGO = (dr["ENTIDADCATALOGO"]).ToString()!.Trim();
                        }


                        if (dr["ENTIDADCATALOGOCAMPO"] != System.DBNull.Value)
                        {
                            row.ENTIDADCATALOGOCAMPO = (dr["ENTIDADCATALOGOCAMPO"]).ToString()!.Trim();
                        }


                        if (dr["ENTIDADCATALOGOCAMPOREL"] != System.DBNull.Value)
                        {
                            row.ENTIDADCATALOGOCAMPOREL = (dr["ENTIDADCATALOGOCAMPOREL"]).ToString()!.Trim();
                        }

                        if (dr["ESCATALOGOGENERICO"] != System.DBNull.Value)
                        {
                            row.ESCATALOGOGENERICO = (dr["ESCATALOGOGENERICO"]).ToString()!.Trim();
                        }


                        if (modoGenerador == "migracion")
                        {
                            if (dr["TAB"] != System.DBNull.Value)
                            {
                                row.TAB = (dr["TAB"]).ToString()!.Trim();
                            }

                            if (dr["GRID"] != System.DBNull.Value)
                            {
                                row.GRID = (dr["GRID"]).ToString()!.Trim();
                            }

                            if (dr["OBJETOPROPIEDAD"] != System.DBNull.Value)
                            {
                                row.OBJETOPROPIEDAD = (dr["OBJETOPROPIEDAD"]).ToString()!.Trim();
                            }

                            if (dr["PROPIEDAD"] != System.DBNull.Value)
                            {
                                row.PROPIEDAD = (dr["PROPIEDAD"]).ToString()!.Trim();
                            }
                        }


                        this.DataSetSchema1.columnas.AddcolumnasRow(row);

                    }

                    dr.Close();

                    //agregar campos para selectores si no estan
                    foreach (string campocatalogo in camposCamposCatalogo)
                    {
                        if (this.DataSetSchema1.columnas.Where(x => x.COLUMN_NAME.ToLower() == campocatalogo.ToLower()).Count() == 0)
                        {

                            columnasRow row = this.DataSetSchema1.columnas.NewcolumnasRow();

                            row.TABLE_NAME = tableName;
                            row.COLUMN_NAME = campocatalogo;
                            row.IS_NULLABLE = "YES";
                            row.DATA_TYPE = "VARCHAR";
                            row.IDENTIDAD = "NO";
                            row.SIZE = "255";
                            row.IS_KEY = "SI";
                            row.ESCALCULADO = "NO";
                            row.ESCOMBO = "NO";
                            row.ENLISTA = "NO";
                            row.ENEDICION = "NO";
                            row.ORDEN = "0";
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
                            row.NOMBREENFORM = campocatalogo;
                            row.GRUPOFORM = "";
                            row.ANCHOB12 = "3";
                            row.TAB = "";
                            row.SUBTIPO = "ESCOMPLEMENTARIO";
                            row.ENBUSQUEDALISTA = "NO";
                            row.ESSUBENTIDAD = "NO";
                            row.SUBENTIDADTIPO = "";
                            row.SUBENTIDADCAMPO = "";
                            row.SUBENTIDADCAMPOREL = "";
                            row.DEFAULTVALUE = "";
                            row.ESCAMPODECATALOGO = "NO";
                            row.ESCATALOGOGENERICO = "NO";

                            row.ENTIDADCATALOGO = "";
                            row.ENTIDADCATALOGOCAMPO = "";
                            row.ENTIDADCATALOGOCAMPOREL = "";


                            row.GRID = "";
                            row.OBJETOPROPIEDAD = "";
                            row.PROPIEDAD = "";

                            this.DataSetSchema1.columnas.AddcolumnasRow(row);
                        }
                    }



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

                if (modoGenerador == "controladores")
                {

                    columnasRow row = this.DataSetSchema1.columnas.NewcolumnasRow();

                    row.TABLE_NAME = tableName;
                    row.COLUMN_NAME = "DUMMY";
                    row.IS_NULLABLE = "YES";
                    row.DATA_TYPE = "VARCHAR";
                    row.IDENTIDAD = "NO";
                    row.SIZE = "255";
                    row.IS_KEY = "SI";
                    row.ESCALCULADO = "NO";
                    row.ESCOMBO = "NO";
                    row.ENLISTA = "NO";
                    row.ENEDICION = "NO";
                    row.ORDEN = "0";
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
                    row.NOMBREENFORM = "";
                    row.GRUPOFORM = "";
                    row.ANCHOB12 = "3";
                    row.TAB = "";
                    row.SUBTIPO = "ESCOMPLEMENTARIO";
                    row.ENBUSQUEDALISTA = "NO";
                    row.ESSUBENTIDAD = "NO";
                    row.SUBENTIDADTIPO = "";
                    row.SUBENTIDADCAMPO = "";
                    row.SUBENTIDADCAMPOREL = "";
                    row.DEFAULTVALUE = "";
                    row.ESCAMPODECATALOGO = "NO";
                    row.ESCATALOGOGENERICO = "NO";

                    row.ENTIDADCATALOGO = "";
                    row.ENTIDADCATALOGOCAMPO = "";
                    row.ENTIDADCATALOGOCAMPOREL = "";


                    row.GRID = "";
                    row.OBJETOPROPIEDAD = "";
                    row.PROPIEDAD = "";

                    this.DataSetSchema1.columnas.AddcolumnasRow(row);
                }
                else
                {

                    MessageBox.Show("Error 2 " + ex.Message);
                }
                return;
            }

        }

        private string IncludeCommandForWholeEntity()
        {
            var strResult = "";

            var rowsWithDirectCatalogs =
                this.DataSetSchema1.columnas.Where(x => (!x.IsESCAMPODECATALOGONull() && x.ESCAMPODECATALOGO.ToUpper() == "YES" && !x.IsENTIDADCATALOGOCAMPONull()) 
                                                && (x.IsESSUBENTIDADNull() || x.ESSUBENTIDAD.ToUpper() != "YES"))
                .Select(y => "Include(c => c." + y.ENTIDADCATALOGOCAMPO + ")" + System.Environment.NewLine + "              ")
                .Distinct() 
                .ToList();

            if (rowsWithDirectCatalogs != null && rowsWithDirectCatalogs.Count() > 0)
                strResult += String.Join(".", rowsWithDirectCatalogs);


            var rowsWithSunEntities =
                this.DataSetSchema1.columnas.Where(x => (!x.IsESSUBENTIDADNull() && x.ESSUBENTIDAD.ToUpper() == "YES" && !x.IsSUBENTIDADCAMPONull()))
                .Select(y => y.SUBENTIDADCAMPO)
                .Distinct()
                .ToList();



            foreach (string subEntityBuffer in rowsWithSunEntities)
            {
                var secondSubEntity = "";
                var subEntity = subEntityBuffer;
                if (subEntityBuffer.Contains("?."))
                {
                    var splitEnt = subEntityBuffer.Split("?.");
                    subEntity = splitEnt[0];
                    secondSubEntity = splitEnt[1];

                }    
                
                 

                var strThenInclude = "";
                var strOnlyEntity = "Include(c => c." + subEntity + ")";
                //strResult += (strResult.Length > 0 ? "." : "") + "Include(c => c." + subEntity + ")" + System.Environment.NewLine + "              ";


                if (!secondSubEntity.IsNullOrEmpty())
                    strOnlyEntity += ".ThenInclude(s => s." + secondSubEntity + ")";

                var rowsWithSubEntityCatalogs =
                        this.DataSetSchema1.columnas.Where(x => (!x.IsESCAMPODECATALOGONull() && x.ESCAMPODECATALOGO.ToUpper() == "YES" && !x.IsENTIDADCATALOGOCAMPONull())
                                                             && (!x.IsESSUBENTIDADNull() && x.ESSUBENTIDAD.ToUpper() == "YES" && !x.IsSUBENTIDADCAMPONull() && x.SUBENTIDADCAMPO == subEntity))
                            .Select(y => strOnlyEntity + ".ThenInclude(d => d." + y.ENTIDADCATALOGOCAMPO.Split(".").Last() + ")" + System.Environment.NewLine + "              ")
                            .Distinct()
                            .ToList();

                if (rowsWithSubEntityCatalogs != null && rowsWithSubEntityCatalogs.Count() > 0)
                    strThenInclude += String.Join(".", rowsWithSubEntityCatalogs);


                strResult += (strResult.Length > 0 ? "." : "");

                if (strThenInclude != null && strThenInclude.Length > 0)
                    strResult +=  strThenInclude;
                else
                    strResult += strOnlyEntity + System.Environment.NewLine + "              ";

            }

            return (strResult.Length > 0 ? "." + strResult : "");
        }

        List<string> strToIgnore = new List<string>() { "fadministracion", "wfabout", "wfimportacioncatalogossat", "wfreporteshowing", "wfreportsending", "showprinters", "wfmaxfactedicion", "fmain", "wfcancelacionaltseleccion", "wfcargadellavesbancomer", "wfclosingwait", "wfeliminaciondocpendientes", "wfgastoimprimir", "wfimportandoexistencias", "wfnosepudofacturarpregunta", "wfpagopreguntarcredito", "wfreajustarcamposproductosemida", "wftipocotizaciontope", "wftrasladosestatusenvio", "cortexmailtest", "wfconsolidadoautomatico", "wfeditarclaveproductosat", "form1test", "wfactualizandokitmultinivel", "wfappinvexport", "wfisinventariociclico", "wfseleccionartipo", "wfbigmessagebox", "wfeliminacionpagomovil", "wfenviopagomovil", "wfenviopagomovil_3", "wfespera", "wfexportarclientesmovil", "wfimportarpendientesmovilcs", "wfimportarpreciosnuevosmovil", "wfimportarpreciosnuevosmovil3", "wfmatrizmovil3importar", "wfmovilpagorestante", "wfmovilreportes", "frptclientes", "frptkardex", "frptproducto", "frpttesting", "wfcartaportedetalles", "wffacturaelectronica", "wfimpresionabono", "wfimpresioncorte", "wfimpresionrecibolargo", "wfinformevendedores", "wfreportemovclientes", "wfreportemovprovee", "wfreportingshowing", "wfrptinventarioxloc", "wfdesaprobarmovilcxc", "wfconfirmarimportacion", "wfdevolucionesamatriz", "wfexportaraexcel", "wfgetinventariomovil", "wfimportacioninventariomovil", "wfimportar", "wfimportardeexcel", "wfimportarprectemp", "wfmatrizexportar", "wfmatrizexportprectemp", "wfmatrizimportar" };

        private bool IgnorarFormEnMigracion(string? nombreForm)
        {
            return strToIgnore.Contains(nombreForm?.ToLower() ?? "");
        }

    }
}
