using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosData
{

    public class ExportacionesConstants
    {

        public static  string m_versionExportacionSQLite = "SQLite";
        public static  string m_versionExportacionDBF = "DBF";
    }
    public interface ICOMMOND
    {

        string IComentario { get; set; }
        string IComentarioAdicional { get; set; }
    }

    public interface IPRODD: ICOMMOND
    {
        
        bool AgregarPROD_MOVIL(CPRODBE oCPROD, string strFileName, string strOleDbConn);
    }


    public interface IMCLIPD:ICOMMOND
    {
        bool AgregarM_CLIPD(CM_CLIPBE oCM_CLIP, string strFileName, string strOleDbConn);
        
    }


    public interface IMPROVD : ICOMMOND
    {
        bool AgregarM_PROVD(CM_PROVBE oCM_CLIP, string strFileName, string strOleDbConn);

    }

    public interface IMBANKD : ICOMMOND
    {
        bool AgregarM_BANKD(CM_BANKBE oCM_BANK, string strFileName, string strOleDbConn);

    }


    public interface IMCREPD : ICOMMOND
    {
        bool AgregarM_CREPD(CM_CREPBE oCM_CREP, string strFileName, string strOleDbConn);

    }

    public interface IMEDOSD : ICOMMOND
    {
        bool AgregarM_EDOSD(CM_EDOSBE oCM_EDOS, string strFileName, string strOleDbConn);

    }
    public interface IMKITSD : ICOMMOND
    {
        bool AgregarM_KITSD(CM_KITSBE oCM_KITS, string strFileName, string strOleDbConn);

    }



    public interface IMUSERD : ICOMMOND
    {
        bool AgregarM_USERD(CM_USERBE oCM_USER, string strFileName, string strOleDbConn);
    }

    public interface IMPARMD : ICOMMOND
    {
        bool AgregarM_PARMD(CM_PARMBE oCM_PARM, string strFileName, string strOleDbConn);
    }



    public interface IMDERD : ICOMMOND
    {
        bool AgregarM_DERD(CM_DERBE oCM_DER, string strFileName, string strOleDbConn);
    }

    public interface IMDERUD : ICOMMOND
    {
        bool AgregarM_DER_UD(CM_DER_UBE oCM_DER_U, string strFileName, string strOleDbConn);
    }

}
