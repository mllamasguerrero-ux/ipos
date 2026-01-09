using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using ConexionesBD;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.Services;
using System.Net;
using System.Globalization;
using System.Diagnostics;

namespace iPosData
{
    public class ActualizacionesBD
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
        private string sCadenaConexion;


        public const string FolderMetadataUpdates = "sampdata\\MDUpdates\\";
        public const string FolderMetadataRespaldos = "sampdata\\DBRespaldos\\";
        public int numberOfFiles;

        public ActualizacionesBD()
        {
            numberOfFiles = new int();
            this.sCadenaConexion = ConexionBD.ConexionString();
        }


        public long GetCurrentAppVersion()
        {
            return 7045; 
        }

        public bool SelectIPOS_ACTUALIZADOR_LastVersion(ref long lastVersion, FbTransaction st)
        {
            string query = "SELECT LASTVERSION FROM IPOS_ACTUALIZADOR";

            FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, query, out pcn);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, query);

                while (dr.Read())
                {

                    string auxVersion = dr["LASTVERSION"].ToString();
                    if (!string.IsNullOrEmpty(auxVersion))
                    {
                        lastVersion = long.Parse(auxVersion);
                    }

                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return true;
            }
            catch (Exception ex)
            {

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                iComentario = ex.Message;

                return false;
            }
        }

        public long GetCurrentDBVersion()
        {
            long lDBVersion = -1;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                String CmdTxt = @"select NUMVERSION from VERSION ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);


                if (dr.Read())
                {

                    if (dr["NUMVERSION"] != System.DBNull.Value)
                    {
                        lDBVersion = (long)(dr["NUMVERSION"]);
                    }

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return lDBVersion;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }

        }



        private ArrayList ListaArchivosAEjecutar(long lDBVersion, long lNewVersion)
        {
            ArrayList retorno = new ArrayList();
            string strBuffer;
            string strFolderUpdates = System.AppDomain.CurrentDomain.BaseDirectory + FolderMetadataUpdates;

            for (long i = lDBVersion + 1; i <= lNewVersion; i++)
            {
                strBuffer = i.ToString().PadLeft(8, '0') + ".sql";
                strBuffer = strFolderUpdates + strBuffer;
                retorno.Add(strBuffer);
            }
            return retorno;
         
        }

        public bool RequiereActualizacionesDeBD()
        {
            //ActualizarPasswords();

            long lDBVersion = 0, lAppVersion = 1;

            lDBVersion = GetCurrentDBVersion();
            lAppVersion = GetCurrentAppVersion();

            if (lDBVersion < lAppVersion)
                return true;

            return false;

            
        }


        public bool RespaldarBD(long currentVersion, string strDBLocation, string strNombreEmpresa, CEMPRESASBE empresaBE)
        {

            bool bServer = false;

            string strIp = empresaBE.IEM_SERVER.ToLower().Trim();


            if (strIp.Equals("localhost"))
            {
                bServer = true;
            }
            else
            {
                IPAddress compareIp = IPAddress.Parse(strIp);
                string strCompareIp = compareIp.ToString().ToLower().Trim();
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());


                foreach (IPAddress ip in localIPs)
                {
                    string sIp = ip.ToString().ToLower().Trim();
                    if (sIp.Equals(strCompareIp))
                    {
                        bServer = true;
                    }
                }
            }

            if(bServer)
            {
                try
                {
                    return RespaldarBD_copy(currentVersion, strDBLocation, strNombreEmpresa);
                }
                catch(Exception ex)
                {

                    MessageBox.Show("No se pudo hacer el respaldo fdb de la empresa " + ex.Message);
                    return false;
                }
            }
            else
            {
                try
                {
                    return RespaldarBD_fbk(currentVersion, strDBLocation, strNombreEmpresa);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo hacer el respaldo fbk de la empresa " + ex.Message);
                    return false;
                }
                
            }


        }

        public bool RespaldarBD_copy(long currentVersion, string strDBLocation, string strNombreEmpresa)
        {

            string strBackupLocation = System.AppDomain.CurrentDomain.BaseDirectory  + FolderMetadataRespaldos + strNombreEmpresa + "." + currentVersion.ToString();
            File.Copy(strDBLocation, strBackupLocation,true);
            return true;



        }


        static void ServiceOutput(object sender, ServiceOutputEventArgs e)
        {
            Console.WriteLine(e.Message);
        }



        public bool CorregirBD(string path, string dbName)
        {
            string auxBackupFileName = Path.GetFileNameWithoutExtension(path);
            string auxBackupPath = Path.GetDirectoryName(path);
            string auxBackupBd = auxBackupPath + "/" + auxBackupFileName + "_copia_ml.fdb";

            File.Copy(path, auxBackupBd);

            FbConnection.ClearAllPools();
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "menddb.bat";
            p.StartInfo.Arguments = String.Format("\"{0}\" ", auxBackupBd);

            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            //string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            FbConnection.ClearAllPools();
            File.Delete(path);
            File.Copy(auxBackupBd, path);
            File.Delete(auxBackupBd);

            return CompactarBD(path, dbName);
            
        }

        public bool CompactarBD(string path, string dbName)
        {
            //iPos.CurrentUserID.DBLocation, iPos.CurrentUserID.CurrentCompania.IEM_NOMBRE, iPos.CurrentUserID.CurrentCompania
            //string strBackupLocation = System.AppDomain.CurrentDomain.BaseDirectory;

            string auxBackupFileName = Path.GetFileNameWithoutExtension(path);
            string auxBackupPath = Path.GetDirectoryName(path);
            string auxBackupBd = auxBackupPath + "/" + auxBackupFileName + ".fbk";

            File.Delete(auxBackupBd);

            FbBackup backupSvc = new FbBackup();

            backupSvc.ConnectionString = sCadenaConexion;
            backupSvc.BackupFiles.Add(new FbBackupFile(auxBackupBd, 2048));
            backupSvc.Verbose = true;

            backupSvc.Options = FbBackupFlags.IgnoreLimbo;

            //backupSvc.ServiceOutput += new ServiceOutputEventHandler(ServiceOutput);

            backupSvc.Execute();
            FbConnection.ClearAllPools();

            FbRestore restoresSvc = new FbRestore();
            restoresSvc.ConnectionString = sCadenaConexion;
            restoresSvc.BackupFiles.Add(new FbBackupFile(auxBackupBd, 2048));
            restoresSvc.Verbose = true;
            restoresSvc.Options = /*FbRestoreFlags.Create |*/ FbRestoreFlags.Replace |/* FbRestoreFlags.NoValidity |*/ FbRestoreFlags.IndividualCommit /*| FbRestoreFlags.NoShadow*/;
            restoresSvc.ServiceOutput += new ServiceOutputEventHandler(ServiceOutput);
            restoresSvc.Execute();

            return true;
        }

        public bool RespaldarBD_fbk(long currentVersion, string strDBLocation, string strNombreEmpresa)
        {
   

            string strBackupLocation = System.AppDomain.CurrentDomain.BaseDirectory + FolderMetadataRespaldos + strNombreEmpresa + "." + currentVersion.ToString() + ".fbk";


            FbBackup backupSvc = new FbBackup();

            backupSvc.ConnectionString = sCadenaConexion;
            backupSvc.BackupFiles.Add(new FbBackupFile(strBackupLocation, 2048));
            backupSvc.Verbose = true;

            backupSvc.Options = FbBackupFlags.IgnoreLimbo;

            //backupSvc.ServiceOutput += new ServiceOutputEventHandler(ServiceOutput);

            backupSvc.Execute();
            

            //File.Copy(strDBLocation, strBackupLocation, true);
            return true;



        }

        public ArrayList FilesForUpdate(string strDBLocation, string strNombreEmpresa, CEMPRESASBE empresaBE)
        {
            long lDBVersion = 0, lAppVersion = 1;
            ArrayList listaArchivosSql = new ArrayList();

            lDBVersion = GetCurrentDBVersion();
            lAppVersion = GetCurrentAppVersion();

            if (lDBVersion < lAppVersion)
            {
                    if(!RespaldarBD(lDBVersion, strDBLocation, strNombreEmpresa, empresaBE))
                    {
                        return null;
                    }
                    //fConn.Open();
                    //fTrans = fConn.BeginTransaction();

                    listaArchivosSql = ListaArchivosAEjecutar(lDBVersion, lAppVersion);
                    numberOfFiles = (int)Decimal.Round((100/listaArchivosSql.Count));
                    if(numberOfFiles < 1)
                    {
                        numberOfFiles = 1;
                    }
                    return listaArchivosSql;
            }
            else
            {
                listaArchivosSql = null;
                return listaArchivosSql;
            }
        }

        public bool ActualizarBD(FileInfo file, ref bool compactar, ref bool corregir)
        {
            string script;

            bool bRes = true;
            
            try
            {
                long iX = GetCurrentDBVersion();

                script = file.OpenText().ReadToEnd();

                try
                {
                    
                    SqlHelper.ExecuteNonQuery(ConexionesBD.ConexionBD.ConexionStringSinPooling(), CommandType.Text, script, null);
                }
                catch(Exception ex)
                {
                     if ((iX + 1) != 2355)
                     {
                        if(ex.Message.Contains("too many versions"))
                        {
                            compactar = true;
                            return false;
                        }
                        else if((iX + 1) >= 5465 && (iX + 1) <= 5467)
                        {
                            ActualizarNumeroVersionEnBD(5464);
                            corregir = true;
                            return false;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                }

                iX++;

                if (iX == DBValues._VERSION_PASSWORDS_ENCRIPTADOS_CON_USUARIO || iX == DBValues._VERSION_PASSWORDS_ENCRIPTADOS)
                {
                    ActualizarPasswords(iX);
                }

                ActualizarNumeroVersionEnBD(iX);
                bRes = true;

                }
                catch(Exception ex)
                {
                    IComentario = ex.Message + "\n" + ex.StackTrace;
                    MessageBox.Show(IComentario);
                    bRes = false;
                }    


            return bRes;
        }


        private void ActualizarNumeroVersionEnBD(long iX)
        {
            SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, "UPDATE VERSION SET NUMVERSION = " + iX.ToString(), null);

        }

        private void ActualizarPasswords(long versionBDAActualizar)
        {
            //ciclo que va ir recorriendo los objeto prsona de tipo usuario y va ir actualizandoles el password
            CPERSONAD daoUser = new CPERSONAD();
            List<CPERSONABE> users = daoUser.seleccionarPERSONAS();

            //long versionBD = GetCurrentDBVersion();

            foreach(CPERSONABE user in users)
            {
                string encryPass = "";
                string pass = "";


                
               // if(versionBD >= DBValues._VERSION_PASSWORDS_ENCRIPTADOS && versionBD < DBValues._VERSION_PASSWORDS_ENCRIPTADOS_CON_USUARIO)
                if (versionBDAActualizar == DBValues._VERSION_PASSWORDS_ENCRIPTADOS_CON_USUARIO)
                {
                    if (user.ICLAVEACCESO == null || user.ICLAVEACCESO == "")
                    {
                        pass = "";
                    }
                    else
                    {

                        pass = iPos.EncDec.Decrypt(user.ICLAVEACCESO, "DryHit");
                    }


                    encryPass = iPos.EncDec.Encrypt(pass, "DryHit" + user.IUSERNAME.Trim());

                }
                else if (versionBDAActualizar == DBValues._VERSION_PASSWORDS_ENCRIPTADOS)
                {
                    pass = user.ICLAVEACCESO;

                    encryPass = iPos.EncDec.Encrypt(pass, "DryHit");
                }
                else
                {
                    return;
                }

                //encryPass = iPos.EncDec.Encrypt(pass, "DryHit" + user.IUSERNAME.Trim());
                user.ICLAVEACCESO = encryPass;
                daoUser.CambiarPERSONAUSUARIO_PASS_D(user, user, null);
            }
        }




    }
}
