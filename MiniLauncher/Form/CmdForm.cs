using MiniLauncher.Model;
using System;
using System.Windows.Forms;

namespace MiniLauncher.Form
{
    internal partial class CmdForm : System.Windows.Forms.Form
    {
        internal Cmd cmd;

        internal Cmd Cmd
        {
            get
            {
                cmd.name = nameTextBox.Text;
                cmd.description = descriptionTextBox.Text;
                cmd.path = pathTextBox.Text;
                cmd.arg = argTextBox.Text;
                return cmd;
            }
            set
            {
                cmd = value;
                nameTextBox.Text = cmd.name;
                descriptionTextBox.Text = cmd.description;
                pathTextBox.Text = cmd.path;
                argTextBox.Text = cmd.arg;
            }
        }

        public CmdForm()
        {
            InitializeComponent();

            cmd = new Cmd();
        }

        private void CmdForm_Load(object sender, EventArgs e)
        {
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
