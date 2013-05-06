using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniLauncher.Form
{
    public partial class SettingForm : System.Windows.Forms.Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'databaseDataSet.Cmd' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.cmdTableAdapter.Fill(this.databaseDataSet.Cmd);
            databaseDataSet = null;
        }
    }
}
