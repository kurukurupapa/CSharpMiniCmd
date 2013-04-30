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
using System.Diagnostics;
using System.Threading;
using IWshRuntimeLibrary;
using System.Reflection;
using System.Collections;

namespace MiniFilePropChanger
{
    public partial class MainForm : Form
    {
        private ProgressForm progressForm = new ProgressForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddDirectory(string dir)
        {
            foreach (string subdir in Directory.GetDirectories(dir))
            {
                AddDirectory(subdir);
            }
            foreach (string path in Directory.GetFiles(dir))
            {
                AddFile(path);
            }
        }

        private void AddFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Utils.ShowErrorMessage("ファイルが見つかりません。\r\n"
                    + "ファイル=" + path);
                return;
            }

            FileDataSet.FilePropertiesRow row =
                fileDataSet.FileProperties.NewRow() as FileDataSet.FilePropertiesRow;

            FileInfo fileInfo = new FileInfo(path);
            row.Name = fileInfo.FullName;
            row.Size = fileInfo.Length;
            //row.CreationTime = fileInfo.CreationTime;
            row.LastWriteTime = fileInfo.LastWriteTime;

            OleDocumentProperties props = null;
            try
            {
                // 書き込み用で開くけど、ここでは何もしない
                // 後続処理で、書き込み出来ることを前提とするため
                props = new OleDocumentProperties();
                props.Open(fileInfo.FullName, false, dsoFileOpenOptions.dsoOptionDefault);
                SummaryProperties summaryProps = props.SummaryProperties;

                row.SummaryPropsFlag = true;
                row.SummaryPropsAuthor = summaryProps.Author;
                row.SummaryPropsCategory = summaryProps.Category;
                row.SummaryPropsComments = summaryProps.Comments;
                row.SummaryPropsCompany = summaryProps.Company;
                row.SummaryPropsKeywords = summaryProps.Keywords;
                row.SummaryPropsLastSavedBy = summaryProps.LastSavedBy;
                row.SummaryPropsManager = summaryProps.Manager;
                row.SummaryPropsRevisionNumber = summaryProps.RevisionNumber;
                row.SummaryPropsSubject = summaryProps.Subject;
                row.SummaryPropsTemplate = summaryProps.Template;
                row.SummaryPropsTitle = summaryProps.Title;
                row.SummaryPropsVersion = summaryProps.Version;
            }
            catch (Exception e)
            {
                row.SummaryPropsFlag = false;
                row.SummaryPropsAuthor = "(取得不可)";
                row.SummaryPropsCategory = "(取得不可)";
                row.SummaryPropsComments = "(取得不可)";
                row.SummaryPropsCompany = "(取得不可)";
                row.SummaryPropsKeywords = "(取得不可)";
                row.SummaryPropsLastSavedBy = "(取得不可)";
                row.SummaryPropsManager = "(取得不可)";
                row.SummaryPropsRevisionNumber = "(取得不可)";
                row.SummaryPropsSubject = "(取得不可)";
                row.SummaryPropsTemplate = "(取得不可)";
                row.SummaryPropsTitle = "(取得不可)";
                row.SummaryPropsVersion = "(取得不可)";
            }
            finally
            {
                if (props != null)
                {
                    props.Close(false);
                }
            }

            AddFilePropertiesRow(row);

            // 変更を確定する
            // グリッドにレコード追加後でないと例外発生する
            row.AcceptChanges();
        }

        private delegate void AddFilePropertiesRowDelegate(FileDataSet.FilePropertiesRow row);
        private void AddFilePropertiesRow(FileDataSet.FilePropertiesRow row)
        {
            if (InvokeRequired)
            {
                Invoke(new AddFilePropertiesRowDelegate(AddFilePropertiesRow), new object[]{ row });
                return;
            }
            fileDataSet.FileProperties.Rows.Add(row);
        }

        private void UpdateFileProperties(FileDataSet.FilePropertiesRow row)
        {
            FileInfo fileInfo = new FileInfo(row.Name);

            if (row.SummaryPropsFlag)
            {
                OleDocumentProperties props = null;
                try
                {
                    props = new OleDocumentProperties();
                    props.Open(fileInfo.FullName, false, dsoFileOpenOptions.dsoOptionDefault);
                    SummaryProperties summaryProps = props.SummaryProperties;

                    summaryProps.Author = row.SummaryPropsAuthor;
                    summaryProps.Category = row.SummaryPropsCategory;
                    summaryProps.Comments = row.SummaryPropsComments;
                    summaryProps.Company = row.SummaryPropsCompany;
                    summaryProps.Keywords = row.SummaryPropsKeywords;
                    summaryProps.LastSavedBy = row.SummaryPropsLastSavedBy;
                    summaryProps.Manager = row.SummaryPropsManager;
                    //summaryProps.RevisionNumber = row.SummaryPropsRevisionNumber;
                    summaryProps.Subject = row.SummaryPropsSubject;
                    //summaryProps.Template = row.SummaryPropsTemplate;
                    summaryProps.Title = row.SummaryPropsTitle;
                    //summaryProps.Version = row.SummaryPropsVersion;

                    props.Save();
                }
                catch (Exception e)
                {
                    Utils.ShowErrorMessage("プロパティの変更に失敗しました。\r\n"
                        + "ファイル=" + row.Name + "\r\n"
                        + "エラー詳細=" + e.Message);
                    return;
                }
                finally
                {
                    if (props != null)
                    {
                        props.Close(false);
                    }
                }
            }

            // 変更を確定する
            row.AcceptChanges();
        }

        private void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                OutLineBuilder line;

                line = new OutLineBuilder();
                foreach (DataGridViewColumn column in gviewFiles.Columns)
                {
                    line.AddColumn(column.HeaderText);
                }
                sw.WriteLine(line.ToString());

                foreach (DataGridViewRow row in gviewFiles.Rows)
                {
                    line = new OutLineBuilder();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        line.AddColumn(cell.Value.ToString());
                    }
                    sw.WriteLine(line.ToString());
                }
            }

            //Utils.ShowInformationMessage("ファイル保存完了");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Text = Properties.Resources.AppName;
            cboxSendToShortcut.Checked = Properties.Settings.Default.SendToShortcutFlag;

            // コマンドラインを配列で取得する
            // 配列の1つ目には、当実行ファイル名が設定される
            string[] args = Environment.GetCommandLineArgs();
            // コマンドライン引数からファイルパスを取り出す
            for (int i = 1; i < args.Length; i++)
            {
                AddFile(args[i]);
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (dlgAddFolderBrowser.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            progressForm.SetBackgroundWorker(addFolderBackgroundWorker);
            progressForm.ShowDialog();
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (dlgAddOpenFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            progressForm.SetBackgroundWorker(addFileBackgroundWorker);
            progressForm.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gviewFiles.SelectedRows)
            {
                // グリッドで選択されているファイル名を取得する
                string name = row.Cells[0].Value.ToString();

                // データソースから該当するファイルを削除する
                DataRow[] rows = fileDataSet.FileProperties.Select("Name='" + name + "'");
                foreach (DataRow dataRow in rows)
                {
                    dataRow.Delete();
                    dataRow.AcceptChanges();
                }
            }
        }

        private void btnFileSelectForm_Click(object sender, EventArgs e)
        {
            FileSelectForm form = new FileSelectForm();

            // 初期データを設定する
            int i = 0;
            form.files = new string[fileDataSet.FileProperties.Rows.Count];
            foreach (FileDataSet.FilePropertiesRow row in fileDataSet.FileProperties.Rows)
            {
                form.files[i] = row.Name;
                i++;
            }

            // ダイアログ表示
            // キャンセルされたら何もしない
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // データを初期化する
            fileDataSet.FileProperties.Rows.Clear();

            // 追加する
            foreach (string path in form.files)
            {
                if (!string.IsNullOrEmpty(path.Trim()))
                {
                    AddFile(path);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Save(dlgSaveFile.FileName);
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            progressForm.SetBackgroundWorker(execBackgroundWorker);
            progressForm.ShowDialog();
        }

        private void addFileBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            addFileBackgroundWorker.ReportProgress(0, "追加中（" + dlgAddOpenFile.FileName + "）");
            AddFile(dlgAddOpenFile.FileName);
        }

        private void addFolderBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            addFolderBackgroundWorker.ReportProgress(0, "追加中（" + dlgAddFolderBrowser.SelectedPath + "）");
            AddDirectory(dlgAddFolderBrowser.SelectedPath);
        }

        private void execBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            execBackgroundWorker.ReportProgress(0, "反映中");
            foreach (FileDataSet.FilePropertiesRow row in fileDataSet.FileProperties.Rows)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    UpdateFileProperties(row);
                }
            }
        }

        private delegate void RunWorkerCompletedDelegate(object sender, RunWorkerCompletedEventArgs e);
        private void execBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new RunWorkerCompletedDelegate(execBackgroundWorker_RunWorkerCompleted), new object[] { sender, e });
                return;
            }

            progressForm.SetMessage(string.Empty);
            progressForm.Close();
            Refresh();
        }

        private delegate void ProgressChangedDelegate(object sender, ProgressChangedEventArgs e);
        private void execBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new ProgressChangedDelegate(execBackgroundWorker_ProgressChanged), new object[] { sender, e });
                return;
            }

            progressForm.SetMessage(e.UserState as string);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SendToShortcutFlag = cboxSendToShortcut.Checked;

            // 送るフォルダのショートカット設定
            string sendtoDir = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            string sendtoPath = Path.Combine(sendtoDir, Properties.Resources.AppId + ".lnk");
            if (cboxSendToShortcut.Checked)
            {
                if (!System.IO.File.Exists(sendtoPath))
                {
                    IWshShell shell = new WshShellClass();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(sendtoPath);
                    shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                    shortcut.Description = Properties.Resources.AppName + "を起動します。";
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
    }
}
