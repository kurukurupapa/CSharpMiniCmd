using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DSOFile;
using System.Threading;
using IWshRuntimeLibrary;
using System.Reflection;

namespace MiniFileList
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            if (!Logic.ValidateDirectory(tbInDir.Text))
            {
                ShowErrorMessage(labelInDir.Text + "が不正です。");
                return;
            }

            if (!Logic.ValidateFile(tbOutFile.Text))
            {
                ShowErrorMessage(labelOutFile.Text + "が不正です。");
                return;
            }

            Thread thread = new Thread(new ThreadStart(StartThread));
            thread.IsBackground = true;
            thread.Start();
        }

        private void btnInDir_Click(object sender, EventArgs e)
        {
            // 既に入力済みの値があれば、それをダイアログのデフォルト値とする。
            if (!string.IsNullOrEmpty(tbInDir.Text))
            {
                dlgInDir.SelectedPath = tbInDir.Text;
            }

            if (dlgInDir.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            tbInDir.Text = dlgInDir.SelectedPath;
        }

        private void btnExclusionAdd_Click(object sender, EventArgs e)
        {
            if (dlgInDir.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            lboxExclusion.Items.Add(dlgInDir.SelectedPath);
        }

        private void btnExclusionDel_Click(object sender, EventArgs e)
        {
            // 除外フォルダリストが未選択なら何もしない
            if (lboxExclusion.SelectedIndex < 0)
            {
                return;
            }

            lboxExclusion.Items.RemoveAt(lboxExclusion.SelectedIndex);
        }

        private void btnOutFile_Click(object sender, EventArgs e)
        {
            if (dlgOutFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            tbOutFile.Text = dlgOutFile.FileName;
        }

        private void StartThread()
        {
            DirectoryInfo inDirInfo = new DirectoryInfo(tbInDir.Text);
            FileInfo outFileInfo = new FileInfo(tbOutFile.Text);

            //using (StreamWriter sw = new StreamWriter(outFileInfo.OpenWrite()))
            using (StreamWriter sw = outFileInfo.CreateText())
            {
                WriteHeader(sw);
                SearchFolder(sw, inDirInfo);
            }

            SetInfo("");
            ShowInformationMessage("完了");
        }

        private delegate void SetInfoDelegate(string msg);
        private void SetInfo(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new SetInfoDelegate(SetInfo), new object[] { msg });
                return;
            }

            labelStatus.Text = msg;
        }

        private void SearchFolder(StreamWriter sw, DirectoryInfo targetDir)
        {
            // 対象ディレクトリが除外ディレクトリなら何もしない
            if (IsExclusionDir(targetDir))
            {
                return;
            }

            // 下位ディレクトリを検索
            DirectoryInfo[] dirs = targetDir.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                SearchFolder(sw, dir);
            }

            // 処理フォルダをユーザへ通知
            SetInfo(targetDir.FullName);

            // ファイル処理
            foreach (FileInfo file in targetDir.GetFiles())
            {
                WriteFileInfo(sw, file);
            }
        }

        private bool IsExclusionDir(DirectoryInfo dir)
        {
            foreach (string item in lboxExclusion.Items)
            {
                if (dir.FullName.StartsWith(item))
                {
                    return true;
                }
            }
            return false;
        }

        private void WriteFileInfo(StreamWriter sw, FileInfo fileInfo)
        {
            OutLineBuilder line = new OutLineBuilder();

            line.AddColumn(fileInfo.FullName);
            line.AddColumn(fileInfo.Length);
            line.AddColumn(fileInfo.LastWriteTime);

            OleDocumentProperties props = null;
            try
            {
                props = new OleDocumentProperties();
                props.Open(fileInfo.FullName, true, dsoFileOpenOptions.dsoOptionDefault);
                SummaryProperties summaryProps = props.SummaryProperties;
                line.AddColumn(summaryProps.Title);
                line.AddColumn(summaryProps.Subject);
                line.AddColumn(summaryProps.Category);
                line.AddColumn(summaryProps.Keywords);
                line.AddColumn(summaryProps.Comments);
                line.AddColumn(summaryProps.Author);
                line.AddColumn(summaryProps.LastSavedBy);
                line.AddColumn(summaryProps.RevisionNumber);
                line.AddColumn(summaryProps.Company);
                line.AddColumn(summaryProps.Version);
                line.AddColumn(summaryProps.Manager);
                line.AddColumn(summaryProps.Template);
            }
            catch (Exception e)
            {
                line.AddColumn(e.Message);
            }
            finally
            {
                if (props != null)
                {
                    props.Close(false);
                }
            }

            sw.WriteLine(line.ToString());
        }

        private void WriteHeader(StreamWriter sw)
        {
            OutLineBuilder line = new OutLineBuilder();

            line.AddColumn("Path");
            line.AddColumn("Size");
            line.AddColumn("LastWriteTime");

            line.AddColumn("Title");
            line.AddColumn("Subject");
            line.AddColumn("Category");
            line.AddColumn("Keywords");
            line.AddColumn("Comments");
            line.AddColumn("Author");
            line.AddColumn("LastSavedBy");
            line.AddColumn("RevisionNumber");
            line.AddColumn("Company");
            line.AddColumn("Version");
            line.AddColumn("DigitalSignature");
            line.AddColumn("Manager");
            line.AddColumn("Template");

            sw.WriteLine(line.ToString());
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            lboxExclusion.Items.Clear();

            cboxSendToShortcut.Checked = Properties.Settings.Default.SendToShortCutFlag;

            // コマンドラインを配列で取得する
            // 配列の1つ目には、当実行ファイル名が設定される
            string[] args = Environment.GetCommandLineArgs();

            // コマンドライン引数からファイルパスを取り出す
            if (args.Length > 1)
            {
                tbInDir.Text = args[1];
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.InDir = tbInDir.Text;
            Properties.Settings.Default.OutFile = tbOutFile.Text;
            Properties.Settings.Default.SendToShortCutFlag = cboxSendToShortcut.Checked;

            // 送るフォルダのショートカット設定
            string sendtoDir = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            string sendtoPath = Path.Combine(sendtoDir, Properties.Settings.Default.AppName + ".lnk");
            if (cboxSendToShortcut.Checked)
            {
                if (!System.IO.File.Exists(sendtoPath))
                {
                    IWshShell shell = new WshShellClass();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(sendtoPath);
                    shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                    shortcut.Description = Properties.Settings.Default.AppName + "を起動します。";
                    shortcut.Save();
                }
            }
            else
            {
                if (System.IO.File.Exists(sendtoPath))
                {
                    System.IO.File.Delete(sendtoPath);
                }
            }
        }

        private void ShowInformationMessage(string msg)
        {
            MessageBox.Show(msg, Properties.Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string msg)
        {
            MessageBox.Show(msg, Properties.Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
