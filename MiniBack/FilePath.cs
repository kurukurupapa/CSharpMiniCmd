using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiniBackup
{
    class FilePath
    {
        // ディレクトリ
        // 末尾"\\"含まない
        public string dir = null;

        // ファイル名
        // 拡張子なし
        public string baseName = null;

        // 拡張子
        // "."含む
        public string ext = null;

        public void SetPath(string filePath)
        {
            dir = Path.GetDirectoryName(filePath);
            baseName = Path.GetFileNameWithoutExtension(filePath);
            ext = Path.GetExtension(filePath);
        }

        public string GetPath()
        {
            return Path.Combine(dir, baseName + ext);
        }

        public void AddTimeStamp()
        {
            baseName += "." + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "bk";
        }

        public void MoveDir(string targetDir)
        {
            if (targetDir.IndexOf(":") > 0)
            {
                // 絶対ディレクトリ
                dir = Path.Combine(targetDir, dir.Replace(":", ""));
            }
            else
            {
                // 相対ディレクトリ
                dir = Path.Combine(dir, targetDir);
            }
        }
    }
}
