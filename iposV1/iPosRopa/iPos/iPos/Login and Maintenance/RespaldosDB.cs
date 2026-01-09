using iPos.Tools;
using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iPos
{
    public class RespaldosDB
    {

        public bool requiereRespaldo()
        {
            if (CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT == null || !CurrentUserID.CurrentCompania.IHABILITAR_IMPEXP_AUT.Equals("S"))
                return false;

            //string straux = CurrentUserID.CurrentParameters.IFECHARESPALDO.ToString();
            if ((!(bool)CurrentUserID.CurrentParameters.isnull["IFECHARESPALDO"]) && CurrentUserID.CurrentParameters.IFECHARESPALDO != null && CurrentUserID.CurrentParameters.IRUTARESPALDO != null && CurrentUserID.CurrentParameters.IRUTARESPALDO != "")
            {
                if (CurrentUserID.CurrentParameters.IFECHARESPALDO.Date < DateTime.Today.Date)
                {
                    return true;
                }
            }
            else if ( (  ((bool)CurrentUserID.CurrentParameters.isnull["IFECHARESPALDO"]) || CurrentUserID.CurrentParameters.IFECHARESPALDO == null) && CurrentUserID.CurrentParameters.IRUTARESPALDO != null && CurrentUserID.CurrentParameters.IRUTARESPALDO != "")
            {
                
                return true;
                
            }
            
           return false;
        }

        public bool respaldarDB()
        {
            CPARAMETROBE before = new CPARAMETROBE();
            CPARAMETROBE after = new CPARAMETROBE();
            CPARAMETROD cparametrod = new CPARAMETROD();

            CSUCURSALD sucursalD = new CSUCURSALD();
            CSUCURSALBE sucursalBE = new CSUCURSALBE();
            sucursalBE.ICLAVE = CurrentUserID.SUCURSAL_CLAVE;

            sucursalBE = sucursalD.seleccionarSUCURSALPorClave(sucursalBE, null);

            string strOriginalDBLocation = iPos.CurrentUserID.DBLocation;
            string strCopyDBLocation = CurrentUserID.CurrentParameters.IRUTARESPALDO + "\\" + sucursalBE.INOMBRERESPALDOBD + ".fdb";
            string strBackupLocation = CurrentUserID.CurrentParameters.IRUTARESPALDO + "\\" + sucursalBE.INOMBRERESPALDOBD + ".zip";

            try
            {
                File.Copy(strOriginalDBLocation, strCopyDBLocation, true);

                ZipUtil.ZipFile(strCopyDBLocation, strBackupLocation, "");

                if (File.Exists(strCopyDBLocation))
                    File.Delete(strCopyDBLocation);

                before = CurrentUserID.CurrentParameters;
                CurrentUserID.CurrentParameters.IFECHARESPALDO = DateTime.Now;
                after = CurrentUserID.CurrentParameters;
                cparametrod.CambiarPARAMETROD(after, before, null);
            }
            catch
            {

            }


            return true;
            
        }
    }
}
