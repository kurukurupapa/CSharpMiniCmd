using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSOFile;

namespace MiniFilePropChanger
{
    public partial class FileSelectForm : Form
    {
        public string[] files = new string[]{};

        public FileSelectForm()
        {
            InitializeComponent();
        }

        private void FileSelectForm_Shown(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string file in files)
            {
                sb.Append(file + "\r\n");
            }
            tboxFiles.Text = sb.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            files = tboxFiles.Text.Split(new char[]{'\r','\n'});
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
