

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using iPosBusinessEntity;
using DataLayer;

namespace iPosData
{
    public class CM_VISID
    {

        private string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }


        public static CM_VISIBE convertVisitaIntoVISI(CVISITABE visita)
        {



            CM_VISIBE retorno = new CM_VISIBE();
            retorno.IVISITA = Double.Parse(visita.IID.ToString());
            retorno.ICLIENTE = visita.IPERSONACLAVE;
            retorno.IHIZOPEDIDO = visita.IHIZOPEDIDO;
            retorno.IFECHA = visita.IFECHA;
            retorno.IINICIA = visita.IHORAINICIO != null ? visita.IHORAINICIO.ToString("HH:mm:ss") : "";
            retorno.IFINALIZA = visita.IHORAFIN != null ? visita.IHORAFIN.ToString("HH:mm:ss") : "";

            retorno.IID_FECHA = visita.IFECHA;
            retorno.IID_HORA = visita.IHORAINICIO != null ? visita.IHORAINICIO.ToString("HH:mm:ss") : "";
            retorno.IID = visita.IID.ToString();







            return retorno;


        }



    }
}
