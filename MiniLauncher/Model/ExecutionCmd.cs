using System.Diagnostics;

namespace MiniLauncher.Model
{
    class ExecutionCmd : Cmd
    {
        public ExecutionCmd()
            : base()
        {
        }

        public ExecutionCmd(string cmdline)
            : base(cmdline)
        {
        }

        public override void Start()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = path;
            proc.Start();
        }
    }
}
