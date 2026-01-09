using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPos.Tools
{
    public class FbDbFixer
    {
        private string filePath;

        public string FilePath { get => filePath; set => filePath = value; }

        public FbDbFixer()
        {

        }

        public bool CheckForErrors()
        {
            string checkForErrorsCmds = CreateCmdText(GetCheckErrorsCmds(filePath));

            string checkForErrorsResults = CmdHelper.ExecuteCommand(checkForErrorsCmds);

            return !checkForErrorsResults.Equals("\n\n");
        }

        public string FixErrors()
        {
            filePath = filePath.ToLower();

            if (File.Exists(filePath.Replace(".fdb", "_original_backup.fdb")))
                File.Delete(filePath.Replace(".fdb", "_original_backup.fdb"));

            File.Copy(filePath, filePath.Replace(".fdb", "_original_backup.fdb"));

            string cmdOutput = String.Empty;

            string fixResults = CmdHelper.ExecuteCommand(CreateCmdText(GetFixDbCmds(filePath)));

            string newFileCheckErrorsResult =
                CmdHelper.ExecuteCommand(CreateCmdText(GetCheckErrorsCmds(filePath.Replace(".fdb", "_fixed.fdb"))));

            if (newFileCheckErrorsResult.Equals("\n\n"))
            {
                cmdOutput = fixResults + "\n\n New file errors: NO ERRORS FOUND!!!";

                File.Replace(
                    filePath.Replace(".fdb", "_fixed.fdb"),
                    filePath,
                    filePath.Replace(".fdb", "_backup.fdb")
                );
            }
            else
            {
                cmdOutput = fixResults + "\n\nNew file errors: " + newFileCheckErrorsResult;
            }

            if(File.Exists(filePath.Replace(".fdb", "_fixed.fdb")))
                File.Delete(filePath.Replace(".fdb", "_fixed.fdb"));

            if(File.Exists(filePath.Replace(".fdb", ".fbk")))
                File.Delete(filePath.Replace(".fdb", ".fbk"));

            return cmdOutput;
        }

        private List<string> GetCheckErrorsCmds(string path)
        {
            List<string> commands = new List<string>();
            commands.Add(
                "/C cd \"C:\\Program Files (x86)\\Firebird\\Firebird_2_5\\bin\""
            );

            commands.Add(
                "gfix.exe -v -full -user SYSDBA -pass masterkey \"" + path + "\""
            );

            return commands;
        }

        private List<string> GetFixDbCmds(string path)
        {
            string newFileName = path.Replace(".fdb", "_fixed.fdb");
            string backUpFileName = path.Replace("fdb", "fbk");

            List<string> commands = new List<string>();
            commands.Add(
                "/C cd \"C:\\Program Files (x86)\\Firebird\\Firebird_2_5\\bin\""
            );

            commands.Add(
                "gfix.exe -v -full -user SYSDBA -pass masterkey \"" + path + "\""
            );

            commands.Add(
                "gfix.exe -mend -ig -user SYSDBA -pass masterkey \"" + path + "\""

                );

            commands.Add(
                "gbak -b -g -v -user SYSDBA -pass masterkey  \"" +
                path + "\"" + " \"" + backUpFileName + "\""

                );

            commands.Add(
                "gbak -c -v -user SYSDBA -pass masterkey \"" + backUpFileName + "\" \"" + newFileName + "\"&&exit"
                );

            return commands;
        }

        private string CreateCmdText(List<string> commands)
        {
            string finalCmd = String.Empty;

            for (int i = 0; i < commands.Count; i++)
            {
                if (i < commands.Count - 1)
                    finalCmd += commands[i] + "&&";
                else
                    finalCmd += commands[i];
            }

            return finalCmd;
        }
    }
}
