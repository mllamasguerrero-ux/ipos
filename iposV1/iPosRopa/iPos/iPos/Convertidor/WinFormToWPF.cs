using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using iPos.Tools;
using Microsoft.ApplicationBlocks.Data;
using iPosReporting;
using Microsoft.Reporting.WinForms;

namespace iPos.Convertidor
{
    public partial class WinFormToWPF : Form
    {

        private string strConstructoresFaltantes = "";
        private string strRutasNoEncontradas = "";
        private iPosReporting.FRptProducto fr = new FRptProducto();

        Dictionary<string, BindingSource> formBindDict;

        Dictionary<string, string> buttonImgDictCurrentForm = new Dictionary<string, string>();

        Dictionary<string, string> imgExceptions = new Dictionary<string, string>();


        public WinFormToWPF()
        {
            InitializeComponent();
            formBindDict = new Dictionary<string, BindingSource>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DefinirProyectos()
        {


            DSConvertidor.PROYECTOSRow fr = dSConvertidor.PROYECTOS.NewPROYECTOSRow();
            fr.NOMBRE = "iPos";
            fr.FORMULARIOINICIAL = "FLogin";
            fr.RUTAFORMULARIOINICIAL = "Login and Maintenance\\";
            fr.RUTAPROYECTO = "iPos";
            dSConvertidor.PROYECTOS.AddPROYECTOSRow(fr);

            fr = dSConvertidor.PROYECTOS.NewPROYECTOSRow();
            fr.NOMBRE = "iPosReporting";
            fr.FORMULARIOINICIAL = "FRptClientes";
            fr.RUTAFORMULARIOINICIAL = "\\";
            fr.RUTAPROYECTO = "iPosReporting";
            dSConvertidor.PROYECTOS.AddPROYECTOSRow(fr);
        }




        private bool EsAutoComplete(string campo, string form)
        {
            foreach(DSConvertidor.AUTOCOMPLETERow fr in dSConvertidor.AUTOCOMPLETE.Rows)
            {
                if(fr.CAMPO == campo && fr.FORMULARIO == form)
                {
                    return true;
                }
            }

            return false;

        }




            

        private void DefinirAutocomplete()
        {


            DSConvertidor.AUTOCOMPLETERow fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "TestConversion1";
            fr.CAMPO = "testAutoComplete";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);



            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFClientes";
            fr.CAMPO = "TSTPalabrasClave";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFProveedores";
            fr.CAMPO = "TSTPalabrasClave";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFOtrasEntradas";
            fr.CAMPO = "TBCommandLine";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFOtrasSalidas";
            fr.CAMPO = "TBCommandLine";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFCobranzaMovil";
            fr.CAMPO = "TBBusqueda";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFMovilPuntoDeVenta";
            fr.CAMPO = "TBCommandLine";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "LOOKPROD";
            fr.CAMPO = "busquedaToolStripTextBox";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

            fr = dSConvertidor.AUTOCOMPLETE.NewAUTOCOMPLETERow();
            fr.FORMULARIO = "WFPuntoDeVenta";
            fr.CAMPO = "TBCommandLine";
            dSConvertidor.AUTOCOMPLETE.AddAUTOCOMPLETERow(fr);

        }


        private void defineImageRouteExceptions()
        {
            imgExceptions = new Dictionary<string, string>();
            imgExceptions.Add("Accept", "gif/Accept.gif");
            imgExceptions.Add("Add", "gif/Add.gif");
            imgExceptions.Add("Closed_door", "gif/Closed door.gif.gif");
            imgExceptions.Add("Closed_folder", "gif/Closed folder.gif");
            imgExceptions.Add("Delete", "gif/Delete.gif");
            imgExceptions.Add("Document", "gif/Document.gif");
            imgExceptions.Add("Edit", "gif/Edit.gif");
            imgExceptions.Add("Exit", "gif/Exit.gif");
            imgExceptions.Add("Info", "gif/info.gif");
            imgExceptions.Add("Numbered_list", "gif/Numbered list.gif");
            imgExceptions.Add("Open_door", "gif/Open door.gif");
            imgExceptions.Add("retiro", "gif/retiro.gif");
            imgExceptions.Add("1", "1.jpg");
            imgExceptions.Add("Buttons", "Buttons.jpg");
            imgExceptions.Add("Buttons1", "Buttons1.jpg");
            imgExceptions.Add("EnterKey", "EnterKey.jpg");
            imgExceptions.Add("EnterKey1", "EnterKey1.jpg");
            imgExceptions.Add("i-pos.ico", "i-pos.ico");
            imgExceptions.Add("iconBinoculars", "iconBinoculars.gif");
            imgExceptions.Add("icono_cliente", "icono_cliente.jpg");
            imgExceptions.Add("keyboard_alphabetical", "keyboard_alphabetical.jpg");
            imgExceptions.Add("keyboard_kids_lower", "keyboard_kids_lower.jpg");
            imgExceptions.Add("keyboard_kids_upper", "keyboard_kids_upper.jpg");
            imgExceptions.Add("keyboard_white", "keyboard_white.jpg");

            imgExceptions.Add("shift_down_white", "shift_down_white.jpg");
            imgExceptions.Add("SpaceDarkgd", "SpaceDarkgd.jpg");
            imgExceptions.Add("SpaceDarkgd1", "SpaceDarkgd1.jpg");
            imgExceptions.Add("spacekey", "spacekey.jpg");
            imgExceptions.Add("submission_form_background", "submission_form_background.jpg");
            imgExceptions.Add("th", "th.jpg");
            imgExceptions.Add("th_down", "th_down.jpg");
            imgExceptions.Add("verreporte", "verreporte.jpg");

        }



        private void ConfigurarProyectos()
        {
            string nombreSolucion = "iPos";

            foreach (DSConvertidor.PROYECTOSRow pr in dSConvertidor.PROYECTOS.Rows)
            {
                string strRutaProyecto = TBRutaModificar.Text + "\\" + pr.RUTAPROYECTO;

                string fileProgramCs = strRutaProyecto + "\\Program.cs";

                bool fileExists = File.Exists(fileProgramCs);
                if (fileExists)
                    File.Delete(fileProgramCs);


                string fileXAML = strRutaProyecto + "\\App.xaml";

                fileExists = File.Exists(fileXAML);
                if (fileExists)
                    File.Delete(fileXAML);

                using (StreamWriter sw = new StreamWriter(fileXAML))
                {
                    string strContent = "<Application x:Class=\"(nombreProyecto).App\"\n             xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n             xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n             StartupUri=\"(rutaRelativaFormularioPrincipal)(formularioPrincipal).xaml\">\n    <Application.Resources>\n    \n        <ResourceDictionary>\n            <ResourceDictionary.MergedDictionaries>\n                <ResourceDictionary Source=\"pack://application:,,,/WPFMigrating;component/AutoComplete/Editors/Themes/AutoCompleteGeneric.xaml\" />\n                <ResourceDictionary Source=\"pack://application:,,,/WPFMigrating;component/Themes/ExpressionDark.xaml\" />\n            </ResourceDictionary.MergedDictionaries>\n        </ResourceDictionary>     \n    </Application.Resources>\n</Application>";
                    strContent = strContent.Replace("(nombreProyecto)", pr.NOMBRE);
                    strContent = strContent.Replace("(rutaRelativaFormularioPrincipal)", pr.RUTAFORMULARIOINICIAL);
                    strContent = strContent.Replace("(formularioPrincipal)", pr.FORMULARIOINICIAL);
                    strContent = strContent.Replace("\n", Environment.NewLine);
                    sw.Write(strContent);
                }



                string fileXAMLCS = strRutaProyecto + "\\App.xaml.cs";

                fileExists = File.Exists(fileXAMLCS);
                if (fileExists)
                    File.Delete(fileXAMLCS);

                using (StreamWriter sw = new StreamWriter(fileXAMLCS))
                {
                    string strContent = "using System;\nusing System.Collections.Generic;\nusing System.Configuration;\nusing System.Data;\nusing System.Linq;\nusing System.Windows;\n\nnamespace (nombreProyecto)\n{\n    /// <summary>\n    /// Interaction logic for App.xaml\n    /// </summary>\n    public partial class App : Application\n    {\n    }\n}\n";
                    strContent = strContent.Replace("(nombreProyecto)", pr.NOMBRE);
                    strContent = strContent.Replace("(rutaRelativaFormularioPrincipal)", pr.RUTAFORMULARIOINICIAL);
                    strContent = strContent.Replace("(formularioPrincipal)", pr.FORMULARIOINICIAL);
                    strContent = strContent.Replace("\n", Environment.NewLine);
                    sw.Write(strContent);
                }
                


                string fileProject = strRutaProyecto + "\\" + pr.NOMBRE + ".csproj";
                using (StreamReader sr = new StreamReader(fileProject))
                {
                    StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                    stBuilder.Replace(Environment.NewLine, "\n");

                    stBuilder = stBuilder.Replace("<TargetFrameworkVersion>v3.5</TargetFrameworkVersion>", "<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                    stBuilder = stBuilder.Replace("<FileAlignment>512</FileAlignment>", "<FileAlignment>512</FileAlignment>\n    <ProjectTypeGuids>{60dc8134-eba5-43b8-bcc9-bb4bc16c2548};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>\n    <WarningLevel>4</WarningLevel>\n    <TargetFrameworkProfile />");
                    stBuilder = stBuilder.Replace("<Reference Include=\"System.Xml\" />", "\n    <Reference Include=\"System.Xml\" />\n    <Reference Include=\"System.Xaml\" />\n    <Reference Include=\"WindowsBase\" />\n    <Reference Include=\"PresentationCore\" />\n    <Reference Include=\"PresentationFramework\" />\n    <Reference Include=\"WindowsFormsIntegration\" />");
                    stBuilder = stBuilder.Replace("<Compile Include=\"Program.cs\" />", "<AppDesigner Include=\"Properties\\\" />\n    <ApplicationDefinition Include=\"App.xaml\">\n      <Generator>MSBuild:Compile</Generator>\n      <SubType>Designer</SubType>\n    </ApplicationDefinition>\n    <Compile Include=\"App.xaml.cs\">\n      <DependentUpon>App.xaml</DependentUpon>\n      <SubType>Code</SubType>\n    </Compile>");
                    stBuilder = stBuilder.Replace("<Compile Include=\"Properties\\AssemblyInfo.cs\" />", "<Compile Include=\"Properties\\AssemblyInfo.cs\">\n      <SubType>Code</SubType>\n    </Compile>");
                    stBuilder = stBuilder.Replace("<Compile Include=\"Properties\\Resources.Designer.cs\">\n      <AutoGen>True</AutoGen>\n      <DependentUpon>Resources.resx</DependentUpon>\n    </Compile>", "<Compile Include=\"Properties\\Resources.Designer.cs\">\n      <AutoGen>True</AutoGen>\n      <DesignTime>True</DesignTime>\n      <DependentUpon>Resources.resx</DependentUpon>\n    </Compile>");
                    stBuilder = stBuilder.Replace("<EmbeddedResource Include=\"Properties\\Resources.resx\">\n      <Generator>ResXFileCodeGenerator</Generator>\n      <LastGenOutput>Resources.Designer.cs</LastGenOutput>\n      <SubType>Designer</SubType>\n    </EmbeddedResource>", "<EmbeddedResource Include=\"Properties\\Resources.resx\">\n      <Generator>ResXFileCodeGenerator</Generator>\n      <LastGenOutput>Resources.Designer.cs</LastGenOutput>\n    </EmbeddedResource>");
                    stBuilder = stBuilder.Replace("<ProjectReference Include=\"..\\DataLayer\\DataLayer.csproj\">\n      <Project>{F8605CF6-91D5-4FD7-8147-AC7F13C7404A}</Project>\n      <Name>DataLayer</Name>\n    </ProjectReference>\n", "<ProjectReference Include=\"..\\DataLayer\\DataLayer.csproj\">\n      <Project>{F8605CF6-91D5-4FD7-8147-AC7F13C7404A}</Project>\n      <Name>DataLayer</Name>\n    </ProjectReference>\n    <ProjectReference Include=\"..\\dotLinkControlsWpf\\dotLinkControlsWpf.csproj\">\n      <Project>{d9fbec73-0fa7-4fc2-bfae-d9bd6d36c566}</Project>\n      <Name>dotLinkControlsWpf</Name>\n    </ProjectReference>\n    <ProjectReference Include=\"..\\WPFMigrating\\WPFMigrating.csproj\">\n      <Project>{500fb957-fd06-4efc-92f0-7a33dbac8c0f}</Project>\n      <Name>WPFMigrating</Name>\n    </ProjectReference>\n");

                    stBuilder = stBuilder.Replace("<Reference Include=\"Microsoft.Office.Interop.Excel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c, processorArchitecture=MSIL\">\n      <SpecificVersion>False</SpecificVersion>\n      <EmbedInteropTypes>True</EmbedInteropTypes>\n      <HintPath>..\\iPosInstalador\\Microsoft.Office.Interop.Excel.dll</HintPath>\n    </Reference>","<Reference Include=\"Microsoft.Office.Interop.Excel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c, processorArchitecture=MSIL\">\n      <SpecificVersion>False</SpecificVersion>\n      <EmbedInteropTypes>False</EmbedInteropTypes>\n      <HintPath>..\\iPosInstalador\\Microsoft.Office.Interop.Excel.dll</HintPath>\n    </Reference>");


                    foreach (DSConvertidor.FORMULARIOSRow fr in dSConvertidor.FORMULARIOS.Rows)
                    {
                        if (fr.IsRUTANull())
                            continue;

                        if (fr.NOMBRECOMPLETO.ToUpper().StartsWith(pr.NOMBRE.ToUpper()))
                        {
                            string rutaRelativa = fr.RUTA.Replace(TBRutaModificar.Text, "").Replace("\\" + pr.NOMBRE + "\\", "");
                            string strOrig = "<Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".cs\">\n      <SubType>Form</SubType>\n    </Compile>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".Designer.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n    </Compile>";
                            stBuilder = stBuilder.Replace("<Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".cs\">\n      <SubType>Form</SubType>\n    </Compile>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".Designer.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n    </Compile>", "<Page Include=\"" + rutaRelativa + fr.NOMBRE + ".xaml\">\n      <Generator>MSBuild:Compile</Generator>\n      <SubType>Designer</SubType>\n    </Page>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".xaml.Designer.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".xaml</DependentUpon>\n      <SubType>Code</SubType>\n    </Compile>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".xaml.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".xaml</DependentUpon>\n      <SubType>Code</SubType>\n    </Compile>");
                            stBuilder = stBuilder.Replace("<Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".cs\">\n      <SubType>Form</SubType>\n    </Compile>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".designer.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n    </Compile>", "<Page Include=\"" + rutaRelativa + fr.NOMBRE + ".xaml\">\n      <Generator>MSBuild:Compile</Generator>\n      <SubType>Designer</SubType>\n    </Page>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".xaml.Designer.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".xaml</DependentUpon>\n      <SubType>Code</SubType>\n    </Compile>\n    <Compile Include=\"" + rutaRelativa + fr.NOMBRE + ".xaml.cs\">\n      <DependentUpon>" + fr.NOMBRE + ".xaml</DependentUpon>\n      <SubType>Code</SubType>\n    </Compile>");
                            stBuilder = stBuilder.Replace("<EmbeddedResource Include=\"" + rutaRelativa + fr.NOMBRE + ".resx\">\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n    </EmbeddedResource>", "");
                            stBuilder = stBuilder.Replace("<EmbeddedResource Include=\"" + rutaRelativa + fr.NOMBRE + ".resx\">\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n      <SubType>Designer</SubType>\n    </EmbeddedResource>\n", "");
                            stBuilder = stBuilder.Replace("<EmbeddedResource Include=\"" + rutaRelativa + fr.NOMBRE + ".resx\">\n      <SubType>Designer</SubType>\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n    </EmbeddedResource>\n", "");
                            
                            //string strTest = "<EmbeddedResource Include=\"" + rutaRelativa + fr.NOMBRE + ".resx\">\n      <DependentUpon>" + fr.NOMBRE + ".cs</DependentUpon>\n    </EmbeddedResource>";
                        }
                    }


                    stBuilder = stBuilder.Replace("\n", Environment.NewLine);

                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(fileProject))
                    {
                        sw.Write(stBuilder);
                    }

                }


                using (StreamReader sr = new StreamReader(fileProject))
                {
                    StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                    StringBuilder stBuilderNew = new StringBuilder(sr.ReadToEnd());
                    stBuilder = stBuilder.Replace(Environment.NewLine, "\n");
                    string[] strLines = stBuilder.ToString().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strLines)
                    {
                        string newStr = str;
                        if ((str.Contains("None Include") || str.Contains("Content Include"))  &&
                            (str.Contains(".png") || str.Contains(".jpg") || str.Contains(".gif") || str.Contains(".ico")) &&
                             (str.Contains("Resources")))
                        {
                            string[] splitStr = str.Split( new string[]{"Resources"}, StringSplitOptions.None);
                            string reso = splitStr[splitStr.Length - 1].Replace("\" />","");

                            newStr = "<Resource Include=\"Resources" + reso + "\">\n      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>\n    </Resource>";
                            newStr = newStr.Replace("\n", Environment.NewLine);
                        }

                        stBuilderNew.Append(newStr + Environment.NewLine);
                    }


                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(fileProject))
                    {
                        sw.Write(stBuilderNew);
                    }

                }





                string fileAppConfig = strRutaProyecto + "\\app.config";
                using (StreamReader sr = new StreamReader(fileAppConfig))
                {
                    StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                    stBuilder.Replace(Environment.NewLine, "\n");

                    stBuilder = stBuilder.Replace("</configuration>", "<startup><supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.0\"/></startup></configuration>");

                    stBuilder = stBuilder.Replace("\n", Environment.NewLine);

                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(fileAppConfig))
                    {
                        sw.Write(stBuilder);
                    }

                }



                string fileAssemblyInfo = strRutaProyecto + "\\Properties\\assemblyinfo.cs";
                using (StreamReader sr = new StreamReader(fileAssemblyInfo))
                {
                    StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                    stBuilder.Replace(Environment.NewLine, "\n");

                    stBuilder = stBuilder.Replace("using System.Reflection;", "using System.Reflection;\nusing System.Resources;");
                    stBuilder = stBuilder.Replace("using System.Runtime.InteropServices;", "using System.Runtime.InteropServices;\nusing System.Windows;");
                    stBuilder = stBuilder.Replace("[assembly: ComVisible(false)]", "[assembly: ComVisible(false)]\n\n//In order to begin building localizable applications, set \n//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file\n//inside a <PropertyGroup>.  For example, if you are using US english\n//in your source files, set the <UICulture> to en-US.  Then uncomment\n//the NeutralResourceLanguage attribute below.  Update the \"en-US\" in\n//the line below to match the UICulture setting in the project file.\n\n//[assembly: NeutralResourcesLanguage(\"en-US\", UltimateResourceFallbackLocation.Satellite)]\n\n\n[assembly: ThemeInfo(\n    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located\n    //(used if a resource is not found in the page, \n    // or application resource dictionaries)\n    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located\n    //(used if a resource is not found in the page, \n    // app, or any theme specific resource dictionaries)\n)]");

                    stBuilder = stBuilder.Replace("\n", Environment.NewLine);

                    sr.Close();
                    using (StreamWriter sw = new StreamWriter(fileAssemblyInfo))
                    {
                        sw.Write(stBuilder);
                    }

                }


            }

            
            string fileSolucion = TBRutaModificar.Text + "\\" + nombreSolucion + ".sln";
            using (StreamReader sr = new StreamReader(fileSolucion))
            {
                StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                stBuilder.Replace(Environment.NewLine, "\n");

                stBuilder = stBuilder.Replace("Global\n GlobalSection(SolutionConfigurationPlatforms) = preSolution", "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"dotLinkControlsWpf\", \"dotLinkControlsWpf\\dotLinkControlsWpf.csproj\", \"{D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}\"\nEndProject\nProject(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"WPFMigrating\", \"WPFMigrating\\WPFMigrating.csproj\", \"{500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}\"\nEndProject\nGlobal\n GlobalSection(SolutionConfigurationPlatforms) = preSolution\n");

                stBuilder = stBuilder.Replace("SccLocalPath6 = SetupCustomActions", "SccLocalPath6 = SetupCustomActions\n SccProjectUniqueName7 = dotLinkControlsWpf\\\\dotLinkControlsWpf.csproj\nSccProjectName7 = dotLinkControlsWpf\nSccLocalPath7 = dotLinkControlsWpf\nSccProjectUniqueName8 = WPFMigrating\\\\WPFMigrating.csproj\nSccProjectName8 = WPFMigrating\nSccLocalPath8 = WPFMigrating");
                
                stBuilder = stBuilder.Replace("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"SetupCustomActions\", \"SetupCustomActions\\SetupCustomActions.csproj\", \"{D83A56B6-B913-4593-99D1-5C29D1B69907}\"\nEndProject", "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"SetupCustomActions\", \"SetupCustomActions\\SetupCustomActions.csproj\", \"{D83A56B6-B913-4593-99D1-5C29D1B69907}\"\nEndProject\nProject(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"dotLinkControlsWpf\", \"dotLinkControlsWpf\\dotLinkControlsWpf.csproj\", \"{D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}\"\nEndProject\nProject(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"WPFMigrating\", \"WPFMigrating\\WPFMigrating.csproj\", \"{500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}\"\nEndProject");
                
                stBuilder = stBuilder.Replace("{D83A56B6-B913-4593-99D1-5C29D1B69907}.SingleImage|x86.ActiveCfg = Release|Any CPU", "{D83A56B6-B913-4593-99D1-5C29D1B69907}.SingleImage|x86.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.CD_ROM|Any CPU.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.CD_ROM|Any CPU.Build.0 = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.CD_ROM|Mixed Platforms.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.CD_ROM|Mixed Platforms.Build.0 = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.CD_ROM|x86.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Debug|Any CPU.Build.0 = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Debug|Mixed Platforms.ActiveCfg = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Debug|Mixed Platforms.Build.0 = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Debug|x86.ActiveCfg = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.DVD-5|Any CPU.ActiveCfg = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.DVD-5|Any CPU.Build.0 = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.DVD-5|Mixed Platforms.ActiveCfg = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.DVD-5|Mixed Platforms.Build.0 = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.DVD-5|x86.ActiveCfg = Debug|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Release|Any CPU.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Release|Any CPU.Build.0 = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Release|Mixed Platforms.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Release|Mixed Platforms.Build.0 = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.Release|x86.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.SingleImage|Any CPU.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.SingleImage|Any CPU.Build.0 = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.SingleImage|Mixed Platforms.ActiveCfg = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.SingleImage|Mixed Platforms.Build.0 = Release|Any CPU\n  {D9FBEC73-0FA7-4FC2-BFAE-D9BD6D36C566}.SingleImage|x86.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.CD_ROM|Any CPU.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.CD_ROM|Any CPU.Build.0 = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.CD_ROM|Mixed Platforms.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.CD_ROM|Mixed Platforms.Build.0 = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.CD_ROM|x86.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Debug|Any CPU.Build.0 = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Debug|Mixed Platforms.ActiveCfg = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Debug|Mixed Platforms.Build.0 = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Debug|x86.ActiveCfg = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.DVD-5|Any CPU.ActiveCfg = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.DVD-5|Any CPU.Build.0 = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.DVD-5|Mixed Platforms.ActiveCfg = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.DVD-5|Mixed Platforms.Build.0 = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.DVD-5|x86.ActiveCfg = Debug|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Release|Any CPU.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Release|Any CPU.Build.0 = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Release|Mixed Platforms.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Release|Mixed Platforms.Build.0 = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.Release|x86.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.SingleImage|Any CPU.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.SingleImage|Any CPU.Build.0 = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.SingleImage|Mixed Platforms.ActiveCfg = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.SingleImage|Mixed Platforms.Build.0 = Release|Any CPU\n  {500FB957-FD06-4EFC-92F0-7A33DBAC8C0F}.SingleImage|x86.ActiveCfg = Release|Any CPU");


                stBuilder = stBuilder.Replace("\n", Environment.NewLine);

                sr.Close();
                using (StreamWriter sw = new StreamWriter(fileSolucion))
                {
                    sw.Write(stBuilder);
                }

            }

        }




        private static void DirectoryCopy(
        string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }

        private void copiaProyectoInicialEnDestino()
        {

            string rutaFuente = this.TBRutaProyectoBase.Text;
            string rutaDestino = TBRutaModificar.Text;
           bool exists = System.IO.Directory.Exists(rutaDestino);

            if (exists)
            {
                clearFolder(rutaDestino);
                System.IO.Directory.Delete(rutaDestino);
            }

            WinFormToWPF.DirectoryCopy(rutaFuente, rutaDestino, true);

            

            string rutaFuenteLibrerias = "C:\\IposProject\\LibreriasWPF";
            WinFormToWPF.DirectoryCopy(rutaFuenteLibrerias, rutaDestino, true);


        }





        private void btnConvertir_Click(object sender, EventArgs e)
        {

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            
           

            copiaProyectoInicialEnDestino();

            defineImageRouteExceptions();

            DefinirAutocomplete();

            DefinirProyectos();

            int iCountAsm = 0;
            foreach (Assembly a in assemblies)
            {

                Type[] types = a.GetTypes();
                foreach (Type t in types)
                {
                    if (t.IsPublic && t.IsSubclassOf(typeof(Form)) && (t.Namespace.Contains("WindowsFormsApplication1") || (t.Namespace.Contains("iPos"))) &&
                        (t.Name != "WinFormToWPF" && t.Name != "IposForm" && t.Name != "ScreenConfigurableForm" && t.Name != "FQuery" && 
                        t.Name != "EMPRESAEdit_Reg" &&   t.Name != "USUARIOSEdit"  && t.Name != "GeneralLookUp" &&
                        t.Name != "CalculatorForm" && t.Name != "EnviosMail" && t.Name != "WFReporteDesigning" && t.Name != "WFReporteDeConcentradoDeRuta"
                        /*t.Name != "WFActualizacionBD" && t.Name != "WFIntercambioLotes" && t.Name != "WFLogDetail" && t.Name != "WFLogItems" && t.Name != "WFImpresionCorte" &&*/
                        /*t.Name != "WFEntregarVentaFuturo" && t.Name != "WFImportarCompras" && t.Name != "WFImportarOrdenes" && t.Name != "WFImportarPedidosSucursales" &&*/
                        /*t.Name != "WFListaDiferencias" &&*//* t.Name != "WFGenerarPolizas"*/ /*&& (t.Name == "WFImpresionCorte")*/  /*&& (t.Name == "TestConversion1")*/) /*&&
                        (t.Name == "Form1" ||
                         t.Name == "WinFormToWPF")*/
                        )
                    {

                        DSConvertidor.FORMULARIOSRow fr = dSConvertidor.FORMULARIOS.NewFORMULARIOSRow();
                        fr.NOMBRE = t.Name;
                        fr.NOMBRECOMPLETO = t.FullName;
                        fr.ENSAMBLADOID = iCountAsm;
                        dSConvertidor.FORMULARIOS.AddFORMULARIOSRow(fr);
                        //f = (Form)a.CreateInstance(t.FullName);

                    }
                }
                iCountAsm++;
            }


            string strMainPath = TBRutaProyectoBase.Text;
            String[] allfiles = System.IO.Directory.GetFiles(strMainPath, "*.Designer.cs", System.IO.SearchOption.AllDirectories);
            foreach (string file in allfiles)
            {
                DSConvertidor.ARCHIVOSRow fr = dSConvertidor.ARCHIVOS.NewARCHIVOSRow();
                fr.NOMBRE = Path.GetFileName(file).Replace(".Designer.cs", "").Replace(".designer.cs", "");
                fr.RUTA = Path.GetFullPath(file).Replace(strMainPath, "").Replace(Path.GetFileName(file), "").Replace("TestWinForms\\", "");
                dSConvertidor.ARCHIVOS.AddARCHIVOSRow(fr);
            }


            foreach (DSConvertidor.FORMULARIOSRow fr in dSConvertidor.FORMULARIOS.Rows)
            {

                foreach (DSConvertidor.ARCHIVOSRow ar in dSConvertidor.ARCHIVOS.Rows)
                {
                    if (ar.NOMBRE.ToUpper() == fr.NOMBRE.ToUpper())
                    {
                        fr.RUTA = ar.RUTA;
                    }
                }
            }


            string rutaMolde = TBRutaModificar.Text;

            foreach (DSConvertidor.FORMULARIOSRow fr in dSConvertidor.FORMULARIOS.Rows)
            {

                if (fr.IsRUTANull())
                {

                    strRutasNoEncontradas += ", " + fr.NOMBRECOMPLETO;
                    continue;
                }


                string rutaFolder = rutaMolde + fr.RUTA;




                string rutaOrigen = TBRutaProyectoBase.Text + fr.RUTA;

                bool exists = System.IO.Directory.Exists(rutaFolder);

                if (!exists)
                    System.IO.Directory.CreateDirectory(rutaFolder);


                bool fileExists = false;

                string fileOrigenDesigner = rutaOrigen + fr.NOMBRE + ".Designer.cs";

                string fileDesigner = rutaFolder + fr.NOMBRE + ".Designer.cs";
                fileExists = File.Exists(fileDesigner);
                if (fileExists)
                    File.Delete(fileDesigner);

                string fileResX = rutaFolder + fr.NOMBRE + ".resx";
                fileExists = File.Exists(fileResX);
                if (fileExists)
                    File.Delete(fileResX);





                string fileXAMLCS = rutaFolder + fr.NOMBRE + ".xaml.cs";
                string fileWinFormsCS = rutaOrigen + fr.NOMBRE + ".cs";
                string fileXAMLOldWinFormCS = rutaFolder + fr.NOMBRE + ".cs";


                fileExists = File.Exists(fileXAMLCS);
                if (fileExists)
                    File.Delete(fileXAMLCS);


                fileExists = File.Exists(fileXAMLOldWinFormCS);
                if (fileExists)
                    File.Delete(fileXAMLOldWinFormCS);

                using (StreamReader sr = new StreamReader(fileWinFormsCS))
                {
                    StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                    stBuilder.Replace(Environment.NewLine, "\n");
                    stBuilder = stBuilder.Replace("using System.ComponentModel;", "");
                    stBuilder = stBuilder.Replace("using System.Drawing;", "");
                    stBuilder = stBuilder.Replace("using System.Windows.Forms;", "using System.Windows;\nusing System.Windows.Controls;\nusing System.Windows.Data;\nusing System.Windows.Documents;\nusing System.Windows.Input;\nusing System.Windows.Media;\nusing System.Windows.Media.Imaging;\nusing System.Windows.Shapes;\nusing WPFMigrating;\nusing WPFMigrate.Tools;");


                    //stBuilder = stBuilder.Replace(fr.NOMBRE + " : Form", fr.NOMBRE + " : Window");
                    stBuilder = stBuilder.Replace(", EventArgs", ", RoutedEventArgs");
                    stBuilder = stBuilder.Replace(fr.NOMBRE + " : IposForm", fr.NOMBRE + " : Form");
                    stBuilder = stBuilder.Replace(fr.NOMBRE + " : iPos.IposForm", fr.NOMBRE + " : Form");
                    stBuilder = stBuilder.Replace(fr.NOMBRE + " : iPos.Tools.ScreenConfigurableForm", fr.NOMBRE + " : Form");



                    //stBuilder = stBuilder.Replace(fr.NOMBRE + " : Form", fr.NOMBRE + " : Windows");

                    stBuilder = stBuilder.Replace("Color.FromArgb", "ColorWF.FromArgb");
                    stBuilder = stBuilder.Replace("DialogResult.", "MessageBoxResult.");
                    stBuilder = stBuilder.Replace("MessageBoxIcon", "MessageBoxImage");
                    stBuilder = stBuilder.Replace("MessageBoxDefaultButton.Button2", "MessageBoxResult.No");
                    stBuilder = stBuilder.Replace("MessageBoxDefaultButton.Button1", "MessageBoxResult.Yes");
                    stBuilder = stBuilder.Replace("Application.Exit()", "Application.Current.Shutdown()");
                    stBuilder = stBuilder.Replace("FormWindowState", "WindowState");

                    //stBuilder = stBuilder.Replace(".KeyCode == Keys.", ".Key == Key.");
                    //stBuilder = stBuilder.Replace(".KeyCode == System.Windows.Forms.Keys.", ".Key == Key.");
                    //stBuilder = stBuilder.Replace("switch (e.KeyCode)", "switch (e.Key)");
                    //stBuilder = stBuilder.Replace("switch(e.KeyCode)", "switch(e.Key)");
                    //stBuilder = stBuilder.Replace("case Keys.", "case Key.");
                    //stBuilder = stBuilder.Replace("e.Modifiers == Keys.Control", "(Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control");

                    stBuilder = stBuilder.Replace(".KeyCode == Keys.", ".KeyCode == System.Windows.Forms.Keys.");
                    stBuilder = stBuilder.Replace("case Keys.", "case System.Windows.Forms.Keys.");
                    stBuilder = stBuilder.Replace("e.Modifiers == Keys.Control", "e.Modifiers == System.Windows.Forms.Keys.Control");
                    stBuilder = stBuilder.Replace("KeyEventArgs", "System.Windows.Forms.KeyEventArgs");
                    stBuilder = stBuilder.Replace("ManejaTecla(Keys key)", "ManejaTecla(System.Windows.Forms.Keys key)");

                    stBuilder = stBuilder.Replace("Application.StartupPath", "System.AppDomain.CurrentDomain.BaseDirectory");
                    stBuilder = stBuilder.Replace(" Image.FromFile", " System.Drawing.Image.FromFile");
                    stBuilder = stBuilder.Replace("= Color.", "= System.Drawing.Color.");
                    stBuilder = stBuilder.Replace("Control.ModifierKeys == Keys.Control", "(Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control");
                    stBuilder = stBuilder.Replace("FillRectangle(Brushes.", "FillRectangle(System.Drawing.Brushes.");
                    //stBuilder = stBuilder.Replace("(!e.Alt)", "(!((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt))");
                    //stBuilder = stBuilder.Replace("(e.Alt)", "((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)");
                    //stBuilder = stBuilder.Replace("Key.Oemplus", "Key.OemPlus");

                    stBuilder = stBuilder.Replace("coloreaRow(DataGridViewRow", "coloreaRow(System.Windows.Forms.DataGridViewRow");
                    stBuilder = stBuilder.Replace("DataGridViewRow dr =", "System.Windows.Forms.DataGridViewRow dr =");
                    stBuilder = stBuilder.Replace(".IndexFromPoint(e.Location)", ".IndexFromPoint(/*e.Location*/)");
                    stBuilder = stBuilder.Replace(" Brushes.", " System.Drawing.Brushes.");

                    stBuilder = stBuilder.Replace("System.Windows.Forms.AutoCompleteMode", "AutoCompleteMode");
                    stBuilder = stBuilder.Replace("AutoCompleteMode", "System.Windows.Forms.AutoCompleteMode");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.AutoCompleteSource", "AutoCompleteSource");
                    stBuilder = stBuilder.Replace("AutoCompleteSource", "System.Windows.Forms.AutoCompleteSource");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.AutoCompleteStringCollection", "AutoCompleteStringCollection");
                    stBuilder = stBuilder.Replace("AutoCompleteStringCollection", "System.Windows.Forms.AutoCompleteStringCollection");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.BorderStyle", "BorderStyle");
                    stBuilder = stBuilder.Replace("BorderStyle", "System.Windows.Forms.BorderStyle");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewCellCancelEventArgs", "DataGridViewCellCancelEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewCellCancelEventArgs", "System.Windows.Forms.DataGridViewCellTancelEventArgs");
                    stBuilder = stBuilder.Replace("System.ComponentModel.CancelEventArgs", "CancelEventArgs");
                    stBuilder = stBuilder.Replace("CancelEventArgs", "System.ComponentModel.CancelEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewCellTancelEventArgs", "DataGridViewCellCancelEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewAutoSizeRowsMode", "DataGridViewAutoSizeRowsMode");
                    stBuilder = stBuilder.Replace("DataGridViewAutoSizeRowsMode", "System.Windows.Forms.DataGridViewAutoSizeRowsMode");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewCellEventArgs", "DataGridViewCellEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewCellEventArgs", "System.Windows.Forms.DataGridViewCellEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewCellFormattingEventArgs", "DataGridViewCellFormattingEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewCellFormattingEventArgs", "System.Windows.Forms.DataGridViewCellFormattingEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewCellValidatingEventArgs", "DataGridViewCellValidatingEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewCellValidatingEventArgs", "System.Windows.Forms.DataGridViewCellValidatingEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewColumn", "DataGridViewColumn");
                    stBuilder = stBuilder.Replace("DataGridViewColumn", "System.Windows.Forms.DataGridViewColumn");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewColumnSortMode", "DataGridViewColumnSortMode");
                    stBuilder = stBuilder.Replace("DataGridViewColumnSortMode", "System.Windows.Forms.DataGridViewColumnSortMode");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewDataErrorEventArgs", "DataGridViewDataErrorEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewDataErrorEventArgs", "System.Windows.Forms.DataGridViewDataErrorEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewEditingControlShowingEventArgs", "DataGridViewEditingControlShowingEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewEditingControlShowingEventArgs", "System.Windows.Forms.DataGridViewEditingControlShowingEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewEditMode", "DataGridViewEditMode");
                    stBuilder = stBuilder.Replace("DataGridViewEditMode", "System.Windows.Forms.DataGridViewEditMode");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewRow", "DataGridViewRow");
                    stBuilder = stBuilder.Replace("DataGridViewRow", "System.Windows.Forms.DataGridViewRow");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewRowsAddedEventArgs", "DataGridViewRowsAddedEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewRowsAddedEventArgs", "System.Windows.Forms.DataGridViewRowsAddedEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DrawItemEventArgs", "DrawItemEventArgs");
                    stBuilder = stBuilder.Replace("DrawItemEventArgs", "System.Windows.Forms.DrawItemEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DrawItemState", "DrawItemState");
                    stBuilder = stBuilder.Replace("DrawItemState", "System.Windows.Forms.DrawItemState");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.FormClosingEventArgs", "FormClosingEventArgs");
                    stBuilder = stBuilder.Replace("FormClosingEventArgs", "System.Windows.Forms.FormClosingEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.KeyPressEventArgs", "KeyPressEventArgs");
                    stBuilder = stBuilder.Replace("KeyPressEventArgs", "System.Windows.Forms.KeyPressEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.MeasureItemEventArgs", "MeasureItemEventArgs");
                    stBuilder = stBuilder.Replace("MeasureItemEventArgs", "System.Windows.Forms.MeasureItemEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.PaintEventArgs", "PaintEventArgs");
                    stBuilder = stBuilder.Replace("PaintEventArgs", "System.Windows.Forms.PaintEventArgs");

                    stBuilder = stBuilder.Replace("System.ComponentModel.BackgroundWorker", "BackgroundWorker");
                    stBuilder = stBuilder.Replace("BackgroundWorker", "System.ComponentModel.BackgroundWorker");

                    stBuilder = stBuilder.Replace("ProgressBarStyle", "Progress_BarStyle");

                    stBuilder = stBuilder.Replace("System.Windows.Forms.ProgressBar", "ProgressBar");
                    stBuilder = stBuilder.Replace("ProgressBar", "WPFMigrating.ProgressBarWF");

                    stBuilder = stBuilder.Replace("Progress_BarStyle", "ProgressBarStyle");

                    stBuilder = stBuilder.Replace("System.Windows.Forms.ProgressBarStyle", "ProgressBarStyle");
                    stBuilder = stBuilder.Replace("ProgressBarStyle", "System.Windows.Forms.ProgressBarStyle");

                    stBuilder = stBuilder.Replace("System.Windows.Forms.BindingSource source", "BindingSource source");
                    stBuilder = stBuilder.Replace("BindingSource source", "System.Windows.Forms.BindingSource source");
                    stBuilder = stBuilder.Replace("new System.Windows.Forms.BindingSource()", "new BindingSource()");
                    stBuilder = stBuilder.Replace("new BindingSource()", "new System.Windows.Forms.BindingSource()");


                    stBuilder = stBuilder.Replace("System.ComponentModel.ProgressChangedEventArgs", "ProgressChangedEventArgs");
                    stBuilder = stBuilder.Replace("ProgressChangedEventArgs", "System.ComponentModel.ProgressChangedEventArgs");
                    stBuilder = stBuilder.Replace("System.ComponentModel.DoWorkEventArgs", "DoWorkEventArgs");
                    stBuilder = stBuilder.Replace("DoWorkEventArgs", "System.ComponentModel.DoWorkEventArgs");
                    stBuilder = stBuilder.Replace("System.ComponentModel.RunWorkerCompletedEventArgs", "RunWorkerCompletedEventArgs");
                    stBuilder = stBuilder.Replace("RunWorkerCompletedEventArgs", "System.ComponentModel.RunWorkerCompletedEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewCellMouseEventArgs", "DataGridViewCellMouseEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewCellMouseEventArgs", "System.Windows.Forms.DataGridViewCellMouseEventArgs");
                    stBuilder = stBuilder.Replace("System.Windows.Forms.DataGridViewBindingCompleteEventArgs", "DataGridViewBindingCompleteEventArgs");
                    stBuilder = stBuilder.Replace("DataGridViewBindingCompleteEventArgs", "System.Windows.Forms.DataGridViewBindingCompleteEventArgs");

                    stBuilder = stBuilder.Replace(".TabPages.Remove", ".Items.Remove");


                    stBuilder = stBuilder.Replace("System.Windows.Forms.FormClosedEventArgs", "FormClosedEventArgs");
                    stBuilder = stBuilder.Replace("FormClosedEventArgs", "System.Windows.Forms.FormClosedEventArgs");
                    stBuilder = stBuilder.Replace("System.IO.Path.GetFileName", "Path.GetFileName");
                    stBuilder = stBuilder.Replace("Path.GetFileName", "System.IO.Path.GetFileName");



                    stBuilder = stBuilder.Replace(".Preview = this.previewControl1", ".Preview = this.previewControl1.WrapControl");
                    stBuilder = stBuilder.Replace(".Preview = this.previewMovtosPendientes", ".Preview = this.previewMovtosPendientes.WrapControl");
                    stBuilder = stBuilder.Replace("DialogResult dialogResult", "MessageBoxResult dialogResult");
                    stBuilder = stBuilder.Replace("(DataGridView dataGridView)", "(System.Windows.Forms.DataGridView dataGridView)");
                    stBuilder = stBuilder.Replace("DataGridViewCell currentCell", "System.Windows.Forms.DataGridViewCell currentCell");
                    stBuilder = stBuilder.Replace("DataGridViewCell nextCell", "System.Windows.Forms.DataGridViewCell nextCell");
                    stBuilder = stBuilder.Replace("(Image image, ImageFormat format)", "(System.Drawing.Image image, ImageFormat format)");
                    stBuilder = stBuilder.Replace("Image bitmap = global::", "System.Drawing.Image bitmap = global::");
                    stBuilder = stBuilder.Replace("tabControl1.Controls.Remove", "tabControl1.Items.Remove");

                    stBuilder = stBuilder.Replace("override bool applyGeneralFormBehaviour()", "bool applyGeneralFormBehaviour()");
                    stBuilder = stBuilder.Replace("rEP_FACTURAELECTRONICA_DETSystem.Windows.Forms.BindingSource", "rEP_FACTURAELECTRONICA_DETBindingSource");

                    stBuilder = stBuilder.Replace("tabControl1.TabPages", "tabControl1.Items");

                    stBuilder = stBuilder.Replace("OpenFileDialog", "System.Windows.Forms.OpenFileDialog");
                    stBuilder = stBuilder.Replace(".ShowDialog() == MessageBoxResult.OK", ".ShowDialog() == System.Windows.Forms.DialogResult.OK");
                    stBuilder = stBuilder.Replace("wf.Owner =", "//wf.Owner = ");
                    stBuilder = stBuilder.Replace("this.MaximumSize =", "//this.MaximumSize = ");
                    stBuilder = stBuilder.Replace("this.MaximizedBounds =", "//this.MaximizedBounds =");
                    stBuilder = stBuilder.Replace("configuraLaPantalla(", "//configuraLaPantalla(");
                    stBuilder = stBuilder.Replace("PreviewKeyDownEventArgs", "System.Windows.Forms.PreviewKeyDownEventArgs");
                    stBuilder = stBuilder.Replace("this.ControlBox =", "//this.ControlBox =");




                    stBuilder = stBuilder.Replace("DataGridViewImageCell", "System.Windows.Forms.DataGridViewImageCell");
                    stBuilder = stBuilder.Replace("SaveFileDialog", "System.Windows.Forms.SaveFileDialog");

                    stBuilder = stBuilder.Replace("SendKeys.Send", "//SendKeys.Send");
                    stBuilder = stBuilder.Replace("Preview = this.previewControl2", "Preview = this.previewControl2.WrapControl");

                    stBuilder = stBuilder.Replace("System.IO.Path.GetExtension", "Path.GetExtension");
                    stBuilder = stBuilder.Replace("Path.GetExtension", "System.IO.Path.GetExtension");
                    stBuilder = stBuilder.Replace("System.IO.Path.GetDirectoryName", "Path.GetDirectoryName");
                    stBuilder = stBuilder.Replace("Path.GetDirectoryName", "System.IO.Path.GetDirectoryName");

                    stBuilder = stBuilder.Replace("ref TextBox", "ref TextBoxWF");
                    stBuilder = stBuilder.Replace("DataGridViewTextBoxCell", "System.Windows.Forms.DataGridViewTextBoxCell");

                    stBuilder = stBuilder.Replace("fq.Owner = this;", "//fq.Owner = this;");

                    stBuilder = stBuilder.Replace("wf.Owner = this;", "//wf.Owner = this;");

                    stBuilder = stBuilder.Replace("CheckBox[]", "CheckBoxWF[]");
                    stBuilder = stBuilder.Replace("foreach (CheckBox cb in checkboxes)", "foreach (CheckBoxWF cb in checkboxes)");
                    stBuilder = stBuilder.Replace("foreach(CheckBox cb in checkboxes)", "foreach(CheckBoxWF cb in checkboxes)");
                    stBuilder = stBuilder.Replace("new CheckBox[]", "new CheckBoxWF[]");
                    stBuilder = stBuilder.Replace("CheckBox chBox = null;", "CheckBoxWF chBox = null;");

                    stBuilder = stBuilder.Replace("DataGridView view = (DataGridView)sender;", "//DataGridView view = (DataGridView)sender;");

                    stBuilder = stBuilder.Replace("DialogResult result = this.folderBrowserDialog1", "MessageBoxResult result = this.folderBrowserDialog1");

                    stBuilder = stBuilder.Replace("_Tick(object sender, RoutedEventArgs e)", "_Tick(object sender, EventArgs e)");

                    stBuilder = stBuilder.Replace(".System.Windows.Forms.", ".");

                    stBuilder = stBuilder.Replace("/**winforms only starts**/", "/**winforms only starts*");
                    stBuilder = stBuilder.Replace("/**wpf only starts*", "/**wpf only starts**/");

                    stBuilder = stBuilder.Replace("\n", Environment.NewLine);


                    using (StreamWriter sw = new StreamWriter(fileXAMLCS))
                    {
                        sw.Write(stBuilder);
                    }

                }





                




                string designerContent = "";

                string fileXAML = rutaFolder + fr.NOMBRE + ".xaml";

                fileExists = File.Exists(fileXAML);
                if (fileExists)
                    File.Delete(fileXAML);

                using (StreamWriter sw = new StreamWriter(fileXAML))
                {
                    Assembly asm = assemblies[fr.ENSAMBLADOID];
                    sw.Write(convertirForm(fr.NOMBRECOMPLETO, ref designerContent, fr.NOMBRE, asm, fileOrigenDesigner));
                }




                string fileXAMLDesigner = rutaFolder + fr.NOMBRE + ".xaml.Designer.cs";

                fileExists = File.Exists(fileXAMLDesigner);
                if (fileExists)
                    File.Delete(fileXAMLDesigner);

                using (StreamWriter sw = new StreamWriter(fileXAMLDesigner))
                {
                    sw.Write(designerContent);
                }




            }

            ConfigurarProyectos();

            MessageBox.Show("Faltan constructores " + strConstructoresFaltantes);
            MessageBox.Show("Faltan rutas " + strRutasNoEncontradas);


        }




        private string obtenerEventoForm(Object f, Type tipo, string clave_evento)
        {
            //typeof(Form)

            try
            {
                EventHandlerList events = (EventHandlerList)typeof(Component)
                    .GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(f, null);
                object key = tipo
                    .GetField(clave_evento, BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null);

                Delegate handlers = events[key];
                if (handlers == null)
                    return "";

                foreach (Delegate handler in handlers.GetInvocationList())
                {
                    MethodInfo method = handler.Method;
                    string name = handler.Target == null ? "" : handler.Target.ToString();
                    if (handler.Target is Control) name = ((Control)handler.Target).Name;
                    Console.WriteLine(name + "; " + method.DeclaringType.Name + "." + method.Name);


                    if (method == null || method.Name == null)
                        return "";

                    return method.Name;
                }

                return "";
            }
            catch
            {
                return "";
            }


        }



        private Dictionary<string, string> EventMetods(Object baseControl, string[] excludedEventNames = null, string[] includedEventNames = null)
        {
            Dictionary<string, string> retorno = new Dictionary<string, string>();
            Type baseType = baseControl.GetType();

            EventHandlerList events = typeof(Control).GetProperty("Events", BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic).GetValue(baseControl, null) as EventHandlerList;
            foreach (EventInfo baseEventInfo in baseType.GetEvents())
            {
                if (excludedEventNames != null && excludedEventNames.Contains(baseEventInfo.Name))
                    continue;

                if (includedEventNames != null && !includedEventNames.Contains(baseEventInfo.Name))
                    continue;

                FieldInfo field = typeof(Control).GetField("Event" + baseEventInfo.Name, BindingFlags.NonPublic | BindingFlags.Static);


                if (field == null)
                    continue;


                object eventField = field.GetValue(baseControl);

                retorno.Add(baseEventInfo.Name, "");
                if (eventField != null)
                {

                    Delegate aDel = events[eventField];
                    if (aDel != null && aDel.Method != null && aDel.Method.Name != null)
                        retorno[baseEventInfo.Name] = aDel.Method.Name;
                }
                //
                // Checking if current control has the same event..
                //
            }

            return retorno;
        }




        private Dictionary<string, string> EventToolStripButtonMetods(Object baseControl, string[] excludedEventNames = null, string[] includedEventNames = null)
        {
            Dictionary<string, string> retorno = new Dictionary<string, string>();
            Type baseType = baseControl.GetType();

            EventHandlerList events = typeof(ToolStripItem).GetProperty("Events", BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic).GetValue(baseControl, null) as EventHandlerList;
            foreach (EventInfo baseEventInfo in baseType.GetEvents())
            {
                if (excludedEventNames != null && excludedEventNames.Contains(baseEventInfo.Name))
                    continue;

                if (includedEventNames != null && !includedEventNames.Contains(baseEventInfo.Name))
                    continue;

                retorno.Add(baseEventInfo.Name, "");


                FieldInfo field = typeof(ToolStripItem).GetField("Event" + baseEventInfo.Name, BindingFlags.NonPublic | BindingFlags.Static);


                if (field == null)
                    continue;


                object eventField = field.GetValue(baseControl);

                if (eventField != null)
                {

                    Delegate aDel = events[eventField];
                    if (aDel != null && aDel.Method != null && aDel.Method.Name != null)
                        retorno[baseEventInfo.Name] = aDel.Method.Name;
                }
                //
                // Checking if current control has the same event..
                //
            }

            return retorno;
        }


        private static object GetDelegateToolStrip(Component issuer, string keyName)
        {
            // Get key value for a Click Event
            var key = issuer
                .GetType()
                .GetField(keyName, BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.FlattenHierarchy)
                .GetValue(null);
            // Get events value to get access to subscribed delegates list
            var events = typeof(Component)
                .GetField("events", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(issuer);
            // Find the Find method and use it to search up listEntry for corresponding key
            var listEntry = typeof(EventHandlerList)
                .GetMethod("Find", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(events, new object[] { key });
            if (listEntry == null)
                return null;
            // Get handler value from listEntry 
            var handler = listEntry
                .GetType()
                .GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(listEntry);
            return handler;
        }


        private string GetMethodNameOpcion3(Control ctrl, string eventname)
        {
            Delegate aDel = GetEventDelegate(ctrl, eventname);
            if (aDel != null && aDel.Method != null && aDel.Method.Name != null)
                return aDel.Method.Name;

            return "";
        }

        private Delegate GetEventDelegate(Control ctrl, string eventname)
        {
            PropertyInfo propInfo = typeof(Component).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            EventHandlerList handlerList = (EventHandlerList)propInfo.GetValue(ctrl, null);
            FieldInfo fi = null;
            Type typeControl = ctrl.GetType();
            while (!object.ReferenceEquals(typeControl, typeof(object)))
            {
                fi = typeControl.GetField(eventname, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                if (fi != null)
                {
                    break; // TODO: might not be correct. Was : Exit While
                }
                typeControl = typeControl.BaseType;
            }
            if (fi == null)
            {
                return null;
                //throw new ArgumentException("Specified event does not exist.");
            }
            object eventKey = fi.GetValue(ctrl);
            Delegate EventHandlerDelegate = eventKey as Delegate;
            if (EventHandlerDelegate == null)
            {
                return handlerList[eventKey];
            }
            return EventHandlerDelegate;
        }




        private IEnumerable<Component> EnumerateComponents(Form f)
        {
            return from field in f.GetType().GetFields(
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Component).IsAssignableFrom(field.FieldType)
                   let component = (Component)field.GetValue(f)
                   where component != null
                   //where component.GetType().GetProperty("Name") == null
                   select component;
        }



        private string winFormFontStyleToWPF(FontStyle st)
        {
            switch(st)
            {
                case FontStyle.Bold: return "Bold";
                case FontStyle.Underline: return "Underline";
                default: return "Normal";
            }

        }


        private string winFormFontSizeToWPF(float st)
        {
            return (st * (96.0 / 72.0)).ToString();

        }



        private string convertirForm(string formName, ref string designerContent, string shortName, Assembly asm, string fileDesigner)
        {

            string strContent = "";
            //Assembly asm = Assembly.GetEntryAssembly();
            Form f = null;

            try
            {

                f = (Form)asm.CreateInstance(formName);
            }
            catch(Exception ex)
            {
                strConstructoresFaltantes += " , " +  formName;
                return "";
            }


            /*Data sets and binding source start*/
            string xmlnsData = "";
            string windResData = "";
            string codeHdrData = "";
            string codeLoadData = "";
            formBindDict = new Dictionary<string, BindingSource>();

            convierteDataElements(f, ref xmlnsData, ref windResData, ref codeHdrData, ref codeLoadData, ref formBindDict, fileDesigner);



            string strFormNameSpace = "";
            string[] strBufferFormNameSpace = f.GetType().ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i <= strBufferFormNameSpace.Length - 2; i++)
            {
                if (i == 0)
                    strFormNameSpace = strBufferFormNameSpace[i];
                else
                    strFormNameSpace += "." + strBufferFormNameSpace[i];
            }

            designerContent = "using System.Text;\nusing System.Windows;\nusing System.Windows.Controls;\nusing System.Windows.Data;\nusing System.Windows.Documents;\nusing System.Windows.Input;\nusing System.Windows.Media;\nusing System.Windows.Media.Imaging;\nusing System.Windows.Shapes;\n\nusing WPFMigrating;\nusing WPFMigrate.Tools;\n\nnamespace " + strFormNameSpace + "\n{\n    public partial class " + shortName + " : Form\n    {\n        /*CODE HEADER DATA ELEMENTS*/\n        protected override void OnLoad(object sender, RoutedEventArgs e)\n        {\n            /*CODE LOAD DATA ELEMENTS*/\n            /*TEST CODE*/\n        }\n    }\n\n}";

            designerContent = designerContent.Replace("/*CODE HEADER DATA ELEMENTS*/", codeHdrData);
            designerContent = designerContent.Replace("/*CODE LOAD DATA ELEMENTS*/", codeLoadData);
            designerContent = designerContent.Replace("\n", Environment.NewLine);


            /*Data sets and binding source end*/


            string strShockWaveXmlns = shortName.Contains("WFPuntoDeVenta") ? "      xmlns:Ax=\"clr-namespace:AxShockwaveFlashObjects;assembly=AxInterop.ShockwaveFlashObjects\"\n" : "";

            string xamlFormMolde = "<src:Form x:Class=\"" + formName + "\"\n        xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n        xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n   xmlns:src=\"clr-namespace:WPFMigrating;assembly=WPFMigrating\"  \n     xmlns:Tools=\"clr-namespace:WPFMigrate.Tools;assembly=WPFMigrating\"\n        xmlns:rv=\"clr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms\"\n      xmlns:WinForms=\"clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms\"\n" + strShockWaveXmlns + "      xmlns:FastReport=\"clr-namespace:dotLinkControlsWpf.FastReport;assembly=dotLinkControlsWpf\" \n<!-- XMLNSDATA -->  \n       Title=\"" + f.Text + "\" Height=\"" + f.Size.Height + "\" Width=\"" + f.Size.Width + "\"  Icon=\"/Resources/i-pos.ico\"  <!-- Events form --> >\n  <Window.Resources> \n <!-- WINDRESDATA -->\n</Window.Resources>   \n   <Grid  Background=\"{DynamicResource WindowBackgroundBrush}\">\n        <!-- Content XAML -->\n    </Grid>\n</src:Form>\n";

            strContent += convierteControles(f.Controls, f.Name);

            xamlFormMolde = xamlFormMolde.Replace("<!-- Content XAML -->", strContent);

            string strEvents = "";
            string eventNameLoad = obtenerEventoForm(f, typeof(Form), "EVENT_LOAD");
            string eventNameShown = obtenerEventoForm(f, typeof(Form), "EVENT_SHOWN");
            string eventNameClosing = obtenerEventoForm(f, typeof(Form), "EVENT_FORMCLOSING");


            if (eventNameLoad != null && eventNameLoad != "")
            {
                strEvents += " Loaded=\"" + eventNameLoad + "\"";
            }
            if (eventNameShown != null && eventNameShown != "")
            {
                strEvents += " Shown=\"" + eventNameShown + "\"";
            }
            if (eventNameClosing != null && eventNameClosing != "")
            {
                strEvents += " ClosingWF=\"" + eventNameClosing + "\"";
            }

            xamlFormMolde = xamlFormMolde.Replace("<!-- Events form -->", strEvents);

            xamlFormMolde = xamlFormMolde.Replace("<!-- XMLNSDATA -->", xmlnsData);
            xamlFormMolde = xamlFormMolde.Replace("<!-- WINDRESDATA -->", windResData);

            return xamlFormMolde.Replace("\n", Environment.NewLine);
        }




        private string convierteDataElements(Form f, ref string xmlns, ref string windRes, ref string codeHdr, ref string codeLoad, ref Dictionary<string, BindingSource> bindDict, string fileDesigner)
        {


            string strA = "";

            FieldInfo[] pInfoArray = f.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Dictionary<string, DataSet> dataSetDict = new Dictionary<string, DataSet>();
            Dictionary<string, string> tableAdapterBind = new Dictionary<string, string>();
            Dictionary<string, string> dataSetBind = new Dictionary<string, string>();
            Dictionary<string, FbCommand> fbCommandDict = new Dictionary<string, FbCommand>();
            Dictionary<string, FbConnection> fbConnectionDict = new Dictionary<string, FbConnection>();
            Dictionary<string, OpenFileDialog> openFileDialogDict = new Dictionary<string, OpenFileDialog>();
            Dictionary<string, FolderBrowserDialog> folderBrowserDialogDict = new Dictionary<string, FolderBrowserDialog>();
            Dictionary<string, SaveFileDialog> saveFileDialogDict = new Dictionary<string, SaveFileDialog>();
            Dictionary<string, CustomValidation.RequiredFieldValidator> rfvDict = new Dictionary<string, CustomValidation.RequiredFieldValidator>();


            Dictionary<string, ReportViewer> reportViewerDict = new Dictionary<string, ReportViewer>();


            Dictionary<string, BackgroundWorker> bgWorkerDict = new Dictionary<string, BackgroundWorker>();
            Dictionary<string, Timer> timerDict = new Dictionary<string, Timer>();
            
            //Dictionary<string, ProgressBar> pgBarDict = new Dictionary<string, ProgressBar>();

            Dictionary<string, FastReport.Report> frDict = new Dictionary<string, FastReport.Report>();

            Dictionary<string, DataGridView> dataGrids = new Dictionary<string, DataGridView>();
            Dictionary<string, string> dataGridDataBind = new Dictionary<string, string>();
            List<string> dataGridTextBoxColumns = new List<string>();
            List<string> dataGridButtonColumns = new List<string>();
            List<string> dataGridCheckBoxColumns = new List<string>();
            List<string> dataGridImageColumns = new List<string>();



            Dictionary<string, TextBoxFB> textBoxFbDict = new Dictionary<string, TextBoxFB>();

            buttonImgDictCurrentForm = new Dictionary<string, string>();


            DataSet ds;
            BindingSource db;
            DataGridView dg;

            Dictionary<string, string> strType = new Dictionary<string, string>();
            foreach (FieldInfo pi in pInfoArray)
            {


                if (pi.FieldType.IsSubclassOf(typeof(System.Data.DataSet)))
                {
                    ds = pi.GetValue(f) as DataSet;

                    if (ds != null)
                    {
                        dataSetDict.Add(pi.Name, ds);
                    }
                }



                if (pi.FieldType.IsAssignableFrom(typeof(BindingSource)))
                {

                    db = pi.GetValue(f) as BindingSource;

                    if (db != null)
                    {
                        bindDict.Add(pi.Name, db);
                    }
                }


                if (pi.FieldType.IsAssignableFrom(typeof(DataGridView)) || pi.FieldType.IsSubclassOf(typeof(DataGridView)))
                {
                    dg =  pi.GetValue(f) as DataGridView;
                    dataGrids.Add(pi.Name, dg);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(DataGridViewTextBoxColumn)) || pi.FieldType.IsSubclassOf(typeof(DataGridViewTextBoxColumn)))
                {
                    dataGridTextBoxColumns.Add(pi.Name);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(DataGridViewButtonColumn)) || pi.FieldType.IsSubclassOf(typeof(DataGridViewButtonColumn)))
                {
                    dataGridButtonColumns.Add(pi.Name);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(DataGridViewCheckBoxColumn)) || pi.FieldType.IsSubclassOf(typeof(DataGridViewCheckBoxColumn)))
                {
                    dataGridCheckBoxColumns.Add(pi.Name);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(DataGridViewImageColumn)) || pi.FieldType.IsSubclassOf(typeof(DataGridViewImageColumn)))
                {
                    dataGridImageColumns.Add(pi.Name);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(FbCommand)))
                {
                    fbCommandDict.Add(pi.Name, pi.GetValue(f) as FbCommand);
                }


                if (pi.FieldType.IsAssignableFrom(typeof(FbConnection)))
                {
                    fbConnectionDict.Add(pi.Name, pi.GetValue(f) as FbConnection);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(OpenFileDialog)))
                {
                    openFileDialogDict.Add(pi.Name, pi.GetValue(f) as OpenFileDialog);
                }

                
                if (pi.FieldType.IsAssignableFrom(typeof(SaveFileDialog)))
                {
                    saveFileDialogDict.Add(pi.Name, pi.GetValue(f) as SaveFileDialog);
                }

                

                if (pi.FieldType.IsAssignableFrom(typeof(FolderBrowserDialog)))
                {
                    folderBrowserDialogDict.Add(pi.Name, pi.GetValue(f) as FolderBrowserDialog);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(CustomValidation.RequiredFieldValidator)))
                {
                    rfvDict.Add(pi.Name, pi.GetValue(f) as CustomValidation.RequiredFieldValidator);
                }


                if (pi.FieldType.IsAssignableFrom(typeof(BackgroundWorker)))
                {
                    bgWorkerDict.Add(pi.Name, pi.GetValue(f) as BackgroundWorker);
                }

                if (pi.FieldType.IsAssignableFrom(typeof(Timer)))
                {
                    timerDict.Add(pi.Name, pi.GetValue(f) as Timer);
                }


                /*
                if (pi.FieldType.IsAssignableFrom(typeof(ProgressBar)))
                {
                    pgBarDict.Add(pi.Name, pi.GetValue(f) as ProgressBar);
                }*/

                if (pi.FieldType.IsAssignableFrom(typeof(FastReport.Report)))
                {
                    frDict.Add(pi.Name, pi.GetValue(f) as FastReport.Report);
                }


                if (pi.FieldType.IsAssignableFrom(typeof(ReportViewer)))
                {
                    reportViewerDict.Add(pi.Name, pi.GetValue(f) as ReportViewer);
                }


                if (!strType.ContainsKey(pi.FieldType.ToString()))
                    strType.Add(pi.FieldType.ToString(), pi.Name);

                
                if (pi.FieldType == typeof(TextBoxFB))
                {
                    textBoxFbDict.Add(pi.Name, pi.GetValue(f) as TextBoxFB);
                }



                if (pi.FieldType == typeof(Button) || pi.FieldType == typeof(PictureBox)
                    || pi.FieldType.IsSubclassOf(typeof(Button)) || pi.FieldType.IsSubclassOf(typeof(PictureBox)))
                {
                    buttonImgDictCurrentForm.Add(pi.Name, "");
                }
                

                

            }

            foreach (string strDict in bindDict.Keys)
            {
                db = bindDict[strDict] as BindingSource;
                foreach (string strDs in dataSetDict.Keys)
                {
                    ds = dataSetDict[strDs] as DataSet;

                    if (db.DataSource == ds)
                    {
                        dataSetBind.Add(strDict, strDs);
                        break;
                    }


                }
            }



            foreach (string strGrid in dataGrids.Keys)
            {
                dg = dataGrids[strGrid] as DataGridView;
                foreach (string strDict in bindDict.Keys)
                {
                    db = bindDict[strDict] as BindingSource;

                    if (dg.DataSource == db)
                    {
                        dataGridDataBind.Add(strGrid, strDict);
                        break;
                    }


                }
            }

            foreach (string strDict in dataSetBind.Keys)
            {
                string strDs = dataSetBind[strDict];

                db = bindDict[strDict] as BindingSource;
                ds = dataSetDict[strDs] as DataSet;

                string strRuta = ds.GetType().ToString() + "TableAdapters." + db.DataMember + "TableAdapter";

                int iCount = 0;
                foreach (string sType in strType.Keys)
                {
                    if (sType == strRuta)
                    {
                        tableAdapterBind.Add(strDict, strType[sType]);
                    }
                }
            }




            string strCat = "";
            string strBind = "";

            string strCodHdrCat = "";
            string strCodHdrBS = "";
            string strCodLoadCat = "";
            string strCodLoadBS = "";


            List<string> xmlnsArray = new List<string>();
            List<string> dsArray = new List<string>();

            foreach (string strDict in dataSetBind.Keys)
            {
                string strDs = dataSetBind[strDict];
                db = bindDict[strDict] as BindingSource;
                ds = dataSetDict[strDs] as DataSet;

                if (!tableAdapterBind.Keys.Contains(strDict))
                {
                    continue;
                }

                string strDataSetFullType = ds.GetType().ToString();
                string strTagName = "";
                string strDataSetNameSpace = "";
                string strDataSetClassName = "";
                string strDataMember = db.DataMember;
                string strTableAdapterFullType = ds.GetType().ToString() + "TableAdapters." + db.DataMember + "TableAdapter";
                string strTableAdapterName = tableAdapterBind[strDict];


                string[] strBufferTag = strDataSetFullType.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (strBufferTag == null || strBufferTag.Length <= 1)
                    continue;

                strDataSetClassName = strBufferTag[strBufferTag.Length - 1];
                strTagName = strBufferTag[strBufferTag.Length - 2];


                for (int i = 0; i <= strBufferTag.Length - 2; i++)
                {
                    if (i == 0)
                    {
                        strDataSetNameSpace = strBufferTag[i];
                    }
                    else
                    {
                        strDataSetNameSpace += "." + strBufferTag[i];
                    }

                }

                string xmlnsTemp = "\nxmlns:" + strTagName + "=\"clr-namespace:" + strDataSetNameSpace + "\"";
                string strCatTemp = "\n<" + strTagName + ":" + strDataSetClassName + " x:Key=\"" + strDs + "\"  />";
                string strBindTemp = "\n        <src:CollectionViewSourceWF x:Key=\"" + strDict + "\" Source=\"{Binding " + strDataMember + ", Source={StaticResource " + strDs + "}}\"/>\n";

                string strCodHdrTempCat = "\n" + strDataSetFullType + " " + strDs + ";";
                string strCodHdrTempBS = "\n" + strTableAdapterFullType + " " + strTableAdapterName + ";\n        CollectionViewSourceWF " + strDict + ";";
                string strCodLoadTempCat = "\n" + strDs + " = ((" + strDataSetFullType + ")(this.FindResource(\"" + strDs + "\")));";
                string strCodLoadTempBS = "\n" + strTableAdapterName + " = new " + strTableAdapterFullType + "();\n        " + strDict + " = ((CollectionViewSourceWF)(this.FindResource(\"" + strDict + "\")));\n        " + strDict + ".View.MoveCurrentToFirst();";


                if (!xmlnsArray.Contains(xmlnsTemp))
                {
                    xmlns += xmlnsTemp;

                    xmlnsArray.Add(xmlnsTemp);

                }

                if(!dsArray.Contains(strCatTemp))
                {

                    strCat += strCatTemp;

                    strCodHdrCat += strCodHdrTempCat;
                    strCodLoadCat += strCodLoadTempCat;

                    dsArray.Add(strCatTemp);
                }

                strBind += strBindTemp;
                strCodLoadBS += strCodLoadTempBS;
                strCodHdrBS += strCodHdrTempBS;


            }


            foreach (string strDict in bindDict.Keys)
            {
                if (!dataSetBind.Keys.Contains(strDict))
                {
                    string strBindTemp = "\n        <src:CollectionViewSourceWF x:Key=\"" + strDict + "\" />\n";
                    string strCodHdrTempBS = "\n CollectionViewSourceWF " + strDict + ";";
                    string strCodLoadTempBS = "\n        " + strDict + " = ((CollectionViewSourceWF)(this.FindResource(\"" + strDict + "\")));";

                    strBind += strBindTemp;
                    strCodLoadBS += strCodLoadTempBS;
                    strCodHdrBS += strCodHdrTempBS;


                }

            }


            windRes = strCat + strBind;
            codeHdr = strCodHdrCat + strCodHdrBS;
            codeLoad = strCodLoadCat + strCodLoadBS;


            string lastCodeLoadDataGrid = "";
            string lastCodeLoadBackGroundWorker = "";
            string lastCodeLoadTimer = "";

            string lastCodeLoadRdlc = "";
            

            // copia los cellstyle del constructor de grids
           using (StreamReader sr = new StreamReader(fileDesigner))
           {
                    StringBuilder stBuilder = new StringBuilder(sr.ReadToEnd());
                    stBuilder = stBuilder.Replace(Environment.NewLine, "\n");
                    string[] strLines = stBuilder.ToString().Split(new string[]{"\n"},StringSplitOptions.RemoveEmptyEntries);
                    foreach(string str in strLines)
                    {
                        if(str.Contains("DataGridViewCellStyle"))
                        {
                            codeLoad += "\n" + str;
                        }
                    }


                    string strForeColorHdrGrid = ".ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));";
                    string strBackColorHdrGrid = ".BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));";

                    lastCodeLoadDataGrid += obtenLineasDesignerPorElemento(strLines, dataGrids.Keys.ToList(), true, true, false, strForeColorHdrGrid, strBackColorHdrGrid);
                    lastCodeLoadDataGrid += obtenLineasDesignerPorElemento(strLines, dataGridTextBoxColumns, false, false, false, "", "");
                    lastCodeLoadDataGrid += obtenLineasDesignerPorElemento(strLines, dataGridImageColumns, false, false, false, "", "");
                    lastCodeLoadDataGrid += obtenLineasDesignerPorElemento(strLines, dataGridCheckBoxColumns, false, false, false, "", "");
                    lastCodeLoadDataGrid += obtenLineasDesignerPorElemento(strLines, dataGridButtonColumns, false, false, false, "", "");


                    lastCodeLoadBackGroundWorker += obtenLineasDesignerPorElemento(strLines, bgWorkerDict.Keys.ToList(), false, false, false, "", "");

                    lastCodeLoadTimer += obtenLineasDesignerPorElemento(strLines, timerDict.Keys.ToList(), false, false, false, "", "");

                    //lastCodeLoadRdlc += obtenLineasDesignerContengan(strLines, "Microsoft.Reporting.WinForms.ReportDataSource");
                    lastCodeLoadRdlc += obtenLineasDesignerPorElemento(strLines, reportViewerDict.Keys.ToList(), true, true, true, "", "");

                    obtenImagenesPorElemento(strLines, ref buttonImgDictCurrentForm);
                    



            }


            
            foreach (string str in dataGrids.Keys)
            {
                /*
                string strCodeGridDefinition = "\n System.Windows.Forms.DataGridView " + str + ";";
                string strCodeGridInitializacion = "\n " + str + " = new System.Windows.Forms.DataGridViewSum();\n " +  str + "_Host.Child = " + str + " ;";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;*/

                if(!dataGridDataBind.Keys.Contains(str))
                {
                    continue;
                }

                DataGridView dgv = dataGrids[str];
                BindingSource bsb = bindDict[dataGridDataBind[str]];

                string dsName = "";
                if(dataSetBind.Keys.Contains(dataGridDataBind[str]))
                {
                    dsName = dataSetBind[dataGridDataBind[str]];
                }
                else
                {
                    foreach(string keyds in dataSetDict.Keys)
                    {
                        DataSet dts = dataSetDict[keyds];
                        if(dts == bsb.DataSource)
                        {
                            dsName = keyds;
                            break;
                        }
                    }
                }

                if (dsName != "")
                {

                    string strCodeGridInitializacion = "\n      System.Windows.Forms.BindingSource " + str + "BindingSource = new System.Windows.Forms.BindingSource();\n      " + str + "BindingSource.DataMember = \"" + bsb.DataMember + "\";\n      " + str + "BindingSource.DataSource = " + dsName + ";\n      " + str + ".DataSource = " + str + "BindingSource;";
                    codeLoad += strCodeGridInitializacion;
                }

            }




            foreach (string str in dataGridTextBoxColumns)
            {
                string strCodeGridDefinition = "\n System.Windows.Forms.DataGridViewTextBoxColumn " + str + ";";
                string strCodeGridInitializacion = "\n " + str + " = new System.Windows.Forms.DataGridViewTextBoxColumn();";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            foreach (string str in dataGridButtonColumns)
            {
                string strCodeGridDefinition = "\n System.Windows.Forms.DataGridViewButtonColumn " + str + ";";
                string strCodeGridInitializacion = "\n " + str + " = new System.Windows.Forms.DataGridViewButtonColumn();";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }

            foreach (string str in dataGridImageColumns)
            {
                string strCodeGridDefinition = "\n System.Windows.Forms.DataGridViewImageColumn " + str + ";";
                string strCodeGridInitializacion = "\n " + str + " = new System.Windows.Forms.DataGridViewImageColumn();";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }

            foreach (string str in dataGridCheckBoxColumns)
            {
                string strCodeGridDefinition = "\n System.Windows.Forms.DataGridViewCheckBoxColumn " + str + ";";
                string strCodeGridInitializacion = "\n " + str + " = new System.Windows.Forms.DataGridViewCheckBoxColumn();";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            codeLoad += lastCodeLoadDataGrid;





            /*Dictionary<string, FbCommand> fbCommandDict = new Dictionary<string, FbCommand>();
            Dictionary<string, FbConnection> fbConnectionDict = new Dictionary<string, FbConnection>();
            Dictionary<string, OpenFileDialog> openFileDialogDict = new Dictionary<string, OpenFileDialog>();
            Dictionary<string, CustomValidation.RequiredFieldValidator> rfvDict = new Dictionary<string, CustomValidation.RequiredFieldValidator>();
            */

            int iCountParam = 0;
            foreach (string str in fbCommandDict.Keys)
            {
                FbCommand obj = fbCommandDict[str];
                string connection = "";

                foreach (string strConn in fbConnectionDict.Keys)
                {
                    if (fbConnectionDict[strConn] == obj.Connection)
                    {
                        connection = strConn;
                        break;
                    }
                }


                string strCodeGridDefinition = "\n  private FirebirdSql.Data.FirebirdClient.FbCommand " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new FirebirdSql.Data.FirebirdClient.FbCommand();\n            this." + str + ".CommandText = \"" + obj.CommandText + "\";\n            this." + str + ".CommandTimeout = " + obj.CommandTimeout.ToString() + ";\n            this." + str + ".Connection = this." + connection + ";\n";

                foreach (FbParameter p in obj.Parameters)
                {
                    iCountParam++;
                    string strParamInitialization = "\nFirebirdSql.Data.FirebirdClient.FbParameter fbParameter" + iCountParam.ToString() + " = new FirebirdSql.Data.FirebirdClient.FbParameter();\n  fbParameter" + iCountParam.ToString() + ".ParameterName = \"" + p.ParameterName + "\";\n            this.FbCommand1.Parameters.Add(  fbParameter" + iCountParam.ToString() + ");";
                    strCodeGridInitializacion += strParamInitialization;
                }

                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            foreach (string str in fbConnectionDict.Keys)
            {
                FbConnection obj = fbConnectionDict[str];
                string strCodeGridDefinition = "\n  private FirebirdSql.Data.FirebirdClient.FbConnection " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new FirebirdSql.Data.FirebirdClient.FbConnection();\n      this." + str + ".ConnectionString = \"" + obj.ConnectionString + "\";";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            foreach (string str in openFileDialogDict.Keys)
            {
                OpenFileDialog obj = openFileDialogDict[str];
                string strCodeGridDefinition = "\n  internal System.Windows.Forms.OpenFileDialog " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new System.Windows.Forms.OpenFileDialog();\n            this." + str + ".FileName = \"" + str + "\";\n            this." + str + ".Filter = \"" + obj.Filter + "\";";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            foreach (string str in folderBrowserDialogDict.Keys)
            {
                FolderBrowserDialog obj = folderBrowserDialogDict[str];
                string strCodeGridDefinition = "\n  internal System.Windows.Forms.FolderBrowserDialog " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new System.Windows.Forms.FolderBrowserDialog();";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }



            foreach (string str in saveFileDialogDict.Keys)
            {
                SaveFileDialog obj = saveFileDialogDict[str];
                string strCodeGridDefinition = "\n  internal System.Windows.Forms.SaveFileDialog " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new System.Windows.Forms.SaveFileDialog();\n            this." + str + ".FileName = \"" + str + "\";\n            this." + str + ".Filter = \"" + obj.Filter + "\";";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }

            foreach (string str in rfvDict.Keys)
            {
                CustomValidation.RequiredFieldValidator obj = rfvDict[str];
                string strCodeGridDefinition = "\n  private CustomValidation.RequiredFieldValidator " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new CustomValidation.RequiredFieldValidator();\n            this." + str + ".Enabled = false;\n            this." + str + ".Icon = null;";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            foreach (string str in bgWorkerDict.Keys)
            {
                BackgroundWorker obj = bgWorkerDict[str];

                if (obj == null)
                    continue;

                string strCodeGridDefinition = "\n   System.ComponentModel.BackgroundWorker " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new System.ComponentModel.BackgroundWorker();\n";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }

            codeLoad += lastCodeLoadBackGroundWorker;



            foreach (string str in timerDict.Keys)
            {
                Timer obj = timerDict[str];

                if (obj == null)
                    continue;

                string strCodeGridDefinition = "\n   System.Windows.Forms.Timer " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new System.Windows.Forms.Timer();\n";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }

            codeLoad += lastCodeLoadTimer;


           /* foreach (string str in pgBarDict.Keys)
            {
                ProgressBar obj = pgBarDict[str];


                if (obj == null)
                    continue;

                string strCodeGridDefinition = "\n   System.Windows.Forms.ProgressBar " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new System.Windows.Forms.ProgressBar();\n";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }*/


            foreach (string str in frDict.Keys)
            {
                FastReport.Report obj = frDict[str];
                string strCodeGridDefinition = "\n   FastReport.Report " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new FastReport.Report();\n";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }


            foreach (string str in dataSetDict.Keys)
            {

                if (dataSetBind.Values.Contains(str))
                    continue;

                DataSet obj = dataSetDict[str];

                string strDataSetFullType = obj.GetType().ToString();
                string strTagName = "";
                string strDataSetNameSpace = "";
                string strDataSetClassName = "";


                string[] strBufferTag = strDataSetFullType.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (strBufferTag == null || strBufferTag.Length <= 1)
                    continue;

                strDataSetClassName = strBufferTag[strBufferTag.Length - 1];
                strTagName = strBufferTag[strBufferTag.Length - 2];


                
                for (int i = 0; i <= strBufferTag.Length - 2; i++)
                {
                    if (i == 0)
                    {
                        strDataSetNameSpace = strBufferTag[i];
                    }
                    else
                    {
                        strDataSetNameSpace += "." + strBufferTag[i];
                    }

                }

                string strCodeGridDefinition = "\n  "   + strDataSetFullType + " " + str + ";";
                string strCodeGridInitializacion = "\n            this." + str + " = new " + strDataSetFullType + "();\n";
                codeHdr += strCodeGridDefinition;
                codeLoad += strCodeGridInitializacion;
            }

            foreach (string strDict in dataSetBind.Keys)
            {
                BindingSource objBs = bindDict[strDict] as BindingSource;

                


                if (!tableAdapterBind.Keys.Contains(strDict))
                {
                    string strCodeGridDefinition = "\n      CollectionViewSourceWF " + strDict + ";";
                    string strCodeGridInitializacion = "\n      " + strDict + " = new CollectionViewSourceWF();";
                    codeHdr += strCodeGridDefinition;
                    codeLoad += strCodeGridInitializacion;

		        }

                bool bDataSetYaDeclarado = false;

                foreach(string str in tableAdapterBind.Keys)
                {
                    if (dataSetBind[str] == dataSetBind[strDict])
                   {
                       bDataSetYaDeclarado = true;
                   }
                }


                if (!tableAdapterBind.Keys.Contains(strDict) && !bDataSetYaDeclarado)
                {
                    DataSet obj = dataSetDict[dataSetBind[strDict]];
                    string strDataSetFullType = obj.GetType().ToString();
                    string strTagName = "";
                    string strDataSetNameSpace = "";
                    string strDataSetClassName = "";


                    string[] strBufferTag = strDataSetFullType.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (strBufferTag == null || strBufferTag.Length <= 1)
                        continue;

                    strDataSetClassName = strBufferTag[strBufferTag.Length - 1];
                    strTagName = strBufferTag[strBufferTag.Length - 2];

                    for (int i = 0; i <= strBufferTag.Length - 2; i++)
                    {
                        if (i == 0)
                        {
                            strDataSetNameSpace = strBufferTag[i];
                        }
                        else
                        {
                            strDataSetNameSpace += "." + strBufferTag[i];
                        }

                    }




                    string strDs = dataSetBind[strDict];

                    string strCodeGridDefinition = "\n  " + strDataSetFullType + " " + strDs + ";";
                    string strCodeGridInitializacion = "\n            this." + strDs + " = new " + strDataSetFullType + "();\n";
                    codeHdr += strCodeGridDefinition;
                    codeLoad += strCodeGridInitializacion;
                }




                


	        }


            foreach (string str in textBoxFbDict.Keys)
            {
                TextBoxFB obj = textBoxFbDict[str];

                string strCodeGridInitializacion = "";

                if(obj.LabelDescription != null)
                    strCodeGridInitializacion += "\n            this." + str + ".LabelDescription = " + obj.LabelDescription.Name + ";\n";
                
                if(obj.BotonLookUp != null)
                    strCodeGridInitializacion += "\n            this." + str + ".BotonLookUp = " + obj.BotonLookUp.Name + ";\n";
                
                codeLoad += strCodeGridInitializacion;
            }






            string strCodeLBErrorDefinition = "\n  LabelWF LBError;";
            string strCodeLBErrorInitializacion = "\n            this.LBError = new LabelWF();\n";
            codeHdr += strCodeLBErrorDefinition;
            codeLoad += strCodeLBErrorInitializacion;




            codeLoad += lastCodeLoadRdlc;
            foreach (string str in reportViewerDict.Keys)
            {
                ReportViewer rv = reportViewerDict[str] as ReportViewer;

                int iCountRds = 0;
                foreach (ReportDataSource rds in rv.LocalReport.DataSources)
                {
                    
                    BindingSource bsb = null;
                    string bsbName = "";
                    foreach(string bsName in bindDict.Keys )
                    {
                        BindingSource bs = bindDict[bsName] as BindingSource;
                        if(rds.Value == bs)
                        {
                            bsb = bs;
                            break;
                        }
                    }

                    if (bsb == null)
                        continue;

                    

                    //BindingSource bsb = bindDict[dataGridDataBind[str]];

                    string dsName = "";
                    foreach (string keyds in dataSetDict.Keys)
                    {
                            DataSet dts = dataSetDict[keyds];
                            if (dts == bsb.DataSource)
                            {
                                dsName = keyds;
                                break;
                            }
                    }
                   

                    if (dsName != "")
                    {

                        string strNameBs = str + "_" + iCountRds.ToString() + "_" + "BindingSource";
                        string strNameRds = str + "_" + iCountRds.ToString() + "_" + "ReportingDataSource";

                        string strCodeGridInitializacion = "\n      System.Windows.Forms.BindingSource " + strNameBs + " = new System.Windows.Forms.BindingSource();\n      " + strNameBs + ".DataMember = \"" + bsb.DataMember + "\";\n      " + strNameBs + ".DataSource = " + dsName + ";";
                        strCodeGridInitializacion += "\n      Microsoft.Reporting.WinForms.ReportDataSource " + strNameRds + "  = new Microsoft.Reporting.WinForms.ReportDataSource();\n      " + strNameRds + ".Name = \"" + rds.Name + "\";\n      " + strNameRds + ".Value = " + strNameBs + ";";
                        strCodeGridInitializacion += "\n      this." + str + ".LocalReport.DataSources.Add(" + strNameRds + ");";


                        codeLoad += strCodeGridInitializacion;
                    }
                    iCountRds++;



                }

                codeLoad += "\n      " + str + ".RefreshReport();";

            }




            return "";
        }


        private string obtenLineasDesignerContengan(string[] lines, string strCadena)
        {
            string strReturn = "";


            foreach (string str in lines)
            {

                if(str.Contains(strCadena))
                {
                    strReturn += "\n" + str;
                }
            }

            return strReturn;


        }

        private string obtenLineasDesignerPorElemento(string[] lines, List<string> elementos, bool evitarUbicacionYTamanio, bool evitarDataSource, bool contenganNombreElemento, string noContengan1, string noContengan2)
        {

            string strReturn = "";

            bool bFlag = false;
            int iCountComent = 0;
            foreach (string strGrid in elementos)
            {
                bFlag = false;
                iCountComent = 0;
                foreach (string str in lines)
                {
                    if (!bFlag)
                    {
                        if (str.EndsWith("// " + strGrid ))
                        {
                            bFlag = true;
                            iCountComent = 0;

                            string strToAdd = str;
                            if (str.Contains("EnterKeyDownEvent") || str.Contains("Sort") || str.Contains("Leave"))
                            {
                                strToAdd = strToAdd.Replace("new System.EventHandler", "new System.Windows.RoutedEventHandler");
                            }

                            strReturn += "\n" + strToAdd;
                        }
                    }
                    else
                    {
                        if (str.Contains("//") )
                        {
                            if (iCountComent > 0)
                                break;
                            else
                                iCountComent++;
                            
                        }

                        if (str.Contains("System.ComponentModel.ISupportInitialize"))
                        {
                            break;
                        }

                        if (evitarUbicacionYTamanio &&
                            (str.Contains(".Size = new System.Drawing.Size") || str.Contains(".Location = new System.Drawing.Point") || str.Contains(".Dock = System.Windows.Forms.DockStyle.")))
                        {
                            continue;
                        }

                        if(evitarDataSource &&
                            (str.Contains(".DataSource = ") || str.Contains(".DataSources.Add")))
                        {
                            continue;
                        }

                        


                        if (contenganNombreElemento &&
                            (!str.Contains("this." + strGrid)))
                        {
                            continue;
                        }

                        if(noContengan1 != null && noContengan1.Length > 0 && str.Contains(noContengan1))
                        {
                            continue;
                        }



                        if (noContengan2 != null && noContengan2.Length > 0 && str.Contains(noContengan2))
                        {
                            continue;
                        }

                        string strToAdd = str;
                        if (str.Contains("EnterKeyDownEvent") || str.Contains("Sort") || str.Contains("Leave"))
                        {
                            strToAdd = strToAdd.Replace("new System.EventHandler", "new System.Windows.RoutedEventHandler");
                        }

                        strReturn += "\n" + strToAdd;
                    }
                }
            }

            return strReturn;


        }





        private string obtenImagenesPorElemento(string[] lines, ref Dictionary<string, string> imgedControls)
        {

            string strReturn = "";

            bool bFlag = false;
            int iCountComent = 0;

            List<String> strKeys = new List<String>();
            strKeys.AddRange(imgedControls.Keys);

            foreach (string strGrid in strKeys)
            {
                bFlag = false;
                iCountComent = 0;
                
                foreach (string str in lines)
                {
                    if (!bFlag)
                    {
                        if (str.EndsWith("// " + strGrid))
                        {
                            bFlag = true;
                            iCountComent = 0;

                        }
                    }
                    else
                    {
                        if (str.Contains("//"))
                        {
                            if (iCountComent > 0)
                                break;
                            else
                                iCountComent++;

                        }

                        if (str.Contains("System.ComponentModel.ISupportInitialize"))
                        {
                            break;
                        }



                        string strToAdd = str;
                        if (str.Contains(".Image = global::") || str.Contains(".BackgroundImage = global::"))
                        {
                            imgedControls[strGrid] = str;
                            break;
                        }

                    }
                }
            }

            return strReturn;


        }


        private string convierteControles(Control.ControlCollection controls)
        {
            return convierteControles(controls, null);
        }

        private string convierteControles(Control.ControlCollection controls, string formName)
        {
            string strContent = "";


            foreach (Control c in controls)
            {
                if (c is ToolStrip && !(c is MenuStrip))
                {
                    strContent += "\n" + convierteToolStrip((ToolStrip)c);
                }
            }

            foreach (Control c in controls)
            {
                if (c is Label)
                {
                    strContent += "\n" + convierteLabel((Label)c);
                }
                else if (c is TextBoxFB)
                {
                    strContent += "\n" + convierteTextBoxFB((TextBoxFB)c);
                }
                else if (c is TextBoxFBRpt)
                {
                    strContent += "\n" + convierteTextBoxFBRpt((TextBoxFBRpt)c);
                }
                else if (c is NumericUpDown)
                {
                    strContent += "\n" + convierteNumericUpDown((NumericUpDown)c);
                }
                else if (c is NumericTextBox)
                {
                    strContent += "\n" + convierteNumericTextBox((NumericTextBox)c);
                }
                else if (c is TextBoxET)
                {
                    strContent += "\n" + convierteTextBoxET((TextBoxET)c, formName);
                }
                else if (c is TextBoxETRpt)
                {
                    strContent += "\n" + convierteTextBoxETRpt((TextBoxETRpt)c);
                }
                else if (c is TextBox)
                {
                    strContent += "\n" + convierteTextBox((TextBox)c, formName);
                }
                else if (c is Button)
                {
                    strContent += "\n" + convierteButton((Button)c);
                }
                else if (c is GroupBox)
                {
                    strContent += "\n" + convierteGroupBox((GroupBox)c);
                }
                else if (c is MenuStrip)
                {

                    if (formName != null && formName == "Form1")
                    {
                        strContent += "\n" + convierteMenuPrincipal((MenuStrip)c);
                    }
                    else
                    {
                        strContent += "\n" + convierteMenuStrip((MenuStrip)c);
                    }
                }
                else if (c is TabControl)
                {
                    strContent += "\n" + convierteTabControl((TabControl)c);
                }
                else if (c is DateTimePicker)
                {
                    strContent += "\n" + convierteDateTimePicker((DateTimePicker)c);
                }
                else if (c is CheckBox)
                {
                    strContent += "\n" + convierteCheckBox((CheckBox)c);
                }
                else if (c is RadioButton)
                {
                    strContent += "\n" + convierteRadioButton((RadioButton)c);
                }
                else if (c is ComboBoxFB)
                {
                    strContent += "\n" + convierteComboBoxFB((ComboBoxFB)c);
                }
                else if (c is ComboBox)
                {
                    strContent += "\n" + convierteComboBox((ComboBox)c);
                }
                else if (c is ListBox)
                {
                    strContent += "\n" + convierteListBox((ListBox)c);
                }
                else if (c is Microsoft.Reporting.WinForms.ReportViewer)
                {
                    strContent += "\n" + convierteRDLC((Microsoft.Reporting.WinForms.ReportViewer)c);
                }
                else if (c is FastReport.Preview.PreviewControl)
                {
                    strContent += "\n" + convierteFastReport((FastReport.Preview.PreviewControl)c);
                }
                else if (c is PictureBox)
                {
                    strContent += "\n" + conviertePictureBox((PictureBox)c);
                }
                else if (c is DataGridViewE)
                {
                    strContent += "\n" + convierteGridE((DataGridViewE)c);
                }
                else if (c is DataGridView)
                {
                    strContent += "\n" + convierteGrid((DataGridView)c);
                }
                else if (c is Panel)
                {
                    strContent += "\n" + conviertePanel((Panel)c, formName);
                }
                else if (c is AxShockwaveFlashObjects.AxShockwaveFlash)
                {
                    strContent += "\n" + convierteFlash((AxShockwaveFlashObjects.AxShockwaveFlash)c);
                }
                else if (c is ProgressBar)
                {
                    strContent += "\n" + convierteProgressbar((ProgressBar)c);
                }



            }

            return strContent;
        }



        private string convierteControlesToolStrip(ToolStripItemCollection controls)
        {
            string strContent = "";
            foreach (ToolStripItem c in controls)
            {
                if (c is ToolStripLabel)
                {
                    strContent += "\n" + convierteToolStripLabel((ToolStripLabel)c);
                }
                else if (c is ToolStripTextBox)
                {
                    strContent += "\n" + convierteToolStripTextBox((ToolStripTextBox)c);
                }
                else if (c is ToolStripButton)
                {
                    strContent += "\n" + convierteToolStripButton((ToolStripButton)c);
                }

            }

            return strContent;
        }



        private string convierteTextBox(TextBox control, string form)
        {
            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown" , "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated"});
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                strEvents += " KeyUpWin=\"" + eventNameKeyUp + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }




            bool bEsAutoComplete = EsAutoComplete(control.Name, form);

            string xamlMolde = "";


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string strTextBind = dataBindTextBox(control);
            string strTextContent = strTextBind == "" ? " Text=\"" + control.Text + "\"  " : strTextBind;


            if(bEsAutoComplete)
                xamlMolde = "<src:TextBoxWFAutoComplete x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  " + strTextContent + "  TabIndex=\"" + control.TabIndex + "\"   FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\" <!-- Events --> />";
            else if (control.PasswordChar == '*')
                xamlMolde = "<src:CustomPasswordBox  x:Name=\"" + control.Name + "\"   " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"    FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  />";
            else
                xamlMolde = "<src:TextBoxWF  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\"  " + strTextContent + "  TabIndex=\"" + control.TabIndex + "\"    FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\" <!-- Events --> />";
            
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }

        private string convierteToolStripTextBox(ToolStripTextBox control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/


            string xamlMolde = "<TextBox x:Name=\"" + control.Name + "\" HorizontalAlignment=\"Left\" Height=\"" + control.Size.Height + "\" VerticalAlignment=\"Top\" Width=\"" + control.Size.Width + "\"  Margin=\"0\" TextWrapping=\"Wrap\" Text=\"" + control.Text + "\" />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }

        private string convierteLabel(Label control)
        {
            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true,false, false);

            string strTextBind = dataBindLabel(control);
            string content = control.Text.Replace("&", "").Replace("<", "").Replace(">", "").Replace("\"", "");

            string strTextContent = strTextBind == "" ? " Content=\"" + content + "\"  " : strTextBind;

            string xamlMolde = "<src:LabelWF  x:Name=\"" + control.Name + "\" " + strTextContent + "  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"   FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\" Padding=\"0\" />";
            return xamlMolde;
        }



        private string convierteToolStripLabel(ToolStripLabel control)
        {

            string xamlMolde = "<Label  x:Name=\"" + control.Name + "\" Content=\"" + control.Text + "\" HorizontalAlignment=\"Left\" Margin=\"0\" VerticalAlignment=\"Top\"/>";
            return xamlMolde;
        }




        private string obtenImageRouteButton(Button control)
        {
            foreach(string str in buttonImgDictCurrentForm.Keys)
            {
                if(str == control.Name  )
                {
                    if(buttonImgDictCurrentForm[str] != null && buttonImgDictCurrentForm[str] != "")
                    {
                        string[] strSplit = buttonImgDictCurrentForm[str].Replace(";","").Split(new string[] { "Resources." }, StringSplitOptions.None);
                        string strBuffer = strSplit[strSplit.Length - 1];

                        string strRuta = "/Resources/" + strBuffer + ".png";

                        if (imgExceptions.Keys.Contains(strBuffer))
                        {
                            strRuta = "/Resources/" + imgExceptions[strBuffer];
                        }


                        return /*"pack://siteoforigin:,,," +*/ strRuta ;
                    }
                }
            }

            return "";

        }


        private string obtenImageRoutePictureBox(PictureBox control)
        {
            foreach (string str in buttonImgDictCurrentForm.Keys)
            {
                if (str == control.Name)
                {
                    if (buttonImgDictCurrentForm[str] != null && buttonImgDictCurrentForm[str] != "")
                    {
                        string[] strSplit = buttonImgDictCurrentForm[str].Replace(";", "").Split(new string[] { "Resources." }, StringSplitOptions.None);
                        string strBuffer = strSplit[strSplit.Length - 1];

                        string strRuta = "/Resources/" + strBuffer + ".png";

                        if (imgExceptions.Keys.Contains(strBuffer))
                        {
                            strRuta = "/Resources/" + imgExceptions[strBuffer];
                        }


                        return /*"pack://siteoforigin:,,," +*/ strRuta;
                    }
                }
            }

            return "";

        }

        private string convierteButton(Button control)
        {

            Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                if (!eventNameClick.Equals("botonLookUp_Click"))
                {

                    strEvents += " Click=\"" + eventNameClick + "\" ";
                }
            }

            string content = control.Text.Replace("&", "").Replace("<", "").Replace(">", "").Replace("\"", "");


            string strContent = "";
            string strOrientacion = "Horizontal";
            string strRutaImagen = "";
            float fHeightImg = 12;
            float fWidthImg = 12;
            bool bTieneImagen = false;
            bool bTieneTexto = control.Text != null && control.Text.Trim().Length > 0;
            bool bTextoPrimero = true;


            if((control.Image != null && control.Image is Bitmap ) ||
               (control.BackgroundImage != null && control.BackgroundImage is Bitmap))
            {
                //Properties.Resources.ResourceManager.GetResourceSet

                strRutaImagen =  obtenImageRouteButton(control);
                if(strRutaImagen != "")
                {
                    bTieneImagen = true;

                    if(control.ImageAlign == ContentAlignment.TopCenter || control.ImageAlign == ContentAlignment.TopLeft || control.ImageAlign == ContentAlignment.TopRight ||
                       control.ImageAlign == ContentAlignment.BottomCenter || control.ImageAlign == ContentAlignment.BottomLeft || control.ImageAlign == ContentAlignment.BottomRight ||
                        ( (control.BackgroundImage != null && control.BackgroundImage is Bitmap)) )
                    {
                        strOrientacion = "Vertical";
                    }


                    if (control.ImageAlign == ContentAlignment.TopCenter || control.ImageAlign == ContentAlignment.TopLeft || control.ImageAlign == ContentAlignment.TopRight ||
                       control.ImageAlign == ContentAlignment.MiddleLeft ||
                        ((control.BackgroundImage != null && control.BackgroundImage is Bitmap)) )
                    {
                        bTextoPrimero = false;
                    }

                    if (!bTieneTexto)
                    {
                        fHeightImg = (float)control.Height;
                        fWidthImg = (float)control.Width;
                    }
                    else
                    {

                        if (strOrientacion == "Vertical")
                        {
                            fHeightImg = (float)control.Height * 0.7f;
                        }
                        else
                        {
                            fWidthImg = (float)control.Width * 0.3f;
                        }
                    }



                }
                
            }




            string xamlMoldeStartStack = "            <StackPanel Orientation=\""+ strOrientacion +"\">";
            string xamlMoldeImgStack = strOrientacion == "Horizontal" ? "                <Image Source=\"" + strRutaImagen + "\"   Width=\"" + fWidthImg.ToString() + "\" />" :
                                       "                <Image Source=\"" + strRutaImagen + "\"  Height=\"" + fHeightImg.ToString() + "\"  />";
            //string xamlMoldeImgStack = "                <Image Source=\"" + strRutaImagen + "\"  />";
            string xamlMoldeTxtStack = "                <Label Padding=\"0\">" + content + "</Label>";
            string xamlMoldeEndStack = "            </StackPanel>";

            strContent += xamlMoldeStartStack;
            if(bTextoPrimero)
            {
                if(bTieneTexto)
                    strContent += xamlMoldeTxtStack;

                if (bTieneImagen)
                    strContent += xamlMoldeImgStack;
            }
            else
            {
                if (bTieneImagen)
                    strContent += xamlMoldeImgStack;

                if (bTieneTexto)
                    strContent += xamlMoldeTxtStack;
            }
            strContent += xamlMoldeEndStack;


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);
            string xamlMolde = "<src:ButtonWF  x:Name=\"" + control.Name + "\"   " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events -->> <!-- Content --> </src:ButtonWF>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            xamlMolde = xamlMolde.Replace("<!-- Content -->", strContent);
            return xamlMolde;
        }

        private string convierteToolStripButton(ToolStripButton control)
        {
            Dictionary<string, string> events = EventToolStripButtonMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "" &&
                !eventNameClick.Contains("OnMove") && !eventNameClick.Contains("OnAdd") && !eventNameClick.Contains("OnDelete")
                 )
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }

            string xamlMolde = "<src:ButtonWF  x:Name=\"" + control.Name + "\" Content=\"" + control.Text + "\" HorizontalAlignment=\"Left\" Margin=\"0\" VerticalAlignment=\"Top\" Width=\"" + control.Size.Width + "\" <!-- Events -->/>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }

        private string conviertePanel(Panel control, string formName)
        {
            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<src:GridWF  x:Name=\"" + control.Name + "\" Uid=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  <!-- Events -->>\n<!-- Content XAML -->\n</src:GridWF>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);

            string strContent = "";
            strContent = convierteControles(control.Controls, formName);
            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }


        private string convierteDateTimePicker(DateTimePicker control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "ValueChanged" });
            //string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/


            string strEvents = "";
            string eventNameClick = GetMethodNameOpcion3(control, "onValueChanged");//obtenerEventoForm(control, typeof(DateTimePicker), "EVENT_VALUECHANGED");

            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " SelectedDateChanged=\"" + eventNameClick + "\" ";
            }


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<src:DatePickerWF  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }



        private string convierteTextBoxFB(TextBoxFB control)
        {


            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown", "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated" });
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                strEvents += " KeyUpWin=\"" + eventNameKeyUp + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<Tools:TextBoxFB x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\" Text=\"" + control.Text + "\"  QueryPorDBValue=\"" + control.QueryPorDBValue + "\" QueryDeSeleccion=\"" + control.QueryDeSeleccion + "\" Query=\"" + control.Query + "\" Titulo=\"" + control.Titulo + "\" ValidarEntrada=\"True\" NombreCampoValue=\"" + control.NombreCampoValue + "\" NombreCampoSelector=\"" + control.NombreCampoSelector + "\" MostrarErrores=\"True\" IndiceCampoSelector=\"" + control.IndiceCampoSelector + "\" IndiceCampoDescripcion=\"" + control.IndiceCampoDescripcion + "\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }



        private string convierteTextBoxFBRpt(TextBoxFBRpt control)
        {


            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown", "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated" });
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                strEvents += " KeyUpWin=\"" + eventNameKeyUp + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);
            string xamlMolde = "<Tools:TextBoxFB x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\" Text=\"" + control.Text + "\" QueryPorDBValue=\"" + control.QueryPorDBValue + "\" QueryDeSeleccion=\"" + control.QueryDeSeleccion + "\" Query=\"" + control.Query + "\" Titulo=\"" + control.Titulo + "\" ValidarEntrada=\"True\" NombreCampoValue=\"" + control.NombreCampoValue + "\" NombreCampoSelector=\"" + control.NombreCampoSelector + "\" MostrarErrores=\"True\" IndiceCampoSelector=\"" + control.IndiceCampoSelector + "\" IndiceCampoDescripcion=\"" + control.IndiceCampoDescripcion + "\"   TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"   <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }

        private string convierteTextBoxET(TextBoxET control, string form)
        {



            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown", "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated" });
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                strEvents += " KeyUpWin=\"" + eventNameKeyUp + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }


            bool bEsAutoComplete = EsAutoComplete(control.Name, form);

            string xamlMolde = "";


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);


            string strTextBind = dataBindTextBox(control);
            string strTextContent = strTextBind == "" ? " Text=\"" + control.Text + "\"  " : strTextBind;


            if(bEsAutoComplete)
                xamlMolde = "<src:TextBoxETWFAutoComplete x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\"  " + strTextContent + "   TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events -->/>";
            else if (control.PasswordChar == '*')
                xamlMolde = "<src:CustomPasswordBox  x:Name=\"" + control.Name + "\"   " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"    FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  />";
            else
                xamlMolde = "<Tools:TextBoxET x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\"  " + strTextContent + "   TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events -->/>";
            
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }


        private string convierteTextBoxETRpt(TextBoxETRpt control)
        {

            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown", "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated" });
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                strEvents += " KeyUpWin=\"" + eventNameKeyUp + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string strTextBind = dataBindTextBox(control);
            string strTextContent = strTextBind == "" ? " Text=\"" + control.Text + "\"  " : strTextBind;

            string xamlMolde = "<Tools:TextBoxET  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\" " + strTextContent + "  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"   <!-- Events -->/>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }

        private string convierteNumericTextBox(NumericTextBox control)
        {


            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown", "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated" });
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                if(!eventNameKeyDown.StartsWith("NumericTextBox_"))
                    strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                if (!eventNameKeyUp.StartsWith("NumericTextBox_"))
                    strEvents += " KeyUpWin=\"" + eventNameKeyUp + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                if (!eventNameKeyPress.StartsWith("NumericTextBox_"))
                    strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                if (!eventNamePreviewKeyDown.StartsWith("NumericTextBox_"))
                    strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                if (!eventNameEnter.StartsWith("NumericTextBox_"))
                    strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                if (!eventNameLeave.StartsWith("NumericTextBox_"))
                    strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                if (!eventNameValidating.StartsWith("NumericTextBox_"))
                    strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                if (!eventNameValidated.StartsWith("NumericTextBox_"))
                    strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<Tools:NumericTextBox  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\"  NumericPrecision=\"" + control.NumericPrecision + "\" AllowNegative=\"True\" NumericScaleOnFocus=\"" + control.NumericScaleOnFocus + "\" ZeroIsValid=\"True\" NumericScaleOnLostFocus=\"" + control.NumericScaleOnLostFocus + "\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events -->/>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }

        private string convierteNumericUpDown(NumericUpDown control)
        {


            Dictionary<string, string> events = EventMetods(control, null, new string[] { "KeyDown", "KeyUp", "KeyPress", "PreviewKeyDown", "Enter", "Leave", "Validating", "Validated" });
            string strEvents = "";
            string eventNameKeyDown = events["KeyDown"];
            string eventNameKeyUp = events["KeyUp"];
            string eventNameKeyPress = events["KeyPress"];
            string eventNamePreviewKeyDown = events["PreviewKeyDown"];

            string eventNameEnter = events["Enter"];
            string eventNameLeave = events["Leave"];


            string eventNameValidating = events["Validating"];
            string eventNameValidated = events["Validated"];

            if (eventNameKeyDown != null && eventNameKeyDown != "")
            {
                strEvents += " KeyDownWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyUp != null && eventNameKeyUp != "")
            {
                strEvents += " KeyUpWin=\"" + eventNameKeyDown + "\" ";
            }


            if (eventNameKeyPress != null && eventNameKeyPress != "")
            {
                strEvents += " KeyPressWin=\"" + eventNameKeyPress + "\" ";
            }

            if (eventNamePreviewKeyDown != null && eventNamePreviewKeyDown != "")
            {
                strEvents += " PreviewKeyDownWin=\"" + eventNamePreviewKeyDown + "\" ";
            }


            if (eventNameEnter != null && eventNameEnter != "")
            {
                strEvents += " EnterWin=\"" + eventNameEnter + "\" ";
            }


            if (eventNameLeave != null && eventNameLeave != "")
            {
                strEvents += " LeaveWin=\"" + eventNameLeave + "\" ";
            }



            if (eventNameValidating != null && eventNameValidating != "" && eventNameValidating != "ControlToValidate_Validating")
            {
                strEvents += " ValidatingWin=\"" + eventNameValidating + "\" ";
            }


            if (eventNameValidated != null && eventNameValidated != "")
            {
                strEvents += " ValidatedWin=\"" + eventNameValidated + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<Tools:NumericTextBox  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TextWrapping=\"Wrap\" NumericPrecision=\"0\" AllowNegative=\"True\" NumericScaleOnFocus=\"0\" ZeroIsValid=\"True\" NumericScaleOnLostFocus=\"0\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events -->/>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }



        private string convierteCheckBox(CheckBox control)
        {

            string strEvents = "";
            string eventNameChecked = obtenerEventoForm(control, typeof(CheckBox), "EVENT_CHECKEDCHANGED");
            if (eventNameChecked != null && eventNameChecked != "")
            {
                strEvents += " CheckedChanged=\"" + eventNameChecked + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<src:CheckBoxWF  x:Name=\"" + control.Name + "\" Content=\"" + control.Text + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }


        private string convierteRadioButton(RadioButton control)
        {


            string strEvents = "";
            string eventNameChecked = obtenerEventoForm(control, typeof(RadioButton), "EVENT_CHECKEDCHANGED");
            if (eventNameChecked != null && eventNameChecked != "")
            {
                strEvents += " CheckedChanged=\"" + eventNameChecked + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<src:RadioButtonWF  x:Name=\"" + control.Name + "\" Content=\"" + control.Text + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);
            return xamlMolde;
        }


        private string convierteGroupBox(GroupBox control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<src:GroupBoxWF  x:Name=\"" + control.Name + "\" Header=\"" + control.Text + "\"  " + strAllignmentsAndTamanio + "   Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  Padding=\"-12\"  <!-- Events --> >\n<src:GridWF  HorizontalAlignment=\"Left\" Height=\"" + control.Size.Height + "\" Margin=\"0,0,0,0\" VerticalAlignment=\"Top\" Width=\"" + control.Size.Width + "\"  >\n<!-- Content XAML -->\n</src:GridWF>\n</src:GroupBoxWF>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);

            string strContent = "";

            strContent = convierteControles(control.Controls);

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }


        private string convierteTabControl(TabControl control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/


            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<TabControl  x:Name=\"" + control.Name + "\" Grid.ColumnSpan=\"" + control.TabCount.ToString() + "\"  " + strAllignmentsAndTamanio + "   Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"   TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"   <!-- Events --> >\n<!-- Content XAML -->\n</TabControl>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);

            string strContent = "";

            foreach (TabPage tp in control.TabPages)
            {
                string strContentTabPage = "";
                string xamlTabPageMolde = "\n<TabItem  x:Name=\"" + tp.Name + "\" Header=\"" + tp.Text + "\">\n<Grid>\n<!-- Content XAML -->\n</Grid>\n</TabItem>";
                strContentTabPage = convierteControles(tp.Controls);
                xamlTabPageMolde = xamlTabPageMolde.Replace("<!-- Content XAML -->", strContentTabPage);
                strContent += xamlTabPageMolde;
            }

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }


        private string convierteComboBox(ComboBox control)
        {

            string strEvents = "";
            string eventNameClick = obtenerEventoForm(control, typeof(ComboBox), "EVENT_SELECTEDINDEXCHANGED");

            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " SelectionChanged=\"" + eventNameClick + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string strDataBind = itemSourceDataBindComboBox(control);

            string xamlMolde = "<src:ComboBoxWF  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "   Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" Grid.ColumnSpan=\"2\"   TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\" " + strDataBind + "  <!-- Events --> >\n<!-- Content XAML -->\n</src:ComboBoxWF>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);

            string strContent = "";



            foreach (Object tp in control.Items)
            {
                string contentitem = tp.ToString().Replace("&", "").Replace("<", "").Replace(">", "").Replace("\"", "");
                string xamlTabPageMolde = "\n<ComboBoxItem>" + contentitem + "</ComboBoxItem>";
                strContent += xamlTabPageMolde;
            }

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }




        private string convierteListBox(ListBox control)
        {


            string strEvents = "";
            string eventNameClick = obtenerEventoForm(control, typeof(ListBox), "EVENT_SELECTEDINDEXCHANGED");

            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " SelectionChanged=\"" + eventNameClick + "\" ";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);


            string strDataBind = itemSourceDataBindListBox(control);

            string xamlMolde = "<src:ListBoxWF  x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  " + strDataBind + "  <!-- Events -->>\n<!-- Content XAML -->\n</src:ListBoxWF>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);

            string strContent = "";

            foreach (Object tp in control.Items)
            {
                string xamlTabPageMolde = "\n<ListBoxItem Content=\"" + tp.ToString() + "\" />";
                strContent += xamlTabPageMolde;
            }

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }


        private string convierteToolStrip(ToolStrip control)
        {





            string xamlMolde = "";

            if (control.LayoutStyle == ToolStripLayoutStyle.HorizontalStackWithOverflow)
            {
                xamlMolde = "<ToolBar  x:Name=\"" + control.Name + "\" HorizontalAlignment=\"Left\" VerticalAlignment=\"Top\" Width=\"" + control.Width + "\" Height=\"" + control.Height + "\"  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  <!-- Events -->>\n<!-- Content XAML -->\n</ToolBar>";
            }
            else
            {
                xamlMolde = "<ToolBarTray Orientation=\"Vertical\" HorizontalAlignment=\"Left\" VerticalAlignment=\"Top\" Width=\"" + control.Width + "\" Height=\"" + control.Height + "\"  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" >\n<ToolBar  x:Name=\"" + control.Name + "\" HorizontalAlignment=\"Left\" Margin=\"0,0,0,0\" VerticalAlignment=\"Top\" Width=\"" + control.Width + "\" Height=\"" + control.Height + "\"  <!-- Events -->>\n<!-- Content XAML -->\n</ToolBar></ToolBarTray>";
            }
            
            xamlMolde = xamlMolde.Replace("<!-- Events -->", "");

            string strContent = "";

            
            strContent = convierteControlesToolStrip(control.Items);

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }



        private string convierteRDLC(Microsoft.Reporting.WinForms.ReportViewer control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";

            }*/

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<WindowsFormsHost  " + strAllignmentsAndTamanio + " Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"   >\n     <rv:ReportViewer x:Name=\"" + control.Name + "\"  Dock=\"Fill\"  Location=\"0, 0\"  <!-- Events -->/>\n</WindowsFormsHost>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);
            return xamlMolde;
        }


        private string convierteFastReport(FastReport.Preview.PreviewControl control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<FastReport:FPPreviewHost x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\"   <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);
            return xamlMolde;
        }



        private string conviertePictureBox(PictureBox control)
        {
            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/


            string strRutaImagen = "";
            string strAsignacionImagen = "";
            if (control.Image != null && control.Image is Bitmap)
            {
                strRutaImagen = obtenImageRoutePictureBox(control);
            }

            if(strRutaImagen != null && strRutaImagen.Length > 0)
            {
                strAsignacionImagen = "Source=\"" + strRutaImagen + "\"";
            }

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string strImagen = control.ImageLocation;
            string xamlMolde = "<src:PictureBoxWF  x:Name=\"" + control.Name + "\"   " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" " + strAsignacionImagen + "  <!-- Events --> />";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);
            return xamlMolde;
        }





        private string convierteMenuPrincipal(MenuStrip control)
        {

            string xamlMolde = "<Menu  x:Name=\"" + control.Name + "\"  Height=\"" + control.Height + "\" Margin=\"0\" VerticalAlignment=\"Top\" Grid.ColumnSpan=\"2\"   >\n                    <Menu.ItemTemplate>\n                        <HierarchicalDataTemplate ItemsSource=\"{Binding SubItems}\">\n                            <TextBlock Text=\"{Binding MyHeader}\"/>\n                        </HierarchicalDataTemplate>\n                    </Menu.ItemTemplate>\n                    <Menu.ItemContainerStyle>\n                        <Style TargetType=\"MenuItem\">\n                            <Setter Property=\"Command\" Value=\"{Binding DataContext.ImportRecentItemCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type MenuItem}, AncestorLevel=1}}\" />\n                            <Setter Property=\"CommandParameter\" Value=\"{Binding}\" />\n                            <Setter Property=\"Background\" Value=\"{DynamicResource ControlBackgroundBrush}\" />\n                            <Style.Triggers>\n                                <Trigger Property=\"IsHighlighted\" Value=\"True\">\n                                </Trigger>\n                            </Style.Triggers>\n                        </Style>\n                    </Menu.ItemContainerStyle>\n                </Menu>";
             return xamlMolde;
        }

        private string convierteMenuStrip(MenuStrip control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/

            string xamlMolde = "<Menu  x:Name=\"" + control.Name + "\"  Height=\"" + control.Height + "\" Margin=\"0\" VerticalAlignment=\"Top\" Grid.ColumnSpan=\"2\"  <!-- Events --> >\n<!-- Content XAML -->\n</Menu>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);

            string strContent = "";

            foreach (ToolStripMenuItem tp in control.Items)
            {
                strContent += convierteMenuItem(tp);
            }

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }




        private string convierteMenuItem(ToolStripMenuItem control)
        {


            /* Dictionary<string, string> events = EventMetodsMenu(control, null, new string[] { "Click" });
             string strEvents = "";
             string eventNameClick = events["Click"];
             if (eventNameClick != null && eventNameClick != "")
             {
                     strEvents += " Click=\"" + eventNameClick + "\" ";
             }
             */

            EventHandler handler = (EventHandler)GetDelegateToolStrip(control, "EventClick");
            string eventNameClick = handler != null && handler.Method != null ? handler.Method.Name : null;

            string strEvents = "";
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }

            string xamlMolde = "\n            <src:MenuItemWF  x:Name=\"" + control.Name + "\"  Header=\"" + control.Text + "\"  <!-- Events --> >\n                <!-- Content XAML -->\n            </src:MenuItemWF>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", strEvents);

            string strContent = "";

            foreach (ToolStripMenuItem tp in control.DropDownItems)
            {
                strContent += convierteMenuItem(tp);
            }

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }


        private string convierteComboBoxFB(ComboBoxFB control)
        {

            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<Tools:ComboBoxFB x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" Query=\"" + control.Query + "\" QueryDeSeleccion=\"" + control.QueryDeSeleccion + "\" NombreCampoSelector=\"" + control.NombreCampoSelector + "\" DisplayMemberPath=\"" + control.DisplayMember + "\" SelectedValuePath=\"" + control.ValueMember + "\" Grid.Column=\"1\"   TabIndex=\"" + control.TabIndex + "\"  FontFamily=\"" + control.Font.FontFamily.Name + "\" FontSize=\"" + winFormFontSizeToWPF(control.Font.Size) + "\" FontWeight=\"" + winFormFontStyleToWPF(control.Font.Style) + "\"  <!-- Events -->/>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);

            return xamlMolde;
        }

        private string convierteFlash(AxShockwaveFlashObjects.AxShockwaveFlash control)
        {
            //Dictionary<string, string> events = EventMetods(control, null, new string[] { "Click" });
            string strEvents = "";
            /*string eventNameClick = events["Click"];
            if (eventNameClick != null && eventNameClick != "")
            {
                strEvents += " Click=\"" + eventNameClick + "\" ";
            }*/

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "\n                <WindowsFormsHost x:Name=\"" + control.Name + "_Host\" Uid=\"" + control.Name + "_Host\"   " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" >\n                    <Ax:AxShockwaveFlash x:Name=\"" + control.Name + "\" Dock=\"Fill\"  Location=\"0, 0\"     />\n                </WindowsFormsHost>";
            xamlMolde = xamlMolde.Replace("<!-- Events -->", ""/*strEvents*/);

            return xamlMolde;
        }

      
        

        private string findBindSourceName(object dataSource)
        {
            if (dataSource != null && dataSource.GetType().IsAssignableFrom(typeof(BindingSource)))
            {
                foreach (string strKey in formBindDict.Keys)
                {
                    if (dataSource == formBindDict[strKey])
                    {
                        return strKey;
                    }
                }
            }
            return "";
        }





        private string convierteGrid(DataGridView control)
        {

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<WindowsFormsHost x:Name=\"" + control.Name + "_Host\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"   TabIndex=\"" + control.TabIndex + "\" >\n            <src:DataGridViewWF x:Name=\"" + control.Name + "\" Dock=\"Fill\"  Location=\"0, 0\"   AutoGenerateColumns=\"False\" />\n        </WindowsFormsHost>";
            
            return xamlMolde;
        }


        private string convierteGridE(DataGridViewE control)
        {

            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);

            string xamlMolde = "<WindowsFormsHost x:Name=\"" + control.Name + "_Host\" HorizontalAlignment=\"Left\" Height=\"" + control.Height + "\" VerticalAlignment=\"Top\" Width=\"" + control.Width + "\"  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  TabIndex=\"" + control.TabIndex + "\" >\n            <src:DataGridViewEWF x:Name=\"" + control.Name + "\" Dock=\"Fill\"  Location=\"0, 0\"   AutoGenerateColumns=\"False\"  />\n        </WindowsFormsHost>";

            return xamlMolde;
        }

        private string convierteGridOld(DataGridView control)
        {
            string dataSource = findBindSourceName(control.DataSource);
            string xamlMolde = "<DataGrid x:Name=\"" + control.Name + "__\" AutoGenerateColumns=\"False\" EnableRowVirtualization=\"True\" ItemsSource=\"{Binding Source={StaticResource " + dataSource + "}}\" Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\" RowDetailsVisibilityMode=\"VisibleWhenSelected\"  CanUserAddRows=\"False\" CanUserDeleteRows=\"False\" Background=\"#FFC7C7C7\" IsReadOnly=\"True\" ColumnHeaderHeight=\"30\" RowHeight=\"35\">\n            <DataGrid.Columns>     \n   <!-- Content XAML -->        \n            </DataGrid.Columns>\n</DataGrid>";

            //xamlMolde = xamlMolde.Replace("<!-- Events -->", "");

            string strContent = "";

            foreach (DataGridViewColumn tp in control.Columns)
            {
                if(tp is DataGridViewButtonColumn)
                {
                    string xamlTabPageMolde = convierteGridButton((DataGridViewButtonColumn)tp);
                    strContent += xamlTabPageMolde;

                }
                else if( tp is DataGridViewCheckBoxColumn)
                {
                    string xamlTabPageMolde = convierteGridCheckBox((DataGridViewCheckBoxColumn)tp);
                    strContent += xamlTabPageMolde;
                }
                else if (tp is DataGridViewTextBoxColumn)
                {

                    string xamlTabPageMolde = convierteGridText((DataGridViewTextBoxColumn) tp);
                    strContent += xamlTabPageMolde;
                }
                else
                {
                    
                    string xamlTabPageMolde = "\n<DataGridTextColumn x:Name=\"" + tp.Name + "_\" Binding=\"{Binding " + tp.DataPropertyName + "}\" Header=\"" + tp.HeaderText + "\" Width=\"" + tp.Width.ToString() + "\"/>";
                    strContent += xamlTabPageMolde;
                }
            }

            xamlMolde = xamlMolde.Replace("<!-- Content XAML -->", strContent);

            return xamlMolde;
        }



        private string convierteGridText(DataGridViewTextBoxColumn tp)
        {
            return "\n<DataGridTextColumn x:Name=\"" + tp.Name + "_\" Binding=\"{Binding " + tp.DataPropertyName + "}\" Header=\"" + tp.HeaderText + "\" Width=\"" + tp.Width.ToString() + "\"/>";
              
        }


        private string convierteGridButton(DataGridViewButtonColumn tp)
        {
            return "\n<DataGridTemplateColumn x:Name=\"" + tp.Name + "_\" Header=\"" + tp.HeaderText + "\" Width=\"" + tp.Width.ToString() + "\" >\n                    <DataGridTemplateColumn.CellTemplate>\n                        <DataTemplate>\n                            <Button  Content=\"" + tp.Text + "\" Width=\"" + tp.Width.ToString() + "\" >\n                            </Button>\n                        </DataTemplate>\n                    </DataGridTemplateColumn.CellTemplate>\n                </DataGridTemplateColumn>";
             
        }


        private string convierteGridCheckBox(DataGridViewCheckBoxColumn tp)
        {

            if (tp.DataPropertyName != null && tp.DataPropertyName.Trim().Length > 0)
                return "\n<DataGridCheckBoxColumn  x:Name=\"" + tp.Name + "_\" Header=\"" + tp.HeaderText + "\" Width=\"" + tp.Width.ToString() + "\"  Binding=\"{Binding " + tp.DataPropertyName + ", UpdateSourceTrigger=PropertyChanged}\"></DataGridCheckBoxColumn>";
            else
                return "\n<DataGridCheckBoxColumn  x:Name=\"" + tp.Name + "_\" Header=\"" + tp.HeaderText + "\" Width=\"" + tp.Width.ToString() + "\"  ></DataGridCheckBoxColumn>";
        }


        private string convierteProgressbar(ProgressBar control)
        {
            string strAllignmentsAndTamanio = allignmentsAndTamanioControl(control, true, true, true, true);
            string xamlMolde = "<src:ProgressBarWF x:Name=\"" + control.Name + "\"  " + strAllignmentsAndTamanio + "  Margin=\"" + control.Location.X + "," + control.Location.Y + ",0,0\"  />";
            return xamlMolde;
        }


        private string allignmentsAndTamanioControl(Control control, bool bHorizontalAlignment,  bool bVerticalAlignment, bool bWidth, bool bHeight)
        {
            int height = -1;
            int width = -1;
            string vertAlignment = "Top";
            string horzAlignment = "Left";

                switch(control.Dock)
                {
                    case DockStyle.Top:       height = control.Height; width = -1; vertAlignment = "Top"; horzAlignment = "Stretch"; break;
                    case DockStyle.Bottom:    height = control.Height; width = -1; vertAlignment = "Bottom"; horzAlignment = "Stretch"; break;
                    case DockStyle.Left:      height = -1; width = control.Width; vertAlignment = "Stretch"; horzAlignment = "Left"; break;
                    case DockStyle.Right:     height = -1; width = control.Width; vertAlignment = "Stretch"; horzAlignment = "Right"; break;
                    case DockStyle.Fill: height = control.Height; width = -1; vertAlignment = "Top"; horzAlignment = "Stretch"; break;
                    default: height = control.Height; width = control.Width; vertAlignment = "Top"; horzAlignment = "Left"; break;
                                    
                }

             string str = "";
            
            if(bHeight && height != -1)
                str += " Height=\"" + height.ToString() + "\" ";

            if(bWidth && width != -1)
                str += " Width=\"" + width.ToString() + "\"  ";

            if(bVerticalAlignment)
                str += " VerticalAlignment=\"" + vertAlignment + "\" ";

            if(bHorizontalAlignment)
                str += " HorizontalAlignment=\"" + horzAlignment + "\" ";

            return str;


        }



        private string itemSourceDataBindComboBox(ComboBox control)
        {
            string dataSourceName = "";
            string dataValue = "";
            string dataDisplay = "";

            if(control.DataSource != null)
            {
                foreach(string strBind in formBindDict.Keys)
                {
                    BindingSource bs = formBindDict[strBind];
                    if(bs == control.DataSource)
                    {
                        dataSourceName = strBind;
                        dataValue = control.ValueMember;
                        dataDisplay = control.DisplayMember;

                        return " ItemsSource=\"{Binding Source={StaticResource " + dataSourceName + "} }\" DisplayMemberPath=\"" + dataDisplay + "\" SelectedValuePath=\"" + dataValue + "\" ";
                    }
                }
            }

            return "";
        }


        private string itemSourceDataBindListBox(ListBox control)
        {
            string dataSourceName = "";
            string dataValue = "";
            string dataDisplay = "";

            if (control.DataSource != null)
            {
                foreach (string strBind in formBindDict.Keys)
                {
                    BindingSource bs = formBindDict[strBind];
                    if (bs == control.DataSource)
                    {
                        dataSourceName = strBind;
                        dataValue = control.ValueMember;
                        dataDisplay = control.DisplayMember;

                        return " ItemsSource=\"{Binding Source={StaticResource " + dataSourceName + "} }\" DisplayMemberPath=\"" + dataDisplay + "\" SelectedValuePath=\"" + dataValue + "\" ";
                    }
                }
            }

            return "";
        }



        private string dataBindTextBox(TextBox control)
        {
            string dataSourceName = "";
            string dataDisplay = "";

            if (control.DataBindings != null && control.DataBindings.Count > 0)
            {
                foreach (string strBind in formBindDict.Keys)
                {
                    BindingSource bs = formBindDict[strBind];
                    if (bs == control.DataBindings[0].DataSource)
                    {
                        dataSourceName = strBind;
                        dataDisplay = control.DataBindings[0].BindingMemberInfo.BindingField;

                        return " Text=\"{Binding Source={StaticResource " + dataSourceName + "}, Path=CurrentItem." + dataDisplay + "}\" ";
                    }
                }
            }

            return "";
        }




        private string dataBindLabel(Label control)
        {
            string dataSourceName = "";
            string dataDisplay = "";

            if (control.DataBindings != null && control.DataBindings.Count > 0)
            {
                foreach (string strBind in formBindDict.Keys)
                {
                    BindingSource bs = formBindDict[strBind];
                    if (bs == control.DataBindings[0].DataSource)
                    {
                        dataSourceName = strBind;
                        dataDisplay = control.DataBindings[0].BindingMemberInfo.BindingField;

                        return " Content=\"{Binding Source={StaticResource " + dataSourceName + "}, Path=CurrentItem." + dataDisplay + "}\" ";
                    }
                }
            }

            return "";
        }

    }
}
