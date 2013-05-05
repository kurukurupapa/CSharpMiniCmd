using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MiniLauncher
{
    public abstract class Cmd
    {
        public enum CommandType
        {
            Execution,
            Setting
        }

        public string name;
        public string description;
        //public CommandType type;
        public string path;
        public string arg;

        public Cmd()
        {
            // 処理なし
        }

        public Cmd(string cmdline)
        {
            string[] arr = SplitCmdLine(cmdline);

            name = cmdline;
            description = cmdline;
            //type = CommandType.Execution;
            path = arr[0];
            arg = arr[1];
        }

        private string[] SplitCmdLine(string cmdline)
        {
            string[] arr = new string[2];
            cmdline = cmdline.Trim();
            // TODO 実行ファイルパスのスペースを考慮する
            Regex regex = new Regex("^([^ ]+) (.+)$", RegexOptions.IgnoreCase);
            Match match = regex.Match(cmdline);
            if (match.Success)
            {
                arr[0] = match.Groups[1].Value;
                arr[1] = match.Groups[2].Value;
            }
            else
            {
                arr[0] = cmdline;
                arr[1] = null;
            }
            return arr;
        }

        public abstract void Start();

        public override string ToString()
        {
            return name;
        }

    }
}
