using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MiniLauncher
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private CmdLogic cmdListLogic = new CmdLogic();
        //private List<Cmd> cmdList = null;
        private bool cmdListSelectMode = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // コマンド候補リストを更新する。
            cmdListLogic.Update();
            UpdateCmdListBox();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            // 入力された文字列に該当するコマンド候補を表示する。
            UpdateCmdListBox();
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // コマンドラインの内容を実行する。
                    Run();
                    e.Handled = true;
                    break;

                case Keys.Escape:
                    // コマンドラインをクリアする。
                    inputTextBox.Clear();
                    cmdListSelectMode = false;
                    e.Handled = true;
                    break;

                case Keys.Up:
                    cmdListBox.Up();
                    cmdListSelectMode = true;
                    e.Handled = true;
                    break;

                case Keys.Down:
                    cmdListBox.Down();
                    cmdListSelectMode = true;
                    e.Handled = true;
                    break;

                default:
                    cmdListSelectMode = false;
                    break;
            }
        }

        /// <summary>
        /// コマンド候補リストに、引数の内容を表示する。
        /// </summary>
        private void UpdateCmdListBox()
        {
            cmdListBox.CmdList = cmdListLogic.Find(inputTextBox.Text);
        }

        /// <summary>
        /// コマンドを実行する。
        /// </summary>
        private void Run()
        {
            try
            {
                if (cmdListSelectMode)
                {
                    cmdListBox.SelectedCmd.Start();
                }
                else
                {
                    Cmd cmd = inputTextBox.Cmd;
                    //MessageBox.Show("path=" + cmd.path + "\r\n" + "arg=" + cmd.arg);
                    cmdListLogic.RunWithCmd(cmd);
                }

                // コマンド候補リストを更新する。
                UpdateCmdListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Cmd cmd = cmdListBox.SelectedCmd;
            CmdForm form = new CmdForm();
            form.SetCmd(cmd);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
            }
        }

        /// <summary>
        /// コントロール内へのドラッグ処理を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// コントロール内へのドロップ処理を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたすべてのファイル名を取得する
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // テキストボックスに表示する
            inputTextBox.AddFileList(fileName);
        }

    }
}
