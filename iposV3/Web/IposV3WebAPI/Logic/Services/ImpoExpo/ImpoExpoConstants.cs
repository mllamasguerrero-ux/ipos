using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{
    public class ImpoExpoConstants
    {

        public const string ImpoExpoApi = "http://localhost:49154/api";
        public const string ImpoExpoApiPassword = "p4222";

        public const string ImpoExpoBasePath = @"C:\temporal\dbftest";

        //Exportacion

        public const string FileLocalLocation_Pedidos = "\\in\\";
        public const string FileLocalLocation_Pedidos_Molde = "\\in\\Molde";

        public const string FileLocalLocation_SolicitudMercancia = "\\solicitudMercancia";


        public const string FileLocalLocation_Ventas = "\\bases\\";
        public const string FileLocalLocation_Ventas_Molde = "\\bases\\Molde";


        public const string FileLocalLocation_TrasladosEnvios = "\\trasEnv";
        public const string FileLocalLocation_TrasladosEnvios_Molde = "\\trasEnv\\Molde";
        public const string FileLocalLocation_TrasladosEnviosAux = "\\trasEnv_aux";


        public const string FileLocalLocation_TrasladosDevoEnvios = "\\trasDevoEnv";
        public const string FileLocalLocation_TrasladosDevoEnvios_Molde = "\\trasDevoEnv\\Molde";


        public const string FileLocalLocation_PedidosDevoEnvios = "\\pedidosDevo";
        public const string FileLocalLocation_PedidosDevoEnvios_Molde = "\\pedidosDevo\\Molde";


        public const string FileLocalLocation_ExistenciasLocales = "\\existenciasLocales\\";
        public const string FileLocalLocation_ExistenciasLocales_Molde = "\\existenciasLocales\\Molde";

        public const string FileLocalLocation_CatalogsExpo_FolderBuffer = "\\matriz\\precios\\prec";
        public const string FileLocalLocation_CatalogsExpo_Folder = "\\matriz\\precios";
        public const string FileLocalLocation_CatalogsExpo_FileNameZip = "prec.zip";



        //Importacion

        public const string FileLocalLocation_RecCompras = "\\pedidos";
        public const string FileLocalLocation_RecComprasAux = "\\pedidos_aux";

        public const string FileLocalLocation_Productos = "\\precios";
        public const string FileLocalLocation_ProductosBuffer = "\\precios\\prec";

        public const string FileLocalLocation_Traslados = "\\TRASLA";
        public const string FileLocalLocation_TrasladosAux = "\\TRASLA_aux";

        public const string FileLocalLocation_TrasladosDevo = "\\TRASLADEVO\\";

        public const string FileLocalLocation_PedidosDevo = "\\matriz\\devolucionessucursales";

        public const string FileLocalLocation_ExistenciasGenerales = "\\ExistenciasGenerales";

        public const string FileLocalLocation_PreciosTemp = "\\preciostemp";

        public const string FileLocalLocation_SolicitudMercaRecepcion = "\\solicitudMercaRecepcion";

        public const string FileLocalLocation_MatrizPedidosSucursales = "\\matriz\\pedidossucursales";

        //replicacion

        public const string FileLocalLocation_ReplTemp_Expo = "\\replicacion";



        public const string RemoteTraslaFolder = @"TRASLA";


        //file types

        public const string _REMOTE_FILE_TYPE_CATALOGOS = "CAT";
        public const string _REMOTE_FILE_TYPE_TRASLADOS = "T";
        public const string _REMOTE_FILE_TYPE_TRASLADOSDEVO = "TD";
        public const string _REMOTE_FILE_TYPE_PEDIDO = "P";
    }
}
