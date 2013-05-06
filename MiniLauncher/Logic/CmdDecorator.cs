using MiniLauncher.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniLauncher.Logic
{
    class CmdDecorator
    {
        private Cmd cmd;

        internal CmdDecorator(Cmd cmd)
        {
            this.cmd = cmd;
        }

        internal void Start()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = cmd.path;
            proc.StartInfo.Arguments = cmd.arg;
            proc.Start();
        }

    }
}
