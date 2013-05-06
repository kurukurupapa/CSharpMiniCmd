using MiniLauncher.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniLauncher.Logic
{
    internal class CmdFactory
    {
        internal static Cmd CreateCmdWithPath(string path)
        {
            Cmd cmd = new Cmd();
            cmd.name = path;
            cmd.path = path;
            return cmd;
        }

        internal static Cmd CreateCmdWithCmdLine(string cmdLine)
        {
            string[] arr = SplitCmdLine(cmdLine);

            Cmd cmd = new Cmd();
            cmd.name = cmdLine;
            cmd.path = arr[0];
            cmd.arg = arr[1];
            return cmd;
        }

        private static string[] SplitCmdLine(string cmdLine)
        {
            string[] arr = new string[2];
            cmdLine = cmdLine.Trim();
            // TODO 実行ファイルパスのスペースを考慮する
            Regex regex = new Regex("^([^ ]+) (.+)$", RegexOptions.IgnoreCase);
            Match match = regex.Match(cmdLine);
            if (match.Success)
            {
                arr[0] = match.Groups[1].Value;
                arr[1] = match.Groups[2].Value;
            }
            else
            {
                arr[0] = cmdLine;
                arr[1] = string.Empty;
            }
            return arr;
        }


        internal static Cmd CreateSettingCmd()
        {
            Cmd cmd = new Cmd();
            cmd.name = "Setting";
            cmd.type = Cmd.CmdType.Setting;
            return cmd;
        }
    }
}
