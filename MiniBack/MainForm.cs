using System;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;
using System.Reflection;

namespace MiniBackup
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Console.WriteLine("----- frmMain_Shown -----");

            // 設定ファイルを読み込む
            string backupDir = Properties.Settings.Default.BackupDir;
            if (backupDir.Length <= 0 || backupDir.Equals("."))
            {
                rdbSameDir.Checked = true;
            }
            else
            {
                rdbSpecifiedDir.Checked = true;
                txtSpecifiedDir.Text = backupDir;
            }
            chkCompleteMsg.Checked = Properties.Settings.Default.CompleteMsg;
            chkSendToShortcut.Checked = Properties.Settings.Default.SendToShortcut;

            // コマンドラインを配列で取得する
            // 配列の1つ目には、当実行ファイル名が設定される
            string[] args = Environment.GetCommandLineArgs();

            //コマンドライン引数の表示
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }

            // コマンドライン引数からファイルパスを取り出す
            string[] pathArr = new string[args.Length - 1];
            for (int i = 0; i < args.Length - 1; i++) {
                pathArr[i] = args[i + 1];
            }

            // 引数にファイルパスが存在したら、バックアップ処理を行い、
            // プログラムを終了する。
            if (pathArr.Length >= 1)
            {
                this.Backup(pathArr);
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----- btnOk_Click -----");

            // 設定ファイルを保存する
            Properties.Settings.Default.BackupDir = txtSpecifiedDir.Text;
            Properties.Settings.Default.CompleteMsg = chkCompleteMsg.Checked;
            Properties.Settings.Default.SendToShortcut = chkSendToShortcut.Checked;
            Properties.Settings.Default.Save();
            Console.WriteLine("設定ファイル保存完了");

            // 送るフォルダのショートカット設定
            string sendtoDir = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            string sendtoPath = Path.Combine(sendtoDir, Properties.Settings.Default.ShortcutName);
            if (chkSendToShortcut.Checked)
            {
                if (! System.IO.File.Exists(sendtoPath))
                {
                    IWshShell shell = new WshShellClass();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(sendtoPath);
                    shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                    shortcut.Description = Properties.Settings.Default.AppName + "を起動します。";
                    shortcut.Save();

                    Console.WriteLine("ショートカットファイル[" + sendtoPath + "]を作成しました。");
                }
            }
            else
            {
                if (System.IO.File.Exists(sendtoPath))
                {
                    System.IO.File.Delete(sendtoPath);
                    Console.WriteLine("ショートカットファイル[" + sendtoPath + "]を削除しました。");
                }
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----- btnCancel_Click -----");
            this.Close();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("----- frmMain_DragEnter -----");

            // ファイルのドロップのみ許可する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("----- frmMain_DragDrop -----");

            // ドロップされたファイル名
            // 絶対パスで取得できる
            string[] pathArr = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // バックアップ
            this.Backup(pathArr);
        }

        private void Backup(string[] pathArr)
        {
            BackupService service = new BackupService();
            string dir = null;
            if (rdbSpecifiedDir.Checked)
            {
                dir = txtSpecifiedDir.Text;
            }
            service.Backup(pathArr, dir, chkCompleteMsg.Checked);
        }
    }
}
