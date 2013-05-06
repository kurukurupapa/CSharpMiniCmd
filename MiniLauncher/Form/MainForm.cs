using MiniLauncher.Logic;
using MiniLauncher.Model;
using System;
using System.Windows.Forms;

namespace MiniLauncher.Form
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private CmdFacade cmdFacade = new CmdFacade();
        private bool cmdListSelectMode = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // コマンド候補リストを更新する。
            cmdFacade.Update();
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
            cmdListBox.CmdList = cmdFacade.Find(inputTextBox.Text);
        }

        /// <summary>
        /// コマンドを実行する。
        /// </summary>
        private void Run()
        {
            try
            {
                // テキストボックス入力中の場合、入力テキストは、DB登録されていない可能性がある。
                // DB登録状態を確認し、必要ならDB登録する。
                if (!cmdListSelectMode)
                {
                    Cmd cmd = CmdFactory.CreateCmdWithCmdLine(inputTextBox.Text);
                    //MessageBox.Show("path=" + cmd.path + "\r\n" + "arg=" + cmd.arg);
                    cmdFacade.Save(cmd);
                }

                // コマンドの種類を判定して、実行する。
                switch (cmdListBox.SelectedCmd.type)
                {
                    case Cmd.CmdType.Execution:
                        new CmdDecorator(cmdListBox.SelectedCmd).Start();
                        break;
                    case Cmd.CmdType.Setting:
                        SettingForm form = new SettingForm();
                        form.ShowDialog();
                        break;
                }

                // テキストボックスやリストボックスを初期状態に戻す。
                inputTextBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// コントロール内へのドラッグ処理を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((string[])e.Data.GetData(DataFormats.FileDrop, false)).Length == 1)
            {
                //ドラッグされたデータ形式を調べ、ファイル/ディレクトリのときはコピーとする
                // １件のみを対象とする
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

            // コマンド登録フォームを表示する。
            CmdForm form = new CmdForm();
            form.Cmd = CmdFactory.CreateCmdWithPath(fileName[0]);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // DB登録する。
                cmdFacade.Save(form.Cmd);

                // テキストボックスに表示する
                inputTextBox.Text = form.Cmd.name;
            }
        }

    }
}
