using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;
using System.Collections;

namespace IposV3.Services
{
    public class MovtoService
    {
        private KitdefinicionService _kitDefinicionService;
        private ImpuestosService _impuestoSevice;
        private InventarioService _inventarioSevice;
        //private DoctoService _doctoService;
        public MovtoService(KitdefinicionService kitDefinicionService, 
                            ImpuestosService impuestoService,
                            InventarioService inventarioSevice//,
                            //DoctoService doctoService
            )
        {
            _kitDefinicionService = kitDefinicionService;
            _impuestoSevice = impuestoService;
            _inventarioSevice = inventarioSevice;
            //_doctoService = doctoService;
        }



        public void MovtoUpdateStatus(
              long empresaId, long sucursalId, long id,long estatusMovtoId,
            ApplicationDbContext localContext)
        {


            long? oldestatusmovtoid = null;
            long? productoid = null;
            long? almacenid = null;
            long? tipodoctoid = null;
            decimal? cantidad = null;


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                var movtoInfo = localContext.Movto.AsNoTracking()
                                            .Include(m => m.Docto)
                                            .Include(m => m.Movto_devolucion)
                                            .Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == id)
                                            .Select(m => new { m.Estatusmovtoid, m.Productoid, m.Docto!.Almacenid, m.Docto.Tipodoctoid, m.Cantidad, MovtoRefDevolucionId = (m.Movto_devolucion != null ? m.Movto_devolucion.Movtorefid : null), m.CreadoPorId })
                                            .FirstOrDefault();

                if (movtoInfo == null)
                    throw new Exception("No se encontro el movimiento");


                oldestatusmovtoid = movtoInfo.Estatusmovtoid;
                productoid = movtoInfo.Productoid;
                almacenid = movtoInfo.Almacenid;
                tipodoctoid = movtoInfo.Tipodoctoid;
                cantidad = movtoInfo.Cantidad;

                var movto = localContext.Movto.Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Id == id)
                                            .FirstOrDefault();

                movto!.Estatusmovtoid = estatusMovtoId;
                localContext.Update(movto);

                if (oldestatusmovtoid == 0 && estatusMovtoId == 1)
                {
                    _inventarioSevice.MovtoInventarioAplicar(empresaId, sucursalId, id, localContext);

                    _inventarioSevice.MovtoAplicarEnProcesoSalida(empresaId, sucursalId, id, (cantidad!.Value * -1), localContext);

                    if ((movtoInfo.MovtoRefDevolucionId ?? 0) != 0)
                    {
                        Movto_devolucion_aplicar(empresaId, sucursalId, id,
                                                    movtoInfo.MovtoRefDevolucionId!.Value, localContext);
                    }
                }


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }

        public void Movto_devolucion_aplicar(long empresaId, long sucursalId, 
                                                long movtoId , 
                                                long movtoRefDevolucionId, 
                                                ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try {

                var bufferIsNewRecord = false;

                var movto_referencia_devolucion = localContext.Movto_devolucion
                                                              .Where(md => md.EmpresaId == empresaId && md.SucursalId == sucursalId &&
                                                                           md.Movtoid == movtoRefDevolucionId)
                                                              .FirstOrDefault();


                var movto_referencia = localContext.Movto.AsNoTracking()
                                                    .Include(m => m.Docto).ThenInclude(d => d!.Tipodocto)
                                                   .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId &&
                                                               x.Id == movtoRefDevolucionId)
                                                   .Select(m => new { m.Cantidad, Sentidoinventario = (m.Docto != null & m.Docto!.Tipodocto != null) ? m.Docto!.Tipodocto!.Sentidoinventario : 0 })
                                                   .FirstOrDefault();

                var movto_devolucion_info = localContext.Movto.AsNoTracking()
                                                    .Include(m => m.Docto).ThenInclude(d => d!.Tipodocto)
                                                   .Where(x => x.EmpresaId == empresaId && x.SucursalId == sucursalId &&
                                                               x.Id == movtoId)
                                                   .Select(m => new { m.CreadoPorId, m.Cantidad, Sentidoinventario = (m.Docto != null & m.Docto!.Tipodocto != null) ? m.Docto!.Tipodocto!.Sentidoinventario : 0 })
                                                   .FirstOrDefault();


                if (movto_devolucion_info == null)
                    throw new Exception("NO existe el regsitro de movto de la devolucion");

                if (movto_referencia == null)
                    throw new Exception("NO existe el regsitro de movto que se devolvio");



                decimal cantidadDevuelta = (movto_devolucion_info.Sentidoinventario != movto_referencia.Sentidoinventario ? 1m : -1m) * movto_devolucion_info.Cantidad; 



                if (movto_referencia_devolucion == null)
                {

                    if (movto_referencia == null)
                        throw new Exception("la referencia de movto no existe");

                    movto_referencia_devolucion = new Movto_devolucion();
                    movto_referencia_devolucion.EmpresaId = empresaId;
                    movto_referencia_devolucion.SucursalId = sucursalId;
                    movto_referencia_devolucion.Creado = DateTimeOffset.UtcNow;
                    movto_referencia_devolucion.Modificado = DateTimeOffset.UtcNow;
                    movto_referencia_devolucion.CreadoPorId = movto_devolucion_info.CreadoPorId;
                    movto_referencia_devolucion.ModificadoPorId = movto_devolucion_info.CreadoPorId;
                    movto_referencia_devolucion.Movtoid = movtoRefDevolucionId;
                    movto_referencia_devolucion.Movtorefid = null;
                    movto_referencia_devolucion.Cantidadsurtida = movto_referencia.Cantidad;
                    movto_referencia_devolucion.Cantidadfaltante = 0m;
                    movto_referencia_devolucion.Cantidaddevuelta = 0m;
                    movto_referencia_devolucion.Razondiferenciaid = null;
                    movto_referencia_devolucion.Otrarazondiferencia = null;

                    bufferIsNewRecord = true;
                }
                else
                    bufferIsNewRecord = false;

                movto_referencia_devolucion.Cantidaddevuelta = movto_referencia_devolucion.Cantidaddevuelta + cantidadDevuelta;
                movto_referencia_devolucion.Cantidadsaldo = movto_referencia_devolucion.Cantidadsurtida - movto_referencia_devolucion.Cantidaddevuelta;


                if (bufferIsNewRecord)
                    localContext.Add(movto_referencia_devolucion);
                else
                    localContext.Update(movto_referencia_devolucion);

                localContext.SaveChanges();

            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }
        }

        public void CalcularImpuestosTotalesMovto(
              long empresaId, long sucursalId, long productoId,
              decimal cantidad, decimal precioLista,
              decimal? tasaIva, decimal? tasaIeps,
              BoolCN esKit, BoolCN kitImpFijo, BoolCN calc_imp_de_total,
              long? movtoRefId, long? clienteId,
              ref decimal? precio, ref decimal? precioconimp, ref decimal? total,

              out decimal? importe, out decimal? subtotal, out decimal? iva, out decimal? ieps, 
              out decimal? impuesto, out decimal? descuento, 
              out decimal? ivaRetenido, out decimal? isrRetenido, 
              out decimal? tasaIvaRetenido, out decimal? tasaIsrRetenido,
              out List<MovtoKitdefinicionBuffer> movto_kit_def_arr, ApplicationDbContext localContext
            )
        {


            var retieneisr = BoolCN.N;
            var retieneiva = BoolCN.N;


            importe = 0m;
            subtotal = 0m;
            iva = 0m;
            ieps = 0m;
            impuesto = 0m;
            descuento = 0m;
            ivaRetenido = 0m;
            isrRetenido = 0m;
            tasaIvaRetenido = 0m;
            tasaIsrRetenido = 0m;
            tasaIva = tasaIva == null ? 0 : tasaIva;
            tasaIeps = tasaIeps == null ? 0 : tasaIeps;
            movto_kit_def_arr = new List<MovtoKitdefinicionBuffer>();


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try {

                var parametro = localContext.Parametro.AsNoTracking()
                                                       .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                                       .Select(p => new { p.Retencionisr, p.Retencioniva })
                                                       .FirstOrDefault();
                tasaIsrRetenido = parametro?.Retencionisr;
                tasaIvaRetenido = parametro?.Retencioniva;


                Cliente? cliente;
                if(clienteId != null)
                {
                    cliente = localContext.Cliente.AsNoTracking().Include(c => c.Cliente_fact_elect).FirstOrDefault(c => c.EmpresaId == empresaId && c.SucursalId == sucursalId && c.Id == clienteId.Value);
                    retieneiva = cliente?.Cliente_fact_elect?.Retieneiva ?? BoolCN.N;
                    retieneisr = cliente?.Cliente_fact_elect?.Retieneisr ?? BoolCN.N;
                }




                if (esKit == BoolCN.S && kitImpFijo == BoolCN.N)
                {

                    if (calc_imp_de_total == BoolCN.S)
                    {
                        precio = null;
                        _kitDefinicionService.CalcularImpuestosTotalesKitMovto(empresaId, sucursalId, productoId,
                            cantidad, precioconimp ?? 0m, movtoRefId, ref precio, ref total,
                            out subtotal, out iva, out ieps, out movto_kit_def_arr, localContext);

                    }
                    else
                    {
                        precioconimp = null;
                        total = null;
                        _kitDefinicionService.CalcularImpuestosTotalesKitMovto(empresaId, sucursalId, productoId,
                            cantidad, precioconimp, movtoRefId, ref precio, ref total,
                            out subtotal, out iva, out ieps, out movto_kit_def_arr, localContext);
                    }
                }
                else
                {
                    //precio = null;
                    decimal? dummy_precio = precio;
                    decimal? dummy_total = total;
                    decimal? dummy_subtotal = null;
                    decimal? dummy_iva = null;
                    decimal? dummy_ieps = null;

                    if (calc_imp_de_total == BoolCN.S)
                    { 

                        precio = null;
                        dummy_precio = null;

                        _kitDefinicionService.CalcularImpuestosTotalesKitMovto(empresaId, sucursalId, productoId,
                            cantidad, precioconimp ?? 0m, movtoRefId, ref dummy_precio, ref dummy_total,
                            out dummy_subtotal, out dummy_iva, out dummy_ieps, out movto_kit_def_arr, localContext);

                        _impuestoSevice.CalcularImpuestos(tasaIva ?? 0m, tasaIeps ?? 0m,
                                                          cantidad, ref precioconimp, ref precio,
                                                          ref total, out iva, out ieps, out subtotal);

                    }
                    else
                    {
                        precioconimp = null;

                        total = null;
                        dummy_total = null;

                        _kitDefinicionService.CalcularImpuestosTotalesKitMovto(empresaId, sucursalId, productoId,
                            cantidad, precioconimp, movtoRefId, ref dummy_precio, ref dummy_total,
                            out dummy_subtotal, out dummy_iva, out dummy_ieps, out movto_kit_def_arr, localContext);

                        _impuestoSevice.CalcularImpuestos(tasaIva ?? 0m, tasaIeps ?? 0m,
                                                          cantidad, ref precioconimp, ref precio,
                                                          ref total, out iva, out ieps, out subtotal);

                    }
                }

                importe = cantidad * precioLista;
                subtotal = cantidad * precio;
                descuento = precioLista - precio;
                impuesto = iva + ieps;
                total = subtotal + impuesto;

                ivaRetenido = Math.Round((retieneiva == BoolCN.S && tasaIvaRetenido != null && tasaIvaRetenido.Value > 0) ?
                                             subtotal!.Value * (tasaIvaRetenido!.Value / 100m)  :  0m, 4);


                isrRetenido = Math.Round((retieneisr == BoolCN.S && tasaIsrRetenido != null && tasaIsrRetenido.Value > 0) ?
                                             subtotal!.Value * (tasaIsrRetenido!.Value / 100m) : 0m, 4);





            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }


        public void ProcesarMovtoKitDefFromArray(
              long empresaId, long sucursalId, long movtoId,
                List<MovtoKitdefinicionBuffer> movto_kit_def_arr, 
                ApplicationDbContext localContext)
        {


            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {
                if (movto_kit_def_arr == null || movto_kit_def_arr.Count == 0)
                    return;

                var productKitid = movto_kit_def_arr.First().Productokitid;

                var movto_kit_defItems = localContext.Movto_kit_def.Where(m => m.EmpresaId == empresaId && m.SucursalId == sucursalId && m.Movtoid == movtoId &&
                                                                m.Productokitid == productKitid).ToList();// && m.Productoparteid == mkd.Productoparteid);


                foreach (var mkd in movto_kit_def_arr)
                {
                    var movto_kit_defItem = movto_kit_defItems.FirstOrDefault(y => y.Productoparteid == mkd.Productoparteid);

                    if (movto_kit_defItem != null)
                    {

                        movto_kit_defItem.Cantidadparte = mkd.Cantidadparte;
                        movto_kit_defItem.Costoparte = mkd.Costoparte;
                        movto_kit_defItem.Tasaieps = mkd.Iepsimpuesto ?? 0m;
                        movto_kit_defItem.Tasaiva = mkd.Ivaimpuesto ?? 0m;
                        movto_kit_defItem.Cantidadpartetotal = mkd.Cantidad ?? 0m;
                        movto_kit_defItem.Precioporunidad = mkd.Preciosinimpuesto ?? 0m;
                        movto_kit_defItem.Montototal = mkd.Totalamount ?? 0m;
                        movto_kit_defItem.Montosubtotal = mkd.Subtotalkit ?? 0m;
                        movto_kit_defItem.Montoiva = mkd.Ivakit ?? 0m;
                        movto_kit_defItem.Montoieps = mkd.Iepskit ?? 0m;



                    }
                    else
                    {
                        movto_kit_defItem = new Movto_kit_def();
                        movto_kit_defItem.EmpresaId = empresaId;
                        movto_kit_defItem.SucursalId = sucursalId;
                        movto_kit_defItem.Movtoid = movtoId;
                        movto_kit_defItem.Productokitid = mkd.Productokitid;
                        movto_kit_defItem.Productokitid = mkd.Productokitid;
                        movto_kit_defItem.Productoparteid = mkd.Productoparteid;
                        movto_kit_defItem.Cantidadparte = mkd.Cantidadparte;
                        movto_kit_defItem.Costoparte = mkd.Costoparte;
                        movto_kit_defItem.Tasaieps = mkd.Iepsimpuesto ?? 0m;
                        movto_kit_defItem.Tasaiva = mkd.Ivaimpuesto ?? 0m;
                        movto_kit_defItem.Cantidadpartetotal = mkd.Cantidad ?? 0m;
                        movto_kit_defItem.Precioporunidad = mkd.Preciosinimpuesto ?? 0m;
                        movto_kit_defItem.Montototal = mkd.Totalamount ?? 0m;
                        movto_kit_defItem.Montosubtotal = mkd.Subtotalkit ?? 0m;
                        movto_kit_defItem.Montoiva = mkd.Ivakit ?? 0m;
                        movto_kit_defItem.Montoieps = mkd.Iepskit ?? 0m;

                        localContext.Movto_kit_def.Add(movto_kit_defItem);

                    }

                }

                localContext.SaveChanges();


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }
        }





        public void Movto_command_decipher(long empresaId, long sucursalId, string commandtext,
                                            ref Movto_command_deciphered comando_decifrado, 
                                            ApplicationDbContext localContext)
        {

            var previousLazyLoadingEnabledValue = localContext.ChangeTracker.LazyLoadingEnabled;
            localContext.ChangeTracker.LazyLoadingEnabled = false;

            try
            {

                comando_decifrado.Preguntacantidad = false;
                comando_decifrado.Esean = false;
                comando_decifrado.Esempaque = false;
                comando_decifrado.Escaja = false;
                comando_decifrado.Tieneprefijobascula = false;
                comando_decifrado.Cantidadaux = 0m;
                comando_decifrado.Productoid = null;

                var productoEncontrado = localContext.Producto.AsNoTracking()
                                                          .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                      p.Activo == BoolCS.S &&
                                                                      (
                                                                        (p.Ean != null && p.Ean.Trim().ToLower() == commandtext.Trim().ToLower()) ||
                                                                        (p.Cbarras != null && p.Cbarras.Trim().ToLower() == commandtext.Trim().ToLower()) ||
                                                                        (p.Cempaque != null && p.Cempaque.Trim().ToLower() == commandtext.Trim().ToLower()) ||
                                                                        (p.Clave != null && p.Clave.Trim().ToLower() == commandtext.Trim().ToLower())

                                                                      )
                                                                )
                                                          .Select(p => new { p.Id, p.Ean, p.Cbarras, p.Cempaque })
                                                          .FirstOrDefault();
                if (productoEncontrado != null)
                {
                    comando_decifrado.Esean = (productoEncontrado.Ean != null && productoEncontrado.Ean.Trim().ToLower() == commandtext.Trim().ToLower());
                    comando_decifrado.Escaja = (productoEncontrado.Cbarras != null && productoEncontrado.Cbarras.Trim().ToLower() == commandtext.Trim().ToLower());
                    comando_decifrado.Esempaque = (productoEncontrado.Cempaque != null && productoEncontrado.Cempaque.Trim().ToLower() == commandtext.Trim().ToLower());
                    comando_decifrado.Productoid = productoEncontrado.Id;
                    return;
                }


                var parametro = localContext.Parametro.AsNoTracking()
                                            .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId)
                                            .Select(p => new { p.Longpesobascula, p.Longprodbascula, p.Prefijobascula })
                                            .FirstOrDefault();

                if (parametro == null)
                    throw new Exception("No hay parametro ");




                if ((parametro.Prefijobascula ?? "") != "" && (parametro.Longpesobascula ?? 0) > 0 &&
                    (parametro.Longprodbascula ?? 0) > 0 && commandtext.StartsWith(parametro.Prefijobascula ?? "") &&
                     commandtext.Length >= parametro.Prefijobascula!.Length + parametro.Longprodbascula + parametro.Longpesobascula)
                {

                    var buffercommandtext = commandtext.Substring(parametro.Prefijobascula!.Length, parametro.Longprodbascula!.Value);

                    var productoPlug = localContext.Producto.AsNoTracking()
                                                          .Where(p => p.EmpresaId == empresaId && p.SucursalId == sucursalId &&
                                                                      p.Activo == BoolCS.S &&
                                                                      (
                                                                        (p.Plug != null && p.Plug.Trim().ToLower() == buffercommandtext.Trim().ToLower())
                                                                      )
                                                                )
                                                          .FirstOrDefault();
                    if (productoPlug != null)
                    {
                        comando_decifrado.Tieneprefijobascula = true;
                        buffercommandtext = commandtext.Substring(parametro.Prefijobascula!.Length + parametro.Longprodbascula!.Value, parametro.Longpesobascula!.Value);


                        decimal buffer_cantidadaux = 0m;
                        decimal.TryParse(buffercommandtext, out buffer_cantidadaux);
                        comando_decifrado.Cantidadaux = buffer_cantidadaux;


                    }


                }


            }
            catch
            {
                throw;
            }
            finally
            {
                localContext.ChangeTracker.LazyLoadingEnabled = previousLazyLoadingEnabledValue;
            }

        }





        public Movto_command_deciphered? DecipherCommand(long empresaId, long sucursalId, string commandText, 
                                                        ApplicationDbContext localContext)
        {

            bool bLastAssigned = false; // ultima busqueda
            string texto = commandText;
            decimal cantidad = 0m;
            Movto_command_deciphered retorno = new Movto_command_deciphered();

            string bufferBusquedaText = texto;
            if (bufferBusquedaText.Contains(" <(("))
            {
                string[] strSeparators = new string[] { " <((" };


                string[] strBuffert = bufferBusquedaText.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (strBuffert.Count() > 1)
                {

                    //ultima busqueda
                    bLastAssigned = true;
                    bufferBusquedaText = strBuffert[strBuffert.Count() - 1];


                    string[] strSeparatorsBeta = new string[] { "))>" };

                    string[] strBufferz = bufferBusquedaText.Split(strSeparatorsBeta, StringSplitOptions.RemoveEmptyEntries);
                    if (strBufferz.Count() > 0)
                        bufferBusquedaText = strBufferz[0];

                    if (bufferBusquedaText.Trim().Length > 0)
                        texto = bufferBusquedaText.Trim();
                }

            }

            ArrayList splitChars = new ArrayList();
            splitChars.Add('*');
            splitChars.Add('%');
            string commandLine = texto;
            ArrayList commandElemts = SplitCommandLine(commandLine, splitChars);
            int prodIndex = -1, cantIndex = -1, /*descIndex = -1,*/ contIndex;

            decimal cantidadAux = 1;


            contIndex = 0;
            foreach (Object objComm in commandElemts)
            {
                contIndex++;
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if ( pvComm.commandOper == ' ')
                {

                    this.Movto_command_decipher(empresaId, sucursalId, pvComm.commandText, ref retorno!, localContext);

                    if (retorno != null && retorno.Productoid != null)
                    {
                        //ultima busqueda
                        if (!bLastAssigned)
                        {
                            bLastAssigned = true;
                        }


                        prodIndex = contIndex;
                        break;
                    }
                }

            }

            contIndex = 0;
            foreach (Object objComm in commandElemts)
            {
                contIndex++;
                if (contIndex == prodIndex)
                {
                    continue;
                }
                PVCommandElement pvComm = (PVCommandElement)objComm;
                if (pvComm.commandOper == '*' || pvComm.commandOper == ' ')
                {
                    Decimal buffCant;
                    if (Decimal.TryParse(pvComm.commandText, out buffCant))
                    {
                        cantidad = buffCant;
                        cantIndex = contIndex;
                        break;
                    }
                }

            }


            cantidad = cantidad * ((cantidadAux == 0) ? 1 : cantidadAux);

            //retorno.Producto = prod;
            if (retorno != null)
            {
                retorno.Cantidad = cantidad;
            }

            return retorno;
        }


        public ArrayList SplitCommandLine(string commandLine, ArrayList splitChars)
        {
            ArrayList commandElemts = new ArrayList();
            PVCommandElement elemInicial = new PVCommandElement();
            elemInicial.commandText = commandLine;
            elemInicial.commandOper = ' ';
            commandElemts.Add(elemInicial);
            foreach (Object objSep in splitChars)
            {
                char[] cSep = new char[1];
                cSep[0] = (char)objSep;
                ArrayList BufferArr = new ArrayList();
                foreach (Object objComm in commandElemts)
                {
                    PVCommandElement pvComm = (PVCommandElement)objComm;

                    string[] splittedComm = pvComm.commandText.Split(cSep, StringSplitOptions.RemoveEmptyEntries);
                    int numSplittedStr = splittedComm.Count();
                    for (int iSplitIndex = 0; iSplitIndex < numSplittedStr; iSplitIndex++)
                    {
                        PVCommandElement bufferElem = new PVCommandElement();
                        bufferElem.commandText = splittedComm[iSplitIndex];
                        if (iSplitIndex == 0 && numSplittedStr > 1)
                        {
                            bufferElem.commandOper = cSep[0]/*pvComm.commandOper*/;
                        }
                        else
                        {
                            bufferElem.commandOper = pvComm.commandOper/*cSep[0]*/;
                        }
                        BufferArr.Add(bufferElem);
                    }
                }
                commandElemts.Clear();
                commandElemts = (ArrayList)BufferArr.Clone();
            }
            return commandElemts;
        }


    }

    public class MovtoTransaccion : TransitionClass
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Id { get; set; }
        public BoolCS? Activo { get; set; }
        public DateTimeOffset? Creado { get; set; }
        public long? Creadopor_userid { get; set; }
        public int? Partida { get; set; }
        public long? Estatusmovtoid { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public DateTimeOffset? Fechahora { get; set; }
        public long? Productoid { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Preciolista { get; set; }
        public decimal? Descuentoporcentaje { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Ieps { get; set; }
        public decimal? Tasaiva { get; set; }
        public decimal? Tasaieps { get; set; }
        public decimal? Total { get; set; }
        public string? Lote { get; set; }
        public DateTimeOffset? Fechavence { get; set; }
        public long? Loteimportado { get; set; }
        public long? Movtoparentid { get; set; }
        public int? Movtonivel { get; set; }
        public BoolCS? Afectainventario { get; set; }
        public BoolCS? Afectatotales { get; set; }
        public BoolCN? Eskit { get; set; }
        public BoolCN? Kitimpfijo { get; set; }
        public long? Doctoid { get; set; }
        public decimal? Cargo { get; set; }
        public decimal? Abono { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? Preciomanual { get; set; }
        public decimal? Preciomaximopublico { get; set; }
        public decimal? Isrretenido { get; set; }
        public decimal? Ivaretenido { get; set; }
        public int? Orden { get; set; }
        public decimal? Tasaisrretenido { get; set; }
        public decimal? Tasaivaretenido { get; set; }
        public BoolCN? Calc_imp_de_total { get; set; }
        public string? Localidad { get; set; }
        public string? Descripcion1 { get; set; }
        public string? Descripcion2 { get; set; }
        public string? Descripcion3 { get; set; }
        public BoolCN? Agrupaporparametro { get; set; }
        public BoolCN? Cargartarjetapreciomanual { get; set; }
        public BoolCN? Precioyavalidado { get; set; }
        public long? Usuarioid { get; set; }
        public decimal? Precioconimp { get; set; }
        public long? Anaquelid { get; set; }
        public long? Movtoadevolverid { get; set; }

    }

    struct PVCommandElement
    {
        public string commandText;
        public char commandOper;
    }
}
