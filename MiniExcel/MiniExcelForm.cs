using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;
using System.Reflection;

namespace MiniExcel
{
    public partial class MiniExcelForm : Form
    {
        public MiniExcelForm()
        {
            InitializeComponent();
        }

        private void MiniExcelForm_Shown(object sender, EventArgs e)
        {
            Console.WriteLine("----- MiniExcelForm_Shown -----");

            // 設定ファイルを読み込む
            comboBoxFormat.Text = Properties.Settings.Default.FormatType;
            checkBoxFileName.Checked = Properties.Settings.Default.FileNameOutput;
            checkBoxSheetName.Checked = Properties.Settings.Default.SheetNameOutput;
            checkBoxLineNo.Checked = Properties.Settings.Default.LineNoOutput;
            chkCompleteMsg.Checked = Properties.Settings.Default.CompleteMsg;
            chkSendToShortcut.Checked = Properties.Settings.Default.SendToShortcut;

            // コマンドラインを配列で取得する
            // 配列の1つ目には、当実行ファイル名が設定される
            string[] args = Environment.GetCommandLineArgs();

            //コマンドライン引数のデバッグ出力
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }

            // コマンドライン引数からファイルパスを取り出す
            string[] pathArr = new string[args.Length - 1];
            for (int i = 0; i < args.Length - 1; i++)
            {
                pathArr[i] = args[i + 1];
            }

            // 引数にファイルパスが存在したら、処理を行い、プログラムを終了する。
            if (pathArr.Length >= 1)
            {
                this.Process(pathArr);
                this.Close();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----- buttonOk_Click -----");

            // 設定ファイルを保存する
            Properties.Settings.Default.FormatType = comboBoxFormat.Text;
            Properties.Settings.Default.FileNameOutput = checkBoxFileName.Checked;
            Properties.Settings.Default.SheetNameOutput = checkBoxSheetName.Checked;
            Properties.Settings.Default.LineNoOutput = checkBoxLineNo.Checked;
            Properties.Settings.Default.CompleteMsg = chkCompleteMsg.Checked;
            Properties.Settings.Default.SendToShortcut = chkSendToShortcut.Checked;
            Properties.Settings.Default.Save();
            Console.WriteLine("設定ファイル保存完了");

            // 送るフォルダのショートカット設定
            string sendtoDir = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            string sendtoPath = Path.Combine(sendtoDir, Properties.Settings.Default.ShortcutName);
            if (chkSendToShortcut.Checked)
            {
                if (!System.IO.File.Exists(sendtoPath))
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----- buttonCancel_Click -----");
            this.Close();
        }

        private void Process(string[] pathArr)
        {
            ExcelService service = new ExcelService();
            if ("CSV".Equals(comboBoxFormat.Text))
            {
                service.separator = ",";
                service.fileExt = ".csv";
            }
            else if ("TSV".Equals(comboBoxFormat.Text))
            {
                service.separator = "\t";
                service.fileExt = ".tsv";
            }
            service.fileNameOutputFlag = checkBoxFileName.Checked;
            service.sheetNameOutputFlag = checkBoxSheetName.Checked;
            service.lineNoOutputFlag = checkBoxLineNo.Checked;
            service.completeMsgFlag = chkCompleteMsg.Checked;
            service.OutputTextFile(pathArr);
        }
    }
}
