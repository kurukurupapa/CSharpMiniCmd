using MiniLauncher.Model;
using System.Collections.Generic;
using System.Diagnostics;

namespace MiniLauncher.Logic
{
    internal class CmdFacade
    {
        private List<Cmd> cmdList = new List<Cmd>();
        private FileDao fileDao = new FileDao();
        private DbDao dbDao = new DbDao();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        internal CmdFacade()
        {
            // 処理なし
        }

        /// <summary>
        /// コマンドリストを取得する。
        /// </summary>
        /// <returns></returns>
        internal List<Cmd> FindAll()
        {
            return cmdList;
        }

        /// <summary>
        /// コマンドリストを抽出する。
        /// </summary>
        /// <param name="keyword">キーワード</param>
        /// <returns></returns>
        internal List<Cmd> Find(string keyword)
        {
            // キーワードが空の場合、全コマンドリストを返却する。
            if (string.IsNullOrEmpty(keyword))
            {
                return FindAll();
            }

            List<Cmd> list = new List<Cmd>();

            // キーワードをディレクトリパスと見なしてファイルを検索する。
            list.AddRange(fileDao.GetFileCmdList(keyword));

            // コマンドリストからキーワードに該当するコマンドを抽出する。
            keyword = keyword.ToUpper();
            foreach (Cmd cmd in cmdList)
            {
                if (cmd.name.ToUpper().Contains(keyword))
                {
                    list.Add(cmd);
                }
            }

            return list;
        }

        /// <summary>
        /// リストを更新する。
        /// </summary>
        internal void Update()
        {
            cmdList.Clear();
            cmdList.AddRange(dbDao.GetDbList());
            cmdList.AddRange(fileDao.GetPathEnvList());
            cmdList.AddRange(fileDao.GetMiniCmdList());
            cmdList.AddRange(GetAppList());
        }

        private List<Cmd> GetAppList()
        {
            List<Cmd> list = new List<Cmd>();
            Cmd cmd = CmdFactory.CreateSettingCmd();
            return list;
        }

        /// <summary>
        /// 引数のコマンドがDB未登録なら、登録する。
        /// </summary>
        /// <param name="cmd"></param>
        internal void Save(Cmd cmd)
        {
            if (!Contains(cmdList, cmd))
            {
                cmdList.Add(cmd);
                dbDao.InsertCmd(cmd);
            }
        }

        private bool Contains(List<Cmd> cmdList, Cmd targetCmd)
        {
            bool result = false;

            foreach (Cmd cmd in cmdList)
            {
                if (cmd.EqualsCmdLine(targetCmd))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
