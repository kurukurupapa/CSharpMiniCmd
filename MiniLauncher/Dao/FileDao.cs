using MiniLauncher.Model;
using System.Collections.Generic;
using System.IO;

namespace MiniLauncher
{
    /// <summary>
    /// ファイルにアクセスするクラスです。
    /// </summary>
    public class FileDao
    {
        /// <summary>
        /// Path環境変数で指定されたフォルダ配下のコマンドリストを取得する。
        /// </summary>
        /// <returns></returns>
        public List<Cmd> GetPathEnvList()
        {
            List<Cmd> list = new List<Cmd>();

            string pathEnv = System.Environment.GetEnvironmentVariable("Path");

            // Path環境変数に同じディレクトリが複数登録されいる可能性を考慮し、重複を除外する。
            HashSet<string> hashSet = new HashSet<string>();
            foreach (string dir in pathEnv.Split(';'))
            {
                hashSet.Add(dir);
            }

            // Path環境変数で指定されたディレクトリについて、実行ファイルを取得する。
            foreach (string dir in hashSet)
            {
                list.AddRange(GetFileCmdList(dir, "*.com"));
                list.AddRange(GetFileCmdList(dir, "*.bat"));
                list.AddRange(GetFileCmdList(dir, "*.exe"));
            }
            return list;
        }

        public List<Cmd> GetFileCmdList(string dir)
        {
            return GetFileCmdList(dir, null);
        }

        public List<Cmd> GetFileCmdList(string dir, string pattern)
        {
            List<Cmd> list = new List<Cmd>();

            if (!Directory.Exists(dir))
            {
                return list;
            }

            List<string> exeList = new List<string>();
            if (pattern == null)
            {
                exeList.AddRange(Directory.GetFiles(dir));
            }
            else
            {
                exeList.AddRange(Directory.GetFiles(dir, pattern));
            }

            foreach (string path in exeList)
            {
                Cmd command = new ExecutionCmd();
                //command.name = Path.GetFileName(path);
                command.name = path;
                //command.type = Cmd.CommandType.Execution;
                command.path = path;
                command.arg = "";
                list.Add(command);
            }

            return list;
        }

        /// <summary>
        /// MiniCmdシリーズのコマンドリストを取得する。
        /// カレントフォルダ配下の実行ファイルをMiniCmdシリーズのコマンドとして判断する。
        /// </summary>
        /// <returns>コマンドリスト</returns>
        public List<Cmd> GetMiniCmdList()
        {
            List<Cmd> list = new List<Cmd>();
            foreach (Cmd cmd in GetFileCmdList(Directory.GetCurrentDirectory()))
            {
                // TODO 自分自身を除外する
                list.Add(cmd);
            }
            return list;
        }
    }
}
