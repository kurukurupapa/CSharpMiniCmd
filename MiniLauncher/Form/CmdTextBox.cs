using MiniLauncher.Model;
using System.Windows.Forms;

namespace MiniLauncher.Form
{
    internal class CmdTextBox : TextBox
    {
        //public void Clear()
        //{
        //    Text = string.Empty;
        //}

        public Cmd Cmd
        {
            get
            {
                return new ExecutionCmd(Text);
            }
        }

        internal void AddFileList(string[] fileName)
        {
            // TODO とりあえず、ドラッグ&ドロップされた1件目のデータをテキストボックスに表示する。
            Text = fileName[0];
        }
    }
}
