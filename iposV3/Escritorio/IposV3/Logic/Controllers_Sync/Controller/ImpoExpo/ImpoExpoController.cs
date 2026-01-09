using BindingModels;
using IposV3.Model;
using DataAccess;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using IposV3.Services;
using Microsoft.EntityFrameworkCore;
using IposV3.Services.Extensions;

namespace Controllers.Controller
{

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class ImpoExpoController 
    {

        OperationsContextFactory _operationsContextFactory;

        ProveeduriaService _proveeduriaService;

        //ILineaDaoProvider lineaProvider = null;
        //IMarcaDaoProvider marcaProvider = null;
        //IUnidadDaoProvider unidadProvider = null;
        //IBancoDaoProvider bancoProvider = null;
        //ISubtipoclienteDaoProvider subtipoclienteProvider = null;
        //ITerminalpagoservicioDaoProvider terminalProvider = null;
        //IMerchantpagoservicioDaoProvider merchantProvider = null;
        //IClerkpagoservicioDaoProvider clerkProvider = null;
        //IContenidoDaoProvider contenidoProvider = null;
        //IClasificaDaoProvider clasificaProvider = null;
        //ITipodiferenciainventarioDaoProvider tipoDifIngProvider = null;
        //ITasaivaDaoProvider tasaIvaProvider = null;
        //IGruposucursalDaoProvider gpoSucursalProvider = null;
        //IPlazoDaoProvider plazoProvider = null;
        //IGastoDaoProvider gastoProvider = null;
        //IPromocionDaoProvider promocionProvider = null;
        //IProveedorControllerProvider proveedorProvider = null;
        //ISucursal_extControllerProvider sucursalExtProvider = null;
        //IEstadopaisControllerProvider estadopaisProvider = null;
        //IProductoControllerProvider productoProvider = null;
        //IKitdefinicionControllerProvider kitdefinicionProvider = null;

        //IDoctoDaoProvider doctoProvider = null;

        //ISync_impoDaoProvider sync_ImpoDaoProvider = null;
        //ISync_expoDaoProvider sync_ExpoDaoProvider = null;
        //ISucursal_extDaoProvider sucursalExtDaoProvider = null;





        public ImpoExpoController(
            ProveeduriaService proveeduriaService,
            //ILineaDaoProvider lineaProvider,
            //IMarcaDaoProvider marcaProvider,
            //IUnidadDaoProvider unidadProvider,
            //IBancoDaoProvider bancoProvider,
            //ISubtipoclienteDaoProvider subtipoclienteProvider,
            //ITerminalpagoservicioDaoProvider terminalProvider,
            //IMerchantpagoservicioDaoProvider merchantProvider,
            //IClerkpagoservicioDaoProvider clerkProvider,
            //IContenidoDaoProvider contenidoProvider,
            //IClasificaDaoProvider clasificaProvider,
            //ITipodiferenciainventarioDaoProvider tipoDifIngProvider,
            //ITasaivaDaoProvider tasaIvaProvider,
            //IGruposucursalDaoProvider gpoSucursalProvider,
            //IPlazoDaoProvider plazoProvider,
            //IGastoDaoProvider gastoProvider,
            //IPromocionDaoProvider promocionProvider,
            //IProveedorControllerProvider proveedorProvider,
            //ISucursal_extControllerProvider sucursalExtProvider,
            //IEstadopaisControllerProvider estadopaisProvider,
            //IProductoControllerProvider productoProvider,
            //IKitdefinicionControllerProvider kitdefinicionProvider,
            //IDoctoDaoProvider doctoProvider,
            //ISync_impoDaoProvider sync_ImpoDaoProvider,
            //ISync_expoDaoProvider sync_ExpoDaoProvider,
            //ISucursal_extDaoProvider sucursalExtDaoProvider
            OperationsContextFactory operationsContextFactory

            )
        {

            //this.lineaProvider = lineaProvider;
            //this.marcaProvider = marcaProvider;
            //this.unidadProvider = unidadProvider;
            //this.bancoProvider = bancoProvider;
            //this.subtipoclienteProvider = subtipoclienteProvider;
            //this.terminalProvider = terminalProvider;
            //this.merchantProvider = merchantProvider;
            //this.clerkProvider = clerkProvider;
            //this.contenidoProvider = contenidoProvider;
            //this.clasificaProvider = clasificaProvider;
            //this.tipoDifIngProvider = tipoDifIngProvider;
            //this.tasaIvaProvider = tasaIvaProvider;
            //this.gpoSucursalProvider = gpoSucursalProvider;
            //this.plazoProvider = plazoProvider;
            //this.gastoProvider = gastoProvider;
            //this.promocionProvider = promocionProvider;
            //this.proveedorProvider = proveedorProvider;
            //this.sucursalExtProvider = sucursalExtProvider;
            //this.estadopaisProvider = estadopaisProvider;
            //this.productoProvider = productoProvider;
            //this.kitdefinicionProvider = kitdefinicionProvider;
            //this.doctoProvider = doctoProvider;
            //this.sync_ImpoDaoProvider = sync_ImpoDaoProvider;
            //this.sync_ExpoDaoProvider = sync_ExpoDaoProvider;
            //this.sucursalExtDaoProvider = sucursalExtDaoProvider;

            _proveeduriaService = proveeduriaService;
            this._operationsContextFactory = operationsContextFactory;
        }


        public async Task<bool> ExportCatalogs(long empresaid, long sucursalid, string empresaClave, string sucursalFuenteClave)
        {

            try
            {
                string expoBufferFullPath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FolderBuffer;
                string expoZipExpoFile = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_Folder + "\\" + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FileNameZip;


                if (Directory.Exists(expoBufferFullPath))
                    DeleteDirectory(expoBufferFullPath);

                Directory.CreateDirectory(expoBufferFullPath);

                using (var operationsDbContext = this._operationsContextFactory.Create())
                {
                    (new LineaImpoExpoService()).Export(empresaid, sucursalid, "linea", expoBufferFullPath, operationsDbContext);
                    (new MarcaImpoExpoService()).Export(empresaid, sucursalid, "marca", expoBufferFullPath, operationsDbContext);

                    (new UnidadImpoExpoService()).Export(empresaid, sucursalid, "unidad", expoBufferFullPath, operationsDbContext);
                    (new BancoImpoExpoService()).Export(empresaid, sucursalid, "banco", expoBufferFullPath, operationsDbContext);
                    (new SubtipoclienteImpoExpoService()).Export(empresaid, sucursalid, "subticli", expoBufferFullPath, operationsDbContext);
                    (new TerminalpagoservicioImpoExpoService()).Export(empresaid, sucursalid, "terminal", expoBufferFullPath, operationsDbContext);
                    (new MerchantpagoservicioImpoExpoService()).Export(empresaid, sucursalid, "merchant", expoBufferFullPath, operationsDbContext);
                    (new ClerkpagoservicioImpoExpoService()).Export(empresaid, sucursalid, "clerk", expoBufferFullPath, operationsDbContext);
                    (new ContenidoImpoExpoService()).Export(empresaid, sucursalid, "contenido", expoBufferFullPath, operationsDbContext);
                    (new ClasificaImpoExpoService()).Export(empresaid, sucursalid, "clasifica", expoBufferFullPath, operationsDbContext);
                    (new TipodiferenciainventarioImpoExpoService()).Export(empresaid, sucursalid, "tipodifinv", expoBufferFullPath, operationsDbContext);
                    (new TasaivaImpoExpoService()).Export(empresaid, sucursalid, "tasaiva", expoBufferFullPath, operationsDbContext);
                    (new GruposucursalImpoExpoService()).Export(empresaid, sucursalid, "gposucursal", expoBufferFullPath, operationsDbContext);
                    (new PlazoImpoExpoService()).Export(empresaid, sucursalid, "plazo", expoBufferFullPath, operationsDbContext);
                    (new GastoImpoExpoService()).Export(empresaid, sucursalid, "gasto", expoBufferFullPath, operationsDbContext);
                    (new PromocionImpoExpoService()).Export(empresaid, sucursalid, "promo", expoBufferFullPath, operationsDbContext);
                    (new ProveedorImpoExpoService()).Export(empresaid, sucursalid, "prov", expoBufferFullPath, operationsDbContext);
                    (new Sucursal_infoImpoExpoService()).Export(empresaid, sucursalid, "sucext", expoBufferFullPath, operationsDbContext);
                    (new EstadopaisImpoExpoService()).Export(empresaid, sucursalid, "estadop", expoBufferFullPath, operationsDbContext);
                    (new ProductoImpoExpoService()).Export(empresaid, sucursalid, "prod", expoBufferFullPath, operationsDbContext);

                    (new KitdefinicionImpoExpoService()).Export(empresaid, sucursalid, "kitdef", expoBufferFullPath, operationsDbContext);


                }

                if (File.Exists(expoZipExpoFile))
                    File.Delete(expoZipExpoFile);

                Thread.Sleep(3000);

                await Task.Delay(1);//todo es solo para evitar el warning de que no requiere el "async" y creo que si lo requerira en algun momento

                System.IO.Compression.ZipFile.CreateFromDirectory(expoBufferFullPath, expoZipExpoFile);

                var nameFileInS3 = ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FileNameZip;
                var fileType = ImpoExpoConstants._REMOTE_FILE_TYPE_CATALOGOS;
                var passwordApi = ImpoExpoConstants.ImpoExpoApiPassword;
                //var filePathInS3 = empresa.clave;
                var client = new RestClient(ImpoExpoConstants.ImpoExpoApi);
                //var request = new RestRequest($"/values/{nameFileInS3}/uploadFile/{filePathInS3}", Method.Post);
                var request = new RestRequest($"/syncWS/{empresaClave}/uploadFileByType/{sucursalFuenteClave}/sucdest/_/filename/{nameFileInS3}/type/{fileType}/pass/{passwordApi}", Method.Post);
                request.AddFile(ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FileNameZip, expoZipExpoFile);


                var taskResponse = client.ExecuteAsync(request);
                RestSharp.RestResponse? response = null;

                Task continuation = taskResponse.ContinueWith(t =>
                {
                    Console.WriteLine(t.Result.Content);
                    response = t.Result;
                });

                continuation.Wait(30000);

                if (response == null || response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(response?.ErrorMessage ?? "Repuesta nula");

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ;
            }
        }


        private void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }




        private (Empresa?, Sucursal?) ObtenerClaveDeEmpresaYSucursal(long empresaid, long sucursalid, ApplicationDbContext? localContext)
        {

            Empresa? empresa = null;
            Sucursal? sucursal = null;
            if (localContext == null)
            {

                using (var operationsDbContext = this._operationsContextFactory.Create())
                {

                    empresa = operationsDbContext.Empresa.AsNoTracking().FirstOrDefault(x => x.Id == empresaid);
                    sucursal = operationsDbContext.Sucursal.AsNoTracking().FirstOrDefault(x => x.EmpresaId == empresaid && x.Id == sucursalid);
                }
                return (empresa, sucursal);
            }
            else
            {
                empresa = localContext.Empresa.AsNoTracking().FirstOrDefault(x => x.Id == empresaid);
                sucursal = localContext.Sucursal.AsNoTracking().FirstOrDefault(x => x.EmpresaId == empresaid && x.Id == sucursalid);
                return (empresa, sucursal);
            }    

        }

        public async Task<bool> ImportCatalogsFromServer(long empresaid, long sucursalId, string empresaClave, string sucursalClave,
                                                 string remoteFileFullName, long userId, long remoteFileId, string fileName, DateTime? fechaHoraArchivoRemoto)
        {
            string localPath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_Productos;
            string localFileName = ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FileNameZip;
            string localFullPath = localPath + @"\" + localFileName;
            string remoteFullPath = remoteFileFullName;



            var downloaded = await SaveFileFromS3(empresaid, sucursalId,
                                                  empresaClave, sucursalClave,
                                                  remoteFullPath, localFullPath, remoteFileId);
            var sucursalOrigenClave = fileName.Split('.').LastOrDefault();

            if (sucursalOrigenClave == null)
                throw new Exception("Mal nombre");




            if (downloaded)
            {

                using (var operationsDbContext = this._operationsContextFactory.Create())
                {
                    var sync_Impo = new Sync_impo()
                    {
                        Id = 0,
                        EmpresaId = empresaid,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Archivolocal = localFullPath,
                        Archivoremoto = remoteFullPath,
                        Nombre = fileName,
                        Reenviado = BoolCN.N,
                        Sucursalorigenclave = null,
                        //Doctoserie = item.Serie,
                        CreadoPorId = userId,
                        ModificadoPorId = userId,
                        Tipoimpoid = DBValues.FileType_Producto,
                        Estatusimpoid = DBValues.Status_Bajado_id,
                        Fechahorarecepcion = fechaHoraArchivoRemoto != null ?  DateTime.SpecifyKind(fechaHoraArchivoRemoto.Value, DateTimeKind.Utc).AddMinutes(1) : DateTimeOffset.UtcNow,
                        //Fechahoraproceso =
                        Sucursalorigenid = null,
                        //Doctoid = item.Id,
                        //Doctofolio = item.Folio//,
                        //Personaid = item.Clienteid != null ? item.Clienteid,

                    };


                    operationsDbContext.Sync_impo.Add(sync_Impo);
                    operationsDbContext.SaveChanges();

                    //if (sync_Impo == null)
                    //    throw new Exception("No podimos registrar la importacion");

                    ImportCatalogs(empresaid, sucursalId, empresaClave, sucursalClave);

                    sync_Impo.Estatusimpoid = DBValues.Status_Completo_id;
                    operationsDbContext.Sync_impo.Update(sync_Impo);
                    operationsDbContext.SaveChanges();
                    //comentado sync_ImpoDaoProvider.Update(sync_Impo, null);
                }


            }

            return true;
        }


        public bool ImportCatalogs(long empresaid, long sucursalid, string empresaClave, string sucursalFuenteClave)
        {


            string impoZipExpoFile = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_Productos + "\\" + ImpoExpoConstants.FileLocalLocation_CatalogsExpo_FileNameZip;
            string impoBufferFullPath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_ProductosBuffer;



            if (!File.Exists(impoZipExpoFile))
                return false;


            if (Directory.Exists(impoBufferFullPath))
                DeleteDirectory(impoBufferFullPath);

            Directory.CreateDirectory(impoBufferFullPath);

            System.IO.Compression.ZipFile.ExtractToDirectory(impoZipExpoFile, impoBufferFullPath);

            long? doctoId = null;

            using (var operationsDbContext = this._operationsContextFactory.Create())
            {


                (new LineaImpoExpoService()).Import(empresaid,sucursalid, null, ref doctoId, null, "linea", impoBufferFullPath, operationsDbContext);
                (new MarcaImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "marca", impoBufferFullPath, operationsDbContext);

                (new UnidadImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "unidad", impoBufferFullPath, operationsDbContext);
                (new BancoImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "banco", impoBufferFullPath, operationsDbContext);
                (new SubtipoclienteImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "subticli", impoBufferFullPath, operationsDbContext);
                (new TerminalpagoservicioImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "terminal", impoBufferFullPath, operationsDbContext);
                (new MerchantpagoservicioImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "merchant", impoBufferFullPath, operationsDbContext);
                (new ClerkpagoservicioImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "clerk", impoBufferFullPath, operationsDbContext);
                (new ContenidoImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "contenido", impoBufferFullPath, operationsDbContext);
                (new ClasificaImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "clasifica", impoBufferFullPath, operationsDbContext);
                (new TipodiferenciainventarioImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "tipodifinv", impoBufferFullPath, operationsDbContext);
                (new TasaivaImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "tasaiva", impoBufferFullPath, operationsDbContext);
                (new GruposucursalImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "gposucursal", impoBufferFullPath, operationsDbContext);
                (new PlazoImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "plazo", impoBufferFullPath, operationsDbContext);
                (new GastoImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "gasto", impoBufferFullPath, operationsDbContext);
                (new PromocionImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "promo", impoBufferFullPath, operationsDbContext);
                (new ProveedorImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "prov", impoBufferFullPath, operationsDbContext);
                (new Sucursal_infoImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "sucext", impoBufferFullPath, operationsDbContext);
                (new EstadopaisImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "estadop", impoBufferFullPath, operationsDbContext);
                (new ProductoImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "prod", impoBufferFullPath, operationsDbContext);
                (new KitdefinicionImpoExpoService()).Import(empresaid, sucursalid, null, ref doctoId, null, "kitdef", impoBufferFullPath, operationsDbContext);
            }

            return true;
        }



        public async Task ExportArchivosPendientes(long empresaid, long sucursalid, string sucursalFuenteClave, string empresaClave)
        {

            var sync_expoPendientes = ObtainListaArchivosPendientesAExportar(empresaid, sucursalid);


            if (sync_expoPendientes != null)
            {

                foreach (var expofile in sync_expoPendientes.Where(y => y.Tipoexpoid == DBValues._EXP_FILES_TIPO_TRASLADO_ID))
                {
                    try
                    {
                        await ExportTraslado(empresaid, sucursalid, sucursalFuenteClave, empresaClave, expofile.Doctoid!.Value, expofile.Id);
                    }
                    catch { }
                }
            }
        }

        public async Task<bool> ExportTraslado(long empresaid, long sucursalid, string sucursalFuenteClave, string empresaClave, long doctoId, long? syncExpoId)
        {

            Sync_expo? sync_Expo = null;
            try
            {
                string expoBufferFullPath = ImpoExpoConstants.ImpoExpoBasePath + ImpoExpoConstants.FileLocalLocation_TrasladosEnvios;

                string expoFileNamePart1 = "";
                string expoLocalFileDBF = "";

                string expoFileName = "";

                var nameFileInS3 = "";
                var filePathInS3 = "";

                Docto? item = null;

                using (var operationsDbContext = this._operationsContextFactory.Create())
                {
                    item = operationsDbContext.Docto.AsNoTracking()
                                                  .Include(d => d.Docto_traslado).ThenInclude(t => t!.Sucursalt)
                                                  .FirstOrDefault(d => d.EmpresaId == empresaid && d.SucursalId == sucursalid && d.Id == doctoId);

                    if (item == null || item.Docto_traslado?.Sucursaltid == null)
                        throw new Exception("No se encontro la sucursal destino");


                    expoFileNamePart1 = "M" + item.Folio.ToString();
                    expoLocalFileDBF = expoBufferFullPath + "/" + expoFileNamePart1 + ".DBF";

                    expoFileName = expoFileNamePart1 + "." + sucursalFuenteClave;


                    if (Directory.Exists(expoBufferFullPath))
                        DeleteDirectory(expoBufferFullPath);

                    Directory.CreateDirectory(expoBufferFullPath);

                    //doctoProvider



                    (new TrasladoImpoExpoService(_proveeduriaService)).Export(empresaid, sucursalid, expoFileNamePart1, expoBufferFullPath, operationsDbContext, doctoId);


                    Thread.Sleep(1000);
                    await Task.Delay(1);//todo es solo para evitar el warning de que no requiere el "async" y creo que si lo requerira en algun momento

                    nameFileInS3 = expoFileName;
                    filePathInS3 = System.Net.WebUtility.UrlEncode(empresaClave + "/" + (item.Docto_traslado.Sucursalt?.Clave ?? "") + "/" + ImpoExpoConstants.RemoteTraslaFolder);

                    //record the impo/expo operation in database if not exist
                    if (syncExpoId == null)
                    {
                        sync_Expo = new Sync_expo()
                        {
                            Id = 0,
                            EmpresaId = empresaid,
                            SucursalId = sucursalid,
                            Activo = BoolCS.S,
                            Archivolocal = expoLocalFileDBF,
                            Archivoremoto = filePathInS3,
                            Nombre = nameFileInS3,
                            Reenviado = BoolCN.N,
                            Sucursaldestinoclave = item.Docto_traslado!.Sucursalt!.Clave,
                            //comentado Doctoserie = item.Serie,
                            CreadoPorId = item.CreadoPorId,
                            ModificadoPorId = item.CreadoPorId,
                            Tipoexpoid = TipoExpoFileByTipoDocto(item.Tipodoctoid!.Value),
                            Estatusexpoid = DBValues._EXP_FILES_ESTADOS_ENPROCESO_ID,
                            Fechahoracreacion = DateTimeOffset.UtcNow,
                            //Fechahoraenvio = sucursalid,
                            Sucursaldestinoid = item.Docto_traslado.Sucursaltid,
                            Doctoid = item.Id//comentado ,
                                             //comentado Doctofolio = item.Folio//,
                                             //Personaid = item.Clienteid != null ? item.Clienteid,

                        };

                        operationsDbContext.Add(sync_Expo);
                        operationsDbContext.SaveChanges();

                    }
                    else
                    {
                        sync_Expo = operationsDbContext.Sync_expo
                                                       .FirstOrDefault(s => s.EmpresaId == empresaid && s.SucursalId == sucursalid &&
                                                                             s.Id == syncExpoId);

                        if (sync_Expo == null)
                            throw new Exception("No se pudo leer el registro de exportacion");

                    }



                    ///{nameFileInS3}/{filePathInS3}
                    var passwordApi = ImpoExpoConstants.ImpoExpoApiPassword;
                    var fileType = FileTypeByTipoDocto(item.Tipodoctoid!.Value);
                    var client = new RestClient(ImpoExpoConstants.ImpoExpoApi);
                    var request = new RestRequest($"/syncWS/{empresaClave}/uploadFileByType/{sucursalFuenteClave}/sucdest/{item.Docto_traslado.Sucursalt!.Clave}/filename/{nameFileInS3}/type/{fileType}/pass/{passwordApi}", Method.Post);
                    request.AddFile(nameFileInS3, expoLocalFileDBF);


                    var taskResponse = client.ExecuteAsync(request);
                    RestSharp.RestResponse? response = null;

                    Task continuation = taskResponse.ContinueWith(t =>
                    {
                        Console.WriteLine(t.Result.Content);
                        response = t.Result;
                    });

                    continuation.Wait(30000);


                    if (response == null || response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        sync_Expo.Estatusexpoid = DBValues._EXP_FILES_ESTATUS_AGREGADO_ID;
                        //comentado this.sync_ExpoDaoProvider.Update(sync_Expo, null);
                        throw new Exception(response?.ErrorMessage ?? "Response nulo");
                    }

                    sync_Expo.Estatusexpoid = DBValues._EXP_FILES_ESTADOS_ENVIADO_ID;
                    sync_Expo.Fechahoraenvio = DateTimeOffset.UtcNow;

                    operationsDbContext.Update(sync_Expo);
                    operationsDbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ;
            }
            finally
            {

                if (sync_Expo != null && sync_Expo.Estatusexpoid == DBValues._EXP_FILES_ESTADOS_ENPROCESO_ID)
                {
                    sync_Expo.Estatusexpoid = DBValues._EXP_FILES_ESTATUS_AGREGADO_ID;
                    //comentado this.sync_ExpoDaoProvider.Update(sync_Expo, null);
                }
            }
        }



        private long? TipoExpoFileByTipoDocto(long tipoDoctoId)
        {
            switch(tipoDoctoId)
            {
                case DBValues._DOCTO_TIPO_COMPRA_DEVO:
                    return DBValues._EXP_FILES_TIPO_TRASLADO_ID;

                case DBValues._DOCTO_TIPO_PEDIDO_COMPRA:
                    return DBValues._EXP_FILES_TIPO_PEDIDO_ID;

                default:
                    return DBValues._EXP_FILES_TIPO_TRASLADO_ID;
            }
        }

        private string FileTypeByTipoDocto(long tipoDoctoId)
        {

            switch (tipoDoctoId)
            {
                case DBValues._DOCTO_TIPO_COMPRA_DEVO:
                    return ImpoExpoConstants._REMOTE_FILE_TYPE_TRASLADOSDEVO;

                case DBValues._DOCTO_TIPO_PEDIDO_COMPRA:
                    return ImpoExpoConstants._REMOTE_FILE_TYPE_PEDIDO;

                default:
                    return ImpoExpoConstants._REMOTE_FILE_TYPE_TRASLADOS;
            }
        }


        public async Task<List<Sync>?> GetFileList(long empresaid, long sucursalid, 
                                                  string empresaClave, string sucursalClave, 
                                                  string path, DateTime minDate)
        {

            var filePathInS3 = System.Net.WebUtility.UrlEncode(path);
            var client = new RestClient(ImpoExpoConstants.ImpoExpoApi);
            var minDateStr = minDate.ToString( "yyyy'-'MM'-'dd'T'HH':'mm':'ss", System.Globalization.CultureInfo.InvariantCulture);
            var passwordApi = ImpoExpoConstants.ImpoExpoApiPassword;
            var strRequest = $"/syncWS/{empresaClave}/GetFileList/{sucursalClave}/pass/{passwordApi}/minDate/{minDateStr}";
            //var strRequest = $"/values/{empresaClave}/getFileList/{sucursalClave}/path/{filePathInS3}/minDate/{minDateStr}";
            var request = new RestRequest(strRequest, Method.Get);
            


            var taskResponse = client.ExecuteAsync(request);
            RestSharp.RestResponse? response = null;

            Task continuation = taskResponse.ContinueWith(t =>
            {
                Console.WriteLine(t.Result.Content);
                response = t.Result;
            });

            continuation.Wait(30000);

            await Task.Delay(1);//todo es solo para evitar el warning de que no requiere el "async" y creo que si lo requerira en algun momento

            if (response?.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response?.ErrorMessage ?? "Response es nulo");

            var responseContent = response.Content; 
            var optionsSerializer = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var listSync = responseContent != null ?
                                JsonSerializer.Deserialize<List<Sync>>(responseContent, optionsSerializer) :
                                new List<Sync>();

            return listSync;

        }

        public async Task<bool> SaveFileFromS3(long empresaid, long sucursalId, string empresaClave, string sucursalClave, string remotePath, string localPath, long remoteFileId)
        {

            var filePathInS3 = System.Net.WebUtility.UrlEncode(remotePath);
            var client = new RestClient(ImpoExpoConstants.ImpoExpoApi);
            var passwordApi = ImpoExpoConstants.ImpoExpoApiPassword;
            var strRequest = $"/syncWS/{empresaClave}/DownloadFile/{sucursalClave}/path/{filePathInS3}/fileId/{remoteFileId}/pass/{passwordApi}";
            var request = new RestRequest(strRequest, Method.Get);



            var taskResponse = client.ExecuteAsync(request);
            RestSharp.RestResponse? response = null;

            Task continuation = taskResponse.ContinueWith(t =>
            {
                Console.WriteLine(t.Result.Content);
                response = t.Result;
            });

            continuation.Wait(30000);

            await Task.Delay(1);//todo es solo para evitar el warning de que no requiere el "async" y creo que si lo requerira en algun momento

            if (response?.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response?.ErrorMessage ?? "Response es nulo");
            var bytes = response.RawBytes;

            if (bytes != null)
            {
                if (File.Exists(localPath))
                    File.Delete(localPath);

                var stream = File.Create(localPath);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                stream.Close();
                stream.Dispose();
            }

            return true;
        }



        public async Task<bool> MoveFilesInS3(long empresaid, long sucursalId, string empresaClave, string sucursalClave, string filePathFrom, string filePathTo)
        {

            var filePathFromInS3 = System.Net.WebUtility.UrlEncode(filePathFrom);
            var filePathToInS3 = System.Net.WebUtility.UrlEncode(filePathTo);
            var client = new RestClient(ImpoExpoConstants.ImpoExpoApi);
            var strRequest = $"/values/{empresaClave}/MoveFiles/{sucursalClave}/filePathFrom/{filePathFromInS3}/filePathTo/{filePathToInS3}";
            var request = new RestRequest(strRequest, Method.Post);



            var taskResponse = client.ExecuteAsync(request);
            RestSharp.RestResponse? response = null;

            Task continuation = taskResponse.ContinueWith(t =>
            {
                Console.WriteLine(t.Result.Content);
                response = t.Result;
            });

            continuation.Wait(30000);

            await Task.Delay(1);//todo es solo para evitar el warning de que no requiere el "async" y creo que si lo requerira en algun momento

            if (response?.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response?.ErrorMessage ?? "Response es nulo");


            return true;
        }



        public async Task ImportarArchivosPendientes(long empresaid, long sucursalid,
                                                     string empresaClave, string sucursalFuenteClave,
                                                     long? usuarioId, string localPath)
        {

            try
            {


                var path = ImpoExpoConstants.RemoteTraslaFolder;
                var dateTimeMinDate = DateTime.Parse("01/01/2000"); ;
                using (var operationsDbContext = this._operationsContextFactory.Create())
                {
                    dateTimeMinDate = ObtainLastImpoCatalogDate(empresaid, sucursalid, operationsDbContext) ?? DateTime.Parse("01/01/2000");
                }

                List<Sync>? remoteTrasladosPendientes = null;

                remoteTrasladosPendientes = await GetFileList(empresaid, sucursalid, empresaClave, sucursalFuenteClave,
                                                                path + "/", dateTimeMinDate);

                var localPathTraslados = localPath + ImpoExpoConstants.FileLocalLocation_Traslados;
                var localPathSolicitudMercancia = localPath + ImpoExpoConstants.FileLocalLocation_SolicitudMercaRecepcion;

                foreach (var remoteFile in remoteTrasladosPendientes?.Where(r => r.Tiposyncclave == ImpoExpoConstants._REMOTE_FILE_TYPE_TRASLADOS ||
                                                                                r.Tiposyncclave == ImpoExpoConstants._REMOTE_FILE_TYPE_TRASLADOSDEVO) ?? Enumerable.Empty<Sync>())
                {
                    try
                    {
                        if (remoteFile.Archivoremoto == null || usuarioId == null || remoteFile.Id == null || remoteFile.Nombre == null)
                            continue;

                        await this.ImportTraslado(empresaid, sucursalid, empresaClave, sucursalFuenteClave,
                                                              localPathTraslados, remoteFile.Archivoremoto, usuarioId.Value, remoteFile.Id.Value, remoteFile.Nombre);
                    }
                    catch { }
                }


                foreach (var remoteFile in remoteTrasladosPendientes?.Where(r => r.Tiposyncclave == ImpoExpoConstants._REMOTE_FILE_TYPE_PEDIDO) ?? Enumerable.Empty<Sync>())
                {
                    try
                    {
                        if (remoteFile.Archivoremoto == null || usuarioId == null || remoteFile.Id == null || remoteFile.Nombre == null)
                            continue;

                        await this.ImportPedido(empresaid, sucursalid, empresaClave, sucursalFuenteClave,
                                                              localPathSolicitudMercancia, remoteFile.Archivoremoto, usuarioId.Value, remoteFile.Id.Value, remoteFile.Nombre);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

                //var archivoPendienteCatalogo = remoteTrasladosPendientes.Where(r => r.Tiposyncclave == ImpoExpoConstants._REMOTE_FILE_TYPE_CATALOGOS).OrderByDescending(y => y.Fechahoracreacion).FirstOrDefault();
                //if (archivoPendienteCatalogo != null)
                //{
                //    try
                //    {
                //        await this.ImportCatalogsFromServer(empresaid, sucursalid, empresaClave, sucursalFuenteClave,
                //                                               archivoPendienteCatalogo.Archivoremoto, usuarioId.Value, archivoPendienteCatalogo.Id.Value, archivoPendienteCatalogo.Nombre, 
                //                                               (archivoPendienteCatalogo.Modificado != null ? archivoPendienteCatalogo.Modificado : archivoPendienteCatalogo.Fechahoracreacion));
                //    }
                //    catch(Exception ex) {
                //        Console.WriteLine(ex.Message);
                //    }
                //}
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public async Task<bool> ImportTraslado(long empresaid, long sucursalId, string empresaClave, string sucursalClave, string localPath, string remoteFileFullName, long userId, long remoteFileId, string fileName)
        {

            string localFileName = fileName + ".dbf";
            string localFullPath = localPath + @"\" + localFileName;
            string remoteFullPath = remoteFileFullName;

            var downloaded = await SaveFileFromS3(empresaid, sucursalId,
                                                  empresaClave, sucursalClave,
                                                  remoteFullPath, localFullPath, remoteFileId);
            var sucursalOrigenClave = fileName.Split('.').LastOrDefault();

            if (sucursalOrigenClave == null)
                throw new Exception("Mal nombre");


            using (var operationsDbContext = this._operationsContextFactory.Create())
            {

                var sucOrigen = operationsDbContext.Sucursal_info
                                                   .FirstOrDefault(s => s.EmpresaId == empresaid && s.SucursalId == sucursalId && 
                                                                 s.Clave == sucursalClave);

                if (sucOrigen == null)
                    throw new Exception("No podemos identificar la sucursal origen");


                if (downloaded)
                {

                    var sync_Impo = new Sync_impo()
                    {
                        Id = 0,
                        EmpresaId = empresaid,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Archivolocal = localFullPath,
                        Archivoremoto = remoteFullPath,
                        Nombre = fileName,
                        Reenviado = BoolCN.N,
                        Sucursalorigenclave = sucOrigen.Clave,
                        //Doctoserie = item.Serie,
                        CreadoPorId = userId,
                        ModificadoPorId = userId,
                        Tipoimpoid = DBValues.FileType_Traslados,
                        Estatusimpoid = DBValues.Status_Bajado_id,
                        Fechahorarecepcion = DateTimeOffset.UtcNow,
                        //Fechahoraproceso =
                        Sucursalorigenid = sucOrigen.Id
                        //Doctoid = item.Id,
                        //Doctofolio = item.Folio//,
                        //Personaid = item.Clienteid != null ? item.Clienteid,

                    };

                    operationsDbContext.Add(sync_Impo);
                    operationsDbContext.SaveChanges();


                    if (sync_Impo == null)
                        throw new Exception("No podimos registrar la importacion");

                    //comentado doctoProvider.ImportFromDbf_traslado_impoexpo(empresaid, sucursalId,
                    //comentado sucursalOrigenClave, userId,  localFileName, localPath);


                    long? doctoIdRef = null;
                    (new TrasladoImpoExpoService(_proveeduriaService)).Import(empresaid, sucursalId, userId, ref doctoIdRef, DBValues._DOCTO_TIPO_TRASPASO_REC,  localFileName, localPath, operationsDbContext);


                    sync_Impo.Estatusimpoid = DBValues.Status_Completo_id;
                    operationsDbContext.Update(sync_Impo);
                    operationsDbContext.SaveChanges();


                    //var remoteFileBackup = remoteFullPath.Replace(ImpoExpoConstants.RemoteTraslaFolder, "Backup/" + ImpoExpoConstants.RemoteTraslaFolder);

                    //await MoveFilesInS3(empresaid, sucursalId,
                    //                    empresaClave, sucursalClave,
                    //                    remoteFullPath, remoteFileBackup);
                }
            }

            return true;
        }



        public async Task<bool> ImportPedido(long empresaid, long sucursalId, string empresaClave, string sucursalClave, string localPath, string remoteFileFullName, long userId, long remoteFileId, string fileName)
        {

            string localFileName = fileName + ".dbf";
            string localFullPath = localPath + @"\" + localFileName;
            string remoteFullPath = remoteFileFullName;

            var downloaded = await SaveFileFromS3(empresaid, sucursalId,
                                                  empresaClave, sucursalClave,
                                                  remoteFullPath, localFullPath, remoteFileId);
            var sucursalOrigenClave = fileName.Split('.').LastOrDefault();

            if (sucursalOrigenClave == null)
                throw new Exception("Mal nombre");


            using (var operationsDbContext = this._operationsContextFactory.Create())
            {

                var sucOrigen = operationsDbContext.Sucursal_info
                                                   .FirstOrDefault(s => s.EmpresaId == empresaid && s.SucursalId == sucursalId &&
                                                                 s.Clave == sucursalClave);

                if (sucOrigen == null)
                    throw new Exception("No podemos identificar la sucursal origen");


                if (downloaded)
                {

                    var sync_Impo = new Sync_impo()
                    {
                        Id = 0,
                        EmpresaId = empresaid,
                        SucursalId = sucursalId,
                        Activo = BoolCS.S,
                        Archivolocal = localFullPath,
                        Archivoremoto = remoteFullPath,
                        Nombre = fileName,
                        Reenviado = BoolCN.N,
                        Sucursalorigenclave = sucOrigen.Clave,
                        //Doctoserie = item.Serie,
                        CreadoPorId = userId,
                        ModificadoPorId = userId,
                        Tipoimpoid = DBValues.FileType_SolicitudMercancia,
                        Estatusimpoid = DBValues.Status_Bajado_id,
                        Fechahorarecepcion = DateTimeOffset.UtcNow,
                        //Fechahoraproceso =
                        Sucursalorigenid = sucOrigen.Id
                        //Doctoid = item.Id,
                        //Doctofolio = item.Folio//,
                        //Personaid = item.Clienteid != null ? item.Clienteid,

                    };

                    operationsDbContext.Add(sync_Impo);
                    operationsDbContext.SaveChanges();


                    if (sync_Impo == null)
                        throw new Exception("No podimos registrar la importacion");

                    //comentado doctoProvider.ImportFromDbf_traslado_impoexpo(empresaid, sucursalId,
                    //comentado sucursalOrigenClave, userId,  localFileName, localPath);


                    long? doctoIdRef = null;
                    (new TrasladoImpoExpoService(_proveeduriaService)).Import(empresaid, sucursalId, userId, ref doctoIdRef, DBValues._DOCTO_TIPO_TRASPASO_ENVIO_BORRADOR, localFileName, localPath, operationsDbContext);


                    sync_Impo.Estatusimpoid = DBValues.Status_Completo_id;
                    operationsDbContext.Update(sync_Impo);
                    operationsDbContext.SaveChanges();


                    //var remoteFileBackup = remoteFullPath.Replace(ImpoExpoConstants.RemoteTraslaFolder, "Backup/" + ImpoExpoConstants.RemoteTraslaFolder);

                    //await MoveFilesInS3(empresaid, sucursalId,
                    //                    empresaClave, sucursalClave,
                    //                    remoteFullPath, remoteFileBackup);
                }
            }

            return true;
        }




        private DateTime? ObtainLastImpoCatalogDate(long empresaid, long sucursalId, ApplicationDbContext localContext)
        {

            //var sqlQuery = $@"Select * from synchronization.v_sync_impo 
            //                            where 
            //                                  Empresaid = {empresaid.ToString()} and
            //                                  Sucursalid = {sucursalId.ToString()} and
            //                                  Tipoimpoid = 2 and
            //                                  Estatusimpoid = 2 
            //                     order by fechahorarecepcion desc
            //                     limit 1
            //                                    ";

            //KendoParams emptyParam = new KendoParams("", "",
            //                                        new KendoFilters(new List<KendoFilter>() { }, "and"));

            //comentado var lastCatalogImpoRecord = sync_ImpoDaoProvider.SelectList(null, new Sync_impoParam(empresaid, sucursalId), null, sqlQuery)?.FirstOrDefault();

            //comentado if (lastCatalogImpoRecord != null)
            //comentado return lastCatalogImpoRecord.Fechahorarecepcion.Value;


            var sync_impo = localContext.Sync_impo.AsNoTracking()
                            .OrderByDescending(x => x.Fechahorarecepcion)
                            .FirstOrDefault( s => s.EmpresaId == empresaid && s.SucursalId == sucursalId && 
                            s.Tipoimpoid == DBValues.FileType_Producto && s.Estatusimpoid == DBValues.Status_Completo_id)
                            ;

            DateTime dateRecepcion = sync_impo!.Fechahorarecepcion != null ? sync_impo!.Fechahorarecepcion!.Value.ToDateTime() : DateTime.Parse("2000-01-01");
            return sync_impo != null ? new DateTimeOffset(dateRecepcion, TimeZoneInfo.Local.GetUtcOffset(dateRecepcion)).UtcDateTime : null;

        }

        public List<Sync_expo>? ObtainListaArchivosPendientesAExportar(long empresaid, long sucursalid)
        {

            KendoParams sync_expoParam = new KendoParams("", "",
                                                    new KendoFilters(new List<KendoFilter>() {
                                                            new KendoFilter(DBValues._EXP_FILES_ESTATUS_AGREGADO_ID.ToString(), "eq", "Estatusexpoid", "S") }, "and"));

            //comentado var sync_expoPendientes = sync_ExpoDaoProvider.SelectList(null, new Sync_expoParam(empresaid, sucursalid), sync_expoParam)?.ToList();
            //comentado return sync_expoPendientes;
            return null;

        }

        public async Task TestUploadFile()
        {


            var expoZipExpoFile = ImpoExpoConstants.ImpoExpoBasePath +  @"\testupload.zip";
            var nameFileInS3 = "testupload.zip";
            var filePathInS3 = "compania01";
            var client = new RestClient("http://testmomus-staging.eba-nv9ryvpv.us-east-1.elasticbeanstalk.com/api"); 
            var request = new RestRequest($"/values/{nameFileInS3}/uploadFile/{filePathInS3}", Method.Post);
            request.AddFile("prec.zip", expoZipExpoFile);


            var taskResponse = client.ExecuteAsync(request);
            RestSharp.RestResponse? response = null;

            Task continuation = taskResponse.ContinueWith(t =>
            {
                Console.WriteLine(t.Result.Content);
                response = t.Result;
            });

            continuation.Wait(30000);

            await Task.Delay(1);//todo es solo para evitar el warning de que no requiere el "async" y creo que si lo requerira en algun momento

            if (response?.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response?.ErrorMessage ?? "Reponse es nulo");

        }

    }
}
