using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MiniLauncher.Model
{
    internal class Cmd
    {
        internal enum CmdType
        {
            Execution,
            Setting
        }

        internal string name = string.Empty;
        internal string description = string.Empty;
        internal CmdType type = CmdType.Execution;
        internal string path = string.Empty;
        internal string arg = string.Empty;

        internal Cmd()
        {
            // 処理なし
        }

        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// 実行内容の同一性を判定する。
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool EqualsCmdLine(Cmd cmd)
        {
            return this.path.Equals(cmd.path) &&
                this.arg.Equals(cmd.arg);
        }
    }
}
