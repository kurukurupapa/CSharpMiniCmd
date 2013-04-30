using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MiniFilePropChanger
{
    public partial class ProgressForm : Form
    {
        private BackgroundWorker worker = null;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public void SetBackgroundWorker(BackgroundWorker worker)
        {
            this.worker = worker;
        }

        private void ProgressForm_Shown(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.RunWorkerAsync();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
            Close();
        }

        public void SetMessage(string msg)
        {
            tboxMessage.Text = msg;
        }
    }
}
