using System;
using System.IO;
using System.Windows.Forms;

namespace MiniBackup
{
    class BackupService
    {
        public void Backup(string[] srcList, string targetDir, bool completeMsgFlag)
        {
            string msg = "";

            foreach (string src in srcList)
            {
                try
                {
                    this.Backup(src, targetDir);
                }
                catch (Exception ex)
                {
                    // 1件ごとにエラーを表示し、正常処理に復帰する。
                    MessageBox.Show(ex.Message, Properties.Settings.Default.AppName);
                }

                msg += src + "\r\n";
            }

            // 完了メッセージを表示する
            if (completeMsgFlag)
            {
                MessageBox.Show("バックアップが完了しました。\r\n" + msg, Properties.Settings.Default.AppName);
            }
        }

        public void Backup(string src, string targetDir) {
            FilePath destPath = new FilePath();
            destPath.SetPath(src);
            destPath.AddTimeStamp();
            if (targetDir != null && targetDir.Length > 0)
            {
                destPath.MoveDir(targetDir);
            }

            Directory.CreateDirectory(destPath.dir);
            Copy(src, destPath.GetPath());

            Console.WriteLine("BackupService.Backup: src=[" + src + "]");
            Console.WriteLine("BackupService.Backup: dest=[" + destPath.GetPath() + "]");
        }

        private void Copy(string src, string dest)
        {
            if ((File.GetAttributes(src) & FileAttributes.Directory) != 0)
            {
                Directory.CreateDirectory(dest);

                foreach (string dir in Directory.GetDirectories(src))
                {
                    Copy(dir, Path.Combine(dest, Path.GetFileName(dir)));
                }

                foreach (string path in Directory.GetFiles(src))
                {
                    Copy(path, Path.Combine(dest, Path.GetFileName(path)));
                }
            }
            else
            {
                File.Copy(src, dest);
            }
        }
    }
}
