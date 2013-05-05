using MiniLauncher.Model;
using System;
using System.Windows.Forms;

namespace MiniLauncher
{
    public partial class CmdForm : System.Windows.Forms.Form
    {
        public CmdForm()
        {
            InitializeComponent();
        }

        private void CmdForm_Load(object sender, EventArgs e)
        {
        }

        public Cmd GetCmd()
        {
            Cmd cmd = new ExecutionCmd();
            cmd.name = nameTextBox.Text;
            cmd.description = descriptionTextBox.Text;
            cmd.path = pathTextBox.Text;
            cmd.arg = argTextBox.Text;
            return cmd;
        }

        public void SetCmd(Cmd cmd)
        {
            nameTextBox.Text = cmd.name;
            descriptionTextBox.Text = cmd.description;
            pathTextBox.Text = cmd.path;
            argTextBox.Text = cmd.arg;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
