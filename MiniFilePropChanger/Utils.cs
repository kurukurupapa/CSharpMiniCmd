using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniFilePropChanger
{
    class Utils
    {
        public static void ShowInformationMessage(string msg)
        {
            MessageBox.Show(msg, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
