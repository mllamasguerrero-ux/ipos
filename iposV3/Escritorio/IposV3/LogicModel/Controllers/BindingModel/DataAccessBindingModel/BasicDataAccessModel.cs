
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{

    public enum BoolCS
    {
        S = 0,
        N = 1
    }
    public enum BoolCN
    {
        N = 0,
        S = 1
    }


    public enum BoolCNI
    {
        I = 0,
        N = 1,
        S = 2
    }


    public enum TipoPagoConTarjeta
    {
        I = 0,
        N = 1,
        S = 2,
        D = 3,
        C = 4
    }



    public enum BoolManejoReceta
    {
        N = 0,
        S = 1,
        R = 2
    }


    public enum LetraEnTicket : short
    { Normal, Pequenia }

    public enum FormatTicketCorto : short
    { Normal, Por_linea }

    public enum OrdenImpresion : short
    { Normal, Descripcion, Descripcion1, Descripcion2 }


    public enum FormatoFactura : short
    { Normal, FastReport }


    public enum FiltroProductoSat : short
    { Todos, Parcial, Linea }

    public enum ModoAlertaPV : short
    { Ninguno_Especial, Precio_minimo_costo }

    public enum ConfigPantalla : short
    { Normal, Movil_mediano, Movil_10 }

    public enum TipoSyncMovil : short
    { WS, FTP }

    public enum TipoConexionMovil : short
    { Ninguno, Tipo1, Tipo2, Tipo3, Tipo4 }



}
